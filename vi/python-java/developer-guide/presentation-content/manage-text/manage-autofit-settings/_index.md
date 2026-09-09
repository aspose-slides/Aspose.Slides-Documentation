---
title: Nâng cao bài thuyết trình của bạn với AutoFit trong Python
linktitle: Cài đặt Autofit
type: docs
weight: 30
url: /vi/python-java/manage-autofit-settings/
keywords:
- hộp văn bản
- tự động điều chỉnh
- không tự động điều chỉnh
- vừa văn bản
- thu nhỏ văn bản
- đóng gói văn bản
- thay đổi kích thước hình
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách quản lý cài đặt AutoFit trong Aspose.Slides cho Python thông qua Java để tối ưu hiển thị văn bản trong các bản trình chiếu PowerPoint và OpenDocument và cải thiện khả năng đọc nội dung."
---
## **Giới thiệu**

Mặc định, khi bạn thêm một hộp văn bản, Microsoft PowerPoint sử dụng cài đặt **Resize shape to fit text** cho hộp văn bản—nó tự động thay đổi kích thước của hộp văn bản để đảm bảo văn bản luôn vừa vào trong.

![Hộp văn bản trong PowerPoint](textbox-in-powerpoint.png)

* Khi văn bản trong hộp văn bản dài hơn hoặc lớn hơn, PowerPoint tự động mở rộng hộp văn bản—tăng chiều cao—để cho phép nó chứa thêm văn bản.
* Khi văn bản trong hộp văn bản ngắn hơn hoặc nhỏ hơn, PowerPoint tự động thu nhỏ hộp văn bản—giảm chiều cao—để loại bỏ không gian thừa.

Trong PowerPoint, có 4 tham số hoặc tùy chọn quan trọng kiểm soát hành vi autofit cho hộp văn bản:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![Tùy chọn autofit trong PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java cung cấp các tùy chọn tương tự—một số thuộc tính trong lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/)—cho phép bạn kiểm soát hành vi autofit cho các hộp văn bản trong bản trình chiếu.

## **Thay đổi kích thước hình để vừa văn bản**

Nếu bạn muốn văn bản trong một hộp luôn vừa với hộp đó sau khi thay đổi nội dung, bạn phải sử dụng tùy chọn **Resize shape to fit text**. Để chỉ định cài đặt này, sử dụng phương thức [setAutofitType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setAutofitType) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/)) với [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textautofittype/#Shape).

![Cài đặt alwaysfit trong PowerPoint](alwaysfit-setting-powerpoint.png)

Đoạn mã Python này cho bạn cách chỉ định rằng văn bản luôn phải vừa với hộp của nó trong một bản trình chiếu PowerPoint:

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

Nếu văn bản dài hơn hoặc lớn hơn, hộp văn bản sẽ tự động được thay đổi kích thước (tăng chiều cao) để đảm bảo tất cả văn bản vừa vào trong. Nếu văn bản ngắn lại, quá trình ngược lại sẽ xảy ra.

## **Không tự động điều chỉnh**

Nếu bạn muốn một hộp văn bản hoặc hình dạng giữ nguyên kích thước bất kể các thay đổi của văn bản chứa trong đó, bạn phải sử dụng tùy chọn **Do not Autofit**. Để chỉ định cài đặt này, sử dụng phương thức [setAutofitType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setAutofitType) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/)) với [None](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textautofittype/#None).

![Cài đặt không tự động điều chỉnh trong PowerPoint](donotautofit-setting-powerpoint.png)

Đoạn mã Python này cho bạn cách chỉ định rằng một hộp văn bản luôn phải giữ nguyên kích thước trong một bản trình chiếu PowerPoint:

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
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Khi văn bản trở nên quá dài so với hộp, nó sẽ tràn ra ngoài.

## **Thu nhỏ văn bản khi tràn**

Nếu văn bản trở nên quá dài so với hộp, bạn có thể sử dụng tùy chọn **Shrink text on overflow** để chỉ định rằng kích thước và khoảng cách của văn bản phải được giảm để vừa vào hộp. Để chỉ định cài đặt này, sử dụng phương thức [setAutofitType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setAutofitType) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/)) với [Normal](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textautofittype/#Normal).

![Cài đặt thu nhỏ văn bản khi tràn trong PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Đoạn mã Python này cho bạn cách chỉ định rằng văn bản phải được thu nhỏ khi tràn trong một bản trình chiếu PowerPoint:

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

{{% alert title="Lưu ý" color="info" %}}
Khi sử dụng tùy chọn **Shrink text on overflow**, cài đặt này chỉ được áp dụng khi văn bản trở nên quá dài so với hộp.
{{% /alert %}}

## **Đóng gói văn bản**

Nếu bạn muốn văn bản trong một hình dạng được đổ vào bên trong hình khi văn bản vượt quá đường viền của hình (chỉ chiều rộng), bạn phải sử dụng tham số **Wrap text in shape**. Để chỉ định cài đặt này, bạn phải sử dụng phương thức [setWrapText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setWrapText) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/)) với [NullableBool.True_](https://reference.aspose.com/slides/vi/python-java/aspose.slides/nullablebool/#True).

Đoạn mã Python này cho bạn cách sử dụng cài đặt Wrap Text trong một bản trình chiếu PowerPoint:

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
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Cảnh báo" color="warning" %}}
Nếu bạn sử dụng phương thức [setWrapText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setWrapText) với [NullableBool.False](https://reference.aspose.com/slides/vi/python-java/aspose.slides/nullablebool/#False) cho một hình dạng, khi văn bản bên trong hình dài hơn chiều rộng của hình, văn bản sẽ kéo dài ra ngoài biên của hình trên một dòng duy nhất.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các lề nội bộ của khung văn bản có ảnh hưởng đến AutoFit không?**

Có. Khoảng đệm (lề nội bộ) làm giảm khu vực có thể sử dụng cho văn bản, vì vậy AutoFit sẽ kích hoạt sớm hơn—giảm kích thước phông chữ hoặc thay đổi kích thước hình sớm hơn. Kiểm tra và điều chỉnh lề trước khi tinh chỉnh AutoFit.

**AutoFit tương tác như thế nào với các ngắt dòng thủ công và ngắt dòng mềm?**

Các ngắt dòng được ép vẫn giữ nguyên, và AutoFit điều chỉnh kích thước phông chữ và khoảng cách quanh chúng. Loại bỏ các ngắt không cần thiết thường giảm mức độ AutoFit phải thu nhỏ văn bản.

**Thay đổi phông chữ chủ đề hoặc kích hoạt việc thay thế phông chữ có ảnh hưởng đến kết quả AutoFit không?**

Có. Thay thế phông chữ bằng một phông chữ có các chỉ số glyph khác nhau sẽ thay đổi độ rộng/độ cao của văn bản, từ đó có thể thay đổi kích thước phông chữ cuối cùng và cách bọc dòng. Sau bất kỳ thay đổi hoặc thay thế phông chữ nào, hãy kiểm tra lại các slide.