---
title: Lấy Thuộc tính Hiệu lực của Hình dạng từ Bản trình chiếu trong Python qua Java
linktitle: Thuộc tính Hiệu lực
type: docs
weight: 50
url: /vi/python-java/shape-effective-properties/
keywords:
- thuộc tính hình dạng
- thuộc tính camera
- hệ thống ánh sáng
- hình dạng viền
- khung văn bản
- kiểu văn bản
- chiều cao phông chữ
- định dạng nền
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách sử dụng Aspose.Slides cho Python qua Java để phân biệt định dạng hình dạng cục bộ, kế thừa và hiệu lực trong các bản trình chiếu PowerPoint."
---
## **Hiểu Thuộc tính Cục bộ, Kế thừa và Hiệu lực**

Định dạng PowerPoint có thể đến từ nhiều nguồn. Giá trị được lưu trực tiếp trên một đối tượng là **giá trị cục bộ**. Nếu giá trị đó chưa được đặt, PowerPoint sẽ xem các nguồn định dạng cha, chẳng hạn như mặc định đoạn văn, kiểu văn bản, bố cục hoặc slide mẫu, chủ đề, hoặc mặc định cấp trình chiếu. Những giá trị đó là **giá trị kế thừa**. Giá trị còn lại sau khi toàn bộ cây kế thừa được giải quyết là **giá trị hiệu lực** — giá trị được dùng để hiển thị đối tượng.

Ví dụ, một phần văn bản có thể không xác định chiều cao phông chữ riêng. Giá trị cục bộ của nó [getFontHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseportionformat/#getFontHeight) sẽ là `float("nan")`, nghĩa là “không được đặt ở đây”. Phần này có thể kế thừa chiều cao từ đoạn văn, kiểu văn bản mặc định của trình chiếu, hoặc nguồn áp dụng khác. Gọi [getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/#getEffective) trên định dạng phần sẽ trả về chiều cao đã được giải quyết cuối cùng.

Sử dụng hai loại dữ liệu định dạng cho các mục đích khác nhau:

- Đọc hoặc thay đổi một đối tượng định dạng cục bộ, chẳng hạn như [PortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/), khi bạn cần kiểm soát vị trí mà một giá trị được định nghĩa.
- Đọc một đối tượng dữ liệu hiệu lực, chẳng hạn như `PortionFormatEffectiveData`, khi bạn cần kết quả cuối cùng đã được render. Dữ liệu hiệu lực chỉ đọc.

## **So sánh Giá trị Cục bộ, Kế thừa và Hiệu lực**

Ví dụ hoàn chỉnh sau tạo một hình dạng và áp dụng chiều cao phông chữ ở mức trình chiếu, đoạn văn và phần. Mỗi bước in ra các giá trị được định nghĩa ở các mức đó và giá trị hiệu lực kết quả cho cùng một phần văn bản. Nó cũng minh họa lý do tại sao dữ liệu hiệu lực phải được đọc lại sau khi thay đổi định dạng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # Đọc dữ liệu hiệu lực sau các thay đổi trước đó.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # Xác định các giá trị kế thừa ở hai mức độ khác nhau.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Giá trị cục bộ trên phần ghi đè cả hai giá trị kế thừa.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Thay đổi một giá trị kế thừa không ghi đè giá trị cục bộ đã tồn tại.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Xóa giá trị cục bộ. Phần hiện tại lại kế thừa từ đoạn văn.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Xóa giá trị đoạn văn. Mặc định của bản trình chiếu bây giờ cung cấp kết quả.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mức ưu tiên trong ví dụ này là định dạng cục bộ của phần, tiếp theo là định dạng đoạn văn, rồi đến mặc định của trình chiếu. Các đối tượng khác có thể có chuỗi kế thừa khác, nhưng nguyên tắc vẫn giống: giá trị cụ thể hơn sẽ thắng, và [getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/#getEffective) trả về kết quả cuối cùng.

## **Lấy Thuộc tính Văn bản Hiệu lực**

Định dạng văn bản được chia thành nhiều đối tượng:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#getEffective) giải quyết các thuộc tính khung văn bản như lề, neo, tự động vừa, và hướng văn bản dọc.
- [TextStyle.getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textstyle/#getEffective) giải quyết định dạng đoạn văn cho mỗi mức độ kiểu văn bản.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/paragraphformat/#getEffective) giải quyết các thuộc tính đoạn văn như căn chỉnh, thụt lề, và dấu ký tự đầu dòng.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/#getEffective) giải quyết các thuộc tính ký tự như chiều cao phông, phông chữ, màu, in đậm và in nghiêng.

Đối với ví dụ tiếp theo, `text-formatting.pptx` phải chứa ít nhất một slide và một [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) có khung văn bản không rỗng. AutoShape có thể xuất hiện ở bất kỳ vị trí nào trong bộ sưu tập hình dạng; mã sẽ tìm kiếm đối tượng phù hợp và xác thực nó trước khi sử dụng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **Lấy Thuộc tính 3D Hiệu lực**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getEffective) trả về một đối tượng `ThreeDFormatEffectiveData` nhóm tất cả các cài đặt 3D đã được giải quyết. Các phương thức `getCamera`, `getLightRig`, `getBevelTop` và `getBevelBottom` của nó công khai dữ liệu hiệu lực tương ứng. Đọc các cài đặt liên quan này cùng nhau giúp dễ hiểu hơn về diện mạo 3D cuối cùng của một hình dạng.

Đối với ví dụ này, `shape-3d.pptx` phải chứa ít nhất một hình dạng trên slide đầu tiên. Áp dụng cài đặt camera 3D, ánh sáng hoặc bevel cho hình dạng đó nếu bạn muốn kết quả chứa các giá trị khác với mặc định.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **Lấy Định dạng Bảng Hiệu lực**

Định dạng bảng có thể đến từ kiểu bảng và từ các định dạng được áp dụng cho toàn bộ bảng, một cột, một hàng hoặc một ô riêng lẻ. Khi có xung đột giữa các màu nền được xác định rõ, mức ưu tiên là ô, hàng, cột, rồi toàn bộ bảng. Định dạng hiệu lực của một ô là định dạng cuối cùng được dùng để vẽ ô đó.

Đối với ví dụ này, `table-formatting.pptx` phải chứa ít nhất một bảng trên slide đầu tiên. Bảng phải có ít nhất một hàng và một cột. Mã sẽ tìm kiếm một [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/) thay vì giả định rằng `getShapes().get_Item(0)` là một bảng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

Nếu bạn cần màu thay vì chỉ loại nền, trước hết kiểm tra `getFillType` hiệu lực, sau đó đọc phương thức tương ứng với loại đó — ví dụ, `getSolidFillColor` cho nền đặc.

## **Đọc lại Dữ liệu Hiệu lực sau Khi Thay đổi**

Dữ liệu hiệu lực mô tả cây định dạng tại thời điểm nó được giải quyết. Gọi lại [getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/#getEffective) sau khi thay đổi bất kỳ thứ gì có thể tham gia vào cây đó, bao gồm:

- định dạng cục bộ của đối tượng;
- mặc định đoạn văn hoặc khung văn bản;
- kiểu bảng, bảng, cột, hàng hoặc định dạng ô;
- định dạng bố cục hoặc slide mẫu;
- dữ liệu chủ đề hoặc mặc định cấp trình chiếu;
- bố cục hoặc mẫu được gán cho một slide.

Không giữ một đối tượng dữ liệu hiệu lực như một ảnh chụp nhanh vĩnh viễn. Aspose.Slides có thể lưu bộ nhớ đệm một số dữ liệu hiệu lực nội bộ, và một lời gọi [getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/#getEffective) sau này có thể làm mới dữ liệu đó. Nếu bạn cần so sánh các giá trị trước và sau khi thay đổi, sao chép các giá trị vô hướng bạn cần — chẳng hạn như chiều cao phông, màu, căn chỉnh, hoặc độ rộng bevel — vào các biến của bạn trước khi thực hiện thay đổi.

Để thay đổi một giá trị, cập nhật đối tượng định dạng cục bộ thích hợp rồi gọi [getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/#getEffective) để xác minh kết quả. Các đối tượng dữ liệu hiệu lực tự chúng là chỉ đọc.

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể biết cấp độ nào cung cấp giá trị hiệu lực?**

Dữ liệu hiệu lực chứa giá trị cuối cùng, không phải nguồn của nó. Kiểm tra các đối tượng cục bộ áp dụng từ mức độ cụ thể nhất ra ngoài. Đối với văn bản, điều này có thể bao gồm phần, đoạn, khung văn bản, bố cục, mẫu, chủ đề và mặc định của trình chiếu. Các giá trị không xác định như `float("nan")` hoặc `None` cho biết việc tìm kiếm tiếp tục ở cấp độ khác.

**Điều gì xảy ra khi không có cấp độ nào định nghĩa thuộc tính?**

Aspose.Slides sẽ giải quyết giá trị mặc định thích hợp của PowerPoint hoặc thư viện. Giá trị đã giải quyết đó sẽ xuất hiện trong dữ liệu hiệu lực mặc dù không có đối tượng cục bộ nào xác định rõ nó.

**Tại sao đôi khi một giá trị hiệu lực lại bằng giá trị cục bộ?**

Giá trị cục bộ đã thắng trong phép tính kế thừa. Điều này là mong đợi khi thuộc tính được đặt rõ ràng trên đối tượng và không có quy tắc cụ thể hơn nào ghi đè nó.

**Khi nào tôi nên sử dụng dữ liệu cục bộ thay vì dữ liệu hiệu lực?**

Sử dụng dữ liệu cục bộ để kiểm tra hoặc chỉnh sửa một mức định dạng cụ thể. Sử dụng dữ liệu hiệu lực khi bạn cần giao diện cuối cùng sau khi kế thừa, quy tắc chủ đề và các kiểu áp dụng đã được giải quyết. [Ví dụ so sánh đầy đủ](#compare-local-inherited-and-effective-values) minh họa cả hai trong cùng một quy trình làm việc.