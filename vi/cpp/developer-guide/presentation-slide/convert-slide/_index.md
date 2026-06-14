---
title: Chuyển đổi slide bản trình bày thành hình ảnh trong C++
linktitle: Slide sang Hình ảnh
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
- bản trình bày
- C++
- Aspose.Slides
description: "Chuyển đổi các slide từ PPT, PPTX và ODP sang hình ảnh trong C++ bằng Aspose.Slides—độ render nhanh, chất lượng cao với các ví dụ mã rõ ràng."
---
## **Giới thiệu**

Aspose.Slides for C++ cho phép bạn dễ dàng chuyển đổi các slide PowerPoint và OpenDocument thành nhiều định dạng hình ảnh khác nhau, bao gồm BMP, PNG, JPG (JPEG), GIF và các định dạng khác.

Để chuyển đổi một slide thành hình ảnh, làm theo các bước sau:

1. Xác định các cài đặt chuyển đổi mong muốn và chọn các slide bạn muốn xuất bằng cách sử dụng:
    - giao diện [ITiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/itiffoptions/) hoặc
    - giao diện [IRenderingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/irenderingoptions/).
2. Tạo hình ảnh slide bằng cách gọi phương thức [GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/getimage/).

Một [Bitmap](https://reference.aspose.com/slides/vi/cpp/system.drawing/bitmap/) là một đối tượng cho phép bạn làm việc với các hình ảnh được xác định bằng dữ liệu pixel. Bạn có thể sử dụng một thể hiện của lớp này để lưu hình ảnh ở nhiều định dạng khác nhau (BMP, JPG, PNG, v.v.).

## **Chuyển đổi Slide thành Bitmap và Lưu Hình Ảnh ở Định Dạng PNG**

Bạn có thể chuyển đổi một slide thành đối tượng bitmap và sử dụng trực tiếp trong ứng dụng của mình. Ngoài ra, bạn cũng có thể chuyển đổi slide thành bitmap và sau đó lưu hình ảnh ở định dạng JPEG hoặc bất kỳ định dạng nào bạn muốn.

Đoạn mã C++ dưới đây minh họa cách chuyển đổi slide đầu tiên của một bản trình bày thành đối tượng bitmap và sau đó lưu hình ảnh dưới định dạng PNG:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Chuyển đổi slide đầu tiên trong bản trình bày thành bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Lưu hình ảnh dưới định dạng PNG.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Chuyển đổi Slide thành Hình Ảnh với Kích Thước Tùy Chỉnh**

Bạn có thể cần có một hình ảnh với kích thước nhất định. Sử dụng một phiên bản overload của [GetImage](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islide/getimage/), bạn có thể chuyển đổi slide thành hình ảnh với các kích thước cụ thể (chiều rộng và chiều cao).

Đoạn mã mẫu dưới đây minh họa cách thực hiện:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Chuyển đổi slide đầu tiên trong bản trình bày thành bitmap với kích thước được chỉ định.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Lưu hình ảnh dưới định dạng JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Chuyển đổi Slide có Ghi Chú và Bình Luận thành Hình Ảnh**

Một số slide có thể chứa ghi chú và bình luận.

Aspose.Slides cung cấp hai giao diện—[ITiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/itiffoptions/) và [IRenderingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/irenderingoptions/)—cho phép bạn kiểm soát việc render các slide của bản trình bày thành hình ảnh. Cả hai giao diện đều bao gồm phương thức `set_SlidesLayoutOptions`, cho phép bạn cấu hình việc render ghi chú và bình luận trên một slide khi chuyển đổi thành hình ảnh.

Với lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notescommentslayoutingoptions/), bạn có thể chỉ định vị trí mong muốn cho ghi chú và bình luận trong hình ảnh kết quả.

Đoạn mã C++ dưới đây minh họa cách chuyển đổi một slide có ghi chú và bình luận:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Đặt vị trí của ghi chú.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Đặt vị trí của bình luận.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Đặt độ rộng của vùng bình luận.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Đặt màu cho vùng bình luận.

// Create the rendering options.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Convert the first slide of the presentation to an image.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Save the image in the GIF format.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
Trong bất kỳ quá trình chuyển đổi slide sang hình ảnh nào, phương thức [set_NotesPosition](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) không thể áp dụng `BottomFull` (để chỉ định vị trí cho ghi chú) vì văn bản của ghi chú có thể quá dài, khiến nó không thể vừa trong kích thước ảnh đã chỉ định.
{{% /alert %}} 

## **Chuyển đổi Slide thành Hình Ảnh bằng Tùy Chọn TIFF**

Giao diện [ITiffOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/itiffoptions/) cung cấp khả năng kiểm soát tốt hơn đối với hình ảnh TIFF kết quả bằng cách cho phép bạn chỉ định các tham số như kích thước, độ phân giải, bảng màu và hơn thế nữa.

Đoạn mã C++ dưới đây minh họa một quá trình chuyển đổi trong đó các tùy chọn TIFF được sử dụng để xuất một hình ảnh đen trắng với độ phân giải 300 DPI và kích thước 2160 × 2800:

```cpp 
// Tải tệp bản trình bày.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Lấy slide đầu tiên từ bản trình bày.
auto slide = presentation->get_Slide(0);

// Cấu hình các thiết lập cho hình ảnh TIFF đầu ra.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Đặt kích thước hình ảnh.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Đặt định dạng pixel (đen trắng).
tiffOptions->set_DpiX(300);                                         // Đặt độ phân giải ngang.
tiffOptions->set_DpiY(300);                                         // Đặt độ phân giải dọc.

// Chuyển đổi slide thành hình ảnh với các tùy chọn đã chỉ định.
auto image = slide->GetImage(tiffOptions);

// Lưu hình ảnh dưới định dạng TIFF.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Chuyển đổi Tất Cả Slide thành Hình Ảnh**

Aspose.Slides cho phép bạn chuyển đổi tất cả các slide trong một bản trình bày thành hình ảnh, hiệu quả là chuyển toàn bộ bản trình bày thành một chuỗi hình ảnh.

Đoạn mã mẫu dưới đây minh họa cách chuyển đổi tất cả các slide trong một bản trình bày thành hình ảnh bằng C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Render bản trình bày thành các hình ảnh từng slide.
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

## **Câu Hỏi Thường Gặp**

**Aspose.Slides có hỗ trợ render slide có hoạt ảnh không?**

Không, phương thức `GetImage` chỉ lưu một hình ảnh tĩnh của slide, không có hoạt ảnh.

**Có thể xuất các slide ẩn thành hình ảnh không?**

Có, các slide ẩn có thể được xử lý giống như các slide bình thường. Chỉ cần chắc chắn chúng được bao gồm trong vòng lặp xử lý.

**Có thể lưu hình ảnh kèm bóng và hiệu ứng không?**

Có, Aspose.Slides hỗ trợ render bóng, độ trong suốt và các hiệu ứng đồ họa khác khi lưu slide dưới dạng hình ảnh.