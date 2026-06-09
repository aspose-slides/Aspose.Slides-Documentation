---
title: "Αντικείμενο OLE"
type: docs
weight: 210
url: /el/php-java/examples/elements/ole-object/
keywords:
- αντικείμενο OLE
- προσθήκη αντικειμένου OLE
- πρόσβαση σε αντικείμενο OLE
- αφαίρεση αντικειμένου OLE
- ενημέρωση αντικειμένου OLE
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εργαστείτε με αντικείμενα OLE σε PHP χρησιμοποιώντας Aspose.Slides: εισαγάγετε ή ενημερώστε ενσωματωμένα αρχεία, ορίστε εικονίδια ή συνδέσμους, εξαγάγετε περιεχόμενο, ελέγξτε τη συμπεριφορά για PPT, PPTX και ODP."
---
Επιδεικνύει την ενσωμάτωση ενός αρχείου ως αντικείμενο OLE και την ενημέρωση των δεδομένων του χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

## **Προσθήκη αντικειμένου OLE**

Ενσωματώστε ένα αρχείο PDF σε μια παρουσίαση.

```php
function addOleObject() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $pdfData = new OleEmbeddedDataInfo(file_get_contents("doc.pdf"), "pdf");
        $oleFrame = $slide->getShapes()->addOleObjectFrame(20, 20, 50, 50, $pdfData);

        $presentation->save("ole_object.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε αντικείμενο OLE**

Ανακτήστε το πρώτο πλαίσιο αντικειμένου OLE σε μια διαφάνεια.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Πρόσβαση στο πρώτο πλαίσιο OLE στη διαφάνεια.
        $firstOleFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $firstOleFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Αφαίρεση αντικειμένου OLE**

Διαγράψτε ένα ενσωματωμένο αντικείμενο OLE από τη διαφάνεια.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα στη διαφάνεια είναι το πλαίσιο OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ενημέρωση δεδομένων αντικειμένου OLE**

Αντικαταστήστε τα δεδομένα που είναι ενσωματωμένα σε ένα υπάρχον αντικείμενο OLE.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα στη διαφάνεια είναι το πλαίσιο OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```