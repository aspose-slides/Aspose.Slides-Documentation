---
title: Aspose.Slides for Java 15.4.0 のパブリック API と下位互換性のない変更
linktitle: Aspose.Slides for Java 15.4.0
type: docs
weight: 120
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のパブリック API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行してください。"
---
{{% alert color="info" %}} 

このページは、Aspose.Slides for Java 15.4.0 APIで導入された、すべての[追加](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)クラス、メソッド、プロパティ等、また新しい制約やその他の[変更](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
### **Enum OrganizationChartLayoutType が追加されました**
com.aspose.slides.OrganizationChartLayoutType 列挙型は、組織図の子ノードの書式設定タイプを表します。
### **Method IBulletFormat.applyDefaultParagraphIndentsShifts() が追加されました**
Method com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts は、箇条書きが有効な場合に有効な段落インデントと MarginLeft のデフォルトの非ゼロシフトを設定します（PowerPoint が段落の箇条書き/番号付けを有効にしたときと同様です）。箇条書きが無効な場合は、段落インデントと MarginLeft をリセットします（PowerPoint が段落の箇条書き/番号付けを無効にしたときと同様です）。
### **Method IConnector.reroute() が追加されました**
Method com.aspose.slides.IConnector.reroute() は、接続されるシェイプ間の最短パスを取るようにコネクタを再ルーティングします。この際、reroute() メソッドは StartShapeConnectionSiteIndex および EndShapeConnectionSiteIndex を変更する可能性があります。

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
### **Method IPresentation.getSlideById(long) が追加されました**
Method Aspose.Slides.IPresentation.getSlideById(long) は、スライド ID に基づいて Slide、MasterSlide、または LayoutSlide を返します。

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Method ISmartArt.getNodes() が追加されました**
Method com.aspose.slides.ISmartArt.getNodes() は、SmartArt オブジェクト内のルートノードのコレクションを返します。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // 2番目のルートノードを選択

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArt.setLayout(int) が追加されました**
Method for property com.aspose.slides.ISmartArt.setLayout(int) が追加されました。既存の図のレイアウトタイプを変更できます。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArtNode.isHidden() が追加されました**
Method com.aspose.slides.ISmartArtNode.isHidden() は、このノードがデータモデル内で非表示ノードである場合に true を返します。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); // true を返します

if(hidden) {

    // いくつかのアクションまたは通知を実行します

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Methods ISmartArt.isReversed(), setReversed() が追加されました**
Property com.aspose.slides.ISmartArt.IsReversed は、図が反転をサポートしている場合に、SmartArt 図の状態を左から右 (LTR) または右から左 (RTL) に取得または設定できます。

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) が追加されました**
Methods com.aspose.slides.ISmartArtNode.getOrganizationChartLayout()、setOrganizationChartLayout(int) は、現在のノードに関連付けられた組織図タイプを取得または設定できます。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Property IShape.getConnectionSiteCount() が追加されました**
Property com.aspose.slides.getConnectionSiteCount() は、シェイプ上の接続サイトの数を返します。

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
### **マイナー変更**
以下はマイナー API 変更の一覧です。

| Enum com.aspose.slides.BevelColorMode | 削除、未使用の列挙型 |
| :- | :- |
| Method ThreeDFormatEffectiveData.getBevelColorMode() | 削除、未使用のプロパティ |
| Method com.aspose.slides.ChartSeriesGroup.getChart() | 追加 |
| Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent | 削除 |
| Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() | 非推奨として削除 |