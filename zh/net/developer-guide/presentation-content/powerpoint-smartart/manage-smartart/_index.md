---
title: 管理 SmartArt
type: docs
weight: 10
url: /zh/net/manage-smartart/
keywords: "SmartArt, SmartArt 文本, 组织类型图表, 图片组织图表, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中使用 PowerPoint 演示文稿中的 SmartArt 和组织类型图表"
---

## **从 SmartArt 获取文本**
现在 ISmartArtShape 接口和 SmartArtShape 类分别增加了 TextFrame 属性。这个属性允许您从 SmartArt 中获取所有文本，即使它不仅仅包含节点文本。以下示例代码将帮助您从 SmartArt 节点中获取文本。

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
为了更改 SmartArt 的布局类型。请按照以下步骤操作：

- 创建一个 `Presentation` 类的实例。
- 通过索引获取幻灯片的引用。
- 添加 SmartArt 基础块列表。
- 将 LayoutType 更改为基础流程。
- 将演示文稿写入 PPTX 文件。
  在下面的示例中，我们在两个形状之间添加了连接器。

```c#
using (Presentation presentation = new Presentation())
{
    // 添加 SmartArt 基础流程 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // 将 LayoutType 更改为基础流程
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // 保存演示文稿
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```



## **检查 SmartArt 的隐藏属性**
请注意，方法 com.aspose.slides.ISmartArtNode.isHidden() 如果该节点是数据模型中的隐藏节点，则返回 true。为了检查 SmartArt 中任何节点的隐藏属性。请按照以下步骤操作：

- 创建一个 `Presentation` 类的实例。
- 添加 SmartArt 循环。
- 在 SmartArt 上添加节点。
- 检查 isHidden 属性。
- 将演示文稿写入 PPTX 文件。

在下面的示例中，我们在两个形状之间添加了连接器。

```c#
using (Presentation presentation = new Presentation())
{
    // 添加 SmartArt 基础流程 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // 在 SmartArt 上添加节点 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // 检查 isHidden 属性
    bool hidden = node.IsHidden; // 返回 true

    if (hidden)
    {
        // 执行一些操作或通知
    }
    // 保存演示文稿
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```



## **获取或设置组织图表类型**
方法 com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) 允许获取或设置与当前节点关联的组织图表类型。为了获取或设置组织图表类型。请按照以下步骤操作：

- 创建一个 `Presentation` 类的实例。
- 在幻灯片上添加 SmartArt。
- 获取或设置组织图表类型。
- 将演示文稿写入 PPTX 文件。
  在下面的示例中，我们在两个形状之间添加了连接器。

```c#
using (Presentation presentation = new Presentation())
{
    // 添加 SmartArt 基础流程 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // 获取或设置组织图表类型 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // 保存演示文稿
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```




## **创建图片组织图表**
Aspose.Slides for .NET 提供了一个简单的 API，方便地创建图片组织图表。要在幻灯片上创建图表：

1. 创建一个 `Presentation` 类的实例。
1. 通过索引获得幻灯片的引用。
1. 添加一个带有默认数据和所需类型（ChartType.PictureOrganizationChart）的图表。
1. 将修改后的演示文稿写入 PPTX 文件。

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