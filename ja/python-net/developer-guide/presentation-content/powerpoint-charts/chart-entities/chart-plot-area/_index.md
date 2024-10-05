---
title: チャートプロットエリア
type: docs
url: /python-net/chart-plot-area/
keywords: "チャートプロットエリア PowerPoint プレゼンテーション、Python、Aspose.Slides for Python via .NET"
description: "チャートプロットエリアの幅と高さを取得します。レイアウトモードを設定します。PythonでのPowerPointプレゼンテーション"
---

## **チャートプロットエリアの幅と高さを取得する**
Aspose.Slides for Python via .NET はシンプルなAPIを提供します。 

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. 実際の値を取得する前にメソッド IChart.ValidateChartLayout() を呼び出します。
1. チャートの左上隅に対するチャート要素の実際のX位置（左）を取得します。
1. チャートの左上隅に対するチャート要素の実際の上部を取得します。
1. チャート要素の実際の幅を取得します。
1. チャート要素の実際の高さを取得します。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# チャート付きのプレゼンテーションを保存
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```




## **チャートプロットエリアのレイアウトモードを設定する**
Aspose.Slides for Python via .NET はチャートプロットエリアのレイアウトモードを設定するためのシンプルなAPIを提供します。プロパティ **LayoutTargetType** が **ChartPlotArea** および **IChartPlotArea** クラスに追加されました。プロットエリアのレイアウトが手動で定義された場合、このプロパティはプロットエリアを内部（軸と軸ラベルを含まない）または外部（軸と軸ラベルを含む）でレイアウトするかどうかを指定します。 **LayoutTargetType** 列挙型で定義された2つの可能な値があります。

- **LayoutTargetType.Inner** - プロットエリアのサイズは、ティックマークと軸ラベルを含まないプロットエリアのサイズを決定することを指定します。
- **LayoutTargetType.Outer** - プロットエリアのサイズは、ティックマークと軸ラベルを含むプロットエリアのサイズを決定することを指定します。

サンプルコードは以下の通りです。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```