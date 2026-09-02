---
title: Định dạng các hình dạng PowerPoint trong Python
linktitle: Định dạng Hình dạng
type: docs
weight: 20
url: /vi/python-net/shape-formatting/
keywords:
- định dạng hình dạng
- định dạng đường
- hiệu ứng phác thảo
- đường viền hình dạng phác thảo
- định dạng kiểu nối
- tô màu gradient
- tô màu mẫu
- tô màu ảnh
- tô màu kết cấu
- tô màu đồng nhất
- trong suốt hình dạng
- hiển thị hình dạng đen‑trắng
- hiển thị hình dạng xám
- xoay hình dạng
- hiệu ứng bo 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong Python bằng Aspose.Slides—đặt kiểu tô, đường viền và hiệu ứng cho các tệp PPT, PPTX và ODP một cách chính xác và kiểm soát đầy đủ."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách sửa đổi hoặc áp dụng hiệu ứng cho đường viền của chúng. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách nội bộ của chúng được tô màu.

![định dạng hình dạng trong PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python cung cấp các lớp và thuộc tính cho phép bạn định dạng các hình dạng bằng các tùy chọn có sẵn trong PowerPoint.

## **Định dạng Đường**

Sử dụng Aspose.Slides, bạn có thể chỉ định kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt [định dạng đường](https://reference.aspose.com/slides/vi/python-net/aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng đường.
1. Đặt [kiểu gạch đứt](https://reference.aspose.com/slides/vi/python-net/aspose.slides/linedashstyle/) cho hình dạng.
1. Đặt màu đường cho hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Python sau minh họa cách định dạng một `AutoShape` hình chữ nhật:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto shape loại Hình chữ nhật.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Xóa phần tô khỏi hình chữ nhật để chỉ hiển thị các đường viền.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Áp dụng định dạng cho các đường của hình chữ nhật.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Đặt màu cho đường viền của hình chữ nhật.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Lưu tệp PPTX vào ổ đĩa.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Các đường đã định dạng trong bản trình chiếu](formatted-lines.png)

## **Áp dụng Hiệu ứng Phác thảo cho Đường Hình dạng**

Hiệu ứng phác thảo làm cho đường hình dạng trông như được vẽ tay. Sử dụng [Shape.line_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/line_format/) để truy cập cài đặt đường, [LineFormat.sketch_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/lineformat/sketch_format/) để truy cập cài đặt phác thảo, và [SketchFormat.sketch_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sketchformat/sketch_type/) để chọn một giá trị từ enumeration [LineSketchType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/linesketchtype/).

Đoạn mã Python sau cho thấy cách áp dụng hiệu ứng [LineSketchType.CURVED](https://reference.aspose.com/slides/vi/python-net/aspose.slides/linesketchtype/), đọc giá trị được gán một cách rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.NONE](https://reference.aspose.com/slides/vi/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Truy cập định dạng đường của hình dạng và định dạng phác thảo của nó.
    sketch_format = shape.line_format.sketch_format

    # Áp dụng hiệu ứng phác thảo.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Đọc hiệu ứng phác thảo được gán trực tiếp cho hình dạng.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Xóa hiệu ứng phác thảo.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Giá trị trả về bởi `SketchFormat.sketch_type` đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide mẹ hoặc slide bố cục, hãy sử dụng [LineFormat.get_effective](https://reference.aspose.com/slides/vi/python-net/aspose.slides/lineformat/get_effective/), truy cập thuộc tính `sketch_format` của đối tượng trả về, và đọc thuộc tính `sketch_type` của nó. Giá trị hiệu quả phản ánh định dạng thực sự được áp dụng sau khi kế thừa được giải quyết:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Định dạng Kiểu Nối**

Ba tùy chọn kiểu nối:

* Round
* Miter
* Bevel

Mặc định, khi PowerPoint nối hai đường tại một góc (như ở góc của hình dạng), nó sử dụng cài đặt **Round**. Tuy nhiên, nếu bạn đang vẽ một hình dạng với các góc nhọn, bạn có thể thích tùy chọn **Miter** hơn.

![Kiểu nối trong bản trình chiếu](join-style-powerpoint.png)

Đoạn mã Python sau minh họa cách ba hình chữ nhật (như trong hình trên) được tạo bằng các cài đặt Kiểu Nối Miter, Bevel và Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation() as presentation:

	# Lấy slide đầu tiên.
	slide = presentation.slides[0]

	# Thêm ba auto shape loại Hình chữ nhật.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Đặt màu tô cho mỗi hình chữ nhật.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Đặt độ rộng đường viền.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Đặt màu cho đường viền của mỗi hình chữ nhật.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Đặt kiểu nối.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Thêm văn bản vào mỗi hình chữ nhật.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Lưu tệp PPTX vào ổ đĩa.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Đổ màu Gradient**

Trong PowerPoint, Đổ màu Gradient là một tùy chọn định dạng cho phép bạn áp dụng một sự pha trộn liên tục của các màu vào một hình dạng. Ví dụ, bạn có thể áp dụng hai màu hoặc nhiều màu sao cho một màu dần dần chuyển sang màu khác.

Cách áp dụng Đổ màu Gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/filltype/) của hình dạng thành `GRADIENT`.
1. Thêm hai màu ưa thích của bạn cùng với vị trí đã xác định bằng các phương thức `add` của bộ sưu tập `gradient_stops` được cung cấp bởi lớp [GradientFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/gradientformat/).
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Python sau minh họa cách áp dụng hiệu ứng Đổ màu Gradient cho một hình ellipse:

```python
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto shape loại Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Áp dụng định dạng gradient cho hình ellipse.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Đặt hướng của gradient.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Thêm hai điểm dừng gradient.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Lưu tệp PPTX vào ổ đĩa.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Ellipse với Đổ màu Gradient](gradient-fill.png)

## **Đổ màu Pattern**

Trong PowerPoint, Đổ màu Pattern là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu — chẳng hạn như chấm, sọc, chéo hay dấu chéo — lên một hình dạng. Bạn có thể chọn màu tùy chỉnh cho nền và tiền cảnh của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định nghĩa trước mà bạn có thể áp dụng cho các hình dạng để tăng tính thẩm mỹ cho bản trình chiếu. Ngay cả sau khi đã chọn một mẫu đã định nghĩa, bạn vẫn có thể chỉ định các màu cụ thể mà mẫu sẽ sử dụng.

Cách áp dụng Đổ màu Pattern cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/filltype/) của hình dạng thành `PATTERN`.
1. Chọn một kiểu mẫu từ các tùy chọn được định nghĩa trước.
1. Đặt [back_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/patternformat/back_color/) của mẫu.
1. Đặt [fore_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/patternformat/fore_color/) của mẫu.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Python sau minh họa cách áp dụng Đổ màu Pattern cho một hình chữ nhật:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto shape loại Hình chữ nhật.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Đặt loại tô là Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Đặt kiểu mẫu.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Đặt màu nền và màu tiền cảnh của mẫu.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Lưu tệp PPTX vào ổ đĩa.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Hình chữ nhật với Đổ màu Pattern](pattern-fill.png)

## **Đổ màu Picture**

Trong PowerPoint, Đổ màu Picture là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào bên trong một hình dạng — thực tế là sử dụng hình ảnh làm nền của hình dạng.

Cách sử dụng Aspose.Slides để áp dụng Đổ màu Picture cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/filltype/) của hình dạng thành `PICTURE`.
1. Đặt chế độ Đổ màu picture thành `TILE` (hoặc chế độ ưa thích khác).
1. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) từ hình ảnh bạn muốn sử dụng.
1. Gán hình ảnh này cho thuộc tính `picture.image` của `picture_fill_format` của hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình ảnh lotus](lotus.png)

Đoạn mã Python sau minh họa cách đổ một hình dạng bằng hình ảnh:

```python
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto shape loại Hình chữ nhật.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Đặt loại tô là Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Đặt chế độ tô ảnh.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Tải hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Đặt hình ảnh.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Lưu tệp PPTX vào ổ đĩa.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Hình dạng với Đổ màu Picture](picture-fill.png)

### **Tile Picture As Texture**

Nếu bạn muốn đặt một hình ảnh lặp lại làm kết cấu và tùy chỉnh hành vi lặp, bạn có thể sử dụng các thuộc tính sau của lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Đặt chế độ Đổ màu picture — `TILE` hoặc `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/tile_alignment/): Xác định căn chỉnh của các ô gạch trong hình dạng.
- [tile_flip](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/tile_flip/): Điều khiển việc lật ô gạch theo chiều ngang, chiều dọc hoặc cả hai.
- [tile_offset_x](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/tile_offset_x/): Đặt độ lệch ngang của ô gạch (đơn vị điểm) so với gốc của hình dạng.
- [tile_offset_y](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/tile_offset_y/): Đặt độ lệch dọc của ô gạch (đơn vị điểm) so với gốc của hình dạng.
- [tile_scale_x](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/tile_scale_x/): Xác định tỷ lệ chiều ngang của ô gạch dưới dạng phần trăm.
- [tile_scale_y](https://reference.aspose.com/slides/vi/python-net/aspose.slides/picturefillformat/tile_scale_y/): Xác định tỷ lệ chiều dọc của ô gạch dưới dạng phần trăm.

Đoạn mã mẫu dưới đây cho thấy cách thêm một hình chữ nhật với Đổ màu picture dạng lặp và cấu hình các tùy chọn ô gạch:

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    first_slide = presentation.slides[0]

    # Thêm một auto shape hình chữ nhật.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Đặt loại tô của hình dạng là Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Tải hình ảnh và thêm nó vào tài nguyên của bản trình chiếu.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Gán hình ảnh cho hình dạng.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Cấu hình chế độ tô ảnh và các thuộc tính lặp.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Lưu tệp PPTX vào ổ đĩa.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Các tùy chọn ô gạch](tile-options.png)

## **Đổ màu Đơn sắc**

Trong PowerPoint, Đổ màu Đơn sắc là một tùy chọn định dạng làm đầy một hình dạng bằng một màu duy nhất, đồng nhất. Màu nền đơn giản này được áp dụng mà không có gradient, kết cấu hay mẫu nào.

Để áp dụng Đổ màu Đơn sắc cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/filltype/) của hình dạng thành `SOLID`.
1. Gán màu tô mà bạn muốn cho hình dạng.
1. Lưu bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Đoạn mã Python sau minh họa cách áp dụng Đổ màu Đơn sắc cho một hình chữ nhật trong slide PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto shape loại Hình chữ nhật.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Đặt loại tô là Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Đặt màu tô.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Lưu tệp PPTX vào ổ đĩa.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Hình dạng với Đổ màu Đơn sắc](solid-color-fill.png)

## **Đặt Độ trong suốt**

Trong PowerPoint, khi bạn áp dụng màu đơn, gradient, picture hoặc texture cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của phần tô. Giá trị trong suốt cao hơn sẽ làm cho hình dạng trở nên trong suốt hơn, cho phép nền hoặc các đối tượng bên dưới hiển thị một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được dùng để tô. Cách thực hiện:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt loại tô thành `SOLID`.
1. Sử dụng `Color.from_argb` để định nghĩa một màu có độ trong suốt (thành phần `alpha` điều khiển độ trong suốt).
1. Lưu bản trình chiếu.

Đoạn mã Python sau minh họa cách áp dụng màu tô trong suốt cho một hình chữ nhật:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    slide = presentation.slides[0]
    
    # Thêm một auto shape hình chữ nhật đặc.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Thêm một auto shape hình chữ nhật trong suốt lên trên hình dạng đặc.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình chiếu PowerPoint. Điều này hữu ích khi cần định vị các yếu tố hình ảnh với yêu cầu căn chỉnh hoặc thiết kế nhất định.

Để xoay một hình dạng trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt thuộc tính `rotation` của hình dạng thành góc mong muốn.
1. Lưu bản trình chiếu.

Đoạn mã Python sau minh họa cách xoay một hình dạng 5 độ:

```python
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto shape loại Hình chữ nhật.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Xoay hình dạng 5 độ.
    shape.rotation = 5

    # Lưu tệp PPTX vào ổ đĩa.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Xoay hình dạng](shape-rotation.png)

## **Thêm Hiệu ứng Bo 3D**

Aspose.Slides cho phép bạn áp dụng các hiệu ứng bo 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/) của chúng.

Để thêm hiệu quả bo 3D cho một hình dạng, thực hiện các bước sau:

1. Khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/) của hình dạng để định nghĩa cài đặt bo.
1. Lưu bản trình chiếu.

Đoạn mã Python dưới đây cho thấy cách áp dụng hiệu ứng bo 3D cho một hình dạng:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Thêm một hình dạng vào slide.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Đặt các thuộc tính ThreeDFormat của hình dạng.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Lưu bản trình chiếu dưới dạng tệp PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Hiệu ứng bo 3D](3D-bevel-effect.png)

## **Thêm Hiệu ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng các hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính [ThreeDFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/) của chúng.

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide theo chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt [camera_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/camera/camera_type/) và [light_type](https://reference.aspose.com/slides/vi/python-net/aspose.slides/lightrig/light_type/) của hình dạng để xác định xoay 3D.
1. Lưu bản trình chiếu.

Đoạn mã Python sau minh họa cách áp dụng hiệu ứng xoay 3D cho một hình dạng:

```python
import aspose.slides as slides

# Khởi tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Lưu bản trình chiếu dưới dạng tệp PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Kết quả:

![Hiệu ứng xoay 3D](3D-rotation-effect.png)

## **Kiểm soát Hiển thị Đen‑Trắng cho Hình dạng**

Thuộc tính [Shape.black_white_mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/black_white_mode/) chỉ định cách một hình dạng cá nhân được hiển thị khi bản trình chiếu được xem hoặc xử lý ở chế độ đen‑trắng. Thuộc tính này không kích hoạt chế độ hiển thị đen‑trắng tự động và cũng không thay đổi màu tô, đường viền hay các định dạng khác trong chế độ màu bình thường.

Sử dụng một giá trị từ enumeration [BlackWhiteMode](https://reference.aspose.com/slides/vi/python-net/aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `AUTOMATIC` để cho ứng dụng quyết định cách chuyển đổi, `GRAY` và `LIGHT_GRAY` để sử dụng màu xám, `BLACK_WHITE` để chỉ dùng đen và trắng, `BLACK` và `WHITE` để ép màu duy nhất, `COLOR` để giữ nguyên màu, và `HIDDEN` để ẩn hình dạng ở chế độ đen‑trắng. `NOT_DEFINED` có nghĩa là không có chế độ cấp cho hình dạng.

Đoạn mã Python sau tạo một hình dạng màu và làm cho nó hiển thị màu xám trong chế độ hiển thị đen‑trắng:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Giữ màu nền cam trong chế độ màu, nhưng hiển thị hình dạng với màu xám trong chế độ đen-trắng.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Trong chế độ màu bình thường, hình chữ nhật giữ nguyên màu nền cam. Khi chuyển sang chế độ hiển thị đen‑trắng, nó sẽ hiển thị màu xám vì chế độ của nó được đặt thành `GRAY`. Điều này cho phép bạn giữ bản trình chiếu màu đầy đủ đồng thời định nghĩa cách hiển thị riêng cho việc in, xem trước hoặc các quy trình làm việc khác tôn trọng cài đặt hiển thị đen‑trắng của bản trình chiếu.

## **Đặt lại Định dạng**

Đoạn mã Python sau cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/layoutslide/) về giá trị mặc định:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Đặt lại mỗi hình dạng trên slide có placeholder trên layout.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của tệp bản trình chiếu không?**

Chỉ ảnh hưởng rất ít. Các hình ảnh và phương tiện nhúng chiếm phần lớn dung lượng tệp, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng siêu dữ liệu và gần như không tăng dung lượng.

**Làm sao tôi có thể phát hiện các hình dạng trên một slide có cùng định dạng để có thể nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của từng hình dạng — cài đặt tô, đường viền và hiệu ứng. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là cùng một kiểu và nhóm logic các hình dạng đó, giúp việc quản lý kiểu sau này đơn giản hơn.

**Tôi có thể lưu một tập hợp các kiểu hình dạng tùy chỉnh vào một tệp riêng để tái sử dụng trong các bản trình chiếu khác không?**

Có. Lưu các hình mẫu có kiểu mong muốn trong một slide mẫu hoặc tệp mẫu .POTX. Khi tạo một bản trình chiếu mới, mở mẫu, sao chép các hình dạng đã định dạng bạn cần và áp dụng lại định dạng của chúng ở bất kỳ nơi nào cần thiết.