---
title: 使用 Java 管理簡報中的圖表工作簿
linktitle: 圖表工作簿
type: docs
weight: 70
url: /zh-hant/java/chart-workbook/
keywords:
- 圖表工作簿
- 圖表資料
- 工作簿儲存格
- 資料標籤
- 工作表
- 資料來源
- 外部工作簿
- 外部資料
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表工作簿，簡化簡報資料。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、使用工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

它還涵蓋了將外部工作簿作為圖表資料來源的使用方式。範例示範了如何建立與指派外部工作簿、取得連結到圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

## **從工作簿讀寫圖表資料**
Aspose.Slides 提供 [ReadWorkbookStream](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartData#readWorkbookStream--) 與 [WriteWorkbookStream](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) 方法，讓您讀寫圖表資料工作簿（其中包含以 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同方式組織，或其結構需類似於來源。

以下 Java 程式碼示範一個範例操作：

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

## **將工作簿儲存格設定為圖表資料標籤**

1. 建立一個 [Presentation](https://apireference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的執行個體。  
2. 透過索引取得投影片的參照。  
3. 加入一個包含資料的氣泡圖表。  
4. 存取圖表系列。  
5. 將工作簿儲存格設定為資料標籤。  
6. 儲存簡報。  

以下 Java 程式碼示範如何將工作簿儲存格設定為圖表資料標籤：

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// 實例化表示簡報檔案的 Presentation 類別
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

## **管理工作表**

以下 Java 程式碼示範使用 [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) 方法存取工作表集合的操作：

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

## **指定資料來源類型**

以下 Java 程式碼示範如何為資料來源指定類型：

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

## **偵測不受支援的內嵌工作簿格式**

Aspose.Slides 不支援某些圖表中可內嵌的 Excel 二進位工作簿 (.xlsb) 格式。您可以在 [IChartData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartData) 上使用 `getEmbeddedWorkbookType` 方法，結合 [WorkbookType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/WorkbookType) 列舉，偵測不受支援的格式並跳過這些圖表。

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
            // 嵌入的工作簿是 .xlsb 格式，不受支援。
            continue;
        }

        // 在此讀取或修改圖表工作簿資料。
    }
} finally {
    presentation.dispose();
}
```

## **外部工作簿**

{{% alert color="primary" %}} 
在 [Aspose.Slides 19.4](https://docs.aspose.com/slides/zh-hant/java/aspose-slides-for-java-19-4-release-notes/) 中，我們實作了對外部工作簿作為圖表資料來源的支援。
{{% /alert %}} 

### **建立外部工作簿**

使用 **`readWorkbookStream`** 與 **`setExternalWorkbook`** 方法，您可以從頭建立外部工作簿，或將內部工作簿轉為外部工作簿。

以下 Java 程式碼示範外部工作簿的建立流程：

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

### **設定外部工作簿**

使用 **`setExternalWorkbook`** 方法，您可以將外部工作簿指派給圖表作為其資料來源。此方法也可用於更新外部工作簿的路徑（如果該檔案已移動）。

雖然無法編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源使用。如果提供外部工作簿的相對路徑，系統會自動將其轉換為完整路徑。

以下 Java 程式碼示範如何設定外部工作簿：

```java
// 建立 Presentation 類別的實例
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

`setExternalWorkbook` 方法中的 `ChartData` 參數用於指定是否載入 Excel 工作簿。

* 當 `ChartData` 值設為 `false` 時，僅更新工作簿路徑——圖表資料不會從目標工作簿載入或更新。當目標工作簿不存在或無法取得時，可使用此設定。  
* 當 `ChartData` 值設為 `true` 時，圖表資料會從目標工作簿更新。

```java
// 建立 Presentation 類別的實例
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

### **取得圖表的外部資料來源工作簿路徑**

1. 建立一個 [Presentation](https://apireference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的執行個體。  
2. 透過索引取得投影片的參照。  
3. 建立圖表形狀的物件。  
4. 建立來源 (`ChartDataSourceType`) 類型的物件，以表示圖表的資料來源。  
5. 根據來源類型與外部工作簿資料來源類型相同，指定相關條件。  

以下 Java 程式碼示範此操作：

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// 儲存簡報
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **編輯圖表資料**

您可以以與編輯內部工作簿相同的方式編輯外部工作簿的資料。當無法載入外部工作簿時，會擲出例外。

以下 Java 程式碼實作上述流程：

```java
// 建立 Presentation 類別的實例
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

## **常見問題**

**我能否判斷特定圖表是連結到外部工作簿還是嵌入的工作簿？**

可以。圖表具有 [資料來源類型](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chartdata/#getDataSourceType--) 與 [外部工作簿路徑](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)；若來源為外部工作簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援外部工作簿的相對路徑，且它們如何被儲存？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。這對專案可移植性很有幫助；但需注意簡報會在 PPTX 檔案中儲存絕對路徑。

**我可以使用位於網路資源/共享上的工作簿嗎？**

可以，此類工作簿可作為外部資料來源使用。然而，Aspose.Slides 不支援直接編輯遠端工作簿——只能將其作為來源使用。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 嗎？**

不會。簡報會儲存一個 [外部檔案的連結](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) 並用於讀取資料。儲存簡報時外部檔案本身不會被修改。

**如果外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 在建立連結時不接受密碼。常見的做法是事先移除保護或準備一個已解密的副本（例如使用 [Aspose.Cells](/cells/java/)），並連結至該副本。

**多個圖表可以參考同一個外部工作簿嗎？**

可以。每個圖表都儲存自己的連結。若它們皆指向同一檔案，更新該檔案後在下次載入資料時會反映於每個圖表。