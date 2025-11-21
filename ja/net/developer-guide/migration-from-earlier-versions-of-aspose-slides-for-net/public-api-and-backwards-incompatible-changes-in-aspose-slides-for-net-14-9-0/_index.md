---
title: Aspose.Slides for .NET 14.9.0 のパブリック API と後方互換性のない変更
linktitle: Aspose.Slides for .NET 14.9.0
type: docs
weight: 110
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページは、Aspose.Slides for .NET 14.9.0 APIで導入された、[追加された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/)または[削除された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/)クラス、メソッド、プロパティなど、その他の変更をすべて一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **ISmartArtNodeCollection に ICollection およびジェネリック IEnumerable インターフェイスが追加**
The class Aspose.Slides.SmartArt.SmartArtNodeCollection (and the related interface Aspose.Slides.SmartArt.ISmartArtNodeCollection) inherit the generic interface IEnumerable<ISmartArtNode> and interface ICollection.
#### **SmartArtLayoutType.Custom 列挙値が追加**
The Custom SmartArt layout type represents a diagram with a custom template. Custom diagrams can only be loaded from a presentation file and can't be created via the ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) method.
#### **SmartArtShape クラス と ISmartArtShape インターフェイスが追加**
The Aspose.Slides.SmartArt.SmartArtShape class (and its interface Aspose.Slides.SmartArt.ISmartArtShape) give access to individual shapes in a SmartArt diagram. SmartArtShape can be used to change FillFormat, LineFormat, adding Hyperlinks and other tasks.

{{% alert color="primary" %}} 

**注**: SmartArtShape は IShape プロパティ RawFrame、Frame、Rotation、X、Y、Width、Height をサポートしておらず、これらにアクセスしようとすると System.NotSupportedException がスローされます。

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
#### **SmartArtShapeCollection クラス、ISmartArtShapeCollection インターフェイス および ISmartArtNode.Shapes プロパティが追加**
The Aspose.Slides.SmartArt.SmartArtShapeCollection class (and its interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) add access to individual shapes in a SmartArt diagram. The collection contains shapes associated with SmartArtNode. The SmartArtNode.Shapes property returns collections of all shapes associated with the node.

{{% alert color="primary" %}} 

**注**: SmartArtLayoutType によっては、1 つの SmartArtShape が複数のノード間で共有される場合があります。

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
#### **ページ番号を保持したスライド保存メソッドが追加**
The following methods have been added:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

These methods allow developers to save specified presentation slides to PDF, XPS, TIFF, HTML formats. The 'slides' array is used to specify page numbers, starting from 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array of slides positions

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **PPImage、IPPImage に画像置換メソッドが追加**
New methods added:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//First method

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//Second method

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//Third method

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```