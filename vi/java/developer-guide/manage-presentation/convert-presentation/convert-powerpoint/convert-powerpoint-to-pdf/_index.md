---
title: Chuyển đổi PPT và PPTX sang PDF trong Java [Bao gồm các tính năng nâng cao]
linktitle: PowerPoint sang PDF
type: docs
weight: 40
url: /vi/java/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm trong Java bằng Aspose.Slides, kèm các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bài thuyết trình PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong Java mang lại một số lợi thế, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo tồn bố cục cùng định dạng của bài thuyết trình. Hướng dẫn này trình bày cách chuyển đổi bài thuyết trình sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bài thuyết trình ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bài thuyết trình sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) và sau đó lưu bài thuyết trình dưới dạng PDF bằng phương thức [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) cung cấp phương thức [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) thường được dùng để chuyển đổi bài thuyết trình sang PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java chèn thông tin API và số phiên bản vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bài thuyết trình sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Note** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bài thuyết trình sang PDF
* Các slide cụ thể trong một bài thuyết trình sang PDF

Aspose.Slides xuất các bài thuyết trình sang PDF, đảm bảo các tệp PDF kết quả gần giống với bài thuyết trình gốc. Các yếu tố và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Liên kết
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi PowerPoint sang PDF tiêu chuẩn sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides sẽ cố gắng chuyển đổi bài thuyết trình được cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng tối đa.

Ví dụ sau tải một bài thuyết trình và lưu tất cả các slide hiển thị sang PDF bằng các cài đặt xuất mặc định.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose cung cấp một công cụ chuyển đổi trực tuyến miễn phí [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) để minh họa quy trình chuyển đổi bài thuyết trình sang PDF. Bạn có thể chạy thử công cụ này để thấy quy trình thực tế như mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)—cho phép bạn tùy biến PDF kết quả, khóa PDF bằng mật khẩu, hoặc chỉ định cách quy trình chuyển đổi sẽ diễn ra.

### **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn Tùy Chỉnh**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định cài đặt chất lượng mong muốn cho hình raster, chỉ định cách xử lý metafile, thiết lập mức nén cho văn bản, cấu hình DPI cho hình ảnh, và nhiều hơn nữa.

Ví dụ sau xuất một bài thuyết trình sang PDF 1.5 với chất lượng JPEG đặt ở 90, độ phân giải hình ảnh 300 DPI, metafile được lưu dưới dạng PNG và nén văn bản kiểu Flate.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Tự Động Chọn Nén Hình Ảnh**

Khi một bài thuyết trình chứa nhiều ảnh chụp hoặc ảnh chụp màn hình, việc giảm kích thước PDF xuất ra có thể giúp dễ dàng gửi email hoặc tải về hơn. Gọi [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) với `true` để tự động chọn thuật toán nén phù hợp nhất cho mỗi hình ảnh trong quá trình xuất PDF.

Ví dụ sau tải một bài thuyết trình hiện có, bật lựa chọn nén ảnh tự động và lưu nó dưới dạng tài liệu PDF. Tất cả các cài đặt xuất PDF khác vẫn giữ giá trị mặc định.

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Tùy chọn này chọn một thuật toán nén cho mỗi hình ảnh. Giảm giá trị truyền vào [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) sẽ làm giảm chất lượng ảnh JPEG, trong khi giảm giá trị truyền vào [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) cho phép hạ độ phân giải hình ảnh, nhờ đó giảm chi tiết. Bật lựa chọn nén tự động không tự động hạ thấp bất kỳ cài đặt nào trong hai trường hợp trên.

Việc chọn thuật toán nén ảnh yêu cầu thời gian xử lý và bộ nhớ bổ sung. Mức giảm kích thước phụ thuộc vào hình ảnh trong bài thuyết trình và cài đặt xuất; không có mức giảm cố định cho mọi bài thuyết trình.

### **Giữ Các Tập Tin OLE Nhúng Là Tệp Đính Kèm PDF**

Nếu một bài thuyết trình chứa một workbook Excel được nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu workbook cũng như xem các slide. Gọi [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) với `true` để giữ các tệp OLE nhúng làm tệp đính kèm trong PDF kết quả.

Giá trị mặc định là `false`: hình ảnh hoặc biểu tượng xem trước của đối tượng OLE được hiển thị trên trang PDF, nhưng tệp nhúng không được bao gồm dưới dạng tệp đính kèm. Đặt tùy chọn thành `true` sẽ thêm dữ liệu tệp vào. Hình ảnh xem trước vẫn là đại diện trực quan; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng rẽ. Đối tượng OLE sẽ không trở thành một bảng tính Excel tương tác trên trang PDF.

Ví dụ sau tải một bài thuyết trình đã chứa workbook Excel nhúng và xuất nó sang PDF với workbook được đính kèm.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Để kiểm tra kết quả:

1. Mở PDF đã xuất trong trình xem hỗ trợ tệp đính kèm, chẳng hạn Adobe Acrobat Reader.
2. Mở bảng **Attachments** của trình xem và tìm workbook đã nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Hình ảnh xem trước trên trang PDF tách biệt với tệp đính kèm.

{{% alert color="info" title="Note" %}}
Tiêu chuẩn PDF/A áp đặt các hạn chế đối với tệp đính kèm: PDF/A-1 cấm tệp nhúng, PDF/A-2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm workbook Excel. Đây là yêu cầu của tiêu chuẩn, không phải là giới hạn riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không minh họa việc xuất PDF/A.
{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với Các Slide Ẩn**

Nếu một bài thuyết trình chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) từ lớp [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) để đưa các slide ẩn vào dưới dạng trang trong PDF kết quả.

Ví dụ sau xuất một bài thuyết trình sang PDF, bao gồm mọi slide ẩn.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Chuyển đổi PowerPoint sang PDF Có Bảo Vệ Bằng Mật Khẩu**

Ví dụ sau xuất một bài thuyết trình sang PDF yêu cầu mật khẩu `password` để mở. Quyền truy cập cho phép in, bao gồm in chất lượng cao.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Phát Hiện Thay Thế Phông Chữ**

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) trong lớp [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) giúp bạn phát hiện các trường hợp thay thế phông chữ trong quá trình chuyển đổi bài thuyết trình sang PDF.

Ví dụ sau xuất một bài thuyết trình sang PDF và in các cảnh báo thay thế phông chữ ra console. Cảnh báo chỉ được in khi một phông chữ không khả dụng bị thay thế trong quá trình xuất.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Để biết thêm thông tin về thay thế phông chữ, xem bài viết [Font Substitution](/slides/vi/java/font-substitution/).
{{% /alert %}} 

### **Xử Lý Phông Chữ Không Có Kiểu Đậm Riêng**

Một bài thuyết trình có thể áp dụng định dạng đậm cho văn bản ngay cả khi phông chữ không có kiểu đậm riêng. Văn bản vẫn có thể hiển thị đậm thông qua “synthetic bolding”, nghĩa là làm dày các glyph thông thường. Khi văn bản trông quá nặng hoặc không giống như mong muốn trong PDF, hãy thử gọi [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) với `true`. Tùy chọn này sẽ raster hóa (biểu diễn dưới dạng bitmap) văn bản bị ảnh hưởng trong quá trình xuất PDF và có thể cải thiện hiển thị cho một số phông chữ. Giá trị mặc định là `false`.

Bài thuyết trình mẫu chứa hai hộp văn bản: một với văn bản thường và một với định dạng đậm áp dụng cùng một phông chữ không có kiểu đậm riêng. Ví dụ sau tải bài thuyết trình, bật raster hóa các kiểu phông chữ không hỗ trợ, và xuất nó sang PDF:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Các hình ảnh dưới đây cho thấy kết quả khi tùy chọn bị tắt và khi bật. Trong ví dụ này, văn bản đậm có nét dày hơn khi tùy chọn tắt. Khi bật, nét đậm nhẹ hơn; văn bản thường không thay đổi. So sánh kết quả trước khi quyết định cài đặt cho bài thuyết trình của bạn.

| Tùy chọn tắt (`false`, mặc định) | Tùy chọn bật (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Trong ví dụ này, bật tùy chọn chỉ raster hóa văn bản đậm: nó không thể được chọn, sao chép, hoặc tìm kiếm dưới dạng văn bản mà không có OCR, và các cạnh của nó sẽ mềm hơn ở mức phóng đại 800 %. Văn bản thường vẫn có thể tìm kiếm. Khi tùy chọn tắt, cả hai chuỗi vẫn là văn bản.

Tùy chọn này raster hóa văn bản được định dạng đậm khi phông chữ không có kiểu đậm riêng. [Font Substitution](/slides/vi/java/font-substitution/) thay vào đó sẽ chọn một phông chữ khác khi phông chữ gốc không khả dụng.

## **Chuyển Đổi Các Slide Được Chọn Từ PowerPoint sang PDF**

Ví dụ sau xuất các slide 1 và 3 từ một bài thuyết trình sang PDF. Các số slide trong mảng này tính từ 1, và bài thuyết trình đầu vào phải chứa ít nhất ba slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Chuyển Đổi PowerPoint sang PDF với Kích Thước Slide Tùy Chỉnh**

Ví dụ sau sao chép slide đầu tiên từ một bài thuyết trình vào một bài thuyết trình mới với kích thước slide 612 × 792 điểm (8.5 × 11 inch). Nó sẽ co giãn nội dung slide để vừa và xuất slide đơn này sang PDF.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Xóa slide trống mà bản trình chiếu mới được tạo ra.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Chuyển Đổi PowerPoint sang PDF trong Chế Độ Ghi Chú Slide**

Ví dụ sau xuất một bài thuyết trình sang PDF, đặt ghi chú của mỗi slide dưới slide tương ứng. Hãy sử dụng một bài thuyết trình có ghi chú để xem kết quả.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Tiêu Chuẩn Truy Cập và Tuân Thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng một quy trình chuyển đổi tuân thủ các [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất một tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã dưới đây minh họa một quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều tệp PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi tệp PDF sang các định dạng tệp phổ biến. Bạn có thể thực hiện chuyển đổi [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), và [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang định dạng chuyên biệt—[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), và [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—cũng được hỗ trợ.
{{% /alert %}}

> **Note:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức dưới dạng một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại như nội dung độc lập và có thể được đánh dấu là nhiễu; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF cùng lúc không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể duyệt qua các tệp và áp dụng quy trình chuyển đổi một cách lập trình.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm sao để bao gồm các slide ẩn trong PDF?**

Gọi [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) với `true` trong lớp [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng các phương thức như [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) và [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) trong lớp [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) để đảm bảo hình ảnh có chất lượng cao trong PDF.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ [các tiêu chuẩn khác nhau](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng yêu cầu truy cập và lưu trữ.

## **Tài Nguyên Bổ Sung**

- [Aspose.Slides for Java Documentation](/slides/vi/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)