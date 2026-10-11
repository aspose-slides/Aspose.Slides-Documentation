---
title: Chuyển đổi bản trình chiếu PowerPoint ở chế độ Handout bằng Python
linktitle: Chế độ Handout
type: docs
weight: 150
url: /vi/python-java/convert-powerpoint-in-handout-mode/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chế độ handout
- handout
- PPT
- PPTX
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi bản trình chiếu PowerPoint thành handout trong Python thông qua Java. Sắp xếp nhiều slide trên mỗi trang và xuất ra PDF bằng Aspose.Slides."
---
## **Giới thiệu**

Aspose.Slides for Python via Java cho phép bạn xuất bản trình chiếu ở chế độ handout, sắp xếp nhiều slide trên một trang. Điều này hữu ích cho việc in tài liệu trình chiếu cho hội nghị, hội thảo và các sự kiện tương tự.

Định cấu hình bố cục thông qua phương thức [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). Các bố cục handout được hỗ trợ bởi [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/) và [TiffOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/). Sử dụng một đối tượng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/handoutlayoutingoptions/) để chỉ định bố cục và các cài đặt hiển thị.

Để đặt kích thước trang handout và hướng trang trước khi xuất, xem [Kích thước Trang Ghi chú](/slides/vi/python-java/notes-size/).

## **Xuất chế độ Handout**

Để xuất một bản trình chiếu ở chế độ handout, tạo một thể hiện của [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/handoutlayoutingoptions/) và gán nó vào các tùy chọn xuất đích bằng cách sử dụng [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Ví dụ dưới đây tải `sample.pptx` và xuất nó ra PDF với bốn slide trên mỗi trang theo thứ tự ngang. Nó bao gồm số slide và khung quanh các slide, và loại bỏ nhận xét.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Tải một bản trình chiếu.
presentation = Presentation("sample.pptx")
try:
    # Cấu hình bố cục handout.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Xuất bản trình chiếu ra PDF với bố cục đã chọn.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Cài đặt bố cục handout áp dụng cho các định dạng đầu ra được hỗ trợ, chẳng hạn như PDF, HTML, TIFF và các hình ảnh được render. Chúng không sắp xếp lại các slide trong bản trình chiếu nguồn.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Số lượng ảnh thu nhỏ slide tối đa trên mỗi trang trong chế độ handout là bao nhiêu?**

Aspose.Slides hỗ trợ tối đa chín ảnh thu nhỏ trên mỗi trang. Các thiết lập sẵn của [HandoutType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/handouttype/) cung cấp một, hai, ba, bốn, sáu hoặc chín slide trên mỗi trang. Các thiết lập sẵn bốn, sáu và chín slide cho phép sắp xếp theo chiều ngang và chiều dọc.

**Tôi có thể định nghĩa lưới tùy chỉnh, chẳng hạn năm hoặc tám slide trên một trang không?**

Không. Số lượng và thứ tự của các ảnh thu nhỏ được kiểm soát bởi các giá trị [HandoutType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/handouttype/) được định trước. Các lưới tùy ý không được hỗ trợ bởi các cài đặt bố cục handout này.

**Tôi có thể bao gồm các slide ẩn trong đầu ra handout không?**

Có. Bật các slide ẩn trong cài đặt xuất cho định dạng đích. Đối với PDF, gọi [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) với `True` trước khi lưu bản trình chiếu.