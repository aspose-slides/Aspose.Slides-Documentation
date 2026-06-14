---
title: Tạo ảnh thu nhỏ cho các hình dạng trong bài thuyết trình bằng PHP
linktitle: Ảnh thu nhỏ hình dạng
type: docs
weight: 70
url: /vi/php-java/create-shape-thumbnails/
keywords:
- ảnh thu nhỏ hình dạng
- hình ảnh hình dạng
- kết xuất hình dạng
- kết xuất hình dạng
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tạo ảnh thu nhỏ hình dạng chất lượng cao từ các slide PowerPoint với Aspose.Slides cho PHP qua Java – dễ dàng tạo và xuất ảnh thu nhỏ cho bài thuyết trình."
---
## **Giới thiệu**

Aspose.Slides được sử dụng để tạo tệp trình chiếu trong đó mỗi trang là một slide. Các slide này có thể được xem bằng cách mở tệp trình chiếu bằng Microsoft PowerPoint. Tuy nhiên, đôi khi các nhà phát triển cần xem hình ảnh của các hình dạng riêng biệt trong một trình xem ảnh. Trong những trường hợp như vậy, Aspose.Slides giúp bạn tạo ảnh thu nhỏ của các hình dạng trong slide. Cách sử dụng tính năng này được mô tả trong bài viết này.

Bài viết này giải thích cách tạo ảnh thu nhỏ slide theo các cách khác nhau:

- Tạo ảnh thu nhỏ hình dạng bên trong một slide.
- Tạo ảnh thu nhỏ hình dạng cho một slide shape với kích thước do người dùng xác định.
- Tạo ảnh thu nhỏ hình dạng trong giới hạn của cách hiển thị của hình dạng.

## **Tạo ảnh thu nhỏ hình dạng từ một slide**
Để tạo ảnh thu nhỏ hình dạng từ bất kỳ slide nào bằng Aspose.Slides cho PHP qua Java, thực hiện các bước sau:

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. Lấy [hình ảnh thu nhỏ hình dạng](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getImage) của slide đã tham chiếu với tỷ lệ mặc định.
1. Lưu hình ảnh thu nhỏ dưới định dạng ảnh bạn muốn.

Đoạn mã mẫu dưới đây cho thấy cách tạo ảnh thu nhỏ hình dạng từ một slide:

```php
  # Khởi tạo một lớp Presentation đại diện cho tệp bài thuyết trình
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Tạo một hình ảnh ở tỷ lệ đầy đủ
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Lưu hình ảnh vào đĩa ở định dạng PNG
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

## **Tạo ảnh thu nhỏ với hệ số tỷ lệ do người dùng xác định**
Để tạo ảnh thu nhỏ hình dạng của một slide bằng Aspose.Slides cho PHP qua Java, thực hiện các bước sau:

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. Lấy [hình ảnh thu nhỏ hình dạng](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getImage) của slide đã tham chiếu với kích thước do người dùng xác định.
1. Lưu hình ảnh thu nhỏ dưới định dạng ảnh bạn muốn.

Đoạn mã mẫu dưới đây cho thấy cách tạo ảnh thu nhỏ hình dạng dựa trên hệ số tỷ lệ đã định nghĩa:

```php
  # Khởi tạo một lớp Presentation đại diện cho tệp bài thuyết trình
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Tạo một hình ảnh ở tỷ lệ đầy đủ
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Lưu hình ảnh vào đĩa ở định dạng PNG
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

## **Tạo ảnh thu nhỏ hiển thị hình dạng dựa trên giới hạn**
Phương pháp tạo ảnh thu nhỏ cho các hình dạng này cho phép các nhà phát triển tạo ảnh thu nhỏ trong giới hạn của cách hiển thị hình dạng. Nó tính đến tất cả các hiệu ứng của hình dạng. Ảnh thu nhỏ hình dạng được tạo ra bị giới hạn bởi giới hạn của slide. Để tạo ảnh thu nhỏ cho một slide shape trong giới hạn của cách hiển thị, thực hiện các bước sau:

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Lấy tham chiếu của bất kỳ slide nào bằng ID hoặc chỉ mục của nó.
1. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với giới hạn hình dạng được sử dụng làm cách hiển thị.
1. Lưu hình ảnh thu nhỏ dưới định dạng ảnh bạn muốn.

Đoạn mã mẫu dưới đây dựa trên các bước trên:

```php
  # Khởi tạo một lớp Presentation đại diện cho tệp bài thuyết trình
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Tạo một hình ảnh ở tỷ lệ đầy đủ
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Lưu hình ảnh vào đĩa ở định dạng PNG
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

## **FAQ**

**Các định dạng ảnh nào có thể được sử dụng khi lưu ảnh thu nhỏ hình dạng?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imageformat/), và các định dạng khác. Các hình dạng cũng có thể được [xuất ra dưới dạng SVG vectơ](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/writeassvg/) bằng cách lưu nội dung của hình dạng dưới dạng SVG.

**Sự khác biệt giữa giới hạn Shape và Appearance khi render ảnh thu nhỏ là gì?**

`Shape` sử dụng hình học của hình dạng; `Appearance` tính đến [các hiệu ứng trực quan](/slides/vi/php-java/shape-effect/) (bóng, ánh hào quang, v.v.).

**Điều gì xảy ra nếu một hình dạng được đánh dấu là ẩn? Nó vẫn sẽ được render thành ảnh thu nhỏ không?**

Một hình dạng ẩn vẫn là một phần của mô hình và có thể được render; cờ ẩn chỉ ảnh hưởng đến việc hiển thị trong trình chiếu nhưng không ngăn việc tạo ảnh của hình dạng.

**Các nhóm hình dạng, biểu đồ, SmartArt và các đối tượng phức tạp khác có được hỗ trợ không?**

Có. Bất kỳ đối tượng nào được biểu diễn dưới dạng [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) (bao gồm [GroupShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/), và [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/)) đều có thể được lưu dưới dạng ảnh thu nhỏ hoặc SVG.

**Các phông chữ được cài đặt trên hệ thống có ảnh hưởng đến chất lượng ảnh thu nhỏ của các hình dạng văn bản không?**

Có. Bạn nên [cung cấp các phông chữ cần thiết](/slides/vi/php-java/custom-font/) (hoặc [cấu hình thay thế phông chữ](/slides/vi/php-java/font-substitution/)) để tránh việc thay thế không mong muốn và việc sắp xếp lại văn bản.