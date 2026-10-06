---
title: 使用 Python 管理 PowerPoint 演示文稿中的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh/python-net/manage-smartart/
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
description: "学习使用 Aspose.Slides for Python via .NET 构建和编辑 PowerPoint SmartArt，提供简洁的代码示例，加快幻灯片设计和自动化。"
---
## **概述**

SmartArt 是一种由节点、节点形状和布局组成的 PowerPoint 图表。使用 Aspose.Slides for Python via .NET，您可以创建 SmartArt，从其节点读取文本，更改其布局，检查隐藏节点，配置组织结构图布局，并创建图片组织结构图。

## **获取 SmartArt 对象的文本**

SmartArt 节点可以包含一个或多个形状。要读取节点形状中的文本，遍历 [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/)，然后读取由 [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/) 返回的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。  

示例要求演示文稿至少包含一张幻灯片，并且该幻灯片的第一个形状是 SmartArt 对象。它会将每个可用的文本框打印到控制台。

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **更改 SmartArt 对象的布局类型**

SmartArt 布局控制节点的排列和连接方式。以下示例使用 [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` 值创建一个 SmartArt 对象，将其更改为 `BASIC_PROCESS` 值，并保存演示文稿。传递给 [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) 的位置和大小以点为单位。设置 [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) 以更改布局。

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **检查 SmartArt 节点是否隐藏**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) 指示该节点在 SmartArt 数据模型中是否隐藏。即使所选布局未将它们显示为可见的图表元素，隐藏节点仍可能存在于结构中。  

以下示例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` 值的 SmartArt 对象添加一个节点，并检查该添加节点的隐藏状态。如果节点是隐藏的，它会打印一条消息并保存图表。

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **获取或设置组织结构图布局**

对于使用组织结构图布局的 SmartArt 图表，[SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) 定义子节点在父节点下的排列方式。例如，您可以根据所选的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) 将子节点挂在左侧、右侧或两侧。  

以下示例创建一个组织结构图，并将第一个节点的布局设置为 [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` 值。零基索引 `0` 选择第一个顶层节点；其子节点使用所选的排列方式。然后保存修改后的演示文稿。

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **创建图片组织结构图**

图片组织结构图是一种针对包含图像占位符的层次结构图设计的 SmartArt 布局。在向幻灯片添加 SmartArt 对象时，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` 值。此示例保存了带有图像占位符的图表，但不向占位符填充图像。

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **将旧版图表转换为形状组**

在现代化现有演示文稿时，您可能需要更新最初在 PowerPoint 97–2003 中创建的组织结构图。Aspose.Slides 将这些旧版图表表示为 [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) 对象。使用 [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) 将图表转换为形状组，以便编辑各个可视元素。有关详细信息，请参阅 [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/)。  

转换会向形状集合中添加一个新组，而不会删除原始图表。转换成功后，使用 [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) 删除原始图表，以避免重复内容。在转换之前将旧版图表收集到列表中，以免在添加和删除形状时打乱迭代。  

以下示例打开一个演示文稿，遍历每张幻灯片，将图表转换为形状组，并将更新后的演示文稿另存为 PPTX。

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

保存的演示文稿在已转换的旧版图表位置包含可编辑的形状组，并且不再保留原始图表。使用 PowerPoint 打开 PPTX，编辑每个组内的各个元素，例如文本、填充或位置。

## **常见问题**

**SmartArt 是否支持针对 RTL 语言的镜像或反转？**  
是的。当所选 SmartArt 布局支持反转时，[SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) 属性可将图表方向从从左到右切换为从右到左，或反之。

**如何在保留格式的情况下将 SmartArt 复制到同一幻灯片或另一个演示文稿？**  
您可以使用 [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) [克隆 SmartArt 形状](/slides/zh/python-net/shape-manipulations/) 或者使用 [克隆整个幻灯片](/slides/zh/python-net/clone-slides/) 来克隆包含 SmartArt 的整个幻灯片。这两种方法都能保留大小、位置和格式。

**如何将 SmartArt 渲染为光栅图像以进行预览或网页导出？**  
[渲染幻灯片](/slides/zh/python-net/convert-powerpoint-to-png/) 或将整个演示文稿渲染为 PNG 或 JPEG。SmartArt 作为幻灯片的一部分进行渲染。

**如果幻灯片上有多个 SmartArt 对象，如何找到特定的对象？**  
在 SmartArt 形状上设置唯一的 [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) 或 [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) 值，然后在 [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) 中搜索该值，并检查匹配的形状是否为 [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)。