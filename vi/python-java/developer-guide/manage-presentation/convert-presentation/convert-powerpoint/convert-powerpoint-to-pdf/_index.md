---
title: Chuyển đổi PPT và PPTX sang PDF trong Python qua Java [Bao gồm các Tính năng Nâng cao]
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
- tệp đính kèm
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm trong Python qua Java bằng Aspose.Slides, kèm ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Việc chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong Python thông qua Java mang lại một số lợi thế, bao gồm khả năng tương thích trên các thiết bị khác nhau và việc bảo toàn bố cục và định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo mật PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi, và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF, truyền tên tệp như một đối số cho lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) , sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) cung cấp phương thức [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) thường được dùng để chuyển đổi bản trình chiếu sang PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides cho Python thông qua Java chèn thông tin API và số phiên bản của nó vào các tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản trình chiếu sang PDF, Aspose.Slides sẽ điền trường Application bằng "*Aspose.Slides*" và trường PDF Producer bằng giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi các tài liệu đầu ra.
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

Việc chuyển đổi tiêu chuẩn sử dụng các cài đặt xuất PDF mặc định. Sử dụng các tùy chọn tùy chỉnh khi bạn cần kiểm soát chất lượng hình ảnh, nội dung trang hoặc tuân thủ PDF.

Ví dụ sau tải một bản trình chiếu và lưu tất cả các slide có thể hiển thị sang PDF bằng các cài đặt xuất mặc định.

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
Aspose cung cấp một công cụ chuyển đổi **PowerPoint sang PDF** trực tuyến miễn phí([**Công cụ chuyển đổi PowerPoint sang PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf)) mô tả quá trình chuyển đổi bản trình chiếu sang PDF. Bạn có thể thực hiện thử nghiệm với công cụ này để triển khai thực tế quy trình được mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính dưới lớp [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)—cho phép bạn tùy biến PDF kết quả, khóa PDF bằng mật khẩu, hoặc chỉ định cách tiến trình chuyển đổi sẽ diễn ra.

### **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn Tùy Chỉnh**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định thiết lập chất lượng mong muốn cho hình raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và hơn thế nữa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Tự Động Chọn Nén Hình Ảnh**

Khi một bản trình chiếu chứa nhiều ảnh chụp hoặc screenshot, giảm kích thước PDF đã xuất có thể giúp việc gửi email hoặc tải xuống dễ dàng hơn. Gọi [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setBestImagesCompressionRatio) với `True` để tự động chọn thuật toán nén phù hợp nhất cho mỗi hình ảnh trong quá trình xuất PDF.

Ví dụ sau tải một bản trình chiếu hiện có, bật tự động chọn nén hình ảnh, và lưu nó dưới dạng tài liệu PDF. Tất cả các cài đặt xuất PDF khác vẫn giữ giá trị mặc định.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setBestImagesCompressionRatio(True)

presentation = Presentation("image-heavy.pptx")
try:
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Tùy chọn này chọn một thuật toán nén cho từng hình ảnh. Giảm giá trị truyền vào [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) thay vì giảm chất lượng ảnh JPEG, trong khi giảm giá trị truyền vào [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) cho phép giảm độ phân giải của ảnh, có thể giảm chi tiết. Bật tự động chọn nén không tự động giảm bất kỳ thiết lập nào trong hai trường hợp trên.

Việc chọn thuật toán nén hình ảnh yêu cầu thời gian xử lý và bộ nhớ bổ sung. Mức giảm kích thước phụ thuộc vào hình ảnh và cài đặt xuất của bản trình chiếu; không có mức giảm cố định cho mọi bản trình chiếu.

### **Giữ lại các tệp OLE nhúng dưới dạng tập tin đính kèm PDF**

Nếu một bản trình chiếu chứa một workbook Excel nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu workbook đồng thời xem các slide. Gọi [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) với `True` để giữ lại các tệp OLE nhúng dưới dạng tập tin đính kèm trong PDF kết quả.

Giá trị mặc định là `False`: hình ảnh hoặc biểu tượng xem trước của đối tượng OLE được hiển thị trên trang PDF, nhưng tệp nhúng không được bao gồm dưới dạng đính kèm. Đặt tùy chọn thành `True` sẽ bổ sung dữ liệu tệp. Bản xem trước vẫn là hình ảnh trực quan; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE sẽ không trở thành một bảng tính Excel tương tác trên trang PDF.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Để kiểm tra kết quả:

1. Mở file PDF đã xuất trong trình xem hỗ trợ tập tin đính kèm, chẳng hạn Adobe Acrobat Reader.
2. Mở bảng **Attachments** của trình xem và tìm workbook đã nhúng.
3. Lưu tập tin đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Bản xem trước trên trang PDF tách biệt với tập tin đính kèm.

{{% alert color="info" title="Note" %}}
Tiêu chuẩn PDF/A áp đặt các hạn chế đối với tập tin đính kèm: PDF/A-1 cấm các tệp nhúng, PDF/A-2 chỉ cho phép các tập tin đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm workbook Excel. Đây là yêu cầu của tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không trình bày xuất PDF/A.
{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với các Slide Ẩn**

Nếu một bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng phương thức [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) từ lớp [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn dưới dạng trang trong PDF kết quả.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Chuyển đổi PowerPoint sang PDF có Bảo Mật Mật Khẩu**

Ví dụ sau xuất một bản trình chiếu sang PDF yêu cầu mật khẩu `password` để mở. Các quyền truy cập cho phép in, bao gồm in chất lượng cao.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Phát Hiện Thay Thế Phông Chữ**

Aspose.Slides cung cấp phương thức [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) dưới lớp [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) , cho phép bạn phát hiện các trường hợp thay thế phông chữ trong quá trình chuyển đổi bản trình chiếu sang PDF.

Ví dụ sau xuất một bản trình chiếu sang PDF và in các cảnh báo thay thế phông chữ ra console. Cảnh báo chỉ được in khi một phông chữ không khả dụng bị thay thế trong quá trình xuất. Sử dụng proxy JPype để nhận các callback cảnh báo từ API Java. Chuyển chuỗi mô tả Java sang chuỗi Python trước khi kiểm tra tiền tố:

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


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Để biết thêm thông tin về việc thay thế phông chữ, xem bài viết [Thay Thế Phông Chữ](/slides/vi/python-java/font-substitution/).
{{% /alert %}}

### **Xử Lý Phông Chữ Không Có Kiểu Đậm Riêng**

Một bản trình chiếu có thể áp dụng định dạng đậm cho văn bản ngay cả khi phông chữ không có kiểu đậm riêng. Văn bản vẫn có thể hiển thị đậm thông qua việc tạo đậm tổng hợp, làm dày các glyph thường. Khi văn bản như vậy trông quá nặng hoặc không khớp với mong muốn trong PDF, hãy thử gọi [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) với `True`. Tùy chọn này render văn bản bị ảnh hưởng dưới dạng bitmap trong quá trình xuất PDF và có thể cải thiện việc hiển thị cho một số phông chữ. Giá trị mặc định là `False`.

Bản trình chiếu mẫu chứa hai hộp văn bản: một hộp có văn bản thường và một hộp có định dạng đậm áp dụng cho cùng một phông chữ, phông chữ này không có kiểu đậm riêng. Ví dụ sau tải bản trình chiếu, bật raster hóa các kiểu phông chữ không được hỗ trợ, và xuất nó sang PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Các preview sau đây cho thấy đầu ra khi tùy chọn tắt và khi bật. Trong ví dụ này, văn bản đậm có nét dày hơn khi tùy chọn tắt. Khi bật, nét của nó nhẹ hơn; văn bản thường không thay đổi. So sánh kết quả trước khi chọn cài đặt cho bản trình chiếu của bạn.

| Tùy chọn tắt (`False`, mặc định) | Tùy chọn bật (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Trong ví dụ này, bật tùy chọn chỉ chuyển đổi văn bản đậm thành bitmap: nó không thể được chọn, sao chép, hoặc tìm kiếm dưới dạng văn bản mà không có OCR, và các cạnh của nó xuất hiện mềm hơn ở độ phóng 800 %. Văn bản thường vẫn có thể tìm kiếm được. Khi tắt, cả hai chuỗi vẫn là văn bản.

Tùy chọn này raster hóa văn bản được định dạng đậm khi phông chữ không có kiểu đậm riêng. [Thay Thế Phông Chữ](/slides/vi/python-java/font-substitution/) thay vào đó sẽ chọn một phông chữ khác khi phông chữ gốc không khả dụng.

## **Chuyển Đổi Các Slide Được Chọn Từ PowerPoint Sang PDF**

Số slide truyền vào [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) bắt đầu từ 1. Ví dụ này xuất các slide 1 và 3 khi cả hai tồn tại:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Chuyển Đổi PowerPoint Sang PDF với Kích Thước Slide Tùy Chỉnh**

Ví dụ này xuất slide đầu tiên trên một trang có kích thước 612 × 792 điểm (US Letter). Nó sao chép slide vào một bản trình chiếu mới với kích thước đã chỉ định và thu phóng nội dung slide để vừa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # Xóa slide trống mà bản trình chiếu mới được tạo ra.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Chuyển Đổi PowerPoint Sang PDF trong chế độ Xem Ghi Chú Slide**

Ví dụ sau xuất một bản trình chiếu sang PDF, đặt ghi chú của người thuyết trình cho mỗi slide dưới slide. Sử dụng một bản trình chiếu có ghi chú để thấy kết quả.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Tiêu Chuẩn Truy Cập và Tuân Thủ cho PDF**

Khi chuẩn bị các PDF có thể truy cập, tham khảo [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Sử dụng [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) để chọn tiêu chuẩn đầu ra: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Mã này minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại dưới dạng nội dung riêng và có thể được đánh dấu là artefact; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF hàng loạt không?**

Có, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp và áp dụng quy trình chuyển đổi bằng mã.

**Có thể bảo vệ PDF đã chuyển đổi bằng mật khẩu không?**

Có. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm thế nào để bao gồm các slide ẩn trong PDF?**

Gọi [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) với `True` trong lớp [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có thể duy trì chất lượng hình ảnh cao trong PDF không?**

Có, bạn có thể kiểm soát chất lượng hình ảnh bằng cách sử dụng các phương thức như [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) và [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) trong lớp [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) để đảm bảo hình ảnh có chất lượng cao trong PDF của bạn.

**Aspose.Slides có hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Có, Aspose.Slides cho phép bạn xuất PDF tuân thủ với [các tiêu chuẩn](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) bao gồm PDF/A1a, PDF/A1b và PDF/UA, phù hợp cho khả năng truy cập hoặc lưu trữ. Hãy chọn tiêu chuẩn phù hợp và kiểm tra đầu ra theo yêu cầu của bạn.

## **Tài Nguyên Bổ Sung**

- [Tài liệu Aspose.Slides cho Python qua Java](/slides/vi/python-java/)
- [Tham chiếu API Aspose.Slides cho Python qua Java](https://reference.aspose.com/slides/python-java/)
- [Công cụ chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/conversion)