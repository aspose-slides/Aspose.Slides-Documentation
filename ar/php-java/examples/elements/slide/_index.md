---
title: شريحة
type: docs
weight: 10
url: /ar/php-java/examples/elements/slide/
keywords:
- شريحة
- إضافة شريحة
- الوصول إلى شريحة
- فهرس الشريحة
- استنساخ شريحة
- إعادة ترتيب الشرائح
- إزالة شريحة
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة الشرائح في PHP باستخدام Aspose.Slides: إنشاء، استنساخ، إعادة ترتيب، إخفاء، تعيين الخلفيات والحجم، تطبيق الانتقالات، وتصدير إلى PowerPoint وOpenDocument."
---
توفر هذه المقالة مجموعة من الأمثلة التي توضح كيفية العمل مع الشرائح باستخدام **Aspose.Slides for PHP via Java**. ستتعلم كيفية إضافة، الوصول، استنساخ، إعادة ترتيب، وإزالة الشرائح باستخدام الفئة `Presentation`.

كل مثال أدناه يتضمن شرحًا موجزًا يليه مقطع شفرة بلغة PHP.

## **إضافة شريحة**

لإضافة شريحة جديدة، يجب أولاً اختيار تخطيط. في هذا المثال، نستخدم تخطيط `Blank` ونضيف شريحة فارغة إلى العرض التقديمي.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // كل شريحة تستند إلى تخطيط، والذي نفسه يستند إلى شريحة رئيسية.
        // استخدم التخطيط الفارغ لإنشاء شريحة جديدة.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // أضف شريحة فارغة جديدة باستخدام التخطيط المحدد.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **نصيحة:** كل تخطيط شريحة مشتق من شريحة رئيسية، التي تحدد التصميم العام وبنية العناصر النائبة. الصورة أدناه توضح كيفية تنظيم الشرائح الرئيسية وتخطيطاتها المرتبطة في PowerPoint.

![العلاقة بين الشريحة الرئيسية والتخطيط](master-layout-slide.png)

## **الوصول إلى الشرائح وفق الفهرس**

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // الوصول إلى شريحة حسب الفهرس.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **استنساخ شريحة**

```php
function cloneSlide() {
    // افتراضيًا، يحتوي العرض التقديمي على شريحة فارغة واحدة.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // استنسخ الشريحة الأولى؛ سيتم إضافتها في نهاية العرض التقديمي.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // فهرس الشريحة المستنسخة هو 1 (الشريحة الثانية في العرض التقديمي).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **إعادة ترتيب الشرائح**

يمكنك تغيير ترتيب الشرائح عن طريق نقل إحدى الشرائح إلى فهرس جديد. في هذه الحالة، ننقل شريحة إلى الموضع الأول.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // انقل الشريحة إلى الموضع الأول (تتحرك الأخرى إلى الأسفل).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة شريحة**

لإزالة شريحة، ما عليك سوى الإشارة إليها واستدعاء `remove`. يوضح هذا المثال كيفية إزالة الشرائح وفق الفهرس أو وفق الإشارة.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // إزالة شريحة حسب الفهرس.
        $presentation->getSlides()->removeAt(0);

        // إزالة شريحة حسب الإشارة.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```