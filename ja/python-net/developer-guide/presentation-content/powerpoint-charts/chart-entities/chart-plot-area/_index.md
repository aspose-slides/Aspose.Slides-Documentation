---
title: Python でプレゼンテーションチャートのプロット領域をカスタマイズする
linktitle: プロット領域
type: docs
url: /ja/python-net/chart-plot-area/
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのチャートプロット領域をカスタマイズする方法を学びましょう。スライドのビジュアルを簡単に向上させることができます。"
---

## **Get Width, Height of Chart Plot Area**
Aspose.Slides for Python via .NET はシンプルな API を提供します。

1. **[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)** クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. 実際の値を取得するために、IChart.ValidateChartLayout() メソッドを呼び出します。
1. チャート要素の左上隅からの実際の X 位置（左）を取得します。
1. チャート要素の左上隅からの実際の上位置を取得します。
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
	
	# チャート付きプレゼンテーションを保存
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```





## **Set Layout Mode of Chart Plot Area**
Aspose.Slides for Python via .NET はチャートプロット領域のレイアウト モードを設定するシンプルな API を提供します。**LayoutTargetType** プロパティが **ChartPlotArea** と **IChartPlotArea** クラスに追加されました。プロット領域のレイアウトが手動で定義されている場合、このプロパティは領域を内部（軸や軸ラベルを含まない）でレイアウトするか、外部（軸や軸ラベルを含む）でレイアウトするかを指定します。**LayoutTargetType** 列挙体で定義されている 2 つの可能な値があります。

- **LayoutTargetType.Inner** - プロット領域のサイズが領域のサイズを決定し、目盛りや軸ラベルは含まれません。
- **LayoutTargetType.Outer** - プロット領域のサイズが領域、目盛り、軸ラベルのサイズを決定します。

サンプルコードは以下です。
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

ポイント単位です。1 インチ = 72 ポイント。これは Aspose.Slides の座標単位です。

**プロット領域はコンテンツの観点でチャート領域とどう違いますか？**

プロット領域はデータ描画領域（系列、グリッド線、トレンドラインなど）です。チャート領域はタイトルや凡例などの周囲要素を含みます。3D チャートの場合、プロット領域は壁・床および軸も含みます。

**レイアウトが手動の場合、プロット領域の X、Y、幅、高さはどのように解釈されますか？**

チャート全体サイズに対する割合（0–1）として扱われます。このモードでは自動位置決めが無効になり、設定した割合が使用されます。

**凡例を追加/移動した後にプロット領域の位置が変わったのはなぜですか？**

凡例はプロット領域の外側にあるチャート領域に配置されますが、レイアウトと利用可能なスペースに影響を与えるため、自動位置決めが有効な場合にはプロット領域がシフトすることがあります。（これは PowerPoint のチャートで標準的な動作です。）