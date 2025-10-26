---
title: Pythonでプレゼンテーションのチャートブックを管理する
linktitle: チャートブック
type: docs
weight: 70
url: /ja/python-net/developer-guide/presentation-content/powerpoint-charts/chart-workbook/
keywords:
- チャートブック
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument 形式のチャートブックを簡単に管理し、プレゼンテーションデータの効率化を実現します。"
---

## **ワークブックからチャートデータを設定する**

Aspose.Slides は、チャートデータワークブック（Aspose.Cells で編集されたチャートデータを含む）を読み書きするメソッドを提供します。**注意:** チャートデータは、元のデータと同様に構成されているか、構造が似ている必要があります。

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

## **ワークブックのセルをチャートデータラベルとして設定する**

場合によっては、基になるデータワークブックのセルから直接取得したチャートラベルが必要になることがあります。Aspose.Slides は、データラベルを特定のワークブックセルにバインドできるため、ラベルテキストは常にセルの値を反映します。以下の例は、セルから値を取得するラベルを有効にし、選択したラベルをチャートのワークブック内のカスタムセルに割り当てる方法を示しています。

1. [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. サンプルデータでバブルチャートを追加します。  
4. チャート系列にアクセスします。  
5. ワークブックのセルをデータラベルとして使用します。  
6. プレゼンテーションを保存します。  

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

以下の Python コードは、`worksheets` プロパティを使用してワークシートコレクションにアクセスする方法を示しています：

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

## **データソースタイプの指定**

以下の Python コードは、データソースタイプを指定する方法を示しています：

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

Aspose.Slides は、外部ワークブックをチャートのデータソースとして使用することをサポートしています。

### **外部ワークブックの設定**

ChartData.set_external_workbook メソッドを使用すると、外部ワークブックをチャートのデータソースとして割り当てることができます。このメソッドは、ワークブックが移動された場合にパスを更新することも可能です。

リモートの場所やリソースに保存されたワークブックのデータは編集できませんが、外部データソースとして使用することは可能です。外部ワークブックに相対パスを指定すると、自動的にフルパスに変換されます。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`set_external_workbook` メソッドの `update_chart_data` パラメータは、Excel ワークブックを読み込むかどうかを指定します。

- `update_chart_data` が `False` に設定されている場合、ワークブックのパスのみが更新され、チャートデータは対象ワークブックから読み込まれず、更新もされません。対象ワークブックが存在しない、または利用できない場合にこの設定を使用します。  
- `update_chart_data` が `True` に設定されている場合、チャートデータが対象ワークブックから読み込まれ、更新されます。

### **外部ワークブックの作成**

`read_workbook_stream` と `set_external_workbook` メソッドを使用すると、外部ワークブックをゼロから作成するか、内部ワークブックを外部ワークブックに変換することができます。

以下の Python コードは、外部ワークブック作成プロセスを示しています。

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

### **チャートの外部データソースワークブックパスの取得**

場合によっては、チャートのデータがプレゼンテーションに埋め込まれたデータではなく、外部の Excel ワークブックにリンクされていることがあります。Aspose.Slides を使用すると、チャートのデータソースを確認し、外部ワークブックの場合はフルパスを取得できます。

1. [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. チャートシェイプへの参照を取得します。  
4. チャートのデータソースを表すソース（[ChartDataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/)）を取得します。  
5. ソースタイプが外部ワークブックのデータソースタイプと一致するか確認します。  

以下の Python コードは、この操作を示しています：

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

外部ワークブックのデータは、内部ワークブックと同様に編集できます。外部ワークブックをロードできない場合は例外がスローされます。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**特定のチャートが外部ワークブックまたは埋め込みワークブックにリンクされているかどうか判断できますか？**

はい。チャートにはデータソースタイプと外部ワークブックへのパスがあります。ソースが外部ワークブックである場合、フルパスを読み取ることで外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？また、どのように保存されますか？**

はい。相対パスを指定すると、自動的に絶対パスに変換されます。これによりプロジェクトのポータビリティが向上しますが、プレゼンテーションは PPTX ファイル内に絶対パスを保存する点に留意してください。

**ネットワークリソース／共有上にあるワークブックを使用できますか？**

はい、そのようなワークブックは外部データソースとして使用できます。ただし、Aspose.Slides からリモートのワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーション保存時に Aspose.Slides は外部 XLSX を上書きしますか？**

いいえ。プレゼンテーションは外部ファイルへのリンクを保存し、データの読み取りに使用します。プレゼンテーションを保存しても外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合、どうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、復号化したコピー（例: Aspose.Cells を使用）を作成し、そのコピーにリンクします。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべて同じファイルを指している場合、そのファイルを更新すると、次回データが読み込まれたときに各チャートに反映されます。