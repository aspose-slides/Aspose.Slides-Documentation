---
title: 在 .NET 中管理簡報中的圖表工作簿
linktitle: 圖表工作簿
type: docs
weight: 70
url: /zh-hant/net/chart-workbook/
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
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET：輕鬆管理 PowerPoint 與 OpenDocument 格式的圖表工作簿，以簡化簡報資料。"
---
## **概述**

本文說明了如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、將工作簿儲存格用作圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

同時也討論了將外部工作簿作為圖表資料來源的使用方式。範例示範了如何建立與指派外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

## **從工作簿讀寫圖表資料**
Aspose.Slides 提供了 [ReadWorkbookStream](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/readworkbookstream/) 和 [WriteWorkbookStream](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/writeworkbookstream/) 方法，允許您讀寫圖表資料工作簿（包含使用 Aspose.Cells 編輯的圖表資料）。**Note** 圖表資料必須以相同方式組織或結構類似於來源。

此 C# 程式碼示範了一個範例操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

### **在工作簿變更後驗證圖表版面配置**

當您以已修改的工作簿取代內嵌工作簿時，圖表仍保留原始的系列與類別集合。此不匹配可能導致 [IChart.ValidateChartLayout](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/validatechartlayout/) 因索引超出範圍而失敗。請在將更新後的工作簿寫回圖表之前，先清除現有的系列與類別。

```csharp
// 在修改工作簿串流之後（例如使用 Aspose.Cells）
using var updatedWorkbook = chartData.ReadWorkbookStream();

// 清除現有的資料參照。
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

清除集合可確保圖表資料結構與新工作簿一致，讓 `ValidateChartLayout` 能在無錯誤的情況下完成。

## **將工作簿儲存格設為圖表資料標籤**
1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 新增一個泡泡圖並加入一些資料。  
4. 取得圖表系列。  
5. 將工作簿儲存格設為資料標籤。  
6. 儲存簡報。

此 C# 程式碼示範如何將工作簿儲存格設為圖表資料標籤：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// 建立一個表示簡報檔案的 Presentation 類別實例 

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **管理工作表**

此 C# 程式碼示範了使用 [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) 屬性存取工作表集合的操作：

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **指定資料來源類型**

此 C# 程式碼示範如何為資料來源指定類型：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **偵測不支援的內嵌工作簿格式**

Aspose.Slides 不支援某些圖表可能內嵌的 Excel 二進位工作簿（.xlsb）格式。您可以在 [IChartData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/) 上使用 `EmbeddedWorkbookType` 屬性，搭配 [WorkbookType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/workbooktype/) 列舉來偵測不支援的格式並跳過這些圖表。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // 嵌入的工作簿為 .xlsb 格式，未受支援。
            continue;
        }

        // 在此讀取或修改圖表工作簿資料。
    }
}
```

## **外部工作簿**

{{% alert color="info" %}} 
在 [Aspose.Slides 19.4](https://docs.aspose.com/slides/zh-hant/net/aspose-slides-for-net-19-4-release-notes/) 中，我們實作了支援將外部工作簿作為圖表資料來源的功能。 
{{% /alert %}} 

### **建立外部工作簿**
使用 **`ReadWorkbookStream`** 和 **`SetExternalWorkbook`** 方法，您可以從頭建立外部工作簿，或將內部工作簿轉為外部工作簿。

此 C# 程式碼示範外部工作簿的建立過程：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **設定外部工作簿**
使用 **`SetExternalWorkbook`** 方法，您可以將外部工作簿指定為圖表的資料來源。此方法也可用於更新外部工作簿的路徑（若該工作簿已被移動）。

雖然無法編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源使用。若提供外部工作簿的相對路徑，系統會自動將其轉換為完整路徑。

此 C# 程式碼示範如何設定外部工作簿：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// 文件目錄的路徑。
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

`SetExternalWorkbook` 方法下的 `ChartData` 參數用於指定是否載入 Excel 工作簿。

* 當 `ChartData` 設為 `false` 時，僅會更新工作簿路徑——圖表資料不會從目標工作簿載入或更新。若目標工作簿不存在或無法取得，建議使用此設定。  
* 當 `ChartData` 設為 `true` 時，圖表資料會自目標工作簿更新。

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **取得圖表的外部資料來源工作簿路徑**

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 為圖表形狀建立物件。  
4. 為來源 (`ChartDataSourceType`) 類型建立物件，以表示圖表的資料來源。  
5. 根據來源類型與外部工作簿資料來源類型相同的條件，指定相關條件。

此 C# 程式碼示範此操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // 儲存簡報
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **編輯圖表資料**

您可以像編輯內部工作簿內容一樣編輯外部工作簿的資料。若無法載入外部工作簿，將拋出例外。

此 C# 程式碼實作上述流程：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **從圖表快取中復原工作簿**

如果圖表使用的外部工作簿缺失或無法取得，Aspose.Slides 可以從簡報中快取的資料重建圖表工作簿。建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/)，設定其 [SpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/spreadsheetoptions/)，並在開啟簡報前將 [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) 設為 `true`。

以下 C# 範例開啟一個圖表參照不可用外部工作簿的簡報，並透過 [IChart.ChartData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/chartdata/) 與 [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/chartdataworkbook/) 取得復原的資料：

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Read or modify the recovered workbook data here.
```

如果外部工作簿不可用且未啟用復原，Aspose.Slides 會拋出 `InvalidOperationException`。僅在使用快取的圖表資料是可接受的備援方案時才啟用復原，因為快取可能不包含外部工作簿在最後一次更新簡報後所做的變更。

## **常見問題**

**我能判斷特定圖表是連結到外部工作簿還是內嵌工作簿嗎？**

可以。圖表具有 [資料來源類型](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/datasourcetype/) 與 [外部工作簿路徑](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/externalworkbookpath/)；若來源是外部工作簿，您可以讀取完整路徑以確認使用了外部檔案。

**支援相對路徑的外部工作簿嗎？它們如何儲存？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。這對專案可移植性很方便；但請注意，簡報會在 PPTX 檔案中儲存絕對路徑。

**可以使用位於網路資源/共享上的工作簿嗎？**

可以，此類工作簿可作為外部資料來源使用。然而，Aspose.Slides 不支援直接編輯遠端工作簿——只能作為來源使用。

**保存簡報時，Aspose.Slides 會覆寫外部 XLSX 嗎？**

不會。簡報只儲存一個指向外部檔案的 [連結](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/externalworkbookpath/)，並在讀取資料時使用該連結。保存簡報時不會修改外部檔案本身。

**如果外部檔案受密碼保護，該怎麼辦？**

Aspose.Slides 連結時不接受密碼。常見做法是事先解除保護，或事先準備一個已解密的副本（例如使用 [Aspose.Cells](/cells/net/)），再連結至該副本。

**多個圖表可以參照同一個外部工作簿嗎？**

可以。每個圖表都會存儲自己的連結。如果它們指向同一個檔案，更新該檔案後，下次載入資料時所有圖表都會反映變更。