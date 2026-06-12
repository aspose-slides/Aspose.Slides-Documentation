---
title: Obrázek
type: docs
weight: 50
url: /cs/php-java/examples/elements/picture/
keywords:
- obrázek
- rám obrázku
- přidat obrázek
- přístup k obrázku
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Práce s obrázky v PHP pomocí Aspose.Slides: vkládání, nahrazování, ořezávání, komprese, úprava průhlednosti a efektů, vyplňování tvarů a export do PPT, PPTX a ODP."
---
Ukazuje, jak vkládat a přistupovat k obrázkům pomocí **Aspose.Slides for PHP via Java**. Níže uvedené příklady umístí obrázek na snímek a poté jej načtou.

## **Přidání obrázku**

Tento kód vloží obrázek jako rámeček na první snímek.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Přidejte obrázek do zdrojů prezentace.
        // Vložte rámeček obrázku zobrazující obrázek na první snímek.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Přístup k obrázku**

Tento příklad zajistí, že snímek obsahuje rámeček s obrázkem, a poté přistoupí k prvnímu nalezenému.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přístup k prvnímu PictureFrame na snímku.
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