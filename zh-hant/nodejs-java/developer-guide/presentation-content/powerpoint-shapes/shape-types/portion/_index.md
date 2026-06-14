---
title: 使用 JavaScript 管理簡報中的文字片段
linktitle: 文字片段
type: docs
weight: 70
url: /zh-hant/nodejs-java/portion/
keywords:
- 文字片段
- 文字部份
- 文字座標
- 文字位置
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 JavaScript 以及 Aspose.Slides for Node.js（透過 Java）在 PowerPoint 簡報中管理文字片段，提升效能與客製化。"
---
## **概述**

文字片段（Portion）代表段落內特定的文字片段，讓您能夠獨立於其餘內容對該片段進行操作。在 Aspose.Slides 中，當您需要取得文字片段的位置、僅對段落的一部份套用格式，或在更細緻的層級控制文字行為時，就可以使用 Portion。

本文說明如何使用 `getCoordinates()` 方法取得片段起始點的座標，並闡述常見的 Portion 相關情境，例如對單一文字片段套用超連結、了解格式如何透過 Portion、Paragraph、TextFrame 以及主題（theme）繼承而解析，以及處理指定字型在目標機器/伺服器上不存在的情況。另外，也說明在同一段落中，個別 Portion 可以設定不同的文字填色、顏色與透明度。

## **取得 Portion 的位置座標**
[**getCoordinates()**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Portion#getCoordinates--) 方法已新增至 [Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 類別，允許取得片段起始點的座標。

```javascript
// 實例化代表 PPTX 的 Presentation 類別
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // 重塑簡報的上下文
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以只對單一段落中的部分文字套用超連結嗎？**

是的，您可以[指派超連結](/slides/zh-hant/nodejs-java/manage-hyperlinks/)給單一 Portion；只有該文字片段可點擊，整段不會被連結。

**樣式繼承的運作方式為何：Portion 會覆寫什麼，什麼是從 Paragraph/TextFrame 繼承的？**

Portion 級別的屬性具有最高優先權。若在 [Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 上未設定屬性，系統會從 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 取得；若仍未設定，則從 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 或 [theme](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/theme/) 取得。

**如果指定給 Portion 的字型在目標機器/伺服器上不存在，會發生什麼情況？**

會套用[字型取代規則](/slides/zh-hant/nodejs-java/font-selection-sequence/)。文字可能會重新分行：度量、斷字與寬度都可能改變，這會影響精確定位。

**我可以為單一 Portion 設定與段落其他文字不同的文字填色透明度或漸層嗎？**

可以，[Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/) 級別的文字顏色、填色與透明度可以與相鄰片段不同。