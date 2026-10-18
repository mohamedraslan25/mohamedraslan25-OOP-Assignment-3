# Task 2.2 — Pick the Collection

**S1 — Find a student by national ID**

**Collection:** `Dictionary<string, Student>`

A dictionary allows fast average O(1) lookups by national ID because each ID is used as a key.

**S2 — Keep the tags of a course without duplicates**

**Collection:** `HashSet<string>`

A hash set stores unique elements, so the same tag cannot be added more than once.

**S3 — Keep a student's grades in the order they were entered**

**Collection:** `List<decimal>`

A list preserves the order in which grades are added and allows duplicate grades.

**S4 — Return the course price list for reading only**

**Collection:** `IReadOnlyDictionary<string, decimal>`

This interface allows callers to read prices by key without exposing methods for adding, removing, or changing entries through the returned reference.

**S5 — Keep a timetable sorted by session start time**

**Collection:** `SortedDictionary<DateTime, Session>`

A sorted dictionary automatically maintains sessions in key order, allowing them to be enumerated by start time even when sessions are added later.

**S6 — Return results that the caller only loops over once and may stop early**

**Collection:** `IEnumerable<Result>`

An enumerable allows the caller to iterate through results one at a time and stop early without requiring a concrete collection type.