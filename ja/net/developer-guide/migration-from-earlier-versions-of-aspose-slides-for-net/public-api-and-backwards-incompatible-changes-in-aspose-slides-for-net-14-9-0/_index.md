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
description: "Aspose.Slides for .NET のパブリック API 更新と破壊的変更をレビューし、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---
{{% alert color="info" %}} 

このページでは、Aspose.Slides for .NET 14.9.0 APIで導入された、[追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) または [削除](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) クラス、メソッド、プロパティなど、その他の変更をすべて一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **ISmartArtNodeCollection への ICollection およびジェネリック IEnumerable インターフェイスの継承が追加**
クラス Aspose.Slides.SmartArt.SmartArtNodeCollection（および関連インターフェイス Aspose.Slides.SmartArt.ISmartArtNodeCollection）は、ジェネリックインターフェイス IEnumerable<ISmartArtNode> とインターフェイス ICollection を継承します。
#### **SmartArtLayoutType.Custom 列挙値が追加**
Custom SmartArt レイアウトタイプは、カスタムテンプレートを持つ図を表します。カスタム図はプレゼンテーションファイルからのみ読み込むことができ、ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) メソッドでは作成できません。
#### **SmartArtShape クラスと ISmartArtShape インターフェイスが追加**
Aspose.Slides.SmartArt.SmartArtShape クラス（およびそのインターフェイス Aspose.Slides.SmartArt.ISmartArtShape）は、SmartArt 図内の個々のシェイプへのアクセスを提供します。SmartArtShape は FillFormat、LineFormat の変更、ハイパーリンクの追加、その他の操作に使用できます。

{{% alert color="info" %}} 

**注**: SmartArtShape は IShape プロパティ RawFrame、Frame、Rotation、X、Y、Width、Height をサポートせず、これらにアクセスしようとすると System.NotSupportedException がスローされます。

使用例:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **SmartArtShapeCollection クラス、ISmartArtShapeCollection インターフェイス、および ISmartArtNode.Shapes プロパティが追加**
Aspose.Slides.SmartArt.SmartArtShapeCollection クラス（およびそのインターフェイス Aspose.Slides.SmartArt.ISmartArtShapeCollection）は、SmartArt 図内の個々のシェイプへのアクセスを提供します。このコレクションには SmartArtNode に関連付けられたシェイプが含まれます。SmartArtNode.Shapes プロパティは、そのノードに関連付けられたすべてのシェイプのコレクションを返します。

{{% alert color="info" %}} 

**注**: SmartArtLayoutType によっては、1つの SmartArtShape が複数のノード間で共有されることがあります。

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **ページ番号を保持したスライド保存用メソッドが追加**
次のメソッドが追加されました:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

これらのメソッドにより、開発者は指定したプレゼンテーションのスライドを PDF、XPS、TIFF、HTML 形式で保存できます。'slides' 配列はページ番号（1 から開始）を指定するために使用されます。
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //スライド位置の配列

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **PPImage、IPPImage 用画像置換メソッドが追加**
新しいメソッドが追加されました:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //最初のメソッド

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //2番目のメソッド

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //3番目のメソッド

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```