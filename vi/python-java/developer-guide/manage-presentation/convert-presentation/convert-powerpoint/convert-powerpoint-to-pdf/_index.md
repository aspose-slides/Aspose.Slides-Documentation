---
title: "Chuyển đổi PPT và PPTX sang PDF trong Python qua Java [Bao gồm các tính năng nâng cao]"
linktitle: "PowerPoint sang PDF"
type: docs
weight: 40
url: /vi/python-java/convert-powerpoint-to-pdf/
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
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm trong Python qua Java bằng Aspose.Slides, kèm các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong Python thông qua Java mang lại một số lợi ích, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo toàn bố cục cùng định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu thành tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi, và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức [save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save). Lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) cung cấp phương thức [save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) thường được sử dụng để chuyển đổi bản trình chiếu sang PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java chèn thông tin API và số phiên bản của nó vào các tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản trình chiếu sang PDF, Aspose.Slides sẽ khai báo trường Application là "*Aspose.Slides*" và trường PDF Producer với giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc xóa thông tin này khỏi các tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể từ một bản trình chiếu sang PDF

Aspose.Slides xuất bản trình chiếu sang PDF, đảm bảo các tệp PDF kết quả gần giống với bản trình chiếu gốc. Các thành phần và thuộc tính được hiển thị một cách chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Đầu trang và chân trang
* Đầu mục
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi chuẩn sử dụng các thiết lập xuất PDF mặc định. Sử dụng các tùy chọn tùy chỉnh khi bạn cần kiểm soát chất lượng hình ảnh, nội dung trang, hoặc tiêu chuẩn PDF.

Cài đặt [Aspose.Slides for Python via Java](/slides/vi/python-java/installation/) và một môi trường chạy Java tương thích trước khi chạy các ví dụ. Mỗi ví dụ đọc tệp `presentation.pptx` từ thư mục làm việc hiện tại; hãy thay thế nó bằng tệp PPT, PPTX hoặc ODP của bạn. Khởi động JVM một lần cho mỗi tiến trình Python.

Đoạn mã này chuyển đổi một bản trình chiếu sang PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose cung cấp một công cụ chuyển đổi [**PowerPoint sang PDF**](https://products.aspose.app/slides/vi/conversion/ppt-to-pdf) miễn phí trực tuyến, cho phép bạn xem quá trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể chạy thử công cụ này để thực hiện trực tiếp quy trình được mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/)—cho phép bạn tùy biến PDF kết quả, khóa PDF bằng mật khẩu, hoặc chỉ định cách thực hiện quá trình chuyển đổi.

### **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn Tùy Chỉnh**

Bằng cách sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định cài đặt chất lượng mong muốn cho hình ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và nhiều hơn nữa.

Ví dụ mã dưới đây minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với một số tùy chọn tùy chỉnh.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Chuyển đổi PowerPoint sang PDF với Các Slide Ẩn**

Nếu một bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) của lớp [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/) để đưa các slide ẩn vào dưới dạng các trang trong PDF kết quả.

Đoạn mã này cho thấy cách chuyển đổi một bản trình chiếu PowerPoint sang PDF có bao gồm các slide ẩn:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Chuyển đổi PowerPoint sang PDF có Bảo Vệ Mật Khẩu**

Đoạn mã này minh họa cách chuyển đổi một bản trình chiếu PowerPoint thành PDF có bảo vệ mật khẩu bằng cách sử dụng các tham số bảo vệ từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Phát Hiện Thay Thế Phông Chữ**

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveoptions/#setWarningCallback) trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/), cho phép bạn phát hiện các trường hợp thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

Sử dụng proxy JPype để nhận các callback cảnh báo từ API Java. Chuyển đổi chuỗi mô tả Java sang chuỗi Python trước khi kiểm tra tiền tố của nó:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Để biết thêm thông tin về việc nhận callback cho các trường hợp thay thế phông chữ trong quá trình render, xem [Getting Warning Callbacks for Fonts Substitution](/slides/vi/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Để biết thêm thông tin về việc thay thế phông chữ, xem bài viết [Font Substitution](/slides/vi/python-java/font-substitution/).
{{% /alert %}}

## **Chuyển đổi Các Slide Được Chọn trong PowerPoint sang PDF**

Các số slide truyền vào phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) là đếm từ 1. Ví dụ này xuất các slide 1 và 3 khi chúng tồn tại:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **Chuyển đổi PowerPoint sang PDF với Kích Thước Slide Tùy Chỉnh**

Ví dụ này xuất slide đầu tiên trên một trang có kích thước 612 x 792 điểm (US Letter). Nó sao chép slide vào một bản trình chiếu mới với kích thước đã chỉ định:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **Chuyển đổi PowerPoint sang PDF trong Chế Độ Xem Ghi Chú Slide**

Đoạn mã này minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF có bao gồm ghi chú:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Tiêu Chuẩn Truy Cập và Tuân Thủ cho PDF**

Khi chuẩn bị các tệp PDF có thể truy cập, hãy tham khảo [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Sử dụng [PdfOptions.setCompliance](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setCompliance) để chọn tiêu chuẩn đầu ra: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã này minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều tệp PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại dưới dạng nội dung riêng và có thể được đánh dấu là hiện tượng phụ; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu Hỏi Thường Gặp**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF hàng loạt không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp của mình và áp dụng quy trình chuyển đổi một cách lập trình.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/) để đặt mật khẩu và xác định các quyền truy cập trong quá trình chuyển đổi.

**Làm thế nào để bao gồm các slide ẩn trong PDF?**

Sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng cách sử dụng các phương thức như [setJpegQuality](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setJpegQuality) và [setSufficientResolution](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setSufficientResolution) trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/) để đảm bảo hình ảnh chất lượng cao trong PDF của bạn.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ [các tiêu chuẩn khác nhau](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfcompliance/), bao gồm PDF/A1a, PDF/A1b và PDF/UA, để đáp ứng nhu cầu truy cập hoặc lưu trữ. Hãy chọn tiêu chuẩn phù hợp và kiểm tra kết quả so với yêu cầu của bạn.

## **Tài Nguyên Bổ Sung**

- [Tài liệu Aspose.Slides cho Python qua Java](/slides/vi/python-java/)
- [Tham chiếu API Aspose.Slides cho Python qua Java](https://reference.aspose.com/slides/vi/python-java/)
- [Công cụ chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/vi/conversion)