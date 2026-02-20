---
title: Mathe-Text
type: docs
weight: 160
url: /de/php-java/examples/elements/math-text/
keywords:
- Mathe-Text
- Mathe-Text hinzufügen
- Mathe-Text abrufen
- Mathe-Text entfernen
- Mathe-Text formatieren
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Arbeiten Sie mit mathematischem Text in PHP mithilfe von Aspose.Slides: Erstellen und bearbeiten Sie Gleichungen, Brüche, Radikale, Skripte, Formatierungen und rendern Sie die Ergebnisse für PPT und PPTX."
---
Veranschaulicht die Arbeit mit mathematischen Textformen und das Formatieren von Gleichungen mit **Aspose.Slides for PHP via Java**.

## **Mathe-Text hinzufügen**

Erstellen Sie eine mathematische Form, die einen Bruch und die pythagoreische Formel enthält.

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Füge der Folie eine mathematische Form hinzu.
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // Greife auf den mathematischen Absatz zu.
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // Füge einen einfachen Bruch hinzu: x / y.
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // Füge die Gleichung hinzu: c² = a² + b².
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

## **Mathe-Text abrufen**

Suchen Sie eine Form, die einen mathematischen Absatz auf der Folie enthält.

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Finde die erste Form, die einen mathematischen Absatz enthält.
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

## **Mathe-Text entfernen**

Löschen Sie eine mathematische Form von der Folie.

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, die erste Form auf der Folie ist eine mathematische Form.
        $mathShape = $slide->getShapes()->get_Item(0);

        // Entferne die mathematische Form von der Folie.
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Mathe-Text formatieren**

Legen Sie die Schriftart-Eigenschaften für einen mathematischen Teil fest.

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, die erste Form auf der Folie ist eine mathematische Form.
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