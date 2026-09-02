---
title: Pythonでプレゼンテーションのチャート ワークブックを管理する
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
- チャート キャッシュ
- ワークブック 復元
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python 用 Aspose.Slides for .NET を利用して、PowerPoint および OpenDocument 形式のチャート ワークブックを簡単に管理し、プレゼンテーション データを効率化します。"
---
## **概要**

この記事では、Aspose.Slides でチャート ワークブックを操作する方法を説明します。ワークブック ストリームを介してチャート データを読み書きする方法、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションにアクセスする方法、チャート値のデータ ソース タイプを指定する方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法についても説明します。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能な場合のチャート データ編集をデモンストレーションします。

## **ワークブックからチャート データの読み書き**

Aspose.Slides は、ワークブック（Aspose.Cells で編集されたチャート データを含む）からチャート データを読み書きするメソッドを提供します。**注:** チャート データは、元の構造と同じ方式、または類似した構造で整理されている必要があります。

以下の Python コードがサンプル操作を示しています:

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

## **ワークブックセルをチャート データ ラベルとして設定**

場合によっては、基になるデータ ワークブックのセルから直接取得したラベルが必要になることがあります。Aspose.Slides では、データ ラベルを特定のワークブック セルにバインドでき、ラベル テキストは常にセルの値を反映します。以下の例は、セルからの値をラベルとして有効にし、選択されたラベルをチャートのワークブック内のカスタム セルにポイントさせる方法を示します。

1. [Presentation](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. サンプル データでバブル チャートを追加します。  
4. チャート シリーズにアクセスします。  
5. ワークブック セルをデータ ラベルとして使用します。  
6. プレゼンテーションを保存します。

以下の Python コードが、ワークブック セルをチャート データ ラベルとして設定する方法を示しています:

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

以下の Python コードは、`worksheets` プロパティを使用してワークシート コレクションにアクセスする方法を示しています:

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

以下の Python コードは、データ ソース タイプを指定する方法を示しています:

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

## **サポートされていない埋め込みワークブック形式の検出**

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック（.xlsb）形式をサポートしていません。`embedded_workbook_type` プロパティを [ChartData](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/) と共に、[WorkbookType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/workbooktype/) 列挙体で使用して、サポートされていない形式を検出し、該当チャートをスキップできます。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # 埋め込みワークブックは .xlsb 形式で、サポートされていません。
            continue

        # ここでチャート ワークブック データを読み取りまたは変更します。
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートします。

### **外部ワークブックの設定**

[ChartData.set_external_workbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/set_external_workbook/) メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てできます。このメソッドは、ワークブックが移動された場合にパスを更新することもできます。

リモート ロケーションやリソースに保存されたワークブックのデータを編集することはできませんが、外部データ ソースとして使用することは可能です。外部ワークブックの相対パスを指定すると、自動的にフル パスに変換されます。

以下の Python コードが、外部ワークブックを設定する方法を示しています:

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

- `update_chart_data` が `False` の場合、ワークブック パスのみが更新され、チャート データはロードまたはリフレッシュされません。ターゲット ワークブックが存在しない、または利用できない場合に使用します。  
- `update_chart_data` が `True` の場合、チャート データがロードされ、ターゲット ワークブックから更新されます。

### **外部ワークブックの作成**

[read_workbook_stream](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) と [set_external_workbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/set_external_workbook/) メソッドを使用すると、外部ワークブックをゼロから作成するか、内部ワークブックを外部ワークブックに変換できます。

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

### **チャートの外部データ ソース ワークブック パス取得**

場合によっては、チャートのデータがプレゼンテーションに埋め込まれたデータではなく、外部 Excel ワークブックにリンクされていることがあります。Aspose.Slides を使用すると、チャートのデータ ソースを調べ、外部ワークブックであればフル パスを取得できます。

1. [Presentation](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドへの参照を取得します。  
3. チャート シェイプへの参照を取得します。  
4. チャートのデータ ソースを表すソース（[ChartDataSourceType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatasourcetype/)）を取得します。  
5. ソース タイプが外部ワークブック データ ソース タイプと一致するか確認します。

以下の Python コードが操作をデモンストレーションします:

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

外部ワークブックのデータは、内部ワークブックと同様に編集できます。外部ワークブックをロードできない場合は例外がスローされます。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **チャート キャッシュからワークブックを復元**

外部ワークブックが欠落または利用できない場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/) を作成し、プレゼンテーションを開く前に [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/spreadsheet_options/) 経由で [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/ja/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) を有効にします。

以下の Python 例は、外部ワークブックが利用できないチャートを含むプレゼンテーションを開き、[Chart.chart_data](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/chart_data/) と [ChartData.chart_data_workbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) を介して復元されたデータにアクセスする方法を示しています:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # ここで復元されたワークブック データを読み取ったり変更したりできます。
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容可能なフォールバックである場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションが最後に更新された後に外部ワークブックで行われた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/data_source_type/) と [path to an external workbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/external_workbook_path/) があり、外部ワークブックの場合はフル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？ それらはどのように保存されますか？**

はい。相対パスを指定すると、自動的に絶対パスに変換されます。これはプロジェクトの移植性に便利ですが、プレゼンテーションは PPTX ファイル内に絶対パスを保存することに注意してください。

**ネットワーク リソース/共有上のワークブックを使用できますか？**

はい。そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされておらず、ソースとしてのみ使用可能です。

**プレゼンテーションを保存するときに、外部 XLSX が上書きされますか？**

いいえ。プレゼンテーションは [link to the external file](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/external_workbook_path/) を保存し、データ読み取りに使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワード保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、[Aspose.Cells](/cells/python-net/) などで復号化したコピーを作成し、そのコピーにリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指している場合、そのファイルを更新すると次回データがロードされる際に各チャートに反映されます。