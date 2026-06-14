---
title: Chuyển đổi PPT và PPTX sang JPG trong JavaScript
linktitle: PowerPoint sang JPG
type: docs
weight: 60
url: /vi/nodejs-java/convert-powerpoint-to-jpg/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang JPG
- bản trình bày sang JPG
- slide sang JPG
- PPT sang JPG
- PPTX sang JPG
- lưu PowerPoint dưới dạng JPG
- lưu bản trình bày dưới dạng JPG
- lưu slide dưới dạng JPG
- lưu PPT dưới dạng JPG
- lưu PPTX dưới dạng JPG
- xuất PPT sang JPG
- xuất PPTX sang JPG
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint (PPT, PPTX) thành hình ảnh JPG chất lượng cao trong JavaScript với Aspose.Slides cho Node.js qua Java bằng các ví dụ mã nhanh và đáng tin cậy."
---
## **Giới thiệu**

Chuyển đổi các bản trình bày PowerPoint và OpenDocument sang hình ảnh JPG giúp chia sẻ slide, tối ưu hiệu năng và nhúng nội dung vào website hoặc ứng dụng. Aspose.Slides cho phép bạn chuyển đổi các tệp PPTX, PPT và ODP thành ảnh JPEG chất lượng cao. Hướng dẫn này giải thích các phương pháp chuyển đổi khác nhau.

Với những tính năng này, bạn có thể dễ dàng triển khai trình xem bản trình bày riêng và tạo hình thu nhỏ cho mỗi slide. Điều này có thể hữu ích nếu bạn muốn bảo vệ các slide khỏi việc sao chép hoặc trình chiếu bản trình bày ở chế độ chỉ đọc. Aspose.Slides cho phép bạn chuyển đổi toàn bộ bản trình bày hoặc một slide cụ thể sang các định dạng hình ảnh.

## **Chuyển đổi PowerPoint PPT/PPTX sang JPG**
Dưới đây là các bước để chuyển đổi PPT/PPTX sang JPG:

1. Tạo một thể hiện của loại [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy đối tượng slide của loại [Slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Slide) từ bộ sưu tập [Presentation.getSlides()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getSlides--) .
3. Tạo hình thu nhỏ của mỗi slide và sau đó chuyển nó sang JPG. Phương thức [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Slide#getImage-float-float-) được dùng để lấy hình thu nhỏ của một slide, nó trả về đối tượng [Imagess](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Images). Phương thức [getImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) phải được gọi từ slide cần thiết của loại [Slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Slide), các tỷ lệ của hình thu nhỏ kết quả được truyền vào phương thức.
4. Sau khi bạn có hình thu nhỏ của slide, gọi phương thức [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/#save) từ đối tượng hình thu nhỏ. Truyền tên tệp và định dạng hình ảnh vào phương thức này.

{{% alert color="primary" %}}

**Lưu ý**: Chuyển đổi PPT/PPTX sang JPG khác với việc chuyển đổi sang các định dạng khác trong API Aspose.Slides. Đối với các định dạng khác, bạn thường sử dụng phương thức [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-), nhưng ở đây bạn cần phương thức [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/#save).

{{% /alert %}} 

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Tạo một hình ảnh toàn kích thước
        var slideImage = sld.getImage(1.0, 1.0);
        // Lưu hình ảnh vào đĩa ở định dạng JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
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

## **Chuyển đổi PowerPoint PPT/PPTX sang JPG với Kích thước tùy chỉnh**
Để thay đổi kích thước của hình thu nhỏ và ảnh JPG kết quả, bạn có thể đặt giá trị *ScaleX* và *ScaleY* bằng cách truyền chúng vào các phương thức [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Slide#getImage-float-float-) :

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // Định nghĩa kích thước
    var desiredX = 1200;
    var desiredY = 800;
    // Lấy giá trị tỉ lệ của X và Y
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Tạo một hình ảnh toàn kích thước
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // Lưu hình ảnh vào đĩa ở định dạng JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
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

## **Kết xuất bình luận khi lưu Bản trình bày dưới dạng Hình ảnh**
Aspose.Slides for Node.js via Java cung cấp một tiện ích cho phép bạn kết xuất các bình luận trong các slide của bản trình bày khi chuyển các slide đó sang hình ảnh. Đoạn mã JavaScript này minh họa cách thực hiện:

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
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

{{% alert title="Tip" color="primary" %}}

Aspose cung cấp một [ứng dụng web Collage MIỄN PHÍ](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể hợp nhất [JPG sang JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG sang PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), và vân vân. 

{{% /alert %}}

## **Xem thêm**

Xem các tùy chọn khác để chuyển đổi PPT/PPTX sang hình ảnh như:

- [PPT/PPTX to SVG conversion](/slides/vi/nodejs-java/render-a-slide-as-an-svg-image/).

## **Câu hỏi thường gặp**

**Phương pháp này có hỗ trợ chuyển đổi hàng loạt không?**

Có, Aspose.Slides cho phép chuyển đổi hàng loạt nhiều slide sang JPG trong một thao tác duy nhất.

**Việc chuyển đổi có hỗ trợ SmartArt, biểu đồ và các đối tượng phức tạp khác không?**

Có, Aspose.Slides render toàn bộ nội dung, bao gồm SmartArt, biểu đồ, bảng, hình dạng và nhiều hơn nữa. Tuy nhiên, độ chính xác khi render có thể hơi khác so với PowerPoint, đặc biệt khi sử dụng phông chữ tùy chỉnh hoặc phông chữ thiếu.

**Có bất kỳ giới hạn nào về số slide có thể được xử lý không?**

Aspose.Slides bản thân không áp đặt giới hạn nghiêm ngặt về số slide bạn có thể xử lý. Tuy nhiên, bạn có thể gặp lỗi thiếu bộ nhớ khi làm việc với các bản trình bày lớn hoặc ảnh có độ phân giải cao.