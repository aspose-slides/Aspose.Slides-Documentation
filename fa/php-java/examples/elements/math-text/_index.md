---
title: متن ریاضی
type: docs
weight: 160
url: /fa/php-java/examples/elements/math-text/
keywords:
- متن ریاضی
- افزودن متن ریاضی
- دسترسی به متن ریاضی
- حذف متن ریاضی
- قالب‌بندی متن ریاضی
- مثال‌های کد
- پاورپوینت
- سند باز
- ارائه
- PHP
- Aspose.Slides
description: "کار کردن با متن ریاضی در PHP با استفاده از Aspose.Slides: ایجاد و ویرایش معادلات، کسرها، رادیکال‌ها، اسکریپت‌ها، قالب‌بندی، و رندر نتایج برای PPT و PPTX."
---
کارکرد با اشکال متن ریاضی و قالب‌بندی معادلات با استفاده از **Aspose.Slides for PHP via Java** را نشان می‌دهد.

## **افزودن متن ریاضی**
یک شکل ریاضی ایجاد کنید که شامل یک کسر و فرمول فیثاغورث باشد.

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // یک شکل ریاضی به اسلاید اضافه کنید.
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // دسترسی به پاراگراف ریاضی.
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // یک کسر ساده اضافه کنید: x / y.
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // یک معادله اضافه کنید: c² = a² + b².
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

## **دسترسی به متن ریاضی**
یک شکل حاوی یک پاراگراف ریاضی را در اسلاید پیدا کنید.

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // اولین شکلی را که شامل یک پاراگراف ریاضی است پیدا کنید.
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

## **حذف متن ریاضی**
یک شکل ریاضی را از اسلاید حذف کنید.

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض می‌کنیم اولین شکل در اسلاید یک شکل ریاضی است.
        $mathShape = $slide->getShapes()->get_Item(0);

        // شکل ریاضی را از اسلاید حذف کنید.
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **قالب‌بندی متن ریاضی**
ویژگی‌های قلم را برای بخشی از متن ریاضی تنظیم کنید.

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // فرض می‌کنیم اولین شکل در اسلاید یک شکل ریاضی است.
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