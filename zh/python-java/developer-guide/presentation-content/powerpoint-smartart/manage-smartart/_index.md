---
title: 使用 Python 管理 PowerPoint 演示文稿中的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt 文本
- 布局类型
- 隐藏属性
- 组织结构图
- 图片组织结构图
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 通过清晰的代码示例构建和编辑 PowerPoint SmartArt，以加快幻灯片设计和自动化。"
---
## **概述**

SmartArt 是由节点、节点形状和布局组成的 PowerPoint 图表。使用 Aspose.Slides for Python via Java，您可以创建 SmartArt、读取其节点的文本、更改其布局、检查隐藏的节点、配置组织结构图布局，并创建图片组织结构图。

## **从 SmartArt 对象获取文本**

SmartArt 节点可以包含一个或多个形状。要读取节点形状中的文本，请遍历 [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes)，然后读取由 [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame) 返回的 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)。

示例需要一个包含至少一张幻灯片的演示文稿，并且该幻灯片上第一个形状是 SmartArt 对象。它会将每个可用的文本框打印到控制台。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape
        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **更改 SmartArt 对象的布局类型**

SmartArt 布局控制节点的排列和连接方式。以下示例使用 [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) 的 `BasicBlockList` 值创建 SmartArt 对象，将其更改为 `BasicProcess` 值，并保存演示文稿。传递给 [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) 的位置和大小以点为单位。使用 [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) 更改布局。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **检查 SmartArt 节点是否隐藏**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) 表示该节点在 SmartArt 数据模型中是否被隐藏。即使所选布局未将隐藏节点显示为可见的图表元素，隐藏节点仍可能存在于结构中。

以下示例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` 值的 SmartArt 对象添加一个节点，并检查该添加节点的隐藏状态。如果节点被隐藏，则打印一条消息并保存图表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **获取或设置组织结构图布局**

对于使用组织结构图布局的 SmartArt 图表，[SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) 和 [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) 定义子节点在父节点下的排列方式。例如，您可以根据所选的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) 将子节点挂在左侧、右侧或两侧。

以下示例创建一个组织结构图，并将第一个节点的布局设置为 [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 值。零基索引 `0` 选择第一个顶层节点；其子节点使用所选的排列方式。随后保存修改后的演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **创建图片组织结构图**

图片组织结构图是一种 SmartArt 布局，专为包含图像占位符的层级图表设计。在将 SmartArt 对象添加到幻灯片时，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 值。此示例保存了带有图像占位符的图表，但未用图像填充这些占位符。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **将旧版图表转换为形状组**

在现代化现有演示文稿时，可能需要更新最初在 PowerPoint 97–2003 中创建的组织结构图。Aspose.Slides 将这些旧版图表表示为 [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) 对象。使用 [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) 将图表转换为形状组，以便编辑各个可视元素。有关详细信息，请参阅 [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/)。

转换会向形状集合中添加一个新组，而不会删除原始图表。转换成功后，使用 [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) 删除原始图表，以避免重复内容。将旧版图表收集到列表中再进行转换，以防止在添加和删除形状时中断迭代。

以下示例打开一个演示文稿，遍历每张幻灯片，将图表转换为形状组，并将更新后的演示文稿另存为 PPTX。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

保存的演示文稿在转换后的旧版图表位置包含可编辑的形状组，不会保留原始图表。使用 PowerPoint 打开 PPTX，可编辑每个组内的各个元素，如文本、填充或位置。

## **常见问题**

**SmartArt 是否支持 RTL 语言的镜像或反转？**

是的。当所选 SmartArt 布局支持反转时，[SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) 方法会将图表方向从从左到右切换为从右到左，或反向切换。

**如何在保留格式的情况下将 SmartArt 复制到同一幻灯片或其他演示文稿？**

您可以 [克隆 SmartArt 形状](/slides/zh/python-java/shape-manipulations/) 使用 [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) 或 [克隆整张幻灯片](/slides/zh/python-java/clone-slides/) 包含 SmartArt 的幻灯片。这两种方法都保留尺寸、位置和格式。

**如何将 SmartArt 渲染为栅格图像以进行预览或网页导出？**

[渲染幻灯片](/slides/zh/python-java/convert-powerpoint-to-png/) 或将整个演示文稿导出为 PNG 或 JPEG。SmartArt 会作为幻灯片的一部分被渲染。

**如果幻灯片上有多个 SmartArt 对象，如何找到特定的对象？**

使用 [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) 或 [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) 为 SmartArt 形状分配独特的替代文本或名称，在 [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) 中搜索该值，然后检查匹配的形状是否为 [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/)。