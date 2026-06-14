---
title: Ứng dụng Hello World sử dụng Aspose.Slides cho C++
type: docs
weight: 80
url: /vi/cpp/hello-world-application-using-aspose-slides/
keywords:
- xin chào thế giới
- ứng dụng
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tạo ứng dụng C++ đầu tiên của bạn với Aspose.Slides, một ví dụ Hello World đơn giản giúp bạn sẵn sàng tự động hóa các bản trình chiếu PPT, PPTX và ODP."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo một bản trình chiếu PowerPoint đơn giản **Hello World** bằng Aspose.Slides. Ví dụ minh họa cách tạo một bản trình chiếu mới, truy cập slide đầu tiên, thêm một AutoShape hình chữ nhật ở vị trí xác định, chèn một khung văn bản chứa văn bản **Hello World**, và điều chỉnh định dạng hình dạng và văn bản.

Nó cũng giải thích cách làm cho văn bản hiển thị bằng cách thay đổi màu thành màu đen, ẩn viền hình bằng cách đặt màu đường viền thành màu trắng, loại bỏ màu nền của hình và lưu bản trình chiếu dưới dạng tệp PPTX.

## **Các bước tạo ứng dụng Hello World**

- Tạo một thể hiện của lớp Presentation
- Lấy tham chiếu tới slide đầu tiên trong bản trình chiếu được tạo khi khởi tạo lớp Presentation.
- Thêm một AutoShape với ShapeType là Rectangle tại vị trí xác định trên slide.
- Thêm một TextFrame vào AutoShape chứa văn bản Hello World làm mặc định
- Thay đổi màu văn bản thành màu đen vì mặc định là màu trắng và không hiển thị trên slide có nền trắng
- Thay đổi màu đường viền của hình thành màu trắng để ẩn viền hình
- Xóa định dạng nền mặc định của hình
- Cuối cùng, ghi bản trình chiếu ra định dạng tệp mong muốn bằng đối tượng Presentation

Việc thực hiện các bước trên được thể hiện dưới đây trong một ví dụ.

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // lấy slide đầu tiên
    auto slide = pres->get_Slides()->idx_get(0);

    // thêm một AutoShape kiểu Hình chữ nhật
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // thêm TextFrame vào Hình chữ nhật
    shape->AddTextFrame(u"Hello World");

    // đổi màu văn bản thành Đen (mặc định là Trắng)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // đổi màu đường viền của hình chữ nhật thành Trắng
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // xóa mọi định dạng nền trong hình
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // lưu bản trình chiếu vào đĩa
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```