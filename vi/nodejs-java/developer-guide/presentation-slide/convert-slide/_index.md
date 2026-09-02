---
title: Chuyển đổi các slide bài thuyết trình sang hình ảnh trong JavaScript
linktitle: Slide sang Hình ảnh
type: docs
weight: 35
url: /vi/nodejs-java/convert-slide/
keywords: 
- chuyển đổi slide
- xuất slide
- slide thành hình ảnh
- lưu slide dưới dạng hình ảnh
- slide thành EMF
- slide thành PNG
- slide thành JPEG
- slide thành bitmap
- slide thành TIFF
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi các slide từ bài thuyết trình PPT, PPTX và ODP sang PNG, JPEG, GIF, TIFF, EMF và các định dạng hình ảnh khác trong JavaScript với Aspose.Slides."
---
## **Giới thiệu**

Aspose.Slides for Node.js via Java có thể render các slide riêng lẻ từ các bài thuyết trình PowerPoint và OpenDocument dưới dạng PNG, JPEG, GIF, TIFF và các định dạng hình ảnh khác.

Để chuyển đổi một slide thành hình ảnh, thực hiện các bước sau:

1. Tải bài thuyết trình bằng lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Chọn slide mà bạn muốn render.
3. Nếu cần, cấu hình việc render bằng lớp [RenderingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/renderingoptions/) hoặc [TiffOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/).
4. Gọi phương thức [Slide.getImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#getImage). Nó trả về một đối tượng [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/).
5. Gọi phương thức [IImage.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/#save) và chỉ định định dạng đầu ra bằng một giá trị của [ImageFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imageformat/).

## **Chuyển đổi Slide thành Hình PNG**

Cách chuyển đổi đơn giản nhất sử dụng các thiết lập render mặc định. Đối tượng [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/) kết quả có thể được xử lý trong bộ nhớ hoặc lưu thành file.

Ví dụ JavaScript sau render slide đầu tiên và lưu dưới dạng hình PNG:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi Slides sang Hình ảnh với Kích thước Tùy chỉnh**

Sử dụng phương thức overload của [Slide.getImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#getImage) chấp nhận giá trị `java.awt.Dimension` để render slide với kích thước pixel chính xác.

Ví dụ sau tạo hình JPEG kích thước 1820 × 1040:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi Slides có Ghi chú và Bình luận sang Hình ảnh**

Mặc định, hình ảnh slide không bao gồm ghi chú hoặc bình luận. Truyền một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notescommentslayoutingoptions/) vào phương thức [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) để điều khiển vị trí của ghi chú và bình luận.

Ví dụ sau đặt ghi chú đã cắt ngắn phía dưới slide và bình luận bên phải slide:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Đối với việc chuyển đổi slide sang hình ảnh, không truyền [BottomFull](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notespositions/) vào phương thức [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Ghi chú có thể chứa nhiều văn bản hơn kích thước ảnh cố định có thể chứa. Hãy sử dụng [BottomTruncated](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/notespositions/) thay thế.
{{% /alert %}}

## **Chuyển đổi Slides sang Hình ảnh bằng Tùy chọn TIFF**

Lớp [TiffOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/tiffoptions/) cho phép bạn kiểm soát kích thước, độ phân giải và các thuộc tính khác của hình ảnh TIFF đã render.

Ví dụ sau render slide đầu tiên dưới dạng hình TIFF 2160 × 2880 với 300 DPI:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Hỗ trợ TIFF không được đảm bảo trong các phiên bản Java trước JDK 9.
{{% /alert %}}

## **Chuyển đổi Tất cả Slides sang Hình ảnh**

Lặp qua bộ sưu tập slide để chuyển đổi toàn bộ bài thuyết trình thành một loạt hình ảnh. Các slide ẩn sẽ được bao gồm trừ khi bạn bỏ qua chúng một cách rõ ràng.

Ví dụ sau render mọi slide thành hình JPEG với hệ số phóng to ngang và dọc là 2:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Tạo Đầu ra Metafile Nâng cao**

Enhanced Metafile (EMF) hữu dụng khi đồ họa dựa trên vector cần được trao đổi với Microsoft Office hoặc các ứng dụng Windows hỗ trợ metafile. Khác với hình ảnh dựa trên pixel, EMF có thể giữ lại các thao tác vẽ vector và mở rộng mà không mất độ sắc nét. Tuy nhiên, EMF chủ yếu là định dạng tương thích cho các ứng dụng hỗ trợ metafile Windows, không phải là định dạng trao đổi chung. Ngoài ra, nội dung slide phức tạp, chẳng hạn ảnh bitmap và một số hiệu ứng, có thể được lưu dưới dạng các yếu tố raster trong container metafile vector.

### **Xuất Slide sang EMF**

Phương thức [Slide.writeAsEmf](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#writeAsEmf) ghi một slide vào một stream đích ở định dạng EMF. Ví dụ sau tải một bài thuyết trình, chọn slide đầu tiên và ghi nó vào một stream file EMF:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Người gọi sở hữu stream được truyền vào [Slide.writeAsEmf](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#writeAsEmf) và chịu trách nhiệm đóng nó, như đã mô tả ở trên.

### **Chuyển đổi Ảnh SVG sang EMF và Thêm Vào Bài Thuyết trình**

Sử dụng [SvgImage.writeAsEmf](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/#writeAsEmf) để chuyển đổi nội dung SVG sang EMF. Các byte kết quả có thể được thêm vào bài thuyết trình thông qua [ImageCollection.addImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagecollection/#addImage) và đặt lên slide bằng [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/#addPictureFrame).

Ví dụ dưới đây tạo một [SvgImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/) từ mã SVG, chuyển đổi nó thành EMF trong bộ nhớ, chèn metafile vào slide đầu tiên và lưu bài thuyết trình:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/svgimage/#writeAsEmf) không lấy quyền sở hữu stream đích. Một `java.io.ByteArrayOutputStream` lưu tất cả dữ liệu đã tạo trong bộ nhớ, vì vậy không cần đặt lại vị trí trước khi gọi `toByteArray`. Mảng byte trả về vẫn hợp lệ sau khi stream được đóng.

Việc tạo EMF khả dụng trên các hệ điều hành được hỗ trợ bởi Aspose.Slides for Node.js via Java và cấu hình JDK đã chọn, nhưng quá trình render có thể khác nhau giữa các nền tảng khi thiếu phông chữ hoặc phụ thuộc đồ họa. Cài đặt các phông chữ được sử dụng trong nội dung nguồn hoặc cấu hình các thay thế phù hợp, tuân theo [yêu cầu nền tảng](/slides/vi/nodejs-java/system-requirements/) cho Aspose.Slides for Node.js via Java, và xác thực kết quả trong ứng dụng tiêu thụ EMF mục tiêu. Các ứng dụng trên Linux và macOS thường có hỗ trợ hạn chế hoặc không nhất quán đối với việc hiển thị và chỉnh sửa metafile Windows.

## **Render Emoji Màu**

{{% alert title="Note" color="info" %}}
Để render emoji màu đúng cách khi chuyển đổi slide trình chiếu sang hình ảnh, các phông chữ emoji được sử dụng trong bài thuyết trình phải được cài đặt và có sẵn trên hệ thống thực hiện việc chuyển đổi. Ví dụ, nếu bài thuyết trình sử dụng **Segoe UI Emoji** và phông chữ này thiếu, các emoji có thể xuất hiện dưới dạng monochrome trong các hình ảnh đầu ra.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ render slide có hoạt ảnh không?**

Không. Phương thức [Slide.getImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#getImage) render một hình ảnh tĩnh của slide và không xuất hoạt ảnh.

**Có thể xuất các slide ẩn thành hình ảnh không?**

Có. Các slide ẩn có thể được render giống như các slide thông thường. Bao gồm chúng trong vòng xử lý, như đã trình bày trong ví dụ ở trên.

**Bóng đổ và các hiệu ứng khác có được giữ lại trong hình ảnh slide không?**

Có. Aspose.Slides render bóng đổ, độ trong suốt và các hiệu ứng đồ họa được hỗ trợ khác trong hình ảnh slide.