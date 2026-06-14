---
title: 數學文字
type: docs
weight: 160
url: /zh-hant/androidjava/examples/elements/math-text/
keywords:
- 程式碼範例
- 數學文字
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Android 的 MathematicalText 範例：使用 Java 在 PPT、PPTX 和 ODP 簡報中建立與格式化方程式、分數、矩陣和符號。"
---
本文示範如何使用 **Aspose.Slides for Android via Java** 處理數學文字形狀並格式化方程式。

## **新增數學文字**

建立包含分數與畢氏定理公式的數學形狀。

```java
static void addMathText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 新增一個數學形狀到投影片。
        IAutoShape mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // 取得數學段落。
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        IMathParagraph mathParagraph = ((MathPortion) textPortion).getMathParagraph();

        // 新增一個簡單的分數：x / y。
        IMathElement fraction = new MathematicalText("x").divide("y");
        mathParagraph.add(new MathBlock(fraction));

        // 新增方程式：c² = a² + b²。
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

## **存取數學文字**

在投影片上定位包含數學段落的形狀。

```java
static void accessMathText() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 尋找第一個包含數學段落的形狀。
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

            // 範例：建立分數（此處未加入）。
            IMathElement fraction = new MathematicalText("x").divide("y");

            // 依需求使用 mathParagraph 或 fraction……
        }
    } finally {
        presentation.dispose();
    }
}
```

## **移除數學文字**

從投影片中刪除數學形狀。

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

        // 移除數學形狀。
        slide.getShapes().remove(mathShape);
    } finally {
        presentation.dispose();
    }
}
```

## **格式化數學文字**

設定數學部分的字型屬性。

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