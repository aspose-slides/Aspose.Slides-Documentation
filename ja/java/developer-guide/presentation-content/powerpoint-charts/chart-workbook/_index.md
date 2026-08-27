---
title: Java を使用したプレゼンテーションでのチャート ワークブック管理
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
- ワークブック 復元
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を発見し、PowerPoint および OpenDocument 形式でチャート ワークブックを手軽に管理して、プレゼンテーション データを効率化しましょう。"
---
## **Overview**

このガイドでは、Aspose.Slides でチャートのワークブックを扱う方法を説明します。ワークブック ストリームを使用したチャート データの読み書き、ワークブック セルをチャート データ ラベルとして使用、ワークシート コレクションへのアクセス、チャート値のデータ ソース タイプの指定方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も取り上げます。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能な場合のチャート データの編集方法をデモンストレーションします。

## **Read and Write Chart Data from a Workbook**
Aspose.Slides は、[ReadWorkbookStream](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IChartData#readWorkbookStream--) および [WriteWorkbookStream](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) メソッドを提供し、チャート データ ワークブック（Aspose.Cells で編集されたチャート データを含む）の読み書きを可能にします。**Note** チャート データは元データと同じ構造で整理されているか、類似した構造である必要があります。

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

埋め込みワークブックを変更済みのものに差し替えると、チャートは元のシリーズおよびカテゴリ コレクションを保持したままになります。この不整合により `chart.validateChartLayout()` が `ArgumentOutOfRangeException`（パラメーター: index）をスローすることがあります。例外を回避するには、更新されたワークブックをチャートに書き込む **before** に既存のシリーズとカテゴリをクリアしてください。

```java
// ワークブック ストリームを変更した後（例: Aspose.Cells を使用）
byte[] updatedWorkbook = baos.toByteArray();

// 既存のデータ参照をクリアします。
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

// 更新されたワークブックをチャートに書き戻します。
chart.getChartData().writeWorkbookStream(updatedWorkbook);

// これで検証が成功します。
chart.validateChartLayout();
```

コレクションをクリアすることで、チャート データ構造が新しいワークブックに合わせて整合し、`validateChartLayout()` がエラーなく完了します。

## **Set a Workbook Cell as a Chart Data Label**

1. [Presentation](https://apireference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドの参照を取得します。  
1. データを持つバブル チャートを追加します。  
1. チャート シリーズにアクセスします。  
1. ワークブック セルをデータ ラベルとして設定します。  
1. プレゼンテーションを保存します。

この Java コードは、ワークブック セルをチャート データ ラベルとして設定する方法を示しています:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します
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

この Java コードは、[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) メソッドを使用してワークシート コレクションにアクセスする操作を示しています:

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

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック（.xlsb）形式をサポートしていません。`getEmbeddedWorkbookType` メソッドを [IChartData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IChartData) と組み合わせて、[WorkbookType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/WorkbookType) 列挙体を使用し、**unsupported formats** を検出して対象のチャートをスキップできます。

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
            // 埋め込みワークブックは .xlsb 形式で、サポートされていません。
            continue;
        }

        // ここでチャート ワークブック データを読み取るか変更します。
    }
} finally {
    presentation.dispose();
}
```

## **External Workbook**

{{% alert color="info" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/ja/java/aspose-slides-for-java-19-4-release-notes/) では、外部ワークブックをチャートのデータ ソースとして使用する機能を実装しました。
{{% /alert %}} 

### **Create an External Workbook**

**`readWorkbookStream`** と **`setExternalWorkbook`** メソッドを使用すると、外部ワークブックをゼロから作成するか、内部ワークブックを外部化することができます。

この Java コードは外部ワークブック作成プロセスを示しています:

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

**`setExternalWorkbook`** メソッドを使用して、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合（移動された場合）にも更新に利用できます。

リモート ロケーションやリソースに保存されたワークブックのデータを直接編集することはできませんが、外部データ ソースとして使用することは可能です。外部ワークブックの相対パスが指定されている場合、自動的にフル パスに変換されます。

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

`setExternalWorkbook` メソッドの第2引数（`boolean`）は、Excel ワークブックをロードするかどうかを指定します。

* `false` に設定すると、ワークブック パスのみが更新され、チャート データは対象ワークブックからロードまたは更新されません。対象ワークブックが存在しない、または利用できない状況でこの設定を使用します。  
* `true` に設定すると、チャート データが対象ワークブックから更新されます。

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

1. [Presentation](https://apireference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドの参照を取得します。  
1. チャート シェイプのオブジェクトを作成します。  
1. チャートのデータ ソースを表す `ChartDataSourceType` オブジェクトを作成します。  
1. ソース タイプが外部ワークブック データ ソース タイプと同じであることを条件として指定します。

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

チャートが存在しないまたは利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされているデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/) を作成し、[SpreadsheetOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/spreadsheetoptions/) で構成し、プレゼンテーションを開く前に `ISpreadsheetOptions.setRecoverWorkbookFromChartCache(true)` を呼び出します。

次の Java 例は、利用できない外部ワークブックを参照しているプレゼンテーションを開き、[IChart.getChartData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichart/#getChartData--) と [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) を使用して復元されたデータにアクセスする方法を示しています:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // ここで復元されたワークブック データを読み取るか、変更します。
} finally {
    presentation.dispose();
}
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データをフォールバックとして使用できる場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションの最終更新以降に外部ワークブックで行われた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chartdata/#getDataSourceType--) と [path to an external workbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) があり、ソースが外部ワークブックの場合はフル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？また、どのように保存されますか？**

はい。相対パスを指定すると、自動的に絶対パスに変換されます。これはプロジェクトのポータビリティに便利ですが、PPTX ファイル内には絶対パスが保存される点に留意してください。

**ネットワーク リソース/共有上のワークブックを使用できますか？**

はい、これらのワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません。ソースとしてのみ利用可能です。

**プレゼンテーション保存時に外部 XLSX が上書きされますか？**

いいえ。プレゼンテーションは [link to the external file](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) を保持し、データの読み取りに使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、[Aspose.Cells](/cells/java/) などで復号化したコピーを用意してそのコピーにリンクしてください。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートはそれぞれ独自のリンクを保持します。すべてが同一ファイルを指している場合、そのファイルを更新すると次回データをロードしたときに各チャートに反映されます。