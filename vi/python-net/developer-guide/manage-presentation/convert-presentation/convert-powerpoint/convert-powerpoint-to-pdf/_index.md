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
- bài thuyết trình
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
description: "Hướng dẫn từng bước chuyển đổi PPT, PPTX và ODP sang các tệp PDF chất lượng cao, tuân thủ WCAG trong Python với Aspose.Slides—bao gồm bảo vệ mật khẩu, chọn slide và kiểm soát chất lượng hình ảnh."
showReadingTime: true
---
## **Tổng quan**

Chuyển đổi các bản trình chiếu PowerPoint (PPT, PPTX, ODP) sang định dạng PDF trong Python mang lại nhiều lợi thế, bao gồm đảm bảo tính tương thích trên các thiết bị khác nhau và giữ nguyên bố cục cũng như định dạng của bản trình chiếu. Hướng dẫn này trình bày cách chuyển đổi bản trình chiếu thành tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện việc thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình chiếu ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình chiếu sang PDF trong Python, bạn chỉ cần truyền tên tệp làm đối số cho lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) và sau đó lưu bản trình chiếu dưới dạng PDF bằng phương thức [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) cung cấp phương thức [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) thường được sử dụng để chuyển đổi bản trình chiếu sang PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python chèn thông tin API và số phiên bản của nó vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản trình chiếu sang PDF, Aspose.Slides for Python điền trường Application bằng giá trị '*Aspose.Slides*' và trường PDF Producer bằng giá trị dạng '*Aspose.Slides v XX.XX*'. **Lưu ý** rằng bạn không thể chỉ đạo Aspose.Slides cho Python thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.
{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình chiếu sang PDF
* Các slide cụ thể trong bản trình chiếu sang PDF

Aspose.Slides xuất bản trình chiếu sang PDF, đảm bảo nội dung của các tệp PDF kết quả gần như khớp với bản trình chiếu gốc. Các yếu tố và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Liên kết siêu văn bản
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Quá trình chuyển đổi PowerPoint sang PDF tiêu chuẩn sử dụng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản trình chiếu đã cung cấp sang PDF bằng các thiết lập tối ưu với mức chất lượng cao nhất.

Ví dụ sau tải một bản trình chiếu và lưu tất cả các slide hiển thị sang PDF bằng các thiết lập xuất mặc định.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose cung cấp một trình chuyển đổi trực tuyến miễn phí [**Trình chuyển đổi PowerPoint sang PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) để minh họa quy trình chuyển đổi bản trình chiếu sang PDF. Để thực hiện quy trình mô tả ở đây, bạn có thể thử nghiệm với trình chuyển đổi.
{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính trong lớp [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—cho phép bạn tùy chỉnh PDF (kết quả từ quá trình chuyển đổi), khóa PDF bằng mật khẩu, hoặc thậm chí chỉ định cách thức thực hiện quá trình chuyển đổi.

### **Chuyển đổi PowerPoint sang PDF với các tùy chọn tùy chỉnh**

Bằng cách sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể đặt mức chất lượng mong muốn cho hình raster, chỉ định cách xử lý metafile, đặt mức nén cho văn bản, đặt DPI cho hình ảnh, v.v.

Ví dụ sau xuất một bản trình chiếu sang PDF 1.5 với chất lượng JPEG được đặt là 90, độ phân giải hình ảnh là 300 DPI, metafile được lưu dưới dạng PNG, và nén văn bản Flate.

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

### **Giữ nguyên tệp OLE nhúng dưới dạng tệp đính kèm PDF**

Nếu một bản trình chiếu chứa một sổ làm việc Excel nhúng, bạn có thể muốn người nhận PDF truy cập dữ liệu của sổ làm việc cũng như xem các slide. Đặt [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) thành `True` để giữ nguyên các tệp OLE nhúng dưới dạng tệp đính kèm trong PDF kết quả.

Giá trị mặc định là `False`: hình ảnh hoặc biểu tượng xem trước của đối tượng OLE được hiển thị trên trang PDF, nhưng tệp nhúng của nó không được bao gồm dưới dạng tệp đính kèm. Đặt tùy chọn này thành `True` sẽ thêm dữ liệu tệp vào. Bản xem trước vẫn là một biểu diễn hình ảnh; tệp đính kèm cho phép người nhận mở hoặc lưu tệp nhúng riêng biệt. Đối tượng OLE không trở thành một bảng tính Excel tương tác trên trang PDF.

Ví dụ sau tải một bản trình chiếu đã chứa sổ làm việc Excel nhúng và xuất nó sang PDF với sổ làm việc được đính kèm.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Để kiểm tra kết quả:

1. Mở PDF đã xuất trong một trình xem hỗ trợ tệp đính kèm, chẳng hạn Adobe Acrobat Reader.
2. Mở bảng **Đính kèm** của trình xem và tìm sổ làm việc đã nhúng.
3. Lưu tệp đính kèm và mở nó trong Excel để kiểm tra dữ liệu, hoặc mở trực tiếp nếu trình xem cho phép. Bản xem trước trên trang PDF là riêng biệt so với tệp đính kèm.

{{% alert color="info" title="Note" %}}
Các tiêu chuẩn PDF/A áp đặt các hạn chế đối với tệp đính kèm: PDF/A-1 cấm tệp nhúng, PDF/A-2 chỉ cho phép tệp đính kèm PDF/A, và PDF/A-3 cho phép các loại tệp khác, bao gồm sổ làm việc Excel. Đây là yêu cầu của tiêu chuẩn, không phải là hạn chế riêng của Aspose.Slides. Ví dụ này sử dụng thiết lập tuân thủ PDF mặc định và không minh họa việc xuất PDF/A.
{{% /alert %}}

### **Chuyển đổi PowerPoint sang PDF với các slide ẩn**

Nếu một bản trình chiếu chứa các slide ẩn, bạn có thể sử dụng một tùy chọn tùy chỉnh—thuộc tính [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) từ lớp [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—để chỉ đạo Aspose.Slides bao gồm các slide ẩn dưới dạng trang trong PDF kết quả.

Ví dụ sau xuất một bản trình chiếu sang PDF, bao gồm cả các slide ẩn.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Chuyển đổi PowerPoint sang PDF được bảo vệ bằng mật khẩu**

Ví dụ sau xuất một bản trình chiếu sang PDF yêu cầu mật khẩu `password` để mở. Các quyền truy cập cho phép in, bao gồm cả in chất lượng cao.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Chuyển đổi các slide đã chọn trong PowerPoint sang PDF**

Ví dụ sau xuất các slide 1 và 3 từ một bản trình chiếu sang PDF. Các số slide trong mảng này bắt đầu từ 1, và bản trình chiếu đầu vào phải chứa ít nhất ba slide.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Chuyển đổi PowerPoint sang PDF với kích thước slide tùy chỉnh**

Ví dụ sau sao chép slide đầu tiên từ một bản trình chiếu vào một bản trình chiếu mới với kích thước slide là 612 × 792 điểm (8,5 × 11 inch). Nó thu phóng nội dung slide để vừa và xuất slide đơn này sang PDF.

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

Ví dụ sau xuất một bản trình chiếu sang PDF, đặt các ghi chú của mỗi slide dưới slide tương ứng. Hãy sử dụng một bản trình chiếu có ghi chú để xem kết quả.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Tiêu chuẩn truy cập và tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng một quy trình chuyển đổi phù hợp với [Hướng dẫn Truy cập Nội dung Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF sử dụng bất kỳ tiêu chuẩn tuân thủ nào trong số: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

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
Hỗ trợ của Aspose.Slides cho các thao tác chuyển đổi PDF cho phép bạn chuyển đổi PDF sang các định dạng tệp phổ biến nhất. Bạn có thể thực hiện các chuyển đổi [PDF sang HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF sang hình ảnh](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF sang JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), và [PDF sang PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt khác—[PDF sang SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF sang TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), và [PDF sang XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—cũng được hỗ trợ.
{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được giữ lại như nội dung riêng và có thể được đánh dấu là nhiễu; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Có Aspose.Slides cho Python có thể xóa thông tin ứng dụng khỏi PDF không?**

Không, Aspose.Slides cho Python tự động bao gồm thông tin API và số phiên bản trong PDF đầu ra. Thông tin này không thể được sửa đổi hoặc xóa.

**Làm sao để chỉ bao gồm các slide cụ thể trong quá trình chuyển đổi PDF?**

Bạn có thể chỉ định chỉ số slide muốn chuyển đổi bằng cách truyền một mảng các vị trí slide vào phương thức [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**Có thể bảo vệ PDF bằng mật khẩu trong quá trình chuyển đổi không?**

Có, bạn có thể đặt mật khẩu và định nghĩa quyền truy cập bằng cách sử dụng lớp [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) trước khi lưu bản trình chiếu dưới dạng PDF.

**Aspose.Slides có hỗ trợ chuyển đổi PDF sang các định dạng khác không?**

Có, Aspose.Slides hỗ trợ chuyển đổi PDF sang các định dạng như HTML, các định dạng hình ảnh (JPG, PNG), SVG, TIFF và XML.

**Làm sao để đảm bảo PDF của tôi tuân thủ các tiêu chuẩn truy cập?**

Đặt thuộc tính [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) trong [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) thành các tiêu chuẩn như `PDF_A1A`, `PDF_A1B` hoặc `PDF_UA` để đảm bảo tuân thủ các hướng dẫn truy cập.

**Có thể bao gồm các slide ẩn trong PDF xuất ra không?**

Có, bằng cách đặt thuộc tính [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) trong [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) thành `True`, các slide ẩn sẽ được bao gồm trong PDF.

**Làm sao để điều chỉnh chất lượng và độ phân giải hình ảnh trong quá trình chuyển đổi?**

Sử dụng các thuộc tính [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) và [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) trong [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) để kiểm soát chất lượng và độ phân giải hình ảnh trong PDF kết quả.

**Aspose.Slides có tự động xử lý việc thay thế phông chữ không?**

Aspose.Slides phát hiện việc thay thế phông chữ trong quá trình chuyển đổi và bạn có thể xử lý chúng bằng thuộc tính `warning_callback` trong `SaveOptions` (hiện tại còn giới hạn).

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides cho Python qua .NET](/slides/vi/python-net/)
- [Tham chiếu API Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Trình chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/conversion)