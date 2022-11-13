# .NET 7 Minimal API - QuickStart

Quickly clone this repository to get a .NET 7 [minimal API](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-7.0) which:

1. Has a basic set of endpoints
1. Produces OpenApi Explorer
1. Has dependency injection usage examples ([\[FromServices\]](./BasicWebApi/Endpoints/HostInfoEndpoints.cs#L21))
1. Demonstrates deprecated API ([GetHostInfo2](./BasicWebApi/Endpoints/HostInfoEndpoints.cs#L13))
1. Docker container support
1. Has a basic Filter added ([ExceptionFilter](./BasicWebApi/Filters/ExceptionFilter.cs))
1. devcontainer configured - only need container runtime, not dotnet locally installed (TODO)
1. Has GitHub actions to build a container (TODO)
1. Has a Client generator (TODO)
1. [Versioned API](https://github.com/dotnet/aspnet-api-versioning/blob/3857a332057d970ad11bac0edfdbff8a559a215d/examples/AspNetCore/WebApi/MinimalOpenApiExample/Program.cs) built-in (TODO)
1. Has optional [authentication/authorization](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/security?view=aspnetcore-7.0) with Azure AD (TODO)

## Build & Run Docker container

```bash
docker build -t dotnet-basic-webapi:latest .
docker run --rm -p 5080:80 dotnet-basic-webapi:latest
open http://localhost:5080/swagger/
```

## Renaming from template:

_zsh_ :

```bash
TEMPLATENAME="dotnet-basic-webapi"
NEWNAME="ClonedWebApi"
git clone https://github.com/mitch-b/dotnet-basic-webapi $NEWNAME
# update filenames

find "$NEWNAME" -type f -name "$TEMPLATENAME*" | sed "p;s/$TEMPLATENAME/$NEWNAME/g" | xargs -L2 echo mv
# update namespaces

sed -i -- 's/$TEMPLATENAMESPACE/$NEWNAMESPACE/g' **/*(D.)
```

_PowerShell_ :

```powershell
# TODO
```

_Bash_ :

```bash
# TODO
```