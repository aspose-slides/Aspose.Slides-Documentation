---
title: Chuyển đổi bản trình chiếu PowerPoint sang XML trong JavaScript
linktitle: PowerPoint sang XML
type: docs
weight: 145
url: /vi/nodejs-java/convert-powerpoint-to-xml/
keywords:
- chuyển đổi PowerPoint sang XML
- chuyển đổi bản trình chiếu sang XML
- PPT sang XML
- PPTX sang XML
- ODP sang XML
- Bản trình chiếu XML PowerPoint
- SaveFormat.Xml
- lưu bản trình chiếu dưới dạng XML
- xuất bản trình chiếu sang XML
- luồng XML
- Node.js
- JavaScript
- Aspose.Slides
description: Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument thành các tệp hoặc luồng XML PowerPoint trong JavaScript với Aspose.Slides cho Node.js thông qua Java.
---
## **Tổng quan**

Aspose.Slides for Node.js via Java có thể chuyển đổi các bản trình chiếu PowerPoint sang định dạng PowerPoint XML Presentation. Đầu ra XML hữu ích khi bạn cần biểu diễn dạng văn bản để kiểm tra cấu trúc bản trình chiếu, khắc phục sự cố tài liệu tạo ra, so sánh đầu ra trong các bài kiểm tra tự động, hoặc tích hợp với quy trình làm việc tiêu thụ XML thay vì một gói bản trình chiếu.

Sử dụng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save) với giá trị `Xml` từ liệt kê [SaveFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveformat/). Bạn có thể ghi kết quả trực tiếp vào tệp hoặc vào luồng.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` tạo một PowerPoint XML Presentation. Nó không trích xuất các phần Office Open XML riêng lẻ được lưu trong gói PPTX. Nếu bạn cần các phần gói PPTX chính xác, chẳng hạn như `ppt/presentation.xml` hoặc các tệp XML slide riêng lẻ, hãy kiểm tra trực tiếp gói PPTX.
{{% /alert %}}

## **Chuyển đổi bản trình chiếu sang tệp XML**

Tải một bản trình chiếu nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/), rồi truyền đường dẫn đầu ra và `SaveFormat.Xml` vào [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save). Nguồn có thể là bất kỳ định dạng bản trình chiếu nào được hỗ trợ để tải, chẳng hạn như PPT, PPTX hoặc ODP.

Ví dụ dưới đây chuyển đổi một bản trình chiếu PPTX thành tệp XML:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Ghi đầu ra XML vào luồng**

Sử dụng phiên bản overload của luồng cho [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save) khi XML phải ở trong bộ nhớ hoặc được truyền cho thành phần khác, chẳng hạn như dịch vụ web, nhà cung cấp lưu trữ hoặc pipeline xử lý XML. Ví dụ dưới đây ghi kết quả vào một Java `ByteArrayOutputStream` và sao chép dữ liệu đã tạo vào một Node.js `Buffer`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // Chuyển xmlBuffer đến thành phần tiếp theo trong quy trình làm việc.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **So sánh XML với các định dạng bản trình chiếu và xuất**

Chọn định dạng đầu ra dựa trên cách mà kết quả sẽ được sử dụng:

| Định dạng | Đầu ra | Ứng dụng điển hình |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Một bản trình chiếu PowerPoint XML | Kiểm tra cấu trúc, khắc phục sự cố, so sánh đầu ra được tạo và tích hợp dựa trên XML |
| PPT (`.ppt`) | Tệp trình chiếu nhị phân kế thừa | Tương thích với các quy trình làm việc PowerPoint cũ |
| PPTX (`.pptx`) | Một gói Office Open XML chứa nhiều phần | Chỉnh sửa PowerPoint thông thường và trao đổi bản trình chiếu |
| PDF hoặc TIFF | Các trang bố cục cố định hoặc hình ảnh đa trang | Xem, in và lưu trữ |
| PNG, JPEG hoặc SVG | Đại diện đã render của một slide riêng lẻ | Hình thu nhỏ, bản xem trước và tài nguyên hình ảnh |
| HTML hoặc HTML5 | Đầu ra bản trình chiếu hướng web | Xem trên trình duyệt và xuất bản web |

Khác với PPT và PPTX, đầu ra XML chủ yếu dành cho việc kiểm tra và các quy trình làm việc dựa trên dữ liệu. Khác với PDF, TIFF, HTML và các định dạng hình ảnh slide, nó biểu diễn dữ liệu bản trình chiếu thay vì render các slide thành trang hoặc tài sản hình ảnh. Bảng [supported file formats](/slides/vi/nodejs-java/supported-file-formats/) liệt kê PowerPoint XML Presentation là định dạng chỉ lưu, vì vậy đừng sử dụng nó khi một quy trình phải tải lại tệp đã xuất vào Aspose.Slides để tiếp tục chỉnh sửa.

## **Câu hỏi thường gặp**

**`SaveFormat.Xml` có giống như lưu tệp PPTX không?**

Không. PPTX là một gói chứa nhiều phần Office Open XML, trong khi `SaveFormat.Xml` tạo một tệp PowerPoint XML Presentation.

**Tôi có thể lưu đầu ra XML mà không tạo tệp trên đĩa không?**

Có. Truyền một luồng có thể ghi vào [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save). Ví dụ, sử dụng một Java `ByteArrayOutputStream` và sao chép dữ liệu của nó vào một Node.js `Buffer` để xử lý trong bộ nhớ.

**Aspose.Slides có thể tải lại tệp XML đã xuất không?**

Không. PowerPoint XML Presentation hiện chỉ được hỗ trợ để lưu, không hỗ trợ tải. Hãy dùng PPTX hoặc định dạng bản trình chiếu được hỗ trợ khác khi cần chỉnh sửa vòng tròn.

**Quá trình chuyển đổi XML có render mỗi slide thành trang hoặc hình ảnh không?**

Không. Chuyển đổi XML ghi dữ liệu cấu trúc của bản trình chiếu. Sử dụng PDF hoặc TIFF cho đầu ra dạng trang, hoặc PNG, JPEG và SVG cho hình ảnh slide riêng lẻ.