---
title: Lấy Thuộc tính Hiệu quả của Hình từ Bài thuyết trình trong Python
linktitle: Thuộc tính Hiệu quả
type: docs
weight: 50
url: /vi/python-net/shape-effective-properties/
keywords:
- thuộc tính hình
- thuộc tính máy ảnh
- bộ ánh sáng
- hình chạm góc
- khung văn bản
- kiểu văn bản
- chiều cao phông chữ
- định dạng tô màu
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách sử dụng Aspose.Slides cho Python thông qua .NET để phân biệt định dạng hình cục bộ, kế thừa và hiệu quả trong các bài thuyết trình PowerPoint."
---
## **Hiểu Thuộc tính Cục bộ, Kế thừa và Hiệu quả**

Định dạng PowerPoint có thể đến từ nhiều nơi. Giá trị được lưu trữ trực tiếp trên một đối tượng là **giá trị cục bộ** của nó. Nếu giá trị đó không được đặt, PowerPoint sẽ xem các nguồn định dạng cha, chẳng hạn như mặc định đoạn văn, kiểu văn bản, bố cục hoặc slide mẫu, chủ đề, hoặc mặc định ở mức bài thuyết trình. Những giá trị đó là **giá trị kế thừa**. Giá trị còn lại sau khi toàn bộ chuỗi phân cấp được giải quyết là **giá trị hiệu quả**, giá trị này được sử dụng để hiển thị đối tượng.

Ví dụ, một phần văn bản có thể không xác định chiều cao phông chữ của riêng mình. **font_height** cục bộ của nó là `float("nan")`, nghĩa là “không được đặt ở đây.” Phần văn bản có thể kế thừa chiều cao từ đoạn văn, kiểu văn bản mặc định của bài thuyết trình, hoặc nguồn áp dụng khác. Gọi [get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iportionformat/get_effective/) trên định dạng phần sẽ trả về chiều cao đã được giải quyết cuối cùng.

Sử dụng hai loại dữ liệu định dạng cho các mục đích khác nhau:

- Đọc hoặc thay đổi một đối tượng định dạng cục bộ, chẳng hạn như [IPortionFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iportionformat/), khi bạn cần kiểm soát nơi giá trị được định nghĩa.
- Đọc một đối tượng dữ liệu hiệu quả, chẳng hạn như [IPortionFormatEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iportionformateffectivedata/), khi bạn cần kết quả cuối cùng đã được hiển thị. Dữ liệu hiệu quả chỉ đọc.

## **So sánh Giá trị Cục bộ, Kế thừa và Hiệu quả**

Ví dụ hoàn chỉnh dưới đây tạo một hình và áp dụng chiều cao phông chữ ở mức bài thuyết trình, đoạn văn và phần. Mỗi bước in ra các giá trị được định nghĩa ở các mức đó và giá trị hiệu quả tương ứng cho cùng một phần văn bản. Nó cũng minh họa vì sao dữ liệu hiệu quả phải được đọc lại sau khi thay đổi định dạng.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # Đọc dữ liệu hiệu quả sau các thay đổi trước đó.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # Xác định các giá trị kế thừa ở hai mức khác nhau.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Giá trị cục bộ trên phần sẽ ghi đè cả hai giá trị kế thừa.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Thay đổi giá trị kế thừa sẽ không ghi đè giá trị cục bộ hiện có.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Xóa giá trị cục bộ. Phần bây giờ lại kế thừa từ đoạn văn.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Xóa giá trị đoạn văn. Mặc định của bài thuyết trình bây giờ cung cấp kết quả.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

Độ ưu tiên trong ví dụ này là định dạng cục bộ của phần, sau đó là định dạng đoạn, rồi đến mặc định của bài thuyết trình. Các đối tượng khác có thể có chuỗi kế thừa khác, nhưng nguyên tắc vẫn giống: một giá trị cụ thể hơn sẽ thắng, và [get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iportionformat/get_effective/) trả về kết quả cuối cùng.

## **Lấy Thuộc tính Văn bản Hiệu quả**

Định dạng văn bản được chia thành nhiều đối tượng:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/vi/python-net/aspose.slides/itextframeformat/get_effective/) giải quyết các thuộc tính khung văn bản như lề, neo, tự động vừa, và hướng văn bản dọc.
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/vi/python-net/aspose.slides/itextstyle/get_effective/) giải quyết định dạng đoạn văn cho mỗi mức độ kiểu văn bản.
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iparagraphformat/get_effective/) giải quyết các thuộc tính đoạn văn như căn chỉnh, thụt lề và dấu đầu dòng.
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iportionformat/get_effective/) giải quyết các thuộc tính ký tự như chiều cao phông, kiểu chữ, màu, in đậm và in nghiêng.

Đối với ví dụ tiếp theo, tệp `text-formatting.pptx` phải chứa ít nhất một slide và một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) có khung văn bản không rỗng. AutoShape có thể xuất hiện ở bất kỳ vị trí nào trong bộ sưu tập hình; mã sẽ tìm một đối tượng phù hợp và kiểm tra trước khi sử dụng.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **Lấy Thuộc tính 3D Hiệu quả**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ithreedformat/get_effective/) trả về một đối tượng [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ithreedformateffectivedata/) nhóm tất cả các cài đặt 3D đã được giải quyết. Các thuộc tính [camera](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/) và [bevel_bottom](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) hiển thị dữ liệu hiệu quả tương ứng. Đọc các cài đặt liên quan này cùng nhau giúp dễ hiểu hơn về diện mạo 3D cuối cùng của một hình.

Đối với ví dụ này, tệp `shape-3d.pptx` phải chứa ít nhất một hình trên slide đầu tiên. Áp dụng cài đặt camera 3D, ánh sáng hoặc bevel cho hình đó nếu bạn muốn đầu ra chứa các giá trị khác với mặc định.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **Lấy Định dạng Bảng Hiệu quả**

Định dạng bảng có thể đến từ kiểu bảng và từ các định dạng áp dụng cho toàn bộ bảng, một cột, một hàng, hoặc một ô riêng lẻ. Khi có xung đột giữa các fill được xác định rõ ràng, độ ưu tiên là ô, hàng, cột, rồi đến toàn bảng. Định dạng hiệu quả của một ô là định dạng cuối cùng được dùng để vẽ ô đó.

Đối với ví dụ này, tệp `table-formatting.pptx` phải chứa ít nhất một bảng trên slide đầu tiên. Bảng phải có ít nhất một hàng và một cột. Mã sẽ tìm một [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/) thay vì giả định rằng `shapes[0]` là một bảng.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

Nếu bạn cần màu thay vì chỉ loại fill, trước hết kiểm tra [fill_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ifillformateffectivedata/fill_type/) đã hiệu quả, sau đó đọc thuộc tính áp dụng cho loại đó, ví dụ, [solid_fill_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) cho fill đặc.

## **Đọc lại Dữ liệu Hiệu quả Sau Khi Thay đổi**

Dữ liệu hiệu quả mô tả chuỗi định dạng tại thời điểm nó được giải quyết. Gọi lại `get_effective` sau khi thay đổi bất cứ thứ gì có thể tham gia vào chuỗi đó, bao gồm:

- định dạng cục bộ của đối tượng;
- mặc định đoạn hoặc khung văn bản;
- kiểu bảng, bảng, cột, hàng hoặc định dạng ô;
- định dạng bố cục hoặc slide mẫu;
- dữ liệu chủ đề hoặc mặc định ở mức bài thuyết trình;
- bố cục hoặc mẫu được gán cho một slide.

Không giữ một đối tượng dữ liệu hiệu quả như một bản sao cố định. Aspose.Slides có thể lưu cache một số dữ liệu hiệu quả nội bộ, và một lời gọi `get_effective` sau này có thể làm mới dữ liệu đó. Nếu bạn cần so sánh giá trị trước và sau khi thay đổi, sao chép các giá trị vô hướng cần thiết, chẳng hạn như chiều cao phông, màu, căn chỉnh hoặc độ rộng bevel, vào các biến của riêng bạn trước khi thực hiện thay đổi.

Để thay đổi một giá trị, cập nhật đối tượng định dạng cục bộ thích hợp rồi gọi `get_effective` để xác nhận kết quả. Các đối tượng dữ liệu hiệu quả tự chúng là chỉ đọc.

## **FAQ**

**Làm sao tôi có thể biết mức nào đã cung cấp giá trị hiệu quả?**

Dữ liệu hiệu quả chỉ chứa giá trị cuối cùng, không phải nguồn gốc của nó. Kiểm tra các đối tượng cục bộ áp dụng từ mức cụ thể nhất ra ngoài. Đối với văn bản, điều này có thể bao gồm phần, đoạn, khung văn bản, bố cục, mẫu, chủ đề và mặc định của bài thuyết trình. Các giá trị chưa xác định như `float("nan")` hoặc `None` cho biết việc tìm kiếm tiếp tục ở mức khác.

**Điều gì xảy ra khi không có mức nào định nghĩa thuộc tính?**

Aspose.Slides sẽ giải quyết mặc định phù hợp của PowerPoint hoặc thư viện. Giá trị đã giải quyết sẽ xuất hiện trong dữ liệu hiệu quả ngay cả khi không có đối tượng cục bộ nào xác định rõ ràng nó.

**Tại sao đôi khi giá trị hiệu quả lại bằng giá trị cục bộ?**

Giá trị cục bộ đã thắng trong tính toán kế thừa. Điều này là bình thường khi thuộc tính được đặt rõ ràng trên đối tượng và không có quy tắc cụ thể hơn nào ghi đè lên nó.

**Khi nào tôi nên sử dụng dữ liệu cục bộ thay vì dữ liệu hiệu quả?**

Sử dụng dữ liệu cục bộ để kiểm tra hoặc chỉnh sửa một mức định dạng cụ thể. Sử dụng dữ liệu hiệu quả khi bạn cần kết quả cuối cùng sau khi kế thừa, quy tắc chủ đề và các kiểu áp dụng đã được giải quyết. **Ví dụ so sánh đầy đủ** (#compare-local-inherited-and-effective-values) trình bày cả hai trong cùng một quy trình làm việc.