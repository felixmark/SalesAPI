# SalesAPI
This is a simple C# REST API for storing sold items with POST requests and getting information about the items with GET requests.

Routes are:
```
/api              - Documentation of the API.
/api/sold         - POST a new sold item (see documentation for the format) 
/api/swagger      - GET the swagger definition of the API in JSON format.
/api/numsales     - GET the sold items for the current day or with ?date=MM/DD/YYYY parameter of the given day.
/api/totalrevenue - GET the total revenue of the current day or with ?date=MM/DD/YYYY parameter of the given day.
/api/statistics   - GET the total revenue grouped by article. 
```
