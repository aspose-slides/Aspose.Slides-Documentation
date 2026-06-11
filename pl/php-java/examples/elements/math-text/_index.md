---
title: Tekst Matematyczny
type: docs
weight: 160
url: /pl/php-java/examples/elements/math-text/
keywords:
  - tekst matematyczny
  - dodaj tekst matematyczny
  - dostęp do tekstu matematyczny
  - usuń tekst matematyczny
  - formatuj tekst matematyczny
  - przykłady kodu
  - PowerPoint
  - OpenDocument
  - prezentacja
  - PHP
  - Aspose.Slides
description: "Pracuj z tekstem matematycznym w PHP przy użyciu Aspose.Slides: twórz i edytuj równania, ułamki, pierwiastki, indeksy, formatowanie oraz renderuj wyniki dla formatów PPT i PPTX."
---
Ilustruje pracę z kształtami tekstowymi matematycznymi i formatowaniem równań przy użyciu **Aspose.Slides for PHP via Java**.

## **Dodaj tekst matematyczny**

Utwórz kształt matematyczny zawierający ułamek i wzór Pitagorasa.

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Dodaj kształt matematyczny do slajdu.
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // Uzyskaj dostęp do akapitu matematycznego.
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // Dodaj prosty ułamek: x / y.
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // Dodaj równanie: c² = a² + b².
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

## **Dostęp do tekstu matematycznego**

Zlokalizuj kształt zawierający akapit matematyczny na slajdzie.

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Znajdź pierwszy kształt, który zawiera akapit matematyczny.
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

## **Usuń tekst matematyczny**

Usuń kształt matematyczny ze slajdu.

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszy kształt na slajdzie jest kształtem Math.
        $mathShape = $slide->getShapes()->get_Item(0);

        // Usuń kształt Math ze slajdu.
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Formatuj tekst matematyczny**

Ustaw właściwości czcionki dla fragmentu matematycznego.

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszy kształt na slajdzie jest kształtem Math.
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