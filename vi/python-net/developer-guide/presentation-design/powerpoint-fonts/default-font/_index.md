---
title: Tùy chỉnh phông chữ mặc định trong trình chiếu bằng Python
linktitle: Phông chữ mặc định
type: docs
weight: 30
url: /vi/python-net/default-font/
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
- Python
- Aspose.Slides
description: "Đặt phông chữ mặc định trong Aspose.Slides cho Python để đảm bảo chuyển đổi đúng PowerPoint (PPT, PPTX) và OpenDocument (ODP) sang PDF, XPS và hình ảnh."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định các phông chữ mặc định được sử dụng khi trình chiếu được render. Điều này hữu ích khi tạo hình thu nhỏ của các slide hoặc xuất bản trình chiếu sang các định dạng như PDF và XPS. Các phông chữ mặc định được cấu hình thông qua `LoadOptions` trước khi trình chiếu được tải.

Thuộc tính `default_regular_font` xác định phông chữ mặc định cho văn bản thường, trong khi `default_asian_font` xác định phông chữ mặc định cho văn bản châu Á. Sau khi thiết lập các tùy chọn này, trình chiếu có thể được tải và render bằng các phông chữ đã chỉ định.

## **Sử dụng phông chữ mặc định để render trình chiếu**
Aspose.Slides cho phép bạn đặt phông chữ mặc định để render trình chiếu sang PDF, XPS hoặc hình thu nhỏ. Bài viết này hướng dẫn cách định nghĩa DefaultRegularFont và DefaultAsianFont để sử dụng làm phông chữ mặc định. Vui lòng thực hiện các bước sau để tải phông chữ từ các thư mục bên ngoài bằng Aspose.Slides cho Python thông qua .NET API:

1. Tạo một thể hiện của LoadOptions.
1. Đặt DefaultRegularFont thành phông chữ bạn muốn. Trong ví dụ dưới đây, tôi đã sử dụng Wingdings.
1. Đặt DefaultAsianFont thành phông chữ bạn muốn. Tôi đã sử dụng Wingdings trong mẫu sau.
1. Tải trình chiếu bằng Presentation và thiết lập các tùy chọn tải.
1. Bây giờ, tạo hình thu nhỏ của slide, PDF và XPS để xác minh kết quả.

Cài đặt của phần trên được cung cấp bên dưới.

```py
import aspose.slides as slides

# Sử dụng tùy chọn tải để xác định phông chữ mặc định cho văn bản thường và văn bản châu Á# Sử dụng tùy chọn tải để xác định phông chữ mặc định cho văn bản thường và văn bản châu Á
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Tải trình chiếu
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Tạo hình thu nhỏ của slide
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Tạo PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Tạo XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```


## **Câu hỏi thường gặp**

**Thực sự các thuộc tính default_regular_font và default_asian_font ảnh hưởng đến gì — chỉ xuất khẩu hay cả hình thu nhỏ, PDF, XPS, HTML và SVG?**

Chúng tham gia vào pipeline render cho tất cả các đầu ra được hỗ trợ. Điều này bao gồm hình thu nhỏ của slide, [PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/vi/python-net/convert-powerpoint-to-xps/), [hình raster](/slides/vi/python-net/convert-powerpoint-to-png/), [HTML](/slides/vi/python-net/convert-powerpoint-to-html/), và [SVG](/slides/vi/python-net/render-a-slide-as-an-svg-image/), bởi vì Aspose.Slides sử dụng cùng một logic bố cục và giải quyết glyph cho các mục tiêu này.

**Phông chữ mặc định có được áp dụng khi chỉ đọc và lưu một tệp PPTX mà không thực hiện render nào không?**

Không. Phông chữ mặc định chỉ quan trọng khi văn bản phải được đo lường và vẽ. Một hành động mở‑lưu đơn giản của trình chiếu không thay đổi các chuỗi phông chữ đã lưu hoặc cấu trúc của tệp. Phông chữ mặc định sẽ được sử dụng trong các thao tác render hoặc tái bố trí văn bản.

**Nếu tôi thêm các thư mục phông chữ của riêng mình hoặc cung cấp phông chữ từ bộ nhớ, chúng có được xem xét khi chọn phông chữ mặc định không?**

Có. [Custom font sources](/slides/vi/python-net/custom-font/) mở rộng danh mục các họ và glyph có sẵn mà công cụ có thể sử dụng. Phông chữ mặc định và bất kỳ [fallback rules](/slides/vi/python-net/fallback-font/) nào sẽ được giải quyết dựa trên những nguồn này trước, giúp đạt được độ bao phủ đáng tin cậy hơn trên máy chủ và trong container.

**Phông chữ mặc định có ảnh hưởng đến các chỉ số văn bản (kerning, advance) và do đó đến ngắt dòng và wrap không?**

Có. Thay đổi phông chữ làm thay đổi các chỉ số glyph và có thể gây thay đổi ngắt dòng, wrap và phân trang trong quá trình render. Để duy trì tính ổn định của bố cục, hãy [embed the original fonts](/slides/vi/python-net/embedded-font/) hoặc chọn các họ phông chữ mặc định và fallback có độ tương thích về mặt metric.

**Có ý nghĩa gì khi đặt phông chữ mặc định nếu tất cả phông chữ trong trình chiếu đã được nhúng không?**

Thường thì không cần thiết, bởi vì [embedded fonts](/slides/vi/python-net/embedded-font/) đã đảm bảo giao diện nhất quán. Phông chữ mặc định vẫn hữu ích như một biện pháp an toàn cho các ký tự không được bao phủ bởi tập hợp phông đã nhúng hoặc khi tệp kết hợp cả văn bản nhúng và không nhúng.