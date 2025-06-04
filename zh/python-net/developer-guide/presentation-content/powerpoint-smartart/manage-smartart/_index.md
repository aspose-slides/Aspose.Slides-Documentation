---
title: 在 Python 中管理 PowerPoint 演示文稿中的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh/python-net/manage-smartart/
keywords:
- SmartArt
- 从 SmartArt 获取文本
- 布局类型
- 隐藏属性
- 组织结构图
- 图片组织结构图
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "学习如何使用适用于 .NET 的 Aspose.Slides for Python 构建和编辑 PowerPoint SmartArt，通过清晰的代码示例加速幻灯片设计与自动化。"
---

## **获取SmartArt中的文本**
现在，ISmartArtShape接口和SmartArtShape类分别添加了TextFrame属性。此属性允许您获取SmartArt中的所有文本，即使它并不仅仅是节点文本。以下示例代码将帮助您从SmartArt节点获取文本。

```py
import aspose.slides as slides

with slides.Presentation(path + "SmartArt.pptx") as pres:
    slide = pres.slides[0]
    smartArt = slide.shapes[0]

    for smartArtNode in smartArt.all_nodes:
        for nodeShape in smartArtNode.shapes:
            if nodeShape.text_frame != None:
                print(nodeShape.text_frame.text)
```



## **更改SmartArt的布局类型**
要更改SmartArt的布局类型，请按照以下步骤操作：

- 创建`Presentation`类的实例。
- 使用其索引获取幻灯片的引用。
- 添加SmartArt基础块列表。
- 将LayoutType更改为基础流程。
- 将演示文稿写入PPTX文件。
  在下面给出的示例中，我们在两个形状之间添加了连接器。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # 添加SmartArt基础流程 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # 将LayoutType更改为基础流程
    smart.layout = art.SmartArtLayoutType.BASIC_PROCESS
    # 保存演示文稿
    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```



## **检查SmartArt的隐藏属性**
请注意，方法com.aspose.slides.ISmartArtNode.isHidden()如果该节点在数据模型中是隐藏节点，则返回true。要检查SmartArt任何节点的隐藏属性，请按照以下步骤操作：

- 创建`Presentation`类的实例。
- 添加SmartArt径向循环。
- 在SmartArt上添加节点。
- 检查isHidden属性。
- 将演示文稿写入PPTX文件。

在下面给出的示例中，我们在两个形状之间添加了连接器。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # 添加SmartArt基础流程 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.RADIAL_CYCLE)
    # 在SmartArt上添加节点 
    node = smart.all_nodes.add_node()
    # 检查isHidden属性
    if node.is_hidden:
        print("隐藏")
        # 执行一些操作或通知
    # 保存演示文稿
    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```



## **获取或设置组织图表类型**
方法com.aspose.slides.ISmartArtNode.getOrganizationChartLayout()和setOrganizationChartLayout(int)允许获取或设置与当前节点关联的组织图表类型。要获取或设置组织图表类型，请按照以下步骤操作：

- 创建`Presentation`类的实例。
- 在幻灯片上添加SmartArt。
- 获取或设置组织图表类型。
- 将演示文稿写入PPTX文件。
  在下面给出的示例中，我们在两个形状之间添加了连接器。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # 添加SmartArt基础流程 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.ORGANIZATION_CHART)
    # 获取或设置组织图表类型 
    smart.nodes[0].organization_chart_layout = art.OrganizationChartLayoutType.LEFT_HANGING
    # 保存演示文稿
    presentation.save("OrganizeChartLayoutType_out.pptx", slides.export.SaveFormat.PPTX)
```




## **创建图片组织图表**
Aspose.Slides for Python via .NET提供了一种简单的API，用于轻松创建PictureOrganization图表。要在幻灯片上创建图表：

1. 创建`Presentation`类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加带有默认数据的图表，以及所需的类型（ChartType.PictureOrganizationChart）。
1. 将修改后的演示文稿写入PPTX文件。

以下代码用于创建图表。

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as pres:
    smartArt = pres.slides[0].shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    pres.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```