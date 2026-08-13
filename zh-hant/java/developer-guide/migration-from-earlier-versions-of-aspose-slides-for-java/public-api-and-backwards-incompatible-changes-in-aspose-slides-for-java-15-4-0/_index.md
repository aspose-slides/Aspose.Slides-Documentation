---
title: Aspose.Slides for Java 15.4.0 的公共 API 以及向後不相容的變更
linktitle: Aspose.Slides for Java 15.4.0
type: docs
weight: 120
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢閱 Aspose.Slides for Java 的公共 API 更新與重大變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 

此頁面列出所有[新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)類別、方法、屬性等，任何新的限制以及其他[變更](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)，此等皆於 Aspose.Slides for Java 15.4.0 API 中引入。

{{% /alert %}} 
## **公共 API 變更**
### **已新增 Enum OrganizationChartLayoutType**
com.aspose.slides.OrganizationChartLayoutType 列舉表示組織圖中子節點的格式類型。
### **已新增 Method IBulletFormat.applyDefaultParagraphIndentsShifts()**
Method com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts 設定在啟用項目符號時（如 PowerPoint 在啟用段落項目符號/編號時的行為）有效段落的預設非零縮排與左側邊距。如果項目符號被停用，則僅重設段落的縮排與左側邊距（如 PowerPoint 在停用段落項目符號/編號時的行為）。
### **已新增 Method IConnector.reroute()**
Method com.aspose.slides.IConnector.reroute() 會重新路由連接線，使其在連接的形狀之間走最短路徑。為此，reroute() 方法可能會變更 StartShapeConnectionSiteIndex 與 EndShapeConnectionSiteIndex。

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
### **已新增 Method IPresentation.getSlideById(long)**
Method Aspose.Slides.IPresentation.getSlideById(long) 會根據投影片 ID 回傳 Slide、MasterSlide 或 LayoutSlide。

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **已新增 Method ISmartArt.getNodes()**
Method com.aspose.slides.ISmartArt.getNodes() 會回傳 SmartArt 物件中根節點的集合。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // 選取第二個根節點

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **已新增 Method ISmartArt.setLayout(int)**
已新增屬性 com.aspose.slides.ISmartArt.setLayout(int) 方法。它允許變更現有圖表的版面配置類型。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **已新增 Method ISmartArtNode.isHidden()**
Method com.aspose.slides.ISmartArtNode.isHidden() 若此節點在資料模型中為隱藏節點，則回傳 true。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //傳回 true

if(hidden) {

    //執行某些操作或通知

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **已新增 Methods ISmartArt.isReversed(), setReversed()**
Property com.aspose.slides.ISmartArt.IsReversed 允許取得或設定 SmartArt 圖表相對於 (左至右) LTR 或 (右至左) RTL 的方向狀態，前提是圖表支援反向。

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);
```
### **已新增 Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)**
Methods com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) 允許取得或設定目前節點所屬的組織圖類型。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **已新增 Property IShape.getConnectionSiteCount()**
Property com.aspose.slides.getConnectionSiteCount() 會回傳形狀的連接點數量。

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
### **次要變更**
以下為次要 API 變更列表：

|Enum com.aspose.slides.BevelColorMode |已刪除，未使用的列舉 |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |已刪除，未使用的屬性 |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |已新增 |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |已刪除 |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |已刪除，視為過時 |