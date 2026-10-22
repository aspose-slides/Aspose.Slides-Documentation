---
title: Python via Java を使用してプレゼンテーションのチャート ワークブックを管理する
linktitle: チャート ワークブック
type: docs
weight: 70
url: /ja/python-java/chart-workbook/
keywords:
- チャート ワークブック
- チャート データ
- ワークブック セル
- データ ラベル
- ワークシート
- データ ソース
- 外部 ワークブック
- 外部 データ
- チャート キャッシュ
- ワークブック 復元
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を発見し、PowerPoint および OpenDocument 形式でチャート ワークブックを簡単に管理して、プレゼンテーション データを効率化します。"
---
## **概要**

この記事では、Aspose.Slides のチャート ワークブックの操作方法を説明します。ワークブック ストリームを介してチャート データの読み書き、ワークブック セルをチャート データ ラベルとして使用、ワークシート コレクションへのアクセス、チャート値のデータ ソース タイプの指定方法を示します。

外部ワークブックをチャート データ ソースとして使用する方法も取り上げます。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能な場合のチャート データ編集を示します。

欠損データを表すワークブック セルについては、[空のセルの表示制御](/slides/ja/python-java/chart-series/) を参照し、空セルとゼロの違いや利用可能な表示モードの折れ線グラフ比較をご確認ください。

## **非表示行と列からデータを含める**

[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) を使用して、チャートが非表示のワークシート行や列からデータをプロットするかどうかを制御します。`True` に設定すると表示セルのみをプロットし、`False` に設定すると表示セルと非表示セルの両方を含めます。この設定はチャートのプロットにのみ影響し、ワークシートの行や列を非表示または表示にするものではありません。

[sample presentation](hidden-source-data.pptx) には、最初のスライドの最初のシェイプとして列グラフが含まれています。埋め込みワークシート `Sheet1` には、`A1:C4` のソース範囲が設定されています。3 行目と C 列は非表示ですが、セルには値が保持されています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売 (非表示列) |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3 (非表示行) | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) でソースセルにアクセスし、[ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) で非表示ステータスを確認します。このメソッドはステータスを変更せずに報告します。この例では、B2 は表示、B3 は非表示行に属し、C2 は非表示列に属するため、それぞれ `False`、`True`、`True` が出力されます。

この例では、プロット設定を変更した後にチャート データを更新します。[readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) で埋め込みワークブックを保持し、[writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) で再読み込みします。すべてのセルを含める場合は、[setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) を使用して非表示の 2 月カテゴリを含む完全な範囲を復元します。フラグを変更するだけでは、このサンプルのキャッシュ済みチャート データとカテゴリ ラベルは更新されません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # 埋め込みワークブックからチャート データを更新します。
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # 非表示カテゴリを含む完全なソース範囲を復元します。
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

この例は、プレゼンテーションを 2 つのバージョンで保存します。1 つは表示セルのみ（小売値 10 と 20）で、もう 1 つはすべての 6 つの値を含みます。下の画像は 2 つのプロット モードを示しています。3 行目と C 列は両方の埋め込みワークブックで非表示のままです。

| 表示セルのみ (`True`) | すべてのセル (`False`) |
| --- | --- |
| ![表示セルのみ: 1月と3月の小売値 10 と 20.](hidden_cells_True.png) | ![すべてのセル: 1月、2月、3月の小売および卸売値.](hidden_cells_False.png) |

値を保持する非表示セルは空セルとは異なります。[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) は欠損値の表示方法を制御しますが、非表示ソース データの含有・除外は行いません。例については、[空のセルの表示制御](/slides/ja/python-java/chart-series/#control-the-display-of-empty-cells) を参照してください。

## **チャートのデータ範囲を取得する**

既存のプレゼンテーションでワークブック データを更新する前に、各チャートが使用しているワークシート セルのソース範囲を確認して特定します。[ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) メソッドは、現在のデータ範囲をワークシート限定の数式で返します。例: `Sheet1!$A$1:$D$5`。ここで `Sheet1` がシート名、`!` がセル範囲との区切り、`$A$1:$D$5` が A1 から D5 までの絶対参照です。

このメソッドはチャートやワークブックを変更せずに現在の範囲を読み取ります。チャートがワークブックをデータ ソースとして使用していない場合は `InvalidOperationException` がスローされます。詳細は [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) を参照してください。

この例はプレゼンテーションを開き、各スライド上のシェイプを直接走査してチャートを検出します。各チャートの名前とソース範囲を出力し、ワークブックを使用しないチャートはメッセージを出力して次のチャートへ進みます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **ワークブックからチャート データを読み書きする**

Aspose.Slides for Python via Java は、[readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) と [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) メソッドを提供し、チャート データ ワークブック（Aspose.Cells で編集されたチャート データを含む）の読み書きが可能です。**注意**: チャート データは同様の構造で編成されている必要があります。

この例は、最初のスライドの最初のシェイプとしてチャートを含むプレゼンテーションを使用します。埋め込みワークブックをバイト配列に読み取り、既存の系列とカテゴリをクリアし、同じワークブックを書き戻します。変更はメモリ上に残り、プレゼンテーションは保存されません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **ワークブック変更後のチャート レイアウトの検証**

埋め込みワークブックを変更版に置き換えると、チャートは元の系列とカテゴリ コレクションを保持します。この不整合により [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に既存の系列とカテゴリをクリアしてください。この例は最初のスライドの最初のシェイプとしてチャートを使用します。コメントはワークブック編集が行われる場所を示しています。実行可能な例は元のワークブックを書き戻し、メモリ上でレイアウトを検証します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # ここでワークブックのバイトを変更します。たとえば、Aspose.Cells を使用します。

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

コレクションをクリアすると、ワークブックが書き戻される前に古いデータ参照が除去されます。更新されたワークブックに対して必要な系列とカテゴリのマッピングを再構築してからチャートを使用してください。

## **ワークブックセルのカスタム数値書式を設定する**

[ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) を使用して、チャートの埋め込みワークブック内の数値の表示形式を制御します。たとえば、レポートで変換率を小数点以下 4 桁のパーセンテージとして、係数を小数点以下 5 桁で表示したい場合に有用です。両方の値は数値として保持し、計算やチャートのプロットに使用できるようにします。

数値書式は表示を変更するだけで、保存された値は変更されません。書式 `0.0000%` は `0.125` を `12.5000%` と表示しますが、保存された数値は `12.5` にはなりません。同様に `0.00000` は `0.1234567` を `0.12346` と表示し、保存値は丸められません。カスタム書式が空文字列 (`""`) の場合は、[getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) が返す書式が使用されます。

以下の例は列グラフを作成し、[getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) を通じてセルにアクセスします。ワークシート 0 の B2 に変換率、C2 に係数が格納され、両方ともチャート値として使用されます。例ではソース書式にリンクした値ラベルも有効にしています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ワークブック セルの書式は、チャート軸やデータ ラベルに直接設定された書式とは別です。この例では、各ラベルが `True` に設定された [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) のおかげでソースセルの値を表示し、`True` に設定された [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) によってソースの数値書式を継承しています。プレゼンテーションを保存して再度開くと、ラベルは `12.5000%` と `0.12346` を表示します。縦軸は独自の書式 `0.00` が [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) で設定され、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) は `False` です。

データ ラベルを個別に書式設定するには、ソースリンク フラグを `False` にし、[setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) で書式を割り当てます。これによりワークブック セルの書式は変更されません。たとえば独立したラベル書式 `0.00` は最初の値を `0.13` と表示し、B2 は引き続き `12.5000%` を表示します。直接ラベル書式設定の例については、[Chart Data Labels](/slides/ja/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) を参照してください。

以下の画像は、再度開いた保存済みプレゼンテーションからレンダリングしたものです。

![ソースリンク ラベルが 12.5000% と 0.12346 を表示し、独立書式の数値軸を持つ列グラフ.](custom-cell-formats.png)

## **ワークブック セルをチャート データ ラベルとして使用する**

ワークブック セルのテキストをチャート データ ラベルとして使用できます。

この例は既存のプレゼンテーションの最初のスライドにデフォルト データのバブル チャートを追加します。ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 つのラベルとして使用し、セルからのラベルを有効にして、更新されたプレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
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

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) メソッドは、チャート ワークブック内のワークシートへのアクセスを提供します。この例はデフォルト データの円グラフを作成し、各ワークシート名をコンソールに出力します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **データ ソース タイプの指定**

系列のポイント値は数値リテラルとして直接格納することもできます。[数値リテラルを使用した系列値の設定](/slides/ja/python-java/chart-series/#set-series-values-using-numeric-literals) で、保存および読み取りの完全な例をご覧ください。ポイント値のソース タイプは、チャートの内部または外部ワークブック構成とは別であり、数値リテラルの使用だけで埋め込みワークブックが削除されるわけではありません。

この例はデフォルト データの 3D 列グラフを作成し、異なるデータ ソースを使用して 2 つの系列名を設定します。最初の名前は文字列リテラル、2 番目の名前はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) 列挙体で各名前のソースを選択します。例は更新された系列名でプレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **サポートされていない埋め込みワークブック形式の検出**

Aspose.Slides は、一部のチャートに埋め込める Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。[ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) の [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) メソッドと [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) 列挙体を組み合わせて、サポートされていない形式を検出し、該当チャートをスキップできます。この例は既存プレゼンテーションの最初のスライド上のシェイプを調べ、非チャートシェイプをスキップし、.xlsb 埋め込みワークブックを持つ各チャートについて診断メッセージを出力します。

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

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # ここでサポートされているチャート ワークブック データを読み取るか変更します。
finally:
    presentation.dispose()
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートします。

### **外部ワークブックの作成**

[readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) と [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、チャートをその外部ワークブックにリンクします。

この例はデフォルト データの円グラフを作成し、ワークブックをエクスポートします。ファイル書き込みが完了した後に外部ワークブックをデータ ソースとして割り当て、リンクされたプレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **外部ワークブックの設定**

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) メソッドを使用して、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合（ファイルが移動された場合）にも使用できます。

リモート ロケーションやリソースに保存されたワークブックのデータを編集することはできませんが、外部データ ソースとして使用することは可能です。相対パスが指定された場合、自動的にフル パスに変換されます。

この例は、`Sheet1` という名前のワークシートに B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値を持つ外部ワークブックを使用します。円グラフを作成し、ワークブックをリンクし、[setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) で A1:B4 を 1 系列と 3 カテゴリにマップします。リンクされたチャートでプレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) の `updateChartData` パラメータは、ワークブックをロードするかどうかを制御します。

* `updateChartData` が `False` の場合、パスのみが更新されます。チャート データはターゲット ワークブックからロードまたは更新されないため、ワークブックが利用できなくても構いません。  
* `updateChartData` が `True` の場合、チャート データはターゲット ワークブックから更新されます。

以下の例は `updateChartData` を `False` に設定し、プレースホルダー URL を割り当てます。円グラフのデフォルト データは保持され、利用できないワークブックをロードせずにプレゼンテーションが保存されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **チャートの外部データ ソース ワークブック パスの取得**

チャートにリンクされたワークブックを特定するには、チャートが外部データ ソースを使用しているか確認し、ワークブック パスを取得します。

この例は、外部ワークブックにリンクされたチャートを含むプレゼンテーションの最初のスライドの最初のシェイプを調べます。外部ワークブックにリンクされたチャートであれば、[getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) をコンソールに出力し、その後プレゼンテーションのコピーを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **チャート データの編集**

外部ワークブックのデータは、内部ワークブックと同様に編集できます。外部ワークブックがロードできない場合は例外がスローされます。

この例は、最初のスライドの最初のシェイプとして配置されたチャートを使用し、アクセス可能な外部ワークブックにリンクされています。最初の系列の最初のデータ ポイントのセル参照値を 100 に設定し、更新されたプレゼンテーションを保存します。セル値の編集はリンクされた外部 XLSX ファイルを更新できるため、元のワークブックを保持したい場合はコピーを使用してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **チャート キャッシュからワークブックを復元する**

チャートが欠損または利用不可の外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) を作成し、[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) を呼び出し、[SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) を `True` に設定してからプレゼンテーションを開きます。

以下の Python 例は、利用できない外部ワークブックを参照する最初のスライドの最初のシェイプのチャートのワークブック データを復元します。復元されたデータは [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) と [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) を通じてアクセスできます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # ここで復元されたワークブック データを読み取るか変更します。
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュにはプレゼンテーションが最後に更新された後の外部ワークブックの変更が含まれない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判断できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) と [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) があり、外部ワークブックであればフル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？また、どのように保存されていますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワーク リソース/共有上のワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーションを保存すると外部 XLSX が上書きされますか？**

プレゼンテーションは [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) を保存します。セル参照のチャート データを編集すると、リンクされたローカル XLSX ファイルも更新される可能性があります。元のワークブックを変更したくない場合は、コピーを使用してください。

**外部ファイルがパスワード保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、[Aspose.Cells](https://reference.aspose.com/cells/python-java/) などで復号化したコピーを作成してリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべて同じファイルを指す場合、そのファイルを更新すると次回データがロードされる際に各チャートに反映されます。