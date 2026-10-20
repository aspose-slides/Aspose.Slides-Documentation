---
title: Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX
type: docs
weight: 60
url: /vi/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- thay đổi kích thước biểu đồ
- biểu đồ Excel
- đối tượng OLE
- nhúng biểu đồ
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Khắc phục việc thay đổi kích thước biểu đồ không mong muốn trong PPTX khi sử dụng đối tượng OLE Excel được nhúng với Aspose.Slides cho C++. Đặt kích thước biểu đồ cố định để giữ cho kích thước biểu đồ và khung OLE đồng nhất."
---
## **Bối cảnh**

Biểu đồ Excel được nhúng dưới dạng đối tượng OLE trong các bản trình chiếu PowerPoint bằng các thành phần Aspose có thể thay đổi kích thước sau lần kích hoạt đầu tiên. Điều này có thể gây ra sự khác biệt đáng chú ý về giao diện của biểu đồ trước và sau khi kích hoạt. Bài viết này giải thích tại sao việc thay đổi kích thước xảy ra và chỉ ra cách ngăn chặn bằng cách khớp kích thước biểu đồ cố định với khung OLE.

Trong [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình chiếu](/slides/vi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), chúng tôi đã giải thích cách tạo một biểu đồ Excel bằng Aspose.Cells cho C++ và nhúng nó vào bản trình chiếu PowerPoint bằng Aspose.Slides cho C++. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/cpp/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán hình ảnh biểu đồ cho khung đối tượng OLE của biểu đồ. Trong bản trình chiếu đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh biểu đồ, biểu đồ Excel sẽ được kích hoạt. Người dùng có thể chỉnh sửa workbook Excel được nhúng và sau đó quay lại slide bằng cách nhấp ngoài workbook đã kích hoạt. Kích thước của khung đối tượng OLE thay đổi khi người dùng quay lại slide, và hệ số thay đổi kích thước phụ thuộc vào kích thước gốc của cả khung đối tượng OLE và workbook Excel được nhúng.

## **Nguyên nhân gây thay đổi kích thước**

Workbook Excel được nhúng có kích thước cửa sổ riêng, mà Excel cố gắng giữ lại khi đối tượng được kích hoạt lần đầu. Khung OLE trên slide có kích thước được xác định độc lập. Khi workbook Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước của đối tượng để duy trì tỉ lệ như một phần của quy trình nhúng. Sự khác biệt giữa cửa sổ workbook và khung OLE do đó có thể gây việc đối tượng thay đổi kích thước.

## **Giải pháp hoạt động**

Khớp kích thước biểu đồ với khung OLE trên slide và giữ kích thước biểu đồ độc lập với cửa sổ workbook. Giải pháp này hoạt động với bản trình chiếu mới hoặc mẫu hiện có.

Ví dụ này yêu cầu Aspose.Cells cho C++ và Aspose.Slides cho C++. Nó tạo một biểu đồ cột đơn giản trên một sheet biểu đồ đang hoạt động và nhúng workbook dưới định dạng XLS. Không có hình ảnh xem trước biểu đồ nào được gán; biểu đồ sẽ hiển thị khi đối tượng OLE được kích hoạt trong PowerPoint.

Đặt mã ví dụ vào điểm nhập của ứng dụng, với các khai báo include ở phạm vi tệp. Khởi tạo Aspose.Cells trước khi tạo các đối tượng và giải phóng tài nguyên sau khi các đối tượng đã bị hủy. Ví dụ sao chép vector byte của workbook được Aspose.Cells trả về vào kiểu mảng mà Aspose.Slides chấp nhận.

Ví dụ tạo một bản trình chiếu mới với khung OLE kích thước 9.5 × 4 inch được đặt cách mép trái 0.5 inch và cách mép trên 1 inch. Tọa độ và kích thước slide được tính bằng điểm (72 điểm mỗi inch). Đối với bản trình chiếu hiện có, xem [Sử dụng mẫu](#use-a-template).

## **Đặt kích thước biểu đồ cố định**

Đặt [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) thành false để kích thước biểu đồ độc lập với cửa sổ workbook. Đặt kích thước của [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) thông qua [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) và [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), chuyển đổi điểm sang pixel bằng 96 pixel mỗi inch: một khung có kích thước 684 × 288 điểm tương ứng với biểu đồ có kích thước 912 × 384 pixel. Đặt [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) thành giá trị Custom của [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). Ví dụ nhúng workbook bằng [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) và lưu bản trình chiếu với khung OLE kích thước 9.5 × 4 inch.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Các tọa độ và kích thước slide được tính bằng điểm (72 điểm mỗi inch).
    auto width = 684.f; // 9.5 inch.
    auto height = 288.f; // 4 inch.

    chart.SetSizeWithWindow(false);
    // Chuyển đổi điểm sang pixel biểu đồ sử dụng 96 pixel mỗi inch.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Sao chép vector byte của Cells vào kiểu mảng được Slides chấp nhận.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```

## **Sử dụng mẫu**

Logic tính kích thước giống nhau cho bản trình chiếu hiện có. Để áp dụng ví dụ:

1. Tải bản trình chiếu mẫu thay vì tạo một bản trình chiếu trống.
1. Kiểm tra xem slide đầu tiên có ít nhất ba hình dạng, sau đó sử dụng hình dạng tại chỉ mục 2 làm trình giữ chỗ.
1. Lấy chiều rộng và chiều cao khung từ hình dạng đó thay vì sử dụng các giá trị cố định 684 và 288. Giữ nguyên các phép tính kích thước.
1. Thêm khung OLE tại vị trí của trình giữ chỗ thay vì các tọa độ cố định 36 và 72.
1. Xóa trình giữ chỗ trước khi lưu bản trình chiếu.

## **FAQ**

**Tại sao biểu đồ Excel được nhúng của tôi lại thay đổi kích thước sau khi kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng khôi phục kích thước cửa sổ ban đầu khi được kích hoạt lần đầu, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel thương lượng kích thước để duy trì tỉ lệ khung hình, điều này có thể gây ra việc thay đổi kích thước.

**Làm thế nào để giữ kích thước biểu đồ và khung OLE nhất quán?**

Đặt kích thước biểu đồ cố định phù hợp với khung OLE và sử dụng kích thước in biểu đồ tùy chỉnh trước khi nhúng workbook. Ví dụ trên cho thấy các cài đặt cần thiết và cách chuyển đổi đơn vị.

**Việc khớp kích thước cửa sổ workbook có đủ không?**

Chỉ khớp kích thước cửa sổ workbook không đảm bảo ngăn khung OLE thay đổi kích thước sau khi kích hoạt. Hãy sử dụng kích thước biểu đồ cố định như trong ví dụ.

**Giải pháp này có hoạt động với cả bản trình chiếu dựa trên mẫu và bản trình chiếu mới không?**

Có. Đối với mẫu, sử dụng kích thước và vị trí của trình giữ chỗ. Đối với bản trình chiếu mới, chỉ định trực tiếp kích thước và vị trí của khung.

**Tôi có thể sử dụng ví dụ này với các biểu đồ được tạo trong các chương trình bảng tính khác không?**

Ví dụ sử dụng một workbook Excel được tạo bằng Aspose.Cells. Nó không minh họa hành vi kích hoạt cho các chương trình bảng tính khác.

## **Các phần liên quan**

- [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình chiếu](/slides/vi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)