---
title: الارتباط التشعبي
type: docs
weight: 130
url: /ar/androidjava/examples/elements/hyperlink/
keywords:
- مثال على الكود
- ارتباط تشعبي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إضافة وإدارة الروابط التشعبية في Aspose.Slides لنظام Android: ربط النص، الأشكال، والصور، ضبط الأهداف والإجراءات لملفات PPT و PPTX و ODP مع أمثلة Java."
---
يوضح هذا المقال إضافة، وصول، إزالة وتحديث الروابط التشعبية على الأشكال باستخدام **Aspose.Slides for Android via Java**.

## **إضافة ارتباط تشعبي**

إنشاء شكل مستطيل يحتوي على ارتباط تشعبي يشير إلى موقع ويب خارجي.

```java
static void addHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى ارتباط تشعبي**

قراءة معلومات الارتباط التشعبي من جزء نص الشكل.

```java
static void accessHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        IHyperlink hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة ارتباط تشعبي**

مسح الارتباط التشعبي من نص الشكل.

```java
static void removeHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        textPortion.getPortionFormat().setHyperlinkClick(null);
    } finally {
        presentation.dispose();
    }
}
```

## **تحديث ارتباط تشعبي**

تغيير الهدف لارتباط تشعبي موجود. استخدم `HyperlinkManager` لتعديل النص الذي يحتوي بالفعل على ارتباط تشعبي، مما يحاكي طريقة PowerPoint في تحديث الروابط التشعبية بأمان.

```java
static void updateHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://old.example.com"));

        // يجب تغيير ارتباط تشعبي داخل النص الموجود عبر
        // HyperlinkManager بدلاً من ضبط الخاصية مباشرة.
        // هذا يحاكي طريقة PowerPoint في تحديث الروابط التشعبية بأمان.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```