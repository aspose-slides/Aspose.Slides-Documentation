---
title: Quản lý phông chữ trong bản trình chiếu bằng Python qua Java
linktitle: Quản lý phông chữ
type: docs
weight: 10
url: /vi/python-java/manage-fonts/
keywords:
- quản lý phông chữ
- thuộc tính phông chữ
- đoạn văn
- định dạng văn bản
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Kiểm soát phông chữ trong Python qua Java với Aspose.Slides: nhúng, thay thế và tải phông chữ tùy chỉnh để giữ cho các bản trình chiếu PPT, PPTX và ODP rõ ràng, an toàn với thương hiệu và nhất quán."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý các thuộc tính phông chữ trong văn bản của bài thuyết trình trực tiếp từ mã của bạn. Bạn có thể truy cập văn bản trong các slide thông qua các hình dạng, khung văn bản, đoạn văn và phần, sau đó áp dụng định dạng cho văn bản đã chọn.

Bài viết này giải thích cách cấu hình các thuộc tính liên quan đến phông chữ cho văn bản hiện có trong một bản trình chiếu, bao gồm họ phông chữ, kiểu in đậm và in nghiêng, căn chỉnh đoạn văn và màu phông chữ. Nó cũng chỉ cách tạo một hộp văn bản, thêm văn bản vào và đặt các thuộc tính phông chữ như họ phông chữ, in đậm, in nghiêng, gạch dưới, kích thước và màu trước khi lưu kết quả dưới dạng tệp PPTX.

## **Quản lý các thuộc tính liên quan đến phông chữ**
{{% alert color="info" title="Note" %}} 

Bản trình chiếu thường chứa cả văn bản và hình ảnh. Văn bản có thể được định dạng theo nhiều cách khác nhau, để làm nổi bật các phần và từ cụ thể hoặc để phù hợp với phong cách công ty. Định dạng văn bản giúp người dùng thay đổi giao diện và cảm nhận của nội dung bản trình chiếu. Bài viết này cho thấy cách sử dụng Aspose.Slides for Python via Java để cấu hình các thuộc tính phông chữ của các đoạn văn bản trên slide.

{{% /alert %}} 

Để quản lý các thuộc tính phông chữ của một đoạn văn bằng Aspose.Slides for Python via Java:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
1. Truy cập các hình dạng [Placeholder](https://reference.aspose.com/slides/vi/python-java/aspose.slides/placeholder/) trong slide dưới dạng [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/).
1. Lấy [Paragraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/) từ [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) được cung cấp bởi [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/).
1. Căn chỉnh đoạn văn.
1. Truy cập phần văn bản [Portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/) của một [Paragraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/).
1. Định nghĩa phông chữ bằng [FontData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontdata/) và đặt **Font** của phần văn bản [Portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/) cho phù hợp.
   1. Đặt phông chữ thành in đậm.
   1. Đặt phông chữ thành in nghiêng.
1. Đặt màu phông chữ bằng [FillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/) được cung cấp bởi đối tượng [Portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/).
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Việc triển khai các bước trên được đưa ra dưới đây. Nó nhận một bản trình chiếu chưa được định dạng và áp dụng định dạng phông chữ trên một trong các slide. Các ảnh chụp màn hình sau đây cho thấy tệp đầu vào và cách các đoạn mã thay đổi nó. Mã thay đổi phông chữ, màu và kiểu phông chữ.

|![Văn bản trong bản trình chiếu đầu vào](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Hình: Văn bản trong tệp đầu vào**|

|![Văn bản với định dạng phông chữ đã cập nhật](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Hình: Văn bản giống nhau với định dạng đã cập nhật**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Tải bản trình chiếu.
presentation = Presentation("FontProperties.pptx")
try:
    # Truy cập slide đầu tiên và các khung văn bản của hai placeholder đầu tiên.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Truy cập đoạn văn đầu tiên trong mỗi khung văn bản.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Truy cập phần văn bản đầu tiên trong mỗi đoạn văn.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Định nghĩa và gán các phông chữ mới.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Đặt phông chữ thành in đậm và in nghiêng.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Đặt màu phông chữ.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Lưu bản trình chiếu.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt thuộc tính phông chữ cho văn bản**
{{% alert color="info" title="Note" %}} 

Như đã đề cập trong **Quản lý các thuộc tính liên quan đến phông chữ**, một [Portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/) được dùng để chứa văn bản có cùng kiểu định dạng trong một đoạn văn. Bài viết này cho thấy cách sử dụng Aspose.Slides for Python via Java để tạo một hộp văn bản có một số văn bản và sau đó định nghĩa một phông chữ cụ thể cùng các thuộc tính phông chữ khác.

{{% /alert %}} 

Để tạo một hộp văn bản và đặt các thuộc tính phông chữ cho văn bản bên trong:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) loại **Rectangle** vào slide.
1. Xóa kiểu nền liên quan đến [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/).
1. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) của [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/).
1. Thêm một số văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/).
1. Truy cập đối tượng [Portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/) liên quan đến [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/).
1. Định nghĩa phông chữ sẽ được sử dụng cho [Portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/).
1. Đặt các thuộc tính phông chữ khác như in đậm, in nghiêng, gạch dưới, màu và kích thước bằng các thuộc tính tương ứng được cung cấp bởi đối tượng [Portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/).
1. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Việc triển khai các bước trên được đưa ra dưới đây.

|![Văn bản với một số thuộc tính phông chữ được áp dụng](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Hình: Văn bản với một số thuộc tính phông chữ được thiết lập bởi Aspose.Slides for Python via Java**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # Lấy slide đầu tiên và thêm một hình chữ nhật.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Xóa màu nền của hình.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Thêm văn bản vào khung văn bản của hình.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Đặt họ phông chữ.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Đặt in đậm, in nghiêng, gạch dưới và kích thước phông chữ.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # Đặt màu phông chữ.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Lưu bản trình chiếu.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```