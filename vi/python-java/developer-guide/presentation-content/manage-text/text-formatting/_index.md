---
title: Định dạng Văn bản Bản trình chiếu trong Python qua Java
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/python-java/text-formatting/
keywords:
- căn chỉnh đoạn
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
- thuộc tính tự động vừa
- neo khung văn bản
- phân tab văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Định dạng và tạo kiểu cho văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua Java. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và nhiều hơn nữa."
---
## **Tổng quan**

Bài viết này hướng dẫn cách định dạng văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua Java. Nó bao gồm màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn, hành vi tự động vừa, neo văn bản, tab stops và cài đặt ngôn ngữ.

Trong các ví dụ dưới đây, chúng tôi sẽ sử dụng tệp có tên "sample.pptx", chứa một hộp văn bản duy nhất trên slide đầu tiên với văn bản sau:

![Văn bản mẫu](sample_text.png)

Để tìm và làm nổi bật văn bản nguyên mẫu hoặc các khớp biểu thức chính quy, xem [Tìm và Thay thế Văn bản](/slides/vi/python-java/search-and-replace-text/).

## **Thiết lập màu nền cho văn bản**

Sử dụng [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) để đặt màu tô sáng mặc định cho một đoạn, hoặc sử dụng [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/) cho các phần văn bản riêng lẻ.

Ví dụ mã sau cho thấy cách đặt màu nền cho **toàn bộ đoạn**:

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

![Đoạn màu xám](gray_paragraph.png)

Ví dụ mã dưới đây trình bày cách đặt màu nền cho **các phần văn bản có phông chữ in đậm**:

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

Sử dụng [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setAlignment) để đặt căn chỉnh đoạn trong khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, căn đều, v.v.

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

    # Đặt căn chỉnh của đoạn văn thành trung tâm.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Đoạn được căn giữa](aligned_paragraph.png)

## **Đặt độ trong suốt cho văn bản**

Độ trong suốt của văn bản được kiểm soát thông qua thành phần alpha của màu được gán cho [PortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0–255, không phải là phần trăm độ trong suốt.

Ví dụ mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn**:

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

![Đoạn trong suốt](transparent_paragraph.png)

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

## **Đặt khoảng cách ký tự cho văn bản**

Sử dụng [PortionFormat.setSpacing](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản.

Mã Python sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn**:

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

### **Vô hiệu hoá kerning cho các phông chữ cụ thể**

Trong một số trường hợp, văn bản được render bởi Aspose.Slides có thể trông hơi chặt hơn văn bản tương tự hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chữ chứa thông tin kerning hợp lệ và kerning được bật trong cài đặt PowerPoint.

Để làm cho kết quả render gần với PowerPoint hơn trong các trường hợp này, bạn có thể vô hiệu hoá kerning cho các phần văn bản sử dụng phông chữ bị ảnh hưởng. Đặt [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/) thành một giá trị lớn hơn đáng kể so với kích thước phông chữ thực tế:

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
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Cài đặt này ngăn kerning được áp dụng cho các phần văn bản phù hợp và có thể giúp đồng bộ việc render của Aspose.Slides với đầu ra trực quan của PowerPoint cho các phông chữ bị ảnh hưởng bởi hành vi đặc thù của PowerPoint.

## **Quản lý thuộc tính phông chữ của văn bản**

Thuộc tính phông chữ có thể được thiết lập ở mức đoạn thông qua [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) hoặc trên các phần riêng lẻ thông qua [PortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/).

Mã sau đặt phông chữ và kiểu văn bản cho toàn bộ đoạn: nó áp dụng kích thước phông chữ, in đậm, in nghiêng, gạch chân chấm, và phông Times New Roman cho tất cả các phần trong đoạn.

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

    # Đặt thuộc tính phông chữ cho đoạn.
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

Ví dụ mã dưới đây áp dụng các thuộc tính tương tự cho **các phần văn bản có phông chữ in đậm**:

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

## **Đặt xoay văn bản**

Sử dụng [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setTextVerticalType) để đặt hướng văn bản đã định sẵn trong một hình dạng.

Ví dụ mã sau đặt hướng văn bản trong hình dạng thành `Vertical270`, làm quay văn bản **90 độ ngược chiều kim đồng hồ**:

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

Ví dụ mã dưới đây quay khung văn bản 3 độ theo chiều kim đồng hồ trong hình dạng:

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

Aspose.Slides cung cấp [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setSpaceBefore) và [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setSpaceWithin) để điều khiển khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Sử dụng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm của chiều cao dòng.
* Sử dụng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Ví dụ mã sau cho thấy cách chỉ định khoảng cách dòng trong đoạn:

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

## **Đặt kiểu tự động vừa cho khung văn bản**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setAutofitType) xác định cách văn bản hoạt động khi vượt quá ranh giới của container. Sử dụng nó để kiểm soát việc văn bản co lại, tràn ra ngoài hoặc tự động điều chỉnh kích thước hình dạng.

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

## **Đặt neo cho khung văn bản**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setAnchoringType) xác định cách văn bản được định vị theo chiều dọc bên trong một hình dạng, ví dụ ở trên cùng, giữa hoặc dưới cùng.

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

Sử dụng [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) và [ParagraphFormat.getTabs](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#getTabs) để cấu hình các vị trí tab trong một đoạn.

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

![Các tab trong đoạn](paragraph_tabs.png)

## **Đặt ngôn ngữ kiểm tra chính tả**

Aspose.Slides cung cấp [PortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ kiểm tra quyết định ngôn ngữ được dùng cho kiểm tra chính tả và ngữ pháp trong PowerPoint.

Ví dụ mã sau cho thấy cách đặt ngôn ngữ kiểm tra cho một phần văn bản:

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

## **Đặt ngôn ngữ mặc định**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) để xác định ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo một bản trình chiếu.

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

    # Kiểm tra ngôn ngữ của phần đầu tiên.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Đặt kiểu văn bản mặc định**

Để áp dụng định dạng văn bản mặc định ở mức bản trình chiếu, sử dụng [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Ví dụ mã sau cho thấy cách đặt phông chữ in đậm mặc định với kích thước 14 pt cho tất cả văn bản trên các slide trong một bản trình chiếu mới.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Lấy định dạng đoạn cấp cao nhất.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Trích xuất văn bản với hiệu ứng Chữ HOA**

Trong PowerPoint, áp dụng hiệu ứng **All Caps** làm cho văn bản hiển thị ở dạng chữ hoa trên slide ngay cả khi nó được gõ bằng chữ thường. Khi bạn lấy phần văn bản như vậy bằng Aspose.Slides, thư viện sẽ trả về văn bản đúng như khi nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textcaptype/) và chuyển chuỗi trả về thành chữ hoa khi giá trị là `All`.

Giả sử chúng ta có hộp văn bản sau trên slide đầu tiên của tệp sample2.pptx.

![Hiệu ứng Chữ HOA](all_caps_effect.png)

Ví dụ mã dưới đây cho thấy cách trích xuất văn bản với hiệu ứng **All Caps** đã được áp dụng:

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

**Làm thế nào để sửa đổi văn bản trong bảng trên một slide?**

Để sửa đổi văn bản trong bảng trên một slide, sử dụng [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/). Duyệt qua các ô và cập nhật mỗi ô thông qua [Cell.getTextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cell/#getTextFrame) và định dạng đoạn qua [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Làm thế nào để áp dụng màu gradient cho văn bản trên một slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [PortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/). Đặt [FillFormat.setFillType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/#setFillType) thành [FillType.Gradient](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/#Gradient) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.