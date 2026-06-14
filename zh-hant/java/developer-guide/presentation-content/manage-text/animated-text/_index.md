---
title: 在 Java 中為 PowerPoint 文本添加動畫
linktitle: 動畫文字
type: docs
weight: 60
url: /zh-hant/java/animated-text/
keywords:
- 動畫文字
- 文字動畫
- 動畫段落
- 段落動畫
- 動畫效果
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java，在 PowerPoint 與 OpenDocument 簡報中建立動態動畫文字，並提供易於遵循、最佳化的 Java 程式碼範例。"
---
## **概述**

本文說明如何在 Aspose.Slides 中透過對單獨段落套用動畫效果以及取得已指派至文字框中段落的動畫效果，以處理動畫文字。重點在於用於新增段落層級動畫以及檢查簡報中現有段落動畫效果的 API 方法。

## **為段落新增動畫效果**

我們在 [**Sequence**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Sequence) 與 [**ISequence**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISequence) 類別中加入了 [**addEffect()**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) 方法。此方法允許您對單一段落新增動畫效果。以下範例程式碼示範如何對單一段落加入動畫效果：

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 選取要添加效果的段落
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 為選取的段落添加 Fly 動畫效果
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **取得段落的動畫效果**

您可能想要查詢已套用至段落的動畫效果，例如在某些情況下，您希望取得段落中的動畫效果，以便將這些效果套用到另一個段落或圖案上。

Aspose.Slides for Java 讓您取得套用於文字框（圖形）內所有段落的動畫效果。以下範例程式碼示範如何取得段落中的動畫效果：

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```

## **常見問題**

**文字動畫與投影片轉場有何不同？可以合併使用嗎？**

文字動畫控制投影片上物件隨時間的行為，而 [transitions](/slides/zh-hant/java/slide-transition/) 控制投影片之間的切換方式。兩者相互獨立，且可同時使用；播放順序由動畫時間軸與轉場設定決定。

**將投影片匯出為 PDF 或影像時，文字動畫會被保留嗎？**

不會。PDF 與點陣圖影像為靜態內容，僅顯示投影片的單一狀態，不會有動作。若需保留動態效果，請使用 [video](/slides/zh-hant/java/convert-powerpoint-to-video/) 或 [HTML](/slides/zh-hant/java/export-to-html5/) 匯出。

**文字動畫在佈局與投影片母片中是否有效？**

套用於佈局/母片物件的效果會被投影片繼承，但其時間安排與與投影片層級動畫的互動取決於最終在投影片上的序列。