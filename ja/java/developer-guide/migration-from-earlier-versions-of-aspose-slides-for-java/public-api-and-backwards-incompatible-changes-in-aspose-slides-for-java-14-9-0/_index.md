---
title: Aspose.Slides for Java 14.9.0 におけるパブリック API と後方互換性のない変更点
type: docs
weight: 80
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 14.9.0 API で追加されたすべての [クラス](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/)、メソッド、プロパティ、その他の新しい制限や他の [変更](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
### **PPImage, IPPImage への画像を置き換えるための追加メソッド**
新しいメソッドが追加されました：

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//最初の方法

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//二番目の方法

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **スライドのページ番号を保持して保存するための追加メソッド**
次のメソッドが追加されました：

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

これらのメソッドは、指定されたプレゼンテーションスライドを PDF、XPS、TIFF、HTML 形式で保存することを可能にします。'slides' 配列は、1 から始まるページ番号を指定するために使用されます。

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //スライドポジションの配列

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **SmartArtLayoutType.Custom 列挙型の値が追加されました**
このタイプの SmartArt レイアウトは、カスタムテンプレートを持つ図を表します。カスタム図は、プレゼンテーションファイルからのみロードされ、メソッド ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) を介して作成することはできません。
### **SmartArtShape クラスと ISmartArtShape インターフェイスが追加されました**
Aspose.Slides.SmartArt.SmartArtShape クラス（およびそのインターフェイス Aspose.Slides.SmartArt.ISmartArtShape）は、SmartArt 図内の個々の形状へのアクセスを追加します。SmartArtShape は、FillFormat、LineFormat の変更、ハイパーリンクの追加などに使用できます。

{{% alert color="primary" %}} 

SmartArtShape は IShape プロパティ RawFrame、Frame、Rotation、X、Y、Width、Height をサポートしておらず、それらにアクセスしようとすると System.NotSupportedException がスローされます。

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
### **SmartArtShapeCollection クラス、ISmartArtShapeCollection インターフェイス、および ISmartArtNode.getShapes() メソッドが追加されました**
Aspose.Slides.SmartArt.SmartArtShapeCollection クラス（およびそのインターフェイス Aspose.Slides.SmartArt.ISmartArtShapeCollection）は、SmartArt 図内の個々の形状へのアクセスを提供します。このコレクションは、SmartArtNode に関連付けられた形状を含みます。プロパティ SmartArtNode.Shapes は、ノードに関連付けられたすべての形状のコレクションを返します。

{{% alert color="primary" %}} 

SmartArtLayoutType に応じて、一つの SmartArtShape を複数のノードで共有することができます。

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