---
title: 長方形
type: docs
weight: 80
url: /ja/net/rectangle/
keywords: "長方形を作成, PowerPoint形状, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションに長方形を作成する"
---


## **単純な長方形を作成する**
前のトピックと同様に、これは形状を追加することに関するもので、今回は長方形について説明します。このトピックでは、開発者がAspose.Slides for .NETを使用してスライドに単純または形式設定された長方形を追加する方法について説明します。プレゼンテーションの選択したスライドに単純な長方形を追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapesオブジェクトによって公開されたAddAutoShapeメソッドを使用して、長方形タイプのIAutoShapeを追加します。
1. 変更されたプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、プレゼンテーションの最初のスライドに単純な長方形を追加しました。

```c#
// PPTXを表すPresentationクラスをインスタンス化します
using (Presentation pres = new Presentation())
{

    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // 長方形タイプの自動形状を追加します
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // PPTXファイルをディスクに書き込みます
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **形式設定された長方形を作成する**
スライドに形式設定された長方形を追加するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. IShapesオブジェクトによって公開されたAddAutoShapeメソッドを使用して、長方形タイプのIAutoShapeを追加します。
1. 長方形の塗りつぶしタイプをソリッドに設定します。
1. IShapeオブジェクトに関連するFillFormatオブジェクトによって公開されたSolidFillColor.Colorプロパティを使用して、長方形の色を設定します。
1. 長方形の線の色を設定します。
1. 長方形の線の幅を設定します。
1. 変更されたプレゼンテーションをPPTXファイルとして書き込みます。
   上記の手順は、以下の例に実装されています。

```c#
// PPTXを表すPresentationクラスをインスタンス化します
using (Presentation pres = new Presentation())
{

    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // 長方形タイプの自動形状を追加します
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 長方形の形状にいくつかの形式設定を適用します
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // 長方形の線にいくつかの形式設定を適用します
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // PPTXファイルをディスクに書き込みます
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```