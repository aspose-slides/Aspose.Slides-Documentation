---
title: "Quản lý các ô bảng trong bản trình chiếu với Python"
linktitle: "Quản lý Ô"
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
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Quản lý các ô bảng trong PowerPoint và OpenDocument một cách dễ dàng với Aspose.Slides cho Python qua .NET. Nắm vững việc truy cập, chỉnh sửa và tạo kiểu cho các ô nhanh chóng để tự động hoá slide liền mạch."
---
## **Tổng quan**

Aspose.Slides cho phép bạn truy cập và chỉnh sửa các ô bảng trong bản trình chiếu PowerPoint. Bài viết này giải thích cách xác định các ô bảng đã hợp nhất, xóa viền ô, làm việc với việc đánh số ô sau khi hợp nhất hoặc tách ô, thay đổi màu nền của ô và chèn hình ảnh vào trong ô bảng. Các ví dụ cho thấy cách tạo hoặc mở một bản trình chiếu, lấy một bảng từ một slide, cập nhật định dạng ô qua các thuộc tính ô, và lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

## **Xác định các ô bảng đã hợp nhất**

Các bảng thường chứa các ô được hợp nhất cho tiêu đề hoặc để nhóm các dữ liệu có liên quan. Trong phần này, bạn sẽ thấy cách xác định xem một ô cụ thể có thuộc vùng hợp nhất hay không và cách tham chiếu ô chủ (trên‑trái) để bạn có thể đọc hoặc định dạng toàn bộ khối một cách nhất quán.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy bảng từ slide đầu tiên.
1. Duyệt qua các hàng và cột của bảng để tìm các ô đã hợp nhất.
1. In ra thông báo khi phát hiện ô hợp nhất.

Đoạn mã Python sau xác định các ô bảng đã hợp nhất trong một bản trình chiếu:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Giả sử hình dạng đầu tiên trên slide đầu tiên là một bảng.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **Xóa viền ô bảng**

Đôi khi viền bảng gây mất tập trung khỏi nội dung hoặc tạo ra sự lộn xộn thị giác. Phần này hướng dẫn cách xóa viền khỏi các ô đã chọn—hoặc các phía cụ thể của một ô—để bạn có thể đạt được bố cục sạch sẽ hơn và phù hợp hơn với thiết kế slide của mình.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy slide theo chỉ số của nó.
1. Định nghĩa một mảng chiều rộng các cột.
1. Định nghĩa một mảng chiều cao các hàng.
1. Thêm một bảng vào slide bằng phương pháp [add_table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_table/).
1. Duyệt qua từng ô để xóa các viền trên, dưới, trái và phải.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Python sau cho thấy cách xóa viền khỏi các ô bảng:

```python
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
with slides.Presentation() as presentation:
    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Xác định các cột với độ rộng và các hàng với độ cao.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Thêm hình dạng bảng vào slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Xóa màu nền viền cho mỗi ô.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Lưu tệp PPTX vào đĩa.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Đánh số trong ô đã hợp nhất**

Nếu bạn hợp nhất hai cặp ô—ví dụ, (1, 1) x (2, 1) và (1, 2) x (2, 2)—bảng kết quả sẽ giữ nguyên đánh số ô như bảng trước khi hợp nhất. Đoạn mã Python sau minh họa hành vi này:

```python
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
with slides.Presentation() as presentation:
    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Xác định các cột với độ rộng và các hàng với độ cao.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Thêm hình dạng bảng vào slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Hợp nhất các ô (1,1) và (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Hợp nhất các ô (1, 2) và (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # In ra chỉ số các ô.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Lưu tệp PPTX vào đĩa.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Đánh số trong ô bị tách**

Trong ví dụ trước, khi các ô bảng được hợp nhất, việc đánh số trong các ô còn lại không thay đổi. Lần này, chúng ta tạo một bảng thông thường (không có ô hợp nhất) và sau đó tách ô (1, 1) để tạo ra một bảng đặc biệt. Hãy chú ý đến việc đánh số của bảng này—nó có thể trông bất thường. Tuy nhiên, đây là cách Microsoft PowerPoint đánh số các ô bảng, và Aspose.Slides cũng tuân theo cùng hành vi.

Đoạn mã Python sau minh họa hành vi này:

```python
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp PPTX.
with slides.Presentation() as presentation:
    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Xác định chiều rộng cột và chiều cao hàng.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Thêm hình dạng bảng vào slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Tách ô (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # In ra chỉ số các ô.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Lưu tệp PPTX vào đĩa.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Thay đổi màu nền ô bảng**

Đoạn ví dụ Python sau minh họa cách thay đổi màu nền của một ô bảng:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Tạo một bảng mới.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Đặt màu nền cho một ô.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Chèn hình ảnh vào ô bảng**

Phần này cho thấy cách chèn một hình ảnh vào ô bảng trong Aspose.Slides. Nó đề cập đến việc áp dụng ảnh nền vào ô mục tiêu và cấu hình các tùy chọn hiển thị như kéo dài hoặc lát.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu slide theo chỉ số của nó.
1. Định nghĩa một mảng chiều rộng các cột.
1. Định nghĩa một mảng chiều cao các hàng.
1. Thêm một bảng vào slide bằng phương pháp [add_table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_table/).
1. Tải ảnh từ tệp.
1. Thêm ảnh vào bộ sưu tập ảnh của bản trình chiếu để lấy một [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/).
1. Đặt [FillType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/filltype/) của ô bảng thành `PICTURE`.
1. Áp dụng ảnh vào ô bảng và chọn chế độ nền (ví dụ, `STRETCH`).
1. Lưu bản trình chiếu dưới dạng tệp PPTX.

Đoạn mã Python sau cho thấy cách đặt ảnh vào trong một ô bảng khi tạo bảng:

```python
import aspose.slides as slides

# Khởi tạo đối tượng Presentation.
with slides.Presentation() as presentation:
    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Xác định chiều rộng cột và chiều cao hàng.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Thêm hình dạng bảng vào slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Tải ảnh và thêm vào bản trình chiếu để có được một PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Áp dụng ảnh vào ô bảng đầu tiên.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Lưu bản trình chiếu vào đĩa.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt độ dày và kiểu đường viền khác nhau cho các mặt của một ô duy nhất không?**

Có. Các viền [top](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/vi/python-net/aspose.slides/cellformat/border_right/) có các thuộc tính riêng, vì vậy độ dày và kiểu của mỗi mặt có thể khác nhau. Điều này hợp lý với việc điều khiển viền theo từng mặt cho một ô được trình bày trong bài viết.

**Điều gì xảy ra với hình ảnh nếu tôi thay đổi kích thước cột/hàng sau khi thiết lập ảnh làm nền cho ô?**

Hành vi phụ thuộc vào [fill mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillmode/) (stretch/tile). Khi kéo dài, ảnh sẽ điều chỉnh theo ô mới; khi lát, các lát sẽ được tính lại. Bài viết đề cập đến các chế độ hiển thị ảnh trong ô.

**Tôi có thể gán siêu liên kết cho toàn bộ nội dung của một ô không?**

[Hyperlinks](/slides/vi/python-net/manage-hyperlinks/) được đặt ở mức đoạn văn bản (portion) bên trong khung văn bản của ô hoặc ở mức toàn bộ bảng/hình. Trong thực tế, bạn gán liên kết cho một đoạn hoặc cho toàn bộ văn bản trong ô.

**Tôi có thể đặt các phông chữ khác nhau trong một ô duy nhất không?**

Có. Khung văn bản của ô hỗ trợ [portions](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/) (run) với định dạng độc lập—gia đình phông, kiểu, kích thước và màu.