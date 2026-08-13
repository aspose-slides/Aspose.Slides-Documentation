---
title: Nhập Bài Thuyết Trình từ PDF hoặc HTML trong Java
linktitle: Nhập Bài Thuyết Trình
type: docs
weight: 60
url: /vi/java/import-presentation/
keywords:
- nhập bài thuyết trình
- nhập slide
- nhập PDF
- nhập HTML
- PDF sang bài thuyết trình
- PDF sang PPT
- PDF sang PPTX
- PDF sang ODP
- HTML sang bài thuyết trình
- HTML sang PPT
- HTML sang PPTX
- HTML sang ODP
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Dễ dàng nhập tài liệu PDF và HTML vào các bài thuyết trình PowerPoint và OpenDocument trong Java bằng Aspose.Slides để xử lý slide liền mạch, hiệu năng cao."
---
## **Giới thiệu**

Sử dụng Aspose.Slides, bạn có thể nhập các bài thuyết trình từ các tệp ở định dạng khác. Aspose.Slides cung cấp lớp [SlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidecollection/) cho phép bạn nhập các bài thuyết trình từ tài liệu PDF và HTML.

## **Nhập PowerPoint từ PDF**

Trong trường hợp này, bạn sẽ chuyển đổi PDF sang bản trình chiếu PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/) .
2. Gọi phương thức [addFromPdf()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) và truyền tệp PDF.
3. Sử dụng phương thức [save()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#save-java.lang.String-int-) để lưu tệp dưới định dạng PowerPoint.

Mã Java này minh họa thao tác chuyển đổi PDF sang PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Mẹo" color="info" %}} 

Bạn có thể muốn thử **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/vi/import/pdf-to-powerpoint) vì đây là một ứng dụng web thực hiện quy trình đã mô tả ở đây. 

{{% /alert %}} 

## **Nhập PowerPoint từ HTML**

Trong trường hợp này, bạn sẽ chuyển đổi tài liệu HTML sang bản trình chiếu PowerPoint.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/) .
2. Gọi phương thức [addFromHtml()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) và truyền một luồng chứa tài liệu HTML.
3. Sử dụng phương thức [save()](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation#save-java.lang.String-int-) để lưu tệp dưới định dạng PowerPoint.

Mã Java này minh họa thao tác chuyển đổi HTML sang PowerPoint: 

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

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

### Các bảng có được giữ lại khi nhập PDF không, và có thể cải thiện việc phát hiện chúng không?

Các bảng có thể được phát hiện trong quá trình nhập; [PdfImportOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfimportoptions/) bao gồm phương thức [setDetectTables](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) cho phép nhận dạng bảng. Hiệu quả phụ thuộc vào cấu trúc của PDF.

{{% alert title="Lưu ý" color="warning" %}} 

Bạn cũng có thể sử dụng Aspose.Slides để chuyển đổi HTML sang các định dạng tệp phổ biến khác: 

* [HTML to image](https://products.aspose.com/slides/vi/java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/vi/java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/vi/java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/vi/java/conversion/html-to-tiff/)

{{% /alert %}}