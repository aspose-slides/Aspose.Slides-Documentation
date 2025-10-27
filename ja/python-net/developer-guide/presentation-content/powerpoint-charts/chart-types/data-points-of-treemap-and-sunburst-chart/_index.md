---
title: Python でのツリーマップおよびサンバーストチャートのデータポイントのカスタマイズ
linktitle: ツリーマップおよびサンバーストチャートのデータポイント
type: docs
url: /ja/python-net/developer-guide/presentation-content/powerpoint-charts/chart-types/data-points-of-treemap-and-sunburst-chart/
keywords:
- ツリーマップチャート
- サンバーストチャート
- データポイント
- ラベルの色
- ブランチの色
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument 形式に対応したツリーマップおよびサンバーストチャートのデータポイントを管理する方法を学びます。"
---

## **イントロダクション**

他の PowerPoint グラフの種類の中でも、階層構造を持つものが 2 つあります――**ツリーマップ** と **サンバースト**（サンバーストグラフ、サンバーストダイアグラム、ラジアルチャート、ラジアルグラフ、またはマルチレベル円グラフとも呼ばれます）。これらのチャートは、ツリー構造で整理された階層データを表示します――葉から枝の上部へと。葉はシリーズのデータポイントで定義され、各ネストされたグループレベルは対応するカテゴリで定義されます。Aspose.Slides for Python via .NET を使用すると、Python でサンバーストチャートとツリーマップのデータポイントをフォーマットできます。

以下は、Series1 列のデータが葉ノードを定義し、他の列が階層データポイントを定義するサンバーストチャートの例です。

![Sunburst chart example](sunburst_example.png)

まず、プレゼンテーションに新しいサンバーストチャートを追加してみましょう。

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="See also" %}}
- [**Create Sunburst Charts**](/slides/ja/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

チャートのデータポイントをフォーマットする必要がある場合は、次の API を使用します。

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/)、[ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/)、および [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) プロパティです。これらはツリーマップとサンバーストチャートのデータポイントの書式設定にアクセスできます。[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) はマルチレベルカテゴリにアクセスするために使用され、[ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) オブジェクトのコンテナを表します。実質的には [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) のラッパーであり、データポイント固有の追加プロパティがあります。[ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) タイプは、対応する設定にアクセスできる 2 つのプロパティ――[format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) と [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/) を公開しています。

## **データポイントの値を表示する**

このセクションでは、ツリーマップとサンバーストチャートの個々のデータポイントの値を表示する方法を示します。選択したポイントの値ラベルを有効にする方法を確認します。

「Leaf 4」データポイントの値を表示する例:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Data point value](data_point_value.png)

## **データポイントのラベルと色を設定する**

このセクションでは、ツリーマップとサンバーストチャートの個々のデータポイントにカスタムラベルと色を設定する方法を示します。特定のデータポイントにアクセスし、ラベルを割り当て、重要なノードを強調表示するために単色塗りつぶしを適用する手順を学びます。

「Branch 1」データラベルをカテゴリ名ではなくシリーズ名（「Series1」）に変更し、テキスト色を黄色に設定する例:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Data point's label and color](data_point_color.png)

## **データポイントのブランチカラーを設定する**

ブランチカラーを使用して、ツリーマップとサンバーストチャートで親子ノードが視覚的にどのようにグループ化されるかを制御します。このセクションでは、特定のデータポイントにカスタムブランチカラーを設定し、重要なサブツリーをハイライトしてチャートの可読性を向上させる方法を示します。

「Stem 4」ブランチの色を変更する例:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![Branch color](branch_color.png)

## **FAQ**

**サンバースト／ツリーマップのセグメントの順序（ソート）を変更できますか？**

できません。PowerPoint はセグメントを自動的に（通常は降順で時計回りに）ソートします。Aspose.Slides も同様の動作を鏡像化しており、直接順序を変更することはできません。データを前処理して順序を調整してください。

**プレゼンテーションのテーマはセグメントやラベルの色にどのように影響しますか？**

チャートの色は、特に塗りつぶしやフォントを明示的に設定しない限り、プレゼンテーションの [テーマ/パレット](/slides/ja/python-net/presentation-theme/) を継承します。一定の結果を得るには、必要なレベルで単色塗りつぶしとテキスト書式を固定してください。

**PDF／PNG へのエクスポート時にカスタムブランチカラーやラベル設定は保持されますか？**

保持されます。プレゼンテーションをエクスポートするとき、チャート設定（塗りつぶし、ラベル）は出力形式にそのまま反映されます。Aspose.Slides はチャートの書式設定を適用した状態でレンダリングします。

**チャート上にカスタムオーバーレイを配置するために、ラベル／要素の実際の座標を計算できますか？**

できます。チャートレイアウトが確定した後、要素（例: [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)）には `actual_x` / `actual_y` が利用可能になるため、オーバーレイの正確な位置決めに役立ちます。