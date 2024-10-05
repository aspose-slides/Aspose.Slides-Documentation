---
title: 階層型データのツリーマップとサンバーストチャート
type: docs
url: /python-net/data-points-of-treemap-and-sunburst-chart/
keywords: "サンバーストチャート, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションにサンバーストチャートを追加する"
---

他の種類のPowerPointチャートの中で、**ツリーマップ**と**サンバースト**チャート（サンバーストグラフ、サンバースト図、ラジアルチャート、ラジアルグラフ、またはマルチレベル円グラフとも呼ばれる）の2つの「階層型」チャートがあります。これらのチャートは、葉からブランチの上部までのツリーとして整理された階層データを表示します。葉はシリーズデータポイントによって定義され、各次の入れ子グルーピングレベルは対応するカテゴリによって定義されます。Aspose.Slides for Python via .NETを使用することで、Pythonでサンバーストチャートとツリーマップのデータポイントをフォーマットできます。

以下はサンバーストチャートで、Series1列のデータが葉ノードを定義しており、他の列が階層データポイントを定義しています：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しいサンバーストチャートを追加して始めましょう:



```py
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
```

{{% alert color="primary" title="見出し" %}} 
- [**サンバーストチャートの作成**](/slides/python-net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


チャートのデータポイントをフォーマットする必要がある場合、以下を使用するべきです：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/)、 
[IChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/)クラス 
および [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/)プロパティ 
は、ツリーマップとサンバーストチャートのデータポイントをフォーマットするためのアクセスを提供します。 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/) 
はマルチレベルのカテゴリにアクセスするために使用され、 それは 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/)オブジェクトのコンテナを表します。 
基本的には、データポイント特有のプロパティが追加された 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartCategoryLevelsManager/)のラッパーです。 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/)クラスには 
2つのプロパティがあり、[**Format**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/)と 
[**DataLabel** ](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/)が 
対応する設定にアクセスします。
## **データポイントの値を表示**
「Leaf 4」データポイントの値を表示します：



```py
    dataPoints = chart.chart_data.series[0].data_points
    dataPoints[3].data_point_levels[0].label.data_label_format.show_value = True
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **データポイントラベルと色を設定**
「Branch 1」のデータラベルをカテゴリ名の代わりにシリーズ名（「Series1」）を表示するように設定します。その後、テキストの色を黄色に設定します：



```py
    branch1Label = dataPoints[0].data_point_levels[2].label
    branch1Label.data_label_format.show_category_name = False
    branch1Label.data_label_format.show_series_name = True

    branch1Label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    branch1Label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **データポイントのブランチ色を設定**

「Stem 4」ブランチの色を変更します：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
    dataPoints = chart.chart_data.series[0].data_points

    stem4branch = dataPoints[9].data_point_levels[1]
    
    stem4branch.format.fill.fill_type = slides.FillType.SOLID
    stem4branch.format.fill.solid_fill_color.color = draw.Color.red
      
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)