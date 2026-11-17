---
title: Quản lý các ô bảng trong bản trình bày bằng Python
linktitle: Quản lý ô
type: docs
weight: 30
url: /vi/python-net/manage-cells/
keywords:
- ô bảng
- hợp nhất ô
- xóa viền
- tách ô
- hình ảnh trong ô
- màu nền
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Quản lý các ô bảng PowerPoint trong Python: xác định các ô đã hợp nhất, xóa viền, tách ô, và đặt màu nền cùng hình ảnh bằng Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và chỉnh sửa các ô bảng trong bản trình bày PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa viền ô, làm việc với việc đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô và thêm hình ảnh vào trong ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bản trình bày, lấy bảng từ một slide, cập nhật định dạng ô qua các thuộc tính ô, và lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Aspose.Slides sử dụng chỉ số bắt đầu từ 0. Các tọa độ trong bài viết này được viết dưới dạng `(cột, hàng)`.

## **Xác định ô bảng đã hợp nhất**

Ví dụ mở một bản trình bày hiện có và truy cập hình dạng đầu tiên trên slide đầu tiên dưới dạng bảng. Giả sử slide và hình dạng tồn tại và hình dạng là một bảng. Sau đó duyệt qua tất cả các hàng và cột và sử dụng [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) để xác định các ô trong vùng hợp nhất. Đối với mỗi kết quả phù hợp, nó in tọa độ ô theo thứ tự `hàng;cột`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), và tọa độ bắt đầu của vùng, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) và [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

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

## **Xóa viền ô bảng**

Tạo một [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) và thêm một bảng vào slide đầu tiên bằng [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Độ rộng cột, chiều cao hàng và vị trí bảng được xác định bằng điểm. Ví dụ đặt bốn viền ô thành [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), khiến chúng không hiển thị.

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

## **Thêm viền chéo cho ô**

Sử dụng [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) để vẽ một đường từ góc trên‑trái đến góc dưới‑phải, và [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) để vẽ một đường từ góc dưới‑trái đến góc trên‑phải. Đường chéo có thể đánh dấu tiêu đề góc; cả hai đường chéo có thể tạo thành chữ X để đánh dấu ô là không áp dụng.

Mỗi đường chéo là một [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). Trong [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) của nó, đặt [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) thành [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) và chọn một [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/). Đặt [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) của đường bằng điểm.

Ví dụ tạo ba ô trong một hàng: một đường chéo màu đỏ đi xuống, một đường chéo màu xanh lên, và cả hai đường chéo. Nó để nguyên viền trên, dưới, trái và phải của ô.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

Một đường chéo là thuộc tính định dạng, không phải là tách ô. Mỗi ô giữ một [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/); các vùng ở hai phía của đường chéo không thể chỉnh sửa độc lập.

Bảng đã lưu, được hiển thị trong Microsoft PowerPoint:

![Ba ô bảng hiển thị đường chéo đỏ từ góc trên‑trái đến góc dưới‑phải, đường chéo xanh từ góc dưới‑trái đến góc trên‑phải, và cả hai đường chéo tạo thành chữ X.](diagonal-cell-borders.png)

*Trái sang phải: đường chéo đi xuống (đỏ, 3 pt), đường chéo đi lên (xanh, 5 pt), và cả hai đường chéo.*

## **Hợp nhất các ô bảng**

Sử dụng [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) để kết hợp một vùng hình chữ nhật của các ô thành một ô duy nhất. Xác định các ô ở góc trên‑trái và góc dưới‑phải của vùng. Tham số cuối cùng điều khiển việc hợp nhất có cho phép bao gồm các ô ngoài vùng đã chỉ định hay không; `False` giữ cho việc hợp nhất chỉ diễn ra trong vùng đó.

Ví dụ tạo một bảng 4×4 với các cột và hàng có độ rộng 70 điểm, sau đó hợp nhất bốn ô trung tâm từ `(1, 1)` đến `(2, 2)`. Ô kết quả kéo dài qua hai cột và hai hàng, trong khi lưới cơ bản của bảng vẫn giữ bốn cột và bốn hàng. Để truy cập nội dung hoặc định dạng của ô đã hợp nhất, sử dụng vị trí góc trên‑trái: `table.rows[1][1]` trong ví dụ này. Các vị trí khác trong vùng hợp nhất vẫn là một phần của lưới bảng, vì vậy các chỉ mục của các ô nằm ngoài vùng không thay đổi.

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

## **Tách các ô bảng**

Việc hợp nhất các ô trong ví dụ trước giữ nguyên lưới của bảng. Tách một ô có thể tạo thêm một cột lưới mới và thay đổi chỉ mục cột của các ô bên phải nó. Aspose.Slides tuân theo mô hình lưới bảng của PowerPoint.

Ví dụ này tạo một bảng 4×4 với các cột và hàng có độ rộng 70 điểm và gọi [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) trên ô `(1, 1)`. Một nửa độ rộng 70 điểm của ô được truyền vào để tạo hai ô có chiều rộng bằng nhau.

Sau khi tách, hai nửa được truy cập dưới dạng `table.rows[1][1]` và `table.rows[1][2]`. Lưới bảng hiện có năm cột: các ô ban đầu ở cột 2 và 3 dịch sang cột 3 và 4 tương ứng. Các chỉ mục hàng không thay đổi. Hãy dùng các chỉ mục cột đã cập nhật khi truy cập các ô sau khi tách.

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

<!-- visual-explanation:manage-cells:start -->
[![Một ô chưa hợp nhất có độ rộng 70 điểm tách thành hai ô 35 điểm, thêm cột lưới thứ năm và đẩy các chỉ mục sang phải.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Việc tách chiều rộng ảnh hưởng đến ô (1, 1), sử dụng chỉ số (cột, hàng) bắt đầu từ 0. Các hàng khác giữ ô kéo dài qua cả hai vị trí cột mới.*
<!-- visual-explanation:manage-cells:end -->

### **Tách các ô đã hợp nhất theo chiều hàng hoặc cột**

Để chuẩn bị các ô mẫu đã hợp nhất cho việc điền dữ liệu, sử dụng [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) để tách dọc theo một ranh giới hàng hiện có, hoặc [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) để tách dọc theo một ranh giới cột.

Tham số `index` đếm số hàng ở phần trên hoặc số cột ở phần trái của phần tách; nó được tính tương đối so với vùng đã hợp nhất:

- Tách hàng: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Tách cột: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Ví dụ yêu cầu bản trình bày có một bảng là hình dạng đầu tiên trên slide đầu tiên, với các ô `(1, 2)` và `(1, 3)` hợp nhất theo chiều dọc. Bắt đầu từ vị trí thấp hơn, nó dùng [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) và [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) để xác định nguồn gốc và kiểm tra cả hai phạm vi. `split_by_row_span` với chỉ số 1 sau đó tách các hàng 2 và 3 để đặt tên sản phẩm. Đối với một vùng hợp nhất ngang hai cột, sử dụng `split_by_col_span` với chỉ số 1 thay thế.

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

Lưới bảng và các chỉ mục ô xung quanh không thay đổi. Lấy các ô kết quả bằng tọa độ của chúng; ở đây cả hai ô đều có phạm vi là 1 và [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) in ra `False`. Các vùng lớn hơn vẫn có thể còn một phần hợp nhất sau một lần tách.

Văn bản gốc và định dạng của nó vẫn nằm trong ô trên (hoặc trái); ô mới trống nhưng kế thừa định dạng ô như màu nền, viền và lề. Điền dữ liệu vào các ô sau khi tách và đặt bất kỳ định dạng văn bản nào cần thiết một cách rõ ràng.

Bản trình bày đã lưu chứa các ô “Product A” và “Product B” riêng biệt, vẫn giữ định dạng ô của mẫu. Xem [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) để biết chi tiết.

### **Tách một ô ở độ cao cụ thể**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) nhận chiều cao của phần trên bằng điểm. [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) nhận số hàng lưới hiện có ở phần trên. Để căn giữa một ô 40 điểm theo chiều dọc trong cột bên phải, giảm 40 từ chiều cao thực tế của ô và chia phần không gian còn lại đều cho phần trên và phần dưới.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

Lần tách đầu tiên thêm một hàng lưới, để lại 90 điểm ở `table.rows[1][1]`. Lần tách thứ hai chia ô đó thành một ô giữa 40 điểm và một ô dưới 50 điểm. Ba ô trong cột bên phải giờ có độ cao 50, 40 và 50 điểm từ trên xuống dưới. Ô trái kéo dài qua cả ba hàng với chiều cao gốc 140 điểm.

![Ô trái kéo dài toàn bộ chiều cao bảng bên cạnh ba ô có phần “Middle” ở giữa.](split-by-height.png)

## **Thay đổi màu nền của ô bảng**

Ví dụ này tạo một bảng với các cột 150 điểm và các hàng 50 điểm. Nó đặt [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) thành màu đặc và [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) thành màu đỏ cho ô `(2, 3)`, nằm ở cột thứ ba và hàng thứ tư.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm hình ảnh vào trong ô bảng**

Đặt hình ảnh đầu vào trong thư mục làm việc trước khi chạy ví dụ này. Nó tải hình ảnh bằng [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) và thêm vào bộ sưu tập hình ảnh của bản trình bày bằng [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Sau đó gán hình ảnh cho nền ảnh của ô `(0, 0)`, ô đầu tiên trong bảng.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) kéo dài hình ảnh để lấp đầy ô, có thể làm thay đổi tỷ lệ khung hình. Độ rộng cột và chiều cao hàng tính bằng điểm. Hình ảnh đã tải sẽ được giải phóng tự động khi khối `with` kết thúc.

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

## **Câu hỏi thường gặp**

**Tôi có thể đặt độ dày và kiểu đường khác nhau cho các mặt của một ô duy nhất không?**

Có. Các viền [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) có các thuộc tính riêng, vì vậy độ dày và kiểu của từng mặt có thể khác nhau.

**Nếu tôi thay đổi kích thước cột/hàng sau khi đã đặt hình ảnh làm nền ô, hình ảnh sẽ xảy ra gì?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Khi kéo dài, hình ảnh sẽ điều chỉnh theo ô mới; khi lát, các mẫu sẽ được tính lại.

**Tôi có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/python-net/manage-hyperlinks/) được đặt ở mức đoạn văn bản (portion) bên trong khung văn bản của ô hoặc ở mức toàn bộ bảng/hình dạng. Trong thực tế, bạn gán liên kết cho một đoạn hoặc cho toàn bộ văn bản trong ô.

**Tôi có thể đặt các phông chữ khác nhau trong một ô duy nhất không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (các đoạn) với định dạng độc lập — họa tiết phông, kiểu, kích thước và màu.