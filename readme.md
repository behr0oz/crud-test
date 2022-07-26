# CRUD Code Test 

Feel free to add/change project structure to a clean architecture to your view.
and if you are not able to work on FrontEnd project, you can add a Swagger UI
in a new Front project.

simple CRUD application with ASP NET Core that implements the below model:
```
Customer {
	Firstname
	Lastname
	DateOfBirth
	PhoneNumber
	Email
	BankAccountNumber
}
```
## Practices and patterns:

- [DDD](https://en.wikipedia.org/wiki/Domain-driven_design)
- [Clean architecture](https://github.com/jasontaylordev/CleanArchitecture)
- [CQRS](https://en.wikipedia.org/wiki/Command%E2%80%93query_separation#Command_query_responsibility_separation) pattern 
- Clean git commits
- Blazor Web.
- Docker-compose project will loads database service automatically with `docker-compose up`
- 
### Validations 

- During Create; valid *mobile* number only (used [Google LibPhoneNumber](https://github.com/google/libphonenumber) to validate number at the backend).

- Validate email and bank account number before submitting the form.

- Customers are unique in database: By `Firstname`, `Lastname` and `DateOfBirth`.

- Email is unique in the database.

