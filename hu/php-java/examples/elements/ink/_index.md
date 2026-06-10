---
title: Tinta
type: docs
weight: 180
url: /hu/php-java/examples/elements/ink/
keywords:
- tinta
- tinta elérése
- tinta eltávolítása
- kódpéldák
- PowerPoint
- OpenDocument
- bemutató
- PHP
- Aspose.Slides
description: "Digitális tinta kezelése diákon PHP-vel az Aspose.Slides segítségével: hozzáadhat tollvonásokat, szerkesztheti az útvonalakat, beállíthatja a színt és a szélességet, valamint exportálhatja az eredményeket PowerPoint és OpenDocument formátumba."
---
Példákat biztosít a meglévő tinta alakzatok elérésére és azok eltávolítására a **Aspose.Slides for PHP via Java** használatával.

> ❗ **Megjegyzés:** A tinta alakzatok a speciális eszközök felhasználói bevitelét képviselik. Az Aspose.Slides programból nem tud új tinta vonalakat létrehozni, de a meglévő tintát olvashatja és módosíthatja.

## **Tinta elérése**

Szerezze meg az első tinta alakzatot egy dián.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // A dia első tinta alakzatának elérése.
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

## **Tinta eltávolítása**

Törölje a tinta alakzatot a diáról.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a dia első alakzata egy tinta alakzat.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```