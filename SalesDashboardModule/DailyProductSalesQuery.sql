USE [AdventureWorksLT2012]

DECLARE @startDate as date;

SET @startDate = cast('$(FILTERDATE)' as datetime);

SELECT p.[Name] ProductName, sh.OrderDate ,SUM(OrderQty) Quantity             
FROM SalesLT.SalesOrderDetail sd
	 JOIN SalesLT.SalesOrderHeader sh ON sd.SalesOrderID = sh.SalesOrderID
	 JOIN SalesLT.Product		   p  ON sd.ProductID = p.ProductID
WHERE sh.OrderDate >= @startDate
GROUP BY p.[Name], sh.OrderDate
ORDER BY p.[Name]