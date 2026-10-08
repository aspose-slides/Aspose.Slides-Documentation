---
title: Chuyển đổi PPT và PPTX sang PDF trên Android [Bao gồm các tính năng nâng cao]
linktitle: PowerPoint sang PDF
type: docs
weight: 40
url: /vi/androidjava/convert-powerpoint-to-pdf/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- PowerPoint sang PDF
- bản trình bày sang PDF
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
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có khả năng tìm kiếm trong Java bằng Aspose.Slides cho Android, kèm các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản trình bày PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trên Android mang lại nhiều lợi ích, bao gồm khả năng tương thích trên các thiết bị khác nhau và giữ nguyên bố cục cũng như định dạng của bản trình bày. Hướng dẫn này trình bày cách chuyển đổi bản trình bày sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo mật PDF bằng mật khẩu, phát hiện việc thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình bày ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình bày sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) và sau đó lưu bản trình bày dưới dạng PDF bằng phương pháp [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) cung cấp phương pháp [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) thường được sử dụng để chuyển đổi bản trình bày sang PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java chèn thông tin API và số phiên bản vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản trình bày sang PDF, Aspose.Slides điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình bày sang PDF
* Các slide cụ thể từ một bản trình bày sang PDF

Aspose.Slides xuất bản trình bày sang PDF, đảm bảo các PDF kết quả gần như khớp với bản trình bày gốc. Các yếu tố và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các ô văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Liên kết siêu văn bản
* Đầu và chân trang
* Đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi tiêu chuẩn PowerPoint‑to‑PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản trình bày đã cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng cao nhất.

Ví dụ sau tải một bản trình bày và lưu tất cả các slide có thể hiển thị sang PDF bằng cài đặt xuất mặc định.

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
Aspose cung cấp một công cụ chuyển đổi **PowerPoint sang PDF** miễn phí trực tuyến tại [**Công cụ chuyển đổi PowerPoint sang PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) để minh họa quy trình chuyển đổi bản trình bày sang PDF. Bạn có thể chạy thử nghiệm với công cụ này để thấy quá trình thực tế được mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính dưới lớp [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)—cho phép bạn tùy chỉnh PDF đầu ra, khóa PDF bằng mật khẩu hoặc chỉ định cách tiến hành quá trình chuyển đổi.

### **Chuyển đổi PowerPoint sang PDF với các tùy chọn tùy chỉnh**

Bằng cách sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể định nghĩa cài đặt chất lượng mong muốn cho ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh và nhiều hơn nữa.

Ví dụ sau xuất một bản trình bày sang PDF 1.5 với chất lượng JPEG đặt ở 90, độ phân giải hình ảnh đặt ở 300 DPI, metafile được lưu dưới dạng PNG và nén văn bản Flate.

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

### **Giữ lại các tệp OLE nhúng dưới dạng tệp đính kèm PDF**

Nếu bản trình bày chứa một workbook Excel được nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu của workbook cùng với việc xem các slide. Gọi phương pháp [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) với `true` để giữ lại các tệp OLE được nhúng dưới dạng tệp đính kèm trong PDF kết quả.

Giá trị mặc định là `false`: hình ảnh xem trước hoặc biểu tượng của đối tượng OLE được hiển thị trên trang PDF, nhưng tệp nhúng không được bao gồm dưới dạng tệp đính kèm. Đặt tùy chọn thành `true` sẽ thêm dữ liệu tệp vào. Bản xem trước vẫn là một hình ảnh đại diện; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE không trở thành một bảng tính Excel tương tác trên trang PDF.

Ví dụ sau tải một bản trình bày đã chứa workbook Excel nhúng và xuất nó sang PDF với workbook được đính kèm.

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

1. Mở PDF đã xuất trong trình xem hỗ trợ tệp đính kèm, chẳng hạn như Adobe Acrobat Reader.
2. Mở bảng **Attachments** của trình xem và tìm workbook đã nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Bản xem trước trên trang PDF tách biệt với tệp đính kèm.

{{% alert color="info" title="Note" %}}
Tiêu chuẩn PDF/A đưa ra các hạn chế đối với tệp đính kèm: PDF/A‑1 cấm tệp nhúng, PDF/A‑2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A‑3 cho phép các loại tệp khác, bao gồm workbook Excel. Đây là yêu cầu của tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không minh họa xuất PDF/A.
{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với các slide ẩn**

Nếu bản trình bày chứa các slide ẩn, bạn có thể sử dụng phương pháp [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) từ lớp [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) để bao gồm các slide ẩn dưới dạng trang trong PDF kết quả.

Ví dụ sau xuất một bản trình bày sang PDF, bao gồm mọi slide ẩn.

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

### **Chuyển đổi PowerPoint sang PDF được bảo vệ bằng mật khẩu**

Ví dụ sau xuất một bản trình bày sang PDF yêu cầu mật khẩu `password` để mở. Các quyền truy cập cho phép in, bao gồm in chất lượng cao.

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

### **Phát hiện việc thay thế phông chữ**

Aspose.Slides cung cấp phương pháp [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) dưới lớp [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), cho phép bạn phát hiện việc thay thế phông chữ trong quá trình chuyển đổi bản trình bày sang PDF.

Ví dụ sau xuất một bản trình bày sang PDF và in các cảnh báo thay thế phông chữ ra console. Cảnh báo chỉ được in khi một phông chữ không có sẵn bị thay thế trong quá trình xuất.

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
Để biết thêm thông tin về việc thay thế phông chữ, xem bài viết [Thay thế phông chữ](/slides/vi/androidjava/font-substitution/).
{{% /alert %}} 

### **Xử lý phông chữ không có kiểu chữ đậm riêng**

Một bản trình bày có thể áp dụng định dạng đậm cho văn bản ngay cả khi phông chữ không có kiểu chữ đậm riêng. Văn bản vẫn có thể xuất hiện đậm thông qua việc làm đậm tổng hợp, làm tăng độ dày của glyph thường. Khi văn bản đó trông quá nặng hoặc không phù hợp với hình ảnh mong muốn trong PDF, hãy thử gọi [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) với `true`. Tùy chọn này sẽ render văn bản bị ảnh hưởng dưới dạng bitmap trong quá trình xuất PDF và có thể cải thiện ngoại hình của một số phông chữ. Giá trị mặc định là `false`.

Bản trình bày mẫu chứa hai ô văn bản: một ô với văn bản thường và một ô với định dạng đậm áp dụng cho cùng một phông chữ, phông chữ này không có kiểu chữ đậm riêng. Ví dụ sau tải bản trình bày, bật rasterization cho các kiểu chữ không hỗ trợ, và xuất nó sang PDF:

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

Các bản xem trước dưới đây cho thấy kết quả khi tùy chọn bị tắt và khi bật. Trong ví dụ này, văn bản đậm có đường nét dày hơn khi tùy chọn bị tắt. Khi bật, các đường nét nhẹ hơn; văn bản thường không thay đổi. So sánh kết quả trước khi quyết định cài đặt cho bản trình bày của bạn.

| Tùy chọn bị tắt (`false`, mặc định) | Tùy chọn được bật (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Trong ví dụ này, bật tùy chọn chỉ chuyển đổi văn bản đậm thành bitmap: không thể chọn, sao chép hoặc tìm kiếm như văn bản mà không dùng OCR, và các cạnh của nó trở nên mềm hơn ở mức phóng to 800 %. Văn bản thường vẫn có thể tìm kiếm. Khi tùy chọn bị tắt, cả hai chuỗi vẫn là văn bản.

Tùy chọn này rasterizes văn bản được định dạng là đậm khi phông chữ không có kiểu chữ đậm riêng. [Thay thế phông chữ](/slides/vi/androidjava/font-substitution/) sẽ chọn một phông chữ khác khi phông chữ gốc không khả dụng.

## **Chuyển đổi các slide đã chọn từ PowerPoint sang PDF**

Ví dụ sau xuất các slide 1 và 3 từ một bản trình bày sang PDF. Các số slide trong mảng này bắt đầu từ 1, và bản trình bày đầu vào phải chứa ít nhất ba slide.

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

## **Chuyển đổi PowerPoint sang PDF với kích thước slide tùy chỉnh**

Ví dụ sau sao chép slide đầu tiên từ một bản trình bày vào một bản trình bày mới với kích thước slide là 612 × 792 điểm (8,5 × 11 inch). Nó thu phóng nội dung slide để vừa và xuất slide đơn này sang PDF.

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

    // Xóa slide trống mà bản trình bày mới được tạo.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Chuyển đổi PowerPoint sang PDF trong chế độ xem ghi chú slide**

Ví dụ sau xuất một bản trình bày sang PDF, đặt ghi chú của người thuyết trình cho mỗi slide dưới slide. Hãy sử dụng một bản trình bày có ghi chú để xem kết quả.

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

## **Tiêu chuẩn truy cập và tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ theo [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Mã này minh họa quy trình chuyển đổi PowerPoint‑to‑PDF tạo ra nhiều PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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
Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi tệp PDF sang các định dạng tệp phổ biến. Bạn có thể thực hiện các chuyển đổi [PDF sang HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF sang hình ảnh](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF sang JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), và [PDF sang PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) . Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt—[PDF sang SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF sang TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), và [PDF sang XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—cũng được hỗ trợ.
{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức dưới dạng một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại như nội dung độc lập và có thể được đánh dấu là nhãn; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **FAQ**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF hàng loạt không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp và áp dụng quy trình chuyển đổi bằng mã.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm thế nào để bao gồm các slide ẩn trong PDF?**

Gọi [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) với `true` trong lớp [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng cách sử dụng các phương pháp như [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) và [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) trong lớp [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) để đảm bảo hình ảnh trong PDF của bạn có chất lượng cao.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các [tiêu chuẩn khác nhau](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/), bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng yêu cầu truy cập và lưu trữ.

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides cho Android qua Java](/slides/vi/androidjava/)
- [Tham chiếu API Aspose.Slides cho Android qua Java](https://reference.aspose.com/slides/androidjava/)
- [Trình chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/conversion)