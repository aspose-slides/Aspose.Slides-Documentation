---
title: Objekt OLE
type: docs
weight: 210
url: /cs/php-java/examples/elements/ole-object/
keywords:
- objekt OLE
- přidat objekt OLE
- přístup k objektu OLE
- odstranit objekt OLE
- aktualizovat objekt OLE
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Pracujte s objekty OLE v PHP pomocí Aspose.Slides: vkládejte nebo aktualizujte vložené soubory, nastavujte ikony nebo odkazy, extrahujte obsah, ovládejte chování pro PPT, PPTX a ODP."
---
Ukazuje vložení souboru jako objektu OLE a aktualizaci jeho dat pomocí **Aspose.Slides for PHP via Java**.

## **Přidat objekt OLE**

Vložte soubor PDF do prezentace.

```php
function addOleObject() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $pdfData = new OleEmbeddedDataInfo(file_get_contents("doc.pdf"), "pdf");
        $oleFrame = $slide->getShapes()->addOleObjectFrame(20, 20, 50, 50, $pdfData);

        $presentation->save("ole_object.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Přístup k objektu OLE**

Získejte první rámec objektu OLE na snímku.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přístup k prvnímu OLE rámečku na snímku.
        $firstOleFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $firstOleFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Odstranit objekt OLE**

Odstraňte vložený objekt OLE ze snímku.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že první tvar na snímku je OLE rámeček.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Aktualizovat data objektu OLE**

Nahraďte data vložená v existujícím objektu OLE.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že první tvar na snímku je OLE rámec.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```