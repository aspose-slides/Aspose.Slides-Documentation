---
title: Aspose.Slides for .NET 15.4.0 中的公共 API 和不向后兼容的更改
type: docs
weight: 150
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for .NET 15.4.0 API 中[添加的](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/)或[移除的](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/)类、方法、属性等，以及其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **添加了枚举 OrganizationChartLayoutType**
Aspose.Slides.SmartArt.OrganizationChartLayoutType枚举表示在组织图中子节点的格式类型。
#### **添加了方法 IBulletFormat.ApplyDefaultParagraphIndentsShifts**
方法Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts在启用项目符号时设置有效段落缩进和左边距的默认非零偏移（类似于 PowerPoint 在启用段落项目符号/编号时的行为）。如果禁用项目符号，则仅重置段落缩进和左边距（类似于 PowerPoint 在禁用段落项目符号/编号时的行为）。

示例见[这里](/slides/zh/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **添加了方法 IConnector.Reroute**
方法Aspose.Slides.IConnector.Reroute重新路由连接器，以使其采取连接形状之间的最短路径。为此，Reroute()方法可能会更改StartShapeConnectionSiteIndex和EndShapeConnectionSiteIndex。

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
#### **添加了方法 IPresentation.GetSlideById**
方法Aspose.Slides.IPresentation.GetSlideById(System.UInt32)根据幻灯片 ID 返回幻灯片、母版幻灯片或布局幻灯片。

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **添加了属性 IShape.ConnectionSiteCount**
属性Aspose.Slides.IShape.ConnectionSiteCount返回形状上的连接点数量。

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
#### **添加了属性 ISmartArt.IsReversed**
属性Aspose.Slides.SmartArt.ISmartArt.IsReversed允许获取或设置有关SmartArt图表的状态（左到右 LTR 或右到左 RTL），如果图表支持反转。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **添加了属性 ISmartArt.Nodes**
属性Aspose.Slides.SmartArt.ISmartArt.Nodes返回SmartArt对象中的根节点集合。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // 选择第二个根节点

  node.TextFrame.Text = "第二个根节点";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **添加了属性 ISmartArtNode.IsHidden**
属性Aspose.Slides.SmartArt.ISmartArtNode.IsHidden返回true，如果该节点是数据模型中的隐藏节点。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; // 返回true

  if(hidden)

  {

    // 执行一些操作或通知

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **添加了属性 ISmartArtNode.OrganizationChartLayout**
属性Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout允许获取或设置与当前节点关联的组织图类型。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **添加了属性 ISmartArt.Layout 的 set 方法**
添加了属性Aspose.Slides.SmartArt.ISmartArt.Layout的 set 方法。它允许更改现有图表的布局类型。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **小型 API 更改**
**以下是小型 API 更改的列表:**

|枚举 Aspose.Slides.BevelColorMode |已删除，未使用的枚举 |
| :- | :- |
|属性 ThreeDFormatEffectiveData.BevelColorMode |已删除，未使用的属性 |
|属性 Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>属性 Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |已添加 |
|属性 Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>IParagraphFormatEffectiveData 继承自 ISlideComponent <br>属性 Aspose.Slides.IThreeDFormat.AsISlideComponent <br>IThreeDFormat 继承自 ISlideComponent |已删除 |
|属性 Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>属性 Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>属性 Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>属性 Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>属性 Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>属性 Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |已删除，因已过时 |