---
title: انتقال الشريحة
type: docs
weight: 110
url: /ar/php-java/examples/elements/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال الشريحة
- الوصول إلى انتقال الشريحة
- إزالة انتقال الشريحة
- مدة الانتقال
- أمثلة التعليمات البرمجية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحكم في انتقالات الشرائح في PHP مع Aspose.Slides: اختر الأنواع، السرعة، الصوت، والتوقيت لتحسين العروض التقديمية بصيغ PPT و PPTX و ODP."
---
يوضح تطبيق تأثيرات انتقال الشرائح والتوقيتات باستخدام **Aspose.Slides for PHP via Java**.

## **إضافة انتقال شريحة**

تطبيق تأثير انتقال تلاشي على الشريحة الأولى.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // تطبيق انتقال تلاشي.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **الوصول إلى انتقال شريحة**

قراءة نوع الانتقال المعين لشريحة.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // الوصول إلى نوع الانتقال.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة انتقال شريحة**

مسح أي تأثير انتقال عن طريق تعيين النوع إلى `None`.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // إزالة الانتقال بتعيين none.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **تعيين مدة الانتقال**

تحديد المدة التي تُعرض فيها الشريحة قبل الانتقال تلقائيًا.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // بالملي ثانية.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```