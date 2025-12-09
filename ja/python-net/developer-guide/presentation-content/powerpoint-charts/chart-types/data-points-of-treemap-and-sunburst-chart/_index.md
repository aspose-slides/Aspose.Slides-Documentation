---
title: PythonでTreemapとSunburstチャートのデータポイントをカスタマイズ
linktitle: TreemapとSunburstチャートのデータポイント
type: docs
url: /ja/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemapチャート
- Sunburstチャート
- データポイント
- ラベルカラー
- ブランチカラー
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument 形式に対応した Treemap と Sunburst チャートのデータポイントの管理方法を学びます。"
---

## **概要**

PowerPoint の他のチャートタイプの中には、階層構造を持つものが 2 つあります—**Treemap** と **Sunburst**（サンバースト グラフ、サンバースト ダイアグラム、放射状チャート、放射状グラフ、またはマルチレベル パイ チャートとしても知られています）。これらのチャートは、ツリー構造として整理された階層データを表示します—リーフから枝の先端まで。リーフはシリーズのデータポイントで定義され、各ネストされたグループレベルは対応するカテゴリで定義されます。Aspose.Slides for Python via .NET を使用すると、Python で Sunburst チャートと Treemap のデータポイントの書式設定が可能です。

以下は Series1 列のデータがリーフ ノードを定義し、他の列が階層データポイントを定義するサンバースト チャートの例です：

![サンバースト チャート例](sunburst_example.png)

プレゼンテーションに新しいサンバースト チャートを追加してみましょう：
```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```


{{% alert color="primary" title="参照" %}}
- [**サンバースト チャートの作成**](/slides/ja/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

チャート データポイントの書式設定が必要な場合は、以下の API を使用してください：

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/), および [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) プロパティ。これらは Treemap と Sunburst チャートのデータポイントの書式設定にアクセスできるようにします。ChartDataPointLevelsManager はマルチレベル カテゴリにアクセスするために使用され、ChartDataPointLevel オブジェクトのコンテナを表します。実質的には [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) のラッパーであり、データポイント固有の追加プロパティを提供します。ChartDataPointLevel 型は、[format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) と [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/) の 2 つのプロパティを公開し、対応する設定にアクセスできるようにします。

## **データポイントの値を表示する**

このセクションでは、Treemap および Sunburst チャートの個々のデータポイントの値を表示する方法を示します。選択したポイントの値ラベルを有効にする手順を確認できます。

「Leaf 4」データポイントの値を表示します：
```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```


![データポイントの値](data_point_value.png)

## **データポイントのラベルと色を設定する**

このセクションでは、Treemap および Sunburst チャートの個々のデータポイントにカスタム ラベルと色を設定する方法を示します。特定のデータポイントにアクセスし、ラベルを割り当て、重要なノードを強調するために単色塗りつぶしを適用する手順を学びます。

「Branch 1」データラベルをカテゴリ名ではなくシリーズ名（「Series1」）に設定し、テキストの色を黄色に変更します：
```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```


![データポイントのラベルと色](data_point_color.png)

## **データポイントの枝色を設定する**

枝色を使用して、Treemap および Sunburst チャートで親子ノードが視覚的にどのようにグループ化されるかを制御します。このセクションでは、特定のデータポイントにカスタム 枝色を設定し、重要なサブツリーをハイライトしてチャートの可読性を向上させる方法を示します。

「Stem 4」枝の色を変更します：
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


![枝の色](branch_color.png)

## **FAQ**

**Sunburst/Treemap のセグメントの順序（ソート）を変更できますか？**

いいえ。PowerPoint はセグメントを自動的にソートします（通常は値の降順で時計回り）。Aspose.Slides も同様の動作をし、直接順序を変更することはできません。データを事前に加工することで順序を調整します。

**プレゼンテーションのテーマはセグメントやラベルの色にどのように影響しますか？**

チャートの色はプレゼンテーションの [テーマ/パレット](/slides/ja/python-net/presentation-theme/) を継承します。明示的に塗りつぶしやフォントを設定しない限り、テーマの色が適用されます。一定の結果を得るには、必要なレベルで単色塗りつぶしとテキスト書式を固定してください。

**PDF/PNG へのエクスポート時にカスタム 枝色やラベル設定は保持されますか？**

はい。プレゼンテーションをエクスポートすると、チャート設定（塗りつぶし、ラベル）は出力形式に保持されます。Aspose.Slides は書式設定されたチャートをそのままレンダリングします。

**チャート上にカスタム オーバーレイを配置するために、ラベルや要素の実際の座標を計算できますか？**

はい。チャートのレイアウトが確定した後、要素（例: [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)）には `actual_x` と `actual_y` が利用可能になり、正確なオーバーレイ位置決めに役立ちます。