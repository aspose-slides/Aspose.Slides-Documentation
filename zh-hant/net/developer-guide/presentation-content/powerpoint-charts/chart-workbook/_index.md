---
title: 在 .NET 中管理投影片的圖表工作簿
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
- 投影片
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表工作簿，簡化您的投影片資料。"
---
## **概述**

本文說明了如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、將工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

它還涵蓋了將外部工作簿作為圖表資料來源的使用方式。範例示範如何建立並指派外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

關於代表遺失資料的工作簿儲存格，請參閱[控制空儲存格的顯示](/slides/zh-hant/net/chart-series/)，了解空儲存格與零之間的差異，以及可用顯示模式的折線圖比較。

## **包含隱藏列與欄位的資料**

使用[IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/plotvisiblecellsonly/)來控制圖表是否繪製來自隱藏工作表列與欄位的資料。設為 `true` 只繪製可見儲存格，設為 `false` 則同時包含可見與隱藏儲存格。此設定僅影響圖表繪製，並不會隱藏或取消隱藏工作表的列或欄位。

下載[hidden-source-data.pptx](hidden-source-data.pptx)並放在工作目錄中。其第一張投影片包含一個柱狀圖作為第一個圖形。內嵌工作表 `Sheet1` 包含以下來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍保有值。

| 工作表列 | A: 月份 | B: 零售 | C: 批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隱藏列） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/chartdataworkbook/)存取來源儲存格，並讀取[IChartDataCell.IsHidden](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/ishidden/)檢查其隱藏狀態。此屬性為唯讀。在此檔案中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別印出 `False`、`True` 與 `True`。

對於此範例，變更繪製設定後需重新整理圖表資料：使用[ReadWorkbookStream](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/readworkbookstream/)保留內嵌工作簿，然後以[WriteWorkbookStream](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/writeworkbookstream/)重新載入。若要包含所有儲存格，亦須使用[SetRange](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/setrange/)還原完整範圍，包含被隱藏的二月類別。僅變更旗標不足以刷新此範例的快取圖表資料與類別標籤。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // 從內嵌工作簿重新整理圖表資料。
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // 還原完整來源範圍，包括隱藏的類別。
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

此範例將 `hidden_cells_True.pptx` 儲存為僅包含可見零售值 (10 與 20) 的檔案，將 `hidden_cells_False.pptx` 儲存為包含全部六個值的檔案。下方圖片是重新開啟保存後的投影片渲染結果；兩個檔案皆保留其指派的繪製設定。第 3 列與 C 欄在兩個內嵌工作簿中仍保持隱藏。

| 僅可見儲存格 (`true`) | 所有儲存格 (`false`) |
| --- | --- |
| ![僅可見儲存格：一月與三月的零售值 10 與 20。](hidden_cells_True.png) | ![所有儲存格：一月、二月與三月的零售與批發值。](hidden_cells_False.png) |

隱藏且包含值的儲存格與空儲存格不同。[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/displayblanksas/) 控制遺失值的顯示方式，並不會包含或排除隱藏的來源資料。請參閱[控制空儲存格的顯示](/slides/zh-hant/net/chart-series/#control-the-display-of-empty-cells)取得範例。

## **從工作簿讀寫圖表資料**

Aspose.Slides for .NET 提供[ReadWorkbookStream](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/readworkbookstream/)與[WriteWorkbookStream](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/writeworkbookstream/) 方法，允許您讀寫圖表資料工作簿（包含透過 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同方式組織，或結構需類似於來源。

此範例開啟 `chart.pptx`（必須在第一張投影片的第一個圖形是圖表），將內嵌工作簿讀入串流、清除現有系列與類別，並將相同工作簿寫回。變更停留於記憶體中；範例不會儲存投影片。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **在修改工作簿後驗證圖表版面配置**

當您以已修改的工作簿取代內嵌工作簿時，圖表仍保留原始的系列與類別集合。此不匹配可能導致[IChart.ValidateChartLayout](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/validatechartlayout/) 因索引超出範圍而失敗。寫回更新的工作簿前請先清除現有系列與類別。本例需要 `chart.pptx`，其中第一張投影片的第一個圖形為圖表。註解標示了工作簿編輯的地方；可執行的範例寫回原始工作簿並在記憶體中驗證版面配置。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // 在此修改工作簿串流，例如使用 Aspose.Cells。

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

清除集合可在寫回工作簿前移除過時的資料參考。更新工作簿之前，請重新建構任何必要的系列與類別映射。

## **將工作簿儲存格設定為圖表資料標籤**

您可以使用工作簿儲存格的文字作為圖表資料標籤。以下步驟示範如何在氣泡圖中將標籤連結至資料工作簿的儲存格。

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/)類別的實例。  
2. 以零基索引存取第一張投影片。  
3. 新增預設資料的氣泡圖。  
4. 存取圖表系列。  
5. 設定工作簿儲存格為資料標籤。  
6. 儲存投影片。

此範例開啟 `chart2.pptx`（必須至少有一張投影片），並新增一個預設資料的氣泡圖。它使用工作表 0 的 A10:A12 作為第一系列前三個標籤，啟用從儲存格取得標籤，最後將結果儲存為 `resultchart.pptx`。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **管理工作表**

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/worksheets/) 屬性提供對圖表工作簿中工作表的存取。本範例建立一個預設資料的圓餅圖，並將每個工作表名稱輸出到主控台。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **指定資料來源類型**

本範例建立一個預設資料的 3D 柱狀圖，並使用不同的資料來源設定兩個系列名稱。第一個名稱使用字串常值；第二個名稱使用工作表 0 中的儲存格 C1。[DataSourceType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/datasourcetype/) 列舉用於為每個名稱選擇來源。結果儲存為 `pres.pptx`。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **偵測不支援的內嵌工作簿格式**

Aspose.Slides 不支援可嵌入某些圖表的 Excel 二進位工作簿（.xlsb）格式。您可以使用[IChartData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/) 上的[EmbeddedWorkbookType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/)屬性，結合[WorkbookType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/workbooktype/)列舉，以偵測不支援的格式並略過那些圖表。本例檢查 `sample.pptx` 的第一張投影片上的形狀，跳過非圖表形狀，並為每個含有內嵌 .xlsb 工作簿的圖表輸出診斷訊息。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // 在此讀取或修改受支援的圖表工作簿資料。
}
```

## **外部工作簿**

Aspose.Slides 支援使用外部工作簿作為圖表的資料來源。

### **建立外部工作簿**

使用[ReadWorkbookStream](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/readworkbookstream/)與[SetExternalWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/setexternalworkbook/)將內嵌圖表工作簿匯出為檔案，並將圖表連結至該外部工作簿。

此範例建立一個預設資料的圓餅圖，將其工作簿寫入 `externalWorkbook1.xlsx`，然後在指派檔案為圖表資料來源前關閉輸出串流。最後將已連結的投影片儲存為 `externalWorkbook.pptx`。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **設定外部工作簿**

使用[SetExternalWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/setexternalworkbook/) 方法，您可以將外部工作簿指派給圖表作為資料來源。此方法亦可用於更新外部工作簿的路徑（若工作簿已移動）。

雖然無法直接編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此範例需要工作目錄中已有 `externalWorkbook.xlsx`。其工作表 `Sheet1` 必須在 B1 放置系列名稱、A2:A4 放置類別名稱，且在 B2:B4 放置數值。範例建立圓餅圖、連結工作簿，並使用[SetRange](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/setrange/) 將 A1:B4 映射為一個系列和三個類別。結果儲存為 `Presentation_with_externalWorkbook.pptx`。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

`SetExternalWorkbook` 的 `updateChartData` 參數控制是否載入工作簿。

* 當 `updateChartData` 為 `false` 時，僅更新工作簿路徑。圖表資料不會從目標工作簿載入或更新，因而工作簿可以不存在。  
* 當 `updateChartData` 為 `true` 時，圖表資料會從目標工作簿更新。

以下範例將占位 URL 指派給 `updateChartData` 為 `false` 的情況。它保留圓餅圖的預設資料，且在未載入不可用工作簿的情況下儲存投影片。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **取得圖表外部資料來源工作簿路徑**

若要識別連結至圖表的工作簿，首先檢查圖表是否使用外部資料來源。若是，請依照以下步驟取得工作簿路徑。

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/)類別的實例。  
2. 以零基索引存取第一張投影片。  
3. 確認第一個圖形是圖表。  
4. 讀取圖表的資料來源類型。  
5. 若來源為外部工作簿，讀取其路徑。

此範例開啟先前建立的 `externalWorkbook.pptx`，檢查第一張投影片的第一個圖形。若它是連結至外部工作簿的圖表，範例會將[ExternalWorkbookPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/externalworkbookpath/) 輸出至主控台，然後將投影片複製儲存為 `Result.pptx`。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **編輯圖表資料**

您可以像編輯內部工作簿內容一樣編輯外部工作簿的資料。若無法載入外部工作簿，將拋出例外。

此範例需要 `presentation.pptx`（第一張投影片的第一個圖形為圖表）以及可存取的外部工作簿。它將第一系列第一個資料點的儲存格值設為 100，並將投影片儲存為 `presentation_out.pptx`。編輯儲存格值會更新連結的外部 XLSX 檔案，若需保留原始工作簿，請使用副本。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **從圖表快取還原工作簿**

如果圖表使用的外部工作簿遺失或不可用，Aspose.Slides 可從投影片快取的資料重建圖表工作簿。建立[LoadOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/)，設定其[SpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/spreadsheetoptions/)，並在開啟投影片前將[ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) 設為 `true`。

以下 C# 範例開啟 `presentation.pptx`（第一張投影片的第一個圖形必須是參考不可用外部工作簿的圖表），並透過[IChart.ChartData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/chartdata/) 與[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/chartdataworkbook/) 取得還原的資料：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // 在此讀取或修改還原的工作簿資料。
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

如果外部工作簿不可用且未啟用還原，Aspose.Slides 會拋出[InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)。僅在使用快取圖表資料為可接受的備援方案時才啟用還原，因為快取可能不包含外部工作簿在投影片最後一次更新後所做的變更。

## **常見問題**

**我能否判斷特定圖表是連結到外部工作簿還是內嵌工作簿？**

可以。圖表具有[資料來源類型](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/datasourcetype/)與[外部工作簿路徑](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/externalworkbookpath/)，若來源是外部工作簿，您即可讀取完整路徑以確認使用了外部檔案。

**是否支援相對路徑的外部工作簿，且它們如何被儲存？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。投影片會在 PPTX 檔案中儲存絕對路徑，搬移工作簿時可能需要更新連結。

**我可以使用位於網路資源/共享資料夾的工作簿嗎？**

可以，這類工作簿可作為外部資料來源。但無法直接從 Aspose.Slides 編輯遠端工作簿——只能作為來源使用。

**Aspose.Slides 在儲存投影片時會覆寫外部 XLSX 嗎？**

投影片會儲存指向外部檔案的[連結](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/externalworkbookpath/)。編輯由儲存格支援的圖表資料也可能會更新連結的本機 XLSX 檔案。若原始檔案必須保持不變，請使用其副本。

**若外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 連結時不接受密碼。常見做法是事先移除保護，或先產生已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/net/)），再連結該副本。

**是否允許多個圖表參考同一個外部工作簿？**

可以。每個圖表都會儲存自己的連結。若它們指向同一檔案，更新該檔案後，下次載入資料時所有圖表皆會反映變更。