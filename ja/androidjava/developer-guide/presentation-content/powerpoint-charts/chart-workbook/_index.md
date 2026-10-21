---
title: Android でのプレゼンテーションにおけるチャート ワークブックの管理
linktitle: チャート ワークブック
type: docs
weight: 70
url: /ja/androidjava/chart-workbook/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java をご紹介します。PowerPoint および OpenDocument 形式でチャート ワークブックを簡単に管理し、プレゼンテーション データを効率化できます。"
---
## **概要**

この記事では、Aspose.Slides のチャート ワークブックの操作方法を説明します。ワークブック ストリームを介してチャート データの読み取りと書き込みを行う方法、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションへのアクセス方法、チャート値のデータ ソース タイプの指定方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法についても取り上げます。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能な場合のチャート データの編集方法を示しています。

欠損データを表すワークブック セルについては、空のセルとゼロの違い、および利用可能な表示モードの折れ線グラフ比較については、[空白セルの表示制御](/slides/ja/androidjava/chart-series/) を参照してください。

## **非表示行や列からのデータの包含**

非表示のワークシート行や列からデータをプロットするかどうかは、[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) を使用して制御します。`true` に設定すると表示セルのみをプロットし、`false` に設定すると表示セルと非表示セルの両方を含めます。この設定はチャートのプロットに影響しますが、ワークシートの行や列を非表示または表示にするものではありません。

[サンプル プレゼンテーション](hidden-source-data.pptx) には、最初のスライドの最初のシェイプとして列グラフが含まれています。埋め込みワークシート `Sheet1` には、次のソース範囲 `A1:C4` が含まれます。3 行目と C 列は非表示ですが、セルには値が保持されています。

| ワークシート 行 | A: 月 | B: 小売 | C: 卸売 (非表示列) |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3 (非表示行) | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

ソースセルには [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) でアクセスし、[IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) で非表示かどうかを確認します。このメソッドは非表示状態を変更せずに報告します。このファイルでは、B2 は表示、B3 は非表示行に属し、C2 は非表示列に属します。例ではそれぞれ `false`、`true`、`true` が出力されます。

この例では、プロット設定を変更した後にチャート データを更新します。埋め込みワークブックは [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) で保持し、[writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) で再読み込みします。すべてのセルを含める場合は、[setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) を使用して非表示の February カテゴリを含む完全な範囲を復元します。フラグを変更するだけでは、このサンプルのキャッシュされたチャート データとカテゴリ ラベルは更新されません。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // 埋め込みワークブックからチャート データを更新します。
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // 非表示カテゴリを含む完全なソース範囲を復元します。
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

この例では、プレゼンテーションを 2 つのバージョンで保存します。1 つは表示されている小売値 (10 と 20) のみ、もう 1 つはすべての 6 値です。以下の画像は 2 つのプロット モードを示しています。3 行目と C 列は両方の埋め込みワークブックで非表示のままです。

| 表示セルのみ (`true`) | すべてのセル (`false`) |
| --- | --- |
| ![表示セルのみ: 1月と3月の小売値 10 と 20.](hidden_cells_True.png) | ![すべてのセル: 1月、2月、3月の小売と卸売の値.](hidden_cells_False.png) |

値を持つ非表示セルは空のセルとは異なります。[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) は欠損値の表示方法を制御し、非表示のソース データの含有・除外は行いません。例については、[空白セルの表示制御](/slides/ja/androidjava/chart-series/#control-the-display-of-empty-cells) を参照してください。

## **チャートのデータ 範囲 の取得**

既存のプレゼンテーションでワークブック データを更新する前に、ソース範囲を確認し、各チャートが使用しているワークシート セルを特定します。[IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) メソッドは、現在のデータ範囲をワークシート限定の数式として返します。例: `Sheet1!$A$1:$D$5`。ここで `Sheet1` はシート名、`!` はセル範囲との区切り、`$A$1:$D$5` は A1 から D5 までのセルを示し、ドル記号は絶対参照であることを示します。

このメソッドはチャートやワークブックを変更せずに現在の範囲を読み取ります。チャートがデータ ソースとしてワークブックを使用していない場合、`InvalidOperationException` がスローされます。詳細は [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/) を参照してください。

この例ではプレゼンテーションを開き、各スライドのシェイプを直接確認してチャートを探します。各チャートの名前とソース範囲を出力します。ワークブックを使用しないチャートの場合、メッセージを出力して次のチャートに進みます。

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **ワークブックからのチャート データの読み取りと書き込み**

Aspose.Slides for Android via Java は、[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) と [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) メソッドを提供し、チャート データ ワークブック（Aspose.Cells で編集されたチャート データを含む）の読み書きが可能です。**注**: チャート データは同様の構成もしくはソースに似た構造で整理されている必要があります。

この例では、最初のスライドの最初のシェイプとしてチャートが配置されたプレゼンテーションを使用します。埋め込みワークブックをバイト配列に読み取り、既存のシリーズとカテゴリをクリアし、同じワークブックを書き戻します。変更はメモリ上に残り、プレゼンテーションは保存されません。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **ワークブック変更後のチャート レイアウトの検証**

埋め込みワークブックを変更済みのものに置き換えると、チャートは元のシリーズとカテゴリ コレクションを保持します。この不整合により [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に既存のシリーズとカテゴリをクリアしてください。この例は、最初のスライドの最初のシェイプとしてのチャートを使用します。コメントはワークブック編集が行われる場所を示しており、実行可能な例では元のワークブックを書き戻し、メモリ内でレイアウトを検証します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // ワークブックのバイトをここで変更します。例えば、Aspose.Cells を使用します。

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

コレクションをクリアすると、ワークブックを書き戻す前に古いデータ参照が削除されます。チャートを使用する前に、更新されたワークブック用に必要なシリーズとカテゴリのマッピングを再構築してください。

## **ワークブック セルのカスタム数値書式の設定**

[IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) を使用して、チャートの埋め込みワークブック内の数値の表示方法を制御します。たとえば、レポートで変換率を小数点以下 4 桁のパーセンテージで、係数を小数点以下 5 桁で表示する必要がある場合があります。両方の値は数値のままにして、計算やチャート描画に利用できるようにします。

数値書式は表示を変更するだけで、保存された値は変わりません。書式 `0.0000%` は `0.125` を `12.5000%` と表示しますが、保存された数値を `12.5` に置き換えるわけではありません。同様に、`0.00000` は `0.1234567` を `0.12346` と表示し、保存値は丸められません。カスタム書式が空文字列 (`""`) の場合、[getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) が返す書式が使用されます。

以下の例では、列グラフを作成し、[getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) を通じてセルにアクセスします。ワークシート 0 の B2 に変換率、C2 に係数が格納されています。両方のセルがチャート値として使用されます。また、例ではソース書式にリンクした値ラベルも有効にしています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ワークブック セルの書式は、チャート軸やデータ ラベルに直接設定された書式とは別です。この例では、[setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) が `true` に設定され、ラベルはソースセルの値を表示し、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) が `true` のためソースの数値書式に従います。プレゼンテーションを保存して再度開くと、ラベルは `12.5000%` と `0.12346` を表示します（下図参照）。縦軸は独自の書式 `0.00` を [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) で設定し、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) は `false` にしています。

データ ラベルを個別に書式設定するには、ソースリンクフラグを `false` にし、[setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) で書式を割り当てます。これによりワークブック セルの書式は変更されません。例として、ラベル書式を `0.00` に設定すると、最初の値は `0.13` と表示されますが、B2 は依然として `12.5000%` を示します。ラベルの直接書式設定については、[Chart Data Labels](/slides/ja/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) を参照してください。

以下の画像は、保存したプレゼンテーションを再度開いた後にレンダリングしたものです。

![ソースリンクされたラベルが 12.5000% と 0.12346 を示し、独立して書式設定された数値軸を持つ列グラフ](custom-cell-formats.png)

## **ワークブック セルをチャート データ ラベルとして設定**

ワークブック セルのテキストをチャート データ ラベルとして使用できます。

この例では、既存のプレゼンテーションの最初のスライドにデフォルト データのバブル チャートを追加します。ワークシート 0 のセル A10:A12 を最初のシリーズの最初の 3 ラベルとして使用し、セルからのラベルを有効にして、更新されたプレゼンテーションを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ワークシートの管理**

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) メソッドは、チャート ワークブック内のワークシートへのアクセスを提供します。この例では、デフォルト データの円グラフを作成し、各ワークシート名をコンソールに出力します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **データ ソース タイプの指定**

この例では、デフォルト データの 3D 列グラフを作成し、異なるデータ ソースを使用して 2 つのシリーズ名を設定します。最初の名前は文字列リテラル、2 番目はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) 列挙体で各名前のソースを選択します。例では、更新されたシリーズ名でプレゼンテーションを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **サポートされていない埋め込みワークブック形式の検出**

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。[IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) の [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) メソッドと [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) 列挙体を組み合わせて、サポートされていない形式を検出し、該当チャートをスキップできます。この例では、既存のプレゼンテーションの最初のスライドのシェイプを検査し、チャート以外のシェイプをスキップし、.xlsb 埋め込みワークブックを持つ各チャートに診断メッセージを出力します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // ここでサポートされているチャート ワークブック データを読み取るか変更します。
    }
} finally {
    presentation.dispose();
}
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートしています。

### **外部ワークブックの作成**

[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) と [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、チャートをその外部ワークブックにリンクします。

この例では、デフォルト データの円グラフを作成し、ワークブックをエクスポートします。外部ワークブックをチャート データ ソースとして割り当てる前にファイル書き込みを完了し、リンクされたプレゼンテーションを保存します。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **外部ワークブックの設定**

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合（移動した場合）にも更新できます。

リモートの場所やリソースに格納されたワークブックのデータは編集できませんが、外部データ ソースとして使用することは可能です。外部ワークブックの相対パスが指定された場合、自動的にフルパスに変換されます。

この例では、`Sheet1` という名前のワークシートに、B1 にシリーズ名、A2:A4 にカテゴリ名、B2:B4 に数値が含まれる外部ワークブックを使用します。例は円グラフを作成し、ワークブックをリンクし、[setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) を使用して A1:B4 を 1 つのシリーズと 3 つのカテゴリにマッピングします。リンクされたチャート付きでプレゼンテーションを保存します。

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) の `updateChartData` パラメータは、ワークブックをロードするかどうかを制御します。

* `updateChartData` が `false` の場合、ワークブック パスのみが更新されます。チャート データは対象ワークブックからロードまたは更新されないため、ワークブックが存在しなくても構いません。
* `updateChartData` が `true` の場合、チャート データは対象ワークブックから更新されます。

以下の例では、`updateChartData` を `false` に設定したプレースホルダー URL を割り当てます。円グラフのデフォルト データは保持され、利用できないワークブックをロードせずにプレゼンテーションを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **チャートの外部データ ソース ワークブック パスの取得**

チャートにリンクされたワークブックを特定するには、チャートが外部データ ソースを使用しているか確認し、ワークブック パスを取得します。

この例では、外部ワークブックがリンクされたプレゼンテーションの最初のスライドの最初のシェイプを検査します。外部ワークブックにリンクされたチャートである場合、[getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) をコンソールに出力します。その後、プレゼンテーションのコピーを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **チャート データの編集**

外部ワークブックのデータは、内部ワークブックの内容を変更するのと同様に編集できます。外部ワークブックをロードできない場合、例外がスローされます。

この例では、最初のスライドの最初のシェイプであり、アクセス可能な外部ワークブックにリンクされたチャートを使用します。最初のシリーズの最初のデータ ポイントのセル裏付け値を 100 に設定し、更新されたプレゼンテーションを保存します。セル値を編集するとリンクされた外部 XLSX ファイルが更新されるため、元のワークブックを保持したい場合はコピーを使用してください。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **チャート キャッシュからワークブックを復元**

チャートが欠損または利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。プレゼンテーションを開く前に、[LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) を作成し、[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) を呼び出し、[ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) を `true` に設定します。

以下の Java 例は、最初のスライドの最初のシェイプで、利用できない外部ワークブックを参照しているチャートのワークブック データを復元します。復元されたデータは、[IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) と [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) を通じてアクセスします。

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // ここで復元されたワークブック データを読み取るか、変更してください。
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションの最終更新後に外部ワークブックで行われた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックまたは埋め込みワークブックにリンクされているか判別できますか？**  
はい。チャートには [data source type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) と [path to an external workbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) があり、ソースが外部ワークブックの場合、完全なパスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされますか？また、どのように保存されますか？**  
はい。相対パスを指定すると、自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワークリソース/共有上にあるワークブックを使用できますか？**  
はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートのワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**Aspose.Slides はプレゼンテーション保存時に外部 XLSX を上書きしますか？**  
プレゼンテーションは [link to the external file](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) を保存します。セル裏付けのチャート データを編集すると、リンクされたローカル XLSX ファイルも更新される可能性があります。元のファイルを変更せずに保ちたい場合は、ワークブックのコピーを使用してください。

**外部ファイルがパスワードで保護されている場合、どうすればよいですか？**  
Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、復号化したコピー（例: [Aspose.Cells](https://reference.aspose.com/cells/java/) を使用）を用意してそのコピーにリンクします。

**複数のチャートが同じ外部ワークブックを参照できますか？**  
はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指す場合、そのファイルを更新すると、次回データをロードしたときに各チャートに反映されます。