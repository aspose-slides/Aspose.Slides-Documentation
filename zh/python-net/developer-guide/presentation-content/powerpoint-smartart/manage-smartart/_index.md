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
description: "通过 Aspose.Slides for Python via .NET 的清晰代码示例，学习构建和编辑 PowerPoint SmartArt，以加快幻灯片设计和自动化。"
---

## **概述**

本指南展示了如何在 Aspose.Slides for Python 中创建和操作 SmartArt。您将学习如何从 SmartArt（包括节点形状内部的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 内容）提取文本、向幻灯片添加 SmartArt 并切换其布局、检测并处理隐藏节点、配置组织结构图布局，以及创建图片组织结构图——所有示例均为简洁、可直接复制粘贴的 Python 代码，打开一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)，操作幻灯片和 SmartArt 节点，并将结果保存为 PPTX。

## **从 SmartArt 获取文本**

[SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) 的 `text_frame` 属性允许您检索 SmartArt 形状中的所有文本——不仅仅是节点中包含的文本。以下示例代码演示了如何获取 SmartArt 节点的文本。

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
3. 使用 `BASIC_BLOCK_LIST` 布局添加 SmartArt 形状。  
4. 将其布局更改为 `BASIC_PROCESS`。  
5. 将演示文稿另存为 PPTX 文件。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the BASIC_BLOCK_LIST layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Change the layout type to BASIC_PROCESS.
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # Save the presentation.
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **检查 SmartArt 的隐藏属性**

`SmartArtNode.is_hidden` 属性在节点在数据模型中被隐藏时返回 `True`。要检查 SmartArt 节点是否隐藏，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 使用 `RADIAL_CYCLE` 布局添加 SmartArt 形状。  
3. 向 SmartArt 添加一个节点。  
4. 检查 `is_hidden` 属性。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the RADIAL_CYCLE layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # Add a node to the SmartArt.
    node = smart.all_nodes.add_node()

    # Check the is_hidden property.
    if node.is_hidden:
        print("The node is hidden.")
```

## **获取或设置组织结构图类型**

`SmartArtNode.organization_chart_layout` 属性获取或设置当前节点关联的组织结构图类型。要获取或设置组织结构图类型，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 向幻灯片添加 SmartArt 形状。  
3. 获取或设置组织结构图类型。  
4. 将演示文稿另存为 PPTX 文件。

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add a SmartArt shape with the ORGANIZATION_CHART layout.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # Set the organization chart type.
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # Save the presentation.
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **创建图片组织结构图**

Aspose.Slides for Python 提供了简洁的 API，轻松创建图片组织结构图。要在幻灯片上创建图表，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 使用所需类型的默认数据添加图表。  
4. 将修改后的演示文稿另存为 PPTX 文件。

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

是的。若所选 SmartArt 类型支持反转，`[is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/)` 属性可切换图表方向（LTR/RTL）。

**如何在同一幻灯片或另一个演示文稿中复制 SmartArt 并保留格式？**

您可以通过形状集合使用 [克隆 SmartArt 形状](/slides/zh/python-net/shape-manipulations/)（`ShapeCollection.add_clone`）或 [克隆包含该形状的整张幻灯片](/slides/zh/python-net/clone-slides/)。两种方法都会保留大小、位置和样式。

**如何将 SmartArt 渲染为光栅图像以进行预览或网页导出？**

通过 API 将 [幻灯片](/slides/zh/python-net/convert-powerpoint-to-png/)（或整个演示文稿）转换为 PNG/JPEG，即可得到包含 SmartArt 的图像。

**如果幻灯片上有多个 SmartArt，如何通过代码选中特定的一个？**

常用做法是为 SmartArt 设置 [替代文本](/slides/zh/python-net/aspose.slides.smartart/smartart/alternative_text/)（Alt Text）或 [名称](/slides/zh/python-net/aspose.slides.smartart/smartart/name/)，然后在 `Slide.shapes` 中按该属性搜索形状，再检查类型确认是 [SmartArt](/slides/zh/python-net/aspose.slides.smartart/smartart/)。文档中描述了常见的查找和操作形状的技巧。