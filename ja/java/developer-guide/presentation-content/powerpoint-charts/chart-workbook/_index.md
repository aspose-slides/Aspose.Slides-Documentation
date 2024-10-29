---
title: チャートワークブック
type: docs
weight: 70
url: /ja/java/chart-workbook/
keywords: "チャートワークブック, チャートデータ, PowerPointプレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaにおけるPowerPointプレゼンテーションのチャートワークブック"
---

## **ワークブックからチャートデータを設定**
Aspose.Slidesは、チャートデータワークブック（Aspose.Cellsで編集されたチャートデータを含む）の読み取りと書き込みを可能にする[ReadWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#readWorkbookStream--)および[WriteWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-)メソッドを提供しています。 **注意**：チャートデータは、同じ方法で整理されている必要があるか、ソースに似た構造を持っている必要があります。

このJavaコードはサンプル操作を示しています：

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

## **ワークブックセルをチャートデータラベルとして設定**

1. [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのインデックスを通じて参照を取得します。
1. データを持つバブルチャートを追加します。
1. チャートシリーズにアクセスします。
1. ワークブックセルをデータラベルとして設定します。
1. プレゼンテーションを保存します。

このJavaコードはワークブックセルをチャートデータラベルとして設定する方法を示しています：

```java
String lbl0 = "ラベル0のセル値";
String lbl1 = "ラベル1のセル値";
String lbl2 = "ラベル2のセル値";

// プレゼンテーションクラスのインスタンスを作成します
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

## **ワークシートを管理**

このJavaコードは、[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--)メソッドを使用してワークシートコレクションにアクセスする操作を示しています：

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

## **データソースタイプを指定**

このJavaコードは、データソースのタイプを指定する方法を示しています：

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

{{% alert color="primary" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/java/aspose-slides-for-java-19-4-release-notes/)では、チャートのデータソースとして外部ワークブックのサポートを実装しました。
{{% /alert %}} 

### **外部ワークブックを作成**

**`readWorkbookStream`**および**`setExternalWorkbook`**メソッドを使用することで、外部ワークブックをゼロから作成することも、内部ワークブックを外部にすることもできます。

このJavaコードは外部ワークブック作成プロセスを示しています：

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

### **外部ワークブックを設定**

**`setExternalWorkbook`**メソッドを使用すると、チャートに外部ワークブックをデータソースとして割り当てることができます。このメソッドは、外部ワークブックのパスを更新するためにも使用できます（移動した場合）。

リモートの場所やリソースに保存されたワークブック内のデータを編集することはできませんが、そのようなワークブックを外部データソースとして使用することはできます。外部ワークブックの相対パスが提供された場合、自動的にフルパスに変換されます。

このJavaコードは外部ワークブックを設定する方法を示しています：

```java
// プレゼンテーションクラスのインスタンスを作成します
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

`setExternalWorkbook`メソッドの`ChartData`パラメータは、Excelワークブックが読み込まれるかどうかを指定するために使用されます。 

* `ChartData`の値が`false`に設定されている場合、ワークブックのパスのみが更新され、チャートデータは対象のワークブックから読み込まれたり更新されたりしません。この設定は、対象のワークブックが存在しないか、利用できない場合に使用したい場合です。
* `ChartData`の値が`true`に設定されている場合、チャートデータは対象のワークブックから更新されます。

```java
// プレゼンテーションクラスのインスタンスを作成します
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

### **チャート外部データソースワークブックパスを取得**

1. [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドのインデックスを通じて参照を取得します。
1. チャートシェイプのオブジェクトを作成します。
1. チャートのデータソースを表すオブジェクト（`ChartDataSourceType`）を作成します。
1. ソースタイプが外部ワークブックデータソースタイプと同じであるという条件に基づいて関連条件を指定します。

このJavaコードは操作を示しています：

```java
// プレゼンテーションクラスのインスタンスを作成します
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// プレゼンテーションを保存
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **チャートデータの編集**

外部ワークブック内のデータは、内部ワークブックの内容を変更するのと同じ方法で編集できます。外部ワークブックを読み込めない場合は、例外がスローされます。

このJavaコードは、記述されたプロセスの実装です：

```java
// プレゼンテーションクラスのインスタンスを作成します
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