---
title: Chuyển đổi Slide PowerPoint sang PNG trong JavaScript
linktitle: PowerPoint sang PNG
type: docs
weight: 30
url: /vi/nodejs-java/convert-powerpoint-to-png/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PNG
- bài thuyết trình sang PNG
- slide sang PNG
- PPT sang PNG
- PPTX sang PNG
- lưu PPT dưới dạng PNG
- lưu PPTX dưới dạng PNG
- xuất PPT sang PNG
- xuất PPTX sang PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi các bài thuyết trình PowerPoint sang hình ảnh PNG chất lượng cao trong JavaScript nhanh chóng với Aspose.Slides cho Node.js, đảm bảo kết quả chính xác, tự động."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bài thuyết trình PowerPoint sang hình ảnh PNG bằng Aspose.Slides. Nó cho thấy cách tải các tệp bài thuyết trình ở các định dạng như PPT, PPTX và ODP, render các slide thành hình ảnh và lưu kết quả dưới dạng PNG.

Bài viết cũng trình bày cách tùy chỉnh các hình ảnh PNG được tạo ra bằng cách đặt giá trị tỷ lệ hoặc chỉ định chiều rộng và chiều cao mong muốn.

## **Chuyển đổi PowerPoint sang PNG**

Thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy đối tượng slide từ bộ sưu tập được trả về bởi phương thức [Presentation.getSlides()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) trong lớp [Slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Slide).
3. Sử dụng phương thức [Slide.getImage()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Slide) để lấy hình thu nhỏ cho mỗi slide.
4. Sử dụng phương thức [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/#save) để lưu hình thu nhỏ của slide dưới định dạng PNG.

Đoạn mã JavaScript này cho bạn thấy cách chuyển đổi một bài thuyết trình PowerPoint sang PNG:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Nếu bạn muốn tạo các tệp PNG với một tỷ lệ nhất định, bạn có thể đặt giá trị cho `desiredX` và `desiredY`, những giá trị này xác định kích thước của hình thu nhỏ kết quả. 

Đoạn mã JavaScript này minh họa thao tác đã mô tả:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Nếu bạn muốn tạo các tệp PNG với một kích thước nhất định, bạn có thể truyền các đối số `width` và `height` mong muốn cho `ImageSize`. 

Đoạn mã này cho bạn thấy cách chuyển đổi PowerPoint sang PNG đồng thời chỉ định kích thước cho các hình ảnh: 

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Làm sao tôi có thể xuất chỉ một hình dạng cụ thể (ví dụ: biểu đồ hoặc ảnh) thay vì toàn bộ slide?**

Aspose.Slides hỗ trợ [tạo hình thu nhỏ cho các hình dạng riêng lẻ](/slides/vi/nodejs-java/create-shape-thumbnails/); bạn có thể render một hình dạng thành hình ảnh PNG.

**Việc chuyển đổi song song có được hỗ trợ trên máy chủ không?**

Có, nhưng [không nên chia sẻ](/slides/vi/nodejs-java/multithreading/) một thể hiện Presentation duy nhất giữa các luồng. Sử dụng một thể hiện riêng cho mỗi luồng hoặc tiến trình.

**Những hạn chế của phiên bản dùng thử khi xuất ra PNG là gì?**

Chế độ đánh giá sẽ thêm một watermark vào các hình ảnh đầu ra và áp dụng [các hạn chế khác](/slides/vi/nodejs-java/licensing/) cho đến khi có giấy phép.