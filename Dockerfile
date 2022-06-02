#Another stage that is all about running the application or how to run
from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

workdir /app
#Remove the copy instruction here

#Copy the publish folder into the image
copy /publish ./

#Change from CMD to entrypoint
entrypoint ["dotnet", "PokeApi.dll"]

#Change port to 5000
expose 5000

#Add new environment to change ASP.NET app to listen to 5000 port
env ASPNETCORE_URLS=http://+:5000
