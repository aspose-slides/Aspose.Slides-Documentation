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
- tab văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Định dạng và tạo kiểu cho văn bản trong các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua Java. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và nhiều hơn nữa."
---
## **Tổng quan**

Bài viết này hướng dẫn cách định dạng văn bản trong các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua Java. Nó bao gồm các màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn, hành vi tự động vừa khít, neo văn bản, tab stops và cài đặt ngôn ngữ.

Trừ khi có ghi chú ngược lại, các ví dụ sử dụng [sample.pptx](sample.pptx). Hình dạng đầu tiên trên slide đầu tiên là một hộp văn bản, và đoạn văn đầu tiên của nó chứa văn bản được hiển thị bên dưới. Cả chỉ số slide và hình dạng đều bắt đầu từ 0. Các ví dụ chọn phần in đậm sử dụng định dạng hiệu quả, bao gồm định dạng in đậm kế thừa:

![Văn bản mẫu](sample_text.png)

Để tìm và làm nổi bật văn bản nguyên bản hoặc các khớp biểu thức chính quy, xem [Tìm và Thay thế Văn bản](/slides/vi/python-java/search-and-replace-text/).

## **Đặt Màu Nền cho Văn bản**

Sử dụng [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) để đặt màu nền mặc định cho một đoạn văn, hoặc sử dụng [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) cho các phần văn bản riêng lẻ.

Ví dụ sau đặt màu nền xám nhạt làm mặc định cho đoạn văn đầu tiên. Màu nền cụ thể trên các phần riêng lẻ sẽ có ưu tiên hơn mặc định này:

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

    # Đặt màu làm nổi bật cho toàn bộ đoạn văn.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Đoạn văn màu xám](gray_paragraph.png)

Ví dụ mã dưới đây minh họa cách đặt màu nền cho **các phần văn bản có phông chữ in đậm**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpride.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Đặt màu làm nổi bật cho phần văn bản.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Các phần văn bản màu xám](gray_text_portions.png)

## **Căn Đoạn Văn Bản**

Sử dụng [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) để đặt căn chỉnh đoạn văn trong một khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, căn đều, v.v.

Ví dụ mã sau cho thấy cách căn đoạn văn về **giữa**:

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

## **Căn Chỉnh Phông Chữ Trong Một Dòng**

Sử dụng [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) để căn chỉnh dọc các phần văn bản có kích thước phông khác nhau trong một dòng. Cài đặt này áp dụng cho toàn bộ đoạn và kiểm soát căn chỉnh trong mỗi dòng của nó.

Ví dụ tự chứa dưới đây tạo bốn hộp văn bản có nhãn trên một slide. Mỗi đoạn chứa cùng một văn bản ở kích thước 18, 36 và 54 điểm, với căn chỉnh phông khác nhau. Nó sử dụng Arial, tắt tự động vừa khít và gói dòng, và giữ khung văn bản đủ lớn cho một dòng.

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

![So sánh căn baseline, top, center và bottom với các kích thước phông hỗn hợp](font_alignment.png)

Căn chỉnh phông sử dụng các chỉ số phông, vì vậy các cạnh hiển thị của các chữ cái riêng lẻ không nhất thiết phải thẳng hàng hoàn toàn. Ví dụ bao gồm một chữ in hoa và một ký tự có phần dưới để minh họa sự khác nhau giữa căn baseline và bottom. Tính khả dụng và thay thế phông chữ, các ký tự được dùng và sự khác biệt kích thước phông đều ảnh hưởng đến kết quả. Kích thước khung, lề, khoảng cách dòng, gói và tự động vừa khít cũng ảnh hưởng đến bố trí; hãy sử dụng cùng phông và cùng cài đặt bố trí khi so sánh các chế độ.

Cài đặt này khác với [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment), kiểm soát căn chỉnh ngang của đoạn, và [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType), định vị khối văn bản theo chiều dọc trong hình. Định dạng superscript và subscript qua [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) dịch chuyển các phần riêng lẻ so với baseline thay vì đặt căn chỉnh phông cho các dòng của đoạn.

## **Đặt Độ Trong Suốt cho Văn Bản**

Độ trong suốt của văn bản được kiểm soát thông qua thành phần alpha của màu được gán cho [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0–255, không phải phần trăm trong suốt.

Ví dụ mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn văn**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpipe.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Đặt màu tô của văn bản thành màu trong suốt.
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

## **Đặt Khoảng Cách Ký Tự cho Văn Bản**

Sử dụng [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản. Các ví dụ thêm 3 điểm khoảng cách; giá trị âm sẽ thu hẹp văn bản.

Mã Python sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn văn**:

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

![Khoảng cách ký tự trong đoạn văn](character_spacing_in_paragraph.png)

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

### **Vô Hiệu Hoá Kerning cho Các Phông Chữ Cụ Thể**

Trong một số trường hợp, văn bản được render bởi Aspose.Slides có thể trông hơi chặt hơn so với cùng văn bản hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông, ngay cả khi phông chứa thông tin kerning hợp lệ và kerning đã được bật trong cài đặt PowerPoint.

Để làm cho kết quả render gần với PowerPoint hơn trong những trường hợp này, bạn có thể tắt kerning cho các phần văn bản sử dụng phông bị ảnh hưởng. Đặt [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) thành giá trị lớn hơn kích thước phông thực tế. Ví dụ này yêu cầu “presentation.pptx” có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Nó kiểm tra tên phông hiệu quả, bao gồm phông kế thừa, và đặt ngưỡng 100 điểm cho các phần sử dụng Roboto. Điều này tắt kerning cho các phần phù hợp có kích thước phông dưới 100 điểm:

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

Đối với văn bản phù hợp dưới ngưỡng, cài đặt này ngăn kerning và có thể giúp khớp kết quả render của Aspose.Slides với đầu ra hình ảnh của PowerPoint cho các phông bị hành vi đặc thù này ảnh hưởng.

## **Quản Lý Thuộc Tính Phông Chữ Văn Bản**

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

![Thuộc tính phông chữ cho đoạn văn](font_properties_for_paragraph.png)

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

![Thuộc tính phông chữ cho các phần văn bản](font_properties_for_text_portions.png)

## **Kiểm Soát Chuẩn Hoá Chiều Cao Văn Bản**

Sử dụng [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) khi tái tạo kiểu chữ mẫu hoặc điều tra sự khác biệt chiều cao ký tự. Trong PowerPoint, bật chuẩn hoá sẽ kéo hoặc nén các ký tự riêng lẻ theo chiều dọc để chúng có chiều cao hiển thị đồng nhất trong phần văn bản. Nó không đảm bảo chiều cao văn bản bằng nhau giữa các phông khác nhau.

Đặt thuộc tính thành [NullableBool.True_ or False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) để bật hoặc tắt chuẩn hoá một cách rõ ràng. `NullableBool.NotDefined` để lại cài đặt cục bộ không được đặt, do đó phần sẽ kế thừa giá trị, ví dụ, từ [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) của đoạn. Nó không đồng nghĩa với `False`. Sử dụng [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) và đọc `getNormaliseHeight` trên định dạng hiệu quả trả về để có giá trị Boolean đã giải quyết.

Ví dụ tự chứa dưới đây yêu cầu **Arial** được cài đặt. Nó tạo hai khối văn bản chứa cùng các chữ in hoa, chữ thường, ký tự có phần dưới và ký tự có dấu ở kích thước 54 điểm. Cả hai đoạn đều bật chuẩn hoá theo mặc định. Phần trên tắt chuẩn hoá một cách rõ ràng; phần dưới kế thừa nó. Kích thước khung, lề và khoảng cách đoạn giống hệt nhau, với gói và tự động vừa khít tắt để giữ so sánh nhất quán. Ví dụ in ra `False: False` và `NotDefined: True`, sau đó lưu “text_height_normalization.pptx”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

So sánh dưới đây được xuất từ bản trình bày đã lưu. Hàng trên có chuẩn hoá bị tắt (`False`); hàng dưới kế thừa cài đặt bật (`NotDefined` → `True`). Giữ Arial được cài đặt để tái tạo giao diện này.

![Văn bản Arial 54 điểm với chuẩn hoá bị tắt ở trên và chuẩn hoá được thừa kế bật ở dưới](text_height_normalization.png)

Chuẩn hoá thay đổi chiều cao ký tự mà không thay đổi giá trị [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight) được gán, giá trị này chỉ xác định kích thước phông chữ tính bằng điểm. [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) kiểm soát khoảng cách dòng, trong khi [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) kiểm soát cách văn bản hoặc khung của nó điều chỉnh để vừa. Các cài đặt này phục vụ mục đích khác nhau và có thể ảnh hưởng đến bố cục tổng thể một cách độc lập. Để biết thêm về định dạng đoạn và kế thừa, xem [Quản Lý Đoạn](/slides/vi/python-java/manage-paragraph/).

## **Áp Dụng và Xóa Gạch Ngang**

Sử dụng [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) trên một phần văn bản để hiển thị các sửa đổi, từ bị hủy hoặc giá cũ mà không xóa văn bản gốc. Đặt thành [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) để có một hoặc hai đường qua văn bản.

Để xóa gạch ngang, truyền [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None). Điều này vô hiệu hoá hiệu ứng ngay cả khi định dạng bao quanh chỉ định gạch ngang. Ngược lại, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) để lại cài đặt cục bộ không xác định, cho phép phần kế thừa định dạng, ví dụ, từ đoạn. Nó không đảm bảo gạch ngang được xóa. Sử dụng [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) để đọc định dạng kết quả, bao gồm các giá trị kế thừa.

Ví dụ tự chứa dưới đây tạo ba so sánh giá. Mỗi đoạn có các phần riêng cho nhãn, giá cũ và giá hiện tại, vì vậy chỉ giá cũ bị ảnh hưởng. Hàng trên áp dụng và sau đó xóa gạch ngang; các hàng còn lại giữ gạch ngang đơn và gạch ngang đôi. Thay đổi cài đặt này giữ nguyên văn bản và các định dạng khác, bao gồm giá cũ in đậm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # Áp dụng gạch ngang, sau đó loại bỏ một cách rõ ràng khỏi giá trước đầu tiên.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả, từ trên xuống dưới: không gạch ngang, gạch ngang đơn và gạch ngang đôi.

![Giá trước không gạch ngang, gạch ngang đơn, và gạch ngang đôi](strikethrough.png)

## **Đặt Xoay Văn Bản**

Sử dụng [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) để đặt hướng văn bản định sẵn trong một hình dạng.

Ví dụ mã sau đặt hướng văn bản trong hình dạng thành [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/), xoay văn bản **90 độ ngược chiều kim đồng hồ**:

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

## **Đặt Xoay Tùy Chỉnh cho Khung Văn Bản**

Sử dụng [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) để đặt góc xoay tùy chỉnh cho một [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).

Ví dụ mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình dạng:

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

## **Đặt Khoảng Cách Dòng cho Đoạn Văn**

Aspose.Slides cung cấp [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) và [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) để kiểm soát khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Dùng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm của chiều cao dòng.
* Dùng giá trị âm để chỉ định khoảng cách dòng tính bằng điểm.

Ví dụ sau đặt khoảng cách trong đoạn đầu tiên là 200% chiều cao dòng (khoảng cách gấp đôi):

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

![Khoảng cách dòng trong đoạn văn](line_spacing.png)

## **Kiểm Soát Ngắt Dòng**

Quy tắc ngắt dòng của đoạn hữu ích trong các khối văn bản hẹp và các bài thuyết trình hỗn hợp giữa văn bản Latin và Đông Á. Các phương thức sau thuộc về [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/), vì vậy chúng áp dụng cho toàn bộ đoạn:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) kiểm soát quy tắc ngắt dòng Latin. Trong văn bản hỗn hợp, thay đổi nó cũng có thể thay đổi nơi văn bản và dấu câu Đông Á gần đó ngắt.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) kiểm soát quy tắc ngắt dòng Đông Á, bao gồm các hạn chế về ký tự ở đầu và cuối dòng.

Các quy tắc này không thay thế [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText), cho phép tự động gói trong khung văn bản. Chúng ảnh hưởng đến bố cục khi gói xảy ra; chúng không chèn ký tự ngắt dòng. Một ngắt dòng tường minh buộc tạo dòng mới trong đoạn độc lập với độ rộng khả dụng.

Ví dụ tự chứa dưới đây tạo một khối văn bản hẹp chứa tiếng Trung và Latin. Nó đặt cả hai tùy chọn ngắt dòng một cách rõ ràng và lưu “line_breaking.pptx”. Để thử nghiệm bất kỳ quy tắc nào, thay đổi giá trị tương ứng trong khi giữ các cài đặt còn lại cố định. Ví dụ sử dụng Arial 24 điểm và SimSun với độ rộng khung 160 điểm và lề ngang khung bằng 0. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) được gọi với [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) để kích thước văn bản và kích thước khung giữ nguyên.

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

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) cho phép các dấu câu đủ điều kiện mở rộng ra ngoài cạnh phải của dòng văn bản thay vì chiếm dòng tiếp theo. Nó áp dụng cho toàn bộ đoạn và khác với thụt lề treo.

Ví dụ tự chứa dưới đây bật dấu câu treo trong một khung văn bản rộng 100 điểm và lưu “hanging_punctuation.pptx”. Với Arial 24 điểm và lề ngang khung bằng 0, dấu chấm cuối cùng ở sau “sentence” và mở rộng ra ngoài cạnh phải của văn bản. Đặt thuộc tính thành [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) để so sánh: với các cài đặt này, dấu chấm sẽ nằm trên một dòng riêng. Gói được bật và tự động vừa khít tắt để giữ độ rộng khả dụng cố định.

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

Không phải mọi dấu câu đều có thể treo. Các [điều kiện phông và bố cục được mô tả ở trên](#control-line-breaking) cũng áp dụng cho so sánh này: thay đổi phông, độ rộng khả dụng, lề hoặc cài đặt tự động vừa khít có thể làm mất sự khác biệt nhìn thấy được.

## **Đặt Kiểu Tự Động Vừa Khít cho Khung Văn Bản**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) quyết định cách văn bản phản ứng khi vượt quá giới hạn của vùng chứa. Sử dụng để kiểm soát văn bản co lại, tràn ra ngoài hoặc tự động thay đổi kích thước hình dạng. Ví dụ sau cấu hình hình dạng để thay đổi kích thước cho vừa với văn bản và lưu kết quả thành “autofit_type.pptx”.

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

Để đếm số dòng sau khi tự động gói và xem cách độ rộng văn bản hoặc hình dạng thay đổi kết quả, xem [Đếm dòng đã render](/slides/vi/python-java/manage-paragraph/). Số lượng dòng một mình không cho biết liệu văn bản có tràn ra ngoài vùng chứa hay không.

## **Đặt Neo cho Khung Văn Bản**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) xác định cách văn bản được định vị dọc bên trong một hình dạng, ví dụ: ở trên, giữa hoặc dưới. Ví dụ sau neo văn bản xuống dưới của hình dạng đầu tiên và lưu kết quả thành “text_anchor.pptx”.

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

## **Đặt Tab cho Văn Bản**

Sử dụng [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) và [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) để cấu hình các vị trí tab trong một đoạn. Ví dụ sau đặt khoảng cách tab mặc định là 100 điểm và thêm một vị trí tab căn trái ở 30 điểm. Các cài đặt này ảnh hưởng đến văn bản chứa ký tự tab.

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

![Tab của đoạn văn](paragraph_tabs.png)

## **Đặt Ngôn Ngữ Kiểm Tra Chính Tả**

Aspose.Slides cung cấp [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ này quyết định ngôn ngữ được dùng cho kiểm tra chính tả và ngữ pháp trong PowerPoint.

Ví dụ sau yêu cầu “presentation.pptx” có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên và ít nhất một đoạn. Nó thay thế nội dung của đoạn đầu tiên bằng “1。”, đặt SimSun làm phông và gán ngôn ngữ kiểm tra tiếng Trung giản thể (`zh-CN`). Sau đó lưu kết quả thành “proofing_language.pptx”:

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

    # Đặt Id của ngôn ngữ kiểm tra.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Sao Chép Siêu Dữ Liệu Ngôn Ngữ**

Khi sao chép văn bản đa ngôn ngữ từ mẫu, giữ cả [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId) và [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). Ví dụ tự chứa dưới đây tạo một phần nguồn có tiếng Anh Hoa Kỳ làm ngôn ngữ và tiếng Pháp làm ngôn ngữ thay thế, sau đó sao chép văn bản và các định danh sang một phần trong bản trình bày mới.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # Nếu nguồn không có ngôn ngữ thay thế, None sẽ xóa giá trị đích.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Để thử nguồn không có ngôn ngữ thay thế, bỏ qua việc gán `"fr-FR"`. Khi đó định danh thay thế sẽ là `None`, và câu lệnh sao chép vẫn giữ nguyên sự vắng mặt mà không tạo giá trị mặc định, ngay cả khi đích trước đó đã có ngôn ngữ thay thế được gán.

Các định danh này lưu trữ siêu dữ liệu ngôn ngữ. Giữ chúng không quyết định từ điển nào PowerPoint sẽ chọn cho kiểm tra chính tả hoặc ngữ pháp.

## **Đặt Ngôn Ngữ Mặc Định**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) để xác định ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo bản trình bày. Ví dụ sau tạo một bản trình bày với tiếng Anh Hoa Kỳ làm ngôn ngữ văn bản mặc định, thêm một hộp văn bản và in `en-US` cho phần văn bản đầu tiên.

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

    # Thêm một hình dạng hình chữ nhật với văn bản.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Kiểm tra ngôn ngữ của phần văn bản đầu tiên.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Đặt Kiểu Văn Bản Mặc Định**

Để áp dụng định dạng văn bản mặc định ở mức bản trình bày, sử dụng [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Ví dụ sau đặt phông bold 14 điểm làm mặc định cho các đoạn cấp cao nhất trong một bản trình bày mới và lưu thành “default_text_style.pptx”. Văn bản có thể kế thừa các mặc định này trừ khi định dạng cụ thể hơn ghi đè chúng.

```python
import jpage
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

## **Trích Xuất Văn Bản với Hiệu Ứng All-Caps**

Trong PowerPoint, áp dụng hiệu ứng **All Caps** làm cho văn bản hiển thị ở dạng chữ hoa trên slide ngay cả khi nó được gõ bằng chữ thường. Khi bạn truy xuất phần văn bản như vậy bằng Aspose.Slides, thư viện sẽ trả về văn bản đúng như khi nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) và chuyển chuỗi trả về thành chữ hoa khi giá trị là `All`.

Ví dụ này yêu cầu “sample2.pptx” có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Phần đầu tiên của đoạn đầu tiên chứa “Hello, Aspose!” với hiệu ứng All Caps được áp dụng, như hình dưới.

![Hiệu ứng All Caps](all_caps_effect.png)

Ví dụ mã dưới đây cho thấy cách trích xuất văn bản với hiệu ứng **All Caps** được áp dụng:

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

## **Câu hỏi thường gặp**

**Làm thế nào để chỉnh sửa văn bản trong một bảng trên slide?**

Để chỉnh sửa văn bản trong một bảng trên slide, sử dụng [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Duyệt qua các ô và cập nhật mỗi ô thông qua [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) và định dạng đoạn qua [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Làm thế nào để áp dụng màu gradient cho văn bản trên một slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Đặt [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) thành [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.