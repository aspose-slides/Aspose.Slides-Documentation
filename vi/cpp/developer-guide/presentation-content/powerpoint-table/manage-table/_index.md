---
title: Quản lý Bảng trong Bản Trình Chiếu bằng C++
linktitle: Quản lý Bảng
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
- trình chiếu
- C++
- Aspose.Slides
description: "Tạo & chỉnh sửa bảng trong các slide PowerPoint với Aspose.Slides cho C++. Khám phá các ví dụ mã đơn giản để tối ưu quy trình làm việc với bảng."
---
## **Giới thiệu**

Bảng trong PowerPoint là một cách hiệu quả để hiển thị và mô tả thông tin. Thông tin trong lưới các ô (sắp xếp theo hàng và cột) rất đơn giản và dễ hiểu.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/cpp/aspose.slides/table/) , giao diện [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) , lớp [Cell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/cell/) , giao diện [ICell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icell/) và các kiểu khác để cho phép bạn tạo, cập nhật và quản lý bảng trong mọi kiểu trình chiếu. 

## **Tạo bảng từ đầu**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Định nghĩa một mảng `columnWidth` .
4. Định nghĩa một mảng `rowHeight` .
5. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) vào slide thông qua phương thức [AddTable()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addtable/) .
6. Duyệt qua mỗi [ICell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icell/) để áp dụng định dạng cho các đường viền trên, dưới, bên phải và bên trái.
7. Hợp nhất hai ô đầu tiên của hàng đầu tiên trong bảng. 
8. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textframe/) của một [ICell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icell/) .
9. Thêm một số văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textframe/) .
10. Lưu bản trình chiếu đã sửa đổi.

Đoạn mã C++ sau đây cho thấy cách tạo bảng trong một bản trình chiếu:

```c++
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
auto pres = System::MakeObject<Presentation>();

// Truy cập slide đầu tiên
auto sld = pres->get_Slides()->idx_get(0);

// Xác định các cột với độ rộng và các hàng với chiều cao
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Thêm một hình bảng vào slide
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

// Lưu bản trình chiếu vào đĩa
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Đánh số trong bảng tiêu chuẩn**

Trong một bảng tiêu chuẩn, việc đánh số các ô rất đơn giản và bắt đầu từ 0. Ô đầu tiên trong bảng có chỉ mục là 0,0 (cột 0, hàng 0). 

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Đoạn mã C++ sau đây cho thấy cách chỉ định đánh số cho các ô trong bảng:

```c++
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX
auto pres = System::MakeObject<Presentation>();

// Truy cập slide đầu tiên
auto sld = pres->get_Slides()->idx_get(0);

// Xác định các cột với độ rộng và các hàng với chiều cao
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Thêm một hình bảng vào slide
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

## **Truy cập bảng hiện có**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu tới slide chứa bảng thông qua chỉ mục của nó. 
3. Tạo một đối tượng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) và gán nó thành null.
4. Duyệt qua tất cả các đối tượng [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/) cho đến khi tìm được bảng.

   Nếu bạn nghi ngờ slide đang làm việc chứa một bảng duy nhất, bạn có thể simplement kiểm tra tất cả các shape trong nó. Khi một shape được xác định là bảng, bạn có thể ép kiểu nó thành đối tượng [Table](https://reference.aspose.com/slides/vi/cpp/aspose.slides/table/) . Nhưng nếu slide chứa nhiều bảng, thì tốt hơn nên tìm bảng bạn cần thông qua thuộc tính [set_AlternativeText()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/set_alternativetext/) .
5. Sử dụng đối tượng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) để làm việc với bảng. Trong ví dụ dưới đây, chúng tôi đã thêm một hàng mới vào bảng.
6. Lưu bản trình chiếu đã sửa đổi.

Đoạn mã C++ sau đây cho thấy cách truy cập và làm việc với một bảng hiện có:

```c++
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

## **Căn chỉnh văn bản trong bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) vào slide. 
4. Truy cập một đối tượng [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) từ bảng. 
5. Truy cập [IParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/) của [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) .
6. Căn chỉnh văn bản theo chiều dọc.
7. Lưu bản trình chiếu đã sửa đổi.

Đoạn mã C++ sau đây cho thấy cách căn chỉnh văn bản trong bảng:

```c++
// Tạo một thể hiện của lớp Presentation
auto presentation = System::MakeObject<Presentation>();

// Lấy slide đầu tiên 
auto slide = presentation->get_Slides()->idx_get(0);

// Xác định các cột với độ rộng và các hàng với chiều cao
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Thêm hình bảng vào slide
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
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Truy cập một đối tượng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) từ Slide.
4. Đặt [set_FontHeight()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseportionformat/set_fontheight/) cho văn bản. 
5. Đặt [set_Alignment()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_alignment/) và [set_MarginRight()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_marginright/) . 
6. Đặt [set_TextVerticalType()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textframeformat/set_textverticaltype/) .
7. Lưu bản trình chiếu đã sửa đổi. 

Đoạn mã C++ sau đây cho thấy cách áp dụng các tùy chọn định dạng ưa thích cho văn bản trong bảng:

```c++
// Tạo một thể hiện của lớp Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// Giả sử rằng shape đầu tiên trên slide đầu tiên là một bảng
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Đặt chiều cao phông chữ của các ô trong bảng
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Đặt căn chỉnh văn bản và lề phải của các ô trong bảng trong một lần gọi
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Đặt loại văn bản dọc của các ô trong bảng
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Lấy thuộc tính kiểu bảng**

Aspose.Slides cho phép bạn truy xuất các thuộc tính kiểu cho một bảng để bạn có thể sử dụng chi tiết đó cho bảng khác hoặc ở nơi khác. Đoạn mã C++ sau đây cho thấy cách lấy các thuộc tính kiểu từ một kiểu bảng đã định sẵn:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Khóa tỷ lệ khung hình của bảng**

Tỷ lệ khung hình của một hình dạng hình học là tỉ lệ kích thước của nó ở các chiều khác nhau. Aspose.Slides cung cấp thuộc tính `AspectRatioLocked()` để cho phép bạn khóa thiết lập tỷ lệ khung hình cho các bảng và các hình dạng khác. 

Đoạn mã C++ sau đây cho thấy cách khóa tỷ lệ khung hình cho một bảng:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Câu hỏi thường gặp**

**Tôi có thể bật chế độ đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô của nó không?**

Có. Bảng cung cấp phương thức [set_RightToLeft](https://reference.aspose.com/slides/vi/cpp/aspose.slides/table/set_righttoleft/) , và các đoạn văn có [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/vi/cpp/aspose.slides/paragraphformat/set_righttoleft/) . Sử dụng cả hai sẽ đảm bảo thứ tự RTL đúng và hiển thị bên trong các ô.

**Làm sao tôi có thể ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong file cuối cùng?**

Sử dụng [shape locks](/slides/vi/cpp/applying-protection-to-presentation/) để vô hiệu hoá việc di chuyển, thay đổi kích thước, chọn, v.v. Các khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn hình ảnh vào bên trong ô làm nền không?**

Có. Bạn có thể đặt một [picture fill](https://reference.aspose.com/slides/vi/cpp/aspose.slides/picturefillformat/) cho ô; hình ảnh sẽ bao phủ toàn bộ khu vực ô theo chế độ đã chọn (kéo giãn hoặc lát).