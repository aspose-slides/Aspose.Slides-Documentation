---
title: ".NET でプレゼンテーションにラインシェイプを追加する"
linktitle: "ライン"
type: docs
weight: 50
url: /ja/net/line/
keywords:
- "ライン"
- "ラインの作成"
- "ラインの追加"
- "プレーンライン"
- "ラインの構成"
- "ラインのカスタマイズ"
- "破線スタイル"
- "矢じり"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションのライン書式設定を操作する方法を学びます。プロパティ、メソッド、例をご紹介します。"
---
## **概要**

Aspose.Slides を使用すると、PowerPoint スライドにラインシェイプをプログラムで追加できます。本記事では、シンプルなラインの作成方法と、ラインを矢印のようにカスタマイズする方法を示します。

スライドにラインシェイプを追加し、外観を調整し、更新されたプレゼンテーションを保存する方法を学びます。例では、スタイル、幅、破線パターン、矢じりオプション、塗りつぶし色など、実用的なライン書式設定に焦点を当てています。

## **単純なラインの作成**
プレゼンテーションの選択されたスライドにシンプルな単純ラインを追加するには、以下の手順に従ってください。

- [Presentation ](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドへの参照を取得します。
- Shapes オブジェクトが提供する [AddAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/methods/addautoshape/index) メソッドを使用して、Line タイプの AutoShape を追加します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの最初のスライドにラインを追加しています。

```c#
 // PPTX ファイルを表す PresentationEx クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{
    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // ラインタイプのオートシェイプを追加します
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Write PPTX をディスクに書き込みます
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **矢印形状のラインの作成**
Aspose.Slides for .NET は、ラインの外観を向上させるためにいくつかのプロパティを設定できるようにします。ラインを矢印のように見せるために、いくつかのプロパティを設定してみましょう。以下の手順に従ってください。

- インスタンスを作成します [Presentation ](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/ja/aspose.slides/)[](http://www.aspose.com/api/net/slides/ja/aspose.slides/)。
- インデックスを使用してスライドへの参照を取得します。
- Shapes オブジェクトが提供する AddAutoShape メソッドを使用して、Line タイプの AutoShape を追加します。
- Aspose.Slides for .NET が提供するスタイルの中から Line Style を設定します。
- ラインの幅を設定します。
- ラインの [Dash Style](https://reference.aspose.com/slides/ja/net/aspose.slides/linedashstyle) を Aspose.Slides for .NET が提供するスタイルの中から設定します。
- ラインの開始点の [Arrow Head Style](https://reference.aspose.com/slides/ja/net/aspose.slides/linearrowheadstyle) と長さを設定します。
- ラインの終了点の矢じりスタイルと長さを設定します。
- 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

```c#
// PPTX ファイルを表す PresentationEx クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{

    // 最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // ラインタイプのオートシェイプを追加します
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

    //Write PPTX をディスクに書き込みます
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**通常のラインをコネクタに変換して図形に「スナップ」させることはできますか？**

いいえ。通常のライン（[AutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/) の [Line](https://reference.aspose.com/slides/ja/net/aspose.slides/shapetype/) タイプ）は自動的にコネクタにはなりません。図形にスナップさせるには、専用の [Connector](https://reference.aspose.com/slides/ja/net/aspose.slides/connector/) タイプと、接続用の [corresponding APIs](/slides/ja/net/connector/) を使用してください。

**ラインのプロパティがテーマから継承されていて最終的な値が判別しにくい場合はどうすればよいですか？**

[ILineFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/ja/net/aspose.slides/ilinefillformateffectivedata/) インターフェイスを介して [Read the effective properties](/slides/ja/net/shape-effective-properties/) を取得してください。これらは継承とテーマスタイルをすでに考慮しています。

**ラインを編集（移動、サイズ変更）からロックできますか？**

はい。Shapes は [lock objects](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/autoshapelock/) を提供しており、[disallow editing operations](/slides/ja/net/applying-protection-to-presentation/) を実行できます。