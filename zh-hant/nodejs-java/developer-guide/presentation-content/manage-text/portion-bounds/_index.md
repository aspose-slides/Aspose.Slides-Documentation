---
title: 在 JavaScript 中從簡報取得文字片段邊界
linktitle: Portion 邊界
type: docs
weight: 47
url: /zh-hant/nodejs-java/portion-bounds/
keywords:
- 文字片段邊界
- 文字片段
- 文字部分
- 文字座標
- 文字位置
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何透過 Java 使用 Aspose.Slides for Node.js 在 PowerPoint 簡報中取得文字片段的邊界。"
---
## **概述**

文字 Portion 代表段落內的特定文字片段，讓您能獨立於周圍內容操作該片段。在 Aspose.Slides 中，當您需要取得文字片段的邊界、僅對段落的一部分套用格式，或在更細緻的層面控制文字行為時，可使用 Portion。

本文說明如何使用 [Portion.getRect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/getrect/) 取得 Portion 的邊界矩形。也說明如何使用 [Portion.getCoordinates](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/getcoordinates/) 取得 Portion 起始位置的座標。此外，本文還強調了常見的與 Portion 相關的情境，例如對單一文字片段套用超連結、了解格式如何透過 Portion、Paragraph、TextFrame 和主題的繼承機制解析，以及處理指定字型不存在的情況。

## **取得文字 Portion 的邊界矩形**

使用 [Portion.getRect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/getrect/) 取得文字 Portion 的邊界矩形：

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **取得文字 Portion 的座標**

使用 [Portion.getCoordinates](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/getcoordinates/) 取得文字 Portion 起始位置的座標：

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **常見問題**

**我可以只對單一段落內的部分文字套用超連結嗎？**

是的，您可以對單一 Portion[指派超連結](/slides/zh-hant/nodejs-java/manage-hyperlinks/)，只有該片段會變成可點擊，而不是整個段落。

**樣式繼承如何運作：Portion 會覆寫哪些屬性，哪些會從 Paragraph 或 TextFrame 繼承？**

Portion 級別的屬性具有最高優先權。如果在 [Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 上未設定屬性，Aspose.Slides 會從 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 繼承。若該處仍未設定，則使用 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 或 [theme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/theme/) 的樣式。

**如果針對 Portion 指定的字型在目標機器或伺服器上不存在，會發生什麼情況？**

[字型替換規則](/slides/zh-hant/nodejs-java/font-selection-sequence/) 會生效。文字可能重新排版：度量、斷字與寬度都可能改變，這會影響精確的定位。

**我可以為特定 Portion 設定文字填色的透明度或漸層，而不影響段落其他部分嗎？**

是的，[Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 級別的文字顏色、填色與透明度可以與相鄰的片段不同。