---
title: Bild
type: docs
weight: 50
url: /de/php-java/examples/elements/picture/
keywords:
- Bild
- Bildrahmen
- Bild hinzufügen
- Bild abrufen
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Arbeiten Sie mit Bildern in PHP mithilfe von Aspose.Slides: Einfügen, Ersetzen, Zuschneiden, Komprimieren, Transparenz und Effekte anpassen, Formen füllen und für PPT, PPTX und ODP exportieren."
---
Zeigt, wie man Bilder mithilfe von **Aspose.Slides for PHP via Java** einfügt und darauf zugreift. Die nachstehenden Beispiele platzieren ein Bild auf einer Folie und rufen es anschließend ab.

## **Bild hinzufügen**

Dieser Code fügt ein Bild als Bildrahmen auf der ersten Folie ein.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Bild zu den Präsentationsressourcen hinzufügen.
        $ppImage = $presentation->getImages()->addImage($image);

        // Bildrahmen einfügen, der das Bild auf der ersten Folie zeigt.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Zugriff auf ein Bild**

Dieses Beispiel stellt sicher, dass eine Folie einen Bildrahmen enthält, und greift anschließend auf den ersten gefundenen zu.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zugriff auf den ersten Bildrahmen auf der Folie.
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