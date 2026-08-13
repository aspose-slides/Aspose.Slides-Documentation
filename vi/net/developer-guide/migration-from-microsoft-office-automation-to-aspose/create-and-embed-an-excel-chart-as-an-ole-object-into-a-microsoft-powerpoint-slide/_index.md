---
title: Tạo và Nhúng Biểu Đồ Excel dưới dạng OLE Object bằng VSTO và Aspose.Slides cho .NET
linktitle: Tạo và Nhúng Biểu Đồ Excel dưới dạng OLE Object
type: docs
weight: 70
url: /vi/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- tạo biểu đồ
- nhúng biểu đồ Excel
- đối tượng OLE
- di chuyển
- VSTO
- tự động hóa Office
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Di chuyển từ tự động hóa Microsoft Office sang Aspose.Slides cho .NET và nhúng biểu đồ Excel dưới dạng đối tượng OLE vào các slide PowerPoint (PPT, PPTX) trong C#."
---
{{% alert color="info" %}} 

Biểu đồ là biểu diễn trực quan dữ liệu của bạn và được sử dụng rộng rãi trong các slide thuyết trình. Bài viết này sẽ cho bạn thấy mã để tạo và nhúng một biểu đồ Excel dưới dạng OLE Object vào slide PowerPoint một cách lập trình bằng cách sử dụng [VSTO](/slides/vi/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) và [Aspose.Slides for .NET](/slides/vi/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Tạo và Nhúng Biểu Đồ Excel**
Hai ví dụ mã dưới đây dài và chi tiết vì nhiệm vụ chúng mô tả khá phức tạp. Bạn tạo một workbook Microsoft Excel, tạo một biểu đồ và sau đó tạo bản trình bày Microsoft PowerPoint mà bạn sẽ nhúng biểu đồ vào. Các đối tượng OLE chứa liên kết tới tài liệu gốc nên người dùng nhấp đúp vào tệp được nhúng sẽ mở tệp và ứng dụng của nó.
## **Ví dụ VSTO**
Sử dụng VSTO, các bước sau được thực hiện:

1. Tạo một thể hiện của đối tượng Microsoft Excel ApplicationClass.
1. Tạo một workbook mới chứa một sheet.
1. Thêm biểu đồ vào sheet.
1. Lưu workbook.
1. Mở workbook Excel chứa worksheet có dữ liệu biểu đồ.
1. Lấy tập hợp ChartObjects cho sheet.
1. Lấy biểu đồ để sao chép.
1. Tạo một bản trình bày Microsoft PowerPoint.
1. Thêm một slide trống vào bản trình bày.
1. Sao chép biểu đồ từ worksheet Excel vào clipboard.
1. Dán biểu đồ vào bản trình bày PowerPoint.
1. Đặt vị trí biểu đồ trên slide.
1. Lưu bản trình bày.

```c#
CreateNewChartInExcel();
UseCopyPaste();
```

```c#
static void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)
{
    targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);
}
```

```c#
static void CreateNewChartInExcel()
{
    // Khai báo một biến cho thể hiện của lớp Excel ApplicationClass.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Khai báo các biến cho các tham số của phương thức Workbooks.Open.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Khai báo các biến cho phương thức Chart.ChartWizard.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Tạo một thể hiện của đối tượng Excel ApplicationClass.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Tạo một workbook mới với 1 sheet bên trong.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Thay đổi tên của sheet.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // Chèn một số dữ liệu cho biểu đồ vào sheet.
        //              A       B       C       D       E
        //     1                Q1      Q2      Q3      Q4
        //     2    Bắc Mỹ  1.5     2       1.5     2.5
        //     3    Nam Mỹ  2       1.75    2       2
        //     4    Châu Âu      2.25    2       2.5     2
        //     5    Châu Á        2.5     2.5     2       2.75

        SetCellValue(targetSheet, "A2", "N. America");
        SetCellValue(targetSheet, "A3", "S. America");
        SetCellValue(targetSheet, "A4", "Europe");
        SetCellValue(targetSheet, "A5", "Asia");

        SetCellValue(targetSheet, "B1", "Q1");
        SetCellValue(targetSheet, "B2", 1.5);
        SetCellValue(targetSheet, "B3", 2);
        SetCellValue(targetSheet, "B4", 2.25);
        SetCellValue(targetSheet, "B5", 2.5);

        SetCellValue(targetSheet, "C1", "Q2");
        SetCellValue(targetSheet, "C2", 2);
        SetCellValue(targetSheet, "C3", 1.75);
        SetCellValue(targetSheet, "C4", 2);
        SetCellValue(targetSheet, "C5", 2.5);

        SetCellValue(targetSheet, "D1", "Q3");
        SetCellValue(targetSheet, "D2", 1.5);
        SetCellValue(targetSheet, "D3", 2);
        SetCellValue(targetSheet, "D4", 2.5);
        SetCellValue(targetSheet, "D5", 2);

        SetCellValue(targetSheet, "E1", "Q4");
        SetCellValue(targetSheet, "E2", 2.5);
        SetCellValue(targetSheet, "E3", 2);
        SetCellValue(targetSheet, "E4", 2);
        SetCellValue(targetSheet, "E5", 2.75);

        // Lấy phạm vi chứa dữ liệu biểu đồ.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Lấy tập hợp ChartObjects cho sheet.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Thêm một biểu đồ vào tập hợp.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // Tạo một biểu đồ mới từ dữ liệu.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Lưu workbook.
        newWorkbook.SaveAs(paramWorkbookPath, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, xlNS.XlSaveAsAccessMode.xlNoChange, paramMissing, paramMissing, paramMissing, paramMissing, paramMissing);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        if (excelApplication != null)
        {
            // Đóng Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Khai báo các biến để giữ tham chiếu tới các đối tượng PowerPoint.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Khai báo các biến để giữ tham chiếu tới các đối tượng Excel.
    xlNS.ApplicationClass excelApplication = null;
    xlNS.Workbook excelWorkBook = null;
    xlNS.Worksheet targetSheet = null;
    xlNS.ChartObjects chartObjects = null;
    xlNS.ChartObject existingChartObject = null;

    string paramPresentationPath = Application.StartupPath + @"\ChartTest.pptx";
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    try
    {
        // Tạo một thể hiện của PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // Tạo một thể hiện của Excel.
        excelApplication = new xlNS.ApplicationClass();

        // Mở workbook Excel chứa worksheet có dữ liệu biểu đồ.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Lấy worksheet chứa biểu đồ.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // Lấy tập hợp ChartObjects cho sheet.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Lấy biểu đồ để sao chép.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // Tạo một bản trình bày PowerPoint.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Thêm một slide trống vào bản trình bày.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Sao chép biểu đồ từ worksheet Excel vào clipboard.
        existingChartObject.Copy();

        // Dán biểu đồ vào bản trình bày PowerPoint.
        shapeRange = pptSlide.Shapes.Paste();

        // Đặt vị trí biểu đồ trên slide.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Lưu bản trình bày.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Giải phóng đối tượng slide PowerPoint.
        shapeRange = null;
        pptSlide = null;

        // Đóng và giải phóng đối tượng Presentation.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Thoát PowerPoint và giải phóng đối tượng ApplicationClass.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Giải phóng các đối tượng Excel.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Đóng và giải phóng đối tượng Workbook Excel.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Thoát Excel và giải phóng đối tượng ApplicationClass.
        if (excelApplication != null)
        {
            excelApplication.Quit();
            excelApplication = null;
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
```




## **Ví dụ Aspose.Slides cho .NET**
Sử dụng Aspose.Slides cho .NET, các bước sau được thực hiện:

1. Tạo một workbook bằng Aspose.Cells cho .NET.
1. Tạo một biểu đồ Microsoft Excel.
1. Đặt kích thước OLE cho biểu đồ Excel.
1. Lấy hình ảnh của biểu đồ.
1. Nhúng biểu đồ Excel dưới dạng OLE Object vào bản trình bày PPTX bằng Aspose.Slides cho .NET.
1. Thay thế hình ảnh đối tượng đã thay đổi bằng hình ảnh thu được ở bước 3 để giải quyết vấn đề đối tượng đã thay đổi.
1. Ghi bản trình bày đầu ra ra đĩa ở định dạng PPTX.



```c#
using System.Drawing;
using Aspose.Slides;

//Bước - 1: Tạo biểu đồ excel bằng Aspose.Cells
//--------------------------------------------------
//Tạo một workbook
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Thêm một biểu đồ excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Bước - 2: Đặt kích thước OLE cho biểu đồ. sử dụng Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Bước - 3: Lấy hình ảnh của biểu đồ bằng Aspose.Cells
//-----------------------------------------------------------
MemoryStream chartImageStream = new MemoryStream();
wb.Worksheets[chartSheetIndex].Charts[0].ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
Bitmap imgChart = new Bitmap(chartImageStream);
//Lưu workbook vào stream
MemoryStream wbStream = wb.SaveToStream();
//Bước - 4  VÀ 5
//-----------------------------------------------------------
//Bước - 4: Nhúng biểu đồ dưới dạng đối tượng OLE vào bản trình bày .ppt bằng Aspose.Slides
//-----------------------------------------------------------
//Bước - 5: Thay thế hình ảnh đối tượng đã thay đổi bằng hình ảnh thu được ở bước 3 để giải quyết vấn đề Object Changed
//-----------------------------------------------------------
//Tạo một presentation
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Thêm workbook vào slide
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Bước - 6: Ghi bản trình bày đầu ra ra đĩa
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] chartOleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(chartOleData, 0, chartOleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

    imageStream.Position = 0;
        IPPImage image = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = image;
    }
}
```

```c#
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook wb, int chartRows, int chartCols)
{
    //Mảng tên ô
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Mảng dữ liệu ô
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Thêm một worksheet mới để điền dữ liệu vào các ô
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //Điền dữ liệu vào DataSheet
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Thêm một sheet biểu đồ
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //Thêm một biểu đồ trong ChartSheet với các chuỗi dữ liệu từ DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Đặt ChartSheet làm sheet hoạt động
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```