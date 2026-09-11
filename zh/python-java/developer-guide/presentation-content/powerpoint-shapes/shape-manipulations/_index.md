---
title: 使用 Python via Java 管理演示文稿形状
linktitle: 形状操作
type: docs
weight: 40
url: /zh/python-java/shape-manipulations/
keywords:
- PowerPoint 形状
- 演示文稿形状
- 幻灯片上的形状
- 查找形状
- 克隆形状
- 移除形状
- 隐藏形状
- 更改形状顺序
- 获取互操作形状 ID
- 形状替代文本
- 形状调整点
- 预设形状调整
- 形状几何
- 形状布局格式
- 形状为 SVG
- 形状转 SVG
- 对齐形状
- 翻转形状
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 对演示文稿形状进行识别、调整、克隆、移除、隐藏、重新排序、导出、对齐和翻转。"
---
## **概述**

Aspose.Slides for Python via Java 将幻灯片上的形状表示为有序的 [ShapeCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/)。该集合既是查找和修改形状的地方，也是它们堆叠顺序的来源：索引 `0` 为最底层形状，最后一个索引为最前层形状。

本文遵循该模型。首先说明如何可靠地识别形状并修改预设的形状调整点，然后展示如何克隆、移除、隐藏和重新排序形状。最后几节覆盖布局级格式、SVG 导出、对齐以及翻转设置。每个示例都是独立的，您可以只使用工作流所需的操作。

## **识别并查找形状**

在处理已知文件时，集合索引很方便，但它们不是稳定的标识符。添加、删除或重新排序形状都会改变其索引。请根据演示文稿的创建和维护方式选择标识符：

- [Name](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getName) 对于受开发者控制的模板很有用，并且可以在 PowerPoint 的“选择窗格”中轻松查看。名称可以编辑，但不保证唯一，因此如果代码依赖名称，请制定命名约定。
- [AlternativeText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getAlternativeText) 在已有可访问性描述或作者提供的标签已经标识形状时很有用。它对用户可见，可能会本地化或为可访问性而重写，且不保证唯一。不要在不知情的情况下将有意义的可访问性文本用作数据库键。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getOfficeInteropShapeId) 是只读标识符，在同一幻灯片内唯一，且对应 PowerPoint 互操作使用的形状 ID。将其用于与 PowerPoint 集成或在形状生命周期内需要明确引用的场景。克隆或重新创建的形状是不同的形状，会获得自己的 ID。

相关的 [getUniqueId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getUniqueId) 方法返回演示文稿范围的标识符，但该标识符面向插件，可能会被重新分配，不应视为永久的外部键。如果需要长期唯一性，请在应用程序数据中维护映射并验证预期的形状仍然存在。

下面的示例通过精确比较按名称搜索，并报告幻灯片范围的互操作 ID。当模板不包含期望的形状时，代码会报告该结果，而不是继续使用错误的对象。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

当操作特定于某种形状类型时，请在使用类型特定成员之前检查类型。此示例仅在命名对象是 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 时更新文本和替代文本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **识别并修改预设形状调整**

预设几何形状可以公开调整点，以控制角大小、箭头比例或弧度等特性。通过只读的 [GeometryShape.getAdjustments](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometryshape/#getAdjustments) 集合访问它们。该集合由形状提供，但每个 [AdjustValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/) 包含可更改的数值。

不要仅依赖固定的集合索引。遍历调整项并检查只读的 [getType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#getType) 方法，其返回的 [ShapeAdjustmentType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapeadjustmenttype/) 值描述该调整控制的内容。只读的 [getName](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#getName) 方法提供额外的标识信息，特别是在同一预设包含多个语义相同类型的调整时非常有用。

使用与调整意义相匹配的数值方法：

| 调整类型 | 目的 | 要更改的值 |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | 圆角大小 | [setRawValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | 箭尾粗细 | [setRawValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | 箭头长度 | [setRawValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | 箭头宽度 | [setRawValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | 饼形或弧形的起始角度 | [setAngleValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | 饼形或弧形的结束角度 | [setAngleValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#getType) 和 [getName](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#getName) 返回只读信息。[getRawValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#getRawValue) 与 [setRawValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#setRawValue) 使用预设原生几何单位的整数，而 [getAngleValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#getAngleValue) 与 [setAngleValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#setAngleValue) 使用度数。调整的数量、顺序、含义和有效范围取决于预设的 [ShapeType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometryshape/#getShapeType)。在一种预设下有效的数值在另一种预设中可能无效或产生不同效果。

当 [getType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#getType) 返回 [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapeadjustmenttype/#Custom) 时，API 并未识别标准语义。检查 [getName](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#getName)、预设类型和现有数值，除非已知期望的含义和范围，否则保持调整不变。即使是已识别的类型，也要在选择数值前检查同类型是否出现多次。[Connector](/slides/zh/python-java/connector/) 文章展示了连接器弯曲调整的这种情况。

下面的完整示例创建了三种预设形状的默认和修改版本。它遍历每个调整，报告其名称和类型，通过 [setRawValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#setRawValue) 更改尺寸相关数值，通过 [setAngleValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#setAngleValue) 更改角度，并保存结果。左列保留默认几何，右列展示了调整后的圆角矩形、四向箭头和饼形。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 为默认和调整后的形状列添加标题。
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在更改数值之前检查语义类型可以使代码意图明确，并避免假设特定集合索引在不同预设形状间具有相同含义。

## **修改形状集合**

add、clone、remove 和 reorder 方法会立即作用于集合。如果一次操作改变了形状的数量或顺序，请勿继续依赖操作前捕获的索引。

### **克隆形状**

[addClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addClone) 创建一个独立副本并将其追加到目标集合。[insertClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#insertClone) 也创建副本，但将其放置在指定的 z 顺序索引。接受坐标的重载在不改变尺寸的情况下移动克隆；接受宽度和高度的重载则可以同时调整大小。

示例创建目标幻灯片，将带标签的矩形克隆到前面，并在后面插入第二个克隆。对任一克隆的更改都不影响源形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

克隆会复制形状的内容和格式，包括名称和替代文本。当这些值必须唯一时，请为克隆分配新的逻辑标识符。复杂形状使用的资源由演示文稿处理，但克隆仍然是集合中的新项目，拥有新的形状标识。

### **移除形状**

[remove](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#remove) 从其集合中删除特定形状对象。在索引遍历期间移除多个匹配项时，请从末端向前遍历，以保持其余索引有效。

此示例移除所有具有指定名称的形状。它读取当前索引处的形状，而不是固定的集合项，并且没有不必要的强制转换。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

移除后，形状计数以及后续形状的索引会改变。对未受影响的形状的引用比保存的索引更可靠。还要考虑连接器、动画等可能引用被移除对象的演示文稿特性；移除可见形状可能会影响幻灯片的外观之外的其他方面。

### **隐藏形状**

将 [Hidden](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#setHidden) 设置为 `True` 会保留形状在集合中，但阻止其在普通幻灯片放映中出现。其索引、格式和内容仍可供代码使用，因此隐藏适用于可能稍后恢复的可选元素。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

隐藏并不是删除或安全保密。对象仍然可以被用户或代码发现并取消隐藏，它仍是演示文稿文件的一部分。

### **更改 Z 顺序**

重叠的形状按照集合顺序绘制。[reorder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#reorder) 在不克隆的情况下将已有形状移动到目标索引。索引 `0` 为最底层，集合 [size](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#size) 减一为最前层。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

矩形最初创建时位于椭圆之后。将其移动到最后索引后会置于前面。请在添加或克隆所有相关形状后再确定最终的 Z 顺序，因为这些操作会追加或插入新集合项，可能改变原有堆叠。

## **检查布局幻灯片上的形状**

普通幻灯片、布局幻灯片和母版幻灯片拥有各自的形状集合。布局集合中的形状并非普通幻灯片上同位形状的同一对象。需要了解或更改布局提供的格式时，请检查布局形状。

下面的示例读取每个布局形状的 [FillFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getFillFormat) 和 [LineFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getLineFormat)，而不假设每个形状都是 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

编辑布局可能影响使用该布局的多个幻灯片。更改布局形状前，请确定普通幻灯片是继承该对象还是包含本地覆盖，并测试使用该布局的每张幻灯片。

## **将形状导出为 SVG**

[Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 的 `writeAsSvg` 方法将单个形状的渲染内容写入流。结果仅包含该形状，而不包括整个幻灯片背景或相邻形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

在渲染期间保持演示文稿打开。输出受形状格式以及字体、图像等资源影响。若需要完整的组合，请导出幻灯片而非单个形状。调用者拥有流的所有权，需要自行关闭。

## **对齐形状**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slideutil/#alignShapes) 重载可对齐所有形状或选定的集合索引。[ShapesAlignmentType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapesalignmenttype/) 指定边缘、中心线或分布模式。将 `align_to_slide` 设置为 `True` 使用幻灯片边缘；设置为 `False` 则相对于彼此对齐选中的形状。

此示例将三个形状对齐到幻灯片的上边缘。对齐前会立即将返回的形状引用转换为当前索引。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

对齐会改变位置，而不是 Z 顺序。相对对齐通常至少需要两个形状，水平或垂直分布则需要足够的形状来定义间距。如在调用方法前修改了集合，请重新计算索引。

## **翻转形状**

[ShapeFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapeframe/) 类存储位置、大小、水平和垂直翻转设置以及旋转。其 [getFlipH](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapeframe/#getFlipH) 和 [getFlipV](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapeframe/#getFlipV) 值使用 [NullableBool](https://reference.aspose.com/slides/zh/python-java/aspose.slides/nullablebool/)：`True` 启用翻转，`False` 禁用，`NotDefined` 保持未指定/默认状态。

下面的输入演示文稿包含一个未翻转的形状。

![翻转前的形状](shape_to_be_flipped.png)

示例保留其他所有帧值，仅替换两个翻转设置。这一点很重要，因为为 [Frame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#setFrame) 赋新值会替换整个帧。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

保存后的形状在水平和垂直方向上均被镜像，同时保持其位置、大小和旋转不变。

![翻转后的形状](flipped_shape.png)

## **常见问题**

**我应该使用集合索引作为形状标识符吗？**

仅在短期处理且在使用索引前集合不会变化的情况下使用。对于已编写的模板，请优先使用已验证的 [Name](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getName) 或 [AlternativeText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getAlternativeText) 约定；对于幻灯片范围的互操作工作，请使用 [OfficeInteropShapeId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getOfficeInteropShapeId)。

**隐藏形状会从 Z 顺序中移除吗？**

不会。隐藏的形状仍然保留在集合中，索引不变。它可以被查找、重新排序、编辑或再次显示。

**为什么克隆的形状会出现在另一个形状前面？**

[addClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addClone) 会将克隆追加到集合末尾，即 Z 顺序的最前端。使用 [insertClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#insertClone) 可以指定初始索引，或在全部形状添加完毕后使用 [reorder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#reorder) 调整顺序。

**我可以使用固定索引来识别预设形状的调整吗？**

仅在验证了确切预设和集合布局后才可以。更推荐遍历 [GeometryShape.getAdjustments](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometryshape/#getAdjustments) 并检查 [AdjustValue.getType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#getType)；当同一语义类型出现多次时，可使用 [AdjustValue.getName](https://reference.aspose.com/slides/zh/python-java/aspose.slides/adjustvalue/#getName) 作为补充信息。