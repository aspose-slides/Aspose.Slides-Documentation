---
title: Chuyển đổi các slide PowerPoint sang PNG trong PHP
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
description: "Chuyển đổi các bản trình chiếu PowerPoint sang ảnh PNG chất lượng cao một cách nhanh chóng với Aspose.Slides cho PHP qua Java, đảm bảo kết quả chính xác và tự động."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi các bản trình chiếu PowerPoint sang ảnh PNG bằng Aspose.Slides. Nó chỉ ra cách tải các tệp bản trình chiếu ở các định dạng như PPT, PPTX và ODP, render các slide thành hình ảnh và lưu kết quả ở định dạng PNG.

Bài viết cũng trình bày cách tùy chỉnh các ảnh PNG được tạo ra bằng cách đặt giá trị tỷ lệ hoặc chỉ định chiều rộng và chiều cao mong muốn.

## **Chuyển đổi PowerPoint sang PNG**

Thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy đối tượng slide từ bộ sưu tập [Presentation.getSlides()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSlides) dưới lớp [Slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/).
3. Sử dụng phương thức [Slide.getImage()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage) để lấy hình thu nhỏ cho từng slide.
4. Sử dụng phương thức [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/#save) để lưu hình thu nhỏ của slide ở định dạng PNG.

Đoạn mã PHP này cho bạn thấy cách chuyển đổi một bản trình chiếu PowerPoint sang PNG:

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Nếu bạn muốn nhận các tệp PNG với một tỷ lệ nhất định, bạn có thể đặt giá trị cho `desiredX` và `desiredY`, những giá trị này xác định kích thước của hình thu nhỏ kết quả. 

Đoạn mã này minh họa thao tác đã mô tả:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Chuyển đổi PowerPoint sang PNG với Kích thước Tùy chỉnh**

Nếu bạn muốn nhận các tệp PNG với một kích thước nhất định, bạn có thể truyền các đối số `width` và `height` mong muốn cho `ImageSize`. 

Đoạn mã này cho bạn thấy cách chuyển đổi PowerPoint sang PNG đồng thời chỉ định kích thước cho các hình ảnh: 

```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Làm sao tôi có thể xuất chỉ một hình dạng cụ thể (ví dụ: biểu đồ hoặc hình ảnh) thay vì toàn bộ slide?**

Aspose.Slides hỗ trợ [tạo hình thu nhỏ cho các hình dạng riêng lẻ](/slides/vi/php-java/create-shape-thumbnails/); bạn có thể render một hình dạng thành ảnh PNG.

**Việc chuyển đổi song song có được hỗ trợ trên server không?**

Có, nhưng [không chia sẻ](/slides/vi/php-java/multithreading/) một thể hiện Presentation duy nhất giữa các luồng. Hãy sử dụng một thể hiện riêng cho mỗi luồng hoặc tiến trình.

**Các hạn chế của phiên bản dùng thử khi xuất ra PNG là gì?**

Chế độ đánh giá sẽ thêm watermark vào các ảnh đầu ra và áp dụng [các hạn chế khác](/slides/vi/php-java/licensing/) cho đến khi có giấy phép.