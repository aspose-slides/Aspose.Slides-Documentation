---
title: رأس وتذييل
type: docs
weight: 220
url: /ar/androidjava/examples/elements/header-footer/
keywords:
- مثال على الشيفرة
- رأس
- تذييل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تحكم في رؤوس وتذييلات الشرائح باستخدام Aspose.Slides for Android: أضف التواريخ وأرقام الشرائح والنص المخصص في صيغ PPT و PPTX و ODP مع أمثلة Java."
---
توضح هذه المقالة كيفية إضافة التذييلات وتحديث عناصر النائب للتاريخ والوقت باستخدام **Aspose.Slides for Android via Java**.

## **إضافة تذييلة**
أضف نصًا إلى منطقة التذييل في الشريحة واجعله مرئيًا.

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **تحديث التاريخ والوقت**
عدّل عنصر النائب للتاريخ والوقت في الشريحة.

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```