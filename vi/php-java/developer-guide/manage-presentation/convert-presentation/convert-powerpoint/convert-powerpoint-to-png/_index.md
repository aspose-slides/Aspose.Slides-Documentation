---
title: Chuyển đổi slide PowerPoint sang PNG trong PHP
linktitle: PowerPoint sang PNG
type: docs
weight: 30
url: /vi/php-java/convert-powerpoint-to-png/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang PNG
- bản trình chiếu sang PNG
- slide sang PNG
- PPT sang PNG
- PPTX sang PNG
- lưu PPT dưới dạng PNG
- lưu PPTX dưới dạng PNG
- xuất PPT sang PNG
- xuất PPTX sang PNG
- PHP
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PowerPoint sang hình ảnh PNG chất lượng cao nhanh chóng với Aspose.Slides cho PHP qua Java, đảm bảo kết quả chính xác và tự động."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các slide trình chiếu sang hình ảnh PNG bằng Aspose.Slides cho PHP qua Java. Bạn có thể tải các bản trình chiếu ở các định dạng như PPT, PPTX và ODP, render mỗi slide và lưu nó dưới dạng một hình ảnh PNG riêng biệt.

Các ví dụ dưới đây minh họa việc render ở tỷ lệ mặc định, tăng tỷ lệ, chỉ định kích thước đầu ra tính bằng pixel, và chọn kiểu render gradient.

## **Chuyển đổi PowerPoint sang PNG**

Tải một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) và truy cập các slide thông qua bộ sưu tập [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides). Ví dụ render mỗi slide bằng [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) mà không truyền tham số để tạo thumbnail. Sau đó gọi [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) với [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) để lưu mỗi slide đã render dưới dạng hình ảnh PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Phiên bản overload không tham số của [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) render ở tỷ lệ 0.2. Ví dụ, một slide có kích thước 720 × 540 points tạo ra thumbnail 144 × 108 pixel. Để kiểm soát kích thước đầu ra, sử dụng các overload với hệ số tỷ lệ hoặc kích thước hình ảnh rõ ràng như dưới đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Cung cấp các hệ số tỷ lệ ngang và dọc cho [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) để kiểm soát kích thước render. Trong ví dụ này, cả hai hệ số đều là 2, vì vậy một slide có kích thước 720 × 540 points tạo ra hình ảnh 1440 × 1080 pixel. Các hệ số tỷ lệ bằng nhau giữ tỷ lệ khung hình của slide. Mỗi hình ảnh được lưu ở định dạng PNG bằng [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save).

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Để chỉ định kích thước đầu ra tính bằng pixel, truyền kích thước vào [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) thay vì các hệ số tỷ lệ. Ví dụ này render mỗi slide ở kích thước 960 × 720 pixel và lưu kết quả bằng [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Chọn kích thước khớp với tỷ lệ khung hình của slide để tránh kéo dài hình ảnh.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Chọn Kiểu Render Gradient**

Giả sử một slide có các vùng màu gradient, nhưng các chuyển đổi trong PNG xuất ra trông nhạt hơn hoặc khác so với những gì bạn thấy trong PowerPoint. Bạn có thể sử dụng phương thức [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) được kế thừa bởi [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) để chọn cách render gradient.

Tải xuống [gradient-styles.pptx](gradient-styles.pptx) và đặt nó vào thư mục làm việc của ứng dụng. Slide đầu tiên chứa hai gradient tuyến tính: xanh lơ tới cam ở trên và xanh dương tới vàng ở dưới. Mỗi gradient có hai điểm dừng, ở 0% và 100%.

Ví dụ sau tải bản trình chiếu này và render slide đầu tiên giống nhau trong cả hai chế độ bằng [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Các hình ảnh bên dưới hiển thị kết quả từ cùng một slide, với cả hai gradient trong mỗi hình ảnh:

| Default | PowerPointUI |
| --- | --- |
| ![Gradient xanh lơ tới cam và xanh dương tới vàng được render với Default](gradient-Default.png) | ![Cùng gradient được render với PowerPointUI](gradient-PowerPointUI.png) |

Trong ví dụ này, `Default` tạo ra các màu trung gian sáng hơn, trong khi `PowerPointUI` tạo ra các màu trung gian tối hơn. Sự khác biệt phụ thuộc vào các màu và điểm dừng trong gradient.

Chọn `Default` khi đầu ra tiêu chuẩn của Aspose.Slides đáp ứng nhu cầu của bạn. Thử `PowerPointUI` khi ưu tiên của bạn là khớp với giao diện trong PowerPoint. So sánh cả hai kết quả với mục tiêu mong muốn; không có chế độ nào là tốt nhất cho mọi trường hợp.

## **Câu hỏi thường gặp**

**Làm thế nào để tôi xuất một hình dạng cụ thể, ví dụ như biểu đồ hoặc hình ảnh, thay vì toàn bộ slide?**

Aspose.Slides hỗ trợ [tạo thumbnail cho các hình dạng riêng lẻ](/slides/vi/php-java/create-shape-thumbnails/), cho phép bạn render một hình dạng dưới dạng hình ảnh PNG.

**Chuyển đổi song song có được hỗ trợ trên máy chủ không?**

Có. Sử dụng một thể hiện trình chiếu riêng cho mỗi luồng hoặc tiến trình; [không chia sẻ một thể hiện duy nhất giữa các luồng](/slides/vi/php-java/multithreading/).

**Những hạn chế của chế độ đánh giá khi xuất ra PNG là gì?**

Chế độ đánh giá sẽ thêm watermark vào các hình ảnh đầu ra và áp dụng [các giới hạn khác](/slides/vi/php-java/licensing/) cho đến khi có giấy phép.