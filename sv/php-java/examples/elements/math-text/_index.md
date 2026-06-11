---
title: Matematisk text
type: docs
weight: 160
url: /sv/php-java/examples/elements/math-text/
keywords:
- matematisk text
- lägg till matematisk text
- komma åt matematisk text
- ta bort matematisk text
- formatera matematisk text
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Arbeta med matematisk text i PHP med Aspose.Slides: skapa och redigera ekvationer, bråk, rotuttryck, script, formatering och rendera resultat för PPT och PPTX."
---
Illustrerar hur man arbetar med matematiska textformer och formaterar ekvationer med **Aspose.Slides for PHP via Java**.

## **Lägg till matematisk text**

Skapa en matematisk form som innehåller en bråkdel och Pythagoras formel.

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Lägg till en matematisk form på bilden.
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // Kom åt det matematiska stycket.
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // Lägg till ett enkelt bråk: x / y.
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // Lägg till ekvation: c² = a² + b².
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

## **Kom åt matematisk text**

Hitta en form som innehåller ett matematiskt stycke på bilden.

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Hitta den första formen som innehåller ett matematiskt stycke.
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

## **Ta bort matematisk text**

Ta bort en matematisk form från bilden.

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antag att den första formen på bilden är en Math-form.
        $mathShape = $slide->getShapes()->get_Item(0);

        // Ta bort Math-formen från bilden.
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Formatera matematisk text**

Ange teckensnittsegenskaper för en matematisk del.

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antag att den första formen på bilden är en Math-form.
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