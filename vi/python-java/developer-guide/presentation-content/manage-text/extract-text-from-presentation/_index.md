---
title: Trích xuất Văn bản Nâng cao từ Bản trình bày trong Python qua Java
linktitle: Trích xuất Văn bản
type: docs
weight: 90
url: /vi/python-java/extract-text-from-presentation/
keywords:
- trích xuất văn bản
- trích xuất văn bản từ slide
- trích xuất văn bản từ bản trình bày
- trích xuất văn bản từ PowerPoint
- trích xuất văn bản từ OpenDocument
- trích xuất văn bản từ PPT
- trích xuất văn bản từ PPTX
- trích xuất văn bản từ ODP
- lấy văn bản
- lấy văn bản từ slide
- lấy văn bản từ bản trình bày
- lấy văn bản từ PowerPoint
- lấy văn bản từ OpenDocument
- lấy văn bản từ PPT
- lấy văn bản từ PPTX
- lấy văn bản từ ODP
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Nhanh chóng trích xuất văn bản từ các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua Java. Thực hiện theo hướng dẫn đơn giản, từng bước của chúng tôi để tiết kiệm thời gian."
---
## **Tổng quan**

Việc trích xuất văn bản từ các bản trình bày là một nhiệm vụ phổ biến nhưng quan trọng đối với các nhà phát triển làm việc với nội dung slide. Dù bạn đang xử lý các tệp Microsoft PowerPoint ở định dạng PPT hoặc PPTX, hay các bản trình bày OpenDocument (ODP), việc truy cập và lấy dữ liệu văn bản có thể thiết yếu cho việc phân tích, tự động hoá, lập chỉ mục hoặc di chuyển nội dung.

Bài viết này cung cấp hướng dẫn toàn diện về cách hiệu quả trích xuất văn bản từ các định dạng bản trình bày khác nhau, bao gồm PPT, PPTX và ODP, bằng Aspose.Slides for Python via Java. Bạn sẽ học cách lặp lại có hệ thống các thành phần trong bản trình bày để lấy chính xác nội dung văn bản cần thiết.

## **Trích xuất văn bản từ một Slide**

Aspose.Slides for Python via Java cung cấp lớp [SlideUtil](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideutil/) . Lớp này mở ra một số phương thức tĩnh nạp chồng để trích xuất toàn bộ văn bản từ một bản trình bày hoặc slide. Để trích xuất văn bản từ một slide trong bản trình bày, sử dụng phương thức [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideutil/#getAllTextBoxes). Phương thức này nhận một đối tượng kiểu [BaseSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/) làm tham số. Khi thực thi, phương thức sẽ quét toàn bộ slide để tìm văn bản và trả về một mảng các đối tượng kiểu [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/), bảo toàn mọi định dạng văn bản.

Đoạn mã dưới đây trích xuất toàn bộ văn bản từ slide đầu tiên của bản trình bày:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Trích xuất văn bản từ một Bài thuyết trình**

Để quét văn bản từ toàn bộ bản trình bày, sử dụng phương thức tĩnh [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideutil/#getAllTextFrames) được cung cấp bởi lớp [SlideUtil](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideutil/). Phương thức này nhận hai tham số:

1. Đầu tiên, một đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) đại diện cho bản trình bày PowerPoint hoặc OpenDocument mà từ đó văn bản sẽ được trích xuất.
2. Thứ hai, một giá trị `bool` chỉ ra liệu các slide master có nên được bao gồm khi quét văn bản từ bản trình bày hay không.

Phương thức trả về một mảng các đối tượng kiểu [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/), bao gồm thông tin định dạng văn bản. Đoạn mã dưới đây quét văn bản và chi tiết định dạng từ một bản trình bày, bao gồm cả các slide master.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Trích xuất văn bản có phân loại và nhanh**

Lớp [PresentationFactory](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationfactory/) cũng cung cấp các phương thức để trích xuất toàn bộ văn bản từ các bản trình bày:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# Trích xuất văn bản từ tệp.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# Trích xuất văn bản từ luồng.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# Trích xuất văn bản từ luồng sử dụng tùy chọn tải.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

Tham số enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textextractionarrangingmode/) cho biết chế độ sắp xếp kết quả trích xuất văn bản và có thể được đặt thành các giá trị sau:

- [Unarranged](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) - Văn bản thô mà không quan tâm tới vị trí trên slide.
- [Arranged](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textextractionarrangingmode/#Arranged) - Văn bản được sắp xếp theo cùng thứ tự như trên slide.

Chế độ Unarranged có thể được sử dụng khi tốc độ là yếu tố quan trọng; nó nhanh hơn chế độ Arranged.

[PresentationText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationtext/) đại diện cho văn bản thô được trích xuất từ bản trình bày. Phương thức [PresentationText.getSlidesText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentationtext/#getSlidesText) trả về một mảng các đối tượng kiểu `SlideText`. Mỗi đối tượng đại diện cho văn bản trên slide tương ứng. Đối tượng kiểu `SlideText` có các phương thức sau:

- `getText` - Văn bản trong các shape của slide.
- `getMasterText` - Văn bản trong các shape của slide master liên quan đến slide này.
- `getLayoutText` - Văn bản trong các shape của slide layout liên quan đến slide này.
- `getNotesText` - Văn bản trong các shape của slide ghi chú liên quan đến slide này.
- `getCommentsText` - Văn bản trong các bình luận liên quan đến slide này.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **Câu hỏi thường gặp**

**Aspose.Slides xử lý các bản trình bày lớn như thế nào khi trích xuất văn bản?**

Aspose.Slides được tối ưu cho hiệu năng cao và có thể xử lý ngay cả [các bài thuyết trình lớn](/slides/vi/python-java/open-presentation/), phù hợp cho các kịch bản xử lý thời gian thực hoặc xử lý hàng loạt.

**Aspose.Slides có thể trích xuất văn bản từ bảng và biểu đồ trong bản trình bày không?**

Có. Aspose.Slides có thể trích xuất văn bản từ nhiều thành phần slide, bao gồm bảng và các đối tượng liên quan đến biểu đồ, cho phép bạn truy cập và phân tích nội dung văn bản trong các cấu trúc bản trình bày phổ biến.

**Tôi có cần giấy phép đặc biệt của Aspose.Slides để trích xuất văn bản từ bản trình bày không?**

Bạn có thể trích xuất văn bản bằng phiên bản dùng thử miễn phí của Aspose.Slides, tuy nhiên nó sẽ có [một số hạn chế](/slides/vi/python-java/licensing/), chẳng hạn như chỉ xử lý một số lượng slide giới hạn. Để sử dụng không giới hạn và xử lý các bản trình bày lớn hơn, việc mua giấy phép đầy đủ được khuyến nghị.