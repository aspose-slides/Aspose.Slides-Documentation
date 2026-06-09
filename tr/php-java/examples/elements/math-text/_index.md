---
title: Matematik Metni
type: docs
weight: 160
url: /tr/php-java/examples/elements/math-text/
keywords:
- matematik metni
- matematik metni ekle
- matematik metnine eriş
- matematik metnini kaldır
- matematik metnini biçimlendir
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides kullanarak PHP'de matematik metniyle çalışın: denklemler, kesirler, kökler, üst/alt simgeler, biçimlendirme oluşturun ve düzenleyin ve sonuçları PPT ve PPTX olarak render edin."
---
Matematik metin şekilleriyle çalışmayı ve denklemleri biçimlendirmeyi **Aspose.Slides for PHP via Java** kullanarak gösterir.

## **Matematik Metni Ekle**

Bir kesir ve Pisagor formülünü içeren bir matematik şekli oluşturun.

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayta bir Matematik şekli ekle.
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // Matematik paragrafına eriş.
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // Basit bir kesir ekle: x / y.
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // Denklem ekle: c² = a² + b².
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

## **Matematik Metnine Eriş**

Slaytta bir matematik paragrafı içeren bir şekli bulun.

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Matematik paragrafı içeren ilk şekli bulun.
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

## **Matematik Metnini Kaldır**

Slayttan bir matematik şekli silin.

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Kaydırmadaki ilk şeklin bir Matematik şekli olduğunu varsayarak.
        $mathShape = $slide->getShapes()->get_Item(0);

        // Matematik şekli kayıdrımdan kaldır.
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Matematik Metnini Biçimlendir**

Bir matematik bölümü için yazı tipi özelliklerini ayarlayın.

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Kaydırmadaki ilk şeklin bir Matematik şekli olduğunu varsayarak.
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