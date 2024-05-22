#!/bin/bash

echo "[*] Cleaning environment..."
dotnet clean

echo "[*] Restoring dependencies..."
dotnet restore

echo "[*] Building the project..."
dotnet build

echo "[*] Run tests with coverage..."
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov