---
title: "Python を使用したプレゼンテーションでのチャート ワークブック管理"
linktitle: "チャート ワークブック"
type: docs
weight: 70
url: /ja/python-net/chart-workbook/
keywords:
- "チャート ワークブック"
- "チャート データ"
- "ワークブック セル"
- "データ ラベル"
- "ワークシート"
- "データ ソース"
- "外部ワークブック"
- "外部データ"
- "チャート キャッシュ"
- "ワークブック 復旧"
- "PowerPoint"
- "プレゼンテーション"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via .NET を活用し、PowerPoint および OpenDocument 形式のチャート ワークブックを手軽に管理して、プレゼンテーション データを効率化します。"
---
## **概要**

この記事では、Aspose.Slides でチャート ワークブックを操作する方法を説明します。ワークブック ストリームを介したチャート データの読み取りと書き込み、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションへのアクセス、チャートの値に対するデータ ソース タイプの指定方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も取り上げます。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能な場合のチャート データの編集方法を示します。

## **ワークブックからチャートデータを読み書きする**

Aspose.Slides は、ワークブック (Aspose.Cells で編集されたチャート データを含む) の読み取りと書き込みのメソッドを提供します。**Note:** チャート データは、元のデータと同じ方法で編成されているか、構造が類似している必要があります。

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

### **ワークブック変更後のチャートレイアウトの検証**

埋め込みワークブックを変更済みのものに置き換えると、チャートは元のシリーズとカテゴリ コレクションを保持したままになります。この不一致により[IChart.validate_chart_layout](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/ichart/validate_chart_layout/) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に、既存のシリーズとカテゴリをクリアしてください。

```python
# ワークブック ストリームを変更した後 (例: Aspose.Cells を使用)
updated_workbook = chart_data.read_workbook_stream()

# 既存のデータ参照をクリアします。
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

コレクションをクリアすることで、チャート データ構造が新しいワークブックと一致し、`validate_chart_layout` がエラーなく完了します。

## **ワークブックセルをチャートデータラベルとして設定する**

場合によっては、基になるデータ ワークブックのセルから直接ラベルを取得したいことがあります。Aspose.Slides は、データ ラベルを特定のワークブック セルにバインドできるため、ラベルのテキストは常にセルの値を反映します。以下の例は、セルから値を取得するラベルを有効にし、選択したラベルをチャートのワークブック内のカスタム セルにポイントさせる方法を示します。

1. [Presentation](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. サンプル データでバブル チャートを追加します。
4. チャート シリーズにアクセスします。
5. ワークブック セルをデータ ラベルとして使用します。
6. プレゼンテーションを保存します。

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

以下の Python コードは、`worksheets` プロパティを使用してワークシート コレクションにアクセスする方法を示しています。

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

以下の Python コードは、データ ソース タイプを指定する方法を示しています。

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

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。[ChartData](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/) の `embedded_workbook_type` プロパティと [WorkbookType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/workbooktype/) 列挙体を組み合わせて、サポートされていない形式を検出し、該当チャートをスキップできます。

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
            # .xlsb 形式の埋め込みワークブックですが、サポートされていません。
            continue

        # ここでチャート ワークブック データを読み取るか、変更してください。
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートします。

### **外部ワークブックの設定**

[ChartData.set_external_workbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/set_external_workbook/) メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てられます。このメソッドは、外部ワークブックが移動された場合にパスを更新することもできます。

リモート ロケーションやリソースに保存されたワークブックのデータを編集することはできませんが、外部データ ソースとして使用することは可能です。外部ワークブックに相対パスを指定すると、自動的にフル パスに変換されます。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # False を渡すとパスだけが保存されます: 対象のワークブックはまだ存在しなくてもかまいません。
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`set_external_workbook` メソッドの `update_chart_data` パラメータは、Excel ワークブックをロードするかどうかを指定します。

- `update_chart_data` が `False` に設定されている場合、ワークブックのパスだけが更新され、チャート データはロードまたはリフレッシュされません。対象ワークブックが存在しない、または利用できないときに使用します。
- `update_chart_data` が `True`（デフォルト）に設定されている場合、チャート データが対象ワークブックから読み込まれ、更新されます。そのワークブックを開けない場合は、"External workbook is not available" というメッセージの例外がスローされます。

### **外部ワークブックの作成**

[read_workbook_stream](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) と [set_external_workbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/set_external_workbook/) メソッドを使用すると、外部ワークブックをゼロから作成するか、内部ワークブックを外部ワークブックに変換できます。

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

場合によっては、チャートのデータがプレゼンテーションに埋め込まれたデータではなく外部の Excel ワークブックにリンクされていることがあります。Aspose.Slides を使用すると、チャートのデータ ソースを調べ、外部ワークブックであればフル パスを取得できます。

1. [Presentation](https://docs.aspose.com/slides/ja/python-net/api-reference/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. チャート シェイプへの参照を取得します。
4. チャートのデータ ソースを表す [ChartDataSourceType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatasourcetype/) を取得します。
5. 取得したソース タイプが外部ワークブックのデータ ソース タイプと一致するか確認します。

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

### **チャートキャッシュからワークブックを復元する**

外部ワークブックが欠落または利用できない場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/) を作成し、[LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/spreadsheet_options/) を介して [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/ja/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) を有効にした上でプレゼンテーションを開きます。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # ここで復旧されたワークブック データを読み取るか、変更してください。
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションが最後に更新された後に外部ワークブックで行われた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判別できますか？**

はい。チャートには[data source type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/data_source_type/) と[external workbook path](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/external_workbook_path/) があり、ソースが外部ワークブックであればフル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされますか？また、どのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。プロジェクトのポータビリティに便利ですが、プレゼンテーションは PPTX ファイル内に絶対パスを保存する点に注意してください。

**ネットワーク共有やリソース上のワークブックを使用できますか？**

はい。そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーション保存時に外部 XLSX が上書きされますか？**

チャート データを編集した場合に限ります。プレゼンテーションは[external file link](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/external_workbook_path/) を保存し、データの読み取りに使用します。そのため、プレゼンテーションを開いて保存してもワークブックはそのままです。ただし、チャート データを介して変更した値はプレゼンテーション保存時に外部ワークブックに書き戻されます。元のファイルをそのままにしておく必要がある場合は、コピーで作業してください。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対処法は、事前に保護を解除するか、[Aspose.Cells](/cells/python-net/) などで復号化したコピーを作成してそのコピーにリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指している場合、そのファイルを更新すると次回データをロードしたときに各チャートに反映されます。