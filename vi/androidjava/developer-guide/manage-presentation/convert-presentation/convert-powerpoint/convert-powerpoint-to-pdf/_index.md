---
title: Chuyển đổi PPT và PPTX sang PDF trên Android [Bao gồm tính năng nâng cao]
linktitle: PowerPoint sang PDF
type: docs
weight: 40
url: /vi/androidjava/convert-powerpoint-to-pdf/
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm trong Java sử dụng Aspose.Slides cho Android, với các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bài thuyết trình PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trên Android mang lại một số lợi ích, bao gồm khả năng tương thích trên các thiết bị khác nhau và duy trì bố cục cũng như định dạng của bài thuyết trình. Hướng dẫn này trình bày cách chuyển đổi bài thuyết trình sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện việc thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bài thuyết trình ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bài thuyết trình sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) và sau đó lưu bài thuyết trình dưới dạng PDF bằng phương thức `save`. Lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) cung cấp phương thức `save` thường được sử dụng để chuyển đổi bài thuyết trình sang PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for Android via Java chèn thông tin API và số phiên bản của nó vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bài thuyết trình sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc xóa thông tin này khỏi tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bài thuyết trình sang PDF
* Các slide cụ thể từ một bài thuyết trình sang PDF

Aspose.Slides xuất bài thuyết trình ra PDF, đảm bảo các PDF tạo ra gần giống với bản gốc. Các yếu tố và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi tiêu chuẩn PowerPoint sang PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides sẽ cố gắng chuyển đổi bài thuyết trình đã cung cấp sang PDF bằng các thiết lập tối ưu ở mức chất lượng tối đa.

Đoạn mã dưới đây cho bạn thấy cách chuyển đổi một bài thuyết trình (PPT, PPTX, ODP, v.v.) sang PDF:

```java
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Lưu bài thuyết trình dưới dạng PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 
Aspose cung cấp một công cụ chuyển đổi trực tuyến miễn phí [**PowerPoint sang PDF**](https://products.aspose.app/slides/vi/conversion/ppt-to-pdf) để minh họa quá trình chuyển đổi bài thuyết trình sang PDF. Bạn có thể thực hiện thử nghiệm với công cụ này để thấy việc triển khai thực tế của quy trình được mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/)—cho phép bạn tùy chỉnh PDF kết quả, khóa PDF bằng mật khẩu, hoặc chỉ định cách quá trình chuyển đổi sẽ tiến hành.

### **Chuyển đổi PowerPoint sang PDF với các tùy chọn tùy chỉnh**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định mức chất lượng mong muốn cho hình raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và hơn thế nữa.

Ví dụ mã dưới đây minh họa cách chuyển đổi một bài thuyết trình PowerPoint sang PDF với một số tùy chọn tùy chỉnh.

```java
// Khởi tạo lớp PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Đặt chất lượng cho hình JPG.
pdfOptions.setJpegQuality((byte)90);

// Đặt DPI cho hình ảnh.
pdfOptions.setSufficientResolution(300);

/// Đặt hành vi cho metafile.
pdfOptions.setSaveMetafilesAsPng(true);

// Đặt mức nén văn bản cho nội dung văn bản.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Xác định chế độ tuân thủ PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Lưu bài thuyết trình dưới dạng tài liệu PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Chuyển đổi PowerPoint sang PDF với các slide ẩn**

Nếu một bài thuyết trình chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/) để bao gồm các slide ẩn dưới dạng trang trong PDF kết quả.

Đoạn mã này cho thấy cách chuyển đổi một bài thuyết trình PowerPoint sang PDF kèm các slide ẩn được bao gồm:

```java
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Khởi tạo lớp PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Thêm các slide ẩn.
    pdfOptions.setShowHiddenSlides(true);

    // Lưu bài thuyết trình dưới dạng PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Chuyển đổi PowerPoint sang PDF được bảo vệ bằng mật khẩu**

Đoạn mã này minh họa cách chuyển đổi một bài thuyết trình PowerPoint sang PDF được bảo vệ bằng mật khẩu bằng cách sử dụng các tham số bảo vệ từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/):

```java
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Khởi tạo lớp PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Đặt mật khẩu PDF và các quyền truy cập.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Lưu bài thuyết trình dưới dạng PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Phát hiện việc thay thế phông chữ**

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/), giúp bạn phát hiện việc thay thế phông chữ trong quá trình chuyển đổi bài thuyết trình sang PDF.

Đoạn mã này cho thấy cách phát hiện việc thay thế phông chữ:

```java
public static void main(String[] args) {
    // Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Đặt callback cảnh báo trong tùy chọn PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Lưu bài thuyết trình dưới dạng PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
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
Để biết thêm thông tin về việc thay thế phông chữ, xem bài viết [Font Substitution](/slides/vi/androidjava/font-substitution/).
{{% /alert %}} 

## **Chuyển đổi các slide được chọn từ PowerPoint sang PDF**

Đoạn mã này minh họa cách chỉ chuyển đổi các slide cụ thể từ một bài thuyết trình PowerPoint sang PDF:

```java
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Đặt mảng các số slide.
    int[] slides = { 1, 3 };

    // Lưu bài thuyết trình dưới dạng PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi PowerPoint sang PDF với kích thước slide tùy chỉnh**

Đoạn mã này minh họa cách chuyển đổi một bài thuyết trình PowerPoint sang PDF với kích thước slide được chỉ định:

```java
float slideWidth = 612;
float slideHeight = 792;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Tạo một bài thuyết trình mới với kích thước slide đã điều chỉnh.
Presentation resizedPresentation = new Presentation();

try {
    // Đặt kích thước slide tùy chỉnh.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Sao chép slide đầu tiên từ bài thuyết trình gốc.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Lưu bài thuyết trình đã thay đổi kích thước sang PDF có ghi chú.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Chuyển đổi PowerPoint sang PDF trong chế độ xem ghi chú của slide**

Đoạn mã này minh họa cách chuyển đổi một bài thuyết trình PowerPoint sang PDF có bao gồm ghi chú:

```java
// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Cấu hình các tùy chọn PDF với bố cục ghi chú.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Lưu bài thuyết trình thành PDF có ghi chú.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Tiêu chuẩn truy cập và tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ các [Hướng dẫn về Truy cập Nội dung Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã này minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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
Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi các tệp PDF sang các định dạng tệp phổ biến. Bạn có thể thực hiện các chuyển đổi [PDF sang HTML](https://products.aspose.com/slides/vi/java/conversion/pdf-to-html/), [PDF sang hình ảnh](https://products.aspose.com/slides/vi/java/conversion/pdf-to-image/), [PDF sang JPG](https://products.aspose.com/slides/vi/java/conversion/pdf-to-jpg/), và [PDF sang PNG](https://products.aspose.com/slides/vi/java/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên dụng khác—[PDF sang SVG](https://products.aspose.com/slides/vi/java/conversion/pdf-to-svg/), [PDF sang TIFF](https://products.aspose.com/slides/vi/java/conversion/pdf-to-tiff/), và [PDF sang XML](https://products.aspose.com/slides/vi/java/conversion/pdf-to-xml/)—cũng được hỗ trợ.
{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại dưới dạng nội dung riêng và có thể được đánh dấu là hiện vật; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF hàng loạt không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp của mình và áp dụng quy trình chuyển đổi bằng lập trình.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Chắc chắn. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm sao để bao gồm các slide ẩn trong PDF?**

Sử dụng phương thức `setShowHiddenSlides` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng cách sử dụng các phương thức như `setJpegQuality` và `setSufficientResolution` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/) để đảm bảo hình ảnh chất lượng cao trong PDF của bạn.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các tiêu chuẩn khác nhau, bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng yêu cầu về truy cập và lưu trữ.

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides cho Android qua Java](/slides/vi/androidjava/)
- [Tham chiếu API Aspose.Slides cho Android qua Java](https://reference.aspose.com/slides/vi/androidjava/)
- [Công cụ chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/vi/conversion)