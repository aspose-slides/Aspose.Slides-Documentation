---
title: Aspose.Slides for .NET 14.9.0における公開APIと後方互換性のない変更
type: docs
weight: 110
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.9.0 API に伴って追加された ([added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/)) または削除された ([removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/)) クラス、メソッド、プロパティなど、その他の変更をリストします。

{{% /alert %}} 
## **公開APIの変更**
#### **ISmartArtNodeCollectionへのICollectionおよびジェネリックIEnumerableインターフェースの継承が追加**
クラスAspose.Slides.SmartArt.SmartArtNodeCollection（および関連するインターフェースAspose.Slides.SmartArt.ISmartArtNodeCollection）は、ジェネリックインターフェースIEnumerable<ISmartArtNode>およびインターフェースICollectionを継承します。
#### **SmartArtLayoutType.Custom列挙値が追加**
カスタムSmartArtレイアウトタイプは、カスタムテンプレートを持つ図を表します。カスタム図はプレゼンテーションファイルからのみロードでき、ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom)メソッドを使用して作成することはできません。
#### **SmartArtShapeクラスおよびISmartArtShapeインターフェースが追加**
Aspose.Slides.SmartArt.SmartArtShapeクラス（およびそのインターフェースAspose.Slides.SmartArt.ISmartArtShape）は、SmartArt図の個々の形状へのアクセスを提供します。SmartArtShapeはFillFormat、LineFormatを変更したり、ハイパーリンクを追加したりするために使用できます。

{{% alert color="primary" %}} 

**注**: SmartArtShapeはIShapeプロパティRawFrame、Frame、Rotation、X、Y、Width、Heightをサポートしておらず、アクセスしようとするとSystem.NotSupportedExceptionがスローされます。

使用例:

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **SmartArtShapeCollectionクラス、ISmartArtShapeCollectionインターフェース、ISmartArtNode.Shapesプロパティが追加**
Aspose.Slides.SmartArt.SmartArtShapeCollectionクラス（およびそのインターフェースAspose.Slides.SmartArt.ISmartArtShapeCollection）は、SmartArt図の個々の形状へのアクセスを追加します。このコレクションにはSmartArtNodeに関連付けられた形状が含まれています。SmartArtNode.Shapesプロパティは、ノードに関連付けられたすべての形状のコレクションを返します。

{{% alert color="primary" %}} 

**注**: SmartArtLayoutTypeに応じて、1つのSmartArtShapeは複数のノード間で共有される場合があります。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **ページ番号を保持してスライドを保存するためのメソッドが追加**
次のメソッドが追加されました：

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

これらのメソッドにより、開発者は指定されたプレゼンテーションスライドをPDF、XPS、TIFF、HTML形式で保存できます。'slides'配列はページ番号を指定するために使用され、1から始まります。
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //スライド位置の配列

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **PPImageおよびIPPImageに画像を置き換えるためのメソッドが追加**
新しいメソッドが追加されました：

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//最初のメソッド

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//2番目のメソッド

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//3番目のメソッド

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

``` 