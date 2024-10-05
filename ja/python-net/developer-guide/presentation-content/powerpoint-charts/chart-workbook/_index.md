---
title: チャートワークブック
type: docs
weight: 70
url: /python-net/chart-workbook/
keywords: "チャートワークブック, チャートデータ, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでのPowerPointプレゼンテーションにおけるチャートワークブック"
---

## **ワークブックからチャートデータを設定する**

Aspose.Slidesは、チャートデータワークブック（Aspose.Cellsで編集されたチャートデータを含む）を読み書きするためのいくつかのメソッドを提供します。**注意**: チャートデータは同じ方法で整理される必要があり、ソースと同様の構造を持っている必要があります。

このPythonコードはサンプル操作を示しています。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationクラスをインスタンス化
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series

    series[0].labels.default_data_label_format.show_label_value_from_cell = True

    wb = chart.chart_data.chart_data_workbook

    series[0].labels[0].value_from_cell = wb.get_cell(0, "A10", "ラベル0のセル値")
    series[0].labels[1].value_from_cell = wb.get_cell(0, "A11", "ラベル1のセル値")
    series[0].labels[2].value_from_cell = wb.get_cell(0, "A12", "ラベル2のセル値")

    pres.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **ワークブックのセルをチャートデータラベルとして設定する**

1. [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. データと共にバブルチャートを追加します。
1. チャートシリーズにアクセスします。
1. ワークブックセルをデータラベルとして設定します。
1. プレゼンテーションを保存します。

このPythonコードは、ワークブックセルをチャートデータラベルとして設定する方法を示しています: xxx

```python

```

## **ワークシートを管理する**

このPythonコードは、`worksheets`プロパティを使用してワークシートコレクションにアクセスする操作を示しています。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
   chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
   wb =  chart.chart_data.chart_data_workbook
   for i in range(len(wb.worksheets)):
      print(wb.worksheets[i].name)
```

## **データソースタイプを指定する**

このPythonコードは、データソースのタイプを指定する方法を示しています: 

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    val = chart.chart_data.series[0].name

    val.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    val.data = "リテラル文字列"

    val = chart.chart_data.series[0].name
    val.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "新しいセル")

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **外部ワークブック**

{{% alert color="primary" %}} 
[Aspose.Slides for .NET 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/) では、チャートのデータソースとして外部ワークブックのサポートを実装しました。
{{% /alert %}} 

### **外部ワークブックを作成する**

**`IChartData`** のいくつかのメソッドを使用して、ゼロから外部ワークブックを作成するか、内部ワークブックを外部にすることができます。

このPythonコードは、外部ワークブック作成プロセスを示しています。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:

    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.chart_data_workbook.clear(0)

    chart.chart_data.set_external_workbook(path + "externalWorkbook.xlsx")

    chart.chart_data.set_range("Sheet1!$A$2:$B$5")
    series = chart.chart_data.series[0]
    series.parent_series_group.is_color_varied = True
    pres.save("response2.pptx", slides.export.SaveFormat.PPTX)
```

### **外部ワークブックを設定する**

**`chartData.set_external_workbook`** メソッドを使用すると、チャートに外部ワークブックをデータソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが移動された場合にパスを更新するためにも使用できます。

リモートの場所やリソースに保存されたワークブック内のデータを編集することはできませんが、そのようなワークブックを外部データソースとして使用することはできます。外部ワークブックの相対パスが提供されると、それは自動的に完全なパスに変換されます。

このPythonコードは、外部ワークブックを設定する方法を示しています。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

# ドキュメントディレクトリへのパス
with slides.Presentation() as pres:

    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data
                    
    chartData.set_external_workbook(path + "externalWorkbook.xlsx")
                  

    chartData.series.add(chartData.chart_data_workbook.get_cell(0, "B1"), charts.ChartType.PIE)
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B2"))
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B3"))
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B4"))

    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A2"))
    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A3"))
    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A4"))
    pres.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

`chart_data`パラメータ（`set_external_workbook`メソッドの下）は、Excelワークブックを読み込むかどうかを指定するために使用されます。

* `chart_data`の値が`false`に設定されると、ワークブックのパスのみが更新されます—チャートデータはターゲットワークブックから読み込まれたり、更新されたりしません。この設定は、ターゲットワークブックが存在しないか、利用できない状況のときに使用することをお勧めします。 
* `chart_data`の値が`true`に設定されると、チャートデータはターゲットワークブックから更新されます。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data

    chartData.set_external_workbook("http://path/doesnt/exists", False)

    pres.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **チャート外部データソースワークブックパスを取得する**

1. [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. チャートシェイプのオブジェクトを作成します。
1. チャートのデータソースを表すソース（`ChartDataSourceType`）タイプのオブジェクトを作成します。
1. ソースタイプが外部ワークブックデータソースタイプと同じである条件を指定します。

このPythonコードは操作を示しています。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("response2.pptx") as pres:
    chart = pres.slides[0].shapes[0]
    sourceType = chart.chart_data.data_source_type
    if sourceType == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **チャートデータを編集する**

外部ワークブックのデータは、内部ワークブックの内容を修正するのと同じ方法で編集できます。外部ワークブックを読み込むことができない場合、例外がスローされます。

このPythonコードは、説明されたプロセスの実装です。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "presentation.pptx") as pres:
    pres.slides[0].shapes[0].chart_data.series[0].data_points[0].value.as_cell.value = 100
    pres.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
```