---
title: Chuyển đổi các slide PowerPoint sang PNG trong C++
linktitle: PowerPoint sang PNG
type: docs
weight: 30
url: /vi/cpp/convert-powerpoint-to-png/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PNG
- bản trình bày sang PNG
- slide sang PNG
- PPT sang PNG
- PPTX sang PNG
- lưu PPT dưới dạng PNG
- lưu PPTX dưới dạng PNG
- xuất PPT sang PNG
- xuất PPTX sang PNG
- C++
- Aspose.Slides
description: "Chuyển đổi các bản trình bày PowerPoint thành hình ảnh PNG chất lượng cao một cách nhanh chóng với Aspose.Slides cho C++, đảm bảo kết quả chính xác và tự động."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình bày PowerPoint sang hình ảnh PNG bằng Aspose.Slides. Nó cho thấy cách tải các tệp bản trình bày ở các định dạng như PPT, PPTX và ODP, hiển thị các slide dưới dạng hình ảnh và lưu kết quả ở định dạng PNG.

Bài viết cũng trình bày cách tùy chỉnh các hình ảnh PNG được tạo bằng cách đặt giá trị tỉ lệ hoặc chỉ định chiều rộng và chiều cao mong muốn.

## **Chuyển đổi PowerPoint sang PNG**

Thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation).
2. Lấy đối tượng slide từ bộ sưu tập [Presentation::get_Slides()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) dưới giao diện [ISlide](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_slide).
3. Sử dụng phương thức [ISlide::GetImage()](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/getimage) để lấy hình thu nhỏ cho mỗi slide.
4. Dùng phương thức [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) để lưu hình thu nhỏ của slide sang định dạng PNG.

Đoạn mã C++ sau cho thấy cách chuyển đổi bản trình bày PowerPoint sang PNG:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Nếu bạn muốn tạo các tệp PNG với một tỉ lệ nhất định, bạn có thể đặt các giá trị cho `desiredX` và `desiredY`, những giá trị này xác định kích thước của hình thu nhỏ kết quả.

Đoạn mã C++ dưới đây minh họa thao tác đã mô tả:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tuỳ ý**

Nếu bạn muốn tạo các tệp PNG với một kích thước cụ thể, bạn có thể truyền các đối số `width` và `height` mong muốn cho `ImageSize`.

Đoạn mã này cho thấy cách chuyển đổi PowerPoint sang PNG trong khi chỉ định kích thước cho các hình ảnh:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```

## **Câu hỏi thường gặp**

**Làm sao tôi có thể xuất chỉ một hình dạng cụ thể (ví dụ: biểu đồ hoặc ảnh) thay vì toàn bộ slide?**

Aspose.Slides hỗ trợ [tạo hình thu nhỏ cho các hình dạng riêng lẻ](/slides/vi/cpp/create-shape-thumbnails/); bạn có thể hiển thị một hình dạng dưới dạng hình ảnh PNG.

**Có hỗ trợ chuyển đổi song song trên máy chủ không?**

Có, nhưng [không chia sẻ](/slides/vi/cpp/multithreading/) một thể hiện bản trình bày duy nhất giữa các luồng. Sử dụng một thể hiện riêng cho mỗi luồng hoặc tiến trình.

**Các hạn chế của phiên bản dùng thử khi xuất sang PNG là gì?**

Chế độ đánh giá sẽ thêm một watermark vào các hình ảnh đầu ra và áp dụng [các hạn chế khác](/slides/vi/cpp/licensing/) cho đến khi có giấy phép.