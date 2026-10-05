---
title: "Chuyển đổi PPT và PPTX sang PDF trong .NET [Bao gồm các tính năng nâng cao]"
linktitle: "PowerPoint sang PDF"
type: docs
weight: 40
url: /vi/net/convert-powerpoint-to-pdf/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- PowerPoint sang PDF
- bản trình chiếu sang PDF
- PPT sang PDF
- chuyển đổi PPT sang PDF
- PPTX sang PDF
- chuyển đổi PPTX sang PDF
- lưu PowerPoint dưới dạng PDF
- lưu PPT dưới dạng PDF
- lưu PPTX dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- tệp đính kèm
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm trong .NET bằng Aspose.Slides, kèm theo các ví dụ mã C# nhanh chóng và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong C# mang lại một số lợi ích, bao gồm khả năng tương thích trên các thiết bị khác nhau và giữ nguyên bố cục cũng như định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu xuất ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) cung cấp phương thức [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) thường được dùng để chuyển đổi một bản trình chiếu sang PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides cho .NET chèn thông tin API và số phiên bản vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản trình chiếu sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Note** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể từ một bản trình chiếu sang PDF

Aspose.Slides xuất bản trình chiếu sang PDF, đảm bảo các PDF kết quả gần giống với bản trình chiếu gốc. Các thành phần và thuộc tính được render một cách chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Liên kết siêu văn bản
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi PowerPoint sang PDF tiêu chuẩn sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản trình chiếu đã cung cấp sang PDF bằng các thiết lập tối ưu ở mức chất lượng cao nhất.

Ví dụ sau tải một bản trình chiếu và lưu tất cả các slide hiển thị sang PDF bằng các thiết lập xuất mặc định.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose cung cấp một công cụ trực tuyến miễn phí [**trình chuyển đổi PowerPoint sang PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) để minh họa quy trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể chạy thử công cụ này để thực hiện quy trình chuyển đổi trong thời gian thực như mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với các Tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính dưới lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—cho phép bạn tùy biến PDF đầu ra, khóa PDF bằng mật khẩu, hoặc chỉ định cách quá trình chuyển đổi sẽ diễn ra.

### **Chuyển đổi PowerPoint sang PDF với Các Tùy chọn Tùy chỉnh**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể định nghĩa thiết lập chất lượng mong muốn cho ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho ảnh, và nhiều hơn nữa.

Ví dụ sau xuất một bản trình chiếu sang PDF 1.5 với chất lượng JPEG được đặt là 90, độ phân giải ảnh là 300 DPI, metafile được lưu dưới dạng PNG, và nén văn bản Flate.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Bảo tồn các tệp OLE nhúng dưới dạng Tệp đính kèm PDF**

Nếu một bản trình chiếu chứa một workbook Excel được nhúng, bạn có thể muốn người nhận PDF cũng truy cập được dữ liệu của workbook cùng với việc xem các slide. Đặt [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) thành `true` để bảo tồn các tệp OLE nhúng dưới dạng tệp đính kèm trong PDF đầu ra.

Giá trị mặc định là `false`: hình ảnh hoặc biểu tượng xem trước của đối tượng OLE được render trên trang PDF, nhưng tệp nhúng không được bao gồm dưới dạng tệp đính kèm. Khi đặt tùy chọn thành `true` thì dữ liệu tệp cũng được bao gồm. Bản xem trước vẫn là một hình ảnh trực quan; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE không trở thành một worksheet Excel tương tác trên trang PDF.

Ví dụ sau tải một bản trình chiếu đã chứa sẵn workbook Excel nhúng và xuất nó sang PDF với workbook được đính kèm.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Để kiểm tra kết quả:

1. Mở PDF đã xuất trong một trình xem hỗ trợ tệp đính kèm, chẳng hạn Adobe Acrobat Reader.
2. Mở panel **Attachments** của trình xem và tìm workbook đã nhúng.
3. Lưu tệp đính kèm và mở trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Bản xem trước trên trang PDF là riêng biệt so với tệp đính kèm.

{{% alert color="info" title="Note" %}}
Các tiêu chuẩn PDF/A áp đặt các giới hạn đối với tệp đính kèm: PDF/A-1 cấm các tệp nhúng, PDF/A-2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm workbook Excel. Đây là các yêu cầu của tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng thiết lập tuân thủ PDF mặc định và không minh họa việc xuất PDF/A.
{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với các Slide Ẩn**

Nếu một bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng thuộc tính [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) từ lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) để bao gồm các slide ẩn làm các trang trong PDF đầu ra.

Ví dụ sau xuất một bản trình chiếu sang PDF, bao gồm mọi slide ẩn.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Chuyển đổi PowerPoint sang PDF được Bảo mật bằng Mật khẩu**

Ví dụ sau xuất một bản trình chiếu sang PDF yêu cầu mật khẩu `password` để mở. Các quyền truy cập cho phép in, bao gồm in chất lượng cao.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Phát hiện Thay thế Phông chữ**

Aspose.Slides cung cấp thuộc tính [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) dưới lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) cho phép bạn phát hiện các trường hợp thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

Ví dụ sau xuất một bản trình chiếu sang PDF và in các cảnh báo thay thế phông chữ ra console. Cảnh báo chỉ được in khi một phông chữ không có sẵn bị thay thế trong quá trình xuất.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
Để biết thêm thông tin về thay thế phông chữ, xem bài viết [Thay thế Phông chữ](/slides/vi/net/font-substitution/).
{{% /alert %}} 

## **Chuyển đổi các Slide Được Chọn từ PowerPoint sang PDF**

Ví dụ sau xuất các slide 1 và 3 từ một bản trình chiếu sang PDF. Các số slide trong mảng này được đánh số bắt đầu từ 1, và bản trình chiếu đầu vào phải chứa ít nhất ba slide.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Chuyển đổi PowerPoint sang PDF với Kích thước Slide Tùy chỉnh**

Ví dụ sau sao chép slide đầu tiên từ một bản trình chiếu vào một bản trình chiếu mới với kích thước slide là 612 × 792 điểm (8.5 × 11 inch). Nó thu phóng nội dung slide để vừa và xuất slide đơn này sang PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Chuyển đổi PowerPoint sang PDF trong chế độ Xem Ghi chú Slide**

Ví dụ sau xuất một bản trình chiếu sang PDF, đặt ghi chú của mỗi slide dưới slide tương ứng. Sử dụng một bản trình chiếu có ghi chú để xem kết quả.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Tiêu chuẩn Truy cập và Tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ các [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF sử dụng bất kỳ tiêu chuẩn tuân thủ nào trong số: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert color="info" title="Note" %}}
Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi các tệp PDF sang các định dạng phổ biến. Bạn có thể thực hiện các chuyển đổi [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), và [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt khác—[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), và [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—cũng được hỗ trợ.
{{% /alert %}}

> **Note:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại làm nội dung riêng và có thể được đánh dấu là artefact; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Có thể chuyển đổi nhiều tệp PowerPoint sang PDF cùng lúc không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể duyệt qua các tệp và áp dụng quy trình chuyển đổi bằng lập trình.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm sao để bao gồm các slide ẩn trong PDF?**

Đặt thuộc tính [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) trong lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) thành `true` để bao gồm các slide ẩn trong PDF đầu ra.

**Aspose.Slides có thể giữ chất lượng ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng ảnh bằng cách đặt các thuộc tính như [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) và [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) trong lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) để đảm bảo ảnh trong PDF có độ phân giải cao.

**Aspose.Slides có hỗ trợ các tiêu chuẩn PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các tiêu chuẩn khác nhau, bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng yêu cầu truy cập và lưu trữ lâu dài.

## **Additional Resources**

- [Aspose.Slides for .NET Documentation](/slides/vi/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)