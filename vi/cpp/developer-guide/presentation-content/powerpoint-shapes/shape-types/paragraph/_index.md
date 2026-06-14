---
title: Lấy giới hạn đoạn văn từ bản trình chiếu trong C++
linktitle: Đoạn văn
type: docs
weight: 60
url: /vi/cpp/paragraph/
keywords:
- giới hạn đoạn văn
- giới hạn phần văn bản
- tọa độ đoạn văn
- tọa độ phần văn bản
- kích thước đoạn văn
- kích thước phần văn bản
- khung văn bản
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn đoạn văn và phần văn bản trong Aspose.Slides cho C++ để tối ưu vị trí văn bản trong các bản trình chiếu PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách lấy giới hạn, kích thước và tọa độ của các đoạn văn và phần văn bản trong Aspose.Slides. Nó cho thấy cách truy xuất hình chữ nhật của một đoạn văn trong `TextFrame` bằng cách sử dụng `GetRect()`, cách lấy tọa độ đoạn văn và phần văn bản bên trong khung văn bản của ô bảng, và nêu bật các chi tiết quan trọng như đơn vị đo lường, ảnh hưởng của việc bao text tới giới hạn, chuyển đổi sang pixel, và các giá trị định dạng đoạn văn “hiệu quả”.

## **Lấy tọa độ đoạn văn và phần văn bản trong TextFrame**
Sử dụng Aspose.Slides cho C++, các nhà phát triển hiện có thể lấy tọa độ hình chữ nhật cho Paragraph trong bộ sưu tập paragraphs của TextFrame. Nó cũng cho phép bạn lấy tọa độ của portion trong bộ sưu tập portion của một đoạn văn. Trong chủ đề này, chúng tôi sẽ trình bày bằng một ví dụ cách lấy tọa độ hình chữ nhật cho đoạn văn cùng với vị trí của portion trong một đoạn văn.

## **Lấy tọa độ hình chữ nhật của một Paragraph**
Phương thức mới **GetRect()** đã được thêm vào. Nó cho phép lấy hình chữ nhật giới hạn của đoạn văn.

``` cpp
// Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình chiếu
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Lấy kích thước của Paragraph và Portion trong TextFrame của ô bảng**

Để lấy kích thước và tọa độ của [Portion](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.portion) hoặc [Paragraph](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.paragraph) trong khung văn bản của ô bảng, bạn có thể sử dụng các phương thức [IPortion::GetRect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) và [IParagraph::GetRect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t).

Mã mẫu sau minh họa thao tác đã mô tả:

``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```

## **FAQ**

**Các tọa độ trả về cho đoạn văn và phần văn bản được đo bằng đơn vị gì?**

Bằng điểm, trong đó 1 inch = 72 điểm. Điều này áp dụng cho tất cả các tọa độ và kích thước trên slide.

**Việc bao text có ảnh hưởng đến giới hạn của đoạn văn không?**

Có. Nếu [wrapping](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textframeformat/set_wraptext/) được bật trong [TextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/textframe/), văn bản sẽ ngắt để phù hợp với chiều rộng vùng, làm thay đổi giới hạn thực tế của đoạn văn.

**Có thể ánh xạ tọa độ đoạn văn sang pixel trong hình ảnh xuất ra một cách đáng tin cậy không?**

Có. Chuyển đổi điểm sang pixel bằng công thức: pixels = points × (DPI / 72). Kết quả phụ thuộc vào DPI được chọn cho việc render/xuất.

**Làm thế nào để lấy các tham số định dạng đoạn văn “hiệu quả”, tính đến kế thừa kiểu?**

Sử dụng [cấu trúc dữ liệu định dạng đoạn văn hiệu quả](/slides/vi/cpp/shape-effective-properties/); nó trả về các giá trị cuối cùng đã được hợp nhất cho thụt lề, khoảng cách, bao text, RTL, và các thiết lập khác.