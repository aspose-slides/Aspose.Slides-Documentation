---
title: Aspose.Slides for Java 15.4.0における公開APIと後方互換性のない変更
type: docs
weight: 120
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 15.4.0 APIで追加されたすべての[class](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)クラス、メソッド、プロパティ、その他の新しい制限や[changes](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)をリストしています。

{{% /alert %}} 
## **公開APIの変更**
### **Enum OrganizationChartLayoutTypeが追加されました**
com.aspose.slides.OrganizationChartLayoutType enumは、組織図内の子ノードの書式設定タイプを表します。
### **メソッド IBulletFormat.applyDefaultParagraphIndentsShifts() が追加されました**
メソッドcom.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShiftsは、箇条書きが有効な場合に、実効段落インデントとMarginLeftのデフォルトの非ゼロシフトを設定します（PowerPointが段落箇条書き/番号付けを有効にした場合に行うように）。箇条書きが無効な場合は、段落インデントとMarginLeftをリセットします（PowerPointが段落箇条書き/番号付けを無効にした場合のように）。
### **メソッド IConnector.reroute() が追加されました**
メソッドcom.aspose.slides.IConnector.reroute()は、接続されている図形間の最短経路になるようにコネクタを再ルートします。これを行うために、reroute()メソッドはStartShapeConnectionSiteIndexとEndShapeConnectionSiteIndexを変更することがあります。

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
### **メソッド IPresentation.getSlideById(long) が追加されました**
メソッドAspose.Slides.IPresentation.getSlideById(int)は、スライドIDによってスライド、マスター スライドまたはレイアウト スライドを返します。

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **メソッド ISmartArt.getNodes() が追加されました**
メソッドcom.aspose.slides.ISmartArt.getNodes()は、SmartArtオブジェクトのルートノードのコレクションを返します。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // 2番目のルートノードを選択

node.getTextFrame().setText("第二のルートノード");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **メソッド ISmartArt.setLayout(int) が追加されました**
プロパティcom.aspose.slides.ISmartArt.setLayout(int)のためのメソッドが追加されました。これは、既存のダイアグラムのレイアウトタイプを変更することを可能にします。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **メソッド ISmartArtNode.isHidden() が追加されました**
メソッドcom.aspose.slides.ISmartArtNode.isHidden()は、このノードがデータモデル内の隠れたノードである場合にはtrueを返します。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //returns true

if(hidden) {

    //何らかのアクションまたは通知を行う

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **メソッド ISmartArt.isReversed(), setReserved() が追加されました**
プロパティcom.aspose.slides.ISmartArt.IsReversedを使用すると、SmartArtダイアグラムのLTR（左から右）またはRTL（右から左）に関する状態を取得または設定できます。

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **メソッド ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) が追加されました**
メソッドcom.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)は、現在のノードに関連付けられた組織図タイプを取得または設定できます。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **プロパティ IShape.getConnectionSiteCount() が追加されました**
プロパティcom.aspose.slides.getConnectionSiteCount()は、図形上の接続サイトの数を返します。

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
### **マイナー変更**
これは、マイナーAPI変更のリストです：

|Enum com.aspose.slides.BevelColorMode |削除、未使用のenum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |削除、未使用のプロパティ |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |追加 |
|IParagraphFormatEffectiveDataからISlideComponentへの継承 <br>IThreeDFormatからISlideComponentへの継承 |削除 |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |廃止されたため削除 |