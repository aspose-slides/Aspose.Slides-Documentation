---
title: 管理 SmartArt
type: docs
weight: 10
url: /zh/net/manage-smartart/
keywords: "SmartArt, SmartArt 文本, 组织类型图表, 图片组织图表, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中用于 PowerPoint 演示文稿的 SmartArt 和组织类型图表"
---

## **从 SmartArt 获取文本**
现在 TextFrame 属性已分别添加到 ISmartArtShape 接口和 SmartArtShape 类中。该属性允许您获取 SmartArt 中的所有文本，而不仅仅是节点文本。下面的示例代码将帮助您获取 SmartArt 节点的文本。
```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
	ISlide slide = pres.Slides[0];
	ISmartArt smartArt = (ISmartArt)slide.Shapes[0];

	ISmartArtNodeCollection smartArtNodes = smartArt.AllNodes;
	foreach (ISmartArtNode smartArtNode in smartArtNodes)
	{
		foreach (ISmartArtShape nodeShape in smartArtNode.Shapes)
		{
			if (nodeShape.TextFrame != null)
				Console.WriteLine(nodeShape.TextFrame.Text);
		}
	}
}
```


## **更改 SmartArt 的布局类型**
为了更改 SmartArt 的布局类型，请按照以下步骤操作：

- 创建 `Presentation` 类的实例。
- 使用索引获取幻灯片的引用。
- 添加 SmartArt BasicBlockList。
- 将 LayoutType 更改为 BasicProcess。
- 将演示文稿保存为 PPTX 文件。

在下面的示例中，我们在两个形状之间添加了连接线。
```c#
using (Presentation presentation = new Presentation())
{
    // 添加 SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // 将 LayoutType 更改为 BasicProcess
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // 保存演示文稿
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```


## **检查 SmartArt 的 Hidden 属性**
请注意，方法 com.aspose.slides.ISmartArtNode.isHidden() 如果此节点在数据模型中是隐藏节点，则返回 true。要检查 SmartArt 任意节点的 Hidden 属性，请按照以下步骤操作：

- 创建 `Presentation` 类的实例。
- 添加 SmartArt RadialCycle。
- 在 SmartArt 上添加节点。
- 检查 isHidden 属性。
- 将演示文稿保存为 PPTX 文件。

在下面的示例中，我们在两个形状之间添加了连接线。
```c#
using (Presentation presentation = new Presentation())
{
    // 添加 SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // 在 SmartArt 上添加节点 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // 检查 isHidden 属性
    bool hidden = node.IsHidden; // Returns true

    if (hidden)
    {
        // 执行一些操作或通知
    }
    // 保存演示文稿
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```


## **获取或设置组织结构图类型**
方法 com.aspose.slides.ISmartArtNode.getOrganizationChartLayout()、setOrganizationChartLayout(int) 允许获取或设置与当前节点关联的组织结构图类型。要获取或设置组织结构图类型，请按照以下步骤操作：

- 创建 `Presentation` 类的实例。
- 在幻灯片上添加 SmartArt。
- 获取或设置组织结构图类型。
- 将演示文稿保存为 PPTX 文件。

在下面的示例中，我们在两个形状之间添加了连接线。
```c#
using (Presentation presentation = new Presentation())
{
    // 添加 SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // 获取或设置组织结构图类型 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // 保存演示文稿
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```


## **创建图片组织结构图**
Aspose.Slides for .NET 提供了一个简单的 API，可轻松创建 PictureOrganization 图表。要在幻灯片上创建图表：

1. 创建 `Presentation` 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加具有默认数据并指定类型 (ChartType.PictureOrganizationChart) 的图表。
4. 将修改后的演示文稿写入 PPTX 文件。

以下代码用于创建图表。
```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		ISmartArt smartArt = pres.Slides[0].Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
		pres.Save("OrganizationChart.pptx", SaveFormat.Pptx);
	}			
}
```


## **常见问题**

**SmartArt 是否支持 RTL 语言的镜像/反转？**

是的。如果所选 SmartArt 类型支持反转，则 [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) 属性会切换图表方向（LTR/RTL）。

**如何在同一幻灯片或其他演示文稿中复制 SmartArt 并保留格式？**

您可以通过形状集合 [克隆 SmartArt 形状](/slides/zh/net/shape-manipulations/)（[ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)）或 [克隆整个幻灯片](/slides/zh/net/clone-slides/) 来复制 SmartArt。两种方法都能够保留大小、位置和样式。

**如何将 SmartArt 渲染为栅格图像以供预览或网页导出？**

您可以通过将幻灯片（或整个演示文稿）[渲染幻灯片](/slides/zh/net/convert-powerpoint-to-png/) 为 PNG/JPEG 的 API 将 SmartArt 渲染为栅格图像用于预览或 Web 导出——SmartArt 将作为幻灯片的一部分进行绘制。

**如果幻灯片上有多个 SmartArt，如何以编程方式选择特定的一个？**

常用做法是使用 [替代文本](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/)（Alt Text）或 [名称](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) 并在 [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) 中按该属性搜索形状，然后检查类型以确认它是 [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)。文档描述了查找和使用形状的典型技术。