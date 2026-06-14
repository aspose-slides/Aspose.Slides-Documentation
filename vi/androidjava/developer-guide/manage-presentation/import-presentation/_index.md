---
title: Nhập bản trình bày từ PDF hoặc HTML trên Android
linktitle: Nhập Bản Trình Bày
type: docs
weight: 60
url: /vi/androidjava/import-presentation/
keywords:
- nhập bản trình bày
- nhập slide
- nhập PDF
- nhập HTML
- PDF sang bản trình bày
- PDF sang PPT
- PDF sang PPTX
- PDF sang ODP
- HTML sang bản trình bày
- HTML sang PPT
- HTML sang PPTX
- HTML sang ODP
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Nhập tài liệu PDF và HTML vào các bản trình bày PowerPoint và OpenDocument trong Java với Aspose.Slides cho Android để xử lý slide liền mạch, hiệu suất cao."
---
## **Giới thiệu**

Sử dụng [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/vi/androidjava/), bạn có thể nhập các bài thuyết trình từ các tệp ở định dạng khác. Aspose.Slides cung cấp lớp [SlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidecollection/) cho phép bạn nhập các bài thuyết trình từ PDF, tài liệu HTML, v.v.

## **Nhập PowerPoint từ PDF**

Trong trường hợp này, bạn sẽ chuyển đổi một tệp PDF thành bản trình bày PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/).
2. Gọi phương thức [addFromPdf()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) và truyền tệp PDF.
3. Sử dụng phương thức [save()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) để lưu tệp dưới định dạng PowerPoint.

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="primary" %}}Bạn có thể muốn kiểm tra **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/vi/import/pdf-to-powerpoint) web app vì nó là một triển khai trực tiếp của quy trình được mô tả ở đây.{{% /alert %}}

## **Nhập PowerPoint từ HTML**

Trong trường hợp này, bạn sẽ chuyển đổi một tài liệu HTML thành bản trình bày PowerPoint.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/).
2. Gọi phương thức [addFromHtml()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) và truyền tệp HTML.
3. Sử dụng phương thức [save()](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) để lưu tệp dưới định dạng PowerPoint.

```java
Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Các bảng có được giữ lại khi nhập PDF không, và có thể cải thiện việc phát hiện chúng không?**

Các bảng có thể được phát hiện trong quá trình nhập; [PdfImportOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfimportoptions/) bao gồm phương thức [setDetectTables](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) cho phép nhận dạng bảng. Hiệu quả phụ thuộc vào cấu trúc của PDF.