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
description: "通过 Aspose.Slides for Python via .NET 的清晰代码示例，学习构建和编辑 PowerPoint SmartArt，快速实现幻灯片设计和自动化。"
---

## **概述**

本指南展示了如何在 Aspose.Slides for Python 中创建和操作 SmartArt。您将学习如何从 SmartArt（包括节点形状内部的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 内容）中提取文本，向幻灯片添加 SmartArt 并切换其布局，检测并处理隐藏节点，配置组织结构图布局，以及创建图片组织结构图——所有示例均为简洁、可直接复制粘贴的 Python 代码，能够打开一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)，对幻灯片和 SmartArt 节点进行操作，并将结果保存为 PPTX。

## **从 SmartArt 获取文本**

[SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) 的 `text_frame` 属性允许您检索 SmartArt 形状中的所有文本——不仅限于节点中的文本。下面的示例代码展示了如何从 SmartArt 节点获取文本。

```py
import aspose.slides as slides

with slides.Presentation("SmartArt.pptx") as presentation:
    slide = presentation.slides[0]
    smart_art = slide.shapes[0]

    for smart_art_node in smart_art.all_nodes:
        for node_shape in smart_art_node.shapes:
            if node_shape.text_frame is not None:
                print(node_shape.text_frame.text)
```

## **更改 SmartArt 布局类型**

要更改 SmartArt 布局类型，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 使用 `BASIC_BLOCK_LIST` 布局添加 SmartArt 形状。  
1. 将其布局更改为 `BASIC_PROCESS`。  
1. 将演示文稿保存为 PPTX 文件。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加具有 BASIC_BLOCK_LIST 布局的 SmartArt 形状。
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # 将布局类型更改为 BASIC_PROCESS。
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # 保存演示文稿。
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **检查 SmartArt 的隐藏属性**

`SmartArtNode.is_hidden` 属性在数据模型中节点被隐藏时返回 `True`。要检查 SmartArt 节点是否隐藏，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 使用 `RADIAL_CYCLE` 布局添加 SmartArt 形状。  
1. 向 SmartArt 添加一个节点。  
1. 检查 `is_hidden` 属性。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加具有 RADIAL_CYCLE 布局的 SmartArt 形状。
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # 向 SmartArt 添加一个节点。
    node = smart.all_nodes.add_node()

    # 检查 is_hidden 属性。
    if node.is_hidden:
        print("The node is hidden.")
```

## **获取或设置组织结构图类型**

`SmartArtNode.organization_chart_layout` 属性用于获取或设置当前节点关联的组织结构图类型。要获取或设置组织结构图类型，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 向幻灯片添加 SmartArt 形状。  
1. 获取或设置组织结构图类型。  
1. 将演示文稿保存为 PPTX 文件。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加具有 ORGANIZATION_CHART 布局的 SmartArt 形状。
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # 设置组织结构图类型。
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # 保存演示文稿。
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **创建图片组织结构图**

Aspose.Slides for Python 提供了简洁的 API，能够轻松创建图片组织结构图。要在幻灯片上创建此类图表，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 使用所需类型的默认数据添加图表。  
1. 将修改后的演示文稿保存为 PPTX 文件。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**SmartArt 是否支持 RTL 语言的镜像/反转？**

是的。`[is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/)` 属性在所选 SmartArt 类型支持反转时切换图表方向（LTR/RTL）。

**如何在同一幻灯片或其他演示文稿中复制 SmartArt 并保留格式？**

您可以通过形状集合的 **克隆** 方法 [clone the SmartArt shape](/slides/zh/python-net/shape-manipulations/)（`ShapeCollection.add_clone`）或 **克隆整个幻灯片**（/slides/python-net/clone-slides/）来实现，两种方式都会保留大小、位置和样式。

**如何将 SmartArt 渲染为栅格图像以供预览或 Web 导出？**

通过 API 将幻灯片（或整个演示文稿）[渲染为 PNG/JPEG](/slides/zh/python-net/convert-powerpoint-to-png/)，SmartArt 将作为幻灯片的一部分被绘制出来。

**如果幻灯片上有多个 SmartArt，如何以编程方式选中指定的一个？**

常用做法是使用 **替代文本**（Alt Text）或 **名称**（`alternative_text`、`name`），在 [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) 中搜索该属性，然后检查类型以确认它是 **SmartArt**（`SmartArt`）。文档中描述了查找和操作形状的典型技术。