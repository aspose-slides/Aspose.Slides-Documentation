---
title: SmartArt
type: docs
weight: 140
url: /el/php-java/examples/elements/smartart/
keywords:
- SmartArt
- προσθήκη SmartArt
- πρόσβαση SmartArt
- αφαίρεση SmartArt
- διάταξη SmartArt
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Δημιουργήστε και επεξεργαστείτε SmartArt σε PHP με Aspose.Slides: προσθέστε κόμβους, αλλάξτε διατάξεις και στυλ, μετατρέψτε σε σχήματα με ακρίβεια, και εξαγάγετε για PPT, PPTX και ODP."
---
Δείχνει πώς να προσθέσετε γραφικά SmartArt, να τα προσεγγίσετε, να τα αφαιρέσετε και να αλλάξετε διατάξεις χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

## **Προσθήκη SmartArt**

Εισαγάγετε ένα γραφικό SmartArt χρησιμοποιώντας μία από τις ενσωματωμένες διατάξεις.

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε SmartArt**

Ανακτήστε το πρώτο αντικείμενο SmartArt σε μια διαφάνεια.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Πρόσβαση στο πρώτο SmartArt στη διαφάνεια.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Αφαίρεση SmartArt**

Διαγράψτε ένα σχήμα SmartArt από τη διαφάνεια.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτουμε ότι το πρώτο σχήμα στη διαφάνεια είναι SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Αλλαγή Διάταξης SmartArt**

Ενημερώστε τον τύπο διάταξης ενός υπάρχοντος γραφικού SmartArt.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτουμε ότι το πρώτο σχήμα στη διαφάνεια είναι SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // Αλλάξτε τη διάταξη του SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```