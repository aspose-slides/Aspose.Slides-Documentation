---
title: Chuyển đổi PPT và PPTX sang PDF trong JavaScript [Bao gồm tính năng nâng cao]
linktitle: PowerPoint sang PDF
type: docs
weight: 40
url: /vi/nodejs-java/convert-powerpoint-to-pdf/
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
- đính kèm
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có khả năng tìm kiếm bằng Aspose.Slides cho Node.js, với các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong JavaScript mang lại một số lợi thế, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo toàn bố cục cũng như định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi, và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **PowerPoint to PDF Conversions**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save). Lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) cung cấp phương thức [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) thường được sử dụng để chuyển đổi bản trình chiếu sang PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Node.js via Java chèn thông tin API và số phiên bản vào tài liệu đầu ra. Ví dụ, khi chuyển đổi bản trình chiếu sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Note** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.

{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể trong bản trình chiếu sang PDF

Aspose.Slides xuất bản trình chiếu sang PDF, đảm bảo các tệp PDF kết quả gần như khớp với bản trình chiếu gốc. Các thành phần và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Convert PowerPoint to PDF**

Quy trình chuyển đổi tiêu chuẩn PowerPoint‑to‑PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản trình chiếu được cung cấp sang PDF bằng các thiết lập tối ưu ở mức chất lượng cao nhất.

Ví dụ sau tải một bản trình chiếu và lưu tất cả các slide hiển thị sang PDF bằng các cài đặt xuất mặc định.

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

Aspose cung cấp một công cụ trực tuyến miễn phí [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) cho phép bạn xem quy trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể thử nghiệm công cụ này để thực hiện một thử nghiệm thực tế của quy trình mô tả ở đây.

{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh — các thuộc tính dưới lớp [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) — cho phép bạn tùy chỉnh PDF kết quả, khóa PDF bằng mật khẩu, hoặc chỉ định cách thức quá trình chuyển đổi sẽ diễn ra.

### **Convert PowerPoint to PDF with Custom Options**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định mức chất lượng mong muốn cho các hình ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và nhiều hơn nữa.

Ví dụ sau xuất một bản trình chiếu sang PDF 1.5 với chất lượng JPEG được đặt thành 90, độ phân giải hình ảnh là 300 DPI, metafile được lưu dưới dạng PNG, và nén văn bản Flate.

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

Nếu bản trình chiếu chứa một workbook Excel được nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu của workbook cũng như xem các slide. Gọi [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) với `true` để giữ lại các tệp OLE nhúng dưới dạng tệp đính kèm trong PDF kết quả.

Giá trị mặc định là `false`: ảnh xem trước hoặc biểu tượng của đối tượng OLE được hiển thị trên trang PDF, nhưng tệp nhúng không được bao gồm như một tệp đính kèm. Đặt tùy chọn này thành `true` sẽ bổ sung dữ liệu tệp. Ảnh xem trước vẫn là biểu diễn hình ảnh; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE sẽ không trở thành một worksheet Excel tương tác trên trang PDF.

Ví dụ sau tải một bản trình chiếu đã chứa một workbook Excel nhúng và xuất nó sang PDF với workbook được đính kèm.

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

1. Mở PDF đã xuất trong một trình xem hỗ trợ tệp đính kèm, chẳng hạn Adobe Acrobat Reader.
2. Mở bảng **Attachments** của trình xem và tìm workbook được nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Ảnh xem trước trên trang PDF tách biệt khỏi tệp đính kèm.

{{% alert color="info" title="Note" %}}

Các tiêu chuẩn PDF/A áp đặt hạn chế đối với tệp đính kèm: PDF/A‑1 cấm tệp nhúng, PDF/A‑2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A‑3 cho phép các loại tệp khác, bao gồm workbook Excel. Đây là yêu cầu của các tiêu chuẩn, không phải hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không minh họa xuất PDF/A.

{{% /alert %}}

### **Convert PowerPoint to PDF with Hidden Slides**

Nếu bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setShowHiddenSlides) từ lớp [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn làm các trang trong PDF kết quả.

Ví dụ sau xuất một bản trình chiếu sang PDF, bao gồm mọi slide ẩn.

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

Ví dụ sau xuất một bản trình chiếu sang PDF yêu cầu mật khẩu `password` để mở. Các quyền truy cập cho phép in, bao gồm in chất lượng cao.

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

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) dưới lớp [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), cho phép bạn phát hiện các trường hợp thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

Ví dụ sau xuất một bản trình chiếu sang PDF và in các cảnh báo thay thế phông chữ ra console. Cảnh báo chỉ được in khi một phông chữ không khả dụng bị thay thế trong quá trình xuất.

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

Để biết thêm thông tin về thay thế phông chữ, xem bài viết [Font Substitution](/slides/vi/nodejs-java/font-substitution/).

{{% /alert %}} 

## **Convert Selected Slides from PowerPoint to PDF**

Ví dụ sau xuất các slide 1 và 3 từ một bản trình chiếu sang PDF. Các số slide trong mảng này bắt đầu từ 1, và bản trình chiếu đầu vào phải có ít nhất ba slide.

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

Ví dụ sau sao chép slide đầu tiên từ một bản trình chiếu vào một bản trình chiếu mới với kích thước slide 612 × 792 điểm (8,5 × 11 inch). Nội dung slide được thu phóng để vừa và xuất slide đơn này sang PDF.

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

    // Xóa slide trống mà bản trình chiếu mới được tạo ra.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Convert PowerPoint to PDF in Notes Slide View**

Ví dụ sau xuất một bản trình chiếu sang PDF, đặt ghi chú của mỗi slide dưới slide tương ứng. Sử dụng một bản trình chiếu có ghi chú để xem kết quả.

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

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi đáp ứng các [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất một tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã này minh họa quy trình chuyển đổi PowerPoint‑to‑PDF tạo ra nhiều PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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

Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi các tệp PDF sang các định dạng tệp phổ biến. Bạn có thể thực hiện các chuyển đổi [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), và [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt khác — [PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) — cũng được hỗ trợ.

{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức dưới dạng một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại như nội dung riêng và có thể bị đánh dấu là artefact; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **FAQ**

**Can I convert multiple PowerPoint files to PDF in bulk?**

Yes, Aspose.Slides supports batch conversion of multiple PPT or PPTX files to PDF. You can iterate through your files and apply the conversion process programmatically.

**Is it possible to password-protect the converted PDF?**

Yes. Use the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) class to set a password and define access permissions during the conversion process.

**How do I include hidden slides in the PDF?**

Call [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setShowHiddenSlides) with `true` in the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) class to include hidden slides in the resulting PDF.

**Can Aspose.Slides maintain high image quality in the PDF?**

Yes, you can control image quality by using methods such as [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setJpegQuality) and [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setSufficientResolution) in the [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) class to ensure high-quality images in your PDF.

**Does Aspose.Slides support PDF/A compliance standards?**

Yes, Aspose.Slides allows you to export PDFs that comply with [various standards](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), including PDF/A1a, PDF/A1b, and PDF/UA, ensuring your documents meet accessibility and archival requirements.

## **Additional Resources**

- [Aspose.Slides for Node.js via Java Documentation](/slides/vi/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)