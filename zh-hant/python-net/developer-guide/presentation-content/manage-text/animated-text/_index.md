---
title: 在 Python 中為 PowerPoint 文字添加動畫
linktitle: 動畫文字
type: docs
weight: 60
url: /zh-hant/python-net/animated-text/
keywords:
- 動畫文字
- 文字動畫
- 動畫段落
- 段落動畫
- 動畫效果
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 透過 .NET，在 PowerPoint 與 OpenDocument 簡報中建立動態動畫文字，並提供易於跟隨、最佳化的程式碼範例。"
---
## **概觀**

本篇文章說明如何使用 Aspose.Slides for Python 在 PowerPoint 簡報中為文字添加動畫。您將學會對單獨段落加入效果、調整觸發條件，並讀取現有的動畫序列。完成後，您將能建立可重複使用的文字動畫工作流程，輸出為標準 PPTX 並在 PowerPoint 中正確播放。

## **添加段落動畫效果**

[add_effect](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/sequence/add_effect/) 方法屬於 [Sequence](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.animation/sequence/) 類別，可將動畫效果套用到單一段落。以下範例程式碼示範如何執行此操作：

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # 選取要加入效果的段落。
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 為選取的段落新增 Fly 動畫效果。
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **取得段落動畫效果**

您可能想要判斷已套用於段落的動畫效果——例如，若您打算將這些效果複製到其他段落或圖形。Aspose.Slides for Python 允許您取得套用於文字框（圖形）中段落的所有動畫效果。以下範例程式碼示範如何取得段落的動畫效果：

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **FAQ**

**文字動畫與投影片轉場有何不同，且可否同時使用？**

文字動畫控制投影片上物件隨時間的行為，而 [transitions](/slides/zh-hant/python-net/slide-transition/) 則控制投影片之間的切換方式。兩者是獨立的且可同時使用；播放順序由動畫時間軸與轉場設定決定。

**匯出為 PDF 或影像時，文字動畫會被保留嗎？**

不會。PDF 與點陣圖都是靜態的，因此您只能看到投影片的單一狀態，沒有動畫。若要保留動態效果，請使用 [video](/slides/zh-hant/python-net/convert-powerpoint-to-video/) 或 [HTML](/slides/zh-hant/python-net/export-to-html5/) 匯出。

**文字動畫在版面配置與投影片母片中是否有效？**

套用於版面配置/母片物件的效果會被投影片繼承，但其時機與投影片層級動畫的互動取決於投影片上最終的動畫序列。