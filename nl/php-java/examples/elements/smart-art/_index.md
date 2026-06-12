---
title: SmartArt
type: docs
weight: 140
url: /nl/php-java/examples/elements/smartart/
keywords:
- SmartArt
- SmartArt toevoegen
- SmartArt openen
- SmartArt verwijderen
- SmartArt lay-out
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Bouw en bewerk SmartArt in PHP met Aspose.Slides: voeg knooppunten toe, wijzig lay-outs en stijlen, zet om naar vormen met precisie, en exporteer naar PPT, PPTX en ODP."
---
Toont hoe je SmartArt-illustraties toevoegt, er toegang toe krijgt, ze verwijdert en lay-outs wijzigt met **Aspose.Slides for PHP via Java**.

## **SmartArt toevoegen**
Voeg een SmartArt-illustratie in met een van de ingebouwde lay-outs.

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

## **SmartArt openen**
Haal het eerste SmartArt-object op een dia op.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Toegang tot de eerste SmartArt op de dia.
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

## **SmartArt verwijderen**
Verwijder een SmartArt-vorm van de dia.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aannemende dat de eerste vorm op de dia een SmartArt is.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **SmartArt lay-out wijzigen**
Werk het lay-outtype van een bestaande SmartArt-illustratie bij.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aannemende dat de eerste vorm op de dia een SmartArt is.
        $smartArt = $slide->getShapes()->get_Item(0);

        // Wijzig de lay-out van de SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```