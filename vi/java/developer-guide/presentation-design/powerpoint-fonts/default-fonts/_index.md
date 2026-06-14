---
title: Xác định phông chữ mặc định cho bản trình chiếu trong Java
linktitle: Phông chữ mặc định
type: docs
weight: 30
url: /vi/java/default-font/
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
- bản trình chiếu
- Java
- Aspose.Slides
description: "Đặt phông chữ mặc định trong Aspose.Slides cho Java để đảm bảo chuyển đổi đúng PowerPoint (PPT, PPTX) và OpenDocument (ODP) sang PDF, XPS và hình ảnh."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định các phông chữ mặc định được sử dụng khi bản trình chiếu được hiển thị. Điều này hữu ích khi tạo ảnh thu nhỏ của slide hoặc xuất bản trình chiếu sang các định dạng như PDF và XPS. Các phông chữ mặc định được cấu hình thông qua `LoadOptions` trước khi bản trình chiếu được tải.

Phương thức `setDefaultRegularFont` xác định phông chữ mặc định cho văn bản thường, trong khi `setDefaultAsianFont` xác định phông chữ mặc định cho văn bản châu Á. Sau khi các tùy chọn này được thiết lập, bản trình chiếu có thể được tải và hiển thị bằng các phông chữ đã chỉ định.

## **Sử dụng phông chữ mặc định để hiển thị bản trình chiếu**
Aspose.Slides cho phép bạn đặt phông chữ mặc định để hiển thị bản trình chiếu dưới dạng PDF, XPS hoặc ảnh thu nhỏ. Bài viết này hướng dẫn cách định nghĩa DefaultRegularFont và DefaultAsianFont để sử dụng làm phông chữ mặc định. Vui lòng làm theo các bước dưới đây để tải phông chữ từ các thư mục bên ngoài bằng API Aspose.Slides cho Java:

1. Tạo một thể hiện của [LoadOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) thành phông chữ mong muốn. Trong ví dụ sau, tôi đã sử dụng Wingdings.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) thành phông chữ mong muốn. Tôi đã sử dụng Wingdings trong mẫu dưới đây.
1. Tải bản trình chiếu bằng cách sử dụng Presentation và đặt các tùy chọn tải.
1. Sau đó, tạo ảnh thu nhỏ slide, PDF và XPS để kiểm tra kết quả.

Mã thực hiện các bước trên được đưa ra dưới đây.

```java
// Sử dụng tùy chọn tải để xác định phông chữ mặc định cho văn bản thường và châu Á
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Tải bản trình chiếu
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Tạo ảnh thu nhỏ slide
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // lưu hình ảnh vào đĩa.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Tạo PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Tạo XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**DefaultRegularFont và DefaultAsianFont ảnh hưởng như thế nào—chỉ khi xuất hay còn ảnh thu nhỏ, PDF, XPS, HTML và SVG không?**

Họ tham gia vào quy trình hiển thị cho tất cả các đầu ra được hỗ trợ. Điều này bao gồm ảnh thu nhỏ slide, [PDF](/slides/vi/java/convert-powerpoint-to-pdf/), [XPS](/slides/vi/java/convert-powerpoint-to-xps/), [hình ảnh raster](/slides/vi/java/convert-powerpoint-to-png/), [HTML](/slides/vi/java/convert-powerpoint-to-html/), và [SVG](/slides/vi/java/render-a-slide-as-an-svg-image/), vì Aspose.Slides sử dụng cùng một logic bố cục và giải quyết glyph trên các mục tiêu này.

**Phông chữ mặc định có được áp dụng khi chỉ đọc và lưu một file PPTX mà không thực hiện bất kỳ quá trình hiển thị nào không?**

Không. Phông chữ mặc định chỉ quan trọng khi văn bản cần được đo và vẽ. Việc mở‑lưu trực tiếp một bản trình chiếu không thay đổi các đoạn phông chữ đã lưu hoặc cấu trúc của tệp. Phông chữ mặc định chỉ được sử dụng trong các thao tác hiển thị hoặc điều chỉnh lại bố cục văn bản.

**Nếu tôi thêm các thư mục phông chữ của mình hoặc cung cấp phông chữ từ bộ nhớ, chúng có được xem xét khi lựa chọn phông chữ mặc định không?**

Đúng. [Nguồn phông chữ tùy chỉnh](/slides/vi/java/custom-font/) mở rộng danh mục các họ và glyph có sẵn mà công cụ có thể sử dụng. Phông chữ mặc định và bất kỳ [quy tắc fallback](/slides/vi/java/fallback-font/) nào sẽ được giải quyết dựa trên các nguồn này trước, mang lại độ phủ rộng hơn và đáng tin cậy hơn trên máy chủ và trong các container.

**Phông chữ mặc định có ảnh hưởng đến các chỉ số văn bản (kerning, advance) và do đó đến việc ngắt dòng và đóng gói không?**

Đúng. Thay đổi phông chữ thay đổi các chỉ số glyph và có thể làm thay đổi cách ngắt dòng, đóng gói và phân trang trong quá trình hiển thị. Để duy trì sự ổn định của bố cục, [nhúng các phông chữ gốc](/slides/vi/java/embedded-font/) hoặc chọn các họ phông chữ mặc định và fallback có chỉ số tương thích.

**Có cần thiết phải đặt phông chữ mặc định nếu tất cả các phông chữ được sử dụng trong bản trình chiếu đã được nhúng không?**

Thường thì không cần thiết, vì [phông chữ đã nhúng](/slides/vi/java/embedded-font/) đã đảm bảo hiển thị nhất quán. Phông chữ mặc định vẫn hữu ích như một lớp bảo vệ cho các ký tự không được bao phủ bởi tập con đã nhúng hoặc khi một tệp kết hợp cả văn bản đã nhúng và chưa nhúng.