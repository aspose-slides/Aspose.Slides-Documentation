---
title: プレゼンテーション チャートのプロット領域を .NET でカスタマイズ
linktitle: プロット領域
type: docs
url: /ja/net/chart-plot-area/
keywords:
- チャート
- プロット領域
- プロット領域の幅
- プロット領域の高さ
- プロット領域のサイズ
- レイアウト モード
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションのチャート プロット領域をカスタマイズする方法をご紹介します。スライドのビジュアルを簡単に向上させましょう。"
---

## **チャート プロット領域の幅と高さを取得する**
Aspose.Slides for .NET はシンプルな API を提供します。

1. Presentation クラスのインスタンスを作成します。([Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation))
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. 実際の値を取得するために、事前に IChart.ValidateChartLayout() メソッドを呼び出します。
1. チャート要素の左上隅を基準とした、実際の X 位置（左）を取得します。
1. チャート要素の左上隅を基準とした、実際の上位置を取得します。
1. チャート要素の実際の幅を取得します。
1. チャート要素の実際の高さを取得します。

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// チャートを含むプレゼンテーションを保存
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```


## **チャート プロット領域のレイアウト モードを設定する**
Aspose.Slides for .NET は、チャート プロット領域のレイアウト モードを設定するためのシンプルな API を提供します。プロパティ **LayoutTargetType** が **ChartPlotArea** および **IChartPlotArea** クラスに追加されました。プロット領域のレイアウトが手動で定義されている場合、このプロパティはプロット領域を内部（軸と軸ラベルを除く）でレイアウトするか、外部（軸と軸ラベルを含む）でレイアウトするかを指定します。**LayoutTargetType** 列挙体に定義されている 2 つの可能な値があります。

- **LayoutTargetType.Inner** - プロット領域のサイズがプロット領域自体のサイズを決定し、目盛りと軸ラベルは含まれないことを指定します。
- **LayoutTargetType.Outer** - プロット領域のサイズがプロット領域、目盛り、および軸ラベルのサイズを決定することを指定します。

以下にサンプルコードを示します。

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**ActualX、ActualY、ActualWidth、ActualHeight はどの単位で返されますか？**

ポイント単位です。1インチ = 72ポイントです。これは Aspose.Slides の座標単位です。

**プロット領域はコンテンツの観点でチャート領域とどのように異なりますか？**

プロット領域はデータ描画領域（系列、グリッド線、トレンドラインなど）です。一方、チャート領域は周囲の要素（タイトル、凡例など）を含みます。3D チャートでは、プロット領域は壁・床および軸も含みます。

**レイアウトが手動の場合、プロット領域の X、Y、幅、高さはどのように解釈されますか？**

チャート全体サイズに対する割合（0〜1）として解釈されます。このモードでは自動配置が無効になり、設定した割合が使用されます。

**凡例を追加/移動した後、プロット領域の位置が変わったのはなぜですか？**

凡例はプロット領域の外側のチャート領域に配置されますが、レイアウトと利用可能なスペースに影響を与えるため、自動配置が有効な場合にプロット領域が移動することがあります。（これは PowerPoint チャートの標準的な動作です。）