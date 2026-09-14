---
title: 使用 Python via Java 在簡報中管理字體
linktitle: 管理字體
type: docs
weight: 10
url: /zh-hant/python-java/manage-fonts/
keywords:
- 管理字體
- 字體屬性
- 段落
- 文字格式化
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 透過 Python via Java 控制字體：嵌入、取代並載入自訂字體，以保持 PPT、PPTX 與 ODP 簡報的清晰、品牌安全與一致性。"
---
## **概覽**

Aspose.Slides 允許您直接從程式碼中管理簡報文字的字體屬性。您可以透過形狀、文字框、段落和 Portion 來存取投影片中的文字，然後對所選文字套用格式設定。

本文說明如何為簡報中現有的文字配置字體相關屬性，包括字體族、粗體與斜體樣式、段落對齊方式以及字體顏色。它還示範如何建立文字方塊、向其中加入文字，並在儲存為 PPTX 檔案之前設定字體屬性，如字體族、粗體、斜體、底線、字型大小及顏色。

## **管理字體相關屬性**
{{% alert color="info" title="Note" %}} 

簡報通常包含文字與影像。文字可以以多種方式格式化，無論是突顯特定段落與詞彙，或符合公司樣式。文字格式化協助使用者變化簡報內容的外觀與感受。本文示範如何使用 Aspose.Slides for Python via Java 來配置投影片上段落文字的字體屬性。

{{% /alert %}} 

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 透過索引取得投影片的參考。
1. 以 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 方式存取投影片中的 [Placeholder](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/placeholder/) 形狀。
1. 從由 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 所公開的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 中取得 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/)。
1. 將段落設定為兩端對齊。
1. 存取 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/) 的文字 [Portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/)。
1. 使用 [FontData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontdata/) 定義字體，並相應設定文字 [Portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/) 的 **Font**。
   1. 設定字體為粗體。
   1. 設定字體為斜體。
1. 使用由 [Portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/) 物件所公開的 [FillFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fillformat/) 設定字體顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下提供上述步驟的實作範例。它會取得一個未經格式化的簡報，並對其中一張投影片的字體進行格式化。以下的螢幕截圖顯示輸入檔案以及程式碼片段如何變更它。程式碼會變更字體、顏色與字體樣式。

|![輸入簡報中的文字](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**圖：輸入檔案中的文字**|

|![已更新字體格式的文字](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**圖：相同文字的更新格式**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# 載入簡報。
presentation = Presentation("FontProperties.pptx")
try:
    # 取得第一張投影片以及其前兩個佔位符的文字框。
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # 存取每個文字框中的第一段落。
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # 取得每個段落的第一個 Portion。
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # 定義並指派新字體。
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # 設定字體為粗體與斜體。
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # 設定字體顏色。
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # 儲存簡報。
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定文字字體屬性**
{{% alert color="info" title="Note" %}} 

如 **管理字體相關屬性** 中所述， [Portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/) 用於在段落中保存具有相似格式樣式的文字。本篇說明如何使用 Aspose.Slides for Python via Java 建立帶有文字的文字方塊，然後定義特定字體及各種其他字體屬性。

{{% /alert %}} 

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 透過索引取得投影片的參考。
1. 向投影片加入類型為 **Rectangle** 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/)。
1. 移除與 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 相關的填充樣式。
1. 存取 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/)。
1. 向 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 中加入一些文字。
1. 存取與 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 關聯的 [Portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/) 物件。
1. 定義用於 [Portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/) 的字體。
1. 使用 [Portion](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portion/) 物件所公開的相關屬性，設定其他字體屬性，如粗體、斜體、底線、顏色與高度。
1. 將修改後的簡報寫入為 PPTX 檔案。

以下提供上述步驟的實作範例。

|![已套用字體屬性的文字](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**圖：由 Aspose.Slides for Python via Java 設定的字體屬性示例**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # 取得第一張投影片並加入矩形。
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # 移除形狀的填充。
    shape.getFillFormat().setFillType(FillType.NoFill)

    # 在形狀的文字框中加入文字。
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # 設定字體族。
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # 設定粗體、斜體、底線與字體大小。
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # 設定字體顏色。
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # 儲存簡報。
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```