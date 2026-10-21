## Step 2 — StudentStore vs CourseStore

**What is the same?**

Both stores use a List to store items and provide the same four methods: Add, GetById, GetAll, and Remove. Both search for an item using its Id and return null when the item is not found.

**What is different?**

StudentStore stores Student objects, while CourseStore stores Course objects. Student has Id and Name, while Course has Id, Title, and Price.

The main logic is almost identical, so we are repeating code. We can solve this problem by using Generics to create one store that works with different types.


## Step 3 — Why does GetById fail to compile?

**Compiler error:**

CS1061 'T' does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found (are you missing a using directive or an assembly
reference?)
CS1061 'T' does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found (are you missing a using directive or an assembly
reference?)

**Explanation:**

T is a generic type, and the compiler does not know which type will be used when Store<T> is created. Not every type has an Id property. Therefore, the compiler cannot allow us to access item.Id without a constraint that guarantees the property exists.

We need to tell the compiler that T must implement an interface that provides an Id property.

