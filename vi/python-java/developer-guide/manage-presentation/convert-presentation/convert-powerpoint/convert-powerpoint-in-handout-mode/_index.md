---
title: Chuyển đổi bài thuyết trình PowerPoint ở chế độ Handout bằng Python
linktitle: Chế độ Handout
type: docs
weight: 150
url: /vi/python-java/convert-powerpoint-in-handout-mode/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chế độ handout
- handout
- PPT
- PPTX
- PowerPoint
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi bài thuyết trình PowerPoint thành bản handout trong Python qua Java. Sắp xếp nhiều slide trên mỗi trang và xuất ra PDF bằng Aspose.Slides."
---
## **Giới thiệu**

Aspose.Slides for Python via Java cho phép bạn xuất bản trình chiếu ở chế độ handout, sắp xếp nhiều slide trên một trang. Điều này hữu ích cho việc in tài liệu trình chiếu cho hội nghị, hội thảo và các sự kiện tương tự.

Cấu hình bố cục thông qua phương thức [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). Các bố cục handout được hỗ trợ bởi [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/htmloptions/) và [TiffOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/). Sử dụng đối tượng [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/handoutlayoutingoptions/) để chỉ định các thiết lập bố cục và hiển thị.

## **Xuất chế độ Handout**

Để xuất một bản trình chiếu ở chế độ handout, tạo một thể hiện [HandoutLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/handoutlayoutingoptions/) và gán nó cho các tùy chọn xuất đích bằng cách sử dụng [setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Ví dụ sau tải `sample.pptx` và xuất nó ra PDF với bốn slide mỗi trang theo thứ tự ngang. Nó bao gồm số slide và khung quanh các slide, và không bao gồm bình luận.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Tải bản trình chiếu.
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

{{% alert color="warning" title="Cảnh báo" %}}
Cài đặt bố cục handout áp dụng cho các định dạng đầu ra được hỗ trợ, chẳng hạn như PDF, HTML, TIFF và các hình ảnh đã render. Chúng không sắp xếp lại các slide trong bản trình chiếu nguồn.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Số lượng thu nhỏ slide tối đa mỗi trang trong chế độ handout là bao nhiêu?**

Aspose.Slides hỗ trợ tối đa chín thu nhỏ mỗi trang. Các cài đặt sẵn của [HandoutType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/handouttype/) cung cấp một, hai, ba, bốn, sáu hoặc chín slide mỗi trang. Các cài đặt sẵn bốn, sáu và chín slide cho phép sắp xếp ngang và dọc.

**Tôi có thể định nghĩa lưới tùy chỉnh, chẳng hạn như năm hoặc tám slide mỗi trang không?**

Không. Số lượng và thứ tự của các thu nhỏ được kiểm soát bởi các giá trị [HandoutType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/handouttype/) đã được định sẵn. Các lưới tùy ý không được hỗ trợ bởi các cài đặt bố cục handout này.

**Tôi có thể bao gồm các slide ẩn trong đầu ra handout không?**

Có. Bật các slide ẩn trong cài đặt xuất cho định dạng đích. Đối với PDF, gọi [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) với `True` trước khi lưu bản trình chiếu.