---
title: 使用 Python 從簡報中取得形狀的有效屬性
linktitle: 有效屬性
type: docs
weight: 50
url: /zh-hant/python-net/shape-effective-properties/
keywords:
- 形狀屬性
- 相機屬性
- 光源裝置
- 斜角形狀
- 文字框
- 文字樣式
- 字型高度
- 填充格式
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "探索 Aspose.Slides for Python via .NET 如何計算與套用形狀的有效屬性，以實現精確的 PowerPoint 呈現。"
---
## **概述**

本主題說明 **本機** 與 **有效** 屬性之間的差異。本機值是直接在特定格式層級上設定的值，例如：

1. 投影片上的段落屬性。
1. 版面或母片投影片上，當段落的文字框形狀具有文字樣式時的原型形狀文字樣式。
1. 簡報中的全域文字設定。

本機值可以在任何層級上定義或省略。當 Aspose.Slides 需要最終「實際呈現」的格式時，會解析繼承鏈並回傳 **有效** 值。您可以透過呼叫本機格式物件的 `get_effective` 方法取得它們。

以下範例說明如何取得有效值。範例假設第一張投影片的第一個形狀是一個具有文字框且至少包含一個段落的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}

有效格式資料代表在套用繼承後目前計算出的格式。在目前的實作中，某些有效資料物件（例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iportionformateffectivedata/)）可能會在內部快取。變更父層或繼承格式後再次呼叫 `get_effective` 可重新整理快取的資料，先前取得的物件可能不再代表先前的狀態。若需要保留有效值以供日後使用，請將所需的屬性（例如字型高度、填色、字型樣式或對齊方式）複製到您自己的資料物件中。

{{% /alert %}}

## **取得相機的有效屬性**

Aspose.Slides 允許您取得相機的有效屬性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/icameraeffectivedata/) 類型代表一個不可變的物件，內含有效的相機屬性。透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ithreedformateffectivedata/) 可取得 [ICameraEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/icameraeffectivedata/) 實例，進而提供 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/) 的有效值。

以下程式碼範例示範如何取得相機的有效屬性。範例假設第一張投影片的第一個形狀具有 3D 格式。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **取得光源裝置的有效屬性**

Aspose.Slides 允許您取得光源裝置的有效屬性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ilightrigeffectivedata/) 類型代表一個不可變的物件，內含有效的光源裝置屬性。透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ithreedformateffectivedata/) 可取得 [ILightRigEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ilightrigeffectivedata/) 實例，進而提供 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/) 的有效值。

以下程式碼範例示範如何取得光源裝置的有效屬性。範例假設第一張投影片的第一個形狀具有 3D 格式。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **取得形狀斜角的有效屬性**

Aspose.Slides 允許您取得形狀斜角的有效屬性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ishapebeveleffectivedata/) 類型代表一個不可變的物件，內含形狀面部凹凸的有效屬性。透過 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ithreedformateffectivedata/) 可取得 [IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ishapebeveleffectivedata/) 實例，進而提供 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/threedformat/) 的有效值。

以下程式碼範例示範如何取得形狀上方斜角的有效屬性。範例假設第一張投影片的第一個形狀具有 3D 格式。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **取得文字框的有效屬性**

使用 Aspose.Slides，您可以取得文字框的有效屬性。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/itextframeformateffectivedata/) 類型包含有效的文字框格式屬性。

以下程式碼範例示範如何取得文字框的有效格式屬性。範例假設第一張投影片的第一個形狀是一個具有文字框的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **取得文字樣式的有效屬性**

使用 Aspose.Slides，您可以取得文字樣式的有效屬性。[ITextStyleEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/itextstyleeffectivedata/) 類型包含有效的文字樣式屬性。

以下程式碼範例示範如何取得文字樣式的有效屬性。範例假設第一張投影片的第一個形狀是一個具有文字框的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **取得有效的字型高度值**

使用 Aspose.Slides，您可以取得有效的字型高度。以下程式碼示範在簡報結構的不同層級設定本機字型高度後，段落的有效字型高度如何變化。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **取得表格的有效填充格式**

使用 Aspose.Slides，您可以取得不同表格部分的有效填充格式。[IFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ifillformateffectivedata/) 類型包含有效的填充格式屬性。儲存格格式的優先順序高於列格式，列格式高於欄格式，欄格式高於整表格式。

因此，會使用 [ICellFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/icellformateffectivedata/) 屬性來繪製表格儲存格。以下程式碼範例示範如何取得不同表格部分的有效填充格式。範例假設第一張投影片的第一個形狀是一個 [Table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/)。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **常見問題集**

**`get_effective` 會回傳快照嗎？**

不一定。有效資料代表套用繼承後計算出的格式，但某些有效資料物件可能在內部被快取。之後再呼叫 `get_effective` 可能會重新計算格式並刷新快取資料，因此先前取得的物件不應被視為永久快照。

**什麼時候需要重新讀取有效屬性？**

在變更本機格式、父樣式、版面格式、母片格式或簡報層級的預設值後，請再次呼叫 `get_effective`。下一次呼叫會重新評估格式層級，並回傳當前的有效結果。

**變更或移除版面/母片投影片會影響已取得的有效屬性嗎？**

會，變更會在下一次 `get_effective` 呼叫時反映出來。如果父層格式來源被變更或移除，先前取得的有效資料可能已過時。再次呼叫 `get_effective` 後，Aspose.Slides 會重新評估格式樹，字型、顏色、大小或其他值可能隨之變化。

**我可以透過有效資料物件修改值嗎？**

不能。有效資料物件只會暴露計算後的值。請在本機格式物件上進行變更，然後再次取得有效值。

**如果在形狀層級、版面/母片、全域設定中都未設定某屬性，會發生什麼？**

有效值會由預設機制決定，包含 PowerPoint 以及 Aspose.Slides 的預設值。解析出的值會成為目前有效資料的一部份。

**從有效的字型值，我可以判斷是哪個層級提供了尺寸或字型嗎？**

無法直接判斷。有效資料只回傳最終值。若要找出來源，請檢查段落、文字框、文字樣式在段落、版面、母片和簡報層級的本機值，找出第一個明確定義的地方。

**為什麼有效值有時看起來與本機值相同？**

因為本機值已成為最終值（不需要更高層級的繼承）。在此情況下，有效值與本機值相同。

**什麼時候應使用有效屬性，什麼時候只使用本機屬性？**

當您需要在套用所有繼承後的「實際呈現」結果時（例如對齊顏色、縮排或大小），請使用有效資料。如果您需要在稍後的格式變更中保留這些值，請將所需屬性複製到自己的物件中。若您需要在特定層級變更格式，請修改本機屬性，然後在需要時再次讀取有效資料以驗證結果。