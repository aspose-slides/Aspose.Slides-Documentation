---
title: .NETでHello Worldプレゼンテーションを作成する方法
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
- description: " .NETでAspose.Slidesを使用して、レガシーおよびモダンAPIの両方でHello WorldのPowerPoint PPT、PPTX、ODPプレゼンテーションを作成するシンプルなガイドです。"
---

{{% alert color="primary" %}}
新しい[Aspose.Slides for .NET API](/slides/ja/net/)がリリースされ、この単一製品は最初からPowerPoint文書を生成し、既存の文書を編集する機能をサポートします。
{{% /alert %}}
## **レガシーコードのサポート**
13.x以前のAspose.Slides for .NETバージョンで開発されたレガシーコードを使用するには、コードにいくつかの小さな変更を加える必要がありますが、変更後も従来どおり動作します。旧Aspose.Slides for .NETでAspose.SlideおよびAspose.Slides.Pptx名前空間に存在していたすべてのクラスは、現在単一のAspose.Slides名前空間に統合されています。以下のシンプルなコードスニペットで、レガシーAspose.Slides APIを使用したHello Worldプレゼンテーション文書の作成方法をご確認いただき、新しい統合APIへの移行手順をご参照ください。
## **レガシーAspose.Slides for .NETのアプローチ**
```c#
//PPT ファイルを表す Presentation オブジェクトをインスタンス化する
Presentation pres = new Presentation();

//License オブジェクトを作成する
License license = new License();

//評価制限を回避するために Aspose.Slides for .NET のライセンスを設定する
license.SetLicense("Aspose.Slides.lic");

//プレゼンテーションに空のスライドを追加し、参照を取得する
//その空のスライド
Slide slide = pres.AddEmptySlide();

//スライドに矩形 (X=2400, Y=1800, 幅=1000, 高さ=500) を追加する
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//矩形の線を非表示にする
rect.LineFormat.ShowLines = false;

//矩形にテキストフレームを追加し、デフォルトテキストとして "Hello World" を設定する
rect.AddTextFrame("Hello World");

//プレゼンテーションの最初のスライドを削除する（このスライドは常に
//Aspose.Slides for .NET によってデフォルトで作成時に追加されるものです）
pres.Slides.RemoveAt(0);

//プレゼンテーションを PPT ファイルとして書き出す
pres.Write("C:\\hello.ppt");
```


## **新しいAspose.Slides for .NET 13.xのアプローチ**
```c#
// Presentation をインスタンス化
Presentation pres = new Presentation();

// 最初のスライドを取得
ISlide sld = (ISlide)pres.Slides[0];

// Rectangle タイプの AutoShape を追加
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Rectangle に ITextFrame を追加
ashp.AddTextFrame("Hello World");

// テキストの色を黒に変更（デフォルトは白）
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// 矩形の線の色を白に変更
ashp.ShapeStyle.LineColor.Color = Color.White;

// シェイプの塗りつぶし設定を削除
ashp.FillFormat.FillType = FillType.NoFill;

// プレゼンテーションをディスクに保存
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
