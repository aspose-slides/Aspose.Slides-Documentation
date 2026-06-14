---
title: 在 Python 中格式化簡報文字
linktitle: 文字格式化
type: docs
weight: 50
url: /zh-hant/python-net/text-formatting/
keywords:
- 突顯文字
- 正規表達式
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
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中格式化與樣式化文字。自訂字型、色彩、對齊方式等。"
---
## **概述**

本文說明如何使用 Aspose.Slides for Python via .NET 來格式化 PowerPoint 與 OpenDocument 簡報中的文字。內容涵蓋醒目標示、背景色、透明度、字元間距、字型屬性、旋轉、段落間距、自動縮放行為、文字錨點、定位點以及語言設定。

在以下範例中，我們將使用名為「sample.pptx」的檔案，該檔案在第一張投影片上包含一個文字方塊，內容如下：

![範例文字](sample_text.png)

## **標示文字**

使用 [TextFrame.highlight_text](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/highlight_text/) 方法當您需要在文字框中標示符合特定樣本的文字時。該方法會將醒目色套用至符合的文字片段，並可與 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textsearchoptions/) 搭配使用，以控制搜尋方式，例如只匹配完整單詞。

以下程式碼範例會將所有 **"try"** 字元標示出來，然後僅標示完整的單字 **"to"** 。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # 取得第一張投影片中的第一個形狀。
    shape = presentation.slides[0].shapes[0]

    # 在形狀中突顯字詞 "try"。
    shape.text_frame.highlight_text("try", draw.Color.light_blue)

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True

    # 在形狀中突顯字詞 "to"。
    shape.text_frame.highlight_text("to", draw.Color.violet, search_options, None)

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![已標示的文字](highlighted_text.png)

## **使用正則表達式標示文字**

[TextFrame.highlight_regex](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/highlight_regex/) 方法會將正則表達式找到的文字匹配項目標示出來。在 Python 中，該 API 以 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 形式公開。

以下程式碼範例會標示所有 **包含七個或以上字符** 的單詞：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    regex = r"\b[^\s]{7,}\b"

    # 突顯所有含有七個或以上字元的單詞。
    shape.text_frame.highlight_regex(regex, draw.Color.yellow, None)

    presentation.save("highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![使用正則表達式標示的文字](highlighted_text_using_regex.png)

## **設定文字背景色**

使用 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/default_portion_format/) 可為段落設定預設的醒目色，或使用 [PortionFormat.highlight_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/highlight_color/) 為個別文字區段設定醒目色。

以下程式碼範例顯示如何為 **整段落** 設定背景色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 設定整段落的醒目顏色。
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼範例示範如何為 **粗體字型的文字區段** 設定背景色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 設定文字區段的醒目顏色。
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![灰色文字區段](gray_text_portions.png)

## **對齊文字段落**

使用 [ParagraphFormat.alignment](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/alignment/) 可設定文字框內段落的對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

以下程式碼範例顯示如何將段落對齊至 **置中**：

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

文字透明度透過指定給 [PortionFormat.fill_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/fill_format/) 的顏色之 alpha 成分來控制。在以下範例中，`alpha = 50` 為 0‑255 範圍內的 ARGB alpha 通道值，並非透明度百分比。

以下程式碼範例示範如何為 **整段落** 套用透明度：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 設定文字的填充顏色為透明顏色。
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![透明段落](transparent_paragraph.png)

以下程式碼範例示範如何為 **粗體字型的文字區段** 套用透明度：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

使用 [BasePortionFormat.spacing](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/spacing/) 可在文字方塊內擴大或縮小字元之間的間距。

以下 Python 程式碼示範如何在 **整段落** 中擴大字元間距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 注意：使用負值來壓縮字元間距。
    paragraph.paragraph_format.default_portion_format.spacing = 3  # 展開字元間距。

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼範例示範如何在 **粗體字型的文字區段** 中擴大字元間距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 注意：使用負值來壓縮字元間距。
            portion.portion_format.spacing = 3  # 展開字元間距。

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![文字區段中的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距微調**

在某些情況下，Aspose.Slides 呈現的文字可能看起來比 PowerPoint 中的相同文字稍微緊湊。這可能是因為 PowerPoint 會忽略某些字型的字距微調資料，即使該字型已包含有效的字距微調資訊且在 PowerPoint 設定中已啟用字距微調。

若要在此類情況下使渲染輸出更接近 PowerPoint，可為使用受影響字型的文字區段停用字距微調。將 [PortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) 設為遠大於實際字型大小的值：

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

此設定會阻止對符合的文字區段套用字距微調，並有助於在受 PowerPoint 特定行為影響的字型上，使 Aspose.Slides 的渲染結果與 PowerPoint 的視覺輸出更為一致。

## **管理文字字型屬性**

字型屬性可透過 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/default_portion_format/) 在段落層級設定，或透過 [PortionFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/) 在單一區段上設定。

以下程式碼為整段落設定字型與文字樣式：為段落內所有區段套用字型大小、粗體、斜體、點狀底線，以及 Times New Roman 字型。

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

以下程式碼範例為 **粗體字型的文字區段** 套用類似屬性：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

使用 [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/text_vertical_type/) 可在形狀內設定預定義的文字方向。

以下程式碼範例將形狀內的文字方向設定為 `VERTICAL270`，即將文字 **逆時針旋轉 90 度**：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![文字旋轉](text_rotation.png)

## **設定文字框自訂旋轉**

使用 [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/rotation_angle/) 可為 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 設定自訂的旋轉角度。

以下程式碼範例將文字框在形狀內順時針旋轉 3 度：

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

Aspose.Slides 提供 [ParagraphFormat.space_after](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/space_after/)、[ParagraphFormat.space_before](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/space_before/)、以及 [ParagraphFormat.space_within](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/space_within/) 以控制段落間距。這些屬性使用方式如下：

* 使用正值以百分比方式指定行距（相對於行高）。
* 使用負值以點數方式指定行距。

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

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/autofit_type/) 決定文字在超出容器邊界時的行為。可用來控制文字是縮小、溢出，或自動調整形狀大小。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **設定文字框的錨點**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframeformat/anchoring_type/) 定義文字在形狀內的垂直定位方式，例如置頂、置中或置底。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **設定文字定位點**

使用 [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/default_tab_size/) 與 [ParagraphFormat.tabs](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraphformat/tabs/) 來配置段落中的定位點。

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

Aspose.Slides 提供 [PortionFormat.language_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/language_id/)，可為文字區段設定校對語言。校對語言決定 PowerPoint 中拼寫與文法檢查所使用的語言。

以下程式碼範例顯示如何為文字區段設定校對語言：

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

    text_portion.text = "1."
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **設定預設語言**

使用 [LoadOptions.default_text_language](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/default_text_language/) 可為在載入或建立簡報時產生的文字定義預設語言。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # 新增一個帶文字的矩形形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # 檢查第一個文字區段的語言。
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用 [Presentation.default_text_style](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/default_text_style/)。

以下程式碼範例示範如何為新簡報中所有投影片的文字設定預設的粗體字型，字型大小為 14 pt：

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

## **擷取全部大寫效果的文字**

在 PowerPoint 中，套用 **全部大寫** 字型效果會使文字在投影片上以大寫顯示，即使原本是小寫。當您使用 Aspose.Slides 取得此類文字區段時，函式庫會回傳原始輸入的文字。為了匹配顯示的文字，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textcaptype/) 並在值為 `ALL` 時將返回的字串轉為大寫。

假設我們在 sample2.pptx 檔案的第一張投影片上有以下文字方塊。

![全部大寫效果](all_caps_effect.png)

以下程式碼範例示範如何擷取套用 **全部大寫** 效果的文字：

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

要在投影片的表格中修改文字，請使用 [Table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/)。遍歷儲存格並透過 [Cell.text_frame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cell/text_frame/) 更新每個儲存格，並透過 [Paragraph.paragraph_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/paragraph_format/) 調整段落格式。

**如何在 PowerPoint 投影片的文字上套用漸層顏色？**

要為文字套用漸層顏色，請使用 [PortionFormat.fill_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/fill_format/)。將 [FillFormat.fill_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fillformat/fill_type/) 設為 [FillType.GRADIENT](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/filltype/)，並配置漸層停止點、方向與透明度。