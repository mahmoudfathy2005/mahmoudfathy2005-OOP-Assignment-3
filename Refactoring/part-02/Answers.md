# Part 02 — answers

---



## Reports — Template Method

**What was the problem?**

The three report exporters duplicated the same export workflow: loading data, validating it, formatting it, and saving the file. This made the code harder to maintain because changes to the common workflow had to be repeated in multiple classes.

**What did you change?**

Created an abstract `ReportExporter` base class containing the `Export()` template method. It defines the export steps in one place and provides shared implementations for loading, validating, and saving data. The `Format()` method is abstract, so each concrete exporter implements its own formatting logic.

`CsvReportExporter`, `JsonReportExporter`, and `TextReportExporter` now inherit from `ReportExporter` and only implement their specific formatting behavior.

**Why is an abstract class a better fit than an interface here?**

An abstract class allows the shared export workflow and common method implementations to be reused by all exporters. It also allows `Format()` to be declared abstract, requiring each exporter to provide its own implementation. An interface could define a common contract, but it would not provide the same straightforward base-class implementation for this workflow.

**How did you verify the refactoring?**

Ran the application and verified that all three report files were generated: `report.csv`, `report.json`, and `report.txt`. Compared their contents with the original output to ensure that the refactoring did not change the report data or formatting.


---



## Enrollment — Facade

**What problem does the Facade solve here?**

Before the refactoring, `Program.cs` had to create four services and call them individually in the correct order to enroll a student. This coupled the caller to the implementation details of the enrollment workflow and made the caller responsible for coordinating multiple services.

I introduced an `EnrollmentFacade` that provides a single `Enroll()` method. The facade coordinates payment, seat reservation, invoice generation, and email notification in one place.

**What does the caller no longer need to know?**

The caller no longer needs to know how to create or interact with `PaymentGateway`, `SeatInventory`, `InvoiceGenerator`, or `EmailService`. It also no longer needs to know the order in which these services must be called or how the invoice ID is passed to the email service.

**How did you verify the refactoring?**

Ran the application and confirmed that the enrollment output remained the same and that `Program.cs` calls only `EnrollmentFacade.Enroll()` for the enrollment workflow. The four existing service classes were left unchanged.
