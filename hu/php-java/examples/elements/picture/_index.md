---
title: Kép
type: docs
weight: 50
url: /hu/php-java/examples/elements/picture/
keywords:
- kép
- képkocka
- kép hozzáadása
- kép elérése
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Képek kezelése PHP-ben az Aspose.Slides használatával: beszúrás, cserélés, vágás, tömörítés, átlátszóság és hatások állítása, alakzatok kitöltése, valamint exportálás PPT, PPTX és ODP formátumokba."
---
Bemutatja, hogyan lehet képeket beszúrni és elérni az **Aspose.Slides for PHP via Java** segítségével. Az alábbi példák egy képet helyeznek el egy dián, majd visszakeresik azt.

## **Kép hozzáadása**

Ez a kód egy képet képkockaként helyez el az első dián.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Adja hozzá a képet a bemutató erőforrásaihoz.
        $ppImage = $presentation->getImages()->addImage($image);

        // Helyezzen be egy képkockát, amely megjeleníti a képet az első dián.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Kép elérése**

Ez a példa biztosítja, hogy a dia tartalmaz egy képkockát, majd eléri az első megtaláltat.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // A dián található első PictureFrame elérése.
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