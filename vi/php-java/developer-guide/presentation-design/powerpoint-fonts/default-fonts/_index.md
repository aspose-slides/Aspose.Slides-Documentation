---
title: Xác định phông chữ mặc định cho trình chiếu trong PHP
linktitle: Phông chữ mặc định
type: docs
weight: 30
url: /vi/php-java/default-font/
keywords:
- phông chữ mặc định
- phông chữ thường
- phông chữ bình thường
- phông chữ châu Á
- xuất PDF
- xuất XPS
- xuất hình ảnh
- PowerPoint
- OpenDocument
- trình chiếu
- PHP
- Aspose.Slides
description: "Đặt phông chữ mặc định trong Aspose.Slides cho PHP qua Java để đảm bảo việc chuyển đổi PowerPoint (PPT, PPTX) và OpenDocument (ODP) sang PDF, XPS và hình ảnh một cách chính xác."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định các phông chữ mặc định được sử dụng khi trình chiếu được kết xuất. Điều này hữu ích khi tạo ảnh thu nhỏ của slide hoặc xuất một trình chiếu ra các định dạng như PDF và XPS. Các phông chữ mặc định được cấu hình thông qua `LoadOptions` trước khi trình chiếu được tải.

Phương thức `setDefaultRegularFont` xác định phông chữ mặc định cho văn bản thường, trong khi `setDefaultAsianFont` xác định phông chữ mặc định cho văn bản Châu Á. Sau khi các tùy chọn này được đặt, trình chiếu có thể được tải và kết xuất bằng các phông chữ đã chỉ định.

## **Sử dụng phông chữ mặc định để kết xuất một trình chiếu**
Aspose.Slides cho phép bạn đặt phông chữ mặc định để kết xuất trình chiếu sang PDF, XPS hoặc ảnh thu nhỏ. Bài viết này hướng dẫn cách xác định DefaultRegular Font và DefaultAsian Font để sử dụng làm phông chữ mặc định. Vui lòng làm theo các bước dưới đây để tải phông chữ từ các thư mục bên ngoài bằng cách sử dụng Aspose.Slides cho PHP qua API Java:

1. Tạo một thể hiện của [LoadOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LoadOptions).
1. [Đặt DefaultRegularFont](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) thành phông chữ mong muốn của bạn. Trong ví dụ dưới đây, tôi đã sử dụng Wingdings.
1. [Đặt DefaultAsianFont](https://reference.aspose.com/slides/vi/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) thành phông chữ mong muốn của bạn. Tôi đã sử dụng Wingdings trong mẫu dưới đây.
1. Tải trình chiếu bằng cách sử dụng Presentation và thiết lập các tùy chọn tải.
1. Bây giờ, tạo ảnh thu nhỏ slide, PDF và XPS để xác minh kết quả.

Triển khai các bước trên được đưa ra dưới đây.

```php
  # Sử dụng tùy chọn tải để xác định phông chữ mặc định cho văn bản thường và châu Á
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Tải trình chiếu
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Tạo ảnh thu nhỏ slide
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # lưu hình ảnh vào đĩa.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Tạo PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Tạo XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**DefaultRegularFont và DefaultAsianFont ảnh hưởng cụ thể tới gì—chỉ xuất khẩu, hay còn cả ảnh thu nhỏ, PDF, XPS, HTML và SVG?**

Chúng tham gia vào quy trình kết xuất cho tất cả các đầu ra được hỗ trợ. Điều này bao gồm ảnh thu nhỏ slide, [PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/vi/php-java/convert-powerpoint-to-xps/), [hình raster](/slides/vi/php-java/convert-powerpoint-to-png/), [HTML](/slides/vi/php-java/convert-powerpoint-to-html/), và [SVG](/slides/vi/php-java/render-a-slide-as-an-svg-image/), vì Aspose.Slides sử dụng cùng một logic bố trí và giải quyết glyph cho các mục tiêu này.

**Phông chữ mặc định có được áp dụng khi chỉ đọc và lưu một tệp PPTX mà không thực hiện bất kỳ kết xuất nào không?**

Không. Phông chữ mặc định chỉ quan trọng khi văn bản cần được đo và vẽ. Việc mở‑lưu trực tiếp một trình chiếu không thay đổi các đoạn phông chữ đã lưu hoặc cấu trúc của tệp. Phông chữ mặc định chỉ xuất hiện trong các thao tác mà văn bản được kết xuất hoặc sắp xếp lại.

**Nếu tôi thêm thư mục phông chữ của riêng mình hoặc cung cấp phông chữ từ bộ nhớ, chúng có được xem xét khi chọn phông chữ mặc định không?**

Có. [Nguồn phông chữ tùy chỉnh](/slides/vi/php-java/custom-font/) mở rộng danh mục các họ và glyph có sẵn mà engine có thể sử dụng. Phông chữ mặc định và bất kỳ [quy tắc dự phòng](/slides/vi/php-java/fallback-font/) nào sẽ được giải quyết dựa trên các nguồn này trước, mang lại khả năng bao phủ đáng tin cậy hơn trên máy chủ và trong container.

**Phông chữ mặc định có ảnh hưởng đến các chỉ số văn bản (kerning, advance) và do đó ảnh hưởng đến ngắt dòng và việc gói văn bản không?**

Có. Thay đổi phông chữ sẽ thay đổi các chỉ số glyph và có thể thay đổi ngắt dòng, việc gói và phân trang trong quá trình kết xuất. Để duy trì ổn định bố cục, [nhúng các phông chữ gốc](/slides/vi/php-java/embedded-font/) hoặc chọn các họ phông chữ mặc định và dự phòng tương thích về mặt chỉ số.

**Có cần thiết phải thiết lập phông chữ mặc định nếu tất cả các phông chữ được sử dụng trong trình chiếu đã được nhúng không?**

Thường thì không cần thiết, vì [phông chữ đã nhúng](/slides/vi/php-java/embedded-font/) đã đảm bảo sự nhất quán về giao diện. Phông chữ mặc định vẫn hữu ích như một lớp bảo hiểm cho các ký tự không được bao phủ bởi tập con đã nhúng hoặc khi một tệp kết hợp văn bản đã nhúng và chưa nhúng.