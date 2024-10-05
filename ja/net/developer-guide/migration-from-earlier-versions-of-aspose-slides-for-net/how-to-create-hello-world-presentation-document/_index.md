---
title: こんにちは世界プレゼンテーション文書の作成方法
type: docs
weight: 10
url: /net/how-to-create-hello-world-presentation-document/
---

{{% alert color="primary" %}} 

新しい[Aspose.Slides for .NET API](/slides/net/)がリリースされ、これによりこの単一の製品がゼロからPowerPoint文書を生成し、既存の文書を編集する機能をサポートするようになりました。

{{% /alert %}} 
## **レガシーコードのサポート**
Aspose.Slides for .NETの13.x以前に開発されたレガシーコードを使用するには、コードにいくつかの軽微な変更を加える必要があり、コードは以前と同様に動作します。古いAspose.Slides for .NETにあったAspose.SlideおよびAspose.Slides.Pptx名前空間のすべてのクラスは、単一のAspose.Slides名前空間に統合されました。レガシーAspose.Slides APIでHello Worldプレゼンテーション文書を作成するための以下の簡単なコードスニペットを参照し、新しい統合APIへの移行方法について説明する手順に従ってください。
## **レガシーAspose.Slides for .NETアプローチ**
```c#
// PPTファイルを表すプレゼンテーションオブジェクトをインスタンス化
Presentation pres = new Presentation();

// ライセンスオブジェクトを作成
License license = new License();

// 評価制限を避けるためにAspose.Slides for .NETのライセンスを設定
license.SetLicense("Aspose.Slides.lic");

// プレゼンテーションに空のスライドを追加し、その空のスライドの参照を取得
Slide slide = pres.AddEmptySlide();

// スライドに長方形（X=2400, Y=1800, 幅=1000 & 高さ=500）を追加
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

// 長方形の線を非表示に
rect.LineFormat.ShowLines = false;

// "Hello World"をデフォルトテキストとして長方形にテキストフレームを追加
rect.AddTextFrame("Hello World");

// プレゼンテーション作成時にAspose.Slides for .NETによって常に追加される最初のスライドを削除
pres.Slides.RemoveAt(0);

// プレゼンテーションをPPTファイルとして書き込む
pres.Write("C:\\hello.ppt");
```



## **新しいAspose.Slides for .NET 13.xアプローチ**
```c#
// プレゼンテーションをインスタンス化
Presentation pres = new Presentation();

// 最初のスライドを取得
ISlide sld = (ISlide)pres.Slides[0];

// 長方形型のAutoShapeを追加
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// 長方形にITextFrameを追加
ashp.AddTextFrame("Hello World");

// テキストの色を黒に変更（デフォルトは白）
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// 長方形の線の色を白に変更
ashp.ShapeStyle.LineColor.Color = Color.White;

// 形状の塗りつぶし形式を削除
ashp.FillFormat.FillType = FillType.NoFill;

// プレゼンテーションをディスクに保存
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```