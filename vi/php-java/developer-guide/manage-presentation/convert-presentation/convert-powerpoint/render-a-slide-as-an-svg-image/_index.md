---
title: "Xuất các slide PowerPoint dưới dạng hình ảnh SVG trong PHP"
linktitle: "Slide sang SVG"
type: docs
weight: 50
url: /vi/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- bài thuyết trình sang SVG
- slide sang SVG
- PPT sang SVG
- PPTX sang SVG
- các tùy chọn xuất SVG
- SVG tương tác
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Xuất các slide PowerPoint dưới dạng hình ảnh SVG trong PHP và kiểm soát phông chữ, văn bản, hình ảnh, ID và sự kiện bằng Aspose.Slides."
---
## **Tổng quan**

SVG là định dạng hình ảnh dựa trên XML có khả năng mở rộng, phù hợp cho việc xuất bản web, trình xem slide, quy trình truy cập, và xử lý hậu kỳ tự động. Aspose.Slides xuất mỗi slide thành một tệp SVG riêng và cho phép bạn kiểm soát cách văn bản, phông chữ, hình ảnh và các phần tử SVG được ghi.

Sử dụng [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) khi SVG được xuất cần gọn nhẹ, dự đoán được trên các trình duyệt, hoặc sẵn sàng cho việc sử dụng tương tác.

## **Xuất slide dưới dạng SVG**

Tạo một [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), chọn một slide và ghi nó vào luồng bằng [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). Ví dụ sau xuất từng slide trong một bản trình chiếu thành một tệp SVG riêng.

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

Tên tệp sử dụng [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) thay vì chỉ mục vòng lặp. Bạn cũng có thể xuất một hình dạng riêng lẻ bằng [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) khi trình xem slide hoặc trang web chỉ cần hình dạng đó.

## **Cấu hình đầu ra SVG**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) kiểm soát việc render SVG. Đối với khung văn bản, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) bao gồm khung văn bản trong khu vực render, và [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) xác định xem có áp dụng phép quay khung hay không. Đặt [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) thành `true` khi văn bản phải được render mà không có ligature.

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

Khi xuất slide sang SVG, bạn có thể kiểm soát liệu văn bản có giữ lại dạng văn bản hay được chuyển thành đồ họa vector, và cách các phông chữ bên ngoài được bao gồm hoặc tham chiếu. Các tùy chọn sau giúp bạn cân bằng độ nhất quán trực quan, khả năng chọn văn bản và phụ thuộc phông chữ trong SVG được xuất.

### **Vector hoá toàn bộ Văn bản**

Đặt [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) thành `true` để ghi toàn bộ văn bản slide dưới dạng đồ họa vector. Điều này loại bỏ phụ thuộc phông chữ và làm cho kết quả trực quan nhất quán hơn trên các trình duyệt, nhưng văn bản sẽ không còn có thể được chọn hoặc tìm kiếm dưới dạng văn bản SVG.

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

### **Chọn Cách Xử lý Phông chữ Bên ngoài**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) sử dụng giá trị [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) cho các phông chữ được tải từ bên ngoài. Chọn `AddLinksToFontFiles` để tham chiếu các tệp phông chữ riêng biệt, `Embed` để bao gồm dữ liệu phông trong SVG, hoặc `Vectorize` để render chỉ những văn bản sử dụng phông chữ bên ngoài dưới dạng đồ họa. Kiểm tra giấy phép phông chữ trước khi nhúng phông.

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

Sử dụng [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) để giảm độ phân giải của các hình ảnh nhúng, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) để loại bỏ các khu vực đã cắt của nguồn, và [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) để kiểm soát chất lượng mã hoá JPEG. Các cài đặt này giảm kích thước tệp với chi phí là độ trung thực hoặc dữ liệu hình ảnh được giữ lại.

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

## **Kiểm soát Độ phân giải Raster hóa Metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) đặt giới hạn độ phân giải thấp nhất cho việc raster hóa metafile trong quá trình xuất SVG. Sử dụng nó để cân bằng chi tiết và kích thước tệp khi một hình ảnh EMF hoặc WMF được raster hóa. Nó không định nghĩa DPI toàn cục cho SVG hay buộc mọi đối tượng trên slide chuyển thành hình raster.

Tải xuống [metafile-rasterization.pptx](metafile-rasterization.pptx), chứa một ảnh EMF với các đường chéo gần nhau. Ví dụ sau xuất slide đầu tiên của nó ở ba độ phân giải raster khác nhau qua [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). Tất cả các cài đặt xuất khác vẫn giữ nguyên để có thể so sánh kết quả.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

Trong kết quả, EMF trở thành một PNG nhúng trong mỗi SVG. Các đo lường sau áp dụng cho bản trình chiếu đã cung cấp; chúng không phải là công thức chung để chuyển DPI sang kích thước pixel.

| DPI raster hóa Metafile | Kích thước PNG nhúng | Kích thước tệp SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

So sánh dưới đây hiển thị cùng một khu vực raster đã nhúng ở cùng kích thước hiển thị phóng to. Các đường chéo cho thấy hiện tượng pixel hoá ở 72 DPI và các cạnh mượt hơn ở độ phân giải cao hơn, trong khi tệp SVG tăng kích thước. Tăng giá trị không nhất thiết cải thiện mọi chi tiết hay thay đổi mọi hình ảnh đã xuất.

![Chi tiết đường chéo được phóng to ở 72, 150 và 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) kiểm soát việc giảm độ phân giải ảnh và có thể che đi ảnh hưởng của việc thay đổi độ phân giải raster hóa metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) kiểm soát chất lượng mã hoá JPEG, không phải độ phân giải raster hóa metafile.

## **Gán ID Ổn định cho Các Hình dạng và Văn bản**

Cung cấp một callback định dạng cho [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) để đặt [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) cho mỗi hình dạng SVG. Callback cũng có thể đặt giá trị [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) trên các phần tử `tspan` của văn bản.

PhpJavaBridge không thể gọi một callback PHP từ `writeAsSvg` khi nó chạy ở chế độ stream. Đặt logic định dạng vào một lớp trợ giúp Java nhỏ, biên dịch nó, và thêm tệp JAR kết quả vào classpath của bridge. Trợ giúp này có thể sử dụng [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId), vốn ổn định trong suốt vòng đời của hình dạng, và một bộ đếm lặp lại cho các đoạn văn bản của nó. Xem [Triển khai Java của `StableSvgIdController`](/slides/vi/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) để xem mã trợ giúp.

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

Trong một callback định dạng, gọi [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) với một giá trị [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) để thêm một trình xử lý sự kiện JavaScript vào một hình dạng đã xuất. Gán callback bằng [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) và định nghĩa hàm JavaScript trong trang hoặc tài liệu SVG lưu trữ kết quả.

Giống như ID ổn định, triển khai callback trong một trợ giúp Java khi PhpJavaBridge sử dụng chế độ stream. Xem [Triển khai Java của `SvgEventController`](/slides/vi/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) để xem cách gán ID và trình xử lý `OnClick` cho một hình dạng có tên `ActionButton`. Biên dịch trợ giúp đó, thêm nó vào classpath của bridge dưới tên `com.example.slides.SvgEventController`, và sử dụng từ PHP như sau:

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

Trang host có thể định nghĩa hàm JavaScript được tham chiếu bởi trình xử lý. Gán ID và trình xử lý sự kiện cho phép các trình xem slide, cải tiến khả năng truy cập, và các quy trình làm việc SVG tương tác khác.

## **Câu hỏi thường gặp**

**Khi nào tôi nên sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) thay vì [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

Sử dụng [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) khi tất cả văn bản phải độc lập với phông chữ. Sử dụng [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) khi chỉ văn bản sử dụng phông chữ bên ngoài cần được chuyển thành đồ họa.

**Cách tốt nhất để làm cho một SVG nhỏ hơn là gì?**

Bắt đầu bằng cách nén các hình ảnh đã nhúng, xóa các khu vực ảnh đã cắt và chọn liên kết tới các tệp phông chữ khi môi trường mục tiêu có thể phục vụ chúng. Kiểm tra kết quả vì việc giảm độ phân giải ảnh, giảm chất lượng JPEG và vector hoá văn bản mỗi thứ đều có các thỏa hiệp về chất lượng và kích thước khác nhau.

**Tôi có thể chỉnh sửa các phần tử SVG đã xuất sau khi xuất không?**

Có. Gán ID thông qua một callback định dạng, rồi chọn các phần tử SVG tương ứng trong công cụ hậu xử lý hoặc script trình duyệt của bạn.