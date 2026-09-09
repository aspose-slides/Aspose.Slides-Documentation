---
title: 使用 Python 透過 Java 管理簡報中的上標與下標
linktitle: 上標與下標
type: docs
weight: 80
url: /zh-hant/python-java/superscript-and-subscript/
keywords:
- 上標
- 下標
- 新增上標
- 新增下標
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "精通 Aspose.Slides 中的上標與下標（使用 Python 透過 Java），並以專業的文字格式提升簡報的最大影響力。"
---
## **概觀**

Aspose.Slides 提供將上標與下標文字整合至 PowerPoint（PPT、PPTX）與 OpenDocument（ODP）簡報的功能。無論您需要突顯化學式、數學方程式，或以腳註方式標註內容，這些特殊的格式選項都能協助維持清晰與精準。本文將說明如何無縫套用上標與下標樣式，確保每張投影片皆呈現專業效果。

## **管理上標與下標文字**

您可以在段落的任意部分加入上標與下標文字。若要在 Aspose.Slides 文字框中套用此格式，請使用 [PortionFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/) 類別的 [setEscapement](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/#setEscapement) 方法。

Escapement 值的範圍從 -100%（下標）到 100%（上標）。例如：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
- 依索引取得投影片。
- 在投影片上加入類型為 [ShapeType.Rectangle](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapetype/#Rectangle) 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/)。
- 存取與 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 關聯的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/)。
- 清除現有的段落。
- 建立一個用於放置上標文字的段落，並將其加入文字框的段落集合。
- 建立一個 Portion。
- 使用 [setEscapement](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/#setEscapement) 設定 0 到 100 之間的值作為上標（0 表示不使用上標）。
- 設定 [Portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/) 的文字，並將其加入段落的部分集合。
- 建立一個用於放置下標文字的段落，並將其加入文字框的段落集合。
- 建立一個 Portion。
- 使用 [setEscapement](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/#setEscapement) 設定 -100 到 0 之間的值作為下標（0 表示不使用下標）。
- 設定 [Portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/) 的文字，並將其加入段落的部分集合。
- 將簡報儲存為 PPTX 檔案。

以下範例實作了這些步驟：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# 建立簡報。
presentation = Presentation()
try:
    # 取得投影片。
    slide = presentation.getSlides().get_Item(0)

    # 建立文字方塊。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # 建立上標文字的段落。
    superscript_paragraph = Paragraph()

    # 建立一般文字的部分。
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # 建立上標文字的部分。
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # 建立下標文字的段落。
    subscript_paragraph = Paragraph()

    # 建立一般文字的部分。
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # 建立下標文字的部分。
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # 將段落加入文字方塊。
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**匯出為 PDF 或其他格式時，上標與下標會被保留嗎？**

是的，Aspose.Slides 會正確保留上標與下標格式，當匯出簡報為 PDF、PPT/PPTX、影像及其他支援的格式時。專門的格式在所有輸出檔案中皆保持完整。

**上標與下標可以與粗體或斜體等其他格式樣式結合嗎？**

是的，Aspose.Slides 允許在同一段文字的單一部分中混合多種文字樣式。您可以啟用粗體、斜體、底線，並同時透過設定 [PortionFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/) 的相應屬性來套用上標或下標。

**上標與下標格式適用於表格、圖表或 SmartArt 內的文字嗎？**

是的，Aspose.Slides 支援在大多數物件內的格式設定，包括表格與圖表元素。使用 SmartArt 時，您需要存取相應的元素（例如 [SmartArtNode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartartnode/)）及其文字容器，然後以類似方式設定 [PortionFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/) 的屬性。