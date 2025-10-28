---
title: Python でのツリーマップおよびサンバーストチャートのデータ ポイントのカスタマイズ
linktitle: ツリーマップとサンバーストチャートのデータ ポイント
type: docs
url: /ja/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- ツリーマップチャート
- サンバーストチャート
- データ ポイント
- ラベルの色
- ブランチの色
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument 形式に対応したツリーマップとサンバーストチャートのデータ ポイントを管理する方法を学びます。"
---

## **はじめに**

PowerPoint の他のチャート タイプの中でも、階層的なものが2つあります—**ツリーマップ** と **サンバースト**（サンバースト グラフ、サンバースト ダイアグラム、ラジアル チャート、ラジアル グラフ、またはマルチレベル パイ チャートとも呼ばれます）。これらのチャートは、ツリー構造として整理された階層データを表示します—葉からブランチの上部まで。葉はシリーズのデータ ポイントで定義され、各ネストされた次のレベルは対応するカテゴリで定義されます。Aspose.Slides for Python via .NET を使用すると、Python でサンバースト チャートとツリーマップのデータ ポイントを書式設定できます。

以下は、Series1 列のデータが葉ノードを定義し、他の列が階層データ ポイントを定義しているサンバースト チャートの例です。

![Sunburst chart example](sunburst_example.png)

まず、プレゼンテーションに新しいサンバースト チャートを追加してみましょう。

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="参考" %}}
- [**サンバースト チャートの作成**](/slides/ja/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

チャートのデータ ポイントをフォーマットする必要がある場合は、次の API を使用してください。

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/)、[ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/)、および [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) プロパティです。これらはツリーマップとサンバースト チャートのデータ ポイントの書式設定へのアクセスを提供します。[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) はマルチレベル カテゴリへのアクセスに使用され、[ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) オブジェクトのコンテナを表します。実質的には [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) のラッパーで、データ ポイント固有の追加プロパティが含まれています。[ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) 型は、[format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) と [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/) の 2 つのプロパティを公開し、対応する設定へのアクセスを提供します。

## **データ ポイントの値を表示する**

このセクションでは、ツリーマップとサンバースト チャートの個々のデータ ポイントの値を表示する方法を示します。選択したポイントに対して値ラベルを有効にする方法をご覧ください。

「Leaf 4」データ ポイントの値を表示する:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Data point value](data_point_value.png)

## **データ ポイントのラベルと色を設定する**

このセクションでは、ツリーマップとサンバースト チャートの個々のデータ ポイントにカスタム ラベルと色を設定する方法を示します。特定のデータ ポイントにアクセスし、ラベルを割り当て、重要なノードを強調表示するために単色塗りつぶしを適用する方法を学びます。

「Branch 1」データ ラベルをカテゴリ名ではなくシリーズ名（「Series1」）を表示するように設定し、テキストの色を黄色に変更します:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Data point's label and color](data_point_color.png)

## **データ ポイントのブランチ色を設定する**

ブランチ色を使用して、ツリーマップとサンバースト チャート内で親ノードと子ノードが視覚的にどのようにグループ化されるかを制御します。このセクションでは、特定のデータ ポイントにカスタム ブランチ色を設定し、重要なサブツリーを強調表示してチャートの読みやすさを向上させる方法を示します。

「Stem 4」ブランチの色を変更する:

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

**サンバースト／ツリーマップのセグメントの順序（並び替え）を変更できますか？**

できません。PowerPoint はセグメントを自動的に（通常は降順かつ時計回り）ソートします。Aspose.Slides も同様の動作を反映するため、直接順序を変更することはできません。データを事前に加工することで実現します。

**プレゼンテーションのテーマはセグメントやラベルの色にどのように影響しますか？**

チャートの色は、明示的に塗りつぶしやフォントを設定しない限り、プレゼンテーションの [テーマ/パレット](/slides/ja/python-net/presentation-theme/) を継承します。一貫した結果を得るには、必要なレベルで単色塗りつぶしとテキスト書式を固定してください。

**PDF／PNG へのエクスポート時にカスタム ブランチ色やラベル設定は保持されますか？**

保持されます。プレゼンテーションをエクスポートする際、チャート設定（塗りつぶし、ラベル）は出力形式にそのまま反映されます。Aspose.Slides はチャートの書式設定を適用した状態でレンダリングします。

**ラベルや要素の実際の座標を取得して、チャート上にカスタム オーバーレイを配置できますか？**

できます。チャートのレイアウトが確定した後、要素（例: [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)）には `actual_x` / `actual_y` が利用可能になり、正確なオーバーレイ位置決めに役立ちます。