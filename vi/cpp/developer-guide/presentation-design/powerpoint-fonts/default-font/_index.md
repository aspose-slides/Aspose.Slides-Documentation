---
title: Xác định phông chữ mặc định cho bản trình chiếu trong C++
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
description: "Đặt phông chữ mặc định trong Aspose.Slides cho C++ để đảm bảo việc chuyển đổi PowerPoint (PPT, PPTX) và OpenDocument (ODP) sang PDF, XPS và hình ảnh một cách chính xác."
---
## **Tổng quan**

Aspose.Slides cho phép bạn chỉ định các phông chữ mặc định được sử dụng khi một bản trình bày được hiển thị. Điều này hữu ích khi tạo ảnh thu nhỏ của slide hoặc xuất bản trình bày sang các định dạng như PDF và XPS. Các phông chữ mặc định được cấu hình thông qua `LoadOptions` trước khi tải bản trình bày.

Phương thức `set_DefaultRegularFont` xác định phông chữ mặc định cho văn bản thường, trong khi `set_DefaultAsianFont` xác định phông chữ mặc định cho văn bản châu Á. Sau khi các tùy chọn này được thiết lập, bản trình bày có thể được tải và hiển thị bằng các phông chữ đã chỉ định.

## **Sử dụng phông chữ mặc định để hiển thị bản trình bày**
Aspose.Slides cho phép bạn đặt phông chữ mặc định để hiển thị bản trình bày thành PDF, XPS hoặc ảnh thu nhỏ. Bài viết này chỉ ra cách định nghĩa DefaultRegularFont và DefaultAsianFont để sử dụng làm phông chữ mặc định. Vui lòng thực hiện các bước sau để tải phông chữ từ các thư mục bên ngoài bằng API Aspose.Slides cho C++:

1. Tạo một thể hiện của LoadOptions.
1. Đặt DefaultRegularFont thành phông chữ mong muốn. Trong ví dụ sau, tôi đã sử dụng Wingdings.
1. Đặt DefaultAsianFont thành phông chữ mong muốn. Tôi đã sử dụng Wingdings trong mẫu dưới đây.
1. Tải bản trình bày bằng Presentation và thiết lập các tùy chọn tải.
1. Bây giờ, tạo ảnh thu nhỏ của slide, PDF và XPS để kiểm chứng kết quả.

Cài đặt cho các bước trên được đưa ra dưới đây.

```cpp
// Sử dụng tùy chọn tải để chỉ định phông chữ thường và phông chữ châu Á mặc định
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

**Thực sự các thuộc tính DefaultRegularFont và DefaultAsianFont ảnh hưởng tới gì — chỉ xuất khẩu, hay còn ảnh hưởng tới ảnh thu nhỏ, PDF, XPS, HTML và SVG?**

Chúng tham gia vào quy trình hiển thị cho mọi đầu ra được hỗ trợ. Điều này bao gồm ảnh thu nhỏ của slide, [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/vi/cpp/convert-powerpoint-to-xps/), [hình raster](/slides/vi/cpp/convert-powerpoint-to-png/), [HTML](/slides/vi/cpp/convert-powerpoint-to-html/), và [SVG](/slides/vi/cpp/render-a-slide-as-an-svg-image/), vì Aspose.Slides sử dụng cùng một logic bố cục và giải quyết glyph cho các mục tiêu này.

**Phông chữ mặc định có được áp dụng khi chỉ đọc và lưu một tệp PPTX mà không thực hiện bất kỳ quá trình hiển thị nào không?**

Không. Phông chữ mặc định chỉ có vai trò khi văn bản cần được đo và vẽ. Một thao tác mở‑lưu đơn giản của bản trình bày không thay đổi các run phông chữ được lưu hoặc cấu trúc tệp. Phông chữ mặc định sẽ xuất hiện trong các thao tác render hoặc reflow văn bản.

**Nếu tôi thêm các thư mục phông chữ của riêng mình hoặc cung cấp phông chữ từ bộ nhớ, chúng có được cân nhắc khi chọn phông chữ mặc định không?**

Có. [Custom font sources](/slides/vi/cpp/custom-font/) mở rộng danh mục các họ và glyph có sẵn mà engine có thể sử dụng. Phông chữ mặc định và bất kỳ [fallback rules](/slides/vi/cpp/fallback-font/) nào sẽ được giải quyết dựa trên các nguồn này trước, giúp đạt độ phủ rộng hơn trên máy chủ và trong container.

**Phông chữ mặc định có ảnh hưởng đến các chỉ số văn bản (kerning, advances) và do đó làm thay đổi việc ngắt dòng và gói chữ không?**

Có. Thay đổi phông chữ sẽ thay đổi các chỉ số glyph và có thể làm thay đổi cách ngắt dòng, gói chữ và phân trang trong quá trình render. Để duy trì tính ổn định bố cục, hãy [embed the original fonts](/slides/vi/cpp/embedded-font/) hoặc chọn các họ phông chữ mặc định và fallback có tính tương thích về mặt metric.

**Có cần thiết phải đặt phông chữ mặc định nếu tất cả các phông chữ được dùng trong bản trình bày đã được nhúng không?**

Thường thì không cần, vì [embedded fonts](/slides/vi/cpp/embedded-font/) đã đảm bảo hiển thị nhất quán. Tuy nhiên, phông chữ mặc định vẫn hữu ích như một lớp bảo vệ cho các ký tự không được bao phủ bởi tập con nhúng hoặc khi tệp có sự pha trộn giữa văn bản nhúng và không nhúng.