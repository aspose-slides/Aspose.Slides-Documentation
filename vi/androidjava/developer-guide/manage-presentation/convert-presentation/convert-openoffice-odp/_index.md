---
title: Chuyển đổi Bài thuyết trình OpenDocument trên Android
linktitle: Chuyển đổi OpenDocument
type: docs
weight: 10
url: /vi/androidjava/convert-openoffice-odp/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides cho Android cho phép bạn chuyển đổi ODP sang PDF, HTML và các định dạng hình ảnh một cách dễ dàng. Tăng tốc ứng dụng Java của bạn với việc chuyển đổi bài thuyết trình nhanh chóng và chính xác."
---
## **Giới thiệu**

[**Aspose.Slides API**](https://products.aspose.com/slides/vi/androidjava/) cho phép bạn chuyển đổi các bài thuyết trình OpenDocument (ODP) sang nhiều định dạng (HTML, PDF, TIFF, SWF, XPS, vv). API được sử dụng để chuyển đổi tệp ODP sang các định dạng tài liệu khác tương tự như API dùng cho các thao tác chuyển đổi PowerPoint (PPT và PPTX).

Ví dụ, nếu bạn cần chuyển đổi một bài thuyết trình ODP sang PDF, bạn có thể thực hiện như sau:

```java
Presentation presentation = null;
try {
    presentation = new Presentation("pres.odp");
    presentation.save("pres.pdf", SaveFormat.Pdf);
    
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Nếu định dạng của tệp ODP của tôi thay đổi sau khi chuyển đổi thì sao?**

ODP và PowerPoint sử dụng các mô hình trình chiếu khác nhau, và một số yếu tố — như bảng, phông chữ tùy chỉnh, hoặc kiểu nền màu — có thể không hiển thị hoàn toàn giống nhau. Bạn nên kiểm tra kết quả và điều chỉnh bố cục hoặc định dạng trong mã nếu cần.

**Tôi có cần cài đặt OpenOffice hoặc LibreOffice để sử dụng chuyển đổi ODP không?**

Không, Aspose.Slides là một thư viện độc lập và không yêu cầu cài đặt OpenOffice hoặc LibreOffice trên hệ thống của bạn.

**Tôi có thể tùy chỉnh định dạng đầu ra trong quá trình chuyển đổi ODP (ví dụ, thiết lập tùy chọn PDF) không?**

Có, Aspose.Slides cung cấp nhiều tùy chọn phong phú để tùy chỉnh đầu ra. Ví dụ, khi lưu dưới dạng PDF, bạn có thể kiểm soát nén, chất lượng hình ảnh, cách hiển thị văn bản và nhiều hơn nữa thông qua lớp [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/).

**Aspose.Slides có thích hợp cho việc xử lý ODP phía máy chủ hoặc dựa trên đám mây không?**

Chắc chắn. Aspose.Slides được thiết kế để hoạt động trong cả môi trường máy tính để bàn và máy chủ, bao gồm các nền tảng dựa trên đám mây như Azure, AWS và các container Docker, mà không cần bất kỳ phụ thuộc giao diện người dùng nào.