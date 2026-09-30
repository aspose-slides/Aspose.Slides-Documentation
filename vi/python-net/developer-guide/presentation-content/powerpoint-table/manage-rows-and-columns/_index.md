---
title: Quản lý hàng và cột trong bảng PowerPoint bằng Python
linktitle: Hàng và Cột
type: docs
weight: 20
url: /vi/python-net/manage-rows-and-columns/
keywords:
- hàng bảng
- cột bảng
- hàng đầu tiên
- đầu đề bảng
- sao chép hàng
- sao chép cột
- chép hàng
- chép cột
- xóa hàng
- xóa cột
- định dạng văn bản hàng
- định dạng văn bản cột
- kiểu bảng
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Quản lý các hàng và cột của bảng trong PowerPoint bằng Aspose.Slides cho Python thông qua .NET và tăng tốc việc chỉnh sửa bản trình bày và cập nhật dữ liệu."
---
## **Giới thiệu**

Aspose.Slides for Python via .NET cho phép bạn quản lý cấu trúc và định dạng bảng trong các bản trình bày PowerPoint thông qua lớp [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) . Bạn có thể chỉ định một hàng tiêu đề, sao chép hoặc xóa các hàng và cột, và áp dụng định dạng văn bản cho toàn bộ một hàng hoặc cột.

Bài viết này giải thích các thao tác này bằng các ví dụ Python. Nó cũng cho thấy cách lấy trước kiểu bảng để bạn có thể tái sử dụng. Chỉ số hàng và cột của bảng bắt đầu từ không.

## **Kiểm soát chiều cao hàng**

Sử dụng [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) để đặt chiều cao tối thiểu của một hàng tính bằng điểm. Đây là một giới hạn dưới, không phải chiều cao cố định. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) trả về chiều cao thực tế và chỉ đọc. Truy cập hàng qua [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/).

Ví dụ tải [row-height-input.pptx](row-height-input.pptx), trong đó có một bảng là hình dạng đầu tiên trên slide đầu tiên. Hàng đầu tiên bắt đầu ở 70 điểm. Các ô sử dụng văn bản Arial 18 điểm, có ngắt dòng và lề trên dưới 6 điểm; văn bản dài hơn ở cột thứ hai được ngắt dòng thành nhiều dòng. Ví dụ tăng tối thiểu lên 100 điểm, sau đó giảm xuống 20 điểm, in chiều cao thực tế sau mỗi thay đổi, và lưu cả hai kết quả.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

Với bản trình bày được cung cấp, tăng tối thiểu sẽ thêm không gian vào hàng. Giảm nó sẽ loại bỏ không gian thừa, nhưng chiều cao thực tế vẫn lớn hơn 20 điểm vì văn bản và lề ô cần nhiều không gian hơn. Chỉ giảm tối thiểu không thể ép hàng xuống dưới không gian cần thiết cho nội dung của nó.

Một số yếu tố ảnh hưởng đến chiều cao thực tế:

- **Văn bản và kích thước phông chữ:** văn bản dài hơn, ngắt dòng rõ ràng, hoặc phông chữ lớn hơn có thể yêu cầu nhiều không gian dọc hơn.
- **Ngắt dòng và độ rộng cột:** khi bật ngắt dòng, một [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) hẹp hơn có thể tạo ra nhiều dòng hơn. Cột rộng hơn có thể giảm không gian cần thiết theo chiều dọc.
- **Lề ô:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) và [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) thêm không gian dọc. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) và [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) giảm độ rộng có thể dùng cho văn bản và có thể gây ngắt dòng thêm.

Đối với bảng này không có ô ghép, ô cần nhiều không gian dọc nhất quyết định giới hạn dưới dựa trên nội dung cho toàn bộ hàng. Để làm hàng ngắn hơn, bạn có thể cần rút ngắn văn bản, giảm kích thước phông chữ hoặc lề, hoặc làm rộng một cột.

Các hình ảnh bên dưới hiển thị cùng một bảng ở cùng tỷ lệ. Trong ví dụ này, chiều cao thực tế là 70, 100 và 55.2 điểm: hàng cuối vẫn cao hơn mức tối thiểu 20 điểm. Các đo lường văn bản chính xác có thể thay đổi tùy vào phông chữ có trong môi trường của bạn. Tải xuống các kết quả đã lưu: [tối thiểu tăng](row-height-increased.pptx) và [tối thiểu giảm](row-height-decreased.pptx).

| Gốc: tối thiểu 70 pt, thực tế 70 pt | Tăng: tối thiểu 100 pt, thực tế 100 pt | Giảm: tối thiểu 20 pt, thực tế 55.2 pt |
| --- | --- | --- |
| ![Bảng gốc với hàng đầu tiên 70 điểm.](row-height-before.png) | ![Bảng sau khi tăng tối thiểu hàng đầu tiên lên 100 điểm.](row-height-increased.png) | ![Bảng sau khi giảm tối thiểu hàng đầu tiên xuống 20 điểm; văn bản được ngắt dòng khiến hàng cao hơn mức tối thiểu.](row-height-decreased.png) |

## **Đặt hàng đầu tiên làm tiêu đề**

Sử dụng thuộc tính [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) để đánh dấu hàng đầu tiên cho định dạng tiêu đề. Hiển thị của nó phụ thuộc vào kiểu bảng được áp dụng cho bảng.

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Truy cập bảng được lưu dưới dạng hình dạng đầu tiên trên slide.
4. Bật định dạng tiêu đề cho hàng đầu tiên của nó.
5. Lưu bản trình bày đã sửa đổi.

Ví dụ yêu cầu `table.pptx` có một bảng là hình dạng đầu tiên trên slide đầu tiên. Nó bật định dạng tiêu đề cho hàng đầu tiên và lưu thành `First_row_header.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao chép một hàng hoặc cột bảng**

Sao chép các hàng hoặc cột để tái sử dụng nội dung và định dạng của chúng. Bạn có thể bổ sung một bản sao vào cuối bảng hoặc chèn vào vị trí cụ thể.

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Định nghĩa độ rộng cột và chiều cao hàng.
4. Thêm một bảng bằng phương thức [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Sao chép các hàng cần thiết.
6. Sao chép các cột cần thiết.
7. Lưu bản trình bày đã sửa đổi.

Ví dụ yêu cầu `Test.pptx` có ít nhất một slide. Nó tạo một bảng có ba cột và năm hàng, với kích thước được chỉ định bằng điểm. Nó bổ sung các bản sao của hàng và cột đầu tiên, sau đó chèn các bản sao của hàng và cột thứ hai tại chỉ mục 3 (vị trí thứ tư). Bảng kết quả có bảy hàng và năm cột. Tham số `False` vô hiệu hoá việc sao chép vào các hàng hoặc cột ghép liền kề; bảng này không có ô ghép.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Xóa một hàng hoặc cột khỏi bảng**

Xóa các hàng hoặc cột không còn cần thiết trong một bảng. Việc xóa một mục sẽ làm lệch chỉ số của các hàng hoặc cột phía sau nó.

1. Tạo một bản trình bày với lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Truy cập slide đầu tiên.
3. Định nghĩa độ rộng cột và chiều cao hàng.
4. Thêm một bảng bằng phương thức [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Xóa hàng thứ hai và cột thứ hai.
6. Lưu bản trình bày đã sửa đổi.

Ví dụ này tạo một bảng ba‑by‑ba và xóa hàng và cột ở chỉ mục 1, để lại một bảng hai‑by‑hai trong `TestTable_out.pptx`. Kích thước được tính bằng điểm. Tham số `False` vô hiệu hoá việc xóa các hàng hoặc cột ghép liền kề; bảng này không có ô ghép.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.shapes.add_table(100, 100, column_widths, row_heights)

    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt định dạng văn bản ở mức độ hàng bảng**

Áp dụng định dạng văn bản cho toàn bộ một hàng để giữ cho các ô của nó nhất quán. Bạn có thể đặt các thuộc tính phông chữ, định dạng đoạn văn và hướng văn bản mà không cần định dạng từng ô riêng lẻ.

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Truy cập bảng trên slide đầu tiên.
3. Đặt [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) cho hàng đầu tiên.
4. Đặt [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) và [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) cho hàng đầu tiên.
5. Đặt [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) cho hàng thứ hai.
6. Lưu bản trình bày đã sửa đổi.

Ví dụ yêu cầu `table.pptx` có một bảng là hình dạng đầu tiên trên slide đầu tiên và ít nhất hai hàng. Nó áp dụng văn bản 25 điểm, căn phải và lề đoạn văn phải 20 điểm cho hàng đầu tiên, sau đó đặt văn bản dọc cho hàng thứ hai.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt định dạng văn bản ở mức độ cột bảng**

Áp dụng định dạng văn bản cho toàn bộ một cột để giữ cho các ô của nó nhất quán. Bạn có thể đặt các thuộc tính phông chữ, định dạng đoạn văn và hướng văn bản mà không cần định dạng từng ô riêng lẻ.

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Truy cập bảng trên slide đầu tiên.
3. Đặt [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) cho cột đầu tiên.
4. Đặt [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) và [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) cho cột đầu tiên.
5. Đặt [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) cho cột thứ hai.
6. Lưu bản trình bày đã sửa đổi.

Ví dụ yêu cầu `table.pptx` có một bảng là hình dạng đầu tiên trên slide đầu tiên và ít nhất hai cột. Nó áp dụng văn bản 25 điểm, căn phải và lề đoạn văn phải 20 điểm cho cột đầu tiên, sau đó đặt văn bản dọc cho cột thứ hai.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Lấy thuộc tính kiểu bảng**

Sử dụng thuộc tính [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) để lấy trước kiểu đã áp dụng cho một bảng và tái sử dụng nó trên một bảng khác. Điều này xác định trước kiểu thay vì các ghi đè định dạng riêng lẻ của ô.

Ví dụ tạo một bảng, áp dụng [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) và đọc lại trước kiểu. Nó in ra `True` khi trước kiểu được lấy khớp với trước kiểu đã áp dụng và lưu bảng trong `table.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng giao diện/kiểu PowerPoint cho một bảng đã được tạo không?**

Có. Bảng kế thừa giao diện slide/bố cục/máy chủ, và bạn vẫn có thể ghi đè màu nền, viền và màu văn bản phía trên giao diện đó.

**Tôi có thể sắp xếp các hàng bảng giống như trong Excel không?**

Không, các bảng Aspose.Slides không có tính năng sắp xếp hay bộ lọc tích hợp. Bạn nên sắp xếp dữ liệu trong bộ nhớ trước, sau đó điền lại các hàng bảng theo thứ tự đó.

**Tôi có thể có các cột dạng sọc trong khi giữ màu tùy chỉnh cho các ô cụ thể không?**

Có. Bật cột dạng sọc, sau đó ghi đè các ô cụ thể bằng định dạng cục bộ; định dạng ở mức ô sẽ ưu tiên hơn kiểu bảng.