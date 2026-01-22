---
title: Androidでのプレゼンテーションにおけるチャートワークブックの管理
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
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides をご紹介します。PowerPoint および OpenDocument 形式のチャートワークブックを簡単に管理し、プレゼンテーション データを効率化します。"
---

## **ワークブックからチャート データの読み取りと書き込み**
Aspose.Slides は、[ReadWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) と [WriteWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) メソッドを提供し、チャート データ ワークブック（Aspose.Cells で編集されたチャート データを含む）を読み書きできます。**注**：チャート データは同じ形式で整理されているか、元のデータと類似した構造である必要があります。

この Java コードはサンプル操作を示しています:
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


## **ワークブックのセルをチャート データ ラベルとして設定**

1. [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドの参照を取得します。  
1. データを含むバブル チャートを追加します。  
1. チャート シリーズにアクセスします。  
1. ワークブックのセルをデータ ラベルとして設定します。  
1. プレゼンテーションを保存します。

この Java コードは、ワークブックのセルをチャート データ ラベルとして設定する方法を示しています:
```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します
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

この Java コードは、[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) メソッドを使用してワークシート コレクションにアクセスする操作を示しています:
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

この Java コードは、データ ソースのタイプを指定する方法を示しています:
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


## **外部ワークブック**

Aspose.Slides は、チャートのデータ ソースとして外部ワークブックをサポートしています。

### **外部ワークブックの作成**

**`readWorkbookStream`** と **`setExternalWorkbook`** メソッドを使用すると、最初から外部ワークブックを作成するか、内部ワークブックを外部化することができます。

この Java コードは、外部ワークブック作成プロセスを示しています:
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

**`setExternalWorkbook`** メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックへのパスが変更された場合（移動された場合）に更新するためにも使用できます。

リモートの場所やリソースに保存されているワークブックのデータは編集できませんが、外部データ ソースとして使用することは可能です。外部ワークブックの相対パスが指定されている場合、自動的にフル パスに変換されます。

この Java コードは、外部ワークブックを設定する方法を示しています:
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


`ChartData` パラメーター（`setExternalWorkbook` メソッド内）は、Excel ワークブックをロードするかどうかを指定するために使用されます。

* `ChartData` の値が `false` に設定されている場合、ワークブックのパスだけが更新され、チャート データは対象ワークブックからロードまたは更新されません。対象ワークブックが存在しない、または利用できない状況でこの設定を使用することがあります。  
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


### **チャートの外部データ ソース ワークブック パスの取得**

1. [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
1. インデックスを使用してスライドの参照を取得します。  
1. チャート シェイプのオブジェクトを作成します。  
1. チャートのデータ ソースを表すソース（`ChartDataSourceType`）タイプのオブジェクトを作成します。  
1. ソース タイプが外部ワークブック データ ソース タイプと同じであることに基づき、該当する条件を指定します。  

この Java コードは、上記の操作を示しています:
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

外部ワークブックのデータは、内部ワークブックの内容を変更するのと同様に編集できます。外部ワークブックをロードできない場合、例外がスローされます。

この Java コードは、上記のプロセスの実装例です:
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


## **よくある質問**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判別できますか？**

はい。チャートには [データ ソース タイプ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) と [外部ワークブックへのパス](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) があり、ソースが外部ワークブックの場合、フル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？また、どのように保存されますか？**

はい。相対パスを指定すると、自動的に絶対パスに変換されます。これはプロジェクトのポータビリティに便利ですが、PPTX ファイルには絶対パスが保存されることに注意してください。

**ネットワークリソース/共有上にあるワークブックを使用できますか？**

はい。そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートのワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーションを保存するとき、Aspose.Slides は外部 XLSX を上書きしますか？**

いいえ。プレゼンテーションは外部ファイルへの [リンク](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) を保存し、データの読み取りに使用します。プレゼンテーションを保存しても外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合、どうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、復号化したコピー（例: [Aspose.Cells](/cells/androidjava/) を使用）を用意してそのコピーにリンクします。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートはそれぞれのリンクを保持します。すべてが同じファイルを指している場合、そのファイルを更新すると、次回データがロードされる際に各チャートに反映されます。