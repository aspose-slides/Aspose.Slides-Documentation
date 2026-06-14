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
description: "Quản lý các ô bảng trong PowerPoint một cách dễ dàng với Aspose.Slides cho C++. Thành thạo việc truy cập, chỉnh sửa và tạo kiểu cho các ô nhanh chóng để tự động hoá slide liền mạch."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và chỉnh sửa các ô bảng trong bản trình bày PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa viền ô, làm việc với việc đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô và thêm hình ảnh bên trong ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bản trình bày, lấy bảng từ một slide, cập nhật định dạng ô thông qua các thuộc tính của ô, và lưu bản trình bày đã chỉnh sửa dưới dạng file PPTX.

## **Xác định ô đã hợp nhất**
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy bảng từ slide đầu tiên. 
3. Duyệt qua các hàng và cột của bảng để tìm các ô đã hợp nhất.
4. In ra thông báo khi phát hiện ô đã hợp nhất.

Đoạn mã C++ này cho bạn thấy cách xác định các ô bảng đã hợp nhất trong một bản trình bày:

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// assuming that Slide#0.Shape#0 is a table
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **Xóa viền ô bảng**
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Xác định một mảng các cột với độ rộng.
4. Xác định một mảng các hàng với chiều cao.
5. Thêm một bảng vào slide bằng phương thức `AddTable`.
6. Duyệt qua mọi ô để xóa viền trên, dưới, phải và trái.
7. Lưu bản trình bày đã chỉnh sửa dưới dạng file PPTX.

Đoạn mã C++ này cho bạn thấy cách xóa viền khỏi các ô bảng:

``` cpp
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
auto pres = MakeObject<Presentation>();
// Truy cập slide đầu tiên
auto sld = pres->get_Slides()->idx_get(0);

// Định nghĩa các cột với độ rộng và các hàng với chiều cao
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// Thêm hình dạng bảng vào slide
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Đặt định dạng viền cho mỗi ô
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// Ghi tệp PPTX ra đĩa
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Đánh số trong ô đã hợp nhất**
Nếu chúng ta hợp nhất 2 cặp ô (1, 1) x (2, 1) và (1, 2) x (2, 2), bảng kết quả sẽ được đánh số. Đoạn mã C# này minh họa quy trình:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// Tải bản trình bày mong muốn
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Định nghĩa các cột với độ rộng và các hàng với chiều cao
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Thêm hình dạng bảng vào slide
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
// Hợp nhất các ô (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Hợp nhất các ô (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Lưu tệp PPTX ra đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Sau đó chúng ta tiếp tục hợp nhất các ô bằng cách hợp nhất (1, 1) và (1, 2). Kết quả là một bảng chứa một ô hợp nhất lớn ở trung tâm: 

```c++
// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/MergeCells_out.pptx";

// Tải bản trình bày mong muốn
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Định nghĩa các cột với độ rộng và các hàng với chiều cao
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Thêm hình dạng bảng vào slide
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

// Hợp nhất các ô (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Hợp nhất các ô (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// Lưu tệp PPTX ra đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Đánh số trong ô đã tách**
Trong các ví dụ trước, khi các ô bảng được hợp nhất, hệ thống đánh số hoặc đánh số trong các ô khác không thay đổi. 

Lần này, chúng ta lấy một bảng thông thường (bảng không có ô hợp nhất) và sau đó cố gắng tách ô (1,1) để tạo ra một bảng đặc biệt. Bạn có thể muốn chú ý đến cách đánh số của bảng này, có thể sẽ có vẻ lạ. Tuy nhiên, đó là cách Microsoft PowerPoint đánh số các ô bảng và Aspose.Slides cũng làm tương tự. 

Đoạn mã C++ này minh họa quy trình mà chúng tôi mô tả:

```c++
// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/CellSplit_out.pptx";

// Tải bản trình bày mong muốn
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Định nghĩa các cột với độ rộng và các hàng với chiều cao
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// Thêm hình dạng bảng vào slide
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

// Hợp nhất các ô (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// Hợp nhất các ô (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// tách ô (1, 1). 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// Lưu tệp PPTX ra đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Thay đổi màu nền ô bảng**

Đoạn mã C++ này cho bạn thấy cách thay đổi màu nền của một ô bảng:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// tạo một bảng mới
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// đặt màu nền cho một ô 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Thêm hình ảnh vào trong ô bảng**
1. Tạo một thể hiện của lớp `Presentation`.
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Xác định một mảng các cột với độ rộng.
4. Xác định một mảng các hàng với chiều cao.
5. Thêm một bảng vào slide bằng phương thức `AddTable`. 
6. Tạo một đối tượng `Bitmap` để chứa tệp hình ảnh.
7. Thêm hình bitmap vào đối tượng `IPPImage`.
8. Đặt `FillFormat` cho Ô Bảng thành `Picture`.
9. Thêm hình ảnh vào ô đầu tiên của bảng.
10. Lưu bản trình bày đã chỉnh sửa dưới dạng file PPTX

Đoạn mã C# này cho bạn thấy cách đặt một hình ảnh vào trong ô bảng khi tạo bảng:

```c++
// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Tải bản trình bày mong muốn
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Truy cập slide đầu tiên
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// Định nghĩa các cột với độ rộng và các hàng với chiều cao
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// Thêm hình dạng bảng vào slide
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// Lấy hình ảnh
auto img = Images::FromFile(ImagePath);

// Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình bày
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// Thêm hình ảnh vào ô bảng đầu tiên
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// Lưu tệp PPTX ra đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Câu hỏi thường gặp**

**Có thể đặt độ dày và kiểu đường viền khác nhau cho các phía của một ô duy nhất không?**

Đúng. Các viền [top](https://reference.aspose.com/slides/vi/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/vi/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/vi/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/vi/cpp/aspose.slides/cellformat/get_borderright/) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi phía có thể khác nhau. Điều này hợp lý dựa trên việc kiểm soát viền từng phía cho một ô được trình bày trong bài viết.

**Điều gì xảy ra với hình ảnh nếu tôi thay đổi kích thước cột/hàng sau khi đặt một hình ảnh làm nền cho ô?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/vi/cpp/aspose.slides/picturefillmode/) (stretch/tile). Khi kéo dãn, hình ảnh sẽ điều chỉnh theo ô mới; khi lát, các ô ảnh sẽ được tính lại. Bài viết đề cập đến các chế độ hiển thị hình ảnh trong ô.

**Có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/cpp/manage-hyperlinks/) được đặt ở mức độ văn bản (phần) bên trong khung văn bản của ô hoặc ở mức độ toàn bộ bảng/hình dạng. Trong thực tế, bạn gán liên kết cho một phần hoặc cho toàn bộ văn bản trong ô.

**Có thể đặt các phông chữ khác nhau trong một ô duy nhất không?**

Đúng. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/portion/) (run) với định dạng độc lập — họ phông chữ, kiểu, kích thước và màu.