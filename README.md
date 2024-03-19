# Customer Claims API

This project is an API for managing customer claims. It provides endpoints for retrieving, updating, and managing claims data.

The API is documented using Swagger, providing an interactive interface for exploring and testing the endpoints. 

Once the application is running, you can access the Swagger documentation by navigating to the appropriate URL in your browser.

Running the application requires an authenticated user, please use the user to login, which then provides a JWT Bearer token. 

Use the following credentials to login:

   - Username: string
   - Password: string

NOTE, by default, the [Authorize] attribute is commented out on both the Claims and Company controllers so that you cam test without the need for authentication. 

To test using authentication follow these steps:

1. Uncomment the [Authorize] attribute in the respective controllers.
2. Run the application 
3. From the Swagger UI select login from the User:
4. Enter the username and password default : string
5. After logging in, copy the provided JWT Bearer token (between the quotes) and paste it into the Authorise dialog.
6. Now test the enpoints

The application as I unit test with check to see we have one or more claims for companyId:1
