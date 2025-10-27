---
title: Python 用プレゼンテーションチャートのプロット領域をカスタマイズする
linktitle: プロット領域
type: docs
url: /ja/python-net/developer-guide/presentation-content/powerpoint-charts/chart-entities/chart-plot-area/
keywords:
- チャート
- プロット領域
- プロット領域の幅
- プロット領域の高さ
- プロット領域のサイズ
- レイアウトモード
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのチャートプロット領域をカスタマイズする方法をご紹介します。スライドのビジュアルを手軽に向上させましょう。"
---

## **チャートのプロット領域の幅と高さの取得**
Aspose.Slides for Python via .NET はシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルトデータでチャートを追加します。
4. 実際の値を取得するために、IChart.ValidateChartLayout() メソッドを呼び出します。
5. チャート要素の実際の X 位置（左）を、チャートの左上隅に対する相対位置として取得します。
6. チャート要素の実際の上部位置を、チャートの左上隅に対する相対位置として取得します。
7. チャート要素の実際の幅を取得します。
8. チャート要素の実際の高さを取得します。

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

## **チャートのプロット領域のレイアウトモードの設定**
Aspose.Slides for Python via .NET は、チャートのプロット領域のレイアウトモードを設定するシンプルな API を提供します。**LayoutTargetType** プロパティが **ChartPlotArea** および **IChartPlotArea** クラスに追加されました。プロット領域のレイアウトが手動で定義されている場合、このプロパティは領域を内部（軸と軸ラベルを除く）でレイアウトするか、外部（軸と軸ラベルを含む）でレイアウトするかを指定します。**LayoutTargetType** 列挙体で定義されている2つの可能な値があります。

- **LayoutTargetType.Inner** - プロット領域のサイズが領域のサイズを決定し、目盛りと軸ラベルは含まれないことを指定します。
- **LayoutTargetType.Outer** - プロット領域のサイズが領域のサイズ、目盛り、および軸ラベルを決定することを指定します。

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
ポイント単位です。1 インチ = 72 ポイントです。これらは Aspose.Slides の座標単位です。

**コンテンツの観点で、プロット領域はチャート領域とどのように異なりますか？**  
プロット領域はデータ描画領域（系列、グリッド線、トレンドラインなど）です。チャート領域はそれに加えてタイトルや凡例などの周囲要素を含みます。3D チャートの場合、プロット領域には壁・床および軸も含まれます。

**レイアウトが手動の場合、プロット領域の X、Y、幅、高さはどのように解釈されますか？**  
それらはチャート全体サイズに対する割合（0〜1）で表されます。このモードでは自動配置が無効になり、設定した割合が使用されます。

**凡例を追加/移動した後にプロット領域の位置が変わったのはなぜですか？**  
凡例はプロット領域の外側のチャート領域に配置されますが、レイアウトや利用可能なスペースに影響するため、自動配置が有効な場合はプロット領域がずれることがあります。（これは PowerPoint チャートの標準的な動作です。）