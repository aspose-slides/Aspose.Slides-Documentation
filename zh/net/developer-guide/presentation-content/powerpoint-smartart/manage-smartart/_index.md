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
description: "了解如何使用 Aspose.Slides for .NET 通过清晰的 C# 代码示例构建和编辑 PowerPoint SmartArt，从而加快幻灯片设计和自动化。"
---
## **概述**

SmartArt 是由节点、节点形状和布局组成的 PowerPoint 图表。使用 Aspose.Slides for .NET，您可以创建 SmartArt、读取其节点中的文本、更改其布局、检查隐藏节点、配置组织结构图布局以及创建图片组织结构图。

## **获取 SmartArt 对象的文本**

SmartArt 节点可以包含一个或多个形状。要读取节点形状中的文本，请遍历 [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/)，然后读取由 [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/) 返回的 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)。

此示例需要一个至少包含一张幻灯片且在该幻灯片上第一个形状为 SmartArt 对象的演示文稿。它会将每个可用的文本框打印到控制台。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **更改 SmartArt 对象的布局类型**

SmartArt 布局控制节点的排列和连接方式。下面的示例使用 [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` 值创建一个 SmartArt 对象，将其更改为 `BasicProcess` 值，并保存演示文稿。传递给 [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) 的位置和大小以点为单位。设置 [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) 可更改布局。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **检查 SmartArt 节点是否隐藏**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) 指示节点在 SmartArt 数据模型中是否被隐藏。即使所选布局未将其显示为可见的图表元素，隐藏节点仍可能存在于结构中。

下面的示例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` 值的 SmartArt 对象添加一个节点，并检查所添加节点的隐藏状态。如果节点被隐藏，则打印一条消息并保存图表。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **获取或设置组织结构图布局**

对于使用组织结构图布局的 SmartArt 图表，[ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) 定义子节点在父节点下的排列方式。例如，您可以根据所选的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) 将子节点挂靠在左侧、右侧或两侧。

下面的示例创建一个组织结构图，并将第一个节点的布局设置为 [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` 值。零基索引 `0` 选中第一个顶层节点；其子节点使用所选的排列方式。随后保存修改后的演示文稿。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **创建图片组织结构图**

图片组织结构图是一种为包含图像占位符的层级图表设计的 SmartArt 布局。向幻灯片添加 SmartArt 对象时使用 [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` 值。本示例保存了带有图像占位符的图表，但不会向占位符中填充图像。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **将旧版图表转换为形状组**

在对现有演示文稿进行现代化改造时，可能需要更新最初在 PowerPoint 97–2003 中创建的组织结构图。Aspose.Slides 将这些旧版图表表示为 [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/) 对象。使用 [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) 可将图表转换为形状组，以便编辑各个可视元素。有关详细信息，请参阅 [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/)。

转换会在形状集合中添加一个新组，而不会删除原始图表。转换成功后，使用 [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) 删除原始图表，以避免重复内容。在转换之前先将旧版图表收集到数组中，以免在添加和删除形状时中断迭代。

下面的示例打开一个演示文稿，遍历每张幻灯片，将图表转换为形状组，并将更新后的演示文稿保存为 PPTX。

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

保存的演示文稿在原始旧版图表位置包含可编辑的形状组，不再保留原始图表。打开 PPTX 在 PowerPoint 中即可编辑每个组内的单个元素，如文本、填充或位置。

## **FAQ**

**SmartArt 是否支持 RTL 语言的镜像或翻转？**

是的。[IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) 属性在所选 SmartArt 布局支持翻转时，可将图表方向从左到右切换为右到左，或反之。

**如何在保留格式的情况下将 SmartArt 复制到同一幻灯片或另一个演示文稿？**

您可以通过 [克隆 SmartArt 形状](/slides/zh/net/shape-manipulations/) 使用 [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)，或者通过 [克隆整张幻灯片](/slides/zh/net/clone-slides/) 复制包含 SmartArt 的整张幻灯片。两种方法都会保留大小、位置和格式。

**如何将 SmartArt 渲染为栅格图像以进行预览或网页导出？**

您可以 [将幻灯片渲染](/slides/zh/net/convert-powerpoint-to-png/) 或将整个演示文稿渲染为 PNG 或 JPEG。SmartArt 会作为幻灯片的一部分进行渲染。

**如果幻灯片上有多个 SmartArt 对象，如何找到特定的 SmartArt 对象？**

在 SmartArt 形状上设置唯一的 [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) 或 [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) 值，在 [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) 中搜索该值，然后检查匹配的形状是否为 [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/)。