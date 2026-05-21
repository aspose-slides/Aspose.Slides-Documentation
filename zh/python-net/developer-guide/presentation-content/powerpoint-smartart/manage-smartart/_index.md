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
description: "学习使用 Aspose.Slides for Python via .NET 构建和编辑 PowerPoint SmartArt，提供清晰的代码示例，加快幻灯片设计与自动化。"
---
## **概述**

SmartArt 是由节点、节点形状和布局组成的 PowerPoint 图表。使用 Aspose.Slides for Python via .NET，您可以创建 SmartArt，从其节点读取文本，更改其布局，检查隐藏节点，配置组织结构图布局，并创建图片组织结构图。

## **获取 SmartArt 对象的文本**

SmartArt 节点可以包含一个或多个形状。要读取可见文本，请遍历 [SmartArt.all_nodes](https://reference.aspose.com/slides/zh/python-net/aspose.slides.smartart/smartart/all_nodes/)，然后读取由 [SmartArtShape.text_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides.smartart/smartartshape/text_frame/) 返回的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **更改 SmartArt 对象的布局类型**

SmartArt 布局控制节点的排列和连接方式。下面的示例创建一个使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST` 值的 SmartArt 对象，将其更改为 `BASIC_PROCESS` 值，并保存演示文稿。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **检查 SmartArt 节点是否隐藏**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/zh/python-net/aspose.slides.smartart/smartartnode/is_hidden/) 指示节点在 SmartArt 数据模型中是否被隐藏。即使所选布局未将它们显示为可见的图表元素，隐藏节点仍可能存在于结构中。

下面的示例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` 值的 SmartArt 对象添加一个节点，并检查该节点的隐藏状态。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **获取或设置组织结构图布局**

对于使用组织结构图布局的 SmartArt 图表，[SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/zh/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) 定义子节点在父节点下的排列方式。例如，您可以根据所选的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/python-net/aspose.slides.smartart/organizationchartlayouttype/) 将子节点挂在左侧、右侧或两侧。

下面的示例创建一个组织结构图，并将第一个节点的布局设置为 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING` 值。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **创建图片组织结构图**

图片组织结构图是一种为包含图像占位符的层次结构图设计的 SmartArt 布局。在将 SmartArt 对象添加到幻灯片时，请使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` 值。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**SmartArt 支持 RTL 语言的镜像或反转吗？**

是的。当所选 SmartArt 布局支持反转时，[SmartArt.is_reversed](https://reference.aspose.com/slides/zh/python-net/aspose.slides.smartart/smartart/is_reversed/) 属性可以将图表方向从从左到右切换为从右到左，或恢复原状。

**如何在保留格式的情况下将 SmartArt 复制到同一幻灯片或其他演示文稿？**

您可以使用 [克隆 SmartArt 形状](/slides/zh/python-net/shape-manipulations/) 的 [ShapeCollection.add_clone](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_clone/) 方法，或使用 [克隆整个幻灯片](/slides/zh/python-net/clone-slides/) 的方式复制包含 SmartArt 的整张幻灯片。这两种方法都能保留大小、位置和格式。

**如何将 SmartArt 渲染为栅格图像以进行预览或 Web 导出？**

可以将幻灯片或整个演示文稿渲染为 PNG 或 JPEG，参考 [渲染幻灯片](/slides/zh/python-net/convert-powerpoint-to-png/)。SmartArt 将作为幻灯片的一部分进行渲染。

**如果幻灯片上有多个 SmartArt 对象，如何找到特定的对象？**

为 SmartArt 形状设置唯一的 [Shape.alternative_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/alternative_text/) 或 [Shape.name](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/name/) 值，在 [Slide.shapes](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/shapes/) 中搜索该值，然后确认匹配的形状是 [SmartArt](https://reference.aspose.com/slides/zh/python-net/aspose.slides.smartart/smartart/)。