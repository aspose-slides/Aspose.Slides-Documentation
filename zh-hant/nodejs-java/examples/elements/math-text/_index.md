---
title: 數學文字
type: docs
weight: 160
url: /zh-hant/nodejs-java/examples/elements/math-text/
keywords:
- 程式碼範例
- 數學文字
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "探索 Aspose.Slides for Node.js 的 MathematicalText 範例：在 PPT、PPTX 與 ODP 簡報中建立與格式化方程式、分數、矩陣與符號。"
---
本文示範了如何使用 **Aspose.Slides for Node.js via Java** 處理數學文字形狀與格式化方程式。

## **新增數學文字**

建立一個包含分數與畢氏定理公式的數學形狀。

```js
function addMathText() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 新增一個數學形狀到投影片。
        let mathShape = slide.getShapes().addMathShape(0, 0, 720, 150);

        // 存取數學段落。
        let paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);
        let mathParagraph = textPortion.getMathParagraph();

        // 新增一個簡單的分數：x / y。
        let fraction = new aspose.slides.MathematicalText("x").divide("y");
        mathParagraph.add(new aspose.slides.MathBlock(fraction));

        // 新增方程式：c² = a² + b²。
        let mathBlock = new aspose.slides.MathematicalText("c")
                .setSuperscript("2")
                .join("=")
                .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
                .join("+")
                .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
        mathParagraph.add(mathBlock);

        presentation.save("math_text.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **存取數學文字**

在投影片上找到包含數學段落的形狀。

```js
function accessMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 尋找第一個包含數學段落的形狀。
        let mathShape = null;
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            let shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                let textFrame = autoShape.getTextFrame();
                if (textFrame != null) {
                    let hasMath = false;
                    for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                        let paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                        for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                            let portion = paragraph.getPortions().get_Item(portionIndex);
                            if (java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
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
            let paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
            let textPortion = paragraph.getPortions().get_Item(0);
            let mathParagraph = textPortion.getMathParagraph();

            // ...
        }
    } finally {
        presentation.dispose();
    }
}
```

## **移除數學文字**

從投影片中刪除數學形狀。

```js
function removeMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 假設第一個形狀是數學形狀。
        let mathShape = slide.getShapes().get_Item(0);

        // 移除數學形狀。
        slide.getShapes().remove(mathShape);

        presentation.save("math_text_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **格式化數學文字**

設定數學部分的字型屬性。

```js
function formatMathText() {
    let presentation = new aspose.slides.Presentation("math_text.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 假設第一個形狀是數學形狀。
        let mathShape = slide.getShapes().get_Item(0);

        let paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setFontHeight(20);

        presentation.save("math_text_formatted.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```