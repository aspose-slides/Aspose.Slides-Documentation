---
title: Nhập các bài thuyết trình từ PDF hoặc HTML trong JavaScript
linktitle: Nhập Bài Thuyết Trình
type: docs
weight: 60
url: /vi/nodejs-java/import-presentation/
keywords:
- nhập bài thuyết trình
- nhập slide
- nhập PDF
- nhập HTML
- PDF sang bản thuyết trình
- PDF sang PPT
- PDF sang PPTX
- PDF sang ODP
- HTML sang bản thuyết trình
- HTML sang PPT
- HTML sang PPTX
- HTML sang ODP
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Nhập tài liệu PDF và HTML vào các bản thuyết trình PowerPoint và OpenDocument với Aspose.Slides cho Node.js để xử lý slide liền mạch, hiệu suất cao."
---
## **Giới thiệu**

Sử dụng [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/vi/nodejs-java/), bạn có thể nhập các bài thuyết trình từ các tệp ở định dạng khác. Aspose.Slides cung cấp lớp [SlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/) để cho phép bạn nhập các bài thuyết trình từ PDF, tài liệu HTML, v.v.

## **Nhập PowerPoint từ PDF**

Trong trường hợp này, bạn sẽ chuyển đổi PDF sang bản trình chiếu PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/).
2. Gọi phương thức [addFromPdf()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) và truyền tệp PDF.
3. Sử dụng phương thức [save()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) để lưu tệp dưới định dạng PowerPoint.

Đoạn mã JavaScript này minh họa quá trình chuyển đổi PDF sang PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert  title="Tip" color="primary" %}} 
Bạn có thể muốn khám phá ứng dụng web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/vi/import/pdf-to-powerpoint) vì đây là một triển khai thực tế của quy trình được mô tả ở đây. 
{{% /alert %}} 

## **Nhập PowerPoint từ HTML**

Trong trường hợp này, bạn sẽ chuyển đổi tài liệu HTML sang bản trình chiếu PowerPoint.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/).
2. Gọi phương thức [addFromHtml()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) và truyền tệp PDF.
3. Sử dụng phương thức [save()](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) để lưu tệp dưới định dạng PowerPoint.

Đoạn mã JavaScript này minh họa quá trình chuyển đổi HTML sang PowerPoint:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var htmlStream = java.newInstanceSync("java.io.FileInputStream", "page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) {
            htmlStream.close();
        }
    }
    presentation.save("MyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Các bảng có được giữ lại khi nhập PDF không, và việc phát hiện chúng có thể được cải thiện không?**

Các bảng có thể được phát hiện trong quá trình nhập; [PdfImportOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pdfimportoptions/) bao gồm phương thức [setDetectTables](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) cho phép nhận dạng bảng. Hiệu quả phụ thuộc vào cấu trúc của PDF.