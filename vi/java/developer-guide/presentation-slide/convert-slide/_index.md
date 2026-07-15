---
title: Chuyển đổi Slide Bản trình bày thành Hình ảnh trong Java
linktitle: Slide sang Hình ảnh
type: docs
weight: 35
url: /vi/java/convert-slide/
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
- Java
- Aspose.Slides
description: "Chuyển đổi slide từ PPT, PPTX và ODP thành hình ảnh trong Java bằng Aspose.Slides—render nhanh, chất lượng cao với các ví dụ mã rõ ràng."
---
## **Giới thiệu**

Aspose.Slides for Java cho phép bạn dễ dàng chuyển đổi các slide bản trình bày PowerPoint và OpenDocument sang nhiều định dạng hình ảnh khác nhau, bao gồm BMP, PNG, JPG (JPEG), GIF và các định dạng khác.

Để chuyển đổi một slide thành hình ảnh, hãy làm theo các bước sau:

1. Xác định các thiết lập chuyển đổi mong muốn và chọn các slide bạn muốn xuất bằng cách sử dụng:
    - Giao diện [ITiffOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiffoptions/) , hoặc
    - Giao diện [IRenderingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/irenderingoptions/) .
2. Tạo hình ảnh slide bằng cách gọi phương thức [getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) .

Trong Aspose.Slides for Java, một [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) là giao diện cho phép bạn làm việc với các hình ảnh được định nghĩa bằng dữ liệu pixel. Bạn có thể sử dụng giao diện này để lưu hình ảnh ở nhiều định dạng khác nhau (BMP, JPG, PNG, v.v.).

## **Chuyển đổi Slide sang Bitmap và Lưu Hình ảnh dưới dạng PNG**

Bạn có thể chuyển đổi một slide thành đối tượng bitmap và sử dụng trực tiếp trong ứng dụng của mình. Ngoài ra, bạn cũng có thể chuyển đổi slide thành bitmap và sau đó lưu hình ảnh dưới dạng JPEG hoặc bất kỳ định dạng nào khác mà bạn muốn.

Đoạn mã dưới đây minh họa cách chuyển đổi slide đầu tiên của bản trình bày thành đối tượng bitmap và sau đó lưu hình ảnh dưới định dạng PNG:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Chuyển đổi slide đầu tiên trong bản trình bày thành bitmap.
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

## **Chuyển đổi Slide sang Hình ảnh với Kích thước Tùy chỉnh**

Bạn có thể cần có một hình ảnh với kích thước nhất định. Sử dụng một phiên bản quá tải của phương thức [getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), bạn có thể chuyển đổi slide thành hình ảnh với kích thước cụ thể (chiều rộng và chiều cao).

Đoạn mã mẫu dưới đây cho thấy cách thực hiện điều này:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Chuyển đổi slide đầu tiên trong bản trình bày thành bitmap với kích thước được chỉ định.
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

## **Chuyển đổi Slide có Ghi chú và Bình luận thành Hình ảnh**

Một số slide có thể chứa ghi chú và bình luận.

Aspose.Slides cung cấp hai giao diện—[ITiffOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiffoptions/) và [IRenderingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/irenderingoptions/)—cho phép bạn kiểm soát việc render các slide bản trình bày thành hình ảnh. Cả hai giao diện đều bao gồm phương thức `setSlidesLayoutOptions`, cho phép bạn cấu hình việc render ghi chú và bình luận trên một slide khi chuyển đổi nó thành hình ảnh.

Với lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/notescommentslayoutingoptions/) , bạn có thể chỉ định vị trí mong muốn cho ghi chú và bình luận trong hình ảnh kết quả.

Đoạn mã dưới đây minh họa cách chuyển đổi một slide có ghi chú và bình luận:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Đặt vị trí của ghi chú.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Đặt vị trí của bình luận.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Đặt độ rộng của vùng bình luận.
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // Đặt màu cho vùng bình luận.

    // Create the rendering options.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Convert the first slide of the presentation to an image.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // Save the image in the GIF format.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Trong bất kỳ quy trình chuyển đổi slide sang hình ảnh nào, phương thức [setNotesPosition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) không thể áp dụng `BottomFull` (để chỉ định vị trí cho ghi chú) vì văn bản ghi chú có thể quá dài, khiến nó không thể vừa trong kích thước hình ảnh đã chỉ định.
{{% /alert %}} 

## **Chuyển đổi Slide sang Hình ảnh bằng Tùy chọn TIFF**

Giao diện [ITiffOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiffoptions/) cung cấp khả năng kiểm soát cao hơn đối với hình ảnh TIFF kết quả bằng cách cho phép bạn chỉ định các tham số như kích thước, độ phân giải, bảng màu và các tùy chọn khác.

Đoạn mã dưới đây minh họa một quy trình chuyển đổi sử dụng tùy chọn TIFF để tạo ra hình ảnh đen trắng với độ phân giải 300 DPI và kích thước 2160 × 2800:

```java 
// Tải tệp bản trình bày.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Lấy slide đầu tiên từ bản trình bày.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Cấu hình các thiết lập cho hình ảnh TIFF đầu ra.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // Đặt kích thước hình ảnh.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Đặt định dạng pixel (đen và trắng).
    tiffOptions.setDpiX(300);                                        // Đặt độ phân giải theo chiều ngang.
    tiffOptions.setDpiY(300);                                        // Đặt độ phân giải theo chiều dọc.

    // Chuyển đổi slide thành hình ảnh với các tùy chọn đã chỉ định.
    IImage image = slide.getImage(tiffOptions);

    try {
        // Lưu hình ảnh ở định dạng TIFF.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Hỗ trợ TIFF không được đảm bảo trong các phiên bản cũ hơn JDK 9.
{{% /alert %}} 

## **Chuyển đổi Tất cả Slide sang Hình ảnh**

Aspose.Slides cho phép bạn chuyển đổi tất cả các slide trong một bản trình bày thành hình ảnh, thực chất biến toàn bộ bản trình bày thành một loạt các hình ảnh.

Đoạn mã mẫu dưới đây minh họa cách chuyển đổi tất cả các slide trong một bản trình bày thành hình ảnh trong Java:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Kết xuất bản trình bày thành các hình ảnh slide theo slide.
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

## **Render Emoji Màu**

{{% alert title="Note" color="warning" %}} 
Để hiển thị emoji màu đúng khi chuyển đổi slide bản trình bày sang hình ảnh, các phông chữ emoji được sử dụng trong bản trình bày phải được cài đặt và khả dụng trên hệ thống thực hiện việc chuyển đổi. Ví dụ, nếu bản trình bày sử dụng **Segoe UI Emoji** mà phông chữ này thiếu, các emoji có thể xuất hiện dưới dạng đen trắng trong các hình ảnh đầu ra.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ render slide có hoạt ảnh không?**

Không, phương thức `getImage` chỉ lưu một hình ảnh tĩnh của slide, không có hoạt ảnh.

**Có thể xuất các slide ẩn dưới dạng hình ảnh không?**

Có, các slide ẩn có thể được xử lý giống như các slide thường. Chỉ cần đảm bảo chúng được bao gồm trong vòng lặp xử lý.

**Có thể lưu hình ảnh có bóng và hiệu ứng không?**

Có, Aspose.Slides hỗ trợ render bóng, độ trong suốt và các hiệu ứng đồ họa khác khi lưu slide dưới dạng hình ảnh.