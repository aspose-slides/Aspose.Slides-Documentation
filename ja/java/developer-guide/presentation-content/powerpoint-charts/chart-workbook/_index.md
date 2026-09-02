---
title: "Java を使用したプレゼンテーションでのチャート ワークブックの管理"
linktitle: "チャート ワークブック"
type: docs
weight: 70
url: /ja/java/chart-workbook/
keywords:
- "チャート ワークブック"
- "チャート データ"
- "ワークブック セル"
- "データ ラベル"
- "ワークシート"
- "データ ソース"
- "外部ワークブック"
- "外部データ"
- "チャート キャッシュ"
- "ワークブック 復元"
- "PowerPoint"
- "プレゼンテーション"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java を発見: PowerPoint および OpenDocument 形式でチャート ワークブックを簡単に管理し、プレゼンテーション データを効率化します。"
---
## **概要**

本記事では、Aspose.Slides でチャートブックを操作する方法を説明します。ワークブック ストリームを介してチャート データの読み書き、ワークブック セルをチャート データ ラベルとして使用、ワークシート コレクションへのアクセス、チャート値のデータ ソース タイプの指定方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も扱います。例では、外部ワークブックを作成して割り当てる方法、チャートにリンクされた外部ワークブックのパスを取得する方法、ワークブックが利用可能な場合にチャート データを編集する方法を示します。

## **ワークブックからチャート データの読み取りと書き込み**

Aspose.Slides は、[ReadWorkbookStream](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IChartData#readWorkbookStream--) と [WriteWorkbookStream](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) メソッドを提供しており、これらを使用してチャート データ ワークブック（Aspose.Cells で編集されたチャート データを含む）の読み取りと書き込みが可能です。**注**: チャート データは同じ方法で構成されているか、元データと同様の構造を持っている必要があります。

この Java コードはサンプル操作を示しています。

```java
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

## **ワークブック セルをチャート データ ラベルとして設定する**

1. [Presentation](https://apireference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. データを含むバブル チャートを追加します。
1. チャート シリーズにアクセスします。
1. ワークブック セルをデータ ラベルとして設定します。
1. プレゼンテーションを保存します。

この Java コードは、ワークブック セルをチャート データ ラベルとして設定する方法を示しています。

```java
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

この Java コードは、[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) メソッドを使用してワークシート コレクションにアクセスする操作を示しています。

```java
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

この Java コードは、データ ソースのタイプを指定する方法を示しています。

```java
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

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。サポートされていない形式を検出し、該当するチャートをスキップするには、[IChartData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IChartData) の `getEmbeddedWorkbookType` メソッドと [WorkbookType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/WorkbookType) 列挙体を組み合わせて使用できます。

```java
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

                // ここでチャート ワークブック データを読み取るか、変更します。
    }
} finally {
    presentation.dispose();
}
```

## **外部ワークブック**

{{% alert color="primary" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/ja/java/aspose-slides-for-java-19-4-release-notes/) では、外部ワークブックをチャートのデータ ソースとしてサポートする機能を実装しました。
{{% /alert %}} 

### **外部ワークブックの作成**

**`readWorkbookStream`** および **`setExternalWorkbook`** メソッドを使用すると、外部ワークブックをゼロから作成するか、内部ワークブックを外部化することができます。

この Java コードは、外部ワークブックの作成プロセスを示しています。

```java
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

**`setExternalWorkbook`** メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合にパスを更新するためにも使用できます。

リモート場所やリソースに保存されているワークブックのデータは編集できませんが、外部データ ソースとして使用することは可能です。外部ワークブックの相対パスが指定された場合、自動的に絶対パスに変換されます。

この Java コードは、外部ワークブックを設定する方法を示しています。

```java
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

`setExternalWorkbook` メソッドの `ChartData` パラメータは、Excel ワークブックをロードするかどうかを指定するために使用されます。

* `ChartData` の値が `false` に設定されている場合、ワークブック パスのみが更新され、チャート データは対象ワークブックから読み込まれず、更新もされません。対象ワークブックが存在しない、または利用できない状況でこの設定を使用することがあります。
* `ChartData` の値が `true` に設定されている場合、チャート データは対象ワークブックから更新されます。

```java
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

### **チャートの外部データソース ワークブック パスの取得**

1. [Presentation](https://apireference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. チャート シェイプのオブジェクトを作成します。
1. ソース（`ChartDataSourceType`）タイプのオブジェクトを作成します。これはチャートのデータ ソースを表します。
1. ソース タイプが外部ワークブック データ ソース タイプと同じであることに基づいて、適切な条件を指定します。

この Java コードは、操作を示しています。

```java
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

この Java コードは、上記プロセスの実装例です。

```java
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

チャートが存在しない、または利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされているデータからチャート ワークブックを再構築できます。プレゼンテーションを開く前に、[LoadOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/) を作成し、[SpreadsheetOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/spreadsheetoptions/) で構成し、`true` を指定して [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) を呼び出します。

以下の Java 例は、チャートが利用できない外部ワークブックを参照しているプレゼンテーションを開き、[IChart.getChartData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichart/#getChartData--) および [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) を通じて復元されたデータにアクセスします。

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // 復元されたワークブック データをここで読み取るか、変更します。
} finally {
    presentation.dispose();
}
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションが最後に更新された後に外部ワークブックで行われた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックまたは埋め込みワークブックにリンクされているかを判別できますか？**

はい。チャートには[データ ソース タイプ](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chartdata/#getDataSourceType--) と[外部ワークブックへのパス](https://reference.aspose.com/slides/ja/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) があり、ソースが外部ワークブックの場合、完全なパスを読み取ることで外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？ また、どのように保存されますか？**

はい。相対パスを指定すると、自動的に絶対パスに変換されます。これはプロジェクトのポータビリティに便利ですが、プレゼンテーションは PPTX ファイル内に絶対パスを保存することに注意してください。

**ネットワークリソース/共有上にあるワークブックを使用できますか？**

はい、これらのワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートワークブックを直接編集することはサポートされておらず、ソースとしてのみ使用可能です。

**プレゼンテーションを保存する際に、Aspose.Slides は外部 XLSX を上書きしますか？**

いいえ。プレゼンテーションは外部ファイルへのリンクを保存し、データの読み取りに使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、復号化されたコピー（例: [Aspose.Cells](/cells/java/) を使用）を用意してそのコピーにリンクします。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートはそれぞれのリンクを保持します。すべてが同じファイルを指している場合、そのファイルを更新すると、次回データがロードされたときに各チャートに反映されます。