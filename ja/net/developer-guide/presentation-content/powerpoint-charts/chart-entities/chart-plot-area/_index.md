---
title: .NET のプレゼンテーションチャートのプロット領域をカスタマイズする
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
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションのチャート プロット領域をカスタマイズする方法を紹介します。スライドのビジュアルを簡単に向上させましょう。"
---

## **チャート プロット領域の幅と高さを取得する**
Aspose.Slides for .NET はシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルト データでチャートを追加します。
1. 実際の値を取得するために IChart.ValidateChartLayout() メソッドを呼び出します。
1. チャート要素の実際の X 座標（左）を、チャートの左上隅に対する相対位置で取得します。
1. チャート要素の実際の上位置を、チャートの左上隅に対する相対位置で取得します。
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
	
	// チャート付きのプレゼンテーションを保存
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```





## **チャート プロット領域のレイアウト モードを設定する**
Aspose.Slides for .NET はチャート プロット領域のレイアウト モードを設定するためのシンプルな API を提供します。**LayoutTargetType** プロパティが **ChartPlotArea** と **IChartPlotArea** クラスに追加されました。プロット領域のレイアウトが手動で定義されている場合、このプロパティは領域の内側（軸と軸ラベルを除く）でレイアウトするか、外側（軸と軸ラベルを含む）でレイアウトするかを指定します。**LayoutTargetType** 列挙体に定義されている 2 つの可能な値があります。

- **LayoutTargetType.Inner** - プロット領域のサイズが領域のサイズを決定し、目盛りと軸ラベルは含めないことを指定します。
- **LayoutTargetType.Outer** - プロット領域のサイズが領域のサイズ、目盛り、および軸ラベルを決定することを指定します。

以下にサンプル コードを示します。
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

ポイント単位です。1 インチ = 72 ポイントです。これは Aspose.Slides の座標単位です。

**プロット領域はコンテンツ的にチャート領域とどう違いますか？**

プロット領域はデータ描画領域（系列、グリッド線、トレンドライン etc.）です。チャート領域は周囲の要素（タイトル、凡例 etc.）を含みます。3D チャートの場合、プロット領域は壁/床と軸も含みます。

**レイアウトが手動の場合、プロット領域の X、Y、幅、高さはどのように解釈されますか？**

それらはチャート全体サイズに対する割合（0〜1）です。このモードでは自動配置が無効になり、設定した割合が使用されます。

**凡例を追加/移動した後、プロット領域の位置が変わったのはなぜですか？**

凡例はプロット領域の外側のチャート領域に配置されますが、レイアウトと利用可能なスペースに影響するため、自動配置が有効な場合にプロット領域がずれることがあります。（これは PowerPoint チャートの標準的な動作です。）