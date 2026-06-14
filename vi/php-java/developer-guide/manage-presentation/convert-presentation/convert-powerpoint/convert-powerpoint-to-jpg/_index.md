---
title: Chuyển đổi PPT và PPTX sang JPG trong PHP
linktitle: PowerPoint sang JPG
type: docs
weight: 60
url: /vi/php-java/convert-powerpoint-to-jpg/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang JPG
- bài thuyết trình sang JPG
- slide sang JPG
- PPT sang JPG
- PPTX sang JPG
- lưu PowerPoint dưới dạng JPG
- lưu bài thuyết trình dưới dạng JPG
- lưu slide dưới dạng JPG
- lưu PPT dưới dạng JPG
- lưu PPTX dưới dạng JPG
- xuất PPT sang JPG
- xuất PPTX sang JPG
- PHP
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint (PPT, PPTX) sang hình ảnh JPG chất lượng cao trong PHP với Aspose.Slides cho PHP bằng các ví dụ mã nhanh và đáng tin cậy."
---
## **Giới thiệu**

Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang hình ảnh JPG giúp việc chia sẻ slide, tối ưu hiệu năng và nhúng nội dung vào trang web hoặc ứng dụng. Aspose.Slides cho phép bạn chuyển đổi các tệp PPTX, PPT và ODP thành hình ảnh JPEG chất lượng cao. Hướng dẫn này giải thích các phương pháp chuyển đổi khác nhau.

Với các tính năng này, bạn có thể dễ dàng triển khai trình xem bản trình chiếu của riêng mình và tạo ảnh thu nhỏ cho mỗi slide. Điều này có thể hữu ích nếu bạn muốn bảo vệ các slide khỏi việc sao chép hoặc trình diễn bản trình chiếu ở chế độ chỉ đọc. Aspose.Slides cho phép bạn chuyển đổi toàn bộ bản trình chiếu hoặc một slide cụ thể sang các định dạng hình ảnh.

## **Chuyển đổi PowerPoint PPT/PPTX sang JPG**

Dưới đây là các bước để chuyển đổi PPT/PPTX sang JPG:

1. Tạo một thể hiện của kiểu [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy đối tượng slide kiểu [Slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/) từ bộ sưu tập [Presentation::getSlides()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation#getSlides--) .
3. Tạo ảnh thu nhỏ cho mỗi slide và sau đó chuyển đổi nó sang JPG. Phương thức [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage) được sử dụng để lấy ảnh thu nhỏ của một slide. Phương thức [getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage) phải được gọi từ slide cần thiết của kiểu [Slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/), các tỉ lệ của ảnh thu nhỏ kết quả được truyền vào phương thức.
4. Sau khi bạn có ảnh thu nhỏ của slide, gọi phương thức [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/IImage#save(String%20formatName,%20int%20imageFormat)) từ đối tượng ảnh thu nhỏ. Truyền tên tệp kết quả và định dạng hình ảnh vào phương thức này.

{{% alert color="primary" %}}
**Lưu ý**: Việc chuyển đổi PPT/PPTX sang JPG khác với việc chuyển đổi sang các loại khác trong API Aspose.Slides. Đối với các loại khác, bạn thường sử dụng phương thức [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/save/), nhưng ở đây bạn cần phương thức [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/IImage#save(String%20formatName,%20int%20imageFormat)) method.
{{% /alert %}}

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # Tạo ảnh đầy đủ tỷ lệ
      $slideImage = $sld->getImage(1.0, 1.0);
      # Lưu ảnh vào đĩa ở định dạng JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
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
## **Chuyển đổi PowerPoint PPT/PPTX sang JPG với Kích thước Tùy chỉnh**

Để thay đổi kích thước của ảnh thu nhỏ và hình ảnh JPG kết quả, bạn có thể đặt giá trị *ScaleX* và *ScaleY* bằng cách truyền chúng vào các phương thức [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage):

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Xác định kích thước
    $desiredX = 1200;
    $desiredY = 800;
    # Lấy giá trị tỉ lệ của X và Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # Tạo ảnh đầy đủ tỷ lệ
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # Lưu ảnh vào đĩa ở định dạng JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
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

## **Kết xuất bình luận khi lưu slide dưới dạng hình ảnh**

Aspose.Slides cho PHP thông qua Java cung cấp một tính năng cho phép bạn kết xuất bình luận trong các slide của bản trình chiếu khi chuyển đổi các slide đó thành hình ảnh. Đoạn mã PHP dưới đây minh họa hoạt động này:

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
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

{{% alert title="Tip" color="primary" %}}
Aspose cung cấp một [ứng dụng Web Collage MIỄN PHÍ](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể ghép các hình ảnh [JPG sang JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG sang PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), và nhiều hơn nữa.

Bằng cách áp dụng các nguyên tắc đã mô tả trong bài viết này, bạn có thể chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Để biết thêm thông tin, xem các trang sau: chuyển đổi [hình ảnh sang JPG](https://products.aspose.com/slides/vi/php-java/conversion/image-to-jpg/); chuyển đổi [JPG sang hình ảnh](https://products.aspose.com/slides/vi/php-java/conversion/jpg-to-image/); chuyển đổi [JPG sang PNG](https://products.aspose.com/slides/vi/php-java/conversion/jpg-to-png/), chuyển đổi [PNG sang JPG](https://products.aspose.com/slides/vi/php-java/conversion/png-to-jpg/); chuyển đổi [PNG sang SVG](https://products.aspose.com/slides/vi/php-java/conversion/png-to-svg/), chuyển đổi [SVG sang PNG](https://products.aspose.com/slides/vi/php-java/conversion/svg-to-png/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Phương pháp này có hỗ trợ chuyển đổi hàng loạt không?**

Có, Aspose.Slides cho phép chuyển đổi hàng loạt nhiều slide sang JPG trong một thao tác duy nhất.

**Việc chuyển đổi có hỗ trợ SmartArt, biểu đồ và các đối tượng phức tạp khác không?**

Có, Aspose.Slides sẽ kết xuất tất cả nội dung, bao gồm SmartArt, biểu đồ, bảng, hình dạng và hơn thế nữa. Tuy nhiên, độ chính xác của việc kết xuất có thể hơi khác so với PowerPoint, đặc biệt khi sử dụng phông chữ tùy chỉnh hoặc thiếu.

**Có bất kỳ giới hạn nào về số slide có thể xử lý không?**

Aspose.Slides không áp đặt bất kỳ giới hạn nghiêm ngặt nào về số slide bạn có thể xử lý. Tuy nhiên, bạn có thể gặp lỗi thiếu bộ nhớ khi làm việc với bản trình chiếu lớn hoặc hình ảnh độ phân giải cao.

## **Xem thêm**

Xem các tùy chọn khác để chuyển đổi PPT/PPTX sang hình ảnh như:

- [Chuyển đổi PPT/PPTX sang SVG](/slides/vi/php-java/render-a-slide-as-an-svg-image/).