---
title: "Chuyển đổi PPT và PPTX sang PDF trong JavaScript [Bao gồm các tính năng nâng cao]"
linktitle: "PowerPoint sang PDF"
type: docs
weight: 40
url: /vi/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- "chuyển đổi PowerPoint"
- "chuyển đổi bản thuyết trình"
- "PowerPoint sang PDF"
- "bản thuyết trình sang PDF"
- "PPT sang PDF"
- "chuyển đổi PPT sang PDF"
- "PPTX sang PDF"
- "chuyển đổi PPTX sang PDF"
- "lưu PowerPoint dưới dạng PDF"
- "lưu PPT dưới dạng PDF"
- "lưu PPTX dưới dạng PDF"
- "xuất PPT sang PDF"
- "xuất PPTX sang PDF"
- "tệp đính kèm"
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm được bằng Aspose.Slides cho Node.js, kèm ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Việc chuyển đổi các bản thuyết trình PowerPoint và OpenDocument (PPT, PPTX, ODP, v.v.) sang định dạng PDF bằng JavaScript mang lại nhiều lợi ích, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo toàn bố cục cũng như định dạng của bản thuyết trình. Hướng dẫn này trình bày cách chuyển đổi bản thuyết trình sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng ảnh, bao gồm các slide ẩn, bảo mật PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **PowerPoint to PDF Conversions**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản thuyết trình ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản thuyết trình sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) và sau đó lưu bản thuyết trình dưới dạng PDF bằng phương thức [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). Lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) cung cấp phương thức [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) thường được dùng để chuyển đổi bản thuyết trình sang PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Node.js via Java chèn thông tin API và số phiên bản vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản thuyết trình sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị có dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể chỉ định Aspose.Slides thay đổi hoặc xoá thông tin này khỏi tài liệu đầu ra.

{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản thuyết trình sang PDF
* Các slide cụ thể trong bản thuyết trình sang PDF

Aspose.Slides xuất bản thuyết trình sang PDF, đảm bảo các tệp PDF tạo ra gần giống với bản thuyết trình gốc. Các thành phần và thuộc tính được hiển thị một cách chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Header và Footer
* Danh sách đầu dòng
* Bảng

## **Convert PowerPoint to PDF**

Quá trình chuyển đổi chuẩn từ PowerPoint sang PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản thuyết trình đã cung cấp sang PDF bằng các thiết lập tối ưu ở mức chất lượng cao nhất.

Ví dụ dưới đây tải một bản thuyết trình và lưu tất cả các slide hiển thị sang PDF bằng các cài đặt xuất mặc định.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose cung cấp một công cụ chuyển đổi trực tuyến miễn phí [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) để minh họa quy trình chuyển đổi bản thuyết trình sang PDF. Bạn có thể thử nghiệm công cụ này để xem thực tế quy trình được mô tả ở đây.

{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)—cho phép bạn tùy biến PDF kết quả, khóa PDF bằng mật khẩu, hoặc chỉ định cách quá trình chuyển đổi sẽ diễn ra.

### **Convert PowerPoint to PDF with Custom Options**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định mức chất lượng mong muốn cho các ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho ảnh, và nhiều hơn nữa.

Ví dụ dưới đây xuất một bản thuyết trình sang PDF 1.5 với chất lượng JPEG là 90, độ phân giải ảnh là 300 DPI, metafile được lưu dưới dạng PNG, và nén văn bản bằng Flate.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Preserve Embedded OLE Files as PDF Attachments**

Nếu bản thuyết trình chứa một workbook Excel nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu trong workbook cũng như xem các slide. Gọi [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) với `true` để giữ các tệp OLE nhúng dưới dạng tệp đính kèm trong PDF kết quả.

Giá trị mặc định là `false`: hình ảnh xem trước hoặc biểu tượng của đối tượng OLE được hiển thị trên trang PDF, nhưng tệp nhúng không được bao gồm dưới dạng đính kèm. Đặt tùy chọn thành `true` sẽ bổ sung dữ liệu tệp. Hình ảnh xem trước vẫn là một biểu diễn trực quan; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE sẽ không trở thành một worksheet Excel tương tác trên trang PDF.

Ví dụ dưới đây tải một bản thuyết trình đã chứa sẵn workbook Excel nhúng và xuất nó sang PDF với workbook được đính kèm.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Để kiểm tra kết quả:

1. Mở PDF đã xuất trong trình xem hỗ trợ tệp đính kèm, chẳng hạn Adobe Acrobat Reader.
2. Mở bảng **Attachments** của trình xem và tìm workbook nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Hình ảnh xem trước trên trang PDF tách riêng khỏi tệp đính kèm.

{{% alert color="info" title="Note" %}}

Tiêu chuẩn PDF/A áp đặt các hạn chế đối với tệp đính kèm: PDF/A-1 cấm tệp nhúng, PDF/A-2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm workbook Excel. Đây là yêu cầu của tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không minh họa xuất PDF/A.

{{% /alert %}}

### **Convert PowerPoint to PDF with Hidden Slides**

Nếu bản thuyết trình có các slide ẩn, bạn có thể dùng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) của lớp [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn như các trang trong PDF kết quả.

Ví dụ dưới đây xuất một bản thuyết trình sang PDF, bao gồm cả các slide ẩn.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convert PowerPoint to a Password-Protected PDF**

Ví dụ dưới đây xuất một bản thuyết trình sang PDF yêu cầu mật khẩu `password` để mở. Quyền truy cập cho phép in, bao gồm in chất lượng cao.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detect Font Substitutions**

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) trong lớp [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), cho phép bạn phát hiện việc thay thế phông chữ trong quá trình chuyển đổi bản thuyết trình sang PDF.

Ví dụ dưới đây xuất một bản thuyết trình sang PDF và in các cảnh báo thay thế phông chữ ra console. Cảnh báo chỉ được in khi một phông chữ không khả dụng được thay thế trong quá trình xuất.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Để biết thêm thông tin về việc thay thế phông chữ, xem bài viết [Font Substitution](/slides/vi/nodejs-java/font-substitution/).

{{% /alert %}} 

### **Handle Fonts Without a Dedicated Bold Typeface**

Một bản thuyết trình có thể áp dụng định dạng đậm cho văn bản ngay cả khi phông chữ không có kiểu đậm riêng. Văn bản vẫn có thể hiển thị đậm thông qua việc tạo đậm tổng hợp, làm dày các glyph thường. Khi văn bản này trông quá nặng hoặc không khớp với mong muốn trong PDF, hãy thử gọi [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) với `true`. Tùy chọn này sẽ render văn bản bị ảnh hưởng dưới dạng bitmap trong quá trình xuất PDF và có thể cải thiện giao diện cho một số phông chữ. Giá trị mặc định là `false`.

Bản thuyết trình mẫu chứa hai hộp văn bản: một với văn bản thường và một với định dạng đậm áp dụng cho cùng một phông chữ không có kiểu đậm riêng. Ví dụ dưới đây tải bản thuyết trình, bật rasterization cho các kiểu phông chữ không hỗ trợ, và xuất nó sang PDF:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Các hình xem trước dưới đây cho thấy kết quả khi tắt và bật tùy chọn. Trong ví dụ này, văn bản đậm có nét dày hơn khi tùy chọn bị tắt. Khi bật, nét của nó nhẹ hơn; văn bản thường không thay đổi. So sánh kết quả trước khi quyết định cài đặt cho bản thuyết trình của bạn.

| Tùy chọn tắt (`false`, mặc định) | Tùy chọn bật (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Trong ví dụ này, bật tùy chọn chỉ biến văn bản đậm thành bitmap: nó không thể được chọn, sao chép hoặc tìm kiếm dưới dạng văn bản mà không có OCR, và các cạnh của nó sẽ mờ hơn ở mức phóng đại 800 %. Văn bản thường vẫn có thể tìm kiếm. Khi tắt tùy chọn, cả hai chuỗi vẫn là văn bản.

Tùy chọn này rasterizes văn bản được định dạng đậm khi phông chữ không có kiểu đậm riêng. [Font substitution](/slides/vi/nodejs-java/font-substitution/) thay vào đó sẽ chọn một phông chữ khác khi phông chữ gốc không khả dụng.

## **Convert Selected Slides from PowerPoint to PDF**

Ví dụ dưới đây xuất các slide 1 và 3 từ một bản thuyết trình sang PDF. Các số slide trong mảng này được đếm từ 1, và bản thuyết trình đầu vào phải có ít nhất ba slide.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Convert PowerPoint to PDF with Custom Slide Size**

Ví dụ dưới đây sao chép slide đầu tiên từ một bản thuyết trình vào một bản thuyết trình mới với kích thước slide 612 × 792 điểm (8.5 × 11 inch). Nó thu phóng nội dung slide để vừa và xuất slide đơn này sang PDF.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Xóa slide trống mà bản thuyết trình mới được tạo ra.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Convert PowerPoint to PDF in Notes Slide View**

Ví dụ dưới đây xuất một bản thuyết trình sang PDF, đặt ghi chú của mỗi slide dưới slide tương ứng. Sử dụng một bản thuyết trình có ghi chú người thuyết trình để xem kết quả.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Accessibility and Compliance Standards for PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã dưới đây minh họa quá trình chuyển đổi PowerPoint sang PDF tạo ra nhiều tệp PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi các tệp PDF sang các định dạng tệp phổ biến. Bạn có thể thực hiện chuyển đổi [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), và [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt khác—[PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)—cũng được hỗ trợ.

{{% /alert %}}

> **Lưu ý:** Khi xuất ra PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại dưới dạng nội dung riêng và có thể được đánh dấu là artefact; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **FAQ**

**Có thể chuyển đổi hàng loạt nhiều tệp PowerPoint sang PDF không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp và áp dụng quy trình chuyển đổi bằng cách lập trình.

**Có thể bảo mật PDF đã chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm sao để bao gồm các slide ẩn trong PDF?**

Gọi [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) với `true` trong lớp [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có thể duy trì chất lượng ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng ảnh bằng các phương thức như [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) và [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) trong lớp [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) để đảm bảo ảnh chất lượng cao trong PDF.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ [các tiêu chuẩn khác nhau](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng yêu cầu về khả năng truy cập và lưu trữ lâu dài.

## **Additional Resources**

- [Aspose.Slides for Node.js via Java Documentation](/slides/vi/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)