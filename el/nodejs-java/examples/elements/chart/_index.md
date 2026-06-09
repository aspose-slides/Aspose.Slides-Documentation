---
title: Διάγραμμα
type: docs
weight: 60
url: /el/nodejs-java/examples/elements/chart/
keywords:
- παράδειγμα κώδικα
- διάγραμμα
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαχειριστείτε διαγράμματα με Aspose.Slides για Node.js μέσω Java: δημιουργήστε, μορφοποιήστε, συνδέστε δεδομένα και εξαγάγετε διαγράμματα σε PPT, PPTX και ODP με παραδείγματα JavaScript."
---
Παραδείγματα προσθήκης, πρόσβασης, κατάργησης και ενημέρωσης διαφορετικών τύπων διαγραμμάτων με **Aspose.Slides for Node.js via Java**. Τα παρακάτω αποσπάσματα δείχνουν βασικές λειτουργίες διαγραμμάτων.

## **Προσθήκη διαγράμματος**

Αυτή η μέθοδος προσθέτει ένα απλό διάγραμμα περιοχής στην πρώτη διαφάνεια.

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Προσθέστε ένα απλό διάγραμμα περιοχής στην πρώτη διαφάνεια.
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε διάγραμμα**

Αφού δημιουργήσετε ένα διάγραμμα, μπορείτε να το ανακτήσετε μέσω της συλλογής σχημάτων.

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Πρόσβαση στο πρώτο διάγραμμα στη διαφάνεια.
        let firstChart = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                firstChart = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση διαγράμματος**

Ο παρακάτω κώδικας αφαιρεί το διάγραμμα από τη διαφάνεια.

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Αφαίρεση του διαγράμματος.
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ενημέρωση δεδομένων διαγράμματος**

Μπορείτε να αλλάξετε τις ιδιότητες του διαγράμματος, όπως ο τίτλος.

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // Αλλαγή του τίτλου του διαγράμματος.
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```