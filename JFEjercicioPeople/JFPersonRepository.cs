using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFEjercicioPeople.Models;
using SQLite;

namespace JFEjercicioPeople;

public class JFPersonRepository
{
    string _dbPath;
    private SQLiteAsyncConnection conn;


    public string StatusMessage { get; set; }

    // TODO: Add variable for the SQLite connection

    private async Task Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteAsyncConnection(_dbPath);

        await conn.CreateTableAsync<JFPerson>();
    }

    public JFPersonRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public async Task AddNewPerson(string name)
    {
        int result = 0;
        try
        {
            // TODO: Call Init()
            await Init();

            // basic validation to ensure a name was entered
            if (string.IsNullOrEmpty(name))
                throw new Exception("Valid name required");

            // TODO: Insert the new person into the database
            // enter this line
            result = await conn.InsertAsync(new JFPerson { Name = name });

            StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
        }

    }

    public async Task<List<JFPerson>> GetAllPeople()
    {
        try
        {
            await Init();
            return await conn.Table<JFPerson>().ToListAsync();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<JFPerson>();
    }
}
