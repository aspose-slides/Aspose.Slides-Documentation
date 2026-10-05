---
title: Chuyển đổi PPT và PPTX sang PDF trong PHP [Bao gồm các tính năng nâng cao]
linktitle: PowerPoint sang PDF
type: docs
weight: 40
url: /vi/php-java/convert-powerpoint-to-pdf/
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
- PHP
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có khả năng tìm kiếm trong PHP bằng Aspose.Slides, kèm theo các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Việc chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong PHP mang lại nhiều lợi thế, bao gồm khả năng tương thích trên các thiết bị khác nhau và duy trì bố cục cũng như định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện việc thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Bạn có thể sử dụng Aspose.Slides để chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save). Lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) cung cấp phương thức [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) thường được sử dụng để chuyển đổi bản trình chiếu sang PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java chèn thông tin API và số phiên bản của nó vào các tài liệu đầu ra. Ví dụ, khi chuyển đổi bản trình chiếu sang PDF, Aspose.Slides điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể trong bản trình chiếu sang PDF

Aspose.Slides xuất các bản trình chiếu sang PDF, đảm bảo các PDF kết quả khớp chặt chẽ với bản trình chiếu gốc. Các yếu tố và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Liên kết siêu văn bản
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi tiêu chuẩn từ PowerPoint sang PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides sẽ cố gắng chuyển đổi bản trình chiếu được cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng tối đa.

Ví dụ dưới đây tải một bản trình chiếu và lưu tất cả các slide hiển thị sang PDF bằng các cài đặt xuất mặc định.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose cung cấp một công cụ chuyển đổi PowerPoint sang PDF trực tuyến miễn phí [**Trình chuyển đổi PowerPoint sang PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) cho thấy quá trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể thực hiện thử nghiệm với công cụ này để áp dụng thực tế quy trình được mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—cho phép bạn tùy biến PDF đầu ra, khóa PDF bằng mật khẩu, hoặc chỉ định cách thực hiện quá trình chuyển đổi.

### **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn Tùy Chỉnh**

Bằng cách sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể định nghĩa cài đặt chất lượng mong muốn cho hình ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và nhiều hơn nữa.

Ví dụ dưới đây xuất một bản trình chiếu sang PDF 1.5 với chất lượng JPEG đặt thành 90, độ phân giải hình ảnh đặt thành 300 DPI, metafile được lưu dưới dạng PNG, và nén văn bản Flate.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Bảo tồn các tệp OLE nhúng dưới dạng tệp đính kèm PDF**

Nếu bản trình chiếu chứa một sổ làm việc Excel được nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu của sổ làm việc cũng như xem các slide. Gọi [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) với `true` để bảo tồn các tệp OLE nhúng dưới dạng tệp đính kèm trong PDF đầu ra.

Giá trị mặc định là `false`: hình ảnh hoặc biểu tượng xem trước của đối tượng OLE được hiển thị trên trang PDF, nhưng tệp nhúng của nó không được bao gồm dưới dạng tệp đính kèm. Đặt tùy chọn thành `true` sẽ bao gồm thêm dữ liệu tệp. Bản xem trước vẫn là một biểu hiện hình ảnh; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE sẽ không trở thành một worksheet Excel tương tác trên trang PDF.

Ví dụ dưới đây tải một bản trình chiếu đã chứa sổ làm việc Excel nhúng và xuất nó sang PDF với sổ làm việc được đính kèm.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Để kiểm tra kết quả:

1. Mở PDF đã xuất trong một trình xem hỗ trợ tệp đính kèm, chẳng hạn Adobe Acrobat Reader.
2. Mở bảng **Attachments** của trình xem và tìm sổ làm việc nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Bản xem trước trên trang PDF là riêng biệt so với tệp đính kèm.

{{% alert color="info" title="Note" %}}
Các tiêu chuẩn PDF/A áp đặt các hạn chế đối với tệp đính kèm: PDF/A-1 cấm các tệp được nhúng, PDF/A-2 chỉ cho phép các tệp đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm sổ làm việc Excel. Đây là yêu cầu của các tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không minh họa việc xuất PDF/A.
{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với Các Slide Ẩn**

Nếu bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) từ lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn như các trang trong PDF đầu ra.

Ví dụ dưới đây xuất một bản trình chiếu sang PDF, bao gồm cả các slide ẩn.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Chuyển đổi PowerPoint sang PDF có Bảo Vệ Bằng Mật Khẩu**

Ví dụ dưới đây xuất một bản trình chiếu sang PDF yêu cầu mật khẩu `password` để mở. Các quyền truy cập cho phép in, bao gồm in chất lượng cao.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Phát Hiện Việc Thay Thế Phông Chữ**

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) trong lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), cho phép bạn phát hiện việc thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

Ví dụ dưới đây xuất một bản trình chiếu sang PDF và in các cảnh báo thay thế phông chữ ra console. Cảnh báo chỉ được in khi một phông chữ không khả dụng bị thay thế trong quá trình xuất.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Để biết thêm thông tin về việc thay thế phông chữ, xem bài viết [Thay Thế Phông Chữ](/slides/vi/php-java/font-substitution/).
{{% /alert %}} 

## **Chuyển Đổi Các Slide Được Chọn Từ PowerPoint sang PDF**

Ví dụ dưới đây xuất các slide 1 và 3 từ một bản trình chiếu sang PDF. Các số slide trong mảng này bắt đầu từ 1, và bản trình chiếu đầu vào phải chứa ít nhất ba slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Chuyển Đổi PowerPoint sang PDF với Kích Thước Slide Tùy Chỉnh**

Ví dụ dưới đây sao chép slide đầu tiên từ một bản trình chiếu vào một bản trình chiếu mới với kích thước slide 612 × 792 điểm (8.5 × 11 inch). Nó thu phóng nội dung slide để vừa và xuất slide đơn lẻ sang PDF.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // Xóa slide trống mà bản trình chiếu mới được tạo ra.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Chuyển Đổi PowerPoint sang PDF trong Chế Độ Ghi Chú Slide**

Ví dụ dưới đây xuất một bản trình chiếu sang PDF, đặt ghi chú người nói của mỗi slide dưới slide tương ứng. Sử dụng một bản trình chiếu có chứa ghi chú người nói để xem kết quả.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Tiêu Chuẩn Truy Cập và Tuân Thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ các [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Mã sau đây minh họa một quy trình chuyển đổi PowerPoint sang PDF tạo nhiều PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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

{{% alert color="info" title="Note" %}}
Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi tệp PDF sang các định dạng phổ biến. Bạn có thể thực hiện các chuyển đổi [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) và [PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt khác—[PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/) và [PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—cũng được hỗ trợ.
{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại như nội dung riêng và có thể được đánh dấu là artefact; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **FAQ**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF đồng thời không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể duyệt qua các tệp của mình và áp dụng quy trình chuyển đổi bằng cách lập trình.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) để đặt mật khẩu và xác định các quyền truy cập trong quá trình chuyển đổi.

**Làm thế nào để bao gồm các slide ẩn trong PDF?**

Gọi [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) với `true` trong lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF đầu ra.

**Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng cách sử dụng các phương thức như [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setJpegQuality) và [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setSufficientResolution) trong lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) để đảm bảo hình ảnh chất lượng cao trong PDF của bạn.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ [various standards](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng các yêu cầu về truy cập và lưu trữ.

## **Tài Nguyên Bổ Sung**

- [Tài liệu Aspose.Slides cho PHP qua Java](/slides/vi/php-java/)
- [Tham chiếu API Aspose.Slides cho PHP qua Java](https://reference.aspose.com/slides/php-java/)
- [Công cụ Chuyển Đổi Trực Tuyến Miễn Phí của Aspose](https://products.aspose.app/slides/conversion)