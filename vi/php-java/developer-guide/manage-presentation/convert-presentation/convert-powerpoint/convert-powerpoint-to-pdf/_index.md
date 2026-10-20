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
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm trong PHP bằng Aspose.Slides, kèm theo các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong PHP mang lại nhiều lợi ích, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo tồn bố cục cũng như định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) cung cấp phương thức [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) thường được sử dụng để chuyển đổi một bản trình chiếu sang PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java chèn thông tin API và số phiên bản của nó vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản trình chiếu sang PDF, Aspose.Slides điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Note** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc xóa thông tin này khỏi tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể từ một bản trình chiếu sang PDF

Aspose.Slides xuất bản trình chiếu sang PDF, đảm bảo các PDF tạo ra gần giống với bản trình chiếu gốc. Các yếu tố và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Đầu trang và chân trang
* Dấu chấm đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi tiêu chuẩn từ PowerPoint sang PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản trình chiếu đã cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng tối đa.

Ví dụ sau tải một bản trình chiếu và lưu tất cả các slide hiển thị sang PDF bằng các cài đặt xuất mặc định.

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
Aspose cung cấp một trình chuyển đổi trực tuyến miễn phí [**Trình chuyển đổi PowerPoint sang PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) để minh họa quy trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể chạy thử với trình chuyển đổi này để thực hiện thực tế quy trình được mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính dưới lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—cho phép bạn tùy chỉnh PDF tạo ra, khóa PDF bằng mật khẩu, hoặc chỉ định cách tiến trình chuyển đổi sẽ diễn ra.

### **Chuyển đổi PowerPoint sang PDF với các tùy chọn tùy chỉnh**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể định nghĩa thiết lập chất lượng ưa thích cho hình raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và hơn thế nữa.

Ví dụ sau xuất một bản trình chiếu sang PDF 1.5 với chất lượng JPEG được đặt là 90, độ phân giải hình ảnh là 300 DPI, metafile được lưu dưới dạng PNG, và nén văn bản Flate.

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

### **Tự động chọn nén hình ảnh**

Khi một bản trình chiếu chứa nhiều ảnh chụp hoặc ảnh chụp màn hình, việc giảm kích thước PDF xuất ra có thể giúp dễ dàng gửi email hoặc tải về hơn. Gọi [PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) với `true` để tự động chọn thuật toán nén phù hợp nhất cho mỗi hình ảnh trong quá trình xuất PDF.

Ví dụ sau tải một bản trình chiếu hiện có, bật chế độ tự động chọn nén hình ảnh, và lưu nó dưới dạng tài liệu PDF. Tất cả các cài đặt xuất PDF khác vẫn giữ nguyên giá trị mặc định.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Tùy chọn này chọn một thuật toán nén cho mỗi hình ảnh. Giảm giá trị truyền vào [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) sẽ làm giảm chất lượng ảnh JPEG, trong khi giảm giá trị truyền vào [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) cho phép hình ảnh được giảm mẫu xuống mức phân giải thấp hơn, có thể làm giảm chi tiết. Bật chế độ tự động chọn nén không tự làm giảm bất kỳ cài đặt nào trong số này.

Việc chọn thuật toán nén hình ảnh đòi hỏi thời gian xử lý và bộ nhớ bổ sung. Tỷ lệ giảm kích thước phụ thuộc vào hình ảnh và cài đặt xuất của bản trình chiếu; không có mức giảm cố định cho mọi bản trình chiếu.

### **Giữ lại các tệp OLE nhúng dưới dạng tệp đính kèm PDF**

Nếu một bản trình chiếu chứa một workbook Excel được nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu của workbook đó cũng như xem các slide. Gọi [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) với `true` để giữ lại các tệp OLE nhúng dưới dạng tệp đính kèm trong PDF tạo ra.

Giá trị mặc định là `false`: hình ảnh hoặc biểu tượng xem trước của đối tượng OLE được hiển thị trên trang PDF, nhưng tệp được nhúng không được bao gồm dưới dạng tệp đính kèm. Đặt tùy chọn thành `true` sẽ bổ sung cả dữ liệu tệp. Xem trước vẫn là một biểu diễn trực quan; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE sẽ không trở thành một worksheet Excel tương tác trên trang PDF.

Ví dụ sau tải một bản trình chiếu đã chứa một workbook Excel được nhúng và xuất nó sang PDF với workbook được đính kèm.

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
2. Mở bảng **Attachments** của trình xem và tìm workbook được nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Bản xem trước trên trang PDF tách biệt với tệp đính kèm.

{{% alert color="info" title="Note" %}}
Các tiêu chuẩn PDF/A đưa ra các hạn chế về tệp đính kèm: PDF/A-1 cấm tệp nhúng, PDF/A-2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm workbook Excel. Đây là yêu cầu của tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không minh họa xuất PDF/A.
{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với các slide ẩn**

Nếu một bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) từ lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn dưới dạng trang trong PDF tạo ra.

Ví dụ sau xuất một bản trình chiếu sang PDF, bao gồm cả các slide ẩn.

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

### **Chuyển đổi PowerPoint sang PDF có bảo mật bằng mật khẩu**

Ví dụ sau xuất một bản trình chiếu sang PDF yêu cầu mật khẩu `password` để mở. Quyền truy cập cho phép in, bao gồm in chất lượng cao.

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

### **Phát hiện Thay thế Phông chữ**

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) dưới lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), cho phép bạn phát hiện việc thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

Ví dụ sau xuất một bản trình chiếu sang PDF và in cảnh báo thay thế phông chữ lên console. Cảnh báo chỉ được in khi một phông chữ không khả dụng được thay thế trong quá trình xuất.

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
Đối với thông tin thêm về thay thế phông chữ, xem bài viết [Thay thế Phông chữ](/slides/vi/php-java/font-substitution/).
{{% /alert %}}

### **Xử lý Phông chữ không có kiểu chữ đậm riêng**

Một bản trình chiếu có thể áp dụng định dạng đậm cho văn bản ngay cả khi phông chữ của nó không có kiểu chữ đậm riêng. Văn bản vẫn có thể hiển thị đậm qua việc tạo đậm tổng hợp, làm tăng độ dày của glyph thường. Khi văn bản đó trông quá nặng hoặc không giống như mong muốn trong PDF, hãy thử gọi [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) với `true`. Tùy chọn này sẽ vẽ văn bản bị ảnh hưởng dưới dạng bitmap trong quá trình xuất PDF và có thể cải thiện hiển thị của một số phông chữ. Giá trị mặc định là `false`.

Bản trình chiếu mẫu chứa hai hộp văn bản: một hộp có văn bản thường và một hộp có định dạng đậm được áp dụng cho cùng một phông chữ, không có kiểu chữ đậm riêng. Ví dụ sau tải bản trình chiếu, bật rasterization cho các kiểu phông chữ không hỗ trợ, và xuất nó sang PDF:

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

Các bản xem trước sau đây cho thấy kết quả khi tắt và khi bật tùy chọn. Trong ví dụ này, văn bản đậm có nét dày hơn khi tắt tùy chọn. Khi bật, nét của nó nhẹ hơn; văn bản thường không thay đổi. So sánh kết quả trước khi chọn cài đặt cho bản trình chiếu của bạn.

| Tùy chọn tắt (`false`, mặc định) | Tùy chọn bật (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Trong ví dụ này, bật tùy chọn sẽ chuyển chỉ văn bản đậm thành bitmap: nó không thể được chọn, sao chép hoặc tìm kiếm dưới dạng văn bản mà không có OCR, và các góc cạnh của nó xuất hiện mềm hơn ở mức phóng 800%. Văn bản thường vẫn có thể tìm kiếm. Khi tắt tùy chọn, cả hai chuỗi đều vẫn là văn bản.

Tùy chọn này rasterizes (chuyển thành bitmap) văn bản được định dạng đậm khi phông chữ không có kiểu chữ đậm riêng. [Thay thế Phông chữ](/slides/vi/php-java/font-substitution/) thay vào đó sẽ chọn một phông chữ khác khi phông chữ gốc không khả dụng.

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

Ví dụ sau sao chép slide đầu tiên từ một bản trình chiếu vào một bản trình chiếu mới với kích thước slide là 612 × 792 điểm (8,5 × 11 inch). Nó thu phóng nội dung slide để vừa và xuất slide đơn sang PDF.

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

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân theo [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Mã này minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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
Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi các tệp PDF sang các định dạng phổ biến. Bạn có thể thực hiện các chuyển đổi [PDF sang HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF sang ảnh](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF sang JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), và [PDF sang PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt—[PDF sang SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF sang TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), và [PDF sang XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—cũng được hỗ trợ.
{{% /alert %}}

> **Note:** Khi xuất sang PDF/UA, Aspose.Slides coi các đồ họa phức tạp như SmartArt, biểu đồ và công thức là một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại dưới dạng nội dung riêng và có thể được đánh dấu là nhiễu; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF hàng loạt không?**  
Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp của mình và áp dụng quy trình chuyển đổi bằng chương trình.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**  
Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) để đặt mật khẩu và xác định các quyền truy cập trong quá trình chuyển đổi.

**Làm sao để bao gồm các slide ẩn trong PDF?**  
Gọi [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) với `true` trong lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF tạo ra.

**Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?**  
Có, bạn có thể kiểm soát chất lượng hình ảnh bằng cách sử dụng các phương thức như [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) và [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) trong lớp [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) để đảm bảo hình ảnh chất lượng cao trong PDF của bạn.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**  
Có, Aspose.Slides cho phép bạn xuất PDF tuân theo [các tiêu chuẩn khác nhau](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng các yêu cầu về khả năng truy cập và lưu trữ.

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides cho PHP qua Java](/slides/vi/php-java/)
- [Tham chiếu API Aspose.Slides cho PHP qua Java](https://reference.aspose.com/slides/php-java/)
- [Trình chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/conversion)