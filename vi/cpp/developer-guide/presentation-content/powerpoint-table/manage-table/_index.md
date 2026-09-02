---
title: Quản lý bảng trình chiếu trong C++
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
description: "Tạo và chỉnh sửa bảng trong các slide PowerPoint bằng Aspose.Slides cho C++. Khám phá các ví dụ mã đơn giản để tối ưu hoá quy trình làm việc với bảng."
---
## **Giới thiệu**

Bảng trong PowerPoint là một cách hiệu quả để hiển thị và trình bày thông tin. Thông tin trong lưới các ô (được sắp xếp thành hàng và cột) rất rõ ràng và dễ hiểu.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/cpp/aspose.slides/table/) , giao diện [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) , lớp [Cell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/cell/) , giao diện [ICell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icell/) và các kiểu khác để cho phép bạn tạo, cập nhật và quản lý bảng trong mọi loại bài thuyết trình. 

## **Tạo bảng từ đầu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Xác định một mảng `columnWidth`.
4. Xác định một mảng `rowHeight`.
5. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) vào slide thông qua phương thức [AddTable()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addtable/) .
6. Duyệt qua từng [ICell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icell/) để áp dụng định dạng cho các viền trên, dưới, phải và trái.
7. Hợp nhất hai ô đầu tiên của hàng đầu tiên của bảng. 
8. Truy cập vào [TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textframe/) của một [ICell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icell/) .
9. Thêm một số văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textframe/) .
10. Lưu bản trình bày đã sửa đổi.

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
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

// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
auto pres = System::MakeObject<Presentation>();

// Truy cập slide đầu tiên
auto sld = pres->get_Slides()->idx_get(0);

// Xác định các cột với độ rộng và các hàng với chiều cao
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Thêm một hình dạng bảng vào slide
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Đặt định dạng viền cho mỗi ô
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
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
// Hợp nhất các ô 1 và 2 của hàng 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Thêm một số văn bản vào ô đã hợp nhất
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Lưu bản trình bày vào đĩa
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Đánh số trong bảng chuẩn**

Trong một bảng chuẩn, việc đánh số các ô rất đơn giản và bắt đầu từ 0. Ô đầu tiên trong bảng có chỉ số là 0,0 (cột 0, hàng 0). 

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Đoạn mã C++ này cho thấy cách chỉ định đánh số cho các ô trong bảng:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Tạo một đối tượng lớp Presentation đại diện cho tệp PPTX
auto pres = System::MakeObject<Presentation>();

// Truy cập slide đầu tiên
auto sld = pres->get_Slides()->idx_get(0);

// Xác định các cột với độ rộng và các hàng với chiều cao
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Thêm một hình dạng bảng vào slide
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Đặt định dạng viền cho mỗi ô
for (const auto& row : tbl->get_Rows())
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

// Lưu bản trình chiếu vào đĩa
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Truy cập bảng đã tồn tại**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu tới slide chứa bảng thông qua chỉ số của nó. 
3. Tạo một đối tượng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) và đặt nó thành null.
4. Duyệt qua tất cả các đối tượng [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/) cho đến khi tìm thấy bảng.

   Nếu bạn cho rằng slide đang xử lý chỉ chứa một bảng, bạn có thể đơn giản kiểm tra tất cả các hình dạng nó chứa. Khi một hình dạng được xác định là bảng, bạn có thể ép kiểu nó thành đối tượng [Table](https://reference.aspose.com/slides/vi/cpp/aspose.slides/table/) . Nhưng nếu slide chứa nhiều bảng, bạn nên tìm kiếm bảng cần thiết thông qua phương thức [set_AlternativeText()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/set_alternativetext/) .
5. Sử dụng đối tượng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) để làm việc với bảng. Trong ví dụ dưới đây, chúng tôi đã thêm một hàng mới vào bảng.
6. Lưu bản trình bày đã sửa đổi.

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// Truy cập slide đầu tiên
auto sld = pres->get_Slides()->idx_get(0);

// Khởi tạo Table null
System::SharedPtr<ITable> tbl;

// Duyệt qua các shape và đặt tham chiếu tới bảng được tìm thấy
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Đặt văn bản cho cột đầu tiên của hàng thứ hai
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Lưu bản trình chiếu đã sửa đổi vào đĩa
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Tìm ô sở hữu một khung văn bản**

Khi mã xử lý văn bản chung nhận được một [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) từ bảng, sử dụng [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/get_parentcell/) để lấy [ICell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icell/) sở hữu. Đối với khung văn bản trong ô bảng, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/get_parentcell/) trả về chủ sở hữu và [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/get_parentshape/) trả về `nullptr`, mặc dù bảng tự nó là một hình dạng.

Các tọa độ của ô có thể truy cập thông qua các phương thức chỉ‑đọc [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icell/get_firstcolumnindex/) và [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icell/get_firstrowindex/) . [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/get_parentcell/) cũng cung cấp khả năng điều hướng chỉ‑đọc: nó trả về chủ sở hữu nhưng không thay đổi quyền sở hữu. Luôn kiểm tra ô trả về có phải `nullptr` trước khi sử dụng.

Đối với ví dụ hoàn chỉnh xác định chủ sở hữu ô bảng và hình dạng, bao gồm các hình dạng liên kết với nút SmartArt, xem [Search and Replace Text](/slides/vi/cpp/search-and-replace-text/) .

## **Căn chỉnh văn bản trong bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) vào slide. 
4. Truy cập vào đối tượng [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) từ bảng. 
5. Truy cập [IParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/) của [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) .
6. Căn chỉnh văn bản theo chiều dọc.
7. Lưu bản trình bày đã sửa đổi.

```c++
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
#include <DOM/ISlideCollection.h>
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

// Tạo một thực thể của lớp Presentation
auto presentation = System::MakeObject<Presentation>();

// Lấy slide đầu tiên
auto slide = presentation->get_Slides()->idx_get(0);

// Xác định các cột với độ rộng và các hàng với chiều cao
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Thêm hình dạng bảng vào slide
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Truy cập khung văn bản
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Tạo đối tượng Paragraph cho khung văn bản
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Tạo đối tượng Portion cho đoạn văn
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Căn chỉnh văn bản theo chiều dọc
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Lưu Presentation vào đĩa
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Đặt định dạng văn bản ở mức độ bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Truy cập vào đối tượng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) từ Slide.
4. Đặt [set_FontHeight()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseportionformat/set_fontheight/) cho văn bản. 
5. Đặt [set_Alignment()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_alignment/) và [set_MarginRight()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_marginright/) .
6. Đặt [set_TextVerticalType()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textframeformat/set_textverticaltype/) .
7. Lưu bản trình bày đã sửa đổi. 

Đoạn mã C++ này cho thấy cách áp dụng các tùy chọn định dạng ưa thích cho văn bản trong bảng:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Tạo một thực thể của lớp Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Giả sử rằng hình dạng đầu tiên trên slide đầu tiên là một bảng
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Đặt kích thước font cho các ô của bảng
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Đặt căn chỉnh văn bản và lề phải cho các ô của bảng trong một lần gọi
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Đặt loại văn bản theo chiều dọc cho các ô của bảng
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Lấy thuộc tính kiểu bảng**

Aspose.Slides cho phép bạn truy xuất các thuộc tính kiểu cho một bảng để bạn có thể sử dụng các chi tiết này cho một bảng khác hoặc ở nơi khác. Đoạn mã C++ này cho thấy cách lấy các thuộc tính kiểu từ một kiểu bảng có sẵn:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Khóa tỉ lệ khung hình của bảng**

Tỷ lệ khung hình của một hình học là tỉ lệ kích thước của nó ở các chiều khác nhau. Aspose.Slides cung cấp thuộc tính `AspectRatioLocked()` để cho phép bạn khóa cài đặt tỷ lệ khung hình cho bảng và các hình dạng khác. 

Đoạn mã C++ này cho thấy cách khóa tỉ lệ khung hình cho một bảng:

```c++
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Câu hỏi thường gặp**

**Tôi có thể bật chế độ đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô của nó không?**

Có. Bảng cung cấp phương thức [set_RightToLeft](https://reference.aspose.com/slides/vi/cpp/aspose.slides/table/set_righttoleft/) và các đoạn văn có [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/vi/cpp/aspose.slides/paragraphformat/set_righttoleft/) . Sử dụng cả hai sẽ đảm bảo thứ tự và hiển thị RTL đúng bên trong các ô.

**Làm sao tôi có thể ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong tệp cuối cùng?**

Sử dụng [shape locks](/slides/vi/cpp/applying-protection-to-presentation/) để vô hiệu hoá việc di chuyển, thay đổi kích thước, lựa chọn, v.v. Các khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn ảnh vào bên trong một ô dưới dạng nền không?**

Có. Bạn có thể đặt một [picture fill](https://reference.aspose.com/slides/vi/cpp/aspose.slides/picturefillformat/) cho ô; ảnh sẽ phủ hết vùng ô theo chế độ đã chọn (kéo giãn hoặc lặp).