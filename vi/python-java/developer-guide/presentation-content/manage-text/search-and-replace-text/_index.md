---
title: Tìm kiếm và Thay thế Văn bản trong Bài thuyết trình PowerPoint bằng Python qua Java
linktitle: Tìm kiếm và Thay thế Văn bản
type: docs
weight: 55
url: /vi/python-java/search-and-replace-text/
keywords:
- văn bản tìm kiếm
- văn bản tô sáng
- văn bản thay thế
- biểu thức chính quy
- callback kết quả
- khung văn bản
- báo cáo kiểm toán
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Tìm kiếm, tô sáng và thay thế văn bản trong các bài thuyết trình PowerPoint đồng thời thu thập mọi kết quả khớp với Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Aspose.Slides for Python qua Java có thể tìm kiếm, tô sáng và thay thế văn bản trong một khung văn bản riêng lẻ hoặc trên toàn bộ bản trình bày. Mỗi thao tác cũng có thể thông báo cho ứng dụng về mọi kết quả khớp thông qua một callback kết quả. Điều này cho phép cập nhật bản trình bày và đồng thời xây dựng một nhật ký kiểm toán chứa văn bản khớp, ngữ cảnh, vị trí, khung văn bản và số slide.

Các khả năng này hữu ích cho việc rà soát, xóa nhạy cảm, kiểm tra thuật ngữ, làm sạch mẫu và quy trình báo cáo tự động.

Trong các ví dụ đầu tiên bên dưới, chúng tôi sử dụng tệp có tên “sample.pptx”, chứa một hộp văn bản duy nhất trên slide đầu tiên với đoạn văn bản sau:

![Văn bản mẫu](sample_text.png)

## **Chọn phạm vi tìm kiếm**

Sử dụng các phương thức trên [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) để giới hạn một thao tác cho một khung văn bản. Sử dụng các phương thức trên [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) để xử lý tất cả văn bản áp dụng trong bản trình bày.

| Thao tác | Một khung văn bản | Toàn bộ bản trình bày |
|---|---|---|
| Tô sáng văn bản nguyên văn | [TextFrame.highlightText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#highlightText) | [Presentation.highlightText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#highlightText) |
| Tô sáng các khớp biểu thức chính quy | [TextFrame.highlightRegex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#highlightRegex) | [Presentation.highlightRegex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#highlightRegex) |
| Thay thế văn bản nguyên văn | [TextFrame.replaceText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#replaceText) | [Presentation.replaceText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#replaceText) |
| Thay thế các khớp biểu thức chính quy | [TextFrame.replaceRegex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#replaceRegex) | [Presentation.replaceRegex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#replaceRegex) |

## **Cấu hình khớp văn bản**

Đối với các thao tác văn bản nguyên văn, sử dụng [TextSearchOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textsearchoptions/) để kiểm soát việc khớp:

- [setWholeWordsOnly](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) giới hạn kết quả khớp chỉ với các từ hoàn chỉnh.
- [setCaseSensitive](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textsearchoptions/#setCaseSensitive) kiểm soát việc có phải khớp phân biệt chữ hoa/thường hay không.
- [setIncludeNotes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textsearchoptions/#setIncludeNotes) bao gồm ghi chú slide trong các thao tác tìm kiếm, thay thế và tô sáng ở mức bản trình bày.

Các thao tác biểu thức chính quy sử dụng một `Pattern` của Java, vì vậy các quy tắc khớp như phân biệt chữ hoa/thường và ranh giới từ được xác định bởi biểu thức và các cờ của nó.

## **Xác định chủ sở hữu của khung văn bản**

Các quy trình xử lý văn bản tổng quát thường nhận một [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) khi tìm kiếm, thay thế, xác thực hoặc xuất văn bản. Sử dụng [TextFrame.getParentShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getParentShape) và [TextFrame.getParentCell](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getParentCell) để xác định đối tượng bản trình bày nào sở hữu khung văn bản.

Giá trị mong đợi phụ thuộc vào chủ sở hữu:

| Chủ sở hữu khung văn bản | `getParentShape` | `getParentCell` |
|---|---|---|
| Một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) hoặc một hình dạng chứa văn bản khác | Shape sở hữu | `None` |
| Một ô bảng | `None` | Cell sở hữu |

Cả hai phương thức đều chỉ cho phép điều hướng chỉ‑đọc. Gọi chúng không di chuyển khung văn bản hay thay đổi chủ sở hữu. Mã chung nên kiểm tra cả hai giá trị xem có `None` và xử lý khả năng không có chủ sở hữu nào.

Ví dụ sau sử dụng [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideutil/#getAllTextFrames) để duyệt qua các khung văn bản trong một bản trình bày. Đối với các hình dạng, nó báo cáo tên hình dạng, kiểu chạy thời gian Java và slide chứa. Đối với các ô bảng, nó báo cáo tọa độ cột và dòng (bắt đầu từ 0) và slide chứa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

presentation = Presentation("presentation.pptx")
try:
    text_frames = SlideUtil.getAllTextFrames(presentation, False)
    for text_frame in text_frames:
        owner_shape = text_frame.getParentShape()
        owner_cell = text_frame.getParentCell()
        if owner_shape is not None:
            shape_name = str(owner_shape.getName()) or "(unnamed)"
            shape_type = owner_shape.getClass().getSimpleName()
            base_slide = owner_shape.getSlide()
        elif owner_cell is not None:
            base_slide = owner_cell.getSlide()
        else:
            print("The text frame owner is not available as a shape or table cell.")
            continue

        if isinstance(base_slide, Slide):
            slide_label = f"slide {base_slide.getSlideNumber()}"
        elif isinstance(base_slide, NotesSlide):
            slide_label = f"notes for slide {base_slide.getParentSlide().getSlideNumber()}"
        else:
            slide_label = str(base_slide.getClass().getSimpleName())

        if owner_shape is not None:
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
        else:
            print(f"Table cell: column {owner_cell.getFirstColumnIndex()}, row {owner_cell.getFirstRowIndex()}; {slide_label}")
finally:
    presentation.dispose()
```

Đối với nội dung SmartArt, duyệt qua các hình dạng trong [SmartArtNode.getShapes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartnode/#getShapes) và truy cập mỗi [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartshape/#getTextFrame). Khung văn bản có thể được truy vết tới hình dạng liên quan thông qua [TextFrame.getParentShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getParentShape), trong khi [TextFrame.getParentCell](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getParentCell) trả về `None`. Do đó, nhánh hình dạng trong ví dụ cũng xử lý văn bản từ các nút SmartArt.

## **Thu thập thông tin khớp với Callback**

Triển khai `IFindResultCallback` thông qua `jpype.JProxy` để nhận thông báo cho mỗi kết quả khớp. Phương thức `foundResult` của nó cung cấp khung văn bản liên quan, văn bản nguồn, văn bản khớp và vị trí khớp.

Callback không nhận trực tiếp số slide. Triển khai dưới đây suy ra nó từ slide cha và cũng xử lý văn bản được tìm thấy trong ghi chú slide. Một số slide tùy chọn cho phép cùng một mô hình kết quả đại diện cho văn bản liên quan tới các loại slide khác.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)
```

Đối với các thao tác thay thế, `found_text` chứa văn bản khớp gốc, vì vậy callback có thể ghi lại chính xác các thuật ngữ đã được thay thế.

## **Tô sáng văn bản**

Sử dụng phương thức [TextFrame.highlightText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#highlightText) để tô sáng các kết quả khớp văn bản nguyên văn trong một khung văn bản. Truyền [TextSearchOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textsearchoptions/) để kiểm soát việc tìm kiếm và một callback để thu thập chi tiết kết quả.

Mã ví dụ dưới đây tô sáng tất cả các lần xuất hiện của ký tự **"try"** rồi sau đó chỉ tô sáng từ hoàn chỉnh **"to"**. Cả hai tìm kiếm đều báo cáo kết quả cho cùng một callback.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)

    substring_search_options = TextSearchOptions()
    substring_search_options.setCaseSensitive(False)
    substring_highlight_color = Color(173, 216, 230)

    # Tô sáng mọi lần xuất hiện của "try" trong khung văn bản.
    shape.getTextFrame().highlightText("try", substring_highlight_color, substring_search_options, callback)

    whole_word_search_options = TextSearchOptions()
    whole_word_search_options.setWholeWordsOnly(True)
    whole_word_search_options.setCaseSensitive(False)
    whole_word_highlight_color = Color(238, 130, 238)

    # Chỉ tô sáng từ hoàn chỉnh "to".
    shape.getTextFrame().highlightText("to", whole_word_highlight_color, whole_word_search_options, callback)

    for result in callback_handler.results:
        print(f"Found '{result.found_text}' at position {result.text_position} on slide {result.slide_number}.")

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Văn bản đã được tô sáng](highlighted_text.png)

## **Tô sáng văn bản bằng biểu thức chính quy**

Phương thức [TextFrame.highlightRegex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#highlightRegex) tô sáng các kết quả khớp được tìm thấy bằng một biểu thức chính quy trong một khung văn bản.

Mã sau tô sáng tất cả các từ có bảy ký tự trở lên và thu thập mỗi kết quả:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    regex = Pattern.compile("\\b[^\\s]{7,}\\b")

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback)

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Văn bản đã được tô sáng bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Tô sáng văn bản trên toàn bộ bản trình bày**

Sử dụng [Presentation.highlightText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#highlightText) và [Presentation.highlightRegex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#highlightRegex) để tìm kiếm tất cả các khung văn bản áp dụng trong một bản trình bày. Ví dụ sau tô sáng một thuật ngữ nguyên văn và tất cả địa chỉ email, đồng thời giữ các bộ kết quả riêng biệt cho hai tìm kiếm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    term_callback_handler = TextSearchCallback()
    term_callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=term_callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(False)

    presentation.highlightText("confidential", Color.ORANGE, search_options, term_callback)

    email_callback_handler = TextSearchCallback()
    email_callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=email_callback_handler)
    email_regex = Pattern.compile("\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", Pattern.CASE_INSENSITIVE)

    presentation.highlightRegex(email_regex, Color.YELLOW, email_callback)
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thay thế văn bản trong khung văn bản**

Sử dụng [TextFrame.replaceText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#replaceText) cho văn bản nguyên văn và [TextFrame.replaceRegex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#replaceRegex) cho việc thay thế dựa trên mẫu. Các phương thức này cập nhật văn bản khớp trong khung văn bản hiện có, giữ nguyên định dạng phần xung quanh thay vì xây dựng lại khung văn bản từ một chuỗi đơn.

Ví dụ sau tiêu chuẩn hoá một biến thể chính tả rồi thay thế các nhãn phiên bản. Callback giống nhau ghi lại các thuật ngữ gốc đã khớp trong cả hai thao tác.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(False)

    shape.getTextFrame().replaceText("colour", "color", search_options, callback)

    version_regex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE)
    shape.getTextFrame().replaceRegex(version_regex, "current version", callback)

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nếu một kết quả khớp phủ một phần có định dạng khác nhau, hãy xem lại đầu ra để xác nhận định dạng nào sẽ được áp dụng cho văn bản thay thế.

## **Thay thế văn bản trên toàn bộ bản trình bày**

Sử dụng [Presentation.replaceText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#replaceText) và [Presentation.replaceRegex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#replaceRegex) để áp dụng các thao tác tương tự trên toàn bộ bản trình bày. Điều này hữu ích cho việc làm sạch mẫu, cập nhật thuật ngữ và xóa nhạy cảm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)

    presentation.replaceText("Contoso", "Example Corp", search_options, callback)

    account_number_regex = Pattern.compile("\\bACCT-\\d{6}\\b")
    presentation.replaceRegex(account_number_regex, "ACCT-REDACTED", callback)

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nhóm các khớp cho báo cáo**

Vì mỗi kết quả lưu trữ số slide và khung văn bản, các ứng dụng có thể nhóm các kết quả khớp cho mục đích kiểm toán, báo cáo hoặc quy trình rà soát. Ví dụ sau nhóm các kết quả đã thu thập đầu tiên theo slide rồi theo khung văn bản:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)

    presentation.replaceText("Contoso", "Example Corp", search_options, callback)

    account_number_regex = Pattern.compile("\\bACCT-\\d{6}\\b")
    presentation.replaceRegex(account_number_regex, "ACCT-REDACTED", callback)

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx)
    matches_by_slide = {}
    for result in callback_handler.results:
        matches_by_text_frame = matches_by_slide.setdefault(result.slide_number, {})
        text_frame_matches = matches_by_text_frame.setdefault(result.text_frame, [])
        text_frame_matches.append(result)

    for slide_number, matches_by_text_frame in matches_by_slide.items():
        slide_label = "Other" if slide_number is None else str(slide_number)
        print(f"Slide: {slide_label}")
        for text_frame, results in matches_by_text_frame.items():
            print(f"  Text frame: {text_frame.getText()}")
            for result in results:
                print(f"    '{result.found_text}' at position {result.text_position}; context: '{result.source_text}'")
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Làm sao tôi có thể tìm kiếm chỉ trong một hộp văn bản thay vì toàn bộ bản trình bày?**

Lấy khung văn bản của hình dạng và gọi [TextFrame.highlightText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#highlightText), [TextFrame.highlightRegex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#highlightRegex), [TextFrame.replaceText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#replaceText) hoặc [TextFrame.replaceRegex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#replaceRegex) trên khung văn bản đó. Các phương thức cấp độ bản trình bày sẽ xử lý tất cả các khung văn bản áp dụng.

**Làm sao tôi có thể khớp toàn bộ từ với đúng kiểu chữ?**

Đặt `TextSearchOptions.setWholeWordsOnly` và `TextSearchOptions.setCaseSensitive` thành `True`, rồi truyền các tùy chọn này vào phương thức tô sáng hoặc thay thế văn bản nguyên văn. Đối với biểu thức chính quy, định nghĩa ranh giới từ và phân biệt chữ hoa/thường trong chính `Pattern` của Java.

**Việc tìm kiếm và thay thế có bao gồm văn bản trong ghi chú slide không?**

Có. Đặt `TextSearchOptions.setIncludeNotes` thành `True` khi sử dụng một thao tác văn bản nguyên văn ở mức bản trình bày. Triển khai callback được trình bày ở trên sẽ ánh xạ kết quả trong slide ghi chú trở lại số slide cha.

**Làm sao tôi có thể tạo báo cáo mà không phải quét lại bản trình bày lần thứ hai?**

Truyền một triển khai `IFindResultCallback` vào thao tác tô sáng hoặc thay thế. Callback sẽ nhận mỗi kết quả khớp trong khi thao tác đang chạy, vì vậy ứng dụng có thể lưu trữ văn bản nguồn, văn bản khớp, vị trí, khung văn bản và số slide suy ra để sau này nhóm hoặc xuất.

**Việc thay thế văn bản có giữ nguyên định dạng không?**

[TextFrame.replaceText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#replaceText) và [TextFrame.replaceRegex](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#replaceRegex) chỉnh sửa văn bản khớp trong khung văn bản hiện có và giữ lại định dạng phần xung quanh. Nếu một kết quả khớp bao phủ các phần có định dạng khác nhau, hãy kiểm tra kết quả để đảm bảo văn bản thay thế sử dụng phong cách mong muốn.