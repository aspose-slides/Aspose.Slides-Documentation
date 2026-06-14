---
title: Quản lý danh sách có dấu đầu dòng và danh sách đánh số trong bản trình bày bằng Python
linktitle: Quản lý danh sách
type: docs
weight: 70
url: /vi/python-net/manage-lists/
keywords:
- dấu đầu dòng
- danh sách có dấu đầu dòng
- danh sách đánh số
- dấu đầu dòng biểu tượng
- dấu đầu dòng hình ảnh
- dấu đầu dòng tùy chỉnh
- danh sách đa cấp
- tạo dấu đầu dòng
- thêm dấu đầu dòng
- thêm danh sách
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách tạo và định dạng danh sách có dấu đầu dòng, hình ảnh, đa cấp và danh sách đánh số trong các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua .NET."
---
## **Tổng quan**

Aspose.Slides for Python qua .NET cho phép bạn tạo và định dạng danh sách có dấu đầu dòng và danh sách đánh số trong các bản trình bày PowerPoint và OpenDocument. Một mục danh sách là một đoạn văn bản mà cài đặt dấu đầu dòng được kiểm soát thông qua định dạng đoạn văn của nó.

Sử dụng thuộc tính [Paragraph.paragraph_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/paragraph_format/) để truy cập cài đặt danh sách ở cấp độ đoạn văn. Điểm vào chính là [ParagraphFormat.bullet](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/bullet/), trả về một đối tượng [BulletFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/). Với đối tượng này, bạn có thể đặt loại dấu đầu dòng, biểu tượng, hình ảnh, màu sắc, kích thước, kiểu đánh số và số bắt đầu.

Bài viết này cho thấy cách:

- tạo danh sách có dấu đầu dòng với biểu tượng tùy chỉnh
- tạo dấu đầu dòng kiểu hình ảnh
- tạo danh sách đa cấp bằng cách đặt độ sâu của đoạn văn
- tạo danh sách đánh số
- kiểm tra và thay đổi định dạng danh sách trong một bản trình bày hiện có

## **Tạo danh sách có dấu đầu dòng**

Để tạo danh sách có dấu đầu dòng, thêm các đối tượng [Paragraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraph/) vào một [TextFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframe/) và đặt [BulletFormat.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/type/) thành [BulletType.SYMBOL](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bullettype/). Sau đó bạn có thể đặt [BulletFormat.char](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/color/) và [BulletFormat.height](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/height/) để kiểm soát ngoại hình của dấu đầu dòng.

Mã Python sau minh họa cách tạo danh sách có dấu đầu dòng trong một slide:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Các dấu đầu dòng biểu tượng](symbol_bullets.png)

## **Tạo danh sách đánh số**

Sử dụng danh sách đánh số khi thứ tự các mục quan trọng. Đặt [BulletFormat.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/type/) thành [BulletType.NUMBERED](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bullettype/). Bạn cũng có thể chọn định dạng đánh số bằng [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/numbered_bullet_style/) hoặc đặt [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) khi danh sách nên bắt đầu từ một giá trị khác 1.

Mã Python sau cho thấy cách tạo danh sách đánh số trong một slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Các dấu đầu dòng đánh số](numbered_bullets.png)

## **Tạo dấu đầu dòng kiểu hình ảnh**

Aspose.Slides cho phép bạn thay thế biểu tượng dấu đầu dòng thông thường bằng một hình ảnh. Dấu đầu dòng kiểu hình ảnh hoạt động tốt nhất với các hình ảnh đơn giản vẫn đọc được ở kích thước nhỏ, chẳng hạn như biểu tượng hoặc các tệp PNG trong suốt nhỏ.

{{% alert color="primary" %}}
Lý tưởng, nếu bạn dự định thay thế biểu tượng dấu đầu dòng thông thường bằng một hình ảnh, tốt nhất là chọn một đồ họa đơn giản với nền trong suốt. Những hình ảnh như vậy hoạt động tốt như các biểu tượng dấu đầu dòng tùy chỉnh.

Hãy nhớ rằng hình ảnh sẽ được thu nhỏ xuống kích thước rất nhỏ. Vì lý do này, chúng tôi mạnh mẽ khuyến nghị chọn một hình ảnh vẫn rõ ràng và hiệu quả về mặt thị giác khi được sử dụng làm dấu đầu dòng trong danh sách.
{{% /alert %}}

Để tạo dấu đầu dòng kiểu hình ảnh, thêm một hình ảnh vào [Presentation.images](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/images/) và gán đối tượng hình ảnh trả về cho [BulletFormat.picture](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/picture/). Đặt [BulletFormat.type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bulletformat/type/) thành [BulletType.PICTURE](https://reference.aspose.com/slides/vi/python-net/aspose.slides/bullettype/) trước khi gán hình ảnh.

Giả sử chúng ta có một "image.png":

![Hình ảnh cho dấu đầu dòng](picture_for_bullets.png)

Mã Python sau cho thấy cách tạo dấu đầu dòng kiểu hình ảnh trong một slide:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Các dấu đầu dòng hình ảnh](picture_bullets.png)

## **Tạo danh sách đa cấp**

Sử dụng [ParagraphFormat.depth](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/depth/) để đặt các mục danh sách ở các cấp độ khác nhau. Cấp độ 0 là cấp cao nhất, cấp độ 1 là cấp con dưới nó, và cứ như vậy.

Mã Python sau cho thấy cách tạo danh sách có dấu đầu dòng đa cấp:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Danh sách đa cấp](multilevel_list.png)

## **Thay đổi danh sách hiện có**

Để thay đổi định dạng danh sách trong một bản trình bày hiện có, truy cập vào đoạn văn mục tiêu và cập nhật cài đặt [ParagraphFormat.bullet](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/bullet/) của nó. Các thuộc tính đã dùng để tạo danh sách cũng có thể được dùng để kiểm tra hoặc sửa đổi các danh sách đã được tải từ tệp PPT, PPTX hoặc ODP.

Mã Python sau thay đổi đoạn văn đầu tiên trong một khung văn bản để sử dụng kiểu danh sách đánh số:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Danh sách có dấu đầu dòng và danh sách đánh số có thể xuất ra PDF hoặc hình ảnh không?**

Có. Aspose.Slides giữ nguyên định dạng danh sách khi định dạng đích hỗ trợ bố cục văn bản và các tính năng dấu đầu dòng tương ứng.

**Tôi có thể chỉnh sửa danh sách trong các bản trình bày hiện có không?**

Có. Tải bản trình bày, truy cập đoạn văn mục tiêu, kiểm tra hoặc cập nhật cài đặt [ParagraphFormat.bullet](https://reference.aspose.com/slides/vi/python-net/aspose.slides/paragraphformat/bullet/) của nó và lưu bản trình bày.

**Danh sách có thể chứa văn bản không phải Latinh không?**

Có. Văn bản của mục danh sách có thể chứa các ký tự Unicode, vì vậy bạn có thể tạo danh sách trong các bản trình bày đa ngôn ngữ. Đảm bảo các phông chữ được sử dụng trong bản trình bày hỗ trợ các ký tự bạn cần.