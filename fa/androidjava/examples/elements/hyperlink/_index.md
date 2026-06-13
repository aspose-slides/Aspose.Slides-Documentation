---
title: پیوند
type: docs
weight: 130
url: /fa/androidjava/examples/elements/hyperlink/
keywords:
- مثال کد
- پیوند
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "افزودن و مدیریت پیوندها در Aspose.Slides برای اندروید: لینک متنی، اشکال و تصاویر، تنظیم هدف‌ها و اقدامات برای PPT، PPTX و ODP با مثال‌های جاوا."
---
این مقاله افزودن، دسترسی، حذف و به‌روزرسانی پیوندهای ابرمتنی روی شکل‌ها را با استفاده از **Aspose.Slides for Android via Java** نشان می‌دهد.

## **افزودن پیوند**

یک شکل مستطیلی ایجاد کنید که شامل پیوندی به یک وب‌سایت خارجی باشد.

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

## **دسترسی به پیوند**

اطلاعات پیوند ابرمتنی را از بخش متن یک شکل بخوانید.

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

## **حذف پیوند**

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

## **به‌روزرسانی پیوند**

هدف یک پیوند موجود را تغییر دهید. برای اصلاح متنی که پیش از این شامل پیوند است از `HyperlinkManager` استفاده کنید، همان‌طور که PowerPoint پیوندها را به‌صورت ایمن به‌روزرسانی می‌کند.

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

        // تغییر یک پیوند درون متن موجود باید از طریق
        // HyperlinkManager انجام شود نه اینکه خصوصیت را به‌طور مستقیم تنظیم کنید.
        // این شبیه‌سازی می‌کند که PowerPoint پیوندها را به‌صورت ایمن به‌روزرسانی می‌کند.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```