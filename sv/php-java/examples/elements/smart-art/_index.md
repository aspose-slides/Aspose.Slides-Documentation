---
title: SmartArt
type: docs
weight: 140
url: /sv/php-java/examples/elements/smartart/
keywords:
- SmartArt
- lägga till SmartArt
- komma åt SmartArt
- ta bort SmartArt
- SmartArt-layout
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Skapa och redigera SmartArt i PHP med Aspose.Slides: lägg till noder, ändra layouter och stilar, konvertera till former med precision och exportera för PPT, PPTX och ODP."
---
Visar hur du lägger till SmartArt-grafik, kommer åt dem, tar bort dem och ändrar layouter med **Aspose.Slides for PHP via Java**.

## **Lägg till SmartArt**

Infoga en SmartArt-grafik med hjälp av en av de inbyggda layouterna.

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

## **Kom åt SmartArt**

Hämta det första SmartArt-objektet på en bild.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Kom åt den första SmartArt på bilden.
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

## **Ta bort SmartArt**

Ta bort en SmartArt-form från bilden.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antag att den första formen på bilden är en SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ändra SmartArt-layout**

Uppdatera layouttypen för en befintlig SmartArt-grafik.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antar att den första formen på bilden är en SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // Ändra layouten för SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```