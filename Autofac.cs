public interface IDatabase
{
}

public class SqlDatabase : IDatabase 
{ 
} 

public class OracleDatabase : IDatabase 
{   
}

public class DatabaseManager 
{ 
    IDatabase _database;

    public DatabaseManager(IDatabase database) 
    { 
        _database = database; 
    } 
}

var builder = new ContainerBuilder(); 
builder.RegisterType<DatabaseManager>(); 
builder.RegisterType<SqlDatabase>().As<IDatabase>();    

using (var container = builder.Build()) 
{ 
    var manager = container.Resolve<DatabaseManager>();   
    manager.Search("SELECT * FORM USER"); 
} 

builder.RegisterModule(new ConfigurationSettingsReader("autofac")); 