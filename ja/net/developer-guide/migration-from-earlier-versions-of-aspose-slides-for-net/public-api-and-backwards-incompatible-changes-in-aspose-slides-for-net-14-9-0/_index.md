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
description: "Aspose.Slides for .NET のパブリック API 更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行しましょう。"
---

{{% alert color="primary" %}} 

このページは、Aspose.Slides for .NET 14.9.0 APIで導入された、[追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/)または[削除](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/)されたクラス、メソッド、プロパティなど、その他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **ISmartArtNodeCollection に ICollection とジェネリック IEnumerable インターフェイスの継承が追加されました**
クラス Aspose.Slides.SmartArt.SmartArtNodeCollection（および関連インターフェイス Aspose.Slides.SmartArt.ISmartArtNodeCollection）は、ジェネリックインターフェイス IEnumerable<ISmartArtNode> とインターフェイス ICollection を継承します。
#### **SmartArtLayoutType.Custom 列挙値が追加されました**
Custom SmartArt レイアウトタイプは、カスタムテンプレートを使用した図を表します。カスタム図はプレゼンテーションファイルからのみ読み込むことができ、ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) メソッドでは作成できません。
#### **SmartArtShape クラスと ISmartArtShape インターフェイスが追加されました**
Aspose.Slides.SmartArt.SmartArtShape クラス（およびそのインターフェイス Aspose.Slides.SmartArt.ISmartArtShape）は、SmartArt 図の個々のシェイプへのアクセスを提供します。SmartArtShape は FillFormat や LineFormat の変更、ハイパーリンクの追加などに使用できます。

{{% alert color="primary" %}} 

**注**: SmartArtShape は IShape プロパティ RawFrame、Frame、Rotation、X、Y、Width、Height をサポートせず、これらにアクセスしようとすると System.NotSupportedException がスローされます。

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
#### **SmartArtShapeCollection クラス、ISmartArtShapeCollection インターフェイス、および ISmartArtNode.Shapes プロパティが追加されました**
Aspose.Slides.SmartArt.SmartArtShapeCollection クラス（およびそのインターフェイス Aspose.Slides.SmartArt.ISmartArtShapeCollection）は、SmartArt 図の個々のシェイプへのアクセスを提供します。このコレクションには SmartArtNode に関連付けられたシェイプが含まれます。SmartArtNode.Shapes プロパティは、ノードに関連付けられたすべてのシェイプのコレクションを返します。

{{% alert color="primary" %}} 

**注**: SmartArtLayoutType によっては、1 つの SmartArtShape が複数のノード間で共有されることがあります。

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
#### **ページ番号を保持したままスライドを保存するメソッドが追加されました**
以下のメソッドが追加されました:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

これらのメソッドにより、開発者は指定したプレゼンテーションスライドを PDF、XPS、TIFF、HTML 形式で保存できます。'slides' 配列はページ番号（1 から開始）を指定するために使用されます。
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array of slides positions

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **PPImage、IPPImage に画像置換メソッドが追加されました**
新しいメソッドが追加されました:

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