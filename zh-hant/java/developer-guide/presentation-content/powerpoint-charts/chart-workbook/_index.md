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
- 圖表快取
- 工作簿復原
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表工作簿，簡化簡報資料。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它示範如何透過工作簿串流讀寫圖表資料、將工作簿儲存格作為圖表資料標籤、存取工作表集合，以及指定圖表數值的資料來源類型。

此外，還涵蓋了使用外部工作簿作為圖表資料來源的情況。範例展示如何建立與指定外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

## **從工作簿讀寫圖表資料**
Aspose.Slides 提供 [ReadWorkbookStream](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartData#readWorkbookStream--) 和 [WriteWorkbookStream](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) 方法，允許您讀寫圖表資料工作簿（其中包含使用 Aspose.Cells 編輯的圖表資料）。**注意**，圖表資料必須以相同的方式組織，或必須具有與來源相似的結構。

以下 Java 程式碼示範了一個範例操作：

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

## **將工作簿儲存格設為圖表資料標籤**

1. 建立 [Presentation](https://apireference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 加入帶有資料的泡沫圖表。  
1. 存取圖表系列。  
1. 將工作簿儲存格設為資料標籤。  
1. 儲存簡報。

以下 Java 程式碼示範如何將工作簿儲存格設為圖表資料標籤：

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// 實例化一個代表簡報檔案的 Presentation 類別
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

以下 Java 程式碼示範一個使用 [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) 方法存取工作表集合的操作：

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

## **指定資料來源類型**

以下 Java 程式碼示範如何為資料來源指定類型：

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

## **偵測不支援的內嵌工作簿格式**

Aspose.Slides 不支援某些圖表可能內嵌的 Excel 二進位工作簿（.xlsb）格式。您可以在 [IChartData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartData#readWorkbookStream--) 上使用 `getEmbeddedWorkbookType` 方法，結合 [WorkbookType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/WorkbookType) 列舉，來偵測不支援的格式並跳過那些圖表。

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
            // 嵌入的工作簿為 .xlsb 格式，不受支援。
            continue;
        }

        // 在此讀取或修改圖表工作簿資料。
    }
} finally {
    presentation.dispose();
}
```

## **外部工作簿**

{{% alert color="info" %}} 
在 [Aspose.Slides 19.4](https://docs.aspose.com/slides/zh-hant/java/aspose-slides-for-java-19-4-release-notes/) 中，我們實作了支援將外部工作簿作為圖表資料來源的功能。
{{% /alert %}} 

### **建立外部工作簿**

使用 **`readWorkbookStream`** 和 **`setExternalWorkbook`** 方法，您可以從頭建立外部工作簿，或將內部工作簿轉為外部工作簿。

以下 Java 程式碼示範外部工作簿的建立過程：

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

### **設定外部工作簿**

使用 **`setExternalWorkbook`** 方法，您可以將外部工作簿指派給圖表作為其資料來源。此方法亦可用於更新外部工作簿的路徑（如果該工作簿已被移動）。

雖然無法編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源使用。若提供外部工作簿的相對路徑，系統會自動將其轉換為完整路徑。

以下 Java 程式碼示範如何設定外部工作簿：

```java
import com.aspose.slides.*;

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

`setExternalWorkbook` 方法的第二個 (`boolean`) 參數用於指定是否載入 Excel 工作簿。

* 當其值設定為 `false` 時，僅會更新工作簿路徑——圖表資料不會從目標工作簿載入或更新。當目標工作簿不存在或無法取得時，可使用此設定。  
* 當其值設定為 `true` 時，圖表資料會從目標工作簿更新。

```java
import com.aspose.slides.*;

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

### **取得圖表外部資料來源工作簿的路徑**

1. 建立 [Presentation](https://apireference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 為圖表形狀建立物件。  
1. 建立代表圖表資料來源的來源 (`ChartDataSourceType`) 類型之物件。  
1. 根據來源類型與外部工作簿資料來源類型相同，指定相關條件。

以下 Java 程式碼示範此操作：

```java
import com.aspose.slides.*;

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

您可以像編輯內部工作簿內容一樣編輯外部工作簿中的資料。若無法載入外部工作簿，將拋出例外。

以下 Java 程式碼實作了上述流程：

```java
import com.aspose.slides.*;

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

### **從圖表快取復原工作簿**

如果圖表使用的外部工作簿遺失或無法取得，Aspose.Slides 可從簡報中快取的資料重建圖表工作簿。建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/loadoptions/)，以 [SpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/spreadsheetoptions/) 進行設定，且在開啟簡報前呼叫 [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) 並傳入 `true`。

以下 Java 範例開啟一個圖表參考不可用外部工作簿的簡報，並透過 [IChart.getChartData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichart/#getChartData--) 與 [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) 取得復原的資料：

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // 在此讀取或修改復原的工作簿資料。
} finally {
    presentation.dispose();
}
```

若外部工作簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅在使用快取的圖表資料作為可接受的備援時才啟用復原，因為快取可能不包含演示文稿最後更新後對外部工作簿所做的變更。

## **常見問題**

**我可以判斷特定圖表是連結到外部工作簿還是內嵌工作簿嗎？**  
可以。圖表具有 [資料來源類型](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chartdata/#getDataSourceType--) 和 [外部工作簿的路徑](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)；如果來源是外部工作簿，您可以讀取完整路徑以確認使用了外部檔案。

**是否支援外部工作簿的相對路徑？它們如何儲存？**  
是的。若指定相對路徑，系統會自動將其轉換為絕對路徑。這對專案可移植性很方便；但請留意簡報會在 PPTX 檔案中儲存絕對路徑。

**我可以使用位於網路資源/共享上的工作簿嗎？**  
可以，此類工作簿可作為外部資料來源使用。然而，Aspose.Slides 不支援直接編輯遠端工作簿——只能用作來源。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 檔案嗎？**  
不會。簡報會儲存 [外部檔案的連結](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) 並在讀取資料時使用。儲存簡報時不會修改外部檔案本身。

**如果外部檔案受密碼保護，我該怎麼辦？**  
Aspose.Slides 在建立連結時不接受密碼。一般的做法是事先移除保護或準備一個已解密的副本（例如使用 [Aspose.Cells](/cells/java/)），並連結至該副本。

**多個圖表可以參考同一個外部工作簿嗎？**  
可以。每個圖表都會儲存自己的連結。如果它們都指向同一個檔案，更新該檔案後，下次載入資料時每個圖表都會反映此變更。