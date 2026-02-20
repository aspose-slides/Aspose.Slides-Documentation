---
title: شريحة تخطيط
type: docs
weight: 20
url: /ar/php-java/examples/elements/layout-slide/
keywords:
- شريحة تخطيط
- إضافة شريحة تخطيط
- الوصول إلى شريحة تخطيط
- حذف شريحة تخطيط
- شريحة تخطيط غير مستخدمة
- استنساخ شريحة تخطيط
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "استخدم PHP لإدارة شرائح التخطيط مع Aspose.Slides: إنشاء، تطبيق، استنساخ، إعادة تسمية وتخصيص العناصر النائبة والسمات في العروض التقديمية لملفات PPT و PPTX و ODP."
---
هذه المقالة توضح كيفية التعامل مع **Layout Slides** في Aspose.Slides لـ PHP عبر Java. يحدد شريحة التخطيط التصميم والتنسيق الموروث من الشرائح العادية. يمكنك إضافة، الوصول، استنساخ، وإزالة شرائح التخطيط، بالإضافة إلى تنظيف الشرائح غير المستخدمة لتقليل حجم العرض.

## **إضافة شريحة تخطيط**

يمكنك إنشاء شريحة تخطيط مخصصة لتحديد تنسيق قابل لإعادة الاستخدام. على سبيل المثال، قد تضيف مربع نص يظهر في جميع الشرائح التي تستخدم هذا التخطيط.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // إنشاء شريحة تخطيط بنوع تخطيط فارغ واسم مخصص.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **نصيحة 1:** تعمل شرائح التخطيط كقوالب للشرائح الفردية. يمكنك تعريف العناصر المشتركة مرة واحدة وإعادة استخدامها عبر العديد من الشرائح.
>
> 💡 **نصيحة 2:** عندما تضيف أشكالًا أو نصًا إلى شريحة التخطيط، ستعرض جميع الشرائح المستندة إلى ذلك التخطيط هذا المحتوى المشترك تلقائيًا.
> الصورة أدناه توضح شريحتين، كل واحدة تورث مربع نص من نفس شريحة التخطيط.

![شرائح وراثة محتوى التخطيط](layout-slide-result.png)


## **الوصول إلى شريحة تخطيط**

يمكن الوصول إلى شرائح التخطيط بواسطة الفهرس أو بواسطة نوع التخطيط (مثل `Blank`, `Title`, `SectionHeader`، إلخ).

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // الوصول حسب الفهرس.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // الوصول حسب نوع التخطيط.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة شريحة تخطيط**

يمكنك إزالة شريحة تخطيط محددة إذا لم تعد بحاجة إليها.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // احصل على شريحة تخطيط حسب النوع وأزلها.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة شرائح التخطيط غير المستخدمة**

لتقليل حجم العرض، قد ترغب في إزالة شرائح التخطيط التي لا تستخدمها أي شرائح عادية.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // يزيل تلقائيًا جميع شرائح التخطيط التي لا يتم الإشارة إليها من قبل أي شريحة.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **استنساخ شريحة تخطيط**

يمكنك استنساخ شريحة تخطيط باستخدام طريقة `addClone`.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // احصل على شريحة تخطيط موجودة حسب النوع.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // استنسخ شريحة التخطيط إلى نهاية مجموعة شرائح التخطيط.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **الملخص:** شرائح التخطيط هي أدوات قوية لإدارة التنسيق المتسق عبر الشرائح. تتيح Aspose.Slides تحكمًا كاملاً في إنشاء وإدارة وتحسين شرائح التخطيط.