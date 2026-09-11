---
title: 在 PowerPoint 演示文稿中使用 Python 管理 SmartArt
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
description: "了解如何使用 Aspose.Slides for Python via Java 构建和编辑 PowerPoint SmartArt，提供清晰的代码示例，加快幻灯片设计和自动化。"
---
## **概述**

SmartArt 是由节点、节点形状和布局构成的 PowerPoint 图表。使用 Aspose.Slides for Python via Java，您可以创建 SmartArt、读取其节点中的文本、更改其布局、检查隐藏节点、配置组织结构图布局以及创建图片组织结构图。

## **获取 SmartArt 对象的文本**

SmartArt 节点可以包含一个或多个形状。要读取可见文本，请遍历 [SmartArt.getAllNodes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartart/#getAllNodes)，然后读取由 [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartartshape/#getTextFrame) 返回的 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/)。

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

SmartArt 布局决定节点的排列和连接方式。以下示例创建了一个使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList` 值的 SmartArt 对象，将其更改为 `BasicProcess` 值，并保存演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **检查 SmartArt 节点是否隐藏**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartartnode/#isHidden) 表示该节点在 SmartArt 数据模型中是否被隐藏。即使所选布局未将其显示为可见的图表元素，隐藏节点仍可能存在于结构中。

以下示例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` 值的 SmartArt 对象添加一个节点，并检查该节点的隐藏状态。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **获取或设置组织结构图布局**

对于使用组织结构图布局的 SmartArt 图表，[SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) 和 [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) 定义子节点在父节点下的排列方式。例如，您可以根据所选的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/organizationchartlayouttype/) 将子节点挂在左侧、右侧或两侧。

以下示例创建了一个组织结构图，并将第一个节点的布局设置为 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **创建图片组织结构图**

图片组织结构图是一种 SmartArt 布局，专为包含图像占位符的层次结构图设计。在将 SmartArt 对象添加到幻灯片时，请使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**SmartArt 是否支持 RTL 语言的镜像或反转？**

是的。当所选 SmartArt 布局支持反转时，[SmartArt.setReversed](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartart/#setReversed) 方法会将图表方向从从左到右切换为从右到左，或反之。

**如何在保持格式的情况下将 SmartArt 复制到同一幻灯片或另一个演示文稿？**

您可以使用 [ShapeCollection.addClone](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addClone) 克隆 [克隆 SmartArt 形状](/slides/zh/python-java/shape-manipulations/)，或者克隆包含 SmartArt 的整个幻灯片 [克隆整个幻灯片](/slides/zh/python-java/clone-slides/)。两种方法都能保留大小、位置和格式。

**如何将 SmartArt 渲染为栅格图像以进行预览或 Web 导出？**

[渲染幻灯片](/slides/zh/python-java/convert-powerpoint-to-png/) 或将整个演示文稿渲染为 PNG 或 JPEG。SmartArt 作为幻灯片的一部分进行渲染。

**如果幻灯片上有多个 SmartArt 对象，如何查找特定的对象？**

在 SmartArt 形状上设置唯一的 [Shape.getAlternativeText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getAlternativeText) 或 [Shape.getName](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getName) 值，在 [BaseSlide.getShapes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseslide/#getShapes) 中搜索该值，然后确认匹配的形状是一个 [SmartArt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartart/)。