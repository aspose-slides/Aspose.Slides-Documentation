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
  - PDF/A1a
  - PDF/A1b
  - PDF/UA
  - Python
  - Aspose.Slides for Python
description: "Hướng dẫn từng bước chuyển đổi PPT, PPTX và ODP thành các tệp PDF chất lượng cao, tuân thủ WCAG trong Python với Aspose.Slides—bao gồm bảo mật bằng mật khẩu, lựa chọn slide và kiểm soát chất lượng hình ảnh."
showReadingTime: true
---
## **Tổng quan**

Chuyển đổi các bản thuyết trình PowerPoint (PPT, PPTX, ODP) sang định dạng PDF trong Python mang lại một số lợi ích, bao gồm đảm bảo tính tương thích trên các thiết bị khác nhau và giữ nguyên bố cục và định dạng của bản thuyết trình. Hướng dẫn này trình bày cách chuyển đổi bản thuyết trình thành tài liệu PDF, sử dụng các tùy chọn khác nhau để kiểm soát chất lượng hình ảnh, bao gồm các slide ẩn, bảo vệ PDF bằng mật khẩu, phát hiện thay thế phông chữ, chọn các slide cụ thể để chuyển đổi và áp dụng các tiêu chuẩn tuân thủ cho tài liệu đầu ra.

## **Cài đặt**

```bash
pip install aspose.slides
```

Gói phần mềm bao gồm runtime cần thiết, do đó Microsoft PowerPoint không cần phải được cài đặt trên máy thực hiện việc chuyển đổi.

## **Chuyển đổi PowerPoint sang PDF**

Bạn có thể sử dụng Aspose.Slides để chuyển đổi các bản thuyết trình ở các định dạng sau sang PDF:

* **PPT**
* **PPTX**
* **ODP**

Để chuyển đổi một bản thuyết trình sang PDF trong Python, bạn chỉ cần truyền tên tệp làm đối số cho lớp [Presentation](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides/presentation/) và sau đó lưu bản thuyết trình dưới dạng PDF bằng phương thức [Save](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides/presentation/#methods). Lớp [Presentation] cung cấp phương thức [Save] thường được sử dụng để chuyển đổi bản thuyết trình sang PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python trực tiếp ghi thông tin API và Số phiên bản vào tài liệu đầu ra. Ví dụ, khi chuyển đổi một bản thuyết trình sang PDF, Aspose.Slides for Python điền trường Application bằng giá trị '*Aspose.Slides*' và trường PDF Producer bằng một giá trị dạng '*Aspose.Slides v XX.XX*'. **Lưu ý** rằng bạn không thể chỉ đạo Aspose.Slides for Python thay đổi hoặc xóa thông tin này khỏi tài liệu đầu ra.

{{% /alert %}}

Aspose.Slides cho phép bạn chuyển đổi:

* Toàn bộ bản thuyết trình sang PDF
* Các slide cụ thể trong bản thuyết trình sang PDF

Aspose.Slides xuất bản thuyết trình sang PDF, đảm bảo nội dung của các tệp PDF kết quả gần như khớp với bản thuyết trình gốc. Các yếu tố và thuộc tính được hiển thị chính xác trong quá trình chuyển đổi, bao gồm:

* Hình ảnh
* Hộp văn bản và hình dạng
* Định dạng văn bản
* Định dạng đoạn văn
* Liên kết siêu văn bản
* Đầu trang và chân trang
* Dấu đầu dòng
* Bảng

## **Chuyển đổi PowerPoint sang PDF**

Hoạt động chuyển đổi PowerPoint sang PDF tiêu chuẩn được thực thi bằng các tùy chọn mặc định. Trong trường hợp này, Aspose.Slides cố gắng chuyển đổi bản thuyết trình được cung cấp sang PDF bằng các cài đặt tối ưu ở mức chất lượng tối đa. Đoạn mã Python dưới đây cho thấy cách chuyển đổi PowerPoint sang PDF:

*Steps: PowerPoint to PDF Conversions in Python*

Mã mẫu sau giải thích các chuyển đổi này bằng Python thông qua .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Bước: Chuyển đổi PowerPoint sang PDF bằng Python qua .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Bước: Chuyển đổi PPT sang PDF bằng Python qua .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Bước: Chuyển đổi PPTX sang PDF bằng Python qua .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Bước: Chuyển đổi ODP sang PDF bằng Python qua .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Bước: Chuyển đổi PPS sang PDF bằng Python qua .NET</a></strong>

**Các bước mã:**

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và cung cấp cho nó tệp PowerPoint.
  * Đuôi *.ppt* để tải tệp **PPT** vào lớp _Presentation_.
  * Đuôi *.pptx* để tải tệp **PPTX** vào lớp _Presentation_.
  * Đuôi *.odp* để tải tệp **ODP** vào lớp _Presentation_.
  * Đuôi *.pps* để tải tệp **PPS** vào lớp _Presentation_.
- Lưu _Presentation_ sang định dạng **PDF** bằng cách gọi phương thức **Save** và sử dụng liệt kê **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Khởi tạo một lớp Presentation đại diện cho tệp PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Lưu bản thuyết trình dưới dạng PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose cung cấp một công cụ trực tuyến miễn phí [**Bộ chuyển đổi PowerPoint sang PDF**](https://products.aspose.app/slides/vi/conversion/ppt-to-pdf) để minh họa quy trình chuyển đổi bản thuyết trình sang PDF. Để thực hiện thử nghiệm trực tiếp quy trình mô tả ở đây, bạn có thể dùng công cụ chuyển đổi này.

{{% /alert %}}

## **Chuyển đổi PowerPoint sang PDF với các tùy chọn**

Aspose.Slides cung cấp các tùy chọn tùy chỉnh—các thuộc tính trong lớp [PdfOptions](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides.export/pdfoptions/)—cho phép bạn tùy chỉnh PDF (kết quả của quá trình chuyển đổi), khóa PDF bằng mật khẩu, hoặc thậm chí chỉ định cách quá trình chuyển đổi diễn ra.

### **Chuyển đổi PowerPoint sang PDF với tùy chọn tùy chỉnh**

Bằng cách sử dụng các tùy chọn chuyển đổi tùy chỉnh, bạn có thể đặt mức chất lượng mong muốn cho hình ảnh raster, chỉ định cách xử lý metafile, thiết lập mức nén cho văn bản, đặt DPI cho hình ảnh, v.v.

Đoạn mã dưới đây minh họa một thao tác trong đó bản thuyết trình PowerPoint được chuyển đổi sang PDF với một số tùy chọn tùy chỉnh:

```python
import aspose.slides as slides

# Khởi tạo lớp PdfOptions
pdf_options = slides.export.PdfOptions()

# Đặt chất lượng cho ảnh JPG
pdf_options.jpeg_quality = 90

# Đặt DPI cho ảnh
pdf_options.sufficient_resolution = 300

# Đặt hành vi cho metafile
pdf_options.save_metafiles_as_png = True

# Đặt mức nén văn bản cho nội dung văn bản
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Xác định chế độ tuân thủ PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Khởi tạo lớp Presentation đại diện cho tài liệu PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Lưu bản thuyết trình dưới dạng tài liệu PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Chuyển đổi PowerPoint sang PDF với các slide ẩn**

Nếu một bản thuyết trình chứa các slide ẩn, bạn có thể sử dụng tùy chọn tùy chỉnh—thuộc tính `show_hidden_slides` từ lớp [PdfOptions](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides.export/pdfoptions/)—để chỉ đạo Aspose.Slides bao gồm các slide ẩn dưới dạng trang trong PDF kết quả.

Đoạn mã Python dưới đây cho thấy cách chuyển đổi một bản thuyết trình PowerPoint sang PDF với các slide ẩn được bao gồm:

```python
import aspose.slides as slides

# Khởi tạo một lớp Presentation đại diện cho tệp PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Khởi tạo lớp PdfOptions
pdfOptions = slides.export.PdfOptions()

# Thêm các slide ẩn
pdfOptions.show_hidden_slides = True

# Lưu bản thuyết trình dưới dạng PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Chuyển đổi PowerPoint sang PDF có bảo vệ mật khẩu**

Đoạn mã Python dưới đây cho thấy cách chuyển đổi PowerPoint sang PDF có bảo vệ bằng mật khẩu (sử dụng các tham số bảo vệ từ lớp [PdfOptions](https://docs.aspose.com/slides/vi/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Khởi tạo một đối tượng Presentation đại diện cho tệp PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Khởi tạo lớp PdfOptions
pdfOptions = slides.export.PdfOptions()

# Đặt mật khẩu PDF và quyền truy cập
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Lưu bản thuyết trình dưới dạng PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Chuyển đổi các slide đã chọn trong PowerPoint sang PDF**

Đoạn mã Python dưới đây cho thấy cách chuyển đổi các slide cụ thể trong một bản thuyết trình PowerPoint sang PDF:

```python
import aspose.slides as slides

# Khởi tạo một đối tượng Presentation đại diện cho tệp PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Đặt một mảng vị trí các slide
slides_array = [ 1, 3 ]

# Lưu bản thuyết trình dưới dạng PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Chuyển đổi PowerPoint sang PDF với kích thước slide tùy chỉnh**

Đoạn mã Python dưới đây cho thấy cách chuyển đổi PowerPoint khi kích thước slide được chỉ định sang PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Khởi tạo lớp Presentation đại diện cho tệp PowerPoint hoặc OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Tạo một bản thuyết trình mới với kích thước slide đã điều chỉnh.
    with slides.Presentation() as resized_presentation:

        # Đặt kích thước slide tùy chỉnh.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Sao chép slide đầu tiên từ bản thuyết trình gốc và loại bỏ slide trống mặc định.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # Lưu bản thuyết trình đã thay đổi kích thước thành PDF.
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Chuyển đổi PowerPoint sang PDF trong chế độ xem ghi chú slide**

Đoạn mã Python dưới đây cho thấy cách chuyển đổi PowerPoint sang PDF ghi chú:

```python
import aspose.slides as slides

# Khởi tạo một lớp Presentation đại diện cho tệp PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

# Cấu hình các tùy chọn PDF với bố cục ghi chú
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Lưu bản thuyết trình thành PDF có ghi chú
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Tiêu chuẩn truy cập và tuân thủ cho PDF**

Aspose.Slides cho phép bạn sử dụng quy trình chuyển đổi tuân thủ theo [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Bạn có thể xuất tài liệu PowerPoint sang PDF bằng bất kỳ tiêu chuẩn tuân thủ nào sau: **PDF/A1a**, **PDF/A1b**, và **PDF/UA**.

Đoạn mã Python dưới đây minh họa một thao tác chuyển đổi PowerPoint sang PDF trong đó tạo ra nhiều tệp PDF dựa trên các tiêu chuẩn tuân thủ khác nhau:

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

Hỗ trợ chuyển đổi PDF của Aspose.Slides mở rộng cho phép bạn chuyển đổi PDF sang các định dạng tệp phổ biến nhất. Bạn có thể thực hiện các chuyển đổi [PDF to HTML](https://products.aspose.com/slides/vi/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/vi/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/vi/python-net/conversion/pdf-to-jpg/), và [PDF to PNG](https://products.aspose.com/slides/vi/python-net/conversion/pdf-to-png/). Các thao tác chuyển đổi PDF sang các định dạng chuyên biệt—[PDF to SVG](https://products.aspose.com/slides/vi/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/vi/python-net/conversion/pdf-to-tiff/), và [PDF to XML](https://products.aspose.com/slides/vi/python-net/conversion/pdf-to-xml/)—cũng được hỗ trợ.

{{% /alert %}}

> **Lưu ý:** Khi xuất sang PDF/UA, Aspose.Slides xử lý các đồ họa phức tạp như SmartArt, biểu đồ và công thức dưới dạng một hình duy nhất. Các phần tử đường dẫn riêng lẻ không được bảo tồn dưới dạng nội dung riêng và có thể được đánh dấu là hiện vật; văn bản thay thế chỉ được cung cấp cho toàn bộ hình.

## **Câu hỏi thường gặp**

### Có thể Aspose.Slides for Python loại bỏ thông tin ứng dụng khỏi PDF không?

Không, Aspose.Slides for Python tự động bao gồm thông tin API và số phiên bản trong PDF đầu ra. Thông tin này không thể sửa đổi hoặc loại bỏ.

### Làm sao để chỉ bao gồm các slide cụ thể trong quá trình chuyển đổi PDF?

Bạn có thể chỉ định chỉ số slide muốn chuyển đổi bằng cách truyền một mảng vị trí slide vào phương thức `save`.

### Có thể bảo vệ PDF bằng mật khẩu trong quá trình chuyển đổi không?

Có, bạn có thể thiết lập mật khẩu và định nghĩa quyền truy cập bằng cách sử dụng lớp `PdfOptions` trước khi lưu bản thuyết trình dưới dạng PDF.

### Aspose.Slides có hỗ trợ chuyển đổi PDF sang các định dạng khác không?

Có, Aspose.Slides hỗ trợ chuyển đổi PDF sang các định dạng như HTML, các định dạng hình ảnh (JPG, PNG), SVG, TIFF và XML.

### Làm sao để đảm bảo PDF của tôi tuân thủ các tiêu chuẩn truy cập?

Đặt thuộc tính `compliance` trong `PdfOptions` thành các tiêu chuẩn như `PDF_A1A`, `PDF_A1B` hoặc `PDF_UA` để đảm bảo tuân thủ các hướng dẫn truy cập.

### Có thể bao gồm các slide ẩn trong PDF xuất ra không?

Có, bằng cách đặt thuộc tính `show_hidden_slides` trong `PdfOptions` thành `True`, các slide ẩn sẽ được bao gồm trong PDF.

### Làm sao điều chỉnh chất lượng và độ phân giải hình ảnh trong quá trình chuyển đổi?

Sử dụng các thuộc tính `jpeg_quality` và `sufficient_resolution` trong `PdfOptions` để kiểm soát chất lượng và độ phân giải hình ảnh trong PDF kết quả.

### Aspose.Slides có tự động xử lý việc thay thế phông chữ không?

Aspose.Slides phát hiện việc thay thế phông chữ trong quá trình chuyển đổi, và bạn có thể xử lý chúng bằng thuộc tính `warning_callback` trong `SaveOptions` (hiện tại còn hạn chế).

## **Tài nguyên bổ sung**

- [Aspose.Slides for .NET Documentation](https://docs.aspose.com/slides/vi/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/vi/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/vi/conversion)