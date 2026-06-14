---
title: Chỉ định phông chữ mặc định cho bản trình chiếu trong JavaScript
linktitle: Phông chữ mặc định
type: docs
weight: 30
url: /vi/nodejs-java/default-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Đặt phông chữ mặc định trong Aspose.Slides cho Node.js qua Java để đảm bảo chuyển đổi chính xác PowerPoint (PPT, PPTX) và OpenDocument (ODP) sang PDF, XPS và hình ảnh."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định các phông chữ mặc định được sử dụng khi bản trình chiếu được kết xuất. Điều này hữu ích khi tạo hình thu nhỏ các slide hoặc xuất bản trình chiếu sang các định dạng như PDF và XPS. Các phông chữ mặc định được cấu hình thông qua `LoadOptions` trước khi tải bản trình chiếu.

Phương thức `setDefaultRegularFont` xác định phông chữ mặc định cho văn bản thường, trong khi `setDefaultAsianFont` xác định phông chữ mặc định cho văn bản châu Á. Sau khi các tùy chọn này được thiết lập, bản trình chiếu có thể được tải và kết xuất bằng các phông chữ đã chỉ định.

## **Sử dụng Phông chữ Mặc định để Kết xuất Bản trình chiếu**

Aspose.Slides cho phép bạn đặt phông chữ mặc định để kết xuất bản trình chiếu sang PDF, XPS hoặc hình thu nhỏ. Bài viết này mô tả cách định nghĩa DefaultRegular Font và DefaultAsian Font để sử dụng làm phông chữ mặc định. Vui lòng làm theo các bước dưới đây để tải phông chữ từ các thư mục bên ngoài bằng cách sử dụng Aspose.Slides cho Node.js thông qua Java API:

1. Tạo một thể hiện của [LoadOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/LoadOptions).
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) tới phông chữ bạn muốn. Trong ví dụ dưới đây, tôi đã sử dụng Wingdings.
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) tới phông chữ bạn muốn. Tôi đã sử dụng Wingdings trong mẫu sau.
4. Tải bản trình chiếu bằng cách sử dụng Presentation và thiết lập các tùy chọn tải.
5. Bây giờ, tạo hình thu nhỏ slide, PDF và XPS để xác nhận kết quả.

Cài đặt của phần trên được đưa ra bên dưới.

```javascript
// Sử dụng tùy chọn tải để xác định phông chữ mặc định thường và châu Á
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Tải bản trình chiếu
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Tạo hình thu nhỏ slide
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // lưu hình ảnh vào đĩa.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Tạo PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // Tạo XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**DefaultRegularFont và DefaultAsianFont ảnh hưởng chính xác như thế nào—chỉ xuất khẩu, hay còn cả hình thu nhỏ, PDF, XPS, HTML và SVG?**

Chúng tham gia vào quy trình kết xuất cho tất cả các đầu ra được hỗ trợ. Điều này bao gồm hình thu nhỏ các slide, [PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/vi/nodejs-java/convert-powerpoint-to-xps/), [hình ảnh raster](/slides/vi/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/vi/nodejs-java/convert-powerpoint-to-html/), và [SVG](/slides/vi/nodejs-java/render-a-slide-as-an-svg-image/), vì Aspose.Slides sử dụng cùng một logic bố cục và giải quyết glyph cho các mục tiêu này.

**Phông chữ mặc định có được áp dụng khi chỉ đọc và lưu một tệp PPTX mà không thực hiện bất kỳ việc kết xuất nào không?**

Không. Phông chữ mặc định chỉ quan trọng khi văn bản cần được đo và vẽ. Việc mở‑lưu trực tiếp một bản trình chiếu không thay đổi các đoạn phông chữ đã lưu hoặc cấu trúc tệp. Phông chữ mặc định chỉ hoạt động trong các thao tác kết xuất hoặc sắp xếp lại văn bản.

**Nếu tôi thêm các thư mục phông chữ của riêng mình hoặc cung cấp phông chữ từ bộ nhớ, chúng sẽ được xem xét khi chọn phông chữ mặc định không?**

Có. [Custom font sources](/slides/vi/nodejs-java/custom-font/) mở rộng danh mục các họ phông chữ và glyph có sẵn mà engine có thể sử dụng. Phông chữ mặc định và bất kỳ [fallback rules](/slides/vi/nodejs-java/fallback-font/) nào sẽ được giải quyết dựa trên các nguồn này trước, cung cấp độ bao phủ đáng tin cậy hơn trên máy chủ và trong container.

**Phông chữ mặc định có ảnh hưởng đến số liệu văn bản (kerning, độ tiến) và do đó tới ngắt dòng và bọc văn bản không?**

Có. Thay đổi phông chữ sẽ thay đổi số liệu glyph và có thể làm thay đổi ngắt dòng, bọc văn bản và phân trang trong quá trình kết xuất. Để duy trì sự ổn định bố cục, [embed the original fonts](/slides/vi/nodejs-java/embedded-font/) hoặc chọn các họ phông chữ mặc định và fallback tương thích về mặt số liệu.

**Có cần thiết phải đặt phông chữ mặc định nếu tất cả phông chữ được sử dụng trong bản trình chiếu đều được nhúng không?**

Thường thì không cần thiết, vì [embedded fonts](/slides/vi/nodejs-java/embedded-font/) đã đảm bảo sự nhất quán về hiển thị. Phông chữ mặc định vẫn hữu ích như một lớp bảo vệ cho các ký tự không được bao phủ bởi tập con nhúng hoặc khi một tệp kết hợp văn bản nhúng và không nhúng.