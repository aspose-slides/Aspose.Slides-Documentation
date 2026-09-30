---
title: Quản lý các hàng và cột trong bảng PowerPoint bằng C++
linktitle: Hàng và Cột
type: docs
weight: 20
url: /vi/cpp/manage-rows-and-columns/
keywords:
- hàng bảng
- cột bảng
- hàng đầu tiên
- đầu đề bảng
- nhân bản hàng
- nhân bản cột
- sao chép hàng
- sao chép cột
- xóa hàng
- xóa cột
- định dạng văn bản hàng
- định dạng văn bản cột
- kiểu bảng
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Quản lý các hàng và cột của bảng trong PowerPoint với Aspose.Slides cho C++ và tăng tốc việc chỉnh sửa bản trình bày cũng như cập nhật dữ liệu."
---
## **Giới thiệu**

Aspose.Slides for C++ cho phép bạn quản lý cấu trúc và định dạng bảng trong các bản trình bày PowerPoint thông qua lớp [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) và giao diện [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Bạn có thể chỉ định hàng tiêu đề, sao chép hoặc xóa các hàng và cột, và áp dụng định dạng văn bản cho toàn bộ hàng hoặc cột.

Bài viết này giải thích các thao tác này bằng các ví dụ C++. Nó cũng chỉ ra cách lấy trước kiểu dáng của bảng để bạn có thể tái sử dụng. Chỉ số hàng và cột của bảng bắt đầu từ 0.

## **Kiểm soát chiều cao hàng**

Sử dụng [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) để đặt chiều cao tối thiểu của một hàng tính bằng điểm. Đây là giới hạn dưới, không phải chiều cao cố định. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) trả về chiều cao thực tế; giá trị này không thể được đặt trực tiếp. Truy cập hàng thông qua [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/).

Ví dụ tải [row-height-input.pptx](row-height-input.pptx), trong đó có một bảng là hình dạng đầu tiên trên slide đầu tiên. Hàng đầu tiên của nó bắt đầu ở 70 điểm. Các ô sử dụng văn bản Arial 18 điểm, cho phép ngắt dòng và lề trên dưới 6 điểm; văn bản dài hơn trong cột thứ hai được ngắt dòng thành nhiều dòng. Ví dụ tăng tối thiểu lên 100 điểm, sau đó giảm xuống 20 điểm, in ra chiều cao thực tế sau mỗi thay đổi và lưu cả hai kết quả.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

Với bản trình bày được cung cấp, việc tăng tối thiểu sẽ thêm không gian vào hàng. Việc giảm nó sẽ loại bỏ không gian thừa, nhưng chiều cao thực tế vẫn lớn hơn 20 điểm vì văn bản và lề ô cần thêm không gian. Chỉ giảm tối thiểu không thể ép hàng xuống dưới không gian mà nội dung yêu cầu.

Một số yếu tố ảnh hưởng đến chiều cao thực tế:

- **Văn bản và kích thước phông:** văn bản dài hơn, ngắt dòng rõ ràng, hoặc phông chữ lớn hơn có thể yêu cầu nhiều không gian theo chiều dọc.
- **Ngắt dòng và độ rộng cột:** khi bật ngắt dòng, giảm độ rộng cột bằng [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) có thể tạo ra nhiều dòng hơn. Cột rộng hơn có thể giảm không gian cần thiết theo chiều dọc.
- **Lề ô:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) và [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) kiểm soát các lề thêm không gian theo chiều dọc. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) và [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) kiểm soát các lề giảm độ rộng có sẵn cho văn bản và có thể gây ngắt dòng thêm.

Đối với bảng này không có ô hợp nhất, ô cần không gian theo chiều dọc nhiều nhất quyết định giới hạn dưới do nội dung gây ra cho toàn bộ hàng. Để làm hàng ngắn hơn, bạn có thể cần rút ngắn văn bản, giảm kích thước phông hoặc lề, hoặc tăng độ rộng cột.

Các hình ảnh bên dưới hiển thị cùng một bảng với cùng tỷ lệ. Trong bản chạy .NET tham chiếu được hiển thị ở đây, chiều cao thực tế là 70, 100 và 55,2 điểm: hàng cuối vẫn cao hơn mức tối thiểu 20 điểm. Các đo lường văn bản chính xác có thể thay đổi tùy vào phông chữ có sẵn trong môi trường của bạn. Tải xuống các kết quả đã lưu: [increased minimum](row-height-increased.pptx) và [decreased minimum](row-height-decreased.pptx).

| Gốc: tối thiểu 70 pt, thực tế 70 pt | Tăng: tối thiểu 100 pt, thực tế 100 pt | Giảm: tối thiểu 20 pt, thực tế 55.2 pt |
| --- | --- | --- |
| ![Bảng gốc với hàng đầu tiên 70 điểm.](row-height-before.png) | ![Bảng sau khi tăng tối thiểu hàng đầu tiên lên 100 điểm.](row-height-increased.png) | ![Bảng sau khi giảm tối thiểu hàng đầu tiên xuống 20 điểm; văn bản ngắt dòng giữ cho hàng cao hơn mức tối thiểu.](row-height-decreased.png) |

## **Đặt hàng đầu tiên làm tiêu đề**

Sử dụng phương thức [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) để đánh dấu hàng đầu tiên cho định dạng tiêu đề. Giao diện của nó phụ thuộc vào kiểu bảng được áp dụng cho bảng.

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Truy cập bảng được lưu dưới dạng hình dạng đầu tiên trên slide.
4. Bật định dạng tiêu đề cho hàng đầu tiên của nó.
5. Lưu bản trình bày đã sửa đổi.

Ví dụ yêu cầu `table.pptx` có một bảng là hình dạng đầu tiên trên slide đầu tiên. Nó bật định dạng tiêu đề cho hàng đầu tiên và lưu thành `First_row_header.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **Sao chép một hàng hoặc cột bảng**

Sao chép các hàng hoặc cột để tái sử dụng nội dung và định dạng của chúng. Bạn có thể thêm bản sao vào cuối bảng hoặc chèn vào vị trí cụ thể.

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Xác định độ rộng cột và chiều cao hàng.
4. Thêm bảng bằng phương thức [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Sao chép các hàng yêu cầu.
6. Sao chép các cột yêu cầu.
7. Lưu bản trình bày đã sửa đổi.

Ví dụ yêu cầu `Test.pptx` có ít nhất một slide. Nó tạo một bảng với ba cột và năm hàng, với các kích thước được chỉ định bằng điểm. Nó thêm các bản sao của hàng và cột đầu tiên, sau đó chèn các bản sao của hàng và cột thứ hai tại chỉ số 3 (vị trí thứ tư). Bảng kết quả có bẩy hàng và năm cột. Đối số `false` tắt việc sao chép vào các hàng hoặc cột hợp nhất liền kề; bảng này không có ô hợp nhất.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Xóa một hàng hoặc cột khỏi bảng**

Xóa các hàng hoặc cột không còn cần thiết trong một bảng. Khi xóa một mục, chỉ số của các hàng hoặc cột phía sau nó sẽ dịch chuyển.

1. Tạo một bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Xác định độ rộng cột và chiều cao hàng.
4. Thêm bảng bằng phương thức [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Xóa hàng thứ hai và cột thứ hai.
6. Lưu bản trình bày đã sửa đổi.

Ví dụ này tạo một bảng ba‑bằng‑ba và xóa hàng và cột tại chỉ số 1, để lại một bảng hai‑bằng‑hai trong `TestTable_out.pptx`. Các kích thước tính bằng điểm. Đối số `false` tắt việc xóa các hàng hoặc cột hợp nhất liền kề; bảng này không có ô hợp nhất.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **Đặt định dạng văn bản ở mức hàng bảng**

Áp dụng định dạng văn bản cho toàn bộ hàng để giữ các ô nhất quán. Bạn có thể đặt thuộc tính phông, định dạng đoạn và hướng văn bản mà không cần định dạng từng ô riêng lẻ.

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Truy cập bảng trên slide đầu tiên.
3. Đặt chiều cao phông bằng [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) cho hàng đầu tiên.
4. Đặt căn chỉnh và lề đoạn bên phải bằng [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) và [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) cho hàng đầu tiên.
5. Đặt hướng văn bản bằng [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) cho hàng thứ hai.
6. Lưu bản trình bày đã sửa đổi.

Ví dụ yêu cầu `table.pptx` có một bảng là hình dạng đầu tiên trên slide đầu tiên và ít nhất hai hàng. Nó áp dụng văn bản 25 điểm, căn phải và lề đoạn phải 20 điểm cho hàng đầu tiên, sau đó đặt văn bản dọc cho hàng thứ hai.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **Đặt định dạng văn bản ở mức cột bảng**

Áp dụng định dạng văn bản cho toàn bộ cột để giữ các ô nhất quán. Bạn có thể đặt thuộc tính phông, định dạng đoạn và hướng văn bản mà không cần định dạng từng ô riêng lẻ.

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Truy cập bảng trên slide đầu tiên.
3. Đặt chiều cao phông bằng [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) cho cột đầu tiên.
4. Đặt căn chỉnh và lề đoạn bên phải bằng [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) và [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) cho cột đầu tiên.
5. Đặt hướng văn bản bằng [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) cho cột thứ hai.
6. Lưu bản trình bày đã sửa đổi.

Ví dụ yêu cầu `table.pptx` có một bảng là hình dạng đầu tiên trên slide đầu tiên và ít nhất hai cột. Nó áp dụng văn bản 25 điểm, căn phải và lề đoạn phải 20 điểm cho cột đầu tiên, sau đó đặt văn bản dọc cho cột thứ hai.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **Lấy thuộc tính kiểu bảng**

Sử dụng phương thức [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) để lấy trước kiểu đã áp dụng cho một bảng và tái sử dụng nó cho bảng khác. Điều này xác định trước kiểu thay vì ghi đè định dạng từng ô.

Ví dụ tạo một bảng, áp dụng [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/), và đọc lại trước kiểu. Nó in ra `DarkStyle1` và lưu bảng trong `table.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Có thể áp dụng chủ đề/kiểu PowerPoint cho một bảng đã tạo chưa?**

Có. Bảng sẽ kế thừa chủ đề slide/layout/master, và bạn vẫn có thể ghi đè màu nền, viền và màu văn bản trên chủ đề đó.

**Bạn có thể sắp xếp các hàng bảng giống như trong Excel không?**

Không, các bảng Aspose.Slides không có tính năng sắp xếp hoặc bộ lọc tích hợp. Hãy sắp xếp dữ liệu trong bộ nhớ trước, sau đó điền lại các hàng bảng theo thứ tự đó.

**Bạn có thể có các cột sọc (banded) trong khi vẫn giữ màu tùy chỉnh cho các ô cụ thể không?**

Có. Bật cột sọc, sau đó ghi đè các ô cụ thể bằng định dạng cục bộ; định dạng ở mức ô sẽ ưu tiên hơn kiểu bảng.