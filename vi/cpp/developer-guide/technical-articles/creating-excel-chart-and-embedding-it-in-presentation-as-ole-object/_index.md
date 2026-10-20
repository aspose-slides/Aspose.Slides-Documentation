---
title: Tạo biểu đồ Excel và nhúng chúng vào bản thuyết trình dưới dạng đối tượng OLE
type: docs
weight: 40
url: /vi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- biểu đồ Excel
- nhúng biểu đồ
- đối tượng OLE
- PowerPoint
- bản thuyết trình
- C++
- Aspose.Slides
description: "Tạo biểu đồ Excel bằng Aspose.Cells cho C++ và nhúng sổ làm việc vào bản thuyết trình PowerPoint bằng Aspose.Slides, bao gồm ảnh xem trước biểu đồ."
---
## **Tổng quan**

Bài viết này mô tả cách tạo biểu đồ cột Excel bằng Aspose.Cells for C++ và nhúng sổ làm việc của nó vào bài thuyết trình PowerPoint bằng Aspose.Slides for C++. Sổ làm việc được nhúng chứa cả dữ liệu nguồn và biểu đồ. Một ảnh PNG riêng biệt hiển thị biểu đồ trên slide trước khi đối tượng OLE được kích hoạt.

Kết quả là một đối tượng Excel được nhúng, không phải là biểu đồ PowerPoint gốc. Việc chỉnh sửa sổ làm việc qua OLE đòi hỏi một ứng dụng desktop hỗ trợ kích hoạt OLE và cài đặt Excel tương thích.

## **Yêu cầu trước**

Cấu hình dự án C++ của bạn với các tệp header và thư viện cho Aspose.Cells for C++ và Aspose.Slides for C++. Đặt mã mẫu vào điểm vào của ứng dụng, với các khai báo include ở phạm vi tệp. Microsoft Office không bắt buộc để tạo bản thuyết trình bằng các thư viện này.

Không cần tệp đầu vào: ví dụ tạo dữ liệu và biểu đồ trong bộ nhớ, sau đó ghi `OutputChart.pptx` vào thư mục làm việc hiện tại. Áp dụng giấy phép cho cả hai sản phẩm khi chạy ngoài chế độ đánh giá.

## **Cách nhúng hoạt động**

1. Tạo một sổ làm việc với một worksheet dữ liệu và một chart sheet.  
1. Đặt chart sheet làm active để sổ mở ở biểu đồ.  
1. Đặt phạm vi hiển thị OLE của sổ và render biểu đồ ra PNG.  
1. Lưu sổ dưới dạng XLSX trong bộ nhớ và nhúng các byte này vào một slide.  
1. Gán PNG làm ảnh xem trước của đối tượng OLE và lưu bản thuyết trình dưới dạng PPTX.

Phạm vi hiển thị của sổ và khung trên slide có vai trò khác nhau. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) nhận chỉ số hàng và cột bắt đầu/kết thúc dựa trên chỉ số 0. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) thay vào đó nhận hàng trên cùng, cột trái, hàng dưới cùng và cột phải. Ví dụ sử dụng chỉ số hàng 55 và chỉ số cột 25 làm giới hạn góc dưới‑phải; các giá trị này là lựa chọn bố cục, không phải số lượng hàng hoặc cột dữ liệu.

Khung slide sử dụng đơn vị điểm. Ví dụ điều chỉnh nó để vừa trong slide và căn giữa trong khi giữ tỉ lệ khung hình của PNG, thay vì kéo dài ảnh xem trước để lấp đầy slide.

## **Tạo và nhúng biểu đồ**

Ví dụ hoàn chỉnh sau đây điền `DataSheet` với bốn hàng và năm cột giá trị. Mỗi hàng trở thành một series biểu đồ. `ChartSheet` được chọn làm sheet hoạt động trước khi sổ được lưu.

Sổ được lưu rõ ràng dưới dạng XLSX, khớp với phần mở rộng `xlsx` được truyền cho [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG được tải từ luồng bộ nhớ mà không cần chuyển đổi qua bitmap trung gian. Aspose.Cells trả về các vector byte, ví dụ sao chép chúng vào kiểu mảng mà Aspose.Slides chấp nhận. Khởi tạo Aspose.Cells trước khi sử dụng các đối tượng của nó, và giải phóng tài nguyên sau khi các đối tượng này bị hủy. Gán nó qua [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) sẽ thay thế ảnh chờ OLE mặc định.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Khởi tạo Cells trước khi tạo bất kỳ đối tượng nào của nó.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // Render ảnh xem trước của biểu đồ và tuần tự hóa sổ làm việc có thể chỉnh sửa riêng biệt.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Sao chép các bộ đệm Cells vào kiểu mảng được Slides sử dụng.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // Điều chỉnh ảnh xem trước vừa trong slide mà không thay đổi tỷ lệ khung hình.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// Giải phóng tài nguyên Cells sau khi tất cả các đối tượng Cells đã được hủy.
Aspose::Cells::Cleanup();
```

## **Kết quả mong đợi**

`OutputChart.pptx` chứa một slide với một sổ Excel được nhúng và một ảnh xem trước biểu đồ. Sổ làm việc chứa dữ liệu gốc và một biểu đồ cột với bốn series. Ảnh xem trước được căn giữa trên slide và giữ tỉ lệ nguyên bản.

![Biểu đồ cột Excel hiển thị làm ảnh xem trước của sổ làm việc được nhúng](excel-chart-ole-preview.png)

Trong môi trường PowerPoint desktop tương thích có Excel, nhấp đúp vào đối tượng để kích hoạt và chỉnh sửa sổ làm việc được nhúng. Việc kích hoạt và chỉnh sửa phụ thuộc vào hỗ trợ OLE và cài đặt bảo mật của ứng dụng host.

## **Câu hỏi thường gặp**

**Tại sao cần ảnh xem trước?**

Sổ làm việc được nhúng và ảnh xem trước trên slide là hai nội dung riêng biệt. Cung cấp ảnh biểu đồ để slide hiển thị biểu đồ thay vì ảnh chờ mặc định "EMBEDDED OLE OBJECT". Xem [Vấn đề xem trước đối tượng khi thêm OleObjectFrame](/slides/vi/cpp/object-preview-issue-when-adding-oleobjectframe/).

**Ảnh xem trước có tự động cập nhật khi tôi thay đổi sổ làm việc trong mã không?**

Xem ảnh trước như một ảnh chụp nhanh. Khi cập nhật dữ liệu sổ làm việc bằng mã, hãy tạo lại ảnh biểu đồ và thay thế ảnh xem trước cũng như dữ liệu sổ làm việc được nhúng.

**Tôi có thể dùng XLS thay cho XLSX không?**

Có. Lưu sổ làm việc ở định dạng XLS và dùng `xls` làm phần mở rộng dữ liệu được nhúng. Phần mở rộng phải khớp với định dạng sổ thực tế; chỉ thay đổi phần mở rộng mà không chuyển đổi dữ liệu sẽ không hiệu quả.

**Tại sao đối tượng có thể thay đổi kích thước sau khi kích hoạt?**

Ứng dụng host có thể cập nhật cách hiển thị của đối tượng OLE khi nó kích hoạt sổ. Cả phạm vi hiển thị OLE của sổ và kích thước khung slide đều quan trọng. Xem [Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX](/slides/vi/cpp/working-solution-for-chart-resizing-in-pptx/).

## **Các phần liên quan**

- [Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX](/slides/vi/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Vấn đề xem trước đối tượng khi thêm OleObjectFrame](/slides/vi/cpp/object-preview-issue-when-adding-oleobjectframe/)