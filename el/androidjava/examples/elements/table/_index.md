---
title: Πίνακας
type: docs
weight: 120
url: /el/androidjava/examples/elements/table/
keywords:
- παράδειγμα κώδικα
- πίνακας
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Δουλέψτε με πίνακες στο Aspose.Slides for Android: δημιουργήστε, μορφοποιήστε, συγχωνεύστε κελιά, εφαρμόστε στυλ, εισάγετε δεδομένα και εξάγετε με παραδείγματα Java για PPT, PPTX και ODP."
---
Παραδείγματα προσθήκης πινάκων, πρόσβασης σε αυτούς, αφαίρεσης και συγχώνευσης κελιών χρησιμοποιώντας **Aspose.Slides for Android via Java**.

## **Προσθήκη Πίνακα**

Δημιουργήστε έναν απλό πίνακα με δύο γραμμές και δύο στήλες.

```java
static void addTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε Πίνακα**

Ακτήστε το πρώτο σχήμα πίνακα στη διαφάνεια.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Πρόσβαση στον πρώτο πίνακα στη διαφάνεια.
        ITable firstTable = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                firstTable = (ITable) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση Πίνακα**

Διαγράψτε έναν πίνακα από μια διαφάνεια.

```java
static void removeTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        slide.getShapes().remove(table);
    } finally {
        presentation.dispose();
    }
}
```

## **Συγχώνευση Κυττάρων Πίνακα**

Συγχωνεύστε τα προσεγγιστικά κελιά ενός πίνακα σε ένα ενιαίο κελί.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Συγχώνευση κελιών.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```