---
title: Python で Treemap と Sunburst チャートのデータポイントをカスタマイズする
linktitle: Treemap と Sunburst チャートのデータポイント
type: docs
url: /ja/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- ツリーマップ チャート
- サンバースト チャート
- データポイント
- ラベルの色
- ブランチの色
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument 形式に対応した Treemap と Sunburst チャートのデータポイントを管理する方法を学びます。
---

## **概要**

他の PowerPoint チャートタイプの中で、階層構造を持つものが 2 つあります—**Treemap** と **Sunburst**（Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph、または Multi-Level Pie Chart とも呼ばれます）。これらのチャートは、ツリー構造として整理された階層データを表示します—葉からブランチのトップまで。葉はシリーズのデータポイントで定義され、以降の各ネストされたグループ化レベルは対応するカテゴリで定義されます。Aspose.Slides for Python via .NET を使用すると、Python で Sunburst チャートと Treemap のデータポイントをフォーマットできます。

以下は、Series1 列のデータがリーフノードを定義し、他の列が階層的なデータポイントを定義しているサンバーストチャートです:

![サンバーストチャート例](sunburst_example.png)

プレゼンテーションに新しい Sunburst チャートを追加するところから始めましょう:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="こちらも参照" %}}
- [**サンバーストチャートの作成**](/slides/ja/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

チャートのデータポイントをフォーマットする必要がある場合は、次の API を使用してください:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/)、[ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/)、および [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) プロパティ。これらは Treemap と Sunburst チャートのデータポイントのフォーマットにアクセスできるようにします。[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) はマルチレベルカテゴリにアクセスするために使用され、[ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) オブジェクトのコンテナを表します。実質的には [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) のラッパーで、データポイント固有の追加プロパティが含まれます。[ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) 型は、対応する設定にアクセスできる 2 つのプロパティ—[format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) と [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/)—を公開します。

## **データポイントの値を表示**

このセクションでは、Treemap と Sunburst チャートの個々のデータポイントの値を表示する方法を示します。選択したポイントの値ラベルを有効にする方法をご覧ください。

"Leaf 4" データポイントの値を表示する例:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![データポイントの値](data_point_value.png)

## **データポイントのラベルと色の設定**

このセクションでは、Treemap と Sunburst チャートの個々のデータポイントにカスタムラベルと色を設定する方法を示します。特定のデータポイントにアクセスし、ラベルを割り当て、重要なノードを強調表示するために単色塗りつぶしを適用する方法を学びます。

"Branch 1" データラベルをカテゴリ名ではなくシリーズ名 ("Series1") を表示するように設定し、テキストの色を黄色に変更する例:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![データポイントのラベルと色](data_point_color.png)

## **データポイントのブランチカラーの設定**

ブランチカラーを使用して、Treemap と Sunburst チャートで親子ノードが視覚的にどのようにグループ化されるかを制御します。このセクションでは、特定のデータポイントにカスタムブランチカラーを設定し、重要なサブツリーを強調表示してチャートの可読性を向上させる方法を示します。

"Stem 4" ブランチの色を変更する例:

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

![ブランチカラー](branch_color.png)

## **FAQ**

**Sunburst / Treemap のセグメントの順序（ソート）を変更できますか？**

できません。PowerPoint はセグメントを自動的にソートします（通常は降順で時計回り）。Aspose.Slides はこの動作をそのまま反映するため、直接順序を変更することはできません。データを事前に加工することで順序を調整してください。

**プレゼンテーションのテーマはセグメントやラベルの色にどのように影響しますか？**

チャートの色はプレゼンテーションの [テーマ/パレット](/slides/ja/python-net/presentation-theme/) を継承します。明示的に塗りつぶしやフォントを設定しない限り、テーマの色が適用されます。一定の結果を得るには、必要なレベルで固体塗りつぶしとテキスト書式をロックしてください。

**PDF/PNG へのエクスポートでカスタムブランチカラーやラベル設定は保持されますか？**

はい。プレゼンテーションをエクスポートする際、チャートの設定（塗りつぶし、ラベル）は出力形式に保持されます。Aspose.Slides はチャートの書式設定を適用した状態でレンダリングします。

**チャート上にカスタムオーバーレイを配置するために、ラベルや要素の実際の座標を計算できますか？**

はい。チャートのレイアウトが確定した後、要素には `actual_x` / `actual_y` が利用可能です（例: [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)）。これにより、オーバーレイの正確な位置決めが可能になります。