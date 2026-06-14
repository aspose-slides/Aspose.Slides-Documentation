---
title: Chuyển Đổi Slide Trình Chiếu Sang Hình Ảnh trong .NET
linktitle: Slide sang Hình ảnh
type: docs
weight: 41
url: /vi/net/convert-slide/
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
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi slide từ PPT, PPTX và ODP sang hình ảnh trong C# bằng Aspose.Slides cho .NET—độ render nhanh, chất lượng cao với các ví dụ mã rõ ràng."
---
## **Giới thiệu**

Aspose.Slides for .NET cho phép bạn dễ dàng chuyển đổi các slide trình chiếu PowerPoint và OpenDocument sang nhiều định dạng hình ảnh khác nhau, bao gồm BMP, PNG, JPG (JPEG), GIF và các định dạng khác.

Để chuyển đổi một slide thành hình ảnh, thực hiện các bước sau:

1. Xác định các cài đặt chuyển đổi mong muốn và chọn các slide bạn muốn xuất bằng cách sử dụng:
    - Giao diện [ITiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/itiffoptions/) hoặc
    - Giao diện [IRenderingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/irenderingoptions/).
2. Tạo hình ảnh slide bằng cách gọi phương thức [GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/).

Trong .NET, một [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) là một đối tượng cho phép bạn làm việc với hình ảnh được định nghĩa bằng dữ liệu pixel. Bạn có thể sử dụng một thể hiện của lớp này để lưu hình ảnh ở nhiều định dạng (BMP, JPG, PNG, v.v.).

## **Chuyển Đổi Slide Sang Bitmap Và Lưu Hình Ảnh Dưới Định Dạng PNG**

Bạn có thể chuyển đổi một slide thành đối tượng bitmap và sử dụng trực tiếp trong ứng dụng của mình. Ngoài ra, bạn cũng có thể chuyển đổi slide sang bitmap rồi lưu hình ảnh dưới định dạng JPEG hoặc bất kỳ định dạng nào bạn muốn.

Đoạn mã C# dưới đây minh họa cách chuyển đổi slide đầu tiên của một bản trình chiếu thành đối tượng bitmap và sau đó lưu hình ảnh dưới định dạng PNG:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Chuyển đổi slide đầu tiên trong bản trình chiếu thành bitmap.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // Lưu hình ảnh dưới định dạng PNG.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **Chuyển Đổi Slide Sang Hình Ảnh Với Kích Thước Tùy Chỉnh**

Bạn có thể cần lấy một hình ảnh có kích thước nhất định. Sử dụng một overload của [GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/islide/getimage/), bạn có thể chuyển đổi một slide thành hình ảnh với chiều rộng và chiều cao cụ thể.

Đoạn mã mẫu dưới đây minh họa cách thực hiện:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Chuyển đổi slide đầu tiên trong bản trình chiếu thành bitmap với kích thước đã chỉ định.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // Lưu hình ảnh dưới định dạng JPEG.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Chuyển Đổi Slide Có Ghi Chú và Bình Luận Sang Hình Ảnh**

Một số slide có thể chứa ghi chú và bình luận.

Aspose.Slides cung cấp hai giao diện—[ITiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/itiffoptions/) và [IRenderingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/irenderingoptions/)—cho phép bạn kiểm soát việc render các slide trình chiếu thành hình ảnh. Cả hai giao diện đều có thuộc tính `SlidesLayoutOptions`, cho phép bạn cấu hình cách render ghi chú và bình luận trên slide khi chuyển đổi sang hình ảnh.

Với lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/notescommentslayoutingoptions/), bạn có thể chỉ định vị trí mong muốn cho ghi chú và bình luận trong hình ảnh kết quả.

Đoạn mã C# dưới đây minh họa cách chuyển đổi một slide có ghi chú và bình luận:

```cs
float scaleX = 2;
float scaleY = scaleX;

// Tải tệp bài thuyết trình.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Tạo các tùy chọn render.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Đặt vị trí của ghi chú.
            CommentsPosition = CommentsPositions.Right,      // Đặt vị trí của bình luận.
            CommentsAreaWidth = 500,                         // Đặt độ rộng của khu vực bình luận.
            CommentsAreaColor = Color.AntiqueWhite           // Đặt màu cho khu vực bình luận.
        }
    };

    // Chuyển đổi slide đầu tiên của bản trình chiếu thành hình ảnh.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // Lưu hình ảnh dưới định dạng GIF.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 
Trong bất kỳ quy trình chuyển đổi slide‑to‑image nào, thuộc tính [NotesPosition](https://reference.aspose.com/slides/vi/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) không thể được đặt thành `BottomFull` (để chỉ định vị trí cho ghi chú) vì nội dung ghi chú có thể quá lớn, khiến nó không vừa trong kích thước hình ảnh đã chỉ định. 
{{% /alert %}} 

## **Chuyển Đổi Slide Sang Hình Ảnh Bằng Tùy Chọn TIFF**

Giao diện [ITiffOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/itiffoptions/) cung cấp khả năng kiểm soát sâu hơn đối với hình ảnh TIFF kết quả bằng cách cho phép bạn chỉ định các tham số như kích thước, độ phân giải, bảng màu và nhiều hơn nữa.

Đoạn mã C# dưới đây minh họa một quy trình chuyển đổi trong đó sử dụng tùy chọn TIFF để xuất một hình ảnh trắng‑đen với độ phân giải 300 DPI và kích thước 2160 × 2800:

```cs
// Tải tệp bài thuyết trình.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Lấy slide đầu tiên từ bản trình chiếu.
    ISlide slide = presentation.Slides[0];

    // Cấu hình các thiết lập cho ảnh TIFF đầu ra.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // Đặt kích thước ảnh.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Đặt định dạng pixel (đen trắng).
        DpiX = 300,                                        // Đặt độ phân giải chiều ngang.
        DpiY = 300                                         // Đặt độ phân giải chiều dọc.
    };

    // Chuyển đổi slide thành hình ảnh với các tùy chọn đã chỉ định.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Lưu ảnh dưới định dạng TIFF.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **Chuyển Đổi Tất Cả Các Slide Sang Hình Ảnh**

Aspose.Slides cho phép bạn chuyển đổi tất cả các slide trong một bản trình chiếu thành hình ảnh, thực chất là chuyển đổi toàn bộ bản trình chiếu thành một loạt các hình ảnh.

Đoạn mã mẫu dưới đây minh họa cách chuyển đổi tất cả các slide trong một bản trình chiếu thành hình ảnh bằng C#:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Render bản thuyết trình thành các hình ảnh từng slide.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // Kiểm soát các slide ẩn (không render các slide ẩn).
        if (presentation.Slides[i].Hidden)
            continue;

        // Chuyển đổi slide thành hình ảnh.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // Lưu hình ảnh dưới định dạng JPEG.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **Câu Hỏi Thường Gặp**

**1. Aspose.Slides có hỗ trợ render slide có hoạt ảnh không?**

Không, phương thức `GetImage` chỉ lưu một hình ảnh tĩnh của slide, không có hoạt ảnh.

**2. Các slide ẩn có thể được xuất thành hình ảnh không?**

Có, các slide ẩn có thể được xử lý giống như các slide thường. Chỉ cần đảm bảo chúng được bao gồm trong vòng lặp xử lý.

**3. Hình ảnh có thể được lưu với bóng đổ và hiệu ứng không?**

Có, Aspose.Slides hỗ trợ render bóng đổ, độ trong suốt và các hiệu ứng đồ họa khác khi lưu slide dưới dạng hình ảnh.