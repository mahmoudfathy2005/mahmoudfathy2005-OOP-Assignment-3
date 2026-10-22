# Task 1.4 — Blocked Users & Students

## R1 — Before Refactoring

* Time Complexity: O(n * m)
* Time Before: 450 ms (estimated)
* Found Before: 5000

The code was slow because `List.Contains()` searches the list for every request ID.

## R2 — BlockedUserChecker

* Changed `List.Contains()` to `HashSet.Contains()`.
* Time Complexity After: O(n + m) on average.
* Time After: 4 ms (estimated)
* Found After: 5000

The result stayed the same, but the execution time became much lower because HashSet provides faster lookups.

## R3 — StudentCatalog

* Changed the return type from `List<Student>` to `IEnumerable<Student>`.
* Used `yield return` to create students only when needed.
* The program now creates only the first 3 students instead of creating all 1,000,000 students.
* The output is still the same:

text
1: Student 1
2: Student 2
3: Student 3
printed=3

