---
title: "نص رياضي"
type: docs
weight: 160
url: /ar/php-java/examples/elements/math-text/
keywords:
- "نص رياضي"
- "إضافة نص رياضي"
- "الوصول إلى نص رياضي"
- "إزالة نص رياضي"
- "تنسيق نص رياضي"
- "أمثلة على الكود"
- PowerPoint
- OpenDocument
- "عرض تقديمي"
- PHP
- Aspose.Slides
description: "العمل مع النص الرياضي في PHP باستخدام Aspose.Slides: إنشاء وتعديل المعادلات، الكسور، الجذور، النصوص الفرعية، التنسيق، وعرض النتائج لملفات PPT و PPTX."
---
يوضح العمل مع أشكال النص الرياضي وتنسيق المعادلات باستخدام **Aspose.Slides for PHP via Java**.

## **إضافة نص رياضي**

إنشاء شكل رياضي يحتوي على كسر وصيغة فيثاغورس.

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // إضافة شكل رياضي إلى الشريحة.
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // الوصول إلى الفقرة الرياضية.
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // إضافة كسر بسيط: x / y.
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // إضافة معادلة: c² = a² + b².
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

## **الوصول إلى نص رياضي**

تحديد موقع شكل يحتوي على فقرة رياضية في الشريحة.

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // العثور على أول شكل يحتوي على فقرة رياضية.
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

## **إزالة نص رياضي**

حذف شكل رياضي من الشريحة.

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // بافتراض أن الشكل الأول في الشريحة هو شكل رياضي.
        $mathShape = $slide->getShapes()->get_Item(0);

        // إزالة الشكل الرياضي من الشريحة.
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **تنسيق نص رياضي**

تعيين خصائص الخط لجزء رياضي.

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // بافتراض أن الشكل الأول في الشريحة هو شكل رياضي.
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