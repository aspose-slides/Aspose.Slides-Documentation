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
- 字型族
- 文字旋轉
- 旋轉角度
- 文字框
- 行距
- 自動調整屬性
- 文字框錨點
- 文字定位點
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中格式化與樣式化文字。自訂字型、顏色、對齊方式等更多設定。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for Python via .NET 來格式化 PowerPoint 與 OpenDocument 簡報中的文字。涵蓋背景顏色、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨定、定位點以及語言設定。

以下範例將使用名為「sample.pptx」的檔案，該檔案在第一張投影片上包含一個含有以下文字的單一文字方塊：

![範例文字](sample_text.png)

要找出並突顯文字或正規表達式匹配，請參考[搜尋與取代文字](/slides/zh-hant/python-net/search-and-replace-text/)。

## **設定文字背景顏色**

使用[ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/default_portion_format/) 來設定段落的預設突顯顏色，或使用[PortionFormat.highlight_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/highlight_color/) 針對單一文字片段設定顏色。

以下程式碼範例示範如何為**整個段落**設定背景顏色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 設定整個段落的突顯顏色。
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼範例示範如何為**具有粗體字型的文字片段**設定背景顏色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 設定文字片段的突顯顏色。
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![灰色文字片段](gray_text_portions.png)

## **對齊文字段落**

使用[ParagraphFormat.alignment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/alignment/) 來設定文字框內段落的對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

以下程式碼範例示範如何將段落對齊至**置中**：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 設定段落的對齊方式為置中。
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![已對齊的段落](aligned_paragraph.png)

## **設定文字透明度**

文字透明度透過指派給[PortionFormat.fill_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/fill_format/)之顏色的 alpha 成分來控制。在下列範例中，`alpha = 50` 為 0-255 之 ARGB alpha 通道值，並非透明度百分比。

以下程式碼範例示範如何對**整個段落**套用透明度：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 設定文字的填充顏色為透明色。
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![透明段落](transparent_paragraph.png)

以下程式碼範例示範如何對**具有粗體字型的文字片段**套用透明度：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 設定文字片段的透明度。
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![透明文字片段](transparent_text_portions.png)

## **設定文字字元間距**

使用[BasePortionFormat.spacing](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/spacing/) 以擴大或縮小文字方塊中字元之間的間距。

以下 Python 程式碼示範如何在**整個段落**中展開字元間距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 注意：使用負值來壓縮字元間距。
    paragraph.paragraph_format.default_portion_format.spacing = 3  # 擴展字元間距。

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼範例示範如何在**具有粗體字型的文字片段**中展開字元間距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 注意：使用負值來壓縮字元間距。
            portion.portion_format.spacing = 3  # 擴展字元間距。

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![文字片段中的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距調整**

在某些情況下，由 Aspose.Slides 呈現的文字可能比 PowerPoint 中顯示的相同文字看起來略為緊密。這可能是因為 PowerPoint 會忽略某些字型的字距調整資料，即使該字型包含有效的字距資訊且在 PowerPoint 設定中已啟用字距調整。

為了使此類情況下的渲染輸出更接近 PowerPoint，您可以對使用受影響字型的文字片段停用字距調整。將[BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) 設為遠大於實際字型大小的值：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

此設定會阻止對符合條件的文字片段套用字距調整，並有助於使 Aspose.Slides 的渲染與受此 PowerPoint 特定行為影響的字型在 PowerPoint 中的視覺輸出保持一致。

## **管理文字字型屬性**

字型屬性可透過[ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/default_portion_format/) 設定於段落層級，或透過[PortionFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/) 設定於單一文字片段。

以下程式碼為整個段落設定字型與文字樣式：它會對段落內所有文字片段套用字型大小、粗體、斜體、點狀底線，以及 Times New Roman 字型。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 設定段落的字型屬性。
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![段落的字型屬性](font_properties_for_paragraph.png)

以下程式碼範例將類似屬性套用到**具有粗體字型的文字片段**：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 設定文字片段的字型屬性。
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![文字片段的字型屬性](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用[TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/text_vertical_type/) 以在圖形內設定預定義的文字方向。

以下程式碼範例將圖形內的文字方向設為 `VERTICAL270`，即將文字**逆時針旋轉 90 度**：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![文字旋轉](text_rotation.png)

## **設定文字框的自訂旋轉**

使用[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/rotation_angle/) 為[TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 設定自訂旋轉角度。

以下程式碼範例將文字框在圖形內順時針旋轉 3 度：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落行距**

Aspose.Slides 提供[ParagraphFormat.space_after](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/space_after/)、[ParagraphFormat.space_before](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/space_before/)、以及[ParagraphFormat.space_within](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/space_within/) 以控制段落間距。這些屬性的使用方式如下：

* 使用正值以指定行距為行高的百分比。
* 使用負值以指定行距的點數。

以下程式碼範例示範如何在段落內指定行距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![段落內的行距](line_spacing.png)

## **設定文字框的自動調整類型**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/autofit_type/) 決定文字在超過容器邊界時的行為。可用來控制文字是縮小、溢出，或自動調整圖形大小。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **設定文字框的錨點**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/anchoring_type/) 定義文字在圖形內的垂直定位方式，例如置於頂部、垂直居中或底部。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **設定文字定位點**

使用[ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/default_tab_size/)與[ParagraphFormat.tabs](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/tabs/) 以在段落中配置定位點。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![段落定位點](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供[PortionFormat.language_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/language_id/)，讓您能為文字片段設定校對語言。校對語言決定 PowerPoint 中拼字與文法檢查所使用的語言。

以下程式碼範例示範如何為文字片段設定校對語言：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # 設定校對語言的 Id。
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **設定預設語言**

使用[LoadOptions.default_text_language](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/default_text_language/) 以定義載入或建立簡報時所建立文字的預設語言。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # 新增一個帶文字的矩形圖形。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # 檢查第一個文字片段的語言。
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用[Presentation.default_text_style](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/default_text_style/)。

以下程式碼範例示範如何在新簡報中為所有投影片的全部文字設定預設的 14 點粗體字型：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 取得頂層段落格式。
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **擷取套用全大寫效果的文字**

在 PowerPoint 中，套用 **All Caps** 字型效果會使投影片上的文字以大寫顯示，即使原本是以小寫輸入。當您使用 Aspose.Slides 取得此類文字片段時，函式庫會返回其原始輸入的文字。若要與顯示的文字一致，請檢查[TextCapType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textcaptype/) 並在其值為 `ALL` 時將返回的字串轉為大寫。

假設我們在 sample2.pptx 檔案的第一張投影片上有以下文字方塊。

![全大寫效果](all_caps_effect.png)

以下程式碼範例示範如何擷取已套用 **All Caps** 效果的文字：

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

要在投影片的表格中修改文字，請使用[Table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/)。遍歷儲存格並透過[Cell.text_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cell/text_frame/) 更新每個儲存格，並使用[Paragraph.paragraph_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/paragraph_format/) 進行段落格式設定。

**如何在 PowerPoint 投影片的文字上套用漸層顏色？**

若要為文字套用漸層顏色，請使用[PortionFormat.fill_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/fill_format/)。將[FillFormat.fill_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/fill_type/) 設為[FillType.GRADIENT](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/)，並配置漸層停點、方向以及透明度。