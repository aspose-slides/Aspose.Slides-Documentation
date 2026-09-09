---
title: Quản lý các đoạn văn bản PowerPoint bằng Python qua Java
linktitle: Quản lý Đoạn văn
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
- thụt lề đoạn
- thụt lề treo
- dấu đầu dòng đoạn
- danh sách đánh số
- danh sách dấu đầu dòng
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
description: "Tìm hiểu cách tạo và định dạng các đoạn, phần, dấu đầu dòng, danh sách đánh số, thụt lề, nội dung HTML và hình ảnh đoạn với Aspose.Slides cho Python qua Java."
---
## **Tổng quan**

Aspose.Slides for Python via Java đại diện cho văn bản dưới dạng một hệ thống phân cấp gồm các khung văn bản, đoạn văn và phần:

* [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) đại diện cho bộ chứa văn bản trong một hình dạng và cung cấp quyền truy cập vào bộ sưu tập đoạn văn của nó.
* [Paragraph](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/) đại diện cho một đoạn văn trong một khung văn bản và cung cấp quyền truy cập vào các phần và định dạng cấp đoạn của nó.
* [Portion](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/) đại diện cho một đoạn chạy văn bản trong một đoạn văn. Mỗi phần có thể có văn bản và định dạng ký tự riêng.

Do đó một đoạn văn có thể chứa văn bản với các phông chữ, màu sắc, kích thước và các định dạng khác nhau bằng cách sử dụng nhiều phần.

## **Tạo và Định dạng Đoạn văn**

### **Tạo Đoạn văn với Nhiều Phần**

Các bước sau tạo một khung văn bản với ba đoạn, mỗi đoạn chứa ba phần:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Truy cập slide tương ứng bằng chỉ mục của nó.
3. Thêm một [AutoShape] hình chữ nhật vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) của hình.
5. Sử dụng đoạn mặc định và thêm hai đối tượng [Paragraph] nữa vào khung văn bản.
6. Thêm đủ các đối tượng [Portion] cho mỗi đoạn để chứa ba phần. Đoạn mặc định đã chứa một phần trống.
7. Đặt văn bản cho mỗi phần.
8. Áp dụng định dạng cấp ký tự qua [Portion.getPortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#getPortionFormat).
9. Lưu bản trình chiếu đã sửa đổi.

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

## **Tạo Danh sách Dấu đầu dòng và Đánh số**

### **Tạo Danh sách Dấu đầu dòng hoặc Đánh số**

Dấu đầu dòng và số giúp các mục liên quan dễ dàng quét. Trong Aspose.Slides, cài đặt danh sách được định nghĩa qua [BulletFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bulletformat/).

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Truy cập slide tương ứng bằng chỉ mục của nó.
3. Thêm một [AutoShape] vào slide đã chọn.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) của hình.
5. Xóa đoạn mặc định khỏi khung văn bản.
6. Tạo một [Paragraph] cho dấu đầu dòng ký hiệu.
7. Đặt [BulletFormat.setType] thành [BulletType.Symbol] và chỉ định ký tự dấu đầu dòng.
8. Đặt văn bản đoạn, thụt lề, màu dấu đầu dòng và chiều cao dấu đầu dòng.
9. Thêm đoạn vào khung văn bản.
10. Tạo đoạn thứ hai và đặt [BulletFormat.setType] thành [BulletType.Numbered].
11. Cấu hình kiểu dấu đầu dòng đánh số và thêm đoạn vào khung văn bản.
12. Lưu bản trình chiếu.

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

### **Sử dụng Dấu đầu dòng Hình ảnh**

Dấu đầu dòng hình ảnh cho phép bạn dùng một hình ảnh tùy chỉnh thay cho ký hiệu hoặc số.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Truy cập slide tương ứng bằng chỉ mục của nó.
3. Thêm một [AutoShape] và truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) của nó.
4. Xóa đoạn mặc định khỏi khung văn bản.
5. Tải hình ảnh dấu đầu dòng và thêm nó vào bộ sưu tập hình ảnh của bản trình chiếu dưới dạng [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) .
6. Tạo một [Paragraph] và đặt văn bản cho nó.
7. Đặt [BulletFormat.setType] thành [BulletType.Picture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bullettype/#Picture) .
8. Gán hình ảnh thông qua [BulletFormat.getPicture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bulletformat/#getPicture) và đặt chiều cao dấu đầu dòng.
9. Thêm đoạn vào khung văn bản.
10. Lưu bản trình chiếu đã sửa đổi.

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

### **Tạo Danh sách Đa cấp**

Đặt [ParagraphFormat.setDepth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setDepth) để đặt các đoạn ở các cấp độ khác nhau của danh sách. Cấp cao nhất có độ sâu là `0`.

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và truy cập một slide.
2. Thêm một [AutoShape] và xóa đoạn mặc định khỏi khung văn bản của nó.
3. Tạo bốn đoạn và cấu hình ký hiệu dấu đầu dòng cho chúng.
4. Đặt giá trị [ParagraphFormat.setDepth] của chúng thành `0`, `1`, `2` và `3`.
5. Thêm các đoạn vào khung văn bản và lưu bản trình chiếu.

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

### **Bắt đầu các mục danh sách đánh số với giá trị tùy chỉnh**

Sử dụng [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/vi/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) để đặt số đầu tiên hiển thị cho một đoạn được đánh số.

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và thêm một [AutoShape] vào một slide.
2. Xóa đoạn mặc định khỏi khung văn bản của hình.
3. Tạo ba đoạn được đánh số.
4. Đặt [BulletFormat.setNumberedBulletStartWith] thành `2`, `3` và `7` cho các đoạn tương ứng.
5. Thêm các đoạn vào khung văn bản và lưu bản trình chiếu.

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

## **Kiểm soát Bố cục Đoạn văn và Thuộc tính Kết thúc**

### **Đặt Thụt Lề Dòng Đầu tiên**

Sử dụng [ParagraphFormat.setIndent](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setIndent) để kiểm soát thụt lề dòng đầu tiên của một đoạn. Phương pháp này di chuyển chỉ dòng đầu tiên so với lề trái của đoạn. Giá trị dương sẽ đẩy dòng đầu tiên sang phải, trong khi các dòng còn lại vẫn căn chỉnh với phần thân đoạn.

Sử dụng [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setMarginLeft) khi bạn cần di chuyển toàn bộ đoạn. Sử dụng [ParagraphFormat.setIndent] khi bạn chỉ cần di chuyển dòng đầu tiên.

Ví dụ dưới đây tạo một số đoạn và áp dụng các giá trị [ParagraphFormat.setIndent] khác nhau để minh họa cách thụt lề dòng đầu tiên ảnh hưởng đến bố cục đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape] hình chữ nhật vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) của hình và xóa đoạn mặc định.
5. Tạo một số đoạn và đặt các giá trị [ParagraphFormat.setIndent] khác nhau cho chúng.
6. Thêm các đoạn vào khung văn bản.
7. Lưu bản trình chiếu đã sửa đổi.

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
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
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

![Thụt lề dòng đầu tiên của các đoạn văn](first_line_indent.png)

### **Đặt Thụt Lề Treo**

Thụt lề treo là bố cục đoạn trong đó dòng đầu tiên bắt đầu ở bên trái so với các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng [ParagraphFormat.setIndent]. Đưa giá trị âm để di chuyển dòng đầu tiên sang trái so với phần thân đoạn.

Thực tế, [ParagraphFormat.setMarginLeft] xác định vị trí bên trái của phần thân đoạn, và [ParagraphFormat.setIndent] xác định vị trí của dòng đầu tiên so với lề đó. Để tạo thụt lề treo, đưa giá trị dương cho [ParagraphFormat.setMarginLeft] và giá trị âm cho [ParagraphFormat.setIndent].

Định dạng này hữu ích cho thư mục, tài liệu tham khảo, mục bách khoa toàn thư và các đoạn khác nơi các dòng gập phải căn dưới phần thân đoạn thay vì dưới ký tự đầu tiên của dòng đầu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape] hình chữ nhật vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) của hình và xóa đoạn mặc định.
5. Tạo các đoạn và đưa giá trị dương cho [ParagraphFormat.setMarginLeft] cho mỗi đoạn.
6. Đưa giá trị âm cho [ParagraphFormat.setIndent] để tạo hiệu ứng thụt lề treo.
7. Thêm các đoạn vào khung văn bản.
8. Lưu bản trình chiếu đã sửa đổi.

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

![Thụt lề treo của các đoạn văn](hanging_indent.png)

### **Đặt Thuộc tính Chạy Đoạn Văn Kết thúc**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) kiểm soát định dạng của dấu kết thúc đoạn. Ví dụ sau gán kích thước phông chữ và phông Latin cho dấu kết thúc của đoạn thứ hai:

1. Tải một [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và truy cập một slide.
2. Thêm một [AutoShape] và xóa đoạn mặc định của nó.
3. Tạo hai đoạn và thêm các phần văn bản vào chúng.
4. Tạo một [PortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/) cho dấu kết thúc của đoạn thứ hai.
5. Đặt [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setFontHeight) và [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setLatinFont) .
6. Gán định dạng bằng [Paragraph.setEndParagraphPortionFormat] và lưu bản trình chiếu.

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

## **Nhập và Xuất Nội dung Đoạn văn**

### **Nhập Văn bản HTML vào Đoạn văn**

Sử dụng [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphcollection/#addFromHtml) để chuyển đổi mã HTML thành các đoạn và phần trong một khung văn bản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Truy cập một slide và thêm một [AutoShape] .
3. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) của hình và xóa đoạn mặc định.
4. Đọc tệp HTML nguồn.
5. Đưa chuỗi HTML vào [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphcollection/#addFromHtml) .
6. Lưu bản trình chiếu đã sửa đổi.

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

### **Xuất Văn bản Đoạn văn ra HTML**

Sử dụng [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphcollection/#exportToHtml) để xuất một phạm vi đã chọn của các đoạn dưới dạng HTML.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu mong muốn.
2. Truy cập slide và tìm [AutoShape] chứa văn bản.
3. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) của hình.
4. Gọi [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphcollection/#exportToHtml) với chỉ mục đoạn bắt đầu và số lượng đoạn cần xuất.
5. Ghi chuỗi HTML trả về vào tệp.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **Kết xuất Đoạn văn thành Hình ảnh**

[Paragraph.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/) kết xuất trực tiếp một đoạn riêng lẻ và trả về một đối tượng hình ảnh. Lưu kết quả vào tệp hoặc luồng bằng phương thức `save` của nó. Bạn không cần phải kết xuất hình chứa hoặc cắt bitmap bằng tay.

[Paragraph.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/) có thể trả về `None` nếu đoạn không tồn tại trong bộ sưu tập cha, không có giới hạn kết xuất hợp lệ, hoặc không thể được kết xuất. Kiểm tra kết quả trước khi lưu và giải phóng hình ảnh đã trả về sau khi sử dụng.

#### **Kết xuất Đoạn văn ở Tỷ lệ Mặc định**

Giả sử chúng ta có một tệp bản trình chiếu có tên sample.pptx với một slide, trong đó hình dạng đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản với ba đoạn văn](paragraph_to_image_input.png)

Ví dụ sau kết xuất đoạn thứ hai trong một hình dạng văn bản thường ở tỷ lệ mặc định và lưu hình ảnh trả về ở định dạng PNG. Khối `finally` đảm bảo hình ảnh được giải phóng đúng cách.

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

#### **Kết xuất Đoạn văn trong Ô Bảng với Tỷ lệ**

Sử dụng overload của [Paragraph.getImage] chấp nhận các tham số `scale_x` và `scale_y` để đặt các hệ số tỷ lệ ngang và dọc. Ví dụ sau tạo một bảng, kết xuất đoạn trong ô đầu tiên với độ rộng và chiều cao gấp đôi so với mặc định, và lưu kết quả dưới dạng PNG.

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

Hệ số tỷ lệ `1` giữ trục tương ứng ở kích thước pixel mặc định. Ví dụ, `2` cho cả hai hệ số sẽ tạo một hình ảnh có chiều rộng và chiều cao khoảng gấp đôi kích thước mặc định, tương đương với bốn lần số pixel. Các hệ số lớn hơn thường tạo ra văn bản sắc nét hơn cho việc phóng to hoặc xuất độ phân giải cao, nhưng cũng tăng sử dụng bộ nhớ và kích thước tệp. Các hệ số dưới `1` tạo hình ảnh nhỏ hơn với chi tiết ít hơn. Sử dụng các hệ số bằng nhau để duy trì tỉ lệ khung hình của đoạn; các hệ số ngang và dọc khác nhau sẽ kéo giãn đầu ra một cách độc lập.

Kết xuất toàn bộ hình dạng bằng [Shape.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage) vẫn hữu ích khi đầu ra cần bao gồm nền, viền hoặc ngữ cảnh hình ảnh khác. Đối với hình ảnh chỉ chứa đoạn, sử dụng [Paragraph.getImage].

## **Câu hỏi thường gặp**

**Tôi có thể hoàn toàn tắt việc ngắt dòng trong khung văn bản không?**

Có. Đặt [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setWrapText) để tắt việc ngắt dòng sao cho các dòng không bị cắt ở các cạnh của khung văn bản.

**Làm sao tôi có thể lấy kích thước chính xác trên slide của một đoạn cụ thể?**

Sử dụng [Paragraph.getRect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraph/#getRect) để lấy hình chữ nhật bao quanh đoạn. [Portion.getRect](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portion/#getRect) cung cấp giới hạn của một phần riêng lẻ.

**Vị trí căn chỉnh đoạn văn (trái, phải, giữa, hoặc đều) được điều khiển ở đâu?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setAlignment) là một cài đặt cấp đoạn và áp dụng cho toàn bộ đoạn bất kể định dạng riêng lẻ của các phần.

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho một phần của đoạn văn không?**

Có. Đặt [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setLanguageId) cho từng phần, vì vậy một đoạn có thể chứa văn bản bằng nhiều ngôn ngữ.