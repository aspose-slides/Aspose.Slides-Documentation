---
title: Quản lý Bảng trong Bản trình chiếu bằng Python
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
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tạo và chỉnh sửa bảng trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua .NET. Khám phá các ví dụ mã đơn giản để tối ưu quy trình làm việc với bảng."
---
## **Giới thiệu**

Bảng trong PowerPoint là cách hiệu quả để trình bày thông tin. Thông tin được sắp xếp trong lưới các ô (hàng và cột) rất đơn giản và dễ hiểu.

Aspose.Slides cung cấp lớp [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/), lớp [Cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cell/), và các kiểu liên quan khác để giúp bạn tạo, cập nhật và quản lý các bảng trong bất kỳ bản trình chiếu nào.

## **Tạo Bảng Từ Đầu**

Phần này mô tả cách tạo một bảng từ đầu trong Aspose.Slides bằng cách thêm một hình dạng bảng vào slide, xác định các hàng và cột, và đặt kích thước chính xác. Bạn cũng sẽ thấy cách điền nội dung vào các ô bằng văn bản, điều chỉnh căn chỉnh và viền, và tùy chỉnh giao diện của bảng.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy tham chiếu đến một slide theo chỉ mục của nó.
3. Xác định một mảng độ rộng cột.
4. Xác định một mảng độ cao hàng.
5. Thêm một [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/) vào slide.
6. Duyệt qua từng [Cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cell/) và định dạng viền trên, dưới, phải và trái của nó.
7. Hợp nhất hai ô đầu tiên trong hàng đầu tiên của bảng.
8. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của một [Cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cell/) .
9. Thêm văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) .
10. Lưu bản trình chiếu đã sửa đổi.

Ví dụ Python sau đây cho thấy cách tạo một bảng trong bản trình chiếu:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation() as presentation:
    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Xác định độ rộng cột và độ cao hàng.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Thêm hình dạng bảng vào slide.
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
        
    # Hợp nhất các ô từ (hàng 0, cột 0) tới (hàng 1, cột 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Thêm văn bản vào ô đã hợp nhất.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Lưu bản trình chiếu vào đĩa.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Đánh số trong Bảng Tiêu chuẩn**

Trong một bảng tiêu chuẩn, việc đánh số ô là đơn giản và dựa trên chỉ số 0. Ô đầu tiên trong bảng được đánh số là (0, 0) (cột 0, hàng 0).

Ví dụ, trong một bảng có 4 cột và 4 hàng, các ô được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ví dụ Python sau đây cho thấy cách tham chiếu các ô bằng cách đánh số dựa trên 0 này:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **Truy cập Bảng hiện có**

Phần này giải thích cách tìm và làm việc với một bảng hiện có trong bản trình chiếu bằng Aspose.Slides. Bạn sẽ học cách tìm bảng trên một slide, truy cập các hàng, cột và ô của nó, và cập nhật nội dung hoặc định dạng.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy tham chiếu đến slide chứa bảng theo chỉ mục của nó.
3. Duyệt qua tất cả các đối tượng [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) cho đến khi bạn tìm thấy bảng.
4. Sử dụng đối tượng [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/) để làm việc với bảng.
5. Lưu bản trình chiếu đã sửa đổi.

{{% alert color="info" %}}
Nếu slide chứa nhiều bảng, tốt hơn là tìm bảng bạn cần bằng thuộc tính `alternative_text` .
{{% /alert %}}

Ví dụ Python sau đây cho thấy cách truy cập và làm việc với một bảng hiện có:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Khởi tạo lớp Presentation để tải tệp PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    table = None

    # Duyệt qua các shape và lấy bảng đầu tiên tìm được.
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

## **Căn chỉnh Văn bản trong Bảng**

Phần này mô tả cách kiểm soát căn chỉnh văn bản bên trong các ô bảng bằng Aspose.Slides. Bạn sẽ học cách đặt căn ngang và dọc cho các ô để giữ cho nội dung của mình rõ ràng và nhất quán.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy tham chiếu đến slide theo chỉ mục của nó.
3. Thêm một đối tượng [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/) vào slide.
4. Truy cập một đối tượng [Cell](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cell/) từ bảng.
5. Căn chỉnh văn bản theo chiều dọc.
6. Lưu bản trình chiếu đã sửa đổi.

Ví dụ Python sau đây cho thấy cách căn chỉnh văn bản trong bảng:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:
    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Xác định độ rộng cột và độ cao hàng.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Thêm hình dạng bảng vào slide.
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

## **Đặt Định dạng Văn bản ở Cấp độ Bảng**

Phần này cho biết cách áp dụng định dạng văn bản ở cấp độ bảng trong Aspose.Slides để mỗi ô thừa nhận một kiểu đồng nhất, thống nhất. Bạn sẽ học cách đặt kích thước phông chữ, căn chỉnh và lề một cách toàn cục.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) .
2. Lấy tham chiếu đến slide theo chỉ mục của nó.
3. Thêm một [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/) vào slide.
4. Đặt kích thước phông chữ (chiều cao phông) cho văn bản.
5. Đặt căn chỉnh đoạn và lề.
6. Đặt hướng văn bản dọc.
7. Lưu bản trình chiếu đã sửa đổi.

Ví dụ Python sau đây cho thấy cách áp dụng các tùy chọn định dạng ưa thích của bạn cho văn bản trong bảng:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Đặt kích thước phông chữ cho tất cả các ô bảng.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Đặt văn bản căn phải và lề phải cho tất cả các ô bảng.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Đặt hướng văn bản dọc cho tất cả các ô bảng.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Áp dụng Kiểu Bảng Được Tích hợp**

Aspose.Slides cho phép bạn định dạng các bảng bằng các kiểu được định sẵn trực tiếp trong mã. Ví dụ minh họa cách tạo một bảng, áp dụng một kiểu được tích hợp, và lưu kết quả—một cách hiệu quả để đảm bảo định dạng nhất quán, chuyên nghiệp.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Khóa Tỷ lệ Khung hình của Bảng**

Tỷ lệ khung hình của một hình dạng là tỉ lệ các kích thước của nó. Aspose.Slides cung cấp thuộc tính `aspect_ratio_locked`, cho phép bạn khóa tỷ lệ khung hình cho các bảng và các hình dạng khác.

Ví dụ Python sau đây cho thấy cách khóa tỷ lệ khung hình cho một bảng:

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

**Có thể bật chế độ đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô của nó không?**

Có. Bảng có thuộc tính [right_to_left](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/right_to_left/), và các đoạn văn có [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/right_to_left/). Sử dụng cả hai sẽ đảm bảo thứ tự và hiển thị RTL đúng trong các ô.

**Làm sao để ngăn người dùng di chuyển hoặc thay đổi kích thước bảng trong tệp cuối cùng?**

Sử dụng [shape locks](/slides/vi/python-net/applying-protection-to-presentation/) để vô hiệu hoá việc di chuyển, thay đổi kích thước, chọn, v.v. Những khóa này cũng áp dụng cho các bảng.

**Có hỗ trợ chèn hình ảnh vào ô làm nền không?**

Có. Bạn có thể đặt một [picture fill](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/) cho ô; hình ảnh sẽ phủ toàn bộ khu vực ô theo chế độ đã chọn (kéo giãn hoặc lát).