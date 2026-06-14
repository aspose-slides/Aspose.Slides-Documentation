---
title: Chuyển đổi Bản trình bày OpenDocument trong .NET
linktitle: Chuyển đổi OpenDocument
type: docs
weight: 10
url: /vi/net/convert-openoffice-odp/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides cho .NET cho phép bạn chuyển đổi ODP sang PDF, HTML và các định dạng hình ảnh một cách dễ dàng. Tăng tốc ứng dụng .NET của bạn với việc chuyển đổi bản trình bày nhanh chóng và chính xác."
---
## **Giới thiệu**

[**Aspose.Slides API**](https://products.aspose.com/slides/vi/net/) cho phép bạn chuyển đổi các bản trình bày OpenDocument (ODP) sang nhiều định dạng (HTML, PDF, TIFF, SWF, XPS, v.v.). API được sử dụng để chuyển đổi tệp ODP sang các định dạng tài liệu khác giống như API được sử dụng cho các thao tác chuyển đổi PowerPoint (PPT và PPTX).

Ví dụ, nếu bạn cần chuyển đổi một bản trình bày ODP sang PDF, bạn có thể thực hiện như sau:

```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```

## **Bản trình bày OpenDocument trong các ứng dụng khác nhau**

Khi một tệp bản trình bày OpenDocument (ODP) được mở trong PowerPoint, nó có thể không giữ nguyên định dạng gốc từ ứng dụng mà nó được tạo ra. Điều này xảy ra vì ứng dụng trình bày OpenDocument và PowerPoint cung cấp các tính năng và cách hiển thị khác nhau.

Dưới đây là một số khác biệt:

- Trong PowerPoint, các bảng thường được vẽ cuối cùng và có thể chồng lên các hình dạng khác, bất kể thứ tự của chúng trên slide ODP.
- Việc điền hình ảnh cho các bảng ODP không được hỗ trợ trong PowerPoint.
- Việc xoay dọc văn bản (270°, xếp chồng) và căn chỉnh phân phối không được hỗ trợ trong LibreOffice/OpenOffice Impress.
- Việc điền hình ảnh, độ chuyển màu gradient và kiểu mẫu cho văn bản không được hỗ trợ trong LibreOffice/OpenOffice Impress.

MS PowerPoint và LibreOffice/OpenOffice Impress cũng xử lý danh sách khác nhau. Một tệp ODP được tạo trong PowerPoint có thể không hiển thị đúng trong LibreOffice/OpenOffice Impress, và ngược lại.

Hình ảnh dưới đây cho thấy cách danh sách xuất hiện khi được tạo trong LibreOffice Impress:

![Ví dụ danh sách ODP](odp-list-example.png)

Aspose.Slides lưu danh sách ODP sao cho chúng được hiển thị đúng trong LibreOffice/OpenOffice Impress.

[Tìm hiểu thêm về định dạng OpenDocument và PowerPoint](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **Câu hỏi thường gặp**

**Nếu định dạng của tệp ODP của tôi thay đổi sau khi chuyển đổi thì sao?**

ODP và PowerPoint sử dụng các mô hình trình bày khác nhau, và một số yếu tố—như bảng, phông chữ tùy chỉnh hoặc kiểu nền—có thể không hiển thị hoàn toàn giống nhau. Bạn nên xem lại đầu ra và điều chỉnh bố cục hoặc định dạng trong mã nếu cần.

**Tôi có cần cài đặt OpenOffice hoặc LibreOffice để sử dụng chuyển đổi ODP không?**

Không, Aspose.Slides for .NET là thư viện độc lập và không yêu cầu OpenOffice hoặc LibreOffice được cài đặt trên hệ thống của bạn.

**Tôi có thể tùy chỉnh định dạng đầu ra trong quá trình chuyển đổi ODP (ví dụ: thiết lập tùy chọn PDF) không?**

Có, Aspose.Slides cung cấp các tùy chọn phong phú để tùy chỉnh đầu ra. Ví dụ, khi lưu thành PDF, bạn có thể kiểm soát nén, chất lượng hình ảnh, cách hiển thị văn bản và nhiều hơn nữa thông qua lớp [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/).

**Aspose.Slides có phù hợp cho xử lý ODP phía máy chủ hoặc dựa trên đám mây không?**

Hoàn toàn. Aspose.Slides for .NET được thiết kế để hoạt động cả trong môi trường desktop và máy chủ, bao gồm các nền tảng dựa trên đám mây như Azure, AWS và các container Docker, mà không cần bất kỳ phụ thuộc giao diện người dùng nào.