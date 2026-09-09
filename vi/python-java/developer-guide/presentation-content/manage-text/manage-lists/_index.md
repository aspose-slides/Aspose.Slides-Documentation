---
title: Quản lý danh sách có dấu đầu dòng và đánh số trong bản trình bày bằng Python qua Java
linktitle: Quản lý danh sách
type: docs
weight: 60
url: /vi/python-java/manage-lists/
keywords:
- dấu đầu dòng
- danh sách có dấu đầu dòng
- danh sách đánh số
- dấu đầu dòng ký hiệu
- dấu đầu dòng hình ảnh
- dấu đầu dòng tùy chỉnh
- danh sách đa cấp
- tạo dấu đầu dòng
- thêm dấu đầu dòng
- thêm danh sách
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Học cách tạo và định dạng danh sách có dấu đầu dòng, dấu đầu dòng hình ảnh, danh sách đa cấp và danh sách đánh số trong bản trình bày PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Aspose.Slides for Python via Java cho phép bạn tạo và định dạng các danh sách có dấu đầu dòng và đánh số trong các bản trình bày PowerPoint và OpenDocument. Một mục danh sách là một đoạn văn mà các cài đặt dấu đầu dòng được kiểm soát thông qua định dạng đoạn văn của nó.

Sử dụng phương thức [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/#getParagraphFormat) để truy cập các cài đặt danh sách ở mức đoạn văn. Điểm vào chính là [ParagraphFormat.getBullet](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#getBullet), nó trả về một đối tượng [BulletFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bulletformat/). Với đối tượng này, bạn có thể đặt loại dấu đầu dòng, ký hiệu, hình ảnh, màu, kích thước, kiểu đánh số và số bắt đầu.

Bài viết này cho thấy cách thực hiện:

- tạo danh sách có dấu đầu dòng với ký hiệu tùy chỉnh
- tạo dấu đầu dòng dạng hình ảnh
- tạo danh sách đa cấp bằng cách đặt độ sâu đoạn văn
- tạo danh sách đánh số
- kiểm tra và thay đổi định dạng danh sách trong bản trình bày hiện có

## **Tạo danh sách có dấu đầu dòng**

Để tạo danh sách có dấu đầu dòng, thêm các đối tượng [Paragraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/) vào một [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) và đặt [BulletFormat.setType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bulletformat/#setType) thành [BulletType.Symbol](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bullettype/#Symbol). Sau đó bạn có thể sử dụng [BulletFormat.setChar](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bulletformat/#setChar), [BulletFormat.getColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bulletformat/#getColor) và [BulletFormat.setHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bulletformat/#setHeight) để kiểm soát giao diện của dấu đầu dòng.

Đoạn mã Python sau đây minh họa cách tạo danh sách có dấu đầu dòng trên một slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Các dấu đầu dòng ký hiệu](symbol_bullets.png)

## **Tạo danh sách đánh số**

Sử dụng danh sách đánh số khi thứ tự các mục quan trọng. Đặt [BulletFormat.setType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bulletformat/#setType) thành [BulletType.Numbered](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bullettype/#Numbered). Bạn cũng có thể chọn định dạng đánh số bằng [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) hoặc sử dụng [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) khi danh sách cần bắt đầu bằng giá trị khác 1.

Đoạn mã Python sau đây cho thấy cách tạo danh sách đánh số trên một slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Các dấu đầu dòng đánh số](numbered_bullets.png)

## **Tạo dấu đầu dòng dạng hình ảnh**

Aspose.Slides cho phép bạn thay thế ký hiệu dấu đầu dòng thông thường bằng một hình ảnh. Dấu đầu dòng dạng hình ảnh hoạt động tốt nhất với các hình ảnh đơn giản vẫn có thể đọc được ở kích thước nhỏ, chẳng hạn như biểu tượng hoặc tệp PNG trong suốt nhỏ.

{{% alert color="info" title="Note" %}}
Nếu bạn dự định thay thế ký hiệu dấu đầu dòng thông thường bằng một hình ảnh, hãy chọn một đồ họa đơn giản với nền trong suốt. Những hình ảnh như vậy hoạt động tốt như các ký hiệu dấu đầu dòng tùy chỉnh.
{{% /alert %}}

Để tạo dấu đầu dòng dạng hình ảnh, thêm một hình ảnh vào [Presentation.getImages](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getImages) và gán đối tượng hình ảnh trả về cho [BulletFormat.getPicture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bulletformat/#getPicture). Đặt [BulletFormat.setType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bulletformat/#setType) thành [BulletType.Picture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bullettype/#Picture) trước khi gán hình ảnh.

Giả sử chúng ta có một hình ảnh có tên "image.png":

![Một hình ảnh cho các dấu đầu dòng](picture_for_bullets.png)

Đoạn mã Python sau đây cho thấy cách tạo dấu đầu dòng dạng hình ảnh trên một slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Các dấu đầu dòng hình ảnh](picture_bullets.png)

## **Tạo danh sách đa cấp**

Sử dụng [ParagraphFormat.setDepth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setDepth) để đặt các mục danh sách ở các cấp độ khác nhau. Cấp độ 0 là cấp cao nhất, cấp độ 1 nằm bên dưới nó, và tiếp tục như vậy.

Đoạn mã Python sau đây cho thấy cách tạo danh sách có dấu đầu dòng đa cấp:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Danh sách đa cấp](multilevel_list.png)

## **Thay đổi danh sách hiện có**

Để thay đổi định dạng danh sách trong một bản trình bày hiện có, truy cập đoạn văn mục tiêu và cập nhật các cài đặt [ParagraphFormat.getBullet](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#getBullet) của nó. Các thuộc tính giống như khi tạo danh sách cũng có thể được sử dụng để kiểm tra hoặc sửa đổi các danh sách được tải từ tệp PPT, PPTX hoặc ODP.

Đoạn mã Python sau đây thay đổi đoạn văn đầu tiên trong một khung văn bản để sử dụng kiểu danh sách đánh số:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Có thể xuất các danh sách có dấu đầu dòng và đánh số sang PDF hoặc hình ảnh không?**

Có. Aspose.Slides giữ nguyên định dạng danh sách khi định dạng đích hỗ trợ bố cục văn bản và tính năng dấu đầu dòng tương ứng.

**Tôi có thể chỉnh sửa danh sách trong bản trình bày hiện có không?**

Có. Tải bản trình bày, truy cập đoạn văn mục tiêu, kiểm tra hoặc cập nhật các cài đặt [ParagraphFormat.getBullet](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#getBullet) của nó, và lưu bản trình bày.

**Các danh sách có thể chứa văn bản không phải tiếng La-tinh không?**

Có. Văn bản của mục danh sách có thể chứa các ký tự Unicode, vì vậy bạn có thể tạo danh sách trong các bản trình bày đa ngôn ngữ. Đảm bảo các phông chữ được sử dụng trong bản trình bày hỗ trợ các ký tự bạn cần.