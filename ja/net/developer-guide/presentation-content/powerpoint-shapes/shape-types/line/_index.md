---
title: 線
type: docs
weight: 50
url: /ja/net/Line/
keywords: "線, PowerPoint の図形, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションに線を追加する"
---

Aspose.Slides for .NET は、スライドにさまざまな種類の図形を追加することをサポートしています。このトピックでは、図形にラインを追加して作業を開始します。Aspose.Slides for .NET を使用すると、開発者は単純な直線を作成できるだけでなく、スライド上に装飾的な直線も描くことができます。

## **単純な直線の作成**
スライドにシンプルな直線を追加するには、以下の手順に従ってください。

- インスタンスを作成します [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスです。
- インデックスを使用してスライドの参照を取得します。
- Shapes オブジェクトが提供する [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) メソッドを使用して、Line タイプの AutoShape を追加します。
- 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。

以下の例では、プレゼンテーションの最初のスライドに直線を追加しています。
```c#
// PPTX ファイルを表す PresentationEx クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // ライン型のオートシェイプを追加します
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Write PPTX をディスクに保存します
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **矢印形状の線の作成**
Aspose.Slides for .NET は、線の外観を調整するためのプロパティも設定できます。線を矢印のように見せるプロパティを設定してみましょう。以下の手順に従ってください。

- インスタンスを作成します [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/)。
- インデックスを使用してスライドの参照を取得します。
- Shapes オブジェクトが提供する AddAutoShape メソッドを使用して、Line タイプの AutoShape を追加します。
- Aspose.Slides for .NET が提供するスタイルのいずれかにラインスタイルを設定します。
- ラインの幅を設定します。
- Aspose.Slides for .NET が提供するスタイルのいずれかに、ラインの[Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) を設定します。
- ラインの開始点の[Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) と長さを設定します。
- ラインの終了点のArrow Head Style と長さを設定します。
- 変更されたプレゼンテーションを書き出して PPTX ファイルとして保存します。
```c#
// PPTX ファイルを表す PresentationEx クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{

    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // ライン型のオートシェイプを追加します
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // ラインにいくつかの書式設定を適用します
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    // PPTX をディスクに保存します
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```


## **よくある質問**

**通常の線をコネクタに変換して形状に「スナップ」させることはできますか？**

いいえ。通常の線（[AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) の [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) タイプ）は自動的にコネクタにはなりません。形状にスナップさせるには、専用の [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) タイプと[corresponding APIs](/slides/ja/net/connector/) を使用してください。

**テーマから継承された線のプロパティで、最終的な値が判別しにくい場合、どうすればよいですか？**

[Read the effective properties](/slides/ja/net/shape-effective-properties/) を [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) クラスを通じて確認してください。これらのクラスは継承とテーマスタイルをすでに考慮しています。

**線を編集（移動、サイズ変更）できないようにロックできますか？**

はい。Shapes は [lock objects](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) を提供しており、[disallow editing operations](/slides/ja/net/applying-protection-to-presentation/) を行うことができます。