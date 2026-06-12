---
title: Inkt
type: docs
weight: 180
url: /nl/php-java/examples/elements/ink/
keywords:
- inkt
- toegang tot inkt
- inkt verwijderen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer digitale inkt op dia's in PHP met Aspose.Slides: voeg penstreken toe, bewerk paden, stel kleur en breedte in, en exporteer resultaten voor PowerPoint en OpenDocument."
---
Biedt voorbeelden van het benaderen van bestaande inktvormen en het verwijderen ervan met **Aspose.Slides for PHP via Java**.

> ❗ **Opmerking:** Inktvormen vertegenwoordigen gebruikersinvoer van gespecialiseerde apparaten. Aspose.Slides kan geen nieuwe inktstreken programmatisch creëren, maar je kunt bestaande inkt lezen en aanpassen.

## **Toegang tot inkt**

Haal de eerste inktvorm op een dia.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Toegang tot de eerste inktvorm op de dia.
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

## **Ink verwijderen**

Verwijder een inktvorm van de dia.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aannemend dat de eerste vorm op de dia een inktvorm is.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```