## Step 2 — Comparing StudentStore and CourseStore

Both stores use a `List<T>` to keep their items and provide the same four operations: `Add`, `GetById`, `GetAll`, and `Remove`. Both search for an item by looping through the list and return `null` when the requested ID is not found.

The main difference is the type of data they manage. `StudentStore` works with `Student` objects, while `CourseStore` works with `Course` objects. Their implementations are almost identical, except for the type and property names used. This duplication suggests that a generic store could handle both types using one reusable implementation.