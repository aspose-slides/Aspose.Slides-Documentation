---
title: "Chuyển đổi PPT và PPTX sang PDF trong Java [Bao gồm các tính năng nâng cao]"
linktitle: "PowerPoint sang PDF"
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm trong Java bằng Aspose.Slides, kèm ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong Java mang lại nhiều lợi ích, bao gồm khả năng tương thích trên các thiết bị khác nhau và giữ nguyên bố cục cũng như định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức `save`. Lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) cung cấp phương thức `save` thường được sử dụng để chuyển đổi bản trình chiếu sang PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java chèn thông tin API và số phiên bản của mình vào tài liệu đầu ra. Ví dụ, khi chuyển đổi bản trình chiếu sang PDF, Aspose.Slides sẽ điền trường Application bằng “*Aspose.Slides*” và trường PDF Producer bằng giá trị có dạng “*Aspose.Slides v XX.XX*”. **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc xóa thông tin này khỏi tài liệu đầu ra.

{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể trong bản trình chiếu sang PDF

Aspose.Slides xuất bản trình chiếu sang PDF, đảm bảo các PDF tạo ra gần như giống nguyên bản. Các yếu tố và thuộc tính được render chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Khung văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Đầu trang và chân trang
* Gạch đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi PowerPoint sang PDF tiêu chuẩn sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides sẽ cố gắng chuyển đổi bản trình chiếu đã cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng cao nhất.

Mã dưới đây cho bạn thấy cách chuyển đổi một bản trình chiếu (PPT, PPTX, ODP, v.v.) sang PDF:

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Lưu bản trình chiếu dưới dạng PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 

Aspose cung cấp một [**trình chuyển đổi PowerPoint sang PDF**](https://products.aspose.app/slides/vi/conversion/ppt-to-pdf) trực tuyến miễn phí, cho phép bạn xem quy trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể thử nghiệm công cụ này để triển khai thực tế theo quy trình được mô tả ở đây.

{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/)—cho phép bạn tùy biến PDF đầu ra, khóa PDF bằng mật khẩu hoặc chỉ định cách quá trình chuyển đổi sẽ tiến hành.

### **Chuyển đổi PowerPoint sang PDF với Các tùy chọn tùy chỉnh**

Bằng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định thiết lập chất lượng mong muốn cho ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và nhiều hơn nữa.

Ví dụ mã dưới đây minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với một số tùy chọn tùy chỉnh.

```java
import com.aspose.slides.*;

// Khởi tạo lớp PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Đặt chất lượng cho ảnh JPG.
pdfOptions.setJpegQuality((byte)90);

// Đặt DPI cho ảnh.
pdfOptions.setSufficientResolution(300);

// Đặt hành vi cho metafile.
pdfOptions.setSaveMetafilesAsPng(true);

// Đặt mức nén văn bản cho nội dung văn bản.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Xác định chế độ tuân thủ PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // Lưu bản trình chiếu dưới dạng tài liệu PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Chuyển đổi PowerPoint sang PDF với Các slide ẩn**

Nếu bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) của lớp [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/) để bao gồm các slide ẩn dưới dạng trang trong PDF kết quả.

Mã dưới đây cho thấy cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với các slide ẩn được bao gồm:

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Khởi tạo lớp PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Thêm các slide ẩn.
    pdfOptions.setShowHiddenSlides(true);

    // Lưu bản trình chiếu dưới dạng PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Chuyển đổi PowerPoint sang PDF có Bảo vệ Mật khẩu**

Mã này minh họa cách chuyển đổi một bản trình chiếu PowerPoint thành PDF được bảo vệ mật khẩu bằng các tham số bảo vệ từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/):

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Khởi tạo lớp PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Đặt mật khẩu PDF và các quyền truy cập.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Lưu bản trình chiếu dưới dạng PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Phát hiện Thay thế Phông chữ**

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/), cho phép bạn phát hiện các trường hợp thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

Mã dưới đây cho thấy cách phát hiện thay thế phông chữ:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Đặt callback cảnh báo trong tùy chọn PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // Lưu bản trình chiếu dưới dạng PDF.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// Cài đặt callback cảnh báo.
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 

Để biết thêm thông tin về nhận callback cảnh báo cho việc thay thế phông chữ trong quá trình render, xem [Getting Warning Callbacks for Fonts Substitution](/slides/vi/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Để biết thêm về việc thay thế phông chữ, xem bài viết [Font Substitution](/slides/vi/java/font-substitution/).

{{% /alert %}} 

## **Chuyển đổi Các Slide Được Chọn trong PowerPoint sang PDF**

Mã này minh họa cách chuyển đổi chỉ các slide cụ thể trong một bản trình chiếu PowerPoint sang PDF:

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Đặt mảng các số slide.
    int[] slides = { 1, 3 };

    // Lưu bản trình chiếu dưới dạng PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi PowerPoint sang PDF với Kích thước Slide Tùy chỉnh**

Mã này minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với kích thước slide được chỉ định:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Tạo một bản trình chiếu mới với kích thước slide đã điều chỉnh.
Presentation resizedPresentation = new Presentation();

try {
    // Đặt kích thước slide tùy chỉnh.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // Sao chép slide đầu tiên từ bản trình chiếu gốc.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Xóa slide trống mà bản trình chiếu mới được tạo ra.
    resizedPresentation.getSlides().removeAt(1);

    // Lưu bản trình chiếu đã điều chỉnh kích thước dưới dạng PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Chuyển đổi PowerPoint sang PDF ở chế độ Xem Ghi chú Slide**

Mã này minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF bao gồm ghi chú:

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Cấu hình tùy chọn PDF với bố cục Ghi chú.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Lưu bản trình chiếu dưới dạng PDF có ghi chú.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Tiêu chuẩn Truy cập và Tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi đáp ứng các [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Mã dưới đây minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều tệp PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi các tệp PDF sang các định dạng phổ biến. Bạn có thể thực hiện các chuyển đổi [PDF sang HTML](https://products.aspose.com/slides/vi/java/conversion/pdf-to-html/), [PDF sang hình ảnh](https://products.aspose.com/slides/vi/java/conversion/pdf-to-image/), [PDF sang JPG](https://products.aspose.com/slides/vi/java/conversion/pdf-to-jpg/), và [PDF sang PNG](https://products.aspose.com/slides/vi/java/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt—[PDF sang SVG](https://products.aspose.com/slides/vi/java/conversion/pdf-to-svg/), [PDF sang TIFF](https://products.aspose.com/slides/vi/java/conversion/pdf-to-tiff/), và [PDF sang XML](https://products.aspose.com/slides/vi/java/conversion/pdf-to-xml/)—cũng được hỗ trợ.

{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các thành phần đường dẫn riêng lẻ không được giữ lại như nội dung riêng và có thể được đánh dấu là các artefact; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

### Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF cùng lúc không?

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể duyệt qua các tệp và áp dụng quy trình chuyển đổi bằng mã.

### Liệu có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?

Chắc chắn rồi. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

### Làm thế nào để bao gồm các slide ẩn trong PDF?

Sử dụng phương thức `setShowHiddenSlides` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

### Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng các phương thức như `setJpegQuality` và `setSufficientResolution` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/) để đảm bảo hình ảnh trong PDF có độ phân giải cao.

### Aspose.Slides có hỗ trợ các tiêu chuẩn PDF/A không?

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các [tiêu chuẩn khác nhau](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfcompliance/), bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng các yêu cầu về truy cập và lưu trữ.

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides for Java](/slides/vi/java/)
- [Tham chiếu API Aspose.Slides for Java](https://reference.aspose.com/slides/vi/java/)
- [Trình chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/vi/conversion)