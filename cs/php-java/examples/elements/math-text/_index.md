---
title: Matematický text
type: docs
weight: 160
url: /cs/php-java/examples/elements/math-text/
keywords:
- matematický text
- přidat matematický text
- přístup k matematickému textu
- odstranit matematický text
- formátovat matematický text
- ukázky kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Pracujte s matematickým textem v PHP pomocí Aspose.Slides: vytvářejte a upravujte rovnice, zlomky, odmocniny, skripty, formátování a renderujte výsledky pro PPT a PPTX."
---
Ukazuje práci s matematickými textovými tvary a formátování rovnic pomocí **Aspose.Slides for PHP via Java**.

## **Přidat matematický text**

Vytvořte matematický tvar obsahující zlomek a Pythagorovu větu.

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přidejte matematický tvar na snímek.
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // Přístup k matematickému odstavci.
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // Přidejte jednoduchý zlomek: x / y.
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // Přidejte rovnici: c² = a² + b².
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

## **Přístup k matematickému textu**

Najděte tvar, který na snímku obsahuje matematický odstavec.

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Najděte první tvar, který obsahuje matematický odstavec.
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

## **Odstranit matematický text**

Odstraňte matematický tvar ze snímku.

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že první tvar na snímku je matematický tvar.
        $mathShape = $slide->getShapes()->get_Item(0);

        // Odstraňte matematický tvar ze snímku.
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Formátovat matematický text**

Nastavte vlastnosti písma pro matematickou část.

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že první tvar na snímku je matematický tvar.
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