---
title: Chuyển đổi Bài thuyết trình OpenDocument trong JavaScript
linktitle: Chuyển đổi OpenDocument
type: docs
weight: 10
url: /vi/nodejs-java/convert-openoffice-odp/
keywords:
- chuyển đổi ODP
- ODP sang hình ảnh
- ODP sang GIF
- ODP sang HTML
- ODP sang JPG
- ODP sang MD
- ODP sang PDF
- ODP sang PNG
- ODP sang PPT
- ODP sang PPTX
- ODP sang TIFF
- ODP sang video
- ODP sang Word
- ODP sang XPS
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides cho Node.js cho phép bạn chuyển đổi ODP sang PDF, HTML và các định dạng hình ảnh một cách dễ dàng. Tăng cường ứng dụng của bạn với việc chuyển đổi bài thuyết trình nhanh chóng và chính xác."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/vi/nodejs-java/) cho phép bạn chuyển đổi các bản trình chiếu OpenDocument (ODP) sang nhiều định dạng (HTML, PDF, TIFF, SWF, XPS, v.v.). API dùng để chuyển đổi tệp ODP sang các định dạng tài liệu khác giống với API dùng cho các thao tác chuyển đổi PowerPoint (PPT và PPTX).

Ví dụ, nếu bạn cần chuyển đổi một bản trình chiếu ODP sang PDF, bạn có thể thực hiện như sau:

```js
let presentation = null;
try {
  presentation = new aspose.slides.Presentation("presentation.odp");
  presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Nếu định dạng của tệp ODP của tôi bị thay đổi sau khi chuyển đổi thì sao?**

ODP và PowerPoint sử dụng các mô hình trình chiếu khác nhau, và một số yếu tố—như bảng, phông chữ tùy chỉnh hoặc kiểu tô màu—có thể không hiển thị hoàn toàn giống nhau. Bạn nên xem lại kết quả và điều chỉnh bố cục hoặc định dạng trong mã nếu cần.

**Tôi có cần cài đặt OpenOffice hoặc LibreOffice để sử dụng chuyển đổi ODP không?**

Không, Aspose.Slides là một thư viện độc lập và không yêu cầu cài đặt OpenOffice hoặc LibreOffice trên hệ thống của bạn.

**Tôi có thể tùy chỉnh định dạng đầu ra trong quá trình chuyển đổi ODP (ví dụ, đặt các tùy chọn PDF) không?**

Có, Aspose.Slides cung cấp nhiều tùy chọn phong phú để tùy chỉnh đầu ra. Ví dụ, khi lưu dưới dạng PDF, bạn có thể kiểm soát nén, chất lượng hình ảnh, cách render văn bản và nhiều hơn nữa thông qua lớp [PdfOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pdfoptions/).

**Aspose.Slides có phù hợp cho việc xử lý ODP phía máy chủ hoặc dựa trên đám mây không?**

Chắc chắn rồi. Aspose.Slides được thiết kế để hoạt động cả trong môi trường máy tính để bàn và máy chủ, bao gồm các nền tảng đám mây như Azure, AWS và các container Docker, mà không phụ thuộc vào giao diện người dùng nào.