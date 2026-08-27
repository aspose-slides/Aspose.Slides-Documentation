---
title: Tìm kiếm và Thay thế Văn bản trong Bài thuyết trình PowerPoint bằng Python
linktitle: Tìm kiếm và Thay thế Văn bản
type: docs
weight: 55
url: /vi/python-net/search-and-replace-text/
keywords:
- tìm kiếm văn bản
- tô sáng văn bản
- thay thế văn bản
- biểu thức chính quy
- khung văn bản
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm kiếm, tô sáng và thay thế văn bản trong các bài thuyết trình PowerPoint bằng Aspose.Slides for Python qua .NET."
---
## **Tổng quan**

Aspose.Slides for Python thông qua .NET có thể tìm kiếm, tô sáng và thay thế văn bản trong một khung văn bản riêng lẻ hoặc trên toàn bộ bài thuyết trình. Những tính năng này hữu ích cho việc xem xét, che thận, kiểm tra thuật ngữ, dọn dẹp mẫu và các quy trình xử lý tài liệu tự động khác.

Trong các ví dụ đầu tiên bên dưới, chúng tôi sử dụng tệp có tên "sample.pptx", chứa một hộp văn bản duy nhất trên slide đầu tiên với văn bản sau:

![Văn bản mẫu](sample_text.png)

## **Chọn phạm vi tìm kiếm**

Sử dụng các phương thức trên [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) để giới hạn một thao tác cho một khung văn bản. Sử dụng các phương thức trên [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) để xử lý tất cả văn bản áp dụng trong bài thuyết trình.

| Thao tác | Một khung văn bản | Toàn bộ bài thuyết trình |
|---|---|---|
| Tô sáng văn bản nguyên gốc | [TextFrame.highlight_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/highlight_text/) |
| Tô sáng kết quả khớp biểu thức chính quy | [TextFrame.highlight_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/highlight_regex/) |
| Thay thế văn bản nguyên gốc | [TextFrame.replace_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/replace_text/) |
| Thay thế kết quả khớp biểu thức chính quy | [TextFrame.replace_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/replace_regex/) |

## **Cấu hình khớp văn bản**

Đối với các thao tác văn bản nguyên gốc, sử dụng [TextSearchOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/) để kiểm soát việc khớp:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/whole_words_only/) giới hạn các kết quả chỉ ở các từ hoàn chỉnh.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/case_sensitive/) kiểm soát việc có phải khớp đúng chữ hoa/chữ thường hay không.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/include_notes/) bao gồm ghi chú slide trong các thao tác tìm kiếm, thay thế và tô sáng ở mức bài thuyết trình.

Các thao tác biểu thức chính quy sử dụng một chuỗi mẫu, do đó các quy tắc khớp như độ nhạy chữ hoa/chữ thường và ranh giới từ được xác định trong biểu thức.

## **Xác định chủ sở hữu của khung văn bản**

Các quy trình xử lý văn bản chung thường nhận được một [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) khi tìm kiếm, thay thế, xác thực hoặc xuất văn bản. Sử dụng [TextFrame.parent_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/parent_shape/) và [TextFrame.parent_cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/parent_cell/) để xác định đối tượng bài thuyết trình nào sở hữu khung văn bản.

Các giá trị dự kiến phụ thuộc vào chủ sở hữu:

| Chủ sở hữu khung văn bản | `parent_shape` | `parent_cell` |
|---|---|---|
| Một AutoShape hoặc một hình dạng chứa văn bản khác | The owning [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) | `None` |
| Một ô bảng | `None` | The owning [Cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cell/) |

Cả hai thuộc tính đều là thuộc tính chỉ đọc để điều hướng. Đọc chúng không di chuyển khung văn bản hay thay đổi chủ sở hữu. Mã chung nên kiểm tra cả hai giá trị xem có `None` và xử lý khả năng không có chủ sở hữu nào.

Ví dụ sau sử dụng [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/vi/python-net/aspose.slides.util/slideutil/get_all_text_frames/) để duyệt qua các khung văn bản trong một bài thuyết trình. Đối với các hình dạng, nó báo cáo tên hình dạng, kiểu thời gian chạy Python và slide chứa. Đối với các ô bảng, nó báo cáo tọa độ cột và hàng bắt đầu từ 0 và slide chứa.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

Đối với nội dung SmartArt, duyệt qua các hình dạng trong [SmartArtNode.shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartartnode/shapes/) và truy cập mỗi [ISmartArtShape.text_frame](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/ismartartshape/text_frame/). Khung văn bản có thể được truy xuất đến hình dạng liên quan thông qua [TextFrame.parent_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/parent_shape/), trong khi [TextFrame.parent_cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/parent_cell/) là `None`. Do đó, nhánh hình dạng trong ví dụ cũng xử lý văn bản từ các nút SmartArt.

## **Tô sáng văn bản**

Sử dụng phương thức [TextFrame.highlight_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/highlight_text/) để tô sáng các kết quả khớp văn bản nguyên gốc trong một khung văn bản. Gửi [TextSearchOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/) để kiểm soát việc tìm kiếm.

Mã ví dụ dưới đây tô sáng tất cả các lần xuất hiện của ký tự **"try"** và sau đó chỉ tô sáng từ hoàn chỉnh **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Đánh dấu mọi lần xuất hiện của "try" trong khung văn bản.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Đánh dấu chỉ từ hoàn chỉnh "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Văn bản đã được tô sáng](highlighted_text.png)

## **Tô sáng văn bản bằng biểu thức chính quy**

Phương thức [TextFrame.highlight_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/highlight_regex/) tô sáng các kết quả khớp được tìm thấy bằng biểu thức chính quy trong một khung văn bản.

Mã sau tô sáng tất cả các từ chứa bảy ký tự trở lên:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

Kết quả:

![Văn bản đã được tô sáng bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Tô sáng văn bản trên toàn bộ bài thuyết trình**

Sử dụng [Presentation.highlight_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/highlight_text/) và [Presentation.highlight_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/highlight_regex/) để tìm kiếm tất cả các khung văn bản áp dụng trong một bài thuyết trình. Ví dụ sau tô sáng một thuật ngữ nguyên gốc và tất cả địa chỉ email:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Thay thế văn bản trong một khung văn bản**

Sử dụng [TextFrame.replace_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_text/) cho văn bản nguyên gốc và [TextFrame.replace_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_regex/) cho việc thay thế dựa trên mẫu. Các phương thức này cập nhật văn bản khớp trong khung văn bản hiện có, giữ lại định dạng phần xung quanh thay vì tạo lại khung văn bản từ một chuỗi thuần.

Ví dụ sau chuẩn hoá một biến thể chính tả và sau đó thay thế các nhãn phiên bản:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

Nếu một kết quả khớp bao phủ các phần có định dạng khác nhau, hãy xem lại đầu ra để xác nhận định dạng nào sẽ được áp dụng cho văn bản thay thế.

## **Thay thế văn bản trên toàn bộ bài thuyết trình**

Sử dụng [Presentation.replace_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/replace_text/) và [Presentation.replace_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/replace_regex/) để áp dụng các thao tác tương tự trên toàn bài thuyết trình. Điều này hữu ích cho việc dọn dẹp mẫu, cập nhật thuật ngữ và che thận.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể tìm kiếm chỉ một hộp văn bản thay vì toàn bộ bài thuyết trình?**

Lấy khung văn bản của hình dạng và gọi [TextFrame.highlight_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_text/), hoặc [TextFrame.replace_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_regex/) trên khung văn bản đó. Các phương thức ở mức bài thuyết trình sẽ xử lý tất cả các khung văn bản áp dụng.

**Làm thế nào tôi có thể khớp toàn bộ từ với đúng chữ hoa/chữ thường?**

Đặt [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/whole_words_only/) và [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/case_sensitive/) thành `True`, và truyền các tùy chọn này vào phương thức tô sáng hoặc thay thế văn bản nguyên gốc. Đối với biểu thức chính quy, xác định ranh giới từ và độ nhạy chữ hoa/chữ thường trong chính mẫu.

**Tìm kiếm và thay thế có thể bao gồm văn bản trong ghi chú slide không?**

Có. Đặt [TextSearchOptions.include_notes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/include_notes/) thành `True` khi sử dụng thao tác văn bản nguyên gốc ở mức bài thuyết trình.

**Việc thay thế văn bản có giữ nguyên định dạng không?**

[TextFrame.replace_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_text/) và [TextFrame.replace_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_regex/) sửa đổi văn bản khớp trong khung văn bản hiện có và giữ lại định dạng phần xung quanh. Nếu một kết quả khớp bao phủ các phần có định dạng khác nhau, hãy kiểm tra kết quả để đảm bảo việc thay thế sử dụng kiểu mong muốn.