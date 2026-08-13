---
title: 在Python中从演示文稿获取形状的有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/python-net/shape-effective-properties/
keywords:
- 形状属性
- 摄像机属性
- 灯光装置
- 倒角形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 演示文稿中区分本地、继承和有效的形状格式化。"
---
## **了解本地、继承和有效属性**

PowerPoint 的格式可以来源于多个位置。直接存储在对象上的值是其 **本地值**。如果该值未设置，PowerPoint 会查看父级格式来源，例如段落默认值、文本样式、布局或母版幻灯片、主题或演示文稿级别的默认值。这些值是 **继承值**。在整个层次结构解析完毕后剩余的值即为 **有效值**，用于渲染对象。

例如，文本片段可能没有自行定义字体高度。其本地 [font_height](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ibaseportionformat/font_height/) 为 `float("nan")`，表示“此处未设置”。该片段可以从其段落、演示文稿的默认文本样式或其他适用来源继承高度。对片段格式调用 [get_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iportionformat/get_effective/) 会返回最终解析后的高度。

使用这两种格式数据用于不同的目的：

- 在需要控制值定义位置时，读取或更改本地格式对象，例如 [IPortionFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iportionformat/)。
- 在需要最终渲染结果时，读取有效数据对象，例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iportionformateffectivedata/)。有效数据为只读。

## **比较本地、继承和有效值**

以下完整示例创建一个形状，并在演示文稿、段落和片段层级上分别应用字体高度。每一步都会打印这些层级定义的值以及同一文本片段的结果有效值。示例还演示了为何在格式更改后必须重新读取有效数据。

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # 在先前的更改之后读取有效数据。
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

    # 在两个不同层级上定义继承值。
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # 片段的本地值覆盖两个继承值。
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # 更改继承值不会覆盖已有的本地值。
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # 清除本地值。片段现在再次从段落继承。
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # 清除段落值。演示文稿默认值现在提供结果。
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

本示例的优先级顺序为片段本地格式、段落格式、演示文稿默认。其他对象可能拥有不同的继承链，但原则相同：更具体的显式值获胜，且 [get_effective](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iportionformat/get_effective/) 返回最终结果。

## **获取有效的文本属性**

文本格式分布在多个对象中：

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/zh/python-net/aspose.slides/itextframeformat/get_effective/) 解析文本框属性，如边距、锚点、自动适应和垂直文字方向。
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/zh/python-net/aspose.slides/itextstyle/get_effective/) 解析每个文本样式级别的段落格式。
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iparagraphformat/get_effective/) 解析段落属性，如对齐、缩进和项目符号。
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iportionformat/get_effective/) 解析字符属性，如字体高度、字体族、颜色、粗体和斜体。

对于下一个示例，`text-formatting.pptx` 必须至少包含一张幻灯片和一个带有非空文本框的 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。AutoShape 可以位于形状集合中的任意位置；代码会搜索合适的对象并在使用前进行验证。

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

## **获取有效的 3D 属性**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ithreedformat/get_effective/) 返回一个 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ithreedformateffectivedata/) 对象，其中聚合了所有已解析的 3D 设置。其 [camera](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ithreedformateffectivedata/camera/)、[light_rig](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ithreedformateffectivedata/light_rig/)、[bevel_top](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/) 和 [bevel_bottom](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) 属性公开相应的有效数据。一起读取这些相关设置可以更容易理解形状的最终 3D 外观。

对于此示例，`shape-3d.pptx` 必须在其第一页至少包含一个形状。如果希望输出包含除默认值之外的数值，请对该形状应用 3D 摄像机、光照或倒角设置。

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

## **获取有效的表格格式**

表格格式可以来自表格样式，也可以来自整体表格、列、行或单元格的格式。对于显式填充的冲突，优先级顺序为单元格、行、列，然后是整个表格。单元格的有效格式即用于绘制该单元格的最终格式。

对于此示例，`table-formatting.pptx` 必须在其第一页至少包含一个表格。该表格必须至少有一行和一列。代码会搜索一个 [Table](https://reference.aspose.com/slides/zh/python-net/aspose.slides/table/)，而不是假设 `shapes[0]` 是表格。

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

如果需要获取颜色而不仅仅是填充类型，首先检查有效的 [fill_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ifillformateffectivedata/fill_type/)，然后读取对应类型的属性，例如针对实体填充的 [solid_fill_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/)。

## **更改后重新读取有效数据**

有效数据描述了解析时的格式层次结构。更改任何可能参与该层次结构的内容后，请再次调用 `get_effective`，包括：

- 对象的本地格式；
- 段落或文本框的默认值；
- 表格样式、表格、列、行或单元格的格式；
- 布局或母版幻灯片的格式；
- 主题数据或演示文稿级别的默认值；
- 分配给幻灯片的布局或母版。

不要将有效数据对象作为永久快照保存。Aspose.Slides 可能在内部缓存部分有效数据，后续的 `get_effective` 调用可以刷新这些数据。如果需要在更改前后比较数值，请在更改之前将所需的标量值（如字体高度、颜色、对齐方式或倒角宽度）复制到自己的变量中。

若要更改某个值，请更新相应的本地格式对象，然后调用 `get_effective` 验证结果。有效数据对象本身是只读的。

## **FAQ**

**如何判断是哪个层级提供了有效值？**

有效数据只包含最终值，不指明其来源。需从最具体的层级向外检查相应的本地对象。对文本而言，这可能包括片段、段落、文本框、布局、母版、主题以及演示文稿默认值。`float("nan")` 或 `None` 等未定义值表示搜索将继续到更高层级。

**如果没有任何层级定义某属性会怎样？**

Aspose.Slides 会解析出相应的 PowerPoint 或库默认值。该解析后的值会出现在有效数据中，即使没有本地对象显式定义它。

**为什么有效值有时等于本地值？**

本地值在继承计算中获胜。这在属性显式设置在对象上且没有更具体的规则覆盖时是预期行为。

**何时应该使用本地数据而不是有效数据？**

在需要检查或编辑特定格式层级时使用本地数据。需要在继承、主题规则和适用样式全部解析后得到的最终外观时使用有效数据。[完整比较示例](#compare-local-inherited-and-effective-values) 在同一工作流中演示了两者的使用。