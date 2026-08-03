---
title: Tạo Thumbnail cho Các Hình dạng Bản trình chiếu trong PHP
linktitle: Thumbnail Hình dạng
type: docs
weight: 70
url: /vi/php-java/create-shape-thumbnails/
keywords:
- thumbnail hình dạng
- hình ảnh hình dạng
- kết xuất hình dạng
- kết xuất hình dạng
- giới hạn trực quan
- giới hạn hình dạng
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tạo thumbnail hình dạng chất lượng cao từ các slide PowerPoint bằng Aspose.Slides cho PHP qua Java – dễ dàng tạo và xuất thumbnail bản trình chiếu."
---
## **Giới thiệu**

Aspose.Slides được sử dụng để tạo các tệp trình chiếu, trong đó mỗi trang là một slide. Các slide này có thể được xem bằng cách mở tệp trình chiếu bằng Microsoft PowerPoint. Tuy nhiên, đôi khi các nhà phát triển cần xem hình ảnh của các shape riêng lẻ trong một trình xem ảnh. Trong những trường hợp như vậy, Aspose.Slides giúp bạn tạo các hình ảnh thumbnail cho các shape của slide. Cách sử dụng tính năng này được mô tả trong bài viết này.
Bài viết này giải thích cách tạo thumbnail cho slide theo các cách khác nhau:

- Tạo thumbnail cho shape bên trong một slide.
- Tạo thumbnail cho shape của slide với kích thước do người dùng định nghĩa.
- Tạo thumbnail cho shape trong giới hạn của hiển thị shape.

## **Tạo Thumbnail Hình Dạng Từ Slide**
Để tạo thumbnail cho shape từ bất kỳ slide nào bằng Aspose.Slides for PHP via Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. [Lấy hình ảnh thumbnail của shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getImage) của slide đã tham chiếu với tỉ lệ mặc định.
1. Lưu hình ảnh thumbnail ở định dạng ảnh bạn muốn.

Mã mẫu sau cho thấy cách tạo thumbnail cho shape từ một slide:

```php
  # Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Tạo hình ảnh ở tỷ lệ đầy đủ
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Lưu hình ảnh ra đĩa ở định dạng PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tạo Thumbnail Với Hệ Số Phóng Đại Do Người Dùng Định Nghĩa**
Để tạo thumbnail cho shape của một slide bằng Aspose.Slides for PHP via Java, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. [Lấy hình ảnh thumbnail của shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getImage) của slide đã tham chiếu với kích thước do người dùng định nghĩa.
1. Lưu hình ảnh thumbnail ở định dạng ảnh bạn muốn.

Mã mẫu sau cho thấy cách tạo thumbnail cho shape dựa trên hệ số phóng đại đã định nghĩa:

```php
  # Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Tạo hình ảnh ở tỷ lệ đầy đủ
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Lưu hình ảnh ra đĩa ở định dạng PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tạo Thumbnail Hình Dạng Dựa Trên Giới Hạn Hiển Thị**
Phương pháp tạo thumbnail cho các shape này cho phép các nhà phát triển tạo thumbnail trong giới hạn của hiển thị shape, bao gồm tất cả các hiệu ứng shape. Thumbnail shape được giới hạn bởi giới hạn của slide. Để tạo thumbnail cho shape của slide trong giới hạn hiển thị, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. Lấy hình ảnh thumbnail của slide đã tham chiếu với giới hạn shape là hiển thị.
1. Lưu hình ảnh thumbnail ở định dạng ảnh bạn muốn.

Mã mẫu dựa trên các bước trên:

```php
  # Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Tạo hình ảnh ở tỷ lệ đầy đủ
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Lưu hình ảnh ra đĩa ở định dạng PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lấy Giới Hạn Trực Quan Thực Tế Của Hình Dạng**

Các thuộc tính khung của [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/)—`Shape::getX()`, `Shape::getY()`, `Shape::getWidth()`, và `Shape::getHeight()`—miêu tả hình chữ nhật được lưu trong mô hình trình chiếu. Nội dung thực tế được vẽ có thể mở rộng ra ngoài khung đó hoặc chiếm một hình chữ nhật căn trục khác. Việc xoay, viền, đầu mũi tên, bố cục và tràn văn bản, hình học SmartArt được tạo ra và các hiệu ứng render khác có thể thay đổi khu vực chiếm dụng.

Sử dụng [Shape::getVisualBounds](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getVisualBounds) để tính toán khu vực chiếm dụng mà không cần tạo hình ảnh. Phương thức này trả về một [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) trong tọa độ slide. Hình chữ nhật trả về không bị cắt theo slide, vì vậy tọa độ có thể là số âm khi nội dung mở rộng ra ngoài gốc slide.

Ví dụ sau lấy và so sánh khung và giới hạn trực quan:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

Cùng một [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) có thể được dùng để căn chỉnh các shape gần nhau sang trái, phải, trên hoặc dưới; dự trữ đủ không gian trong bố cục được tạo; hoặc phát hiện nội dung nằm ngoài vùng cho phép. Giới hạn trực quan đặc biệt hữu ích cho SmartArt, hộp văn bản, mũi tên, hình ảnh, shape xoay và nhóm shape, nơi khung lưu trữ có thể không phản ánh đầy đủ kết quả render.

Sử dụng [Shape::getVisualBounds](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getVisualBounds) khi bạn cần tọa độ cho việc bố cục hoặc kiểm tra và không cần bitmap. Sử dụng [Shape::getImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getImage) khi bạn cần render shape. Với [ShapeThumbnailBounds](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` định kích thước ảnh từ giới hạn shape, bao gồm cài đặt viền, trong khi `ShapeThumbnailBounds::Appearance` định kích thước từ hiển thị của shape và giới hạn kết quả trong giới hạn slide. Ngược lại, `Shape::getVisualBounds` chỉ trả về hình chữ nhật được tính và không cắt nó theo slide.

## **Câu hỏi thường gặp**

**Các định dạng hình ảnh nào có thể được sử dụng khi lưu thumbnail của shape?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imageformat/), và các định dạng khác. Các shape cũng có thể [được xuất dưới dạng SVG vector](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/writeassvg/) bằng cách lưu nội dung shape dưới dạng SVG.

**Sự khác biệt giữa giới hạn Shape và Appearance khi render thumbnail là gì?**

`Shape` sử dụng hình học của shape; `Appearance` tính đến [các hiệu ứng trực quan](/slides/vi/php-java/shape-effect/) (bóng, phát sáng, v.v.).

**Nếu một shape được đánh dấu là ẩn thì sẽ xảy ra gì? Nó vẫn được render thành thumbnail không?**

Một shape ẩn vẫn là một phần của mô hình và có thể được render; cờ ẩn chỉ ảnh hưởng đến việc hiển thị trong slideshow mà không ngăn việc tạo ảnh của shape.

**Các shape nhóm, biểu đồ, SmartArt và các đối tượng phức tạp khác có được hỗ trợ không?**

Có. Bất kỳ đối tượng nào được biểu diễn dưới dạng [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) (bao gồm [GroupShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/), và [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/)) đều có thể được lưu thành thumbnail hoặc SVG.

**Phông chữ được cài đặt trên hệ thống có ảnh hưởng đến chất lượng thumbnail của các shape chứa văn bản không?**

Có. Bạn nên [cung cấp các phông chữ cần thiết](/slides/vi/php-java/custom-font/) (hoặc [cấu hình thay thế phông chữ](/slides/vi/php-java/font-substitution/)) để tránh việc fallback không mong muốn và lỗi bố cục lại văn bản.