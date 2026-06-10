---
title: SmartArt
type: docs
weight: 140
url: /hu/php-java/examples/elements/smartart/
keywords:
- SmartArt
- SmartArt hozzáadása
- SmartArt elérése
- SmartArt eltávolítása
- SmartArt elrendezés
- kódpéldák
- PowerPoint
- OpenDocument
- bemutató
- PHP
- Aspose.Slides
description: "Készítsen és szerkesszen SmartArt-ot PHP-ben az Aspose.Slides használatával: adjon hozzá csomópontokat, módosítsa az elrendezéseket és stílusokat, pontosan konvertálja alakzatokká, és exportálja PPT, PPTX és ODP formátumokba."
---
Megmutatja, hogyan adhatunk hozzá SmartArt grafikákat, érhetjük el őket, távolíthatjuk el őket, és módosíthatjuk az elrendezéseket az **Aspose.Slides for PHP via Java** használatával.

## **SmartArt hozzáadása**

Helyezzünk el egy SmartArt grafikát az egyik beépített elrendezés használatával.

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

## **SmartArt elérése**

Szerezzük meg a dián található első SmartArt objektumot.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // A diában található első SmartArt elérése.
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

## **SmartArt eltávolítása**

Töröljük a SmartArt alakzatot a diáról.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a dián az első alakzat egy SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **SmartArt elrendezés módosítása**

Frissítsük egy létező SmartArt grafika elrendezésének típusát.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a dián az első alakzat egy SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // A SmartArt elrendezésének módosítása.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```