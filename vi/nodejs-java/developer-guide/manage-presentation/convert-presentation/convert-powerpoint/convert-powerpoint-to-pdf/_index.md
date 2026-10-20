---
title: Chuyển đổi PPT và PPTX sang PDF trong JavaScript [Bao gồm các tính năng nâng cao]
linktitle: PowerPoint sang PDF
type: docs
weight: 40
url: /vi/nodejs-java/convert-powerpoint-to-pdf/
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
- tệp đính kèm
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: Chuyển đổi PowerPoint PPT/PPTX thành PDF chất lượng cao, có thể tìm kiếm với Aspose.Slides cho Node.js, kèm theo các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao.
---
## **Tổng quan**

Chuyển đổi các bản trình chiếu PowerPoint và OpenDocument (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong JavaScript mang lại nhiều lợi thế, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo tồn bố cục cũng như định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/). Lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) cung cấp phương thức [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) thường được sử dụng để chuyển đổi bản trình chiếu sang PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Node.js via Java chèn thông tin API và số phiên bản vào tài liệu đầu ra. Ví dụ, khi chuyển đổi bản trình chiếu sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.

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
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi chuẩn từ PowerPoint sang PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides sẽ cố gắng chuyển đổi bản trình chiếu đã cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng cao nhất.

Ví dụ sau tải một bản trình chiếu và lưu tất cả các slide hiển thị sang PDF bằng cài đặt xuất mặc định.

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

Aspose cung cấp một [**bộ chuyển đổi PowerPoint sang PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) trực tuyến miễn phí, cho phép bạn thử quy trình chuyển đổi trình chiếu sang PDF. Bạn có thể chạy thử nghiệm với bộ chuyển đổi này để xem thực tế quá trình được mô tả ở đây.

{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/)—để bạn có thể tùy biến PDF tạo ra, khóa PDF bằng mật khẩu, hoặc chỉ định cách quá trình chuyển đổi diễn ra.

### **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn Tùy Chỉnh**

Bằng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định cài đặt chất lượng mong muốn cho hình raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và nhiều hơn nữa.

Ví dụ sau xuất một bản trình chiếu sang PDF 1.5 với chất lượng JPEG đặt ở 90, độ phân giải hình ảnh 300 DPI, metafile lưu dưới dạng PNG và nén văn bản bằng Flate.

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

### **Tự Động Chọn Thuật Toán Nén Hình Ảnh**

Khi một bản trình chiếu chứa nhiều ảnh chụp hoặc ảnh màn hình, việc giảm kích thước PDF xuất ra có thể giúp việc gửi email hoặc tải về trở nên dễ dàng hơn. Gọi [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) với `true` để tự động chọn thuật toán nén phù hợp nhất cho mỗi hình ảnh trong quá trình xuất PDF.

Ví dụ sau tải một bản trình chiếu hiện có, bật tính năng tự động chọn nén hình ảnh và lưu nó dưới dạng tài liệu PDF. Tất cả các cài đặt xuất PDF khác vẫn giữ giá trị mặc định.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Tùy chọn này chọn một thuật toán nén cho mỗi hình ảnh. Giảm giá trị truyền cho [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) sẽ làm giảm chất lượng ảnh JPEG, trong khi giảm giá trị truyền cho [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) cho phép giảm độ phân giải ảnh, từ đó giảm chi tiết. Việc bật tự động chọn nén không tự động giảm các cài đặt này.

Việc chọn thuật toán nén hình ảnh yêu cầu thời gian xử lý và bộ nhớ bổ sung. Mức giảm kích thước phụ thuộc vào hình ảnh và cài đặt xuất của bản trình chiếu; không có mức giảm cố định cho mọi bản trình chiếu.

### **Bảo Tồn Các Tệp OLE Nhúng dưới Dạng Đính Kèm PDF**

Nếu bản trình chiếu chứa một workbook Excel nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu workbook cùng với việc xem các slide. Gọi [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) với `true` để bảo tồn các tệp OLE nhúng dưới dạng đính kèm trong PDF kết quả.

Giá trị mặc định là `false`: ảnh xem trước hoặc biểu tượng của đối tượng OLE được hiển thị trên trang PDF, nhưng tệp nhúng không được bao gồm như một đính kèm. Đặt tùy chọn này thành `true` sẽ thêm dữ liệu tệp vào đính kèm. Ảnh xem trước vẫn là biểu tượng hình ảnh; đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE sẽ không biến thành một worksheet Excel tương tác trên trang PDF.

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

1. Mở PDF đã xuất trong trình xem hỗ trợ tệp đính kèm, chẳng hạn Adobe Acrobat Reader.
2. Mở bảng **Đính kèm** của trình xem và tìm workbook được nhúng.
3. Lưu đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Ảnh xem trước trên trang PDF tách biệt với đính kèm.

{{% alert color="info" title="Note" %}}

Các tiêu chuẩn PDF/A đặt ra hạn chế về đính kèm: PDF/A-1 cấm tệp nhúng, PDF/A-2 cho phép chỉ các đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm workbook Excel. Đây là yêu cầu của tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không minh họa xuất PDF/A.

{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với Các Slide Ẩn**

Nếu bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) từ lớp [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn dưới dạng trang trong PDF kết quả.

Ví dụ sau xuất một bản trình chiếu sang PDF, bao gồm cả các slide ẩn.

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

### **Chuyển đổi PowerPoint sang PDF được Bảo Vệ Bằng Mật Khẩu**

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

### **Phát Hiện Thay Thế Phông Chữ**

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) trong lớp [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), cho phép bạn phát hiện các trường hợp thay thế phông chữ trong quá trình chuyển đổi trình chiếu sang PDF.

Ví dụ sau xuất một bản trình chiếu sang PDF và in cảnh báo thay thế phông chữ ra console. Cảnh báo chỉ được in khi một phông chữ không khả dụng bị thay thế trong quá trình xuất.

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

Để biết thêm thông tin về thay thế phông chữ, xem bài viết [Thay thế phông chữ](/slides/vi/nodejs-java/font-substitution/).

{{% /alert %}} 

### **Xử Lý Phông Chữ Không Có Kiểu In Đậm Riêng**

Một bản trình chiếu có thể áp dụng định dạng in đậm cho văn bản ngay cả khi phông chữ không có kiểu in đậm riêng. Văn bản vẫn có thể hiển thị in đậm thông qua việc tạo in đậm tổng hợp, làm dày các glyph chuẩn. Khi văn bản trông quá nặng hoặc không giống như dự định trong PDF, hãy thử gọi [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) với `true`. Tùy chọn này sẽ raster hoá văn bản bị ảnh hưởng thành bitmap trong quá trình xuất PDF và có thể cải thiện hiển thị cho một số phông chữ. Giá trị mặc định là `false`.

Bản trình chiếu mẫu chứa hai hộp văn bản: một hộp có văn bản thường và một hộp có định dạng in đậm áp dụng cho cùng một phông chữ, phông chữ này không có kiểu in đậm riêng. Ví dụ sau tải bản trình chiếu, bật raster hoá các kiểu phông chữ không hỗ trợ, và xuất nó sang PDF:

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

Các hình dưới đây cho thấy kết quả khi tùy chọn bị tắt và khi bật. Trong ví dụ này, văn bản in đậm có nét dày hơn khi tùy chọn bị tắt. Khi bật, nét của nó mỏng hơn; văn bản thường không thay đổi. So sánh kết quả trước khi chọn cài đặt cho bản trình chiếu của bạn.

| Tùy chọn tắt (`false`, mặc định) | Tùy chọn bật (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Trong ví dụ này, bật tùy chọn chỉ biến văn bản in đậm thành bitmap: nó không thể được chọn, sao chép hoặc tìm kiếm dưới dạng văn bản mà không có OCR, và các cạnh của nó xuất hiện mềm hơn ở độ phóng 800%. Văn bản thường vẫn có thể tìm kiếm. Khi tắt, cả hai chuỗi đều vẫn là văn bản.

Tùy chọn này raster hoá văn bản được định dạng in đậm khi phông chữ không có kiểu in đậm riêng. [Thay thế phông chữ](/slides/vi/nodejs-java/font-substitution/) thay vào đó sẽ chọn một phông chữ khác khi phông chữ gốc không khả dụng.

## **Chuyển Đổi Các Slide Được Chọn Từ PowerPoint sang PDF**

Ví dụ sau xuất các slide 1 và 3 từ một bản trình chiếu sang PDF. Các số slide trong mảng này bắt đầu từ 1, và bản trình chiếu đầu vào phải chứa ít nhất ba slide.

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

## **Chuyển Đổi PowerPoint sang PDF với Kích Thước Slide Tùy Chỉnh**

Ví dụ sau sao chép slide đầu tiên từ một bản trình chiếu vào một bản trình chiếu mới với kích thước slide là 612 × 792 điểm (8.5 × 11 inch). Nó sẽ thu phóng nội dung slide để vừa và xuất slide đơn lẻ này sang PDF.

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

    // Xóa slide trống mà bản trình chiếu mới được tạo.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Chuyển Đổi PowerPoint sang PDF trong Chế Độ Xem Ghi Chú Slide**

Ví dụ sau xuất một bản trình chiếu sang PDF, đặt ghi chú người thuyết trình của mỗi slide phía dưới slide. Sử dụng bản trình chiếu có ghi chú người thuyết trình để xem kết quả.

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

## **Tiêu Chuẩn Truy Cập và Tuân Thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ [Hướng dẫn Tiếp cận Nội dung Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Mã nguồn dưới đây minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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

Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi các tệp PDF sang các định dạng phổ biến. Bạn có thể thực hiện các chuyển đổi [PDF sang HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF sang JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), và [PDF sang PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt khác—[PDF sang SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF sang TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)—cũng được hỗ trợ.

{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại dưới dạng nội dung riêng và có thể được đánh dấu là nhiễu; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Có thể chuyển đổi hàng loạt nhiều tệp PowerPoint sang PDF không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp và áp dụng quy trình chuyển đổi bằng lập trình.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm sao để bao gồm các slide ẩn trong PDF?**

Gọi [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) với `true` trong lớp [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có duy trì chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng các phương pháp như [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) và [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) trong lớp [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) để đảm bảo hình ảnh chất lượng cao trong PDF của bạn.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các [tiêu chuẩn khác nhau](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng yêu cầu truy cập và lưu trữ lâu dài.

## **Tài Nguyên Bổ Sung**

- [Tài liệu Aspose.Slides cho Node.js qua Java](/slides/vi/nodejs-java/)
- [Tham khảo API Aspose.Slides cho Node.js qua Java](https://reference.aspose.com/slides/nodejs-java/)
- [Công cụ chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/conversion)