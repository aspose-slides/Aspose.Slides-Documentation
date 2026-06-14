---
title: Nhập Bản Trình Chiếu Từ PDF Hoặc HTML Trong .NET
linktitle: Nhập Bản Trình Chiếu
type: docs
weight: 60
url: /vi/net/import-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Dễ dàng nhập các tài liệu PDF và HTML vào các bản trình chiếu PowerPoint và OpenDocument trong .NET với Aspose.Slides để xử lý slide liền mạch và hiệu suất cao."
---
## **Giới thiệu**

Bằng cách sử dụng Aspose.Slides, bạn có thể nhập các bản trình chiếu từ các tệp ở định dạng khác. Aspose.Slides cung cấp lớp [SlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/slidecollection/), cho phép bạn nhập các bản trình chiếu từ tài liệu PDF và HTML.

## **Nhập PowerPoint từ PDF**

Trong trường hợp này, bạn sẽ chuyển đổi một tệp PDF sang bản trình chiếu PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/). 
2. Gọi phương thức [AddFromPdf](https://reference.aspose.com/slides/vi/net/aspose.slides.slidecollection/addfrompdf/methods/1) và truyền tệp PDF. 
3. Sử dụng phương thức [Save](https://reference.aspose.com/slides/vi/net/aspose.slides.presentation/save/methods/5) để lưu tệp ở định dạng PowerPoint.

Đoạn mã C# sau minh họa quá trình chuyển đổi PDF sang PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="primary" %}} 
Bạn có thể muốn thử **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/vi/import/pdf-to-powerpoint) web app vì nó là một triển khai thực tế của quy trình được mô tả ở đây. 
{{% /alert %}} 

## **Nhập PowerPoint từ HTML**

Trong trường hợp này, bạn sẽ chuyển đổi một tài liệu HTML sang bản trình chiếu PowerPoint.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) . 
2. Gọi phương thức [AddFromHtml](https://reference.aspose.com/slides/vi/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) và truyền tệp HTML. 
3. Sử dụng phương thức [Save](https://apireference.aspose.com/slides/vi/net/aspose.slides.presentation/save/methods/5) để lưu tệp dưới dạng tài liệu PowerPoint.

Đoạn mã C# sau minh họa quá trình chuyển đổi HTML sang PowerPoint: 

```c#
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

**Các bảng có được giữ nguyên khi nhập PDF không, và việc phát hiện chúng có thể được cải thiện không?**

Các bảng có thể được phát hiện trong quá trình nhập; [PdfImportOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.import/pdfimportoptions/) bao gồm tham số [DetectTables](https://reference.aspose.com/slides/vi/net/aspose.slides.import/pdfimportoptions/detecttables/) cho phép nhận dạng bảng. Hiệu quả phụ thuộc vào cấu trúc của tệp PDF.

{{% alert title="Note" color="warning" %}} 
Bạn cũng có thể sử dụng Aspose.Slides để chuyển đổi HTML sang các định dạng tệp phổ biến khác: 

* [HTML to image](https://products.aspose.com/slides/vi/net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/vi/net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/vi/net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/vi/net/conversion/html-to-tiff/)

{{% /alert %}}