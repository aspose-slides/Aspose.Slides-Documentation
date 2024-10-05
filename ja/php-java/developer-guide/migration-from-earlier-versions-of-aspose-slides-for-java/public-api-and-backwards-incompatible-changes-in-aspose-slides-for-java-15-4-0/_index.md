---
title: Aspose.Slides for PHP via Java 15.4.0におけるパブリックAPIと後方互換性のない変更
type: docs
weight: 120
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for PHP via Java 15.4.0 APIで新しく追加されたクラス、メソッド、プロパティ、新しい制限、およびその他の変更のすべてを一覧表示しています。[追加された](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)内容を確認してください。

{{% /alert %}} 
## **パブリックAPIの変更**
### **Enum OrganizationChartLayoutTypeが追加されました**
com.aspose.slides.OrganizationChartLayoutType列挙型は、組織図における子ノードのフォーマットタイプを表します。
### **メソッド IBulletFormat.applyDefaultParagraphIndentsShifts()が追加されました**
メソッドcom.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShiftsは、箇条書きが有効な場合（PowerPointが段落の箇条書き/番号付けを有効にするときと同様に）、段落のインデントとMarginLeftのデフォルトのゼロ以外のシフトを設定します。箇条書きが無効な場合は、段落のインデントとMarginLeftをリセットします（PowerPointが段落の箇条書き/番号付けを無効にするときと同様）。
### **メソッド IConnector.reroute()が追加されました**
メソッドcom.aspose.slides.IConnector.reroute()は、コネクタを再ルーティングして、接続されている図形間の最短経路を取るようにします。このために、reroute()メソッドはStartShapeConnectionSiteIndexおよびEndShapeConnectionSiteIndexを変更することがあります。

```php
  $input = new Presentation();
  $shapes = $input->getSlides()->get_Item(0)->getShapes();
  $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
  $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
  $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
  $connector->setStartShapeConnectedTo($ellipse);
  $connector->setEndShapeConnectedTo($rectangle);
  $connector->reroute();
  $input->save("output.pptx", SaveFormat::Pptx);

```
### **メソッド IPresentation.getSlideById(long)が追加されました**
メソッドAspose.Slides.IPresentation.getSlideById(int)は、スライドIdによってスライド、マスタースライド、またはレイアウトスライドを返します。

```php
  $presentation = new Presentation();
  $id = $presentation->getSlides()->get_Item(0)->getSlideId();
  $slide = $presentation->getSlideById($id);

```
### **メソッド ISmartArt.getNodes()が追加されました**
メソッドcom.aspose.slides.ISmartArt.getNodes()は、SmartArtオブジェクト内のルートノードのコレクションを返します。

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::VerticalBulletList);
  $node = $smart->getNodes()->get_Item(1);// 2番目のルートノードを選択

  $node->getTextFrame()->setText("二番目のルートノード");
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **メソッド ISmartArt.setLayout(int)が追加されました**
プロパティcom.aspose.slides.ISmartArt.setLayout(int)のメソッドが追加されました。これにより、既存の図のレイアウトタイプを変更できます。

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $smart->setLayout(SmartArtLayoutType::BasicProcess);
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **メソッド ISmartArtNode.isHidden()が追加されました**
メソッドcom.aspose.slides.ISmartArtNode.isHidden()は、このノードがデータモデル内の隠しノードである場合、trueを返します。

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
  $node = $smart->getAllNodes()->addNode();
  $hidden = $node->isHidden();// trueを返す

  if ($hidden) {
    # 何らかのアクションまたは通知を行う
  }
  $pres->Save("out.pptx", SaveFormat::Pptx);

```
### **メソッド ISmartArt.isReversed(), setReserved()が追加されました**
プロパティcom.aspose.slides.ISmartArt.IsReversedは、図が逆転をサポートしている場合、SmartArt図の状態を左から右（LTR）または右から左（RTL）として取得または設定できます。

```php
  $presentation = new Presentation();
  $smart = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
  $smart->setReversed(true);
  $presentation->save("out.pptx", SaveFormat::Pptx);

```
### **メソッド ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)が追加されました**
メソッドcom.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)は、現在のノードに関連付けられた組織図タイプを取得または設定できます。

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
  $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **プロパティ IShape.getConnectionSiteCount()が追加されました**
プロパティcom.aspose.slides.getConnectionSiteCount()は、形状上の接続サイトの数を返します。

```php
  $input = new Presentation();
  $shapes = $input->getSlides()->get_Item(0)->getShapes();
  $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
  $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
  $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);
  $connector->setStartShapeConnectedTo($ellipse);
  $connector->setEndShapeConnectedTo($rectangle);
  $wantedIndex = 6;
  if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
    $connector->setStartShapeConnectionSiteIndex($wantedIndex);
  }
  $input->save("output.pptx", SaveFormat::Pptx);

```
### **マイナーな変更**
マイナーなAPI変更のリストです：

|Enum com.aspose.slides.BevelColorMode |削除され、未使用のenum |
| :- | :- |
|メソッド ThreeDFormatEffectiveData.getBevelColorMode() |削除され、未使用のプロパティ |
|メソッド com.aspose.slides.ChartSeriesGroup.getChart() |追加されました |
|IParagraphFormatEffectiveDataのISlideComponentからの継承<br>IThreeDFormatのISlideComponentからの継承 |削除されました |
|メソッド com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>メソッド com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>メソッド com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>メソッド com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>メソッド com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>メソッド com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |廃止のため削除されました |