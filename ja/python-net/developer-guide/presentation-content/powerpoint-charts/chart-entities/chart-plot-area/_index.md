---
title: Python でのプレゼンテーション チャートのプロット領域のカスタマイズ
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint や OpenDocument のプレゼンテーションでチャートのプロット領域をカスタマイズする方法をご紹介します。スライドのビジュアルを手軽に向上させましょう。"
---

## **チャート プロット領域の幅と高さを取得**
Aspose.Slides for Python via .NET はシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルトデータでチャートを追加します。
4. 実際の値を取得するために、IChart.ValidateChartLayout() メソッドを呼び出します。
5. チャート要素の左上隅からの実際の X 位置（左）を取得します。
6. チャート要素の左上隅からの実際の上位置を取得します。
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

## **チャート プロット領域のレイアウトモードを設定**
Aspose.Slides for Python via .NET は、チャート プロット領域のレイアウトモードを設定するシンプルな API を提供します。**ChartPlotArea** と **IChartPlotArea** クラスに **LayoutTargetType** プロパティが追加されました。プロット領域のレイアウトが手動で定義されている場合、このプロパティはプロット領域を内部（軸や軸ラベルを除く）でレイアウトするか、外部（軸と軸ラベルを含む）でレイアウトするかを指定します。**LayoutTargetType** 列挙体で定義されている 2 つの可能な値があります。

- **LayoutTargetType.Inner** – プロット領域のサイズは、目盛りと軸ラベルを除いた内部領域のサイズを決定します。
- **LayoutTargetType.Outer** – プロット領域のサイズは、目盛りと軸ラベルを含む外部領域のサイズを決定します。

以下にサンプルコードを示します。

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

**プロット領域とチャート領域は内容面でどのように異なりますか？**  
プロット領域はデータ描画領域（系列、グリッド線、トレンドラインなど）を指し、チャート領域はタイトルや凡例などの周囲要素を含みます。3D チャートの場合、プロット領域は壁・床および軸も含みます。

**レイアウトが手動の場合、プロット領域の X、Y、幅、高さはどのように解釈されますか？**  
チャート全体サイズに対する割合（0〜1）として扱われます。このモードでは自動位置決めが無効になり、設定した割合がそのまま使用されます。

**凡例を追加/移動した後にプロット領域の位置が変わったのはなぜですか？**  
凡例はプロット領域の外側に配置されますが、レイアウトや利用可能スペースに影響を与えるため、オートポジショニングが有効な場合はプロット領域がシフトすることがあります。これは PowerPoint のチャートで標準的な挙動です。