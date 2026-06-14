---
title: Chuyển đổi bản trình bày PowerPoint sang GIF động trong PHP
linktitle: PowerPoint sang GIF
type: docs
weight: 65
url: /vi/php-java/convert-powerpoint-to-animated-gif/
keywords:
- GIF động
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang GIF
- bản trình bày sang GIF
- slide sang GIF
- PPT sang GIF
- PPTX sang GIF
- lưu PPT dưới dạng GIF
- lưu PPTX dưới dạng GIF
- xuất PPT dưới dạng GIF
- xuất PPTX dưới dạng GIF
- cài đặt mặc định
- cài đặt tùy chỉnh
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Dễ dàng chuyển đổi bản trình bày PowerPoint (PPT, PPTX) sang GIF động với Aspose.Slides cho PHP qua Java. Nhanh, kết quả chất lượng cao."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chuyển đổi các bản trình bày PowerPoint sang tệp GIF động chỉ với vài dòng mã. Điều này hữu ích khi bạn cần chia sẻ nội dung slide dưới dạng nhẹ, được hỗ trợ rộng rãi và có thể nhúng vào trang web, ứng dụng nhắn tin hoặc tài liệu. Bài viết này giải thích cách xuất bản trình bày sang GIF bằng cài đặt mặc định và cách tùy chỉnh đầu ra bằng cách cấu hình các tùy chọn như kích thước khung, độ trễ slide và tốc độ khung chuyển đổi thông qua [GifOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/gifoptions/).

## **Chuyển Đổi Bản Trình Bày Sang GIF Động Bằng Cài Đặt Mặc Định**

Mã mẫu này cho bạn thấy cách chuyển đổi một bản trình bày sang GIF động bằng cài đặt tiêu chuẩn:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

GIF động sẽ được tạo với các tham số mặc định. 

{{%  alert  title="TIP"  color="primary"  %}} 
Nếu bạn muốn tùy chỉnh các tham số cho GIF, bạn có thể sử dụng lớp [GifOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/GifOptions). Xem mã mẫu bên dưới. 
{{% /alert %}} 

## **Chuyển Đổi Bản Trình Bày Sang GIF Động Bằng Cài Đặt Tùy Chỉnh**

Mã mẫu này cho bạn thấy cách chuyển đổi một bản trình bày sang GIF động bằng cài đặt tùy chỉnh :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// kích thước của GIF kết quả

    $gifOptions->setDefaultDelay(2000);// thời gian mỗi slide được hiển thị cho đến khi chuyển sang slide tiếp theo

    $gifOptions->setTransitionFps(35);// tăng FPS để cải thiện chất lượng hoạt ảnh chuyển tiếp

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
Bạn có thể muốn xem công cụ chuyển đổi MIỄN PHÍ [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif) được phát triển bởi Aspose. 
{{% /alert %}}

## **Câu Hỏi Thường Gặp**

**Nếu các phông chữ được sử dụng trong bản trình bày không được cài đặt trên hệ thống thì sao?**

Cài đặt các phông chữ thiếu hoặc [cấu hình phông chữ dự phòng](/slides/vi/php-java/powerpoint-fonts/). Aspose.Slides sẽ thay thế, nhưng giao diện có thể khác nhau. Đối với thương hiệu, luôn đảm bảo các phông chữ cần thiết được cung cấp một cách rõ ràng.

**Tôi có thể đặt một dấu nước lên các khung GIF không?**

Có. [Thêm một đối tượng/logo bán trong suốt](/slides/vi/php-java/watermark/) vào slide chủ đề hoặc vào từng slide riêng trước khi xuất — dấu nước sẽ xuất hiện trên mỗi khung.