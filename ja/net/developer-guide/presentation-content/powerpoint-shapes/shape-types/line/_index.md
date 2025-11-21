---
title: 線
type: docs
weight: 50
url: /ja/net/Line/
keywords: "線, PowerPoint シェイプ, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションに線を追加する"
---

Aspose.Slides for .NET はスライドにさまざまな種類のシェイプを追加することをサポートしています。本項では、シェイプの操作を開始するために、スライドに線を追加します。Aspose.Slides for .NET を使用すると、開発者は単純な線だけでなく、いくつかの装飾的な線もスライドに描画できます。
## **プレーンラインの作成**
プレゼンテーションの選択されたスライドにシンプルなプレーンラインを追加するには、以下の手順に従ってください：

- [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class のインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Shapes オブジェクトが提供する [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) メソッドを使用して、Line タイプの AutoShape を追加します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドに線を追加しています。
```c#
// PPTX ファイルを表す PresentationEx クラスのインスタンス化
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得
    ISlide sld = pres.Slides[0];

    // ラインタイプのオートシェイプを追加
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // PPTX をディスクに書き込む
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **矢印形状のラインの作成**
Aspose.Slides for .NET は、ラインの外観をより魅力的にするために、いくつかのプロパティを設定できるようにします。ラインを矢印のように見せるために、いくつかのプロパティを設定してみましょう。以下の手順に従ってください：

- [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/) のインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- Shapes オブジェクトが提供する AddAutoShape メソッドを使用して、Line タイプの AutoShape を追加します。
- Aspose.Slides for .NET が提供するスタイルのいずれかに Line Style を設定します。
- ラインの幅を設定します。
- ラインの [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) を Aspose.Slides for .NET が提供するスタイルのいずれかに設定します。
- ラインの開始点の [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) と長さを設定します。
- ラインの終了点の Arrow Head Style と長さを設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。
```c#
// PPTX ファイルを表す PresentationEx クラスをインスタンス化
using (Presentation pres = new Presentation())
{

    // 最初のスライドを取得
    ISlide sld = pres.Slides[0];

    // ラインタイプのオートシェイプを追加
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

    // PPTX をディスクに書き込む
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**通常の線をコネクタに変換してシェイプに「スナップ」させることはできますか？**

いいえ。通常の線（[AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) の [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) タイプ）は自動的にコネクタにはなりません。シェイプにスナップさせるには、専用の [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) タイプと、接続用の [corresponding APIs](/slides/ja/net/connector/) を使用してください。

**ラインのプロパティがテーマから継承されており、最終的な値を判断しにくい場合はどうすればよいですか？**

[Effective properties](/slides/ja/net/shape-effective-properties/) を [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) インターフェイスを通じて読み取ります。これらはすでに継承とテーマスタイルを考慮しています。

**ラインを編集（移動やサイズ変更）からロックできますか？**

はい。Shapes は [lock objects](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) を提供しており、[disallow editing operations](/slides/ja/net/applying-protection-to-presentation/) が可能です。