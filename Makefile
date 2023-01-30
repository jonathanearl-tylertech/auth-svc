.Phony: db-migrations-add db-migrations-remove db-drop db-update

MIGRATION?="initial"
WEBAPI_PROJECT?="./src/WebApi/WebApi.csproj"

build:
	dotnet build $(WEBAPI_PROJECT)

clean:
	dotnet clean $(WEBAPI_PROJECT)

db-migrations-add:
	cd src/Infrastructure; dotnet ef migrations add $(MIGRATION) -s "../WebApi/WebApi.csproj"

db-migrations-remove:
	cd src/Infrastructure; dotnet ef migrations remove -s "../WebApi/WebApi.csproj"

db-update:
	dotnet ef database update --startup-project $(WEBAPI_PROJECT)

db-drop:
	dotnet ef database drop --startup-project $(WEBAPI_PROJECT)
