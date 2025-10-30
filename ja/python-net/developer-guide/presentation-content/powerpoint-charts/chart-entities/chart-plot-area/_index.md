---
title: Python のプレゼンテーション チャートのプロット領域をカスタマイズする
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのチャートプロット領域をカスタマイズする方法をご紹介します。スライドのビジュアルを簡単に向上させましょう。"
---

## **チャート プロット領域の幅と高さを取得**
Aspose.Slides for Python via .NET は、シンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルト データでチャートを追加します。
4. 実際の値を取得するために、IChart.ValidateChartLayout() メソッドを呼び出します。
5. チャート要素の左上隅を基準とした実際の X 位置（左）を取得します。
6. チャート要素の左上隅を基準とした実際の上位置を取得します。
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
	
	# チャート付きプレゼンテーションを保存
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **チャート プロット領域のレイアウトモードを設定**
Aspose.Slides for Python via .NET は、チャート プロット領域のレイアウトモードを設定するシンプルな API を提供します。**LayoutTargetType** プロパティが **ChartPlotArea** および **IChartPlotArea** クラスに追加されました。プロット領域のレイアウトが手動で定義されている場合、このプロパティは領域を内部（軸や軸ラベルを除く）でレイアウトするか、外部（軸や軸ラベルを含む）でレイアウトするかを指定します。**LayoutTargetType** 列挙型で定義されている 2 つの可能な値があります。

- **LayoutTargetType.Inner** - プロット領域のサイズが領域のサイズを決定し、目盛りや軸ラベルを含まないことを指定します。
- **LayoutTargetType.Outer** - プロット領域のサイズが領域のサイズ、目盛り、軸ラベルを決定することを指定します。

サンプルコードは以下のとおりです。

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

## **よくある質問**

**actual_x、actual_y、actual_width、actual_height はどの単位で返されますか？**  
ポイント単位です。1インチ = 72ポイントです。これらは Aspose.Slides の座標単位です。

**プロット領域は内容的にチャート領域とどのように異なりますか？**  
プロット領域はデータ描画領域（系列、グリッド線、トレンドラインなど）です。チャート領域はそれに加えて周囲の要素（タイトル、凡例など）を含みます。3D チャートの場合、プロット領域は壁・床および軸も含みます。

**レイアウトが手動の場合、プロット領域の X、Y、幅、高さはどのように解釈されますか？**  
それらはチャート全体サイズの割合（0〜1）として扱われます。このモードでは自動配置が無効になり、設定した割合が使用されます。

**凡例を追加/移動した後、プロット領域の位置が変わったのはなぜですか？**  
凡例はプロット領域の外側のチャート領域に配置されますが、レイアウトと利用可能なスペースに影響を与えるため、自動配置が有効な場合にプロット領域がシフトすることがあります。（これは PowerPoint チャートの標準的な動作です。）