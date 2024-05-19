# MOT-history-fetcher
A webapp allowing users to request MOT history information for a given registration number via the check-mot api

## Setting Up Environment Variables

To run this project, you need to configure environment variables to securely manage sensitive information like API keys. This project uses a .env file to store environment variables locally.

### Step-by-Step Guide

1. **Clone the Repository**

```sh
    git clone https://github.com/dylanjones92/MOT-history-fetcher.git
    cd MOT-history-fetcher
```

2. **Create a `.env` File**

    In the root directory of the project, create a file named `.env`.

    ```sh
    touch .env
    ```

3. **Add Your Environment Variables**

    Open the `.env` file in a text editor and add your environment variables as below, filling in the base url and api key for the check-mot.service api

    ```plaintext
    # .env
    MOT_HISTORY_BASE_URL=base-api-url
    MOT_HISTORY_API_KEY=api-key
    ```

4. **Install Dependencies**

    Restore the .NET project dependencies:

    ```sh
    dotnet restore
    ```

5. **Run the Application**

    To run the application, use the following command:

    ```sh
    dotnet run
    ```

    This will start the application and it will read the environment variables from the `.env` file.

### Additional Notes

- **.gitignore**: Ensure that the `.env` file is listed in your `.gitignore` to prevent it from being committed to your repository.

    ```plaintext
    # .gitignore
    .env
    ```