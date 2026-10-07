---
title: Quản lý các ô bảng trong bài thuyết trình bằng C++
linktitle: Quản lý Ô
type: docs
weight: 30
url: /vi/cpp/manage-cells/
keywords:
- ô bảng
- gộp ô
- xóa viền
- tách ô
- hình ảnh trong ô
- màu nền
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Quản lý các ô bảng PowerPoint trong C++: xác định các ô đã gộp, xóa viền, tách ô, và đặt màu nền cùng hình ảnh bằng Aspose.Slides cho C++."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và sửa đổi các ô bảng trong bài thuyết trình PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã được gộp, xóa đường viền ô, làm việc với số thứ tự ô sau khi gộp hoặc tách ô, thay đổi màu nền của ô và thêm hình ảnh vào bên trong một ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bài thuyết trình, lấy bảng từ một slide, cập nhật định dạng ô qua các thuộc tính của ô, và lưu bài thuyết trình đã sửa đổi dưới dạng tệp PPTX.

Aspose.Slides sử dụng chỉ mục bắt đầu từ 0 để truy cập các ô bảng theo thứ tự `(cột, hàng)`.

## **Xác định ô bảng đã gộp**

Ví dụ mở một bài thuyết trình hiện có và truy cập hình dạng đầu tiên trên slide đầu tiên dưới dạng bảng. Giả sử slide và hình dạng tồn tại và hình dạng là một bảng. Sau đó vòng lặp qua tất cả các hàng và cột và sử dụng [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) để xác định các ô trong vùng đã gộp. Đối với mỗi kết quả khớp, nó in tọa độ ô theo thứ tự `hàng;cột`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), và tọa độ bắt đầu của vùng, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) và [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **Xóa đường viền ô bảng**

Tạo một [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) và thêm một bảng vào slide đầu tiên của nó bằng [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). Độ rộng cột, chiều cao hàng và vị trí bảng được chỉ định bằng điểm. Ví dụ đặt cả bốn đường viền ô thành [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), làm chúng ẩn đi.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Gộp ô bảng**

Sử dụng [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) để kết hợp một phạm vi hình chữ nhật các ô bảng thành một ô duy nhất. Xác định các ô ở góc trên‑trái và góc dưới‑phải của phạm vi. Tham số cuối cùng điều khiển việc gộp có cho phép bao gồm các ô ngoài phạm vi đã chỉ định hay không; `false` giữ việc gộp trong phạm vi đó.

Ví dụ tạo một bảng 4×4 với các cột và hàng có độ rộng 70 điểm, sau đó gộp bốn ô trung tâm từ `(1, 1)` tới `(2, 2)`. Ô kết quả trải qua hai cột và hai hàng, trong khi lưới cơ bản của bảng vẫn giữ bốn cột và bốn hàng. Để truy cập nội dung hoặc định dạng của ô đã gộp, sử dụng vị trí trên‑trái của nó: `table->idx_get(1, 1)` trong ví dụ này. Các vị trí khác trong phạm vi gộp vẫn là một phần của lưới bảng, vì vậy chỉ mục của các ô ngoài phạm vi không thay đổi.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **Tách ô bảng**

Việc gộp ô trong ví dụ trước giữ nguyên lưới của bảng. Tách một ô có thể tạo thêm một cột lưới mới và thay đổi chỉ mục cột của các ô ở bên phải nó. Aspose.Slides tuân theo mô hình lưới bảng của PowerPoint.

Ví dụ này tạo một bảng 4×4 với các cột và hàng 70 điểm và gọi [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) trên ô `(1, 1)`. Một nửa độ rộng 70 điểm của ô được truyền vào để tạo hai ô có độ rộng bằng nhau.

Sau khi tách, hai nửa được truy cập dưới dạng `table->idx_get(1, 1)` và `table->idx_get(2, 1)`. Lưới bảng hiện có năm cột: các ô ban đầu ở cột 2 và 3 dịch sang cột 3 và 4 tương ứng. Các chỉ mục hàng không đổi. Hãy sử dụng các chỉ mục cột đã cập nhật khi truy cập các ô sau khi tách.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

### **Tách các ô đã gộp theo chiều hàng hoặc cột**

Để chuẩn bị các ô mẫu đã gộp cho việc chèn dữ liệu, sử dụng [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) để tách theo ranh giới hàng hiện có, hoặc [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) để tách theo ranh giới cột.

Tham số `index` đếm các hàng ở phần trên hoặc các cột ở phần trái của phần tách; nó tương đối với vùng đã gộp:

- Tách hàng: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Tách cột: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

Ví dụ giả định một bài thuyết trình có một bảng là hình dạng đầu tiên trên slide đầu tiên, với các ô `(1, 2)` và `(1, 3)` đã được gộp theo chiều dọc. Bắt đầu từ vị trí dưới cùng, nó sử dụng [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) và [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) để xác định nguồn gốc và kiểm tra cả hai span. `SplitByRowSpan(1)` sau đó tách các hàng 2 và 3 cho tên sản phẩm. Đối với một vùng gộp ngang hai cột, hãy dùng `SplitByColSpan(1)` thay thế.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // Lấy các ô kết quả từ bảng sau khi tách.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

Lưới bảng và các chỉ mục ô xung quanh không thay đổi. Lấy các ô kết quả bằng tọa độ của chúng; ở đây, cả hai đều có span bằng 1 và [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) in ra `False`. Các vùng lớn hơn có thể vẫn còn một phần được gộp sau một lần tách.

Văn bản gốc và định dạng của nó vẫn còn trong ô trên (hoặc trái); ô mới sẽ trống nhưng kế thừa định dạng ô như màu nền, đường viền và lề. Hãy chèn nội dung vào các ô sau khi tách và đặt bất kỳ định dạng văn bản nào cần thiết một cách rõ ràng.

Bài thuyết trình đã lưu chứa các ô “Product A” và “Product B” riêng biệt với định dạng ô mẫu được giữ lại. Xem [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) để biết chi tiết.

## **Thay đổi màu nền ô bảng**

Ví dụ này tạo một bảng với các cột 150 điểm và các hàng 50 điểm. Nó sử dụng [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) để chọn màu nền đặc và [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) để truy cập màu và đặt nó là màu đỏ cho ô `(2, 3)`, nằm ở cột thứ ba và hàng thứ tư.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **Thêm hình ảnh vào bên trong ô bảng**

Đặt hình ảnh đầu vào vào thư mục làm việc trước khi chạy ví dụ này. Nó tải hình ảnh bằng [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) và thêm nó vào bộ sưu tập ảnh của bài thuyết trình bằng [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Sau đó gán hình ảnh cho phần fill hình ảnh của ô `(0, 0)`, ô đầu tiên trong bảng.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) kéo dài hình ảnh để lấp đầy ô, có thể làm thay đổi tỷ lệ khung hình. Độ rộng cột và chiều cao hàng được tính bằng điểm. Hình ảnh đã tải sẽ được giải phóng sau khi đã được thêm vào bài thuyết trình.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt độ dày và kiểu đường viền khác nhau cho từng mặt của một ô duy nhất không?**

Có. Các đường viền [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi mặt có thể khác nhau.

**Nếu tôi thay đổi kích thước cột/hàng sau khi đặt một hình ảnh làm nền cho ô, hình ảnh sẽ xảy ra gì?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). Khi kéo dài, hình ảnh sẽ điều chỉnh theo ô mới; khi lặp, các ô lặp sẽ được tính lại.

**Tôi có thể gắn siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/cpp/manage-hyperlinks/) được đặt ở mức đoạn văn bản (portion) bên trong khung văn bản của ô hoặc ở mức toàn bộ bảng/hình dạng. Thực tế, bạn gắn liên kết cho một đoạn hoặc cho toàn bộ văn bản trong ô.

**Tôi có thể đặt các phông chữ khác nhau trong một ô duy nhất không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (các run) với định dạng độc lập—gia đình phông, kiểu, kích thước và màu.