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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm trong Java bằng Aspose.Slides, kèm theo các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Việc chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong Java mang lại nhiều lợi ích, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo toàn bố cục cũng như định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu thuộc các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức `save`. Lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) cung cấp phương thức `save` thường được dùng để chuyển đổi bản trình chiếu sang PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides cho Java chèn thông tin API và số phiên bản của nó vào tài liệu đầu ra. Ví dụ, khi chuyển đổi bản trình chiếu sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Note** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc xóa thông tin này khỏi tài liệu đầu ra.

{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể trong một bản trình chiếu sang PDF

Aspose.Slides xuất bản trình chiếu sang PDF, đảm bảo các tệp PDF kết quả gần như khớp với bản trình chiếu gốc. Các yếu tố và thuộc tính được render một cách chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Liên kết siêu văn bản
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quy trình chuyển đổi chuẩn từ PowerPoint sang PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides sẽ cố gắng chuyển đổi bản trình chiếu đã cung cấp sang PDF bằng các thiết lập tối ưu ở mức chất lượng cao nhất.

Mã dưới đây cho thấy cách chuyển đổi một bản trình chiếu (PPT, PPTX, ODP, v.v.) sang PDF:

```java
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Lưu bản trình chiếu dưới dạng PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose cung cấp công cụ trực tuyến miễn phí **PowerPoint to PDF converter**(https://products.aspose.app/slides/vi/conversion/ppt-to-pdf) cho phép bạn xem quá trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể thử nghiệm với công cụ này để thực hiện quy trình đã mô tả ở đây.

{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/)—cho phép bạn tùy chỉnh PDF kết quả, khóa PDF bằng mật khẩu, hoặc chỉ định cách quá trình chuyển đổi sẽ diễn ra.

### **Chuyển đổi PowerPoint sang PDF với các tùy chọn tùy chỉnh**

Bằng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể định nghĩa cài đặt chất lượng mong muốn cho ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho ảnh, và nhiều hơn nữa.

Ví dụ mã dưới đây minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với một số tùy chọn tùy chỉnh.

```java
// Khởi tạo lớp PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Đặt chất lượng cho hình ảnh JPG.
pdfOptions.setJpegQuality((byte)90);

// Đặt DPI cho hình ảnh.
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

### **Chuyển đổi PowerPoint sang PDF với các slide ẩn**

Nếu một bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/) để bao gồm các slide ẩn dưới dạng các trang trong PDF kết quả.

Mã dưới đây cho thấy cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với các slide ẩn được bao gồm:

```java
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

### **Chuyển đổi PowerPoint sang PDF có bảo vệ bằng mật khẩu**

Mã này minh họa cách chuyển đổi một bản trình chiếu PowerPoint thành PDF có bảo vệ bằng mật khẩu bằng cách sử dụng các tham số bảo mật từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/):

```java
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Khởi tạo lớp PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Đặt mật khẩu PDF và quyền truy cập.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Lưu bản trình chiếu dưới dạng PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Phát hiện thay thế phông chữ**

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/), cho phép bạn phát hiện các thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

Mã dưới đây cho thấy cách phát hiện thay thế phông chữ:

```java
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

// Triển khai callback cảnh báo.
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

{{%  alert color="primary"  %}} 

Để biết thêm thông tin về nhận các callback cảnh báo cho việc thay thế phông chữ trong quá trình render, xem mục [Getting Warning Callbacks for Fonts Substitution](/slides/vi/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Để biết thêm thông tin về thay thế phông chữ, xem bài viết [Font Substitution](/slides/vi/java/font-substitution/).

{{% /alert %}} 

## **Chuyển đổi các slide được chọn trong PowerPoint sang PDF**

Mã này minh họa cách chuyển đổi chỉ các slide cụ thể từ một bản trình chiếu PowerPoint sang PDF:

```java
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Đặt mảng số slide.
    int[] slides = { 1, 3 };

    // Lưu bản trình chiếu dưới dạng PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi PowerPoint sang PDF với kích thước slide tùy chỉnh**

Mã này minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với kích thước slide được chỉ định:

```java
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

    // Lưu bản trình chiếu đã thay đổi kích thước sang PDF có ghi chú.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Chuyển đổi PowerPoint sang PDF trong chế độ xem ghi chú slide**

Mã này minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF bao gồm phần ghi chú:

```java
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Cấu hình các tùy chọn PDF với bố cục ghi chú.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Lưu bản trình chiếu sang PDF có ghi chú.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Tiêu chuẩn truy cập và tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ các **Web Content Accessibility Guidelines (WCAG)**(https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Mã dưới đây minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều tệp PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

```java
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

Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi các tệp PDF sang các định dạng phổ biến. Bạn có thể thực hiện các chuyển đổi [PDF to HTML](https://products.aspose.com/slides/vi/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/vi/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/vi/java/conversion/pdf-to-jpg/), và [PDF to PNG](https://products.aspose.com/slides/vi/java/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt khác—[PDF to SVG](https://products.aspose.com/slides/vi/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/vi/java/conversion/pdf-to-tiff/), và [PDF to XML](https://products.aspose.com/slides/vi/java/conversion/pdf-to-xml/)—cũng được hỗ trợ.

{{% /alert %}}

> **Note:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức dưới dạng một hình duy nhất. Các thành phần đường dẫn riêng lẻ không được giữ lại như nội dung riêng và có thể được đánh dấu là artifact; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF cùng lúc không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể duyệt qua các tệp và áp dụng quy trình chuyển đổi bằng lập trình.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Chắc chắn. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm sao để bao gồm các slide ẩn trong PDF?**

Sử dụng phương thức `setShowHiddenSlides` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng ảnh bằng các phương thức như `setJpegQuality` và `setSufficientResolution` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfoptions/) để đảm bảo hình ảnh trong PDF có chất lượng cao.

**Aspose.Slides có hỗ trợ các tiêu chuẩn PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các [tiêu chuẩn khác nhau](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pdfcompliance/), bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng yêu cầu truy cập và lưu trữ.

## **Tài nguyên bổ sung**

- [Aspose.Slides for Java Documentation](/slides/vi/java/)
- [Aspose.Slides for Java API Reference](https://reference.aspose.com/slides/vi/java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/vi/conversion)