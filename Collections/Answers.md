# Task 2.1 — IReadOnlyDictionary & SortedDictionary

## 1. What is IReadOnlyDictionary?

`IReadOnlyDictionary<TKey, TValue>` is an interface used to read data stored as key-value pairs. It allows us to access values using keys, check if a key exists, and get the number of items without providing methods to add, remove, or update items through this interface.

## 2. How is IReadOnlyDictionary different from Dictionary?

`Dictionary<TKey, TValue>` allows us to add, remove, update, and read items. `IReadOnlyDictionary<TKey, TValue>` only provides operations for reading the items.

A public method can return `IReadOnlyDictionary` instead of `Dictionary` when the caller only needs to read the data. This helps prevent accidental modifications through the returned reference and makes the code easier to maintain.

However, it does not guarantee that the original data cannot change through another reference.

## 3. What is SortedDictionary?

`SortedDictionary<TKey, TValue>` stores key-value pairs and keeps them sorted by their keys. When we iterate through the collection, the items are returned in ascending key order by default.

Unlike `Dictionary`, it maintains the sorted order automatically.

## 4. How is SortedDictionary different from Dictionary in ordering and lookup speed?

`Dictionary` does not guarantee that items are returned in sorted key order. It provides average O(1) lookup time, which makes it a good choice when fast access by key is the main goal.

`SortedDictionary` keeps its keys sorted and provides O(log n) lookup time. Adding and removing items also generally take O(log n) time.

Therefore, `Dictionary` is usually faster for direct lookups, while `SortedDictionary` is useful when we need to keep the items sorted.

## 5. When would I choose SortedDictionary?

I would choose `SortedDictionary` when I need to store key-value pairs and always access or iterate through them in sorted key order.

For example, I could use it to store student records by student ID and display them in ascending order without sorting the collection manually each time.

If I only need fast access using keys and do not need sorted items, I would choose `Dictionary` instead.

## Sources

1. Microsoft Learn — IReadOnlyDictionary: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2
2. Microsoft Learn — SortedDictionary: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2
3. Microsoft Learn — Dictionary: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2




# Task 2.2 — Pick the Collection

## S1 — Find a student by national ID

**Collection:** `Dictionary`

**Why:** I would use a Dictionary because the national ID can be used as a unique key to find a student's information quickly.

## S2 — Keep the tags of a course

**Collection:** `HashSet`

**Why:** I would use a HashSet because it prevents duplicate tags from being stored in the collection.

## S3 — Keep a student's grades in the order they were entered

**Collection:** `List`

**Why:** I would use a List because it keeps the grades in insertion order and allows the same grade to appear more than once.

## S4 — Return the course price list

**Collection:** `IReadOnlyDictionary`

**Why:** I would use IReadOnlyDictionary because callers need to read course prices by key without being given methods to add, remove, or update entries through the returned interface.

## S5 — Timetable keyed by session start time

**Collection:** `SortedDictionary`

**Why:** I would use a SortedDictionary because it keeps sessions sorted by their start times, even when new sessions are added.

## S6 — Return results that the caller only loops over once

**Collection:** `IEnumerable`

**Why:** I would use IEnumerable because the caller only needs to iterate over the results and may stop early without needing to modify the collection or access items by index.
