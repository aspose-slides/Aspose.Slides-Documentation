---
title: Aspose.Slides for .NET 15.4.0 的公共 API 及不向后兼容更改
linktitle: Aspose.Slides for .NET 15.4.0
type: docs
weight: 150
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 旧版方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出所有[已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/)或[已移除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/)的类、方法、属性等，以及在 Aspose.Slides for .NET 15.4.0 API 中引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **Enum OrganizationChartLayoutType 已添加**
Aspose.Slides.SmartArt.OrganizationChartLayoutType 枚举表示组织结构图中子节点的格式类型。
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts 已添加**
Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts 方法在启用项目符号时（如 PowerPoint 在启用段落项目符号/编号时的行为），为有效段落的缩进和左边距设置默认的非零偏移。若禁用项目符号，则仅重置段落的缩进和左边距（如 PowerPoint 在禁用段落项目符号/编号时的行为）。

请参阅示例[此处](/slides/zh/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx)：
#### **Method IConnector.Reroute 已添加**
Aspose.Slides.IConnector.Reroute 方法重新路由连接线，使其在连接的形状之间采取最短路径。为此，Reroute() 方法可能会更改 StartShapeConnectionSiteIndex 和 EndShapeConnectionSiteIndex。

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
#### **Method IPresentation.GetSlideById 已添加**
Aspose.Slides.IPresentation.GetSlideById(System.UInt32) 方法根据幻灯片 ID 返回 Slide、MasterSlide 或 LayoutSlide。

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Property IShape.ConnectionSiteCount 已添加**
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
#### **Property ISmartArt.IsReversed 已添加**
Aspose.Slides.SmartArt.ISmartArt.IsReversed 属性用于获取或设置 SmartArt 图表相对于左到右 (LTR) 或右到左 (RTL) 的状态（前提是图表支持翻转）。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.Nodes 已添加**
Aspose.Slides.SmartArt.ISmartArt.Nodes 属性返回 SmartArt 对象中根节点的集合。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // select second root node

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.IsHidden 已添加**
Aspose.Slides.SmartArt.ISmartArtNode.IsHidden 属性如果该节点在数据模型中是隐藏节点，则返回 true。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //returns true

  if(hidden)

  {

    //do some actions or notifications

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.OrganizationChartLayout 已添加**
Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout 属性用于获取或设置与当前节点关联的组织结构图类型。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Set Method for Property ISmartArt.Layout 已添加**
Aspose.Slides.SmartArt.ISmartArt.Layout 属性的 set 方法已添加。它允许更改现有图表的布局类型。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Minor API Changes**
**以下是 Minor API 更改的列表:**

|Enum Aspose.Slides.BevelColorMode|已删除，未使用的枚举|
|:-|:-|
|Property ThreeDFormatEffectiveData.BevelColorMode|已删除，未使用的属性|
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent|已添加|
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent|已删除|
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle|已删除，已废弃|