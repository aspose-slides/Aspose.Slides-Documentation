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
- 外部 ワークブック
- 外部 データ
- チャート キャッシュ
- ワークブック 復元
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を発見し、PowerPoint および OpenDocument 形式のチャート ワークブックを簡単に管理してプレゼンテーション データを効率化しましょう。"
---
## **概要**

この記事では、Aspose.Slides でチャート ワークブックを操作する方法を説明します。ワークブック ストリームを介してチャート データの読み取りと書き込み、ワークブック セルをチャート データ ラベルとして使用、ワークシート コレクションへのアクセス、チャート 値のデータ ソース タイプの指定方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も取り上げます。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能な場合のチャート データ編集方法を示しています。

ワークブック セルが欠損データを表す場合は、[空白セルの表示制御](/slides/ja/androidjava/chart-series/) を参照し、空白セルと 0 の違い、および利用可能な表示モードのラインチャート比較を確認してください。

## **非表示の行と列を含めたデータの取得**

[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) を使用して、チャートが非表示のワークシート行と列のデータをプロットするかどうかを制御できます。`true` に設定すると表示セルのみ、`false` に設定すると表示セルと非表示セルの両方がプロットされます。この設定はチャートのプロットにのみ影響し、ワークシートの行や列を非表示にしたり表示にしたりするものではありません。

[サンプルプレゼンテーション](hidden-source-data.pptx) には、最初のスライドの最初のシェイプとして列チャートが含まれています。埋め込みワークシート `Sheet1` にはソース範囲 `A1:C4` があり、3 行目と C 列が非表示ですが、セルには値が保持されています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売（非表示列） |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3（非表示行） | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) でソースセルにアクセスし、[IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) で非表示ステータスを確認できます。このメソッドはステータスを変更せずに報告します。この例では、B2 は表示、B3 は非表示行に属し、C2 は非表示列に属すため、`false`、`true`、`true` がそれぞれ出力されます。

この例では、プロット設定を変更した後にチャート データを更新します：埋め込みワークブックを [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) で取得し、[writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) で再読み込みします。すべてのセルを含める場合は、[setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) を使用して非表示の 2 月カテゴリを含む完全な範囲を復元します。フラグだけを変更しても、このサンプルのキャッシュされたチャート データとカテゴリ ラベルは更新されません。

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

この例は、表示セルのみ（10 と 20）のプレゼンテーションと、すべての 6 つの値を含むプレゼンテーションの 2 つのバージョンを保存します。下の画像は 2 つのプロット モードを示しています。行 3 と列 C は両方の埋め込みワークブックで非表示のままです。

| 表示セルのみ (`true`) | すべてのセル (`false`) |
| --- | --- |
| ![表示セルのみ: 1月と3月の小売値 10 と 20。](hidden_cells_True.png) | ![すべてのセル: 1月、2月、3月の小売と卸売の値。](hidden_cells_False.png) |

値を含む非表示セルは空白セルとは異なります。[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) は欠損値の表示方法を制御しますが、非表示ソース データの包含・除外は行いません。[空白セルの表示制御](/slides/ja/androidjava/chart-series/#control-the-display-of-empty-cells) を参照してください。

## **チャートのデータ範囲を取得する**

既存のプレゼンテーションでワークブック データを更新する前に、各チャートが使用しているワークシート セルを特定するためにソース範囲を確認します。[IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) メソッドは、`Sheet1!$A$1:$D$5` のようなワークシート限定の数式として現在のデータ範囲を返します。ここで `Sheet1` がワークシート名、`!` がセル範囲との区切り、`$A$1:$D$5` が A1 から D5 までの絶対参照です。

このメソッドはチャートやそのワークブックを変更せずに現在の範囲を取得します。チャートがワークブックをデータ ソースとして使用していない場合は `InvalidOperationException` がスローされます。詳細は [ChartData API リファレンス](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/) を参照してください。

この例はプレゼンテーションを開き、各スライドのシェイプを直接走査してチャートをチェックします。各チャートの名前とソース範囲を出力し、ワークブックを使用していないチャートはメッセージを出力して次へ進みます。

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

Aspose.Slides for Android via Java は、[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) と [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) メソッドを提供し、チャート データ ワークブック（Aspose.Cells で編集されたチャート データを含む）を読み書きできます。**注**: チャート データは同じ構造、またはソースに類似した構造で整理されている必要があります。

この例は、最初のスライドの最初のシェイプとしてチャートを含むプレゼンテーションを使用します。埋め込みワークブックをバイト配列に読み込み、既存の系列とカテゴリをクリアし、同じワークブックを再度書き戻します。変更はメモリ内に残り、プレゼンテーションは保存されません。

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

埋め込みワークブックを変更版に置き換えると、チャートは元の系列とカテゴリ コレクションを保持します。この不整合により [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に既存の系列とカテゴリをクリアしてください。この例は最初のスライドの最初のシェイプとしてチャートを使用します。コメントはワークブック 編集が入る場所を示しており、実行可能な例は元のワークブックを書き戻し、メモリ内でレイアウトを検証します。

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

        // ここでワークブックのバイトを変更します。たとえば Aspose.Cells を使用します。

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

コレクションをクリアすることで、ワークブックを書き戻す前に古いデータ参照が除去されます。更新されたワークブックに合わせて必要な系列とカテゴリのマッピングを再構築してください。

## **ワークブック セルのカスタム数値書式を設定する**

[IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) を使用して、チャートの埋め込みワークブック内の数値の表示形式を制御できます。たとえば、変換率を小数点以下 4 桁のパーセンテージで、係数を小数点以下 5 桁で表示したいレポートがある場合です。両方の値は数値のままにしておくことで、計算やチャートのプロットに利用可能な状態を保ちます。

数値書式は表示を変更するだけで、保存されている値は変更しません。書式 `0.0000%` は `0.125` を `12.5000%` と表示しますが、保存された数は `12.5` にはなりません。同様に、`0.00000` は `0.1234567` を `0.12346` と表示し、保存値は丸められません。カスタム書式が空文字列 (`""`) の場合は、[getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) が返す書式が使用されます。

以下の例は列チャートを作成し、[getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) でセルにアクセスします。ワークシート 0 の B2 に変換率、C2 に係数が格納され、両方のセルがチャート値として使用されます。例では、ソース書式にリンクしたデータ ラベルも有効にしています。

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

ワークブック セルの書式は、チャート 軸やデータ ラベルに直接設定した書式とは別物です。この例では、各ラベルがソース セルの値を表示します。これは [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) が `true` に設定され、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) が `true` に設定されているためです。プレゼンテーションを保存して再度開くと、ラベルは `12.5000%` と `0.12346` を表示します。縦軸は独自の書式 `0.00` が [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) で割り当てられ、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) が `false` に設定されています。

データ ラベルの書式を独立させるには、ソースリンク フラグを `false` に設定し、[setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) で書式を割り当てます。これによりワークブック セルの書式は変更されません。たとえば、独立したラベル書式 `0.00` は最初の値を `0.13` と表示し、B2 は依然として `12.5000%` を表示します。[チャート データ ラベル](/slides/ja/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) を参照してください。

![ソースにリンクされたラベルが 12.5000% と 0.12346 を表示し、独立して書式設定された数値軸を持つ列チャート。](custom-cell-formats.png)

## **ワークブック セルをチャート データ ラベルとして設定する**

ワークブック セルのテキストをチャート データ ラベルとして使用できます。

この例は既存のプレゼンテーションの最初のスライドにデフォルト データのバブルチャートを追加し、ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 つのラベルとして使用し、セルからのラベルを有効にして更新されたプレゼンテーションを保存します。

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

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) メソッドは、チャート ワークブック内のワークシートへのアクセスを提供します。この例はデフォルト データの円グラフを作成し、各ワークシート名をコンソールに出力します。

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

系列のポイント値は数値リテラルとして直接格納することもできます。[数値リテラルを使用した系列値の設定](/slides/ja/androidjava/chart-series/#set-series-values-using-numeric-literals) を参照してください。ポイント値のソース タイプはチャートの内部または外部ワークブック構成とは別であり、数値リテラルを使用するだけで埋め込みワークブックが削除されるわけではありません。

この例はデフォルト データの 3D 列チャートを作成し、異なるデータ ソースを使用して 2 つの系列名を設定します。最初の名前は文字列リテラル、2 番目はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) 列挙体で各名前のソースを選択します。例は更新された系列名でプレゼンテーションを保存します。

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

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。[IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) の [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) メソッドと [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) 列挙体を組み合わせて、サポート外の形式を検出し、該当チャートをスキップできます。この例は既存のプレゼンテーションの最初のスライドのシェイプを調べ、非チャート シェイプをスキップし、.xlsb 埋め込みワークブックを持つ各チャートに診断メッセージを出力します。

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

        // ここでサポートされているチャート ワークブック データを読み取るか、変更します。
    }
} finally {
    presentation.dispose();
}
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートします。

### **外部ワークブックの作成**

[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) と [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、チャートをその外部ワークブックにリンクします。

この例はデフォルト データの円グラフを作成し、ワークブックをエクスポートします。ファイルの書き込みが完了した後に外部ワークブックをチャート データ ソースとして割り当て、リンクされたプレゼンテーションを保存します。

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

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) メソッドを使用して、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合（移動された場合）にも更新に使用できます。

リモート場所やリソースに保存されているワークブックのデータを直接編集することはできませんが、外部データ ソースとして使用することは可能です。相対パスが指定されている場合は、自動的に絶対パスに変換されます。

この例は、ワークシート名 `Sheet1` に B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値を含む外部ワークブックを使用します。円グラフを作成し、ワークブックをリンクし、[setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) で A1:B4 を 1 系列と 3 カテゴリにマッピングします。リンクされたチャートとともにプレゼンテーションを保存します。

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

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) の `updateChartData` パラメーターは、ワークブックをロードするかどうかを制御します。

* `updateChartData` が `false` の場合、ワークブック パスのみが更新されます。チャート データはロードまたは更新されず、ワークブックが利用できない状態でも問題ありません。
* `updateChartData` が `true` の場合、チャート データが対象ワークブックから更新されます。

以下の例は、`updateChartData` を `false` に設定したプレースホルダー URL を割り当てます。円グラフはデフォルト データのままで、利用できないワークブックをロードせずにプレゼンテーションを保存します。

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

チャートにリンクされているワークブックを特定するには、チャートが外部データ ソースを使用しているか確認し、ワークブック パスを取得します。

この例は、外部ワークブックにリンクされたプレゼンテーションの最初のスライドの最初のシェイプを調べます。対象が外部ワークブックにリンクされたチャートであれば、[getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) をコンソールに出力し、プレゼンテーションのコピーを保存します。

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

外部ワークブックのデータは、内部ワークブックと同様に編集できます。外部ワークブックをロードできない場合は例外がスローされます。

この例は、最初のスライドの最初のシェイプとして存在し、アクセス可能な外部ワークブックにリンクされたチャートを使用します。最初の系列の最初のデータ ポイントのセル参照値を 100 に設定し、更新されたプレゼンテーションを保存します。セル値の編集はリンクされた外部 XLSX ファイルを更新できるため、元のワークブックを保持する必要がある場合はコピーを使用してください。

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

チャートが存在しないか利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) を作成し、[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) を呼び出し、[ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) を `true` に設定してからプレゼンテーションを開きます。

以下の Java 例は、最初のスライドの最初のシェイプとして存在し、利用できない外部ワークブックを参照しているチャートのワークブック データを復元します。復元されたデータは [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) と [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) を介してアクセスできます。

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

        // ここで復元されたワークブック データを読み取るか、変更します。
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには外部ワークブックが最後に更新された後の変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) と [path to an external workbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) があり、外部ワークブックである場合はフルパスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？また、どのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワークリソース/共有上のワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートワークブックを直接編集することはサポートされていません。ソースとしてのみ使用できます。

**プレゼンテーションを保存すると、外部 XLSX が上書きされますか？**

プレゼンテーションは [link to the external file](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) を保存します。セル参照によるチャート データの編集は、リンクされたローカル XLSX ファイルも更新できます。元のワークブックを変更したくない場合は、コピーを使用してください。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、[Aspose.Cells](https://reference.aspose.com/cells/java/) などで復号化したコピーを作成してリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指す場合、そのファイルを更新すると次回データがロードされたときに各チャートに反映されます。