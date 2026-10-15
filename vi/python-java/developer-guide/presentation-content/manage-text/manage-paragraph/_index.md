---
title: Quản lý các đoạn văn bản PowerPoint trong Python qua Java
linktitle: Quản lý Đoạn Văn
type: docs
weight: 40
url: /vi/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
- thêm văn bản
- thêm đoạn
- quản lý văn bản
- quản lý đoạn
- quản lý dấu đầu dòng
- thụt đoạn
- thụt treo
- dấu đầu dòng đoạn
- danh sách có số
- danh sách có dấu đầu dòng
- thuộc tính đoạn
- nhập HTML
- văn bản sang HTML
- đoạn sang HTML
- đoạn sang hình ảnh
- văn bản sang hình ảnh
- xuất đoạn
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng các đoạn, phần, dấu đầu dòng, danh sách có số, thụt lề, nội dung HTML và hình ảnh đoạn bằng Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Aspose.Slides for Python via Java đại diện cho văn bản như một hệ thống phân cấp gồm các khung văn bản, đoạn văn và phần:

* [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) đại diện cho vùng chứa văn bản trong một hình dạng và cung cấp quyền truy cập vào bộ sưu tập đoạn văn của nó.
* [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) đại diện cho một đoạn văn trong một khung văn bản và cung cấp quyền truy cập vào các phần và định dạng ở mức độ đoạn văn.
* [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) đại diện cho một dải văn bản trong một đoạn. Mỗi phần có thể có văn bản và định dạng ký tự riêng.

Vì vậy, một đoạn văn có thể chứa văn bản với các phông chữ, màu sắc, kích thước và định dạng khác nhau bằng cách sử dụng nhiều phần.

## **Tạo và Định dạng Đoạn văn**

Tạo đoạn văn trong khung văn bản của một hình dạng và sử dụng các phần để định dạng các dải văn bản riêng lẻ. Phần này cho thấy cách kết hợp nhiều phần trong mỗi đoạn văn và áp dụng các màu sắc, kích thước phông chữ và kiểu dáng khác nhau.

### **Tạo Đoạn Văn với Nhiều Phần**

Ví dụ Python sau tạo ba đoạn văn, mỗi đoạn chứa ba dải văn bản trong bộ sưu tập được trả về bởi [Paragraph.getPortions](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getPortions). Nó tái sử dụng đoạn văn mặc định và phần rỗng của nó, sau đó thêm các đoạn và phần còn lại. Định dạng được áp dụng qua [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat): phần đầu tiên trong mỗi đoạn có màu đỏ, in đậm và kích thước 15 điểm; phần thứ hai có màu xanh lam, in nghiêng và kích thước 18 điểm. Phần thứ ba giữ định dạng mặc định:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()

    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())

    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)

    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")

            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tạo Danh Sách Điểm Đánh Dấu và Đánh Số**

Sắp xếp văn bản của đoạn văn thành các danh sách với ký hiệu, số hoặc hình ảnh tùy chỉnh. Các ví dụ trong phần này bao gồm định dạng dấu đầu dòng, danh sách đa cấp và số bắt đầu tùy chỉnh.

### **Tạo Danh Sách Điểm Đánh Dấu hoặc Đánh Số**

Dấu đầu dòng và đánh số giúp người đọc dễ dàng quét các mục liên quan. Trong Aspose.Slides, cài đặt danh sách được định nghĩa qua [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/).

Ví dụ Python này thêm một dấu đầu dòng ký hiệu và một mục được đánh số vào cùng một khung văn bản. [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) chọn loại dấu đầu dòng, trong khi [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar) cung cấp ký hiệu và [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) chọn kiểu đánh số. Cả hai mục đều sử dụng dấu đầu dòng màu đen với chiều cao bằng 100 % và độ thụt đoạn là 25 điểm:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)

    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Sử Dụng Dấu Đầu Dòng Hình Ảnh**

Dấu đầu dòng hình ảnh cho phép bạn sử dụng một hình ảnh tùy chỉnh thay vì ký hiệu hoặc số.

Ví dụ Python này thêm một hình ảnh vào bộ sưu tập hình ảnh của bản trình bày dưới dạng một [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) và sử dụng nó làm dấu đầu dòng cho đoạn văn. Nó gọi [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) để sử dụng dấu đầu dòng hình ảnh và gán hình ảnh qua [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture). [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) được đặt thành 100 % để kích thước dấu đầu dòng tương đối so với văn bản đoạn:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **Tạo Danh Sách Đa Cấp**

Đặt [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) để đặt các đoạn văn ở các cấp độ khác nhau của một danh sách. Cấp độ trên cùng có độ sâu `0`.

Ví dụ Python này gán các giá trị [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) từ 0 đến 3 cho bốn đoạn, tạo một cấu trúc phân cấp trong một khung văn bản. Mỗi đoạn sử dụng dấu đầu dòng ký hiệu, với [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar) luân phiên giữa dấu tròn và dấu gạch ngang để phân biệt các cấp độ liền kề:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)

    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)

    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)

    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Bắt Đầu Các Mục Đánh Số ở Giá Trị Tùy Chỉnh**

Sử dụng [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) để đặt số đầu tiên hiển thị cho một đoạn văn được đánh số.

Ví dụ Python này đặt [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) để sử dụng đánh số cho ba đoạn và gán các giá trị [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) là 2, 3 và 7. Giá trị bắt đầu được cấu hình riêng cho mỗi đoạn, cho phép các số hiển thị bỏ qua một số giá trị:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)

    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kiểm Soát Bố Cục Đoạn Văn và Thuộc Tính Kết Thúc**

Điều chỉnh lề và thụt lề của đoạn để kiểm soát vị trí của dòng đầu và các dòng gói. Bạn cũng có thể định dạng dấu kết thúc đoạn riêng biệt so với các phần văn bản hiển thị.

### **Đặt Thụt Dòng Đầu Tiên**

Sử dụng phương thức [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) để kiểm soát thụt lề dòng đầu tiên của một đoạn. Cài đặt này chỉ di chuyển dòng đầu tiên so với lề trái của đoạn. Giá trị dương đẩy dòng đầu tiên sang phải, trong khi các dòng còn lại vẫn căn chỉnh với thân đoạn.

Sử dụng [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) khi bạn cần di chuyển toàn bộ đoạn. Sử dụng [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) khi bạn chỉ cần di chuyển dòng đầu tiên.

Ví dụ sau đặt ba đoạn cùng một [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) là 20 điểm và các giá trị [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) là 0, 20 và 40 điểm. Các dòng đầu tiên bắt đầu ở các khoảng cách ngày càng lớn, trong khi các dòng gói vẫn giữ cùng một lề trái:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)

    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)

    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Thụt lề dòng đầu tiên của các đoạn](first_line_indent.png)

### **Đặt Thụt Lề Treo**

Thụt lề treo là bố cục đoạn trong đó dòng đầu tiên bắt đầu ở bên trái so với các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng thuộc tính [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent). Đặt `Indent` thành giá trị âm để di chuyển dòng đầu tiên sang trái so với thân đoạn.

Trong thực tế, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) xác định vị trí trái của thân đoạn, và [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) xác định vị trí của dòng đầu tiên so với lề đó. Để tạo thụt lề treo, đặt giá trị `MarginLeft` dương và giá trị `Indent` âm.

Định dạng này hữu ích cho biblio, tài liệu tham khảo, mục từ điển và các đoạn khác nơi các dòng gói phải căn dưới thân đoạn thay vì dưới ký tự đầu tiên của dòng đầu.

Ví dụ Python sau kết hợp các giá trị [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) là 40 và 60 điểm với các giá trị [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) là -20 và -30 điểm. Trong mỗi đoạn, dòng đầu tiên bắt đầu ở bên trái các dòng gói; đoạn thứ hai có thụt lề treo sâu hơn:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)

    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kết quả:

![Thụt lề treo của các đoạn](hanging_indent.png)

### **Đặt Thuộc Tính Kết Thúc Đoạn**

Phương thức [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) điều khiển định dạng của dấu kết thúc đoạn. Ví dụ sau tạo một [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) với [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) đặt thành 48 điểm và [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLatinFont) đặt thành Times New Roman. Nó gán định dạng này cho dấu kết thúc của đoạn thứ hai, để các phần văn bản hiển thị không bị thay đổi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)

    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)

    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đếm Số Dòng Được Kết Xuất**

Đối với các quy tắc đoạn ảnh hưởng đến việc tự động gói và dấu chấm câu ở cuối dòng, xem [Control Line Breaking](/slides/vi/python-java/text-formatting/#control-line-breaking) và [Control Hanging Punctuation](/slides/vi/python-java/text-formatting/#control-hanging-punctuation).

Sử dụng [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) để đếm số dòng mà một đoạn chiếm sau khi bố trí văn bản, bao gồm cả việc gói tự động. Điều này hữu ích khi kiểm tra độ dài văn bản và bố cục trong các mẫu bản trình chiếu.

Một đoạn là một mục trong [TextFrame.getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs), và nó có thể chiếm nhiều dòng đã được kết xuất. Một ngắt dòng rõ ràng trong đoạn buộc tạo một dòng mới mà không tạo đoạn mới. Việc gói tự động tạo các dòng dựa trên chiều rộng có sẵn mà không chèn ký tự ngắt dòng vào văn bản. Do đó, đếm số đoạn hoặc ký tự ngắt dòng không cho biết số dòng đã được kết xuất.

Ví dụ sau tạo một hình dạng văn bản, đếm các dòng của nó, thu hẹp hình dạng, rồi thay thế văn bản bằng một chuỗi ngắn hơn. Ví dụ bật tính năng gói bằng [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) và tắt tự động vừa bằng [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) để chiều rộng hình dạng kiểm soát việc gói mà không tự động thu nhỏ văn bản hay thay đổi kích thước hình dạng. Mỗi lần đo lường đều sử dụng [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount). Kích thước hình dạng tính bằng điểm. Cuối cùng, ví dụ thêm một đoạn khác và cộng tổng số dòng qua toàn bộ khung văn bản.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

Với văn bản và các kích thước này, thu hẹp hình dạng làm tăng số dòng, trong khi thay thế bằng chuỗi ngắn giảm số dòng. Các số đếm chính xác có thể khác nhau tùy vào phông chữ có sẵn và thay thế, kích thước phông, lề, thụt lề, gói và cài đặt tự động vừa. Hãy sử dụng phông và cài đặt bố cục dự kiến cho môi trường mục tiêu khi kiểm tra mẫu.

Số dòng một mình không quyết định liệu văn bản có tràn ra khỏi vùng chứa hay không. Chiều cao khả dụng, độ cao dòng, khoảng cách đoạn và dòng, và hành vi tự động vừa cũng quan trọng; ngay cả một dòng duy nhất cũng có thể vượt quá chiều rộng khả dụng khi tắt tính năng gói.

## **Nhập và Xuất Nội Dung Đoạn Văn**

Sử dụng HTML để đưa văn bản vào bản trình chiếu hoặc xuất các đoạn đã có để sử dụng bên ngoài. Phần này cũng cho thấy cách render các đoạn riêng lẻ thành hình ảnh, bao gồm các đoạn trong ô bảng.

### **Nhập Văn Bản HTML vào Các Đoạn Văn**

Sử dụng [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) để chuyển đổi markup HTML thành các đoạn và phần trong một khung văn bản.

Ví dụ Python này đọc HTML từ một tệp và truyền markup cho [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml). Nó xóa đoạn mặc định của khung văn bản để khung chỉ chứa nội dung đã nhập. Hình dạng chữ nhật để lại lề 10 điểm ở mỗi bên của slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)

        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **Xuất Văn Bản Đoạn Sang HTML**

Sử dụng [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) để xuất một phạm vi đoạn đã chọn dưới dạng HTML. Khi tái sử dụng văn bản bản trình chiếu trên trang web, bạn có thể muốn giữ nguyên các nhấn mạnh cục bộ mà không mang theo phông, kích thước hoặc kiểu hộp văn bản của bản trình chiếu. Đặt [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/python-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) để kiểm soát mức độ exporter tuân theo kế thừa định dạng.

Tải xuống [bản trình chiếu mẫu](text-inheritance.pptx) và đặt nó trong thư mục làm việc của ứng dụng. Slide đầu tiên chứa một hình dạng văn bản với văn bản "Inherited text; explicit red 18pt". Đầu vào cố ý sử dụng nhiều cấp độ định dạng:

- Kiểu văn bản mặc định của bản trình chiếu cung cấp Calibri với kích thước 28 pt.
- Kiểu văn bản cấp một của khung văn bản cung cấp màu xanh và in nghiêng.
- Đoạn văn đặt in đậm một cách rõ ràng.
- Phần thứ hai, "explicit red 18pt", đặt màu đỏ và kích thước 18 pt một cách rõ ràng.

Ví dụ hoàn chỉnh sau xuất cùng các đoạn ba lần. Nó truyền [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-java/aspose.slides/texttohtmlconversionoptions/) vào phương thức xuất và ghi mỗi kết quả thành một tệp HTML UTF‑8 riêng:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, TextInheritanceLimit, TextToHtmlConversionOptions

presentation = Presentation("text-inheritance.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(shape, AutoShape):
        text_frame = shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            
            modes = [TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly]
            file_names = ["All.html", "TextBox.html", "ParagraphOnly.html"]

            for mode, file_name in zip(modes, file_names):
                options = TextToHtmlConversionOptions()
                options.setTextInheritanceLimit(mode)

                html = paragraphs.exportToHtml(0, paragraphs.getCount(), options)
                try:
                    Path(file_name).write_text(str(html), encoding="utf-8")
                except OSError as exception:
                    print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

HTML được tạo chứa CSS sau cho phần đầu tiên, "Inherited text; ". Bảng liệt kê các khai báo liên quan; các thuộc tính được tạo khác bị bỏ qua để dễ đọc.

| Output | Relevant CSS for the first portion | Appearance |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Văn bản màu xanh, in đậm, in nghiêng ở 28 pt với Calibri, nếu phông đó khả dụng. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Văn bản màu xanh, in đậm, in nghiêng; phông chữ và kích thước do trang hoặc trình duyệt cung cấp. |
| `ParagraphOnly.html` | `font-weight:bold` | Văn bản in đậm; phông chữ, kích thước, màu sắc và kiểu nghiêng do trang hoặc trình duyệt cung cấp. |

Phần thứ hai giữ `color:#ff0000`, `font-size:18pt` và `font-weight:bold` trong cả ba đầu ra. Nó cũng giữ in nghiêng trong `All` và `TextBox`, nhưng không trong `ParagraphOnly`. Hạn chế kế thừa do đó không xóa định dạng được gán rõ ràng cho đoạn hoặc phần.

Mở các tệp trong cùng một trình duyệt để so sánh. Trong hai chế độ hạn chế, các thuộc tính CSS bị bỏ qua sẽ được giải quyết bởi kiểu của trang đích hoặc mặc định của trình duyệt, vì vậy giao diện cuối cùng phụ thuộc vào nơi HTML được sử dụng.

### **Render Một Đoạn Văn Thành Hình Ảnh**

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) render một đoạn riêng lẻ trực tiếp và trả về một đối tượng hình ảnh. Lưu kết quả vào tệp hoặc luồng bằng phương thức `save`. Bạn không cần render hình dạng chứa hoặc cắt thủ công bitmap.

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) có thể trả về `None` nếu đoạn không tồn tại trong bộ sưu tập cha, không có giới hạn render hợp lệ, hoặc không thể render. Kiểm tra kết quả trước khi lưu và giải phóng hình ảnh đã trả về sau khi sử dụng.

#### **Render Đoạn Văn ở Tỷ Lệ Mặc Định**

Ví dụ sử dụng một bản trình chiếu có một slide, trong đó hình dạng đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản với ba đoạn](paragraph_to_image_input.png)

Ví dụ sau chọn đoạn thứ hai (chỉ mục 1) và gọi [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) mà không có tham số tỷ lệ. Nó kiểm tra rằng hình dạng chứa đoạn yêu cầu và render trả về một hình ảnh trước khi gọi phương thức `save` để lưu dưới dạng PNG. Khối `finally` giải phóng hình ảnh sau khi dùng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()

            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

Kết quả:

![Hình ảnh đoạn văn](paragraph_to_image_output.png)

#### **Render Đoạn Văn trong Ô Bảng với Tỷ Lệ**

Sử dụng overload của [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) chấp nhận các tham số `scale_x` và `scale_y` để đặt hệ số tỷ lệ ngang và dọc. Ví dụ sau tạo một bảng, render đoạn trong ô đầu tiên với độ rộng và chiều cao gấp đôi kích thước mặc định, rồi lưu kết quả dưới dạng PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])

    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")

    paragraph_image = paragraph.getImage(scale_x, scale_y)

    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

Hệ số `1` giữ trục tại kích thước pixel mặc định. Ví dụ, `2` cho cả hai trục tạo ra hình ảnh có chiều rộng và chiều cao gần gấp đôi kích thước mặc định, tương đương với bốn lần số pixel. Các hệ số lớn hơn thường cho văn bản sắc nét hơn cho phóng to hoặc xuất độ phân giải cao, nhưng cũng tăng bộ nhớ và kích thước tệp. Các hệ số dưới `1` tạo hình ảnh nhỏ hơn với chi tiết ít hơn. Sử dụng các hệ số bằng nhau để giữ tỉ lệ khung hình của đoạn; các hệ số ngang và dọc khác nhau sẽ kéo dãn đầu ra một cách độc lập.

Render toàn bộ hình dạng bằng [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) vẫn hữu ích khi đầu ra cần bao gồm màu nền, viền hoặc ngữ cảnh hình ảnh khác của hình dạng. Đối với hình ảnh chỉ chứa đoạn, hãy sử dụng [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/).

## **Câu Hỏi Thường Gặp**

**Tôi có thể hoàn toàn tắt việc gói dòng trong một khung văn bản không?**

Có. Đặt [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) để tắt gói, vì vậy các dòng sẽ không bị ngắt ở các cạnh của khung văn bản.

**Làm sao tôi có thể lấy tọa độ chính xác trên slide của một đoạn cụ thể?**

Sử dụng [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect) để lấy hình chữ nhật bao quanh đoạn. [Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) cung cấp tọa độ của một phần riêng lẻ.

**Vị trí căn chỉnh đoạn (trái, phải, trung tâm hoặc căn đều) được kiểm soát ở đâu?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) là cài đặt mức độ đoạn và áp dụng cho toàn bộ đoạn bất kể định dạng từng phần.

Để căn chỉnh dọc các phần có kích thước phông khác nhau trong mỗi dòng, xem [Align Fonts Within a Line](/slides/vi/python-java/text-formatting/#align-fonts-within-a-line).

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho một phần của đoạn không?**

Có. Đặt [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) cho các phần riêng lẻ, để một đoạn có thể chứa văn bản bằng nhiều ngôn ngữ.