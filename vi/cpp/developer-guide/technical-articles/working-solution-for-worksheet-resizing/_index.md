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
- bản trình chiếu
- C++
- Aspose.Slides cho C++
description: "Giải pháp hoạt động cho việc thay đổi kích thước bảng tính trong bản trình chiếu PowerPoint sử dụng C++"
---
{{% alert color="primary" %}}
Đã được ghi nhận rằng các bảng tính Excel được nhúng dưới dạng đối tượng OLE trong một bản trình chiếu PowerPoint thông qua các thành phần Aspose bị thay đổi kích thước theo một tỉ lệ không xác định sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt về mặt hình ảnh đáng chú ý trong bản trình chiếu giữa trạng thái trước và sau khi kích hoạt đối tượng OLE. Chúng tôi đã điều tra chi tiết vấn đề này và cung cấp giải pháp, được trình bày trong bài viết này.
{{% /alert %}}

## **Bối cảnh**

Trong bài viết [Manage OLE](/slides/vi/cpp/manage-ole/), chúng tôi đã giải thích cách thêm khung OLE vào bản trình chiếu PowerPoint bằng Aspose.Slides for C++. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/cpp/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán một hình ảnh của khu vực bảng tính đã chọn vào khung đối tượng OLE. Trong bản trình chiếu xuất ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh bảng tính, sổ làm việc Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn trên sổ làm việc Excel thực tế và sau đó quay lại slide bằng cách nhấp ra ngoài sổ làm việc Excel đã kích hoạt. Kích thước của khung đối tượng OLE sẽ thay đổi khi người dùng quay lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy thuộc vào kích thước của khung đối tượng OLE và sổ làm việc Excel được nhúng.

## **Nguyên nhân của việc thay đổi kích thước**

Vì sổ làm việc Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước ban đầu khi kích hoạt lần đầu. Ngược lại, khung đối tượng OLE có kích thước của riêng nó. Theo Microsoft, khi sổ làm việc Excel được kích hoạt, Excel và PowerPoint sẽ đàm phán kích thước để đảm bảo nó duy trì tỷ lệ đúng như một phần của quá trình nhúng. Việc thay đổi kích thước xảy ra dựa trên sự khác biệt giữa kích thước cửa sổ Excel và kích thước cũng như vị trí của khung đối tượng OLE.

## **Giải pháp hoạt động**

Có hai giải pháp khả thi để tránh hiệu ứng thay đổi kích thước.

- Điều chỉnh kích thước khung OLE trong bản trình chiếu PowerPoint để khớp với chiều cao và chiều rộng của số lượng hàng và cột mong muốn trong khung OLE.  
- Giữ kích thước khung OLE không đổi và điều chỉnh kích thước của các hàng và cột tham gia để vừa với kích thước khung OLE đã chọn.

### **Điều chỉnh kích thước khung OLE**

Trong cách tiếp cận này, chúng ta sẽ tìm hiểu cách đặt kích thước khung OLE của sổ làm việc Excel nhúng sao cho khớp với kích thước tổng hợp của các hàng và cột tham gia trong bảng tính Excel.

Giả sử chúng ta có một bảng tính Excel mẫu và muốn thêm nó vào bản trình chiếu dưới dạng khung OLE. Trong trường hợp này, kích thước của khung đối tượng OLE sẽ được tính toán đầu tiên dựa trên tổng chiều cao các hàng và tổng chiều rộng các cột tham gia trong sổ. Sau đó, chúng ta sẽ đặt kích thước của khung OLE thành giá trị đã tính. Để tránh thông báo màu đỏ “EMBEDDED OLE OBJECT” cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp một hình ảnh của các phần hàng và cột mong muốn trong sổ và đặt nó làm hình ảnh khung OLE.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Đặt kích thước hiển thị khi tệp workbook được sử dụng làm đối tượng OLE trong PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Lấy độ rộng và chiều cao của hình ảnh OLE tính bằng điểm.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// Chúng ta cần sử dụng workbook đã được chỉnh sửa.
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

```cpp
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

### **Điều chỉnh kích thước phạm vi ô**

Trong cách tiếp cận này, chúng ta sẽ tìm hiểu cách điều chỉnh chiều cao của các hàng tham gia và chiều rộng của các cột tham gia sao cho phù hợp với một kích thước khung OLE tùy chỉnh.

Giả sử chúng ta có một bảng tính Excel mẫu và muốn thêm nó vào bản trình chiếu dưới dạng khung OLE. Trong trường hợp này, chúng ta sẽ đặt kích thước của khung OLE và điều chỉnh kích thước của các hàng và cột tham gia vào khu vực khung OLE. Sau đó, chúng ta sẽ lưu sổ làm việc vào một luồng để áp dụng các thay đổi và chuyển đổi nó thành mảng byte để thêm vào khung OLE. Để tránh thông báo màu đỏ “EMBEDDED OLE OBJECT” cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp một hình ảnh của các phần hàng và cột mong muốn trong sổ và đặt nó làm hình ảnh khung OLE.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Đặt kích thước hiển thị khi tệp workbook được sử dụng làm đối tượng OLE trong PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Điều chỉnh phạm vi ô để vừa với kích thước khung.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Cần sử dụng workbook đã được chỉnh sửa.
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

```cpp
/// <param name="width">Chiều rộng mong muốn của phạm vi ô tính bằng điểm.</param>
/// <param name="height">Chiều cao mong muốn của phạm vi ô tính bằng điểm.</param>
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

{{% alert color="primary" %}}
Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước bảng tính. Lựa chọn cách tiếp cận phù hợp phụ thuộc vào các yêu cầu và trường hợp sử dụng cụ thể. Cả hai cách đều hoạt động tương tự, bất kể bản trình chiếu được tạo từ mẫu hay từ đầu. Ngoài ra, không có giới hạn nào về kích thước khung đối tượng OLE trong giải pháp này.
{{% /alert %}}

## **FAQ**

**Tại sao một bảng tính Excel được nhúng lại thay đổi kích thước khi được kích hoạt lần đầu trong PowerPoint?**  
Điều này xảy ra vì Excel cố gắng duy trì kích thước cửa sổ gốc khi được kích hoạt, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel sẽ đàm phán kích thước để duy trì tỷ lệ khung hình, dẫn đến việc thay đổi kích thước.

**Có thể ngăn chặn hoàn toàn vấn đề thay đổi kích thước này không?**  
Có. Bằng cách điều chỉnh khung OLE để phù hợp với kích thước phạm vi ô Excel hoặc điều chỉnh phạm vi ô để phù hợp với kích thước khung OLE mong muốn, bạn có thể ngăn ngừa việc thay đổi kích thước không mong muốn.

**Phương pháp điều chỉnh nào nên sử dụng, điều chỉnh khung OLE hay điều chỉnh phạm vi ô?**  
Chọn **điều chỉnh khung OLE** nếu bạn muốn giữ nguyên kích thước hàng và cột Excel gốc. Chọn **điều chỉnh phạm vi ô** nếu bạn muốn khung OLE trong bản trình chiếu có kích thước cố định.

**Liệu các giải pháp này có hoạt động nếu bản trình chiếu của tôi dựa trên mẫu không?**  
Có. Cả hai giải pháp đều hoạt động cho bản trình chiếu được tạo từ mẫu và từ đầu.

**Có giới hạn nào về kích thước khung OLE khi sử dụng các phương pháp này không?**  
Không. Bạn có thể đặt khung đối tượng OLE ở bất kỳ kích thước nào miễn là bạn điều chỉnh tỷ lệ một cách phù hợp.

**Có cách nào tránh văn bản chỗ giữ chỗ "EMBEDDED OLE OBJECT" trong PowerPoint không?**  
Có. Bằng cách chụp ảnh phạm vi ô Excel mục tiêu và đặt nó làm hình ảnh chỗ giữ chỗ của khung OLE, bạn có thể hiển thị một hình ảnh xem trước tùy chỉnh thay cho chỗ giữ chỗ mặc định.

## **Bài viết liên quan**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/vi/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)