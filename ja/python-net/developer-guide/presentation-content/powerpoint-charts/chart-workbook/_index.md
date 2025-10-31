---
title: プレゼンテーションでPythonを使用したチャートワークブックの管理
linktitle: チャート ワークブック
type: docs
weight: 70
url: /ja/python-net/chart-workbook/
keywords:
- チャート ワークブック
- チャート データ
- ワークブック セル
- データ ラベル
- ワークシート
- データ ソース
- 外部 ワークブック
- 外部 データ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NETを使用して、PowerPointおよびOpenDocument形式でチャートワークブックを簡単に管理し、プレゼンテーションデータを効率化します。"
---

## **ワークブックからチャート データを設定**

Aspose.Slides は、チャート データ ワークブック（Aspose.Cells で編集されたチャート データを含む）を読み書きするメソッドを提供します。**注意:** チャート データは、元のデータと同じ構成または類似した構造である必要があります。

次の Python コードはサンプル操作を示しています。

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

## **ワークブック セルをチャート データ ラベルとして設定**

場合によっては、基になるデータ ワークブックのセルから直接取得したラベルが必要です。Aspose.Slides は、データ ラベルを特定のワークブック セルにバインドできるため、ラベル テキストは常にセルの値を反映します。以下の例は、セルから値を取得するラベルを有効にし、選択したラベルをチャートのワークブック内のカスタム セルにポイントさせる方法を示しています。

1. [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. サンプル データでバブル チャートを追加します。
1. チャート系列にアクセスします。
1. ワークブック セルをデータ ラベルとして使用します。
1. プレゼンテーションを保存します。

次の Python コードは、ワークブック セルをチャート データ ラベルとして設定する方法を示しています。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **ワークシートの管理**

次の Python コードは、`worksheets` プロパティを使用してワークシート コレクションにアクセスする方法を示しています。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **データ ソース タイプの指定**

次の Python コードは、データ ソース タイプを指定する方法を示しています。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートします。

### **外部ワークブックの設定**

[ChartData.set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが移動された場合にも更新できます。

リモート ロケーションやリソースに保存されたワークブックのデータを編集することはできませんが、外部データ ソースとして使用することは可能です。外部ワークブックに相対パスを指定すると、自動的にフル パスに変換されます。

次の Python コードは、外部ワークブックを設定する方法を示しています。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`set_external_workbook` メソッドの `update_chart_data` パラメーターは、Excel ワークブックをロードするかどうかを指定します。

- `update_chart_data` が `False` の場合、ワークブック パスのみが更新され、チャート データはロードまたはリフレッシュされません。対象のワークブックが存在しない、または利用できない場合に使用します。
- `update_chart_data` が `True` の場合、チャート データがロードされ、対象ワークブックから更新されます。

### **外部ワークブックの作成**

[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) と [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) メソッドを使用して、外部ワークブックを新規作成するか、内部ワークブックを外部ワークブックに変換できます。

この Python コードは、外部ワークブック作成プロセスを示しています。

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **チャートの外部データ ソース ワークブック パスの取得**

場合によっては、チャートのデータがプレゼンテーションに埋め込まれたデータではなく、外部 Excel ワークブックにリンクされていることがあります。Aspose.Slides を使用すると、チャートのデータ ソースを調べ、外部ワークブックであればフル パスを取得できます。

1. [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. チャート シェイプへの参照を取得します。
1. チャートのデータ ソースを表す [ChartDataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/) を取得します。
1. ソース タイプが外部ワークブック データ ソース タイプと一致するか確認します。

次の Python コードは操作を示しています。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **チャート データの編集**

外部ワークブックのデータは、内部ワークブックのデータと同様に編集できます。外部ワークブックをロードできない場合は例外がスローされます。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **よくある質問**

**特定のチャートが外部ワークブックまたは埋め込みワークブックにリンクされているかどうかを判定できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) と [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) があり、ソースが外部ワークブックの場合はフル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？ それらはどのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。これはプロジェクトのポータビリティに便利ですが、PPTX ファイル内には絶対パスが保存されることに留意してください。

**ネットワーク リソース/共有上にあるワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーションを保存するときに Aspose.Slides は外部 XLSX を上書きしますか？**

いいえ。プレゼンテーションは [外部ファイルへのリンク](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) を保持し、データ読み取りに使用します。プレゼンテーション保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、復号化したコピー（例: [Aspose.Cells](/cells/python-net/) を使用）を用意してそのコピーにリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートはそれぞれのリンクを保持します。すべてが同じファイルを指している場合、そのファイルを更新すると次回データがロードされる際に各チャートに反映されます。