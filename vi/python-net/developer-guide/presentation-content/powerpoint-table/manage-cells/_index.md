---
title: Quản lý các ô bảng trong bài thuyết trình với Python
linktitle: Quản lý ô
type: docs
weight: 30
url: /vi/python-net/manage-cells/
keywords:
- ô bảng
- hợp nhất ô
- xóa đường viền
- tách ô
- hình ảnh trong ô
- màu nền
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý các ô bảng PowerPoint trong Python: xác định các ô đã hợp nhất, xóa đường viền, tách ô, và đặt màu nền cũng như hình ảnh với Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và sửa đổi các ô bảng trong bản trình chiếu PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa đường viền ô, làm việc với số thứ tự ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô, và chèn hình ảnh vào trong ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bản trình chiếu, lấy bảng từ một slide, cập nhật định dạng ô thông qua các thuộc tính ô, và lưu bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Aspose.Slides sử dụng chỉ số bắt đầu từ 0. Các tọa độ trong bài viết này được viết dưới dạng `(cột, hàng)`.

## **Xác định Ô Bảng Được Hợp Nhất**

Ví dụ mở một bản trình chiếu hiện có và truy cập hình dạng đầu tiên trên slide đầu tiên như một bảng. Nó giả định rằng slide và hình dạng tồn tại và hình dạng là một bảng. Sau đó nó lặp qua tất cả các hàng và cột và sử dụng [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) để xác định các ô trong vùng hợp nhất. Đối với mỗi khớp, nó in tọa độ ô theo thứ tự `row;column`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), và tọa độ bắt đầu của vùng, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) và [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **Xóa Đường Viền Ô Bảng**

Tạo một [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) và thêm một bảng vào slide đầu tiên của nó bằng [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Độ rộng cột, chiều cao hàng, và vị trí bảng được chỉ định bằng điểm. Ví dụ đặt bốn đường viền ô thành [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), khiến chúng không hiển thị.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Hợp Nhất Các Ô Bảng**

Sử dụng [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) để kết hợp một phạm vi hình chữ nhật các ô bảng thành một ô. Xác định các ô ở góc trên‑trái và góc dưới‑phải của phạm vi. Tham số cuối cùng kiểm soát việc hợp nhất có cho phép bao gồm các ô ngoài phạm vi đã chỉ định hay không; `False` giữ hợp nhất trong phạm vi đó.

Ví dụ tạo một bảng 4‑by‑4 với các cột và hàng có độ rộng 70 điểm, sau đó hợp nhất bốn ô trung tâm từ `(1, 1)` đến `(2, 2)`. Ô kết quả phủ rộng hai cột và hai hàng, trong khi lưới nền của bảng vẫn giữ bốn cột và bốn hàng. Để truy cập nội dung hoặc định dạng của ô đã hợp nhất, sử dụng vị trí trên‑trái của nó: `table.rows[1][1]` trong ví dụ này. Các vị trí còn lại trong phạm vi hợp nhất vẫn là một phần của lưới bảng, vì vậy các chỉ số của các ô ngoài phạm vi không thay đổi.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **Tách Các Ô Bảng**

Việc hợp nhất các ô trong ví dụ trước giữ nguyên lưới bảng. Tách một ô có thể tạo thêm một cột lưới mới và thay đổi chỉ số cột của các ô bên phải nó. Aspose.Slides tuân theo mô hình lưới bảng của PowerPoint.

Ví dụ này tạo một bảng 4‑by‑4 với các cột và hàng có độ rộng 70 điểm và gọi [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) trên ô `(1, 1)`. Một nửa độ rộng 70 điểm của ô được truyền vào để tạo hai ô có độ rộng bằng nhau.

Sau khi tách, hai nửa được truy cập là `table.rows[1][1]` và `table.rows[1][2]`. Lưới bảng hiện có năm cột: các ô ban đầu ở cột 2 và 3 dịch sang cột 3 và 4, tương ứng. Chỉ số hàng không thay đổi. Hãy sử dụng các chỉ số cột đã cập nhật khi truy cập các ô sau khi tách.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **Tách Các Ô Đã Hợp Nhất Theo Độ Dài Hàng Hoặc Cột**

Để chuẩn bị các ô mẫu đã hợp nhất cho việc điền dữ liệu, sử dụng [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) để tách dọc theo ranh giới hàng hiện có, hoặc [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) để tách dọc theo ranh giới cột.

Tham số `index` đếm các hàng ở phần trên hoặc các cột ở phần trái của phép tách; nó tương đối với vùng đã hợp nhất:

- Tách hàng: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Tách cột: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Ví dụ giả định bản trình chiếu có một bảng là hình dạng đầu tiên trên slide đầu tiên, với `(1, 2)` và `(1, 3)` được hợp nhất theo chiều dọc. Bắt đầu từ vị trí dưới, nó sử dụng [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) và [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) để xác định nguồn gốc và kiểm tra cả hai độ phủ. `split_by_row_span` với chỉ số 1 sau đó tách các hàng 2 và 3 cho tên sản phẩm. Đối với một hợp nhất ngang hai cột, thay vào đó sử dụng `split_by_col_span` với chỉ số 1.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # Lấy các ô kết quả từ bảng sau khi tách.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

Lưới bảng và các chỉ số ô xung quanh vẫn không thay đổi. Lấy các ô kết quả bằng tọa độ của chúng; ở đây, cả hai đều có độ phủ là 1 và [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) trả về `False`. Các vùng lớn hơn có thể vẫn còn một phần được hợp nhất sau một lần tách.

Nội dung và định dạng gốc vẫn ở ô trên (hoặc trái); ô mới trống nhưng kế thừa định dạng ô như màu nền, đường viền và lề. Hãy điền dữ liệu vào các ô sau khi tách và đặt bất kỳ định dạng văn bản nào cần thiết một cách rõ ràng.

Bản trình chiếu đã lưu chứa các ô \"Product A\" và \"Product B\" riêng biệt với định dạng ô của mẫu được giữ nguyên. Xem [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) để biết chi tiết.

## **Thay Đổi Màu Nền Ô Bảng**

Ví dụ này tạo một bảng với các cột 150 điểm và các hàng 50 điểm. Nó đặt [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) thành solid và [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) thành màu đỏ cho ô `(2, 3)`, trong cột thứ ba và hàng thứ tư.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Hình Ảnh Vào Trong Ô Bảng**

Đặt ảnh đầu vào trong thư mục làm việc trước khi chạy ví dụ này. Nó tải ảnh bằng [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) và thêm nó vào bộ sưu tập ảnh của bản trình chiếu bằng [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Sau đó nó gán ảnh cho picture fill của ô `(0, 0)`, ô đầu tiên trong bảng.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) kéo dài ảnh để lấp đầy ô, có thể làm thay đổi tỷ lệ khung hình của nó. Độ rộng cột và chiều cao hàng tính bằng điểm. Ảnh đã tải sẽ được giải phóng tự động khi khối `with` kết thúc.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Có thể thiết lập độ dày và kiểu đường viền khác nhau cho từng mặt của một ô duy nhất không?**

Có. Các đường viền [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi mặt có thể khác nhau.

**Ảnh sẽ xảy ra gì nếu tôi thay đổi kích thước cột/hàng sau khi đặt hình ảnh làm nền cho ô?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Khi kéo dài, ảnh sẽ điều chỉnh theo ô mới; khi lát gạch, các mảnh ảnh sẽ được tính lại.

**Có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/python-net/manage-hyperlinks/) được đặt ở mức văn bản (phần) bên trong khung văn bản của ô hoặc ở mức toàn bộ bảng/hình dạng. Thực tế, bạn gán liên kết cho một phần hoặc cho toàn bộ văn bản trong ô.

**Có thể thiết lập các phông chữ khác nhau trong một ô duy nhất không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (các đoạn) với định dạng độc lập — họa tiết phông, kiểu, kích thước và màu sắc.