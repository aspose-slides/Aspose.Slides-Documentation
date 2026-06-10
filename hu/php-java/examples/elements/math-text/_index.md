---
title: Matematikai szöveg
type: docs
weight: 160
url: /hu/php-java/examples/elements/math-text/
keywords:
- matematikai szöveg
- matematikai szöveg hozzáadása
- matematikai szöveg elérése
- matematikai szöveg eltávolítása
- matematikai szöveg formázása
- kód példák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Matematikai szöveggel való munka PHP-ben az Aspose.Slides használatával: egyenletek, törtök, gyökök, felső és alsó indexek, formázás létrehozása és szerkesztése, valamint a PPT és PPTX eredmények renderelése."
---
Bemutatja a matematikai szöveges alakzatok használatát és egyenletek formázását **Aspose.Slides for PHP via Java** segítségével.

## **Matematikai szöveg hozzáadása**

Hozzon létre egy matematikai alakzatot, amely tartalmaz egy törtet és a Pithagorasz-formulát.

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Math alakzat hozzáadása a diára.
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // A matematikai bekezdés elérése.
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // Egyszerű tört hozzáadása: x / y.
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // Egyenlet hozzáadása: c² = a² + b².
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

## **Matematikai szöveg elérése**

Keressen egy olyan alakzatot, amely a dián matematikai bekezdést tartalmaz.

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Az első alakzat megtalálása, amely matematikai bekezdést tartalmaz.
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

## **Matematikai szöveg eltávolítása**

Törölje a matematikai alakzatot a diáról.

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a dián lévő első alakzat egy matematikai alakzat.
        $mathShape = $slide->getShapes()->get_Item(0);

        // A matematikai alakzat eltávolítása a diáról.
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Matematikai szöveg formázása**

Állítsa be a betűtípus tulajdonságait egy matematikai részhez.

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a dián lévő első alakzat egy matematikai alakzat.
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