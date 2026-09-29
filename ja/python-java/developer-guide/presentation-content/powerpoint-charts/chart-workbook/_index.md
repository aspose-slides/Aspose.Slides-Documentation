---
title: Python via Java を使用してプレゼンテーションのチャートワークブックを管理する
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
- ワークブック復旧
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python via Java 用 Aspose.Slides を発見: PowerPoint および OpenDocument 形式でチャートワークブックを簡単に管理し、プレゼンテーションデータを効率化します。"
---
## **概要**

この記事では、Aspose.Slides でチャートワークブックを操作する方法を説明します。ワークブックストリームを介してチャートデータの読み書きを行う方法、ワークブックセルをチャートデータラベルとして使用する方法、ワークシートコレクションにアクセスする方法、そしてチャート値のデータソースタイプを指定する方法を示します。

また、外部ワークブックをチャートのデータソースとして使用する方法についても取り上げます。例では、外部ワークブックを作成して割り当てる方法、チャートにリンクされた外部ワークブックのパスを取得する方法、ワークブックが利用可能な場合にチャートデータを編集する方法を示しています。

欠損データを表すワークブックセルについては、空セルとゼロの違い、および利用可能な表示モードの折れ線グラフ比較については、[空セルの表示制御](/slides/ja/python-java/chart-series/) を参照してください。

## **非表示行と列からデータを含める**

非表示のワークシート行や列からデータをプロットするかどうかは、[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) を使用して制御します。`True` に設定すると可視セルのみをプロットし、`False` に設定すると可視セルと非可視セルの両方を含めます。この設定はチャートのプロットにのみ影響し、ワークシートの行や列を非表示または表示にするものではありません。

[hidden-source-data.pptx](hidden-source-data.pptx) をダウンロードし、作業ディレクトリに配置します。最初のスライドには最初のシェイプとして縦棒グラフが含まれています。埋め込まれたワークシート `Sheet1` には、ソース範囲 `A1:C4` が含まれます。行 3 と列 C は非表示ですが、セルには依然として値が入っています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売（非表示列） |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3（非表示行） | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

ソースセルには [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getChartDataWorkbook) でアクセスし、[ChartDataCell.isHidden](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/#isHidden) を読んで非表示ステータスを検査します。このメソッドはステータスを変更せずに報告します。このファイルでは、B2 は可視、B3 は非表示行に属し、C2 は非表示列に属します。例はそれぞれ `False`、`True`、`True` を出力します。

この例では、プロット設定を変更した後にチャートデータを更新します。[readWorkbookStream](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#readWorkbookStream) で埋め込みワークブックを保持し、[writeWorkbookStream](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#writeWorkbookStream) で再読み込みします。すべてのセルを含める場合は、[setRange](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#setRange) を使用して非表示の 2 月カテゴリを含む完全な範囲を復元します。フラグを変更するだけでは、このサンプルのキャッシュされたチャートデータとカテゴリラベルを更新できません。

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

            # 埋め込みワークブックからチャートデータを更新します。
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

この例は、可視の小売値 (10 と 20) のみを含む `hidden_cells_True.pptx` と、全 6 つの値を含む `hidden_cells_False.pptx` を保存します。以下の画像は、2 つのプロットモードを示しています。行 3 と列 C は両方の埋め込みワークブックで非表示のままです。

| 可視セルのみ (`True`) | すべてのセル (`False`) |
| --- | --- |
| ![可視セルのみ: 1月と3月の小売値 10 と 20.](hidden_cells_True.png) | ![すべてのセル: 1月、2月、3月の小売および卸売の値.](hidden_cells_False.png) |

値を含む非表示セルは空セルとは異なります。[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#setDisplayBlanksAs) は欠損値の表示方法を制御しますが、非表示のソースデータを含めたり除外したりはしません。例については、[空セルの表示制御](/slides/ja/python-java/chart-series/#control-the-display-of-empty-cells) を参照してください。

## **ワークブックからチャートデータを読み書きする**

Aspose.Slides for Python via Java は、[readWorkbookStream](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#readWorkbookStream) と [writeWorkbookStream](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#writeWorkbookStream) メソッドを提供し、チャートデータワークブック（Aspose.Cells で編集されたチャートデータを含む）を読み書きできます。**注**: チャートデータは同じ方式で構成するか、ソースと類似した構造である必要があります。

この例は、最初のスライドの最初のシェイプとしてチャートが含まれている必要がある `chart.pptx` を開きます。埋め込みワークブックをバイト配列に読み取り、既存のシリーズとカテゴリをクリアし、同じワークブックを書き戻します。変更はメモリ内に留まり、例はプレゼンテーションを保存しません。

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

### **ワークブック変更後のチャートレイアウトの検証**

埋め込みワークブックを変更済みのものに置き換えると、チャートは元のシリーズとカテゴリコレクションを保持したままになります。この不整合により、[Chart.validateChartLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#validateChartLayout) がインデックスが範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に、既存のシリーズとカテゴリをクリアしてください。この例は、最初のスライドの最初のシェイプとしてチャートがある `chart.pptx` が必要です。コメントはワークブック編集箇所を示しています。実行可能な例は元のワークブックを書き戻し、メモリ内でレイアウトを検証します。

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

        # ここでワークブックのバイトを変更します。例えば、Aspose.Cells を使用します。

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

コレクションをクリアすると、ワークブックを書き戻す前に古いデータ参照が削除されます。チャートを使用する前に、更新されたワークブック用に必要なシリーズおよびカテゴリのマッピングを再構築してください。

## **ワークブックセルをチャートデータラベルとして設定する**

ワークブックセルのテキストをチャートデータラベルとして使用できます。以下の手順は、バブルチャートのラベルをデータワークブックのセルにリンクする方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. ゼロベースインデックスで最初のスライドにアクセスします。
1. デフォルトデータでバブルチャートを追加します。
1. チャートシリーズにアクセスします。
1. ワークブックセルをデータラベルとして設定します。
1. プレゼンテーションを保存します。

この例は、少なくとも 1 枚のスライドが含まれている必要がある `chart2.pptx` を開き、デフォルトデータのバブルチャートを追加します。ワークシート 0 のセル A10:A12 を最初のシリーズの最初の 3 つのラベルとして使用し、セルからのラベルを有効にして、結果を `resultchart.pptx` に保存します。

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

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/#getWorksheets) メソッドは、チャートワークブック内のワークシートへのアクセスを提供します。この例はデフォルトデータで円グラフを作成し、各ワークシート名をコンソールに出力します。

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

## **データソースタイプの指定**

この例はデフォルトデータで 3D 縦棒グラフを作成し、異なるデータソースを使用して 2 つのシリーズ名を設定します。最初の名前は文字列リテラルを使用し、2 番目はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datasourcetype/) 列挙体で各名前のソースを選択します。結果は `pres.pptx` に保存されます。

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

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリワークブック（.xlsb）形式をサポートしていません。[ChartData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/) の [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) メソッドと [WorkbookType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/workbooktype/) 列挙体を組み合わせて、サポートされない形式を検出し、該当するチャートをスキップできます。この例は `sample.pptx` の最初のスライドのシェイプを調べ、チャートでないシェイプをスキップし、埋め込み .xlsb ワークブックを持つ各チャートの診断メッセージを出力します。

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
        # ここでサポートされているチャートワークブックデータを読み取りまたは変更します。
finally:
    presentation.dispose()
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータソースとして使用することをサポートしています。

### **外部ワークブックの作成**

[readWorkbookStream](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#readWorkbookStream) と [setExternalWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#setExternalWorkbook) を使用して、埋め込みチャートワークブックをファイルにエクスポートし、チャートをその外部ワークブックにリンクします。

この例はデフォルトデータで円グラフを作成し、ワークブックを `externalWorkbook1.xlsx` に書き込み、ファイル書き込みが完了した後にそのファイルをチャートデータソースとして割り当てます。リンクされたプレゼンテーションは `externalWorkbook.pptx` に保存されます。

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

[setExternalWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#setExternalWorkbook) メソッドを使用すると、外部ワークブックをチャートのデータソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合（移動された場合）にパスを更新することにも利用できます。

リモート場所やリソースに保存されたワークブックのデータは編集できませんが、外部データソースとして使用することは可能です。外部ワークブックの相対パスが指定されると、自動的に絶対パスに変換されます。

この例は作業ディレクトリに `externalWorkbook.xlsx` があることを前提とします。そのワークシート `Sheet1` には、B1 にシリーズ名、A2:A4 にカテゴリ名、B2:B4 に数値が含まれている必要があります。例は円グラフを作成し、ワークブックをリンクし、[setRange](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#setRange) を使用して A1:B4 を 1 つのシリーズと 3 つのカテゴリにマッピングします。結果は `Presentation_with_externalWorkbook.pptx` に保存されます。

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

[setExternalWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#setExternalWorkbook) の `updateChartData` パラメータは、ワークブックを読み込むかどうかを制御します。

* `updateChartData` が `False` の場合、ワークブックのパスのみが更新されます。チャートデータは対象ワークブックから読み込まれず、ワークブックが利用不可でも問題ありません。
* `updateChartData` が `True` の場合、チャートデータは対象ワークブックから更新されます。

以下の例は、`updateChartData` を `False` に設定したプレースホルダー URL を割り当てます。円グラフのデフォルトデータを保持し、利用不可のワークブックをロードせずにプレゼンテーションを保存します。

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

### **チャートの外部データソースワークブックパスの取得**

チャートにリンクされたワークブックを特定するには、まずチャートが外部データソースを使用しているか確認します。使用している場合、以下の手順でワークブックのパスを取得できます。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. ゼロベースインデックスで最初のスライドにアクセスします。
1. 最初のシェイプがチャートであることを確認します。
1. チャートのデータソースタイプを読み取ります。
1. ソースが外部ワークブックの場合、そのパスを読み取ります。

この例は、前の例で作成された `externalWorkbook.pptx` を開き、最初のスライドの最初のシェイプを調べます。もしそれが外部ワークブックにリンクされたチャートであれば、コンソールに [getExternalWorkbookPath](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) を出力します。その後、プレゼンテーションのコピーを `Result.pptx` に保存します。

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

### **チャートデータの編集**

外部ワークブックのデータは、内部ワークブックの内容を変更するのと同様に編集できます。外部ワークブックが読み込めない場合、例外がスローされます。

この例は、最初のスライドの最初のシェイプとしてチャートがある `presentation.pptx` と、アクセス可能な外部ワークブックが必要です。最初のシリーズの最初のデータポイントのセル参照値を 100 に設定し、プレゼンテーションを `presentation_out.pptx` に保存します。セル値を編集するとリンクされた外部 XLSX ファイルが更新される可能性があります。元のファイルを変更できない場合は、ワークブックのコピーを使用してください。

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

### **チャートキャッシュからワークブックを復元する**

チャートが欠損または利用不可の外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャートワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/) を作成し、[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) を呼び出し、[SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ja/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) を `True` に設定してからプレゼンテーションを開きます。

以下の Python 例は、最初のスライドの最初のシェイプが利用不可の外部ワークブックを参照するチャートである必要がある `presentation.pptx` を開き、[Chart.getChartData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#getChartData) と [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getChartDataWorkbook) を通じて復元されたデータにアクセスします：

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

        # ここで復元されたワークブックデータを読み取るか変更してください。
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャートデータの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションが最後に更新された後に外部ワークブックで行われた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックまたは埋め込みワークブックにリンクされているか判別できますか？**  
はい。チャートには [data source type](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getDataSourceType) と [外部ワークブックへのパス](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) があり、ソースが外部ワークブックである場合、完全なパスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされますか？また、どのように保存されますか？**  
はい。相対パスを指定すると、自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワークリソース/共有上のワークブックを使用できますか？**  
はい、そのようなワークブックは外部データソースとして使用できます。ただし、Aspose.Slides からリモートワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーションを保存すると、Aspose.Slides は外部 XLSX を上書きしますか？**  
プレゼンテーションは [外部ファイルへのリンク](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) を保存します。セルに基づくチャートデータを編集すると、リンクされたローカル XLSX ファイルも更新される可能性があります。元のファイルを変更できない場合は、ワークブックのコピーを使用してください。

**外部ファイルがパスワードで保護されている場合、どうすればよいですか？**  
Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、復号化されたコピー（例: [Aspose.Cells](https://reference.aspose.com/cells/python-java/) を使用）を用意し、そのコピーにリンクします。

**複数のチャートが同じ外部ワークブックを参照できますか？**  
はい。各チャートは個別のリンクを保持します。すべてが同じファイルを指す場合、そのファイルを更新すると、次回データが読み込まれたときに各チャートに反映されます。