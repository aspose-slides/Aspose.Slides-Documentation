---
title: Chuyển đổi PPT và PPTX sang PDF trong .NET [Bao gồm các tính năng nâng cao]
linktitle: PowerPoint sang PDF
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
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm được trong .NET bằng Aspose.Slides, kèm ví dụ mã C# nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong C# mang lại một số lợi thế, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo tồn bố cục cũng như định dạng của bản trình chiếu. Hướng dẫn này minh họa cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) cung cấp phương thức [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) thường được dùng để chuyển đổi bản trình chiếu sang PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for .NET chèn thông tin API và số phiên bản của nó vào các tài liệu đầu ra. Ví dụ, khi chuyển đổi bản trình chiếu sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng một giá trị dạng "*Aspose.Slides v XX.XX*". **Note** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.

{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể từ một bản trình chiếu sang PDF

Aspose.Slides xuất bản trình chiếu sang PDF, đảm bảo các tệp PDF tạo ra khớp gần như hoàn hảo với bản trình chiếu gốc. Các thành phần và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Đầu trang và chân trang
* Các dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quy trình chuyển đổi PowerPoint‑to‑PDF tiêu chuẩn sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides sẽ cố gắng chuyển đổi bản trình chiếu đã cung cấp sang PDF với các cài đặt tối ưu ở mức chất lượng cao nhất.

Ví dụ dưới đây tải một bản trình chiếu và lưu tất cả các slide hiển thị sang PDF bằng các cài đặt xuất mặc định.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}

Aspose cung cấp một công cụ chuyển đổi trực tuyến miễn phí [**Bộ chuyển đổi PowerPoint sang PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) để minh họa quy trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể chạy thử công cụ này để xem triển khai thực tế của quy trình được mô tả ở đây.

{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với các Tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính dưới lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—để bạn có thể tùy biến PDF đầu ra, khóa PDF bằng mật khẩu, hoặc chỉ định cách quá trình chuyển đổi sẽ diễn ra.

### **Chuyển đổi PowerPoint sang PDF với Tùy chọn Tùy chỉnh**

Bằng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể định nghĩa mức chất lượng mong muốn cho ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho ảnh, và nhiều hơn nữa.

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

### **Bảo tồn các tệp OLE nhúng dưới dạng tệp đính kèm PDF**

Nếu bản trình chiếu chứa một sổ làm việc Excel được nhúng, bạn có thể muốn người nhận PDF cũng có thể truy cập dữ liệu trong sổ làm việc cũng như xem các slide. Đặt [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) thành `true` để bảo tồn các tệp OLE nhúng dưới dạng tệp đính kèm trong PDF kết quả.

Giá trị mặc định là `false`: ảnh thu nhỏ hoặc biểu tượng của đối tượng OLE được hiển thị trên trang PDF, nhưng tệp nhúng không được đưa vào dưới dạng đính kèm. Khi đặt thành `true` thì dữ liệu tệp cũng sẽ được bao gồm. Ảnh thu nhỏ vẫn chỉ là biểu diễn hình ảnh; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE sẽ không trở thành một bảng tính Excel tương tác trên trang PDF.

Ví dụ dưới đây tải một bản trình chiếu đã chứa sổ làm việc Excel nhúng và xuất nó sang PDF với sổ làm việc được đính kèm.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Để kiểm tra kết quả:

1. Mở PDF đã xuất trong trình xem hỗ trợ tệp đính kèm, chẳng hạn Adobe Acrobat Reader.
2. Mở panel **Attachments** của trình xem và tìm kiếm sổ làm việc được nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Ảnh thu nhỏ trên trang PDF là riêng biệt so với tệp đính kèm.

{{% alert color="info" title="Note" %}}

Tiêu chuẩn PDF/A có các hạn chế về tệp đính kèm: PDF/A‑1 cấm tệp nhúng, PDF/A‑2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A‑3 cho phép các loại tệp khác, bao gồm sổ làm việc Excel. Đây là yêu cầu của tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không minh họa xuất PDF/A.

{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với các Slide Ẩn**

Nếu bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng thuộc tính [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) của lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) để bao gồm các slide ẩn dưới dạng các trang trong PDF kết quả.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Chuyển đổi PowerPoint sang PDF được Bảo mật bằng Mật khẩu**

Ví dụ dưới đây xuất một bản trình chiếu sang PDF yêu cầu mật khẩu `password` để mở. Quyền truy cập cho phép in, bao gồm in với chất lượng cao.

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

Aspose.Slides cung cấp thuộc tính [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) trong lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) cho phép bạn phát hiện các trường hợp thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

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

Để biết thêm thông tin về thay thế phông chữ, xem bài viết [Thay thế phông chữ](/slides/vi/net/font-substitution/).

{{% /alert %}} 

### **Xử lý Phông chữ Không Có Kiểu Bảng chữ Đậm Riêng**

Một bản trình chiếu có thể áp dụng định dạng đậm cho văn bản ngay cả khi phông chữ không có kiểu đậm riêng. Văn bản sẽ vẫn xuất hiện đậm thông qua việc làm đậm tổng hợp, tức là làm dày các glyph thông thường. Khi văn bản này trông quá nặng hoặc không giống như mong muốn trong PDF, hãy thử đặt [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) thành `true`. Tùy chọn này sẽ raster hoá văn bản bị ảnh hưởng thành bitmap trong quá trình xuất PDF và có thể cải thiện hiển thị cho một số phông chữ. Giá trị mặc định là `false`.

Bản trình chiếu mẫu chứa hai hộp văn bản: một với văn bản thường và một với định dạng đậm áp dụng cho cùng một phông chữ, phông chữ này không có kiểu đậm riêng. Ví dụ dưới đây tải bản trình chiếu, bật raster hoá các kiểu phông chữ không hỗ trợ, và xuất nó sang PDF:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

Các hình ảnh dưới đây cho thấy kết quả khi tắt và bật tùy chọn. Trong ví dụ này, văn bản đậm có nét dày hơn khi tùy chọn tắt. Khi bật, nét của nó nhẹ hơn; văn bản thường không thay đổi. Hãy so sánh kết quả trước khi quyết định cài đặt cho bản trình chiếu của bạn.

| Tùy chọn tắt (`false`, mặc định) | Tùy chọn bật (`true`) |
|---|---|
| ![PDF với raster hoá kiểu phông chữ không hỗ trợ bị tắt](unsupported-bold-disabled.png) | ![PDF với raster hoá kiểu phông chữ không hỗ trợ được bật](unsupported-bold-enabled.png) |

Trong ví dụ này, bật tùy chọn chỉ chuyển đổi văn bản đậm thành bitmap: nó không thể được chọn, sao chép hoặc tìm kiếm dưới dạng văn bản mà không có OCR, và các cạnh của nó trông mềm hơn ở mức phóng 800%. Văn bản thường vẫn có thể tìm kiếm. Khi tắt tùy chọn, cả hai chuỗi vẫn là văn bản.

Tùy chọn này raster hoá văn bản được định dạng đậm khi phông chữ không có kiểu đậm riêng. Thay thế phông chữ [Thay thế phông chữ](/slides/vi/net/font-substitution/) sẽ chọn một phông chữ khác khi phông chữ gốc không khả dụng.

## **Chuyển đổi các Slide Đã Chọn từ PowerPoint sang PDF**

Ví dụ dưới đây xuất các slide 1 và 3 từ một bản trình chiếu sang PDF. Các số slide trong mảng này tính từ 1, và bản trình chiếu đầu vào phải chứa ít nhất ba slide.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Chuyển đổi PowerPoint sang PDF với Kích thước Slide Tùy chỉnh**

Ví dụ dưới đây sao chép slide đầu tiên từ một bản trình chiếu vào một bản trình chiếu mới với kích thước slide là 612 × 792 điểm (8.5 × 11 inch). Nó thu phóng nội dung slide để vừa và xuất slide duy nhất này sang PDF.

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

// Loại bỏ slide trống mà bản trình chiếu mới được tạo ra.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Chuyển đổi PowerPoint sang PDF trong chế độ Xem Ghi chú Slide**

Ví dụ dưới đây xuất một bản trình chiếu sang PDF, đặt ghi chú thuyết trình của mỗi slide dưới slide tương ứng. Hãy sử dụng một bản trình chiếu có ghi chú thuyết trình để xem kết quả.

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

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

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

Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi tệp PDF sang các định dạng phổ biến. Bạn có thể thực hiện chuyển đổi [PDF sang HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF sang ảnh](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF sang JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), và [PDF sang PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt—[PDF sang SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF sang TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), và [PDF sang XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—cũng được hỗ trợ.

{{% /alert %}}

> **Note:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại dưới dạng nội dung riêng và có thể được đánh dấu là artefact; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF hàng loạt không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp và áp dụng quy trình chuyển đổi bằng mã.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) để đặt mật khẩu và định nghĩa quyền truy cập trong quá trình chuyển đổi.

**Làm thế nào để bao gồm các slide ẩn trong PDF?**

Đặt thuộc tính [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) trong lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) thành `true` để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có thể duy trì chất lượng ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng ảnh bằng cách đặt các thuộc tính như [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) và [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) trong lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) để đảm bảo ảnh trong PDF có chất lượng cao.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các tiêu chuẩn khác nhau, bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng các yêu cầu về truy cập và lưu trữ.

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides cho .NET](/slides/vi/net/)
- [Tham khảo API Aspose.Slides cho .NET](https://reference.aspose.com/slides/net/)
- [Công cụ Chuyển đổi Trực tuyến Miễn phí của Aspose](https://products.aspose.app/slides/conversion)