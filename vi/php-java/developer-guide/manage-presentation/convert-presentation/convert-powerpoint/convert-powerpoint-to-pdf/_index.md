---
title: "Chuyển đổi PPT và PPTX sang PDF trong PHP [Bao gồm các tính năng nâng cao]"
linktitle: "PowerPoint sang PDF"
type: docs
weight: 40
url: /vi/php-java/convert-powerpoint-to-pdf/
keywords:
- "chuyển đổi PowerPoint"
- "chuyển đổi bản trình bày"
- "PowerPoint sang PDF"
- "bản trình bày sang PDF"
- "PPT sang PDF"
- "chuyển đổi PPT sang PDF"
- "PPTX sang PDF"
- "chuyển đổi PPTX sang PDF"
- "lưu PowerPoint dưới dạng PDF"
- "lưu PPT dưới dạng PDF"
- "lưu PPTX dưới dạng PDF"
- "xuất PPT sang PDF"
- "xuất PPTX sang PDF"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- "PHP"
- "Aspose.Slides"
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có khả năng tìm kiếm trong PHP bằng Aspose.Slides, kèm ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản trình bày PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong PHP mang lại nhiều ưu điểm, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo toàn bố cục cũng như định dạng của bản trình bày. Hướng dẫn này trình bày cách chuyển đổi bản trình bày sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo mật PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình bày ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình bày sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) và sau đó lưu bản trình bày dưới dạng PDF bằng phương thức `save`. Lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) cung cấp phương thức `save` thường được sử dụng để chuyển đổi bản trình bày sang PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for PHP via Java chèn thông tin API và số phiên bản vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản trình bày sang PDF, Aspose.Slides điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc xóa thông tin này khỏi tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình bày sang PDF
* Các slide cụ thể từ một bản trình bày sang PDF

Aspose.Slides xuất bản trình bày sang PDF, đảm bảo các tệp PDF tạo ra gần như giống nguyên bản. Các yếu tố và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Liên kết hyper
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi PowerPoint sang PDF tiêu chuẩn sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides sẽ cố gắng chuyển đổi bản trình bày đã cung cấp sang PDF bằng các thiết lập tối ưu ở mức chất lượng cao nhất.

Mã dưới đây cho bạn thấy cách chuyển đổi một bản trình bày (PPT, PPTX, ODP, v.v.) sang PDF:

```php
# Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Lưu bản trình bày dưới dạng PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 
Aspose cung cấp một trình chuyển đổi PowerPoint sang PDF trực tuyến miễn phí [**PowerPoint to PDF converter**](https://products.aspose.app/slides/vi/conversion/ppt-to-pdf) để minh họa quá trình chuyển đổi bản trình bày sang PDF. Bạn có thể thử nghiệm trình chuyển đổi này để thực hiện quy trình đã mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PdfOptions)—giúp bạn tùy biến PDF kết quả, khóa PDF bằng mật khẩu, hoặc chỉ định cách quá trình chuyển đổi sẽ diễn ra.

### **Chuyển đổi PowerPoint sang PDF với các tùy chọn tùy chỉnh**

Bằng cách sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định cài đặt chất lượng mong muốn cho ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho ảnh, và nhiều hơn nữa.

Mã ví dụ dưới đây minh họa cách chuyển đổi một bản trình bày PowerPoint sang PDF với một số tùy chọn tùy chỉnh.

```php
# Khởi tạo lớp PdfOptions.
$pdfOptions = new PdfOptions();

# Đặt chất lượng cho hình ảnh JPG.
$pdfOptions->setJpegQuality(90);

# Đặt DPI cho hình ảnh.
$pdfOptions->setSufficientResolution(300);

# Đặt hành vi cho các metafile.
$pdfOptions->setSaveMetafilesAsPng(true);

# Đặt mức nén văn bản cho nội dung văn bản.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# Xác định chế độ tuân thủ PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Lưu bản trình bày dưới dạng tài liệu PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Chuyển đổi PowerPoint sang PDF với các slide ẩn**

Nếu một bản trình bày chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PdfOptions) để bao gồm các slide ẩn dưới dạng các trang trong PDF kết quả.

Mã dưới đây cho thấy cách chuyển đổi một bản trình bày PowerPoint sang PDF với các slide ẩn được bao gồm:

```php
# Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Khởi tạo lớp PdfOptions.
    $pdfOptions = new PdfOptions();

    # Thêm các slide ẩn.
    $pdfOptions->setShowHiddenSlides(true);

    # Lưu bản trình bày dưới dạng PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Chuyển đổi PowerPoint sang PDF có bảo mật mật khẩu**

Mã này minh họa cách chuyển đổi một bản trình bày PowerPoint thành PDF có bảo mật bằng mật khẩu bằng cách sử dụng các tham số bảo vệ từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pdfoptions/):

```php
# Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Khởi tạo lớp PdfOptions.
    $pdfOptions = new PdfOptions();

    # Đặt mật khẩu PDF và các quyền truy cập.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Lưu bản trình bày dưới dạng PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Phát hiện Thay thế Phông chữ**

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveoptions/#setWarningCallback) trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pdfoptions/), cho phép bạn phát hiện các thay thế phông chữ trong quá trình chuyển đổi bản trình bày sang PDF.

Mã này cho thấy cách phát hiện các thay thế phông chữ:

```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// Đặt callback cảnh báo trong tùy chọn PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
$presentation = new Presentation("sample.pptx");
try {
    // Lưu bản trình bày dưới dạng PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 
Để biết thêm thông tin về việc thay thế phông chữ, xem bài viết [Font Substitution](/slides/vi/php-java/font-substitution/).
{{% /alert %}} 

## **Chuyển đổi các slide đã chọn trong PowerPoint sang PDF**

Mã này minh họa cách chỉ chuyển đổi các slide cụ thể từ một bản trình bày PowerPoint sang PDF:

```php
# Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Đặt mảng các số slide.
    $slides = array(1, 3);

    # Lưu bản trình bày dưới dạng PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Chuyển đổi PowerPoint sang PDF với kích thước slide tùy chỉnh**

Mã này minh họa cách chuyển đổi một bản trình bày PowerPoint sang PDF với kích thước slide đã chỉ định:

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");

# Tạo một bản trình bày mới với kích thước slide đã điều chỉnh.
$resizedPresentation = new Presentation();

try {
    # Đặt kích thước slide tùy chỉnh.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Nhân bản slide đầu tiên từ bản trình bày gốc.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Lưu bản trình bày đã thay đổi kích thước sang PDF có ghi chú.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Chuyển đổi PowerPoint sang PDF ở chế độ xem ghi chú slide**

Mã này minh họa cách chuyển đổi một bản trình bày PowerPoint sang PDF có bao gồm ghi chú:

```php
# Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Cấu hình tùy chọn PDF với bố cục ghi chú.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Lưu bản trình bày sang PDF có ghi chú.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Tiêu chuẩn truy cập và tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Mã này minh họa một quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều tệp PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi tệp PDF sang các định dạng phổ biến. Bạn có thể thực hiện chuyển đổi [PDF to HTML](https://products.aspose.com/slides/vi/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/vi/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/vi/php-java/conversion/pdf-to-jpg/), và [PDF to PNG](https://products.aspose.com/slides/vi/php-java/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt khác—[PDF to SVG](https://products.aspose.com/slides/vi/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/vi/php-java/conversion/pdf-to-tiff/), và [PDF to XML](https://products.aspose.com/slides/vi/php-java/conversion/pdf-to-xml/)—cũng được hỗ trợ.
{{% /alert %}}

> **Lưu ý:** Khi xuất ra PDF/UA, Aspose.Slides coi các đồ họa phức tạp như SmartArt, biểu đồ và công thức là một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại như nội dung riêng và có thể được đánh dấu là artefact; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Có thể chuyển đổi nhiều tệp PowerPoint sang PDF đồng thời không?**

Đúng vậy, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp của mình và áp dụng quy trình chuyển đổi một cách lập trình.

**Có thể bảo mật bằng mật khẩu cho PDF đã chuyển đổi không?**

Chắc chắn. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm sao để bao gồm các slide ẩn trong PDF?**

Sử dụng phương thức `setShowHiddenSlides` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?**

Đúng vậy, bạn có thể kiểm soát chất lượng hình ảnh bằng các phương pháp như `setJpegQuality` và `setSufficientResolution` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pdfoptions/) để đảm bảo hình ảnh chất lượng cao trong PDF của bạn.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Đúng vậy, Aspose.Slides cho phép bạn xuất PDF tuân thủ các tiêu chuẩn khác nhau, bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng yêu cầu truy cập và lưu trữ.

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides cho PHP qua Java](/slides/vi/php-java/)
- [Tham khảo API Aspose.Slides cho PHP qua Java](https://reference.aspose.com/slides/vi/php-java/)
- [Trình chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/vi/conversion)