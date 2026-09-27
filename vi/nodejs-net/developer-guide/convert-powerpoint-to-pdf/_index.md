---
title: Chuyển đổi PowerPoint sang PDF trong Node.js qua .NET
linktitle: PowerPoint sang PDF
type: docs
weight: 30
url: /vi/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint sang PDF
- chuyển đổi PowerPoint sang PDF
- PPTX sang PDF
- PPT sang PDF
- ODP sang PDF
- lưu bản trình chiếu dưới dạng PDF
- PDF/A
- PdfOptions
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PPTX, PPT và ODP sang PDF trong JavaScript bằng Aspose.Slides cho Node.js qua .NET, và tạo các tệp PDF/A lưu trữ với PdfOptions."
---
## **Tổng quan**

Aspose.Slides cho Node.js thông qua .NET chuyển đổi các bản trình chiếu PowerPoint và OpenDocument sang PDF mà không cần Microsoft PowerPoint. Mỗi slide hiển thị trở thành một trang PDF có cùng kích thước với slide, và văn bản vẫn có thể chọn và tìm kiếm được. Bài viết này trình bày chuyển đổi mặc định và chuyển đổi sang PDF/A bằng [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/).

Các ví dụ yêu cầu một bản trình chiếu có tên `sample.pptx` trong thư mục dự án mà bạn thiết lập trong [Installation](/slides/vi/nodejs-net/installation/). Bất kỳ bản trình chiếu PowerPoint nào đều được. Lưu mỗi ví dụ dưới dạng tệp `.js` trong thư mục dự án và chạy nó từ thư mục đó bằng `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides cho Node.js thông qua .NET không có tài liệu tham chiếu API riêng. Nó sao chép API của Aspose.Slides cho .NET với các tên camelCase, vì vậy các liên kết API trong bài này dẫn tới các lớp và thành viên tương ứng trong [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/vi/net/).
{{% /alert %}}

## **Chuyển đổi bản trình chiếu sang PDF**

Để chuyển đổi bản trình chiếu sang PDF, thực hiện các bước sau:

1. Mở bản trình chiếu bằng cách truyền đường dẫn của nó vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/presentation/). Cùng một đoạn mã hoạt động cho các tệp PPTX, PPT và ODP.
2. Gọi phương thức [save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) với đường dẫn đầu ra và `SaveFormat.Pdf`.
3. Gọi `dispose` trong một khối `finally` để giải phóng các tài nguyên .NET hỗ trợ bản trình chiếu.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

Script ghi `sample.pdf` vào thư mục dự án. Quá trình chuyển đổi sử dụng các thiết lập mặc định: mỗi slide không ẩn sẽ trở thành một trang, theo thứ tự slide. Nếu không có giấy phép, mỗi trang cũng sẽ hiển thị watermark đánh giá; xem [Licensing](/slides/vi/nodejs-net/licensing/).

## **Chuyển đổi bản trình chiếu sang PDF/A**

Để kiểm soát đầu ra, truyền một đối tượng [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/) làm đối số thứ ba của `save`. Ví dụ dưới đây đặt thuộc tính [compliance](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/compliance/) thành `PdfCompliance.PdfA2b`, tạo ra một tệp PDF/A-2b. PDF/A là tiêu chuẩn ISO cho lưu trữ lâu dài: trong số các quy tắc khác, nó yêu cầu mọi phông chữ mà tài liệu sử dụng phải được nhúng trong tệp.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

Script ghi `sample-pdfa.pdf` với các trang giống như chuyển đổi mặc định. Để xác nhận một tệp đáp ứng tiêu chuẩn, kiểm tra nó bằng một trình kiểm tra PDF/A như [veraPDF](https://verapdf.org/). Các giá trị [PdfCompliance](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfcompliance/) khác chọn các tiêu chuẩn khác, chẳng hạn `PdfA1b`, `PdfA2a`, hoặc `PdfUa` cho khả năng truy cập.

## **Câu hỏi thường gặp**

**Làm sao để bao gồm các slide ẩn trong PDF?**

Các slide ẩn bị bỏ qua theo mặc định. Đặt thuộc tính [showHiddenSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/showhiddenslides/) của `PdfOptions` thành `true` và truyền các tùy chọn này vào `save`.

**Tôi có thể bảo vệ PDF bằng mật khẩu không?**

Có. Đặt thuộc tính [password](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/password/) của `PdfOptions` trước khi gọi `save`. Các trình đọc PDF sau đó sẽ yêu cầu mật khẩu đó trước khi mở tệp.

**Tôi có thể chuyển đổi chỉ một số slide không?**

Có. Truyền một mảng các vị trí slide làm đối số thứ tư của `save`. Các vị trí bắt đầu từ 1, và đối số thứ ba có thể là `null` nếu bạn không cần tùy chọn: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` sẽ tạo ra một PDF chứa slide thứ nhất và thứ ba.

**Tại sao văn bản lại trông khác khi tôi chuyển đổi trên Linux?**

Aspose.Slides chỉ có thể sử dụng các phông chữ đã được cài đặt trên máy đang thực hiện chuyển đổi. Khi một bản trình chiếu sử dụng một phông chữ chưa có, chẳng hạn Calibri trên một máy chủ Linux thường gặp, Aspose.Slides sẽ dùng một phông chữ đã cài đặt thay thế, điều này có thể làm thay đổi giao diện của văn bản và vị trí ngắt dòng. Hãy cài đặt các phông chữ mà bản trình chiếu của bạn sử dụng để có kết quả giống như trên Windows.

**Tôi có thể nhận PDF dưới dạng Buffer thay vì tệp không?**

Có. `presentation.saveToBuffer(SaveFormat.Pdf)` trả về PDF dưới dạng `Buffer` của Node.js, tiện lợi khi bạn gửi kết quả trong phản hồi HTTP. Nó cũng chấp nhận `PdfOptions` làm đối số thứ hai.