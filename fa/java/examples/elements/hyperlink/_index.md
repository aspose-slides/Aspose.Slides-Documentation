---
title: پیوند ابرمتنی
type: docs
weight: 130
url: /fa/java/examples/elements/hyperlink/
keywords:
- مثال کد
- پیوند ابرمتنی
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "افزودن و مدیریت پیوندهای ابرمتنی در Aspose.Slides برای Java: متن لینک، اشکال و تصاویر، تنظیم مقصدها و اقدامات برای PPT، PPTX و ODP با مثال‌های Java."
---
این مقاله افزودن، دسترسی، حذف و به‌روزرسانی پیوندهای ابرمتنی بر روی اشکال را با استفاده از **Aspose.Slides for Java** نشان می‌دهد.

## **افزودن پیوند ابرمتنی**

یک شکل مستطیلی با پیوند ابرمتنی که به یک وب‌سایت خارجی اشاره می‌کند ایجاد کنید.

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

## **دسترسی به پیوند ابرمتنی**

اطلاعات پیوند ابرمتنی را از بخش متنی یک شکل بخوانید.

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

## **حذف پیوند ابرمتنی**

پیوند ابرمتنی را از متن یک شکل پاک کنید.

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

## **به‌روزرسانی پیوند ابرمتنی**

مقصد یک پیوند ابرمتنی موجود را تغییر دهید. برای اصلاح متنی که قبلاً شامل پیوند ابرمتنی است از `HyperlinkManager` استفاده کنید، که مشابه نحوه به‌روز‌رسانی ایمن پیوندهای ابرمتنی در PowerPoint می‌باشد.

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

        // تغییر یک پیوند ابرمتنی داخل متن موجود باید از طریق
        // HyperlinkManager به جای تنظیم مستقیم ویژگی انجام شود.
        // این شبیه‌سازی به نحوه به‌روزرسانی ایمن پیوندهای ابرمتنی در PowerPoint است.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```