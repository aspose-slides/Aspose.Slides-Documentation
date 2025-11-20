---
title: Pythonでプレゼンテーションのチャートワークブックを管理
linktitle: チャートワークブック
type: docs
weight: 70
url: /ja/python-net/chart-workbook/
keywords:
- チャートワークブック
- チャートデータ
- ワークブックセル
- データラベル
- ワークシート
- データソース
- 外部ワークブック
- 外部データ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を活用し、PowerPoint および OpenDocument 形式でチャートワークブックを簡単に管理し、プレゼンテーションデータを効率化します。"
---

## **ワークブックからチャートデータを設定**

Aspose.Slides は、チャートデータワークブック（Aspose.Cells で編集されたチャートデータを含む）を読み書きするメソッドを提供します。**注:** チャートデータは、元のデータと同じ形式で構成するか、類似した構造である必要があります。

以下の Python コードはサンプル操作を示しています:
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


## **ワークブックのセルをチャートデータラベルとして設定**

場合によっては、基になるデータワークブックのセルから直接取得したラベルが必要になることがあります。Aspose.Slides は、データラベルを特定のワークブックセルにバインドできるため、ラベルテキストは常にセルの値を反映します。以下の例は、セルから値を取得するラベルを有効にし、選択したラベルをチャートのワークブック内のカスタムセルにポイントする方法を示しています。

1. [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. サンプルデータでバブルチャートを追加します。
1. チャートシリーズにアクセスします。
1. ワークブックセルをデータラベルとして使用します。
1. プレゼンテーションを保存します。

以下の Python コードは、ワークブックセルをチャートデータラベルとして設定する方法を示しています:
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

以下の Python コードは、`worksheets` プロパティを使用してワークシートコレクションにアクセスする方法をデモンストレーションします:
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


## **データソースの種類を指定**

以下の Python コードは、データソースの種類を指定する方法を示しています:
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

Aspose.Slides は、チャートのデータソースとして外部ワークブックの使用をサポートします。

### **外部ワークブックの設定**

[ChartData.set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) メソッドを使用すると、外部ワークブックをチャートのデータソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが移動された場合にパスを更新することも可能です。

リモートロケーションやリソースに保存されたワークブックのデータを編集することはできませんが、外部データソースとして使用することは可能です。外部ワークブックに相対パスを指定すると、自動的にフルパスに変換されます。

以下の Python コードは、外部ワークブックを設定する方法を示しています:
```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```


`set_external_workbook` メソッドの `update_chart_data` パラメーターは、Excel ワークブックを読み込むかどうかを指定します。

- `update_chart_data` が `False` に設定されている場合、ワークブックのパスのみが更新され、チャートデータは対象ワークブックから読み込まれず、更新もされません。対象ワークブックが存在しない、または利用できない場合に使用します。
- `update_chart_data` が `True` に設定されている場合、対象ワークブックからチャートデータが読み込まれ、更新されます。

### **外部ワークブックの作成**

[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) と [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) メソッドを使用すると、ゼロから外部ワークブックを作成するか、内部ワークブックを外部ワークブックに変換できます。

この Python コードは、外部ワークブック作成プロセスを示しています:
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


### **チャートの外部データソースワークブック パスを取得**

場合によっては、チャートのデータがプレゼンテーションに埋め込まれたデータではなく外部 Excel ワークブックにリンクされていることがあります。Aspose.Slides を使用すると、チャートのデータソースを調べ、外部ワークブックである場合はフルパスを取得できます。

1. [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. チャート シェイプへの参照を取得します。
1. チャートのデータソースを表すソース（[ChartDataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/)）を取得します。
1. ソースの種類が外部ワークブック データソースの種類と一致するか確認します。

以下の Python コードはこの操作をデモンストレーションします:
```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```


### **チャートデータの編集**

外部ワークブックのデータは、内部ワークブックと同様に編集できます。外部ワークブックを読み込めない場合は例外がスローされます。
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) と [外部ワークブックへのパス](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) があり、ソースが外部ワークブックの場合はフルパスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされますか？また、どのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。これはプロジェクトの移植性に便利ですが、プレゼンテーションは PPTX ファイル内に絶対パスを保存する点に注意してください。

**ネットワークリソースや共有フォルダー上のワークブックを使用できますか？**

はい、そのようなワークブックは外部データソースとして使用できます。ただし、Aspose.Slides からリモートワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーションを保存するときに外部 XLSX が上書きされますか？**

いいえ。プレゼンテーションは [外部ファイルへのリンク](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) を保存し、データの読み取りに使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、[Aspose.Cells](/cells/python-net/) などで復号化したコピーを作成し、そのコピーにリンクします。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指していれば、そのファイルを更新することで次回データを読み込む際に各チャートに反映されます。