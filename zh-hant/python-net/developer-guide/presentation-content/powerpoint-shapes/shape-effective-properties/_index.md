---
title: 取得 Python 中簡報的圖形有效屬性
linktitle: 有效屬性
type: docs
weight: 50
url: /zh-hant/python-net/shape-effective-properties/
keywords:
- 圖形屬性
- 相機屬性
- 燈光裝置
- 斜角圖形
- 文字框
- 文字樣式
- 字型高度
- 填充格式
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 簡報中區分圖形的本地、繼承與有效格式設定。"
---
## **了解本地、繼承與有效屬性**

PowerPoint 的格式設定可能來自多個來源。直接儲存在物件上的值稱為 **本地值**。如果該值未設定，PowerPoint 會查閱父層的格式來源，例如段落預設、文字樣式、版面或母片投影片、佈景主題或簡報層級的預設。這些值稱為 **繼承值**。在整個層級解析完畢後剩餘的值稱為 **有效值**，它將用來呈現物件。

例如，文字段落可能未定義自己的字型高度。其本地 [font_height](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ibaseportionformat/font_height/) 為 `float("nan")`，表示「此處未設定」。該段落可以從其段落、簡報的預設文字樣式或其他適用來源繼承高度。對段落格式呼叫 [get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iportionformat/get_effective/) 會回傳最終解析的高度。

針對不同需求使用這兩種格式資料：

- 讀取或變更本地格式物件（例如 [IPortionFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iportionformat/)），當您需要控制值的定義位置時。
- 讀取有效資料物件（例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iportionformateffectivedata/)），當您需要最終的渲染結果時。有效資料是唯讀的。

## **比較本地、繼承與有效值**

以下完整範例建立一個圖形，並在簡報、段落與段落層級套用字型高度。每一步都會列印該層級定義的值以及相同文字段落的最終有效值。此範例同時說明為何在格式變更後必須重新讀取有效資料。

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # 讀取先前變更後的有效資料。
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # 定義兩個不同層級的繼承值。
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # 段落的本地值會覆寫兩個繼承值。
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # 更改繼承值不會覆寫現有的本地值。
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # 清除本地值。此文字段現在再次從段落繼承。
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # 清除段落值。簡報預設現在提供結果。
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

此範例的優先順序為段落本地格式、接著段落格式、最後為簡報預設。其他物件可能有不同的繼承鏈，但原則相同：較具體的明確值會優先，且 [get_effective](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iportionformat/get_effective/) 會回傳最終結果。

## **取得有效文字屬性**

文字格式被分散在多個物件中：

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/itextframeformat/get_effective/) 會解析文字框屬性，例如邊距、錨點、自動調整以及垂直文字方向。
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/itextstyle/get_effective/) 會解析每個文字樣式層級的段落格式。
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iparagraphformat/get_effective/) 會解析段落屬性，例如對齊、縮排與項目符號。
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/iportionformat/get_effective/) 會解析字元屬性，例如字型高度、字型、顏色、粗體與斜體。

在下一個範例中，`text-formatting.pptx` 必須至少包含一張投影片與一個含有非空文字框的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/autoshape/)。AutoShape 可以位於圖形集合中的任何位置；程式碼會搜尋適當的物件並在使用前進行驗證。

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **取得有效 3D 屬性**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ithreedformat/get_effective/) 會回傳一個 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ithreedformateffectivedata/) 物件，該物件彙總所有已解析的 3D 設定。其 [camera](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ithreedformateffectivedata/camera/)、[light_rig](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ithreedformateffectivedata/light_rig/)、[bevel_top](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/) 以及 [bevel_bottom](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) 屬性會揭示相對應的有效資料。將這些相關設定一起讀取，可更容易了解圖形最終的 3D 外觀。

在此範例中，`shape-3d.pptx` 必須在第一張投影片上至少包含一個圖形。若希望輸出包含非預設值，請對該圖形套用 3D 相機、照明或斜角設定。

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **取得有效表格格式化**

表格格式化可能來自表格樣式，也可能來自套用於整個表格、欄、列或單一儲存格的格式。當明確定義的填充發生衝突時，優先順序為儲存格、列、欄，最後是整個表格。儲存格的有效格式即繪製該儲存格時使用的最終格式。

在此範例中，`table-formatting.pptx` 必須在第一張投影片上至少包含一個表格。該表格必須至少有一列與一欄。程式碼會搜尋 [Table](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/table/)，而不是直接假設 `shapes[0]` 為表格。

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

如果需要取得顏色而不僅是填充類型，請先檢查有效的 [fill_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ifillformateffectivedata/fill_type/)，然後讀取對應於該類型的屬性，例如實心填充的 [solid_fill_color](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/)。

## **變更後重新讀取有效資料**

有效資料描述解析時的格式層級。變更任何可能參與該層級的項目後，請再次呼叫 `get_effective`，包括：

- 物件的本地格式；
- 段落或文字框的預設值；
- 表格樣式、表格、欄、列或儲存格的格式；
- 版面或母片投影片的格式；
- 主題資料或簡報層級的預設值；
- 分配給投影片的版面或母片。

不要將有效資料物件作為永久快照保存。Aspose.Slides 可能在內部快取部分有效資料，稍後的 `get_effective` 呼叫會刷新這些資料。如果需要比較變更前後的值，請在變更前將所需的純量值（例如字型高度、顏色、對齊或斜角寬度）複製到自己的變數中。

若要變更值，請更新相對應的本地格式物件，然後呼叫 `get_effective` 以驗證結果。有效資料物件本身是唯讀的。

## **常見問題**

**我如何判斷是哪個層級提供了有效值？**

有效資料只包含最終值，而不包含其來源。請從最具體的層級向外檢查相關的本地物件。對於文字而言，可能包括段落、段落、文字框、版面、母片、主題與簡報預設。未定義的值（如 `float("nan")` 或 `None`）表示搜尋會繼續至更高層級。

**當沒有任何層級定義屬性時會發生什麼？**

Aspose.Slides 會解析相應的 PowerPoint 或程式庫預設值。即使沒有本地物件明確定義，該解析出的值仍會出現在有效資料中。

**為何有時有效值等於本地值？**

本地值在繼承計算中獲勝。當屬性在物件上被明確設定且沒有更具體的規則覆蓋時，這是預期的結果。

**什麼時候應使用本地資料而非有效資料？**

在檢查或編輯特定格式層級時使用本地資料。當您需要在繼承、主題規則與適用樣式解析後的最終外觀時，使用有效資料。[完整比較範例](#compare-local-inherited-and-effective-values) 在同一工作流程中展示了兩者的使用方式。