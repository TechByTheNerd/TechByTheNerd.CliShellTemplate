Write-Host "[*] Cleaning environment..."
dotnet clean

Write-Host "[*] Restoring dependencies..."
dotnet restore

Write-Host "[*] Building the project..."
dotnet build

Write-Host "[*] Run tests with coverage..."
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov