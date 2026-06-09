---
title: Διάγραμμα
type: docs
weight: 60
url: /el/androidjava/examples/elements/chart/
keywords:
- παράδειγμα κώδικα
- διάγραμμα
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Διαχειριστείτε τα διαγράμματα με Aspose.Slides για Android: δημιουργήστε, μορφοποιήστε, δεσμεύστε δεδομένα και εξάγετε διαγράμματα σε PPT, PPTX και ODP με παραδείγματα Java."
---
Παραδείγματα για την προσθήκη, την πρόσβαση, την αφαίρεση και την ενημέρωση διαφόρων τύπων διαγραμμάτων με **Aspose.Slides for Android via Java**. Τα παρακάτω αποσπάσματα επιδεικνύουν βασικές λειτουργίες διαγραμμάτων.

## **Προσθήκη Διαγράμματος**

Αυτή η μέθοδος προσθέτει ένα απλό διάγραμμα περιοχής στην πρώτη διαφάνεια.

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Προσθέστε ένα απλό διάγραμμα περιοχής στην πρώτη διαφάνεια.
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε Διάγραμμα**

Αφού δημιουργηθεί ένα διάγραμμα, μπορείτε να το ανακτήσετε μέσω της συλλογής σχημάτων.

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // Πρόσβαση στο πρώτο διάγραμμα της διαφάνειας.
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

## **Αφαίρεση Διαγράμματος**

Ο παρακάτω κώδικας αφαιρεί ένα διάγραμμα από μια διαφάνεια.

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // Αφαίρεση του διαγράμματος.
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **Ενημέρωση Δεδομένων Διαγράμματος**

Μπορείτε να αλλάξετε τις ιδιότητες του διαγράμματος, όπως ο τίτλος.

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // Αλλάξτε τον τίτλο του διαγράμματος.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```