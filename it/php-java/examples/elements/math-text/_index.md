---
title: Testo Matematico
type: docs
weight: 160
url: /it/php-java/examples/elements/math-text/
keywords:
- testo matematico
- aggiungi testo matematico
- accedi al testo matematico
- rimuovi testo matematico
- formatta testo matematico
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Lavora con il testo matematico in PHP usando Aspose.Slides: crea e modifica equazioni, frazioni, radici, script, formattazione e genera risultati per PPT e PPTX."
---
Illustra come lavorare con le forme di testo matematico e formattare le equazioni utilizzando **Aspose.Slides for PHP via Java**.

## **Aggiungi Testo Matematico**

Crea una forma matematica contenente una frazione e la formula di Pitagora.

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aggiungi una forma matematica alla diapositiva.
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // Accedi al paragrafo matematico.
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // Aggiungi una frazione semplice: x / y.
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // Aggiungi un'equazione: c² = a² + b².
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

## **Accedi al Testo Matematico**

Individua una forma che contiene un paragrafo matematico nella diapositiva.

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Trova la prima forma che contiene un paragrafo matematico.
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

## **Rimuovi Testo Matematico**

Elimina una forma matematica dalla diapositiva.

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supponendo che la prima forma nella diapositiva sia una forma Math.
        $mathShape = $slide->getShapes()->get_Item(0);

        // Rimuovi la forma Math dalla diapositiva.
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Formatta Testo Matematico**

Imposta le proprietà del carattere per una porzione matematica.

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supponendo che la prima forma nella diapositiva sia una forma Math.
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