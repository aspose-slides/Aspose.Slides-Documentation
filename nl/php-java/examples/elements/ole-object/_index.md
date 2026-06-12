---
title: Ole-object
type: docs
weight: 210
url: /nl/php-java/examples/elements/ole-object/
keywords:
- OLE-object
- OLE-object toevoegen
- OLE-object benaderen
- OLE-object verwijderen
- OLE-object bijwerken
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Werk met OLE-objecten in PHP met behulp van Aspose.Slides: voeg ingesloten bestanden toe of werk ze bij, stel pictogrammen of koppelingen in, extraheer de inhoud, beheer het gedrag voor PPT, PPTX en ODP."
---
Toont hoe u een bestand als OLE-object insluit en de gegevens bijwerkt met behulp van **Aspose.Slides for PHP via Java**.

## **Voeg een OLE-object toe**

Een PDF-bestand inbedden in een presentatie.

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

## **Toegang tot een OLE-object**

Haal het eerste OLE-objectframe op een dia op.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Toegang tot het eerste OLE-frame op de dia.
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

## **Verwijder een OLE-object**

Verwijder een ingesloten OLE-object van de dia.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aangenomen dat de eerste vorm op de dia het OLE-frame is.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Werk OLE-objectgegevens bij**

Vervang de gegevens die in een bestaand OLE-object zijn ingesloten.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aangenomen dat de eerste vorm op de dia het OLE-frame is.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```