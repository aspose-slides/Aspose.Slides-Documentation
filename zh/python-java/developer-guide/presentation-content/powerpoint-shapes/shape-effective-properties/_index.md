---
title: 在 Python（via Java）中获取演示文稿中形状的有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/python-java/shape-effective-properties/
keywords:
- 形状属性
- 摄像机属性
- 光源设置
- 倒角形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中区分本地、继承和有效的形状格式设置。"
---
## **了解本地、继承和有效属性**

PowerPoint 格式可以来自多个位置。直接存储在对象上的值称为 **本地值**。如果未设置该值，PowerPoint 会查看父级格式来源，如段落默认值、文本样式、布局或母版幻灯片、主题或演示文稿级别的默认值。这些值是 **继承值**。在解析完整层级后剩余的值是 **有效值**——用于呈现对象的值。

例如，文本段落可能未定义自己的字体高度。其本地 [getFontHeight](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#getFontHeight) 值将是 `float("nan")`，表示“此处未设置”。该段落可以从其段落、演示文稿的默认文本样式或其他适用来源继承高度。对段落格式调用 [getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/#getEffective) 将返回最终解析的高度。

在不同场景下使用这两种格式数据：

- 读取或更改本地格式对象，例如 [PortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/)，当您需要控制值的定义位置时。
- 读取有效数据对象，例如 `PortionFormatEffectiveData`，当您需要最终渲染结果时。有效数据是只读的。

## **比较本地、继承和有效值**

下面的完整示例创建一个形状并在演示文稿、段落和段落级别（portion）应用字体高度。每一步都会打印在这些层级上定义的值以及同一文本段落的最终有效值。它还演示了为何在格式更改后必须重新读取有效数据。

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

    # 在前面的更改后读取有效数据。
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

    # 在两个不同层级定义继承值。
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # 段落本地值会覆盖两个继承值。
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # 更改继承值不会覆盖已存在的本地值。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # 清除本地值。该段落现在再次从段落继承。
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # 清除段落值。演示文稿默认值现在提供结果。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此示例中的优先级为段落本地格式，然后是段落格式，最后是演示文稿默认值。其他对象可能具有不同的继承链，但原则相同：更具体的显式值获胜，且 [getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/#getEffective) 返回最终结果。

## **获取有效文本属性**

文本格式分布在多个对象中：

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#getEffective) 解析文本框属性，如边距、锚点、自动适应和垂直文本方向。
- [TextStyle.getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textstyle/#getEffective) 解析每个文本样式层级的段落格式。
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#getEffective) 解析段落属性，如对齐、缩进和项目符号。
- [PortionFormat.getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/#getEffective) 解析字符属性，如字体高度、字形、颜色、粗体和斜体。

对于下一个示例，`text-formatting.pptx` 必须包含至少一个幻灯片和一个带有非空文本框的 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。该 AutoShape 可以位于形状集合中的任意位置；代码将在使用前搜索合适的对象并进行验证。

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

## **获取有效 3D 属性**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/threedformat/#getEffective) 返回一个 `ThreeDFormatEffectiveData` 对象，汇总所有已解析的 3D 设置。其 `getCamera`、`getLightRig`、`getBevelTop` 和 `getBevelBottom` 方法公开相应的有效数据。一起读取这些相关设置可更轻松地了解形状的最终 3D 外观。

对于此示例，`shape-3d.pptx` 必须在其第一页上至少包含一个形状。若希望输出包含除默认值之外的值，请对该形状应用 3D 相机、光照或倒角设置。

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

## **获取有效表格格式**

表格格式可以来自表格样式，也可以来自应用于整个表格、列、行或单元格的格式。对于显式定义的填充冲突，优先级为单元格、行、列，然后是整个表格。单元格的有效格式是用于绘制该单元格的最终格式。

对于此示例，`table-formatting.pptx` 必须在其第一页上至少包含一个表格。该表格必须至少有一行和一列。代码会搜索 [Table](https://reference.aspose.com/slides/zh/python-java/aspose.slides/table/)，而不是假设 `getShapes().get_Item(0)` 是表格。

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

如果您需要颜色而不仅是填充类型，请先检查有效的 `getFillType`，然后读取适用于该类型的方法，例如针对纯色填充的 `getSolidFillColor`。

## **在更改后重新读取有效数据**

有效数据描述解析时的格式层级。在更改任何可能参与该层级的内容后，请再次调用 [getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/#getEffective)，包括：

- 对象的本地格式；
- 段落或文本框默认值；
- 表格样式、表格、列、行或单元格的格式；
- 布局或母版幻灯片的格式；
- 主题数据或演示文稿级别的默认值；
- 分配给幻灯片的布局或母版。

不要将有效数据对象作为永久快照保存。Aspose.Slides 可能在内部缓存部分有效数据，随后调用 [getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/#getEffective) 能刷新该数据。如果需要比较更改前后的值，请在更改之前将所需的标量值（例如字体高度、颜色、对齐方式或倒角宽度）复制到自己的变量中。

要更改值，请更新相应的本地格式对象，然后调用 [getEffective](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/#getEffective) 以验证结果。有效数据对象本身是只读的。

## **常见问题**

**如何判断哪个层级提供了有效值？**

有效数据仅包含最终值，而不指示其来源。请从最具体的层级向外检查相应的本地对象。对于文本，这可能包括文本段落、段落、文本框、布局、母版、主题和演示文稿默认值。`float("nan")` 或 `None` 等未定义值表示搜索将继续到更高层级。

**当没有任何层级定义属性时会发生什么？**

Aspose.Slides 会解析相应的 PowerPoint 或库默认值。即使没有本地对象显式定义该属性，解析后的值也会出现在有效数据中。

**为什么有效值有时等于本地值？**

本地值在继承计算中获胜。当属性在对象上显式设置且没有更具体的规则覆盖时，出现此情况属于预期。

**何时应使用本地数据而非有效数据？**

使用本地数据检查或编辑特定的格式层级。当需要在继承、主题规则和适用样式解析后的最终外观时，使用有效数据。完整的比较示例（[完整比较示例](#compare-local-inherited-and-effective-values)）在同一工作流中演示了两者。