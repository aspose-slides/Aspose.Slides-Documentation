---
title: Aspose.Slides for .NET 14.9.0 のパブリック API と後方互換性がない変更
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
description: Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションを円滑に移行できるようにします。
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.9.0 APIで導入された、追加または削除されたクラス、メソッド、プロパティなど、その他の変更をすべて一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **ISmartArtNodeCollection に ICollection とジェネリック IEnumerable インターフェイスの継承が追加**
クラス Aspose.Slides.SmartArt.SmartArtNodeCollection（および関連インターフェイス Aspose.Slides.SmartArt.ISmartArtNodeCollection）は、ジェネリックインターフェイス IEnumerable<ISmartArtNode> とインターフェイス ICollection を継承します。
#### **SmartArtLayoutType.Custom 列挙値が追加**
Custom SmartArt レイアウトタイプは、カスタムテンプレートを持つ図形を表します。カスタム図形はプレゼンテーションファイルからのみ読み込むことができ、ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) メソッドでは作成できません。
#### **SmartArtShape クラスと ISmartArtShape インターフェイスが追加**
Aspose.Slides.SmartArt.SmartArtShape クラス（およびそのインターフェイス Aspose.Slides.SmartArt.ISmartArtShape）は、SmartArt 図の個々のシェイプにアクセスする機能を提供します。SmartArtShape は FillFormat、LineFormat の変更、ハイパーリンクの追加、その他の操作に使用できます。

{{% alert color="primary" %}} 

**注意**: SmartArtShape は IShape プロパティ RawFrame、Frame、Rotation、X、Y、Width、Height をサポートしておらず、これらにアクセスしようとすると System.NotSupportedException がスローされます。

Example of usage:

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
#### **SmartArtShapeCollection クラス、ISmartArtShapeCollection インターフェイス、および ISmartArtNode.Shapes プロパティが追加**
Aspose.Slides.SmartArt.SmartArtShapeCollection クラス（およびそのインターフェイス Aspose.Slides.SmartArt.ISmartArtShapeCollection）は、SmartArt 図の個々のシェイプへのアクセスを提供します。このコレクションは SmartArtNode に関連付けられたシェイプを含みます。SmartArtNode.Shapes プロパティは、そのノードに関連付けられたすべてのシェイプのコレクションを返します。

{{% alert color="primary" %}} 

**注意**: SmartArtLayoutType によっては、1 つの SmartArtShape が複数のノード間で共有される場合があります。

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
#### **ページ番号を保持したスライド保存用メソッドが追加**
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