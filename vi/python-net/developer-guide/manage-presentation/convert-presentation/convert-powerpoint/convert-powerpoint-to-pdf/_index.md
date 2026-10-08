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
- bản thuyết trình
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
description: "Hướng dẫn chi tiết từng bước để chuyển đổi PPT, PPTX và ODP thành các tệp PDF chất lượng cao, tuân thủ WCAG trong Python với Aspose.Slides—bao gồm bảo mật bằng mật khẩu, chọn slide và kiểm soát chất lượng hình ảnh."
showReadingTime: true
---
## **Tổng quan**

Việc chuyển đổi các bản thuyết trình PowerPoint (PPT, PPTX, ODP) sang định dạng PDF trong Python mang lại một số lợi ích, bao gồm đảm bảo tương thích trên các thiết bị khác nhau và giữ nguyên bố cục cũng như định dạng của bản thuyết trình. Hướng dẫn này trình bày cách chuyển đổi bản thuyết trình sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo mật PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi, và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản thuyết trình ở các định dạng này sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản thuyết trình sang PDF trong Python, bạn chỉ cần truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) và sau đó lưu bản thuyết trình dưới dạng PDF bằng phương thức [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) cung cấp phương thức [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/), thường được sử dụng để chuyển đổi một bản thuyết trình sang PDF.

{{% alert color="info" title="Lưu ý" %}}
Aspose.Slides for Python chèn thông tin API và số phiên bản của nó vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản thuyết trình sang PDF, Aspose.Slides for Python điền trường Application bằng giá trị '*Aspose.Slides*' và trường PDF Producer bằng giá trị dạng '*Aspose.Slides v XX.XX*'. **Lưu ý** rằng bạn không thể yêu cầu Aspose.Slides for Python thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản thuyết trình sang PDF
* Các slide cụ thể trong một bản thuyết trình sang PDF

Aspose.Slides xuất bản thuyết trình ra PDF, đảm bảo nội dung của các tệp PDF kết quả gần giống với bản thuyết trình gốc. Các thành phần và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Liên kết
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi tiêu chuẩn từ PowerPoint sang PDF sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides sẽ cố gắng chuyển đổi bản thuyết trình đã cung cấp sang PDF bằng các thiết lập tối ưu ở mức chất lượng tối đa.

Ví dụ sau tải một bản thuyết trình và lưu tất cả các slide hiển thị sang PDF bằng các cài đặt xuất mặc định.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Lưu ý" %}}
Aspose cung cấp một công cụ chuyển đổi **PowerPoint sang PDF** trực tuyến miễn phí [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) để minh họa quy trình chuyển đổi bản thuyết trình sang PDF. Để thực hiện thử nghiệm quy trình mô tả ở đây, bạn có thể dùng công cụ chuyển đổi này.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh — các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) — cho phép bạn tùy chỉnh PDF (kết quả của quá trình chuyển đổi), khóa PDF bằng mật khẩu, hoặc thậm chí chỉ định cách thực hiện quá trình chuyển đổi.

### **Chuyển đổi PowerPoint sang PDF với Các Tùy Chọn Tùy Chỉnh**

Bằng cách sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể đặt cài đặt chất lượng mong muốn cho hình ảnh raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, đặt DPI cho hình ảnh, v.v.

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

### **Bảo tồn các Tệp OLE Nhúng dưới dạng Tệp Đính Kèm PDF**

Nếu một bản thuyết trình chứa một workbook Excel được nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu workbook cũng như xem các slide. Đặt [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) thành `True` để bảo tồn các tệp OLE nhúng dưới dạng tệp đính kèm trong PDF kết quả.

Giá trị mặc định là `False`: hình ảnh preview hoặc biểu tượng của đối tượng OLE được hiển thị trên trang PDF, nhưng tệp nhúng không được bao gồm dưới dạng tệp đính kèm. Khi đặt tùy chọn thành `True` thì thêm cả dữ liệu tệp. Phần preview vẫn là hình ảnh trực quan; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE không trở thành một bảng tính Excel tương tác trên trang PDF.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Để kiểm tra kết quả:

1. Mở PDF đã xuất trong trình xem hỗ trợ tệp đính kèm, chẳng hạn như Adobe Acrobat Reader.
2. Mở bảng **Attachments** của trình xem và tìm workbook được nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Phần preview trên trang PDF tách riêng khỏi tệp đính kèm.

{{% alert color="info" title="Lưu ý" %}}
Tiêu chuẩn PDF/A áp đặt các hạn chế đối với tệp đính kèm: PDF/A-1 cấm các tệp nhúng, PDF/A-2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm workbook Excel. Đây là yêu cầu của tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng cài đặt tuân thủ PDF mặc định và không trình bày xuất PDF/A.
{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với Các Slide Ẩn**

Nếu một bản thuyết trình chứa các slide ẩn, bạn có thể sử dụng tùy chọn tùy chỉnh—thuộc tính [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) từ lớp [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—để chỉ định Aspose.Slides bao gồm các slide ẩn như các trang trong PDF kết quả.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Chuyển đổi PowerPoint sang PDF có Bảo Mật Mật Khẩu**

Ví dụ sau xuất một bản thuyết trình sang PDF yêu cầu mật khẩu `password` để mở. Quyền truy cập cho phép in, bao gồm in chất lượng cao.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Xử lý Phông chữ Không Có Kiểu Đậm Riêng**

Một bản thuyết trình có thể áp dụng định dạng đậm cho văn bản ngay cả khi phông chữ không có kiểu đậm riêng. Văn bản vẫn có thể hiển thị đậm thông qua việc làm đậm tổng hợp, làm dày các glyph thông thường. Khi văn bản đó trông quá nặng hoặc không giống như mong muốn trong PDF, hãy thử đặt [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) thành `True`. Tùy chọn này sẽ render văn bản bị ảnh hưởng dưới dạng bitmap trong quá trình xuất PDF và có thể cải thiện hiển thị cho một số phông chữ. Giá trị mặc định là `False`.

Ví dụ bản thuyết trình chứa hai hộp văn bản: một với văn bản thường và một với định dạng đậm áp dụng cho cùng một phông chữ, phông chữ này không có kiểu đậm riêng. Ví dụ sau tải bản thuyết trình, bật rasterization cho các kiểu phông chữ không được hỗ trợ, và xuất ra PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Các bản preview dưới đây hiển thị đầu ra khi tùy chọn bị tắt và khi được bật. Trong ví dụ này, văn bản đậm có nét dày hơn khi tùy chọn bị tắt. Khi bật, nét của nó nhẹ hơn; văn bản thường không thay đổi. So sánh kết quả trước khi chọn cài đặt cho bản thuyết trình của bạn.

| Tùy chọn bị tắt (`False`, mặc định) | Tùy chọn được bật (`True`) |
|---|---|
| ![PDF với rasterization kiểu phông chữ không được hỗ trợ bị tắt](unsupported-bold-disabled.png) | ![PDF với rasterization kiểu phông chữ không được hỗ trợ được bật](unsupported-bold-enabled.png) |

Trong ví dụ này, bật tùy chọn sẽ chuyển chỉ văn bản đậm thành bitmap: nó không thể được chọn, sao chép hoặc tìm kiếm dưới dạng văn bản mà không có OCR, và các cạnh của nó trông mềm hơn ở mức phóng 800%. Văn bản thường vẫn có thể tìm kiếm được. Khi tùy chọn bị tắt, cả hai chuỗi đều vẫn là văn bản.

Tùy chọn này rasterize văn bản được định dạng đậm khi phông chữ không có kiểu đậm riêng. [Font substitution](/slides/vi/python-net/font-substitution/) thay thế phông chữ thay vì chọn một phông chữ khác khi phông chữ gốc không khả dụng.

## **Chuyển đổi các Slide Được Chọn trong PowerPoint sang PDF**

Ví dụ dưới đây xuất các slide 1 và 3 từ một bản thuyết trình sang PDF. Các số slide trong mảng này bắt đầu từ 1, và bản thuyết trình đầu vào phải chứa ít nhất ba slide.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Chuyển đổi PowerPoint sang PDF với Kích Thước Slide Tùy Chỉnh**

Ví dụ sau sao chép slide đầu tiên từ một bản thuyết trình vào một bản thuyết trình mới với kích thước slide là 612 × 792 điểm (8.5 × 11 inch). Nó co dãn nội dung slide để vừa và xuất slide duy nhất này sang PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Xóa slide trống mà bản thuyết trình mới được tạo ra.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Chuyển đổi PowerPoint sang PDF ở chế độ Ghi chú Slide**

Ví dụ dưới đây xuất một bản thuyết trình sang PDF, đặt ghi chú của mỗi slide dưới slide. Sử dụng một bản thuyết trình có ghi chú người thuyết trình để xem kết quả.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Tiêu Chuẩn Truy Cập và Tuân Thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ các [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

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

{{% alert color="info" title="Lưu ý" %}}
Aspose.Slides hỗ trợ các thao tác chuyển đổi PDF cho phép bạn chuyển PDF sang các định dạng tệp phổ biến nhất. Bạn có thể thực hiện chuyển đổi [PDF sang HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF sang hình ảnh](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF sang JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), và [PDF sang PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt—[PDF sang SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF sang TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), và [PDF sang XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)...—cũng được hỗ trợ.
{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức dưới dạng một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại như nội dung riêng và có thể được đánh dấu là nhiễu; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Aspose.Slides for Python có thể loại bỏ thông tin ứng dụng khỏi PDF không?**

Không, Aspose.Slides for Python tự động bao gồm thông tin API và số phiên bản trong PDF đầu ra. Thông tin này không thể được chỉnh sửa hoặc loại bỏ.

**Làm thế nào để chỉ bao gồm các slide cụ thể trong quá trình chuyển đổi PDF?**

Bạn có thể chỉ định các chỉ số slide muốn chuyển đổi bằng cách truyền một mảng vị trí slide vào phương thức [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**Có thể bảo mật PDF bằng mật khẩu khi chuyển đổi không?**

Có, bạn có thể đặt mật khẩu và xác định quyền truy cập bằng cách sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) trước khi lưu bản thuyết trình dưới dạng PDF.

**Aspose.Slides có hỗ trợ chuyển đổi PDF sang các định dạng khác không?**

Có, Aspose.Slides hỗ trợ chuyển đổi PDF sang các định dạng như HTML, các định dạng hình ảnh (JPG, PNG), SVG, TIFF và XML.

**Làm sao tôi có thể đảm bảo PDF của tôi tuân thủ các tiêu chuẩn truy cập?**

Đặt thuộc tính [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) trong [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) thành các tiêu chuẩn như `PDF_A1A`, `PDF_A1B`, hoặc `PDF_UA` để đảm bảo PDF tuân thủ các hướng dẫn truy cập.

**Tôi có thể bao gồm các slide ẩn trong PDF không?**

Có, bằng cách đặt thuộc tính [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) trong [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) thành `True`, các slide Ẩn sẽ được bao gồm trong PDF.

**Làm sao để điều chỉnh chất lượng và độ phân giải hình ảnh khi chuyển đổi?**

Sử dụng các thuộc tính [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) và [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) trong [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) để kiểm soát chất lượng và độ phân giải hình ảnh trong PDF kết quả.

**Aspose.Slides có xử lý tự động việc thay thế phông chữ không?**

Aspose.Slides phát hiện việc thay thế phông chữ trong quá trình chuyển đổi, và bạn có thể xử lý chúng bằng thuộc tính `warning_callback` trong `SaveOptions` (hiện đang hạn chế).

## **Tài Nguyên Bổ Sung**

- [Tài liệu Aspose.Slides cho Python qua .NET](/slides/vi/python-net/)
- [Tham chiếu API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Công cụ chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/conversion)