---
title: Nhập Bản Trình Chiếu từ PDF hoặc HTML trong PHP
linktitle: Nhập Bản Trình Chiếu
type: docs
weight: 60
url: /vi/php-java/import-presentation/
keywords:
- nhập bản trình chiếu
- nhập slide
- nhập PDF
- nhập HTML
- PDF sang bản trình chiếu
- PDF sang PPT
- PDF sang PPTX
- PDF sang ODP
- HTML sang bản trình chiếu
- HTML sang PPT
- HTML sang PPTX
- HTML sang ODP
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Nhập tài liệu PDF và HTML vào các bản trình chiếu PowerPoint và OpenDocument trong PHP với Aspose.Slides để xử lý slide liền mạch, hiệu suất cao."
---
## **Giới thiệu**

Sử dụng [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/vi/php-java/), bạn có thể nhập các bản trình chiếu từ các tệp ở định dạng khác. Aspose.Slides cung cấp lớp [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/) để cho phép bạn nhập các bản trình chiếu từ PDF, tài liệu HTML, v.v.

## **Nhập PowerPoint từ PDF**

Trong trường hợp này, bạn sẽ chuyển đổi PDF sang bản trình chiếu PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/) .
2. Gọi phương thức [addFromPdf()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) và truyền tệp PDF.
3. Sử dụng phương thức [save()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation#save-java.lang.String-int-) để lưu tệp ở định dạng PowerPoint.

Đoạn mã PHP dưới đây minh họa thao tác chuyển đổi PDF sang PowerPoint:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->addFromPdf("InputPDF.pdf");
    $pres->save("OutputPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert  title="Tip" color="primary" %}} 

Bạn có thể muốn khám phá ứng dụng web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/vi/import/pdf-to-powerpoint) vì nó là một triển khai trực tiếp của quy trình được mô tả ở đây. 

{{% /alert %}} 

## **Nhập PowerPoint từ HTML**

Trong trường hợp này, bạn sẽ chuyển đổi tài liệu HTML sang bản trình chiếu PowerPoint.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/) .
2. Gọi phương thức [addFromHtml()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) và truyền tệp HTML.
3. Sử dụng phương thức [save()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation#save-java.lang.String-int-) để lưu tệp ở định dạng PowerPoint.

Đoạn mã PHP dưới đây minh họa thao tác chuyển đổi HTML sang PowerPoint:

```php
  $presentation = new Presentation();
  try {
    $htmlStream = new Java("java.io.FileInputStream", "page.html");
    try {
      $presentation->getSlides()->addFromHtml($htmlStream);
    } finally {
      if (!java_is_null($htmlStream)) {
        $htmlStream->close();
      }
    }
    $presentation->save("MyPresentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **FAQ**

**Các bảng có được giữ nguyên khi nhập PDF không, và có thể cải thiện việc phát hiện chúng không?**

Các bảng có thể được phát hiện trong quá trình nhập; [PdfImportOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pdfimportoptions/) bao gồm phương thức [setDetectTables](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pdfimportoptions/#setDetectTables) cho phép nhận dạng bảng. Hiệu quả phụ thuộc vào cấu trúc của PDF.

{{% alert title="Note" color="warning" %}} 

Bạn cũng có thể sử dụng Aspose.Slides để chuyển đổi HTML sang các định dạng tệp phổ biến khác: 

* [HTML to image](https://products.aspose.com/slides/vi/php-java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/vi/php-java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/vi/php-java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/vi/php-java/conversion/html-to-tiff/)

{{% /alert %}}