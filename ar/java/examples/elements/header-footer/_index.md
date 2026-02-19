---
title: ترويسة وتذييل
type: docs
weight: 220
url: /ar/java/examples/elements/header-footer/
keywords:
- مثال على الكود
- ترويسة
- تذييل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحكم في رؤوس وتذييلات الشرائح باستخدام Aspose.Slides for Java: أضف تواريخ، أرقام الشرائح، ونصًا مخصصًا في ملفات PPT و PPTX و ODP مع أمثلة Java."
---
هذه المقالة توضح كيفية إضافة تذييلات وتحديث عناصر العنصر النائب للتاريخ والوقت باستخدام **Aspose.Slides for Java**.

## **إضافة تذييل**

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

قم بتعديل العنصر النائب للتاريخ والوقت في الشريحة.

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