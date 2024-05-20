# MOT-history-fetcher
A webapp allowing users to request MOT history information for a given registration number via the https://beta.check-mot.service.gov.uk/ api

## Setup Instructions

1. **Clone the Repository**

    ```sh
        git clone https://github.com/dylanjones92/MOT-history-fetcher.git
        cd MOT-history-fetcher
    ```

2. **Run the setup script**

    - For Linux/macOS:
        ```sh
        chmod +x setup.sh
        ./setup.sh
        ```
    - For Windows:
        ```sh
        setup.bat
        ```

3. **Follow the prompt to enter you API key**
    
    The program will restore any dependencies, build and run

## Notes

- The `.env` file is used to store environment variables. Ensure you do not commit this file with sensitive information.

- background image is by Max Andrey. Source: https://www.pexels.com/photo/close-up-photo-of-gray-concrete-road-1197095/