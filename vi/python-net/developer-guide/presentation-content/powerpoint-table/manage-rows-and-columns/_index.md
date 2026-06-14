---
title: Quản lý các hàng và cột trong bảng PowerPoint bằng Python
linktitle: Hàng và Cột
type: docs
weight: 20
url: /vi/python-net/manage-rows-and-columns/
keywords:
- hàng bảng
- cột bảng
- hàng đầu tiên
- tiêu đề bảng
- sao chép hàng
- sao chép cột
- sao chép hàng
- sao chép cột
- xóa hàng
- xóa cột
- định dạng văn bản hàng
- định dạng văn bản cột
- kiểu bảng
- PowerPoint
- Python
- Aspose.Slides
description: "Quản lý các hàng và cột của bảng trong PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET và tăng tốc việc chỉnh sửa bản trình chiếu và cập nhật dữ liệu."
---
## **Tổng quan**

Bài viết này trình bày cách quản lý các hàng và cột của bảng trong bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides for Python. Bạn sẽ học cách thêm, chèn, sao chép và xóa các hàng hoặc cột, đánh dấu hàng đầu tiên làm tiêu đề, điều chỉnh kích thước và bố cục, và áp dụng định dạng văn bản và kiểu ở mức hàng hoặc cột. Mỗi tác vụ được minh họa bằng các đoạn mã ngắn gọn, độc lập dựa trên API [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/) , giúp bạn nhanh chóng tìm bảng trên một slide và thay đổi cấu trúc của nó để phù hợp với thiết kế.

## **Đặt Hàng Đầu Tiên Là Tiêu Đề**

Đánh dấu hàng đầu tiên của bảng làm tiêu đề để phân biệt rõ ràng tiêu đề cột với dữ liệu. Trong Aspose.Slides for Python, chỉ cần bật tùy chọn *First Row* của bảng để áp dụng định dạng tiêu đề được xác định bởi kiểu bảng đã chọn.

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải bản trình chiếu.
1. Truy cập slide theo chỉ mục của nó.
1. Duyệt qua tất cả các đối tượng [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/) để tìm bảng tương ứng.
1. Đặt hàng đầu tiên của bảng làm tiêu đề.

```python
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation("table.pptx") as presentation:
    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Duyệt qua các shape và lấy tham chiếu tới bảng.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Đặt hàng đầu tiên của bảng làm tiêu đề.
    table.first_row = True
    
    # Lưu bản trình chiếu vào đĩa.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sao Chép Một Hàng Hoặc Cột Bảng**

Sao chép bất kỳ hàng hoặc cột nào của bảng và chèn bản sao vào vị trí mong muốn trong bảng. Bản sao giữ nguyên nội dung ô, định dạng và kích thước, cho phép bạn mở rộng bố cục nhanh chóng và nhất quán.

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải bản trình chiếu.
1. Truy cập slide theo chỉ mục của nó.
1. Xác định một mảng độ rộng cột.
1. Xác định một mảng độ cao hàng.
1. Thêm một [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/) vào slide bằng cách sử dụng `add_table(x, y, column_widths, row_heights)`.
1. Sao chép một hàng bảng.
1. Sao chép một cột bảng.
1. Lưu bản trình chiếu đã chỉnh sửa.

```python
 import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:
    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Xác định độ rộng cột và độ cao hàng.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Thêm một bảng vào slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Thêm văn bản vào hàng 1, cột 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Thêm văn bản vào hàng 2, cột 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Sao chép hàng 1 vào cuối bảng.
    table.rows.add_clone(table.rows[0], False)

    # Thêm văn bản vào hàng 1, cột 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Thêm văn bản vào hàng 2, cột 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Sao chép hàng 2 làm hàng thứ 4 của bảng.
    table.rows.insert_clone(3,table.rows[1], False)

    # Sao chép cột đầu tiên vào cuối.
    table.columns.add_clone(table.columns[0], False)

    # Sao chép cột thứ hai tại chỉ mục 3 (vị trí thứ 4).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Lưu bản trình chiếu vào đĩa.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Xóa Một Hàng Hoặc Cột Khỏi Bảng**

Tinh giản bảng bằng cách xóa bất kỳ hàng hoặc cột nào theo chỉ mục bằng Aspose.Slides for Python—bố cục sẽ tự động điều chỉnh lại trong khi vẫn giữ định dạng của các ô còn lại. Điều này hữu ích để đơn giản hoá lưới dữ liệu hoặc xóa các chỗ giữ chỗ mà không cần xây dựng lại bảng.

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải bản trình chiếu.
1. Truy cập slide theo chỉ mục của nó.
1. Xác định một mảng độ rộng cột.
1. Xác định một mảng độ cao hàng.
1. Thêm một ITable vào slide bằng cách sử dụng `add_table(x, y, column_widths, row_heights)`.
1. Xóa hàng bảng.
1. Xóa cột bảng.
1. Lưu bản trình chiếu đã chỉnh sửa.

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

## **Đặt Định Dạng Văn Bản ở Mức Hàng Bảng**

Áp dụng kiểu văn bản đồng nhất cho toàn bộ một hàng bảng trong một bước. Với Aspose.Slides for Python, bạn có thể thiết lập họ font, kích thước, độ đậm, màu và căn chỉnh cho tất cả các ô trong hàng cùng lúc để giữ tiêu đề hoặc dải dữ liệu nhất quán.

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải bản trình chiếu.
1. Truy cập slide theo chỉ mục của nó.
1. Truy cập đối tượng [Table] liên quan trên slide.
1. Đặt chiều cao phông chữ cho các ô hàng đầu tiên.
1. Đặt căn chỉnh và lề phải cho các ô hàng đầu tiên.
1. Đặt kiểu dọc của văn bản cho các ô hàng thứ hai.
1. Lưu bản trình chiếu đã chỉnh sửa.

```python
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Đặt chiều cao phông chữ cho các ô hàng đầu tiên.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # Đặt căn chỉnh văn bản và lề phải cho các ô hàng đầu tiên.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # Đặt kiểu dọc của văn bản cho các ô hàng thứ hai.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # Lưu bản trình chiếu vào đĩa.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Định Dạng Văn Bản ở Mức Cột Bảng**

Áp dụng kiểu văn bản đồng nhất cho toàn bộ một cột bảng cùng lúc. Với Aspose.Slides for Python, bạn có thể thiết lập họ font, kích thước, độ đậm, màu và căn chỉnh cho tất cả các ô trong một cột để tạo ra các dải dọc đồng nhất cho tiêu đề hoặc dữ liệu.

1. Tạo một đối tượng của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải bản trình chiếu.
1. Truy cập slide theo chỉ mục của nó.
1. Truy cập đối tượng [Table] liên quan trên slide.
1. Đặt chiều cao phông chữ cho các ô cột đầu tiên.
1. Đặt căn chỉnh và lề phải cho các ô cột đầu tiên.
1. Đặt kiểu dọc của văn bản cho các ô cột thứ hai.
1. Lưu bản trình chiếu đã chỉnh sửa.

```python
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Đặt chiều cao phông chữ cho các ô cột đầu tiên.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # Đặt căn chỉnh văn bản và lề phải cho các ô cột đầu tiên.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # Đặt kiểu dọc của văn bản cho các ô cột thứ hai.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Lưu bản trình chiếu vào đĩa.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Lấy Thuộc Tính Kiểu Bảng**

Aspose.Slides cho phép bạn lấy các thuộc tính kiểu của một bảng để có thể tái sử dụng chúng cho bảng khác hoặc nơi khác. Đoạn mã Python sau cho thấy cách lấy các thuộc tính kiểu từ một kiểu bảng đã định sẵn:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu Hỏi Thường Gặp**

**Can I apply PowerPoint themes/styles to a table that’s already created?**  
**Tôi có thể áp dụng chủ đề/kiểu PowerPoint cho một bảng đã tạo sẵn không?**

Có. Bảng sẽ kế thừa chủ đề của slide/bố cục/master, và bạn vẫn có thể ghi đè các màu nền, đường viền và màu văn bản trên chủ đề đó.

**Can I sort table rows like in Excel?**  
**Tôi có thể sắp xếp các hàng bảng giống như trong Excel không?**

Không, các bảng trong Aspose.Slides không có tính năng sắp xếp hoặc lọc tích hợp. Hãy sắp xếp dữ liệu trong bộ nhớ trước, sau đó điền lại các hàng bảng theo thứ tự đó.

**Can I have banded (striped) columns while keeping custom colors on specific cells?**  
**Tôi có thể có các cột sọc (striped) trong khi vẫn giữ màu tùy chỉnh cho các ô cụ thể không?**

Có. Bật tính năng cột sọc, sau đó ghi đè các ô cụ thể bằng định dạng cục bộ; định dạng ở mức ô sẽ ưu tiên hơn kiểu bảng.