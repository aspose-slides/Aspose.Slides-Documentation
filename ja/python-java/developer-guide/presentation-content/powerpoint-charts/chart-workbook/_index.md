---
title: Python（Java経由）を使用したプレゼンテーションのチャートワークブック管理
linktitle: チャートワークブック
type: docs
weight: 70
url: /ja/python-java/chart-workbook/
keywords:
- チャートワークブック
- チャートデータ
- ワークブックセル
- データラベル
- ワークシート
- データソース
- 外部ワークブック
- 外部データ
- チャートキャッシュ
- ワークブック復元
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python（Java経由）用 Aspose.Slides を発見: PowerPoint および OpenDocument 形式でチャートワークブックを簡単に管理し、プレゼンテーション データを効率化します。"
---
## **概要**

この記事では、Aspose.Slides のチャートワークブックの操作方法を説明します。ワークブック ストリームを使用してチャート データを読み書きする方法、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションにアクセスする方法、そしてチャート 値のデータ ソース タイプを指定する方法を示します。

また、外部ワークブックをチャートのデータ ソースとして使用する方法も取り上げます。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパスの取得、ワークブックが利用可能なときのチャート データの編集方法を示します。

欠損データを表すワークブック セルについては、空のセルとゼロの違い、および利用可能な表示モードの比較を示す [空のセルの表示制御](/slides/ja/python-java/chart-series/) を参照してください。

## **ワークブックからチャート データの読み取りと書き込み**
Aspose.Slides は、[readWorkbookStream](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#readWorkbookStream) および [writeWorkbookStream](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#writeWorkbookStream) メソッドを提供し、ワークブック（Aspose.Cells で編集されたチャート データを含む）の読み取りと書き込みを可能にします。**注意**: チャート データは、元のデータと同様の構造で編成されている必要があります。

この Python コードはサンプル操作を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **ワークブック変更後のチャート レイアウトの検証**
埋め込みワークブックを変更済みのものに置き換えると、チャートは元の系列とカテゴリ コレクションを保持したままになります。この不整合により、[Chart.validateChartLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#validateChartLayout) が `ArgumentOutOfRangeException`（パラメーター: index）をスローすることがあります。例外を回避するには、更新されたワークブックを書き戻す **前に** 既存の系列とカテゴリをクリアしてください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# 変更後（例: Aspose.Cells を使用）にワークブックを読み取ります。
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # 既存のデータ参照をクリアします。
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

コレクションをクリアすると、チャート データ構造が新しいワークブックに合わせられ、[validateChartLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#validateChartLayout) がエラーなく完了します。

## **ワークブック セルをチャート データ ラベルとして設定**
1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. データを持つバブル チャートを追加します。  
4. チャート シリーズにアクセスします。  
5. ワークブック セルをデータ ラベルとして設定します。  
6. プレゼンテーションを保存します。

この Python コードは、ワークブック セルをチャート データ ラベルとして設定する方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)
    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ワークシートの管理**
この Python コードは、[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/#getWorksheets) メソッドを使用してワークシート コレクションにアクセスする操作を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **データ ソース タイプの指定**
この Python コードは、データ ソースのタイプを指定する方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **サポートされていない埋め込みワークブック形式の検出**
Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック（.xlsb）形式をサポートしていません。[ChartData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/) の [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) メソッドと [WorkbookType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/workbooktype/) 列挙体を組み合わせて、サポートされていない形式を検出し、対象のチャートをスキップできます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue
        chart_data = shape.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # 埋め込みワークブックは .xlsb 形式です。この形式はサポートされていません。
            continue
        # ここでチャート ワークブック データを読み取りまたは変更します。
finally:
    presentation.dispose()
```

## **外部ワークブック**
Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートします。

### **外部ワークブックの作成**
[readWorkbookStream](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#readWorkbookStream) と [setExternalWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#setExternalWorkbook) メソッドを使用すると、外部ワークブックをゼロから作成するか、内部ワークブックを外部化することができます。

この Python コードは外部ワークブック作成プロセスを示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **外部ワークブックの設定**
[setExternalWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#setExternalWorkbook) メソッドを使用して、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合（別の場所に移動された場合）にも更新に使用できます。

リモートの場所やリソースに保存されたワークブックのデータは編集できませんが、外部データ ソースとして使用することは可能です。外部ワークブックの相対パスが指定されている場合、自動的にフルパスに変換されます。

この Python コードは、外部ワークブックの設定方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setExternalWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#setExternalWorkbook) メソッドの第2引数（`bool`）は、Excel ワークブックをロードするかどうかを指定します。  

* `False` に設定すると、ワークブック パスのみが更新され、チャート データは対象ワークブックからロードまたは更新されません。対象ワークブックが存在しない、または利用できない状況でこの設定を使用すると便利です。  
* `True` に設定すると、対象ワークブックからチャート データが更新されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **チャートの外部データ ソース ワークブック パスの取得**
1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. チャート シェイプのオブジェクトを作成します。  
4. チャートのデータ ソースを表す [ChartDataSourceType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatasourcetype/) オブジェクトを作成します。  
5. ソース タイプが外部ワークブック データ ソース タイプと同じであることを条件に指定します。

この Python コードは操作を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **チャート データの編集**
外部ワークブックのデータは、内部ワークブックの内容を変更するのと同じ方法で編集できます。外部ワークブックをロードできない場合は例外がスローされます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **チャート キャッシュからワークブックを復元**
チャートが欠損または利用不可の外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされているデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/) を作成し、[SpreadsheetOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/spreadsheetoptions/) で構成し、プレゼンテーションを開く前に `True` を指定して [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ja/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) を呼び出します。

以下の Python 例は、利用できない外部ワークブックを参照しているチャートを含むプレゼンテーションを開き、[Chart.getChartData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#getChartData) と [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getChartDataWorkbook) を通じて復元されたデータにアクセスします：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # ここで復元されたワークブック データを読み取るか変更します。
finally:
    presentation.dispose()
```

外部ワークブックが利用できず、復元が無効化されている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションが最後に更新された後に外部ワークブックに加えられた変更が含まれていない可能性があります。

## **よくある質問**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判断できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getDataSourceType) と [外部ワークブックへのパス](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) があり、ソースが外部ワークブックである場合はフルパスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？ それらはどのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。これはプロジェクトの可搬性に便利ですが、PPTX ファイル内には絶対パスが保存される点に注意してください。

**ネットワーク リソース／共有上にあるワークブックを使用できますか？**

はい。そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません。データ ソースとしてのみ使用できます。

**プレゼンテーションを保存するとき、Aspose.Slides は外部 XLSX を上書きしますか？**

いいえ。プレゼンテーションは [外部ファイルへのリンク](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) を保存し、データの読み取りに使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、[Aspose.Cells](/cells/python-java/) などで復号化したコピーを用意してそのコピーにリンクします。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを持ちます。すべてが同じファイルを指している場合、そのファイルを更新すると次回データがロードされるときに各チャートに反映されます。