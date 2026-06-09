---
title: Εικόνα
type: docs
weight: 50
url: /el/php-java/examples/elements/picture/
keywords:
- εικόνα
- πλαίσιο εικόνας
- προσθήκη εικόνας
- πρόσβαση σε εικόνα
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εργασία με εικόνες σε PHP χρησιμοποιώντας Aspose.Slides: εισαγωγή, αντικατάσταση, περικοπή, συμπίεση, ρύθμιση διαφάνειας και εφέ, γέμισμα σχημάτων, και εξαγωγή για PPT, PPTX και ODP."
---
Δείχνει πώς να εισάγετε και να προσπελάσετε εικόνες χρησιμοποιώντας **Aspose.Slides for PHP via Java**. Τα παραδείγματα παρακάτω τοποθετούν μια εικόνα σε μια διαφάνεια και στη συνέχεια την ανακτούν.

## **Προσθήκη εικόνας**

Αυτός ο κώδικας εισάγει μια εικόνα ως πλαίσιο εικόνας στην πρώτη διαφάνεια.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Προσθήκη της εικόνας στους πόρους της παρουσίασης.
        $ppImage = $presentation->getImages()->addImage($image);

        // Εισαγωγή πλαισίου εικόνας που εμφανίζει την εικόνα στην πρώτη διαφάνεια.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε εικόνα**

Αυτό το παράδειγμα διασφαλίζει ότι μια διαφάνεια περιέχει πλαίσιο εικόνας και στη συνέχεια προσπελάζει το πρώτο που εντοπίζει.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Πρόσβαση στο πρώτο PictureFrame στη διαφάνεια.
        $firstPictureFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $firstPictureFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```