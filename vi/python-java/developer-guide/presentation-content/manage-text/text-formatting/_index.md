---
title: Định dạng Văn bản Trình chiếu trong Python qua Java
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/python-java/text-formatting/
keywords:
- căn chỉnh đoạn văn
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
- thuộc tính tự động điều chỉnh
- neo khung văn bản
- tab văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Định dạng và thiết kế văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua Java. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và hơn nữa."
---
## **Tổng quan**

Bài viết này trình bày cách định dạng văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua Java. Nó bao gồm màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn văn, hành vi tự động điều chỉnh kích thước, neo văn bản, vị trí tab và cài đặt ngôn ngữ.

Trừ khi có ghi chú khác, các ví dụ sử dụng [sample.pptx](sample.pptx). Hình dạng đầu tiên trên slide đầu tiên là một hộp văn bản, và đoạn văn đầu tiên của nó chứa văn bản được hiển thị bên dưới. Cả chỉ số slide và hình dạng đều bắt đầu từ 0. Các ví dụ chọn phần in đậm sử dụng định dạng hiệu quả, bao gồm định dạng in đậm được kế thừa:

![Văn bản mẫu](sample_text.png)

Để tìm và tô sáng văn bản nguyên gốc hoặc các khớp biểu thức chính quy, xem [Tìm kiếm và Thay thế Văn bản](/slides/vi/python-java/search-and-replace-text/).

## **Đặt màu nền cho văn bản**

Sử dụng [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) để đặt màu tô sáng mặc định cho một đoạn, hoặc sử dụng [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#getHighlightColor) cho các phần văn bản riêng lẻ.

Ví dụ sau đặt màu tô sáng màu xám nhạt làm mặc định cho đoạn đầu tiên. Màu tô sáng cụ thể trên các phần riêng lẻ sẽ có ưu tiên cao hơn mặc định này:

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

![Đoạn văn màu xám](gray_paragraph.png)

Đoạn mã dưới đây minh họa cách đặt màu nền cho **các phần văn bản có phông in đậm**:

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

![Các phần văn bản màu xám](gray_text_portions.png)

## **Căn chỉnh các đoạn văn bản**

Sử dụng [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setAlignment) để đặt căn chỉnh đoạn trong một khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, căn đều, v.v.

Ví dụ mã sau cho thấy cách căn đoạn về **giữa**:

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

    # Đặt căn chỉnh của đoạn văn sang trung tâm.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Đoạn văn đã căn](aligned_paragraph.png)

## **Đặt độ trong suốt cho văn bản**

Độ trong suốt của văn bản được kiểm soát thông qua thành phần alpha của màu được gán cho [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#getFillFormat). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0–255, không phải phần trăm độ trong suốt.

Đoạn mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn**:

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

    # Đặt màu tô đầy cho văn bản thành màu trong suốt.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Đoạn văn trong suốt](transparent_paragraph.png)

Ví dụ mã sau cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông in đậm**:

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

## **Đặt khoảng cách ký tự cho văn bản**

Sử dụng [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setSpacing) để mở rộng hoặc giảm khoảng cách giữa các ký tự trong một hộp văn bản. Các ví dụ thêm 3 điểm khoảng cách; giá trị âm sẽ làm văn bản chặt lại.

Mã Python dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn**:

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

Đoạn mã dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông in đậm**:

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
            # Lưu ý: Sử dụng các giá trị âm để nén khoảng cách ký tự.
            portion.getPortionFormat().setSpacing(3) # Mở rộng khoảng cách ký tự.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Khoảng cách ký tự trong các phần văn bản](character_spacing_in_text_portions.png)

### **Vô hiệu hóa Kerning cho các phông chữ cụ thể**

Trong một số trường hợp, văn bản được render bằng Aspose.Slides có thể trông hơi chặt hơn so với cùng văn bản hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chữ chứa thông tin kerning hợp lệ và kerning đã được bật trong cài đặt PowerPoint.

Để kết quả render gần với PowerPoint hơn trong những trường hợp này, bạn có thể vô hiệu hóa kerning cho các phần văn bản sử dụng phông chữ bị ảnh hưởng. Đặt [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) thành giá trị lớn hơn kích thước phông chữ thực tế. Ví dụ này yêu cầu "presentation.pptx" có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Nó kiểm tra tên phông chữ hiệu quả, bao gồm cả phông chữ kế thừa, và đặt ngưỡng 100 điểm cho các phần sử dụng Roboto. Điều này vô hiệu hoá kerning cho các phần phù hợp có kích thước phông chữ dưới 100 điểm:

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

Đối với văn bản phù hợp dưới ngưỡng, cài đặt này ngăn kerning và có thể giúp kết quả render của Aspose.Slides khớp với đầu ra hình ảnh của PowerPoint cho các phông chữ bị ảnh hưởng bởi hành vi đặc thù của PowerPoint này.

## **Quản lý thuộc tính phông chữ của văn bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) hoặc trên các phần riêng lẻ thông qua [PortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/).

Ví dụ sau đặt phông chữ mặc định cho đoạn đầu tiên là Times New Roman 12 điểm với định dạng in đậm, in nghiêng và gạch chân chấm. Định dạng cụ thể trên các phần riêng lẻ sẽ có ưu tiên cao hơn các mặc định này.

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

    # Đặt các thuộc tính phông chữ cho đoạn văn.
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

![Thuộc tính phông chữ cho đoạn](font_properties_for_paragraph.png)

Ví dụ sau áp dụng Times New Roman 13 điểm, định dạng in nghiêng và gạch chân chấm cho các phần có định dạng hiệu quả là in đậm:

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
            # Đặt các thuộc tính phông chữ cho phần văn bản.
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

## **Đặt xoay cho văn bản**

Sử dụng [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setTextVerticalType) để đặt hướng văn bản đã định sẵn trong một hình dạng.

Ví dụ mã sau đặt hướng văn bản trong hình dạng thành [TextVerticalType.Vertical270](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textverticaltype/), làm xoay văn bản **90 độ ngược chiều kim đồng hồ**:

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

## **Đặt xoay tùy chỉnh cho khung văn bản**

Sử dụng [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setRotationAngle) để đặt góc xoay tùy chỉnh cho một [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/).

Đoạn mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình dạng:

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

## **Đặt khoảng cách dòng cho các đoạn**

Aspose.Slides cung cấp [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setSpaceBefore) và [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setSpaceWithin) để kiểm soát khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Sử dụng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm của chiều cao dòng.
* Sử dụng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Ví dụ sau đặt khoảng cách trong đoạn đầu tiên là 200% chiều cao dòng (gấp đôi):

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

## **Kiểm soát ngắt dòng**

Các quy tắc ngắt dòng của đoạn rất hữu ích trong các khối văn bản hẹp và các bản trình chiếu hỗn hợp văn bản Latin và Đông Á. Các phương thức sau thuộc về [ParagraphFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/), do đó áp dụng cho toàn bộ đoạn:

- [setLatinLineBreak](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) kiểm soát quy tắc ngắt dòng cho văn bản Latin. Trong văn bản hỗn hợp, việc thay đổi nó cũng có thể thay đổi vị trí gói văn bản và dấu câu Đông Á bên cạnh.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) kiểm soát quy tắc ngắt dòng cho văn bản Đông Á, bao gồm các hạn chế về ký tự ở đầu và cuối dòng.

Các quy tắc này không thay thế [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setWrapText), chức năng này bật việc tự động ngắt dòng trong khung văn bản. Chúng ảnh hưởng tới bố cục khi ngắt dòng xảy ra; chúng không chèn ký tự ngắt dòng. Một ký tự ngắt dòng rõ ràng sẽ buộc tạo dòng mới trong đoạn, bất kể độ rộng có sẵn.

Ví dụ tự chứa dưới đây tạo một khối văn bản hẹp chứa cả tiếng Trung và Latin. Nó đặt cả hai tùy chọn ngắt dòng một cách rõ ràng và lưu thành "line_breaking.pptx". Để thử nghiệm với mỗi quy tắc, thay đổi giá trị tương ứng trong khi giữ các cài đặt khác không đổi. Ví dụ sử dụng Arial 24 điểm và SimSun với chiều rộng khung 160 điểm và lề ngang của khung văn bản bằng 0. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setAutofitType) được gọi với [TextAutofitType.None_](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textautofittype/) để kích thước văn bản và kích thước khung giữ nguyên.

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

## **Kiểm soát dấu câu treo**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) cho phép các dấu câu đủ điều kiện kéo dài ra ngoài cạnh phải của dòng văn bản thay vì chiếm dòng tiếp theo. Nó áp dụng cho toàn bộ đoạn và khác với thụt lề treo.

Ví dụ tự chứa dưới đây bật dấu câu treo trong một khung văn bản rộng 100 điểm và lưu "hanging_punctuation.pptx". Với Arial 24 điểm và lề ngang khung văn bản bằng 0, dấu chấm cuối cùng vẫn ở sau "sentence" và kéo dài ra ngoài cạnh phải của văn bản. Đặt thuộc tính thành [NullableBool.False_](https://reference.aspose.com/slides/vi/python-java/aspose.slides/nullablebool/) để so sánh: với các cài đặt này, dấu chấm chiếm một dòng riêng. Việc gói văn bản được bật và autofit bị tắt để giữ độ rộng khả dụng cố định.

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

Không phải mọi dấu câu đều có thể treo. Kết quả hiển thị phụ thuộc vào khả năng có sẵn của phông chữ và bố cục: thay đổi phông chữ, độ rộng khả dụng, lề hoặc cài đặt autofit có thể loại bỏ sự khác biệt hiển thị.

## **Đặt kiểu Autofit cho khung văn bản**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setAutofitType) xác định cách văn bản hành động khi vượt quá ranh giới của container. Sử dụng nó để kiểm soát việc văn bản co nhỏ, tràn ra ngoài, hoặc tự động thay đổi kích thước hình dạng. Ví dụ sau cấu hình hình dạng để thay đổi kích thước phù hợp với văn bản và lưu kết quả thành "autofit_type.pptx".

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

Để đếm số dòng sau khi tự động ngắt và xem cách độ rộng văn bản hoặc hình dạng thay đổi kết quả, xem [Đếm dòng đã render](/slides/vi/python-java/manage-paragraph/). Số dòng chỉ không cho biết liệu văn bản có tràn ra ngoài container hay không.

## **Đặt neo cho khung văn bản**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setAnchoringType) xác định vị trí văn bản theo chiều dọc bên trong một hình dạng, ví dụ: trên cùng, giữa hoặc dưới cùng. Ví dụ sau neo văn bản vào phía dưới của hình dạng đầu tiên và lưu kết quả thành "text_anchor.pptx".

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

## **Đặt tab cho văn bản**

Sử dụng [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) và [ParagraphFormat.getTabs](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#getTabs) để cấu hình các vị trí tab trong một đoạn. Ví dụ sau đặt khoảng cách tab mặc định là 100 điểm và thêm một vị trí tab căn trái ở 30 điểm. Các cài đặt này ảnh hưởng tới văn bản có ký tự tab.

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

## **Đặt ngôn ngữ kiểm tra chính tả**

Aspose.Slides cung cấp [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setLanguageId), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ kiểm tra quyết định ngôn ngữ được sử dụng cho việc kiểm tra chính tả và ngữ pháp trong PowerPoint.

Ví dụ sau yêu cầu "presentation.pptx" có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên và ít nhất một đoạn. Nó thay thế nội dung của đoạn đầu tiên bằng "1。", đặt SimSun làm phông chữ và gán ngôn ngữ kiểm tra chính tả là tiếng Trung giản thể (`zh-CN`). Nó lưu kết quả thành "proofing_language.pptx":

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

## **Đặt ngôn ngữ mặc định**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) để định nghĩa ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo bản trình chiếu. Ví dụ sau tạo một bản trình chiếu với tiếng Anh Mỹ làm ngôn ngữ văn bản mặc định, thêm một hộp văn bản và in `en-US` cho phần văn bản đầu tiên của nó.

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

    # Thêm một hình chữ nhật có chứa văn bản.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Kiểm tra ngôn ngữ của phần văn bản đầu tiên.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Đặt kiểu văn bản mặc định**

Để áp dụng định dạng văn bản mặc định ở mức bản trình chiếu, sử dụng [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Ví dụ sau đặt phông chữ in đậm 14 điểm làm mặc định cho các đoạn cấp cao nhất trong một bản trình chiếu mới và lưu nó thành "default_text_style.pptx". Văn bản có thể kế thừa các mặc định này trừ khi có định dạng cụ thể hơn ghi đè lên chúng.

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

## **Trích xuất văn bản với hiệu ứng All-Caps**

Trong PowerPoint, áp dụng hiệu ứng phông **All Caps** làm cho văn bản hiển thị dưới dạng chữ hoa trên slide ngay cả khi nó được gõ bằng chữ thường. Khi bạn lấy một phần văn bản như vậy bằng Aspose.Slides, thư viện sẽ trả về văn bản nguyên bản. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textcaptype/) và chuyển chuỗi trả về sang chữ hoa khi giá trị là `All`.

Ví dụ này yêu cầu "sample2.pptx" có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Phần đầu tiên của đoạn đầu tiên chứa "Hello, Aspose!" với hiệu ứng All Caps được áp dụng, như hình dưới.

![Hiệu ứng All Caps](all_caps_effect.png)

Đoạn mã dưới đây cho thấy cách trích xuất văn bản với hiệu ứng **All Caps** đã được áp dụng:

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

Đầu ra:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Câu hỏi thường gặp**

**Làm thế nào để chỉnh sửa văn bản trong bảng trên một slide?**

Để chỉnh sửa văn bản trong bảng trên một slide, sử dụng [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/). Duyệt qua các ô và cập nhật mỗi ô thông qua [Cell.getTextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cell/#getTextFrame) và định dạng đoạn qua [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Làm thế nào để áp dụng màu gradient cho văn bản trên slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#getFillFormat). Đặt [FillFormat.setFillType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/#setFillType) thành [FillType.Gradient](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.