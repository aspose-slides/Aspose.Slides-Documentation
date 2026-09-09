---
title: 在 Python via Java 中為 PowerPoint 文字加入動畫
linktitle: 動畫文字
type: docs
weight: 60
url: /zh-hant/python-java/animated-text/
keywords:
- 動態文字
- 文字動畫
- 動態段落
- 段落動畫
- 動畫效果
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，在 PowerPoint 與 OpenDocument 簡報中建立動態動畫文字，提供易於理解且最佳化的 Python 程式範例。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中透過將動畫效果套用到個別段落，以及取得已指派給文字框中段落的效果，來操作動畫文字。重點在於用於加入段落層級動畫以及檢查簡報中現有段落動畫效果的 API 方法。

## **將動畫效果套用到段落**

[Sequence](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/) 類別的 [addEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#addEffect) 方法允許您為單一段落新增動畫效果。以下範例程式碼示範如何為單一段落加入動畫效果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # 選取要套用效果的段落。
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 為所選段落加入 Fly 動畫效果。
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **取得段落的動畫效果**

您可能想取得套用在段落上的動畫效果，例如將這些效果套用到其他段落或圖形。

Aspose.Slides for Python via Java 允許您取得文字框（圖形）中段落所套用的全部動畫效果。以下範例程式碼示範如何取得套用在段落上的動畫效果：

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

**文字動畫與投影片過渡有何不同，且可以一起使用嗎？**

文字動畫控制投影片上物件隨時間的行為，而 [過渡效果](/slides/zh-hant/python-java/slide-transition/) 控制投影片之間的切換方式。兩者相互獨立，可同時使用；播放順序由動畫時間軸和過渡設定決定。

**匯出為 PDF 或影像時，文字動畫會被保留嗎？**

不會。PDF 與點陣圖都是靜態的，您只能看到投影片的單一狀態而沒有動作。若想保留動態效果，請使用 [影片](/slides/zh-hant/python-java/convert-powerpoint-to-video/) 或 [HTML](/slides/zh-hant/python-java/export-to-html5/) 匯出。

**文字動畫在版面配置與投影片母片中會生效嗎？**

套用在版面或母片物件上的效果會被投影片繼承，但其時間安排與與投影片層級動畫的互動，取決於最終在投影片上的序列。