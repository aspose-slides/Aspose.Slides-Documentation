---
title: 在 .NET 中為 PowerPoint 文字加入動畫
linktitle: 動畫文字
type: docs
weight: 60
url: /zh-hant/net/animated-text/
keywords:
- 動畫文字
- 文字動畫
- 動畫段落
- 段落動畫
- 動畫效果
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 與 OpenDocument 簡報中建立動態動畫文字，並提供易於理解、最佳化的 C# 程式碼範例。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中對單一段落套用動畫效果，並取得已指派給文字框中段落的動畫效果。重點在於使用 API 方法加入段落層級的動畫，以及檢視簡報中現有的段落動畫效果。

## **將動畫效果套用到段落**

我們在 [**Sequence**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/sequence) 與 [**ISequence**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/isequence) 類別中加入了 [**AddEffect()**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.animation/sequence/methods/addeffect/index) 方法。此方法允許您對單一段落加入動畫效果。以下範例程式碼示範如何對單一段落加入動畫效果：

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // 選取要加入效果的段落
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // 為選取的段落新增 Fly 動畫效果
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **取得段落的動畫效果**

您可能需要查詢已加入段落的動畫效果，例如在某些情境下，您想取得段落的動畫效果，然後將這些效果套用到另一個段落或圖形。

Aspose.Slides for .NET 允許您取得文字框（圖形）中所有段落所套用的動畫效果。以下範例程式碼示範如何取得段落中的動畫效果：

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```

## **常見問題**

**文字動畫與投影片過渡有何不同，能否同時使用？**

文字動畫控制投影片上物件隨時間的行為，而[過渡效果](/slides/zh-hant/net/slide-transition/)則控制投影片之間的切換方式。兩者互相獨立，且可以同時使用；播放順序由動畫時間軸以及過渡設定共同決定。

**將簡報匯出為 PDF 或影像檔時，文字動畫會被保留嗎？**

不會。PDF 與點陣圖影像為靜態檔案，僅會顯示投影片的單一狀態，無法呈現動畫。若需保留動態效果，請使用[影片](/slides/zh-hant/net/convert-powerpoint-to-video/)或[HTML](/slides/zh-hant/net/export-to-html5/)匯出。

**文字動畫在版面配置與投影片母片中會生效嗎？**

套用在版面或母片物件上的效果會被投影片繼承，但其時序與與投影片層級動畫的互動，取決於最終在投影片上的播放順序。