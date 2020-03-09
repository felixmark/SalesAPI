# SalesAPI
This is a simple C# REST API for storing sold items with POST requests and getting information about the items with GET requests.
* Estimated effort: 4-8h
* Approximated real effort: about 8h
\
Routes are:
```
/api              - Documentation of the API.
/api/swagger      - GET the swagger definition of the API in JSON format.
/api/sold         - POST a new sold item.
/api/numsales     - GET the number of sold items for the current day or with ?date=MM/DD/YYYY parameter of the given day.
/api/totalrevenue - GET the total revenue of the current day or with ?date=MM/DD/YYYY parameter of the given day.
/api/statistics   - GET the total revenue grouped by article. 
```
\
\
## api/sold
POST a new sold item.
The format of the article object in the content body is:
```
{
  "articleNumber": "Number123",
  "salesPrice": 10.50
}
```
\
the response to a posted item is:
```
{
  "status": 0,
  "description": "Article SomeArticle was sold for 22.5€."
}
```
\
or in case of an error:
```
{
  "status": 1,
  "description": "You have to provide a valid JSON Object of the article in the POST request body.For an example have a look at the documentation."
}
```
\
\
## /api/numsales
GET the number of sold items for the current day or with ?date=MM/DD/YYYY parameter of the given day.
The format of the response is:
```
{
  "status": 0,
  "value": 7
}
```
\
or in case of an error:
```
{
  "status": 1,
  "description": "There was an error in the given date."
}
```
\
\
## /api/totalrevenue
GET the total revenue of the current day or with ?date=MM/DD/YYYY parameter of the given day.
The format of the response is:
```
{
  "status": 0,
  "value": 70.45
}
```
\
or in case of an error:
```
{
  "status": 1,
  "description": "There was an error in the given date."
}
```
\
\
## /api/statistics
GET the total revenue grouped by article. 
The format of the response is:
```
{
  "status": 0,
  "articles": [
    {
      "articleNumber":"A1301351",
      "revenue": 22.5
    },
    {
      "articleNumber":"B1301351",
      "revenue": 44.25
    }
  ]
}
```
\
or in case of an error:
```
{
  "status": 1,
  "description": "There was an error."
}
```
