---
title: Chuyển Đổi Slide Trình Chiếu Thành Hình Ảnh trên Android
linktitle: Slide sang Hình Ảnh
type: docs
weight: 35
url: /vi/androidjava/convert-slide/
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
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi slide từ PPT, PPTX và ODP sang hình ảnh bằng Aspose.Slides cho Android—kết xuất nhanh, chất lượng cao với các ví dụ mã Java rõ ràng."
---
## **Giới thiệu**

Aspose.Slides for Android qua Java cho phép bạn dễ dàng chuyển đổi các slide trình chiếu PowerPoint và OpenDocument sang nhiều định dạng hình ảnh khác nhau, bao gồm BMP, PNG, JPG (JPEG), GIF và các định dạng khác.

Để chuyển đổi một slide thành hình ảnh, hãy thực hiện các bước sau:

1. Xác định các cài đặt chuyển đổi mong muốn và chọn các slide bạn muốn xuất bằng cách sử dụng:
    - Giao diện [ITiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiffoptions/) , hoặc
    - Giao diện [IRenderingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/irenderingoptions/) .
2. Tạo hình ảnh slide bằng cách gọi phương thức [getImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#getImage--) .

Trong Aspose.Slides for Android qua Java, [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) là một giao diện cho phép bạn làm việc với các hình ảnh được xác định bởi dữ liệu pixel. Bạn có thể sử dụng giao diện này để lưu hình ảnh ở nhiều định dạng khác nhau (BMP, JPG, PNG, v.v.).

## **Chuyển đổi Slide sang Bitmap và Lưu Hình Ảnh ở Định Dạng PNG**

Bạn có thể chuyển đổi một slide thành đối tượng bitmap và sử dụng trực tiếp trong ứng dụng của mình. Ngoài ra, bạn cũng có thể chuyển đổi slide thành bitmap và sau đó lưu hình ảnh ở định dạng JPEG hoặc bất kỳ định dạng ưu thích nào khác.

Mã này minh họa cách chuyển đổi slide đầu tiên của một bài thuyết trình thành đối tượng bitmap và sau đó lưu hình ảnh ở định dạng PNG:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Chuyển đổi slide đầu tiên trong bài thuyết trình thành bitmap.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // Lưu hình ảnh ở định dạng PNG.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển Đổi Slide sang Hình Ảnh với Kích Thước Tùy Chỉnh**

Bạn có thể cần lấy một hình ảnh có kích thước nhất định. Sử dụng một overload của [getImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) , bạn có thể chuyển đổi slide thành hình ảnh với các kích thước cụ thể (chiều rộng và chiều cao).

Mã mẫu này minh họa cách thực hiện:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Chuyển đổi slide đầu tiên trong bài thuyết trình thành bitmap với kích thước đã chỉ định.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // Lưu hình ảnh ở định dạng JPEG.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển Đổi Slide có Ghi Chú và Bình Luận thành Hình Ảnh**

Một số slide có thể chứa ghi chú và bình luận.

Aspose.Slides cung cấp hai giao diện—[ITiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiffoptions/) và [IRenderingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/irenderingoptions/)—cho phép bạn kiểm soát việc kết xuất các slide trình chiếu thành hình ảnh. Cả hai giao diện đều bao gồm phương thức `setSlidesLayoutOptions`, cho phép bạn cấu hình việc kết xuất ghi chú và bình luận trên một slide khi chuyển đổi nó sang hình ảnh.

Với lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) , bạn có thể chỉ định vị trí ưu thích cho ghi chú và bình luận trong hình ảnh kết quả.

Mã này minh họa cách chuyển đổi slide có ghi chú và bình luận:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Tải tệp trình chiếu.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Đặt vị trí của ghi chú.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Đặt vị trí của bình luận.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Đặt chiều rộng của khu vực bình luận.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // Đặt màu cho khu vực bình luận.

    // Tạo các tùy chọn kết xuất.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Chuyển đổi slide đầu tiên của bài thuyết trình thành hình ảnh.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // Lưu hình ảnh ở định dạng GIF.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Trong bất kỳ quá trình chuyển đổi slide sang hình ảnh nào, phương thức [setNotesPosition](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) không thể áp dụng `BottomFull` (để chỉ định vị trí cho ghi chú) vì nội dung ghi chú có thể quá dài, khiến nó không thể vừa trong kích thước hình ảnh đã chỉ định.
{{% /alert %}} 

## **Chuyển Đổi Slide sang Hình Ảnh bằng Tùy Chọn TIFF**

Giao diện [ITiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiffoptions/) cung cấp khả năng kiểm soát tốt hơn đối với hình ảnh TIFF kết quả bằng cách cho phép bạn chỉ định các tham số như kích thước, độ phân giải, bảng màu và hơn thế nữa.

Mã này minh họa một quy trình chuyển đổi trong đó các tùy chọn TIFF được sử dụng để xuất một hình ảnh đen‑trắng với độ phân giải 300 DPI và kích thước 2160 × 2800:

```java 
// Tải tệp trình chiếu.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Lấy slide đầu tiên từ bài thuyết trình.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Cấu hình các thiết lập cho hình ảnh TIFF đầu ra.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // Đặt kích thước hình ảnh.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Đặt định dạng pixel (đen trắng).
    tiffOptions.setDpiX(300);                                        // Đặt độ phân giải chiều ngang.
    tiffOptions.setDpiY(300);                                        // Đặt độ phân giải chiều dọc.

    // Chuyển đổi slide thành hình ảnh với các tùy chọn đã chỉ định.
    IImage image = slide.getImage(tiffOptions);

    try {
        // Lưu hình ảnh dưới định dạng TIFF.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển Đổi Tất Cả Slide sang Hình Ảnh**

Aspose.Slides cho phép bạn chuyển đổi tất cả các slide trong một bài thuyết trình thành hình ảnh, thực chất chuyển đổi toàn bộ bài thuyết trình thành một loạt các hình ảnh.

Mã mẫu này minh họa cách chuyển đổi tất cả các slide trong một bài thuyết trình thành hình ảnh trong Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Kết xuất bài thuyết trình thành hình ảnh slide theo slide.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Kiểm soát các slide ẩn (không kết xuất các slide ẩn).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Chuyển đổi slide thành hình ảnh.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // Lưu hình ảnh ở định dạng JPEG.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Kết Xuất Emoji Màu**

{{% alert title="Note" color="warning" %}} 
Để kết xuất emoji màu đúng cách khi chuyển đổi các slide trình chiếu thành hình ảnh, các phông chữ emoji được sử dụng trong bài thuyết trình phải được cài đặt và có sẵn trên hệ thống thực hiện việc chuyển đổi. Ví dụ, nếu bài thuyết trình sử dụng **Segoe UI Emoji** và phông chữ này thiếu, emoji có thể xuất hiện ở dạng đơn sắc trong các hình ảnh đầu ra.
{{% /alert %}}

## **FAQ**

**Aspose.Slides có hỗ trợ kết xuất slide có hoạt ảnh không?**

Không, phương thức `getImage` chỉ lưu một hình ảnh tĩnh của slide, không có hoạt ảnh.

**Có thể xuất các slide ẩn thành hình ảnh không?**

Có, các slide ẩn có thể được xử lý giống như các slide thường. Chỉ cần đảm bảo chúng được đưa vào vòng lặp xử lý.

**Có thể lưu hình ảnh với bóng và hiệu ứng không?**

Có, Aspose.Slides hỗ trợ kết xuất bóng, độ trong suốt và các hiệu ứng đồ họa khác khi lưu slide dưới dạng hình ảnh.