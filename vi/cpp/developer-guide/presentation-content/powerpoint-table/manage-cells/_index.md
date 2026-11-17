---
title: Quản lý các ô bảng trong bản trình bày bằng C++
linktitle: Quản lý Ô
type: docs
weight: 30
url: /vi/cpp/manage-cells/
keywords:
- ô bảng
- hợp nhất ô
- xóa viền
- tách ô
- hình ảnh trong ô
- màu nền
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Quản lý các ô bảng PowerPoint trong C++: xác định các ô đã hợp nhất, xóa viền, tách ô, và thiết lập màu nền cũng như hình ảnh bằng Aspose.Slides cho C++."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và sửa đổi các ô bảng trong bản trình bày PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa viền ô, làm việc với việc đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô, và thêm hình ảnh vào trong một ô bảng. Các ví dụ minh họa cách tạo hoặc mở một bản trình bày, lấy bảng từ một slide, cập nhật định dạng ô thông qua các thuộc tính của ô, và lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Aspose.Slides sử dụng chỉ mục bắt đầu từ 0 để truy cập các ô bảng theo thứ tự `(column, row)`.

## **Xác định Ô Bảng Đã Hợp Nhất**

Ví dụ mở một bản trình bày hiện có và truy cập hình dạng đầu tiên trên slide đầu tiên dưới dạng một bảng. Nó giả định rằng slide và hình dạng tồn tại và rằng hình dạng là một bảng. Sau đó nó lặp qua tất cả các hàng và cột và sử dụng [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) để xác định các ô trong vùng đã hợp nhất. Đối với mỗi kết quả phù hợp, nó in tọa độ ô theo thứ tự `row;column`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), và tọa độ bắt đầu của vùng, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) và [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

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

## **Xóa Viền Ô Bảng**

Tạo một [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) và thêm một bảng vào slide đầu tiên của nó bằng [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). Độ rộng cột, chiều cao hàng và vị trí bảng được chỉ định bằng điểm. Ví dụ đặt cả bốn viền ô thành [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), khiến chúng không hiển thị.

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

## **Thêm Viền Đường Chéo cho Ô**

Sử dụng [get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/) để vẽ một đường từ góc trên‑trái đến góc dưới‑phải, và [get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/) để vẽ một đường từ góc dưới‑trái đến góc trên‑phải. Đường chéo có thể đánh dấu tiêu đề góc; cả hai đường chéo có thể tạo thành hình X để đánh dấu một ô là không áp dụng.

Mỗi đường chéo là một [ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/). Sử dụng [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) để truy cập phần tô màu của nó, gọi [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/) với [FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) và chọn một màu qua [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/). Đặt độ rộng đường bằng [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) tính bằng điểm.

Ví dụ tạo ba ô trong một hàng: một đường chéo xuống màu đỏ, một đường chéo lên màu xanh dương, và cả hai đường chéo. Nó để nguyên các viền ô trên, dưới, trái và phải.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({210, 210, 210});
auto rowHeights = MakeArray<double>({160});
auto table = slide->get_Shapes()->AddTable(45, 130, columnWidths, rowHeights);

auto downwardBorder = table->idx_get(0, 0)->get_CellFormat()->get_BorderDiagonalDown();
downwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
downwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
downwardBorder->set_Width(3);

auto upwardBorder = table->idx_get(1, 0)->get_CellFormat()->get_BorderDiagonalUp();
upwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
upwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
upwardBorder->set_Width(5);

auto crossDownwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalDown();
crossDownwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossDownwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
crossDownwardBorder->set_Width(3);

auto crossUpwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalUp();
crossUpwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossUpwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
crossUpwardBorder->set_Width(5);

presentation->Save(u"diagonal_cell_borders.pptx", SaveFormat::Pptx);
```

Đường chéo là một thuộc tính định dạng, không phải là sự tách ô. Mỗi ô vẫn giữ một khung văn bản duy nhất được truy cập qua [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/); các vùng ở hai phía của đường chéo không thể chỉnh sửa độc lập.

Bảng đã lưu, được hiển thị trong Microsoft PowerPoint:

![Ba ô bảng hiển thị một đường chéo đỏ từ góc trên‑trái đến góc dưới‑phải, một đường chéo xanh dương từ góc dưới‑trái đến góc trên‑phải, và cả hai đường chéo tạo thành hình X.](diagonal-cell-borders.png)

*Trái sang phải: đường chéo xuống (đỏ, 3 pt), đường chéo lên (xanh dương, 5 pt), và cả hai đường chéo.*

## **Hợp Nhất Các Ô Bảng**

Sử dụng [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) để kết hợp một phạm vi hình chữ nhật các ô bảng thành một ô duy nhất. Chỉ định các ô ở góc trên‑trái và góc dưới‑phải của phạm vi. Đối số cuối cùng kiểm soát việc hợp nhất có cho phép bao gồm các ô nằm ngoài phạm vi đã chỉ định hay không; `false` giữ việc hợp nhất trong phạm vi đó.

Ví dụ tạo một bảng 4x4 với các cột và hàng có độ rộng/cao 70 điểm, sau đó hợp nhất bốn ô trung tâm từ `(1, 1)` đến `(2, 2)`. Ô kết quả chạy qua hai cột và hai hàng, trong khi lưới bảng cơ bản vẫn giữ bốn cột và bốn hàng. Để truy cập nội dung hoặc định dạng của ô đã hợp nhất, sử dụng vị trí góc trên‑trái của nó: `table->idx_get(1, 1)` trong ví dụ này. Các vị trí khác trong phạm vi hợp nhất vẫn là một phần của lưới bảng, vì vậy chỉ mục của các ô ngoài phạm vi không thay đổi.

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

## **Tách Các Ô Bảng**

Việc hợp nhất các ô trong ví dụ trước giữ nguyên lưới bảng. Tách một ô có thể tạo ra một cột lưới mới và thay đổi chỉ mục cột của các ô ở bên phải nó. Aspose.Slides tuân theo mô hình lưới bảng của PowerPoint.

Ví dụ này tạo một bảng 4x4 với các cột và hàng có độ rộng 70 điểm và gọi [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) trên ô `(1, 1)`. Một nửa độ rộng 70 điểm của ô được truyền để tạo hai ô có độ rộng bằng nhau.

Sau khi tách, hai nửa được truy cập dưới dạng `table->idx_get(1, 1)` và `table->idx_get(2, 1)`. Lưới bảng hiện có năm cột: các ô ban đầu ở cột 2 và 3 chuyển sang cột 3 và 4, tương ứng. Chỉ mục hàng không thay đổi. Sử dụng các chỉ mục cột đã cập nhật khi truy cập ô sau khi tách.

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

<!-- visual-explanation:manage-cells:start -->
[![Một ô 70 điểm chưa hợp nhất được tách thành hai ô 35 điểm, thêm một cột lưới thứ năm và đẩy các chỉ mục sang bên phải.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Việc tách độ rộng ảnh hưởng đến ô (1, 1), sử dụng chỉ mục bắt đầu từ 0 (cột, hàng). Các hàng khác giữ một ô kéo qua cả hai vị trí cột mới.*
<!-- visual-explanation:manage-cells:end -->

### **Tách Các Ô Đã Hợp Nhất theo Dải Hàng hoặc Cột**

Để chuẩn bị các ô mẫu đã hợp nhất cho việc điền dữ liệu, sử dụng [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) để tách dọc theo ranh giới hàng hiện có, hoặc [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) để tách dọc theo ranh giới cột.

`Tham số` `index` đếm các hàng ở phần trên hoặc các cột ở phần trái của việc tách; nó tương đối với vùng đã hợp nhất:

- Tách hàng: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Tách cột: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

Ví dụ yêu cầu bản trình bày có một bảng là hình dạng đầu tiên trên slide đầu tiên, với `(1, 2)` và `(1, 3)` được hợp nhất theo chiều dọc. Bắt đầu từ vị trí thấp hơn, nó sử dụng [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) và [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) để xác định nguồn gốc và kiểm tra cả hai dải. `SplitByRowSpan(1)` sau đó tách các hàng 2 và 3 cho tên sản phẩm. Đối với hợp nhất hai cột theo chiều ngang, sử dụng `SplitByColSpan(1)` thay thế.

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

Lưới bảng và các chỉ mục ô xung quanh vẫn không thay đổi. Lấy các ô kết quả theo tọa độ của chúng; ở đây, cả hai đều có dải là 1 và [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) in ra `False`. Các vùng lớn hơn có thể vẫn còn phần nào được hợp nhất sau một lần tách.

Văn bản gốc và định dạng của nó vẫn ở ô trên (hoặc trái); ô mới trống nhưng kế thừa định dạng ô như màu nền, viền và lề. Điền dữ liệu vào các ô sau khi tách và đặt bất kỳ định dạng văn bản nào yêu cầu một cách rõ ràng.

Bản trình bày đã lưu chứa các ô "Product A" và "Product B" riêng biệt với định dạng ô của mẫu được giữ lại. Xem [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) để biết chi tiết.

### **Tách Một Ô tại Chiều Cao Cụ Thể**

[SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/) nhận chiều cao của phần trên tính bằng điểm. [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) nhận số hàng lưới hiện có trong phần trên. Để căn giữa một ô 40 điểm trong cột phải, lấy tổng chiều cao thực của ô trừ 40 và chia phần còn lại đều ở trên và dưới ô.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/ITextFrame.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({160, 160});
auto rowHeights = MakeArray<double>({140});

auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Left");

auto height = table->idx_get(1, 0)->get_Height();
auto margin = (height - 40) / 2;

table->idx_get(1, 0)->SplitByHeight(margin);
table->idx_get(1, 1)->SplitByHeight(40);
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Middle");

presentation->Save(u"split_by_height.pptx", SaveFormat::Pptx);
```

Lần tách đầu tiên thêm một hàng lưới, để lại phần dưới 90 điểm ở `(1, 1)`. Lần tách thứ hai nhắm vào ô đó và thêm một hàng nữa bên dưới. Cột phải hiện chứa `(1, 0)` có độ cao 50 điểm (`margin`), `(1, 1)` có 40 điểm, và `(1, 2)` có 50 điểm (`margin`). Ô trái kéo qua cả ba hàng với chiều cao ban đầu là 140 điểm.

![Ô trái kéo qua toàn bộ chiều cao bảng bên cạnh ba ô có Middle ở trung tâm.](split-by-height.png)

## **Thay Đổi Màu Nền Ô Bảng**

Ví dụ này tạo một bảng với các cột 150 điểm và các hàng 50 điểm. Nó sử dụng [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) để chọn màu nền đặc và [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) để truy cập màu nền và đặt màu đỏ cho ô `(2, 3)`, ở cột thứ ba và hàng thứ tư.

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

## **Thêm Hình Ảnh Vào Trong Ô Bảng**

Đặt hình ảnh đầu vào trong thư mục làm việc trước khi chạy ví dụ này. Nó tải hình ảnh bằng [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/), và thêm nó vào bộ sưu tập hình ảnh của bản trình bày bằng [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Sau đó nó gán hình ảnh vào phần tô ảnh của ô `(0, 0)`, ô đầu tiên trong bảng.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) kéo dài hình ảnh để lấp đầy ô, có thể thay đổi tỷ lệ khung hình của nó. Độ rộng cột và chiều cao hàng tính bằng điểm. Hình ảnh đã tải sẽ được giải phóng sau khi đã được thêm vào bản trình bày.

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

## **Câu Hỏi Thường Gặp**

**Tôi có thể đặt độ dày và kiểu đường khác nhau cho các phía khác nhau của một ô duy nhất không?**

Có. Các viền [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi phía có thể khác nhau.

**Điều gì xảy ra với hình ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đã đặt một ảnh làm nền cho ô?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/). Khi kéo dài, hình ảnh sẽ điều chỉnh theo ô mới; khi lặp lại, các ô lặp sẽ được tính lại.

**Tôi có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/cpp/manage-hyperlinks/) được đặt ở mức văn bản (phần) bên trong khung văn bản của ô hoặc ở mức toàn bộ bảng/hình dạng. Trong thực tế, bạn gán liên kết cho một phần hoặc cho toàn bộ văn bản trong ô.

**Tôi có thể đặt các phông chữ khác nhau trong một ô duy nhất không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (các đoạn) với định dạng độc lập—họ họ font, kiểu, kích thước và màu sắc.