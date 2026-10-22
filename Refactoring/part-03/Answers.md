# Part 03 — answers

---

## BlockedUsers

- **Time complexity before:** O(B × R), where B is the number of blocked IDs and R is the number of requests.
- **Time (ms) before:** Record the actual time measured before optimization.
- **What did you change?** I replaced `List<int>` with `HashSet<int>` to improve membership lookup performance. I updated `BuildBlockedIds`, `CountBlocked`, and `MeasureMs` to use the new data structure.
- **Time complexity after:** O(R) average for counting requests, excluding the initial construction of the HashSet. Including construction, the average complexity is O(B + R).
- **Time (ms) after:** 1 ms.

---

## Students

- **What was the problem?** `GetAllStudents()` created and stored one million `Student` objects in a list, even though the program printed only the first three students. This caused unnecessary object creation and memory allocation.
- **What did you change?** I changed `GetAllStudents()` to return `IEnumerable<Student>` and used `yield return` to generate students lazily. The existing loop now creates only three students before stopping, avoiding the creation and storage of the remaining 999,997 students.