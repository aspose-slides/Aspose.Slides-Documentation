---
title: 在 Python via Java 中格式化簡報文字
linktitle: 文字格式化
type: docs
weight: 50
url: /zh-hant/python-java/text-formatting/
keywords:
- 對齊段落
- 文字樣式
- 文字背景
- 文字透明度
- 字元間距
- 字型屬性
- 字型家族
- 文字旋轉
- 旋轉角度
- 文字框
- 行距
- 自動調整屬性
- 文字框錨點
- 文字定位
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 PowerPoint 與 OpenDocument 簡報中使用 Aspose.Slides for Python via Java 進行文字的格式與樣式設定。自訂字體、顏色、對齊方式等。"
---
## **概觀**

本文章說明如何使用 Aspose.Slides for Python via Java 來格式化 PowerPoint 與 OpenDocument 簡報中的文字。內容涵蓋背景顏色、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨點、定位點以及語言設定。

除非另有說明，範例皆使用 [sample.pptx](sample.pptx)。其第一張投影片的第一個圖形為文字方塊，且其第一段落包含以下顯示的文字。投影片與圖形的索引均從零開始。選取粗體部分的範例使用有效的格式設定，包括繼承的粗體格式：

![範例文字](sample_text.png)

若要尋找並標示文字或正規表示式匹配，請參閱[搜尋與取代文字](/slides/zh-hant/python-java/search-and-replace-text/)。

## **設定文字背景色彩**

使用 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 可設定段落的預設醒目顏色，或使用 [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#getHighlightColor) 設定單一文字部分的醒目顏色。

以下範例將淡灰色醒目設定為第一段落的預設。個別文字部分的明確醒目顏色會優先於此預設：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 設定整段落的醒目顏色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼範例示範如何為 **粗體字型的文字部分** 設定背景色彩：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # 設定文字部分的醒目顏色。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![灰色文字部分](gray_text_portions.png)

## **對齊文字段落**

使用 [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setAlignment) 可設定文字框內段落的對齊方式。可設定為居中、靠左、靠右、兩端對齊等。

以下程式碼範例顯示如何將段落對齊至 **中心**：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 設定段落的對齊方式為置中。
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![已對齊的段落](aligned_paragraph.png)

## **設定文字透明度**

文字透明度透過指派給 [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#getFillFormat) 的顏色之 alpha 成分來控制。在以下範例中，`alpha = 50` 為 0–255 之 ARGB alpha 通道數值，而非透明度百分比。

以下程式碼範例示範如何將透明度套用至 **整段文字**：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 設定文字的填充顏色為透明顏色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![透明段落](transparent_paragraph.png)

以下程式碼範例示範如何將透明度套用至 **粗體字型的文字部分**：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # 設定文字部分的透明度。
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![透明文字部分](transparent_text_portions.png)

## **設定文字字元間距**

使用 [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setSpacing) 可在文字方塊中擴張或縮減字元間的間距。範例中加入 3 點的間距；負值則會壓縮文字。

以下 Python 程式碼示範如何在 **整段文字** 中展開字元間距：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 注意：使用負值可壓縮字元間距。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # 展開字元間距。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼範例示範如何在 **粗體字型的文字部分** 中展開字元間距：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # 注意：使用負值可壓縮字元間距。
            portion.getPortionFormat().setSpacing(3) # 展開字元間距。

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![文字部分的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距微調**

在某些情況下，Aspose.Slides 所渲染的文字可能比 PowerPoint 中顯示的同樣文字看起來稍微緊湊。這可能是因為即使字型包含有效的字距微調資訊且在 PowerPoint 設定中已啟用字距微調，PowerPoint 仍可能忽略某些字型的字距微調資料。

為了在此類情況下使渲染結果更接近 PowerPoint，您可以對使用受影響字型的文字部分停用字距微調。將 [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) 設為大於實際字型大小的值。本範例需要「presentation.pptx」且其第一張投影片的第一個圖形為文字方塊。它會檢查有效的字型名稱（包括繼承的字型），並為使用 Roboto 的文字部分設定 100 點的門檻。這將對字型大小低於 100 點的符合條件文字部分停用字距微調：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

對於低於門檻的符合文字，此設定會阻止字距微調，並可協助使 Aspose.Slides 的渲染與 PowerPoint 對受此 PowerPoint 特定行為影響的字型之視覺輸出保持一致。

## **管理文字字型屬性**

字型屬性可透過 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 在段落層級設定，或透過 [PortionFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/) 在單一文字部分設定。

以下範例將第一段落的預設字型設定為 12 點 Times New Roman，並加上粗體、斜體與點狀底線格式。個別文字部分的明確格式會優先於這些預設值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 設定段落的字型屬性。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![段落的字型屬性](font_properties_for_paragraph.png)

以下範例將 13 點 Times New Roman、斜體格式與點狀底線套用至有效格式為粗體的文字部分：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # 設定文字部分的字型屬性。
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![文字部分的字型屬性](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用 [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setTextVerticalType) 可在形狀內設定預先定義的文字方向。

以下程式碼範例將形狀內的文字方向設為 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textverticaltype/)，此設定會將文字 **逆時針旋轉 90 度**：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![文字旋轉](text_rotation.png)

## **為文字框設定自訂旋轉**

使用 [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setRotationAngle) 可為 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/) 設定自訂的旋轉角度。

以下程式碼範例將形狀內的文字框順時針旋轉 3 度：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落行距**

Aspose.Slides 提供 [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setSpaceAfter)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setSpaceBefore) 與 [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setSpaceWithin) 來控制段落間距。這些屬性的使用方式如下：

* 使用正值以行高的百分比指定行距。
* 使用負值以點數指定行距。

以下範例將第一段落內的間距設定為行高的 200%（雙倍行距）：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![段落內的行距](line_spacing.png)

## **控制換行**

段落換行規則在狹窄文字區塊以及混合拉丁文與東亞文字的簡報中相當有用。以下方法屬於 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/)，因此會套用於整個段落：

- [setLatinLineBreak](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) 控制拉丁文字的換行規則。在混合文字中，變更此設定也會影響相鄰的東亞文字與標點的換行位置。
- [setEastAsianLineBreak](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) 控制東亞文字的換行規則，包括對行首與行尾字元的限制。

這些規則不會取代 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setWrapText)，後者會在文字框內啟用自動換行。它們會在換行發生時影響版面配置；不會插入換行字元。顯式的換行會在段落內強制換行，與可用寬度無關。

以下獨立範例建立一個包含中文與拉丁文字的窄文字區塊。它會明確設定兩個換行選項，並將檔案儲存為「line_breaking.pptx」。若要實驗任一規則，可更改相應的值，同時保持其他設定不變。範例使用 24 點 Arial 與 SimSun，框寬 160 點且水平文字框邊距為零。呼叫 [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setAutofitType) 時，使用 [TextAutofitType.None_](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textautofittype/) 以使文字大小與框尺寸保持固定。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **控制懸掛標點**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) 允許符合條件的標點符號延伸至文字行右邊緣之外，而不是佔據下一行。它適用於整個段落，且不同於懸掛縮排。

以下獨立範例在寬度為 100 點的文字框中啟用懸掛標點，並將檔案儲存為「hanging_punctuation.pptx」。使用 24 點 Arial 且水平文字框邊距為零時，最後的句點仍位於「sentence」之後，且延伸至文字右側邊緣。將屬性設為 [NullableBool.False_](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/nullablebool/) 可比較：在此設定下，句點會佔據單獨一行。啟用自動換行且停用自動調整大小，以固定可用寬度。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

並非所有標點符號都能懸掛。可見結果取決於字型可用性與版面配置：變更字型、可用寬度、邊距或自動調整設定可能會消除可見差異。

## **設定文字框的自動調整類型**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setAutofitType) 決定文字超出容器邊界時的行為。可用來控制文字是縮小、溢出，或自動調整形狀大小以適應文字。以下範例將形狀設定為自動調整大小以符合文字，並將結果儲存為「autofit_type.pptx」。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

若要在自動換行後統計行數並觀察文字或形狀寬度變化對結果的影響，請參閱[計算已渲染的行數](/slides/zh-hant/python-java/manage-paragraph/)。僅靠行數無法判斷文字是否溢出其容器。

## **設定文字框的錨點**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setAnchoringType) 定義文字在形狀內的垂直定位方式，例如置於頂部、中央或底部。以下範例將文字錨定於第一個圖形的底部，並將結果儲存為「text_anchor.pptx」。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定文字定位**

使用 [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) 與 [ParagraphFormat.getTabs](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#getTabs) 可為段落設定定位點。以下範例將預設定位間距設定為 100 點，並在 30 點處加入左對齊的定位點。這些設定會影響含有定位字元的文字。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![段落的定位](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setLanguageId)，可為文字部分設定校對語言。校對語言決定 PowerPoint 進行拼寫與文法檢查時使用的語言。

以下範例需要「presentation.pptx」，且其第一張投影片的第一個圖形為文字方塊且至少包含一個段落。它會將第一段落的內容取代為「1。」，將字型設為 SimSun，並指定簡體中文校對語言 (`zh-CN`)。最終結果儲存為「proofing_language.pptx」：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # 設定校對語言的 Id。
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定預設語言**

使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 可為載入或建立簡報時所建立的文字定義預設語言。以下範例建立一個預設文字語言為美式英語的簡報，加入文字方塊，並為其第一個文字部分輸出 `en-US`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # 新增帶文字的矩形形狀。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # 檢查第一個文字部分的語言。
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，可使用 [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getDefaultTextStyle)。

以下範例將 14 點粗體字型設定為新簡報中頂層段落的預設，並將檔案儲存為「default_text_style.pptx」。文字會繼承這些預設，除非有更具體的格式覆寫。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # 取得頂層段落格式。
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **擷取套用全大寫效果的文字**

在 PowerPoint 中，套用 **All Caps**（全大寫）字型效果會使文字在投影片上以大寫顯示，即使原始輸入為小寫。使用 Aspose.Slides 取得此類文字部分時，函式庫會返回原始輸入的文字。若要匹配顯示的文字，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textcaptype/)，在值為 `All` 時將回傳的字串轉為大寫。

此範例需要「sample2.pptx」，且其第一張投影片的第一個圖形為文字方塊。其第一段落的第一個文字部分包含套用全大寫效果的「Hello, Aspose!」，如下所示。

![全大寫效果](all_caps_effect.png)

以下程式碼範例示範如何擷取套用 **All Caps** 效果的文字：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

輸出：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **常見問題**

**如何在投影片上的表格中修改文字？**

要在投影片的表格中修改文字，請使用 [Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/)。遍歷儲存格，並透過 [Cell.getTextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cell/#getTextFrame) 更新每個儲存格，並使用 [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/#getParagraphFormat) 調整段落格式。

**如何在 PowerPoint 投影片的文字上套用漸層顏色？**

要為文字套用漸層顏色，請使用 [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#getFillFormat)。將 [FillFormat.setFillType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fillformat/#setFillType) 設為 [FillType.Gradient](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/filltype/)，並設定漸層停點、方向與透明度。