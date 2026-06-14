---
title: Nhúng phông chữ trong bản trình bày bằng PHP
linktitle: Nhúng phông chữ
type: docs
weight: 40
url: /vi/php-java/embedded-font/
keywords:
- thêm phông chữ
- nhúng phông chữ
- nhúng phông chữ
- lấy phông chữ đã nhúng
- thêm phông chữ đã nhúng
- xóa phông chữ đã nhúng
- nén phông chữ đã nhúng
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Nhúng phông chữ TrueType vào các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho PHP thông qua Java, đảm bảo việc render chính xác trên mọi nền tảng."
---
## **Giới thiệu**

**Phông chữ được nhúng trong PowerPoint** hữu ích khi bạn muốn bản trình bày của mình hiển thị chính xác trên bất kỳ hệ thống hoặc thiết bị nào. Nếu bạn đã sử dụng phông chữ của bên thứ ba hoặc không chuẩn vì muốn sáng tạo trong công việc, thì bạn có thêm lý do để nhúng phông chữ. Ngược lại (không có phông chữ được nhúng), văn bản hoặc số trên các slide, bố cục, kiểu dáng, v.v. có thể thay đổi hoặc biến thành các hình chữ nhật gây khó hiểu. 

Các lớp [FontsManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontsManager), [FontData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontdata/) và [Compress](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/) chứa hầu hết các phương thức bạn cần để làm việc với phông chữ được nhúng trong bản trình bày PowerPoint.

## **Lấy và Xóa Phông chữ được Nhúng**

Aspose.Slides cung cấp phương thức [getEmbeddedFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) (được mở ra bởi lớp [FontsManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontsManager)) để cho phép bạn lấy (hoặc biết) các phông chữ đã được nhúng trong một bản trình bày. Để xóa phông chữ, phương thức [removeEmbeddedFont](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) (cũng được mở ra bởi cùng lớp) được sử dụng.

Đoạn mã PHP này cho bạn thấy cách lấy và xóa phông chữ được nhúng khỏi một bản trình bày:

```php
  # Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình bày
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Kết xuất một slide chứa khung văn bản sử dụng phông chữ được nhúng "FunSized"
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Lưu hình ảnh vào đĩa ở định dạng JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Lấy tất cả các phông chữ đã nhúng
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Tìm phông chữ "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # Xóa phông chữ "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Kết xuất bản trình bày; "Calibri" phông chữ được thay thế bằng một phông chữ hiện có
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Lưu hình ảnh vào đĩa ở định dạng JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Lưu bản trình bày mà không có phông chữ "Calibri" được nhúng vào đĩa
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thêm Phông chữ được Nhúng**

Sử dụng lớp [EmbedFontCharacters](https://reference.aspose.com/slides/vi/php-java/aspose.slides/embedfontcharacters/) và hai overload của phương thức [addEmbeddedFont](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/#addEmbeddedFont), bạn có thể chọn quy tắc (nhúng) ưa thích để nhúng phông chữ trong một bản trình bày. Đoạn mã PHP này cho bạn thấy cách nhúng và thêm phông chữ vào một bản trình bày:

```php
  # Tải bản trình bày
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # Lưu bản trình bày vào đĩa
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nén Phông chữ được Nhúng**

Để cho phép bạn nén các phông chữ đã được nhúng trong một bản trình bày và giảm kích thước tệp, Aspose.Slides cung cấp phương thức [compressEmbeddedFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/#compressEmbeddedFonts) (được mở ra bởi lớp [Compress](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/)).

Đoạn mã PHP này cho bạn thấy cách nén các phông chữ PowerPoint đã được nhúng:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể biết rằng một phông chữ cụ thể trong bản trình bày vẫn sẽ bị thay thế trong quá trình render dù đã nhúng?**

Kiểm tra [thông tin thay thế](/slides/vi/php-java/font-substitution/) trong trình quản lý phông chữ và [quy tắc dự phòng/thay thế](/slides/vi/php-java/fallback-font/): nếu phông chữ không khả dụng hoặc bị hạn chế, một phông chữ dự phòng sẽ được sử dụng.

**Có đáng để nhúng các phông chữ “hệ thống” như Arial/Calibri không?**

Thông thường không—chúng gần như luôn có sẵn. Nhưng đối với khả năng di động hoàn toàn trong các môi trường “gọn” (Docker, máy chủ Linux không có phông chữ được cài trước), việc nhúng phông chữ hệ thống có thể loại bỏ rủi ro thay thế không mong muốn.