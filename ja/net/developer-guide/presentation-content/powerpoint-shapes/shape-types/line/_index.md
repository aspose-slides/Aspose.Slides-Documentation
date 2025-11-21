---
title: ".NET でプレゼンテーションに線形状を追加"
linktitle: "線"
type: docs
weight: 50
url: /ja/net/Line/
keywords:
- "線"
- "線の作成"
- "線の追加"
- "プレーン線"
- "線の構成"
- "線のカスタマイズ"
- "ダッシュ スタイル"
- "矢印ヘッド"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションの線書式設定を操作する方法を学びます。プロパティ、メソッド、サンプルをご紹介します。"
---

Aspose.Slides for .NET はスライドにさまざまな形状を追加することをサポートしています。このトピックでは、線をスライドに追加して形状の操作を開始します。Aspose.Slides for .NET を使用すると、単純な線だけでなく、装飾的な線もスライド上に描画できます。

## **Create Plain Line**
プレゼンテーションの選択されたスライドに単純な直線を追加するには、以下の手順に従ってください。

- [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Shapes オブジェクトが提供する [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) メソッドを使用して、Line タイプの AutoShape を追加します。
- 変更したプレゼンテーションを書き出して PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに線を追加しています。
```c#
// PPTX ファイルを表す PresentationEx クラスのインスタンスを作成
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得
    ISlide sld = pres.Slides[0];

    // タイプが line のオートシェイプを追加
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // PPTX をディスクに保存
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```



## **Create Arrow Shaped Line**
Aspose.Slides for .NET は、線のプロパティを設定して外観を向上させることも可能です。矢印のような線にするためにいくつかのプロパティを設定してみましょう。以下の手順に従ってください。

- [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/)。
- インデックスを使用してスライドの参照を取得します。
- Shapes オブジェクトが提供する AddAutoShape メソッドを使用して、Line タイプの AutoShape を追加します。
- Aspose.Slides for .NET が提供するスタイルのうちの一つに線のスタイルを設定します。
- 線の幅を設定します。
- 線の [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) を Aspose.Slides for .NET が提供するスタイルのいずれかに設定します。
- 線の開始点の [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) と長さを設定します。
- 線の終了点の Arrow Head Style と長さを設定します。
- 変更したプレゼンテーションを書き出して PPTX ファイルとして保存します。
```c#
 // PPTX ファイルを表す PresentationEx クラスのインスタンスを作成
using (Presentation pres = new Presentation())
{

    // 最初のスライドを取得
    ISlide sld = pres.Slides[0];

    // タイプが line のオートシェイプを追加
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // ラインにいくつかの書式設定を適用
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    // PPTX をディスクに保存
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

No. A regular line (an [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) of type [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) does not automatically become a connector. To make it snap to shapes, use the dedicated [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) type and the [corresponding APIs](/slides/ja/net/connector/) for connections.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Read the effective properties](/slides/ja/net/shape-effective-properties/) through the [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) interfaces—these already account for inheritance and theme styles.

**Can I lock a line against editing (moving, resizing)?**

Yes. Shapes provide [lock objects](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) that let you [disallow editing operations](/slides/ja/net/applying-protection-to-presentation/).