---
title: انتقال الشريحة
type: docs
weight: 110
url: /ar/java/examples/elements/slide-transition/
keywords:
- مثال على الكود
- انتقال الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إتقان انتقالات الشرائح في Aspose.Slides for Java: إضافة، تخصيص، وتسلسل التأثيرات والمدة باستخدام أمثلة Java لملفات عروض PPT و PPTX و ODP."
---
توّضح هذه المقالة تطبيق تأثيرات الانتقال بين الشرائح والتوقيتات باستخدام **Aspose.Slides for Java**.

## **إضافة انتقال شريحة**

تطبيق تأثير انتقال تلاشي على الشريحة الأولى.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // تطبيق انتقال تلاشي.
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى انتقال شريحة**

قراءة نوع الانتقال المعين حاليًا لشريحة.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // الوصول إلى نوع الانتقال.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة انتقال شريحة**

إزالة أي تأثير انتقال عن طريق تعيين النوع إلى `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // إزالة الانتقال بتعيين None.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **تحديد مدة الانتقال**

تحديد مدة عرض الشريحة قبل الانتقال تلقائيًا.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // بالملي ثانية.
    } finally {
        presentation.dispose();
    }
}
```