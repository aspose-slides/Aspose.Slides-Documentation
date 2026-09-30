---
title: Quản lý bảng trình chiếu bằng Python
linktitle: Quản lý bảng
type: docs
weight: 10
url: /vi/python-net/manage-table/
keywords:
- thêm bảng
- tạo bảng
- truy cập bảng
- tỷ lệ khía cạnh
- căn chỉnh văn bản
- định dạng văn bản
- kiểu bảng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tạo & chỉnh sửa bảng trong các slide PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua .NET. Khám phá các ví dụ mã đơn giản để tối ưu hóa quy trình làm việc với bảng."
---
## **Giới thiệu**

Bảng trong PowerPoint sắp xếp thông tin thành các hàng và cột, giúp việc đọc và so sánh giá trị dễ dàng hơn.

Aspose.Slides cung cấp các lớp [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) và [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) cùng các kiểu khác để cho phép bạn tạo, cập nhật và quản lý bảng trong bài thuyết trình.

## **Tạo bảng từ đầu**

Tạo một bảng bằng cách chỉ định vị trí, độ rộng cột và chiều cao hàng. Sau khi thêm nó vào một slide, bạn có thể định dạng viền ô, gộp ô và chèn văn bản.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Xác định một danh sách độ rộng cột tính bằng điểm.
4. Xác định một danh sách chiều cao hàng tính bằng điểm.
5. Thêm một đối tượng [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) vào slide thông qua phương thức [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
6. Lặp qua mỗi [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) để áp dụng định dạng cho các viền trên, dưới, phải và trái.
7. Gộp hai ô đầu tiên của hàng đầu tiên của bảng.
8. Truy cập ô đã gộp thông qua thuộc tính [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/).
9. Đặt văn bản trong ô đã gộp.
10. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ dưới đây tạo một bảng có ba cột và năm hàng tại vị trí (100, 50) điểm. Nó áp dụng viền màu đỏ với độ rộng 5 điểm, gộp hai ô đầu tiên ở hàng đầu tiên và lưu kết quả dưới tên `table.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Đánh số trong Bảng tiêu chuẩn**

Trong một bảng tiêu chuẩn, chỉ mục ô bắt đầu từ 0 và sử dụng thứ tự (cột, hàng). Ô đầu tiên có chỉ mục (0, 0). Trong Python, truy cập một ô bằng `table.rows[row_index][column_index]`; chỉ mục hàng xuất hiện trước trong biểu thức này.

Ví dụ, các ô trong một bảng có 4 cột và 4 hàng được đánh số như sau:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ví dụ này tạo bảng 4 × 4 như hình trên, với độ rộng cột và chiều cao hàng là 70 điểm và viền ô màu đỏ độ rộng 5 điểm. Các tọa độ minh họa chỉ mục ô; ví dụ để các ô trống và lưu bảng dưới tên `StandardTables_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập Bảng hiện có**

Bảng được lưu trong bộ sưu tập shape của slide. Lặp qua các shape để xác định một bảng, sau đó sử dụng lớp [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) để đọc hoặc cập nhật các ô của nó.

1. Tải bản trình chiếu bằng cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Lấy một tham chiếu tới slide chứa bảng theo chỉ mục của nó.
3. Lặp qua các đối tượng [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) và dừng lại khi tìm thấy một bảng. Nếu slide chứa nhiều bảng, sử dụng [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) để xác định bảng bạn cần.
4. Cập nhật văn bản trong ô mục tiêu.
5. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ dưới đây mở `UpdateExistingTable.pptx` và tìm bảng đầu tiên trên slide đầu tiên. Nó đặt ô ở cột 0, hàng 1 thành `New` và lưu kết quả dưới tên `table1_out.pptx`. Tệp đầu vào phải chứa ít nhất một slide, và bảng đầu tiên trên slide đó phải có ít nhất một cột và hai hàng.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

Để thay đổi độ cao của một hàng trong bảng hiện có và hiểu vì sao chiều cao thực tế có thể vượt quá mức tối thiểu yêu cầu, xem [Control Row Height](/slides/vi/python-net/manage-rows-and-columns/#control-row-height).

## **Tìm ô sở hữu khung văn bản**

Khi mã xử lý văn bản chung nhận được một [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) từ bảng, hãy sử dụng thuộc tính [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) để lấy [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) sở hữu. Đối với khung văn bản của ô bảng, [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) được đặt và [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) là `None`, mặc dù bảng tự nó là một shape.

Các chỉ số ô có thể truy cập thông qua các thuộc tính chỉ đọc [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) và [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/). Thuộc tính [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) cũng chỉ đọc: nó cung cấp đường dẫn tới chủ sở hữu nhưng không thay đổi quyền sở hữu. Luôn kiểm tra giá trị trả về có phải `None` trước khi sử dụng.

Đối với một ví dụ đầy đủ xác định chủ sở hữu ô bảng và shape, bao gồm các shape liên kết với node SmartArt, xem [Search and Replace Text](/slides/vi/python-net/search-and-replace-text/).

## **Canh chỉnh Văn bản trong Bảng**

Bạn có thể kiểm soát việc neo dọc và hướng văn bản của từng ô bảng. Ví dụ trong phần này căn giữa văn bản trong ô đầu tiên và xoay nó 270 độ.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Thêm một đối tượng [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) vào slide.
4. Truy cập một đối tượng [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) từ bảng.
5. Truy cập [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) đầu tiên và đặt văn bản cũng như màu sắc cho nó.
6. Đặt [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) và [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) của ô.
7. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ này tạo một bảng 4 × 4 với độ rộng cột 120 điểm và chiều cao hàng 100 điểm. Nó định dạng văn bản trong ô (0, 0), thêm giá trị vào các ô còn lại của hàng đầu tiên và lưu kết quả dưới tên `Vertical_Align_Text_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Định dạng Văn bản ở mức Độ Bảng**

Sử dụng [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) để áp dụng định dạng văn bản cho tất cả các ô trong một bảng. Các overload của nó chấp nhận định dạng phần, đoạn và khung văn bản, vì vậy bạn có thể đặt các thuộc tính này mà không cần lặp qua từng ô riêng lẻ.

1. Tải bản trình chiếu bằng cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Lấy một tham chiếu tới slide theo chỉ mục của nó.
3. Truy cập một đối tượng [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) từ slide.
4. Đặt [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) cho văn bản.
5. Đặt [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) và [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/).
6. Đặt [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/).
7. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ dưới đây mở `table.pptx`, tệp này phải chứa ít nhất một slide với một bảng làm shape đầu tiên. Nó đặt kích thước phông chữ thành 25 điểm, căn phải các đoạn với lề phải 20 điểm và biến văn bản thành dọc. Bản trình chiếu đã định dạng được lưu dưới tên `result.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Lấy Thuộc tính Kiểu Bảng**

Sử dụng [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) để đọc hoặc gán kiểu preset cho bảng. Ví dụ này áp dụng [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) cho một bảng, in ra tên preset và gán cùng preset đó cho bảng thứ hai. Cả hai bảng đều được lưu trong `table-style.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **Khóa Tỷ lệ Khía cạnh của Bảng**

Tỷ lệ khía cạnh của một bảng là tỉ lệ giữa chiều rộng và chiều cao của nó. Sử dụng [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) để khóa tỉ lệ này cho một bảng.

Ví dụ dưới đây mở `pres.pptx`, tệp này phải chứa ít nhất một slide với một bảng làm shape đầu tiên. Nó in trạng thái khóa hiện tại, bật khóa tỷ lệ khía cạnh, in lại trạng thái mới (`True`) và lưu kết quả dưới tên `pres-out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Tôi có thể bật hướng đọc từ phải sang trái (RTL) cho toàn bộ bảng và văn bản trong các ô không?**

Có. Bảng cung cấp thuộc tính [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/), và các đoạn có thuộc tính [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Sử dụng cả hai sẽ保证 đúng thứ tự và cách hiển thị RTL trong các ô.

**Làm sao ngăn người dùng di chuyển hoặc thay đổi kích thước một bảng trong tệp cuối cùng?**

Sử dụng [shape locks](/slides/vi/python-net/applying-protection-to-presentation/) để vô hiệu hoá việc di chuyển, thay đổi kích thước, chọn lựa, v.v. Các khóa này cũng áp dụng cho bảng.

**Có hỗ trợ chèn hình ảnh vào ô làm nền không?**

Có. Bạn có thể đặt một [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) cho ô; hình ảnh sẽ bao phủ khu vực ô theo chế độ đã chọn (kéo dài hoặc lát).