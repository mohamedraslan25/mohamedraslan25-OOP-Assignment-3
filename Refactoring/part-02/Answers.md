# Part 02 — answers

---

## Reports

- What was the problem?
  The three report exporters duplicated the same workflow: loading data, validating it, formatting it, and saving it. This created code duplication and made future changes harder because the same logic had to be maintained in multiple classes.

- What did you change?
  I introduced an abstract ReportExporter base class that contains the shared export workflow, data loading, validation, and saving logic. Each concrete exporter (CsvReportExporter, JsonReportExporter, and TextReportExporter) overrides the Format() method to provide its own output format.
- Why did you choose that approach?
  I used the Template Method design pattern to define the common algorithm once while allowing subclasses to customize the formatting step. This reduces duplication, improves maintainability, and makes it easier to add new report formats without duplicating the export workflow.
---

## Enrollment

- What was the problem?
  The enrollment workflow was implemented directly in Program.cs, which mixed application startup with business orchestration. The program also instantiated concrete service classes directly, making the workflow more tightly coupled to their implementations and harder to test independently.
- What did you change?
  I introduced an EnrollmentService to coordinate the enrollment workflow. I also introduced interfaces for payment, seat reservation, invoice generation, and email delivery, then injected these dependencies through the service's constructor.
- Why did you choose that approach?
  This separates the enrollment workflow from the application's entry point and applies Dependency Inversion and constructor injection. The service depends on abstractions rather than concrete implementations, making the workflow easier to test, maintain, and extend with alternative implementations.