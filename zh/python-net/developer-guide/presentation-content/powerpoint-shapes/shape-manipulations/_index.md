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
- 获取 interop 形状 ID
- 形状替代文本
- 形状布局格式
- 形状为 SVG
- 形状转 SVG
- 对齐形状
- 翻转形状
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 对演示文稿形状进行识别、克隆、删除、隐藏、重新排序、导出、对齐和翻转。"
---
## **概述**

Aspose.Slides for Python via .NET 将幻灯片上的形状表示为有序的[ShapeCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/)。该集合既是查找和修改形状的所在，也是它们堆叠顺序的来源：索引 `0` 为最底层形状，最后一个索引为最前层形状。

本文遵循此模型。首先说明如何可靠地识别形状，然后展示如何克隆、删除、隐藏和重新排序形状。最后的章节涵盖布局级格式、SVG 导出、对齐以及翻转设置。每个示例都是独立的，您可以只使用工作流中需要的操作。

## **识别和查找形状**

在处理已知文件时，集合索引很方便，但它们并不是稳定的标识符。添加、删除或重新排序形状都会改变其索引。请根据演示文稿的编写和维护方式选择标识符：

- [Shape.name](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/name/) 对于开发者可控的模板很有用，并且可以在 PowerPoint 的“选择窗格”中轻松检查。名称可以编辑，但不保证唯一，因此如果代码依赖名称，需建立命名约定。
- [Shape.alternative_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/alternative_text/) 在可访问性描述或作者提供的标签已经标识形状时很有用。它对用户可见，可能会本地化或为可访问性重写，也不保证唯一。不要在不显式检查的情况下将有意义的可访问性文本用作数据库键。
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/office_interop_shape_id/) 是只读标识符，在同一幻灯片内唯一，对应 PowerPoint interop 使用的形状 ID。将其用于与 PowerPoint 集成或在形状生命周期内需要明确引用的场景。克隆或重新创建的形状是不同的形状，拥有自己的 ID。

相关的[Shape.unique_id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/unique_id/)属性具有演示文稿范围，但它面向插件，可能会被重新分配。不要将其视为永久的外部键。如果长期身份至关重要，请在应用程序数据中维护映射，并验证预期的形状仍然存在。

下面的示例使用精确比较按 `name` 搜索，并报告幻灯片范围的 interop ID。当模板不包含预期形状时，代码会报告该结果而不是继续使用错误的对象。

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

当操作特定于某种形状类型时，使用之前应先检查类型。本示例仅在命名对象是[AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)时才更新文本和替代文本。

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

## **修改形状集合**

添加、克隆、删除和重新排序方法会立即作用于集合。如果一次操作改变了形状的数量或顺序，请不要继续依赖该操作前捕获的索引。

### **克隆形状**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_clone/) 创建一个独立的副本并将其追加到目标集合。[ShapeCollection.insert_clone](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/insert_clone/) 也会创建副本，但将其放置在指定的 Z 顺序索引处。接受坐标的重载会在不改变大小的情况下移动克隆；带宽度和高度的重载还能对其进行缩放。

示例创建目标幻灯片，将标记矩形克隆到前面，并在后面插入第二个克隆。对任一克隆的修改都不会影响源形状。

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

克隆会复制形状的内容和格式，包括名称和替代文本。当这些值必须唯一时，请为克隆分配新的逻辑标识符。复杂形状使用的资源由演示文稿统一管理，但克隆仍是集合中的新项，拥有全新的形状标识。

### **删除形状**

[ShapeCollection.remove](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/remove/) 将特定形状对象从其集合中删除。在索引迭代期间删除多个匹配项时，请从末尾向前遍历，以保证剩余索引仍然有效。

本示例删除所有具有指定名称的形状。它读取 `slide.shapes[index]`，而不是固定的集合项，并且不会不必要地进行类型转换。

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

删除后，形状计数以及后续形状的索引会发生变化。对未受影响形状的引用比保存的索引更可靠。另外请考虑连接线、动画及其他可能引用被删除对象的演示文稿特性；删除可见形状可能会影响的不止是幻灯片外观。

### **隐藏形状**

将[Shape.hidden](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/hidden/)设为 `True` 可使形状仍保留在集合中，但在普通幻灯片放映时不显示。其索引、格式和内容仍可被代码访问，因此隐藏适用于可能稍后恢复的可选元素。

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

隐藏并不是删除或安全措施。用户或代码仍然可以发现并取消隐藏该对象，它仍是演示文稿文件的一部分。

### **更改 Z 顺序**

重叠的形状按集合顺序绘制。[ShapeCollection.reorder](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/reorder/) 将已有形状移动到目标索引，而不进行克隆。索引 `0` 为最底层；`len(slide.shapes) - 1` 为最前层。

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

矩形先创建，最初位于椭圆之后。将其移动到最后一个索引后会显示在前面。请在添加或克隆所有相关形状后再最终确定 Z 顺序，因为这些操作会追加或插入新集合项，可能改变预期的堆叠。

## **检查布局幻灯片上的形状**

普通幻灯片、布局幻灯片和母版幻灯片拥有各自的形状集合。布局集合中的形状并不是普通幻灯片上同位置形状的同一对象。需要了解或更改布局提供的格式时，请检查布局形状。

下面的示例读取每个布局形状的[Shape.fill_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/fill_format/)和[Shape.line_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/line_format/)，而不假设每个形状都是 `AutoShape`。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

编辑布局可能会影响使用该布局的多个幻灯片。在更改布局形状之前，请确定普通幻灯片是继承该对象还是包含本地覆盖，并对所有使用该布局的幻灯片进行测试。

## **将形状导出为 SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/write_as_svg/) 将单个形状的渲染内容写入流。结果只包含该形状，而不包括整个幻灯片背景或相邻形状。

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

渲染时请保持演示文稿打开。输出受形状格式以及字体、图像等资源的影响。如果需要整个组合，请导出整张幻灯片而不是单个形状。调用方拥有该流并必须负责关闭。

## **对齐形状**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/zh/python-net/aspose.slides.util/slideutil/align_shapes/) 的重载可以对全部形状或指定集合索引进行对齐。[ShapesAlignmentType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapesalignmenttype/) 指定对齐的边缘、中心线或分布模式。将 `align_to_slide` 设为 `True` 使用幻灯片边缘；设为 `False` 则相对选中形状彼此对齐。

本示例将三个形状对齐到幻灯片的顶部边缘。它们的当前索引在对齐前立即解析。

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

对齐会改变位置，而不改变 Z 顺序。相对对齐通常至少需要两个形状，水平或垂直分布则需要足够的形状来定义间距。若在调用方法前修改了集合，请重新计算索引。

## **翻转形状**

[ShapeFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapeframe/) 类存储位置、大小、水平和垂直翻转设置以及旋转。其 `flip_h` 和 `flip_v` 值使用[NullableBool](https://reference.aspose.com/slides/zh/python-net/aspose.slides/nullablebool/)：`TRUE` 启用翻转，`FALSE` 禁用，`NOT_DEFINED` 保持未指定或默认状态。

下面的输入演示文稿包含一个未翻转的形状。

![翻转前的形状](shape_to_be_flipped.png)

示例保留其他所有框架值，仅替换这两个翻转设置。这一点重要，因为为[Shape.frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/frame/)分配新对象会替换整个框架。

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

保存后的形状在水平和垂直方向上均为镜像，同时保持位置、大小和旋转不变。

![翻转后的形状](flipped_shape.png)

## **常见问题**

**是否应该使用集合索引作为形状标识符？**

仅在短暂处理且在使用索引前集合不会改变的情况下可以。对于已编写的模板，推荐使用经过验证的 `name` 或 `alternative_text` 约定；对于幻灯片范围的 interop 工作，使用 `office_interop_shape_id`。

**隐藏形状会从 Z 顺序中移除吗？**

不会。隐藏的形状仍保留在集合中，索引不变。它仍然可以被查找、重新排序、编辑或再次显示。

**为什么克隆的形状出现在另一形状的前面？**

`add_clone` 将克隆追加到集合末尾，而集合末尾对应 Z 顺序的最前层。使用 `insert_clone` 可以指定初始索引，或在所有形状添加完毕后调用 `reorder`。