---
title: Python 用プレゼンテーション チャートのプロット領域をカスタマイズ
linktitle: プロット領域
type: docs
url: /ja/python-net/chart-plot-area/
keywords:
- チャート
- プロット領域
- プロット領域幅
- プロット領域高さ
- プロット領域サイズ
- レイアウトモード
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのチャート プロット領域をカスタマイズする方法をご紹介します。スライドのビジュアルを簡単に向上させましょう。"
---

## **チャート プロット領域の幅と高さを取得**
Aspose.Slides for Python via .NET は、シンプルな API を提供します。

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Access first slide.
3. Add chart with default data.
4. Call method IChart.ValidateChartLayout() before to get actual values.
5. Gets actual X location (left) of the chart element relative to the left top corner of the chart.
6. Gets actual top of the chart element relative to the left top corner of the chart.
7. Gets actual width of the chart element.
8. Gets actual height of the chart element.

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
	
	# Save presentation with chart
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **チャート プロット領域のレイアウトモードを設定**
Aspose.Slides for Python via .NET は、チャート プロット領域のレイアウトモードを設定するためのシンプルな API を提供します。**LayoutTargetType** プロパティが **ChartPlotArea** および **IChartPlotArea** クラスに追加されました。プロット領域のレイアウトが手動で定義されている場合、このプロパティは、領域を内部（軸と軸ラベルを含まない）でレイアウトするか、外部（軸と軸ラベルを含む）でレイアウトするかを指定します。**LayoutTargetType** 列挙体で定義されている 2 つの可能な値があります。

- **LayoutTargetType.Inner** - プロット領域のサイズが領域のサイズを決定し、目盛りや軸ラベルは含まれません。
- **LayoutTargetType.Outer** - プロット領域のサイズが領域のサイズ、目盛り、軸ラベルを決定します。

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

## **FAQ**

**actual_x、actual_y、actual_width、actual_height はどの単位で返されますか？**

ポイント単位です。1 インチ = 72 ポイントです。これは Aspose.Slides の座標単位です。

**内容の観点で、プロット領域はチャート領域とどのように異なりますか？**

プロット領域はデータ描画領域（系列、グリッドライン、トレンドラインなど）です。チャート領域はタイトルや凡例などの周囲要素を含みます。3D チャートの場合、プロット領域は壁/床と軸も含みます。

**レイアウトが手動の場合、プロット領域の X、Y、幅、高さはどのように解釈されますか？**

チャート全体のサイズに対する比率（0〜1）として扱われます。このモードでは自動配置が無効になり、設定した比率が使用されます。

**凡例を追加/移動した後、プロット領域の位置が変わったのはなぜですか？**

凡例はプロット領域の外側のチャート領域に配置されますが、レイアウトと利用可能なスペースに影響するため、自動配置が有効な場合にプロット領域がずれることがあります。（これは PowerPoint のチャートで標準的な動作です。）