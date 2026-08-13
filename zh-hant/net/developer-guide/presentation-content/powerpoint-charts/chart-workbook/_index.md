---
title: 在 .NET 中管理簡報的圖表工作簿
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
description: "探索適用於 .NET 的 Aspose.Slides：輕鬆管理 PowerPoint 與 OpenDocument 格式中的圖表工作簿，以簡化您的簡報資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、使用工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

此外，也涵蓋了將外部工作簿作為圖表資料來源的使用方式。範例示範了如何建立與指派外部工作簿、取得鏈結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

## **從工作簿讀寫圖表資料**
Aspose.Slides 提供了 [ReadWorkbookStream](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/readworkbookstream/) 和 [WriteWorkbookStream](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/writeworkbookstream/) 方法，允許您讀寫圖表資料工作簿（包含由 Aspose.Cells 編輯的圖表資料）。**注意**，圖表資料必須以相同方式組織或具有類似於來源的結構。

This C# code demonstrates a sample operation:

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

## **將 WorkBook 儲存格設為圖表資料標籤**
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得投影片的參考。
3. 新增一個含有資料的氣泡圖表。
4. 存取圖表系列。
5. 將工作簿儲存格設定為資料標籤。
6. 儲存簡報。

以下 C# 程式碼示範如何將工作簿儲存格設為圖表資料標籤：

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// 實例化一個代表簡報檔案的 Presentation 類別

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
以下 C# 程式碼示範如何使用 [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) 屬性來存取工作表集合：

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
以下 C# 程式碼示範如何為資料來源指定類型：

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
Aspose.Slides 不支援可嵌入某些圖表的 Excel 二進位工作簿（.xlsb）格式。您可以在 [IChartData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/) 上使用 `EmbeddedWorkbookType` 屬性，結合 [WorkbookType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/workbooktype/) 列舉，偵測不支援的格式並略過那些圖表。

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
                // 嵌入式工作簿為 .xlsb 格式，不受支援。
                continue;
        }

                // 在此讀取或修改圖表工作簿資料。
    }
}
```

## **外部工作簿**

{{% alert color="info" %}} 
在 [Aspose.Slides 19.4](https://docs.aspose.com/slides/zh-hant/net/aspose-slides-for-net-19-4-release-notes/) 中，我們實作了對外部工作簿作為圖表資料來源的支援。
{{% /alert %}} 

### **建立外部工作簿**
使用 **`ReadWorkbookStream`** 與 **`SetExternalWorkbook`** 方法，您可以從頭建立外部工作簿，或將內部工作簿轉為外部工作簿。

以下 C# 程式碼示範外部工作簿的建立過程：

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
使用 **`SetExternalWorkbook`** 方法，您可以將外部工作簿指派給圖表作為資料來源。此方法亦可用於更新外部工作簿的路徑（如果該工作簿已被搬移）。

雖然無法編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿用作外部資料來源。如果提供外部工作簿的相對路徑，系統會自動將其轉換為完整路徑。

以下 C# 程式碼示範如何設定外部工作簿：

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

`SetExternalWorkbook` 方法中的 `ChartData` 參數用於指定是否載入 Excel 工作簿。

* 當 `ChartData` 設為 `false` 時，僅更新工作簿路徑——圖表資料不會從目標工作簿載入或更新。當目標工作簿不存在或無法取得時，可使用此設定。  
* 當 `ChartData` 設為 `true` 時，圖表資料會從目標工作簿更新。

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

### **取得圖表外部資料來源工作簿的路徑**
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得投影片的參考。
3. 建立圖表形狀的物件。
4. 建立代表圖表資料來源的來源 (`ChartDataSourceType`) 類型物件。
5. 根據來源類型與外部工作簿資料來源類型相同，指定相關條件。

以下 C# 程式碼示範此操作：

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

### **從圖表快取復原工作簿**
如果圖表使用的外部工作簿遺失或無法取得，Aspose.Slides 可以從簡報中快取的資料重建圖表工作簿。於開啟簡報前，建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/)，設定其 [SpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/spreadsheetoptions/)，並將 [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) 設為 `true`。

以下 C# 範例開啟一個圖表參考不可用外部工作簿的簡報，並透過 [IChart.ChartData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/chartdata/) 與 [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/chartdataworkbook/) 取得已復原的資料：

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

// 在此讀取或修改已復原的工作簿資料。
```

若外部工作簿不可用且未啟用復原，Aspose.Slides 會拋出 `InvalidOperationException`。僅在接受使用快取圖表資料作為備援時才啟用復原，因為快取可能不包含簡報最後更新後對外部工作簿所做的變更。

## **常見問題**

**我能判斷特定圖表是連結至外部工作簿還是內嵌工作簿嗎？**  
是的。圖表具有 [資料來源類型](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/datasourcetype/) 與 [外部工作簿的路徑](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/externalworkbookpath/)；若來源為外部工作簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援外部工作簿的相對路徑？它們如何被儲存？**  
是的。若指定相對路徑，系統會自動轉換為絕對路徑。這對專案可移植性很方便；但請注意，簡報會在 PPTX 檔案中儲存絕對路徑。

**我可以使用位於網路資源/共享上的工作簿嗎？**  
可以，此類工作簿可作為外部資料來源使用。然而，Aspose.Slides 不支援直接編輯遠端工作簿——只能作為來源使用。

**Aspose.Slides 會在儲存簡報時覆寫外部 XLSX 檔案嗎？**  
不會。簡報會儲存一個指向外部檔案的 [連結](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/externalworkbookpath/)，僅用於讀取資料。儲存簡報時不會修改外部檔案本身。

**如果外部檔案受密碼保護，我該怎麼辦？**  
Aspose.Slides 在建立連結時不接受密碼。常見的做法是事先移除保護或備妥解密的副本（例如使用 [Aspose.Cells](/cells/net/)），再連結至該副本。

**多個圖表可以參考同一個外部工作簿嗎？**  
可以。每個圖表皆存有自己的連結。若它們皆指向同一檔案，更新該檔案後，下次載入資料時所有圖表都會反映變更。