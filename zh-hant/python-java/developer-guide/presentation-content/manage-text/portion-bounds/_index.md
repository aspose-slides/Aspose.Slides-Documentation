---
title: 從 Python 透過 Java 於簡報中取得文字段落邊界
linktitle: 段落邊界
type: docs
weight: 47
url: /zh-hant/python-java/portion-bounds/
keywords:
- 文字段落邊界
- 文字段落
- 文字部份
- 文字座標
- 文字位置
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 PowerPoint 簡報中取得文字段落的邊界。"
---
## **概觀**

文字段落（portion）代表段落內的特定文字片段，讓您能在不影響周圍內容的情況下獨立處理該片段。 在 Aspose.Slides 中，當您需要取得文字片段的邊界、僅對段落的一部分套用格式，或在更細緻的層級控制文字行為時，可使用 portion。

本篇文章說明如何使用 [Portion.getRect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/#getRect) 取得 portion 的邊界矩形。它還說明如何使用 [Portion.getCoordinates](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/#getCoordinates) 取得 portion 起始位置的座標。此外，還闡述了常見的 portion 相關情境，例如對單一文字片段套用超連結、了解格式如何透過 portion、段落、文字框與佈景主題的繼承解析，以及處理指定字型不存在的情況。

## **取得文字段落的邊界**

使用 [Portion.getRect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/#getRect) 取得文字段落的邊界矩形：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **取得文字段落的座標**

使用 [Portion.getCoordinates](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/#getCoordinates) 取得文字段落起始位置的座標：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **FAQ**

**我能否僅對單一段落中的部分文字套用超連結？**

可以，您可以[指派超連結](/slides/zh-hant/python-java/manage-hyperlinks/)給單一的 portion；只有該片段會是可點擊的，而不是整個段落。

**樣式繼承如何運作：portion 會覆寫哪些屬性，哪些則從段落或文字框取得？**

在 portion 級別的屬性具有最高優先權。如果屬性未在 [Portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/) 上設定，Aspose.Slides 會從 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/) 繼承。若該屬性在段落也未設定，則會使用 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 或 [theme](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/theme/) 的樣式。

**如果為 portion 指定的字型在目標機器或伺服器上不存在，會發生什麼情況？**

[字型替代規則](/slides/zh-hant/python-java/font-selection-sequence/) 會被套用。文字可能會重新換行：字型度量、斷字與寬度都可能改變，這會影響精確的定位。

**我能否為特定 portion 設定文字填充透明度或漸層，而不影響段落其他部分？**

可以，位於 [Portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/) 級別的文字顏色、填充與透明度可以與相鄰片段不同。