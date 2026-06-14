---
title: Quản lý các đoạn văn bản PowerPoint trong Python
linktitle: Quản lý Đoạn
type: docs
weight: 40
url: /vi/python-net/manage-paragraph/
keywords:
- thêm văn bản
- thêm đoạn
- quản lý văn bản
- quản lý đoạn
- quản lý dấu đầu dòng
- thụt lề đoạn
- thụt lề treo
- đánh dấu đoạn
- danh sách đánh số
- danh sách gạch đầu dòng
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
description: "Thành thạo định dạng đoạn văn bản với Aspose.Slides cho Python qua .NET—tối ưu căn chỉnh, khoảng cách và kiểu dáng trong các bản trình chiếu PowerPoint và OpenDocument bằng Python để thu hút người xem."
---
## **Giới thiệu**

Aspose.Slides cung cấp các lớp cần thiết để làm việc với văn bản PowerPoint trong Python.

* Aspose.Slides cung cấp lớp [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) để tạo các đối tượng khung văn bản. Một đối tượng `TextFrame` có thể chứa một hoặc nhiều đoạn văn (mỗi đoạn được ngăn cách bằng ký tự quay lại).
* Aspose.Slides cung cấp lớp [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) để tạo các đối tượng đoạn văn. Một đối tượng `Paragraph` có thể chứa một hoặc nhiều phần văn bản.
* Aspose.Slides cung cấp lớp [Portion](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/) để tạo các đối tượng phần văn bản và chỉ định các thuộc tính định dạng của chúng.

Một đối tượng `Paragraph` có thể xử lý văn bản với các thuộc tính định dạng khác nhau thông qua các đối tượng `Portion` bên dưới.

## **Thêm Nhiều Đoạn Văn Bản Chứa Nhiều Phần Văn Bản**

Những bước sau minh họa cách thêm một khung văn bản chứa ba đoạn, mỗi đoạn có ba phần.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu đến slide mục tiêu bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) hình chữ nhật vào slide.
1. Lấy [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) liên kết với [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/).
1. Tạo hai đối tượng [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) và thêm chúng vào bộ sưu tập đoạn của [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) (cùng với đoạn mặc định, sẽ có ba đoạn).
1. Đối với mỗi đoạn, tạo ba đối tượng [Portion](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/) và thêm chúng vào bộ sưu tập phần của đoạn đó.
1. Đặt văn bản cho mỗi phần.
1. Áp dụng bất kỳ định dạng mong muốn nào cho mỗi phần văn bản bằng cách sử dụng các thuộc tính được cung cấp bởi [Portion](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portion/).
1. Lưu bản trình chiếu đã chỉnh sửa.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation để tạo một tệp PPTX mới.
with slides.Presentation() as presentation:

    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một AutoShape hình chữ nhật.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Truy cập TextFrame của AutoShape.
    text_frame = shape.text_frame

    # Tạo các đoạn và phần; định dạng sẽ được áp dụng bên dưới.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # Lưu tệp PPTX vào đĩa.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Quản Lý Đánh Dấu Đoạn Văn Bản**

Các danh sách gạch đầu dòng giúp bạn tổ chức và trình bày thông tin nhanh chóng và hiệu quả. Các đoạn văn có dấu đầu dòng thường dễ đọc và hiểu hơn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Truy cập slide mục tiêu bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào slide.
1. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của hình.
1. Xóa đoạn mặc định khỏi [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/).
1. Tạo đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/).
1. Đặt kiểu dấu đầu dòng của đoạn thành `SYMBOL` và chỉ định ký tự dấu đầu dòng.
1. Đặt văn bản cho đoạn.
1. Đặt thụt lề dấu đầu dòng cho đoạn.
1. Đặt màu sắc dấu đầu dòng.
1. Đặt kích thước (chiều cao) dấu đầu dòng.
1. Thêm đoạn vào bộ sưu tập đoạn của [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/).
1. Thêm đoạn thứ hai và lặp lại các bước 7–12.
1. Lưu bản trình chiếu.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Tạo một thể hiện của bản trình chiếu.
with slides.Presentation() as presentation:

    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm và truy cập một AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Truy cập khung văn bản của AutoShape đã tạo.
    text_frame = shape.text_frame

    # Xóa đoạn mặc định.
    text_frame.paragraphs.remove_at(0)

    # Tạo một đoạn.
    paragraph = slides.Paragraph()

    # Đặt kiểu và ký tự dấu đầu dòng cho đoạn.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Đặt văn bản cho đoạn.
    paragraph.text = "Welcome to Aspose.Slides"

    # Đặt thụt lề dấu đầu dòng.
    paragraph.paragraph_format.indent = 25

    # Đặt màu sắc dấu đầu dòng.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Đặt chiều cao dấu đầu dòng.
    paragraph.paragraph_format.bullet.height = 100

    # Thêm đoạn vào khung văn bản.
    text_frame.paragraphs.add(paragraph)

    # Tạo đoạn thứ hai.
    paragraph2 = slides.Paragraph()

    # Đặt loại và kiểu dấu đầu dòng cho đoạn.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Đặt văn bản cho đoạn.
    paragraph2.text = "This is numbered bullet"

    # Đặt thụt lề dấu đầu dòng.
    paragraph2.paragraph_format.indent = 25

    # Đặt màu sắc dấu đầu dòng.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Đặt chiều cao dấu đầu dòng.
    paragraph2.paragraph_format.bullet.height = 100

    # Thêm đoạn vào khung văn bản.
    text_frame.paragraphs.add(paragraph2)

    # Lưu bản trình chiếu thành tệp PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Quản Lý Dấu Đầu Dòng Hình Ảnh**

Các danh sách gạch đầu dòng giúp bạn tổ chức và trình bày thông tin nhanh chóng và hiệu quả. Dấu đầu dòng hình ảnh dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Truy cập slide mục tiêu bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào slide.
1. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của hình.
1. Xóa đoạn mặc định khỏi [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/).
1. Tạo đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/).
1. Tải một hình ảnh vào một [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/).
1. Đặt kiểu dấu đầu dòng thành [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) và gán hình ảnh.
1. Đặt văn bản cho đoạn.
1. Đặt thụt lề đoạn cho dấu đầu dòng.
1. Đặt màu sắc dấu đầu dòng.
1. Đặt chiều cao dấu đầu dòng.
1. Thêm đoạn mới vào bộ sưu tập đoạn của [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/).
1. Thêm đoạn thứ hai và lặp lại các bước 8–12.
1. Lưu bản trình chiếu.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]

    # Tải hình ảnh dấu đầu dòng.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # Thêm và truy cập một AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Truy cập TextFrame của AutoShape đã tạo.
    text_frame = auto_shape.text_frame

    # Xóa đoạn mặc định.
    text_frame.paragraphs.remove_at(0)

    # Tạo một đoạn mới.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Đặt loại dấu đầu dòng của đoạn thành Picture và gán hình ảnh.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Đặt chiều cao dấu đầu dòng.
    paragraph.paragraph_format.bullet.height = 100

    # Thêm đoạn vào khung văn bản.
    text_frame.paragraphs.add(paragraph)

    # Lưu bản trình chiếu thành tệp PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Lưu bản trình chiếu thành tệp PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Quản Lý Dấu Đầu Dòng Đa Cấp**

Các danh sách gạch đầu dòng giúp bạn tổ chức và trình bày thông tin nhanh chóng và hiệu quả. Dấu đầu dòng đa cấp dễ đọc và hiểu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Truy cập slide mục tiêu bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào slide.
1. Truy cập [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/)'s [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/).
1. Xóa đoạn mặc định khỏi [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/).
1. Tạo đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) và đặt độ sâu của nó là 0.
1. Tạo đoạn thứ hai bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) và đặt độ sâu của nó là 1.
1. Tạo đoạn thứ ba bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) và đặt độ sâu của nó là 2.
1. Tạo đoạn thứ tư bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) và đặt độ sâu của nó là 3.
1. Thêm các đoạn mới vào bộ sưu tập đoạn của [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/).
1. Lưu bản trình chiếu.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Tạo một thể hiện của bản trình chiếu.
with slides.Presentation() as presentation:

    # Truy cập slide đầu tiên.
    slide = presentation.slides[0]
    
    # Thêm một AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Truy cập TextFrame của AutoShape đã tạo.
    text_frame = auto_shape.text_frame
    
    # Xóa toàn bộ đoạn mặc định.
    text_frame.paragraphs.clear()

    # Thêm đoạn đầu tiên.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Đặt cấp độ dấu đầu dòng.
    paragraph1.paragraph_format.depth = 0

    # Thêm đoạn thứ hai.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Đặt cấp độ dấu đầu dòng.
    paragraph2.paragraph_format.depth = 1

    # Thêm đoạn thứ ba.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Đặt cấp độ dấu đầu dòng.
    paragraph3.paragraph_format.depth = 2

    # Thêm đoạn thứ tư.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Đặt cấp độ dấu đầu dòng.
    paragraph4.paragraph_format.depth = 3

    # Thêm các đoạn vào bộ sưu tập.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Lưu bản trình chiếu thành tệp PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Quản Lý Các Đoạn Văn Bản Với Danh Sách Đánh Số Tùy Chỉnh**

Lớp [BulletFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/) cung cấp thuộc tính `numbered_bullet_start_with` (và các thuộc tính khác) để kiểm soát việc đánh số và định dạng tùy chỉnh cho các đoạn văn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Truy cập slide mà sẽ chứa các đoạn.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào slide.
1. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của hình.
1. Xóa đoạn mặc định khỏi [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/).
1. Tạo đoạn [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) đầu tiên và đặt `numbered_bullet_start_with` thành 2.
1. Tạo đoạn [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) thứ hai và đặt `numbered_bullet_start_with` thành 3.
1. Tạo đoạn [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) thứ ba và đặt `numbered_bullet_start_with` thành 7.
1. Thêm các đoạn vào bộ sưu tập của [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/).
1. Lưu bản trình chiếu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Thêm và truy cập một AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Truy cập TextFrame của AutoShape đã tạo.
    text_frame = shape.text_frame

    # Xóa đoạn mặc định hiện có.
    text_frame.paragraphs.remove_at(0)

    # Tạo mục đánh số đầu tiên (bắt đầu từ 2, cấp độ sâu 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Tạo mục đánh số thứ hai (bắt đầu từ 3, cấp độ sâu 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Tạo mục đánh số thứ ba (bắt đầu từ 7, cấp độ sâu 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Thụt Lề Dòng Đầu Cho Một Đoạn Văn Bản**

Sử dụng thuộc tính [ParagraphFormat.indent](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/indent/) để điều khiển thụt lề dòng đầu của một đoạn văn. Thuộc tính này chỉ di chuyển dòng đầu tiên so với lề trái của đoạn. Giá trị dương sẽ đẩy dòng đầu sang phải, trong khi các dòng còn lại vẫn căn chỉnh với phần thân đoạn.

Sử dụng [ParagraphFormat.margin_left](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/margin_left/) khi bạn cần di chuyển toàn bộ đoạn. Sử dụng [ParagraphFormat.indent](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/indent/) khi bạn chỉ cần di chuyển dòng đầu tiên.

Ví dụ bên dưới tạo một vài đoạn và áp dụng các giá trị `indent` khác nhau để minh họa cách thụt lề dòng đầu ảnh hưởng đến bố cục đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) trống vào hình và xóa đoạn mặc định.
5. Tạo một vài đoạn và đặt các giá trị [indent](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/indent/) khác nhau cho chúng.
6. Thêm các đoạn vào khung văn bản.
7. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã này cho bạn thấy cách đặt thụt lề cho một đoạn:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

![Thụt lề dòng đầu của các đoạn](first_line_indent.png)

## **Đặt Thụt Lề Treo Cho Một Đoạn Văn Bản**

Thụt lề treo là kiểu bố cục đoạn trong đó dòng đầu tiên bắt đầu phía bên trái của các dòng còn lại. Trong Aspose.Slides, bạn tạo hiệu ứng này bằng thuộc tính [ParagraphFormat.indent](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/indent/). Đặt `indent` thành giá trị âm để di chuyển dòng đầu tiên sang trái so với phần thân đoạn.

Trong thực tế, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/margin_left/) xác định vị trí bên trái của phần thân đoạn, còn [ParagraphFormat.indent](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/indent/) xác định vị trí của dòng đầu tiên so với lề đó. Để tạo thụt lề treo, đặt giá trị `margin_left` dương và giá trị `indent` âm.

Định dạng này hữu ích cho thư mục, tài liệu tham khảo, mục từ điển và các đoạn khác mà các dòng gói xuống cần căn dưới phần thân đoạn thay vì dưới ký tự đầu tiên của dòng đầu.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
2. Truy cập slide mục tiêu.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) hình chữ nhật vào slide.
4. Thêm một [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) trống vào hình và xóa đoạn mặc định.
5. Tạo các đoạn và đặt giá trị [margin_left](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/margin_left/) dương cho mỗi đoạn.
6. Đặt giá trị [indent](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/indent/) âm để tạo hiệu ứng thụt lề treo.
7. Thêm các đoạn vào khung văn bản.
8. Lưu bản trình chiếu đã chỉnh sửa.

Đoạn mã này cho bạn thấy cách đặt thụt lề treo cho một đoạn:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

![Thụt lề treo của các đoạn](hanging_indent.png)

## **Quản Lý Định Dạng Phần Cuối Của Đoạn Văn Bản**

Khi bạn cần kiểm soát kiểu dáng của “cuối” một đoạn (định dạng được áp dụng sau phần văn bản cuối cùng), hãy sử dụng thuộc tính `end_paragraph_portion_format`. Ví dụ dưới đây áp dụng phông chữ Times New Roman cỡ lớn hơn cho phần cuối của đoạn thứ hai.

1. Tạo hoặc mở một tệp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy slide mục tiêu bằng chỉ mục.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) hình chữ nhật vào slide.
1. Sử dụng [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của hình và tạo hai đoạn.
1. Tạo một [PortionFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/) đặt thành Times New Roman 48 pt và áp dụng nó làm định dạng phần cuối của đoạn.
1. Gán nó cho `end_paragraph_portion_format` của đoạn (áp dụng cho phần kết của đoạn thứ hai).
1. Ghi bản trình chiếu đã chỉnh sửa thành tệp PPTX.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Nhập Văn Bản HTML Vào Các Đoạn**

Aspose.Slides cung cấp hỗ trợ nâng cao để nhập văn bản HTML vào các đoạn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Truy cập slide mục tiêu bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào slide.
1. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/).
1. Xóa đoạn mặc định khỏi [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/).
1. Đọc tệp HTML nguồn.
1. Tạo đoạn đầu tiên bằng lớp [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/).
1. Thêm nội dung HTML vào bộ sưu tập đoạn của [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/).
1. Lưu bản trình chiếu đã chỉnh sửa.

```python
import aspose.slides as slides

# Tạo một thể hiện Presentation trống.
with slides.Presentation() as presentation:

    # Truy cập slide đầu tiên của bản trình chiếu.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Thêm một AutoShape để chứa nội dung HTML.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Xóa tất cả các đoạn trong khung văn bản đã thêm.
    shape.text_frame.paragraphs.clear()

    # Tải tệp HTML.
    with open("file.html", "rt") as html_stream:
        # Thêm văn bản từ tệp HTML vào khung văn bản.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Lưu bản trình chiếu.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Xuất Văn Bản Đoạn Sang HTML**

Aspose.Slides cung cấp hỗ trợ nâng cao để xuất văn bản ra HTML.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải bản trình chiếu mục tiêu.
1. Truy cập slide mong muốn bằng chỉ mục.
1. Chọn hình chứa văn bản cần xuất.
1. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) của hình.
1. Mở một luồng tệp để ghi đầu ra HTML.
1. Xác định chỉ mục bắt đầu và xuất các đoạn cần thiết.

```python
import aspose.slides as slides

# Tải tệp bản trình chiếu.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Truy cập slide đầu tiên của bản trình chiếu.
    slide = presentation.slides[0]

    # Chỉ số hình mục tiêu.
    index = 0

    # Truy cập hình bằng chỉ số.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Ghi dữ liệu đoạn vào HTML bằng cách cung cấp chỉ số đoạn bắt đầu và tổng số đoạn cần xuất.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Lưu Một Đoạn Văn Bản Dưới Dạng Hình Ảnh**

Trong phần này, chúng ta sẽ khám phá hai ví dụ minh họa cách lưu một đoạn văn bản, được đại diện bởi lớp [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/), dưới dạng hình ảnh. Cả hai ví dụ đều bao gồm việc lấy hình ảnh của một hình chứa đoạn bằng các phương thức `get_image` từ lớp [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/), tính toán giới hạn của đoạn trong hình và xuất nó dưới dạng hình bitmap. Các cách tiếp cận này cho phép bạn trích xuất các phần cụ thể của văn bản trong bản trình chiếu PowerPoint và lưu chúng dưới dạng hình ảnh riêng, hữu ích cho các kịch bản sử dụng khác nhau.

Giả sử chúng ta có một tệp trình chiếu có tên sample.pptx với một slide, trong đó hình đầu tiên là một hộp văn bản chứa ba đoạn.

![Hộp văn bản với ba đoạn](paragraph_to_image_input.png)

**Ví dụ 1**

Trong ví dụ này, chúng ta lấy đoạn thứ hai dưới dạng hình ảnh. Để thực hiện, ta trích xuất hình ảnh của hình từ slide đầu tiên của bản trình chiếu, sau đó tính giới hạn của đoạn thứ hai trong khung văn bản của hình. Đoạn sau đó được vẽ lại lên một hình bitmap mới, được lưu ở định dạng PNG. Phương pháp này đặc biệt hữu ích khi bạn cần lưu một đoạn cụ thể dưới dạng hình ảnh riêng while preserving the exact dimensions and formatting of the text.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Lưu hình dạng trong bộ nhớ dưới dạng bitmap.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Tạo bitmap hình dạng từ bộ nhớ.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Tính toán giới hạn của đoạn thứ hai.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Tính toán tọa độ và kích thước cho hình ảnh đầu ra (kích thước tối thiểu - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Cắt bitmap hình dạng để chỉ lấy bitmap đoạn.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

![Hình ảnh đoạn](paragraph_to_image_output.png)

**Ví dụ 2**

Trong ví dụ này, chúng ta mở rộng cách tiếp cận trước bằng cách thêm các hệ số tỷ lệ vào hình ảnh đoạn. Hình được trích xuất từ bản trình chiếu và lưu dưới dạng hình ảnh với hệ số tỷ lệ `2`. Điều này cho phép xuất ra độ phân giải cao hơn khi xuất đoạn. Giới hạn đoạn sau đó được tính toán có xét đến tỷ lệ. Việc tỷ lệ hoá có thể đặc biệt hữu ích khi cần một hình ảnh chi tiết hơn, ví dụ cho tài liệu in chất lượng cao.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Lưu hình dạng trong bộ nhớ dưới dạng bitmap.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Tạo bitmap hình dạng từ bộ nhớ.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Tính toán giới hạn của đoạn thứ hai.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Tính toán tọa độ và kích thước cho hình ảnh đầu ra (kích thước tối thiểu - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Cắt bitmap hình dạng để chỉ lấy bitmap đoạn.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **Câu Hỏi Thường Gặp**

**Tôi có thể tắt hoàn toàn việc ngắt dòng trong một khung văn bản không?**

Có. Sử dụng cài đặt ngắt dòng của khung văn bản ([wrap_text](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/wrap_text/)) để tắt tính năng ngắt dòng, vì vậy các dòng sẽ không bị cắt ở cạnh khung.

**Làm sao tôi có thể lấy giới hạn chính xác trên slide của một đoạn cụ thể?**

Bạn có thể truy xuất hình chữ nhật bao quanh của đoạn (hoặc thậm chí của một phần) để biết vị trí và kích thước chính xác của nó trên slide.

**Căn chỉnh đoạn (trái/phải/giữa/đều) được kiểm soát ở đâu?**

[Alignment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/alignment/) là thiết lập cấp đoạn trong [ParagraphFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/); nó áp dụng cho toàn bộ đoạn bất kể định dạng của các phần riêng lẻ.

**Tôi có thể đặt ngôn ngữ kiểm tra chính tả cho chỉ một phần của đoạn (ví dụ, một từ) không?**

Có. Ngôn ngữ được đặt ở cấp phần ([PortionFormat.language_id](https://reference.aspose.com/slides/vi/python-net/aspose.slides/portionformat/language_id/)), vì vậy nhiều ngôn ngữ có thể cùng tồn tại trong một đoạn.