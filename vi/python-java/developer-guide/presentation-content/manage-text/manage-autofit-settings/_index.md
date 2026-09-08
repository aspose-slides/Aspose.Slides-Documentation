---
title: Nâng cao các bài thuyết trình của bạn với AutoFit trong Python
linktitle: Cài đặt Autofit
type: docs
weight: 30
url: /vi/python-java/manage-autofit-settings/
keywords:
- hộp văn bản
- autofit
- không tự động vừa
- vừa văn bản
- thu nhỏ văn bản
- bọc văn bản
- thay đổi kích thước hình
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý cài đặt AutoFit trong Aspose.Slides cho Python thông qua Java để tối ưu hiển thị văn bản trong các bài thuyết trình PowerPoint và OpenDocument và cải thiện khả năng đọc của nội dung."
---
## **Giới thiệu**

Mặc định, khi bạn thêm một hộp văn bản, Microsoft PowerPoint sử dụng cài đặt **Resize shape to fix text** cho hộp văn bản—nó tự động thay đổi kích thước hộp văn bản để đảm bảo văn bản luôn vừa vào bên trong. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Khi văn bản trong hộp văn bản dài hơn hoặc lớn hơn, PowerPoint tự động mở rộng hộp văn bản—tăng chiều cao—để cho phép chứa nhiều văn bản hơn. 
* Khi văn bản trong hộp văn bản ngắn hơn hoặc nhỏ hơn, PowerPoint tự động giảm kích thước hộp văn bản—giảm chiều cao—để loại bỏ không gian thừa. 

Trong PowerPoint, có 4 tham số hoặc tùy chọn quan trọng kiểm soát hành vi autofit cho hộp văn bản: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java cung cấp các tùy chọn tương tự—một số thuộc tính trong lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/)—cho phép bạn kiểm soát hành vi autofit cho các hộp văn bản trong bản trình chiếu. 

## **Thay đổi kích thước hình để vừa với văn bản**

Nếu bạn muốn văn bản trong một hộp luôn vừa vào hộp sau khi thay đổi, bạn phải sử dụng tùy chọn **Resize shape to fix text**. Để chỉ định cài đặt này, sử dụng phương thức [setAutofitType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setAutofitType) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/)) với [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textautofittype/#Shape).

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Mã Python này cho bạn thấy cách chỉ định rằng văn bản phải luôn vừa vào hộp của nó trong một bản trình chiếu PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nếu văn bản dài hơn hoặc lớn hơn, hộp văn bản sẽ tự động được thay đổi kích thước (tăng chiều cao) để đảm bảo mọi văn bản vừa vào. Nếu văn bản ngắn hơn, quá trình ngược lại sẽ xảy ra. 

## **Không tự động điều chỉnh kích thước**

Nếu bạn muốn một hộp văn bản hoặc hình giữ nguyên kích thước bất kể các thay đổi trên văn bản chứa bên trong, bạn phải sử dụng tùy chọn **Do not Autofit**. Để chỉ định cài đặt này, dùng phương thức [setAutofitType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setAutofitType) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/)) với [None](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textautofittype/#None). 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Mã Python này cho bạn thấy cách chỉ định rằng một hộp văn bản luôn giữ nguyên kích thước trong một bản trình chiếu PowerPoint:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Khi văn bản quá dài so với hộp, nó sẽ tràn ra. 

## **Thu nhỏ văn bản khi tràn**

Nếu văn bản trở nên quá dài so với hộp, thông qua tùy chọn **Shrink text on overflow**, bạn có thể chỉ định rằng kích thước và khoảng cách của văn bản phải được giảm để vừa vào hộp. Để chỉ định cài đặt này, sử dụng phương thức [setAutofitType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setAutofitType) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/)) với [Normal](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textautofittype/#Normal).

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Mã Python này cho bạn thấy cách chỉ định rằng văn bản phải được thu nhỏ khi tràn trong một bản trình chiếu PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}
Khi sử dụng tùy chọn **Shrink text on overflow**, cài đặt chỉ được áp dụng khi văn bản trở nên quá dài so với hộp. 
{{% /alert %}}

## **Bọc văn bản**

Nếu bạn muốn văn bản trong một hình được bọc bên trong hình khi văn bản vượt quá biên của hình (chỉ chiều rộng), bạn phải sử dụng tham số **Wrap text in shape**. Để chỉ định cài đặt này, bạn phải sử dụng phương thức [setWrapText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setWrapText) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/)) với [NullableBool.True](https://reference.aspose.com/slides/vi/python-java/aspose.slides/nullablebool/#True). 

Mã Python này cho bạn thấy cách sử dụng cài đặt Wrap Text trong một bản trình chiếu PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
Nếu bạn sử dụng phương thức [setWrapText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setWrapText) với [NullableBool.False](https://reference.aspose.com/slides/vi/python-java/aspose.slides/nullablebool/#False) cho một hình, khi văn bản bên trong hình dài hơn chiều rộng của hình, văn bản sẽ mở rộng ra ngoài biên của hình trên một dòng duy nhất. 
{{% /alert %}}

## **FAQ**

**Việc lề nội bộ của khung văn bản có ảnh hưởng đến AutoFit không?**

Có. Padding (lề nội bộ) làm giảm diện tích có thể sử dụng cho văn bản, vì vậy AutoFit sẽ kích hoạt sớm hơn—thu nhỏ phông chữ hoặc thay đổi kích thước hình sớm hơn. Kiểm tra và điều chỉnh lề trước khi tinh chỉnh AutoFit.

**AutoFit tương tác như thế nào với các ngắt dòng thủ công và ngắt dòng mềm?**

Các ngắt dòng ép buộc vẫn giữ nguyên, và AutoFit điều chỉnh kích thước phông và khoảng cách quanh chúng. Loại bỏ các ngắt không cần thiết thường giảm mức độ AutoFit phải thu nhỏ văn bản.

**Việc thay đổi phông chữ chủ đề hoặc kích hoạt thay thế phông chữ có ảnh hưởng đến kết quả AutoFit không?**

Có. Thay thế bằng phông chữ có các chỉ số glyph khác nhau làm thay đổi chiều rộng/chiều cao văn bản, có thể thay đổi kích thước phông cuối cùng và cách ngắt dòng. Sau bất kỳ thay đổi hoặc thay thế phông nào, hãy kiểm tra lại các slide.