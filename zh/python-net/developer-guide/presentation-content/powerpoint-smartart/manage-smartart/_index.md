---
title: 使用 Python 在 PowerPoint 演示文稿中管理 SmartArt
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
description: "通过 .NET 使用 Aspose.Slides for Python 学习构建和编辑 PowerPoint SmartArt，提供清晰的代码示例，加快幻灯片设计和自动化。"
---

## **概述**

本指南展示了如何在 Aspose.Slides for Python 中创建和操作 SmartArt。您将学习如何从 SmartArt 中提取文本（包括节点形状内部的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 内容），向幻灯片添加 SmartArt 并切换其布局，检测并处理隐藏节点，配置组织结构图布局，以及构建图片组织结构图——所有这些都通过简洁、可复制粘贴的 Python 示例实现，这些示例打开一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)，处理幻灯片和 SmartArt 节点，并将结果保存为 PPTX。

## **从 SmartArt 获取文本**

`text_frame` 属性（位于 [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/)）允许您检索 SmartArt 形状中的所有文本——不仅是节点中包含的文本。以下示例代码展示了如何从 SmartArt 节点获取文本。
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
2. 通过索引获取幻灯片的引用。  
3. 添加一个布局为 `BASIC_BLOCK_LIST` 的 SmartArt 形状。  
4. 将其布局更改为 `BASIC_PROCESS`。  
5. 将演示文稿保存为 PPTX 文件。  
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加一个布局为 BASIC_BLOCK_LIST 的 SmartArt 形状。
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # 将布局类型更改为 BASIC_PROCESS。
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # 保存演示文稿。
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```


## **检查 SmartArt 的隐藏属性**

`SmartArtNode.is_hidden` 属性在节点在数据模型中被隐藏时返回 `True`。要检查 SmartArt 节点是否隐藏，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 添加一个布局为 `RADIAL_CYCLE` 的 SmartArt 形状。  
3. 向 SmartArt 添加一个节点。  
4. 检查 `is_hidden` 属性。  
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

`SmartArtNode.organization_chart_layout` 属性获取或设置与当前节点关联的组织结构图类型。要获取或设置组织结构图类型，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 向幻灯片添加一个 SmartArt 形状。  
3. 获取或设置组织结构图类型。  
4. 将演示文稿保存为 PPTX 文件。  
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 添加一个布局为 ORGANIZATION_CHART 的 SmartArt 形状。
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # 设置组织结构图类型。
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # 保存演示文稿。
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```


## **创建图片组织结构图**

Aspose.Slides for Python 提供了简便的 API，可轻松创建图片组织结构图。要在幻灯片上创建图表，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加具有所需类型默认数据的图表。  
4. 将修改后的演示文稿保存为 PPTX 文件。  
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**SmartArt 是否支持 RTL 语言的镜像/反转？**

是的。如果所选的 SmartArt 类型支持反转，[is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) 属性会切换图表方向（LTR/RTL）。

**如何在保持格式的情况下将 SmartArt 复制到同一幻灯片或另一个演示文稿？**

您可以通过形状集合使用 [克隆 SmartArt 形状](/slides/zh/python-net/shape-manipulations/)（[ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)）或通过 [克隆整个幻灯片](/slides/zh/python-net/clone-slides/) 来克隆包含该形状的整个幻灯片。这两种方法都能保留大小、位置和样式。

**如何将 SmartArt 渲染为光栅图像以进行预览或 Web 导出？**

您可以通过将 [渲染幻灯片](/slides/zh/python-net/convert-powerpoint-to-png/)（或整个演示文稿）转换为 PNG/JPEG 的 API 将 SmartArt 渲染为光栅图像——SmartArt 将作为幻灯片的一部分被绘制。

**如果幻灯片上有多个 SmartArt，如何以编程方式选择特定的 SmartArt？**

常见做法是使用 [替代文本](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/)（Alt Text）或 [名称](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/)，在 [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) 中通过该属性搜索形状，然后检查其类型以确认是 [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)。文档描述了查找和操作形状的典型技术。