---
title: حبر
type: docs
weight: 180
url: /ar/php-java/examples/elements/ink/
keywords:
- حبر
- الوصول إلى الحبر
- إزالة الحبر
- أمثلة على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "التعامل مع الحبر الرقمي على الشرائح في PHP باستخدام Aspose.Slides: إضافة ضربات القلم، تعديل المسارات، ضبط اللون والعرض، وتصدير النتائج لـ PowerPoint وOpenDocument."
---
يوفر أمثلة على الوصول إلى أشكال الحبر الموجودة وإزالتها باستخدام **Aspose.Slides for PHP via Java**.

> ❗ **ملاحظة:** تمثل أشكال الحبر إدخال المستخدم من الأجهزة المتخصصة. لا يمكن لـ Aspose.Slides إنشاء خطوط حبر جديدة برمجياً، لكن يمكنك قراءة الحبر الموجود وتعديله.

## **الوصول إلى الحبر**

احصل على أول شكل حبر في الشريحة.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // الوصول إلى أول شكل حبر في الشريحة.
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة الحبر**

احذف شكل حبر من الشريحة.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // بافتراض أن الشكل الأول في الشريحة هو شكل حبر.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```