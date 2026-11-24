---
title: 在 .NET 中管理簡報的圖表活頁簿
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
description: "探索 Aspose.Slides for .NET：輕鬆管理 PowerPoint 與 OpenDocument 格式中的圖表活頁簿，簡化您的簡報資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿。它展示了如何透過活頁簿串流讀寫圖表資料、將活頁簿儲存格用作圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

亦說明如何將外部活頁簿作為圖表資料來源。範例示範如何建立並指派外部活頁簿、取得圖表所連結的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

若活頁簿儲存格代表缺失資料，請參閱[控制空儲存格的顯示](/slides/zh-hant/net/chart-series/)以了解空儲存格與零值的差異，以及可用顯示模式的折線圖比較。

## **包含隱藏的行與列資料**

使用[IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/)控制圖表是否繪製隱藏工作表行與列的資料。將其設為 `true` 只繪製可見儲存格，或設為 `false` 同時包含可見與隱藏儲存格。此設定僅控制圖表繪製；不會隱藏或取消隱藏工作表的行或列。

[範例簡報](hidden-source-data.pptx)的第一張投影片第一個形狀是一個直條圖。嵌入的工作表 `Sheet1` 包含以下來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍含有值。

| 工作表列 | A: 月份 | B: 零售 | C: 批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3 (隱藏列) | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/)存取來源儲存格，並讀取[IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/)以檢查其隱藏狀態。此屬性唯讀。在此檔案中，B2 可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別輸出 `False`、`True`、`True`。

對此範例，在變更繪製設定後請重新整理圖表資料：使用[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/)保留嵌入的活頁簿，並以[WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/)重新載入。若要包含所有儲存格，亦請使用[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/)還原完整範圍，包含隱藏的二月類別。僅變更旗標不足以重新整理此範例的快取圖表資料與類別標籤。

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
            // 復原完整的來源範圍，包含隱藏的類別。
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

此範例會儲存兩個版本的簡報：一個僅含可見的零售值 (10 與 20)，另一個則包含全部六個值。以下圖像是重新開啟儲存後的簡報渲染結果；兩個檔案皆保留其指派的繪製設定。第 3 列與 C 欄在兩個嵌入活頁簿中仍保留隱藏狀態。

| 僅可見儲存格 (`true`) | 所有儲存格 (`false`) |
| --- | --- |
| ![僅可見儲存格：一月與三月的零售值 10 與 20。](hidden_cells_True.png) | ![所有儲存格：一月、二月、三月的零售與批發值。](hidden_cells_False.png) |

包含值的隱藏儲存格不同於空儲存格。[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/)控制缺失值的顯示方式；它不會包含或排除隱藏的來源資料。請參閱[控制空儲存格的顯示](/slides/zh-hant/net/chart-series/#control-the-display-of-empty-cells)取得範例。

## **取得圖表的資料範圍**

在更新現有簡報中的活頁簿資料之前，先檢查來源範圍以辨識每個圖表使用的工作表儲存格。[IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/)方法會傳回目前的資料範圍，格式為工作表限定的公式，例如 `Sheet1!$A$1:$D$5`。其中 `Sheet1` 為工作表名稱，`!` 為分隔符，`$A$1:$D$5` 表示包含 A1 到 D5 的儲存格。美元符號表示絕對行列參照。

此方法僅讀取目前範圍，不會變更圖表或其活頁簿。若圖表未使用活頁簿作為資料來源，會拋出[InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)。更多資訊請參閱[ChartData API 參考](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/)。

此範例開啟簡報，檢查每張投影片上的圖表形狀，列印每個圖表的名稱與來源範圍。若圖表未使用活頁簿，會列印訊息並繼續處理下一個圖表。

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

Aspose.Slides for .NET 提供[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/)與[WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/)方法，讓您讀寫圖表活頁簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同方式組織，或具備類似於來源的結構。

此範例使用第一張投影片第一個形狀的圖表簡報。它將嵌入的活頁簿讀入串流，清除既有系列與類別，然後將相同的活頁簿寫回。變更保留於記憶體中；範例不會儲存簡報。

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

### **在活頁簿修改後驗證圖表版面配置**

當您以修改過的活頁簿取代嵌入的活頁簿時，圖表仍保留原有的系列與類別集合。此不匹配可能導致[IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/)因索引超出範圍錯誤而失敗。請在將更新的活頁簿寫回圖表之前先清除既有系列與類別。此範例使用第一張投影片第一個形狀的圖表。註解標示了活頁簿編輯會發生的位置；可執行的範例將原始活頁簿寫回，並在記憶體中驗證版面配置。

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

    // 在此修改活頁簿串流，例如使用 Aspose.Cells.

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

清除集合可在寫回活頁簿前移除過期的資料參照。請在使用圖表前，為更新的活頁簿重新建構任何必要的系列與類別對映。

## **選擇類別標籤的儲存方式**

在加入標籤之前，於空的類別集合上設定[IChartCategoryCollection.UseCells](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorycollection/usecells/)。若標籤參考活頁簿資料或形成階層（例如按年度分組的季別），請使用工作表儲存格。若僅需單層且不需要儲存格參照的文字標籤，請使用字串常值。此設定僅套用於類別。以下兩個圖表皆使用工作表儲存格作為數值系列。

此範例建立兩個直條圖，並為每個圖表列印 `Q1 Q2 Q3 Q4` 以及其儲存模式。對於以工作表支援的標籤，[IChartCategory.AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/ascell/)可取得底層儲存格，而[IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/)則回傳其標籤。對於字面標籤，則直接從[IChartCategory.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/value/)讀取字串。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

foreach (var useCells in new[] { true, false })
{
    var x = useCells ? 20 : 360;
    var chart = shapes.AddChart(ChartType.ClusteredColumn, x, 20, 320, 250);
    var data = chart.ChartData;
    data.Series.Clear();
    data.Categories.Clear();
    data.Categories.UseCells = useCells;

    var workbook = data.ChartDataWorkbook;
    var seriesName = workbook.GetCell(0, 0, 1, "Sales");
    var series = data.Series.Add(seriesName, chart.Type);
    for (var row = 1; row <= 4; row++)
    {
        var label = $"Q{row}";
        if (useCells)
        {
            var labelCell = workbook.GetCell(0, row, 0, label);
            data.Categories.Add(labelCell);
        }
        else
        {
            data.Categories.Add(label);
        }

        var valueCell = workbook.GetCell(0, row, 1, row * 10);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    Console.Write($"UseCells = {data.Categories.UseCells}:");
    foreach (var category in data.Categories)
    {
        var label = data.Categories.UseCells ? category.AsCell.Value : category.Value;
        Console.Write($" {label}");
    }
    Console.WriteLine();
}

presentation.Save("category-labels.pptx", SaveFormat.Pptx);
```

## **為活頁簿儲存格設定自訂數字格式**

使用[ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/)控制數值在圖表嵌入活頁簿中的顯示方式。例如，報表可能需要以四位小數的百分比顯示轉換率，並以五位小數的係數顯示。請保持兩個值皆為數字，以便於計算與圖表繪製。

數字格式僅改變顯示，不會改變儲存的值。格式 `0.0000%` 會將 `0.125` 顯示為 `12.5000%`，但不會把儲存的數字改為 `12.5`。同理，`0.00000` 會將 `0.1234567` 顯示為 `0.12346`，而不會四捨五入儲存值。若自訂格式為空字串 (`""`)，則改用[PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/)。

以下範例建立一個直條圖，並透過[ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/)存取其儲存格。第 0 張工作表的 B2 包含轉換率，C2 包含係數。兩個儲存格皆提供圖表值。範例也啟用與來源格式連結的數值標籤。

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

活頁簿儲存格格式與直接在圖表軸或資料標籤上設定的格式分開。在此範例中，每個標籤皆顯示其來源儲存格的值，因為[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/)已啟用，且[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) 為 `true`。重新儲存並重新開啟簡報後，標籤顯示 `12.5000%` 與 `0.12346`，如下所示。縱軸使用自己的[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00`，且[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) 為 `false`。

若要獨立格式化資料標籤，請將其來源連結旗標設為 `false`，並指定其[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/)。此操作不會變更活頁簿儲存格的格式。例如，獨立的標籤格式 `0.00` 會將第一個值顯示為 `0.13`，而 B2 仍顯示 `12.5000%`。請參閱[圖表資料標籤](/slides/zh-hant/net/chart-data-label/#set-percentage-sign-with-chart-data-labels)取得直接標籤格式化範例。

以下圖像是重新開啟儲存的簡報後渲染的結果：

![具有來源連結標籤顯示 12.5000% 與 0.12346，且縱軸獨立格式化為數字的直條圖。](custom-cell-formats.png)

## **將活頁簿儲存格作為圖表資料標籤**

您可以使用活頁簿儲存格中的文字作為圖表資料標籤。

此範例在既有簡報的第一張投影片加入預設資料的氣泡圖，使用第 0 張工作表的 A10:A12 作為第一系列的前三個標籤，啟用儲存格來源標籤，並儲存更新後的簡報。

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

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/)屬性提供對圖表活頁簿中工作表的存取。本範例建立預設資料的圓餅圖，並將每個工作表名稱寫入主控台。

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

系列點的值也可以直接以數字常值儲存。請參閱[使用數字常值設定系列值](/slides/zh-hant/net/chart-series/#set-series-values-using-numeric-literals)取得完整範例，說明如何儲存與讀取它們。點值的來源類型與圖表的內部或外部活頁簿設定分離；使用數字常值本身不會移除嵌入的活頁簿。

此範例建立一個預設資料的 3D 直條圖，並使用不同的資料來源設定兩個系列名稱。第一個名稱使用字串常值；第二個名稱使用第 0 張工作表的 C1 儲存格。[DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) 列舉選擇每個名稱的來源。範例儲存更新後的系列名稱。

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

## **偵測不支援的嵌入活頁簿格式**

Aspose.Slides 不支援可嵌入某些圖表的 Excel 二進位活頁簿（.xlsb）格式。您可以使用[IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) 的[EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/)屬性，搭配[WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) 列舉，偵測不支援的格式並跳過那些圖表。此範例檢查既有簡報第一張投影片上的形狀，跳過非圖表形狀，並為每個嵌入 .xlsb 活頁簿的圖表列印診斷訊息。

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

Aspose.Slides 支援將外部活頁簿作為圖表的資料來源。

### **建立外部活頁簿**

使用[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/)與[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/)將嵌入圖表的活頁簿匯出為檔案，並將圖表連結至該外部活頁簿。

此範例建立預設資料的圓餅圖，並匯出其活頁簿。於指派外部活頁簿為圖表資料來源之前，先關閉輸出串流，然後儲存已連結的簡報。

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

### **設定外部活頁簿**

使用[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/)方法，您可以將外部活頁簿指派給圖表作為資料來源。此方法亦可用於更新外部活頁簿的路徑（若已搬移）。

雖然無法編輯儲存在遠端位置或資源中的活頁簿資料，但仍可將此類活頁簿作為外部資料來源使用。若提供相對路徑，系統會自動轉換為完整路徑。

此範例使用一個外部活頁簿，其工作表 `Sheet1` 包含 B1 的系列名稱、A2:A4 的類別名稱，以及 B2:B4 的數值。範例建立圓餅圖，連結活頁簿，並使用[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/)將 A1:B4 對映至一個系列與三個類別。最後儲存已連結圖表的簡報。

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

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) 的 `updateChartData` 參數決定是否載入活頁簿。

* 當 `updateChartData` 為 `false` 時，僅更新活頁簿路徑。圖表資料不會從目標活頁簿載入或更新，因此活頁簿可以不存在。
* 當 `updateChartData` 為 `true` 時，圖表資料會從目標活頁簿更新。

以下範例將佔位符 URL 指派給 `updateChartData` 為 `false`。它保留圓餅圖的預設資料，且在未載入不可用的活頁簿情況下儲存簡報。

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

若要辨識圖表所連結的活頁簿，請先檢查圖表是否使用外部資料來源，然後取得其活頁簿路徑。

此範例檢查簡報第一張投影片的第一個形狀是否為連結外部活頁簿的圖表。若是，則將[ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/)寫入主控台，並儲存簡報的副本。

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

您可以像編輯內部活頁簿內容一樣編輯外部活頁簿的資料。若外部活頁簿無法載入，會拋出例外。

此範例使用第一張投影片第一個形狀的圖表，且該圖表已連結至可存取的外部活頁簿。它將第一系列第一個資料點的儲存格值設為 100，並儲存更新後的簡報。編輯儲存格值會更新連結的外部 XLSX 檔案，若需保留原始活頁簿，請使用副本。

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

## **從來源活頁簿重新整理圖表資料**

Aspose.Slides for .NET 26.11 新增[IChartData.RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/)（單一圖表）與[IPresentation.RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/)（整份簡報）。在來源活頁簿值變更後使用它們。外部活頁簿必須可存取且受支援。

使用[Aspose.Slides for .NET](/slides/zh-hant/net/installation/) 26.11 或更新版本，此範例重新整理 `charts.pptx` 第一本投影片的第一個圖表。其來源活頁簿必須可用。將結果儲存以保留更新後的圖表資料。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
var chart = presentation.Slides[0].Shapes.OfType<IChart>().FirstOrDefault();
if (chart == null)
{
    Console.WriteLine("The first slide must contain a chart.");
    return;
}

chart.ChartData.RefreshData();
presentation.Save("refreshed-chart.pptx", SaveFormat.Pptx);
```

若要重新整理所有圖表，請使用獨立的簡報執行個體，如下所示。傳入 `false` 會讓重新整理失敗向呼叫端傳遞例外；已重新整理的圖表不會回滾。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
presentation.RefreshChartsData(skipFailedCharts: false);
presentation.Save("refreshed-charts.pptx", SaveFormat.Pptx);
```

此參數預設為 `true`：[RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) 會跳過失敗的圖表並繼續處理其他圖表。它不會回傳每個圖表的結果，因此完成的呼叫並不保證每張圖表皆成功重新整理。若需辨識每個失敗的圖表，請個別呼叫[RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/)。

重新整理會重新載入來源資料。它與公式計算、圖表版面驗證及 OLE 預覽更新分開。檢查即時的儲存格值以驗證記憶體中的重新整理。除非儲存並重新開啟簡報，否則[CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) 仍會描述先前儲存的圖表。

### **在未載入活頁簿的情況下讀取快取圖表值**

在 .NET 26.11 中，快取值存取器會在未開啟活頁簿的情況下讀取圖表所存儲的值。當連結檔案不可用且只需要圖表最後一次儲存的資料時，它們非常有用。這與以下的復原選項不同。

| 物件 | 快取存取器 |
| --- | --- |
| 普通系列資料點 | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) |
| 散佈圖或氣泡圖資料點 | [CachedXValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedxvalue/), [CachedYValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedyvalue/) |
| 氣泡圖資料點 | [CachedBubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedbubblesize/) |
| 圖表類別 | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/cachedvalue/) |

每個存取器皆回傳[ICachedChartValue](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/)。[Data](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/data/) 公開儲存的物件；[ToString](https://reference.aspose.com/slides/net/aspose.slides.charts/cachedchartvalue/tostring/) 提供文字；[ToDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/todouble/) 在缺少或非數值時回傳 `NaN`。快取可能缺失或過時，包括尚未儲存的全新圖表。請勿假設每個欄位皆存在或包含數字。

此範例從 `cached-chart.pptx`（已儲存且含有圖表的簡報）讀取所有上述欄位。外部活頁簿缺失是允許的，因為程式碼不會存取[ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/)或即時活頁簿儲存格。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("cached-chart.pptx");
foreach (var slide in presentation.Slides)
foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
        continue;

    foreach (var category in chart.ChartData.Categories)
        PrintCache("Category", category.CachedValue);

    foreach (var series in chart.ChartData.Series)
    foreach (var point in series.DataPoints)
    {
        PrintCache("Value", point.CachedValue);
        PrintCache("X", point.CachedXValue);
        PrintCache("Y", point.CachedYValue);
        PrintCache("Bubble size", point.CachedBubbleSize);
    }
}

static void PrintCache(string name, ICachedChartValue value)
{
    var number = value.ToDouble();
    if (value.Data == null)
        Console.WriteLine($"{name}: no cached value");
    else if (double.IsNaN(number))
        Console.WriteLine($"{name}: {value} (not numeric)");
    else
        Console.WriteLine($"{name}: {number}");
}
```

需要即時來源資料時使用重新整理；只需要儲存快照時使用快取讀取。快取不是活頁簿的完整副本，無法提供快取之後的變更。

### **從圖表快取復原活頁簿**

如果圖表使用的外部活頁簿遺失或無法取得，Aspose.Slides 可以從簡報中的快取資料重建圖表活頁簿。建立[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)，設定其[SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/)，並在開啟簡報前將[ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) 設為 `true`。

下列 C# 範例為第一張投影片第一個圖表復原活頁簿資料，該圖表參考遺失的外部活頁簿。它透過[IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) 與[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) 存取復原的資料：

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

如果程式碼在外部活頁簿不可用且未啟用復原時存取該活頁簿，Aspose.Slides 會拋出[InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)。僅在接受使用快取圖表資料作為可接受後備的情況下啟用復原，因為快取可能不包含外部活頁簿在簡報最後一次更新後所做的變更。

## **常見問題集**

**我能否判斷特定圖表是連結到外部活頁簿還是嵌入活頁簿？**

可以。圖表具有[資料來源類型](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/)與[外部活頁簿路徑](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/)。如果來源是外部活頁簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援相對路徑的外部活頁簿，且它們如何儲存？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，搬移活頁簿時可能需要更新連結。

**我可以使用位於網路資源/共享的活頁簿嗎？**

可以，此類活頁簿可作為外部資料來源使用。但 Aspose.Slides 不支援直接編輯遠端活頁簿——只能用作來源。

**Aspose.Slides 會在儲存簡報時覆寫外部 XLSX 嗎？**

簡報會儲存[指向外部檔案的連結](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/)。編輯儲存格來源的圖表資料也可能會更新連結的本機 XLSX 檔案。若必須保留原始活頁簿，請使用副本。

**如果外部檔案設有密碼保護，我該怎麼辦？**

Aspose.Slides 連結時不接受密碼。常見做法是事先解除保護，或使用[Aspose.Cells](https://reference.aspose.com/cells/net/) 產生解密的副本再進行連結。

**多個圖表可以參照同一個外部活頁簿嗎？**

可以。每個圖表都儲存自己的連結。若皆指向同一檔案，更新該檔案後下一次載入資料時會反映在所有圖表上。