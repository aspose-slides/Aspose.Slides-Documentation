---
title: Java を使用したプレゼンテーションでのチャート ワークブックの管理
linktitle: チャート ワークブック
type: docs
weight: 70
url: /ja/java/chart-workbook/
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
- ワークブック 復旧
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を発見：PowerPoint および OpenDocument フォーマットでチャート ワークブックを簡単に管理し、プレゼンテーション データを効率化します。"
---
## **概要**

このドキュメントでは、Aspose.Slides でチャート ワークブックを操作する方法を説明します。ワークブック ストリームを介してチャート データの読み取りと書き込みを行う方法、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションへのアクセス方法、チャート 値のデータ ソース タイプの指定方法について解説します。

また、外部ワークブックをチャート データ ソースとして使用する方法も扱います。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能な場合のチャート データ編集を示しています。

欠損データを表すワークブック セルについては、空のセルと 0 の違いや、利用可能な表示モードの折れ線グラフ比較については[空のセルの表示制御](/slides/ja/java/chart-series/)をご参照ください。

## **非表示の行と列からデータを含める**

[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) を使用して、非表示のワークシート 行・列からデータをプロットするかどうかを制御できます。`true` に設定すると可視セルのみをプロットし、`false` に設定すると可視セルと非表示セルの両方を含めます。この設定はチャートのプロットにのみ影響し、ワークシートの行や列を非表示にしたり表示にしたりするものではありません。

[sample presentation](hidden-source-data.pptx) には、最初のスライドの最初のシェイプとして列グラフが含まれています。埋め込まれたワークシート `Sheet1` のデータ範囲は `A1:C4` です。3 行目と C 列は非表示ですが、セルには値が保持されています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売（非表示列） |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) でソース セルにアクセスし、[IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) で非表示かどうかを確認します。このメソッドは非表示ステータスを取得するだけで変更は行いません。このファイルでは、B2 は可視、B3 は非表示行、C2 は非表示列に該当し、例はそれぞれ `false`、`true`、`true` を出力します。

この例では、プロット設定を変更した後にチャート データを更新します。埋め込みワークブックは [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) で取得し、[writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) で再ロードします。すべてのセルを含める場合は、[setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) を使用して非表示の February カテゴリを含む完全な範囲を復元します。フラグだけを変更しても、このサンプルのキャッシュされたチャート データやカテゴリ ラベルは更新されません。

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
                // 非表示のカテゴリを含む完全なソース範囲を復元します。
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

例では、表示されている小売値 (10 と 20) のみを含むバージョンと、すべての 6 値を含むバージョンの 2 つのプレゼンテーションを保存します。以下の画像は 2 つのプロット モードを示しています。行 3 と列 C は両方の埋め込みワークブックで非表示のままです。

| 可視セルのみ (`true`) | すべてのセル (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

値を持つ非表示セルは空のセルとは異なります。[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) は欠損値の表示方法を制御しますが、非表示ソース データの含め方には影響しません。詳細は[空のセルの表示制御](/slides/ja/java/chart-series/#control-the-display-of-empty-cells)をご参照ください。

## **チャートのデータ範囲を取得する**

既存のプレゼンテーションでワークブック データを更新する前に、各チャートが使用しているワークシート セルの範囲を確認してください。[IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) メソッドは、`Sheet1!$A$1:$D$5` のようなワークシート修飾付き数式で現在のデータ範囲を返します。ここで `Sheet1` がシート名、`!` がセル範囲から分離し、`$A$1:$D$5` が絶対参照で A1 から D5 までを示します。

このメソッドはチャートやそのワークブックを変更せずに現在の範囲を取得します。ワークブックをデータ ソースとして使用していないチャートに対して呼び出すと `InvalidOperationException` がスローされます。詳細は[ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/)をご確認ください。

この例はプレゼンテーションを開き、各スライドのシェイプを走査してチャートを検出し、チャート名とソース範囲を出力します。ワークブックを使用しないチャートはメッセージを表示して次へ進みます。

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

## **ワークブックからチャート データを読み書きする**

Aspose.Slides for Java は、[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) と [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) メソッドを提供し、Aspose.Cells で編集したチャート データを含むワークブックを読み書きできます。**注**：チャート データは元の構造と同一、または類似した構造である必要があります。

この例は、最初のスライドの最初のシェイプとして配置されたチャートを含むプレゼンテーションを使用します。埋め込みワークブックをバイト配列に読み取り、既存の系列とカテゴリをクリアし、同じワークブックを再度書き戻します。変更はメモリ上に残り、プレゼンテーションは保存されません。

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

### **ワークブック変更後のチャート レイアウトを検証する**

埋め込みワークブックを修正済みのものに置き換えると、チャートは元の系列とカテゴリ コレクションを保持したままになります。この不整合により、[IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に、既存の系列とカテゴリをクリアしてください。この例は最初のスライドの最初のシェイプにあるチャートを使用します。コメントでワークブック編集箇所を示し、実行可能サンプルは元のワークブックを書き戻し、メモリ上でレイアウトを検証します。

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

        // ここでワークブック バイトを変更します。たとえば、Aspose.Cells を使用して。

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

コレクションをクリアすることで、ワークブックを書き戻す前に古いデータ参照が除去されます。更新されたワークブックに合わせて必要な系列やカテゴリのマッピングを再構築してください。

## **ワークブック セルにカスタム数値書式を設定する**

[IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) を使用して、チャートの埋め込みワークブック内の数値の表示形式を制御できます。たとえば、レポートでコンバージョン率を小数点以下 4 桁のパーセンテージ、係数を小数点以下 5 桁の数値として表示したい場合に役立ちます。両方の値は数値のまま保持され、計算やチャート描画に利用できます。

数値書式は表示を変えるだけで、保存されている値は変更されません。書式 `0.0000%` は `0.125` を `12.5000%` と表示しますが、内部の数値は `0.125` のままです。同様に、`0.00000` は `0.1234567` を `0.12346` と表示しますが、元の数値は丸められません。カスタム書式が空文字列 (`""`) の場合は、[getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) が返す既定の書式が使用されます。

以下の例は列グラフを作成し、[getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) でセルにアクセスします。ワークシート 0 の B2 にコンバージョン率、C2 に係数が格納され、両方のセルがチャート値として使用されます。さらに、ソース書式にリンクした値ラベルも有効にしています。

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

ワークブック セルの書式は、チャート 軸やデータ ラベルに直接設定した書式とは別物です。この例では、各ラベルが [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) を `true` にし、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) を `true` にしてソースセルの書式に従っています。プレゼンテーションを保存・再読込すると、ラベルは `12.5000%` と `0.12346` を表示します。縦軸は独自の書式 `0.00` を [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) で設定し、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) を `false` にしています。

データ ラベルの書式を個別に設定するには、ソースリンク フラグを `false` にし、[setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) で書式を割り当てます。これによりワークブック セルの書式は変更されません。たとえば、独立したラベル書式 `0.00` は最初の値を `0.13` と表示し、B2 は依然として `12.5000%` を保持します。ラベルの直接書式設定については[Chart Data Labels](/slides/ja/java/chart-data-label/#set-percentage-sign-with-chart-data-labels)をご覧ください。

以下の画像は、再読込後に保存されたプレゼンテーションからレンダリングされたものです。

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **ワークブック セルをチャート データ ラベルとして使用する**

ワークブック セルのテキストをチャート データ ラベルとして使用できます。

この例は既存のプレゼンテーションの最初のスライドにデフォルト データのバブル チャートを追加し、ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 ラベルとして使用し、セル ラベルを有効にしたうえで更新されたプレゼンテーションを保存します。

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

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) メソッドでチャート ワークブック内のワークシートにアクセスできます。この例はデフォルト データの円グラフを作成し、各ワークシート名をコンソールに出力します。

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

系列のポイント値は数値リテラルとして直接格納することもできます。完全な例については[数値リテラルを使用した系列値の設定](/slides/ja/java/chart-series/#set-series-values-using-numeric-literals)をご参照ください。ポイント値のソース タイプは、チャートの内部または外部ワークブック設定とは別物であり、数値リテラルを使用しただけで埋め込みワークブックが削除されるわけではありません。

この例はデフォルト データの 3D 列グラフを作成し、2 つの系列名に異なるデータ ソースを使用します。1 つ目は文字列リテラル、2 つ目はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) 列挙体で各名前のソースを選択し、更新された系列名でプレゼンテーションを保存します。

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

## **埋め込みワークブックの非対応形式を検出する**

Aspose.Slides は、一部のチャートに埋め込める Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。[IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) の [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) と [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) 列挙体を組み合わせて、非対応形式を検出し、対象チャートをスキップできます。この例は既存プレゼンテーションの最初のスライドのシェイプを走査し、非チャート シェイプを除外した上で、.xlsb 埋め込みワークブックを持つチャートに診断メッセージを出力します。

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

        // ここでサポートされているチャート ワークブック データを読み取るまたは変更します。
    }
} finally {
    presentation.dispose();
}
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用できます。

### **外部ワークブックの作成**

[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) と [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、チャートをその外部ワークブックにリンクできます。

この例はデフォルト データの円グラフを作成し、ワークブックをエクスポートします。ファイル書き込みが完了した後に外部ワークブックをデータ ソースとして割り当て、リンクされたプレゼンテーションを保存します。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **外部ワークブックの設定**

[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) メソッドを使用して、外部ワークブックをチャートのデータ ソースとして割り当てられます。このメソッドは、外部ワークブックへのパスが変更された場合にも使用できます（ワークブックが移動された場合など）。

リモート ロケーションやリソースに保存されたワークブックのデータを直接編集することはできませんが、外部データ ソースとしては使用可能です。相対パスが指定された場合は、自動的にフル パスに変換されます。

この例は、`Sheet1` に B1 が系列名、A2:A4 がカテゴリ名、B2:B4 が数値の外部ワークブックを使用します。円グラフを作成し、ワークブックをリンクし、[setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) で A1:B4 を 1 系列と 3 カテゴリにマッピングします。リンクされたチャート付きプレゼンテーションを保存します。

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) の `updateChartData` パラメーターは、ワークブックをロードするかどうかを制御します。

* `updateChartData` が `false` の場合、パスだけが更新され、チャート データはターゲット ワークブックからロードまたは更新されません。そのためワークブックが利用できなくても問題ありません。
* `updateChartData` が `true` の場合、チャート データはターゲット ワークブックから更新されます。

以下の例は `updateChartData` を `false` に設定したプレースホルダー URL を割り当て、円グラフのデフォルト データを保持したまま、利用できないワークブックをロードせずにプレゼンテーションを保存します。

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

### **チャートの外部データ ソース ワークブック パスを取得する**

チャートにリンクされたワークブックを特定するには、チャートが外部データ ソースを使用しているか確認し、ワークブック パスを取得します。

この例は、外部ワークブックにリンクされたチャートがあるプレゼンテーションの最初のスライドの最初のシェイプを調べます。外部ワークブックにリンクされたチャートであれば、[getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) をコンソールに出力し、プレゼンテーションのコピーを保存します。

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

外部ワークブックのデータは、内部ワークブックと同様に編集できます。外部ワークブックがロードできない場合は例外がスローされます。

この例は、最初のスライドの最初のシェイプで、アクセス可能な外部ワークブックにリンクされたチャートを使用します。最初の系列の最初のデータ ポイントのセル バック値を 100 に設定し、更新されたプレゼンテーションを保存します。セル値の編集はリンクされた外部 XLSX ファイルを更新できるため、元のワークブックを保持したい場合はコピーを使用してください。

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

### **チャート キャッシュからワークブックを復元する**

チャートが外部ワークブックを参照しているが、そのワークブックが欠損または利用不可の場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) を作成し、[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) を呼び出し、[ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) を `true` に設定してプレゼンテーションを開きます。

以下の Java 例は、最初のスライドの最初のシェイプで、利用できない外部ワークブックを参照しているチャートのワークブック データを復元します。復元されたデータは [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) と [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) を通じてアクセスします。

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

        // ここで復元されたワークブックデータを読み取るまたは変更します。
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

外部ワークブックが利用できず、復元が無効化されている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには外部ワークブックが最後に更新された後の変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているか判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) と [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) があり、外部ワークブックが使用されている場合はフル パスを取得して外部ファイルが利用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？ また、どのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワーク リソース/共有上のワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用可能です。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません。ソースとしてのみ使用できます。

**プレゼンテーション保存時に Aspose.Slides は外部 XLSX を上書きしますか？**

プレゼンテーションは [link to the external file](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) を保存します。セル バックされたチャート データを編集すると、リンクされたローカル XLSX ファイルも更新されます。元のワークブックを変更したくない場合は、コピーを使用してください。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、[Aspose.Cells](https://reference.aspose.com/cells/java/) などで復号化したコピーを作成してリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指している場合、そのファイルを更新すれば次回データをロードしたときにすべてのチャートに反映されます。