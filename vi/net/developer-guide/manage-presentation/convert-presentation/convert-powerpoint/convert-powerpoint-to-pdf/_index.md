---
title: Chuyển đổi PPT và PPTX sang PDF trong .NET [Bao gồm các tính năng nâng cao]
linktitle: PowerPoint sang PDF
type: docs
weight: 40
url: /vi/net/convert-powerpoint-to-pdf/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- PowerPoint sang PDF
- bài thuyết trình sang PDF
- PPT sang PDF
- chuyển đổi PPT sang PDF
- PPTX sang PDF
- chuyển đổi PPTX sang PDF
- lưu PowerPoint dưới dạng PDF
- lưu PPT dưới dạng PDF
- lưu PPTX dưới dạng PDF
- xuất PPT sang PDF
- xuất PPTX sang PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm trong .NET bằng Aspose.Slides, với các ví dụ mã C# nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Việc chuyển đổi các bản thuyết trình PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong C# mang lại một số lợi thế, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo tồn bố cục cũng như định dạng của bản thuyết trình. Hướng dẫn này trình bày cách chuyển đổi bản thuyết trình sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo mật PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản thuyết trình ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản thuyết trình sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và sau đó lưu bản thuyết trình dưới dạng PDF bằng phương thức [Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/). Lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) cung cấp phương thức [Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) thường được dùng để chuyển đổi một bản thuyết trình sang PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides cho .NET chèn thông tin API và số phiên bản của nó vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản thuyết trình sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị có dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể chỉ đạo Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.

{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản thuyết trình sang PDF
* Các slide cụ thể từ một bản thuyết trình sang PDF

Aspose.Slides xuất bản thuyết trình sang PDF, đảm bảo các tệp PDF kết quả gần như khớp với bản thuyết trình gốc. Các yếu tố và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi PowerPoint sang PDF tiêu chuẩn sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản thuyết trình đã cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng tối đa.

Mã C# sau cho thấy cách chuyển đổi một bản thuyết trình (PPT, PPTX, ODP, v.v.) sang PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Lưu bản thuyết trình dưới dạng PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

Aspose cung cấp một công cụ trực tuyến miễn phí **PowerPoint to PDF converter**(https://products.aspose.app/slides/vi/conversion/ppt-to-pdf) cho phép bạn thấy quá trình chuyển đổi bản thuyết trình sang PDF. Bạn có thể chạy thử công cụ này để thực hiện một ví dụ thực tế của quy trình được mô tả ở đây.

{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính dưới lớp [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/)—cho phép bạn tùy biến PDF kết quả, khóa PDF bằng mật khẩu, hoặc chỉ định cách quá trình chuyển đổi sẽ diễn ra.

### **Chuyển đổi PowerPoint sang PDF với tùy chọn tùy chỉnh**

Bằng cách sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định thiết lập chất lượng mong muốn cho hình ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và nhiều hơn nữa.

Ví dụ mã dưới đây minh họa cách chuyển đổi một bản thuyết trình PowerPoint sang PDF với một số tùy chọn tùy chỉnh.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp PdfOptions.
var pdfOptions = new PdfOptions
{
    // Đặt chất lượng cho hình ảnh JPG.
    JpegQuality = 90,

    // Đặt DPI cho hình ảnh.
    SufficientResolution = 300,

    // Đặt hành vi cho metafiles.
    SaveMetafilesAsPng = true,

    // Đặt mức nén văn bản cho nội dung văn bản.
    TextCompression = PdfTextCompression.Flate,

    // Xác định chế độ tuân thủ PDF.
    Compliance = PdfCompliance.Pdf15
};

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Lưu bản thuyết trình dưới dạng tài liệu PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Chuyển đổi PowerPoint sang PDF với các slide ẩn**

Nếu bản thuyết trình chứa các slide ẩn, bạn có thể sử dụng thuộc tính [ShowHiddenSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/showhiddenslides/) từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/) để bao gồm các slide ẩn dưới dạng các trang trong PDF kết quả.

Mã C# này cho thấy cách chuyển đổi một bản thuyết trình PowerPoint sang PDF với các slide ẩn được bao gồm:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Khởi tạo lớp PdfOptions.
var pdfOptions = new PdfOptions();

// Thêm các slide ẩn.
pdfOptions.ShowHiddenSlides = true;

// Lưu bản thuyết trình dưới dạng PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Chuyển đổi PowerPoint sang PDF có bảo mật bằng mật khẩu**

Mã C# này minh họa cách chuyển đổi một bản thuyết trình PowerPoint thành PDF được bảo mật bằng mật khẩu bằng cách sử dụng các tham số bảo vệ từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/):

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Khởi tạo lớp PdfOptions.
var pdfOptions = new PdfOptions();

// Đặt mật khẩu PDF và các quyền truy cập.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Lưu bản thuyết trình dưới dạng PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Phát hiện thay thế phông chữ**

Aspose.Slides cung cấp thuộc tính [WarningCallback](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveoptions/warningcallback/) dưới lớp [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/), cho phép bạn phát hiện các trường hợp thay thế phông chữ trong quá trình chuyển đổi bản thuyết trình sang PDF.

Mã C# này cho thấy cách phát hiện các thay thế phông chữ:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
    using var presentation = new Presentation("sample.pptx");

    // Đặt callback cảnh báo trong tùy chọn PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Lưu bản thuyết trình dưới dạng PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Triển khai callback cảnh báo.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 

Để biết thêm thông tin về nhận callback cho các thay thế phông chữ trong quá trình render, xem mục [Getting Warning Callbacks for Fonts Substitution](/slides/vi/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Để biết thêm thông tin về thay thế phông chữ, tham khảo bài viết [Font Substitution](/slides/vi/net/font-substitution/).

{{% /alert %}} 

## **Chuyển đổi các slide đã chọn từ PowerPoint sang PDF**

Mã C# này minh họa cách chỉ chuyển đổi các slide cụ thể từ một bản thuyết trình PowerPoint sang PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Đặt mảng các số slide.
int[] slides = { 1, 3 };

// Lưu bản thuyết trình dưới dạng PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Chuyển đổi PowerPoint sang PDF với kích thước slide tùy chỉnh**

Mã C# này minh họa cách chuyển đổi một bản thuyết trình PowerPoint sang PDF với kích thước slide đã chỉ định:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

// Tải bản thuyết trình PowerPoint.
using var presentation = new Presentation("SelectedSlides.pptx");

// Tạo một bản thuyết trình mới với kích thước slide được điều chỉnh.
using var resizedPresentation = new Presentation();

// Đặt kích thước slide tùy chỉnh.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Sao chép slide đầu tiên từ bản thuyết trình gốc.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Xóa slide trống mà bản thuyết trình mới được tạo ra.
resizedPresentation.Slides.RemoveAt(1);

// Lưu bản thuyết trình đã thay đổi kích thước dưới dạng PDF.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Chuyển đổi PowerPoint sang PDF ở chế độ xem ghi chú slide**

Mã C# này minh họa cách chuyển đổi một bản thuyết trình PowerPoint sang PDF có bao gồm ghi chú:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Tải bản thuyết trình PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Cấu hình các tùy chọn PDF với bố cục ghi chú.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Lưu bản thuyết trình thành PDF có ghi chú.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Tiêu chuẩn truy cập và tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Mã C# này minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều tệp PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

```c#
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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi các tệp PDF sang các định dạng phổ biến. Bạn có thể thực hiện các chuyển đổi [PDF to HTML](https://products.aspose.com/slides/vi/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/vi/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/vi/net/conversion/pdf-to-jpg/), và [PDF to PNG](https://products.aspose.com/slides/vi/net/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt—[PDF to SVG](https://products.aspose.com/slides/vi/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/vi/net/conversion/pdf-to-tiff/), và [PDF to XML](https://products.aspose.com/slides/vi/net/conversion/pdf-to-xml/)—cũng được hỗ trợ.

{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại như nội dung riêng và có thể được đánh dấu là hiện vật; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

### Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF cùng lúc không?

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp và áp dụng quy trình chuyển đổi bằng lập trình.

### Có thể bảo mật PDF đã chuyển đổi bằng mật khẩu không?

Chắc chắn rồi. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/) để đặt mật khẩu và xác định các quyền truy cập trong quá trình chuyển đổi.

### Làm thế nào để bao gồm các slide ẩn trong PDF?

Đặt thuộc tính `ShowHiddenSlides` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/) thành `true` để bao gồm các slide ẩn trong PDF kết quả.

### Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng cách đặt các thuộc tính như `JpegQuality` và `SufficientResolution` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/) để đảm bảo hình ảnh trong PDF có độ nét cao.

### Aspose.Slides có hỗ trợ các tiêu chuẩn PDF/A không?

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các tiêu chuẩn khác nhau, bao gồm PDF/A1a, PDF/A1b và PDF/UA, giúp tài liệu của bạn đáp ứng các yêu cầu về truy cập và lưu trữ lâu dài.

## **Tài nguyên bổ sung**

- [Aspose.Slides for .NET Documentation](/slides/vi/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/vi/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/vi/conversion)