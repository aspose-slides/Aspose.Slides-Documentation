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
- ワークブック 復元
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java 用 Aspose.Slides を発見: PowerPoint と OpenDocument 形式でチャート ワークブックを簡単に管理し、プレゼンテーション データを効率化します。"
---
## **概要**

本記事では Aspose.Slides でチャート ワークブックを操作する方法を説明します。ワークブック ストリームを介したチャート データの読み取りと書き込み、ワークブック セルをチャート データ ラベルとして使用、ワークシート コレクションへのアクセス、チャート 値のデータ ソース タイプの指定方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法もカバーします。例では外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能な場合のチャート データの編集方法を示しています。

## **ワークブックからチャート データを読み書きする**
Aspose.Slides は [ReadWorkbookStream](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IChartData#readWorkbookStream--) および [WriteWorkbookStream](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) メソッドを提供し、ワークブック (Aspose.Cells で編集されたチャート データを含む) の読み取りと書き込みが可能です。**注**: チャート データは同じ方法で構成されているか、元の構造に似た形式である必要があります。

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

### **ワークブック変更後のチャート レイアウトの検証**

埋め込みワークブックを変更済みのものに置き換えると、チャートは元の系列とカテゴリ コレクションを保持したままになります。この不整合により [IChart.validateChartLayout](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichart/#validateChartLayout--) が `ArgumentOutOfRangeException` (parameter: index) をスローすることがあります。例外を回避するには、更新されたワークブックを書き込む **前に** 既存の系列とカテゴリをクリアしてください。

```java
// ワークブック ストリームを変更した後（例: Aspose.Cells を使用）
byte[] updatedWorkbook = baos.toByteArray();

// 既存のデータ参照をクリアします。
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

コレクションをクリアすると、チャート データ構造が新しいワークブックに合わせられ、`validateChartLayout` がエラーなく完了します。

## **ワークブック セルをチャート データ ラベルとして設定する**

1. [Presentation](https://apireference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドの参照を取得します。  
1. データを含むバブル チャートを追加します。  
1. チャート 系列にアクセスします。  
1. ワークブック セルをデータ ラベルとして設定します。  
1. プレゼンテーションを保存します。

この Java コードはワークブック セルをチャート データ ラベルとして設定する方法を示しています:

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

## **ワークシートの管理**

この Java コードは [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) メソッドを使用してワークシート コレクションにアクセスする操作を示しています:

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

## **データ ソース タイプの指定**

この Java コードはデータ ソースのタイプを指定する方法を示しています:

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

## **サポートされていない埋め込みワークブック形式の検出**

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。`getEmbeddedWorkbookType` メソッドを [IChartData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IChartData) で使用し、[WorkbookType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/WorkbookType) 列挙体と組み合わせることで、サポートされていない形式を検出し、該当チャートをスキップできます。

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
            // 埋め込みワークブックは .xlsb 形式です。これはサポートされていません。
            continue;
        }

        // ここでチャート ワークブック データを読み取るか、変更します。
    }
} finally {
    presentation.dispose();
}
```

## **外部ワークブック**

{{% alert color="info" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/ja/java/aspose-slides-for-java-19-4-release-notes/) では、チャートのデータ ソースとして外部ワークブックをサポートする機能を実装しました。
{{% /alert %}} 

### **外部ワークブックの作成**

**`readWorkbookStream`** と **`setExternalWorkbook`** メソッドを使用すると、外部ワークブックをゼロから作成するか、内部ワークブックを外部化できます。

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

### **外部ワークブックの設定**

**`setExternalWorkbook`** メソッドを使用して、外部ワークブックをチャートのデータ ソースとして割り当てられます。このメソッドは、外部ワークブックのパスが変更された場合の更新にも使用できます。

リモートロケーションやリソースに保存されたワークブックのデータを直接編集することはできませんが、外部データ ソースとして利用できます。相対パスが指定されている場合は、自動的に完全パスに変換されます。

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

`setExternalWorkbook` メソッドの第2パラメータ (`boolean`) は、Excel ワークブックをロードするかどうかを指定します。

* `false` に設定すると、パスのみが更新され、チャート データはターゲット ワークブックからロードまたは更新されません。対象ワークブックが存在しない、または利用できない場合に使用します。  
* `true` に設定すると、チャート データがターゲット ワークブックから更新されます。

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

### **チャートの外部データ ソース ワークブック パス取得**

1. [Presentation](https://apireference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスでスライドの参照を取得します。  
1. チャート シェイプのオブジェクトを作成します。  
1. チャート のデータ ソースを表す `ChartDataSourceType` オブジェクトを作成します。  
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

### **チャート データの編集**

外部ワークブックのデータは、内部ワークブックの内容を変更するのと同様に編集できます。外部ワークブックをロードできない場合は例外がスローされます。

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

### **チャート キャッシュからワークブックを復元する**

チャートが存在しない、または利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされているデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/) を作成し、[SpreadsheetOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/spreadsheetoptions/) で構成した上で、`ISpreadsheetOptions.setRecoverWorkbookFromChartCache(true)` をプレゼンテーションを開く前に呼び出します。

以下の Java 例は、利用できない外部ワークブックを参照しているプレゼンテーションを開き、[IChart.getChartData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichart/#getChartData--) と [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) を通じて復元データにアクセスします:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // ここで回復されたワークブック データを読み取るか、変更します。
} finally {
    presentation.dispose();
}
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションが最後に更新された以降に外部ワークブックで行われた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chartdata/#getDataSourceType--) と [external workbook のパス](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) があり、外部ワークブックの場合はフル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？ それらはどのように保存されますか？**

はい。相対パスを指定すると、自動的に絶対パスに変換されます。これはプロジェクトの移植性に便利ですが、PPTX ファイル内には絶対パスが保存される点に留意してください。

**ネットワーク リソース/共有上のワークブックを使用できますか？**

はい、外部データ ソースとして使用可能です。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません。ソースとしてのみ利用できます。

**プレゼンテーションを保存すると外部 XLSX が上書きされますか？**

いいえ。プレゼンテーションは外部ファイルへの [リンク](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) を保存し、データの読み取りに使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、[Aspose.Cells](/cells/java/) などで復号化したコピーを用意してそのコピーにリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートはそれぞれのリンクを保持します。すべてが同じファイルを指している場合、そのファイルを更新すれば次回データがロードされる際に各チャートに反映されます。