---
title: ارتباط تشعبي
type: docs
weight: 130
url: /ar/java/examples/elements/hyperlink/
keywords:
- مثال على الكود
- ارتباط تشعبي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إضافة وإدارة الروابط التشعبية في Aspose.Slides for Java: ربط النص، الأشكال، والصور، وتعيين الأهداف والإجراءات لملفات PPT و PPTX و ODP باستخدام أمثلة Java."
---
توفر هذه المقالة أمثلة على إضافة، والوصول إلى، وإزالة، وتحديث الروابط التشعبية على الأشكال باستخدام **Aspose.Slides for Java**.

## **إضافة رابط تشعبي**

أنشئ شكلاً مستطيلاً يحتوي على رابط تشعبي يشير إلى موقع ويب خارجي.

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

## **الوصول إلى رابط تشعبي**

قراءة معلومات الرابط التشعبي من جزء النص في الشكل.

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

## **إزالة رابط تشعبي**

مسح الرابط التشعبي من نص الشكل.

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

## **تحديث رابط تشعبي**

تغيير هدف الرابط التشعبي الموجود. استخدم `HyperlinkManager` لتعديل النص الذي يحتوي بالفعل على رابط تشعبي، مما يحاكي طريقة تحديث PowerPoint للروابط التشعبية بأمان.

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

        // يجب تغيير رابط تشعبي داخل نص موجود عبر
        // HyperlinkManager بدلاً من تعيين الخاصية مباشرة.
        // هذا يحاكي طريقة قيام PowerPoint بتحديث الروابط التشعبية بأمان.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```