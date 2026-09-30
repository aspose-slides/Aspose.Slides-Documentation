---
title: Quản lý bảng trong bài thuyết trình bằng C++
linktitle: Quản lý bảng
type: docs
weight: 10
url: /vi/cpp/manage-table/
keywords:
- thêm bảng
- tạo bảng
- truy cập bảng
- tỷ lệ khung hình
- căn chỉnh văn bản
- định dạng văn bản
- kiểu bảng
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tạo và chỉnh sửa bảng trong các slide PowerPoint bằng Aspose.Slides cho C++. Khám phá các ví dụ mã đơn giản để tối ưu hoá quy trình làm việc với bảng của bạn."
---
## **Giới thiệu**

Bảng trong PowerPoint sắp xếp thông tin thành các hàng và cột, giúp dễ dàng đọc và so sánh các giá trị.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) , giao diện [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) , lớp [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) , giao diện [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) , và các kiểu khác cho phép bạn tạo, cập nhật và quản lý bảng trong các bài thuyết trình.

## **Tạo bảng từ đầu**

Tạo một bảng bằng cách chỉ định vị trí, chiều rộng của các cột và chiều cao của các hàng. Sau khi thêm vào một slide, bạn có thể định dạng viền ô, hợp nhất các ô và chèn văn bản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide bằng chỉ mục của nó.
3. Xác định một mảng các chiều rộng cột bằng điểm.
4. Xác định một mảng các chiều cao hàng bằng điểm.
5. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) vào slide thông qua phương thức [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) .
6. Lặp qua từng [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) để áp dụng định dạng cho các viền trên, dưới, phải và trái.
7. Hợp nhất hai ô đầu tiên của hàng đầu tiên của bảng.
8. Truy cập ô đã hợp nhất thông qua phương thức [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) .
9. Đặt văn bản trong ô đã hợp nhất.
10. Lưu bản trình bày đã sửa đổi.

Ví dụ dưới đây tạo một bảng có ba cột và năm hàng tại (100, 50) điểm. Nó áp dụng viền màu đỏ có độ rộng 5 điểm, hợp nhất hai ô đầu tiên trong hàng đầu tiên, và lưu kết quả dưới dạng `table.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICCell.h>
#include <DOM/Table/ICCellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Đánh số trong bảng tiêu chuẩn**

Trong một bảng tiêu chuẩn, chỉ số ô bắt đầu từ 0 và sử dụng thứ tự (cột, hàng). Ô đầu tiên có chỉ số (0, 0).

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ví dụ này tạo bảng 4 × 4 như hình trên, với chiều rộng cột và chiều cao hàng là 70 điểm và viền ô màu đỏ có độ rộng 5 điểm. Các tọa độ minh họa chỉ số ô; ví dụ để các ô trống và lưu bảng dưới dạng `StandardTables_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Truy cập một bảng hiện có**

Bảng được lưu trong bộ sưu tập shape của slide. Duyệt qua các shape để tìm bảng, sau đó sử dụng giao diện [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) để đọc hoặc cập nhật các ô của nó.

1. Tải bản trình bày bằng cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide chứa bảng bằng chỉ mục của nó.
3. Duyệt qua các đối tượng [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) và dừng khi tìm thấy một bảng. Nếu slide chứa nhiều bảng, sử dụng [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) để xác định bảng bạn cần.
4. Cập nhật văn bản trong ô mục tiêu.
5. Lưu bản trình bày đã sửa đổi.

Ví dụ dưới đây mở `UpdateExistingTable.pptx` và tìm bảng đầu tiên trên slide đầu tiên. Nó đặt ô tại cột 0, hàng 1 thành `New` và lưu kết quả dưới dạng `table1_out.pptx`. Tệp đầu vào phải chứa ít nhất một slide, và bảng đầu tiên trên slide đó phải có ít nhất một cột và hai hàng.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

Để thay đổi kích thước hàng trong một bảng hiện có và hiểu tại sao chiều cao thực tế có thể vượt quá mức tối thiểu yêu cầu, xem [Kiểm soát chiều cao hàng](/slides/vi/cpp/manage-rows-and-columns/#control-row-height).

## **Tìm ô sở hữu khung văn bản**

Khi mã xử lý văn bản chung nhận được một [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) từ một bảng, sử dụng [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) để lấy [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) sở hữu. Đối với khung văn bản ô bảng, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) trả về chủ sở hữu và [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) trả về `nullptr`, mặc dù bảng tự nó là một shape.

Các tọa độ ô có sẵn qua các phương thức chỉ đọc [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) và [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/). [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) cũng cung cấp khả năng điều hướng chỉ đọc: nó trả về chủ sở hữu nhưng không thay đổi quyền sở hữu. Luôn kiểm tra ô trả về xem có phải `nullptr` trước khi sử dụng.

Đối với một ví dụ hoàn chỉnh xác định chủ sở hữu ô bảng và shape, bao gồm các shape liên kết với nút SmartArt, xem [Tìm kiếm và Thay thế Văn bản](/slides/vi/cpp/search-and-replace-text/).

## **Căn chỉnh văn bản trong bảng**

Bạn có thể điều khiển việc neo dọc và hướng văn bản của các ô bảng riêng lẻ. Ví dụ trong phần này căn giữa văn bản trong ô đầu tiên và xoay nó 270 độ.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide bằng chỉ mục của nó.
3. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) vào slide.
4. Truy cập một đối tượng [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) từ bảng.
5. Truy cập [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) đầu tiên và đặt văn bản và màu sắc cho nó.
6. Đặt việc neo dọc và hướng văn bản của ô bằng cách sử dụng [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) và [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/) .
7. Lưu bản trình bày đã sửa đổi.

Ví dụ này tạo một bảng 4 × 4 với chiều rộng cột 120 điểm và chiều cao hàng 100 điểm. Nó định dạng văn bản trong ô (0, 0), thêm giá trị vào các ô còn lại trong hàng đầu tiên, và lưu kết quả dưới dạng `Vertical_Align_Text_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Đặt định dạng văn bản ở mức bảng**

Sử dụng [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) để áp dụng định dạng văn bản cho tất cả các ô trong bảng. Các overload của nó chấp nhận định dạng phần, đoạn và khung văn bản, vì vậy bạn có thể đặt các thuộc tính này mà không cần lặp qua từng ô.

1. Tải bản trình bày bằng cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Lấy một tham chiếu tới slide bằng chỉ mục của nó.
3. Truy cập một đối tượng [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) từ slide.
4. Đặt kích thước phông bằng cách sử dụng [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) cho văn bản.
5. Đặt căn chỉnh đoạn và lề phải bằng cách sử dụng [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) và [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) .
6. Đặt hướng văn bản bằng cách sử dụng [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) .
7. Lưu bản trình bày đã sửa đổi.

Ví dụ dưới đây mở `table.pptx`, tệp này phải chứa ít nhất một slide với một bảng là shape đầu tiên. Nó đặt kích thước phông chữ thành 25 điểm, căn phải các đoạn với lề phải 20 điểm, và đặt văn bản theo chiều dọc. Bản trình bày đã định dạng được lưu dưới dạng `result.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Lấy thuộc tính kiểu bảng**

Sử dụng [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) để đọc kiểu preset của bảng và [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) để gán nó. Ví dụ này áp dụng [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) cho một bảng, in ra tên preset và gán cùng preset cho bảng thứ hai. Cả hai bảng đều được lưu trong `table-style.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **Khóa tỷ lệ khung hình của bảng**

Tỷ lệ khung hình của bảng là tỷ lệ giữa chiều rộng và chiều cao của nó. Sử dụng [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) để khóa tỷ lệ này cho một bảng.

Ví dụ dưới đây mở `pres.pptx`, tệp này phải chứa ít nhất một slide với một bảng là shape đầu tiên. Nó in trạng thái khóa hiện tại, bật khóa tỷ lệ khung hình, in trạng thái cập nhật (`True`), và lưu kết quả dưới dạng `pres-out.pptx`.

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Tôi có thể bật hướng đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô của nó không?**

Có. Bảng cung cấp phương thức [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) , và các đoạn có [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/) . Sử dụng cả hai đảm bảo thứ tự RTL đúng và việc hiển thị bên trong các ô.

**Làm thế nào để ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong tệp cuối cùng?**

Sử dụng [shape locks](/slides/vi/cpp/applying-protection-to-presentation/) để vô hiệu hoá việc di chuyển, thay đổi kích thước, chọn, vv. Các khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn hình ảnh vào bên trong ô làm nền không?**

Có. Bạn có thể đặt một [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) cho ô; hình ảnh sẽ bao phủ khu vực ô theo chế độ đã chọn (kéo dài hoặc lát).