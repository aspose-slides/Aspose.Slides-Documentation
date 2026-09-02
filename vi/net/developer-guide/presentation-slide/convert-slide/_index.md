---
title: Chuyển đổi các slide trình chiếu sang ảnh trong .NET
linktitle: Slide sang Ảnh
type: docs
weight: 41
url: /vi/net/convert-slide/
keywords:
- chuyển đổi slide
- xuất slide
- slide sang ảnh
- lưu slide dưới dạng ảnh
- slide sang PNG
- slide sang JPEG
- slide sang bitmap
- slide sang TIFF
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các slide từ PPT, PPTX và ODP sang ảnh trong C# bằng Aspose.Slides for .NET—nhanh, render chất lượng cao với các ví dụ mã rõ ràng."
---
## **Giới thiệu**

Aspose.Slides for .NET cho phép bạn dễ dàng chuyển đổi các slide PowerPoint và OpenDocument sang nhiều định dạng ảnh, bao gồm BMP, PNG, JPG (JPEG), GIF và các định dạng khác.

Để chuyển đổi một slide thành ảnh, thực hiện các bước sau:

1. Xác định các cài đặt chuyển đổi mong muốn và chọn các slide bạn muốn xuất bằng cách sử dụng:
    - Giao diện [ITiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/itiffoptions/) hoặc
    - Giao diện [IRenderingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/irenderingoptions/) 
2. Tạo ảnh slide bằng cách gọi phương thức [GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/).

Trong .NET, một [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) là một đối tượng cho phép bạn làm việc với các ảnh được định nghĩa bằng dữ liệu pixel. Bạn có thể sử dụng một thể hiện của lớp này để lưu ảnh ở nhiều định dạng (BMP, JPG, PNG, v.v.).

## **Chuyển đổi Slide sang Bitmap và Lưu Ảnh dưới dạng PNG**

Bạn có thể chuyển đổi một slide thành đối tượng bitmap và sử dụng trực tiếp trong ứng dụng của mình. Hoặc, bạn có thể chuyển đổi một slide thành bitmap và sau đó lưu ảnh dưới dạng JPEG hoặc bất kỳ định dạng nào bạn muốn.

Mã C# dưới đây minh họa cách chuyển đổi slide đầu tiên của một bản trình bày thành đối tượng bitmap và sau đó lưu ảnh ở định dạng PNG:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Chuyển đổi slide đầu tiên trong bản trình bày thành bitmap.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // Lưu ảnh dưới định dạng PNG.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **Chuyển đổi Slide sang Ảnh với Kích thước Tùy chỉnh**

Bạn có thể cần có một ảnh có kích thước nhất định. Bằng cách sử dụng một overload của [GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/), bạn có thể chuyển đổi một slide thành ảnh với kích thước cụ thể (chiều rộng và chiều cao).

Đoạn mã mẫu dưới đây minh họa cách thực hiện:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Chuyển đổi slide đầu tiên trong bản trình bày thành bitmap với kích thước đã chỉ định.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // Lưu ảnh dưới định dạng JPEG.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Chuyển đổi Slide có Ghi chú và Bình luận sang Ảnh**

Một số slide có thể chứa ghi chú và bình luận.

Aspose.Slides cung cấp hai giao diện—[ITiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/itiffoptions/) và [IRenderingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/irenderingoptions/)—cho phép bạn kiểm soát việc render các slide trình chiếu thành ảnh. Cả hai giao diện đều bao gồm thuộc tính `SlidesLayoutOptions`, cho phép bạn cấu hình việc render ghi chú và bình luận trên một slide khi chuyển đổi thành ảnh.

Với lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/notescommentslayoutingoptions/), bạn có thể chỉ định vị trí mong muốn cho ghi chú và bình luận trong ảnh kết quả.

Mã C# dưới đây minh họa cách chuyển đổi một slide có ghi chú và bình luận:

```cs
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Tạo các tùy chọn render.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Đặt vị trí của ghi chú.
            CommentsPosition = CommentsPositions.Right,      // Đặt vị trí của bình luận.
            CommentsAreaWidth = 500,                         // Đặt chiều rộng của vùng bình luận.
            CommentsAreaColor = Color.AntiqueWhite           // Đặt màu cho vùng bình luận.
        }
    };

    // Chuyển đổi slide đầu tiên của bản trình bày thành ảnh.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // Lưu ảnh dưới định dạng GIF.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Lưu ý" color="warning" %}} 
Trong bất kỳ quá trình chuyển đổi slide sang ảnh nào, thuộc tính [NotesPosition](https://reference.aspose.com/slides/vi/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) không thể được đặt thành `BottomFull` (để chỉ định vị trí cho ghi chú) vì văn bản ghi chú có thể quá lớn, khiến nó không thể vừa trong kích thước ảnh đã chỉ định.
{{% /alert %}} 

## **Chuyển đổi Slide sang Ảnh bằng Tùy chọn TIFF**

Giao diện [ITiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/itiffoptions/) cung cấp khả năng kiểm soát tốt hơn đối với ảnh TIFF đầu ra bằng cách cho phép bạn chỉ định các tham số như kích thước, độ phân giải, bảng màu và hơn thế nữa.

Mã C# dưới đây minh họa quy trình chuyển đổi trong đó các tùy chọn TIFF được sử dụng để xuất một ảnh đen‑trắng với độ phân giải 300 DPI và kích thước 2160 × 2800:

```cs
// Tải tệp trình chiếu.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Lấy slide đầu tiên từ bản trình bày.
    ISlide slide = presentation.Slides[0];

    // Cấu hình các cài đặt của ảnh TIFF đầu ra.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // Đặt kích thước ảnh.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Đặt định dạng pixel (đen và trắng).
        DpiX = 300,                                        // Đặt độ phân giải theo chiều ngang.
        DpiY = 300                                         // Đặt độ phân giải theo chiều dọc.
    };

    // Chuyển đổi slide thành ảnh với các tùy chọn đã chỉ định.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Lưu ảnh dưới định dạng TIFF.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **Chuyển đổi Tất cả Slide sang Ảnh**

Aspose.Slides cho phép bạn chuyển đổi tất cả các slide trong một bản trình bày thành ảnh, thực tế chuyển đổi toàn bộ bản trình bày thành một loạt các ảnh.

Đoạn mã mẫu dưới đây minh họa cách chuyển đổi tất cả các slide trong một bản trình bày thành ảnh bằng C#:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Render bản trình chiếu thành ảnh từng slide.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // Kiểm soát các slide ẩn (không render các slide Ẩn).
        if (presentation.Slides[i].Hidden)
            continue;

        // Chuyển đổi slide thành ảnh.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // Lưu ảnh dưới định dạng JPEG.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **Hiển thị Emoji Màu**

{{% alert title="Lưu ý" color="warning" %}} 
Để render emoji màu đúng cách khi chuyển đổi slide trình chiếu thành ảnh, các phông chữ emoji được sử dụng trong bản trình bày phải được cài đặt và có sẵn trên hệ thống thực hiện chuyển đổi. Ví dụ, nếu bản trình bày sử dụng **Segoe UI Emoji** và phông chữ này thiếu, emoji có thể xuất hiện ở dạng đơn màu trong các ảnh đầu ra.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ hiển thị slide có hoạt ảnh không?**

Không, phương thức `GetImage` chỉ lưu một ảnh tĩnh của slide, không có hoạt ảnh.

**Có thể xuất slide ẩn dưới dạng ảnh không?**

Có, các slide ẩn có thể được xử lý giống như các slide thường. Chỉ cần đảm bảo chúng được bao gồm trong vòng xử lý.

**Có thể lưu ảnh với bóng đổ và hiệu ứng không?**

Có, Aspose.Slides hỗ trợ render bóng đổ, độ trong suốt và các hiệu ứng đồ họa khác khi lưu slide dưới dạng ảnh.