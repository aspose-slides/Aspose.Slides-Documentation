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
- 字型族
- 文字旋轉
- 旋轉角度
- 文字框
- 行間距
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
description: "使用 Aspose.Slides for Python via Java 於 PowerPoint 與 OpenDocument 簡報中格式化與樣式化文字。自訂字型、顏色、對齊方式等。"
---
## **概述**

本文介紹如何使用 Aspose.Slides for Python via Java 來格式化 PowerPoint 與 OpenDocument 簡報中的文字。內容涵蓋背景顏色、透明度、字元間距、字型屬性、旋轉、段落間距、自動適應行為、文字錨點、定位點與語言設定。

以下範例中，我們將使用名為「sample.pptx」的檔案，其中第一張投影片包含一個文字方塊，文字如下：

![範例文字](sample_text.png)

若要尋找並突出顯示文字或正則表達式的匹配項，請參閱[搜尋與取代文字](/slides/zh-hant/python-java/search-and-replace-text/)。

## **設定文字背景顏色**

使用[ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat)可為段落設定預設的突顯顏色，或使用[PortionFormat.getHighlightColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/)為單獨的文字部份設定。

以下程式碼範例示範如何為**整段文字**設定背景顏色：

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

    # 設定整個段落的突顯顏色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果如下：

![灰色段落](gray_paragraph.png)

以下程式碼範例示範如何為**使用粗體字型的文字部份**設定背景顏色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpace.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # 設定文字部份的突顯顏色。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果如下：

![灰色文字部份](gray_text_portions.png)

## **對齊文字段落**

使用[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setAlignment)可設定文字框內段落的對齊方式。其值可以是置中、左對齊、右對齊、兩端對齊等等。

以下程式碼範例示範如何將段落對齊至**置中**：

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

結果如下：

![已對齊的段落](aligned_paragraph.png)

## **設定文字透明度**

文字透明度是透過指派給[PortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/)的顏色之 alpha 成分來控制的。在以下範例中，`alpha = 50` 為 ARGB alpha 通道值，範圍為 0–255，而非透明度百分比。

以下程式碼範例示範如何將透明度套用於**整段文字**：

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

結果如下：

![透明段落](transparent_paragraph.png)

以下程式碼範例示範如何將透明度套用於**使用粗體字型的文字部份**：

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
            # 設定文字部份的透明度。
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果如下：

![透明文字部份](transparent_text_portions.png)

## **設定文字字元間距**

使用[PortionFormat.setSpacing](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/)可擴大或收縮文字方塊中字元之間的間距。

以下 Python 程式碼示範如何在**整段文字**中擴張字元間距：

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

    # 注意: 使用負值壓縮字元間距。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # 擴張字元間距。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果如下：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼範例示範如何在**使用粗體字型的文字部份**中擴張字元間距：

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
            # 注意: 使用負值壓縮字元間距。
            portion.getPortionFormat().setSpacing(3) # 擴張字元間距。

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果如下：

![文字部份中的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距微調 (Kerning)**

在某些情況下，Aspose.Slides 所呈現的文字可能較 PowerPoint 顯示的文字略為緊密。這可能是因為 PowerPoint 會忽略某些字型的字距微調資料，即使該字型包含有效的字距微調資訊且在 PowerPoint 設定中已啟用。

若要使呈現效果更接近 PowerPoint，可對使用受影響字型的文字部份停用字距微調。將[PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/) 設為遠大於實際字型大小的值：

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
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此設定可防止對符合條件的文字部份套用字距微調，協助將 Aspose.Slides 的渲染結果與 PowerPoint 的視覺輸出保持一致。

## **管理文字字型屬性**

字型屬性可透過[ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 在段落層級設定，或透過[PortionFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/) 在單一部份設定。

以下程式碼設定整段文字的字型與樣式：套用字型大小、粗體、斜體、點狀底線，以及 Times New Roman 字型至段落中的所有部份：

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

結果如下：

![段落的字型屬性](font_properties_for_paragraph.png)

以下程式碼範例將相同屬性套用於**使用粗體字型的文字部份**：

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
            # 設定文字部份的字型屬性。
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果如下：

![文字部份的字型屬性](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setTextVerticalType)可為形狀內的文字設定預先定義的方向。

以下程式碼範例將形狀內的文字方向設定為 `Vertical270`，使文字**逆時針旋轉 90 度**：

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

結果如下：

![文字旋轉](text_rotation.png)

## **設定文字框的自訂旋轉**

使用[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setRotationAngle)可為[TextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframe/)設定自訂旋轉角度。

以下程式碼範例將文字框於形狀內順時針旋轉 3 度：

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

結果如下：

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落的行間距**

Aspose.Slides 提供[ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setSpaceAfter)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setSpaceBefore) 與[ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setSpaceWithin) 以控制段落間距。這些屬性的使用方式如下：

* 使用正值可將行間距指定為行高的百分比。
* 使用負值可以點 (pt) 為單位指定行間距。

以下程式碼範例示範如何在段落內指定行間距：

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

結果如下：

![段落內的行間距](line_spacing.png)

## **設定文字框的自動調整類型**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setAutofitType) 決定文字超出容器邊界時的行為。使用它可控制文字是縮小、溢出或自動調整形狀大小。

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

## **設定文字框的錨點**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#setAnchoringType) 定義文字在形狀內的垂直位置，例如置頂、置中或置底。

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

## **設定文字定位點**

使用[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) 與[ParagraphFormat.getTabs](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#getTabs) 可在段落中配置定位點。

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

結果如下：

![段落的定位點](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供[PortionFormat.setLanguageId](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/) 可為文字部份設定校對語言。校對語言決定在 PowerPoint 中進行拼寫與文法檢查時使用的語言。

以下程式碼範例示範如何為文字部份設定校對語言：

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

使用[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 可定義在載入或建立簡報時所建立文字的預設語言。

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

    # 新增一個帶文字的矩形形狀。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # 檢查第一個文字部份的語言。
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用[Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getDefaultTextStyle)。

以下程式碼範例示範如何在新簡報的所有投影片中，將預設字型設定為粗體、字型大小 14 pt：

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

## **以全大寫效果提取文字**

在 PowerPoint 中，套用 **All Caps** 字型效果會使文字在投影片上以大寫顯示，即使原始輸入為小寫。使用 Aspose.Slides 取得此類文字部份時，函式庫會回傳原始輸入的文字。若要與顯示結果一致，請檢查[TextCapType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textcaptype/) 並在值為 `All` 時將回傳的字串轉為大寫。

假設我們在 sample2.pptx 的第一張投影片上有以下文字方塊：

![全大寫效果](all_caps_effect.png)

以下程式碼範例示範如何提取套用 **All Caps** 效果的文字：

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

**如何修改投影片上表格中的文字？**

要修改投影片上表格中的文字，請使用[Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/)。遍歷儲存格並透過[Cell.getTextFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/cell/#getTextFrame) 取得文字框，並使用[Paragraph.getParagraphFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/#getParagraphFormat) 進行段落格式設定。

**如何在 PowerPoint 投影片上的文字套用漸層顏色？**

要在文字上套用漸層顏色，請使用[PortionFormat.getFillFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/)。將[FillFormat.setFillType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fillformat/#setFillType) 設為[FillType.Gradient](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/filltype/#Gradient)，並設定漸層停止點、方向與透明度。