---
title: 在 Android 上為 PowerPoint 文字添加動畫
linktitle: 動畫文字
type: docs
weight: 60
url: /zh-hant/androidjava/animated-text/
keywords:
- 動畫文字
- 文字動畫
- 動畫段落
- 段落動畫
- 動畫效果
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 PowerPoint 與 OpenDocument 簡報中建立動態動畫文字，提供易於理解且最佳化的 Java 程式碼範例。"
---
## **概述**

本文說明如何在 Aspose.Slides 中處理動畫文字，透過對個別段落套用動畫效果以及取得已指派給文字框內段落的效果。重點在於用於新增段落層級動畫和檢查簡報中現有段落動畫效果的 API 方法。

## **新增段落動畫效果**

我們在 [**Sequence**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Sequence) 和 [**ISequence**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISequence) 類別中加入了 [**addEffect()**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) 方法。此方法允許您對單一段落新增動畫效果。以下範例程式碼示範如何對單一段落新增動畫效果：

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 選取要加入效果的段落
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 為選取的段落新增 Fly 動畫效果
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **取得段落的動畫效果**

您可能需要查找已套用於段落的動畫效果──例如，在某些情況下，您想取得段落中的動畫效果，因為您打算將這些效果套用到其他段落或圖形上。

Aspose.Slides for Android via Java 可讓您取得套用於文字框（圖形）中段落的全部動畫效果。以下範例程式碼示範如何取得段落中的動畫效果：

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

**文字動畫與投影片轉場有何不同，且它們可以同時使用嗎？**

文字動畫控制投影片上物件在時間軸上的行為，而 [transitions](/slides/zh-hant/androidjava/slide-transition/) 控制投影片之間的切換方式。兩者互相獨立且可同時使用；播放順序由動畫時間軸與轉場設定共同決定。

**匯出為 PDF 或影像時會保留文字動畫嗎？**

不會。PDF 與光柵影像是靜態的，因此只能看到投影片的單一靜止狀態。若需保留動態效果，請使用 [video](/slides/zh-hant/androidjava/convert-powerpoint-to-video/) 或 [HTML](/slides/zh-hant/androidjava/export-to-html5/) 匯出。

**文字動畫在版面配置與投影片母片中有效嗎？**

套用於版面配置或母片物件的效果會被投影片繼承，但其時間設定與與投影片層級動畫的互動取決於投影片上的最終序列。