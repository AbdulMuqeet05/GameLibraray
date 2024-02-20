Here I have create game library with with feature of adding viewing and deleting the game 
Developemnt stack:
mysql database , connection string is in the appsetting.json
backend is in .Net core
frontend is in Vue.js


To run the project
for backend:
1) go into the main folder where there us a GameLibrary.csproj file
2) run command dotnet restore
3) run dotnet ef migrations add initial
4) run dotnet ef database update
5) run dotnet run


For front end :
go into the ClientApp folder
1) npm install
2) npm run dev