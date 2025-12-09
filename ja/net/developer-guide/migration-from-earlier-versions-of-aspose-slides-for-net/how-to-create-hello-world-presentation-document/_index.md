---
title: .NET でハローワールド プレゼンテーションを作成する方法
linktitle: ハローワールド プレゼンテーション
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
description: ".NET で Aspose.Slides を使用し、レガシー API とモダン API の両方を使ったシンプルなガイドで、ハローワールドの PowerPoint PPT、PPTX、ODP プレゼンテーションを作成します。"
---

{{% alert color="primary" %}} 
新しい [Aspose.Slides for .NET API](/slides/ja/net/) がリリースされ、この単一製品でスクラッチから PowerPoint ドキュメントを生成し、既存のものを編集する機能がサポートされました。
{{% /alert %}} 
## **レガシーコードのサポート**
13.x より前の Aspose.Slides for .NET バージョンで開発されたレガシーコードを使用するには、コードにいくつかの小さな変更を加える必要があり、変更後は従来どおりに動作します。旧 Aspose.Slides for .NET の Aspose.Slide および Aspose.Slides.Pptx 名前空間に存在したすべてのクラスは、現在単一の Aspose.Slides 名前空間に統合されています。以下のシンプルなコードスニペットをご覧いただき、レガシー Aspose.Slides API で Hello World プレゼンテーション ドキュメントを作成する方法を確認し、新しい統合 API への移行手順に従ってください。
## **レガシー Aspose.Slides for .NET アプローチ**
```c#
//PPT ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation();

//License オブジェクトを作成します
License license = new License();

//評価制限を回避するために Aspose.Slides for .NET のライセンスを設定します
license.SetLicense("Aspose.Slides.lic");

//プレゼンテーションに空のスライドを追加し、
//その空のスライドの参照を取得します
Slide slide = pres.AddEmptySlide();

//スライドに矩形 (X=2400, Y=1800, 幅=1000, 高さ=500) を追加します
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//矩形の枠線を非表示にします
rect.LineFormat.ShowLines = false;

//矩形にテキストフレームを追加し、デフォルトテキストとして「Hello World」を設定します
rect.AddTextFrame("Hello World");

//プレゼンテーションの最初のスライドを削除します（常に追加されるものは
//Aspose.Slides for .NET がデフォルトでプレゼンテーションを作成するときに追加されます）
pres.Slides.RemoveAt(0);

//プレゼンテーションを書き出して PPT ファイルに保存します
pres.Write("C:\\hello.ppt");
```


## **新しい Aspose.Slides for .NET 13.x アプローチ**
```c#
// プレゼンテーションをインスタンス化
Presentation pres = new Presentation();

// 最初のスライドを取得
ISlide sld = (ISlide)pres.Slides[0];

// 矩形タイプのAutoShapeを追加
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// 矩形にITextFrameを追加
ashp.AddTextFrame("Hello World");

// テキストの色を黒に変更（デフォルトは白）
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// 矩形の線の色を白に変更
ashp.ShapeStyle.LineColor.Color = Color.White;

// シェイプの塗りつぶし設定をすべて削除
ashp.FillFormat.FillType = FillType.NoFill;

// プレゼンテーションをディスクに保存
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
