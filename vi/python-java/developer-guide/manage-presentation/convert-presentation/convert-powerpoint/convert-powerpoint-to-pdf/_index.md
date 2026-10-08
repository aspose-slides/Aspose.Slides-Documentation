---
title: "Chuyển đổi PPT và PPTX sang PDF trong Python qua Java [Bao gồm các tính năng nâng cao]"
linktitle: "PowerPoint sang PDF"
type: docs
weight: 40
url: /vi/python-java/convert-powerpoint-to-pdf/
keywords:
- "chuyển đổi PowerPoint"
- "chuyển đổi bài thuyết trình"
- "PowerPoint sang PDF"
- "bài thuyết trình sang PDF"
- "PPT sang PDF"
- "chuyển đổi PPT sang PDF"
- "PPTX sang PDF"
- "chuyển đổi PPTX sang PDF"
- "lưu PowerPoint dưới dạng PDF"
- "lưu PPT dưới dạng PDF"
- "lưu PPTX dưới dạng PDF"
- "xuất PPT sang PDF"
- "xuất PPTX sang PDF"
- "tệp đính kèm"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Chuyển đổi PowerPoint PPT/PPTX sang PDF chất lượng cao, có thể tìm kiếm trong Python qua Java bằng Aspose.Slides, kèm theo các ví dụ mã nhanh và các tùy chọn chuyển đổi nâng cao."
---
## **Tổng quan**

Chuyển đổi các bài thuyết trình PowerPoint (PPT, PPTX, ODP, v.v.) sang định dạng PDF trong Python qua Java mang lại một số lợi ích, bao gồm khả năng tương thích trên các thiết bị khác nhau và bảo tồn bố cục và định dạng của bài thuyết trình. Hướng dẫn này trình bày cách chuyển đổi bài thuyết trình thành tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo mật PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bài thuyết trình ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bài thuyết trình sang PDF, truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) và sau đó lưu bài thuyết trình dưới dạng PDF bằng phương pháp [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). Lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) cung cấp phương pháp [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) mà thường được sử dụng để chuyển đổi một bài thuyết trình sang PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java chèn thông tin API và số phiên bản của nó vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bài thuyết trình sang PDF, Aspose.Slides điền trường Application với "*Aspose.Slides*" và trường PDF Producer với giá trị dạng "*Aspose.Slides v XX.XX*". **Lưu ý** rằng bạn không thể chỉ đạo Aspose.Slides thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bài thuyết trình sang PDF
* Các slide cụ thể từ một bài thuyết trình sang PDF

Aspose.Slides xuất các bài thuyết trình sang PDF, đảm bảo các tệp PDF kết quả khớp chặt chẽ với bài thuyết trình gốc. Các yếu tố và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các ô văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi chuẩn sử dụng các cài đặt xuất PDF mặc định. Sử dụng các tùy chọn tùy chỉnh khi bạn cần kiểm soát chất lượng hình ảnh, nội dung trang hoặc tuân thủ PDF.

Cài đặt [Aspose.Slides for Python via Java](/slides/vi/python-java/installation/) và một môi trường Java tương thích trước khi chạy các ví dụ. Mỗi ví dụ đọc tệp `presentation.pptx` từ thư mục làm việc hiện tại; thay thế nó bằng tệp PPT, PPTX hoặc ODP của bạn. Khởi động JVM một lần cho mỗi tiến trình Python.

Ví dụ sau tải một bài thuyết trình và lưu tất cả các slide hiển thị sang PDF bằng các cài đặt xuất mặc định.

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
Aspose cung cấp một bộ chuyển đổi trực tuyến miễn phí [**Bộ chuyển đổi PowerPoint sang PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) để minh họa quy trình chuyển đổi từ bài thuyết trình sang PDF. Bạn có thể thực hiện thử nghiệm với bộ chuyển đổi này cho việc triển khai thực tế của quy trình được mô tả ở đây.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các Tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính dưới lớp [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)—cho phép bạn tùy chỉnh PDF kết quả, khóa PDF bằng mật khẩu, hoặc chỉ định cách tiến trình chuyển đổi sẽ được thực hiện.

### **Chuyển đổi PowerPoint sang PDF với Các Tùy chọn Tùy chỉnh**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể xác định cài đặt chất lượng ưa thích cho hình ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, cấu hình DPI cho hình ảnh, và còn nhiều hơn nữa.

Ví dụ sau xuất một bài thuyết trình sang PDF 1.5 với chất lượng JPEG được đặt là 90, độ phân giải hình ảnh là 300 DPI, metafile được lưu dưới dạng PNG, và nén văn bản Flate.

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

### **Bảo tồn các tệp OLE nhúng dưới dạng tệp đính kèm PDF**

Nếu một bài thuyết trình chứa một workbook Excel nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu workbook cũng như xem các slide. Gọi [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) với `True` để bảo tồn các tệp OLE nhúng dưới dạng tệp đính kèm trong PDF kết quả.

Giá trị mặc định là `False`: hình ảnh hoặc biểu tượng xem trước của đối tượng OLE được hiển thị trên trang PDF, nhưng tệp nhúng của nó không được bao gồm như một tệp đính kèm. Đặt tùy chọn thành `True` sẽ bổ sung dữ liệu tệp. Bản xem trước vẫn là một biểu diễn hình ảnh; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE không trở thành một bảng tính Excel tương tác trên trang PDF.

Ví dụ sau tải một bài thuyết trình đã chứa workbook Excel nhúng và xuất nó sang PDF với workbook được đính kèm.

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

1. Mở PDF đã xuất trong một trình xem hỗ trợ tệp đính kèm, chẳng hạn Adobe Acrobat Reader.
2. Mở bảng **Attachments** của trình xem và tìm workbook nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Bản xem trước trên trang PDF tách biệt khỏi tệp đính kèm.

{{% alert color="info" title="Note" %}}
Tiêu chuẩn PDF/A áp đặt các hạn chế đối với tệp đính kèm: PDF/A-1 cấm tệp nhúng, PDF/A-2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm workbook Excel. Đây là yêu cầu của tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không minh họa việc xuất PDF/A.
{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với các Slide Ẩn**

Nếu một bài thuyết trình chứa các slide ẩn, bạn có thể sử dụng phương pháp [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) từ lớp [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn dưới dạng các trang trong PDF kết quả.

Ví dụ sau xuất một bài thuyết trình sang PDF, bao gồm bất kỳ slide ẩn nào.

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

### **Chuyển đổi PowerPoint sang PDF có Bảo mật Mật khẩu**

Ví dụ sau xuất một bài thuyết trình sang PDF yêu cầu mật khẩu `password` để mở. Các quyền truy cập cho phép in, bao gồm cả in chất lượng cao.

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

### **Phát hiện Thay thế Phông chữ**

Aspose.Slides cung cấp phương pháp [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) trong lớp [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) cho phép bạn phát hiện các trường hợp thay thế phông chữ trong quá trình chuyển đổi bài thuyết trình sang PDF.

Ví dụ sau xuất một bài thuyết trình sang PDF và in cảnh báo thay thế phông chữ ra console. Cảnh báo chỉ được in khi một phông chữ không có sẵn bị thay thế trong quá trình xuất. Sử dụng một proxy JPype để nhận các callback cảnh báo từ API Java. Chuyển chuỗi mô tả Java sang chuỗi Python trước khi kiểm tra tiền tố của nó:

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
Để biết thêm thông tin về thay thế phông chữ, xem bài viết [Thay thế Phông chữ](/slides/vi/python-java/font-substitution/).
{{% /alert %}}

### **Xử lý Phông chữ Không có Kiểu chữ Đậm Riêng**

Một bài thuyết trình có thể áp dụng định dạng đậm cho văn bản ngay cả khi phông chữ của nó không có kiểu chữ đậm riêng. Văn bản vẫn có thể xuất hiện đậm thông qua việc tạo đậm tổng hợp, làm dày các glyph thông thường một cách nhân tạo. Khi văn bản đó trông quá dày hoặc không giống như mong muốn trong PDF, hãy thử gọi [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) với `True`. Tùy chọn này sẽ render văn bản bị ảnh hưởng dưới dạng bitmap trong quá trình xuất PDF và có thể cải thiện ngoại hình của một số phông chữ. Giá trị mặc định là `False`.

Bài thuyết trình mẫu chứa hai ô văn bản: một ô có văn bản thường và một ô có định dạng đậm được áp dụng cho cùng một phông chữ, mà không có kiểu chữ đậm riêng. Ví dụ sau tải bài thuyết trình, kích hoạt rasterization cho các kiểu phông chữ không được hỗ trợ, và xuất nó sang PDF:

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

Các bản xem trước sau đây hiển thị đầu ra khi tùy chọn bị tắt và khi được bật. Trong ví dụ này, văn bản đậm có nét dày hơn khi tùy chọn bị tắt. Khi bật, nét của nó nhẹ hơn; văn bản thường không thay đổi. So sánh kết quả trước khi chọn cài đặt cho bài thuyết trình của bạn.

| Tùy chọn tắt (`False`, mặc định) | Tùy chọn bật (`True`) |
|---|---|
| ![PDF với rasterization kiểu phông chữ không hỗ trợ bị tắt](unsupported-bold-disabled.png) | ![PDF với rasterization kiểu phông chữ không hỗ trợ được bật](unsupported-bold-enabled.png) |

Trong ví dụ này, việc bật tùy chọn chỉ chuyển đổi văn bản đậm thành bitmap: nó không thể được chọn, sao chép hoặc tìm kiếm dưới dạng văn bản mà không có OCR, và các cạnh của nó trông mềm hơn ở mức phóng 800%. Văn bản thường vẫn có thể tìm kiếm. Khi tắt tùy chọn, cả hai chuỗi vẫn là văn bản.

Tùy chọn này rasterize văn bản được định dạng đậm khi phông chữ của nó không có kiểu chữ đậm riêng. [Thay thế Phông chữ](/slides/vi/python-java/font-substitution/) thay vào đó chọn một phông chữ khác khi phông chữ gốc không khả dụng.

## **Chuyển đổi các Slide Được Chọn từ PowerPoint sang PDF**

Các số slide được truyền vào [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) là đánh số bắt đầu từ 1. Ví dụ này xuất các slide 1 và 3 khi cả hai đều tồn tại:

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

## **Chuyển đổi PowerPoint sang PDF với Kích thước Slide Tùy chỉnh**

Ví dụ này xuất slide đầu tiên trên một trang có kích thước 612 x 792 điểm (US Letter). Nó sao chép slide vào một bài thuyết trình mới với kích thước đã chỉ định và điều chỉnh nội dung slide để vừa vặn.

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

    # Xóa slide trống mà bản trình bày mới được tạo ra.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Chuyển đổi PowerPoint sang PDF ở chế độ Xem Ghi chú Slide**

Ví dụ sau xuất một bài thuyết trình sang PDF, đặt ghi chú diễn giả của mỗi slide dưới slide. Sử dụng một bài thuyết trình có ghi chú diễn giả để xem kết quả.

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

## **Tiêu chuẩn Truy cập và Tuân thủ cho PDF**

Trong việc chuẩn bị PDF có khả năng truy cập, tham khảo [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Sử dụng [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) để chọn tiêu chuẩn đầu ra: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã này minh họa quy trình chuyển đổi PowerPoint sang PDF tạo ra nhiều PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại như nội dung riêng và có thể được đánh dấu là các phần dư; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi nhiều tệp PowerPoint sang PDF hàng loạt không?**

Đúng, Aspose.Slides hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT hoặc PPTX sang PDF. Bạn có thể lặp qua các tệp của mình và áp dụng quy trình chuyển đổi bằng chương trình.

**Có thể bảo mật PDF đã chuyển đổi bằng mật khẩu không?**

Đúng. Sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) để đặt mật khẩu và xác định quyền truy cập trong quá trình chuyển đổi.

**Làm sao để bao gồm các slide ẩn trong PDF?**

Gọi [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) với `True` trong lớp [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) để bao gồm các slide ẩn trong PDF kết quả.

**Aspose.Slides có thể giữ chất lượng hình ảnh cao trong PDF không?**

Đúng, bạn có thể kiểm soát chất lượng hình ảnh bằng cách sử dụng các phương pháp như [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) và [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) trong lớp [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) để đảm bảo hình ảnh chất lượng cao trong PDF của bạn.

**Aspose.Slides hỗ trợ các tiêu chuẩn tuân thủ PDF/A không?**

Đúng, Aspose.Slides cho phép bạn xuất PDF tuân thủ [các tiêu chuẩn khác nhau](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), bao gồm PDF/A1a, PDF/A1b và PDF/UA, cho mục đích truy cập hoặc lưu trữ. Chọn tiêu chuẩn phù hợp và kiểm tra đầu ra theo yêu cầu của bạn.

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides cho Python qua Java](/slides/vi/python-java/)
- [Tham chiếu API Aspose.Slides cho Python qua Java](https://reference.aspose.com/slides/python-java/)
- [Trình chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/conversion)