---
title: Xuất các slide trình chiếu thành hình ảnh SVG trong PHP
linktitle: Slide sang SVG
type: docs
weight: 50
url: /vi/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- trình chiếu sang SVG
- slide sang SVG
- PPT sang SVG
- PPTX sang SVG
- tùy chọn xuất SVG
- SVG tương tác
- PowerPoint
- trình chiếu
- PHP
- Aspose.Slides
description: "Xuất các slide PowerPoint thành hình ảnh SVG trong PHP và kiểm soát phông chữ, văn bản, hình ảnh, ID và sự kiện với Aspose.Slides."
---
## **Tổng quan**

SVG là định dạng hình ảnh dựa trên XML có khả năng mở rộng, phù hợp cho việc xuất bản web, trình xem slide, quy trình trợ năng và xử lý hậu kỳ tự động. Aspose.Slides xuất mỗi slide thành một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các phần tử SVG được ghi.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/) khi SVG đã xuất cần phải gọn nhẹ, dự đoán được trên các trình duyệt hoặc sẵn sàng cho việc tương tác.

## **Xuất một slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/), chọn một slide và ghi nó vào luồng bằng [Slide.writeAsSvg](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#writeAsSvg). Ví dụ sau xuất mọi slide trong một bản trình bày dưới dạng các tệp SVG riêng biệt.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Tên tệp sử dụng [Slide.getSlideNumber](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getSlideNumber) thay vì chỉ số vòng lặp. Bạn cũng có thể xuất một hình dạng riêng lẻ bằng [Shape.writeAsSvg](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#writeAsSvg) khi trình xem slide hoặc trang web chỉ cần hình dạng đó.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/) kiểm soát việc render SVG. Đối với khung văn bản, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/#setUseFrameSize) bao gồm khung văn bản trong khu vực render, và [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/#setUseFrameRotation) xác định liệu phép quay khung có được áp dụng hay không. Đặt [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) thành `true` khi văn bản phải được render mà không có các ligature.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Kiểm soát Văn bản và Phông chữ**

### **Biểu diễn Văn bản Thành Vector**

Đặt [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/#setVectorizeText) thành `true` để ghi toàn bộ văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ sự phụ thuộc vào phông chữ và làm cho kết quả hiển thị nhất quán hơn trên các trình duyệt, nhưng văn bản sẽ không còn có thể chọn hoặc tìm kiếm dưới dạng văn bản SVG.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **Chọn Cách Xử lý Phông chữ Ngoài**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) sử dụng giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgexternalfontshandling/) cho các phông chữ được tải từ bên ngoài. Chọn `AddLinksToFontFiles` để tham chiếu các tệp phông chữ riêng biệt, `Embed` để nhúng dữ liệu phông chữ vào SVG, hoặc `Vectorize` để render chỉ những văn bản sử dụng phông chữ ngoài dưới dạng đồ họa. Hãy kiểm tra giấy phép phông chữ trước khi nhúng.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Giảm Kích thước Hình ảnh Nhúng**

Sử dụng [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/#setPicturesCompression) để giảm độ phân giải của các hình ảnh nhúng, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) để bỏ qua các khu vực đã cắt của nguồn hình ảnh, và [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/#setJpegQuality) để kiểm soát chất lượng mã hóa JPEG. Những cài đặt này giảm kích thước tệp với chi phí là độ trung thực hoặc dữ liệu hình ảnh được giữ lại.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Gán ID Ổn định cho Hình dạng và Văn bản**

Cung cấp một callback định dạng cho [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/#setShapeFormattingController) để đặt [SvgShape.setId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgshape/#setId) cho mỗi hình dạng SVG. Callback cũng có thể đặt giá trị [SvgTSpan.setId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgtspan/#setId) cho các phần tử `tspan` của văn bản.

PhpJavaBridge không thể gọi một callback PHP từ `writeAsSvg` khi chạy ở chế độ luồng. Đưa logic định dạng vào một lớp trợ giúp Java nhỏ, biên dịch nó và thêm tệp JAR kết quả vào classpath của bridge. Trợ giúp có thể sử dụng [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getOfficeInteropShapeId), giá trị này ổn định trong vòng đời của hình dạng, và một bộ đếm lặp lại cho các span văn bản của nó. Xem [Java implementation of `StableSvgIdController`](/slides/vi/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) để biết mã trợ giúp.

Sau khi thêm lớp đã biên dịch `com.example.slides.StableSvgIdController` vào classpath của bridge, khởi tạo nó từ PHP và gán cho `SVGOptions`:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Thêm Trình xử lý Sự kiện SVG**

Trong một callback định dạng, gọi [SvgShape.setEventHandler](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgshape/#setEventHandler) với một giá trị [SvgEvent](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgevent/) để thêm trình xử lý sự kiện JavaScript vào một hình dạng đã xuất. Gán callback bằng [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/#setShapeFormattingController) và định nghĩa hàm JavaScript trong trang hoặc tài liệu SVG chứa kết quả.

Như với ID ổn định, triển khai callback trong một lớp trợ giúp Java khi PhpJavaBridge sử dụng chế độ luồng. [Java implementation of `SvgEventController`](/slides/vi/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) gán một ID và một trình xử lý `OnClick` cho hình dạng có tên `ActionButton`. Biên dịch trợ giúp đó, thêm nó vào classpath của bridge dưới tên `com.example.slides.SvgEventController`, và sử dụng từ PHP như sau:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

Trang chủ có thể định nghĩa hàm JavaScript được tham chiếu bởi trình xử lý. Gán ID và trình xử lý sự kiện cho phép các trình xem slide, cải tiến trợ năng và các quy trình làm việc SVG tương tác khác.

## **Câu hỏi thường gặp**

**Khi nào nên sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/#setVectorizeText) thay vì [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgexternalfontshandling/)?**

Sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/#setVectorizeText) khi tất cả văn bản phải độc lập với phông chữ. Sử dụng [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgexternalfontshandling/) khi chỉ những văn bản sử dụng phông chữ ngoài cần được chuyển thành đồ họa.

**Cách tốt nhất để làm giảm kích thước SVG là gì?**

Bắt đầu bằng cách nén các hình ảnh nhúng, xóa các khu vực ảnh đã cắt và chọn liên kết tới tệp phông chữ khi môi trường mục tiêu có thể phục vụ chúng. Kiểm tra kết quả vì độ phân giải ảnh thấp hơn, chất lượng JPEG giảm và văn bản được vector hoá mỗi cái đều có các cân bằng về chất lượng và kích thước khác nhau.

**Tôi có thể sửa đổi các phần tử SVG đã xuất sau khi xuất không?**

Có. Gán ID thông qua một callback định dạng, sau đó chọn các phần tử SVG tương ứng trong công cụ xử lý hậu kỳ hoặc script trình duyệt của bạn.