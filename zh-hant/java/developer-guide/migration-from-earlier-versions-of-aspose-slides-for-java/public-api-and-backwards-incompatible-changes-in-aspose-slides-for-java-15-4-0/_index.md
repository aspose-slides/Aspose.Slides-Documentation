---
title: Aspose.Slides for Java 15.4.0 的公開 API 以及相容性破壞變更
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
description: "檢閱 Aspose.Slides for Java 的公開 API 更新與破壞性變更，以順利遷移您的 PowerPoint PPT、PPTX 及 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 
此頁面列出所有[已新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)類別、方法、屬性等，任何新的限制以及其他[變更](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)均隨 Aspose.Slides for Java 15.4.0 API 引入。 
{{% /alert %}} 
## **公開 API 變更**
### **已新增 Enum OrganizationChartLayoutType**
com.aspose.slides.OrganizationChartLayoutType 列舉代表組織圖中子節點的格式類型。 
### **已新增 Method IBulletFormat.applyDefaultParagraphIndentsShifts()**
com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts 方法會在啟用項目符號時（如 PowerPoint 在啟用段落項目符號/編號時）設定有效段落縮排與左邊距的預設非零位移。如果項目符號被停用，則僅重設段落縮排與左邊距（如 PowerPoint 在停用段落項目符號/編號時的行為）。 
### **已新增 Method IConnector.reroute()**
com.aspose.slides.IConnector.reroute() 方法會重新路由連接線，使其在連接的形狀之間走最短的路徑。為此，reroute() 方法可能會變更 StartShapeConnectionSiteIndex 與 EndShapeConnectionSiteIndex。 
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
### **已新增 Method IPresentation.getSlideById(long)**
Aspose.Slides.IPresentation.getSlideById(int) 方法依據投影片 ID 傳回 Slide、MasterSlide 或 LayoutSlide。 
``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **已新增 Method ISmartArt.getNodes()**
com.aspose.slides.ISmartArt.getNodes() 方法傳回 SmartArt 物件中根節點的集合。 
``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // 選取第二個根節點

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **已新增 Method ISmartArt.setLayout(int)**
已新增屬性 com.aspose.slides.ISmartArt.setLayout(int) 的方法。它允許變更現有圖表的版面配置類型。 
``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **已新增 Method ISmartArtNode.isHidden()**
com.aspose.slides.ISmartArtNode.isHidden() 方法在此節點在資料模型中為隱藏節點時傳回 true。 
``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //傳回 true

if(hidden) {

    //執行一些動作或通知

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **已新增 Methods ISmartArt.isReversed(), setReserved()**
com.aspose.slides.ISmartArt.IsReversed 屬性允許取得或設定 SmartArt 圖表相對於左到右 (LTR) 或右到左 (RTL) 的狀態（若圖表支援反轉）。 
``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **已新增 Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)**
com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() 與 setOrganizationChartLayout(int) 方法允許取得或設定與目前節點關聯的組織圖類型。 
``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **已新增 Property IShape.getConnectionSiteCount()**
com.aspose.slides.getConnectionSiteCount() 屬性傳回形狀上的連接點數量。 
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
### **次要變更**
以下是次要 API 變更的列表：

|Enum com.aspose.slides.BevelColorMode |已刪除，未使用的列舉 |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |已刪除，未使用的屬性 |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |已新增 |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |已刪除 |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |已刪除，因已過時 |