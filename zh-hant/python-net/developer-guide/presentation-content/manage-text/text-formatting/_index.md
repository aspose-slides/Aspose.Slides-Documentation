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
- 自動適應屬性
- 文字框錨點
- 文字定位
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 PowerPoint 和 OpenDocument 簡報中使用 Aspose.Slides for Python via .NET 進行文字的格式化與樣式設定。自訂字型、顏色、對齊方式等。"
---
## **概述**

本文說明如何在 PowerPoint 和 OpenDocument 簡報中使用 Aspose.Slides for Python via .NET 進行文字格式設定。它涵蓋背景色、透明度、字元間距、字型屬性、旋轉、段落間距、自動適應行為、文字錨點、定位點以及語言設定。

除非另有說明，範例使用 [sample.pptx](sample.pptx)。第一張投影片的第一個圖形是一個文字方塊，其第一段落包含以下顯示的文字。投影片與圖形索引皆以 0 為起始。選取粗體部分的範例使用有效格式，包括繼承的粗體格式：
![範例文字](sample_text.png)

若要找出並凸顯文字或正規表達式匹配項目，請參閱 [搜尋與取代文字](/slides/zh-hant/python-net/search-and-replace-text/)。

## **設定文字背景顏色**

使用 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) 設定段落的預設凸顯顏色，或使用 [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) 為個別文字片段設定凸顯顏色。

以下範例將淡灰色凸顯設為第一段落的預設。個別片段的顯式凸顯顏色會優先於此預設：
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 為整個段落設定突顯顏色。
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果如下：
![灰色段落](gray_paragraph.png)

以下程式碼範例示範如何為 **粗體字型的文字片段** 設定背景顏色：
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 為文字片段設定突顯顏色。
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果如下：
![灰色文字片段](gray_text_portions.png)

## **對齊文字段落**

使用 [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 設定文字框內段落的對齊方式。其值可為置中、左對齊、右對齊、兩端對齊等。

以下程式碼範例顯示如何將段落對齊至 **置中**：
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 將段落的對齊方式設定為置中。
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果如下：
![已對齊的段落](aligned_paragraph.png)

## **對齊行內字型**

使用 [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) 垂直對齊同一行中不同字型大小的文字片段。此設定套用於整個段落，並控制每行內的對齊方式。

以下獨立範例在同一張投影片上建立四個帶標籤的文字方塊。每個段落以 18、36、54 點大小呈現相同文字，並使用不同的字型對齊方式。它使用 Arial，停用自動適應與換行，並將文字框保持足夠大以容納單行文字。
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

結果如下：
![基線、頂部、置中與底部字型對齊的比較（混合字型大小）](font_alignment.png)

字型對齊使用字型度量，因而個別字母的可見邊緣未必完全對齊。範例同時包含大寫字母與下延字，以說明基線與底部對齊的差異。字型可用性與替代、使用的字元以及字型大小差異皆會影響結果。框架尺寸、邊距、行距、換行與自動適應亦會影響版面；比對模式時請使用相同的字型與版面設定。

此設定與 [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 不同，後者控制水平段落對齊；亦不同於 [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/)，後者在形狀內垂直定位文字區塊。透過 [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) 的上標與下標格式會相對於基線移動個別片段，而非為段落行設定字型對齊。

## **設定文字透明度**

文字透明度透過指派給 [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) 的顏色之 alpha 成分來控制。以下範例中，`alpha = 50` 為 0–255 範圍的 ARGB alpha 通道值，而非透明度百分比。

以下程式碼範例示範如何對 **整段** 套用透明度：
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

結果如下：
![透明段落](transparent_paragraph.png)

以下程式碼範例示範如何對 **粗體字型的文字片段** 套用透明度：
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
            # 設定文字片段的透明度。
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果如下：
![透明文字片段](transparent_text_portions.png)

## **設定文字字元間距**

使用 [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) 以擴大或縮小文字方塊中字元之間的間距。以下範例加入 3 點間距；負值則會壓縮文字。

以下 Python 程式碼示範如何在 **整段** 中展開字元間距：
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 注意：使用負值可壓縮字元間距。
    paragraph.paragraph_format.default_portion_format.spacing = 3  # 展開字元間距。

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果如下：
![段落內的字元間距](character_spacing_in_paragraph.png)

以下程式碼範例示範如何在 **粗體字型的文字片段** 中展開字元間距：
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 注意：使用負值可壓縮字元間距。
            portion.portion_format.spacing = 3  # 展開字元間距。

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果如下：
![文字片段內的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距調整**

在某些情況下，Aspose.Slides 所渲染的文字可能較 PowerPoint 中的同一文字稍微緊密。這可能是因為 PowerPoint 會忽略某些字型的字距調整資料，即使該字型包含有效的字距資訊且在 PowerPoint 設定中已啟用字距調整。

為使渲染結果更接近 PowerPoint，可對使用受影響字型的文字片段停用字距調整。將 [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) 設為大於實際字型大小的值。本範例需要「presentation.pptx」且其第一張投影片的第一個圖形為文字方塊。它會檢查有效的字型名稱（包括繼承的字型），並對使用 Roboto 且字型大小低於 100 點的片段設定 100 點的門檻：
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

對於低於門檻的符合文字，此設定會阻止字距調整，並有助於將 Aspose.Slides 的渲染與受此 PowerPoint 特定行為影響的字型的視覺輸出對齊。

## **管理文字字型屬性**

字型屬性可以透過 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) 在段落層級設定，或透過 [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) 在個別片段上設定。

以下範例將第一段落的預設字型設定為 12 點 Times New Roman，並套用粗體、斜體與點線底線。個別片段的顯式格式會優先於這些預設值：
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

結果如下：
![段落的字型屬性](font_properties_for_paragraph.png)

以下範例對有效格式為粗體的片段套用 13 點 Times New Roman、斜體與點線底線：
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

結果如下：
![文字片段的字型屬性](font_properties_for_text_portions.png)

## **控制文字高度正規化**

使用 [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) 可在重現範本排版或調查字元高度差異時進行正規化。在 PowerPoint 中，啟用正規化會在垂直方向拉伸或壓縮個別字元，使其在文字片段內呈現統一的可見高度。它並不保證不同字型之間的文字高度相等。

將屬性設為 [NullableBool.TRUE 或 FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) 可明確啟用或停用正規化。`NullableBool.NOT_DEFINED` 會保留本地設定未設定，讓片段繼承其值，例如自段落的 [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/)。這並不等同於 `False`。使用 [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) 並讀取 [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) 可取得解析後的布林值。

以下獨立範例需要安裝 **Arial**。它建立兩個文字區塊，內容包含相同的大寫字母、小寫字母、下延字與帶重音的字元，字型大小為 54 點。兩段落預設皆啟用正規化。上方的片段明確停用，下方則繼承。框架大小、邊距與段落間距相同，且停用換行與自動適應以保持比較一致。範例會輸出 `FALSE: False` 與 `NOT_DEFINED: True`，然後儲存為「text_height_normalization.pptx」：
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

下面的比較圖是從已儲存的簡報匯出。上列的正規化已停用 (`FALSE`)；下列則繼承啟用設定 (`NOT_DEFINED` → `True`)。請保留 Arial 安裝以重現此外觀。
![Arial 54 點文字，上方正規化停用，受繼承正規化啟用於下方](text_height_normalization.png)

正規化會改變字元高度，而不改變指定的 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) 數值（該值以點為單位指定字型大小）。段落的 [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) 控制行距，文字框的 [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) 控制文字或其容器的自動調整方式。這些設定各自服務不同目的，且可獨立影響整體版面。欲了解更多段落格式與繼承，請參閱 [管理段落](/slides/zh-hant/python-net/manage-paragraph/)。

## **套用與移除刪除線**

使用 [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) 可在文字片段上顯示刪除線、取消的詞語或先前價格，而無需刪除原始文字。將其設為 [TextStrikethroughType.SINGLE 或 DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) 可在文字上加入一條或兩條線。

若要移除刪除線，請指派 `TextStrikethroughType.NONE`。此設定會明確停用效果，即使周圍的格式指定了刪除線。相較之下，`TextStrikethroughType.NOT_DEFINED` 會將本地設定保持未定義，允許片段繼承格式，例如自段落而來。它並不保證刪除線已被移除。使用 [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) 可讀取最終的格式，包括繼承的值。

以下獨立範例建立三個價格比較。每段落都有標籤、先前價格與目前價格的獨立片段，因此僅先前價格受到影響。第一列先套用再移除刪除線；其他列則保留單線與雙線刪除線。變更此屬性可保留文字及其他格式，包括粗體的先前價格。
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # 套用刪除線，然後明確從第一個先前價格移除它。
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

結果（從上到下）：無刪除線、單線刪除線和雙線刪除線。
![先前價格（無刪除線、單線刪除線、雙線刪除線）](strikethrough.png)

## **設定文字旋轉**

使用 [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) 可在形狀內設定預定義的文字方向。

以下程式碼範例將形狀內的文字方向設定為 [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/)，此方向會將文字 **逆時針旋轉 90 度**：
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果如下：
![文字旋轉](text_rotation.png)

## **設定文字框的自訂旋轉**

使用 [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) 可為 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 設定自訂旋轉角度。

以下程式碼範例將文字框在形狀內順時針旋轉 3 度：
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

結果如下：
![自訂文字旋轉](custom_text_rotation.png)

## **設定段落的行距**

Aspose.Slides 提供 [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/)、[ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/)、與 [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) 以控制段落間距。這些屬性的使用方式如下：

* 使用正值指定行距為行高的百分比。
* 使用負值以點為單位指定行距。

以下範例將第一段落的內部間距設定為行高的 200%（雙倍行距）：
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

結果如下：
![段落內的行距](line_spacing.png)

## **控制斷行**

段落斷行規則在窄文字區塊與混合拉丁與東亞文字的簡報中相當有用。以下屬性屬於 [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/)，因此適用於整個段落：

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) 控制拉丁文的斷行規則。在混合文字中，變更此設定也可能影響相鄰東亞文字與標點的換行位置。
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) 控制東亞文字的斷行規則，包括字元於行首或行尾的限制。

這些規則不會取代 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)，後者啟用文字框內的自動換行。它們影響換行發生時的版面布局；不會插入換行字元。明確的換行會在段落內強制換行，與可用寬度無關。

以下獨立範例建立一個窄文字區塊，內含中文與拉丁文。它明確設定兩個斷行屬性，並儲存為「line_breaking.pptx」。若要實驗任一規則，只需在保持其他設定不變的情況下變更該屬性的值。範例使用 24 點 Arial 與 SimSun，框寬 160 點，水平文字框邊距為 0。[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) 設為 [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/)，以使文字大小與框尺寸保持固定。
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
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

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

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) 允許符合條件的標點延伸至文字行的右邊緣外，而不是占用下一行。它適用於整段落，且不同於懸掛縮排。

以下獨立範例在寬度 100 點的文字框中啟用懸掛標點，並儲存為「hanging_punctuation.pptx」。使用 24 點 Arial 且水平文字框邊距為 0 時，最終句點會留在「sentence」之後，並延伸至文字右邊緣之外。將屬性設為 [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) 以作比較：在此設定下，句點會佔據獨立行。為了保持可用寬度固定，啟用了換行且停用自動適應。
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

並非所有標點皆可懸掛。可見結果取決於 [字型與版面條件](#control-line-breaking)：變更字型、可用寬度、邊距或自動適應設定皆可能使可見差異消失。

## **設定文字框的自動適應類型**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) 決定文字超出其容器邊界時的行為。可用來控制文字是縮小、溢出，或自動調整形狀大小。以下範例將形狀設定為自動調整以適應文字，並將結果儲存為「autofit_type.pptx」。
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

若要在自動換行後計算行數並查看文字或形狀寬度變化的結果，請參閱 [計算已呈現行數](/slides/zh-hant/python-net/manage-paragraph/)。僅行數不足以判斷文字是否溢出其容器。

## **設定文字框錨點**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) 定義文字在形狀內的垂直定位方式，例如置頂、置中或置底。以下範例將文字錨定於第一個圖形的底部，並將結果儲存為「text_anchor.pptx」。
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **設定文字定位點**

使用 [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) 與 [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) 可在段落中配置定位點。以下範例將預設定位點間距設定為 100 點，並在 30 點處新增左對齊的定位點。這些設定會影響包含定位字符的文字。
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

結果如下：
![段落定位點](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/)，可為文字片段設定校對語言。校對語言決定 PowerPoint 在拼寫與文法檢查時使用的語言。

以下範例需要「presentation.pptx」，其第一張投影片的第一個圖形為文字方塊且至少有一段落。它將第一段落的內容取代為「1。」、將字型設為 SimSun，並指派簡體中文校對語言 (`zh-CN`)。最後將結果儲存為「proofing_language.pptx」：
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

### **複製語言中繼資料**

在從範本複製多語言文字時，請同時保留 [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) 與 [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/)。以下獨立範例建立一個來源片段，其語言為美式英語，備用語言為法語，並將文字與識別碼複製到新簡報中的片段。
```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # 如果來源沒有備用語言，None 會清除目的地的值。
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

若要測試沒有備用語言的來源，請省略對 "fr-FR" 的指派。此時備用識別碼為 `None`，相同的複製語句會保留其缺失，不會引入預設值，即使目標先前已指派備用語言。

這些識別碼屬於語言中繼資料。保留它們不會決定 PowerPoint 用於拼寫或文法檢查的字典。

## **設定預設語言**

使用 [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) 可定義載入或建立簡報時所建立文字的預設語言。以下範例建立一個預設文字語言為美式英語的簡報，新增文字方塊，並列印其第一文字片段的 `en-US`。
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # 新增具有文字的矩形圖形。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # 檢查第一個文字片段的語言。
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用 [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/)。

以下範例將 14 點粗體字型設定為新簡報中頂層段落的預設，並儲存為「default_text_style.pptx」。文字可以繼承這些預設值，除非有更具體的格式覆寫。
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

## **擷取使用全大寫效果的文字**

在 PowerPoint 中，套用 **All Caps** 字型效果會使投影片上的文字以大寫形式顯示，即使實際輸入時為小寫。使用 Aspose.Slides 取得此類文字片段時，函式庫會回傳原始輸入的文字。若要匹配顯示的文字，請檢查 [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/)，當其值為 `ALL` 時，將回傳的字串轉為大寫。

此範例需要「sample2.pptx」，其第一張投影片的第一個圖形為文字方塊。其第一段落的第一片段包含套用全大寫效果的 "Hello, Aspose!"，如下圖所示。
![全大寫效果](all_caps_effect.png)

以下程式碼範例示範如何擷取套用 **All Caps** 效果的文字：
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

## **FAQ**

**如何在投影片的表格中修改文字？**

若要在投影片的表格中修改文字，請使用 [表格](https://reference.aspose.com/slides/python-net/aspose.slides/table/)。迭代儲存格，並透過 [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) 以及 [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) 更新每個儲存格的文字與段落格式。

**如何在 PowerPoint 投影片的文字上套用漸層顏色？**

若要為文字套用漸層顏色，請使用 [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/)。將 [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 設為 [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)，並配置漸層停止點、方向與透明度。

相關功能：[在投影片中格式化文字](/slides/zh-hant/features/text-formatting/)