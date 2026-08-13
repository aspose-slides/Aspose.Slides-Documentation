---
title: .NET で Hello World プレゼンテーションを作成する方法
linktitle: Hello World プレゼンテーション
type: docs
weight: 10
url: /ja/net/how-to-create-hello-world-presentation-document/
keywords:
- 移行
- Hello World
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
- description: ".NET と Aspose.Slides を使用し、レガシー API とモダン API の両方で Hello World の PowerPoint PPT、PPTX、ODP プレゼンテーションを作成するシンプルなガイドです。"
---
{{% alert color="info" %}}

新しい [Aspose.Slides for .NET API](/slides/ja/net/) がリリースされ、この単一製品でスクラッチから PowerPoint ドキュメントを生成し、既存のものを編集する機能がサポートされました。

{{% /alert %}}
## **レガシーコードのサポート**
13.x 以前の Aspose.Slides for .NET バージョンで開発されたレガシーコードを使用するには、コードに少し変更を加える必要がありますが、変更後は従来どおり動作します。以前の Aspose.Slides for .NET にあった Aspose.Slide および Aspose.Slides.Pptx 名前空間のすべてのクラスは、現在単一の Aspose.Slides 名前空間に統合されています。レガシー Aspose.Slides API で Hello World プレゼンテーション ドキュメントを作成する簡単なコードスニペットを以下に示しますので、新しい統合 API への移行手順をご確認ください。
## **レガシー Aspose.Slides for .NET アプローチ**
```c#
using System.Drawing;
using Aspose.Slides;

//PPT ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation();

//License オブジェクトを作成します
License license = new License();

//評価制限を回避するために Aspose.Slides for .NET のライセンスを設定します
license.SetLicense("Aspose.Slides.lic");

//プレゼンテーションに空のスライドを追加し、その参照を取得します
//その空のスライド
Slide slide = pres.AddEmptySlide();

//スライドに矩形 (X=2400, Y=1800, Width=1000, Height=500) を追加します
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//矩形の線を非表示にします
rect.LineFormat.ShowLines = false;

//矩形にテキストフレームを追加し、デフォルトテキストとして "Hello World" を設定します
rect.AddTextFrame("Hello World");

//プレゼンテーションの最初のスライドを削除します。このスライドは常に
//Aspose.Slides for .NET がプレゼンテーション作成時にデフォルトで追加するものです
pres.Slides.RemoveAt(0);

//プレゼンテーションを書き出して PPT ファイルとして保存します
pres.Write("C:\\hello.ppt");
```



## **新しい Aspose.Slides for .NET 13.x アプローチ**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate Presentation
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```