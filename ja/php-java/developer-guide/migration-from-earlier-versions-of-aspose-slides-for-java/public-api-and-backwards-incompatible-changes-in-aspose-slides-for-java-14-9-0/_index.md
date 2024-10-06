---
title: Aspose.Slides for PHP via Java 14.9.0における公開APIおよび後方互換性のない変更
type: docs
weight: 80
url: /ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for PHP via Java 14.9.0 APIで追加されたすべての[クラス](/slides/ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/)、メソッド、プロパティ、その他の新しい制約や[変更](/slides/ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/)をリストしています。

{{% /alert %}} 
## **公開APIの変更**
### **PPImageおよびIPPImageに画像を置き換えるためのメソッドを追加**
新しいメソッドが追加されました：

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

```php
  $presentation = new Presentation("presentation.pptx");
  # 最初の方法
  # ...
  $imageData = $presentation->getImages()->get_Item(0)->replaceImage($imageData);
  # 二つ目の方法
  $presentation->getImages()->get_Item(1)->replaceImage($presentation->getImages()->get_Item(0));
  $presentation->save("presentation_out.pptx", SaveFormat::Pptx);

```
### **ページ番号を保持してスライドを保存するためのメソッドを追加**
以下のメソッドが追加されました：

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

これらのメソッドは、指定されたプレゼンテーションスライドをPDF、XPS、TIFF、HTMLフォーマットに保存することを可能にします。 'slides' 配列は、1から始まるページ番号を指定できます。

```php
  save($string, $slides, SaveFormat);

```

```php
  $presentation = new Presentation($presentationFileName);
  $slides = array(2, 3, 5 );// スライド位置の配列

  $presentation->save($outFileName, $slides, SaveFormat::Pdf);

```
### **SmartArtLayoutType::Custom列挙値を追加**
この種のSmartArtレイアウトはカスタムテンプレートの図を表します。カスタム図はプレゼンテーションファイルからのみ読み込むことができ、ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType::Custom)メソッドを介して作成することはできません。
### **SmartArtShapeクラスおよびISmartArtShapeインターフェイスを追加**
Aspose.Slides.SmartArt.SmartArtShapeクラス（およびそのインターフェイスAspose.Slides.SmartArt.ISmartArtShape）は、SmartArt図内の個々の形状へのアクセスを追加します。SmartArtShapeは、FillFormat、LineFormatの変更、ハイパーリンクの追加などに使用できます。

{{% alert color="primary" %}} 

SmartArtShapeは、IShapeプロパティRawFrame、Frame、Rotation、X、Y、Width、Heightをサポートしておらず、これらにアクセスしようとするとSystem.NotSupportedExceptionがスローされます。

{{% /alert %}} 

使用例：

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $node = $smart->getAllNodes()->get_Item(0);
  foreach($node->getShapes() as $shape) {
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
  }
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **SmartArtShapeCollectionクラス、ISmartArtShapeCollectionインターフェイス、ISmartArtNode.getShapes()メソッドが追加されました**
Aspose.Slides.SmartArt.SmartArtShapeCollectionクラス（およびそのインターフェイスAspose.Slides.SmartArt.ISmartArtShapeCollection）は、SmartArt図内の個々の形状へのアクセスを追加します。このコレクションはSmartArtNodeに関連付けられた形状を含んでいます。プロパティSmartArtNode.Shapesは、ノードに関連付けられたすべての形状のコレクションを返します。

{{% alert color="primary" %}} 

SmartArtLayoutTypeに応じて、1つのSmartArtShapeは複数のノード間で共有される場合があります。

{{% /alert %}} 

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $node = $smart->getAllNodes()->get_Item(0);
  foreach($node->getShapes() as $shape) {
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
  }
  $pres->save("out.pptx", SaveFormat::Pptx);

```