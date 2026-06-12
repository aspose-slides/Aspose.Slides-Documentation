---
title: Inkoust
type: docs
weight: 180
url: /cs/php-java/examples/elements/ink/
keywords:
- inkoust
- přístup k inkoustu
- odstranění inkoustu
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Manipulujte s digitálním inkoustem na snímcích v PHP pomocí Aspose.Slides: přidejte tahy pera, upravte cesty, nastavte barvu a šířku a exportujte výsledky pro PowerPoint a OpenDocument."
---
Poskytuje příklady přístupu k existujícím inkoustovým tvarům a jejich odstraňování pomocí **Aspose.Slides for PHP via Java**.

> ❗ **Poznámka:** Inkoustové tvary představují vstup uživatele ze specializovaných zařízení. Aspose.Slides nemůže programově vytvářet nové inkoustové tahy, ale můžete číst a upravovat existující inkoust.

## **Přístup k inkoustu**

Získejte první inkoustový tvar na snímku.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přístup k prvnímu inkoustovému tvaru na snímku.
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

## **Odstranit inkoust**

Odstraňte inkoustový tvar ze snímku.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že první tvar na snímku je inkoustový tvar.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```