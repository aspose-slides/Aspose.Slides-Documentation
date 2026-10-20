---
title: Giải pháp hoạt động cho việc thay đổi kích thước worksheet
type: docs
weight: 130
url: /vi/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- hình ảnh xem trước
- thay đổi kích thước hình ảnh
- Excel
- worksheet
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides cho C++
description: "Giải pháp hoạt động cho việc thay đổi kích thước worksheet trong bản trình chiếu PowerPoint sử dụng C++"
---
{{% alert color="info" title="Note" %}}

Các worksheet Excel được nhúng dưới dạng đối tượng OLE trong bản trình chiếu PowerPoint bằng các thành phần Aspose có thể thay đổi kích thước không mong muốn sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt về hình ảnh đáng chú ý giữa đối tượng OLE trước và sau khi kích hoạt. Bài viết này giải thích vấn đề và mô tả hai cách khắc phục.

{{% /alert %}}

## **Bối cảnh**

Trong bài viết [Quản lý OLE](/slides/vi/cpp/manage-ole/), chúng tôi đã giải thích cách thêm một khung OLE vào bản trình chiếu PowerPoint bằng Aspose.Slides cho C++. Để khắc phục [vấn đề xem trước đối tượng](/slides/vi/cpp/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán một hình ảnh của khu vực worksheet đã chọn cho khung đối tượng OLE. Trong bản trình chiếu đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh worksheet, sổ làm việc Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn trên sổ làm việc Excel thực tế và sau đó quay lại slide bằng cách nhấp ra ngoài sổ làm việc Excel đã kích hoạt. Kích thước của khung đối tượng OLE sẽ thay đổi khi người dùng quay lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy thuộc vào kích thước của khung đối tượng OLE và sổ làm việc Excel được nhúng.

## **Nguyên nhân của việc thay đổi kích thước**

Vì sổ làm việc Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước gốc khi được kích hoạt lần đầu. Mặt khác, khung đối tượng OLE cũng có kích thước riêng. Theo Microsoft, khi sổ làm việc Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước để đảm bảo duy trì tỷ lệ đúng như một phần của quá trình nhúng. Việc thay đổi kích thước xảy ra dựa trên sự khác biệt giữa kích thước cửa sổ Excel và kích thước và vị trí của khung đối tượng OLE.

## **Giải pháp thực hiện**

Có hai giải pháp khả thi để tránh hiệu ứng thay đổi kích thước.

- Thu phóng khung OLE trong bản trình chiếu PowerPoint để khớp với tổng chiều cao và chiều rộng của các hàng và cột đã chọn.
- Giữ kích thước khung OLE cố định và thu phóng các hàng và cột đã chọn để vừa với khung.

### **Thu phóng Kích thước Khung OLE**

Cách tiếp cận này đặt kích thước khung OLE sao cho khớp với tổng chiều cao và chiều rộng của các hàng và cột đã chọn trong worksheet Excel được nhúng.

Ví dụ tải một sổ làm việc Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của worksheet đầu tiên bằng chỉ mục bắt đầu từ 0. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) xác định phạm vi hiển thị. Bản xem trước được render ở 96 DPI, và kích thước pixel của nó được chuyển sang điểm bằng cách sử dụng 72 điểm mỗi inch. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) nhúng sổ làm việc đã chỉnh sửa vào một khung với các kích thước đó. Bản xem trước được gán thông qua [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) để thay thế trình giữ chỗ "EMBEDDED OLE OBJECT" trong bản trình chiếu đã lưu.

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

// Đặt kích thước hiển thị khi tệp sổ làm việc được sử dụng làm đối tượng OLE trong PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// Chúng ta cần sử dụng sổ làm việc đã được chỉnh sửa.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Thêm hình ảnh OLE vào tài nguyên của bản trình chiếu.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Tạo khung đối tượng OLE.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

Bộ trợ giúp xem trước sử dụng [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) để chọn phạm vi và loại bỏ lề, tiêu đề và chân trang. Khi bật [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/), [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) render phạm vi thành hình ảnh PNG. Bộ trợ giúp sao chép dữ liệu hình ảnh đã render vào một luồng bộ nhớ mới được định vị tại đầu cho việc sử dụng trong bản trình chiếu.

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

### **Thu phóng Kích thước Phạm vi Ô**

Cách tiếp cận này thu phóng chiều cao của các hàng đã chọn và chiều rộng của các cột đã chọn để khớp với kích thước khung OLE tùy chỉnh.

Ví dụ tải một sổ làm việc Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của worksheet đầu tiên bằng chỉ mục bắt đầu từ 0. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) xác định phạm vi hiển thị, và bộ trợ giúp dưới đây thu phóng phạm vi đó để vừa với một khung rộng 400 điểm và cao 100 điểm. Sau khi lưu sổ làm việc đã chỉnh sửa vào một mảng byte, [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) nhúng nó với kích thước đã chỉ định. Một bản xem trước được render ở 96 DPI được gán thông qua [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/), vì vậy bản trình chiếu đã lưu hiển thị các ô đã chọn thay vì trình giữ chỗ mặc định.

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

// Chúng ta cần sử dụng sổ làm việc đã được chỉnh sửa.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Thêm hình ảnh OLE vào tài nguyên của bản trình chiếu.
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

Bộ trợ giúp thu phóng tính toán tỷ lệ chiều rộng và chiều cao riêng cho phạm vi đã chọn, bảo toàn độ rộng tương đối của các cột và độ cao tương đối của các hàng. Nó chuyển đổi các kích thước đã tính từ điểm sang inch trước khi áp dụng chúng bằng [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) và [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/). Phạm vi đã chọn phải có chiều rộng và chiều cao khác không.

```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">Chiều rộng mong đợi của phạm vi ô tính bằng điểm.</param>
/// <param name="height">Chiều cao mong đợi của phạm vi ô tính bằng điểm.</param>
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

Bộ trợ giúp xem trước này render phạm vi đã thay đổi kích thước bằng [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/). Nó sử dụng [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) để giới hạn in chỉ trong phạm vi đó, loại bỏ lề, tiêu đề và chân trang, và trả về một luồng PNG được định vị tại đầu.

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

{{% alert color="info" title="Note" %}}

Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước worksheet. Hãy chọn cách tiếp cận phù hợp nhất với yêu cầu và trường hợp sử dụng của bạn. Cả hai cách đều hoạt động tương tự, bất kể bản trình chiếu được tạo từ mẫu hay từ đầu. Ngoài ra, không có giới hạn nào về kích thước của khung đối tượng OLE trong giải pháp này.

{{% /alert %}}

## **Câu hỏi thường gặp**

**Tại sao một worksheet Excel được nhúng lại thay đổi kích thước khi lần đầu được kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng duy trì kích thước cửa sổ gốc khi được kích hoạt, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel thương lượng kích thước để duy trì tỷ lệ khung hình, điều này có thể gây ra việc thay đổi kích thước.

**Có thể ngăn hoàn toàn vấn đề thay đổi kích thước này không?**

Có. Bằng cách thu phóng khung OLE để phù hợp với kích thước phạm vi ô Excel hoặc thu phóng phạm vi ô để phù hợp với kích thước khung OLE mong muốn, bạn có thể ngăn ngừa việc thay đổi kích thước không mong muốn.

**Tôi nên sử dụng phương pháp thu phóng nào, thu phóng khung OLE hay thu phóng phạm vi ô?**

Chọn **thu phóng khung OLE** nếu bạn muốn duy trì kích thước hàng và cột gốc của Excel. Chọn **thu phóng phạm vi ô** nếu bạn muốn một kích thước cố định cho khung OLE trong bản trình chiếu của bạn.

**Các giải pháp này có hoạt động nếu bản trình chiếu của tôi dựa trên mẫu không?**

Có. Cả hai giải pháp đều hoạt động cho các bản trình chiếu được tạo từ mẫu và từ đầu.

**Có giới hạn nào về kích thước khung OLE khi sử dụng các phương pháp này không?**

Không. Bạn có thể đặt khung đối tượng OLE bất kỳ kích thước nào miễn là bạn thiết lập tỷ lệ thích hợp.

**Có cách nào để tránh văn bản trình giữ chỗ "EMBEDDED OLE OBJECT" trong PowerPoint không?**

Có. Bằng cách chụp ảnh nhanh phạm vi ô Excel mục tiêu và đặt nó làm hình ảnh trình giữ chỗ của khung OLE, bạn có thể hiển thị một hình ảnh xem trước tùy chỉnh thay cho trình giữ chỗ mặc định.

## **Bài viết liên quan**

[Tạo biểu đồ Excel và nhúng nó vào bản trình chiếu dưới dạng đối tượng OLE](/slides/vi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)