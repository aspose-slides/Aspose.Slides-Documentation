---
title: 在 JavaScript 中為 PowerPoint 文字加入動畫
linktitle: 動畫文字
type: docs
weight: 60
url: /zh-hant/nodejs-java/animated-text/
keywords:
- 動畫文字
- 文字動畫
- 動畫段落
- 段落動畫
- 動畫效果
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js，在 PowerPoint 與 OpenDocument 簡報中建立動態動畫文字，提供易於跟隨、最佳化的程式碼範例。"
---
## **概述**

本文說明如何在 Aspose.Slides 中對單一段落套用動畫效果，以及如何取得已指派給文字框段落的動畫效果。重點在於用於新增段落層級動畫與檢視簡報中現有段落動畫效果的 API 方法。

## **將動畫效果新增至段落**

我們在 [**Sequence**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Sequence) 以及 [**Sequence**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Sequence) 類別中加入了 [**addEffect()**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) 方法。此方法允許您為單一段落新增動畫效果。以下範例程式碼示範如何為單一段落新增動畫效果：

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 選取要加入效果的段落
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // 為選取的段落加入 Fly 動畫效果
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **取得段落中的動畫效果**

您可能會想查詢已加入段落的動畫效果——例如，在某些情況下，您想取得段落的動畫效果，以便將這些效果套用到其他段落或圖形。

Aspose.Slides for Node.js via Java 讓您能取得套用於文字框（圖形）中段落的全部動畫效果。以下範例程式碼示範如何取得段落中的動畫效果：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```

## **常見問題**

**文字動畫與投影片切換有何不同，且能否結合使用？**

文字動畫控制投影片上物件隨時間的行為，而[切換](/slides/zh-hant/nodejs-java/slide-transition/)則控制投影片之間的切換方式。兩者互相獨立，可同時使用；播放順序由動畫時間軸與切換設定共同決定。

**將文字動畫匯出為 PDF 或圖像時，是否會保留？**

不會。PDF 與點陣圖都是靜態的，您只能看到投影片的單一狀態，沒有動態效果。若需保留動畫，請使用[影片](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/)或[HTML](/slides/zh-hant/nodejs-java/export-to-html5/)匯出。

**文字動畫在版面配置和投影片母片中是否有效？**

套用於版面配置或母片物件的效果會被繼承至投影片，但其時間與與投影片層級動畫的互動取決於最終在投影片上的序列。