---
title: Chuyển đổi Bản trình bày OpenDocument trong Java
linktitle: Chuyển đổi OpenDocument
type: docs
weight: 10
url: /vi/java/convert-openoffice-odp/
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
- bản trình bày
- Java
- Aspose.Slides
description: "Aspose.Slides cho Java cho phép bạn chuyển đổi ODP sang PDF, HTML và các định dạng hình ảnh một cách dễ dàng. Tăng tốc ứng dụng Java của bạn với việc chuyển đổi bản trình bày nhanh chóng và chính xác."
---
## **Giới thiệu**

[**Aspose.Slides API**](https://products.aspose.com/slides/vi/java/) cho phép bạn chuyển đổi các bản trình bày OpenDocument (ODP) sang nhiều định dạng (HTML, PDF, TIFF, SWF, XPS, v.v.). API được sử dụng để chuyển đổi các tệp ODP sang các định dạng tài liệu khác giống như API được sử dụng cho các thao tác chuyển đổi PowerPoint (PPT và PPTX).

Ví dụ, nếu bạn cần chuyển đổi một bản trình bày ODP sang PDF, bạn có thể thực hiện như sau:

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

## **Bản trình bày OpenDocument trong các ứng dụng khác nhau**

Khi một tệp bản trình bày OpenDocument (ODP) được mở trong PowerPoint, nó có thể không giữ nguyên định dạng gốc từ ứng dụng mà nó được tạo ra. Điều này xảy ra vì ứng dụng trình bày OpenDocument và ứng dụng PowerPoint cung cấp các tính năng và hành vi hiển thị khác nhau.

Dưới đây là một số khác biệt:

- Trong PowerPoint, các bảng thường được render cuối cùng và có thể che phủ các hình dạng khác, bất kể thứ tự của chúng trên slide ODP.
- Không hỗ trợ ảnh nền cho các bảng ODP trong PowerPoint.
- Việc quay dọc văn bản (270°, xếp chồng) và căn chỉnh phân tán không được hỗ trợ trong LibreOffice/OpenOffice Impress.
- Không hỗ trợ ảnh nền, nền gradient và nền mẫu cho văn bản trong LibreOffice/OpenOffice Impress.

MS PowerPoint và LibreOffice/OpenOffice Impress cũng xử lý danh sách khác nhau. Một tệp ODP được tạo trong PowerPoint có thể không hiển thị đúng trong LibreOffice/OpenOffice Impress, và ngược lại.

Hình ảnh dưới đây cho thấy cách một danh sách xuất hiện khi được tạo trong LibreOffice Impress:

![ví dụ danh sách ODP](odp-list-example.png)

Aspose.Slides lưu các danh sách ODP theo cách đảm bảo chúng được hiển thị đúng trong LibreOffice/OpenOffice Impress.

[Tìm hiểu thêm về định dạng OpenDocument và PowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **Câu hỏi thường gặp**

**Nếu định dạng của tệp ODP của tôi thay đổi sau khi chuyển đổi thì sao?**

ODP và PowerPoint sử dụng các mô hình trình bày khác nhau, và một số yếu tố — chẳng hạn như bảng, phông chữ tùy chỉnh hoặc kiểu nền — có thể không được render chính xác giống nhau. Bạn nên xem lại kết quả và điều chỉnh bố cục hoặc định dạng trong mã nếu cần.

**Bạn có cần cài đặt OpenOffice hoặc LibreOffice để sử dụng chuyển đổi ODP không?**

Không, Aspose.Slides là một thư viện độc lập và không yêu cầu cài đặt OpenOffice hoặc LibreOffice trên hệ thống của bạn.

**Tôi có thể tùy chỉnh định dạng đầu ra trong quá trình chuyển đổi ODP (ví dụ, thiết lập các tùy chọn PDF) không?**

Có, Aspose.Slides cung cấp nhiều tùy chọn phong phú để tùy chỉnh đầu ra. Ví dụ, khi lưu dưới dạng PDF, bạn có thể kiểm soát việc nén, chất lượng hình ảnh, render văn bản và hơn thế nữa thông qua lớp [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/).

**Aspose.Slides có phù hợp cho việc xử lý ODP phía máy chủ hoặc dựa trên đám mây không?**

Chắc chắn. Aspose.Slides được thiết kế để hoạt động cả trong môi trường desktop và máy chủ, bao gồm các nền tảng dựa trên đám mây như Azure, AWS và các container Docker, mà không phụ thuộc vào UI nào.