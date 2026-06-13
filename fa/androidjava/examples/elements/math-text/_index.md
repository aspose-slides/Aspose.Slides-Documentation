---
title: متن ریاضی
type: docs
weight: 160
url: /fa/androidjava/examples/elements/math-text/
keywords:
- مثال کد
- متن ریاضی
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "نمونه‌های Aspose.Slides برای Android مرتبط با MathematicalText را بررسی کنید: ایجاد و قالب‌بندی معادلات، کسرها، ماتریس‌ها و نمادها با Java در ارائه‌های PPT، PPTX و ODP."
---
این مقاله نحوه کار با اشکال متن ریاضی و قالب‌بندی معادلات را با استفاده از **Aspose.Slides for Android via Java** نشان می‌دهد.

## **افزودن متن ریاضی**

یک شکل ریاضی شامل یک کسر و فرمول فیثاغورس ایجاد کنید.

```java
static void addMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // افزودن یک شکل ریاضی به اسلاید.
        IAutoShape mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // دسترسی به پاراگراف ریاضی.
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

        // افزودن یک کسر ساده: x / y.
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // افزودن معادله: c² = a² + b².
        IMathBlock mathBlock = new MathematicalText("c")
                .setSuperscript("2")
                .join("=")
                .join(new MathematicalText("a").setSuperscript("2"))
                .join("+")
                .join(new MathematicalText("b").setSuperscript("2"));
        mathParagraph.add(mathBlock);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به متن ریاضی**

در اسلاید، یک شکل که شامل یک پاراگراف ریاضی است را پیدا کنید.

```java
static void accessMathText() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // اولین شکلی که شامل یک پاراگراف ریاضی است را پیدا کنید.
        IAutoShape mathShape = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                ITextFrame textFrame = autoShape.getTextFrame();
                if (textFrame != null) {
                    boolean hasMath = false;
                    for (IParagraph paragraph : textFrame.getParagraphs()) {
                        for (IPortion portion : paragraph.getPortions()) {
                            if (portion instanceof MathPortion) {
                                hasMath = true;
                                break;
                            }
                        }
                        if (hasMath) break;
                    }
                    if (hasMath) {
                        mathShape = autoShape;
                        break;
                    }
                }
            }
        }

        if (mathShape != null) {
            IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
            IPortion textPortion = paragraph.getPortions().get_Item(0);
            IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

            // مثال: ایجاد یک کسر (در اینجا اضافه نشده است).
            IMathElement fraction = new MathematicalText("x").divide("y");

            // استفاده از mathParagraph یا fraction در صورت نیاز...
        }
    } finally {
        presentation.dispose();
    }
}
```

## **حذف متن ریاضی**

یک شکل ریاضی را از اسلاید حذف کنید.

```java
static void removeMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape mathShape = slide.getShapes().addMathShape(50, 50, 100, 50);

        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // حذف شکل ریاضی.
    } finally {
        presentation.dispose();
    }
}
```

## **قالب‌بندی متن ریاضی**

ویژگی‌های قلم را برای بخشی از متن ریاضی تنظیم کنید.

```java
static void formatMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape mathShape = slide.getShapes().addMathShape(50, 50, 100, 50);
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        textPortion.getPortionFormat().setFontHeight(20);
    } finally {
        presentation.dispose();
    }
}
```