# 📚 Publisher System - Linked List in C#

![C#](https://img.shields.io/badge/C%23-.NET-blueviolet)
![Status](https://img.shields.io/badge/status-completed-brightgreen)
![License](https://img.shields.io/badge/license-MIT-blue)

A book management system for a publishing company, implemented using a **singly linked list** in C#. The list is automatically maintained in **ascending order by publication year**.

---

## 📋 Table of Contents

- [About the Project](#-about-the-project)
- [Data Structure](#-data-structure)
- [Features](#-features)
- [How to Run](#-how-to-run)
- [Usage Example](#-usage-example)
- [Concepts Applied](#-concepts-applied)
- [Author](#-author)

---

## 📖 About the Project

This project was developed as part of an academic assignment on **data structures**. The goal is to simulate a publishing company's catalog system, where each book is stored in a node of a linked list sorted by **publication year**.

Sorting is performed automatically at insertion time, ensuring the list always remains in ascending order, regardless of the order in which books are registered.

---

## 🗂 Data Structure

The `NoDaLista` (list node) class represents a book:

| Field | Type | Description |
|-------|------|-------------|
| `Titulo` | `string` | Book title |
| `Autor` | `string` | Book author |
| `Ano` | `int` | Publication year |
| `Quantidade` | `int` | Quantity in stock |
| `Prox` | `NoDaLista` | Reference to the next node |

```csharp
public class NoDaLista
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Ano { get; set; }
    public int Quantidade { get; set; }
    public NoDaLista Prox { get; set; }
}
