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
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF có chất lượng cao, có thể tìm kiếm trong .NET bằng Aspose.Slides, với các ví dụ mã C# nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong C# mang lại một số lợi thế, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo toàn bố cục cùng định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức [Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/). Lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) cung cấp phương thức [Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) thường được sử dụng để chuyển đổi bản trình chiếu sang PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides cho .NET chèn thông tin API và số phiên bản của nó vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản trình chiếu sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể chỉ định cho Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.

{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể trong một bản trình chiếu sang PDF

Aspose.Slides xuất bản trình chiếu sang PDF, đảm bảo các tệp PDF kết quả gần giống với bản gốc. Các yếu tố và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Đầu và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi chuẩn từ PowerPoint sang PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản trình chiếu đã cho sang PDF bằng các thiết lập tối ưu ở mức chất lượng cao nhất.

Mã C# dưới đây cho thấy cách chuyển đổi một bản trình chiếu (PPT, PPTX, ODP, v.v.) sang PDF:

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
using var presentation = new Presentation("PowerPoint.ppt");

// Lưu bản trình chiếu dưới dạng PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose cung cấp một trình chuyển đổi [**PowerPoint sang PDF**](https://products.aspose.app/slides/vi/conversion/ppt-to-pdf) trực tuyến miễn phí, cho phép bạn xem quá trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể chạy thử với trình chuyển đổi này để thực hiện trực tiếp quy trình đã mô tả ở đây.

{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính dưới lớp [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/)—cho phép bạn tùy biến PDF kết quả, khóa PDF bằng mật khẩu, hoặc chỉ định cách tiến trình chuyển đổi được thực hiện.

### **Chuyển đổi PowerPoint sang PDF với Các tùy chọn tùy chỉnh**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định cài đặt chất lượng ưa thích cho hình ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và nhiều hơn nữa.

Ví dụ mã dưới đây minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với một số tùy chọn tùy chỉnh.

```c#
// Khởi tạo lớp PdfOptions.
var pdfOptions = new PdfOptions
{
    // Đặt chất lượng cho ảnh JPG.
    JpegQuality = 90,

    // Đặt DPI cho ảnh.
    SufficientResolution = 300,

    // Đặt hành vi cho metafiles.
    SaveMetafilesAsPng = true,

    // Đặt mức nén văn bản cho nội dung văn bản.
    TextCompression = PdfTextCompression.Flate,

    // Xác định chế độ tuân thủ PDF.
    Compliance = PdfCompliance.Pdf15
};

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// Lưu bản trình chiếu dưới dạng tài liệu PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Chuyển đổi PowerPoint sang PDF với Các slide ẩn**

Nếu một bản trình chiếu chứa các slide ẩn, bạn có thể dùng thuộc tính [ShowHiddenSlides](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/showhiddenslides/) từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/) để bao gồm các slide ẩn làm các trang trong PDF kết quả.

Mã C# dưới đây cho thấy cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với các slide ẩn được bao gồm:

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// Khởi tạo lớp PdfOptions.
var pdfOptions = new PdfOptions();

// Thêm các slide ẩn.
pdfOptions.ShowHiddenSlides = true;

// Lưu bản trình chiếu dưới dạng PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Chuyển đổi PowerPoint sang PDF có Bảo vệ Mật khẩu**

Mã C# này minh họa cách chuyển đổi một bản trình chiếu PowerPoint thành PDF có bảo vệ mật khẩu bằng các tham số bảo mật từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/):

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// Khởi tạo lớp PdfOptions.
var pdfOptions = new PdfOptions();

// Đặt mật khẩu PDF và quyền truy cập.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Lưu bản trình chiếu dưới dạng PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Phát hiện Thay thế Phông chữ**

Aspose.Slides cung cấp thuộc tính [WarningCallback](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveoptions/warningcallback/) dưới lớp [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/), cho phép bạn phát hiện các thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

Mã C# này cho thấy cách phát hiện các thay thế phông chữ:

```c#
public static void Main()
{
    // Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
    using var presentation = new Presentation("sample.pptx");

    // Đặt callback cảnh báo trong tùy chọn PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Lưu bản trình chiếu dưới dạng PDF.
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

{{%  alert color="primary"  %}} 

Để biết thêm thông tin về việc nhận các callback cho việc thay thế phông chữ trong quá trình render, xem [Getting Warning Callbacks for Fonts Substitution](/slides/vi/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Để biết thêm thông tin về việc thay thế phông chữ, xem bài viết [Font Substitution](/slides/vi/net/font-substitution/).

{{% /alert %}} 

## **Chuyển đổi Các slide Được Chọn từ PowerPoint sang PDF**

Mã C# này minh họa cách chỉ chuyển đổi các slide cụ thể từ một bản trình chiếu PowerPoint sang PDF:

```c#
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// Đặt mảng các số slide.
int[] slides = { 1, 3 };

// Lưu bản trình chiếu dưới dạng PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Chuyển đổi PowerPoint sang PDF với Kích thước Slide Tùy chỉnh**

Mã C# này minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với kích thước slide được chỉ định:

```c#
var slideWidth = 612;
var slideHeight = 792;

// Tải một bản trình chiếu PowerPoint.
using var presentation = new Presentation("SelectedSlides.pptx");

// Tạo một bản trình chiếu mới với kích thước slide đã điều chỉnh.
using var resizedPresentation = new Presentation();

// Đặt kích thước slide tùy chỉnh.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Sao chép slide đầu tiên từ bản trình chiếu gốc.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Lưu bản trình chiếu đã thay đổi kích thước dưới dạng PDF có ghi chú.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **Chuyển đổi PowerPoint sang PDF trong Chế độ Xem Ghi chú Slide**

Mã C# này minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF có bao gồm ghi chú:

```c#
// Tải một bản trình chiếu PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Configure the PDF options with Notes Layout.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Save the presentation to a PDF with notes.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Tiêu chuẩn Truy cập và Tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng một quy trình chuyển đổi tuân thủ theo [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất một tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Mã C# dưới đây minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều tệp PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

```c#
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

Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi các tệp PDF sang các định dạng phổ biến. Bạn có thể thực hiện các chuyển đổi [PDF sang HTML](https://products.aspose.com/slides/vi/net/conversion/pdf-to-html/), [PDF sang hình ảnh](https://products.aspose.com/slides/vi/net/conversion/pdf-to-image/), [PDF sang JPG](https://products.aspose.com/slides/vi/net/conversion/pdf-to-jpg/), và [PDF sang PNG](https://products.aspose.com/slides/vi/net/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt—[PDF sang SVG](https://products.aspose.com/slides/vi/net/conversion/pdf-to-svg/), [PDF sang TIFF](https://products.aspose.com/slides/vi/net/conversion/pdf-to-tiff/), và [PDF sang XML](https://products.aspose.com/slides/vi/net/conversion/pdf-to-xml/)—cũng được hỗ trợ.

{{% /alert %}}

> **Lưu ý:** Khi xuất ra PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức dưới dạng một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại dưới dạng nội dung riêng và có thể được đánh dấu là artefact; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Có thể chuyển đổi nhiều tệp PowerPoint sang PDF đồng loạt không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể duyệt qua các tệp của mình và áp dụng quy trình chuyển đổi bằng cách lập trình.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Chắc chắn. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm thế nào để bao gồm các slide ẩn trong PDF?**

Đặt thuộc tính `ShowHiddenSlides` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/) thành `true` để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng cách đặt các thuộc tính như `JpegQuality` và `SufficientResolution` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pdfoptions/) để đảm bảo hình ảnh trong PDF có độ phân giải cao.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các tiêu chuẩn khác nhau, bao gồm PDF/A1a, PDF/A1b và PDF/UA, nhằm đáp ứng yêu cầu truy cập và lưu trữ lâu dài của tài liệu.

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides cho .NET](/slides/vi/net/)
- [Tham chiếu API Aspose.Slides cho .NET](https://reference.aspose.com/slides/vi/net/)
- [Trình chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/vi/conversion)