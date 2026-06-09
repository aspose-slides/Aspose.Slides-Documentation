---
title: Πίνακας
type: docs
weight: 120
url: /el/java/examples/elements/table/
keywords:
- παράδειγμα κώδικα
- πίνακας
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Εργαστείτε με πίνακες στο Aspose.Slides for Java: δημιουργήστε, μορφοποιήστε, συγχωνεύστε κελιά, εφαρμόστε στυλ, εισάγετε δεδομένα και εξάγετε με παραδείγματα Java για PPT, PPTX και ODP."
---
Παραδείγματα για την προσθήκη πινάκων, την πρόσβαση σε αυτούς, την αφαίρεση και τη συγχώνευση κελιών χρησιμοποιώντας **Aspose.Slides for Java**.

## **Προσθήκη πίνακα**

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

## **Πρόσβαση σε πίνακα**

Ανακτήστε το πρώτο σχήμα πίνακα στη διαφάνεια.

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

## **Αφαίρεση πίνακα**

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

## **Συγχώνευση κελιών πίνακα**

Συγχωνεύστε γειτναιόμενα κελιά ενός πίνακα σε ένα ενιαίο κελί.

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