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
description: "レガシーおよびモダン API の両方を使用して、Aspose.Slidesで .NET における Hello World の PowerPoint PPT、PPTX、ODP プレゼンテーションを作成するシンプルなガイドです。"
---

{{% alert color="primary" %}} 

新しい [Aspose.Slides for .NET API](/slides/ja/net/) がリリースされ、現在この単一製品は最初から PowerPoint ドキュメントを生成し、既存のドキュメントを編集する機能をサポートしています。

{{% /alert %}} 
## **レガシーコードのサポート**
13.x 以前の Aspose.Slides for .NET バージョンで作成されたレガシーコードを使用するには、コードにいくつか小さな変更を加える必要がありますが、変更後も従来どおり動作します。旧 Aspose.Slides for .NET の Aspose.Slide および Aspose.Slides.Pptx 名前空間にあったすべてのクラスは、現在単一の Aspose.Slides 名前空間に統合されています。以下のシンプルなコードスニペットでレガシー Aspose.Slides API を使用して Hello World プレゼンテーション ドキュメントを作成する例をご覧いただき、新しい統合 API への移行手順をご確認ください。
## **レガシー Aspose.Slides for .NET アプローチ**
```c#
//PPT ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation();

//License オブジェクトを作成します
License license = new License();

//評価制限を回避するために Aspose.Slides for .NET のライセンスを設定します
license.SetLicense("Aspose.Slides.lic");

//プレゼンテーションに空のスライドを追加し、参照を取得します
//その空のスライド
Slide slide = pres.AddEmptySlide();

//スライドに矩形 (X=2400, Y=1800, Width=1000 & Height=500) を追加します
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//矩形の線を非表示にします
rect.LineFormat.ShowLines = false;

//矩形にテキストフレームを追加し、デフォルトテキストとして "Hello World" を設定します
rect.AddTextFrame("Hello World");

//プレゼンテーションの最初のスライドを削除します。このスライドは常に
//Aspose.Slides for .NET がデフォルトで作成時に追加するものです
pres.Slides.RemoveAt(0);

//プレゼンテーションを PPT ファイルとして書き出します
pres.Write("C:\\hello.ppt");
```




## **新しい Aspose.Slides for .NET 13.x アプローチ**
```c#
// Presentation をインスタンス化
Presentation pres = new Presentation();

// 最初のスライドを取得
ISlide sld = (ISlide)pres.Slides[0];

// 矩形タイプの AutoShape を追加
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// 矩形に ITextFrame を追加
ashp.AddTextFrame("Hello World");

// テキストの色を黒に変更 (デフォルトは白です)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// 矩形の線の色を白に変更
ashp.ShapeStyle.LineColor.Color = Color.White;

// シェイプの塗りつぶし設定をすべて削除
ashp.FillFormat.FillType = FillType.NoFill;

// プレゼンテーションをディスクに保存
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
