---
title: Lấy Giới Hạn Đoạn Văn Từ Bài Thuyết Trình Trong C++
linktitle: Giới Hạn Đoạn Văn
type: docs
weight: 43
url: /vi/cpp/paragraph-bounds/
keywords:
- giới hạn đoạn văn
- tọa độ đoạn văn
- kích thước đoạn văn
- khung văn bản
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tìm hiểu cách lấy giới hạn đoạn văn trong Aspose.Slides cho C++ để tối ưu vị trí văn bản trong các bài thuyết trình PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách lấy giới hạn, kích thước và tọa độ của các đoạn văn trong Aspose.Slides. Nó cho thấy cách lấy hình chữ nhật của đoạn văn từ một [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/) bằng cách sử dụng [IParagraph::GetRect](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/getrect/), cách lấy tọa độ đoạn văn trong khung văn bản của ô bảng, và nêu bật các chi tiết quan trọng như đơn vị đo, ảnh hưởng của việc ngắt dòng văn bản đến giới hạn, chuyển đổi sang pixel, và các giá trị định dạng đoạn văn “effective”.

## **Lấy tọa độ hình chữ nhật của một đoạn văn**

Sử dụng [IParagraph::GetRect](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/getrect/) để lấy hình chữ nhật bao quanh của một đoạn văn.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **Lấy kích thước của một đoạn văn bên trong khung văn bản ô bảng**

Để lấy kích thước và tọa độ của một [IParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/) trong khung văn bản của ô bảng, hãy sử dụng [IParagraph::GetRect](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iparagraph/getrect/). Hình chữ nhật trả về là tương đối so với khung văn bản của ô bảng, vì vậy hãy cộng vị trí bảng và độ dịch của ô khi bạn cần tọa độ ở mức slide.

Ví dụ sau đây lấy giới hạn của đoạn văn bên trong ô bảng và vẽ các hình chữ nhật trên slide để hiển thị các giới hạn đó:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Đơn vị đo của tọa độ đoạn văn là gì?**

Chúng được đo bằng điểm (point), trong đó 1 inch tương đương 72 điểm. Điều này áp dụng cho tất cả các tọa độ và kích thước trên slide.

**Việc ngắt từ có ảnh hưởng đến giới hạn của đoạn văn không?**

Có. Nếu [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframeformat/set_wraptext/) được bật cho [ITextFrame](https://reference.aspose.com/slides/vi/cpp/aspose.slides/itextframe/), văn bản sẽ được ngắt để phù hợp với độ rộng của khu vực, điều này làm thay đổi giới hạn thực tế của đoạn văn.

**Có thể ánh xạ tọa độ đoạn văn sang pixel trong hình ảnh xuất ra một cách đáng tin cậy không?**

Có. Chuyển đổi điểm sang pixel bằng công thức: pixel = điểm x (DPI / 72). Kết quả phụ thuộc vào DPI được chọn cho việc render hoặc xuất.

**Làm thế nào để tôi lấy các tham số định dạng đoạn văn “effective”, xét đến việc kế thừa kiểu?**

Sử dụng [cấu trúc dữ liệu định dạng đoạn văn hiệu quả](/slides/vi/cpp/shape-effective-properties/); nó trả về các giá trị hợp nhất cuối cùng cho các lề, khoảng cách, ngắt dòng, RTL và hơn thế nữa.