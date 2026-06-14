---
title: Chuyển đổi các slide bài thuyết trình sang hình ảnh trong JavaScript
linktitle: Slide sang Hình ảnh
type: docs
weight: 35
url: /vi/nodejs-java/convert-slide/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi các slide từ PPT, PPTX và ODP sang hình ảnh trong JavaScript bằng Aspose.Slides cho Node.js thông qua Java — tốc độ nhanh, render chất lượng cao với các ví dụ mã rõ ràng."
---
## **Giới thiệu**

Aspose.Slides cho Node.js thông qua Java cho phép bạn dễ dàng chuyển đổi các slide bài thuyết trình PowerPoint và OpenDocument sang nhiều định dạng ảnh khác nhau, bao gồm BMP, PNG, JPG (JPEG), GIF và các định dạng khác.

Để chuyển đổi một slide thành hình ảnh, hãy thực hiện các bước sau:

1. Xác định các cài đặt chuyển đổi mong muốn và chọn các slide bạn muốn xuất bằng cách sử dụng:
    - Lớp [TiffOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/) , hoặc
    - Lớp [RenderingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/renderingoptions/) .
2. Tạo hình ảnh slide bằng cách gọi phương thức [getImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#getImage).

Trong Aspose.Slides cho Node.js thông qua Java, một [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/) là một lớp cho phép bạn làm việc với các hình ảnh được định nghĩa bằng dữ liệu pixel. Bạn có thể sử dụng lớp này để lưu hình ảnh ở nhiều định dạng khác nhau (BMP, JPG, PNG, v.v.).

## **Chuyển đổi Slide sang Bitmap và Lưu Hình Ảnh dưới Định dạng PNG**

Bạn có thể chuyển đổi một slide sang đối tượng bitmap và sử dụng trực tiếp trong ứng dụng của mình. Ngoài ra, bạn có thể chuyển đổi một slide sang bitmap và sau đó lưu hình ảnh ở định dạng JPEG hoặc bất kỳ định dạng nào khác mà bạn thích.

Mã JavaScript này minh họa cách chuyển đổi slide đầu tiên của một bài thuyết trình sang đối tượng bitmap và sau đó lưu hình ảnh ở định dạng PNG:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Chuyển đổi slide đầu tiên trong bài thuyết trình thành bitmap.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // Lưu hình ảnh ở định dạng PNG.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi Slide sang Hình Ảnh với Kích Thước Tùy Chỉnh**

Bạn có thể cần lấy một hình ảnh có kích thước nhất định. Sử dụng một overload từ [getImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#getImage), bạn có thể chuyển đổi một slide sang hình ảnh với các kích thước cụ thể (chiều rộng và chiều cao).

Mã mẫu này minh họa cách thực hiện:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Chuyển đổi slide đầu tiên trong bài thuyết trình thành bitmap với kích thước đã chỉ định.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // Lưu hình ảnh ở định dạng JPEG.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi Slide có Ghi chú và Bình luận sang Hình ảnh**

Một số slide có thể chứa ghi chú và bình luận.

Aspose.Slides cung cấp hai lớp—[TiffOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/) và [RenderingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/renderingoptions/)—cho phép bạn kiểm soát việc render các slide bài thuyết trình sang hình ảnh. Cả hai lớp đều bao gồm phương thức `setSlidesLayoutOptions`, cho phép bạn cấu hình việc render ghi chú và bình luận trên một slide khi chuyển đổi nó sang hình ảnh.

Với lớp [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notescommentslayoutingoptions/), bạn có thể chỉ định vị trí mong muốn cho ghi chú và bình luận trong hình ảnh kết quả.

Mã JavaScript này minh họa cách chuyển đổi một slide có ghi chú và bình luận:

```js
const scaleX = 2;
const scaleY = scaleX;

// Load a presentation file.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // Đặt vị trí của ghi chú.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // Đặt vị trí của các bình luận.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // Đặt chiều rộng của khu vực bình luận.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // Đặt màu cho khu vực bình luận.

    // Tạo các tùy chọn render.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // Chuyển đổi slide đầu tiên của bài thuyết trình thành hình ảnh.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // Lưu hình ảnh ở định dạng GIF.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Trong bất kỳ quy trình chuyển đổi slide sang hình ảnh nào, phương thức [setNotesPosition](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) không thể áp dụng `BottomFull` (để chỉ định vị trí cho ghi chú) vì nội dung ghi chú có thể quá dài, khiến nó không vừa trong kích thước hình ảnh đã chỉ định.
{{% /alert %}} 

## **Chuyển đổi Slide sang Hình ảnh Sử dụng Tùy chọn TIFF**

Lớp [TiffOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/) cung cấp khả năng kiểm soát cao hơn đối với hình ảnh TIFF kết quả bằng cách cho phép bạn chỉ định các tham số như kích thước, độ phân giải, bảng màu và hơn thế nữa.

Mã JavaScript này minh họa một quy trình chuyển đổi nơi các tùy chọn TIFF được sử dụng để xuất một hình ảnh đen trắng với độ phân giải 300 DPI và kích thước 2160 × 2800:

```js
// Tải tệp bài thuyết trình.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Lấy slide đầu tiên từ bài thuyết trình.
    let slide = presentation.getSlides().get_Item(0);

    // Cấu hình các thiết lập cho hình ảnh TIFF đầu ra.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Đặt kích thước hình ảnh.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Đặt định dạng pixel (đen và trắng).
    tiffOptions.setDpiX(300);                                                          // Đặt độ phân giải theo chiều ngang.
    tiffOptions.setDpiY(300);                                                          // Đặt độ phân giải theo chiều dọc.

    // Chuyển đổi slide thành hình ảnh với các tùy chọn đã chỉ định.
    let image = slide.getImage(tiffOptions);
    try {
        // Lưu hình ảnh ở định dạng TIFF.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Hỗ trợ TIFF không được đảm bảo trong các phiên bản trước JDK 9.
{{% /alert %}} 

## **Chuyển đổi Tất cả Slide sang Hình ảnh**

Aspose.Slides cho phép bạn chuyển đổi tất cả các slide trong một bài thuyết trình sang hình ảnh, thực sự chuyển đổi toàn bộ bài thuyết trình thành một loạt các hình ảnh.

Mã mẫu này minh họa cách chuyển đổi tất cả các slide trong một bài thuyết trình sang hình ảnh trong JavaScript:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Render bài thuyết trình thành các hình ảnh, mỗi slide một ảnh.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // Kiểm soát các slide ẩn (không render các slide ẩn).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // Chuyển đổi slide thành hình ảnh.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // Lưu hình ảnh ở định dạng JPEG.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ render slide với hoạt ảnh không?**

Không, phương thức `getImage` chỉ lưu một hình ảnh tĩnh của slide, không có hoạt ảnh.

**Có thể xuất các slide ẩn thành hình ảnh không?**

Có, các slide ẩn có thể được xử lý giống như các slide thường. Chỉ cần đảm bảo chúng được đưa vào vòng lặp xử lý.

**Có thể lưu hình ảnh với bóng đổ và hiệu ứng không?**

Có, Aspose.Slides hỗ trợ render bóng đổ, độ trong suốt và các hiệu ứng đồ họa khác khi lưu slide thành hình ảnh.