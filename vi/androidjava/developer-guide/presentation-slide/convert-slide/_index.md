---
title: "Chuyển đổi các slide trình chiếu thành ảnh trên Android"
linktitle: "Slide sang Ảnh"
type: docs
weight: 35
url: /vi/androidjava/convert-slide/
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
- trình chiếu
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các slide từ PPT, PPTX và ODP sang ảnh bằng Aspose.Slides cho Android—độ render nhanh, chất lượng cao với các ví dụ mã Java rõ ràng."
---
## **Introduction**

Aspose.Slides for Android via Java cho phép bạn dễ dàng chuyển đổi các slide trình chiếu PowerPoint và OpenDocument sang nhiều định dạng ảnh khác nhau, bao gồm BMP, PNG, JPG (JPEG), GIF và các định dạng khác.

Để chuyển đổi một slide thành ảnh, làm theo các bước sau:

1. Xác định các cài đặt chuyển đổi mong muốn và chọn các slide bạn muốn xuất bằng cách sử dụng:
    - The [ITiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiffoptions/) interface, or
    - The [IRenderingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/irenderingoptions/) interface.
2. Tạo ảnh slide bằng cách gọi phương thức [getImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#getImage--) method.

Trong Aspose.Slides for Android via Java, [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) là một giao diện cho phép bạn làm việc với các ảnh được định nghĩa bằng dữ liệu pixel. Bạn có thể sử dụng giao diện này để lưu ảnh ở nhiều định dạng khác nhau (BMP, JPG, PNG, v.v.).

## **Convert Slides to Bitmaps and Save the Images in PNG**

Bạn có thể chuyển đổi một slide thành đối tượng bitmap và sử dụng trực tiếp trong ứng dụng của mình. Hoặc, bạn có thể chuyển đổi slide thành bitmap rồi lưu ảnh dưới dạng JPEG hoặc bất kỳ định dạng nào bạn muốn.

Đoạn mã sau minh họa cách chuyển slide đầu tiên của một bản trình bày thành đối tượng bitmap và sau đó lưu ảnh dưới định dạng PNG:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Chuyển đổi slide đầu tiên trong bản trình bày thành bitmap.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // Lưu ảnh ở định dạng PNG.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Convert Slides to Images with Custom Sizes**

Bạn có thể cần có một ảnh với kích thước nhất định. Bằng cách sử dụng một overload của [getImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-), bạn có thể chuyển đổi slide thành ảnh với các kích thước cụ thể (độ rộng và chiều cao).

Đoạn mã mẫu sau minh họa cách thực hiện điều này:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Chuyển đổi slide đầu tiên trong bản trình bày thành bitmap với kích thước đã chỉ định.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // Lưu ảnh ở định dạng JPEG.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Convert Slides with Notes and Comments to Images**

Một số slide có thể chứa ghi chú và bình luận.

Aspose.Slides cung cấp hai giao diện — [ITiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiffoptions/) và [IRenderingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/irenderingoptions/) — cho phép bạn kiểm soát việc render slide trình chiếu thành ảnh. Cả hai giao diện đều bao gồm phương thức `setSlidesLayoutOptions`, giúp bạn cấu hình cách render ghi chú và bình luận trên một slide khi chuyển đổi thành ảnh.

Với lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) , bạn có thể chỉ định vị trí mong muốn cho ghi chú và bình luận trong ảnh kết quả.

Đoạn mã sau minh họa cách chuyển đổi một slide có ghi chú và bình luận:

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

    // Tạo các tùy chọn render.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Chuyển đổi slide đầu tiên của bản trình chiếu thành ảnh.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // Lưu ảnh ở định dạng GIF.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Lưu ý" color="warning" %}} 
Trong bất kỳ quá trình chuyển đổi slide thành ảnh nào, phương thức [setNotesPosition](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) không thể áp dụng `BottomFull` (để chỉ định vị trí cho ghi chú) vì văn bản của ghi chú có thể quá dài, khiến nó không thể vừa vào kích thước ảnh được chỉ định.
{{% /alert %}} 

## **Convert Slides to Images Using TIFF Options**

Giao diện [ITiffOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itiffoptions/) cung cấp khả năng kiểm soát tốt hơn đối với hình ảnh TIFF kết quả bằng cách cho phép bạn chỉ định các tham số như kích thước, độ phân giải, bảng màu và hơn nữa.

Đoạn mã sau minh họa quy trình chuyển đổi trong đó sử dụng các tùy chọn TIFF để xuất ảnh đen trắng với độ phân giải 300 DPI và kích thước 2160 × 2800:

```java 
// Tải tệp trình chiếu.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Lấy slide đầu tiên từ bản trình chiếu.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Cấu hình các cài đặt cho ảnh TIFF đầu ra.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // Đặt kích thước ảnh.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Đặt định dạng pixel (đen trắng).
    tiffOptions.setDpiX(300);                                        // Đặt độ phân giải ngang.
    tiffOptions.setDpiY(300);                                        // Đặt độ phân giải dọc.

    // Chuyển đổi slide thành ảnh với các tùy chọn đã chỉ định.
    IImage image = slide.getImage(tiffOptions);

    try {
        // Lưu ảnh ở định dạng TIFF.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Convert All Slides to Images**

Aspose.Slides cho phép bạn chuyển đổi tất cả các slide trong một bản trình bày thành ảnh, thực tế là chuyển đổi toàn bộ bản trình bày thành một loạt các ảnh.

Đoạn mã mẫu sau minh họa cách chuyển đổi tất cả các slide trong một bản trình bày thành ảnh bằng Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Render bản trình chiếu thành các ảnh slide theo slide.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Kiểm soát các slide ẩn (không render các slide ẩn).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Chuyển đổi slide thành ảnh.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // Lưu ảnh ở định dạng JPEG.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Aspose.Slides có hỗ trợ render slide có hoạt ảnh không?**

Không, phương thức `getImage` chỉ lưu một ảnh tĩnh của slide, không có hoạt ảnh.

**Có thể xuất các slide ẩn thành ảnh không?**

Có, các slide ẩn có thể được xử lý giống như các slide thông thường. Chỉ cần đảm bảo chúng được đưa vào vòng lặp xử lý.

**Có thể lưu ảnh với bóng và hiệu ứng không?**

Có, Aspose.Slides hỗ trợ render bóng, độ trong suốt và các hiệu ứng đồ họa khác khi lưu slide dưới dạng ảnh.