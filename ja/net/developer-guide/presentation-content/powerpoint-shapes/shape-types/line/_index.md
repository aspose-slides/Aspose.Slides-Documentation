---
title: 線
type: docs
weight: 50
url: /ja/net/Line/
keywords: "線, PowerPoint 形状, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションに線を追加する"
---

Aspose.Slides for .NET は、スライドにさまざまな種類の形状を追加することをサポートしています。このトピックでは、スライドに線を追加することで形状の操作を始めます。Aspose.Slides for .NET を使用すると、開発者はシンプルな線を作成するだけでなく、スライドにいくつかのファンシーな線を描くこともできます。
## **シンプルな線の作成**
プレゼンテーションの選択したスライドにシンプルなプレーン線を追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Shapes オブジェクトによって公開された [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) メソッドを使用して、ライン型のオートシェイプを追加します。
- 修正したプレゼンテーションを PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに線を追加しました。

```c#
// PPTX ファイルを表す PresentationEx クラスのインスタンスを作成
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得
    ISlide sld = pres.Slides[0];

    // ライン型のオートシェイプを追加
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // PPTX をディスクに保存
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **矢印型の線の作成**
Aspose.Slides for .NET は、開発者が線のいくつかのプロパティを設定して、見た目をより魅力的にすることを可能にします。線を矢印のように見せるために、いくつかのプロパティを設定してみましょう。以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Shapes オブジェクトによって公開された AddAutoShape メソッドを使用して、ライン型のオートシェイプを追加します。
- Aspose.Slides for .NET によって提供されるスタイルのいずれかに線のスタイルを設定します。
- 線の幅を設定します。
- Aspose.Slides for .NET によって提供されるスタイルのいずれかに線の [ダッシュスタイル](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle)を設定します。
- 線の始点の [矢印の先端スタイル](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle)と長さを設定します。
- 線の終点の矢印の先端スタイルと長さを設定します。
- 修正したプレゼンテーションを PPTX ファイルとして保存します。

```c#
// PPTX ファイルを表す PresentationEx クラスのインスタンスを作成
using (Presentation pres = new Presentation())
{

    // 最初のスライドを取得
    ISlide sld = pres.Slides[0];

    // ライン型のオートシェイプを追加
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 線にいくつかのフォーマットを適用
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