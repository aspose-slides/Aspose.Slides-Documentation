---
title: Aspose.Slides for Java 15.4.0 的公共 API 和不向后兼容的更改
type: docs
weight: 120
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

此页面列出了在 Aspose.Slides for Java 15.4.0 API 中添加的所有[class](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)类、方法、属性等，任何新的限制以及其他[changes](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)。

{{% /alert %}} 
## **公共 API 更改**
### **添加了 Enum OrganizationChartLayoutType**
com.aspose.slides.OrganizationChartLayoutType 枚举表示组织图中子节点的格式类型。
### **添加了方法 IBulletFormat.applyDefaultParagraphIndentsShifts()**
方法 com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts 设置有效段落缩进和 MarginLeft 的默认非零偏移量，当启用项目符号时（如 PowerPoint 在启用段落项目符号/编号时的表现）。如果禁用项目符号，则只重置段落缩进和 MarginLeft（如 PowerPoint 在禁用段落项目符号/编号时的表现）。
### **添加了方法 IConnector.reroute()**
方法 com.aspose.slides.IConnector.reroute() 重新路由连接器，以便它在连接的形状之间采取最短路径。为此，reroute() 方法可能会更改 StartShapeConnectionSiteIndex 和 EndShapeConnectionSiteIndex。

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
### **添加了方法 IPresentation.getSlideById(long)**
方法 Aspose.Slides.IPresentation.getSlideById(int) 根据幻灯片 ID 返回幻灯片、母版幻灯片或布局幻灯片。

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **添加了方法 ISmartArt.getNodes()**
方法 com.aspose.slides.ISmartArt.getNodes() 返回 SmartArt 对象中根节点的集合。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // 选择第二个根节点

node.getTextFrame().setText("第二个根节点");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **添加了方法 ISmartArt.setLayout(int)**
添加了属性 com.aspose.slides.ISmartArt.setLayout(int) 的方法。它允许更改现有图表的布局类型。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **添加了方法 ISmartArtNode.isHidden()**
方法 com.aspose.slides.ISmartArtNode.isHidden() 如果该节点在数据模型中是隐藏的节点，则返回 true。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //返回 true

if(hidden) {

    // 执行某些操作或通知

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **添加了方法 ISmartArt.isReversed(), setReserved()**
属性 com.aspose.slides.ISmartArt.IsReversed 允许获取或设置 SmartArt 图表的状态，与（从左到右）LTR 或（从右到左）RTL 相关，如果图表支持反转。

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **添加了方法 ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)**
方法 com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) 允许获取或设置与当前节点关联的组织图类型。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **添加了属性 IShape.getConnectionSiteCount()**
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
### **小变化**
这是小型 API 变化的列表：

|Enum com.aspose.slides.BevelColorMode |已删除，未使用的枚举 |
| :- | :- |
|方法 ThreeDFormatEffectiveData.getBevelColorMode() |已删除，未使用的属性 |
|方法 com.aspose.slides.ChartSeriesGroup.getChart() |已添加 |
|IParagraphFormatEffectiveData 继承自 ISlideComponent <br>IThreeDFormat 继承自 ISlideComponent |已删除 |
|方法 com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>方法 com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>方法 com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>方法 com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>方法 com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>方法 com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |已删除，已过时 |