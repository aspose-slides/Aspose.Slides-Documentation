---
title: Fejléc és lábléc
type: docs
weight: 220
url: /hu/php-java/examples/elements/header-footer/
keywords:
- fejléc és lábléc
- fejléc és lábléc hozzáadása
- fejléc és lábléc frissítése
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "A fejléc és lábléc vezérlése PHP-ben az Aspose.Slides segítségével: dátum/idő vagy dia számok és lábléc szöveg hozzáadása vagy szerkesztése, helyőrzők megjelenítése vagy elrejtése PPT, PPTX és ODP formátumokban."
---
Bemutatja, hogyan lehet láblécet hozzáadni és a dátum‑ és időhelyőrzőket frissíteni az **Aspose.Slides for PHP via Java** használatával.

## **Lábléc hozzáadása**
Szöveget ad a dia lábléc területéhez, és láthatóvá teszi.

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Dátum és idő frissítése**
Módosítsa a dia dátum‑ és időhelyőrzőjét.

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```