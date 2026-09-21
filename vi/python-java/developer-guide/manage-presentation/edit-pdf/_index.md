---
title: Chỉnh sửa tài liệu PDF trong Python qua Java
linktitle: Chỉnh sửa PDF
type: docs
weight: 65
url: /vi/python-java/edit-pdf/
keywords:
- chỉnh sửa PDF
- thay thế văn bản PDF
- PDF sang PPTX
- PPTX sang PDF
- Python
- Java
- Aspose.Slides
description: "Chỉnh sửa tài liệu PDF trong Python qua Java bằng cách nhập chúng vào Aspose.Slides, thay thế văn bản và lưu bản trình bày đã sửa lại thành PDF."
---
## **Tổng quan**

Aspose.Slides for Python via Java cho phép bạn chỉnh sửa nội dung PDF bằng cách nhập các trang của nó dưới dạng slide, chỉnh sửa bản trình bày và xuất lại dưới dạng PDF. Bài viết này minh họa cách thay thế văn bản đơn giản. Bản trình bày được giữ trong bộ nhớ, vì vậy việc lưu tệp PPTX trung gian là tùy chọn.

## **Thay thế văn bản trong PDF**

Sử dụng [addFromPdf](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addFromPdf) để nhập các trang, [replaceText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#replaceText) để cập nhật văn bản và [save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) để xuất kết quả.

Ví dụ dưới đây giả định rằng `input.pdf` chứa từ “Draft” dưới dạng văn bản có thể chỉnh sửa sau khi nhập. Nó sẽ thay thế từ đó bằng “Final” và ghi ra `edited.pdf`. Xóa slide đầu tiên trước khi nhập ngăn việc tạo thêm một trang trống trong kết quả. Tìm kiếm khớp toàn bộ từ với cùng kiểu chữ; `None` có nghĩa là không cần hàm gọi lại kết quả.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Để biết thêm tùy chọn, xem [Search and Replace Text](/slides/vi/python-java/search-and-replace-text/) và [Convert PowerPoint to PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Việc thay thế văn bản chỉ áp dụng cho văn bản được nhập, không phải văn bản nằm trong ảnh đã quét. Quá trình chuyển đổi có thể ảnh hưởng đến bố cục và định dạng, vì vậy hãy kiểm tra kết quả, đặc biệt khi văn bản thay thế dài hơn so với văn bản gốc.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có cần lưu tệp PPTX trước khi xuất PDF không?**

Không. Bạn có thể chỉnh sửa và xuất cùng một bản trình bày trong bộ nhớ. Chỉ lưu bản sao PPTX nếu bạn cũng muốn tiếp tục chỉnh sửa nó trong PowerPoint; xem [Save Presentations](/slides/vi/python-java/save-presentation/).

**Tại sao một số văn bản vẫn không thay đổi?**

Ví dụ khớp toàn bộ từ “Draft” với kiểu chữ chính xác. Văn bản được nhập dưới dạng ảnh hoặc được chia thành nhiều khung văn bản riêng biệt sẽ không nhất thiết khớp với tìm kiếm. Kiểm tra nội dung đã nhập và điều chỉnh tiêu chí tìm kiếm cho tài liệu của bạn.