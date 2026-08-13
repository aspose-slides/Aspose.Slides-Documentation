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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm trong Java bằng Aspose.Slides cho Android, kèm ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trên Android mang lại nhiều lợi thế, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo toàn bố cục cùng định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo mật PDF bằng mật khẩu, phát hiện thay thế phông chữ, lựa chọn các slide cụ thể để chuyển đổi, và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu dưới các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức `save`. Lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) cung cấp phương thức `save` thường được sử dụng để chuyển đổi bản trình chiếu sang PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for Android via Java chèn thông tin API và số phiên bản của nó vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản trình chiếu sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc xóa thông tin này khỏi tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể từ một bản trình chiếu sang PDF

Aspose.Slides xuất bản trình chiếu sang PDF, đảm bảo các PDF kết quả gần giống với bản trình chiếu gốc. Các yếu tố và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Liên kết siêu văn bản
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi chuẩn từ PowerPoint sang PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides sẽ cố gắng chuyển đổi bản trình chiếu được cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng tối đa.

Mã này cho bạn thấy cách chuyển đổi một bản trình chiếu (PPT, PPTX, ODP, v.v.) sang PDF:

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Lưu bản trình chiếu dưới dạng PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 
Aspose cung cấp một **trình chuyển đổi PowerPoint sang PDF**(https://products.aspose.app/slides/vi/conversion/ppt-to-pdf) miễn phí trực tuyến, diễn giải quá trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể chạy thử nghiệm với trình chuyển đổi này để thực hiện thực tế quy trình được mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính dưới lớp [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/)—cho phép bạn tùy biến PDF đầu ra, khóa PDF bằng mật khẩu, hoặc chỉ định cách thức tiến trình chuyển đổi sẽ diễn ra.

### **Chuyển đổi PowerPoint sang PDF với Tùy Chọn Tùy Chỉnh**

Bằng cách sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể định nghĩa thiết lập chất lượng mong muốn cho hình ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và nhiều hơn nữa.

Mã ví dụ bên dưới minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với một số tùy chọn tùy chỉnh.

```java
import com.aspose.slides.*;

// Khởi tạo lớp PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Đặt chất lượng cho hình ảnh JPG.
pdfOptions.setJpegQuality((byte)90);

// Đặt DPI cho hình ảnh.
pdfOptions.setSufficientResolution(300);

/// Đặt hành vi cho metafiles.
pdfOptions.setSaveMetafilesAsPng(true);

// Đặt mức nén văn bản cho nội dung văn bản.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Xác định chế độ tuân thủ PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Lưu bản trình chiếu dưới dạng tài liệu PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Chuyển đổi PowerPoint sang PDF với Các Slide Ẩn**

Nếu một bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/) để bao gồm các slide ẩn dưới dạng trang trong PDF kết quả.

Mã này cho thấy cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với các slide ẩn được bao gồm:

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
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

### **Chuyển đổi PowerPoint sang PDF Bảo Mật Mật Khẩu**

Mã này minh họa cách chuyển đổi một bản trình chiếu PowerPoint thành PDF được bảo mật bằng mật khẩu bằng cách sử dụng các tham số bảo vệ từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/):

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
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

### **Phát Hiện Thay Thế Phông Chữ**

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) dưới lớp [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/), cho phép bạn phát hiện các thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

Mã này cho thấy cách phát hiện các thay thế phông chữ:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
    Presentation presentation = new Presentation("sample.pptx");

    // Đặt callback cảnh báo trong tùy chọn PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Lưu bản trình chiếu dưới dạng PDF.
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

{{%  alert color="info"  %}} 
Để biết thêm thông tin về việc thay thế phông chữ, xem bài viết [Font Substitution](/slides/vi/androidjava/font-substitution/).
{{% /alert %}} 

## **Chuyển đổi Các Slide Được Chọn từ PowerPoint sang PDF**

Mã này minh họa cách chỉ chuyển đổi các slide cụ thể từ một bản trình chiếu PowerPoint sang PDF:

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

## **Chuyển đổi PowerPoint sang PDF với Kích Thước Slide Tùy Chỉnh**

Mã này minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với kích thước slide được chỉ định:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Tạo một bản trình chiếu mới với kích thước slide được điều chỉnh.
Presentation resizedPresentation = new Presentation();

try {
    // Đặt kích thước slide tùy chỉnh.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Sao chép slide đầu tiên từ bản trình chiếu gốc.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Xóa slide trống mà bản trình chiếu mới được tạo ra.
    resizedPresentation.getSlides().removeAt(1);

    // Lưu bản trình chiếu đã thay đổi kích thước dưới dạng PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Chuyển đổi PowerPoint sang PDF trong chế độ Ghi chú Slide**

Mã này minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF có bao gồm ghi chú:

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument file.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Cấu hình các tùy chọn PDF với bố cục ghi chú.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Lưu bản trình chiếu thành PDF có ghi chú.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Tiêu Chuẩn Truy Cập và Tuân Thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ các [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Mã này minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều tệp PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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
Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF, cho phép bạn chuyển đổi các tệp PDF sang các định dạng phổ biến. Bạn có thể thực hiện các chuyển đổi [PDF to HTML](https://products.aspose.com/slides/vi/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/vi/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/vi/java/conversion/pdf-to-jpg/), và [PDF to PNG](https://products.aspose.com/slides/vi/java/conversion/pdf-to-png/) . Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt—[PDF to SVG](https://products.aspose.com/slides/vi/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/vi/java/conversion/pdf-to-tiff/), và [PDF to XML](https://products.aspose.com/slides/vi/java/conversion/pdf-to-xml/)—cũng được hỗ trợ.
{{% /alert %}}

> **Lưu ý:** Khi xuất ra PDF/UA, Aspose.Slides coi các đồ họa phức tạp như SmartArt, biểu đồ và công thức là một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại dưới dạng nội dung riêng và có thể được đánh dấu là hiện vật; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

### Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF hàng loạt không?

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp của mình và áp dụng quá trình chuyển đổi bằng chương trình.

### Có thể bảo mật bằng mật khẩu cho PDF đã chuyển đổi không?

Chắc chắn. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

### Làm sao để bao gồm các slide ẩn trong PDF?

Sử dụng phương thức `setShowHiddenSlides` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

### Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng cách sử dụng các phương thức như `setJpegQuality` và `setSufficientResolution` trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pdfoptions/) để đảm bảo hình ảnh chất lượng cao trong PDF của bạn.

### Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ các tiêu chuẩn khác nhau, bao gồm PDF/A1a, PDF/A1b và PDF/UA, đảm bảo tài liệu của bạn đáp ứng yêu cầu về khả năng truy cập và lưu trữ.

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides cho Android qua Java](/slides/vi/androidjava/)
- [Tham chiếu API Aspose.Slides cho Android qua Java](https://reference.aspose.com/slides/vi/androidjava/)
- [Bộ chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/vi/conversion)