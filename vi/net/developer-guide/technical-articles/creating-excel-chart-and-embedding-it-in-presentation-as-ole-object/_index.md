---
title: Tạo biểu đồ Excel và nhúng chúng vào bản trình chiếu dưới dạng đối tượng OLE
type: docs
weight: 50
url: /vi/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- biểu đồ Excel
- nhúng biểu đồ
- đối tượng OLE
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong các bản trình chiếu PowerPoint và OpenDocument bằng C#/.NET. Hướng dẫn từng bước kèm mẫu mã."
---
## **Bối cảnh**

Trong PowerPoint, việc sử dụng biểu đồ có thể chỉnh sửa để hiển thị dữ liệu một cách đồ họa là thực hành phổ biến. Aspose hỗ trợ tạo biểu đồ Excel bằng Aspose.Cells cho .NET, và các biểu đồ này sau đó có thể được nhúng dưới dạng đối tượng OLE trong các slide PowerPoint thông qua Aspose.Slides cho .NET. Bài viết này trình bày các bước cần thiết và cung cấp các mẫu mã C# để tạo biểu đồ Excel và nhúng nó dưới dạng đối tượng OLE trong bản trình bày PowerPoint bằng Aspose.Cells và Aspose.Slides.

## **Các bước cần thiết**

Các bước sau đây là cần thiết để tạo và nhúng một biểu đồ Excel dưới dạng đối tượng OLE trong một slide PowerPoint:

1. Tạo biểu đồ Excel bằng Aspose.Cells.
1. Đặt kích thước OLE cho biểu đồ Excel bằng Aspose.Cells.
1. Lấy hình ảnh của biểu đồ Excel bằng Aspose.Cells.
1. Nhúng biểu đồ Excel dưới dạng đối tượng OLE vào bản trình bày PPTX bằng Aspose.Slides.
1. Thay thế hình ảnh "EMBEDDED OLE OBJECT" bằng hình ảnh lấy được ở bước 3 để giải quyết vấn đề[object preview issue](/slides/vi/net/object-preview-issue-when-adding-oleobjectframe/).
1. Lưu bản trình bày vào đĩa ở định dạng PPTX.

## **Triển khai các bước cần thiết**

Việc triển khai C# cho các bước trên như sau:

```cs
// Bước - 1: Tạo biểu đồ Excel bằng Aspose.Cells.
// ---------------------------------------------------
// Tạo một workbook.
Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
// Thêm một biểu đồ Excel.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Bước - 2: Đặt kích thước OLE cho biểu đồ bằng Aspose.Cells.
// -----------------------------------------------------------
workbook.Worksheets.SetOleSize(0, chartRows, 0, chartCols);

// Bước - 3: Lấy hình ảnh của biểu đồ bằng Aspose.Cells.
// -------------------------------------------------------
Bitmap chartImage = workbook.Worksheets[chartSheetIndex].Charts[0].ToImage();
// Lưu workbook vào một stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Bước - 4 VÀ 5
// ==============
 // Bước - 4: Nhúng biểu đồ dưới dạng đối tượng OLE vào bản trình chiếu .ppt bằng Aspose.Slides.
 // ------------------------------------------------------------------------------------------
 // Bước - 5: Thay thế hình ảnh "EMBEDDED OLE OBJECT" bằng hình ảnh lấy được ở bước 3 để khắc phục Vấn đề Xem trước Đối tượng.
 // --------------------------------------------------------------------------------------------------------------------
 // Tạo một presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    // Thêm workbook vào slide.
    AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

    // Bước - 6: Lưu bản trình chiếu đầu ra vào đĩa.
    // -----------------------------------------------
    presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

```cs
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook workbook, int chartRows, int chartCols)
{
    // Một mảng các tên ô.
    string[] cellNames = new string[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Một mảng dữ liệu cho các ô.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Thêm một worksheet mới để điền dữ liệu vào các ô.
    int dataSheetIndex = workbook.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = workbook.Worksheets[dataSheetIndex];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;

    // Điền dữ liệu vào sheet dữ liệu.
    for (int i = 0; i < cellNames.Length; i++)
    {
        string cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }

    // Thêm một sheet biểu đồ.
    int chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = workbook.Worksheets[chartSheetIndex];
    chartSheet.Name = "ChartSheet";

    // Thêm một biểu đồ vào sheet biểu đồ với các chuỗi dữ liệu từ sheet dữ liệu.
    int chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIndex];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);

    // Đặt sheet biểu đồ làm sheet hoạt động.
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

Bản trình bày được tạo bằng phương pháp trên sẽ chứa biểu đồ Excel dưới dạng đối tượng OLE có thể được kích hoạt bằng cách nhấp đúp vào khung đối tượng OLE.

## **Kết luận**

Bằng cách sử dụng Aspose.Cells cho .NET kết hợp với Aspose.Slides cho .NET, chúng ta có thể tạo bất kỳ biểu đồ Excel nào được Aspose.Cells hỗ trợ và nhúng biểu đồ đó dưới dạng đối tượng OLE trong một slide PowerPoint. Kích thước OLE của biểu đồ Excel cũng có thể được xác định. Người dùng cuối sau đó có thể chỉnh sửa biểu đồ Excel như bất kỳ đối tượng OLE nào khác.

## **Các phần liên quan**

- [Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX](/slides/vi/net/working-solution-for-chart-resizing-in-pptx/)
- [Vấn đề xem trước đối tượng khi thêm OleObjectFrame](/slides/vi/net/object-preview-issue-when-adding-oleobjectframe/)
- [Tự động cập nhật đối tượng OLE bằng Add-In PowerPoint](/slides/vi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)