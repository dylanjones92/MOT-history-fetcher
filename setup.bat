@echo off

cd MotHistoryFetcher

echo Setting up MOT History Fetcher...


REM Prompt for the API key
set /p API_KEY="Enter your API key: "

REM Create the .env file
echo MOT_HISTORY_API_KEY=%API_KEY% > .env

REM Restore NuGet packages
dotnet restore

REM Build the application
dotnet build

REM Run the application
start /B dotnet run

REM Wait a few seconds to ensure the server starts
timeout /t 5 /nobreak >nul

REM Open the default web browser
start http://localhost:5237

echo Setup complete. Your application is running.
pause
