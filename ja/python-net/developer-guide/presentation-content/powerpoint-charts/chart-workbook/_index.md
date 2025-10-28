---
title: Python を使用したプレゼンテーションでのチャート ワークブックの管理
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
- 外部ワークブック
- 外部データ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を体験してください：PowerPoint および OpenDocument 形式でのチャート ワークブックを簡単に管理し、プレゼンテーション データを効率化します。"
---

## **ワークブックからチャート データを設定する**

Aspose.Slides は、チャート データ ワークブック（Aspose.Cells で編集されたチャート データを含む）を読み書きするメソッドを提供します。**注:** チャート データは、元データと同じ方式で構成されているか、類似した構造である必要があります。

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

## **ワークブック セルをチャート データ ラベルとして設定する**

場合によっては、基になるデータ ワークブックのセルから直接取得したチャート ラベルが必要になることがあります。Aspose.Slides を使用すると、データ ラベルを特定のワークブック セルにバインドでき、ラベル テキストが常にセルの値を反映するようにできます。以下の例では、セルから値を取得するラベルを有効にし、選択したラベルをチャートのワークブック内のカスタム セルに紐付ける方法を示します。

1. [プレゼンテーション](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. サンプル データでバブル チャートを追加します。
1. チャートの系列にアクセスします。
1. ワークブック セルをデータ ラベルとして使用します。
1. プレゼンテーションを保存します。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instantiate the Presentation class that represents a presentation file.
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

以下の Python コードは、`worksheets` プロパティを使用してワークシート コレクションにアクセスする方法を示しています：

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

## **データ ソースの種類を指定する**

以下の Python コードは、データ ソースの種類を指定する方法を示しています：

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

Aspose.Slides は、チャートのデータ ソースとして外部ワークブックを使用することをサポートしています。

### **外部ワークブックの設定**

このメソッドを使用すると、[ChartData.set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) メソッドで外部ワークブックをチャートのデータ ソースとして割り当てることができます。また、外部ワークブックが移動した場合にパスを更新することも可能です。

リモート ロケーションやリソースに保存されたワークブックのデータを編集することはできませんが、外部データ ソースとして使用することは可能です。外部ワークブックに相対パスを指定すると、自動的にフル パスに変換されます。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`set_external_workbook` メソッドの `update_chart_data` パラメータは、Excel ワークブックをロードするかどうかを指定します。

- `update_chart_data` が `False` に設定されている場合、ワークブック パスのみが更新され、チャート データはロードまたはリフレッシュされません。対象のワークブックが存在しない、または利用できない場合に使用します。
- `update_chart_data` が `True` に設定されている場合、チャート データが対象ワークブックからロードされ、更新されます。

### **外部ワークブックの作成**

`read_workbook_stream` と `set_external_workbook` メソッドを使用すると、外部ワークブックを新規に作成するか、内部ワークブックを外部ワークブックに変換することができます。

以下の Python コードは、外部ワークブック作成プロセスを示しています：

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

場合によっては、チャートのデータがプレゼンテーションに埋め込まれたデータではなく、外部 Excel ワークブックにリンクされていることがあります。Aspose.Slides を使用すると、チャートのデータ ソースを検査し、外部ワークブックである場合はフル パスを取得できます。

1. [プレゼンテーション](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. チャート シェイプへの参照を取得します。
4. チャートのデータ ソースを表すソース（[ChartDataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/)）を取得します。
5. ソースの種類が外部ワークブック データ ソースの種類と一致するか確認します。

以下の Python コードは、この操作を示します：

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

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックかを判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) と [外部ワークブックへのパス](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) があり、ソースが外部ワークブックである場合、フル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？また、どのように保存されますか？**

はい。相対パスを指定すると、自動的に絶対パスに変換されます。これはプロジェクトのポータビリティに便利ですが、プレゼンテーションは PPTX ファイル内に絶対パスを保存します。

**ネットワーク リソース/共有にあるワークブックを使用できますか？**

はい、そのようなワークブックを外部データ ソースとして使用できます。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーションを保存するとき、Aspose.Slides は外部 XLSX を上書きしますか？**

いいえ。プレゼンテーションは外部ファイルへのリンクを保存し、データ読み取りに使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワード保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、復号化したコピー（例: [Aspose.Cells](/cells/python-net/)）を用意してそのコピーにリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートはそれぞれのリンクを保持します。全てが同じファイルを指していれば、そのファイルを更新するだけで、次回データをロードしたときにすべてのチャートに反映されます。