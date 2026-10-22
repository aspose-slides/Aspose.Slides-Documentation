---
title: 管理 .NET 簡報中的圖表活頁簿
linktitle: 圖表活頁簿
type: docs
weight: 70
url: /zh-hant/net/chart-workbook/
keywords:
- 圖表活頁簿
- 圖表資料
- 活頁簿儲存格
- 資料標籤
- 工作表
- 資料來源
- 外部活頁簿
- 外部資料
- 圖表快取
- 活頁簿復原
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET：輕鬆管理 PowerPoint 與 OpenDocument 格式的圖表活頁簿，以簡化您的簡報資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿。它展示了如何透過活頁簿串流讀寫圖表資料、使用活頁簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

它同時涵蓋了將外部活頁簿作為圖表資料來源的使用方式。範例示範了如何建立並指派外部活頁簿、取得連結至圖表的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

若活頁簿儲存格代表遺失的資料，請參閱 [Control the Display of Empty Cells](/slides/zh-hant/net/chart-series/) 以了解空儲存格與零值的差異，並查看可用顯示模式的折線圖比較。

## **將隱藏列和欄的資料納入圖表**

使用 [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) 來控制圖表是否僅繪製來自可見工作表列與欄的資料。將其設為 `true` 只繪製可見儲存格，設為 `false` 則同時包含可見與隱藏儲存格。此設定僅影響圖表的繪製，並不會隱藏或顯示工作表的列或欄。

[樣本簡報](hidden-source-data.pptx) 的第一張投影片第一個圖形是一個直條圖。內嵌工作表 `Sheet1` 的來源範圍為 `A1:C4`。第 3 列與 C 欄被隱藏，但它們的儲存格仍然有值。

| 工作表列 | A: 月份 | B: 零售 | C: 批發 (隱藏欄) |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3 (隱藏列) | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過 [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) 取得來源儲存格，並讀取 [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) 以檢查其隱藏狀態。此屬性為唯讀。在此檔案中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別會印出 `False`、`True`、`True`。

對於此範例，在變更繪製設定後需重新整理圖表資料：使用 [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) 保留內嵌活頁簿，然後以 [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) 重新載入。若要納入所有儲存格，亦需使用 [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) 以復原完整範圍，包含隱藏的二月類別。僅變更旗標不足以刷新此樣本的快取圖表資料與類別標籤。

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

        // 從嵌入的活頁簿重新整理圖表資料。
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // 復原完整的來源範圍，包括隱藏的類別。
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

此範例會儲存兩個版本的簡報：一個僅包含可見的零售值 (10 與 20)，另一個則包含全部六個值。下方圖片是重新開啟儲存後的簡報渲染結果；兩個檔案皆保留其設定的繪製方式。第 3 列與 C 欄在兩個內嵌活頁簿中仍保持隱藏。

| 僅可見儲存格 (`true`) | 所有儲存格 (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

隱藏且含有值的儲存格不同於空儲存格。[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) 控制遺失值的顯示方式，並不會包含或排除隱藏的來源資料。請參閱 [Control the Display of Empty Cells](/slides/zh-hant/net/chart-series/#control-the-display-of-empty-cells) 取得範例。

## **取得圖表的資料範圍**

在既有簡報中更新活頁簿資料之前，應先檢查來源範圍，以確認每個圖表使用了哪些工作表儲存格。[IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) 方法會回傳目前的資料範圍（工作表限定的公式），例如 `Sheet1!$A$1:$D$5`。此處 `Sheet1` 為工作表名稱，`!` 用於分隔工作表名稱與儲存格範圍，`$A$1:$D$5` 表示從 A1 到 D5（含） 的儲存格。美元符號表示絕對列與欄的參照。

此方法僅讀取目前範圍而不變更圖表或其活頁簿。若圖表未使用活頁簿作為資料來源，會拋出 [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)。更多資訊請參閱 [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/)。

此範例會開啟簡報，直接檢查每張投影片上的圖形是否為圖表，並印出每個圖表的名稱與來源範圍。若圖表未使用活頁簿，則印出訊息並繼續處理下一個圖表。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **從活頁簿讀寫圖表資料**

Aspose.Slides for .NET 提供 [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) 與 [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) 方法，讓您能讀取與寫入圖表資料活頁簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同方式組織，或具有類似的結構。

此範例使用第一張投影片第一個圖形的圖表。它將內嵌活頁簿讀入串流、清除既有序列與類別，然後將相同的活頁簿寫回。變更僅保留在記憶體中，範例不會儲存簡報。

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

### **在活頁簿變更後驗證圖表版面配置**

當您以修改過的活頁簿取代內嵌活頁簿時，圖表仍保留原始的序列與類別集合。此不匹配可能導致 [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) 因索引超出範圍而失敗。請在寫回更新後的活頁簿之前，先清除既有的序列與類別。本範例使用第一張投影片第一個圖形的圖表。註解標示了活頁簿編輯可能發生的位置；可執行範例會寫回原始活頁簿並在記憶體中驗證版面配置。

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

    // 在此修改活頁簿串流，例如使用 Aspose.Cells。

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

清除集合可在寫回活頁簿前移除過時的資料參照。請在使用圖表之前，為更新的活頁簿重新建立必要的序列與類別對映。

## **為活頁簿儲存格設定自訂數字格式**

使用 [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) 來控制數值在圖表內嵌活頁簿中的顯示方式。例如，報表可能需要將轉換率以四位小數的百分比顯示，將係數以五位小數顯示。請保留兩個值皆為數值，以便在計算與圖表繪製時仍可使用。

數字格式僅影響顯示，不會改變儲存的值。格式 `0.0000%` 會將 `0.125` 顯示為 `12.5000%`，但不會把儲存的數字改成 `12.5`。同理，`0.00000` 會將 `0.1234567` 顯示為 `0.12346`，而不會四捨五入儲存值。若自訂格式為空字串 (`""`)，則改用 [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/)。

以下範例建立一個直條圖，並透過 [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) 取得其儲存格。在工作表 0 中，B2 含轉換率，C2 含係數。兩個儲存格皆提供圖表值。範例同時啟用與來源格式相關聯的數值標籤。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

活頁簿儲存格的格式與直接設定在圖表軸或資料標籤上的格式是分開的。在此範例中，每個標籤皆因啟用了 [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) 而顯示來源儲存格的值，且因 [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) 為 `true`，遵循來源的數字格式。儲存並重新開啟簡報後，標籤分別顯示 `12.5000%` 與 `0.12346`，如下圖所示。垂直軸則使用自己的 [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00`，且 [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) 為 `false`。

若要獨立格式化資料標籤，請將其來源連結旗標設為 `false`，並指定其 [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/)。此操作不會改變活頁簿儲存格的格式。例如，獨立的標籤格式 `0.00` 會將第一個值顯示為 `0.13`，而 B2 仍顯示 `12.5000%`。詳情請參閱 [Chart Data Labels](/slides/zh-hant/net/chart-data-label/#set-percentage-sign-with-chart-data-labels)。

以下圖示為重新開啟儲存簡報後的渲染結果：

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **將活頁簿儲存格設定為圖表資料標籤**

您可以使用活頁簿儲存格中的文字作為圖表資料標籤。

此範例在既有簡報的第一張投影片加入一個預設資料的泡泡圖，使用工作表 0 的 A10:A12 作為第一系列前三個標籤，啟用來自儲存格的標籤，並儲存更新後的簡報。

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

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) 屬性提供對圖表活頁簿中工作表的存取。本範例建立一個預設資料的圓餅圖，並將每個工作表名稱印出至主控台。

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

序列點的值也可以直接以數值常量形式儲存。請參閱 [Set Series Values Using Numeric Literals](/slides/zh-hant/net/chart-series/#set-series-values-using-numeric-literals) 取得完整範例，說明如何儲存與讀取它們。點值的來源類型與圖表的內部或外部活頁簿設定是分開的；使用數值常量本身不會移除內嵌活頁簿。

此範例建立一個預設資料的 3D 直條圖，並使用不同的資料來源設定兩個序列名稱。第一個名稱使用字串常量；第二個名稱使用工作表 0 的儲存格 C1。[DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) 列舉用來為每個名稱選擇來源。範例會儲存包含更新後序列名稱的簡報。

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

## **偵測不支援的內嵌活頁簿格式**

Aspose.Slides 不支援可在某些圖表中內嵌的 Excel 二進位活頁簿 (.xlsb) 格式。您可以使用 [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) 上的 [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) 屬性，搭配 [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) 列舉，偵測不支援的格式並跳過這些圖表。本範例檢查既有簡報第一張投影片上的圖形，跳過非圖表圖形，並為每個含有 .xlsb 內嵌活頁簿的圖表印出診斷訊息。

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

    // 在此讀取或修改受支援的圖表活頁簿資料。
}
```

## **外部活頁簿**

Aspose.Slides 支援使用外部活頁簿作為圖表的資料來源。

### **建立外部活頁簿**

使用 [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) 與 [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) 將內嵌圖表活頁簿匯出為檔案，並將圖表連結至該外部活頁簿。

此範例建立一個預設資料的圓餅圖，並匯出其活頁簿。將外部活頁簿指派為圖表資料來源前，會先關閉輸出串流，最後儲存已連結的簡報。

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

### **指派外部活頁簿**

透過 [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) 方法，您可以將外部活頁簿指派給圖表作為資料來源。此方法也可用於更新外部活頁簿的路徑（若檔案已移動）。

雖然無法編輯儲存在遠端位置或資源中的活頁簿資料，但仍可將此類活頁簿作為外部資料來源使用。若提供相對路徑，系統會自動轉換為完整路徑。

此範例使用一個外部活頁簿，其工作表 `Sheet1` 包含 B1 的序列名稱、A2:A4 的類別名稱，以及 B2:B4 的數值。範例建立圓餅圖、連結活頁簿，並使用 [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) 將 A1:B4 對映為一個序列與三個類別。最後儲存帶有連結圖表的簡報。

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

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) 的 `updateChartData` 參數控制是否載入活頁簿。

* 當 `updateChartData` 為 `false` 時，僅更新活頁簿路徑。圖表資料不會從目標活頁簿載入或更新，因而即使活頁簿無法取得也不會出錯。
* 當 `updateChartData` 為 `true` 時，圖表資料會從目標活頁簿更新。

以下範例將占位 URL 指派給 `updateChartData` 為 `false` 的情況。它保留圓餅圖的預設資料，並在未載入不可用的活頁簿情況下儲存簡報。

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

### **取得圖表的外部資料來源活頁簿路徑**

若要辨識連結至圖表的活頁簿，請檢查圖表是否使用外部資料來源，並取得其活頁簿路徑。

此範例檢查簡報第一張投影片的第一個圖形是否為連結至外部活頁簿的圖表，若是則印出 [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) 至主控台，並儲存簡報的副本。

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

您可以以與編輯內部活頁簿相同的方式編輯外部活頁簿的資料。若無法載入外部活頁簿，將拋出例外。

此範例使用第一張投影片第一個圖形的圖表，且已連結至可存取的外部活頁簿。它將第一系列第一個資料點的儲存格值設為 100，並儲存更新後的簡報。編輯儲存格值會更新連結的外部 XLSX 檔案，若需保留原始活頁簿，請使用副本。

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

### **從圖表快取復原活頁簿**

如果圖表使用的外部活頁簿遺失或無法取得，Aspose.Slides 可以從簡報快取的資料重建圖表活頁簿。請建立 [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)，設定其 [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/)，並在開啟簡報前將 [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) 設為 `true`。

以下 C# 範例復原第一張投影片第一個圖形的圖表之活頁簿資料，該圖表參照一個不可用的外部活頁簿。它透過 [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) 與 [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) 取得復原後的資料：

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

    // 在此讀取或修改復原的活頁簿資料。
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

若外部活頁簿不可用且未啟用復原，Aspose.Slides 會拋出 [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)。僅在使用快取圖表資料是可接受的備援方案時才啟用復原，因為快取可能不包含外部活頁簿在最後一次更新簡報後所做的變更。

## **常見問題**

**我可以判斷特定圖表是連結至外部還是內嵌活頁簿嗎？**

可以。圖表具有 [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) 與 [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/)；若來源為外部活頁簿，您即可讀取完整路徑以確認使用了外部檔案。

**是否支援相對路徑的外部活頁簿，且它們如何儲存？**

支援。若您指定相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，搬移活頁簿時可能需要更新連結。

**我可以使用位於網路資源/共享資料夾的活頁簿嗎？**

可以，這類活頁簿可作為外部資料來源使用。但 Aspose.Slides 不支援直接編輯遠端活頁簿——只能將其作為來源使用。

**儲存簡報時，Aspose.Slides 會覆寫外部 XLSX 嗎？**

簡報會儲存指向外部檔案的 [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/)。編輯以儲存格為基礎的圖表資料亦會更新連結的本機 XLSX 檔案。若原始活頁簿必須保持不變，請使用其副本。

**若外部檔案受密碼保護該怎麼辦？**

Aspose.Slides 在連結時不接受密碼。常見的做法是事先解除保護，或事先製作已解密的副本（例如使用 [Aspose.Cells](https://reference.aspose.com/cells/net/)），再連結至該副本。

**多個圖表可以參考同一個外部活頁簿嗎？**

可以。每個圖表都會儲存自己的連結。若它們皆指向同一檔案，更新該檔案後，下一次載入資料時所有圖表都會反映變更。