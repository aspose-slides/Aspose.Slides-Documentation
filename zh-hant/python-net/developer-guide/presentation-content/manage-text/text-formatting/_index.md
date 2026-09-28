---
title: 在 Python 中格式化簡報文字
linktitle: 文字格式化
type: docs
weight: 50
url: /zh-hant/python-net/text-formatting/
keywords:
- 對齊段落
- 文字樣式
- 文字背景
- 文字透明度
- 字元間距
- 字型屬性
- 字型系列
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
- Aspose.Slides
description: 使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中格式化與樣式化文字。自訂字型、顏色、對齊方式等。
---
## **概觀**

本文說明如何使用 Aspose.Slides for Python via .NET 於 PowerPoint 與 OpenDocument 簡報中格式化文字。內容涵蓋背景顏色、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨點、定位點以及語言設定。

除非另有說明，範例皆使用 [sample.pptx](sample.pptx)。第一張投影片的第一個圖形是一個文字方塊，其第一段落包含以下顯示的文字。投影片與圖形的索引皆從零開始。選取粗體區段的範例使用有效的格式設定，包括繼承的粗體格式：

![範例文字](sample_text.png)

若要尋找並突顯文字字面值或正規表達式匹配項目，請參閱 [搜尋與取代文字](/slides/zh-hant/python-net/search-and-replace-text/)。

## **設定文字背景顏色**

使用 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/default_portion_format/) 來設定段落的預設標記顏色，或使用 [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/highlight_color/) 針對個別文字區段設定。

以下範例將淡灰色標記設定為第一段落的預設。個別區段的明確標記顏色會優先於此預設值：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 設定整段落的突顯顏色。
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼範例示範如何為 **粗體字型的文字區段** 設定背景顏色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 設定文字區段的突顯顏色。
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![灰色文字區段](gray_text_portions.png)

## **對齊文字段落**

使用 [ParagraphFormat.alignment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/alignment/) 於文字框內設定段落對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

以下程式碼範例示範如何將段落對齊至 **置中**：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 設定段落的對齊方式為置中。
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![對齊的段落](aligned_paragraph.png)

## **設定文字透明度**

文字透明度透過指派給 [BasePortionFormat.fill_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/fill_format/) 之顏色的 α 成分來控制。在以下範例中，`alpha = 50` 為 0–255 範圍的 ARGB α 通道值，並非透明度百分比。

以下程式碼範例示範如何對 **整段文字** 套用透明度：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 設定文字的半透明黑色填充。
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![透明段落](transparent_paragraph.png)

以下程式碼範例示範如何對 **粗體字型的文字區段** 套用透明度：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 設定文字區段的透明度。
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![透明文字區段](transparent_text_portions.png)

## **設定文字字元間距**

使用 [BasePortionFormat.spacing](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/spacing/) 以在文字方塊中擴大或縮小字元間距。範例中加入 3 點間距；負值則會壓縮文字。

以下 Python 程式碼示範如何在 **整段文字** 中展開字元間距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 注意: 使用負值可壓縮字元間距。
    paragraph.paragraph_format.default_portion_format.spacing = 3  # 展開字元間距。

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼範例示範如何在 **粗體字型的文字區段** 中展開字元間距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 注意: 使用負值可壓縮字元間距。
            portion.portion_format.spacing = 3  # 展開字元間距。

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![文字區段中的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距微調**

在某些情況下，Aspose.Slides 所呈現的文字可能比 PowerPoint 中相同的文字看起來稍微緊密。這可能是因為 PowerPoint 會忽略某些字型的字距微調資料，即使該字型包含有效的字距微調資訊且在 PowerPoint 設定中已啟用字距微調。

為使渲染結果更接近 PowerPoint，可對使用受影響字型的文字區段停用字距微調。將 [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) 設為大於實際字型大小的數值。此範例需要「presentation.pptx」，其中第一張投影片的第一個圖形為文字方塊。它會檢查有效的字型名稱（包括繼承的字型），並對使用 Roboto 的區段設定 100 點的門檻。這會在字型大小低於 100 點時停用匹配區段的字距微調：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

對於低於門檻的匹配文字，此設定會阻止字距微調，並可協助使 Aspose.Slides 的渲染與 PowerPoint 在受此 PowerPoint 特定行為影響的字型之視覺輸出保持一致。

## **管理文字字型屬性**

字型屬性可透過 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/default_portion_format/) 在段落層級設定，或透過 [PortionFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/) 在個別區段設定。

以下範例將第一段落的預設字型設定為 12 點 Times New Roman，並套用粗體、斜體與點線底線格式。個別區段的明確格式會優先於這些預設值。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 設定段落的字型屬性。
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![段落的字型屬性](font_properties_for_paragraph.png)

以下範例對有效格式為粗體的區段套用 13 點 Times New Roman、斜體以及點線底線：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 設定文字區段的字型屬性。
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![文字區段的字型屬性](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用 [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/text_vertical_type/) 以在圖形內設定預先定義的文字方向。

以下程式碼範例將圖形內的文字方向設為 [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textverticaltype/)，此設定會使文字 **逆時針旋轉 90 度**：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![文字旋轉](text_rotation.png)

## **設定文字框的自訂旋轉**

使用 [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/rotation_angle/) 為 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 設定自訂的旋轉角度。

以下程式碼範例在圖形內將文字框順時針旋轉 3 度：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落的行距**

Aspose.Slides 提供 [ParagraphFormat.space_after](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/space_after/)、[ParagraphFormat.space_before](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/space_before/)、以及 [ParagraphFormat.space_within](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/space_within/) 以控制段落間距。使用方式如下：

* 使用正值以百分比表示行距（相對於行高）。
* 使用負值以點數表示行距。

以下範例將第一段落的內部間距設為行高的 200%（雙倍行距）：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![段落內的行距](line_spacing.png)

## **控制換行規則**

段落換行規則在窄幅文字區塊以及混合拉丁文與東亞文字的簡報中相當實用。以下屬性屬於 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/)，因此套用於整個段落：

- [latin_line_break](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/latin_line_break/) 控制拉丁文的換行規則。在混合文字中，變更此設定也會影響相鄰的東亞文字與標點符號的換行位置。
- [east_asian_line_break](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/east_asian_line_break/) 控制東亞文字的換行規則，包含行首與行尾字元的限制。

這些規則不會取代 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/wrap_text/)，後者啟用文字框內的自動換行。這些規則會在換行發生時影響版面布局，卻不會插入換行字元。明確的換行會在段落內強制新行，與可用寬度無關。

以下獨立範例建立一個包含中文與拉丁文字的窄幅文字區塊，明確設定兩項換行屬性並另存為「line_breaking.pptx」。若要測試任一規則，變更該屬性的值，同時保持另一設定不變。範例使用 24 點 Arial 與 SimSun，框寬 160 點且水平文字框邊距為零。[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/autofit_type/) 設為 [TextAutofitType.NONE](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textautofittype/)，以固定文字大小與框尺寸。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版測試，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **控制懸掛標點**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/hanging_punctuation/) 允許符合條件的標點延伸至文字行右側邊緣，而不是佔用下一行。此屬性適用於整段落，且不同於懸掛縮排。

以下獨立範例在 100 點寬的文字框中啟用懸掛標點，並另存為「hanging_punctuation.pptx」。使用 24 點 Arial 且水平文字框邊距為零，最後的句點會留在「sentence」之後，並延伸至文字右側邊緣。將屬性設為 [NullableBool.FALSE](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/nullablebool/) 以作比較：此設定下，句點會佔據單獨一行。啟用換行且停用自動調整，以固定可用寬度。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

並非所有標點符號皆能懸掛。可見結果取決於字型與版面條件：變更字型、可用寬度、邊距或自動調整設定皆可能使差異消失。

## **設定文字框的自動調整類型**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/autofit_type/) 決定文字超出容器邊界時的行為。可用於控制文字是否縮小、溢出或自動調整圖形大小。以下範例將圖形設定為依文字自動調整大小，並另存為「autofit_type.pptx」。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

若要在自動換行後計算行數並觀察文字或圖形寬度變化對結果的影響，請參閱 [計算呈現行數](/slides/zh-hant/python-net/manage-paragraph/)。僅行數並不表示文字是否溢出容器。

## **設定文字框的錨點**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/anchoring_type/) 定義文字在圖形內垂直定位的方式，例如置頂、置中或置底。以下範例將文字錨點設為第一個圖形的底部，並另存為「text_anchor.pptx」。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **設定文字定位點**

使用 [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/default_tab_size/) 與 [ParagraphFormat.tabs](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/tabs/) 來配置段落的定位點。以下範例將預設定位間距設為 100 點，並在 30 點位置新增左對齊的定位點。此設定會影響包含定位字元的文字。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![段落定位點](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [BasePortionFormat.language_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/language_id/)，可為文字區段設定校對語言。校對語言決定 PowerPoint 進行拼字與文法檢查時所使用的語言。

以下範例需要「presentation.pptx」，其第一張投影片的第一個圖形為文字方塊且至少有一個段落。它會將第一段落的內容取代為「1。」、將字型設為 SimSun，並指定簡體中文校對語言 (`zh-CN`)。結果另存為「proofing_language.pptx」：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # 設定校對語言為簡體中文。
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **設定預設語言**

使用 [LoadOptions.default_text_language](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/default_text_language/) 來定義在載入或建立簡報時所產生文字的預設語言。以下範例建立一個以美式英語作為預設文字語言的簡報，加入文字方塊，並印出其第一個文字區段的 `en-US`。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # 新增一個帶文字的矩形圖形。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # 檢查第一個區段的語言。
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用 [Presentation.default_text_style](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/default_text_style/)。

以下範例在新簡報的頂層段落設定 14 點粗體字型為預設，並另存為「default_text_style.pptx」。文字會繼承這些預設值，除非更具體的格式設定覆寫它們。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 取得最高層級的段落格式。
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **擷取全部大寫效果的文字**

在 PowerPoint 中，套用 **全大寫** (All Caps) 字型效果會使投影片上的文字以大寫顯示，即使原始輸入為小寫。當使用 Aspose.Slides 取得此類文字區段時，函式庫會回傳原始輸入的文字。若要與顯示效果一致，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textcaptype/)，當其值為 `ALL` 時，將回傳的字串轉為大寫。

此範例需要「sample2.pptx」，其第一張投影片的第一個圖形為文字方塊。第一段落的第一個區段包含帶有全大寫效果的「Hello, Aspose!」，如下圖所示。

![全大寫效果](all_caps_effect.png)

以下程式碼範例示範如何擷取套用 **全大寫** 效果的文字：

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

輸出：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **常見問題**

**如何在投影片的表格中修改文字？**

要在投影片的表格中修改文字，請使用 [Table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/)。遍歷儲存格，透過 [Cell.text_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cell/text_frame/) 更新每個儲存格，並使用 [Paragraph.paragraph_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/paragraph_format/) 進行段落格式設定。

**如何在 PowerPoint 投影片上的文字套用漸層顏色？**

要為文字套用漸層顏色，請使用 [BasePortionFormat.fill_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/fill_format/)。將 [FillFormat.fill_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/fill_type/) 設為 [FillType.GRADIENT](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/)，並配置漸層停點、方向與透明度。