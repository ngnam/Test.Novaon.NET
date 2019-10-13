### Add migrations
```
 Add-Migration "AddNewTable" -c AppDataContext -o Data/Migrations
 Update-Database -Migration <migration name> -c "AppDataContext" 
 Update-Database -c "AppDataContext" 