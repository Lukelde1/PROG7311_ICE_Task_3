# TechEcommerce — ASP.NET Core MVC

A web-based e-commerce application built with ASP.NET Core MVC, converted from a console application as part of a college assignment.

## Project Overview

This project demonstrates the conversion of a C# console application into a fully structured ASP.NET Core MVC web application, following the Model-View-Controller design pattern.

## Features

- Browse available products
- Add products to a shopping cart
- Remove items from the cart
- Place an order and receive a confirmation
- Prices displayed in South African Rand (ZAR)

## Tech Stack

- **Framework:** ASP.NET Core MVC (.NET 8)
- **Language:** C#
- **Frontend:** Razor Views (HTML, CSS)
- **Architecture:** MVC (Model-View-Controller)

## MVC Structure

| Layer | Responsibility |
|---|---|
| **Models** | Product, CartItem, Order, ProductRepository, OrderService |
| **Controllers** | ShopController handles all user actions and routing |
| **Views** | Razor pages for Products, Cart, and Order Confirmation |

## How to Run

1. Clone the repository
