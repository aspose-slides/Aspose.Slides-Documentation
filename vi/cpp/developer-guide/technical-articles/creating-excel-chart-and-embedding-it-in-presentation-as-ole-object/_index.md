---
title: Tạo biểu đồ Excel và nhúng chúng vào bản trình bày dưới dạng đối tượng OLE
type: docs
weight: 40
url: /vi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Biểu đồ Excel
- nhúng biểu đồ
- đối tượng OLE
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong các bản trình bày PowerPoint và OpenDocument bằng C++. Hướng dẫn chi tiết kèm mẫu mã."
---
## **Bối cảnh**

Trong PowerPoint, việc sử dụng biểu đồ có thể chỉnh sửa để hiển thị dữ liệu một cách đồ họa là một thực hành phổ biến. Aspose hỗ trợ tạo biểu đồ Excel bằng Aspose.Cells cho C++, và các biểu đồ này có thể được nhúng dưới dạng đối tượng OLE trong các slide PowerPoint thông qua Aspose.Slides cho C++. Bài viết này trình bày các bước cần thiết và cung cấp mẫu mã C++ để tạo biểu đồ Excel và nhúng nó dưới dạng đối tượng OLE trong một bản trình bày PowerPoint bằng Aspose.Cells và Aspose.Slides.

## **Các bước cần thiết**

1. Tạo biểu đồ Excel bằng Aspose.Cells.
1. Đặt kích thước OLE của biểu đồ Excel bằng Aspose.Cells.
1. Lấy hình ảnh của biểu đồ Excel bằng Aspose.Cells.
1. Nhúng biểu đồ Excel dưới dạng đối tượng OLE trong bản trình bày PPTX bằng Aspose.Slides.
1. Thay thế hình ảnh "EMBEDDED OLE OBJECT" bằng hình ảnh thu được ở bước 3 để giải quyết vấn đề [object preview issue](/slides/vi/cpp/object-preview-issue-when-adding-oleobjectframe/).
1. Lưu bản trình bày vào đĩa ở định dạng PPTX.

## **Triển khai các bước cần thiết**

Việc triển khai C++ của các bước trên như sau:

```cpp
// Bước - 1: Tạo biểu đồ Excel bằng Aspose.Cells.
// ---------------------------------------------------
// Tạo một workbook.
intrusive_ptr<Aspose::Cells::IWorkbook> workbook = Aspose::Cells::Factory::CreateIWorkbook();
// Thêm một biểu đồ Excel.
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(workbook, chartRows, chartCols);

// Bước - 2: Đặt kích thước OLE của biểu đồ bằng Aspose.Cells.
// -----------------------------------------------------------
workbook->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);

// Bước - 3: Lấy hình ảnh của biểu đồ bằng Aspose.Cells.
// -------------------------------------------------------
System::SharedPtr<System::Drawing::Bitmap> chartImage = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
// Lưu workbook vào một luồng.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

// Bước - 4 VÀ 5
// ==============
// Bước - 4: Nhúng biểu đồ dưới dạng đối tượng OLE vào bản trình bày .ppt bằng Aspose.Slides.
// ------------------------------------------------------------------------------------------
// Bước - 5: Thay thế hình ảnh "EMBEDDED OLE OBJECT" bằng hình ảnh thu được ở bước 3 để giải quyết vấn đề Xem trước Đối tượng.
// --------------------------------------------------------------------------------------------------------------------
// Tạo một bản trình bày.
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);
// Thêm workbook vào slide.
AddExcelChartInPresentation(presentation, slide, workbookStream, chartImage);

// Bước - 6: Lưu bản trình bày đầu ra vào đĩa.
// -----------------------------------------------
presentation->Save(u"OutputChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

```cpp
void AddExcelChartInPresentation(System::SharedPtr<Presentation> presentation, System::SharedPtr<ISlide> slide, 
                                 System::SharedPtr<System::IO::Stream> workbookStream, 
                                 intrusive_ptr<Aspose::Cells::Systems::Drawing::Bitmap> chartImage)
{
    float oleWidth = presentation->get_SlideSize()->get_Size().get_Width();
    float oleHeight = presentation->get_SlideSize()->get_Size().get_Height();
    int32_t x = 0;
    System::ArrayPtr<uint8_t> oleData = System::MakeArray<uint8_t>(workbookStream->get_Length(), 0);
    workbookStream->set_Position(0);
    workbookStream->Read(oleData, 0, oleData->get_Length());

    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(oleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oleFrame;
    oleFrame = slide->get_Shapes()->AddOleObjectFrame(static_cast<float>(x), 0.0f, oleWidth, oleHeight, dataInfo);

    intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
    chartImage->Save(cellsOutputStream, Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetBmp());

    auto slidesImage = Images::FromStream(ToSlidesMemoryStream(cellsOutputStream));
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(slidesImage));
}
```

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
int32_t AddExcelChartInWorkbook(intrusive_ptr<Aspose::Cells::IWorkbook> workbook, int32_t chartRows, int32_t chartCols)
{
    // Mảng các tên ô.
    System::ArrayPtr<System::String> cellNames = System::MakeArray<System::String>(
    { 
        u"A1", u"A2", u"A3", u"A4", 
        u"B1", u"B2", u"B3", u"B4",
        u"C1", u"C2", u"C3", u"C4",
        u"D1", u"D2", u"D3", u"D4",
        u"E1", u"E2", u"E3", u"E4" 
    });
    
    // Mảng dữ liệu ô.
    System::ArrayPtr<int32_t> cellValues = System::MakeArray<int32_t>(
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25 
    });

    // Thêm một worksheet mới để điền dữ liệu vào các ô.
    int32_t dataSheetIndex = workbook->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIndex);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Điền dữ liệu vào worksheet dữ liệu.
    for (int32_t i = 0; i < cellNames->get_Length(); i++)
    {
        System::String cellName = cellNames[i];
        int32_t cellValue = cellValues[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Thêm một sheet biểu đồ.
    int32_t chartSheetIndex = workbook->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = workbook->GetIWorksheets()->GetObjectByIndex(chartSheetIndex);
    chartSheet->SetName(new String("ChartSheet"));

    // Thêm một biểu đồ vào sheet biểu đồ với chuỗi dữ liệu từ sheet dữ liệu.
    int32_t chartIndex = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIndex);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // Đặt sheet biểu đồ làm sheet hoạt động.
    workbook->GetIWorksheets()->SetActiveSheetIndex(chartSheetIndex);

    return chartSheetIndex;
}
```

Bản trình bày được tạo bằng phương pháp trên sẽ chứa biểu đồ Excel dưới dạng đối tượng OLE có thể kích hoạt bằng cách nhấp đúp vào khung đối tượng OLE.

## **Kết luận**

Bằng cách sử dụng Aspose.Cells cho C++ cùng với Aspose.Slides cho C++, chúng ta có thể tạo bất kỳ biểu đồ Excel nào được Aspose.Cells hỗ trợ và nhúng biểu đồ đó dưới dạng đối tượng OLE trong một slide PowerPoint. Kích thước OLE của biểu đồ Excel cũng có thể được định nghĩa. Người dùng cuối sau đó có thể chỉnh sửa biểu đồ Excel giống như bất kỳ đối tượng OLE nào khác.

## **Các phần liên quan**

- [Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX](/slides/vi/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Vấn đề xem trước đối tượng khi thêm OleObjectFrame](/slides/vi/cpp/object-preview-issue-when-adding-oleobjectframe/)