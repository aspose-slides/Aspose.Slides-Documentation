---
title: 在 Python 中管理演示文稿形状
linktitle: 形状操作
type: docs
weight: 40
url: /zh/python-net/shape-manipulations/
keywords:
- PowerPoint 形状
- 演示文稿形状
- 幻灯片上的形状
- 查找形状
- 克隆形状
- 删除形状
- 隐藏形状
- 更改形状顺序
- 获取互操作形状 ID
- 形状替代文本
- 形状调整点
- 预设形状调整
- 形状几何
- 形状布局格式
- 形状为 SVG
- 形状转为 SVG
- 对齐形状
- 翻转形状
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 识别、调整、克隆、删除、隐藏、重新排序、导出、对齐和翻转演示文稿形状。"
---
## **概述**

Aspose.Slides for Python via .NET 将幻灯片上的形状表示为有序的 [ShapeCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/)。该集合既是查找和修改形状的地方，也是它们堆叠顺序的来源：索引 `0` 为最底层形状，最后一个索引为最前层形状。

本文遵循该模型。它首先解释如何可靠地识别形状并修改预设的形状调整点，然后展示如何克隆、删除、隐藏和重新排序形状。最后的章节涵盖布局级别的格式设置、SVG 导出、对齐以及翻转设置。每个示例都是独立的，您可以仅使用工作流所需的操作。

## **识别和查找形状**

在处理已知文件时，集合索引很方便，但它们不是稳定的标识符。添加、删除或重新排序形状都会改变其索引。根据演示文稿的创建和维护方式选择标识符：

- [Shape.name](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/name/) 对于开发者控制的模板有用，并且可以在 PowerPoint 的“选择窗格”中轻松查看。名称可以编辑，但不保证唯一，因此如果代码依赖名称，请制定命名约定。
- [Shape.alternative_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/alternative_text/) 在已有可访问性描述或作者提供的标签已标识形状时有用。它对用户可见，可能会本地化或为可访问性重新编写，也不保证唯一。不要在不知情的情况下将有意义的可访问性文本用作数据库键。
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/office_interop_shape_id/) 是只读标识符，在同一幻灯片内唯一，并对应 PowerPoint 互操作使用的形状 ID。将其用于与 PowerPoint 集成或在形状生命周期内需要明确引用的情况。克隆或重新创建的形状是不同的形状，拥有自己的 ID。

相关的 [Shape.unique_id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/unique_id/) 属性具有演示文稿范围，但它面向插件，且可能被重新分配。不要将其视为永久的外部键。如果长期身份至关重要，请在应用程序数据中保存映射，并验证预期形状仍然存在。

下面的示例使用 `name` 进行精确比较搜索，并报告幻灯片范围的互操作 ID。当模板不包含预期形状时，代码会报告该结果，而不是继续使用错误的对象。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

当操作特定于某种形状类型时，请在使用类型特定成员前检查类型。此示例仅在命名对象是 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/) 时更新文本和替代文本。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **识别和修改预设形状调整**

预设几何形状可以公开调整点，以控制角大小、箭头比例或弧度等特性。通过只读的 [GeometryShape.adjustments](https://reference.aspose.com/slides/zh/python-net/aspose.slides/geometryshape/adjustments/) 集合访问它们。该集合由形状提供，但每个 [AdjustValue](https://reference.aspose.com/slides/zh/python-net/aspose.slides/adjustvalue/) 包含可更改的值。

不要仅依赖固定的集合索引。遍历 adjustments 并检查只读的 [AdjustValue.type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/adjustvalue/type/) 属性，其 [ShapeAdjustmentType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapeadjustmenttype/) 值描述了该调整控制的内容。只读的 [AdjustValue.name](https://reference.aspose.com/slides/zh/python-net/aspose.slides/adjustvalue/name/) 属性提供了额外的标识信息，尤其在一个预设包含多个同类型调整时非常有用。

使用与调整意义相匹配的值属性：

| 调整类型 | 用途 | 要更改的值 |
|---|---|---|
| `CORNER_SIZE` | 圆角大小 | [raw_value](https://reference.aspose.com/slides/zh/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | 箭尾粗细 | `raw_value` |
| `ARROWHEAD_LENGTH` | 箭头长度 | `raw_value` |
| `ARROWHEAD_WIDTH` | 箭头宽度 | `raw_value` |
| `START_ANGLE` | 饼图或弧线的起始角度 | [angle_value](https://reference.aspose.com/slides/zh/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | 饼图或弧线的结束角度 | `angle_value` |

`type` 和 `name` 不能赋值。`raw_value` 是预设本身几何单位的可读写整数，而 `angle_value` 是以度为单位的可读写角度。调整的数量、顺序、含义以及有效范围取决于预设的 [GeometryShape.shape_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/geometryshape/shape_type/)。对一种预设有效的值在另一种预设中可能无效或产生不同效果。

当 `type` 为 `ShapeAdjustmentType.CUSTOM` 时，API 不识别标准语义含义。检查 `name`、预设类型以及现有值，除非已知预期含义和范围，否则保持调整不变。即使是已识别的类型，在选择值之前也要检查同一类型是否出现多次。[Connector](/slides/zh/python-net/connector/) 文章展示了连接线弯曲调整的这种情况。

下面的完整示例创建三种预设形状的默认和修改版本。它遍历每个调整，报告其 `name` 和 `type`，通过 `raw_value` 更改大小相关的值，通过 `angle_value` 更改角度，并保存结果。左列保留默认几何；右列显示已调整的圆角矩形、四向箭头和饼形。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加默认和调整后形状列的标题。
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

在更改值之前检查语义类型，使代码明确其意图，避免假设不同预设形状的相同集合索引具有相同含义。

## **修改形状集合**

添加、克隆、删除和重新排序方法会立即作用于集合。如果操作改变了形状数量或顺序，请不要继续依赖在该操作之前捕获的索引。

### **克隆形状**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_clone/) 创建一个独立的副本并将其追加到目标集合。[ShapeCollection.insert_clone](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/insert_clone/) 也创建副本，但将其放置在指定的 Z 顺序索引位置。接受坐标的重载在不改变大小的情况下移动克隆；接受宽度和高度的重载还可以调整大小。

示例创建目标幻灯片，将带标签的矩形克隆到前面，并在后面插入第二个克隆。对任一克隆的更改都不会影响源形状。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

克隆会复制形状的内容和格式，包括名称和替代文本。当这些值必须唯一时，请为克隆分配新的逻辑标识符。复杂形状使用的资源由演示文稿处理，但克隆仍然是具有新形状标识的新集合项。

### **删除形状**

[ShapeCollection.remove](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/remove/) 从其集合中删除特定的形状对象。在索引迭代期间删除多个匹配项时，请从末尾向前遍历，以保持其余索引有效。

此示例删除所有具有指定名称的形状。它读取 `slide.shapes[index]`，而不是固定的集合项，并且没有不必要地强制转换形状类型。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

删除后，形状计数以及后续形状的索引都会改变。对未受影响的形状的引用比保存的索引更可靠。另外还需考虑连接线、动画以及可能引用已删除对象的其他演示文稿特性；删除可见形状可能改变的不仅是幻灯片的外观。

### **隐藏形状**

将 [Shape.hidden](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/hidden/) 设置为 `True` 会保留形状在集合中，但阻止其在普通幻灯片放映中出现。它的索引、格式和内容仍可供代码使用，因此隐藏适用于以后可能恢复的可选元素。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

隐藏不等同于删除或安全保护。对象仍然可以被用户或代码发现并取消隐藏，并且仍是演示文稿文件的一部分。

### **更改 Z 顺序**

重叠的形状按照集合顺序绘制。[ShapeCollection.reorder](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/reorder/) 将现有形状移动到目标索引，且不进行克隆。索引 `0` 为最底层；`len(slide.shapes) - 1` 为最前层。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

矩形最初创建时位于椭圆之后。将其移动到最终索引后会出现在前面。添加或克隆所有相关形状后再最终确定 Z 顺序，因为这些操作会追加或插入新集合项，从而可能改变预期的堆叠顺序。

## **检查布局幻灯片上的形状**

普通幻灯片、布局幻灯片和母版幻灯片拥有各自独立的形状集合。布局集合中的形状与普通幻灯片上位置相同的形状不是同一个对象。需要了解或更改布局提供的格式时，请检查布局形状。

下面的示例读取每个布局形状的 [Shape.fill_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/fill_format/) 和 [Shape.line_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/line_format/)，而不假设每个形状都是 `AutoShape`。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

编辑布局可能影响使用该布局的多个幻灯片。在更改布局形状之前，先确定普通幻灯片是继承该对象还是拥有本地覆盖，并对使用该布局的每张幻灯片进行测试。

## **将形状导出为 SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/write_as_svg/) 将单个形状的渲染内容写入流。结果只包含该形状本身，而不是整个幻灯片背景或相邻形状。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

在渲染期间保持演示文稿打开。输出取决于形状的格式以及字体、图像等资源。如果需要完整的组合，请导出幻灯片而不是单个形状。调用方拥有流的所有权并必须关闭它。

## **对齐形状**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/zh/python-net/aspose.slides.util/slideutil/align_shapes/) 的重载可以对所有形状或选定的集合索引进行对齐。[ShapesAlignmentType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapesalignmenttype/) 指定边缘、中心线或分布模式。将 `align_to_slide` 设置为 `True` 使用幻灯片边缘；设为 `False` 则相对选定形状进行对齐。

此示例将三个形状对齐到幻灯片的顶部边缘。它们的当前索引在对齐前立即解析。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

对齐会改变位置，而不是 Z 顺序。相对对齐通常需要至少两个形状，而水平或垂直分布则需要足够的形状来定义间距。如果在调用方法前修改了集合，请重新计算索引。

## **翻转形状**

[ShapeFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapeframe/) 类存储位置、尺寸、水平和垂直翻转设置以及旋转。其 `flip_h` 和 `flip_v` 值使用 [NullableBool](https://reference.aspose.com/slides/zh/python-net/aspose.slides/nullablebool/)：`TRUE` 启用翻转，`FALSE` 禁用，`NOT_DEFINED` 保持未指定或默认状态。

下面的输入演示文稿包含一个未翻转的形状。

![The shape before flipping](shape_to_be_flipped.png)

示例保留其它所有框架值，仅替换两个翻转设置。这一点很重要，因为为 [Shape.frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/frame/) 赋新值会替换完整的框架。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

保存后的形状在水平和垂直方向上均为镜像，同时保持其位置、尺寸和旋转。

![The shape after flipping](flipped_shape.png)

## **常见问题**

**我可以使用集合索引作为形状标识符吗？**

仅在集合在使用索引前不会改变的短期处理场景下可以。对于已编写模板，建议使用经过验证的 `name` 或 `alternative_text` 约定；对于幻灯片范围的互操作工作，使用 `office_interop_shape_id`。

**隐藏形状会从 Z 顺序中移除吗？**

不会。隐藏的形状仍然保留在集合的相同索引中。它仍然可以被查找、重新排序、编辑或再次显示。

**为什么克隆的形状出现在另一形状之前？**

`add_clone` 将克隆追加到集合末尾，也就是 Z 顺序的前面。使用 `insert_clone` 可以选择初始索引，或者在添加完所有形状后使用 `reorder`。

**我可以使用固定索引来标识预设形状的调整吗？**

只能在验证了确切的预设和集合布局后才能使用。更推荐遍历 `GeometryShape.adjustments` 并检查 `AdjustValue.type`；当同一语义类型出现多次时，使用 `AdjustValue.name` 作为额外信息。