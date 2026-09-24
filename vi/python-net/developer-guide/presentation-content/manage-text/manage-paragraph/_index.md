---
title: Quản lý các đoạn văn bản PowerPoint trong Python
linktitle: Quản lý Đoạn văn
type: docs
weight: 40
url: /vi/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
  - thêm văn bản
  - thêm đoạn
  - quản lý văn bản
  - quản lý đoạn
  - quản lý dấu đầu dòng
  - thụt lề đoạn
  - thụt lề treo
  - dấu đầu dòng đoạn
  - danh sách đánh số
  - danh sách có dấu đầu dòng
  - thuộc tính đoạn
  - nhập HTML
  - văn bản sang HTML
  - đoạn sang HTML
  - đoạn sang hình ảnh
  - văn bản sang hình ảnh
  - xuất đoạn
  - PowerPoint
  - bản trình chiếu
  - Python
  - Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng các đoạn, phần, dấu đầu dòng, danh sách đánh số, thụt lề, nội dung HTML và hình ảnh đoạn với Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Aspose.Slides for Python via .NET đại diện cho văn bản dưới dạng một cấu trúc phân cấp gồm các khung văn bản, đoạn và phần:

* [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) đại diện cho vùng chứa văn bản trong một hình dạng và cung cấp quyền truy cập vào bộ sưu tập đoạn của nó.
* [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) đại diện cho một đoạn trong khung văn bản và cung cấp quyền truy cập vào các phần và định dạng mức độ đoạn.
* [Portion](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/) đại diện cho một đoạn văn bản trong một đoạn. Mỗi phần có thể có văn bản và định dạng ký tự riêng.

Do đó một đoạn có thể chứa văn bản với các phông chữ, màu sắc, kích thước và các định dạng khác nhau bằng cách sử dụng nhiều phần.

## **Tạo và Định dạng Đoạn văn**

### **Tạo Đoạn Văn với Nhiều Portion**

Các bước sau tạo một khung văn bản có ba đoạn, mỗi đoạn chứa ba phần:

1. Tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Truy cập slide liên quan thông qua chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của hình dạng.
5. Sử dụng đoạn mặc định và thêm hai đối tượng [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) nữa vào khung văn bản.
6. Thêm đủ đối tượng [Portion](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/) cho mỗi đoạn để chứa ba phần. Đoạn mặc định đã chứa một phần rỗng.
7. Đặt văn bản cho mỗi phần.
8. Áp dụng định dạng cấp ký tự thông qua [Portion.portion_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/portion_format/).
9. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ Python này thực hiện các bước:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Tạo Danh sách Đánh dấu và Đánh số**

### **Tạo danh sách Đánh dấu hoặc Đánh số**

Các dấu đầu dòng và đánh số giúp người đọc dễ dàng quét các mục liên quan. Trong Aspose.Slides, cài đặt danh sách được định nghĩa qua [BulletFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/).

1. Tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Truy cập slide liên quan thông qua chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào slide đã chọn.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của hình dạng.
5. Xóa đoạn mặc định khỏi khung văn bản.
6. Tạo một [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) cho dấu đầu dòng kiểu ký hiệu.
7. Đặt [BulletFormat.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/type/) thành [BulletType.SYMBOL](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bullettype/) và chỉ định ký tự dấu đầu dòng.
8. Đặt văn bản đoạn, thụt lề, màu dấu đầu dòng và chiều cao dấu đầu dòng.
9. Thêm đoạn vào khung văn bản.
10. Tạo một đoạn thứ hai và đặt [BulletFormat.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/type/) thành [BulletType.NUMBERED](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bullettype/).
11. Cấu hình kiểu dấu đầu dòng có số và thêm đoạn vào khung văn bản.
12. Lưu bản trình chiếu.

Ví dụ Python này tạo một dấu đầu dòng ký hiệu và một dấu đầu dòng có số:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Sử dụng Đánh dấu Hình ảnh**

Đánh dấu hình ảnh cho phép bạn sử dụng một hình ảnh tuỳ chỉnh thay cho ký hiệu hoặc số.

1. Tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Truy cập slide liên quan thông qua chỉ mục của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) và truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của nó.
4. Xóa đoạn mặc định khỏi khung văn bản.
5. Tải hình ảnh dấu đầu dòng và thêm nó vào bộ sưu tập ảnh của bản trình chiếu dưới dạng [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/).
6. Tạo một [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) và đặt văn bản cho nó.
7. Đặt [BulletFormat.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/type/) thành [BulletType.PICTURE](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bullettype/).
8. Gán hình ảnh qua [BulletFormat.picture](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/picture/) và đặt chiều cao dấu đầu dòng.
9. Thêm đoạn vào khung văn bản.
10. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ Python này tạo một dấu đầu dòng hình ảnh:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **Tạo Danh sách Đa cấp**

Đặt [ParagraphFormat.depth](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/depth/) để đặt các đoạn ở các mức độ khác nhau của một danh sách. Mức trên cùng có độ sâu `0`.

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và truy cập một slide.
2. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) và xóa đoạn mặc định khỏi khung văn bản của nó.
3. Tạo bốn đoạn và cấu hình các ký hiệu dấu đầu dòng của chúng.
4. Đặt giá trị [ParagraphFormat.depth](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/depth/) thành `0`, `1`, `2` và `3`.
5. Thêm các đoạn vào khung văn bản và lưu bản trình chiếu.

Ví dụ Python này tạo một danh sách đánh dấu bốn cấp:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Bắt đầu các mục danh sách đánh số với Giá trị Tùy chỉnh**

Sử dụng [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) để đặt số khởi đầu hiển thị cho một đoạn có đánh số.

1. Tạo một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào một slide.
2. Xóa đoạn mặc định khỏi khung văn bản của hình dạng.
3. Tạo ba đoạn có đánh số.
4. Đặt [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) thành `2`, `3` và `7` cho các đoạn tương ứng.
5. Thêm các đoạn vào khung văn bản và lưu bản trình chiếu.

Ví dụ Python này gán một số khởi đầu tùy chỉnh cho mỗi đoạn:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Kiểm soát Bố cục Đoạn và Thuộc tính Kết thúc**

### **Đặt Thụt Lề Dòng Đầu**

Sử dụng thuộc tính [ParagraphFormat.indent](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/indent/) để kiểm soát thụt lề dòng đầu của một đoạn. Thuộc tính này chỉ di chuyển dòng đầu tiên so với lề trái của đoạn. Giá trị dương đẩy dòng đầu tiên sang phải, trong khi các dòng còn lại vẫn căn chỉnh với thân đoạn.

Sử dụng [ParagraphFormat.margin_left](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/margin_left/) khi bạn cần di chuyển toàn bộ đoạn. Sử dụng [ParagraphFormat.indent](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/indent/) khi bạn chỉ muốn di chuyển dòng đầu tiên.

Ví dụ dưới tạo một số đoạn và áp dụng các giá trị [ParagraphFormat.indent](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/indent/) khác nhau để minh họa cách thụt lề dòng đầu ảnh hưởng đến bố cục đoạn.

1. Tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của hình dạng và xóa đoạn mặc định.
5. Tạo một số đoạn và đặt các giá trị [ParagraphFormat.indent](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/indent/) khác nhau cho chúng.
6. Thêm các đoạn vào khung văn bản.
7. Lưu bản trình chiếu đã chỉnh sửa.

Mã này cho bạn thấy cách đặt thụt lề đoạn:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Thụt lề dòng đầu của các đoạn](first_line_indent.png)

### **Đặt Thụt Lề Treo**

Thụt lề treo là một bố cục đoạn trong đó dòng đầu tiên bắt đầu phía trái của các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng thuộc tính [ParagraphFormat.indent](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/indent/). Đặt `indent` thành giá trị âm để di chuyển dòng đầu tiên sang trái so với thân đoạn.

Trong thực tế, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/margin_left/) xác định vị trí trái của thân đoạn, và [ParagraphFormat.indent](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/indent/) xác định vị trí của dòng đầu tiên so với lề đó. Để tạo thụt lề treo, đặt giá trị `margin_left` dương và giá trị `indent` âm.

Định dạng này hữu ích cho các mục thư mục, tài liệu tham khảo, mục từ điển và các đoạn khác nơi các dòng gập phải căn dưới thân đoạn thay vì dưới ký tự đầu tiên của dòng đầu.

1. Tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của hình dạng và xóa đoạn mặc định.
5. Tạo các đoạn và đặt giá trị [ParagraphFormat.margin_left](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/margin_left/) dương cho mỗi đoạn.
6. Đặt giá trị [ParagraphFormat.indent](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/indent/) âm để tạo hiệu ứng thụt lề treo.
7. Thêm các đoạn vào khung văn bản.
8. Lưu bản trình chiếu đã chỉnh sửa.

Mã này cho bạn thấy cách đặt thụt lề treo cho một đoạn:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Thụt lề treo của các đoạn](hanging_indent.png)

### **Đặt Thuộc tính Chạy Đoạn Kết thúc**

Thuộc tính [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) kiểm soát định dạng của dấu kết thúc đoạn. Ví dụ sau gán kích thước phông chữ và phông Latin cho dấu kết thúc của đoạn thứ hai:

1. Tải một [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và truy cập một slide.
2. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) và xóa đoạn mặc định của nó.
3. Tạo hai đoạn và thêm các phần văn bản vào chúng.
4. Tạo một [PortionFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/) cho dấu kết thúc của đoạn thứ hai.
5. Đặt [PortionFormat.font_height](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/font_height/) và [PortionFormat.latin_font](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/latin_font/).
6. Gán định dạng cho [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) và lưu bản trình chiếu.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Đếm Số Dòng Được Định Dạng**

Sử dụng [Paragraph.get_lines_count](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/get_lines_count/) để đếm số dòng mà một đoạn chiếm sau khi bố trí văn bản, bao gồm việc tự động gập. Điều này hữu ích khi kiểm tra độ dài và bố cục văn bản trong các mẫu bản trình chiếu.

Một đoạn là một mục trong [TextFrame.paragraphs](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/paragraphs/), và nó có thể chiếm nhiều dòng đã được định dạng. Một dấu ngắt dòng rõ ràng trong một đoạn buộc tạo một dòng mới mà không tạo đoạn mới. Việc gập tự động tạo các dòng dựa trên chiều rộng có sẵn mà không chèn dấu ngắt dòng vào văn bản. Vì vậy, việc đếm các đoạn hoặc ký tự ngắt dòng không cho số dòng đã được định dạng.

Ví dụ sau tạo một hình dạng văn bản, đếm số dòng, thu hẹp hình dạng, sau đó thay thế văn bản bằng một chuỗi ngắn hơn. Gập được bật và tự động vừa kích thước (autofit) bị tắt nên chiều rộng hình dạng kiểm soát việc gập mà không tự động thu nhỏ văn bản hay thay đổi kích thước hình dạng. Kích thước hình dạng tính bằng điểm. Cuối cùng, ví dụ thêm một đoạn khác và tổng hợp số dòng trên toàn bộ khung văn bản.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

Với văn bản và các kích thước này, thu hẹp hình dạng làm tăng số dòng, trong khi thay thế văn bản bằng chuỗi ngắn làm giảm số dòng. Các số đếm chính xác có thể thay đổi tùy vào sự có sẵn và thay thế phông chữ, kích thước phông, lề, thụt lề, gập và cài đặt autofit. Hãy sử dụng phông chữ và cài đặt bố cục dự định cho môi trường đích khi kiểm tra mẫu.

Chỉ số dòng không tự động xác định liệu văn bản có tràn ra ngoài vùng chứa hay không. Chiều cao khả dụng, chiều cao dòng, khoảng cách đoạn và dòng, và hành vi autofit cũng quan trọng; ngay cả một dòng duy nhất cũng có thể vượt quá chiều rộng khả dụng khi tắt gập.

## **Nhập và Xuất Nội dung Đoạn**

### **Nhập Văn bản HTML vào Đoạn**

Sử dụng [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphcollection/add_from_html/) để chuyển đổi markup HTML thành các đoạn và phần trong một khung văn bản.

1. Tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Truy cập một slide và thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/).
3. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của hình dạng và xóa đoạn mặc định.
4. Đọc tệp HTML nguồn.
5. Truyền chuỗi HTML cho [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ Python này nhập HTML vào một khung văn bản:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **Xuất Văn bản Đoạn ra HTML**

Sử dụng [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphcollection/export_to_html/) để xuất một phạm vi đoạn đã chọn dưới dạng HTML.

1. Tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải bản trình chiếu mong muốn.
2. Truy cập slide và tìm [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) chứa văn bản.
3. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của hình dạng.
4. Gọi [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphcollection/export_to_html/) với chỉ mục đoạn bắt đầu và số lượng đoạn cần xuất.
5. Ghi chuỗi HTML trả về vào tệp.

Ví dụ Python này xuất tất cả các đoạn từ hình dạng văn bản đầu tiên:

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **Kết xuất Đoạn thành Hình ảnh**

[Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) cung cấp phương thức `get_image` để kết xuất trực tiếp một đoạn riêng lẻ. Phương thức trả về một [IImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/) mà bạn có thể lưu vào tệp hoặc luồng bằng [IImage.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/iimage/save/). Bạn không cần phải kết xuất toàn bộ hình dạng chứa hoặc cắt thủ công một bitmap.

Phương thức `get_image` có thể trả về `None` nếu không tìm thấy đoạn trong bộ sưu tập cha, không có giới hạn hiển thị hợp lệ, hoặc không thể kết xuất. Kiểm tra kết quả trước khi lưu và sử dụng hình ảnh trả về như một context manager để giải phóng tài nguyên.

#### **Kết xuất Đoạn ở Tỷ lệ Mặc định**

Giả sử chúng ta có một tệp trình chiếu có tên sample.pptx với một slide, trong đó hình dạng đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản với ba đoạn](paragraph_to_image_input.png)

Ví dụ dưới kết xuất đoạn thứ hai trong một hình dạng văn bản thông thường ở tỷ lệ mặc định và lưu hình ảnh trả về ở định dạng PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

Kết quả:

![Hình ảnh đoạn](paragraph_to_image_output.png)

#### **Kết xuất Đoạn trong Ô Bảng với Thang tỷ lệ**

Chuyển các hệ số tỷ lệ ngang và dọc vào `get_image` để điều khiển kích thước của đoạn đã kết xuất. Ví dụ dưới tạo một bảng, kết xuất đoạn trong ô đầu tiên với độ rộng và chiều cao gấp đôi so với mặc định, và lưu kết quả dưới dạng PNG:

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

Hệ số `1` giữ trục tương ứng ở kích thước pixel mặc định. Ví dụ, `2` cho cả hai hệ số tạo ra một hình ảnh có chiều rộng và chiều cao khoảng gấp đôi kích thước mặc định, tương đương bốn lần số pixel. Các hệ số lớn hơn thường tạo ra văn bản sắc nét hơn cho việc phóng to hoặc xuất kết quả độ phân giải cao, nhưng cũng tăng mức tiêu thụ bộ nhớ và kích thước tệp. Các hệ số dưới `1` tạo ra hình ảnh nhỏ hơn với ít chi tiết hơn. Sử dụng các hệ số bằng nhau để duy trì tỉ lệ khung hình của đoạn; các hệ số ngang và dọc khác nhau sẽ kéo dài đầu ra một cách độc lập.

Việc kết xuất toàn bộ hình dạng bằng [Shape.get_image](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_image/) vẫn hữu ích khi đầu ra cần bao gồm nền, viền hoặc ngữ cảnh hình ảnh khác của hình dạng. Đối với hình ảnh chỉ chứa đoạn, hãy sử dụng `Paragraph.get_image`.

## **Câu hỏi thường gặp**

**Tôi có thể tắt hoàn toàn việc ngắt dòng trong một khung văn bản không?**

Có. Đặt [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/wrap_text/) để tắt việc gập, vì vậy các dòng sẽ không ngắt ở cạnh khung văn bản.

**Làm thế nào để tôi lấy chính xác giới hạn trên slide của một đoạn cụ thể?**

Sử dụng [Paragraph.get_rect](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/get_rect/) để lấy hình chữ nhật bao quanh của đoạn. [Portion.get_rect](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/get_rect/) cung cấp giới hạn của một phần riêng lẻ.

**Nơi nào điều chỉnh căn chỉnh đoạn (trái, phải, giữa hoặc căn đều)?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/alignment/) là một cài đặt mức đoạn và áp dụng cho toàn bộ đoạn bất kể định dạng phần riêng lẻ.

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho một phần của đoạn không?**

Có. Đặt [PortionFormat.language_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/language_id/) cho các phần riêng lẻ, vì vậy một đoạn có thể chứa văn bản bằng nhiều ngôn ngữ.