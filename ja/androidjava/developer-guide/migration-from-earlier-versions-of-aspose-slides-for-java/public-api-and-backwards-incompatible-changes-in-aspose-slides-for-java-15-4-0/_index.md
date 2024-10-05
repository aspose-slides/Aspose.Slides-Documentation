---
title: Aspose.Slides for Java 15.4.0の公開APIおよび後方互換性のない変更
type: docs
weight: 120
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 15.4.0 APIで追加されたすべての[class](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)クラス、メソッド、プロパティ、新しい制限、およびその他の[changes](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)をリストします。

{{% /alert %}} 
## **公開APIの変更**
### **Enum OrganizationChartLayoutTypeが追加されました**
com.aspose.slides.OrganizationChartLayoutType列挙型は、組織図の子ノードのフォーマットタイプを表します。
### **メソッド IBulletFormat.applyDefaultParagraphIndentsShifts()が追加されました**
メソッドcom.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShiftsは、箇条書きが有効になっているときの有効段落インデントとMarginLeftのデフォルトの非ゼロシフトを設定します（これはPowerPointが段落の箇条書き/番号付けを有効にした場合に行うことです）。箇条書きが無効になっている場合は、段落インデントとMarginLeftをリセットします（これはPowerPointが段落の箇条書き/番号付けを無効にした場合に行うことです）。
### **メソッド IConnector.reroute()が追加されました**
メソッドcom.aspose.slides.IConnector.reroute()は、接続する図形間の最短経路を取るようにコネクタを再ルーティングします。これを行うために、reroute()メソッドはStartShapeConnectionSiteIndexとEndShapeConnectionSiteIndexを変更する場合があります。

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
### **メソッド IPresentation.getSlideById(long)が追加されました**
メソッドAspose.Slides.IPresentation.getSlideById(int)は、スライドIdによってスライド、マスタースライド、またはレイアウトスライドを返します。

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **メソッド ISmartArt.getNodes()が追加されました**
メソッドcom.aspose.slides.ISmartArt.getNodes()は、SmartArtオブジェクト内のルートノードのコレクションを返します。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // 2番目のルートノードを選択

node.getTextFrame().setText("第2ルートノード");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **メソッド ISmartArt.setLayout(int)が追加されました**
プロパティcom.aspose.slides.ISmartArt.setLayout(int)のメソッドが追加されました。これにより、既存の図のレイアウトタイプを変更できます。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **メソッド ISmartArtNode.isHidden()が追加されました**
メソッドcom.aspose.slides.ISmartArtNode.isHidden()は、このノードがデータモデルの中で隠されたノードである場合はtrueを返します。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); // trueを返す

if(hidden) {

    //何らかの操作または通知を行う

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **メソッド ISmartArt.isReversed(), setReserved()が追加されました**
プロパティcom.aspose.slides.ISmartArt.IsReversedは、SmartArt図の状態を（左から右）LTRまたは（右から左）RTLに対して取得または設定します。図が反転をサポートしている場合。

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **メソッド ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)が追加されました**
メソッドcom.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)は、現在のノードに関連付けられた組織図タイプを取得または設定します。

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **プロパティ IShape.getConnectionSiteCount()が追加されました**
プロパティcom.aspose.slides.getConnectionSiteCount()は、形状上の接続サイトの数を返します。

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
### **マイナーな変更**
これは、マイナーなAPI変更のリストです：

|Enum com.aspose.slides.BevelColorMode |削除された未使用の列挙型 |
| :- | :- |
|メソッド ThreeDFormatEffectiveData.getBevelColorMode() |削除された未使用のプロパティ |
|メソッド com.aspose.slides.ChartSeriesGroup.getChart() |追加 |
|IParagraphFormatEffectiveDataのISlideComponentからの継承 <br>IThreeDFormatのISlideComponentからの継承 |削除 |
|メソッド com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>メソッド com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>メソッド com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>メソッド com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>メソッド com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>メソッド com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |廃止されたため削除 |