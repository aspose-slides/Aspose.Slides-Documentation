---
title: 從 Python (透過 Java) 取得投影片中圖形的有效屬性
linktitle: 有效屬性
type: docs
weight: 50
url: /zh-hant/python-java/shape-effective-properties/
keywords:
- 圖形屬性
- 相機屬性
- 光源裝置
- 斜角圖形
- 文字框
- 文字樣式
- 字型高度
- 填充格式
- PowerPoint
- 投影片
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 來區分 PowerPoint 投影片中圖形的本地、繼承與有效格式設定。"
---
## **了解本地、繼承和有效屬性**

PowerPoint 的格式設定可能來自多個來源。直接儲存在物件上的值稱為 **本地值**。如果該值未設定，PowerPoint 會檢查父層的格式來源，例如段落預設、文字樣式、版面配置或母片投影片、佈景主題、或簡報層級的預設。這些值稱為 **繼承值**。在整個層級解析完畢後留下的值即為 **有效值**——用於呈現物件的值。

例如，文字段落可能未定義自己的字型高度。其本地 [getFontHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#getFontHeight) 值將為 `float("nan")`，表示「此處未設定」。該段落可以從其段落、簡報的預設文字樣式或其他適用來源繼承高度。對段落格式呼叫 [getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/#getEffective) 會回傳最終解析出的高度。

使用這兩種格式資料以達成不同目的：

- 讀取或變更本地格式物件，例如 [PortionFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/) ，當您需要控制值定義的位置時。  
- 讀取有效資料物件，例如 `PortionFormatEffectiveData`，當您需要最終呈現的結果。有效資料為唯讀。

## **比較本地、繼承與有效值**

以下完整範例建立一個圖形，並在簡報、段落和段落層級套用字型高度。每個步驟都會印出在這些層級定義的值以及同一文字段落的最終有效值。它亦示範了為何在格式變更後必須再次讀取有效資料。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # 在先前的變更之後讀取有效資料。
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # 在兩個不同層級定義繼承值。
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # 段落的本地值會覆蓋兩個繼承值。
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # 變更繼承值不會覆蓋已存在的本地值。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # 清除本地值。段落現在再次從段落繼承。
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # 清除段落值。現在簡報預設提供結果。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此範例的優先順序為段落本地格式、接著段落格式、最後是簡報預設。其他物件可能有不同的繼承鏈，但原則相同：較具體的明確值會取得優先權，而 [getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/#getEffective) 會回傳最終結果。

## **取得有效的文字屬性**

文字格式分散在多個物件中：

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textframeformat/#getEffective) 解析文字框屬性，例如邊距、錨點、自動調整以及垂直文字方向。  
- [TextStyle.getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/textstyle/#getEffective) 解析每個文字樣式層級的段落格式。  
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraphformat/#getEffective) 解析段落屬性，例如對齊、縮排與項目符號。  
- [PortionFormat.getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/#getEffective) 解析字元屬性，例如字型高度、字型、顏色、粗體和斜體。

對於下一個範例，`text-formatting.pptx` 必須至少包含一張投影片以及一個具有非空文字框的 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/)。AutoShape 可以出現在圖形集合的任意位置；程式碼會搜尋符合條件的物件並在使用前驗證它。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **取得有效的 3D 屬性**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/threedformat/#getEffective) 回傳一個 `ThreeDFormatEffectiveData` 物件，將所有已解析的 3D 設定彙總。其 `getCamera`、`getLightRig`、`getBevelTop` 與 `getBevelBottom` 方法會公開相對應的有效資料。一起讀取這些相關設定可以更容易了解圖形最終的 3D 外觀。

此範例中，`shape-3d.pptx` 必須在第一張投影片上至少包含一個圖形。如果您希望輸出包含非預設值，請對該圖形套用 3D 相機、光源或斜角設定。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **取得有效的表格格式設定**

表格格式可能來源於表格樣式，也可能來源於套用於整張表格、欄、列或單一儲存格的格式。若明確定義的填滿發生衝突，優先順序為儲存格、列、欄，最後是整張表格。儲存格的有效格式即為繪製該儲存格所使用的最終格式。

此範例中，`table-formatting.pptx` 必須在第一張投影片上至少包含一個表格。該表格必須至少有一列和一欄。程式碼會搜尋 [Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/) 而不是假設 `getShapes().get_Item(0)` 為表格。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

如果您需要顏色而不只是填滿類型，請先檢查有效的 `getFillType`，然後讀取對應類型的方法——例如，對於實心填滿使用 `getSolidFillColor`。

## **變更後重新讀取有效資料**

有效資料描述了在解析時的格式層級結構。變更任何可能參與該層級的項目後，請再次呼叫 [getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/#getEffective) 。包括：

- 物件的本地格式；
- 段落或文字框的預設值；
- 表格樣式、表格、欄、列或儲存格的格式；
- 版面配置或母片投影片的格式；
- 佈景主題資料或簡報層級的預設值；
- 指派給投影片的版面配置或母片。

請勿將有效資料物件作為永久快照保存。Aspose.Slides 可能會在內部快取部分有效資料，稍後呼叫 [getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/#getEffective) 可以刷新該資料。若需比較變更前後的值，請在變更前將所需的純量值（例如字型高度、顏色、對齊或斜角寬度）複製到自己的變數中。

若要變更值，請更新相應的本地格式物件，然後呼叫 [getEffective](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/portionformat/#getEffective) 以驗證結果。有效資料物件本身是唯讀的。

## **常見問題**

**如何判斷是哪個層級提供了有效值？**

有效資料僅包含最終值，並未指示其來源。請從最具體的層級往外檢查相關的本地物件。對於文字，可能包括段落、段落、文字框、版面配置、母片、主題與簡報預設。未定義的值，如 `float("nan")` 或 `None`，表示搜尋會繼續到其他層級。

**當沒有任何層級定義屬性時會發生什麼情況？**

Aspose.Slides 會解析適當的 PowerPoint 或函式庫預設值。即使沒有本地物件明確定義，該解析後的值仍會出現在有效資料中。

**為什麼有效值有時會等於本地值？**

本地值在繼承計算中取得優先。當屬性在物件上明確設定且沒有更具體的規則覆寫時，就會出現此情況。

**何時應使用本地資料而非有效資料？**

使用本地資料以檢查或編輯特定的格式層級。當您需要在繼承、主題規則與相關樣式解析後的最終外觀時，請使用有效資料。[完整比較範例](#compare-local-inherited-and-effective-values) 在同一工作流程中示範兩者。