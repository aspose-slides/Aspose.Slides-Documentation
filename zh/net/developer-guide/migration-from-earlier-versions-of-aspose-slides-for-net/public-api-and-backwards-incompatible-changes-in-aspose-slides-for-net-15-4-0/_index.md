---
title: Aspose.Slides for .NET 15.4.0 中的公共 API 及向后不兼容的更改
linktitle: Aspose.Slides for .NET 15.4.0
type: docs
weight: 150
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
  - 迁移
  - 旧版代码
  - 现代代码
  - 传统方法
  - 现代方法
  - PowerPoint
  - OpenDocument
  - 演示文稿
  - .NET
  - C#
  - Aspose.Slides
description: "审阅 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，平稳迁移您的 PowerPoint PPT、PPTX 和 ODP 演示解决方案。"
---

{{% alert color="primary" %}} 

此页面列出所有已[added](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/)或已[removed](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/)的类、方法、属性等，以及 Aspose.Slides for .NET 15.4.0 API 引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **已添加枚举 OrganizationChartLayoutType**
Aspose.Slides.SmartArt.OrganizationChartLayoutType 枚举表示组织结构图中子节点的格式类型。
#### **已添加方法 IBulletFormat.ApplyDefaultParagraphIndentsShifts**
Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts 方法在启用项目符号时（类似 PowerPoint 在启用段落项目符号/编号时的行为），为有效的段落缩进和左边距设置默认的非零偏移。如果禁用项目符号，则仅重置段落缩进和左边距（类似 PowerPoint 在禁用段落项目符号/编号时的行为）。

请参见示例[here](/slides/zh/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx)：
#### **已添加方法 IConnector.Reroute**
Aspose.Slides.IConnector.Reroute 方法重新路由连接线，使其在所连接的形状之间走最短路径。为实现此目的，Reroute() 方法可能会更改 StartShapeConnectionSiteIndex 和 EndShapeConnectionSiteIndex。

``` csharp

 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  connector.Reroute();

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **已添加方法 IPresentation.GetSlideById**
Aspose.Slides.IPresentation.GetSlideById(System.UInt32) 方法根据幻灯片 ID 返回 Slide、MasterSlide 或 LayoutSlide。

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **已添加属性 IShape.ConnectionSiteCount**
Aspose.Slides.IShape.ConnectionSiteCount 属性返回形状上的连接点数量。

``` csharp

 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **已添加属性 ISmartArt.IsReversed**
Aspose.Slides.SmartArt.ISmartArt.IsReversed 属性用于获取或设置 SmartArt 图表相对于左到右 (LTR) 或右到左 (RTL) 的状态（如果图表支持翻转）。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **已添加属性 ISmartArt.Nodes**
Aspose.Slides.SmartArt.ISmartArt.Nodes 属性返回 SmartArt 对象中根节点的集合。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // 选择第二个根节点

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **已添加属性 ISmartArtNode.IsHidden**
Aspose.Slides.SmartArt.ISmartArtNode.IsHidden 属性在该节点在数据模型中为隐藏节点时返回 true。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; // returns true

  if(hidden)

  {

    //do some actions or notifications

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **已添加属性 ISmartArtNode.OrganizationChartLayout**
Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout 属性用于获取或设置与当前节点关联的组织结构图类型。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **已添加属性 ISmartArt.Layout 的 set 方法**
Aspose.Slides.SmartArt.ISmartArt.Layout 属性的 set 方法已添加，可更改现有图表的布局类型。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **次要 API 更改**
**以下是次要 API 更改的列表：**

| Enum Aspose.Slides.BevelColorMode | 已删除，未使用的枚举 |
| :- | :- |
| Property ThreeDFormatEffectiveData.BevelColorMode | 已删除，未使用的属性 |
| Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent | 已添加 |
| Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent | 已删除 |
| Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle | 已删除，标记为过时 |