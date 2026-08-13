---
title: Giải pháp hoạt động cho việc thay đổi kích thước bảng tính
type: docs
weight: 130
url: /vi/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- hình ảnh xem trước
- thay đổi kích thước hình ảnh
- Excel
- bảng tính
- PowerPoint
- bản thuyết trình
- C++
- Aspose.Slides for C++
description: "Giải pháp hoạt động cho việc thay đổi kích thước bảng tính trong các bản thuyết trình PowerPoint sử dụng C++"
---
{{% alert color="info" %}}

Đã được quan sát thấy rằng các bảng tính Excel được nhúng dưới dạng đối tượng OLE trong bản thuyết trình PowerPoint thông qua các thành phần Aspose bị thay đổi kích thước theo một tỷ lệ không xác định sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt về mặt hình ảnh đáng chú ý trong bản thuyết trình giữa trạng thái trước và sau khi kích hoạt đối tượng OLE. Chúng tôi đã nghiên cứu chi tiết vấn đề này và đưa ra giải pháp, được đề cập trong bài viết này.

{{% /alert %}}

## **Bối cảnh**

Trong bài viết [Quản lý OLE](/slides/vi/cpp/manage-ole/), chúng tôi đã giải thích cách thêm khung OLE vào bản thuyết trình PowerPoint bằng Aspose.Slides for C++. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/cpp/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán một hình ảnh của vùng bảng tính đã chọn vào khung đối tượng OLE. Trong bản thuyết trình xuất ra, khi bạn nhấp đúp vào khung OLE hiển thị hình ảnh bảng tính, sổ làm việc Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn trên sổ làm việc Excel thực tế và sau đó quay lại slide bằng cách nhấp ra ngoài sổ Excel đã kích hoạt. Kích thước của khung OLE sẽ thay đổi khi người dùng quay lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy thuộc vào kích thước của khung OLE và sổ làm việc Excel được nhúng.

## **Nguyên nhân gây ra việc thay đổi kích thước**

Vì sổ làm việc Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước gốc khi được kích hoạt lần đầu. Mặt khác, khung đối tượng OLE có kích thước của riêng nó. Theo Microsoft, khi sổ làm việc Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước để đảm bảo duy trì tỷ lệ đúng như một phần của quá trình nhúng. Việc thay đổi kích thước diễn ra dựa trên sự khác biệt giữa kích thước cửa sổ Excel và kích thước cũng như vị trí của khung OLE.

## **Giải pháp thực hiện**

Có hai giải pháp khả thi để tránh hiệu ứng thay đổi kích thước.

- Thu phóng kích thước khung OLE trong bản thuyết trình PowerPoint để khớp với chiều cao và chiều rộng của số hàng và cột mong muốn trong khung OLE.
- Giữ kích thước khung OLE cố định và thu phóng kích thước của các hàng và cột tham gia để vừa với kích thước khung OLE đã chọn.

### **Thu phóng kích thước khung OLE**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước khung OLE của sổ làm việc Excel được nhúng sao cho phù hợp với kích thước tổng hợp của các hàng và cột tham gia trong bảng tính Excel.

Giả sử chúng ta có một bảng tính Excel mẫu và muốn thêm nó vào bản thuyết trình dưới dạng khung OLE. Trong trường hợp này, kích thước của khung đối tượng OLE sẽ được tính toán đầu tiên dựa trên tổng chiều cao các hàng và chiều rộng các cột của các hàng và cột tham gia trong sổ làm việc. Sau đó, chúng ta sẽ đặt kích thước khung OLE bằng giá trị đã tính. Để tránh thông báo màu đỏ "EMBEDDED OLE OBJECT" cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp một hình ảnh của các phần hàng và cột mong muốn trong sổ làm việc và đặt nó làm hình ảnh khung OLE.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We need to use the modified workbook.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add the OLE image to the presentation resources.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"
using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **Thu phóng kích thước vùng ô**

Trong cách tiếp cận này, chúng ta sẽ học cách thu phóng chiều cao của các hàng tham gia và chiều rộng của các cột tham gia để phù hợp với kích thước khung OLE tùy chỉnh.

Giả sử chúng ta có một bảng tính Excel mẫu và muốn thêm nó vào bản thuyết trình dưới dạng khung OLE. Trong trường hợp này, chúng ta sẽ đặt kích thước khung OLE và thu phóng kích thước của các hàng và cột tham gia vào khu vực khung OLE. Sau đó, chúng ta sẽ lưu sổ làm việc vào một luồng để áp dụng các thay đổi và chuyển đổi nó thành mảng byte để thêm vào khung OLE. Để tránh thông báo màu đỏ "EMBEDDED OLE OBJECT" cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp một hình ảnh của các phần hàng và cột mong muốn trong sổ làm việc và đặt nó làm hình ảnh khung OLE.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Đặt kích thước hiển thị khi tệp sổ làm việc được sử dụng làm đối tượng OLE trong PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Thu phóng phạm vi ô để vừa với kích thước khung.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Chúng ta cần sử dụng sổ làm việc đã được sửa đổi.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Thêm hình ảnh OLE vào tài nguyên của bản thuyết trình.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Tạo khung đối tượng OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">Chiều rộng dự kiến của phạm vi ô tính bằng điểm.</param>
/// <param name="height">Chiều cao dự kiến của phạm vi ô tính bằng điểm.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"
using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **Kết luận**

{{% alert color="info" %}}

Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước bảng tính. Lựa chọn cách tiếp cận phù hợp phụ thuộc vào yêu cầu và trường hợp sử dụng cụ thể. Cả hai cách đều hoạt động tương tự, bất kể bản thuyết trình được tạo từ mẫu hay từ đầu. Ngoài ra, không có giới hạn nào về kích thước của khung đối tượng OLE trong giải pháp này.

{{% /alert %}}

## **Câu hỏi thường gặp**

### Tại sao một bảng tính Excel được nhúng lại thay đổi kích thước khi được kích hoạt lần đầu trong PowerPoint?

Điều này xảy ra vì Excel cố gắng duy trì kích thước cửa sổ gốc khi được kích hoạt, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel thương lượng kích thước để duy trì tỷ lệ khung hình, điều này có thể gây ra việc thay đổi kích thước.

### Có thể ngăn hoàn toàn vấn đề thay đổi kích thước này không?

Có. Bằng cách thu phóng khung OLE để phù hợp với kích thước vùng ô Excel hoặc thu phóng vùng ô để phù hợp với kích thước khung OLE mong muốn, bạn có thể ngăn ngừa việc thay đổi kích thước không mong muốn.

### Tôi nên sử dụng phương pháp thu phóng nào, thu phóng khung OLE hay thu phóng vùng ô?

Chọn **thu phóng khung OLE** nếu bạn muốn duy trì kích thước hàng và cột gốc của Excel. Chọn **thu phóng vùng ô** nếu bạn muốn có kích thước cố định cho khung OLE trong bản thuyết trình của mình.

### Các giải pháp này có hoạt động nếu bản thuyết trình của tôi dựa trên mẫu không?

Có. Cả hai giải pháp đều hoạt động cho bản thuyết trình được tạo từ mẫu và từ đầu.

### Có giới hạn nào về kích thước khung OLE khi sử dụng các phương pháp này không?

Không. Bạn có thể đặt khung đối tượng OLE ở bất kỳ kích thước nào miễn là bạn điều chỉnh tỷ lệ một cách thích hợp.

### Có cách nào tránh văn bản chỗ giữ chỗ "EMBEDDED OLE OBJECT" trong PowerPoint không?

Có. Bằng cách chụp ảnh nhanh vùng ô Excel mục tiêu và đặt nó làm hình ảnh chỗ giữ chỗ cho khung OLE, bạn có thể hiển thị hình ảnh xem trước tùy chỉnh thay cho chỗ giữ chỗ mặc định.

## **Bài viết liên quan**

[**Tạo biểu đồ Excel và nhúng nó vào bản thuyết trình dưới dạng đối tượng OLE**](/slides/vi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)