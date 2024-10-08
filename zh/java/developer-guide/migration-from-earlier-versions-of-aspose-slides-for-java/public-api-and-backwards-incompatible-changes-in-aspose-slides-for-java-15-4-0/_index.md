---
title: Aspose.Slides for Java 15.4.0 的公共 API 和不兼容的变更
type: docs
weight: 120
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for Java 15.4.0 API 中[添加](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)的类、方法、属性等，以及引入的任何新限制和其他[变更](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)。

{{% /alert %}} 
## **公共 API 变更**
### **Enum OrganizationChartLayoutType 已添加**
com.aspose.slides.OrganizationChartLayoutType 枚举代表组织图中子节点的格式类型。
### **方法 IBulletFormat.applyDefaultParagraphIndentsShifts() 已添加**
方法 com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts 在启用项目符号时（如 PowerPoint 在启用段落项目符号/编号时所做的那样），为有效段落缩进和左边距设置默认非零偏移。如果禁用项目符号，则仅重置段落缩进和左边距（如 PowerPoint 在禁用段落项目符号/编号时所做的那样）。
### **方法 IConnector.reroute() 已添加**
方法 com.aspose.slides.IConnector.reroute() 重新路由连接器，使其沿着连接的形状之间的最短路径行驶。为此，reroute() 方法可能会更改 StartShapeConnectionSiteIndex 和 EndShapeConnectionSiteIndex。

``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

connector.reroute();

input.save("output.pptx", SaveFormat.Pptx);

```
### **方法 IPresentation.getSlideById(long) 已添加**
方法 Aspose.Slides.IPresentation.getSlideById(int) 根据幻灯片 ID 返回幻灯片、母版幻灯片或布局幻灯片。

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **方法 ISmartArt.getNodes() 已添加**
方法 com.aspose.slides.ISmartArt.getNodes() 返回 SmartArt 对象中的根节点集合。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // 选择第二个根节点

node.getTextFrame().setText("第二个根节点");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **方法 ISmartArt.setLayout(int) 已添加**
为属性 com.aspose.slides.ISmartArt.setLayout(int) 添加的方法。它允许更改现有图表的布局类型。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **方法 ISmartArtNode.isHidden() 已添加**
方法 com.aspose.slides.ISmartArtNode.isHidden() 如果此节点是数据模型中的隐藏节点，则返回 true。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //返回 true

if(hidden) {

    //执行一些操作或通知

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **方法 ISmartArt.isReversed(), setReserved() 已添加**
属性 com.aspose.slides.ISmartArt.IsReversed 允许获取或设置 SmartArt 图表的状态，关于（从左到右）LTR 或（从右到左）RTL，如果图表支持反转。

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **方法 ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) 已添加**
方法 com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) 允许获取或设置与当前节点关联的组织图类型。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **属性 IShape.getConnectionSiteCount() 已添加**
属性 com.aspose.slides.getConnectionSiteCount() 返回形状上的连接点数量。

``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

long wantedIndex = 6;

if (ellipse.getConnectionSiteCount() > wantedIndex) {

  connector.setStartShapeConnectionSiteIndex(wantedIndex);

}

input.save("output.pptx", SaveFormat.Pptx);

```
### **小变更**
这是小的 API 变更列表：

|Enum com.aspose.slides.BevelColorMode |已删除，未使用的枚举 |
| :- | :- |
|方法 ThreeDFormatEffectiveData.getBevelColorMode() |已删除，未使用的属性 |
|方法 com.aspose.slides.ChartSeriesGroup.getChart() |已添加 |
|IParagraphFormatEffectiveData 从 ISlideComponent 的继承 <br>IThreeDFormat 从 ISlideComponent 的继承 |已删除 |
|方法 com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>方法 com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>方法 com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>方法 com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>方法 com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>方法 com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |已删除，因为过时 |