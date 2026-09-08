---
title: 在 Python via Java 中為 PowerPoint 文字添加動畫
linktitle: 動畫文字
type: docs
weight: 60
url: /zh-hant/python-java/animated-text/
keywords:
- 動畫文字
- 文字動畫
- 動畫段落
- 段落動畫
- 動畫效果
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，在 PowerPoint 與 OpenDocument 簡報中建立動態動畫文字，並提供易於理解、最佳化的 Python 程式碼範例。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中對單獨段落套用動畫效果，並取得已指派給文字框中段落的動畫效果。重點在於用於加入段落層級動畫與檢查簡報中現有段落動畫效果的 API 方法。

## **將動畫效果套用至段落**

[addEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#addEffect) 方法屬於 [Sequence](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/) 類別，可讓您為單一段落加入動畫效果。以下範例程式碼示範如何為單一段落加入動畫效果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # 選取要加入效果的段落。
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 為所選段落加入 Fly 動畫效果。
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **取得段落的動畫效果**

您可能想要查詢已加入段落的動畫效果——例如在某個情境下，您想取得段落的動畫效果，以便將這些效果套用到另一個段落或圖形。

Aspose.Slides for Python via Java 可讓您取得文字框（圖形）中所有段落所套用的動畫效果。以下範例程式碼示範如何取得段落的動畫效果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **常見問題**

**文字動畫與投影片轉場有何不同？可以同時使用嗎？**

文字動畫控制物件在投影片上的時間行為，而[transitions](/slides/zh-hant/python-java/slide-transition/) 則控制投影片之間的切換方式。兩者彼此獨立，且可同時使用；播放順序由動畫時間軸與轉場設定共同決定。

**將簡報匯出為 PDF 或影像時，文字動畫會保留嗎？**

不會。PDF 與點陣圖影像是靜態的，只會看到投影片的單一狀態而沒有動作。若要保留動態效果，請使用[video](/slides/zh-hant/python-java/convert-powerpoint-to-video/) 或[HTML](/slides/zh-hant/python-java/export-to-html5/) 匯出。

**文字動畫在版面配置與投影片母片上會有效嗎？**

套用於版面/母片物件的效果會被繼承至投影片，但它們的時間設定與與投影片層級動畫的互動，仍取決於最終投影片上的排列順序。