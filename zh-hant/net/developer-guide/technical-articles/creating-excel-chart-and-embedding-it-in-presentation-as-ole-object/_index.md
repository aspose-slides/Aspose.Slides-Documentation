---
title: 建立 Excel 圖表並將其作為 OLE 物件嵌入簡報
type: docs
weight: 50
url: /zh-hant/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 圖表
- 嵌入圖表
- OLE 物件
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 C#/.NET 建立 Excel 圖表，並將其作為 OLE 物件嵌入 PowerPoint 與 OpenDocument 簡報。提供步驟說明與程式碼範例。"
---
## **背景**

在 PowerPoint 中，使用可編輯的圖表以圖形方式顯示資料是常見的做法。Aspose 支援使用 Aspose.Cells for .NET 建立 Excel 圖表，然後可透過 Aspose.Slides for .NET 將這些圖表作為 OLE 物件嵌入 PowerPoint 投影片中。本文說明必要的步驟，並提供 C# 程式碼範例，示範如何使用 Aspose.Cells 及 Aspose.Slides 建立 Excel 圖表並將其作為 OLE 物件嵌入 PowerPoint 簡報。

## **必要步驟**

建立並將 Excel 圖表作為 OLE 物件嵌入 PowerPoint 投影片的步驟如下：

1. 使用 Aspose.Cells 建立 Excel 圖表。
1. 使用 Aspose.Cells 設定 Excel 圖表的 OLE 大小。
1. 使用 Aspose.Cells 取得 Excel 圖表的影像。
1. 使用 Aspose.Slides 將 Excel 圖表作為 OLE 物件嵌入 PPTX 簡報。
1. 將「EMBEDDED OLE OBJECT」影像替換為第 3 步取得的影像，以解決[object preview issue](/slides/zh-hant/net/object-preview-issue-when-adding-oleobjectframe/)。
1. 以 PPTX 格式將簡報儲存至磁碟。

## **必要步驟的實作**

上述步驟的 C# 實作如下：

```cs
// Step - 1: 使用 Aspose.Cells 建立 Excel 圖表。
// ---------------------------------------------------
// 建立一個工作簿。
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Add an Excel chart.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Step - 2: 使用 Aspose.Cells 設定圖表的 OLE 大小。
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// Step - 3: 使用 Aspose.Cells 取得圖表的影像。
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// 將工作簿儲存至串流。
MemoryStream workbookStream = workbook.SaveToStream();

// Step - 4 及 5
// ==============
// Step - 4: 使用 Aspose.Slides 將圖表作為 OLE 物件嵌入 .ppt 簡報中。
// ------------------------------------------------------------------------------------------
// Step - 5: 將「EMBEDDED OLE OBJECT」影像替換為第 3 步取得的影像，以解決物件預覽問題。
// --------------------------------------------------------------------------------------------------------------------
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // 將工作簿新增至投影片。
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // Step - 6: 將輸出簡報儲存至磁碟。
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // 儲存格名稱陣列。
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // 儲存格資料陣列。
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // 新增工作表以填入資料到儲存格。
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // 將資料填入資料工作表。
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // 新增圖表工作表。
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // 在圖表工作表中新增圖表，資料序列來自資料工作表。
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // 將圖表工作表設為使用中的工作表。
    workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
    return chartSheetIndex;
}
```

```cs
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] oleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(oleData, 0, oleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	    imageStream.Position = 0;
        IPPImage ppImage = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

以上方法建立的簡報會包含可透過雙擊 OLE 物件框來啟動的 Excel 圖表。

## **結論**

結合 Aspose.Cells for .NET 與 Aspose.Slides for .NET，我們可建立 Aspose.Cells 支援的任何 Excel 圖表，並將圖表以 OLE 物件形式嵌入 PowerPoint 投影片。亦可自訂 Excel 圖表的 OLE 大小。最終使用者即可像編輯其他 OLE 物件般編輯此 Excel 圖表。

## **相關章節**

- [Working Solution for Chart Resizing in PPTX](/slides/zh-hant/net/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/zh-hant/net/object-preview-issue-when-adding-oleobjectframe/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/zh-hant/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)