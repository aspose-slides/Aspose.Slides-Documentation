---
title: Quản lý hàng và cột trong bảng PowerPoint bằng Python
linktitle: Hàng và Cột
type: docs
weight: 20
url: /vi/python-java/manage-rows-and-columns/
keywords:
- hàng bảng
- cột bảng
- hàng đầu tiên
- đầu đề bảng
- sao chép hàng
- sao chép cột
- sao chép hàng
- sao chép cột
- xóa hàng
- xóa cột
- định dạng văn bản hàng
- định dạng văn bản cột
- kiểu bảng
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý các hàng và cột của bảng trong PowerPoint bằng Aspose.Slides cho Python thông qua Java và tăng tốc việc chỉnh sửa bản trình chiếu cũng như cập nhật dữ liệu."
---
## **Giới thiệu**

Để cho phép bạn quản lý các hàng và cột của bảng trong một bản trình chiếu PowerPoint, Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/) và nhiều kiểu khác.

## **Đặt hàng đầu tiên làm tiêu đề**

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu.  
2. Lấy tham chiếu tới một slide theo chỉ mục của nó.  
3. Tạo một tham chiếu tới [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/) và đặt nó thành `None`.  
4. Duyệt qua tất cả các đối tượng [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/) để tìm bảng phù hợp.  
5. Đặt hàng đầu tiên của bảng làm tiêu đề.

Đoạn mã Python này cho bạn thấy cách đặt hàng đầu tiên của bảng làm tiêu đề:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sao chép một hàng hoặc cột của bảng**

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu.  
2. Lấy tham chiếu tới một slide theo chỉ mục của nó.  
3. Xác định một danh sách độ rộng cột.  
4. Xác định một danh sách chiều cao hàng.  
5. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addTable).  
6. Sao chép hàng của bảng.  
7. Sao chép cột của bảng.  
8. Lưu bản trình chiếu đã sửa đổi.

Đoạn mã Python này cho bạn thấy cách sao chép hàng hoặc cột của bảng PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)
    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Xóa một hàng hoặc cột khỏi bảng**

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .  
2. Lấy tham chiếu tới một slide theo chỉ mục của nó.  
3. Xác định một danh sách độ rộng cột.  
4. Xác định một danh sách chiều cao hàng.  
5. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/) vào slide thông qua phương thức [addTable](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addTable).  
6. Xóa hàng của bảng.  
7. Xóa cột của bảng.  
8. Lưu bản trình chiếu đã sửa đổi.

Đoạn mã Python này cho bạn thấy cách xóa một hàng hoặc cột khỏi bảng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt định dạng văn bản ở cấp độ hàng của bảng**

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu.  
2. Lấy tham chiếu tới một slide theo chỉ mục của nó.  
3. Truy cập đối tượng [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/) liên quan từ slide.  
4. Đặt chiều cao phông chữ của các ô hàng đầu tiên bằng cách sử dụng [setFontHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Đặt căn chỉnh văn bản và lề phải của các ô hàng đầu tiên bằng [setAlignment](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setAlignment) và [setMarginRight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Đặt kiểu văn bản dọc cho các ô hàng thứ hai bằng [setTextVerticalType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Lưu bản trình chiếu đã sửa đổi.

Đoạn mã Python này minh họa thao tác.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getRows().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getRows().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getRows().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Đặt định dạng văn bản ở cấp độ cột của bảng**

1. Tạo một instance của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình chiếu.  
2. Lấy tham chiếu tới một slide theo chỉ mục của nó.  
3. Truy cập đối tượng [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/) liên quan từ slide.  
4. Đặt chiều cao phông chữ của các ô cột đầu tiên bằng cách sử dụng [setFontHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Đặt căn chỉnh văn bản và lề phải của các ô cột đầu tiên bằng [setAlignment](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setAlignment) và [setMarginRight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Đặt kiểu văn bản dọc cho các ô cột thứ hai bằng [setTextVerticalType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Lưu bản trình chiếu đã sửa đổi.

Đoạn mã Python này minh họa thao tác:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getColumns().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getColumns().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getColumns().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Lấy các thuộc tính kiểu của bảng**

Aspose.Slides cho phép bạn lấy các thuộc tính kiểu cho một bảng để bạn có thể sử dụng các chi tiết đó cho bảng khác hoặc ở nơi khác. Đoạn mã Python này cho bạn thấy cách lấy các thuộc tính kiểu từ một kiểu bảng mặc định:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng chủ đề/phong cách PowerPoint cho một bảng đã được tạo không?**

Có. Bảng kế thừa chủ đề của slide/bố cục/máy chủ, và bạn vẫn có thể ghi đè lên các màu nền, viền và màu chữ trên chủ đề đó.

**Tôi có thể sắp xếp các hàng của bảng giống như trong Excel không?**

Không, các bảng trong Aspose.Slides không có tính năng sắp xếp hay lọc tích hợp. Hãy sắp xếp dữ liệu trong bộ nhớ trước, sau đó điền lại các hàng của bảng theo thứ tự đó.

**Tôi có thể có các cột sọc (striped) trong khi vẫn giữ màu tùy chỉnh cho các ô cụ thể không?**

Có. Bật chế độ cột sọc, sau đó ghi đè các ô cụ thể bằng định dạng cục bộ; định dạng cấp ô sẽ ưu tiên hơn kiểu bảng.