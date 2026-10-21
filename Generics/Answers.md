## Step 2 — StudentStore vs CourseStore

**What is the same?**

Both stores use a List to store items and provide the same four methods: Add, GetById, GetAll, and Remove. Both search for an item using its Id and return null when the item is not found.

**What is different?**

StudentStore stores Student objects, while CourseStore stores Course objects. Student has Id and Name, while Course has Id, Title, and Price.

The main logic is almost identical, so we are repeating code. We can solve this problem by using Generics to create one store that works with different types.
