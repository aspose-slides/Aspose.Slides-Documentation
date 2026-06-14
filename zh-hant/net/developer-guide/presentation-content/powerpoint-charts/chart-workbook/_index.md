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
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "探索 Aspose.Slides for .NET：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表活頁簿，提升簡報資料的效率。"
---
## **概述**

本文說明了如何在 Aspose.Slides 中使用圖表活頁簿。它展示了如何透過活頁簿串流讀寫圖表資料、將活頁簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

此外，本文還涵蓋了將外部活頁簿作為圖表資料來源的使用方式。範例說明了如何建立並指派外部活頁簿、取得連結至圖表的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

## **從活頁簿讀寫圖表資料**
Aspose.Slides 提供了 [ReadWorkbookStream](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/readworkbookstream/) 與 [WriteWorkbookStream](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/writeworkbookstream/) 方法，讓您能讀寫圖表資料活頁簿（其中的圖表資料可由 Aspose.Cells 編輯）。**注意**圖表資料必須以相同的方式組織，或必須具備與來源相似的結構。

以下 C# 程式碼示範了一個範例操作：

```c#
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

## **將活頁簿儲存格設為圖表資料標籤**
1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 新增一個氣泡圖並加入一些資料。  
4. 取得圖表系列。  
5. 將活頁簿儲存格設為資料標籤。  
6. 儲存簡報。

以下 C# 程式碼示範如何將活頁簿儲存格設為圖表資料標籤：

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// 實例化表示簡報檔案的 Presentation 類別 

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

以下 C# 程式碼示範了使用 [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) 屬性存取工作表集合的操作：

``` csharp
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

## **偵測不支援的內嵌活頁簿格式**

Aspose.Slides 不支援可以嵌入於某些圖表中的 Excel 二進位活頁簿（.xlsb）格式。您可以在 [IChartData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdata/) 上使用 `EmbeddedWorkbookType` 屬性，搭配 [WorkbookType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/workbooktype/) 列舉，以偵測不支援的格式並跳過這些圖表。

```csharp
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
            // 嵌入式活頁簿為 .xlsb 格式，未受支援。
            continue;
        }

        // 在此讀取或修改圖表活頁簿資料。
    }
}
```

## **外部活頁簿**

{{% alert color="primary" %}}  
在 [Aspose.Slides 19.4](https://docs.aspose.com/slides/zh-hant/net/aspose-slides-for-net-19-4-release-notes/) 中，我們實作了對外部活頁簿作為圖表資料來源的支援。  
{{% /alert %}}  

### **建立外部活頁簿**
使用 **`ReadWorkbookStream`** 與 **`SetExternalWorkbook`** 方法，您可以從頭建立外部活頁簿，或將內部活頁簿轉為外部活頁簿。

以下 C# 程式碼示範外部活頁簿的建立過程：

```c#
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

### **設定外部活頁簿**
使用 **`SetExternalWorkbook`** 方法，您可以將外部活頁簿指派給圖表作為資料來源。此方法亦可用於更新外部活頁簿的路徑（如果該活頁簿已被移動）。

雖然無法編輯儲存在遠端位置或資源中的活頁簿資料，但仍可將此類活頁簿作為外部資料來源使用。若提供相對路徑，系統會自動將其轉換為完整路徑。

以下 C# 程式碼示範如何設定外部活頁簿：

```c#
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

在 `SetExternalWorkbook` 方法的 `ChartData` 參數下，用於指定是否載入 Excel 活頁簿。

* 當 `ChartData` 設為 `false` 時，僅會更新活頁簿路徑——圖表資料不會從目標活頁簿載入或更新。當目標活頁簿不存在或無法取得時，可使用此設定。  
* 當 `ChartData` 設為 `true` 時，圖表資料會從目標活頁簿更新。

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **取得圖表的外部資料來源活頁簿路徑**

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 建立圖表形狀的物件。  
4. 建立代表圖表資料來源的 `ChartDataSourceType` 物件。  
5. 根據來源類型與外部活頁簿資料來源類型相同的條件，指定相關條件。

以下 C# 程式碼示範此操作：

```c#
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

您可以以與編輯內部活頁簿相同的方式編輯外部活頁簿中的資料。當無法載入外部活頁簿時，系統會拋出例外。

以下 C# 程式碼實作了上述流程：

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**我可以判斷特定圖表是連結到外部活頁簿還是內嵌活頁簿嗎？**

可以。圖表具有 [資料來源類型](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/datasourcetype/) 與 [外部活頁簿路徑](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/externalworkbookpath/)；若來源是外部活頁簿，您可以讀取完整路徑，以確認使用的是外部檔案。

**是否支援外部活頁簿的相對路徑，且它們如何儲存？**

支援。若您指定相對路徑，系統會自動將其轉換為絕對路徑。這對於專案可移植性很方便；但請注意，簡報會將絕對路徑儲存在 PPTX 檔案中。

**可以使用位於網路資源/共享資料夾的活頁簿嗎？**

可以，這類活頁簿可作為外部資料來源。然而，Aspose.Slides 不支援直接編輯遠端活頁簿——只能將其作為來源使用。

**保存簡報時，Aspose.Slides 會覆寫外部 XLSX 檔案嗎？**

不會。簡報僅儲存一個指向外部檔案的 [連結](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/externalworkbookpath/)，用於讀取資料。保存簡報時不會修改外部檔案本身。

**如果外部檔案受密碼保護，該怎麼辦？**

Aspose.Slides 在連結時不接受密碼。常見的做法是事先移除保護，或先製作一份已解密的副本（例如使用 [Aspose.Cells](/cells/net/)），再連結至該副本。

**多個圖表可以參照同一個外部活頁簿嗎？**

可以。每個圖表都會儲存自己的連結。若它們指向同一個檔案，更新該檔案後，下次載入資料時所有圖表都會顯示最新內容。