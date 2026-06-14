---
title: Chuyển đổi PPT và PPTX sang PDF trong JavaScript [Bao gồm các tính năng nâng cao]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm bằng Aspose.Slides cho Node.js, kèm theo các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong JavaScript mang lại nhiều ưu điểm, bao gồm khả năng tương thích trên các thiết bị khác nhau và giữ nguyên bố cục cũng như định dạng của bản trình chiếu. Hướng dẫn này minh họa cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện việc thay thế phông chữ, chọn các slide cụ thể để chuyển đổi, và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức `save`. Lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) cung cấp phương thức `save` thường được sử dụng để chuyển đổi bản trình chiếu sang PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides cho Node.js qua Java chèn thông tin API và số phiên bản của nó vào các tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản trình chiếu sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng một giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc xóa thông tin này khỏi các tài liệu đầu ra.

{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể từ một bản trình chiếu sang PDF

Aspose.Slides xuất bản trình chiếu sang PDF, đảm bảo các PDF tạo ra gần giống với bản trình chiếu gốc. Các yếu tố và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn
* Liên kết
* Đầu và cuối trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi chuẩn từ PowerPoint sang PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides sẽ cố gắng chuyển đổi bản trình chiếu đã cung cấp sang PDF bằng các thiết lập tối ưu ở mức chất lượng tối đa.

Đoạn mã dưới đây cho bạn thấy cách chuyển đổi một bản trình chiếu (PPT, PPTX, ODP, v.v.) sang PDF:

```js
// Tạo thể hiện lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Lưu bản trình chiếu dưới dạng PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose cung cấp một công cụ chuyển đổi PowerPoint sang PDF trực tuyến miễn phí [**PowerPoint to PDF converter**](https://products.aspose.app/slides/vi/conversion/ppt-to-pdf) để minh họa quy trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể thực hiện thử nghiệm với công cụ này để triển khai thực tế quy trình được mô tả ở đây.

{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh — các thuộc tính thuộc lớp [PdfOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pdfoptions/) — cho phép bạn tùy chỉnh PDF đầu ra, khóa PDF bằng mật khẩu, hoặc chỉ định cách tiến trình chuyển đổi sẽ diễn ra.

### **Chuyển đổi PowerPoint sang PDF với Các Tùy chọn Tùy chỉnh**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể định nghĩa cài đặt chất lượng mong muốn cho hình raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và nhiều hơn nữa.

Ví dụ mã dưới đây minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với một số tùy chọn tùy chỉnh.

```js
// Tạo thể hiện lớp PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// Đặt chất lượng cho hình ảnh JPG.
pdfOptions.setJpegQuality(java.newByte(90));

// Đặt DPI cho hình ảnh.
pdfOptions.setSufficientResolution(300);

// Đặt hành vi cho metafile.
pdfOptions.setSaveMetafilesAsPng(true);

// Đặt mức nén văn bản cho nội dung văn bản.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Xác định chế độ tuân thủ PDF.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Tạo thể hiện lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Lưu bản trình chiếu dưới dạng tài liệu PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Chuyển đổi PowerPoint sang PDF với Các Slide Ẩn**

Nếu một bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PdfOptions) để bao gồm các slide ẩn dưới dạng trang trong PDF kết quả.

Đoạn mã JavaScript sau đây cho thấy cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với các slide ẩn được bao gồm:

```js
// Tạo thể hiện lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Tạo thể hiện lớp PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Thêm các slide ẩn.
    pdfOptions.setShowHiddenSlides(true);

    // Lưu bản trình chiếu dưới dạng PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Chuyển đổi PowerPoint sang PDF được Bảo vệ Mật khẩu**

Đoạn mã JavaScript này minh họa cách chuyển đổi một bản trình chiếu PowerPoint thành PDF được bảo vệ bằng mật khẩu bằng cách sử dụng các tham số bảo mật từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PdfOptions):

```js
// Tạo thể hiện lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Tạo thể hiện lớp PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Đặt mật khẩu PDF và quyền truy cập.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Lưu bản trình chiếu dưới dạng PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Phát hiện Thay thế Phông chữ**

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PdfOptions), cho phép bạn phát hiện việc thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

Đoạn mã JavaScript này cho thấy cách phát hiện việc thay thế phông chữ:

```js
// Đặt callback cảnh báo trong tùy chọn PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Tạo thể hiện lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Lưu bản trình chiếu dưới dạng PDF.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```

{{%  alert color="primary"  %}} 

Để biết thêm thông tin về việc thay thế phông chữ, xem bài viết [Font Substitution](/slides/vi/nodejs-java/font-substitution/).

{{% /alert %}} 

## **Chuyển đổi Các Slide Được Chọn trong PowerPoint sang PDF**

Đoạn mã JavaScript này minh họa cách chuyển đổi chỉ các slide cụ thể từ một bản trình chiếu PowerPoint sang PDF:

```js
// Tạo thể hiện lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Đặt mảng số slide.
    let slides = java.newArray("int", [1, 3]);

    // Lưu bản trình chiếu dưới dạng PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi PowerPoint sang PDF với Kích thước Slide Tùy chỉnh**

Đoạn mã JavaScript này minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với kích thước slide được chỉ định:

```js
const slideWidth = 612;
const slideHeight = 792;

// Tạo thể hiện lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Tạo một bản trình chiếu mới với kích thước slide được điều chỉnh.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Đặt kích thước slide tùy chỉnh.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Sao chép slide đầu tiên từ bản trình chiếu gốc.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Lưu bản trình chiếu đã thay đổi kích thước sang PDF có ghi chú.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Chuyển đổi PowerPoint sang PDF trong Chế độ Xem Ghi chú Slide**

Đoạn mã JavaScript này minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF có bao gồm ghi chú:

```js
// Tạo thể hiện lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Cấu hình tùy chọn PDF với bố cục ghi chú.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Lưu bản trình chiếu sang PDF có ghi chú.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Tiêu chuẩn Truy cập và Tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã JavaScript này minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

```js
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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi các tệp PDF sang các định dạng phổ biến. Bạn có thể thực hiện các chuyển đổi [PDF to HTML](https://products.aspose.com/slides/vi/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/vi/nodejs-java/conversion/pdf-to-jpg/), và [PDF to PNG](https://products.aspose.com/slides/vi/nodejs-java/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt khác — [PDF to SVG](https://products.aspose.com/slides/vi/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/vi/nodejs-java/conversion/pdf-to-tiff/) — cũng được hỗ trợ.

{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được lưu giữ như nội dung riêng và có thể được đánh dấu là hiện tượng phụ; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF hàng loạt không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể duyệt qua các tệp và thực hiện quá trình chuyển đổi một cách lập trình.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Chắc chắn. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PdfOptions) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm sao tôi có thể bao gồm các slide ẩn trong PDF?**

Sử dụng phương thức `setShowHiddenSlides` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PdfOptions) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng cách sử dụng các phương thức như `setJpegQuality` và `setSufficientResolution` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PdfOptions) để đảm bảo hình ảnh chất lượng cao trong PDF của bạn.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các tiêu chuẩn khác nhau, bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng yêu cầu về khả năng truy cập và lưu trữ.

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides cho Node.js qua Java](/slides/vi/nodejs-java/)
- [Tham chiếu API Aspose.Slides cho Node.js qua Java](https://reference.aspose.com/slides/vi/nodejs-java/)
- [Trình chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/vi/conversion)