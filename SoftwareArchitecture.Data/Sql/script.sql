SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Address]) VALUES (1, N'John', N'Rambo', N'Jungle')
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Address]) VALUES (2, N'Tom', N'Hanks', N'New York, US')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [Number], [CustomerId]) VALUES (1, N'NBR-0001', 1)
INSERT [dbo].[Order] ([Id], [Number], [CustomerId]) VALUES (2, N'NBR-0002', 1)
INSERT [dbo].[Order] ([Id], [Number], [CustomerId]) VALUES (3, N'NBR-0003', 2)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Price], [OrderId]) VALUES (1, N'Water', CAST(0.99 AS Decimal(16, 2)), 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [OrderId]) VALUES (2, N'Pepsi', CAST(1.99 AS Decimal(16, 2)), 1)
INSERT [dbo].[Products] ([Id], [Name], [Price], [OrderId]) VALUES (3, N'Smartphone', CAST(999.00 AS Decimal(16, 2)), 2)
INSERT [dbo].[Products] ([Id], [Name], [Price], [OrderId]) VALUES (6, N'Book', CAST(7.00 AS Decimal(16, 2)), 3)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
