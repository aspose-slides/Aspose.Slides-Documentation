---
title: Xác định phông chữ mặc định cho bản trình bày trong .NET
linktitle: Phông chữ mặc định
type: docs
weight: 30
url: /vi/net/default-font/
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
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Đặt phông chữ mặc định trong Aspose.Slides cho .NET để đảm bảo việc chuyển đổi chính xác PowerPoint (PPT, PPTX) và OpenDocument (ODP) sang PDF, XPS và hình ảnh."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định phông chữ mặc định được sử dụng khi một bản trình bày được hiển thị. Điều này hữu ích khi tạo ảnh thu nhỏ của slide hoặc xuất bản trình bày sang các định dạng như PDF và XPS. Phông chữ mặc định được cấu hình thông qua `LoadOptions` trước khi bản trình bày được tải.

Thuộc tính `DefaultRegularFont` định nghĩa phông chữ mặc định cho văn bản bình thường, trong khi `DefaultAsianFont` định nghĩa phông chữ mặc định cho văn bản châu Á. Sau khi các tùy chọn này được đặt, bản trình bày có thể được tải và hiển thị bằng các phông chữ đã chỉ định.

## **Sử dụng phông chữ mặc định để hiển thị bản trình bày**
Aspose.Slides cho phép bạn đặt phông chữ mặc định để hiển thị bản trình bày thành PDF, XPS hoặc ảnh thu nhỏ. Bài viết này chỉ ra cách định nghĩa DefaultRegularFont và DefaultAsianFont để sử dụng làm phông chữ mặc định. Vui lòng thực hiện các bước dưới đây để tải phông chữ từ các thư mục bên ngoài bằng API Aspose.Slides cho .NET:

1. Tạo một thể hiện của LoadOptions.
2. Đặt DefaultRegularFont thành phông chữ mong muốn của bạn. Trong ví dụ sau, tôi đã sử dụng Wingdings.
3. Đặt DefaultAsianFont thành phông chữ mong muốn của bạn. Tôi đã sử dụng Wingdings trong mẫu sau.
4. Tải bản trình bày bằng cách sử dụng Presentation và thiết lập các tùy chọn tải.
5. Bây giờ, tạo ảnh thu nhỏ slide, PDF và XPS để kiểm tra kết quả.

Việc thực hiện các bước trên được đưa ra dưới đây.

```c#
// Sử dụng các tùy chọn tải để chỉ định phông chữ mặc định cho văn bản thường và văn bản châu Á
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```

## **Câu hỏi thường gặp**

**DefaultRegularFont và DefaultAsianFont ảnh hưởng cụ thể đến gì — chỉ xuất khẩu hay còn ảnh thu nhỏ, PDF, XPS, HTML và SVG?**

Chúng tham gia vào quy trình hiển thị cho tất cả các đầu ra được hỗ trợ. Điều này bao gồm ảnh thu nhỏ slide, [PDF](/slides/vi/net/convert-powerpoint-to-pdf/), [XPS](/slides/vi/net/convert-powerpoint-to-xps/), [raster images](/slides/vi/net/convert-powerpoint-to-png/), [HTML](/slides/vi/net/convert-powerpoint-to-html/), và [SVG](/slides/vi/net/render-a-slide-as-an-svg-image/), vì Aspose.Slides sử dụng cùng logic bố cục và giải quyết glyph cho các mục tiêu này.

**Phông chữ mặc định có được áp dụng khi chỉ đọc và lưu một PPTX mà không có bất kỳ quá trình hiển thị nào không?**

Không. Phông chữ mặc định chỉ quan trọng khi văn bản cần được đo và vẽ. Một thao tác mở‑lưu trực tiếp một bản trình bày sẽ không thay đổi các đoạn phông chữ lưu trữ hoặc cấu trúc của tệp. Phông chữ mặc định sẽ được áp dụng trong các hoạt động render hoặc tái bố trí văn bản.

**Nếu tôi thêm các thư mục phông chữ của riêng mình hoặc cung cấp phông chữ từ bộ nhớ, chúng có được xem xét khi chọn phông chữ mặc định không?**

Có. [Custom font sources](/slides/vi/net/custom-font/) mở rộng danh mục các họ và glyph có sẵn mà engine có thể sử dụng. Phông chữ mặc định và bất kỳ [fallback rules](/slides/vi/net/fallback-font/) sẽ được giải quyết dựa trên các nguồn đó trước, mang lại phủ sóng đáng tin cậy hơn trên máy chủ và trong container.

**Phông chữ mặc định có ảnh hưởng đến các chỉ số văn bản (kerning, advances) và do đó tới ngắt dòng và gói văn bản không?**

Có. Thay đổi phông chữ sẽ thay đổi các chỉ số glyph và có thể làm thay đổi ngắt dòng, gói văn bản và phân trang trong quá trình render. Để duy trì sự ổn định bố cục, [embed the original fonts](/slides/vi/net/embedded-font/) hoặc chọn các họ phông chữ mặc định và dự phòng tương thích về mặt chỉ số.

**Có lợi gì trong việc đặt phông chữ mặc định nếu tất cả phông chữ sử dụng trong bản trình bày đã được nhúng không?**

Thường không cần thiết, vì [embedded fonts](/slides/vi/net/embedded-font/) đã đảm bảo giao diện nhất quán. Phông chữ mặc định vẫn hữu ích như một mạng lưới an toàn cho các ký tự không được bao phủ bởi tập con đã nhúng hoặc khi một tệp kết hợp văn bản đã nhúng và chưa nhúng.