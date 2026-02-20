---
title: مربع النص
type: docs
weight: 40
url: /ar/php-java/examples/elements/text-box/
keywords:
- مربع نص
- إضافة مربع نص
- الوصول إلى مربع نص
- إزالة مربع نص
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتنسيق مربعات النص في PHP باستخدام Aspose.Slides: ضبط الخطوط والمحاذاة والالتفاف، والملاءمة التلقائية، وإضافة الروابط لتحسين الشرائح لـ PowerPoint وOpenDocument."
---
في Aspose.Slides، يتم تمثيل **مربع النص** بواسطة `AutoShape`. يمكن لأي شكل تقريبًا أن يحتوي على نص، ولكن مربع النص النموذجي لا يحتوي على تعبئة أو إطار ويعرض النص فقط.

يشرح هذا الدليل كيفية إضافة مربعات النص والوصول إليها وإزالتها برمجيًا.

## **إضافة مربع نص**

مربع النص هو ببساطة `AutoShape` بدون تعبئة أو إطار وبعض النص المنسق. إليك طريقة إنشائه:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // إنشاء شكل مستطيل (الإعدادات الافتراضية مملوء بحدود ولا يحتوي على نص).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // إزالة التعبئة والحد لتظهر كمربع نص نموذجي.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // ضبط تنسيق النص.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // تعيين محتوى النص الفعلي.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **ملاحظة:** أي `AutoShape` يحتوي على `TextFrame` غير فارغ يمكن أن يعمل كمربع نص.

## **الوصول إلى مربعات النص بحسب المحتوى**

للعثور على جميع مربعات النص التي تحتوي على كلمة مفتاحية محددة (مثال: "Slide")، قم بالتكرار عبر الأشكال وتحقق من نصها:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // الوصول إلى أول مربع نص في الشريحة.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // إجراء شيء ما على مربع النص المتطابق.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة مربعات النص بحسب المحتوى**

هذا المثال يجد ويحذف جميع مربعات النص في الشريحة الأولى التي تحتوي على كلمة مفتاحية محددة:

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **نصيحة:** احرص دائمًا على إنشاء نسخة من مجموعة الأشكال قبل تعديلها أثناء التكرار لتجنب أخطاء تعديل المجموعة.