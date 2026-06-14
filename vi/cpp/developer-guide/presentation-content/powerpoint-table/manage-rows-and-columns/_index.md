---
title: Quản lý hàng và cột trong bảng PowerPoint bằng C++
linktitle: Hàng và Cột
type: docs
weight: 20
url: /vi/cpp/manage-rows-and-columns/
keywords:
- hàng bảng
- cột bảng
- hàng đầu tiên
- tiêu đề bảng
- sao chép hàng
- sao chép cột
- sao chép hàng
- sao chép cột
- xóa hàng
- xóa cột
- định dạng văn bản hàng
- định dạng văn bản cột
- kiểu bảng
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Quản lý các hàng và cột của bảng trong PowerPoint với Aspose.Slides cho C++ và tăng tốc việc chỉnh sửa bản trình chiếu cũng như cập nhật dữ liệu."
---
## **Giới thiệu**

Để cho phép bạn quản lý các hàng và cột của bảng trong bản trình chiếu PowerPoint, Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/cpp/aspose.slides/table/) , giao diện [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) và nhiều kiểu khác. 

## **Đặt hàng đầu tiên làm tiêu đề**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) và tải bản trình chiếu. 
2. Lấy tham chiếu đến slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) và đặt nó thành null. 
4. Duyệt qua tất cả các đối tượng [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishape/) để tìm bảng liên quan. 
5. Đặt hàng đầu tiên của bảng làm tiêu đề. 

Mã C++ sau cho thấy cách đặt hàng đầu tiên của bảng làm tiêu đề:

```c++
// Khởi tạo lớp Presentation 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// Truy cập slide đầu tiên
auto sld = pres->get_Slides()->idx_get(0);

// Khởi tạo TableEx null
SharedPtr<ITable> tbl;

// Duyệt qua các shape và đặt tham chiếu đến bảng
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// Đặt hàng đầu tiên của bảng làm tiêu đề 
tbl->set_FirstRow(true);
```

## **Sao chép hàng hoặc cột của bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) và tải bản trình chiếu, 
2. Lấy tham chiếu đến slide thông qua chỉ mục của nó. 
3. Định nghĩa một mảng `columnWidth`. 
4. Định nghĩa một mảng `rowHeight`. 
5. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) vào slide bằng phương thức [AddTable()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addtable/). 
6. Sao chép hàng của bảng. 
7. Sao chép cột của bảng. 
8. Lưu bản trình chiếu đã sửa đổi. 

Mã C++ sau cho thấy cách sao chép hàng hoặc cột của bảng PowerPoint:

```c++
 // Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/CloningInTable_out.pptx";

// Khởi tạo lớp Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Định nghĩa các cột với độ rộng và các hàng với chiều cao
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Thêm một shape bảng vào slide
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// Đặt định dạng viền cho mỗi ô
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
	SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
	for (int y = 0; y < row->get_Count(); y++)
	{
		SharedPtr<ICell> cell = row->idx_get(y);

		cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderTop()->set_Width(5);

		cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderBottom()->set_Width(5);

		cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderLeft()->set_Width(5);

		cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderRight()->set_Width(5);

	}

}

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

//AddClone thêm một hàng vào cuối bảng
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

//InsertClone thêm một hàng vào vị trí cụ thể trong bảng
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

//AddClone thêm một cột vào cuối bảng
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

//InsertClone thêm một cột vào vị trí cụ thể trong bảng
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// Lưu bản trình chiếu ra đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Xóa hàng hoặc cột khỏi bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) và tải bản trình chiếu, 
2. Lấy tham chiếu đến slide thông qua chỉ mục của nó. 
3. Định nghĩa một mảng `columnWidth`. 
4. Định nghĩa một mảng `rowHeight`. 
5. Thêm một đối tượng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) vào slide bằng phương thức [AddTable()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addtable/). 
6. Xóa hàng của bảng. 
7. Xóa cột của bảng. 
8. Lưu bản trình chiếu đã sửa đổi. 

Mã C++ sau cho thấy cách xóa một hàng hoặc cột khỏi bảng:

```c++
// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Khởi tạo lớp Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Định nghĩa các cột với độ rộng và các hàng với chiều cao
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Thêm một shape bảng vào slide
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// Hợp nhất các ô (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Hợp nhất các ô (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Lưu bản trình chiếu ra đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Định dạng văn bản ở mức hàng của bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) và tải bản trình chiếu, 
2. Lấy tham chiếu đến slide thông qua chỉ mục của nó. 
3. Truy cập đối tượng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) liên quan từ slide. 
4. Đặt [set_FontHeight()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseportionformat/set_fontheight/) cho các ô ở hàng đầu tiên. 
5. Đặt [set_Alignment()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_alignment/) và [set_MarginRight()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_marginright/) cho các ô ở hàng đầu tiên. 
6. Đặt [set_TextVerticalType()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textframeformat/set_textverticaltype/) cho các ô ở hàng thứ hai. 
7. Lưu bản trình chiếu đã sửa đổi. 

Mã C++ sau minh họa thao tác này.

```c++
// Tạo một thể hiện của lớp Presentation
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Giả sử rằng shape đầu tiên trên slide đầu tiên là một bảng
// Đặt chiều cao phông chữ cho các ô của hàng đầu tiên
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// Đặt căn chỉnh văn bản và lề phải cho các ô của hàng đầu tiên
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// Đặt kiểu dọc của văn bản cho các ô của hàng thứ hai
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// Lưu bản trình chiếu ra đĩa
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Định dạng văn bản ở mức cột của bảng**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation) và tải bản trình chiếu, 
2. Lấy tham chiếu đến slide thông qua chỉ mục của nó. 
3. Truy cập đối tượng [ITable](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itable/) liên quan từ slide. 
4. Đặt [set_FontHeight()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/baseportionformat/set_fontheight/) cho các ô ở cột đầu tiên. 
5. Đặt [set_Alignment()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_alignment/) và [set_MarginRight()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraphformat/set_marginright/) cho các ô ở cột đầu tiên. 
6. Đặt [set_TextVerticalType()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textframeformat/set_textverticaltype/) cho các ô ở cột thứ hai. 
7. Lưu bản trình chiếu đã sửa đổi. 

Mã C++ sau minh họa thao tác:

```c++
// Tạo một thể hiện của lớp Presentation
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// Giả sử shape đầu tiên trên slide đầu tiên là một bảng

// Đặt chiều cao phông chữ cho các ô của cột đầu tiên
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// Đặt căn chỉnh văn bản và lề phải cho các ô của cột đầu tiên trong một lần gọi
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// Đặt kiểu dọc của văn bản cho các ô của cột thứ hai
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Lấy thuộc tính kiểu bảng**

Aspose.Slides cho phép bạn lấy các thuộc tính kiểu cho một bảng để bạn có thể sử dụng các chi tiết này cho bảng khác hoặc ở nơi khác. Mã C++ này cho thấy cách lấy các thuộc tính kiểu từ một kiểu bảng đã định sẵn:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng chủ đề/kiểu cho một bảng đã được tạo chưa?**

Có. Bảng sẽ kế thừa chủ đề của slide/bố cục/master, và bạn vẫn có thể ghi đè màu nền, đường viền và màu văn bản phía trên chủ đề đó.

**Tôi có thể sắp xếp các hàng của bảng giống như trong Excel không?**

Không, các bảng Aspose.Slides không có chức năng sắp xếp hay lọc tích hợp. Hãy sắp xếp dữ liệu trong bộ nhớ trước, sau đó điền lại các hàng của bảng theo thứ tự đó.

**Tôi có thể có các cột sọc (banded) đồng thời giữ màu tùy chỉnh cho các ô cụ thể không?**

Có. Bật chế độ cột sọc, sau đó ghi đè các ô cụ thể bằng định dạng cục bộ; định dạng ở cấp độ ô sẽ ưu tiên hơn kiểu bảng.