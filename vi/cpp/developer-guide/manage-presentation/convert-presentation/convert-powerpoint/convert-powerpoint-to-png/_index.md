---
title: Chuyển đổi các slide PowerPoint sang PNG trong C++
linktitle: PowerPoint sang PNG
type: docs
weight: 30
url: /vi/cpp/convert-powerpoint-to-png/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PNG
- bản trình chiếu sang PNG
- slide sang PNG
- PPT sang PNG
- PPTX sang PNG
- lưu PPT dưới dạng PNG
- lưu PPTX dưới dạng PNG
- xuất PPT sang PNG
- xuất PPTX sang PNG
- C++
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PowerPoint sang ảnh PNG chất lượng cao một cách nhanh chóng với Aspose.Slides cho C++, đảm bảo kết quả chính xác và tự động."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các slide trình chiếu sang hình ảnh PNG bằng Aspose.Slides cho C++. Bạn có thể tải các bản trình chiếu ở các định dạng như PPT, PPTX và ODP, render từng slide và lưu chúng dưới dạng hình ảnh PNG riêng biệt.

## **Chuyển đổi PowerPoint sang PNG**

Tải một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) và truy cập các slide của nó thông qua accessor [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/). Ví dụ này render mọi slide bằng [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) không có tham số để tạo thumbnail. Sau đó nó gọi [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) với [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) để lưu mỗi slide đã render dưới dạng hình ảnh PNG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Phiên bản overload không tham số của [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) render với tỉ lệ 0.2. Ví dụ, một slide có kích thước 720 × 540 điểm sẽ tạo ra một thumbnail 144 × 108 pixel. Để kiểm soát kích thước đầu ra, hãy sử dụng các overload với hệ số tỉ lệ hoặc kích thước ảnh rõ ràng như dưới đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Cung cấp hệ số tỉ lệ ngang và dọc cho [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) để kiểm soát kích thước đã render. Trong ví dụ này, cả hai hệ số đều bằng 2, vì vậy một slide có kích thước 720 × 540 điểm sẽ tạo ra hình ảnh 1440 × 1080 pixel. Các hệ số tỉ lệ bằng nhau giữ nguyên tỷ lệ khung hình của slide. Mỗi hình ảnh được lưu ở định dạng PNG bằng [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Để chỉ định kích thước đầu ra bằng pixel, truyền một kích thước cho [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) thay vì các hệ số tỉ lệ. Ví dụ này render mọi slide ở kích thước 960 × 720 pixel và lưu kết quả bằng [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). Chọn kích thước phù hợp với tỷ lệ khung hình của slide để tránh kéo dãn hình ảnh.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Chọn Kiểu Render Gradient**

Giả sử một slide chứa các vùng màu gradient, nhưng các chuyển đổi trong PNG đã xuất ra trông nhẹ hơn hoặc khác với những gì bạn thấy trong PowerPoint. Bạn có thể sử dụng phương thức [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) của [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) để chọn cách render gradient.

Tải xuống tệp [gradient-styles.pptx](gradient-styles.pptx) và đặt nó trong thư mục làm việc của ứng dụng. Slide đầu tiên của nó chứa hai gradient tuyến tính: xanh lục sang cam ở trên và xanh dương sang vàng ở dưới. Mỗi gradient có hai điểm dừng, tại 0% và 100%.

Ví dụ sau tải bản trình chiếu này và render slide đầu tiên trong cả hai chế độ bằng [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

| Default | PowerPointUI |
| --- | --- |
| ![Gradient xanh lục sang cam và xanh dương sang vàng được render bằng Default](gradient-Default.png) | ![Các gradient tương tự được render bằng PowerPointUI](gradient-PowerPointUI.png) |

Trong ví dụ này, `Default` tạo ra các màu trung gian nhẹ hơn, trong khi `PowerPointUI` tạo ra các màu trung gian tối hơn. Sự khác biệt phụ thuộc vào màu sắc và các điểm dừng trong gradient.

Chọn `Default` khi đầu ra tiêu chuẩn của Aspose.Slides đáp ứng nhu cầu của bạn. Thử `PowerPointUI` khi ưu tiên của bạn là khớp với giao diện trong PowerPoint. So sánh cả hai đầu ra với kết quả mong muốn; không có chế độ nào là ưu việt cho mọi trường hợp.

## **Câu hỏi thường gặp**

**Làm thế nào để tôi xuất một hình dạng cụ thể, như biểu đồ hoặc hình ảnh, thay vì toàn bộ slide?**

Aspose.Slides hỗ trợ [tạo thumbnail cho các hình dạng riêng lẻ](/slides/vi/cpp/shape-thumbnails/), cho phép bạn render một hình dạng dưới dạng hình ảnh PNG.

**Có hỗ trợ chuyển đổi song song trên máy chủ không?**

Có. Sử dụng một đối tượng presentation riêng cho mỗi luồng hoặc tiến trình; [không chia sẻ một thể hiện duy nhất giữa các luồng](/slides/vi/cpp/multithreading/).

**Các hạn chế trong chế độ đánh giá khi xuất sang PNG là gì?**

Chế độ đánh giá sẽ thêm watermark vào các hình ảnh đầu ra và áp dụng [các hạn chế khác](/slides/vi/cpp/licensing/) cho đến khi giấy phép được áp dụng.