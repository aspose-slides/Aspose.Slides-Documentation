---
title: Πίνακας
type: docs
weight: 120
url: /el/php-java/examples/elements/table/
keywords:
- πίνακας
- προσθήκη πίνακα
- πρόσβαση σε πίνακα
- αφαίρεση πίνακα
- συγχώνευση κελιών
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε και μορφοποιήστε πίνακες σε PHP με Aspose.Slides: εισαγάγετε δεδομένα, συγχωνεύστε κελιά, μορφοποιήστε τα όρια, ευθυγραμμίστε το περιεχόμενο και κάντε εισαγωγή/εξαγωγή για PPT, PPTX και ODP."
---
Παραδείγματα προσθήκης πινάκων, πρόσβασης σε αυτούς, διαγραφής τους και συγχώνευσης κελιών χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

## **Προσθήκη πίνακα**

Δημιουργήστε έναν απλό πίνακα με δύο σειρές και δύο στήλες.

```php
function addTable() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $widths = [80, 80];
        $heights = [30, 30];
        $table = $slide->getShapes()->addTable(50, 50, $widths, $heights);

        $presentation->save("table.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε πίνακα**

Ανακτήστε το πρώτο σχήμα πίνακα στη διαφάνεια.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Πρόσβαση στον πρώτο πίνακα στη διαφάνεια.
        $firstTable = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Table"))) {
                $firstTable = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Αφαίρεση πίνακα**

Διαγράψτε έναν πίνακα από μια διαφάνεια.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι ο πίνακας είναι το πρώτο σχήμα στη διαφάνεια.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Συγχώνευση κελιών πίνακα**

Συγχωνεύστε τα διπλανά κελιά ενός πίνακα σε ένα ενιαίο κελί.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι ο πίνακας είναι το πρώτο σχήμα στη διαφάνεια.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```