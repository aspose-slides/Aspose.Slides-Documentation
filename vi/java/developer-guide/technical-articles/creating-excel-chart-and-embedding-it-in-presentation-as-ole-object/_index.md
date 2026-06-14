---
title: Tạo biểu đồ Excel và nhúng chúng vào bản trình chiếu dưới dạng đối tượng OLE
type: docs
weight: 30
url: /vi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- biểu đồ Excel
- nhúng biểu đồ
- đối tượng OLE
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong các bản trình chiếu PowerPoint và OpenDocument bằng Java. Hướng dẫn chi tiết từng bước với các mẫu mã."
---
## **Bối cảnh**

Trong PowerPoint, việc sử dụng biểu đồ có thể chỉnh sửa để hiển thị dữ liệu một cách đồ họa là thực tiễn phổ biến. Aspose hỗ trợ tạo biểu đồ Excel bằng Aspose.Cells cho Java, và những biểu đồ này sau đó có thể được nhúng dưới dạng đối tượng OLE trong các slide PowerPoint thông qua Aspose.Slides cho Java. Bài viết này đề cập đến các bước cần thiết và cung cấp các mẫu mã Java để tạo một biểu đồ Excel và nhúng nó dưới dạng đối tượng OLE trong bản trình bày PowerPoint bằng Aspose.Cells và Aspose.Slides.

## **Các bước bắt buộc**

Các bước sau đây là cần thiết để tạo và nhúng một biểu đồ Excel dưới dạng đối tượng OLE trong một slide PowerPoint:

1. Tạo biểu đồ Excel bằng Aspose.Cells.
1. Đặt kích thước OLE cho biểu đồ Excel bằng Aspose.Cells.
1. Lấy hình ảnh của biểu đồ Excel bằng Aspose.Cells.
1. Nhúng biểu đồ Excel dưới dạng đối tượng OLE vào bản trình bày PPTX bằng Aspose.Slides.
1. Thay thế hình ảnh "EMBEDDED OLE OBJECT" bằng hình ảnh thu được ở bước 3 để giải quyết vấn đề [vấn đề xem trước đối tượng](/slides/vi/java/object-preview-issue-when-adding-oleobjectframe/).
1. Lưu bản trình bày ra đĩa ở định dạng PPTX.

## **Triển khai các bước bắt buộc**

Triển khai Java cho các bước trên như sau:

```java
// Tạo một workbook.
Workbook workbook = new Workbook();

// Thêm một biểu đồ Excel.
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Đặt kích thước OLE của biểu đồ.
workbook.getWorksheets().setOleSize(0, chartRows, 0, chartCols);

// Lấy hình ảnh biểu đồ và lưu nó vào một luồng.
com.aspose.cells.ImageOrPrintOptions printOptions = new com.aspose.cells.ImageOrPrintOptions();
printOptions.setImageFormat(com.aspose.cells.ImageFormat.getPng());
ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
workbook.getWorksheets().get(chartSheetIndex).getCharts().get(0).toImage(imageStream, printOptions);

// Lưu workbook vào một luồng.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream(); 
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);

// Tạo một bản trình chiếu.
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Thêm workbook vào một slide.
AddExcelChartInPresentation(presentation, slide, workbookStream.toByteArray(), imageStream.toByteArray());

// Lưu bản trình chiếu vào ổ đĩa.
presentation.save("OutputChart.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, byte[] workbookArray, byte[] chartImage) throws Exception
{
    double oleHeight = presentation.getSlideSize().getSize().getHeight();
    double oleWidth = presentation.getSlideSize().getSize().getWidth();
 
    // Tạo một đối tượng LoadOptions cho EXCEL_97_TO_2003.
    com.aspose.cells.LoadOptions loadOptions = new com.aspose.cells.LoadOptions(com.aspose.cells.FileFormatType.EXCEL_97_TO_2003);         
    Workbook workbook = new Workbook(new ByteArrayInputStream(workbookArray),loadOptions);
 
    IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(0f, 0f, (float)oleWidth, (float)oleHeight, "Excel.Sheet.8", workbookArray);
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(presentation.getImages().addImage(new ByteArrayInputStream(chartImage)));
}
```

```java
static int AddExcelChartInWorkbook(Workbook workbook, int chartRows, int chartCols)
{
    // Một mảng các tên ô.
    String[] cellNames = new String[]
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    // Một mảng các dữ liệu ô.
    int[] cellValues = new int[]
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };

    // Thêm một worksheet mới để điền dữ liệu vào các ô.
    int dataSheetIndex = workbook.getWorksheets().add();
    Worksheet dataSheet = workbook.getWorksheets().get(dataSheetIndex);
    String sheetName = "DataSheet";
    dataSheet.setName(sheetName);

    // Đổ dữ liệu vào worksheet dữ liệu.
    int size = Array.getLength(cellNames);
    for (int i = 0; i < size; i++)
    {
        String cellName = cellNames[i];
        int cellValue = cellValues[i];
        dataSheet.getCells().get(cellName).setValue(cellValue);
    }

    // Thêm một chart sheet.
    int worksheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(worksheetIndex);
    chartSheet.setName("ChartSheet");
    int chartSheetIndex = chartSheet.getIndex();

    // Thêm một biểu đồ vào chart sheet với series dữ liệu từ worksheet dữ liệu.
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, chartRows, 0, chartCols);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    
    chart.getNSeries().add(sheetName + "!A1:E1", false);
    chart.getNSeries().add(sheetName + "!A2:E2", false);
    chart.getNSeries().add(sheetName + "!A3:E3", false);
    chart.getNSeries().add(sheetName + "!A4:E4", false);

    // Đặt chart sheet làm worksheet hoạt động.
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    return chartSheetIndex;
}
```

Bản trình bày được tạo bằng phương pháp trên sẽ chứa biểu đồ Excel dưới dạng đối tượng OLE có thể được kích hoạt bằng cách nhấp đúp vào khung đối tượng OLE.

## **Kết luận**

Bằng cách sử dụng Aspose.Cells cho Java kết hợp với Aspose.Slides cho Java, chúng ta có thể tạo bất kỳ biểu đồ Excel nào được Aspose.Cells hỗ trợ và nhúng biểu đồ đó dưới dạng đối tượng OLE trong một slide PowerPoint. Kích thước OLE của biểu đồ Excel cũng có thể được xác định. Người dùng cuối sau đó có thể chỉnh sửa biểu đồ Excel như bất kỳ đối tượng OLE nào khác.

## **Các phần liên quan**

- [Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX](/slides/vi/java/working-solution-for-chart-resizing-in-pptx/)
- [Vấn đề xem trước đối tượng khi Thêm OleObjectFrame](/slides/vi/java/object-preview-issue-when-adding-oleobjectframe/)
- [Tự động cập nhật Đối tượng OLE bằng Add-In PowerPoint](/slides/vi/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)