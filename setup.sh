#!/bin/bash

cd MotHistoryFetcher

echo "Setting up MOT History Fetcher..."

# Prompt for the API key
read -p "Enter your API key: " API_KEY

# Create the .env file
echo "MOT_HISTORY_API_KEY=$API_KEY" > .env

# Restore NuGet packages
dotnet restore

# Build the application
dotnet build

# Run the application
dotnet run &

# Wait a few seconds to ensure the server starts
sleep 5

# Open the default web browser
if which xdg-open > /dev/null
then
  xdg-open http://localhost:5237
elif which gnome-open > /dev/null
then
  gnome-open http://localhost:5237
elif which open > /dev/null
then
  open http://localhost:5237
else
  echo "Could not detect the web browser to open. Please open http://localhost:5237 manually."
fi

echo "Setup complete. Your application is running."