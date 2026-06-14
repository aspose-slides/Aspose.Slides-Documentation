---
title: 使用 VSTO 與 Aspose.Slides for .NET 建立圖表
linktitle: 建立圖表
type: docs
weight: 80
url: /zh-hant/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- 建立圖表
- 移植
- VSTO
- Office 自動化
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何在 C# 中自動化 PowerPoint 圖表的建立。此步驟指南說明為何 Aspose.Slides for .NET 是比 Microsoft.Office.Interop 更快、更強大的替代方案。"
---
## **概述**

本文示範如何使用 C# 以程式方式在 Microsoft PowerPoint 簡報中建立與自訂圖表。透過 Aspose.Slides for .NET，您可以自動產生專業的資料驅動圖表，而不需要依賴 Microsoft Office 或 Interop 函式庫。此 API 提供豐富的功能，可建立直條圖、圓餅圖、折線圖等，並能完整控制外觀、資料與佈局。無論是產生報表、儀表板或商務簡報，Aspose.Slides 都能協助您直接從 .NET 應用程式產出高品質視覺化效果。

## **VSTO 範例**

本節示範如何使用 **VSTO (Visual Studio Tools for Office)** 在 Microsoft PowerPoint 簡報中建立圖表。透過 VSTO，您可以結合 PowerPoint 與 Excel 自動化，以程式方式產生與自訂圖表。以下示例說明如何新增 **3D 群組直條圖**、從 Excel 工作表填入資料、調整格式與版面，並儲存最終簡報——全部在 .NET 應用程式中完成。

1. 建立一個 Microsoft PowerPoint 簡報的實例。
1. 為簡報新增一張空白投影片。
1. 新增 3D 群組直條圖並取得其參考。
1. 建立新的 Microsoft Excel 活頁簿實例並載入圖表資料。
1. 使用 Excel 活頁簿實例取得圖表資料工作表。
1. 設定工作表中的圖表範圍，並從圖表中移除系列 2 與 3。
1. 在圖表資料工作表中修改圖表類別資料。
1. 在圖表資料工作表中修改系列 1 的資料。
1. 取得圖表標題並設定其字型相關屬性。
1. 取得圖表的值軸，並設定主要單位、次要單位、最大值與最小值。
1. 取得圖表的深度（系列）軸並將其移除——此範例僅使用一個系列。
1. 設定圖表在 X 與 Y 方向的旋轉角度。
1. 儲存簡報。
1. 關閉 Microsoft Excel 與 PowerPoint 實例。

```c#
EnsurePowerPointIsRunning(true, true);

// Instantiate a slide object.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Access the first presentation slide.
objSlide = objPres.Slides[1];

// Select the first slide and set its layout.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Add a default chart to the slide.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Access the added chart.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Access the chart data.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Create an instance of the Excel workbook to work with the chart data.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Access the data worksheet for the chart.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Set the data range for the chart.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Apply the specified range to the chart data table.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Set values for categories and respective series data.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Set the chart title.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Access the chart value axis.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Set the values for the axis units.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Access the chart depth axis.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Set the chart rotation.
ppChart.Rotation = 20;   // Y-值
ppChart.Elevation = 15;  // X-值
ppChart.RightAngleAxes = false;

// Save the presentation as a PPTX file.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Close the workbook and presentation.
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```

```c#
public static void EnsurePowerPointIsRunning(bool blnAddPresentation)
{
    EnsurePowerPointIsRunning(blnAddPresentation, false);
}

public static void EnsurePowerPointIsRunning()
{
    EnsurePowerPointIsRunning(false, false);
}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)
{
    string strName = null;

    // 嘗試存取 Name 屬性。若拋出例外，則啟動新的 PowerPoint 實例。
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation 用於確保已載入簡報。
    if (blnAddPresentation == true)
    {
        try
        {
            strName = objPres.Name;
        }
        catch (Exception ex)
        {
            objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);
        }
    }

    // blnAddSlide 用於確保簡報中至少有一張投影片。
    if (blnAddSlide)
    {
        try
        {
            strName = objPres.Slides[1].Name;
        }
        catch (Exception ex)
        {
            Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
            Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;
            objCustomLayout = objPres.SlideMaster.CustomLayouts[1];
            objSlide = objPres.Slides.AddSlide(1, objCustomLayout);
            objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;
            objCustomLayout = null;
            objSlide = null;
        }
    }
}
```

結果：

![使用 VSTO 建立的圖表](chart-created-using-VSTO.png)

## **Aspose.Slides for .NET 範例**

以下範例說明如何使用 Aspose.Slides for .NET 在 PowerPoint 簡報中建立簡單圖表。此程式碼示範如何新增 **3D 群組直條圖**、填入範例資料，並自訂外觀。只需幾行程式碼，即可動態產生圖表並將其整合至簡報，而無需使用 Microsoft Office。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
1. 取得第一張投影片的參考。
1. 新增 3D 群組直條圖並取得其參考。
1. 取得圖表資料。
1. 移除未使用的系列 2 與系列 3。
1. 透過更新標籤修改圖表類別。
1. 更新系列 1 的數值。
1. 取得圖表標題並設定其字型屬性。
1. 設定圖表的值軸，包括主要單位、次要單位、最大值與最小值。
1. 設定圖表在 X 與 Y 軸上的旋轉角度。
1. 以 PPTX 格式儲存簡報。

```cs
// 建立一個空白簡報。
using (Presentation presentation = new Presentation())
{
    // 存取第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增一個預設圖表。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // 取得圖表資料。
    IChartData chartData = chart.ChartData;

    // 移除額外的預設系列。
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // 修改圖表類別名稱。
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // 設定圖表資料工作表的索引。
    int worksheetIndex = 0;

    // 取得圖表資料活頁簿。
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // 修改圖表系列值。
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // 設定圖表標題。
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // 設定軸選項。
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // 設定圖表旋轉。
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // 將簡報儲存為 PPTX 檔案。
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```

結果：

![使用 Aspose.Slides for .NET 建立的圖表](chart-created-using-aspose-slides.png)

## **常見問題**

**我可以使用 Aspose.Slides 建立其他類型的圖表，例如圓餅圖、折線圖或長條圖嗎？**

可以。Aspose.Slides for .NET 支援廣泛的 [chart types](/slides/zh-hant/net/create-chart/)，包括圓餅圖、折線圖、長條圖、散佈圖、氣泡圖等。新增圖表時，可使用 [ChartType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/charttype/) 列舉指定所需的圖表類型。

**我可以為圖表套用自訂樣式或主題嗎？**

可以。您可以完全自訂圖表的外觀，包括顏色、字型、填色、輪廓、格線與版面配置。然而，若要完全套用 PowerPoint 中的 Office 主題，必須手動設定各項樣式。

**我可以將圖表單獨匯出為圖像嗎？**

可以，Aspose.Slides 允許您使用圖表 [shape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 的 `GetImage` 方法，將任何形狀（包括圖表）匯出為單獨的圖像（例如 PNG、JPEG）。