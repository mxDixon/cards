
Caution, I'm no DBA. I rarely write ad-hoc sql because we use ORMs.

1.
SELECT *
FROM cardlytics.dbo.Customers WITH (NOLOCK)

2.
SELECT * FROM cardlytics.dbo.Customers WITH (NOLOCK)
WHERE ID in (
SELECT distinct Cust.ID
  FROM cardlytics.dbo.Customers AS Usr WITH (NOLOCK)
  LEFT JOIN cardlytics.dbo.Orders AS Ord
  On Cust.ID = Ord.Customer_ID
)

3.
SELECT * FROM cardlytics.dbo.Customers WITH (NOLOCK)
WHERE ID in (
SELECT distinct Cust.ID
  FROM cardlytics.dbo.Customers AS Usr WITH (NOLOCK)
  LEFT JOIN cardlytics.dbo.Orders AS Ord
  On Cust.ID = Ord.Customer_ID
  WHERE ord.id = null
)


4.
ID is the most obvious index on both tables. I would probably also index email on the Customer's table because it's generally going to be the lookup method for non-automated systems. Customer ID should also be indexed on the Order table.

5.
SELECT Cust.Name, Cust.Email, count(ord.id) AS OrderNumber
  FROM cardlytics.dbo.Customers AS Usr WITH (NOLOCK)
  LEFT JOIN cardlytics.dbo.Orders AS Ord
  On Cust.ID = Ord.Customer_ID
  Group by Cust.Name, Cust.Email


6.
SELECT Cust.Name, Cust.Email, count(ord.id) AS OrderNumber
  FROM cardlytics.dbo.Customers AS Usr WITH (NOLOCK)
  LEFT JOIN cardlytics.dbo.Orders AS Ord
  On Cust.ID = Ord.Customer_ID
  Group by Cust.Name, Cust.Email
  HAVING count(ord.id) <= 6 AND  count(ord.id) >= 1
