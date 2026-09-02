---
title: Quản lý bảng trình chiếu với Python
linktitle: Quản lý Bảng
type: docs
weight: 10
url: /vi/python-net/manage-table/
keywords:
- thêm bảng
- tạo bảng
- truy cập bảng
- tỷ lệ khung hình
- căn chỉnh văn bản
- định dạng văn bản
- kiểu bảng
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tạo và chỉnh sửa các bảng trong PowerPoint và slide OpenDocument bằng Aspose.Slides cho Python qua .NET. Khám phá các ví dụ mã đơn giản để tối ưu hoá quy trình làm việc với bảng."
---
## **Giới thiệu**

Bảng trong PowerPoint là một cách hiệu quả để trình bày thông tin. Thông tin được sắp xếp trong lưới các ô (hàng và cột) rất trực quan và dễ hiểu.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/) , lớp [Cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cell/) và các kiểu liên quan khác để giúp bạn tạo, cập nhật và quản lý các bảng trong bất kỳ bài thuyết trình nào.

## **Tạo Bảng Từ Đầu**

Phần này cho thấy cách tạo một bảng từ đầu trong Aspose.Slides bằng cách thêm một hình dạng bảng vào slide, định nghĩa các hàng và cột, và đặt kích thước chính xác. Bạn cũng sẽ thấy cách điền nội dung vào các ô, điều chỉnh căn chỉnh và viền, và tùy chỉnh giao diện của bảng.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy tham chiếu đến một slide bằng chỉ mục của nó.
3. Xác định một mảng chiều rộng các cột.
4. Xác định một mảng chiều cao các hàng.
5. Thêm một [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/) vào slide.
6. Duyệt qua từng [Cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cell/) và định dạng các đường viền trên, dưới, phải và trái của nó.
7. Hợp nhất các ô của hai hàng đầu tiên và hai cột đầu tiên thành một ô duy nhất.
8. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của một [Cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cell/) .
9. Thêm văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) .
10. Lưu bản trình chiếu đã sửa đổi.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation đại diện cho tệp trình chiếu.
with slides.Presentation() as presentation:
    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Định nghĩa độ rộng cột và chiều cao hàng.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Thêm một hình dạng bảng vào slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Đặt định dạng viền cho mỗi ô.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Hợp nhất các ô từ (hàng 0, cột 0) đến (hàng 1, cột 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Thêm văn bản vào ô đã hợp nhất.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Lưu trình chiếu vào đĩa.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Đánh số trong Bảng Tiêu chuẩn**

Trong một bảng tiêu chuẩn, việc đánh số ô rất đơn giản và bắt đầu từ 0. Ô đầu tiên trong bảng có chỉ số là (0, 0) (cột 0, hàng 0).

Ví dụ, trong một bảng có 4 cột và 4 hàng, các ô được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ví dụ Python sau cho thấy cách tham chiếu các ô bằng cách đánh số bắt đầu từ 0 này:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một bảng với 4 cột và 4 hàng.
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập Bảng Đã tồn tại**

Phần này giải thích cách xác định và làm việc với một bảng đã tồn tại trong bài thuyết trình bằng Aspose.Slides. Bạn sẽ học cách tìm bảng trên một slide, truy cập các hàng, cột và ô của nó, và cập nhật nội dung hoặc định dạng.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy tham chiếu đến slide chứa bảng bằng chỉ mục của nó.
3. Duyệt qua tất cả các đối tượng [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) cho đến khi tìm thấy bảng.
4. Sử dụng đối tượng [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/) để làm việc với bảng.
5. Lưu bản trình chiếu đã sửa đổi.

{{% alert color="info" title="Note" %}}
Nếu slide chứa nhiều bảng, tốt hơn là tìm kiếm bảng bạn cần bằng thuộc tính `alternative_text` của nó.
{{% /alert %}}

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Khởi tạo lớp Presentation để tải tệp PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    table = None

    # Duyệt qua các shape và tham chiếu bảng đầu tiên được tìm thấy.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Đặt văn bản cho ô đầu tiên trong hàng đầu tiên.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Lưu bản trình chiếu đã sửa đổi vào đĩa.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Tìm Ô Sở Hữu Khung Văn Bản**

Khi mã xử lý văn bản chung nhận được một [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) từ một bảng, sử dụng thuộc tính [TextFrame.parent_cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/parent_cell/) để lấy ô sở hữu [Cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cell/) . Đối với khung văn bản trong ô bảng, [TextFrame.parent_cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/parent_cell/) được đặt và [TextFrame.parent_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/parent_shape/) là `None`, ngay cả khi bảng tự nó là một shape.

Các tọa độ ô có sẵn qua các thuộc tính chỉ đọc [Cell.first_column_index](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cell/first_column_index/) và [Cell.first_row_index](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cell/first_row_index/) . [TextFrame.parent_cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/parent_cell/) cũng chỉ đọc: nó cung cấp đường dẫn đến chủ sở hữu nhưng không thay đổi quyền sở hữu. Luôn kiểm tra giá trị trả về có phải `None` trước khi sử dụng.

Đối với một ví dụ hoàn chỉnh xác định chủ sở hữu ô bảng và shape, bao gồm các shape liên kết với nút SmartArt, xem [Search and Replace Text](/slides/vi/python-net/search-and-replace-text/) .

## **Căn Văn Bản trong Bảng**

Phần này cho thấy cách kiểm soát vị trí văn bản bên trong các ô bảng bằng Aspose.Slides. Bạn sẽ học cách neo văn bản theo chiều dọc trong một ô và thay đổi hướng viết của văn bản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy tham chiếu đến slide bằng chỉ mục của nó.
3. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/) vào slide.
4. Truy cập một đối tượng [Cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cell/) từ bảng.
5. Căn giữa văn bản theo chiều dọc trong ô và đặt hướng văn bản.
6. Lưu bản trình chiếu đã sửa đổi.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:
    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Định nghĩa độ rộng cột và chiều cao hàng.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Thêm một hình dạng bảng vào slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Căn giữa văn bản và đặt hướng dọc.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Lưu bản trình chiếu vào đĩa.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Định Dạng Văn Bản ở Cấp Độ Bảng**

Phần này cho thấy cách áp dụng định dạng văn bản ở cấp độ bảng trong Aspose.Slides để mỗi ô kế thừa một phong cách thống nhất. Bạn sẽ học cách đặt kích thước phông chữ, căn chỉnh và lề một cách toàn cục.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy tham chiếu đến slide bằng chỉ mục của nó.
3. Thêm một [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/) vào slide.
4. Đặt kích thước phông chữ (font height) cho văn bản.
5. Đặt căn chỉnh đoạn và lề.
6. Đặt hướng dọc của văn bản.
7. Lưu bản trình chiếu đã sửa đổi.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Đặt kích thước phông chữ cho tất cả các ô trong bảng.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Đặt văn bản căn phải và lề phải cho tất cả các ô trong bảng.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Đặt hướng dọc của văn bản cho tất cả các ô trong bảng.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Áp Dụng Kiểu Bảng Có Sẵn**

Aspose.Slides cho phép bạn định dạng các bảng bằng các kiểu dựng sẵn trực tiếp trong mã. Ví dụ minh họa cách tạo bảng, áp dụng một kiểu dựng sẵn và lưu kết quả—một cách hiệu quả để đảm bảo định dạng nhất quán, chuyên nghiệp.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Khóa Tỷ Lệ Khung Hình của Bảng**

Tỷ lệ khung hình của một shape là tỷ lệ giữa các kích thước của nó. Aspose.Slides cung cấp thuộc tính `aspect_ratio_locked`, cho phép bạn khóa tỷ lệ khung hình cho các bảng và các shape khác.

Ví dụ Python sau cho thấy cách khóa tỷ lệ khung hình cho một bảng:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Tôi có thể bật hướng đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô của nó không?**

Có. Bảng cung cấp thuộc tính [right_to_left](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/right_to_left/) , và các đoạn có [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/right_to_left/) . Sử dụng cả hai đảm bảo thứ tự RTL đúng và hiển thị chính xác bên trong các ô.

**Làm thế nào để ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong tệp cuối cùng?**

Sử dụng [shape locks](/slides/vi/python-net/applying-protection-to-presentation/) để tắt việc di chuyển, thay đổi kích thước, chọn, v.v. Các khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn hình ảnh vào ô làm nền không?**

Có. Bạn có thể đặt [picture fill](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/) cho một ô; hình ảnh sẽ bao phủ khu vực ô theo chế độ đã chọn (kéo dài hoặc lát).