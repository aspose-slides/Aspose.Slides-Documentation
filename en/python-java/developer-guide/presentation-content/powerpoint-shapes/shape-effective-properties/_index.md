---
title: Get Shape Effective Properties from Presentations in Python via Java
linktitle: Effective Properties
type: docs
weight: 50
url: /python-java/shape-effective-properties/
keywords:
- shape properties
- camera properties
- light rig
- bevel shape
- text frame
- text style
- font height
- fill format
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Learn how to use Aspose.Slides for Python via Java to distinguish local, inherited, and effective shape formatting in PowerPoint presentations."
---

## **Understand Local, Inherited, and Effective Properties**

PowerPoint formatting can come from several places. The value stored directly on an object is its **local value**. If that value is not set, PowerPoint looks at parent formatting sources, such as a paragraph default, a text style, a layout or master slide, a theme, or presentation-level defaults. Those values are **inherited values**. The value that remains after the entire hierarchy is resolved is the **effective value**—the value used to render the object.

For example, a text portion may not define its own font height. Its local [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight) value is then `float("nan")`, which means "not set here." The portion can inherit a height from its paragraph, the presentation's default text style, or another applicable source. Calling [getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) on the portion format returns the final resolved height.

Use the two kinds of formatting data for different purposes:

- Read or change a local format object, such as [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/), when you need to control where a value is defined.
- Read an effective data object, such as `PortionFormatEffectiveData`, when you need the final, rendered result. Effective data is read-only.

## **Compare Local, Inherited, and Effective Values**

The following complete example creates a shape and applies font heights at the presentation, paragraph, and portion levels. Each step prints the values defined at those levels and the resulting effective value for the same text portion. It also demonstrates why effective data must be read again after formatting changes.

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

    # Read effective data after the preceding changes.
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

    # Define inherited values at two different levels.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # A local value on the portion overrides both inherited values.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Changing an inherited value does not override an existing local value.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Clear the local value. The portion now inherits from the paragraph again.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Clear the paragraph value. The presentation default now supplies the result.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The priority in this example is portion local formatting, then paragraph formatting, then the presentation default. Other objects can have different inheritance chains, but the principle is the same: a more specific explicit value wins, and [getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) returns the final result.

## **Get Effective Text Properties**

Text formatting is split across several objects:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective) resolves text-frame properties such as margins, anchoring, autofit, and vertical text direction.
- [TextStyle.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textstyle/#getEffective) resolves paragraph formatting for each text style level.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective) resolves paragraph properties such as alignment, indentation, and bullets.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) resolves character properties such as font height, typeface, color, bold, and italic.

For the next example, `text-formatting.pptx` must contain at least one slide and one [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) with a non-empty text frame. The AutoShape can appear at any position in the shape collection; the code searches for a suitable object and validates it before use.

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

## **Get Effective 3D Properties**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getEffective) returns one `ThreeDFormatEffectiveData` object that groups all resolved 3D settings. Its `getCamera`, `getLightRig`, `getBevelTop`, and `getBevelBottom` methods expose the corresponding effective data. Reading these related settings together makes it easier to understand the final 3D appearance of a shape.

For this example, `shape-3d.pptx` must contain at least one shape on its first slide. Apply 3D camera, lighting, or bevel settings to that shape if you want the output to contain values other than the defaults.

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

## **Get Effective Table Formatting**

Table formatting can come from the table style and from formats applied to the whole table, a column, a row, or an individual cell. For conflicts among explicitly defined fills, the priority is cell, row, column, and then whole table. The effective format of a cell is the final format used to draw that cell.

For this example, `table-formatting.pptx` must contain at least one table on its first slide. The table must have at least one row and one column. The code searches for a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) instead of assuming that `getShapes().get_Item(0)` is a table.

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

If you need the color rather than only the fill type, first check the effective `getFillType`, and then read the method that applies to that type—for example, `getSolidFillColor` for a solid fill.

## **Re-read Effective Data After Changes**

Effective data describes the formatting hierarchy at the time it is resolved. Call [getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) again after changing anything that can participate in that hierarchy, including:

- the object's local formatting;
- paragraph or text-frame defaults;
- a table style, table, column, row, or cell format;
- layout or master slide formatting;
- theme data or presentation-level defaults;
- the layout or master assigned to a slide.

Do not keep an effective data object as a permanent snapshot. Aspose.Slides may cache some effective data internally, and a later [getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) call can refresh that data. If you need to compare values before and after a change, copy the scalar values you need—such as a font height, color, alignment, or bevel width—into your own variables before making the change.

To change a value, update the appropriate local format object and then call [getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) to verify the result. Effective data objects themselves are read-only.

## **FAQ**

**How can I tell which level supplied an effective value?**

Effective data contains the final value, not its source. Inspect the applicable local objects from the most specific level outward. For text, this can include the portion, paragraph, text frame, layout, master, theme, and presentation defaults. Undefined values such as `float("nan")` or `None` indicate that the search continues to another level.

**What happens when no level defines a property?**

Aspose.Slides resolves the appropriate PowerPoint or library default. That resolved value appears in the effective data even though no local object explicitly defines it.

**Why does an effective value sometimes equal the local value?**

The local value won the inheritance calculation. This is expected when the property is explicitly set on the object and no more specific rule overrides it.

**When should I use local data instead of effective data?**

Use local data to inspect or edit a specific formatting level. Use effective data when you need the final appearance after inheritance, theme rules, and applicable styles have been resolved. The [complete comparison example](#compare-local-inherited-and-effective-values) demonstrates both in the same workflow.
