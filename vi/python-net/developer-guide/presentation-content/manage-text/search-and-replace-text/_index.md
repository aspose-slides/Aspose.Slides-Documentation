---
title: Tìm kiếm và Thay thế Văn bản trong Bản trình chiếu PowerPoint bằng Python
linktitle: Tìm kiếm và Thay thế Văn bản
type: docs
weight: 55
url: /vi/python-net/search-and-replace-text/
keywords:
- tìm kiếm văn bản
- đánh dấu văn bản
- thay thế văn bản
- biểu thức chính quy
- khung văn bản
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm kiếm, đánh dấu và thay thế văn bản trong bản trình chiếu PowerPoint bằng Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Aspose.Slides for Python via .NET có thể tìm kiếm, đánh dấu và thay thế văn bản trong một khung văn bản riêng lẻ hoặc trên toàn bộ bản trình chiếu. Những khả năng này hữu ích cho việc xem xét, gỡ bỏ thông tin, kiểm tra thuật ngữ, dọn dẹp mẫu và các quy trình xử lý tài liệu tự động khác.

Trong các ví dụ đầu tiên bên dưới, chúng tôi sử dụng tệp có tên **"sample.pptx"**, chứa một hộp văn bản duy nhất trên slide đầu tiên với văn bản sau:

![Văn bản mẫu](sample_text.png)

## **Chọn phạm vi tìm kiếm**

Sử dụng các phương thức trên [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) để giới hạn hoạt động chỉ trong một khung văn bản. Sử dụng các phương thức trên [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) để xử lý tất cả văn bản áp dụng trong bản trình chiếu.

| Thao tác | Một khung văn bản | Toàn bộ bản trình chiếu |
|---|---|---|
| Đánh dấu văn bản thuần | [TextFrame.highlight_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/highlight_text/) |
| Đánh dấu kết quả khớp biểu thức chính quy | [TextFrame.highlight_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/highlight_regex/) |
| Thay thế văn bản thuần | [TextFrame.replace_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/replace_text/) |
| Thay thế kết quả khớp biểu thức chính quy | [TextFrame.replace_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/replace_regex/) |

## **Cấu hình khớp văn bản**

Đối với các thao tác văn bản thuần, sử dụng [TextSearchOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/) để kiểm soát việc khớp:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/whole_words_only/) chỉ cho phép khớp toàn bộ từ.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/case_sensitive/) kiểm soát việc có phân biệt chữ hoa‑thường hay không.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/include_notes/) bao gồm ghi chú slide trong các thao tác tìm kiếm, thay thế và đánh dấu ở mức bản trình chiếu.

Các thao tác biểu thức chính quy sử dụng chuỗi mẫu, do đó các quy tắc như phân biệt chữ hoa‑thường và ranh giới từ được xác định trong biểu thức.

## **Đánh dấu văn bản**

Sử dụng phương thức [TextFrame.highlight_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/highlight_text/) để đánh dấu các kết quả khớp văn bản thuần trong một khung văn bản. Truyền [TextSearchOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/) để kiểm soát việc tìm kiếm.

Mã ví dụ dưới đây đánh dấu tất cả các lần xuất hiện của ký tự **"try"** và sau đó chỉ đánh dấu từ đầy đủ **"to"**.

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

    # Đánh dấu chỉ từ đầy đủ "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Văn bản được đánh dấu](highlighted_text.png)

## **Đánh dấu văn bản bằng biểu thức chính quy**

Phương thức [TextFrame.highlight_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/highlight_regex/) đánh dấu các kết quả khớp được tìm thấy bằng biểu thức chính quy trong một khung văn bản.

Mã sau đánh dấu tất cả các từ chứa bảy ký tự trở lên:

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

![Văn bản được đánh dấu bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Đánh dấu văn bản trên toàn bộ bản trình chiếu**

Sử dụng [Presentation.highlight_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/highlight_text/) và [Presentation.highlight_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/highlight_regex/) để tìm kiếm tất cả các khung văn bản áp dụng trong bản trình chiếu. Ví dụ sau đánh dấu một thuật ngữ thuần và tất cả các địa chỉ email:

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

## **Thay thế văn bản trong khung văn bản**

Sử dụng [TextFrame.replace_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_text/) cho văn bản thuần và [TextFrame.replace_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_regex/) cho việc thay thế dựa trên mẫu. Các phương thức này cập nhật văn bản đã khớp bên trong khung văn bản hiện có, giữ định dạng phần xung quanh thay vì xây dựng lại khung văn bản từ một chuỗi thuần.

Ví dụ sau chuẩn hoá một biến thể cách viết và sau đó thay thế các nhãn phiên bản:

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

Nếu một kết quả khớp bao phủ các phần có định dạng khác nhau, hãy xem lại đầu ra để xác nhận định dạng nào sẽ áp dụng cho văn bản thay thế.

## **Thay thế văn bản trên toàn bộ bản trình chiếu**

Sử dụng [Presentation.replace_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/replace_text/) và [Presentation.replace_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/replace_regex/) để thực hiện cùng các thao tác trên toàn bộ bản trình chiếu. Điều này hữu ích cho việc dọn dẹp mẫu, cập nhật thuật ngữ và gỡ bỏ thông tin.

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

**Làm sao tôi có thể tìm kiếm chỉ trong một hộp văn bản thay vì toàn bộ bản trình chiếu?**

Lấy khung văn bản của shape và gọi [TextFrame.highlight_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_text/) hoặc [TextFrame.replace_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_regex/) trên khung văn bản đó. Các phương thức ở mức bản trình chiếu sẽ xử lý tất cả các khung văn bản áp dụng.

**Làm sao tôi có thể khớp toàn bộ từ với cách viết chữ hoa‑thường đúng?**

Đặt [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/whole_words_only/) và [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/case_sensitive/) thành `True`, và truyền các tùy chọn này vào phương thức đánh dấu hoặc thay thế văn bản thuần. Đối với biểu thức chính quy, định nghĩa ranh giới từ và phân biệt chữ hoa‑thường trực tiếp trong mẫu.

**Tìm kiếm và thay thế có bao gồm văn bản trong ghi chú slide không?**

Có. Đặt [TextSearchOptions.include_notes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textsearchoptions/include_notes/) thành `True` khi sử dụng thao tác văn bản thuần ở mức bản trình chiếu.

**Việc thay thế văn bản có giữ nguyên định dạng không?**

[TextFrame.replace_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_text/) và [TextFrame.replace_regex](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/replace_regex/) chỉnh sửa văn bản đã khớp bên trong khung văn bản hiện có và giữ nguyên định dạng phần xung quanh. Nếu một kết quả khớp bao phủ các phần có định dạng khác nhau, hãy kiểm tra kết quả để đảm bảo văn bản thay thế sử dụng kiểu định dạng mong muốn.