---
title: Xác định phông chữ mặc định cho bản trình bày trong Python qua Java
linktitle: Phông chữ mặc định
type: docs
weight: 30
url: /vi/python-java/default-font/
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
- Python
- Java
- Aspose.Slides
description: "Đặt phông chữ mặc định trong Aspose.Slides cho Python qua Java để đảm bảo chuyển đổi đúng định dạng PowerPoint (PPT, PPTX) và OpenDocument (ODP) sang PDF, XPS và hình ảnh."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định các phông chữ mặc định được sử dụng khi một bản trình bày được hiển thị. Điều này hữu ích khi tạo ảnh thu nhỏ của các slide hoặc xuất bản trình bày sang các định dạng như PDF và XPS. Các phông chữ mặc định được cấu hình thông qua [LoadOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/) trước khi bản trình bày được tải.

Phương thức [setDefaultRegularFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) xác định phông chữ mặc định cho văn bản thường, trong khi [setDefaultAsianFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) xác định phông chữ mặc định cho văn bản châu Á. Sau khi thiết lập các tùy chọn này, bản trình bày có thể được tải và hiển thị bằng các phông chữ đã chỉ định.

## **Sử dụng phông chữ mặc định cho việc hiển thị một bản trình bày**

Aspose.Slides cho phép bạn đặt phông chữ mặc định cho việc hiển thị một bản trình bày dưới dạng PDF, XPS hoặc ảnh thu nhỏ. Phần này mô tả cách định nghĩa phông chữ mặc định cho văn bản thường và văn bản châu Á bằng Aspose.Slides cho Python qua Java:

1. Tạo một thể hiện của [LoadOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/).
1. Sử dụng [setDefaultRegularFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) để chỉ định phông chữ mong muốn. Ví dụ dưới đây sử dụng Wingdings.
1. Sử dụng [setDefaultAsianFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) để chỉ định phông chữ mong muốn. Ví dụ này cũng sử dụng Wingdings.
1. Tải bản trình bày bằng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) kèm theo các tùy chọn tải.
1. Tạo ảnh thu nhỏ của slide, PDF và XPS để kiểm tra kết quả.

Ví dụ sau thực hiện các bước trên:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Sử dụng tùy chọn tải để xác định phông chữ mặc định cho văn bản thường và văn bản châu Á.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Tải bản trình bày.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Tạo ảnh thu nhỏ của slide.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Lưu hình ảnh vào đĩa.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # Tạo PDF.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # Tạo tài liệu XPS.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Thực chất các phông chữ mặc định cho văn bản thường và châu Á ảnh hưởng đến gì — chỉ xuất file hay cả ảnh thu nhỏ, PDF, XPS, HTML và SVG?**

Chúng tham gia vào quy trình hiển thị cho mọi đầu ra được hỗ trợ. Điều này bao gồm ảnh thu nhỏ của slide, [PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/vi/python-java/convert-powerpoint-to-xps/), [hình ảnh raster](/slides/vi/python-java/convert-powerpoint-to-png/), [HTML](/slides/vi/python-java/convert-powerpoint-to-html/), và [SVG](/slides/vi/python-java/render-a-slide-as-an-svg-image/), vì Aspose.Slides sử dụng cùng một logic bố cục và giải quyết glyph cho tất cả các mục tiêu này.

**Phông chữ mặc định có được áp dụng khi chỉ đọc và lưu một tệp PPTX mà không thực hiện việc hiển thị nào không?**

Không. Phông chữ mặc định chỉ quan trọng khi văn bản phải được đo và vẽ. Một thao tác mở‑lưu đơn giản của bản trình bày không thay đổi các chuỗi phông chữ đã lưu hoặc cấu trúc tệp. Phông chữ mặc định sẽ được sử dụng trong các thao tác cần hiển thị hoặc điều chỉnh lại bố cục văn bản.

**Nếu tôi thêm các thư mục phông chữ của riêng mình hoặc cung cấp phông chữ từ bộ nhớ, chúng có được xem xét khi lựa chọn phông chữ mặc định không?**

Có. [Custom font sources](/slides/vi/python-java/custom-font/) mở rộng danh mục các họ phông chữ và glyph mà engine có thể sử dụng. Phông chữ mặc định và bất kỳ [fallback rules](/slides/vi/python-java/fallback-font/) nào sẽ được giải quyết dựa trên các nguồn này trước, giúp tăng độ phủ sóng trên máy chủ và trong container.

**Phông chữ mặc định có ảnh hưởng đến các chỉ số văn bản (kerning, advances) và do đó tới việc ngắt dòng và gói văn bản không?**

Có. Thay đổi phông chữ làm thay đổi các chỉ số glyph và có thể thay đổi vị trí ngắt dòng, gói văn bản và cách phân trang khi hiển thị. Để duy trì tính ổn định của bố cục, nên [embed the original fonts](/slides/vi/python-java/embedded-font/) hoặc chọn các họ phông chữ mặc định và dự phòng có metrik tương thích.

**Có cần đặt phông chữ mặc định nếu tất cả các phông chữ trong bản trình bày đã được nhúng không?**

Thường thì không cần, vì [embedded fonts](/slides/vi/python-java/embedded-font/) đã đảm bảo sự nhất quán về hiển thị. Phông chữ mặc định vẫn hữu ích như một lớp bảo vệ cho những ký tự không được bao phủ bởi tập hợp phông chữ đã nhúng hoặc khi tệp có sự pha trộn giữa văn bản nhúng và không nhúng.