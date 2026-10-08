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
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm trong PHP bằng Aspose.Slides, kèm ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Việc chuyển đổi bản trình chiếu PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong PHP mang lại một số lợi ích, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo vệ bố cục cũng như định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) cung cấp phương thức [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) thường được sử dụng để chuyển đổi bản trình chiếu sang PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java chèn thông tin API và số phiên bản vào tài liệu đầu ra. Ví dụ, khi chuyển đổi bản trình chiếu sang PDF, Aspose.Slides điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể chỉ đạo Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.
{{% /alert %}}

Cho phép bạn chuyển đổi:
* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể từ một bản trình chiếu sang PDF

Aspose.Slides xuất các bản trình chiếu sang PDF, đảm bảo các PDF kết quả khớp chặt chẽ với các bản trình chiếu gốc. Các yếu tố và thuộc tính được render chính xác trong quá trình chuyển đổi, bao gồm:
* Hình ảnh
* Hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi PowerPoint sang PDF tiêu chuẩn sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides sẽ cố gắng chuyển đổi bản trình chiếu đã cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng tối đa.

Ví dụ sau tải một bản trình chiếu và lưu tất cả các slide hiển thị sang PDF bằng cài đặt xuất mặc định.

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
Aspose cung cấp một công cụ chuyển đổi PowerPoint sang PDF trực tuyến miễn phí [**Trình chuyển đổi PowerPoint sang PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) minh họa quy trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể thực hiện thử nghiệm với công cụ này để triển khai thực tế quy trình được mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính dưới lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—cho phép bạn tùy chỉnh PDF đầu ra, khóa PDF bằng mật khẩu, hoặc chỉ định cách tiến trình chuyển đổi sẽ diễn ra.

### **Chuyển đổi PowerPoint sang PDF với các tùy chọn tùy chỉnh**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định cài đặt chất lượng ưa thích cho hình ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và hơn thế nữa.

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

Nếu một bản trình chiếu chứa sổ làm việc Excel nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu của sổ làm việc cũng như xem các slide. Gọi [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) với `true` để bảo tồn các tệp OLE nhúng dưới dạng tệp đính kèm trong PDF kết quả.

Giá trị mặc định là `false`: hình ảnh xem trước hoặc biểu tượng của đối tượng OLE được hiển thị trên trang PDF, nhưng tệp nhúng của nó không được bao gồm dưới dạng tệp đính kèm. Đặt tùy chọn thành `true` sẽ bổ sung dữ liệu tệp. Bản xem trước vẫn là đại diện trực quan; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE không trở thành bảng tính Excel tương tác trên trang PDF.

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
1. Mở PDF đã xuất trong trình xem hỗ trợ tệp đính kèm, chẳng hạn Adobe Acrobat Reader.
2. Mở bảng **Attachments** của trình xem và tìm sổ làm việc nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Bản xem trước trên trang PDF là riêng biệt so với tệp đính kèm.

{{% alert color="info" title="Note" %}}
Tiêu chuẩn PDF/A áp đặt các hạn chế đối với tệp đính kèm: PDF/A-1 cấm tệp nhúng, PDF/A-2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm sổ làm việc Excel. Đây là yêu cầu của tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không minh họa xuất PDF/A.
{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với các slide ẩn**

Nếu một bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) từ lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn dưới dạng trang trong PDF kết quả.

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

### **Chuyển đổi PowerPoint sang PDF có bảo vệ bằng mật khẩu**

Ví dụ sau xuất một bản trình chiếu sang PDF yêu cầu mật khẩu `password` để mở. Các quyền truy cập cho phép in, bao gồm in chất lượng cao.

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

### **Phát hiện thay thế phông chữ**

Aspose.Slides cung cấp phương pháp [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) dưới lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) cho phép bạn phát hiện việc thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

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
Để biết thêm thông tin về việc thay thế phông chữ, xem bài viết [Thay thế phông chữ](/slides/vi/php-java/font-substitution/).
{{% /alert %}}

### **Xử lý phông chữ không có kiểu chữ đậm riêng**

Một bản trình chiếu có thể áp dụng định dạng in đậm cho văn bản ngay cả khi phông chữ không có kiểu chữ đậm riêng. Văn bản vẫn có thể hiển thị đậm thông qua việc tạo đậm tổng hợp, làm dày các glyph thông thường. Khi văn bản đó trông quá nặng hoặc khác so với mong muốn trong PDF, hãy thử gọi [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) với `true`. Tùy chọn này render văn bản bị ảnh hưởng dưới dạng bitmap trong quá trình xuất PDF và có thể cải thiện diện mạo của nó cho một số phông chữ nhất định. Giá trị mặc định là `false`.

Bản trình chiếu mẫu chứa hai hộp văn bản: một với văn bản thường và một với định dạng in đậm được áp dụng cho cùng một phông chữ, phông chữ này không có kiểu chữ đậm riêng. Ví dụ sau tải bản trình chiếu, bật rasterization cho các kiểu phông chữ không được hỗ trợ, và xuất nó sang PDF:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Các bản xem trước sau đây hiển thị kết quả khi tắt và bật tùy chọn. Trong ví dụ này, văn bản in đậm có nét dày hơn khi tùy chọn bị tắt. Khi bật, nét của nó nhẹ hơn; văn bản thường không thay đổi. So sánh kết quả trước khi chọn cài đặt cho bản trình chiếu của bạn.

| Tùy chọn tắt (`false`, mặc định) | Tùy chọn bật (`true`) |
|---|---|
| ![PDF với raster hóa kiểu phông chữ không hỗ trợ bị tắt](unsupported-bold-disabled.png) | ![PDF với raster hóa kiểu phông chữ không hỗ trợ được bật](unsupported-bold-enabled.png) |

Trong ví dụ này, bật tùy chọn chỉ biến văn bản in đậm thành bitmap: nó không thể được chọn, sao chép hoặc tìm kiếm dưới dạng văn bản nếu không dùng OCR, và các cạnh của nó trông mềm hơn ở mức phóng 800%. Văn bản thường vẫn có thể tìm kiếm. Khi tắt tùy chọn, cả hai chuỗi vẫn là văn bản.

Tùy chọn này raster hóa văn bản được định dạng in đậm khi phông chữ không có kiểu chữ đậm riêng. [Thay thế phông chữ](/slides/vi/php-java/font-substitution/) thay vào đó sẽ chọn một phông chữ khác khi phông chữ gốc không khả dụng.

## **Chuyển đổi các slide được chọn từ PowerPoint sang PDF**

Ví dụ sau xuất các slide 1 và 3 từ một bản trình chiếu sang PDF. Các số slide trong mảng này bắt đầu từ 1, và bản trình chiếu đầu vào phải chứa ít nhất ba slide.

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

## **Chuyển đổi PowerPoint sang PDF với kích thước slide tùy chỉnh**

Ví dụ sau sao chép slide đầu tiên từ một bản trình chiếu vào một bản trình chiếu mới với kích thước slide là 612 × 792 điểm (8,5 × 11 inch). Nó thu phóng nội dung slide để vừa và xuất slide duy nhất sang PDF.

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

    // Xóa slide trống mà bản trình chiếu mới được tạo.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Chuyển đổi PowerPoint sang PDF ở chế độ xem ghi chú slide**

Ví dụ sau xuất một bản trình chiếu sang PDF, đặt ghi chú người thuyết trình của mỗi slide dưới slide. Sử dụng một bản trình chiếu có ghi chú người thuyết trình để xem kết quả.

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

## **Tiêu chuẩn truy cập và tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

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
Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi tệp PDF sang các định dạng tệp phổ biến. Bạn có thể thực hiện chuyển đổi [PDF sang HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF sang image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF sang JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), và [PDF sang PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) . Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt—[PDF sang SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF sang TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), và [PDF sang XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—cũng được hỗ trợ.
{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại như nội dung riêng và có thể được đánh dấu là nhiễu; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF hàng loạt không?**

Đúng, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể duyệt qua các tệp của mình và áp dụng quy trình chuyển đổi bằng cách lập trình.

**Có thể bảo vệ PDF được chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) để đặt mật khẩu và xác định các quyền truy cập trong quá trình chuyển đổi.

**Làm sao để bao gồm các slide ẩn trong PDF?**

Gọi [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) với `true` trong lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?**

Đúng, bạn có thể kiểm soát chất lượng hình ảnh bằng cách sử dụng các phương thức như [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) và [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) trong lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) để đảm bảo hình ảnh chất lượng cao trong PDF của bạn.

**Aspose.Slides có hỗ trợ tiêu chuẩn tuân thủ PDF/A không?**

Đúng, Aspose.Slides cho phép bạn xuất PDF tuân thủ [các tiêu chuẩn khác nhau](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng yêu cầu truy cập và lưu trữ.

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides cho PHP qua Java](/slides/vi/php-java/)
- [Tham chiếu API Aspose.Slides cho PHP qua Java](https://reference.aspose.com/slides/php-java/)
- [Công cụ chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/conversion)