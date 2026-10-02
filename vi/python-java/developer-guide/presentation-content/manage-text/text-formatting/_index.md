---
title: Định dạng Văn bản Bài thuyết trình trong Python qua Java
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/python-java/text-formatting/
keywords:
- căn đoạn
- kiểu văn bản
- nền văn bản
- độ trong suốt văn bản
- khoảng cách ký tự
- thuộc tính phông chữ
- họ phông chữ
- xoay văn bản
- góc xoay
- khung văn bản
- khoảng cách dòng
- thuộc tính tự động vừa khít
- neo khung văn bản
- đánh dấu tab
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Định dạng và tạo kiểu văn bản trong các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua Java. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và hơn nữa."
---
## **Tổng quan**

Bài viết này trình bày cách định dạng văn bản trong các bản thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides for Python via Java. Nó bao gồm màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn, hành vi tự động vừa khít, neo văn bản, dấu tab và cài đặt ngôn ngữ.

Trừ khi có ghi chú khác, các ví dụ sử dụng [sample.pptx](sample.pptx). Hình dạng đầu tiên trên slide đầu tiên là một hộp văn bản, và đoạn văn đầu tiên chứa văn bản được hiển thị dưới đây. Cả chỉ số slide và hình dạng đều bắt đầu từ 0. Các ví dụ chọn phần in đậm sử dụng định dạng hiệu quả, bao gồm cả định dạng in đậm kế thừa:

![Văn bản mẫu](sample_text.png)

Để tìm và làm nổi bật văn bản nguyên mẫu hoặc các khớp biểu thức chính quy, xem [Tìm và Thay thế Văn bản](/slides/vi/python-java/search-and-replace-text/).

## **Đặt Màu Nền cho Văn bản**

Sử dụng [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) để đặt màu tô sáng mặc định cho một đoạn, hoặc sử dụng [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) cho các phần văn bản riêng lẻ.

Ví dụ sau đặt màu tô sáng xám nhạt làm mặc định cho đoạn đầu tiên. Màu tô sáng cụ thể trên các phần riêng lẻ sẽ có ưu tiên hơn mặc định này:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Đặt màu tô sáng cho toàn bộ đoạn.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Đoạn văn xám](gray_paragraph.png)

Ví dụ mã dưới đây minh họa cách đặt màu nền cho **các phần văn bản có phông chữ in đậm**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Đặt màu tô sáng cho phần văn bản.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Các phần văn bản xám](gray_text_portions.png)

## **Căn Lề Đoạn Văn Bản**

Sử dụng [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) để đặt căn lề đoạn trong một khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, căn đều, v.v.

Ví dụ mã sau cho thấy cách căn đoạn **ở giữa**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Đặt căn chỉnh của đoạn văn thành trung tâm.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Đoạn văn đã căn chỉnh](aligned_paragraph.png)

## **Căn Lề Phông Chữ Trong Dòng**

Sử dụng [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) để căn dọc các phần văn bản có kích thước phông khác nhau trong một dòng. Cài đặt này áp dụng cho toàn đoạn và kiểm soát căn lề trong mỗi dòng của đoạn.

Ví dụ độc lập sau tạo bốn hộp văn bản có nhãn trên một slide. Mỗi đoạn chứa cùng một văn bản với kích thước 18, 36 và 54 điểm, với căn lề phông chữ khác nhau. Nó sử dụng Arial, tắt tự động vừa khít và xuống dòng, và giữ khung văn bản đủ rộng cho một dòng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![So sánh căn lề Baseline, Top, Center và Bottom với các kích thước phông chữ hỗn hợp](font_alignment.png)

Căn lề phông chữ dựa trên các chỉ số phông, vì vậy các cạnh hiển thị của các ký tự riêng lẻ không nhất thiết phải thẳng hàng hoàn toàn. Ví dụ bao gồm cả một ký tự in hoa và một ký tự có phần dưới để minh họa sự khác nhau giữa căn lề Baseline và Bottom. Khả năng sẵn có và thay thế phông, ký tự được sử dụng, và sự chênh lệch kích thước phông ảnh hưởng đến kết quả. Kích thước khung, lề, khoảng cách dòng, việc xuống dòng và tự động vừa khít cũng ảnh hưởng đến bố cục; hãy dùng cùng một phông và cùng cài đặt bố cục khi so sánh các chế độ.

Cài đặt này khác với [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment), kiểm soát căn lề ngang của đoạn, và [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType), định vị khối văn bản theo chiều dọc trong hình dạng. Định dạng chỉ số trên và dưới thông qua [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) dịch chuyển các phần riêng lẻ so với baseline thay vì đặt căn lề phông cho các dòng của đoạn.

## **Đặt Độ Trong Suốt cho Văn bản**

Độ trong suốt văn bản được kiểm soát qua thành phần alpha của màu được gán cho [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Trong các ví dụ dưới, `alpha = 50` là giá trị alpha ARGB trên thang 0‑255, không phải phần trăm trong suốt.

Ví dụ mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn đoạn**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Đặt màu nền của văn bản thành màu trong suốt.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Đoạn văn trong suốt](transparent_paragraph.png)

Ví dụ mã sau cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông chữ in đậm**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Đặt độ trong suốt cho phần văn bản.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Các phần văn bản trong suốt](transparent_text_portions.png)

## **Đặt Khoảng Cách Ký Tự cho Văn bản**

Sử dụng [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) để tăng hoặc giảm khoảng cách giữa các ký tự trong một hộp văn bản. Các ví dụ thêm 3 điểm khoảng cách; giá trị âm sẽ làm văn bản gọn lại.

Mã Python sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn đoạn**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Mở rộng khoảng cách ký tự.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Khoảng cách ký tự trong đoạn](character_spacing_in_paragraph.png)

Ví dụ mã dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông chữ in đậm**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
            portion.getPortionFormat().setSpacing(3) # Mở rộng khoảng cách ký tự.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Khoảng cách ký tự trong các phần văn bản](character_spacing_in_text_portions.png)

### **Vô Hiệu Hóa Kerning cho Các Phông Chữ Cụ Thể**

Trong một số trường hợp, văn bản do Aspose.Slides hiển thị có thể trông hơi chặt hơn so với cùng văn bản trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông, ngay cả khi phông chứa thông tin kerning hợp lệ và kerning đã được bật trong cài đặt PowerPoint.

Để làm cho đầu ra được hiển thị gần hơn với PowerPoint trong các trường hợp này, bạn có thể tắt kerning cho các phần văn bản sử dụng phông bị ảnh hưởng. Đặt [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) thành một giá trị lớn hơn kích thước phông thực tế. Ví dụ này yêu cầu “presentation.pptx” có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Nó kiểm tra tên phông hiệu quả, bao gồm các phông kế thừa, và đặt ngưỡng 100 điểm cho các phần sử dụng Roboto. Điều này vô hiệu hoá kerning cho các phần có kích thước phông dưới 100 điểm:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Đối với các đoạn văn bản phù hợp dưới ngưỡng, cài đặt này ngăn kerning và có thể giúp kết quả hiển thị của Aspose.Slides gần hơn với hình ảnh trong PowerPoint cho các phông bị hành vi đặc thù này ảnh hưởng.

## **Quản Lý Thuộc Tính Phông Chữ của Văn bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) hoặc trên các phần riêng lẻ thông qua [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/).

Ví dụ sau đặt phông mặc định cho đoạn đầu tiên là Times New Roman 12 điểm, in đậm, nghiêng và gạch chân chấm. Định dạng cụ thể trên các phần riêng lẻ sẽ có ưu tiên hơn các mặc định này:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Đặt thuộc tính phông chữ cho đoạn văn.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Thuộc tính phông cho đoạn](font_properties_for_paragraph.png)

Ví dụ sau áp dụng Times New Roman 13 điểm, định dạng nghiêng và gạch chân chấm cho các phần có định dạng hiệu quả là in đậm:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Đặt thuộc tính phông chữ cho phần văn bản.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Thuộc tính phông cho các phần văn bản](font_properties_for_text_portions.png)

## **Đặt Xoay Văn bản**

Sử dụng [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) để đặt hướng văn bản định sẵn trong một hình dạng.

Mã dưới đây đặt hướng văn bản trong hình dạng thành [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/), xoay văn bản **90 độ ngược chiều kim đồng hồ**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Xoay văn bản](text_rotation.png)

## **Đặt Xoay Tùy Chỉnh cho Khung Văn bản**

Sử dụng [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) để đặt góc xoay tùy chỉnh cho một [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).

Mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình dạng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Xoay văn bản tùy chỉnh](custom_text_rotation.png)

## **Đặt Khoảng Cách Dòng cho Đoạn**

Aspose.Slides cung cấp [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) và [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) để kiểm soát khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Dùng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm chiều cao dòng.
* Dùng giá trị âm để chỉ định khoảng cách dòng theo điểm.

Ví dụ sau đặt khoảng cách trong đoạn đầu tiên là 200 % chiều cao dòng (khoảng cách gấp đôi):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Khoảng cách dòng trong đoạn](line_spacing.png)

## **Kiểm Soát Ngắt Dòng**

Các quy tắc ngắt dòng của đoạn hữu ích trong các khối văn bản hẹp và trong các bài thuyết trình hỗn hợp văn bản Latin và Đông Á. Các phương thức sau thuộc về [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/), vì vậy chúng áp dụng cho toàn đoạn:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) kiểm soát quy tắc ngắt dòng cho văn bản Latin. Khi văn bản hỗn hợp, việc thay đổi nó cũng có thể thay đổi vị trí ngắt dòng của văn bản và dấu câu Đông Á lân cận.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) kiểm soát quy tắc ngắt dòng cho văn bản Đông Á, bao gồm các giới hạn ký tự ở đầu và cuối dòng.

Các quy tắc này không thay thế [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText), chức năng tự động xuống dòng trong khung văn bản. Chúng ảnh hưởng đến cách bố trí khi có xuống dòng; chúng không chèn ký tự ngắt dòng. Một ký tự ngắt dòng rõ ràng buộc tạo ra một dòng mới trong đoạn bất kể độ rộng khả dụng.

Ví dụ tự chứa sau tạo một khối văn bản hẹp chứa tiếng Trung và tiếng Latin. Nó đặt cả hai tùy chọn ngắt dòng một cách rõ ràng và lưu “line_breaking.pptx”. Để thử nghiệm từng quy tắc, thay đổi giá trị tương ứng trong khi giữ các cài đặt còn lại cố định. Ví dụ sử dụng Arial 24 điểm và SimSun với độ rộng khung 160 điểm và lề khung ngang bằng 0. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) được gọi với [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) để kích thước văn bản và kích thước khung không thay đổi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kiểm Soát Dấu Câu Treo**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) cho phép các dấu câu đủ điều kiện kéo dài ra ngoài mép phải của dòng văn bản thay vì chiếm dòng tiếp theo. Nó áp dụng cho toàn đoạn và khác với thụt lề treo.

Ví dụ tự chứa sau bật dấu câu treo trong một khung văn bản rộng 100 điểm và lưu “hanging_punctuation.pptx”. Với Arial 24 điểm và lề khung ngang bằng 0, dấu chấm cuối cùng vẫn nằm sau “sentence” và vượt ra ngoài mép phải. Đặt thuộc tính thành [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) để so sánh: trong trường hợp này, dấu chấm chiếm một dòng riêng. Việc xuống dòng được bật và tự động vừa khít bị tắt để giữ độ rộng khả dụng cố định.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Không phải mọi dấu câu đều có thể treo. Các [điều kiện về phông và bố cục được mô tả ở trên](#control-line-breaking) cũng áp dụng cho so sánh này: thay đổi phông, độ rộng khả dụng, lề hoặc cài đặt tự động vừa khít có thể làm mất sự khác biệt hiển thị.

## **Đặt Kiểu Tự Động Vừa Khít cho Khung Văn bản**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) xác định cách văn bản phản ứng khi vượt quá ranh giới của vùng chứa. Dùng nó để kiểm soát việc văn bản co lại, tràn ra ngoài, hoặc tự động thay đổi kích thước hình dạng. Ví dụ sau cấu hình hình dạng để thay đổi kích thước sao cho vừa với văn bản và lưu kết quả thành “autofit_type.pptx”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Để đếm số dòng sau khi tự động xuống dòng và xem cách thay đổi độ rộng văn bản hoặc hình dạng ảnh hưởng tới kết quả, xem [Đếm Các Dòng Được Render](/slides/vi/python-java/manage-paragraph/). Số dòng chỉ cho biết số lượng dòng, không phản ánh việc văn bản có tràn ra khỏi vùng chứa hay không.

## **Đặt Neo cho Khung Văn bản**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) xác định cách văn bản được định vị theo chiều dọc bên trong một hình dạng, ví dụ: ở trên, giữa hoặc dưới. Ví dụ sau neo văn bản xuống dưới của hình dạng đầu tiên và lưu kết quả thành “text_anchor.pptx”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Tab cho Văn bản**

Sử dụng [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) và [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) để cấu hình các vị trí tab trong một đoạn. Ví dụ sau đặt khoảng cách tab mặc định là 100 điểm và thêm một vị trí tab trái ở 30 điểm. Các cài đặt này ảnh hưởng tới văn bản có chứa ký tự tab.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Các tab của đoạn](paragraph_tabs.png)

## **Đặt Ngôn Ngữ Kiểm Tra Chính Tả**

Aspose.Slides cung cấp [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ kiểm tra quyết định ngôn ngữ được dùng cho kiểm tra chính tả và ngữ pháp trong PowerPoint.

Ví dụ sau yêu cầu “presentation.pptx” có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên và ít nhất một đoạn. Nó thay thế nội dung của đoạn đầu tiên bằng “1。”, đặt phông SimSun và gán ngôn ngữ kiểm tra Simplified Chinese (`zh-CN`). Kết quả được lưu thành “proofing_language.pptx”:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # Đặt Id của ngôn ngữ kiểm tra chính tả.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Ngôn Ngữ Mặc Định**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) để định nghĩa ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo một bản thuyết trình. Ví dụ sau tạo một bản thuyết trình với ngôn ngữ văn bản mặc định là Tiếng Anh Hoa Kỳ, thêm một hộp văn bản và in ra `en-US` cho phần văn bản đầu tiên.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # Thêm một hình chữ nhật có văn bản.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Kiểm tra ngôn ngữ của phần văn bản đầu tiên.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Đặt Kiểu Văn Bản Mặc Định**

Để áp dụng định dạng văn bản mặc định ở cấp độ bản thuyết trình, sử dụng [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Ví dụ sau đặt phông chữ in đậm 14 điểm làm mặc định cho các đoạn cấp cao nhất trong một bản thuyết trình mới và lưu thành “default_text_style.pptx”. Văn bản có thể kế thừa các mặc định này trừ khi có định dạng cụ thể hơn ghi đè chúng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Lấy định dạng đoạn văn cấp cao nhất.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Trích Xuất Văn bản với Hiệu Ứng All‑Caps**

Trong PowerPoint, áp dụng hiệu ứng phông **All Caps** làm cho văn bản hiển thị ở dạng chữ hoa trên slide ngay cả khi nó được gõ dưới dạng chữ thường. Khi bạn lấy phần văn bản như vậy bằng Aspose.Slides, thư viện sẽ trả về văn bản đúng như lúc nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) và chuyển chuỗi trả về sang chữ hoa khi giá trị là `All`.

Ví dụ này yêu cầu “sample2.pptx” có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Phần đầu tiên của đoạn đầu tiên chứa “Hello, Aspose!” với hiệu ứng All Caps áp dụng, như hình dưới.

![Hiệu ứng All Caps](all_caps_effect.png)

Mã dưới đây cho thấy cách trích xuất văn bản với hiệu ứng **All Caps** đã được áp dụng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

Kết quả:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Câu Hỏi Thường Gặp**

**Làm sao để sửa đổi văn bản trong bảng trên slide?**

Để sửa đổi văn bản trong bảng trên slide, sử dụng [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Duyệt qua các ô và cập nhật mỗi ô bằng [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) và định dạng đoạn bằng [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Làm sao để áp dụng màu gradient cho văn bản trên slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Đặt [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) thành [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.