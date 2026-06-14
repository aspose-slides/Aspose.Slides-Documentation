---
title: Xác định phông chữ mặc định cho bài thuyết trình trong C++
linktitle: Phông chữ mặc định
type: docs
weight: 30
url: /vi/cpp/default-font/
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
- C++
- Aspose.Slides
description: "Đặt phông chữ mặc định trong Aspose.Slides cho C++ để đảm bảo chuyển đổi PowerPoint (PPT, PPTX) và OpenDocument (ODP) sang PDF, XPS và hình ảnh một cách chính xác."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định các phông chữ mặc định được sử dụng khi một bản trình chiếu được kết xuất. Điều này hữu ích khi tạo ảnh thu nhỏ của slide hoặc xuất bản trình chiếu sang các định dạng như PDF và XPS. Các phông chữ mặc định được cấu hình thông qua `LoadOptions` trước khi bản trình chiếu được tải.

Phương thức `set_DefaultRegularFont` định nghĩa phông chữ mặc định cho văn bản thường, trong khi `set_DefaultAsianFont` định nghĩa phông chữ mặc định cho văn bản châu Á. Sau khi các tùy chọn này được thiết lập, bản trình chiếu có thể được tải và kết xuất bằng các phông chữ đã chỉ định.

## **Sử dụng phông chữ mặc định để hiển thị bản trình chiếu**
Aspose.Slides cho phép bạn đặt phông chữ mặc định khi hiển thị bản trình chiếu thành PDF, XPS hoặc ảnh thu nhỏ. Bài viết này chỉ ra cách định nghĩa DefaultRegularFont và DefaultAsianFont để dùng làm phông chữ mặc định. Vui lòng làm theo các bước dưới đây để tải phông chữ từ các thư mục bên ngoài bằng API Aspose.Slides cho C++:

1. Tạo một thể hiện của LoadOptions.  
1. Đặt DefaultRegularFont thành phông chữ mong muốn. Trong ví dụ sau, tôi đã sử dụng Wingdings.  
1. Đặt DefaultAsianFont thành phông chữ mong muốn. Tôi đã sử dụng Wingdings trong mẫu dưới đây.  
1. Tải bản trình chiếu bằng cách sử dụng Presentation và thiết lập các tùy chọn tải.  
1. Bây giờ, tạo ảnh thu nhỏ của slide, PDF và XPS để xác minh kết quả.

Mã thực hiện của phần trên được đưa ra bên dưới.

```cpp
// Sử dụng các tùy chọn tải để chỉ định phông chữ mặc định cho văn bản thường và châu Á
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **Câu hỏi thường gặp**

**DefaultRegularFont và DefaultAsianFont ảnh hưởng chính xác như thế nào—chỉ xuất khẩu, hay còn ảnh thu nhỏ, PDF, XPS, HTML và SVG?**

Chúng tham gia vào quy trình kết xuất cho tất cả các đầu ra được hỗ trợ. Điều này bao gồm ảnh thu nhỏ của slide, [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/vi/cpp/convert-powerpoint-to-xps/), [raster images](/slides/vi/cpp/convert-powerpoint-to-png/), [HTML](/slides/vi/cpp/convert-powerpoint-to-html/), và [SVG](/slides/vi/cpp/render-a-slide-as-an-svg-image/), vì Aspose.Slides sử dụng cùng một logic bố cục và phân giải glyph cho các mục tiêu này.

**Phông chữ mặc định có được áp dụng khi chỉ đọc và lưu một tệp PPTX mà không thực hiện bất kỳ việc kết xuất nào không?**

Không. Phông chữ mặc định chỉ có vai trò khi văn bản phải được đo và vẽ. Một thao tác mở‑lưu đơn giản của bản trình chiếu không thay đổi các chuỗi phông chữ đã lưu hoặc cấu trúc tệp. Phông chữ mặc định sẽ được sử dụng trong các thao tác yêu cầu kết xuất hoặc tái bố trí văn bản.

**Nếu tôi thêm thư mục phông chữ riêng hoặc cung cấp phông chữ từ bộ nhớ, chúng có được xem xét khi chọn phông chữ mặc định không?**

Có. [Custom font sources](/slides/vi/cpp/custom-font/) mở rộng danh mục các họ phông chữ và glyph mà engine có thể sử dụng. Phông chữ mặc định và bất kỳ [fallback rules](/slides/vi/cpp/fallback-font/) nào sẽ được giải quyết dựa trên các nguồn này trước, giúp phủ sóng đáng tin cậy hơn trên máy chủ và trong container.

**Phông chữ mặc định có ảnh hưởng đến các chỉ số văn bản (kerning, advances) và do đó ảnh hưởng đến ngắt dòng và gói văn bản không?**

Có. Thay đổi phông chữ làm thay đổi các chỉ số glyph và có thể làm thay đổi vị trí ngắt dòng, gói văn bản và phân trang trong quá trình kết xuất. Để duy trì tính ổn định của bố cục, hãy [embed the original fonts](/slides/vi/cpp/embedded-font/) hoặc chọn các họ phông chữ mặc định và dự phòng tương thích về mặt metric.

**Có cần thiết đặt phông chữ mặc định nếu tất cả các phông chữ trong bản trình chiếu đã được nhúng không?**

Thường thì không cần, vì [embedded fonts](/slides/vi/cpp/embedded-font/) đã đảm bảo hiển thị nhất quán. Tuy nhiên, phông chữ mặc định vẫn hữu ích như một lớp bảo vệ cho các ký tự không có trong tập con đã nhúng hoặc khi tệp kết hợp văn bản nhúng và không nhúng.