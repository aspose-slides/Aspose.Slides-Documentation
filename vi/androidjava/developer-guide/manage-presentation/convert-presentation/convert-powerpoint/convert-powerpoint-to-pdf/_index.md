---
title: Chuyển đổi PPT và PPTX sang PDF trên Android [Bao gồm các tính năng nâng cao]
linktitle: PowerPoint sang PDF
type: docs
weight: 40
url: /vi/androidjava/convert-powerpoint-to-pdf/
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
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có khả năng tìm kiếm trong Java bằng Aspose.Slides cho Android, với các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trên Android mang lại một số lợi thế, bao gồm khả năng tương thích trên các thiết bị khác nhau và giữ nguyên bố cục cũng như định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện việc thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) cung cấp phương thức [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) thường được sử dụng để chuyển đổi bản trình chiếu sang PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java chèn thông tin API và số phiên bản của nó vào tài liệu đầu ra. Ví dụ, khi chuyển đổi bản trình chiếu sang PDF, Aspose.Slides điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể từ bản trình chiếu sang PDF

Aspose.Slides xuất bản trình chiếu sang PDF, đảm bảo các PDF tạo ra gần giống với bản trình chiếu gốc. Các thành phần và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Liên kết siêu văn bản
* Đầu trang và chân trang
* Đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi chuẩn từ PowerPoint sang PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản trình chiếu được cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng cao nhất.

Ví dụ sau tải một bản trình chiếu và lưu tất cả các slide hiển thị sang PDF bằng các cài đặt xuất mặc định.

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
Aspose cung cấp bộ chuyển đổi trực tuyến miễn phí [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) để minh họa quy trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể chạy thử bộ chuyển đổi này để xem thực hiện trực tiếp quy trình được mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các Tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính dưới lớp [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—cho phép bạn tùy chỉnh PDF tạo ra, khóa PDF bằng mật khẩu, hoặc chỉ định cách quá trình chuyển đổi nên thực hiện.

### **Chuyển đổi PowerPoint sang PDF với Các Tùy chọn Tùy chỉnh**

Bằng cách sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể định nghĩa cài đặt chất lượng mong muốn cho hình raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh và nhiều hơn nữa.

Ví dụ sau xuất một bản trình chiếu sang PDF 1.5 với chất lượng JPEG được đặt là 90, độ phân giải hình ảnh là 300 DPI, metafile được lưu dưới dạng PNG và nén văn bản Flate.

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

### **Tự động Chọn Nén Hình ảnh**

Khi một bản trình chiếu chứa nhiều ảnh chụp hoặc ảnh màn hình, việc giảm kích thước PDF xuất ra có thể giúp dễ dàng gửi email hoặc tải về hơn. Gọi [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) với `true` để tự động chọn thuật toán nén phù hợp nhất cho mỗi hình ảnh trong quá trình xuất PDF.

Ví dụ sau tải một bản trình chiếu hiện có, bật lựa chọn nén hình ảnh tự động và lưu nó dưới dạng tài liệu PDF. Tất cả các cài đặt xuất PDF khác vẫn giữ giá trị mặc định.

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

Tùy chọn này chọn một thuật toán nén cho mỗi hình ảnh. Giảm giá trị truyền vào [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) sẽ làm giảm chất lượng ảnh JPEG, trong khi giảm giá trị truyền vào [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) cho phép hạ mẫu ảnh xuống độ phân giải thấp hơn, có thể giảm chi tiết. Việc bật tự động chọn nén không tự động làm giảm các cài đặt này.

Việc chọn thuật toán nén hình ảnh đòi hỏi thời gian xử lý và bộ nhớ bổ sung. Mức giảm kích thước phụ thuộc vào các hình ảnh và cài đặt xuất của bản trình chiếu; không có mức giảm cố định cho mọi bản trình chiếu.

### **Bảo toàn Các Tệp OLE Nhúng dưới dạng Đính kèm PDF**

Nếu bản trình chiếu chứa một workbook Excel được nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu workbook cũng như xem các slide. Gọi [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) với `true` để bảo toàn các tệp OLE nhúng dưới dạng đính kèm trong PDF tạo ra.

Giá trị mặc định là `false`: ảnh xem trước hoặc biểu tượng của đối tượng OLE được hiển thị trên trang PDF, nhưng tệp nhúng không được bao gồm dưới dạng đính kèm. Đặt tùy chọn thành `true` sẽ thêm dữ liệu tệp. Ảnh xem trước vẫn là một biểu diễn hình ảnh; đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE không trở thành một worksheet Excel tương tác trên trang PDF.

Ví dụ sau tải một bản trình chiếu đã chứa một workbook Excel nhúng và xuất nó sang PDF với workbook được đính kèm.

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

1. Mở PDF đã xuất trong một trình xem hỗ trợ đính kèm tệp, chẳng hạn Adobe Acrobat Reader.
2. Mở bảng **Attachments** của trình xem và tìm workbook đã nhúng.
3. Lưu đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Ảnh xem trước trên trang PDF tách biệt với đính kèm.

{{% alert color="info" title="Note" %}}
Tiêu chuẩn PDF/A áp đặt các hạn chế về đính kèm: PDF/A-1 cấm tệp nhúng, PDF/A-2 chỉ cho phép đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm workbook Excel. Đây là các yêu cầu của tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không minh họa xuất PDF/A.
{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với Slide Ẩn**

Nếu bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) từ lớp [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) để bao gồm các slide ẩn dưới dạng trang trong PDF tạo ra.

Ví dụ sau xuất một bản trình chiếu sang PDF, bao gồm bất kỳ slide ẩn nào.

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

### **Chuyển đổi PowerPoint sang PDF Có Bảo vệ Mật khẩu**

Ví dụ sau xuất một bản trình chiếu sang PDF yêu cầu mật khẩu `password` để mở. Các quyền truy cập cho phép in, bao gồm in chất lượng cao.

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

### **Phát hiện Thay thế Phông chữ**

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) dưới lớp [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) cho phép bạn phát hiện các trường hợp thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

Ví dụ sau xuất một bản trình chiếu sang PDF và in cảnh báo thay thế phông chữ ra console. Cảnh báo chỉ được in khi một phông chữ không khả dụng bị thay thế trong quá trình xuất.

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
Để biết thêm thông tin về thay thế phông chữ, xem bài viết [Thay thế phông chữ](/slides/vi/androidjava/font-substitution/).
{{% /alert %}} 

### **Xử lý Phông chữ Không Có Kiểu Đậm Riêng**

Một bản trình chiếu có thể áp dụng định dạng đậm cho văn bản ngay cả khi phông chữ không có kiểu đậm riêng. Văn bản vẫn có thể xuất hiện đậm thông qua việc tăng độ đậm nhân tạo, làm dày các glyph thường. Khi văn bản đó trông quá nặng hoặc không giống như mong muốn trong PDF, hãy thử gọi [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) với `true`. Tùy chọn này sẽ render văn bản bị ảnh hưởng dưới dạng bitmap trong quá trình xuất PDF và có thể cải thiện ngoại hình của một số phông chữ. Giá trị mặc định là `false`.

Bản trình chiếu mẫu chứa hai hộp văn bản: một với văn bản thường và một với định dạng đậm áp dụng cho cùng một phông chữ, phông chữ này không có kiểu đậm riêng. Ví dụ sau tải bản trình chiếu, bật rasterization cho các kiểu phông chữ không hỗ trợ, và xuất nó sang PDF:

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

Các bản xem trước sau đây cho thấy đầu ra khi tắt và khi bật tùy chọn. Trong ví dụ này, văn bản đậm có nét dày hơn khi tùy chọn tắt. Khi bật, nét của nó nhẹ hơn; văn bản thường không thay đổi. Hãy so sánh kết quả trước khi chọn cài đặt cho bản trình chiếu của bạn.

| Tùy chọn tắt (`false`, mặc định) | Tùy chọn bật (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Trong ví dụ này, bật tùy chọn chỉ biến văn bản đậm thành bitmap: nó không thể được chọn, sao chép hoặc tìm kiếm dưới dạng văn bản mà không có OCR, và các cạnh của nó trông mềm hơn ở mức phóng 800%. Văn bản thường vẫn có thể tìm kiếm. Khi tắt, cả hai chuỗi đều vẫn là văn bản.

Tùy chọn này rasterizes văn bản được định dạng đậm khi phông chữ không có kiểu đậm riêng. [Thay thế phông chữ](/slides/vi/androidjava/font-substitution/) thay vào đó sẽ chọn một phông chữ khác khi phông chữ gốc không khả dụng.

## **Chuyển đổi Các Slide Được Chọn từ PowerPoint sang PDF**

Ví dụ sau xuất các slide 1 và 3 từ một bản trình chiếu sang PDF. Các số slide trong mảng này được tính bắt đầu từ 1, và bản trình chiếu đầu vào phải có ít nhất ba slide.

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

## **Chuyển đổi PowerPoint sang PDF với Kích thước Slide Tùy chỉnh**

Ví dụ sau sao chép slide đầu tiên từ một bản trình chiếu vào một bản trình chiếu mới với kích thước slide là 612 × 792 điểm (8.5 × 11 inch). Nó điều chỉnh nội dung slide để vừa và xuất slide duy nhất sang PDF.

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

## **Chuyển đổi PowerPoint sang PDF trong chế độ Xem Ghi chú Slide**

Ví dụ sau xuất một bản trình chiếu sang PDF, đặt ghi chú diễn giả của mỗi slide dưới slide. Sử dụng một bản trình chiếu có ghi chú diễn giả để thấy kết quả.

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

## **Tiêu chuẩn Truy cập và Tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ theo [Hướng dẫn về khả năng truy cập nội dung web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Mã sau minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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
Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi tệp PDF sang các định dạng tệp phổ biến. Bạn có thể thực hiện chuyển đổi [PDF sang HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF sang image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF sang JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), và [PDF sang PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt—[PDF sang SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF sang TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), và [PDF sang XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—cũng được hỗ trợ.
{{% /alert %}}

> **Lưu ý:** Khi xuất ra PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức dưới dạng một hình duy nhất. Các yếu tố đường dẫn riêng lẻ không được giữ lại như nội dung riêng biệt và có thể được đánh dấu là hiện vật; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF cùng lúc không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp và áp dụng quá trình chuyển đổi bằng chương trình.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm thế nào để bao gồm các slide ẩn trong PDF?**

Gọi [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) với `true` trong lớp [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF tạo ra.

**Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng cách sử dụng các phương thức như [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) và [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) trong lớp [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) để đảm bảo hình ảnh trong PDF của bạn có chất lượng cao.

**Aspose.Slides hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các [tiêu chuẩn khác nhau](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng yêu cầu về khả năng truy cập và lưu trữ lâu dài.

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides for Android via Java](/slides/vi/androidjava/)
- [Aspose.Slides for Android via Java Tham chiếu API](https://reference.aspose.com/slides/androidjava/)
- [Trình chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/conversion)