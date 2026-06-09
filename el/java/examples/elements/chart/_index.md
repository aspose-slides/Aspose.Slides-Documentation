---
title: Γράφημα
type: docs
weight: 60
url: /el/java/examples/elements/chart/
keywords:
- παράδειγμα κώδικα
- γράφημα
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Κατακτήστε τα γραφήματα με Aspose.Slides for Java: δημιουργήστε, μορφοποιήστε, συνδέστε δεδομένα και εξάγετε γραφήματα σε PPT, PPTX και ODP με παραδείγματα Java."
---
Παραδείγματα προσθήκης, πρόσβασης, αφαίρεσης και ενημέρωσης διαφόρων τύπων γραφημάτων με **Aspose.Slides for Java**. Τα αποσπάσματα παρακάτω επιδεικνύουν βασικές λειτουργίες γραφημάτων.

## **Προσθήκη Γραφήματος**

Αυτή η μέθοδος προσθέτει ένα απλό γράφημα περιοχής στην πρώτη διαφάνεια.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Προσθέτει ένα απλό γράφημα περιοχής στην πρώτη διαφάνεια.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε Γράφημα**

Μετά τη δημιουργία ενός γραφήματος, μπορείτε να το ανακτήσετε μέσω της συλλογής σχημάτων.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Πρόσβαση στο πρώτο γράφημα στη διαφάνεια.
        IChart firstChart = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                firstChart = (IChart) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση Γραφήματος**

Ο ακόλουθος κώδικας αφαιρεί ένα γράφημα από μια διαφάνεια.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Αφαιρεί το γράφημα.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Ενημέρωση Δεδομένων Γραφήματος**

Μπορείτε να αλλάξετε τις ιδιότητες του γραφήματος, όπως τον τίτλο.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Αλλάζει τον τίτλο του γράφηματος.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```