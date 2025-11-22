---
title: チャート プロット領域
type: docs
url: /ja/net/chart-plot-area/
keywords: "チャート プロット領域 PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "チャート プロット領域の幅と高さを取得します。レイアウトモードを設定します。C# または .NET による PowerPoint プレゼンテーション"
---

## **チャート プロット領域の幅と高さを取得する**
Aspose.Slides for .NET はシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルト データでチャートを追加します。
1. 実際の値を取得するために、IChart.ValidateChartLayout() メソッドを呼び出します。
1. チャート要素の左上隅に対する実際の X 位置（左）を取得します。
1. チャート要素の左上隅に対する実際の上位置を取得します。
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
	
	// チャートでプレゼンテーションを保存
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```





## **チャート プロット領域のレイアウトモードを設定する**
Aspose.Slides for .NET はチャート プロット領域のレイアウトモードを設定するためのシンプルな API を提供します。**LayoutTargetType** プロパティが **ChartPlotArea** と **IChartPlotArea** クラスに追加されました。プロット領域のレイアウトが手動で定義されている場合、このプロパティは領域を内部（軸と軸ラベルを含まない）でレイアウトするか、外部（軸と軸ラベルを含む）でレイアウトするかを指定します。**LayoutTargetType** 列挙体には 2 つの可能な値が定義されています。

- **LayoutTargetType.Inner** - プロット領域のサイズがプロット領域のサイズを決定し、目盛りと軸ラベルは含まれないことを指定します。
- **LayoutTargetType.Outer** - プロット領域のサイズがプロット領域、目盛り、軸ラベルのサイズを決定することを指定します。

サンプルコードは以下に示します。
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

ポイント単位です。1 インチ = 72 ポイントです。これらは Aspose.Slides の座標単位です。

**コンテンツの観点で、プロット領域はチャート領域とどのように異なりますか？**

プロット領域はデータ描画領域（系列、グリッド線、トレンドラインなど）です。チャート領域はタイトルや凡例などの周囲要素を含みます。3D チャートの場合、プロット領域には壁/床と軸も含まれます。

**レイアウトが手動の場合、プロット領域の X、Y、幅、そして高さはどのように解釈されますか？**

それらはチャート全体サイズに対する割合（0–1）です。このモードでは自動配置が無効になり、設定した割合が使用されます。

**凡例を追加/移動した後、プロット領域の位置が変わったのはなぜですか？**

凡例はプロット領域の外側のチャート領域に配置されますが、レイアウトと利用可能なスペースに影響するため、自動配置が有効な場合、プロット領域が移動することがあります。（これは PowerPoint チャートの標準的な動作です。）