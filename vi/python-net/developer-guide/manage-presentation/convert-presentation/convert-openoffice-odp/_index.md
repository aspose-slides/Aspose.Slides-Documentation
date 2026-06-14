---
title: Chuyển đổi Bài thuyết trình OpenDocument bằng Python
linktitle: Chuyển đổi OpenDocument
type: docs
weight: 10
url: /vi/python-net/convert-openoffice-odp/
keywords:
- chuyển đổi OpenDocument
- chuyển đổi ODP
- ODP sang PDF
- ODP sang PPT
- ODP sang PPTX
- ODP sang XPS
- ODP sang HTML
- ODP sang TIFF
- ODP sang SWF
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Chuyển đổi ODP OpenDocument sang PDF, PPT, PPTX, XPS, HTML, TIFF hoặc SWF trong Python với Aspose.Slides: ví dụ mã, độ trung thực cao, chuyển đổi hàng loạt và tùy chỉnh."
---
## **Giới thiệu**

[**Aspose.Slides API**](https://products.aspose.com/slides/vi/python-net/) cho phép bạn chuyển đổi các bài thuyết trình OpenDocument (ODP) sang nhiều định dạng (HTML, PDF, TIFF, SWF, XPS, v.v.). API được sử dụng để chuyển đổi các tệp ODP sang các định dạng tài liệu khác giống như API được sử dụng cho các thao tác chuyển đổi PowerPoint (PPT và PPTX).

Ví dụ, nếu bạn cần chuyển đổi một bài thuyết trình ODP sang PDF, bạn có thể thực hiện như sau:

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi ODP sang PPTX mà không cần cài đặt LibreOffice hoặc OpenOffice không?**

Có. Aspose.Slides là một thư viện hoàn toàn độc lập, xử lý cả định dạng PowerPoint và OpenOffice mà không cần bất kỳ ứng dụng bên ngoài nào.

**Aspose.Slides có mở và lưu các tệp ODP/OTP được bảo vệ bằng mật khẩu không?**

Có. Nó có thể [tải các bài thuyết trình đã mã hóa](/slides/vi/python-net/password-protected-presentation/) khi bạn cung cấp mật khẩu và cũng có thể lưu các bài thuyết trình với các cài đặt mã hóa và bảo vệ.

**Tôi có thể trích xuất các tệp phương tiện nhúng (audio/video) từ ODP trước khi chuyển đổi không?**

Có. Aspose.Slides cho phép bạn truy cập và trích xuất [audio](/slides/vi/python-net/audio-frame/) và [video](/slides/vi/python-net/video-frame/) nhúng từ các bài thuyết trình, điều này hữu ích cho việc xử lý trước khi chuyển đổi hoặc tái sử dụng riêng.

**Tôi có thể lưu ODP đã chuyển đổi dưới dạng Strict Office Open XML không?**

Có. Khi lưu dưới dạng PPTX, bạn có thể bật Strict OOXML thông qua [các tùy chọn lưu](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pptxoptions/) để đáp ứng các yêu cầu tuân thủ nghiêm ngặt hơn.