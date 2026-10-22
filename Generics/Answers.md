## Step 2 — Comparing StudentStore and CourseStore

Both stores use a `List<T>` to keep their items and provide the same four operations: `Add`, `GetById`, `GetAll`, and `Remove`. Both search for an item by looping through the list and return `null` when the requested ID is not found.

The main difference is the type of data they manage. `StudentStore` works with `Student` objects, while `CourseStore` works with `Course` objects. Their implementations are almost identical, except for the type and property names used. This duplication suggests that a generic store could handle both types using one reusable implementation.


error CS1061: 'T' does not contain a definition for 'Id'
and no accessible extension method 'Id' accepting a first
argument of type 'T' could be found.


## Step 3 — Why GetById Does Not Compile

**Compiler error:** `CS1061` — The generic type `T` does not contain a definition for `Id`.

The compiler rejects `item.Id` because `T` can represent any type. At this stage, we have not told the compiler that every type used with `Store<T>` must have an `Id` property. Even if `Student` and `Course` both have an `Id`, the compiler cannot assume that every possible type passed to `T` has one.

We need a constraint that guarantees the required property exists. This is what the `IHasId` interface and the `where T : IHasId` constraint will provide in the next step.


## Step 7 — Why Store<string> Must Not Compile

`Store<T>` has the constraint `where T : IHasId`. This means that every type used with the store must implement `IHasId` and provide a readable integer `Id` property. The `string` type does not implement this interface, so `Store<string>` violates the generic constraint and the compiler rejects it.

## Final Research Question — What Is This Kind of Class Called?

The common name for this kind of class is a **generic repository** or **Repository pattern** implementation. It provides a reusable way to store, retrieve, and remove objects without writing a separate store class for every entity type. In a real application, the Repository pattern often abstracts data access, although this assignment's implementation stores objects in memory rather than a database.