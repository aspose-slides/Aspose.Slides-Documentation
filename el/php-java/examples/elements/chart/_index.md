---
title: Διάγραμμα
type: docs
weight: 60
url: /el/php-java/examples/elements/chart/
keywords:
- διάγραμμα
- προσθήκη διαγράμματος
- πρόσβαση σε διάγραμμα
- κατάργηση διαγράμματος
- ενημέρωση διαγράμματος
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε διαγράμματα σε PHP με Aspose.Slides: προσθέστε δεδομένα, μορφοποιήστε σειρές, άξονες και ετικέτες, αλλάξτε τύπους και εξαγάγετε—λειτουργεί με PPT, PPTX και ODP."
---
Παραδείγματα προσθήκης, πρόσβασης, κατάργησης και ενημέρωσης διαφορετικών τύπων διαγραμμάτων με **Aspose.Slides for PHP via Java**. Τα αποσπάσματα παρακάτω παρουσιάζουν βασικές λειτουργίες διαγραμμάτων.

## **Προσθήκη διαγράμματος**

Αυτή η μέθοδος προσθέτει ένα απλό διάγραμμα περιοχής στην πρώτη διαφάνεια.

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Προσθέτει ένα απλό διάγραμμα στήλης στη διαφάνεια.
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε διάγραμμα**

Ανάκτηση του διαγράμματος από τη συλλογή σχημάτων.

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Πρόσβαση στο πρώτο διάγραμμα στη διαφάνεια.
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Κατάργηση διαγράμματος**

Ο παρακάτω κώδικας καταργεί ένα διάγραμμα από τη διαφάνεια.

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα στη διαφάνεια είναι το διάγραμμα.
        $chart = $slide->getShapes()->get_Item(0);

        // Κατάργηση του διαγράμματος.
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ενημέρωση δεδομένων διαγράμματος**

Μπορείτε να αλλάξετε τις ιδιότητες του διαγράμματος, όπως ο τίτλος.

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα στη διαφάνεια είναι το διάγραμμα.
        $chart = $slide->getShapes()->get_Item(0);

        // Αλλαγή του τίτλου του διαγράμματος.
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```