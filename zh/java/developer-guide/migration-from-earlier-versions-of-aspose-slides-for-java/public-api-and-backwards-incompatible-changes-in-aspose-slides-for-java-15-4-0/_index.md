---
title: Aspose.Slides for Java 15.4.0 的公共 API 以及向后不兼容的更改
linktitle: Aspose.Slides for Java 15.4.0
type: docs
weight: 120
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- 迁移
- 传统代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审阅 Aspose.Slides for Java 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

此页面列出了所有[已添加](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)的类、方法、属性等，以及所有新的限制和其他[更改](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)，这些都是在 Aspose.Slides for Java 15.4.0 API 中引入的。

{{% /alert %}} 
## **公共 API 变更**
### **已添加 Enum OrganizationChartLayoutType**
com.aspose.slides.OrganizationChartLayoutType 枚举表示组织结构图中子节点的布局类型。
### **已添加 Method IBulletFormat.applyDefaultParagraphIndentsShifts()**
com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts 方法在启用项目符号时（如 PowerPoint 在启用段落项目符号/编号时的行为），为有效段落的 Indent 和 MarginLeft 设置默认的非零偏移。如果禁用项目符号，则仅重置段落的 Indent 和 MarginLeft（如 PowerPoint 在禁用段落项目符号/编号时的行为）。
### **已添加 Method IConnector.reroute()**
com.aspose.slides.IConnector.reroute() 方法重新路由连接线，使其在连接的形状之间采用最短可能路径。为实现此目的，reroute() 方法可能会更改 StartShapeConnectionSiteIndex 和 EndShapeConnectionSiteIndex。

``` java
import com.aspose.slides.*;


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
### **已添加 Method IPresentation.getSlideById(long)**
Aspose.Slides.IPresentation.getSlideById(long) 方法通过幻灯片 ID 返回 Slide、MasterSlide 或 LayoutSlide。

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **已添加 Method ISmartArt.getNodes()**
com.aspose.slides.ISmartArt.getNodes() 方法返回 SmartArt 对象中根节点的集合。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // 选择第二个根节点

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **已添加 Method ISmartArt.setLayout(int)**
已添加 com.aspose.slides.ISmartArt.setLayout(int) 属性的方法。它允许更改现有图表的布局类型。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **已添加 Method ISmartArtNode.isHidden()**
com.aspose.slides.ISmartArtNode.isHidden() 方法如果该节点在数据模型中为隐藏节点，则返回 true。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //返回 true

if(hidden) {

    //执行一些操作或通知

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **已添加 Methods ISmartArt.isReversed(), setReversed()**
com.aspose.slides.ISmartArt.IsReversed 属性允许获取或设置 SmartArt 图表在左到右 (LTR) 或右到左 (RTL) 方向上的状态（如果该图表支持反转）。

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **已添加 Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)**
com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() 与 setOrganizationChartLayout(int) 方法允许获取或设置与当前节点关联的组织结构图类型。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);
```
### **已添加 Property IShape.getConnectionSiteCount()**
com.aspose.slides.getConnectionSiteCount() 属性返回形状上的连接点数量。

``` java
import com.aspose.slides.*;


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
### **次要更改**
以下是次要 API 更改的列表：

|Enum com.aspose.slides.BevelColorMode |已删除，未使用的枚举 |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |已删除，未使用的属性 |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |已添加 |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |已删除 |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |已删除，视为过时 |