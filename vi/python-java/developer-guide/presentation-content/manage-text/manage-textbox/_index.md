---
title: Quản lý hộp văn bản trong bản trình chiếu bằng Python qua Java
linktitle: Quản lý hộp văn bản
type: docs
weight: 20
url: /vi/python-java/manage-textbox/
keywords:
- hộp văn bản
- khung văn bản
- thêm văn bản
- cập nhật văn bản
- tạo hộp văn bản
- kiểm tra hộp văn bản
- thêm cột văn bản
- thêm siêu liên kết
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tạo, xác định, định dạng và cập nhật hộp văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho Python qua Java."
---
## **Giới thiệu**

Trong Aspose.Slides cho Python thông qua Java, văn bản của slide được lưu trong các khung văn bản thuộc về các hình dạng. Lớp [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) đại diện cho hình dạng chứa văn bản phổ biến nhất và cung cấp văn bản của nó thông qua phương thức [AutoShape.getTextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Mỗi auto shape kế thừa từ [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/), nhưng không phải mọi shape đều là auto shape hoặc hỗ trợ khung văn bản. Khi xử lý một bản trình bày hiện có, hãy kiểm tra xem một shape có phải là thể hiện của [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) trước khi truy cập văn bản của nó.
{{% /alert %}}

## **Tạo một Hộp Văn Bản trên Slide**

Để tạo một hộp văn bản, thêm một auto shape vào slide, thêm văn bản vào khung văn bản của nó và lưu bản trình bày. Ví dụ sau tạo một hộp văn bản hình chữ nhật:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Các tọa độ và kích thước được truyền vào [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addAutoShape) được đo bằng điểm. [AutoShape.addTextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/#addTextFrame) khởi tạo khung văn bản với văn bản được cung cấp.

## **Kiểm Tra Hình Dạng Hộp Văn Bản**

Sử dụng phương thức [AutoShape.isTextBox](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/#isTextBox) để xác định liệu một auto shape có được xem như một hộp văn bản hay không. Điều này hữu ích khi bản trình bày chứa cả các auto shape có văn bản và các auto shape chỉ là đồ họa.

![Một hộp văn bản và một hình dạng](istextbox.png)

Ví dụ sau kiểm tra mọi auto shape trong một bản trình bày:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

Một auto shape mới thêm sẽ không được coi là hộp văn bản cho đến khi nó chứa văn bản không rỗng. Bạn có thể cung cấp văn bản đó qua [AutoShape.addTextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/#addTextFrame) hoặc [TextFrame.setText](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#setText). Thêm hoặc gán một chuỗi rỗng sẽ khiến [AutoShape.isTextBox](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/#isTextBox) trả về `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

Hai lần gọi đầu tiên in ra `True`; hai lần gọi cuối cùng in ra `False`.

## **Tìm Kiếm Shape Chủ Sở Hữu Khung Văn Bản**

Mã xử lý văn bản chung có thể nhận được một [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) mà không biết đối tượng bản trình bày nào chứa nó. Sử dụng phương thức chỉ‑đọc [TextFrame.getParentShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getParentShape) để điều hướng trở lại [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/) sở hữu.

Đối với một khung văn bản được sở hữu bởi một auto shape hoặc một shape khác có văn bản, [TextFrame.getParentShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getParentShape) trả về chủ sở hữu và [TextFrame.getParentCell](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getParentCell) trả về `None`. Kiểm tra giá trị trả về trước khi truy cập. Để xác định cả chủ sở hữu shape và ô bảng, bao gồm các shape liên quan tới nút SmartArt, xem [Search and Replace Text](/slides/vi/python-java/search-and-replace-text/).

## **Thêm Cột Vào Hộp Văn Bản**

Phương thức [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setColumnCount) chia khung văn bản thành các cột, trong khi [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setColumnSpacing) đặt khoảng cách giữa các cột tính bằng điểm. Cả hai cài đặt này thuộc về [TextFrameFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/) và có thể thay đổi thông qua khung văn bản của một hộp văn bản hiện có. Văn bản được tái bố trí giữa các cột trong cùng một shape; nó sẽ không tiếp tục sang shape khác.

Ví dụ sau tạo một hộp văn bản ba cột với khoảng cách 10 điểm giữa các cột, lưu bản trình bày và đọc lại các thiết lập đã lưu từ tệp đầu ra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **Trích Xuất Văn Bản Từ Các Cột Riêng Lẻ**

Sử dụng [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#splitTextByColumns) để lấy văn bản được gán cho mỗi cột trực quan trong một khung văn bản hiện có. Phương thức trả về một chuỗi cho mỗi cột, theo thứ tự đọc dựa trên cột. Một khung văn bản một cột tạo ra một mảng với một phần tử, và một cột trống được biểu thị bằng một chuỗi rỗng. Các chuỗi chỉ chứa văn bản thuần; định dạng cấp phần không được bảo lưu.

Điều này hữu ích khi bạn cần:

- Trích xuất văn bản đồng thời giữ nguyên thứ tự đọc dựa trên cột.
- Lập chỉ mục hoặc so sánh nội dung của các slide đa cột.
- Xuất mỗi cột ra một tệp riêng, trường cơ sở dữ liệu hoặc đích khác.
- Kiểm tra cách văn bản được phân phối lại sau khi thay đổi số cột bằng [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setColumnCount), khoảng cách bằng [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setColumnSpacing), phông chữ hoặc kích thước khung văn bản.

Phương thức báo cáo văn bản phân phối trong [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/) hiện tại; nó không tự động chảy văn bản giữa các shape hoặc hộp văn bản riêng biệt. Việc phân bổ cột có thể phụ thuộc vào phông chữ có sẵn và các cài đặt bố cục văn bản khác, vì vậy hãy đảm bảo các phông chữ cần thiết đã được cài đặt khi kết quả nhất quán là quan trọng.

Ví dụ sau tải một bản trình bày, tìm auto shape đa cột đầu tiên có khung văn bản, đọc số cột đã cấu hình và ghi văn bản từ mỗi cột vào một tệp riêng. Các shape không cung cấp khung văn bản sẽ bị bỏ qua.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **Cập Nhật Văn Bản**

Để cập nhật văn bản trong toàn bộ bản trình bày, lặp qua các slide và shape, chọn các auto shape và sau đó chỉnh sửa các phần văn bản của chúng. Làm việc ở mức phần cho phép bạn thay đổi cả văn bản và định dạng ký tự.

Ví dụ sau thay thế mọi xuất hiện của `years` bằng `months` trong văn bản của auto shape và làm đậm mỗi phần bị ảnh hưởng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Quá trình duyệt này chỉ cập nhật văn bản trong các auto shape. Văn bản được lưu trong bảng, biểu đồ, SmartArt hoặc shape nhóm yêu cầu duyệt các bộ sưu tập riêng của các đối tượng đó.

## **Thêm Hộp Văn Bản Với Siêu Liên Kết**

Một siêu liên kết có thể được gán cho một phần văn bản cụ thể, vì vậy chỉ phần văn bản đó hoạt động như một liên kết có thể nhấp. Sử dụng [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) để liên kết phần đó với một URL bên ngoài.

Ví dụ sau tạo văn bản có liên kết và lưu nó vào một bản trình bày:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu Hỏi Thường Gặp**

**Sự khác nhau giữa hộp văn bản và trình giữ chỗ văn bản trên slide master hoặc layout là gì?**

Một [placeholder](/slides/vi/python-java/manage-placeholder/) có thể kế thừa vị trí và định dạng từ một [master slide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslide/) hoặc [layout slide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/). Một hộp văn bản thông thường là một shape độc lập trên slide mà nó được tạo và sẽ không nhận hành vi của placeholder khi bố cục thay đổi.

**Làm thế nào để thay thế văn bản mà không ảnh hưởng đến văn bản trong biểu đồ, bảng hoặc SmartArt?**

Giới hạn việc duyệt chỉ các shape là thể hiện của [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/), như trong ví dụ Cập Nhật Văn Bản. Biểu đồ, bảng và SmartArt lưu văn bản trong mô hình đối tượng riêng của chúng, vì vậy chúng sẽ không bị thay đổi bởi vòng lặp đó.