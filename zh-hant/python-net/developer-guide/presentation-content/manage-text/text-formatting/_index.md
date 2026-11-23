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
description: "使用 Aspose.Slides for Python via .NET 對 PowerPoint 與 OpenDocument 簡報中的文字進行格式化與樣式設定。自訂字型、顏色、對齊方式等。"
---
## **概覽**

本文說明如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中格式化文字。內容涵蓋背景色、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨點、定位點以及語言設定。

除非另有說明，範例皆使用 [sample.pptx](sample.pptx)。第一張投影片的第一個圖形是一個文字方塊，且第一段落包含下方顯示的文字。投影片與圖形索引均為零基。選取粗體部分的範例使用有效格式，包含繼承的粗體格式：

![範例文字](sample_text.png)

若要搜尋並標示文字字面值或正規表達式匹配項目，請參閱 [搜尋與取代文字](/slides/zh-hant/python-net/search-and-replace-text/)。

## **設定文字背景顏色**

使用 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) 來設定段落的預設突顯顏色，或使用 [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) 針對個別文字片段設定。

下列範例將第一段落的預設突顯設定為淡灰色。個別文字片段上的明確突顯顏色會優先於此預設值：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 為整段落設定突顯顏色。
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼示範如何為 **粗體字型的文字片段** 設定背景顏色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

使用 [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 來設定文字框內段落的對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

下列程式碼示範如何將段落對齊至 **置中**：

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

![已對齊的段落](aligned_paragraph.png)

## **在同一行內對齊字型**

使用 [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) 可在同一行內垂直對齊不同字型大小的文字片段。此設定會套用於整個段落，並控制每一行之內的對齊。

下列獨立範例會在同一張投影片上建立四個標有文字方塊的物件。每個段落以 18、36、54 點字型顯示相同文字，且使用不同的字型對齊方式。範例使用 Arial，停用自動調整與換行，並確保文字框足夠容納單行文字。

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

結果：

![Baseline、Top、Center、Bottom 字型對齊比較（混合字型大小）](font_alignment.png)

字型對齊使用字型度量，因此個別字母的可見邊緣不一定完全對齊。範例同時包含大寫字母與下伸字元，以說明基線與底部對齊的差異。字型可用性與替代、使用的字元以及字型大小差異皆會影響結果。框架尺寸、邊距、行距、換行與自動調整亦會影響版面；比較模式時請使用相同字型與版面設定。

此設定不同於 [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/)，後者控制水平段落對齊；也不同於 [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/)，後者在形狀內垂直定位文字區塊。透過 [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) 進行的上標與下標格式會相對於基線移動單一文字片段，而非設定段落行的字型對齊。

## **設定文字透明度**

文字透明度是透過指派給 [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) 的顏色之 alpha 成分來控制。在以下範例中，`alpha = 50` 為 0–255 之間的 ARGB alpha 通道值，而非透明度百分比。

下列程式碼示範如何對 **整段落** 套用透明度：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 為文字設定半透明的黑色填充。
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![透明段落](transparent_paragraph.png)

以下程式碼示範如何對 **粗體字型的文字片段** 套用透明度：

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

結果：

![透明文字片段](transparent_text_portions.png)

## **設定文字字元間距**

使用 [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) 可在文字方塊內擴大或壓縮字元間距。以下範例加入 3 點間距；負值則會壓縮文字。

下列 Python 程式碼示範如何在 **整段落** 中擴大字元間距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 注意：使用負值可壓縮字元間距。
    paragraph.paragraph_format.default_portion_format.spacing = 3  # 擴展字元間距。

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼示範如何在 **粗體字型的文字片段** 中擴大字元間距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 注意：使用負值可壓縮字元間距。
            portion.portion_format.spacing = 3  # 擴展字元間距。

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

結果：

![文字片段中的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距調整（Kerning）**

在某些情況下，Aspose.Slides 渲染的文字可能比 PowerPoint 中的顯示稍微緊密。這可能是因為 PowerPoint 會忽略某些字型的字距資料，即使該字型包含有效的字距資訊且 PowerPoint 設定已啟用字距。

若要使渲染結果更貼近 PowerPoint，可對使用受影響字型的文字片段停用字距調整。將 [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) 設為大於實際字型大小的值。此範例需要「presentation.pptx」，其第一張投影片的第一個圖形為文字方塊。它會檢查有效字型名稱（包括繼承字型），並對使用 Roboto 且字型大小低於 100 點的片段設定 100 點的門檻，以停用字距調整：

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

對於低於門檻的匹配文字，此設定會阻止字距調整，從而協助 Aspose.Slides 的渲染與 PowerPoint 在受此 PowerPoint 特定行為影響的字型的視覺輸出更為一致。

## **管理文字字型屬性**

字型屬性可透過 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) 在段落層級設定，或透過 [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) 在個別片段設定。

下列範例將第一段落的預設字型設定為 12 點 Times New Roman，並套用粗體、斜體與點狀底線。個別片段的明確格式會優先於這些預設值：

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

下列範例對有效格式為粗體的片段套用 13 點 Times New Roman、斜體與點狀底線：

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

結果：

![文字片段的字型屬性](font_properties_for_text_portions.png)

## **控制文字高度正規化**

在重製範本排版或研究字元高度差異時，可使用 [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/)。在 PowerPoint 中，啟用正規化會垂直拉伸或壓縮個別字元，使其在文字片段內具有統一的可見高度。此設定不保證不同字型之間的文字高度相等。

將屬性設定為 [NullableBool.TRUE 或 FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) 以明確啟用或停用正規化。`NullableBool.NOT_DEFINED` 會保留本地設定未設定，讓片段繼承段落的 [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) 等值。這並不等同於 `False`。可使用 [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) 並讀取 [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) 取得解析後的布林值。

以下獨立範例需要安裝 **Arial**。它會建立兩個文字區塊，包含相同的大寫字母、小寫字母、下伸字元與重音字元，字型大小為 54 點。兩段落預設皆啟用正規化；上方片段明確停用，下方片段則繼承設定。框架尺寸、邊距與段落間距相同，且停用換行與自動調整以保持比較一致。範例會輸出 `FALSE: False` 與 `NOT_DEFINED: True`，然後儲存為「text_height_normalization.pptx」。

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

下圖取自已儲存的簡報。上排正規化已停用 (`FALSE`)；下排則繼承啟用設定 (`NOT_DEFINED` → `True`)。請保留 Arial 安裝以重現此外觀。

![Arial 54 點文字，上方停用正規化、下方繼承啟用正規化](text_height_normalization.png)

正規化在不改變指派的 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) 值（即字型大小）的前提下調整字元高度。段落的 [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) 控制行距，而文字框的 [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) 控制文字或容器的自動調整方式。這些設定各自服務不同目的，且可獨立影響整體版面。欲深入了解段落格式與繼承，請參閱 [管理段落](/slides/zh-hant/python-net/manage-paragraph/)。

## **套用與移除刪除線**

使用 [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) 可在文字片段上顯示修正、取消的字詞或先前價格，而不必刪除原始文字。將其設定為 [TextStrikethroughType.SINGLE 或 DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) 可在文字上加上一條或兩條線。

若要移除刪除線，請指派 `TextStrikethroughType.NONE`。此設定會明確停用效果，即使周圍的格式指定了刪除線。相較之下，`TextStrikethroughType.NOT_DEFINED` 會保留本地設定未定義，讓片段繼承段落等處的格式，並不保證刪除線被移除。可使用 [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) 讀取最終格式，包括繼承值。

下列獨立範例建立三個價格比較。每段落都分別包含標籤、原價與現價的片段，僅原價會受影響。第一排套用後再移除刪除線；其餘列則保留單線與雙線刪除線。變更此屬性可保留文字及其他格式，包括粗體的原價。

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

    # 套用刪除線，然後明確地從第一個原價中移除它。
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

結果（由上至下）：無刪除線、單線刪除線、雙線刪除線。

![無刪除線、單線刪除線與雙線刪除線的前價格比較](strikethrough.png)

## **設定文字旋轉**

使用 [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) 可在形狀內設定預定義的文字方向。

下列程式碼將形狀內的文字方向設定為 [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/)，使文字 **逆時針旋轉 90 度**：

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

## **在直排文字中並排顯示數字**

為了在直排日文標籤中將兩位數字保持在一起，請將兩個數字放在同一文字片段，並在該片段上設定 [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/)。範例建立兩個標籤，使用 [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) 與 40 點 MS Gothic。唯一差異在於指派給數字片段的 [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) 值。

```python
import aspose.slides as slides


def add_label(slide, x, kumimoji):
    label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 48, 120, 420)
    label.fill_format.fill_type = slides.FillType.NO_FILL
    label.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    frame = label.add_text_frame("")
    frame.text_frame_format.text_vertical_type = slides.TextVerticalType.EAST_ASIAN_VERTICAL

    paragraph = frame.paragraphs[0]
    portion_format = paragraph.paragraph_format.default_portion_format
    font = slides.FontData("MS Gothic")
    portion_format.latin_font = font
    portion_format.east_asian_font = font
    portion_format.font_height = 40
    portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion_format.fill_format.solid_fill_color.color = "black"

    digits = slides.Portion("12")
    digits.portion_format.kumimoji = kumimoji

    paragraph.portions.clear()
    paragraph.portions.add(slides.Portion("令和"))
    paragraph.portions.add(digits)
    paragraph.portions.add(slides.Portion("年"))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    add_label(slide, 120, slides.NullableBool.TRUE)
    add_label(slide, 360, slides.NullableBool.FALSE)
    
    presentation.save("vertical_date.pptx", slides.export.SaveFormat.PPTX)
```

在 PowerPoint 中，左側標籤（`TRUE`）會使數字直立並與「和」與「年」之間並排顯示。右側標籤（`FALSE`）則會將數字順時針旋轉 90 度。兩標籤的周圍日文字元皆保持直立。

![PowerPoint 中直排日期標籤的比較：左側直立數字、右側旋轉數字](vertical_date.png)

## **自訂文字框旋轉角度**

使用 [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) 可為 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 設定自訂旋轉角度。

以下程式碼在形狀內將文字框順時針旋轉 3 度：

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

## **設定段落行距**

Aspose.Slides 提供 [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/)、[ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/)、[ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) 以控制段落間距。這些屬性的使用方式如下：

* 正值表示以行高的百分比指定行距。
* 負值表示以點數指定行距。

下列範例將第一段落的內部間距設定為行高的 200%（雙倍行距）：

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

## **控制斷行規則**

段落的斷行規則在窄文字區塊與混合拉丁與東亞文字的簡報中相當實用。以下屬性屬於 [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/)，會套用於整個段落：

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) 控制拉丁文字的斷行規則。於混合文字中，調整此屬性亦可能影響相鄰東亞文字與標點的換行位置。
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) 控制東亞文字的斷行規則，包括行首與行尾字符的限制。

這些規則不會取代 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)，後者啟用文字框內的自動換行。它們僅在換行發生時影響版面配置；不會插入斷行字元。顯式的斷行會強制段落內產生新行，與可用寬度無關。

以下獨立範例建立包含中文與拉丁文字的窄文字區塊。它會明確設定兩個斷行屬性，並儲存為「line_breaking.pptx」。若要實驗任一規則，只需在保持另一設定不變的情況下變更該屬性值。範例使用 24 點 Arial 與 SimSun，框寬 160 點，水平文字框邊距為 0。[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) 設為 [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/)，以固定文字大小與框架尺寸。

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

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) 允許符合條件的標點超出文字行的右邊緣，而不是佔用下一行。它套用於整個段落，與懸掛縮排不同。

以下獨立範例在寬度為 100 點的文字框中啟用懸掛標點，並儲存為「hanging_punctuation.pptx」。使用 24 點 Arial 與水平文字框邊距為 0，最終的句點會留在「sentence」之後，並超出右側文字邊緣。若將屬性設為 [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/)，則句點會佔據獨立一行。此範例啟用換行且停用自動調整，以保持可用寬度固定。

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

不是所有標點皆能懸掛。可見結果取決於 [字型與版面條件](#control-line-breaking)：變更字型、可用寬度、邊距或自動調整設定皆可能取消可見差異。

## **設定文字框的自動調整類型**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) 決定文字超出容器邊界時的行為。使用它可控制文字是縮小、溢出，或自動調整形狀尺寸。以下範例將形狀設定為依文字自動調整大小，並儲存結果為「autofit_type.pptx」。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

若要在自動換行後計算行數並觀察文字或形狀寬度的變化，請參閱 [計算已渲染行](/slides/zh-hant/python-net/manage-paragraph/)。僅有行數並不表示文字是否溢出容器。

## **設定文字框錨點**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) 定義文字在形狀內的垂直定位方式，例如置頂、置中或置底。以下範例將文字錨點設定於第一個圖形的底部，並將結果儲存為「text_anchor.pptx」。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **設定文字定位點（Tabs）**

使用 [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) 與 [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) 來設定段落的定位點。下列範例將預設定位點間距設定為 100 點，並在 30 點處加入左對齊的定位點。此設定會影響含有定位字元的文字。

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

Aspose.Slides 提供 [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/)，可為文字片段設定校對語言。校對語言決定 PowerPoint 進行拼寫與文法檢查時使用的語言。

以下範例需要「presentation.pptx」，其第一張投影片的第一個圖形為文字方塊且至少包含一個段落。它會將第一段落的內容取代為「1。」、將字型設定為 SimSun，並指派簡體中文校對語言 (`zh-CN`)。最後將結果儲存為「proofing_language.pptx」：

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

在從範本複製多語言文字時，請同時保留 [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) 與 [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/)。以下獨立範例會建立一個來源片段，其語言為美式英語，替代語言為法語，然後將文字與識別碼複製到新簡報中的片段。

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
    # 如果來源沒有替代語言，None 會清除目的地的值。
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

若要測試沒有替代語言的來源，只需省略對 `"fr-FR"` 的指派。此時替代識別碼為 `None`，相同的複製語句會保留其缺失，而不會插入預設值，即使目的地先前已指派過替代語言。

這些識別碼屬於語言中繼資料。保留它們不會決定 PowerPoint 選擇哪個字典進行拼寫或文法檢查。

## **設定預設語言**

使用 [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) 可定義在載入或建立簡報時所產生文字的預設語言。以下範例建立一個簡報，預設文字語言為美式英語，加入文字方塊，並印出其第一文字片段的語言 `en-US`。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # 新增一個帶文字的矩形形狀。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # 檢查第一個文字片段的語言。
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用 [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/)。

以下範例將新簡報的頂層段落預設為 14 點粗體字型，並將其儲存為「default_text_style.pptx」。文字會繼承這些預設，除非更具體的格式覆寫它們。

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

## **擷取具有全大寫效果的文字**

在 PowerPoint 中，套用 **全大寫** 字型效果會使文字在投影片上以大寫顯示，即使實際輸入的是小寫。使用 Aspose.Slides 取得此類文字片段時，函式庫會回傳原始輸入的文字。若要與顯示的文字一致，請檢查 [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) 並在值為 `ALL` 時將回傳的字串轉為大寫。

此範例需要「sample2.pptx」，其第一張投影片的第一個圖形為文字方塊，且第一段落的第一片段包含套用全大寫效果的「Hello, Aspose!」，如圖所示。

![全大寫效果](all_caps_effect.png)

以下程式碼示範如何擷取已套用 **全大寫** 效果的文字：

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

**如何修改投影片上表格中的文字？**

請使用 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)。遍歷儲存格，並透過 [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) 更新每個儲存格，並使用 [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) 調整段落格式。

**如何在 PowerPoint 投影片的文字上套用漸層顏色？**

請使用 [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/)。將 [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 設為 [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)，並配置漸層停點、方向與透明度。

相關功能：[格式化投影片內文字](/slides/zh-hant/features/text-formatting/).