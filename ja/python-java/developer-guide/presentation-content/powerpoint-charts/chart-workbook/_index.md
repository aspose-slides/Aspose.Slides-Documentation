---
title: "Python (via Java) を使用してプレゼンテーションでチャートブックレットを管理する"
linktitle: "チャートブックレット"
type: docs
weight: 70
url: /ja/python-java/chart-workbook/
keywords:
- "チャートブックレット"
- "チャートデータ"
- "ブックレットセル"
- "データラベル"
- "ワークシート"
- "データソース"
- "外部ブックレット"
- "外部データ"
- "チャートキャッシュ"
- "ブックレット復元"
- "PowerPoint"
- "プレゼンテーション"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Python (via Java) 用の Aspose.Slides をご紹介します。PowerPoint および OpenDocument 形式でチャートブックレットを簡単に管理し、プレゼンテーションデータを効率化できます。"
---
## **概要**

この記事では、Aspose.Slides でチャート ブックレットを操作する方法を説明します。ブックレット ストリームを介してチャート データを読み書きする方法、ブックレットのセルをチャート データ ラベルとして使用する方法、ワークシート コレクションへのアクセス方法、チャート 値のデータ ソース タイプを指定する方法を示します。

また、外部ブックレットをチャート データ ソースとして使用する方法も取り上げます。サンプルでは、外部ブックレットの作成と割り当て、チャートにリンクされた外部ブックレットのパス取得、ブックレットが利用可能な場合のチャート データの編集を実演します。

## **ブックレットからのチャート データの読み書き**
Aspose.Slides は、[readWorkbookStream](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#readWorkbookStream) および [writeWorkbookStream](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#writeWorkbookStream) メソッドを提供し、チャート データを含むブックレット（Aspose.Cells で編集されたもの）を読み書きできます。**注**: チャート データは元の構造と同様に整理されているか、同等の構造である必要があります。

この Python コードはサンプル操作を示しています:

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

### **ブックレット変更後のチャート レイアウトの検証**
埋め込みブックレットを変更済みのものに置き換えると、チャートは元の系列とカテゴリ コレクションを保持したままになります。この不整合により、[Chart.validateChartLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#validateChartLayout) が `ArgumentOutOfRangeException` (parameter: index) をスローすることがあります。例外を回避するには、更新されたブックレットを書き戻す **前に** 既存の系列とカテゴリをクリアしてください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# 変更後のブックレットを読み取る（例: Aspose.Cells を使用）。
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # 既存のデータ参照をクリアする。
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

コレクションをクリアすると、チャート データ構造が新しいブックレットと一致し、[validateChartLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#validateChartLayout) がエラーなく完了します。

## **ブックレット セルをチャート データ ラベルとして設定**

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドへの参照を取得します。  
1. データ付きのバブル チャートを追加します。  
1. チャート系列にアクセスします。  
1. ブックレット セルをデータ ラベルとして設定します。  
1. プレゼンテーションを保存します。

この Python コードはブックレット セルをチャート データ ラベルとして設定する方法を示しています:

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

この Python コードは、[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/#getWorksheets) メソッドを使用してワークシート コレクションにアクセスする操作を示します:

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

この Python コードはデータ ソースのタイプを指定する方法を示しています:

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

## **サポートされていない埋め込みブックレット形式の検出**

Aspose.Slides は、一部のチャートに埋め込める Excel バイナリ ブックレット (.xlsb) 形式をサポートしていません。`ChartData` の [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) メソッドと `WorkbookType` 列挙体を組み合わせて、サポート外形式を検出し、該当チャートをスキップできます。

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
            # 埋め込みブックレットは .xlsb 形式で、サポートされていません。
            continue
        # ここでチャートブックレットのデータを読み取るか、変更します。
finally:
    presentation.dispose()
```

### **外部ブックレットの作成**

[readWorkbookStream](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#readWorkbookStream) と [setExternalWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#setExternalWorkbook) メソッドを使用すると、スクラッチから外部ブックレットを作成するか、内部ブックレットを外部化できます。

この Python コードは外部ブックレット作成プロセスを示しています:

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

### **外部ブックレットの設定**

[setExternalWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#setExternalWorkbook) メソッドを使用して、外部ブックレットをチャートのデータ ソースとして割り当てられます。このメソッドは、外部ブックレットのパスが変更された場合の更新にも使用できます。

リモート ロケーションやリソースに保存されたブックレットのデータを直接編集することはできませんが、外部データ ソースとして使用できます。外部ブックレットの相対パスが指定されている場合、自動的にフル パスに変換されます。

この Python コードは外部ブックレットの設定方法を示しています:

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

[setExternalWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#setExternalWorkbook) メソッドの第 2 パラメータ (`bool`) は、Excel ブックレットをロードするかどうかを指定します。

* `False` に設定すると、ブックレット パスのみが更新され、チャート データは対象ブックレットからロードまたは更新されません。対象ブックレットが存在しない、または利用できない状況でこの設定を使用します。  
* `True` に設定すると、チャート データが対象ブックレットから更新されます。

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

### **チャートの外部データ ソース ブックレット パスの取得**

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスでスライドへの参照を取得します。  
1. チャート シェイプのオブジェクトを作成します。  
1. チャートのデータ ソースを表す [ChartDataSourceType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatasourcetype/) オブジェクトを作成します。  
1. ソース タイプが外部ブックレット データ ソース タイプと同じであることを条件として指定します。

この Python コードは操作をデモンストレーションします:

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

外部ブックレットのデータは、内部ブックレットと同様に編集できます。外部ブックレットのロードに失敗した場合は例外がスローされます。

この Python コードは上記プロセスの実装例です:

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

### **チャート キャッシュからのブックレット復元**

チャートが欠落または利用不可の外部ブックレットを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからブックレットを再構築できます。`LoadOptions` を作成し、`SpreadsheetOptions` で構成し、プレゼンテーションを開く前に `SpreadsheetOptions.setRecoverWorkbookFromChartCache` を `True` に設定します。

以下の Python 例は、利用不可の外部ブックレットを参照するプレゼンテーションを開き、[Chart.getChartData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#getChartData) と [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getChartDataWorkbook) を通じて復元されたデータにアクセスします:

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

    # ここで復元されたブックレットのデータを読み取ったり、変更したりします。
finally:
    presentation.dispose()
```

外部ブックレットが利用不可で復元が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データをフォールバックとして使用できる場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションが最後に更新されてから外部ブックレットに加えられた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ブックレットにリンクされているか、埋め込みブックレットにリンクされているかを判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getDataSourceType) と [path to an external workbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) があり、外部ブックレットの場合はフル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ブックレットへの相対パスはサポートされますか？ それらはどのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。これはプロジェクトの移植性に便利ですが、PPTX ファイルには絶対パスが保存されます。

**ネットワーク リソース/共有上のブックレットを使用できますか？**

はい、外部データ ソースとして使用できます。ただし、Aspose.Slides からリモート ブックレットを直接編集することはサポートされていません。ソースとしてのみ利用可能です。

**プレゼンテーション保存時に外部 XLSX が上書きされますか？**

いいえ。プレゼンテーションは外部ファイルへの [link to the external file](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) を保存し、データ読み取りに使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、[Aspose.Cells](/cells/python-java/) などで復号化したコピーを作成してリンクすることです。

**複数のチャートが同じ外部ブックレットを参照できますか？**

はい。各チャートは独自のリンクを保持します。同じファイルを指す場合、そのファイルを更新すると次回データがロードされる際にすべてのチャートに反映されます。