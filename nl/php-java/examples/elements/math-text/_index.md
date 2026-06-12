---
title: Wiskundige tekst
type: docs
weight: 160
url: /nl/php-java/examples/elements/math-text/
keywords:
- wiskundige tekst
- wiskundige tekst toevoegen
- wiskundige tekst openen
- wiskundige tekst verwijderen
- wiskundige tekst opmaken
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Werk met wiskundige tekst in PHP met Aspose.Slides: maak en bewerk vergelijkingen, breuken, wortels, scripts, opmaak, en render resultaten voor PPT en PPTX."
---
Illustreert hoe je werkt met wiskundige tekstvormen en het opmaken van vergelijkingen met **Aspose.Slides for PHP via Java**.

## **Wiskundige tekst toevoegen**

Maak een wiskundige vorm die een breuk en de stelling van Pythagoras bevat.

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Voeg een wiskundige vorm toe aan de dia.
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // Open de wiskundige alinea.
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // Voeg een eenvoudige breuk toe: x / y.
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // Voeg vergelijking toe: c² = a² + b².
        $mathBlock = (new MathematicalText("c"))
            - >setSuperscript("2")
            - >join("=")
            - >join((new MathematicalText("a"))->setSuperscript("2"))
            - >join("+")
            - >join((new MathematicalText("b"))->setSuperscript("2"));
        $mathParagraph->add($mathBlock);

        $presentation->save("math_text.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Wiskundige tekst openen**

Zoek een vorm die een wiskundige alinea op de dia bevat.

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zoek de eerste vorm die een wiskundige alinea bevat.
        $mathShape = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $textFrame = $shape->getTextFrame();
                if ($textFrame !== null) {
                    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
                    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                        $portionCount = java_values($paragraph->getPortions()->getCount());
                        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                            $portion = $paragraph->getPortions()->get_Item($portionIndex);
                            if (java_instanceof($portion, new JavaClass("com.aspose.slides.MathPortion"))) {
                                $mathShape = $shape;
                                break 3;
                            }
                        }
                    }
                }
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Wiskundige tekst verwijderen**

Verwijder een wiskundige vorm van de dia.

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Veronderstel dat de eerste vorm op de dia een wiskundige vorm is.
        $mathShape = $slide->getShapes()->get_Item(0);

        // Verwijder de wiskundige vorm van de dia.
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Wiskundige tekst opmaken**

Stel de lettertype‑eigenschappen in voor een wiskundig deel.

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Veronderstel dat de eerste vorm op de dia een wiskundige vorm is.
        $mathShape = $slide->getShapes()->get_Item(0);

        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(20);

        $presentation->save("math_text_formatted.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```