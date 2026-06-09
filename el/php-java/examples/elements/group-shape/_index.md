---
title: Σχήμα Ομάδας
type: docs
weight: 170
url: /el/php-java/examples/elements/group-shape/
keywords:
- ομάδα
- προσθήκη σχήματος ομάδας
- πρόσβαση σε σχήμα ομάδας
- αφαίρεση σχήματος ομάδας
- αποομαδοποίηση σχημάτων
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εργασία με σχήματα ομάδας σε PHP χρησιμοποιώντας Aspose.Slides: δημιουργία και αποομαδοποίηση, αναδιάταξη υποσχημάτων, ορισμός μετασχηματισμών και ορίων σε PowerPoint και OpenDocument."
---
Παραδείγματα δημιουργίας ομάδων σχημάτων, πρόσβασης σε αυτές, αποομαδοποίησης και αφαίρεσης χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

## **Προσθήκη Σχήματος Ομάδας**

Δημιουργήστε μια ομάδα που περιέχει δύο βασικά σχήματα.

```php
function addGroupShape() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $group = $slide->getShapes()->addGroupShape();
        $group->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $group->getShapes()->addAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

        $presentation->save("group_shape.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε Σχήμα Ομάδας**

Ανακτήστε το πρώτο σχήμα ομάδας από μια διαφάνεια.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Πρόσβαση στο πρώτο σχήμα ομάδας στη διαφάνεια.
        $firstGroup = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $firstGroup = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Αφαίρεση Σχήματος Ομάδας**

Διαγράψτε ένα σχήμα ομάδας από τη διαφάνεια.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // Υποθέτοντας ότι το πρώτο σχήμα στη διαφάνεια είναι σχήμα ομάδας.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Αποομαδοποίηση Σχημάτων**

Μετακινήστε τα σχήματα εκτός του περιέκτη ομάδας.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Υποθέτοντας ότι το πρώτο σχήμα στη διαφάνεια είναι σχήμα ομάδας.
        $group = $slide->getShapes()->get_Item(0);

        // Κλωνοποίηση κάθε σχήματος από την ομάδα και προσθήκη του στη διαφάνεια.
        $shapeCount = java_values($group->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $group->getShapes()->get_Item($index);
            $slide->getShapes()->addClone($shape);
        }

        $slide->getShapes()->remove($group);

        $presentation->save("ungrouped_shapes.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```