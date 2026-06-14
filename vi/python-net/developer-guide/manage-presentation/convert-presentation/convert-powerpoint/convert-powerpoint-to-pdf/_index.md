---
title: Chuyển đổi PPT & PPTX sang PDF trong Python | Tùy chọn nâng cao
linktitle: PowerPoint sang PDF
type: docs
weight: 40
url: /vi/python-net/convert-powerpoint-to-pdf/
keywords:
- chuyển đổi PowerPoint
- bản trình bày
- PowerPoint sang PDF
- PPT sang PDF
- PPTX sang PDF
- lưu PowerPoint dưới dạng PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Hướng dẫn chi tiết từng bước để chuyển đổi PPT, PPTX và ODP sang PDF chất lượng cao, tuân thủ WCAG trong Python với Aspose.Slides—bao gồm bảo mật bằng mật khẩu, chọn slide và kiểm soát chất lượng hình ảnh."
showReadingTime: true
---
## **Tổng quan**

Chuyển đổi các bản trình bày PowerPoint (PPT, PPTX, ODP) sang định dạng PDF trong Python mang lại một số lợi thế, bao gồm đảm bảo khả năng tương thích trên các thiết bị khác nhau và giữ nguyên bố cục cũng như định dạng của bản trình bày. Hướng dẫn này minh họa cách chuyển đổi bản trình bày sang tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo mật PDF bằng mật khẩu, phát hiện việc thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Chuyển đổi PowerPoint sang PDF**

Sử dụng Aspose.Slides, bạn có thể chuyển đổi các bản trình bày ở các định dạng này sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản trình bày sang PDF trong Python, bạn chỉ cần truyền tên tệp làm đối số cho lớp [Presentation](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides/presentation/) và sau đó lưu bản trình bày dưới dạng PDF bằng phương thức [Save](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides/presentation/#methods). Lớp [Presentation](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides/presentation/) cung cấp phương thức [Save] mà thường được sử dụng để chuyển đổi bản trình bày sang PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python ghi trực tiếp thông tin API và Số phiên bản vào tài liệu đầu ra. Ví dụ, khi nó chuyển đổi một bản trình bày sang PDF, Aspose.Slides for Python điền trường Application bằng giá trị '*Aspose.Slides*' và trường PDF Producer bằng một giá trị dạng '*Aspose.Slides v XX.XX*'. **Lưu ý** rằng bạn không thể chỉ đạo Aspose.Slides for Python thay đổi hoặc loại bỏ thông tin này khỏi tài liệu đầu ra.

{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản trình bày sang PDF
* Các slide cụ thể trong một bản trình bày sang PDF

Aspose.Slides xuất bản trình bày sang PDF, đảm bảo nội dung của các tệp PDF kết quả khớp chặt chẽ với bản trình bày gốc. Các yếu tố và thuộc tính được hiển thị một cách chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Các hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Siêu liên kết
* Đầu trang và chân trang
* Các dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Hoạt động chuyển đổi PowerPoint sang PDF tiêu chuẩn được thực hiện bằng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản trình bày đã cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng cao nhất. Đoạn mã Python này cho bạn thấy cách chuyển đổi PowerPoint sang PDF:

_Các bước: Chuyển đổi PowerPoint sang PDF trong Python_

Mã mẫu sau giải thích các chuyển đổi này bằng Python thông qua .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Các bước: Chuyển đổi PowerPoint sang PDF bằng Python qua .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Các bước: Chuyển đổi PPT sang PDF bằng Python qua .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Các bước: Chuyển đổi PPTX sang PDF bằng Python qua .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Các bước: Chuyển đổi ODP sang PDF bằng Python qua .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Các bước: Chuyển đổi PPS sang PDF bằng Python qua .NET</strong></a>

_Code Steps:_

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và cung cấp tệp PowerPoint cho nó.
  * Phần mở rộng _.ppt_ để tải tệp **PPT** vào lớp _Presentation_.
  * Phần mở rộng _.pptx_ để tải tệp **PPTX** vào lớp _Presentation_.
  * Phần mở rộng _.odp_ để tải tệp **ODP** vào lớp _Presentation_.
  * Phần mở rộng _.pps_ để tải tệp **PPS** vào lớp _Presentation_.
- Lưu _Presentation_ sang định dạng **PDF** bằng cách gọi phương thức **Save** và sử dụng liệt kê **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation đại diện cho tệp PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Lưu bản trình bày dưới dạng PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose cung cấp một công cụ chuyển đổi PowerPoint sang PDF trực tuyến miễn phí [**PowerPoint to PDF converter**](https://products.aspose.app/slides/vi/conversion/ppt-to-pdf) cho phép xem quy trình chuyển đổi bản trình bày sang PDF. Để thực hiện trực tiếp quy trình được mô tả ở đây, bạn có thể thử công cụ chuyển đổi.

{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính dưới lớp [PdfOptions](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides.export/pdfoptions/)—cho phép bạn tùy biến PDF (được tạo ra từ quá trình chuyển đổi), khóa PDF bằng mật khẩu, hoặc thậm chí chỉ định cách thực hiện quá trình chuyển đổi.

### **Chuyển đổi PowerPoint sang PDF với Tùy chọn Tùy chỉnh**

Bằng cách sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể đặt mức chất lượng ưu tiên cho hình raster, chỉ định cách xử lý metafiles, đặt mức nén cho văn bản, đặt DPI cho hình ảnh, v.v.

Ví dụ mã dưới đây minh họa một thao tác trong đó một bản trình bày PowerPoint được chuyển đổi sang PDF với một số tùy chọn tùy chỉnh:

```python
import aspose.slides as slides

# Khởi tạo lớp PdfOptions
pdf_options = slides.export.PdfOptions()

# Đặt chất lượng cho hình JPG
pdf_options.jpeg_quality = 90

# Đặt DPI cho hình ảnh
pdf_options.sufficient_resolution = 300

# Đặt hành vi cho metafile
pdf_options.save_metafiles_as_png = True

# Đặt mức nén văn bản cho nội dung văn bản
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Xác định chế độ tuân thủ PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Khởi tạo lớp Presentation đại diện cho tài liệu PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Lưu bản trình bày dưới dạng tài liệu PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Chuyển đổi PowerPoint sang PDF với các slide ẩn**

Nếu một bản trình bày chứa các slide ẩn, bạn có thể sử dụng tùy chọn tùy chỉnh—thuộc tính `show_hidden_slides` từ lớp [PdfOptions](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides.export/pdfoptions/)—để hướng dẫn Aspose.Slides bao gồm các slide ẩn dưới dạng trang trong PDF kết quả.

Đoạn mã Python dưới đây cho bạn thấy cách chuyển đổi một bản trình bày PowerPoint sang PDF với các slide ẩn được bao gồm:

```python
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation đại diện cho tệp PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Khởi tạo lớp PdfOptions
pdfOptions = slides.export.PdfOptions()

# Thêm các slide ẩn
pdfOptions.show_hidden_slides = True

# Lưu bản trình bày dưới dạng PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Chuyển đổi PowerPoint sang PDF được bảo mật bằng mật khẩu**

Đoạn mã Python này cho bạn thấy cách chuyển đổi PowerPoint sang PDF được bảo mật bằng mật khẩu (sử dụng các tham số bảo vệ từ lớp [PdfOptions](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Tạo một đối tượng Presentation đại diện cho tệp PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Khởi tạo lớp PdfOptions
pdfOptions = slides.export.PdfOptions()

# Đặt mật khẩu PDF và quyền truy cập
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Lưu bản trình bày dưới dạng PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Chuyển đổi các slide đã chọn trong PowerPoint sang PDF**

Đoạn mã Python này cho bạn thấy cách chuyển đổi các slide cụ thể trong một bản trình bày PowerPoint sang PDF:

```python
import aspose.slides as slides

# Tạo một đối tượng Presentation đại diện cho tệp PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Đặt một mảng vị trí các slide
slides_array = [ 1, 3 ]

# Lưu bản trình bày dưới dạng PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Chuyển đổi PowerPoint sang PDF với Kích thước Slide Tùy chỉnh**

Đoạn mã Python này cho bạn thấy cách chuyển đổi PowerPoint khi kích thước slide được chỉ định sang PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Tạo một bản trình bày mới với kích thước slide được điều chỉnh.
    with slides.Presentation() as resized_presentation:

        # Đặt kích thước slide tùy chỉnh.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Sao chép slide đầu tiên từ bản trình bày gốc.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Lưu bản trình bày đã thay đổi kích thước thành PDF có ghi chú.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Chuyển đổi PowerPoint sang PDF trong chế độ Ghi chú Slide**

Đoạn mã Python này cho bạn thấy cách chuyển đổi PowerPoint sang PDF ghi chú:

```python
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation đại diện cho tệp PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Lưu bản trình bày dưới dạng ghi chú PDF
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Tiêu chuẩn Truy cập và Tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã Python này minh họa một thao tác chuyển đổi PowerPoint sang PDF trong đó nhận được nhiều tệp PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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

{{% alert title="Note" color="warning" %}} 

Hỗ trợ của Aspose.Slides cho các thao tác chuyển đổi PDF mở rộng cho phép bạn chuyển đổi PDF sang các định dạng tệp phổ biến nhất. Bạn có thể thực hiện chuyển đổi [PDF to HTML](https://products.aspose.com/slides/vi/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/vi/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/vi/python-net/conversion/pdf-to-jpg/), và [PDF to PNG](https://products.aspose.com/slides/vi/python-net/conversion/pdf-to-png/) . Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt—[PDF to SVG](https://products.aspose.com/slides/vi/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/vi/python-net/conversion/pdf-to-tiff/), và [PDF to XML](https://products.aspose.com/slides/vi/python-net/conversion/pdf-to-xml/)—cũng được hỗ trợ.

{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức như một hình duy nhất. Các yếu tố đường dẫn riêng lẻ không được duy trì như nội dung riêng và có thể được đánh dấu là tạp chất; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

**Aspose.Slides for Python có thể xóa thông tin ứng dụng khỏi PDF không?**

Không, Aspose.Slides for Python tự động đưa thông tin API và số phiên bản vào PDF đầu ra. Thông tin này không thể được chỉnh sửa hoặc loại bỏ.

**Làm thế nào để chỉ bao gồm các slide cụ thể trong quá trình chuyển đổi PDF?**

Bạn có thể chỉ định các chỉ mục slide muốn chuyển đổi bằng cách truyền một mảng các vị trí slide vào phương thức `save`.

**Có thể bảo mật PDF bằng mật khẩu trong quá trình chuyển đổi không?**

Có, bạn có thể thiết lập mật khẩu và định nghĩa quyền truy cập bằng lớp `PdfOptions` trước khi lưu bản trình bày dưới dạng PDF.

**Aspose.Slides có hỗ trợ chuyển đổi PDF sang các định dạng khác không?**

Có, Aspose.Slides hỗ trợ chuyển đổi PDF sang các định dạng như HTML, các định dạng hình ảnh (JPG, PNG), SVG, TIFF và XML.

**Làm sao để đảm bảo PDF của tôi tuân thủ các tiêu chuẩn truy cập?**

Thiết lập thuộc tính `compliance` trong `PdfOptions` thành các tiêu chuẩn như `PDF_A1A`, `PDF_A1B` hoặc `PDF_UA` để đảm bảo PDF tuân thủ các hướng dẫn truy cập.

**Tôi có thể bao gồm các slide ẩn trong PDF đầu ra không?**

Có, bằng cách đặt thuộc tính `show_hidden_slides` trong `PdfOptions` thành `True`, các slide ẩn sẽ được bao gồm trong PDF.

**Làm sao để điều chỉnh chất lượng và độ phân giải hình ảnh trong quá trình chuyển đổi?**

Sử dụng các thuộc tính `jpeg_quality` và `sufficient_resolution` trong `PdfOptions` để kiểm soát chất lượng và độ phân giải hình ảnh trong PDF kết quả.

**Aspose.Slides tự động xử lý việc thay thế phông chữ không?**

Aspose.Slides phát hiện các việc thay thế phông chữ trong quá trình chuyển đổi, và bạn có thể xử lý chúng bằng thuộc tính `warning_callback` trong `SaveOptions` (hiện tại có giới hạn).

## **Tài nguyên bổ sung**

- [Tài liệu Aspose.Slides cho .NET](https://docs.aspose.com/slides/vi/python-net/)
- [Tham chiếu API Aspose.Slides](https://reference.aspose.com/slides/vi/python-net/)
- [Trình chuyển đổi trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/vi/conversion)