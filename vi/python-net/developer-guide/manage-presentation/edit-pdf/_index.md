---
title: Chỉnh sửa tài liệu PDF trong Python
linktitle: Chỉnh sửa PDF
type: docs
weight: 65
url: /vi/python-net/edit-pdf/
keywords:
- chỉnh sửa PDF
- thay thế văn bản PDF
- PDF sang PPTX
- PPTX sang PDF
- Python
- Aspose.Slides
description: "Chỉnh sửa tài liệu PDF trong Python bằng cách nhập chúng vào Aspose.Slides, thay thế văn bản và lưu bản trình bày đã chỉnh sửa trở lại dưới dạng PDF."
---
## **Tổng quan**

Aspose.Slides for Python qua .NET cho phép bạn chỉnh sửa nội dung PDF bằng cách nhập các trang của nó dưới dạng slide, chỉnh sửa bản trình bày và xuất lại thành PDF. Bài viết này trình bày cách thay thế văn bản đơn giản. Bản trình bày được giữ trong bộ nhớ, vì vậy việc lưu tệp PPTX trung gian là tùy chọn.

## **Thay thế văn bản trong PDF**

Sử dụng [add_from_pdf](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidecollection/add_from_pdf/) để nhập các trang, [replace_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/replace_text/) để cập nhật văn bản, và [save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) để xuất kết quả.

Ví dụ sau giả định `input.pdf` chứa từ "Draft" dưới dạng văn bản có thể chỉnh sửa sau khi nhập. Nó sẽ thay thế từ đó bằng "Final" và ghi ra `edited.pdf`. Xóa slide đầu tiên trước khi nhập giúp ngăn một trang trống thừa trong đầu ra. Tìm kiếm khớp toàn từ với cùng kiểu chữ; `None` có nghĩa là không cần callback kết quả.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

Để biết thêm tùy chọn, xem [Tìm kiếm và Thay thế Văn bản](/slides/vi/python-net/search-and-replace-text/) và [Chuyển đổi PowerPoint sang PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Việc thay thế văn bản chỉ áp dụng cho văn bản đã được nhập, không phải văn bản trong ảnh đã quét. Quá trình chuyển đổi có thể ảnh hưởng đến bố cục và định dạng, vì vậy hãy kiểm tra kết quả, đặc biệt khi văn bản thay thế dài hơn văn bản gốc.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tôi có cần lưu tệp PPTX trước khi xuất PDF không?**

Không. Bạn có thể chỉnh sửa và xuất cùng một bản trình bày trong bộ nhớ. Chỉ lưu bản sao PPTX nếu bạn cũng muốn tiếp tục chỉnh sửa nó trong PowerPoint; xem [Lưu bản trình bày](/slides/vi/python-net/save-presentation/).

**Tại sao một số văn bản có thể không thay đổi?**

Ví dụ khớp toàn từ "Draft" với đúng kiểu chữ. Văn bản được nhập dưới dạng hình ảnh hoặc chia thành nhiều khung văn bản riêng biệt sẽ không nhất thiết khớp với tìm kiếm. Kiểm tra nội dung đã nhập và điều chỉnh tìm kiếm cho tài liệu của bạn.