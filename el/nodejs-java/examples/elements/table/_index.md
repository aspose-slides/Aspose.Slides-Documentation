---
title: Πίνακας
type: docs
weight: 120
url: /el/nodejs-java/examples/elements/table/
keywords:
- παράδειγμα κώδικα
- πίνακας
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εργαστείτε με πίνακες στο Aspose.Slides για Node.js: δημιουργήστε, μορφοποιήστε, συγχωνεύστε κελιά, εφαρμόστε στυλ, εισάγετε δεδομένα και εξάγετε με παραδείγματα για PPT, PPTX και ODP."
---
Παραδείγματα προσθήκης πινάκων, πρόσβασης σε αυτούς, διαγραφής τους και συγχώνευσης κελιών χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

## **Προσθήκη Πίνακα**
Δημιουργήστε έναν απλό πίνακα με δύο σειρές και δύο στήλες.

```js
function addTable() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let widths = java.newArray("double", [80, 80]);
        let heights = java.newArray("double", [30, 30]);
        let table = slide.getShapes().addTable(50, 50, widths, heights);

        presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε Πίνακα**
Ανακτήστε το πρώτο σχήμα πίνακα από τη διαφάνεια.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Πρόσβαση στον πρώτο πίνακα στη διαφάνεια.
        let firstTable = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
                firstTable = shape;
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

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτουμε ότι το πρώτο σχήμα είναι πίνακας.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Συγχώνευση Κελιών Πίνακα**
Συγχωνεύστε γειτονικά κελιά ενός πίνακα σε ένα ενιαίο κελί.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Υποθέτουμε ότι το πρώτο σχήμα είναι πίνακας.
        let table = slide.getShapes().get_Item(0);

        // Συγχώνευση κελιών.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```