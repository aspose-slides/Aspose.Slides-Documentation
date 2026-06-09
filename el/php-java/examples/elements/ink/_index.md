---
title: Μελάνη
type: docs
weight: 180
url: /el/php-java/examples/elements/ink/
keywords:
- μελάνη
- πρόσβαση σε μελάνη
- αφαίρεση μελάνης
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Διαχειριστείτε την ψηφιακή μελάνη στις διαφάνειες σε PHP με το Aspose.Slides: προσθέστε στίγματα πένας, επεξεργαστείτε μονοπάτια, ορίστε χρώμα και πλάτος, και εξάγετε τα αποτελέσματα για PowerPoint και OpenDocument."
---
Παρέχει παραδείγματα πρόσβασης σε υπάρχουσες σχήματα μελάνης και αφαίρεσής τους χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

> ❗ **Σημείωση:** Τα σχήματα μελάνης αντιπροσωπεύουν είσοδο χρήστη από εξειδικευμένες συσκευές. Το Aspose.Slides δεν μπορεί να δημιουργήσει νέα στίγματα μελάνης προγραμματιστικά, αλλά μπορείτε να διαβάσετε και να τροποποιήσετε την υπάρχουσα μελάνη.

## **Πρόσβαση στη Μελάνη**

Αποκτήστε το πρώτο σχήμα μελάνης στη διαφάνεια.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Πρόσβαση στο πρώτο σχήμα μελάνης στη διαφάνεια.
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Αφαίρεση Μελάνης**

Διαγράψτε ένα σχήμα μελάνης από τη διαφάνεια.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα στη διαφάνεια είναι σχήμα μελάνης.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```