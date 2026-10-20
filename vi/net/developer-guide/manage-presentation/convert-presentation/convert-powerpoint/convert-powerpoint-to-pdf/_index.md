---
title: Chuyển đổi PPT và PPTX sang PDF trong .NET [Bao gồm các tính năng nâng cao]
linktitle: PowerPoint sang PDF
type: docs
weight: 40
url: /vi/net/convert-powerpoint-to-pdf/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- PowerPoint sang PDF
- bản trình bày sang PDF
- PPT sang PDF
- chuyển đổi PPT sang PDF
- PPTX sang PDF
- chuyển đổi PPTX sang PDF
- lưu PowerPoint dưới dạng PDF
- lưu PPT dưới dạng PDF
- lưu PPTX dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- đính kèm
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm trong .NET bằng Aspose.Slides, kèm theo các ví dụ mã C# nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản trình bày PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong C# mang lại một số lợi ích, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo tồn bố cục cùng định dạng của bản trình bày. Hướng dẫn này trình bày cách chuyển đổi bản trình bày sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình bày dưới các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình bày sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) và sau đó lưu bản trình bày dưới dạng PDF bằng phương thức [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Lớp [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) cung cấp phương thức [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) thường được sử dụng để chuyển đổi bản trình bày sang PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET chèn thông tin API và số phiên bản của nó vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản trình bày sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình bày sang PDF
* Các slide cụ thể trong một bản trình bày sang PDF

Aspose.Slides xuất bản trình bày sang PDF, đảm bảo các PDF kết quả gần giống với bản trình bày gốc. Các yếu tố và thuộc tính được dựng chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Liên kết siêu văn bản
* Header và footer
* Các dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi PowerPoint sang PDF tiêu chuẩn sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản trình bày đã cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng cao nhất.

Ví dụ sau tải một bản trình bày và lưu tất cả các slide khả dụng thành PDF bằng các cài đặt xuất mặc định.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose cung cấp một công cụ trực tuyến miễn phí [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) cho phép bạn xem quá trình chuyển đổi bản trình bày sang PDF. Bạn có thể thực hiện thử nghiệm với công cụ chuyển đổi này để thực hiện một ví dụ thực tế của quy trình được mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—cho phép bạn tùy chỉnh PDF đầu ra, khóa PDF bằng mật khẩu, hoặc chỉ định cách quy trình chuyển đổi sẽ tiến hành.

### **Chuyển đổi PowerPoint sang PDF với các tùy chọn tùy chỉnh**

Bằng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định cài đặt chất lượng mong muốn cho hình ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và hơn thế nữa.

Ví dụ sau xuất một bản trình bày sang PDF 1.5 với chất lượng JPEG đặt ở 90, độ phân giải hình ảnh đặt ở 300 DPI, metafile được lưu dưới dạng PNG, và nén văn bản Flate.

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

### **Tự động chọn nén hình ảnh**

Khi một bản trình bày chứa nhiều ảnh chụp hoặc ảnh chụp màn hình, việc giảm kích thước PDF xuất ra có thể giúp việc gửi email hoặc tải xuống dễ dàng hơn. Đặt [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) thành `true` để tự động chọn thuật toán nén thích hợp nhất cho mỗi ảnh trong quá trình xuất PDF.

Ví dụ sau tải một bản trình bày hiện có, bật tính năng tự động chọn nén hình ảnh, và lưu nó dưới dạng tài liệu PDF. Tất cả các cài đặt xuất PDF khác giữ nguyên giá trị mặc định.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

Tùy chọn này chọn một thuật toán nén cho mỗi ảnh. Giảm giá trị [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) sẽ làm giảm chất lượng ảnh JPEG, trong khi giảm [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) cho phép ảnh được giảm độ phân giải, có thể giảm chi tiết. Bật tự động chọn nén không tự động giảm bất kỳ cài đặt nào trong số này.

Việc chọn thuật toán nén ảnh yêu cầu thời gian xử lý và bộ nhớ bổ sung. Mức giảm kích thước phụ thuộc vào các ảnh trong bản trình bày và cài đặt xuất; không có mức giảm cố định cho mọi bản trình bày.

### **Bảo tồn tệp OLE nhúng dưới dạng tệp đính kèm PDF**

Nếu một bản trình bày chứa một workbook Excel được nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu workbook cũng như xem các slide. Đặt [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) thành `true` để bảo tồn các tệp OLE nhúng dưới dạng tệp đính kèm trong PDF kết quả.

Giá trị mặc định là `false`: hình ảnh hoặc biểu tượng xem trước của đối tượng OLE được dựng trên trang PDF, nhưng tệp nhúng không được bao gồm dưới dạng tệp đính kèm. Khi đặt tùy chọn này thành `true` thì dữ liệu tệp cũng được bao gồm. Hình ảnh xem trước vẫn là một biểu diễn trực quan; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE không trở thành một worksheet Excel tương tác trên trang PDF.

Ví dụ sau tải một bản trình bày đã có sẵn workbook Excel được nhúng và xuất nó sang PDF với workbook được đính kèm.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Để kiểm tra kết quả:

1. Mở PDF đã xuất trong một trình xem hỗ trợ tệp đính kèm, chẳng hạn Adobe Acrobat Reader.
2. Mở bảng **Attachments** của trình xem và tìm workbook đã nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Hình ảnh xem trước trên trang PDF tách biệt với tệp đính kèm.

{{% alert color="info" title="Note" %}}
Tiêu chuẩn PDF/A áp đặt các hạn chế về tệp đính kèm: PDF/A-1 cấm tệp nhúng, PDF/A-2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm workbook Excel. Đây là yêu cầu của tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không trình bày việc xuất PDF/A.
{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với các slide ẩn**

Nếu một bản trình bày chứa các slide ẩn, bạn có thể sử dụng thuộc tính [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) từ lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) để bao gồm các slide ẩn làm các trang trong PDF kết quả.

Ví dụ sau xuất một bản trình bày sang PDF, bao gồm bất kỳ slide ẩn nào.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Chuyển đổi PowerPoint sang PDF có mật khẩu**

Ví dụ sau xuất một bản trình bày sang PDF yêu cầu mật khẩu `password` để mở. Các quyền truy cập cho phép in, bao gồm in chất lượng cao.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Phát hiện thay thế phông chữ**

Aspose.Slides cung cấp thuộc tính [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) dưới lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) cho phép bạn phát hiện các thay thế phông chữ trong quá trình chuyển đổi bản trình bày sang PDF.

Ví dụ sau xuất một bản trình bày sang PDF và in các cảnh báo thay thế phông chữ ra console. Cảnh báo chỉ được in khi một phông chữ không khả dụng được thay thế trong quá trình xuất.

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

### **Xử lý phông chữ không có kiểu chữ đậm riêng**

Một bản trình bày có thể áp dụng định dạng đậm cho văn bản ngay cả khi phông chữ của nó không có kiểu chữ đậm riêng. Văn bản vẫn có thể xuất hiện đậm thông qua việc làm đậm tổng hợp, làm dày các glyph thường. Khi văn bản đó trông quá nặng hoặc khác với mong muốn trong PDF, hãy thử đặt [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) thành `true`. Tùy chọn này sẽ dựng văn bản bị ảnh hưởng dưới dạng bitmap trong quá trình xuất PDF và có thể cải thiện hiển thị cho một số phông chữ. Giá trị mặc định là `false`.

Bản trình bày mẫu chứa hai hộp văn bản: một với văn bản thường và một với định dạng đậm áp dụng cho cùng một phông chữ, phông chữ này không có kiểu đậm riêng. Ví dụ sau tải bản trình bày, bật rasterization cho các kiểu phông chữ không được hỗ trợ, và xuất nó sang PDF:

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

Các hình ảnh xem trước sau đây cho thấy kết quả khi tắt và khi bật tùy chọn. Trong ví dụ này, văn bản đậm có nét dày hơn khi tùy chọn tắt. Khi bật, nét của nó mỏng hơn; văn bản thường không thay đổi. So sánh kết quả trước khi chọn cài đặt cho bản trình bày của bạn.

| Tùy chọn tắt (`false`, mặc định) | Tùy chọn bật (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Trong ví dụ này, bật tùy chọn chỉ biến văn bản đậm thành bitmap: không thể chọn, sao chép hoặc tìm kiếm dưới dạng văn bản mà không có OCR, và các cạnh của nó trông mềm hơn ở mức phóng đại 800%. Văn bản thường vẫn có thể tìm kiếm. Khi tắt tùy chọn, cả hai chuỗi vẫn là văn bản.

Tùy chọn này rasterizes văn bản được định dạng đậm khi phông chữ của nó không có kiểu đậm riêng. [Thay thế phông chữ](/slides/vi/net/font-substitution/) thay vào đó sẽ chọn một phông chữ khác khi phông chữ gốc không khả dụng.

## **Chuyển đổi các slide đã chọn từ PowerPoint sang PDF**

Ví dụ sau xuất các slide 1 và 3 từ một bản trình bày sang PDF. Các số slide trong mảng này được đánh số bắt đầu từ 1, và bản trình bày đầu vào phải có ít nhất ba slide.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Chuyển đổi PowerPoint sang PDF với kích thước slide tùy chỉnh**

Ví dụ sau sao chép slide đầu tiên từ một bản trình bày vào một bản trình bày mới với kích thước slide 612 × 792 điểm (8,5 × 11 inch). Nó thu phóng nội dung slide để vừa và xuất slide đơn này sang PDF.

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

## **Chuyển đổi PowerPoint sang PDF trong chế độ xem ghi chú slide**

Ví dụ sau xuất một bản trình bày sang PDF, đặt ghi chú của người thuyết trình dưới mỗi slide. Sử dụng một bản trình bày có ghi chú để xem kết quả.

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

## **Tiêu chuẩn truy cập và tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng một quy trình chuyển đổi tuân thủ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã C# dưới đây minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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
Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi tệp PDF sang các định dạng tệp phổ biến. Bạn có thể thực hiện chuyển đổi [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), và [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt—[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), và [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—cũng được hỗ trợ.
{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại dưới dạng nội dung riêng và có thể được đánh dấu là artefacts; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Có thể chuyển đổi nhiều tệp PowerPoint sang PDF đồng thời không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp lại qua các tệp của mình và áp dụng quy trình chuyển đổi bằng cách lập trình.

**Có thể bảo mật PDF đã chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) để đặt mật khẩu và định nghĩa quyền truy cập trong quá trình chuyển đổi.

**Làm thế nào để bao gồm các slide ẩn trong PDF?**

Đặt thuộc tính [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) trong lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) thành `true` để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có duy trì chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng cách đặt các thuộc tính như [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) và [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) trong lớp [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) để đảm bảo hình ảnh chất lượng cao trong PDF.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các tiêu chuẩn khác nhau, bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng yêu cầu truy cập và lưu trữ.

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides for .NET](/slides/vi/net/)
- [Tham chiếu API Aspose.Slides for .NET](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)