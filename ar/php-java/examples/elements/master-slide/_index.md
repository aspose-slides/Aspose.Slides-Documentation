---
title: شريحة ماستر
type: docs
weight: 30
url: /ar/php-java/examples/elements/master-slide/
keywords:
- شريحة ماستر
- إضافة شريحة ماستر
- الوصول إلى شريحة ماستر
- إزالة شريحة ماستر
- شريحة ماستر غير مستخدمة
- أمثلة على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة شرائح الماستر في PHP باستخدام Aspose.Slides: الإنشاء، التحرير، الاستنساخ، وتنسيق القوالب، الخلفيات، العناصر النائبة لتوحيد الشرائح في PowerPoint و OpenDocument."
---
تشكل شرائح الماستر المستوى الأعلى في هيكلية وراثة الشرائح في PowerPoint. تُعرّف **شريحة ماستر** عناصر التصميم المشتركة مثل الخلفيات والشعارات وتنسيق النص. **شرائح التخطيط** ترث من شرائح الماستر، و**الشرائح العادية** ترث من شرائح التخطيط.

يوضح هذا المقال كيفية إنشاء وتعديل وإدارة شرائح الماستر باستخدام Aspose.Slides لـ PHP عبر Java.

## **إضافة شريحة ماستر**

يوضح هذا المثال كيفية إنشاء شريحة ماستر جديدة عن طريق استنساخ الشريحة الافتراضية.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // استنساخ شريحة الماستر الافتراضية.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **نصيحة 1:** توفر شرائح الماستر وسيلة لتطبيق هوية علامة تجارية متسقة أو عناصر تصميم مشتركة عبر جميع الشرائح. أي تغييرات تُجرى على الماستر ستنعكس تلقائيًا على شرائح التخطيط والشرائح العادية التابعة.  
> 💡 **نصيحة 2:** أي أشكال أو تنسيقات تُضاف إلى شريحة ماستر تُورّث إلى شرائح التخطيط، ومن ثم إلى جميع الشرائح العادية التي تستخدم تلك التخطيطات.  
> الصورة أدناه توضح كيف يتم عرض صندوق نص تمت إضافته على شريحة ماستر تلقائيًا على الشريحة النهائية.

![Master Inheritance Example](master-slide-banner.png)

## **الوصول إلى شريحة ماستر**

يمكنك الوصول إلى شرائح الماستر باستخدام طريقة `Presentation::getMasters`. إليك كيفية استرجاعها والعمل معها:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // الوصول إلى شريحة الماستر الأولى.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة شريحة ماستر**

يمكن حذف شرائح الماستر إما بحسب الفهرس أو بالمرجع.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // الإزالة حسب الفهرس.
        $presentation->getMasters()->removeAt(0);

        // أو الإزالة بالمرجع.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة شرائح الماستر غير المستخدمة**

بعض العروض التقديمية تحتوي على شرائح ماستر غير مستخدمة. حذف هذه الشرائح يمكن أن يساعد في تقليل حجم الملف.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // إزالة جميع شرائح الماستر غير المستخدمة (حتى تلك التي تم وضع علامة Preserve عليها).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **نصيحة:** استخدم `removeUnused(true)` لتنظيف شرائح الماستر غير المستخدمة وتقليل حجم العرض التقديمي.