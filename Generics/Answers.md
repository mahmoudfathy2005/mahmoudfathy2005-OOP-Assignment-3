# Generics — Answers

## Step 2 — StudentStore vs CourseStore

### What is the same?

Both stores use a `List<T>` to store items and provide the same four methods: `Add`, `GetById`, `GetAll`, and `Remove`.

Both stores search for items using their IDs and return `null` when an item is not found.

### What is different?

`StudentStore` stores `Student` objects, while `CourseStore` stores `Course` objects.

A `Student` has an `Id` and a `Name`, while a `Course` has an `Id`, a `Title`, and a `Price`.

The main logic of both stores is almost identical. We are repeating the same code with different types, so we can use Generics to avoid this duplication.

---

## Step 3 — Why does GetById fail to compile?

### Compiler Error

The compiler reports an error similar to:

`'T' does not contain a definition for 'Id'`

The exact error message may differ depending on the compiler version.

### Explanation

`T` is a generic type, and the compiler does not know which type will be used when creating `Store<T>`.

Not every type has an `Id` property. Therefore, the compiler cannot allow us to access `item.Id` without knowing that the property exists.

We need to create an interface that defines the `Id` property and add a generic constraint to ensure that `T` implements that interface.

---

## Step 7 — Why must Store<string> not compile?

`Store<T>` has the generic constraint `where T : IHasId`.

This means that `T` must implement the `IHasId` interface and provide an `Id` property.

The `string` type does not implement `IHasId`, so `Store<string>` violates the generic constraint and the compiler rejects it.

This constraint ensures that every type stored in `Store<T>` has an `Id` that can be used for searching and removing items.

---

## Final Question — What is the common name for this kind of class?

The class is similar to a **Generic Repository**.

It provides a common way to add, find, retrieve, and remove items by their IDs.

Since it stores data in a `Dictionary` in memory rather than a database, it can also be described as a **Generic In-Memory Repository**.
