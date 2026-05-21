---
title: 在 .NET 中管理 PowerPoint 演示文稿的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh/net/manage-smartart/
keywords:
- SmartArt
- SmartArt 文本
- 布局类型
- 隐藏属性
- 组织结构图
- 图片组织结构图
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "学习使用 Aspose.Slides for .NET，利用清晰的 C# 代码示例，快速构建和编辑 PowerPoint SmartArt，从而加快幻灯片设计和自动化。"
---
## **概述**

SmartArt 是由节点、节点形状和布局组成的 PowerPoint 图表。使用 Aspose.Slides for .NET，您可以创建 SmartArt、读取其节点中的文本、更改布局、检查隐藏节点、配置组织结构图布局以及创建图片组织结构图。

## **从 SmartArt 对象获取文本**

SmartArt 节点可以包含一个或多个形状。要读取可见文本，请遍历 [ISmartArt.AllNodes](https://reference.aspose.com/slides/zh/net/aspose.slides.smartart/ismartart/allnodes/)，然后读取由 [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides.smartart/ismartartshape/textframe/) 返回的 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/)。

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **更改 SmartArt 对象的布局类型**

SmartArt 布局决定节点的排列和连接方式。下面的示例创建一个使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` 值的 SmartArt 对象，将其更改为 `BasicProcess` 值，并保存演示文稿。

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **检查 SmartArt 节点是否隐藏**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/zh/net/aspose.slides.smartart/ismartartnode/ishidden/) 表示该节点在 SmartArt 数据模型中是否隐藏。即使所选布局未将其显示为可见图表元素，隐藏节点仍可能存在于结构中。

下面的示例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` 值的 SmartArt 对象添加一个节点，并检查该节点的隐藏状态。

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **获取或设置组织结构图布局**

对于使用组织结构图布局的 SmartArt 图表，[ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/zh/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) 定义子节点在父节点下的排列方式。例如，您可以根据所选的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/net/aspose.slides.smartart/organizationchartlayouttype/) 将子节点挂在左侧、右侧或两侧。

下面的示例创建一个组织结构图，并将第一个节点的布局设置为 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` 值。

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **创建图片组织结构图**

图片组织结构图是一种为包含图像占位符的层次结构图表设计的 SmartArt 布局。在将 SmartArt 对象添加到幻灯片时，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` 值。

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **常见问题**

**SmartArt 是否支持 RTL 语言的镜像或翻转？**

是的。当所选 SmartArt 布局支持翻转时，[IsReversed](https://reference.aspose.com/slides/zh/net/aspose.slides.smartart/smartart/isreversed/) 属性可以将图表方向从左到右切换为右到左，或反之。

**如何在同一幻灯片或另一个演示文稿中复制 SmartArt 并保留格式？**

您可以使用 [ShapeCollection.AddClone](https://reference.aspose.com/slides/zh/net/aspose.slides/shapecollection/addclone/) [克隆 SmartArt 形状](/slides/zh/net/shape-manipulations/)，或 [克隆包含 SmartArt 的整张幻灯片](/slides/zh/net/clone-slides/)。两种方法都能保留大小、位置和格式。

**如何将 SmartArt 渲染为栅格图像以进行预览或网页导出？**

[渲染幻灯片](/slides/zh/net/convert-powerpoint-to-png/) 或将整个演示文稿导出为 PNG 或 JPEG。SmartArt 会作为幻灯片的一部分进行渲染。

**如果幻灯片上有多个 SmartArt 对象，如何找到其中的特定对象？**

在 SmartArt 形状上设置唯一的 [AlternativeText](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/alternativetext/) 或 [Name](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/name/) 值，在 [Slide.Shapes](https://reference.aspose.com/slides/zh/net/aspose.slides/baseslide/shapes/) 中搜索该值，然后检查匹配的形状是否为 [ISmartArt](https://reference.aspose.com/slides/zh/net/aspose.slides.smartart/ismartart/)。