---
title: Chuyển đổi các slide PowerPoint sang PNG trong JavaScript
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
description: "Chuyển đổi các bài thuyết trình PowerPoint sang hình ảnh PNG chất lượng cao trong JavaScript một cách nhanh chóng với Aspose.Slides cho Node.js, đảm bảo kết quả chính xác và tự động."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các slide bài thuyết trình sang hình ảnh PNG bằng Aspose.Slides cho Node.js thông qua Java. Bạn có thể tải các bài thuyết trình ở các định dạng như PPT, PPTX và ODP, render mỗi slide và lưu nó dưới dạng một hình ảnh PNG riêng. Các ví dụ dưới đây minh họa việc render ở tỷ lệ mặc định, tăng tỷ lệ, chỉ định kích thước đầu ra tính bằng pixel, và chọn kiểu render gradient.

## **Chuyển đổi PowerPoint sang PNG**

Tải một bài thuyết trình bằng lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) và truy cập các slide thông qua tập hợp [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides). Ví dụ này render mỗi slide bằng [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) không có tham số để tạo thumbnail. Sau đó nó gọi [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) với [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) để lưu mỗi slide đã render dưới dạng hình ảnh PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Phiên bản không tham số của [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) render ở tỷ lệ 0.2. Ví dụ, một slide đo 720 × 540 điểm sẽ tạo ra thumbnail 144 × 108 pixel. Để kiểm soát kích thước đầu ra, sử dụng các phiên bản overload với các hệ số tỷ lệ hoặc kích thước ảnh rõ ràng như dưới đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Gửi các hệ số tỷ lệ chiều ngang và chiều dọc vào [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) để kiểm soát kích thước đã render. Trong ví dụ này, cả hai hệ số đều là 2, vì vậy một slide đo 720 × 540 điểm sẽ tạo ra hình ảnh 1440 × 1080 pixel. Các hệ số tỷ lệ bằng nhau giữ nguyên tỷ lệ khung hình của slide. Mỗi hình ảnh được lưu ở định dạng PNG bằng [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Để chỉ định kích thước đầu ra tính bằng pixel, truyền một kích thước vào [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) thay vì các hệ số tỷ lệ. Ví dụ này render mỗi slide ở kích thước 960 × 720 pixel và lưu kết quả bằng [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Chọn kích thước phù hợp với tỷ lệ khung hình của slide để tránh kéo dài ảnh.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Chọn Kiểu Render Gradient**

Giả sử một slide chứa các fill gradient, nhưng các chuyển đổi trong PNG xuất ra trông nhạt hơn hoặc khác so với những gì bạn thấy trong PowerPoint. Bạn có thể sử dụng phương thức [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) kế thừa từ [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) để chọn cách render gradient.

Tải về [gradient-styles.pptx](gradient-styles.pptx) và đặt nó vào thư mục làm việc của ứng dụng. Slide đầu tiên chứa hai gradient tuyến tính: từ xanh lơ sang cam ở trên và từ xanh dương sang vàng ở dưới. Mỗi gradient có hai dải màu, tại 0% và 100%.

Ví dụ sau tải bài thuyết trình này và render slide đầu tiên giống nhau ở cả hai chế độ bằng [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Các hình ảnh dưới đây hiển thị đầu ra từ cùng một slide, với cả hai gradient trong mỗi hình ảnh:

| Mặc định | PowerPointUI |
| --- | --- |
| ![Gradient từ xanh lơ sang cam và từ xanh dương sang vàng được render với Mặc định](gradient-Default.png) | ![Các gradient tương tự được render với PowerPointUI](gradient-PowerPointUI.png) |

Trong ví dụ này, `Default` tạo ra các màu trung gian sáng hơn, trong khi `PowerPointUI` tạo ra các màu trung gian tối hơn. Sự khác biệt phụ thuộc vào các màu và dải màu trong gradient. Chọn `Default` khi đầu ra tiêu chuẩn của Aspose.Slides đáp ứng nhu cầu của bạn. Thử `PowerPointUI` khi ưu tiên của bạn là khớp với giao diện trong PowerPoint. So sánh cả hai đầu ra với kết quả mong muốn; không có chế độ nào là ưu việt cho mọi trường hợp.

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể xuất một hình dạng cụ thể, chẳng hạn biểu đồ hoặc hình ảnh, thay vì toàn bộ slide?**

Aspose.Slides hỗ trợ [tạo thumbnail cho các hình dạng riêng lẻ](/slides/vi/nodejs-java/create-shape-thumbnails/), cho phép bạn render một hình dạng dưới dạng hình ảnh PNG.

**Việc chuyển đổi song song có được hỗ trợ trên máy chủ không?**

Có. Sử dụng một thể hiện presentation riêng cho mỗi luồng hoặc tiến trình; [không chia sẻ một thể hiện duy nhất giữa các luồng](/slides/vi/nodejs-java/multithreading/).

**Những hạn chế nào của chế độ dùng thử khi xuất sang PNG?**

Chế độ dùng thử sẽ thêm watermark vào các hình ảnh đầu ra và áp dụng [các hạn chế khác](/slides/vi/nodejs-java/licensing/) cho đến khi có giấy phép.