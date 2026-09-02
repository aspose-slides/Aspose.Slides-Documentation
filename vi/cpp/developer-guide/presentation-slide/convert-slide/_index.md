---
title: Chuyển đổi các slide trình chiếu sang hình ảnh trong C++
linktitle: Slide sang hình ảnh
type: docs
weight: 41
url: /vi/cpp/convert-slide/
keywords:
- chuyển đổi slide
- xuất slide
- slide sang hình ảnh
- lưu slide dưới dạng hình ảnh
- slide sang PNG
- slide sang JPEG
- slide sang bitmap
- slide sang TIFF
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Chuyển đổi các slide từ PPT, PPTX và ODP sang hình ảnh trong C++ bằng Aspose.Slides—độ render nhanh, chất lượng cao với các ví dụ mã rõ ràng."
---
## **Giới thiệu**

Aspose.Slides for C++ cho phép bạn dễ dàng chuyển đổi các slide trình chiếu PowerPoint và OpenDocument sang nhiều định dạng hình ảnh khác nhau, bao gồm BMP, PNG, JPG (JPEG), GIF và các định dạng khác.

Để chuyển đổi một slide thành hình ảnh, làm theo các bước sau:

1. Xác định các cài đặt chuyển đổi mong muốn và chọn các slide bạn muốn xuất bằng cách sử dụng:
    - Giao diện [ITiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/itiffoptions/),
    - Giao diện [IRenderingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/irenderingoptions/).
2. Tạo hình ảnh slide bằng cách gọi phương thức [GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/getimage/).

Một [Bitmap](https://reference.aspose.com/slides/vi/cpp/system.drawing/bitmap/) là một đối tượng cho phép bạn làm việc với các hình ảnh được định nghĩa bằng dữ liệu pixel. Bạn có thể sử dụng một thực thể của lớp này để lưu các hình ảnh ở nhiều định dạng khác nhau (BMP, JPG, PNG, v.v.).

## **Chuyển đổi Slide thành Bitmap và Lưu Hình ảnh dưới dạng PNG**

Bạn có thể chuyển đổi một slide thành đối tượng bitmap và sử dụng trực tiếp trong ứng dụng của mình. Hoặc, bạn có thể chuyển đổi slide thành bitmap và sau đó lưu hình ảnh dưới dạng JPEG hoặc bất kỳ định dạng nào khác mà bạn muốn.

Đoạn mã C++ sau minh họa cách chuyển đổi slide đầu tiên của một bản trình chiếu thành đối tượng bitmap và sau đó lưu hình ảnh dưới định dạng PNG:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Convert the first slide in the presentation to a bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Save the image in the PNG format.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Chuyển đổi Slide thành Hình ảnh với Kích thước Tùy chỉnh**

Bạn có thể cần một hình ảnh có kích thước nhất định. Bằng cách sử dụng một overload của [GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/getimage/), bạn có thể chuyển đổi một slide thành hình ảnh với các kích thước cụ thể (chiều rộng và chiều cao).

Đoạn mã mẫu sau minh họa cách thực hiện điều này:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Chuyển đổi slide đầu tiên trong bản trình chiếu thành bitmap với kích thước được chỉ định.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Lưu hình ảnh dưới định dạng JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Chuyển đổi Slide có Ghi chú và Bình luận thành Hình ảnh**

Một số slide có thể chứa ghi chú và bình luận.

Aspose.Slides cung cấp hai giao diện—[ITiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/itiffoptions/) và [IRenderingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/irenderingoptions/)—cho phép bạn kiểm soát quá trình render các slide trình chiếu thành hình ảnh. Cả hai giao diện đều bao gồm phương thức `set_SlidesLayoutOptions`, giúp bạn cấu hình việc render ghi chú và bình luận trên một slide khi chuyển đổi nó thành hình ảnh.

Với lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notescommentslayoutingoptions/), bạn có thể chỉ định vị trí mong muốn cho ghi chú và bình luận trong hình ảnh kết quả.

Đoạn mã C++ dưới đây minh họa cách chuyển đổi một slide có ghi chú và bình luận:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Tải tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Đặt vị trí của ghi chú.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Đặt vị trí của bình luận.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Đặt độ rộng của khu vực bình luận.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Đặt màu cho khu vực bình luận.

// Tạo các tùy chọn render.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Chuyển đổi slide đầu tiên của bản trình chiếu thành hình ảnh.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Lưu hình ảnh dưới định dạng GIF.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
Trong bất kỳ quá trình chuyển đổi slide sang hình ảnh, phương thức [set_NotesPosition](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) không thể áp dụng `BottomFull` (để chỉ định vị trí cho ghi chú) vì nội dung ghi chú có thể quá lớn, khiến nó không thể vừa trong kích thước hình ảnh đã chỉ định.
{{% /alert %}} 

## **Chuyển đổi Slide thành Hình ảnh bằng Tùy chọn TIFF**

Giao diện [ITiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/itiffoptions/) cung cấp khả năng kiểm soát tốt hơn đối với hình ảnh TIFF kết quả bằng cách cho phép bạn chỉ định các tham số như kích thước, độ phân giải, bảng màu và nhiều hơn nữa.

Đoạn mã C++ dưới đây minh họa một quá trình chuyển đổi trong đó các tùy chọn TIFF được sử dụng để xuất một hình ảnh đen trắng với độ phân giải 300 DPI và kích thước 2160 × 2800:

```cpp 
// Tải tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Lấy slide đầu tiên từ bản trình chiếu.
auto slide = presentation->get_Slide(0);

// Cấu hình các cài đặt của hình ảnh TIFF đầu ra.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Đặt kích thước hình ảnh.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Đặt định dạng pixel (đen và trắng).
tiffOptions->set_DpiX(300);                                         // Đặt độ phân giải ngang.
tiffOptions->set_DpiY(300);                                         // Đặt độ phân giải dọc.

// Chuyển đổi slide thành hình ảnh với các tùy chọn đã chỉ định.
auto image = slide->GetImage(tiffOptions);

// Lưu hình ảnh dưới định dạng TIFF.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Chuyển đổi Tất cả Slide thành Hình ảnh**

Aspose.Slides cho phép bạn chuyển đổi tất cả các slide trong một bản trình chiếu thành hình ảnh, hiệu quả là chuyển đổi toàn bộ bản trình chiếu thành một loạt các hình ảnh.

Đoạn mã mẫu dưới đây minh họa cách chuyển đổi tất cả các slide trong một bản trình chiếu thành hình ảnh bằng C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Render bản trình chiếu thành các hình ảnh slide theo slide.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Kiểm soát các slide ẩn (không render các slide ẩn).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Chuyển đổi slide thành hình ảnh.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Lưu hình ảnh dưới định dạng JPEG.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Hiển thị Emoji Màu**

{{% alert title="Note" color="warning" %}} 
Để hiển thị đúng emoji màu khi chuyển đổi slide trình chiếu thành hình ảnh, các phông chữ emoji được sử dụng trong bản trình chiếu phải được cài đặt và có sẵn trên hệ thống thực hiện chuyển đổi. Ví dụ, nếu bản trình chiếu sử dụng **Segoe UI Emoji** và phông chữ này thiếu, emoji có thể hiển thị dưới dạng monochrome trong các hình ảnh đầu ra.
{{% /alert %}} 

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ render các slide có hoạt ảnh không?**  
Không, phương thức `GetImage` chỉ lưu một hình ảnh tĩnh của slide, không có hoạt ảnh.

**Có thể xuất slide ẩn dưới dạng hình ảnh không?**  
Có, các slide ẩn có thể được xử lý giống như các slide thường. Chỉ cần chắc chắn chúng được bao gồm trong vòng lặp xử lý.

**Có thể lưu hình ảnh có bóng và hiệu ứng không?**  
Có, Aspose.Slides hỗ trợ render bóng đổ, độ trong suốt và các hiệu ứng đồ họa khác khi lưu các slide dưới dạng hình ảnh.