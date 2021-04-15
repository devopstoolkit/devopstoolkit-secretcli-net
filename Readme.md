# DevOpsToolkit.SenCli

Easily encrypt secrets:

- Encrypt a string with a key you provide in the configuration.

## Configuration

Change `config.json` file to you needs before you run the tool:

```json
{
    "EncryptionKey": "mykey"
}
```

## Build it yourself

```powershell
dotnet.exe publish --configuration Release --framework net5.0 --output Publish --self-contained True --runtime win-x64 --verbosity Normal /property:PublishTrimmed=True /property:PublishSingleFile=True /property:IncludeNativeLibrariesForSelfExtract=True /property:DebugType=None /property:DebugSymbols=False
```