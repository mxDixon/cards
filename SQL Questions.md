
*Disclaimer: I'm no DBA. I rarely write ad-hoc sql because we use ORMs.*

### 1. Write a SQL Query to pull all customers

```sql
SELECT *
FROM cardlytics.dbo.Customers WITH (NOLOCK)
```

### 2. Write a SQL Query to pull all customers that have orders (no duplicates)

```sql
SELECT * FROM cardlytics.dbo.Customers WITH (NOLOCK)
WHERE ID in (
SELECT distinct Cust.ID
  FROM cardlytics.dbo.Customers AS Usr WITH (NOLOCK)
  LEFT JOIN cardlytics.dbo.Orders AS Ord
  On Cust.ID = Ord.Customer_ID
)
```

### 3. Write a SQL Query to pull all customers that do not have orders

```sql
SELECT * FROM cardlytics.dbo.Customers WITH (NOLOCK)
WHERE ID in (
SELECT distinct Cust.ID
  FROM cardlytics.dbo.Customers AS Usr WITH (NOLOCK)
  LEFT JOIN cardlytics.dbo.Orders AS Ord
  On Cust.ID = Ord.Customer_ID
  WHERE ord.id = null
)
```

### 4. If you had to create an index on these tables, which fields would you most likely index and why?

ID is the most obvious index on both tables. I would probably also index email on the Customer's table because it's generally going to be the lookup method for non-automated systems. Customer ID should also be indexed on the Order table.


### 5. Write a query that lists each customer name, email, and the number of order they have

```sql
SELECT Cust.Name, Cust.Email, count(ord.id) AS OrderNumber
  FROM cardlytics.dbo.Customers AS Usr WITH (NOLOCK)
  LEFT JOIN cardlytics.dbo.Orders AS Ord
  On Cust.ID = Ord.Customer_ID
  Group by Cust.Name, Cust.Email
```

### 6. Write a query that pulls all customers that have between 2 and 5 orders

```sql
SELECT Cust.Name, Cust.Email, count(ord.id) AS OrderNumber
  FROM cardlytics.dbo.Customers AS Usr WITH (NOLOCK)
  LEFT JOIN cardlytics.dbo.Orders AS Ord
  On Cust.ID = Ord.Customer_ID
  Group by Cust.Name, Cust.Email
  HAVING count(ord.id) <= 6 AND  count(ord.id) >= 1
```
