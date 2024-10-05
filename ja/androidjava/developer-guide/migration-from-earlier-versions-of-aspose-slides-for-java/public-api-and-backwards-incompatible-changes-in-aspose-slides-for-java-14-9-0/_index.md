---
title: Aspose.Slides for Java 14.9.0における公開APIと後方互換性のない変更
type: docs
weight: 80
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 14.9.0 APIで追加されたすべての[class](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/)クラス、メソッド、プロパティ、その他の新しい制限および[変更](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/)を一覧表示します。

{{% /alert %}} 
## **公開APIの変更**
### **PPImage、IPPImageのための画像置換用メソッドの追加**
新しいメソッドが追加されました：

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//最初の方法

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//二つ目の方法

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **ページ番号を保持するスライド保存用メソッドの追加**
以下のメソッドが追加されました：

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

これらのメソッドを使用すると、指定したプレゼンテーションスライドをPDF、XPS、TIFF、HTML形式で保存できます。'slides'配列では、1から始まるページ番号を指定できます。

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //スライド位置の配列

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **SmartArtLayoutType.Custom Enum 値の追加**
このタイプのSmartArtレイアウトは、カスタムテンプレートを使用した図を表します。カスタム図はプレゼンテーションファイルからのみロードでき、ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)メソッドを介して作成することはできません。
### **SmartArtShapeクラスとISmartArtShapeインターフェイスの追加**
Aspose.Slides.SmartArt.SmartArtShapeクラス（およびそのインターフェイスAspose.Slides.SmartArt.ISmartArtShape）は、SmartArt図内の個々の図形へのアクセスを追加します。SmartArtShapeを使用してFillFormatやLineFormatを変更したり、ハイパーリンクを追加したりできます。

{{% alert color="primary" %}} 

SmartArtShapeは、IShapeプロパティのRawFrame、Frame、Rotation、X、Y、Width、Heightをサポートしておらず、それらにアクセスしようとするとSystem.NotSupportedExceptionがスローされます。

{{% /alert %}} 

使用例：

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **SmartArtShapeCollectionクラス、ISmartArtShapeCollectionインターフェイス、ISmartArtNode.getShapes()メソッドが追加されました**
Aspose.Slides.SmartArt.SmartArtShapeCollectionクラス（およびそのインターフェイスAspose.Slides.SmartArt.ISmartArtShapeCollection）は、SmartArt図内の個々の図形へのアクセスを追加します。コレクションには、SmartArtNodeに関連付けられた図形が含まれます。プロパティSmartArtNode.Shapesは、ノードに関連付けられたすべての図形のコレクションを返します。

{{% alert color="primary" %}} 

SmartArtLayoutTypeによっては、1つのSmartArtShapeが複数のノードで共有される場合があります。

{{% /alert %}} 

﻿

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```