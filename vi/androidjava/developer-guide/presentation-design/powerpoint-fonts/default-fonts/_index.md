---
title: Chỉ định phông chữ mặc định cho bản trình chiếu trên Android
linktitle: Phông chữ mặc định
type: docs
weight: 30
url: /vi/androidjava/default-font/
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
- Android
- Java
- Aspose.Slides
description: "Đặt phông chữ mặc định trong Aspose.Slides cho Android qua Java để đảm bảo việc chuyển đổi PowerPoint (PPT, PPTX) và OpenDocument (ODP) sang PDF, XPS và hình ảnh một cách chính xác."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định phông chữ mặc định được sử dụng khi một bản trình chiếu được kết xuất. Điều này hữu ích khi tạo ảnh thu nhỏ của các slide hoặc xuất bản trình chiếu sang các định dạng như PDF và XPS. Phông chữ mặc định được cấu hình thông qua `LoadOptions` trước khi bản trình chiếu được tải.

Phương thức `setDefaultRegularFont` xác định phông chữ mặc định cho văn bản thường, trong khi `setDefaultAsianFont` xác định phông chữ mặc định cho văn bản châu Á. Sau khi các tùy chọn này được đặt, bản trình chiếu có thể được tải và kết xuất bằng các phông chữ đã chỉ định.

## **Sử dụng phông chữ mặc định để kết xuất bản trình chiếu**
Aspose.Slides cho phép bạn đặt phông chữ mặc định để kết xuất bản trình chiếu sang PDF, XPS hoặc ảnh thu nhỏ. Bài viết này hướng dẫn cách định nghĩa DefaultRegularFont và DefaultAsianFont để sử dụng làm phông chữ mặc định. Vui lòng làm theo các bước dưới đây để tải phông chữ từ các thư mục bên ngoài bằng cách sử dụng Aspose.Slides cho Android thông qua API Java:

1. Tạo một thể hiện của [LoadOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/LoadOptions).
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) đến phông chữ mong muốn. Trong ví dụ dưới đây, tôi đã sử dụng Wingdings.
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) đến phông chữ mong muốn. Tôi đã sử dụng Wingdings trong mẫu sau.
4. Tải bản trình chiếu bằng Presentation và thiết lập các tùy chọn tải.
5. Bây giờ, tạo ảnh thu nhỏ slide, PDF và XPS để xác minh kết quả.

Việc thực hiện các bước trên được đưa ra dưới đây.

```java
// Sử dụng tùy chọn tải để định nghĩa phông chữ mặc định cho văn bản thường và văn bản châu Á
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Tải bản trình chiếu
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Tạo ảnh thu nhỏ cho slide
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

**Cụ thể, DefaultRegularFont và DefaultAsianFont ảnh hưởng đến gì — chỉ xuất khẩu, hay còn cả ảnh thu nhỏ, PDF, XPS, HTML và SVG?**

Chúng tham gia vào quy trình kết xuất cho tất cả các đầu ra được hỗ trợ. Điều này bao gồm ảnh thu nhỏ của slide, [PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/vi/androidjava/convert-powerpoint-to-xps/), [hình raster](/slides/vi/androidjava/convert-powerpoint-to-png/), [HTML](/slides/vi/androidjava/convert-powerpoint-to-html/), và [SVG](/slides/vi/androidjava/render-a-slide-as-an-svg-image/), vì Aspose.Slides sử dụng cùng một logic bố cục và giải quyết glyph cho các mục tiêu này.

**Phông chữ mặc định có được áp dụng khi chỉ đọc và lưu một tệp PPTX mà không thực hiện bất kỳ việc kết xuất nào không?**

Không. Phông chữ mặc định chỉ có tác dụng khi văn bản cần được đo và vẽ. Việc mở và lưu trực tiếp một bản trình chiếu không làm thay đổi các đoạn phông chữ được lưu hoặc cấu trúc của tệp. Phông chữ mặc định sẽ được sử dụng trong các thao tác mà văn bản được kết xuất hoặc tái bố trí.

**Nếu tôi thêm các thư mục phông chữ của riêng mình hoặc cung cấp phông chữ từ bộ nhớ, chúng có được xem xét khi lựa chọn phông chữ mặc định không?**

Có. [Nguồn phông chữ tùy chỉnh](/slides/vi/androidjava/custom-font/) mở rộng danh mục các họ và glyph có sẵn mà engine có thể sử dụng. Phông chữ mặc định và bất kỳ [quy tắc dự phòng](/slides/vi/androidjava/fallback-font/) nào sẽ được giải quyết dựa trên các nguồn này trước, mang lại khả năng bao phủ đáng tin cậy hơn trên máy chủ và trong các container.

**Phông chữ mặc định có ảnh hưởng đến các chỉ số văn bản (kerning, độ tiến) và do đó tới việc ngắt dòng và ngắt vòng không?**

Có. Thay đổi phông chữ làm thay đổi các chỉ số glyph và có thể thay đổi cách ngắt dòng, vòng lại và phân trang trong quá trình kết xuất. Để duy trì sự ổn định của bố cục, [nhúng các phông chữ gốc](/slides/vi/androidjava/embedded-font/) hoặc chọn các họ phông chữ mặc định và dự phòng có tính đo lường tương thích.

**Có ý nghĩa gì khi đặt phông chữ mặc định nếu tất cả các phông chữ được sử dụng trong bản trình chiếu đã được nhúng không?**

Thường thì không cần thiết, vì [phông chữ được nhúng](/slides/vi/androidjava/embedded-font/) đã đảm bảo giao diện nhất quán. Phông chữ mặc định vẫn hữu ích như một biện pháp dự phòng cho các ký tự không được bao phủ bởi tập con đã nhúng hoặc khi một tệp kết hợp văn bản đã nhúng và chưa nhúng.