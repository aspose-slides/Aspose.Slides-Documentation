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
- đổ màu gradient
- đổ mẫu
- đổ ảnh
- đổ kết cấu
- đổ màu đồng nhất
- độ trong suốt hình dạng
- kết xuất hình dạng đen-trắng
- kết xuất hình dạng xám
- xoay hình dạng
- hiệu ứng đánh bờ 3D
- hiệu ứng xoay 3D
- đặt lại định dạng
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách định dạng các hình dạng PowerPoint trong Python bằng Aspose.Slides—đặt các kiểu tô, đường viền và hiệu ứng cho tệp PPT, PPTX và ODP một cách chính xác và kiểm soát hoàn toàn."
---
## **Giới thiệu**

Trong PowerPoint, bạn có thể thêm các hình dạng vào các slide. Vì các hình dạng được tạo thành từ các đường, bạn có thể định dạng chúng bằng cách chỉnh sửa hoặc áp dụng hiệu ứng cho viền của chúng. Ngoài ra, bạn có thể định dạng các hình dạng bằng cách chỉ định các cài đặt kiểm soát cách nội thất của chúng được tô màu.

![định dạng hình dạng powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python cung cấp các lớp và thuộc tính cho phép bạn định dạng các hình dạng bằng các tùy chọn tương tự như trong PowerPoint.

## **Định dạng Đường**

Sử dụng Aspose.Slides, bạn có thể chỉ định một kiểu đường tùy chỉnh cho một hình dạng. Các bước sau mô tả quy trình:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt [kiểu đường](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) cho hình dạng.
1. Đặt độ rộng đường.
1. Đặt [kiểu gạch](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) cho hình dạng.
1. Đặt màu đường cho hình dạng.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã Python sau đây minh họa cách định dạng một `AutoShape` hình chữ nhật:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto shape loại Hình chữ nhật.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Xóa phần tô màu khỏi hình chữ nhật để chỉ các đường viền hiển thị.
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

![Các đường đã định dạng trong bản trình bày](formatted-lines.png)

## **Áp dụng hiệu ứng Sketch cho đường viền hình dạng**

Hiệu ứng sketch làm cho đường viền của hình dạng trông như được vẽ tay. Sử dụng [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) để truy cập các cài đặt đường, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) để truy cập các cài đặt sketch, và [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) để chọn một giá trị từ liệt kê [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

Mã Python sau đây cho thấy cách áp dụng hiệu ứng [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) , đọc giá trị được gán một cách rõ ràng, và loại bỏ hiệu ứng bằng [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Truy cập định dạng đường của hình dạng và định dạng sketch của nó.
    sketch_format = shape.line_format.sketch_format

    # Áp dụng hiệu ứng sketch.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Đọc hiệu ứng sketch được gán trực tiếp cho hình dạng.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Xóa bỏ hiệu ứng sketch.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Giá trị trả về bởi `SketchFormat.sketch_type` đại diện cho cài đặt được gán trực tiếp cho hình dạng. Nếu định dạng đường có thể được kế thừa từ chủ đề, slide chủ hoặc slide bố cục, hãy sử dụng [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), truy cập thuộc tính `sketch_format` của đối tượng trả về, và đọc thuộc tính `sketch_type` của nó. Giá trị thực tế phản ánh định dạng thực sự được áp dụng sau khi giải quyết kế thừa:

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

## **Định dạng kiểu nối**

Dưới đây là ba tùy chọn kiểu nối:

* Tròn
* Mít
* Góc xiên

Mặc định, khi PowerPoint nối hai đường tại một góc (như ở góc của một hình dạng), nó sử dụng thiết lập **Tròn**. Tuy nhiên, nếu bạn vẽ một hình dạng có các góc nhọn, bạn có thể muốn tùy chọn **Mít**.

![Kiểu nối trong bản trình bày](join-style-powerpoint.png)

Mã Python sau đây minh họa cách ba hình chữ nhật (như trong ảnh ở trên) được tạo bằng các cài đặt kiểu nối Mít, Góc xiên và Tròn:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
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

	# Đặt độ rộng đường.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Đặt màu cho đường của mỗi hình chữ nhật.
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

## **Đổ màu gradient**

Trong PowerPoint, Đổ màu gradient là một tùy chọn định dạng cho phép bạn áp dụng một sự pha trộn liên tục của các màu lên một hình dạng. Ví dụ, bạn có thể áp dụng hai hoặc nhiều màu sao cho một màu dần chuyển sang màu khác.

Đây là cách áp dụng đổ màu gradient cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) của hình dạng thành `GRADIENT`.
1. Thêm hai màu bạn muốn với vị trí đã định nghĩa bằng các phương thức `add` của bộ sưu tập `gradient_stops` được cung cấp bởi lớp [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/).
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

```python
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto shape loại Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Áp dụng định dạng gradient cho ellipse.
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

![Hình ellipse với đổ màu gradient](gradient-fill.png)

Nếu gradient trông khác trong hình ảnh xuất ra so với trong PowerPoint, hãy xem [Chọn Kiểu Kết Xuất Gradient](/slides/vi/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Bạn có thể chọn một kiểu kết xuất mà không thay đổi gradient được lưu trong bản trình bày.

## **Đổ mẫu**

Trong PowerPoint, Đổ mẫu là một tùy chọn định dạng cho phép bạn áp dụng một thiết kế hai màu—như chấm, sọc, chéo hoặc ca rô—cho một hình dạng. Bạn có thể chọn màu tùy chỉnh cho tiền cảnh và nền của mẫu.

Aspose.Slides cung cấp hơn 45 kiểu mẫu được định nghĩa sẵn mà bạn có thể áp dụng cho các hình dạng để nâng cao tính thẩm mỹ của bản trình bày. Ngay cả sau khi chọn một mẫu đã định nghĩa, bạn vẫn có thể chỉ định các màu chính xác mà nó sẽ sử dụng.

Đây là cách áp dụng đổ mẫu cho một hình dạng bằng Aspose.Slides:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) của hình dạng thành `PATTERN`.
1. Chọn một kiểu mẫu từ các tùy chọn được định nghĩa sẵn.
1. Đặt [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) của mẫu.
1. Đặt [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) của mẫu.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto shape loại Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Đặt kiểu tô là Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Đặt kiểu mẫu.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Đặt màu nền và màu tiền cảnh của mẫu.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Lưu tệp PPTX vào ổ đĩa.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

![Hình chữ nhật với đổ mẫu](pattern-fill.png)

## **Đổ ảnh**

Trong PowerPoint, Đổ ảnh là một tùy chọn định dạng cho phép bạn chèn một hình ảnh vào bên trong một hình dạng—thực chất sử dụng hình ảnh làm nền cho hình dạng.

Đây là cách sử dụng Aspose.Slides để áp dụng đổ ảnh cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) của hình dạng thành `PICTURE`.
1. Đặt chế độ đổ ảnh thành `TILE` (hoặc chế độ khác bạn muốn).
1. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) từ hình ảnh bạn muốn sử dụng.
1. Gán hình ảnh này cho thuộc tính `picture.image` của `picture_fill_format` của hình dạng.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Giả sử chúng ta có tệp "lotus.png" với hình ảnh sau:

![Hình lotus](lotus.png)

```python
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto shape loại Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Đặt kiểu tô là Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Đặt chế độ đổ ảnh.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Tải ảnh và thêm vào tài nguyên của bản trình bày.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Đặt ảnh.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Lưu tệp PPTX vào ổ đĩa.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

![Hình dạng với đổ ảnh](picture-fill.png)

### **Lát ảnh làm Kết cấu**

Nếu bạn muốn đặt một ảnh lát làm kết cấu và tùy chỉnh hành vi lát, bạn có thể sử dụng các thuộc tính sau của lớp [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Đặt chế độ đổ ảnh—`TILE` hoặc `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Xác định vị trí căn chỉnh của các ô trong hình dạng.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Điều khiển việc lật ô theo chiều ngang, chiều dọc hoặc cả hai.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Đặt độ dịch chuyển ngang của ô (theo điểm) so với gốc của hình dạng.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Đặt độ dịch chuyển dọc của ô (theo điểm) so với gốc của hình dạng.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Xác định tỷ lệ ngang của ô dưới dạng phần trăm.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Xác định tỷ lệ dọc của ô dưới dạng phần trăm.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    first_slide = presentation.slides[0]

    # Thêm một auto shape hình chữ nhật.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Đặt kiểu tô của hình dạng thành Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Tải ảnh và thêm vào tài nguyên của bản trình bày.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Gán ảnh cho hình dạng.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Cấu hình chế độ đổ ảnh và các thuộc tính lát.
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

![Các tùy chọn lát](tile-options.png)

## **Đổ màu đồng nhất**

Trong PowerPoint, Đổ màu đồng nhất là một tùy chọn định dạng cho phép bạn điền một hình dạng bằng một màu duy nhất, đồng nhất. Màu nền đơn giản này được áp dụng mà không có gradient, kết cấu hay mẫu nào.

Để áp dụng đổ màu đồng nhất cho một hình dạng bằng Aspose.Slides, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) của hình dạng thành `SOLID`.
1. Gán màu điền bạn muốn cho hình dạng.
1. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto shape loại Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Đặt kiểu tô là Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Đặt màu tô.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Lưu tệp PPTX vào ổ đĩa.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

![Hình dạng với đổ màu đồng nhất](solid-color-fill.png)

## **Đặt Độ Trong Suất**

Trong PowerPoint, khi bạn áp dụng một màu đồng nhất, gradient, ảnh hoặc kết cấu cho các hình dạng, bạn cũng có thể đặt mức độ trong suốt để kiểm soát độ mờ của phần tô. Giá trị trong suốt cao hơn làm cho hình dạng trong suốt hơn, cho phép nền hoặc các đối tượng phía dưới nhìn thấy một phần.

Aspose.Slides cho phép bạn đặt mức độ trong suốt bằng cách điều chỉnh giá trị alpha trong màu được sử dụng để tô. Cách thực hiện:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt kiểu điền thành `SOLID`.
1. Sử dụng `Color.from_argb` để định nghĩa một màu có độ trong suốt (thành phần `alpha` kiểm soát độ trong suốt).
1. Lưu bản trình chiếu.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
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

![Hình dạng trong suốt](shape-transparency.png)

## **Xoay Hình Dạng**

Aspose.Slides cho phép bạn xoay các hình dạng trong bản trình bày PowerPoint. Điều này hữu ích khi định vị các yếu tố hình ảnh với yêu cầu căn chỉnh hoặc thiết kế cụ thể.

Để xoay một hình dạng trên slide, làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt thuộc tính `rotation` của hình dạng thành góc mong muốn.
1. Lưu bản trình bày.

```python
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho một tệp bản trình bày.
with slides.Presentation() as presentation:

    # Lấy slide đầu tiên.
    slide = presentation.slides[0]

    # Thêm một auto shape loại Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Xoay hình dạng 5 độ.
    shape.rotation = 5

    # Lưu tệp PPTX vào ổ đĩa.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![Xoay hình dạng](shape-rotation.png)

## **Thêm Hiệu Ứng Đánh Bờ 3D**

Aspose.Slides cho phép bạn áp dụng các hiệu ứng đánh bờ 3D cho các hình dạng bằng cách cấu hình các thuộc tính của lớp [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Để thêm hiệu ứng đánh bờ 3D cho một hình dạng, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vào slide.
1. Cấu hình [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) của hình dạng để định nghĩa các cài đặt đánh bờ.
1. Lưu bản trình bày.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Tạo một thể hiện của lớp Presentation.
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

    # Lưu bản trình bày dưới dạng tệp PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Hiệu ứng Đánh Bờ 3D](3D-bevel-effect.png)

## **Thêm Hiệu Ứng Xoay 3D**

Aspose.Slides cho phép bạn áp dụng các hiệu ứng xoay 3D cho các hình dạng bằng cách cấu hình các thuộc tính của lớp [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Để áp dụng xoay 3D cho một hình dạng:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vào slide.
1. Đặt [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) và [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) của hình dạng để xác định xoay 3D.
1. Lưu bản trình bày.

```python
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Lưu bản trình bày dưới dạng tệp PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Hiệu ứng Xoay 3D](3D-rotation-effect.png)

## **Kiểm soát Kết Xuất Đen‑Trắng cho Hình Dạng**

Thuộc tính [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) chỉ định cách một hình dạng riêng lẻ được kết xuất khi bản trình bày được xem hoặc xử lý ở chế độ đen‑trắng. Thuộc tính này không kích hoạt chế độ hiển thị đen‑trắng tự động và không thay đổi màu nền, đường viền hay các định dạng khác của hình dạng trong chế độ màu bình thường.

Sử dụng một giá trị từ liệt kê [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) để chọn hành vi mong muốn. Ví dụ, `AUTOMATIC` cho phép ứng dụng kết xuất chọn cách chuyển đổi, `GRAY` và `LIGHT_GRAY` sử dụng màu xám, `BLACK_WHITE` chỉ dùng màu đen và trắng, `BLACK` và `WHITE` buộc một màu duy nhất, `COLOR` giữ nguyên màu bình thường, và `HIDDEN` ẩn hình dạng trong chế độ đen‑trắng. `NOT_DEFINED` có nghĩa là không có chế độ cấp cho hình dạng.

Mã Python sau tạo một hình dạng màu và khiến nó hiển thị màu xám trong chế độ hiển thị đen‑trắng:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Keep the orange fill in color mode, but render the shape with gray coloring in black-and-white mode.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Trong chế độ màu bình thường, hình chữ nhật giữ màu nền cam. Khi làm việc trong quy trình hiển thị đen‑trắng, nó sẽ sử dụng màu xám vì chế độ đã được đặt thành `GRAY`. Điều này cho phép bạn giữ slide đầy màu khi định nghĩa cách hiển thị khác nhau cho việc in ấn, xem trước hoặc các quy trình khác tôn trọng cài đặt hiển thị đen‑trắng của bản trình bày.

## **Đặt Lại Định Dạng**

Mã Python sau cho thấy cách đặt lại định dạng của một slide và khôi phục vị trí, kích thước và định dạng của tất cả các hình dạng có placeholder trên [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) về các cài đặt mặc định:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Đặt lại mỗi hình dạng trên slide có placeholder trên bố cục.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Việc định dạng hình dạng có ảnh hưởng đến kích thước cuối cùng của file bản trình bày không?**

Chỉ ảnh hưởng rất ít. Các hình ảnh và phương tiện được nhúng chiếm phần lớn dung lượng file, trong khi các tham số hình dạng như màu, hiệu ứng và gradient được lưu dưới dạng siêu dữ liệu và hầu như không tăng kích thước đáng kể.

**Làm sao tôi có thể phát hiện các hình dạng trên một slide có cùng định dạng để nhóm chúng lại?**

So sánh các thuộc tính định dạng chính của mỗi hình dạng—các cài đặt fill, line và effect. Nếu tất cả các giá trị tương ứng khớp nhau, coi chúng là có cùng kiểu và nhóm chúng lại, giúp việc quản lý kiểu sau này trở nên đơn giản hơn.

**Tôi có thể lưu một tập hợp các kiểu hình dạng tùy chỉnh vào một file riêng để dùng lại trong các bản trình bày khác không?**

Có. Lưu các hình mẫu có kiểu mong muốn trong một slide mẫu hoặc một file mẫu .POTX. Khi tạo bản trình bày mới, mở mẫu, sao chép các hình dạng đã định dạng bạn cần và áp dụng lại định dạng của chúng ở nơi cần thiết.