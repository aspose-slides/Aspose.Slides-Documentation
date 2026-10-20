---
title: Chuyển đổi PPT & PPTX sang PDF trong Python | Tùy chọn nâng cao
linktitle: PowerPoint sang PDF
type: docs
weight: 40
url: /vi/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- chuyển đổi PowerPoint
- bản trình chiếu
- PowerPoint sang PDF
- PPT sang PDF
- PPTX sang PDF
- lưu PowerPoint dưới dạng PDF
- tệp đính kèm
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Hướng dẫn chi tiết từng bước để chuyển đổi PPT, PPTX và ODP sang PDF chất lượng cao, tuân thủ WCAG trong Python với Aspose.Slides — bao gồm bảo mật bằng mật khẩu, lựa chọn slide và kiểm soát chất lượng hình ảnh."
showReadingTime: true
---
## **Tổng quan**

Việc chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX, ODP) sang định dạng PDF trong Python mang lại một số lợi ích, bao gồm đảm bảo khả năng tương thích trên các thiết bị khác nhau và bảo tồn bố cục cũng như định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện việc thay thế phông chữ, chọn các slide cụ thể để chuyển đổi, và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng này sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF trong Python, bạn chỉ cần truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) cung cấp phương thức [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) thường được sử dụng để chuyển đổi bản trình chiếu sang PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python chèn thông tin API và số phiên bản của nó vào các tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản trình chiếu sang PDF, Aspose.Slides for Python sẽ điền trường Application bằng giá trị '*Aspose.Slides*' và trường PDF Producer bằng giá trị dạng '*Aspose.Slides v XX.XX*'. **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides for Python thay đổi hoặc xóa thông tin này khỏi các tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể trong một bản trình chiếu sang PDF

Aspose.Slides xuất bản trình chiếu sang PDF, đảm bảo nội dung của các PDF tạo ra gần giống với bản trình chiếu gốc. Các yếu tố và thuộc tính được render một cách chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn
* Liên kết siêu văn bản
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi chuẩn từ PowerPoint sang PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides sẽ cố gắng chuyển đổi bản trình chiếu đã cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng cao nhất.

Ví dụ sau tải một bản trình chiếu và lưu tất cả các slide hiển thị sang PDF bằng các cài đặt xuất mặc định.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose cung cấp một công cụ chuyển đổi [**PowerPoint sang PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) trực tuyến miễn phí, cho thấy quy trình chuyển đổi bản trình chiếu sang PDF. Để thực hiện việc chuyển đổi thực tế theo mô tả ở đây, bạn có thể thử nghiệm với công cụ này.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh — các thuộc tính thuộc lớp [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) — cho phép bạn tùy chỉnh PDF (kết quả của quá trình chuyển đổi), khóa PDF bằng mật khẩu, hoặc thậm chí chỉ định cách thức thực hiện quá trình chuyển đổi.

### **Chuyển đổi PowerPoint sang PDF với các tùy chọn tùy chỉnh**

Sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể đặt mức chất lượng mong muốn cho ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, đặt DPI cho ảnh, v.v.

Ví dụ sau xuất một bản trình chiếu sang PDF 1.5 với chất lượng JPEG đặt là 90, độ phân giải ảnh đặt là 300 DPI, metafile được lưu dưới dạng PNG và nén văn bản Flate.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Tự động chọn nén hình ảnh**

Khi một bản trình chiếu chứa nhiều ảnh chụp hoặc ảnh chụp màn hình, việc giảm kích thước PDF xuất ra có thể giúp việc gửi email hoặc tải xuống dễ hơn. Đặt [PdfOptions.best_images_compression_ratio](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) thành `True` để tự động chọn thuật toán nén phù hợp nhất cho mỗi ảnh khi xuất PDF.

Ví dụ sau tải một bản trình chiếu hiện có, bật tính năng chọn nén ảnh tự động, và lưu nó dưới dạng tài liệu PDF. Tất cả các cài đặt xuất PDF khác giữ nguyên giá trị mặc định.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.best_images_compression_ratio = True

with slides.Presentation("image-heavy.pptx") as presentation:
    presentation.save("image-heavy.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Tùy chọn này chọn một thuật toán nén cho mỗi ảnh. Giảm giá trị [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) sẽ làm giảm chất lượng ảnh JPEG, trong khi giảm [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) cho phép ảnh được giảm mẫu sang độ phân giải thấp hơn, có thể giảm chi tiết. Bật tính năng chọn nén tự động không làm giảm bất kỳ cài đặt nào trong số này.

Việc lựa chọn thuật toán nén ảnh yêu cầu thời gian xử lý và bộ nhớ bổ sung. Mức giảm kích thước phụ thuộc vào các ảnh trong bản trình chiếu và cài đặt xuất; không đảm bảo giảm cố định cho mọi bản trình chiếu.

### **Bảo tồn các tệp OLE nhúng dưới dạng tệp đính kèm PDF**

Nếu một bản trình chiếu chứa một workbook Excel được nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu của workbook đó cùng với việc xem các slide. Đặt [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) thành `True` để bảo tồn các tệp OLE nhúng dưới dạng tệp đính kèm trong PDF tạo ra.

Giá trị mặc định là `False`: hình ảnh hoặc biểu tượng xem trước của đối tượng OLE được render trên trang PDF, nhưng tệp nhúng không được đưa vào dưới dạng tệp đính kèm. Đặt tùy chọn này thành `True` sẽ bổ sung dữ liệu tệp. Hình ảnh xem trước vẫn là một biểu diễn trực quan; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE không biến thành một worksheet Excel tương tác trên trang PDF.

Ví dụ sau tải một bản trình chiếu đã chứa một workbook Excel nhúng và xuất nó sang PDF với workbook đính kèm.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Để kiểm tra kết quả:

1. Mở PDF đã xuất trong một trình xem hỗ trợ tệp đính kèm, chẳng hạn Adobe Acrobat Reader.
2. Mở bảng **Attachments** của trình xem và tìm workbook đã nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Hình ảnh xem trước trên trang PDF tách biệt với tệp đính kèm.

{{% alert color="info" title="Note" %}}
Tiêu chuẩn PDF/A đặt ra các hạn chế đối với tệp đính kèm: PDF/A-1 cấm tệp nhúng, PDF/A-2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm workbook Excel. Đây là yêu cầu của tiêu chuẩn, không phải hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không trình diễn việc xuất PDF/A.
{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với các slide ẩn**

Nếu một bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng tùy chọn tùy chỉnh — thuộc tính [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) từ lớp [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) — để yêu cầu Aspose.Slides bao gồm các slide ẩn dưới dạng các trang trong PDF tạo ra.

Ví dụ sau xuất một bản trình chiếu sang PDF, bao gồm bất kỳ slide ẩn nào.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Chuyển đổi PowerPoint sang PDF có bảo vệ bằng mật khẩu**

Ví dụ sau xuất một bản trình chiếu sang PDF yêu cầu mật khẩu `password` để mở. Quyền truy cập cho phép in, bao gồm cả in chất lượng cao.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Xử lý phông chữ không có kiểu chữ đậm riêng**

Một bản trình chiếu có thể áp dụng định dạng đậm cho văn bản ngay cả khi phông chữ của nó không có kiểu chữ đậm riêng. Văn bản vẫn có thể hiển thị đậm thông qua việc tạo đậm tổng hợp, tức là làm dày các glyph thông thường một cách nhân tạo. Khi văn bản đó trông quá nặng hoặc không giống như mong muốn trong PDF, hãy thử đặt [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) thành `True`. Tùy chọn này sẽ render văn bản bị ảnh hưởng dưới dạng bitmap khi xuất PDF và có thể cải thiện diện mạo của nó cho một số phông chữ. Giá trị mặc định là `False`.

Bản trình chiếu mẫu chứa hai hộp văn bản: một với văn bản thường và một với định dạng đậm áp dụng cho cùng một phông chữ, phông chữ này không có kiểu chữ đậm riêng. Ví dụ sau tải bản trình chiếu, bật rasterization cho các kiểu chữ không hỗ trợ, và xuất nó sang PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Bản xem trước dưới đây hiển thị kết quả khi tắt và khi bật. Trong ví dụ này, văn bản đậm có nét đậm hơn khi tùy chọn bị tắt. Khi tùy chọn được bật, nét của nó nhẹ hơn; văn bản thường không thay đổi. Hãy so sánh kết quả trước khi lựa chọn cài đặt cho bản trình chiếu của bạn.

| Tùy chọn bị tắt (`False`, mặc định) | Tùy chọn được bật (`True`) |
|---|---|
| ![PDF với rasterization phông không hỗ trợ bị tắt](unsupported-bold-disabled.png) | ![PDF với rasterization phông không hỗ trợ được bật](unsupported-bold-enabled.png) |

Trong ví dụ này, bật tùy chọn sẽ biến chỉ văn bản đậm thành bitmap: nó không thể được chọn, sao chép hoặc tìm kiếm dưới dạng văn bản nếu không có OCR, và các cạnh của nó trông mềm hơn ở mức phóng 800%. Văn bản thường vẫn có thể tìm kiếm. Khi tùy chọn bị tắt, cả hai chuỗi vẫn là văn bản.

Tùy chọn này rasterize văn bản được định dạng đậm khi phông chữ của nó không có kiểu chữ đậm riêng. [Thay thế phông chữ](/slides/vi/python-net/font-substitution/) thay vào đó sẽ chọn một phông chữ khác khi phông gốc không có sẵn.

## **Chuyển đổi các slide đã chọn trong PowerPoint sang PDF**

Ví dụ sau xuất các slide 1 và 3 từ một bản trình chiếu sang PDF. Các số slide trong mảng này bắt đầu từ 1, và bản trình chiếu đầu vào phải có ít nhất ba slide.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Chuyển đổi PowerPoint sang PDF với kích thước slide tùy chỉnh**

Ví dụ sau sao chép slide đầu tiên từ một bản trình chiếu vào một bản trình chiếu mới với kích thước slide là 612 × 792 điểm (8.5 × 11 inch). Nó thu phóng nội dung slide để vừa và xuất slide đơn lẻ sang PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Xóa slide trống mà bản trình chiếu mới được tạo ra.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Chuyển đổi PowerPoint sang PDF ở chế độ xem ghi chú slide**

Ví dụ sau xuất một bản trình chiếu sang PDF, đặt ghi chú của mỗi slide phía dưới slide. Sử dụng một bản trình chiếu có ghi chú người nói để xem kết quả.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Tiêu chuẩn truy cập và tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Mã Python này minh họa một thao tác chuyển đổi PowerPoint sang PDF trong đó nhiều PDF dựa trên các tiêu chuẩn tuân thủ khác nhau được tạo ra:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert color="info" title="Note" %}}
Hỗ trợ chuyển đổi PDF của Aspose.Slides cho phép bạn chuyển đổi PDF sang các định dạng tệp phổ biến nhất. Bạn có thể thực hiện các chuyển đổi [PDF sang HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF sang hình ảnh](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF sang JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), và [PDF sang PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt — [PDF sang SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF sang TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), và [PDF sang XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) — cũng được hỗ trợ.
{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức dưới dạng một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại như nội dung riêng và có thể được đánh dấu là artefact; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **FAQ**

**Aspose.Slides for Python có thể xóa thông tin ứng dụng khỏi PDF không?**

Không, Aspose.Slides for Python tự động chèn thông tin API và số phiên bản vào PDF đầu ra. Thông tin này không thể được sửa đổi hoặc xóa.

**Làm sao để tôi chỉ bao gồm các slide cụ thể trong quá trình chuyển đổi PDF?**

Bạn có thể chỉ định các chỉ mục slide muốn chuyển đổi bằng cách truyền một mảng các vị trí slide vào phương thức [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**Có thể bảo vệ PDF bằng mật khẩu trong quá trình chuyển đổi không?**

Có, bạn có thể đặt mật khẩu và định nghĩa các quyền truy cập bằng cách sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) trước khi lưu bản trình chiếu dưới dạng PDF.

**Aspose.Slides có hỗ trợ chuyển đổi PDF sang các định dạng khác không?**

Có, Aspose.Slides hỗ trợ chuyển đổi PDF sang các định dạng như HTML, các định dạng hình ảnh (JPG, PNG), SVG, TIFF và XML.

**Làm sao để tôi đảm bảo PDF của mình tuân thủ các tiêu chuẩn truy cập?**

Đặt thuộc tính [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) trong [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) thành các tiêu chuẩn như `PDF_A1A`, `PDF_A1B`, hoặc `PDF_UA` để đảm bảo tuân thủ các hướng dẫn truy cập.

**Tôi có thể bao gồm các slide ẩn trong PDF đầu ra không?**

Có, bằng cách đặt thuộc tính [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) trong [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) thành `True`, các slide ẩn sẽ được bao gồm trong PDF.

**Làm sao để tôi điều chỉnh chất lượng và độ phân giải ảnh trong quá trình chuyển đổi?**

Sử dụng các thuộc tính [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) và [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) trong [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) để kiểm soát chất lượng và độ phân giải ảnh trong PDF tạo ra.

**Aspose.Slides có tự động xử lý việc thay thế phông chữ không?**

Aspose.Slides phát hiện việc thay thế phông chữ trong quá trình chuyển đổi, và bạn có thể xử lý chúng bằng thuộc tính `warning_callback` trong `SaveOptions` (hiện đang hạn chế).

## **Additional Resources**

- [Tài liệu Aspose.Slides cho Python qua .NET](/slides/vi/python-net/)
- [Tham chiếu API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Công cụ chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/conversion)