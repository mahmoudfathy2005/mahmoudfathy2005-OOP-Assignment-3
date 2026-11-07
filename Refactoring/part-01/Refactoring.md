# Part 01 — Answers

---

## ShippingCostCalculator

* **What was the problem?**
  The class used a switch statement to calculate the shipping cost for each carrier. If I wanted to add a new carrier, I had to modify the existing class.

* **What did you change?**
  I created an `IShippingCostCalculator` interface and a separate class for each carrier. I used the Strategy Pattern so I can change the shipping calculator without modifying the main class.

---

## OrderProcessor

* **What was the problem?**
  The class created its own dependencies, like the SQL repository and the SMTP email sender. This made it difficult to change or test them.

* **What did you change?**
  I created `IOrderRepository` and `ISmtpSender` interfaces and passed their implementations through the constructor. Now, I can change the dependencies without modifying the `OrderProcessor` class.

---

## Notifications

* **What was the problem?**
  The old design used separate classes for different notification combinations, like urgent email and urgent SMS. Adding more channels and behaviors would make the number of classes grow.

* **What did you change?**
  I used composition by creating an `INotificationChannel` interface and separate classes for each channel. I also made urgency and scheduling configurable through properties, so I can combine them without creating a new class for every combination.

---

## Proof

* **New carrier file(s):** None yet. I separated the existing carriers into their own classes.
* **New notification channel file(s):** `PushNotificationChannel.cs`
* **Existing classes left unchanged?** Yes, the existing calculator and notification classes do not need to be modified when adding a new carrier or notification channel.
