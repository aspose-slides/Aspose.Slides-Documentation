---
title: Διάγραμμα
type: docs
weight: 60
url: /el/net/examples/elements/chart/
keywords:
- διάγραμμα
- προσθήκη διαγράμματος
- πρόσβαση σε διάγραμμα
- αφαίρεση διαγράμματος
- ενημέρωση διαγράμματος
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε διαγράμματα με το Aspose.Slides για .NET: δημιουργήστε, μορφοποιήστε, συνδέστε δεδομένα και εξάγετε διαγράμματα σε PPT, PPTX και ODP με παραδείγματα C#."
---
Παραδείγματα για την προσθήκη, πρόσβαση, αφαίρεση και ενημέρωση διαφόρων τύπων διαγραμμάτων με **Aspose.Slides for .NET**. Τα παρακάτω αποσπάσματα παρουσιάζουν βασικές λειτουργίες διαγράμματος.

## **Προσθήκη Διαγράμματος**

Αυτή η μέθοδος προσθέτει ένα απλό διάγραμμα περιοχής στην πρώτη διαφάνεια.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Προσθέτει ένα απλό διάγραμμα περιοχής στην πρώτη διαφάνεια.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Πρόσβαση σε Διάγραμμα**

Μετά τη δημιουργία ενός διαγράμματος, μπορείτε να το ανακτήσετε μέσω της συλλογής σχημάτων.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Πρόσβαση στο πρώτο διάγραμμα στη διαφάνεια.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Αφαίρεση Διαγράμματος**

Ο παρακάτω κώδικας αφαιρεί ένα διάγραμμα από μια διαφάνεια.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Αφαιρέστε το διάγραμμα.
    slide.Shapes.Remove(chart);
}
```

## **Ενημέρωση Δεδομένων Διαγράμματος**

Μπορείτε να αλλάξετε ιδιότητες του διαγράμματος, όπως ο τίτλος.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Αλλάξτε τον τίτλο του διαγράμματος.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```