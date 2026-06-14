---
title: "Hiển thị Bản trình chiếu với Phông chữ Dự phòng trong PHP"
linktitle: "Hiển thị Bản trình chiếu"
type: docs
weight: 30
url: /vi/php-java/render-presentation-with-fallback-font/
keywords:
- "phông chữ dự phòng"
- "hiển thị PowerPoint"
- "hiển thị bản trình chiếu"
- "hiển thị slide"
- "PowerPoint"
- "OpenDocument"
- "bản trình chiếu"
- "PHP"
- "Aspose.Slides"
description: "Hiển thị bản trình chiếu với phông chữ dự phòng trong Aspose.Slides cho PHP qua Java – giữ cho văn bản nhất quán giữa PPT, PPTX và ODP với các mẫu mã từng bước."
---
## **Tổng quan**

Aspose.Slides cho phép bạn hiển thị các bài thuyết trình bằng cách sử dụng các quy tắc phông chữ dự phòng. Bài viết này hướng dẫn cách tạo bộ sưu tập quy tắc phông chữ dự phòng, chỉnh sửa các quy tắc bằng cách xóa hoặc thêm phông chữ dự phòng, và gán bộ sưu tập này cho phương thức `FontsManager::setFontFallBackRulesCollection`.

Khi bộ sưu tập quy tắc phông chữ dự phòng được gán cho `FontsManager` của bản trình chiếu, các quy tắc sẽ được áp dụng trong các thao tác như lưu, hiển thị và chuyển đổi bản trình chiếu. Ví dụ minh họa cách sử dụng các quy tắc đã cấu hình khi hiển thị ảnh thu nhỏ của slide và lưu nó dưới dạng ảnh PNG.

## **Hiển thị một Slide bằng Quy tắc Phông chữ Dự phòng**

Ví dụ sau đây bao gồm các bước sau:

1. Chúng tôi [tạo bộ sưu tập quy tắc phông chữ dự phòng](/slides/vi/php-java/create-fallback-fonts-collection/).
1. [Xóa](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) một quy tắc phông chữ dự phòng và [addFallBackFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) vào một quy tắc khác.
1. Đặt bộ sưu tập quy tắc cho phương thức [getFontsManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) method.
1. Với phương thức [Presentation.save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation#save-java.lang.String-int-) chúng ta có thể lưu bản trình chiếu ở cùng định dạng, hoặc lưu nó ở định dạng khác. Khi bộ sưu tập quy tắc phông chữ dự phòng được gán cho [FontsManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FontsManager), các quy tắc này sẽ được áp dụng trong mọi thao tác trên bản trình chiếu: lưu, hiển thị, chuyển đổi, v.v.

```php
  # Tạo một thể hiện mới của bộ sưu tập quy tắc
  $rulesList = new FontFallBackRulesCollection();
  # tạo một số quy tắc
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Cố gắng xóa phông chữ dự phòng "Tahoma" khỏi các quy tắc đã tải
    $fallBackRule->remove("Tahoma");
    # Và cập nhật các quy tắc cho phạm vi chỉ định
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Ngoài ra chúng ta có thể xóa bất kỳ quy tắc nào hiện có khỏi danh sách
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Gán danh sách quy tắc đã chuẩn bị để sử dụng
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Hiển thị ảnh thu nhỏ bằng cách sử dụng bộ sưu tập quy tắc đã khởi tạo và lưu dưới dạng JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Lưu ảnh ra đĩa ở định dạng JPEG
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
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

{{% alert color="primary" %}} 
Đọc thêm về cách [Chuyển đổi PPT và PPTX sang JPG trong PHP](/slides/vi/php-java/convert-powerpoint-to-jpg/).
{{% /alert %}}