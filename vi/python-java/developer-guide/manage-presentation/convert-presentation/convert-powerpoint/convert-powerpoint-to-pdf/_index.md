---
title: Chuyển đổi PPT và PPTX sang PDF trong Python qua Java [Bao gồm các tính năng nâng cao]
linktitle: PowerPoint sang PDF
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
description: "Chuyển đổi PowerPoint PPT/PPTX sang các tệp PDF chất lượng cao, có thể tìm kiếm trong Python qua Java sử dụng Aspose.Slides, kèm theo các ví dụ code nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi bài thuyết trình PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong Python thông qua Java mang lại một số lợi thế, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo tồn bố cục và định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi các bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện sự thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho các tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức [save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save). Lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) cung cấp phương thức [save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) thường được dùng để chuyển đổi một bản trình chiếu sang PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides cho Python thông qua Java chèn thông tin API và số phiên bản của nó vào các tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản trình chiếu sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Note** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi các tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể từ một bản trình chiếu sang PDF

Aspose.Slides xuất bản trình chiếu sang PDF, đảm bảo các tệp PDF đầu ra khớp chặt chẽ với bản trình chiếu gốc. Các phần tử và thuộc tính được render một cách chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi tiêu chuẩn sử dụng cài đặt xuất PDF mặc định. Sử dụng các tùy chọn tùy chỉnh khi bạn cần kiểm soát chất lượng hình ảnh, nội dung trang hoặc tiêu chuẩn tuân thủ PDF.

Cài đặt [Aspose.Slides for Python via Java](/slides/vi/python-java/installation/) và một môi trường Java tương thích trước khi chạy các ví dụ. Mỗi ví dụ đọc `presentation.pptx` từ thư mục làm việc hiện tại; thay thế nó bằng tệp PPT, PPTX hoặc ODP của bạn. Khởi động JVM một lần cho mỗi tiến trình Python.

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
Aspose cung cấp một công cụ chuyển đổi **PowerPoint sang PDF** miễn phí trực tuyến (https://products.aspose.app/slides/vi/conversion/ppt-to-pdf) để minh họa quy trình chuyển đổi từ bản trình chiếu sang PDF. Bạn có thể thực hiện thử nghiệm với công cụ này để xem việc thực hiện trực tiếp của quy trình mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/)—cho phép bạn tùy biến PDF đầu ra, khóa PDF bằng mật khẩu, hoặc chỉ định cách quá trình chuyển đổi sẽ được thực hiện.

### **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn Tùy Chỉnh**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định cài đặt chất lượng mong muốn cho hình raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và nhiều hơn nữa.

Đoạn mã dưới đây minh họa cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với một số tùy chọn tùy chỉnh.

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

Nếu một bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn dưới dạng trang trong PDF đầu ra.

Đoạn mã này cho thấy cách chuyển đổi một bản trình chiếu PowerPoint sang PDF với các slide ẩn được bao gồm:

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

### **Chuyển đổi PowerPoint sang PDF được Bảo Vệ Bằng Mật Khẩu**

Đoạn mã này minh họa cách chuyển đổi một bản trình chiếu PowerPoint thành PDF được bảo vệ bằng mật khẩu bằng cách sử dụng các tham số bảo vệ từ lớp [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/):

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

### **Phát Hiện Sự Thay Thế Phông Chữ**

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveoptions/#setWarningCallback) trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/), cho phép bạn phát hiện sự thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

Sử dụng proxy JPype để nhận các lời gọi lại cảnh báo từ API Java. Chuyển đổi chuỗi mô tả Java sang chuỗi Python trước khi kiểm tra tiền tố của nó:

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
Để biết thêm thông tin về nhận các lời gọi lại cảnh báo cho việc thay thế phông chữ trong quá trình render, hãy xem [Getting Warning Callbacks for Font Substitution](/slides/vi/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Để biết thêm thông tin về việc thay thế phông chữ, hãy xem bài viết [Font Substitution](/slides/vi/python-java/font-substitution/).
{{% /alert %}}

## **Chuyển Đổi Các Slide Được Chọn Trong PowerPoint sang PDF**

Các số slide được truyền vào [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) tính từ 1. Ví dụ này xuất các slide 1 và 3 khi cả hai đều tồn tại:

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

## **Chuyển đổi PowerPoint sang PDF trong chế độ xem Slide Ghi chú**

Đoạn mã này minh họa cách chuyển đổi một bản trình chiếu PowerPoint thành PDF có bao gồm ghi chú:

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

Khi chuẩn bị các tệp PDF có khả năng truy cập, hãy tham khảo [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Sử dụng [PdfOptions.setCompliance](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setCompliance) để chọn tiêu chuẩn đầu ra: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã này minh họa một quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều tệp PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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

> **Note:** Khi xuất ra PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các thành phần đường dẫn riêng lẻ không được giữ lại dưới dạng nội dung độc lập và có thể bị đánh dấu là artifact; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu Hỏi Thường Gặp**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF hàng loạt không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp của mình và áp dụng quy trình chuyển đổi một cách lập trình.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm cách nào để bao gồm các slide ẩn trong PDF?**

Sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF đầu ra.

**Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng cách sử dụng các phương thức như [setJpegQuality](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setJpegQuality) và [setSufficientResolution](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setSufficientResolution) trong lớp [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/) để đảm bảo hình ảnh chất lượng cao trong PDF của bạn.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ với [các tiêu chuẩn khác nhau](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfcompliance/), bao gồm PDF/A1a, PDF/A1b và PDF/UA, phục vụ cho khả năng truy cập hoặc lưu trữ. Chọn tiêu chuẩn phù hợp và kiểm tra kết quả dựa trên yêu cầu của bạn.

## **Tài Nguyên Bổ Sung**

- [Tài liệu Aspose.Slides cho Python thông qua Java](/slides/vi/python-java/)
- [Tham chiếu API Aspose.Slides cho Python thông qua Java](https://reference.aspose.com/slides/vi/python-java/)
- [Trình chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/vi/conversion)