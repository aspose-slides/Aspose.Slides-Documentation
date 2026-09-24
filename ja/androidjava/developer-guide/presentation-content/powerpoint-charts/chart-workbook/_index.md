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
description: "Java を使用した Android 用 Aspose.Slides を発見し、PowerPoint および OpenDocument 形式のチャート ワークブックを簡単に管理して、プレゼンテーション データを効率化しましょう。"
---
## **Overview**

このドキュメントでは、Aspose.Slides でチャートブックを操作する方法を説明します。ワークブック ストリームを介してチャート データの読み取りと書き込みを行う方法、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションへのアクセス方法、およびチャート 値のデータ ソース タイプを指定する方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も取り上げます。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能な場合のチャート データの編集方法を示しています。

欠損データを表すワークブック セルについては、[空白セルの表示制御](/slides/ja/androidjava/chart-series/) を参照し、空白セルとゼロの違い、および利用可能な表示モードの折れ線グラフでの比較をご確認ください。

## **Read and Write Chart Data from a Workbook**
Aspose.Slides は、[ReadWorkbookStream](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) および [WriteWorkbookStream](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) メソッドを提供し、チャート データ ワークブック（Aspose.Cells で編集されたチャート データを含む）を読み書きできます。**注意**: チャート データは同じ形式で整理されているか、元の構造に類似した構造である必要があります。

この Java コードはサンプル操作を示しています:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Validate Chart Layout After Workbook Modification**

埋め込みワークブックを変更版に差し替えると、チャートは元の系列とカテゴリ コレクションを保持します。この不一致により、[IChart.validateChartLayout](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IChart#validateChartLayout--) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き込む前に、既存の系列とカテゴリをクリアしてください。

```java
// ワークブック ストリームを変更した後 (例: Aspose.Cells を使用)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// 既存のデータ参照をクリアします。
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

コレクションをクリアすることで、チャート データ構造が新しいワークブックと一致し、`validateChartLayout` がエラーなく完了します。

## **Set a Workbook Cell as a Chart Data Label**

1. [Presentation](https://apireference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使ってスライドの参照を取得します。  
3. データを含むバブル チャートを追加します。  
4. チャート 系列にアクセスします。  
5. ワークブック セルをデータ ラベルとして設定します。  
6. プレゼンテーションを保存します。

この Java コードは、ワークブック セルをチャート データ ラベルとして設定する方法を示しています:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Manage Worksheets**

この Java コードは、[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) メソッドを使用してワークシート コレクションにアクセスする操作を示しています:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Specify the Data Source Type**

この Java コードは、データ ソースのタイプを指定する方法を示しています:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。`getEmbeddedWorkbookType` メソッドを [IChartData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IChartData) と組み合わせて、[WorkbookType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/WorkbookType) 列挙体でサポートされていない形式を検出し、該当チャートをスキップできます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // 埋め込みワークブックは .xlsb フォーマットですが、サポートされていません。
            continue;
        }

        // ここでチャート ワークブック データを読み取るか変更します。
    }
} finally {
    presentation.dispose();
}
```

## **External Workbook**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートします。

### **Create an External Workbook**

**`readWorkbookStream`** と **`setExternalWorkbook`** メソッドを使用すると、ゼロから外部ワークブックを作成するか、内部ワークブックを外部化することができます。

この Java コードは外部ワークブックの作成プロセスを示しています:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Set an External Workbook**

**`setExternalWorkbook`** メソッドを使用して、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合にも更新に使用できます。

リモート ロケーションやリソースに保存されているワークブックのデータを直接編集することはできませんが、外部データ ソースとして使用することは可能です。相対パスが指定された場合は、自動的にフル パスに変換されます。

この Java コードは外部ワークブックの設定方法を示しています:

```java
import com.aspose.slides.*;

// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

`setExternalWorkbook` メソッドの `updateChartData` パラメータは、Excel ワークブックをロードするかどうかを指定します。

* `updateChartData` を `false` に設定すると、ワークブック パスだけが更新され、チャート データはロードまたは更新されません。対象ワークブックが存在しない、または利用できない場合に使用します。  
* `updateChartData` を `true` に設定すると、チャート データが対象ワークブックから更新されます。

```java
import com.aspose.slides.*;

// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Get the External Data Source Workbook Path of a Chart**

1. [Presentation](https://apireference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. チャート シェイプのオブジェクトを作成します。  
4. チャートのデータ ソースを表す `ChartDataSourceType` オブジェクトを作成します。  
5. ソース タイプが外部ワークブック データ ソース タイプと同じであることに基づき、関連条件を指定します。

この Java コードは操作を示しています:

```java
import com.aspose.slides.*;

// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
    
    // プレゼンテーションを保存します
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Edit Chart Data**

外部ワークブックのデータは、内部ワークブックと同様に編集できます。外部ワークブックをロードできない場合は例外がスローされます。

この Java コードは上記プロセスの実装例です:

```java
import com.aspose.slides.*;

// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Recover a Workbook from the Chart Cache**

チャートが存在しないか利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。まず [LoadOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/) を作成し、[SpreadsheetOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/spreadsheetoptions/) で構成し、`ISpreadsheetOptions.setRecoverWorkbookFromChartCache` を `true` に設定してからプレゼンテーションを開きます。

以下の Java 例は、利用できない外部ワークブックを参照しているプレゼンテーションを開き、[IChart.getChartData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichart/#getChartData--) と [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) を介して復元されたデータにアクセスする方法を示しています:

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // ここで復元されたワークブック データを読み取るか変更します。
} finally {
    presentation.dispose();
}
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合のみ、復元を有効にしてください。キャッシュには、プレゼンテーションが最後に更新された後に外部ワークブックで行われた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) と [external workbook のパス](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) があり、外部ワークブックであればフル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？ また、どのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。これはプロジェクトの移植性に便利ですが、PPTX ファイルには絶対パスが保存されることに留意してください。

**ネットワーク リソース／共有上のワークブックを使用できますか？**

はい、外部データ ソースとして使用可能です。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません。ソースとしてのみ利用できます。

**プレゼンテーションを保存すると、外部 XLSX が上書きされますか？**

いいえ。プレゼンテーションは外部ファイルへの [リンク](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) を保存し、データ読み取りに使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、[Aspose.Cells](/cells/androidjava/) などで復号化したコピーを用意し、そのコピーにリンクしてください。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートはそれぞれリンクを保持します。すべてが同一ファイルを指している場合、そのファイルを更新すると次回データがロードされる際に各チャートに反映されます。