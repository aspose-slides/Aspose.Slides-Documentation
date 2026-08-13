---
title: Nhập bản trình bày từ PDF hoặc HTML trong .NET
linktitle: Nhập Bản Trình Bày
type: docs
weight: 60
url: /vi/net/import-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Dễ dàng nhập các tài liệu PDF và HTML vào bản trình bày PowerPoint và OpenDocument trong .NET bằng Aspose.Slides để xử lý slide liền mạch, hiệu suất cao."
---
## **Giới thiệu**

Sử dụng Aspose.Slides, bạn có thể nhập các bản trình bày từ các tệp ở định dạng khác. Aspose.Slides cung cấp lớp [SlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/slidecollection/) cho phép bạn nhập bản trình bày từ tài liệu PDF và HTML.

## **Nhập PowerPoint từ PDF**

Trong trường hợp này, bạn sẽ chuyển đổi một tệp PDF sang bản trình bày PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
2. Gọi phương thức [AddFromPdf](https://reference.aspose.com/slides/vi/net/aspose.slides.slidecollection/addfrompdf/methods/1) và truyền tệp PDF.
3. Sử dụng phương thức [Save](https://reference.aspose.com/slides/vi/net/aspose.slides.presentation/save/methods/5) để lưu tệp ở định dạng PowerPoint.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="info" %}} 
Bạn có thể muốn xem ứng dụng web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/vi/import/pdf-to-powerpoint) vì đây là một triển khai thực tế của quy trình được mô tả ở đây. 
{{% /alert %}} 

## **Nhập PowerPoint từ HTML**

Trong trường hợp này, bạn sẽ chuyển đổi một tài liệu HTML sang bản trình bày PowerPoint.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
2. Gọi phương thức [AddFromHtml](https://reference.aspose.com/slides/vi/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) và truyền tệp HTML.
3. Sử dụng phương thức [Save](https://apireference.aspose.com/slides/vi/net/aspose.slides.presentation/save/methods/5) để lưu tệp dưới dạng tài liệu PowerPoint.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

## **Câu hỏi thường gặp**

### Các bảng có được bảo tồn khi nhập PDF không, và có thể cải thiện việc phát hiện chúng không?

Các bảng có thể được phát hiện khi nhập; [PdfImportOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.import/pdfimportoptions/) bao gồm tham số [DetectTables](https://reference.aspose.com/slides/vi/net/aspose.slides.import/pdfimportoptions/detecttables/) cho phép nhận dạng bảng. Hiệu quả phụ thuộc vào cấu trúc của PDF.

{{% alert title="Note" color="warning" %}} 
Bạn cũng có thể sử dụng Aspose.Slides để chuyển đổi HTML sang các định dạng tệp phổ biến khác: 

* [HTML sang hình ảnh](https://products.aspose.com/slides/vi/net/conversion/html-to-image/)
* [HTML sang JPG](https://products.aspose.com/slides/vi/net/conversion/html-to-jpg/)
* [HTML sang XML](https://products.aspose.com/slides/vi/net/conversion/html-to-xml/)
* [HTML sang TIFF](https://products.aspose.com/slides/vi/net/conversion/html-to-tiff/)

{{% /alert %}}