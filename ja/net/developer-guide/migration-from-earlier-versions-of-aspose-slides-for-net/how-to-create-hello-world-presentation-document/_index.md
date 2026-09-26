---
title: .NET で Hello World プレゼンテーションを作成する方法
linktitle: Hello World プレゼンテーション
type: docs
weight: 10
url: /ja/net/how-to-create-hello-world-presentation-document/
keywords:
- 移行
- ハローワールド
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
description: ".NET で Aspose.Slides を使用して、レガシー API とモダン API の両方を使ったシンプルなガイドで、Hello World の PowerPoint PPT、PPTX、および ODP プレゼンテーションを作成します。"
---
{{% alert color="info" %}} 
新しい [Aspose.Slides for .NET API](/slides/ja/net/) がリリースされ、この単一製品で最初から PowerPoint ドキュメントを生成し、既存のものを編集する機能がサポートされました。
{{% /alert %}} 
## **レガシーコードのサポート**
13.x より前の Aspose.Slides for .NET バージョンで開発されたレガシーコードを使用するには、コードに少しだけ変更を加える必要がありますが、コードは従来どおり動作します。旧版 Aspose.Slides for .NET の Aspose.Slide および Aspose.Slides.Pptx 名前空間に存在したすべてのクラスは、現在単一の Aspose.Slides 名前空間に統合されています。レガシー Aspose.Slides API で Hello World プレゼンテーション ドキュメントを作成する以下のシンプルなコードスニペットをご覧いただき、新しい統合 API への移行手順をご確認ください。
## **レガシー Aspose.Slides for .NET アプローチ**
```c#
using System.Drawing;
using Aspose.Slides;

//Instantiate a Presentation object that represents a PPT file
// => PPT ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation();

//Create a License object
// => License オブジェクトを作成します
License license = new License();

//Set the license of Aspose.Slides for .NET to avoid the evaluation limitations
// => 評価制限を回避するために Aspose.Slides for .NET のライセンスを設定します
license.SetLicense("Aspose.Slides.lic");

//Adding an empty slide to the presentation and getting the reference of
// => プレゼンテーションに空のスライドを追加し、参照を取得します
//that empty slide
// => その空のスライド
Slide slide = pres.AddEmptySlide();

//Adding a rectangle (X=2400, Y=1800, Width=1000 & Height=500) to the slide
// => スライドに長方形 (X=2400, Y=1800, 幅=1000, 高さ=500) を追加します
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Hiding the lines of rectangle
// => 長方形の枠線を非表示にします
rect.LineFormat.ShowLines = false;

//Adding a text frame to the rectangle with "Hello World" as a default text
// => 長方形にテキストフレームを追加し、デフォルトテキストとして "Hello World" を設定します
rect.AddTextFrame("Hello World");

//Removing the first slide of the presentation which is always added by
// => プレゼンテーションの最初のスライドを削除します（このスライドは常に
//Aspose.Slides for .NET by default while creating the presentation
// => Aspose.Slides for .NET によってデフォルトで作成されるものです）
pres.Slides.RemoveAt(0);

//Writing the presentation as a PPT file
// => プレゼンテーションを PPT ファイルとして書き込みます
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