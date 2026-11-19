---
title: Tạo hiệu ứng 3D trong bản trình chiếu bằng Python
linktitle: Bản trình chiếu 3D
type: docs
weight: 232
url: /vi/python-net/3d-presentation/
keywords:
- PowerPoint 3D
- bản trình chiếu 3D
- xoay 3D
- độ sâu 3D
- đùn 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Áp dụng và hiển thị các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong Python với Aspose.Slides. Cấu hình camera, ánh sáng, vật liệu, đùn, màu nền và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for Python qua .NET có thể tạo, chỉnh sửa, bảo tồn và hiển thị định dạng 3D kiểu PowerPoint cho các hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như xoay, đùn, bevels, chiếu sáng, vật liệu, độ chuyển màu hoặc tô bằng hình ảnh, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không liên quan đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide ra hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ hiển thị các hiệu ứng 3D đó trong đầu ra 2D đã xuất.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng thuộc tính [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) để áp dụng định dạng 3D cho một hình dạng. Thuộc tính này cung cấp [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/), điều khiển cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng thuộc tính [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). Điều này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình dạng.

Các thuộc tính quan trọng nhất là:

| Thuộc tính | Chức năng kiểm soát | Khi nào nên dùng |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | Góc nhìn, loại camera preset, xoay, thu phóng và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp một preset xoay 3D của PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | Cài đặt ánh sáng, hướng và góc quay ánh sáng. | Thay đổi cách ánh sáng phản chiếu và bóng xuất hiện trên bề mặt 3D. |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | Vật liệu bề mặt, như phẳng, mờ, nhựa hoặc kim loại. | Làm cho cùng hình học trông phẳng hơn, mềm hơn, sáng bóng hoặc kim loại. |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | Khoảng độ mà hình dạng mở rộng ra phía sau mặt trước. | Biến một hình phẳng thành một đối tượng 3D dày nhìn thấy được. |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | Màu của các mặt bên khi đùn. | Làm cho độ sâu hiển thị hoặc phối màu bên với màu nền phía trước. |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | Độ sâu 3D bổ sung được PowerPoint sử dụng trong định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với thiết lập bevel và vật liệu. |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) và [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | Các cạnh nhô lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm một cạnh mềm mại hoặc đúc thay vì một mặt phẳng sắc nét. |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) và [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới của đối tượng trong kết quả hiển thị. |

## **Tạo một Hình 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi trông thuyết phục là 3D:

- Cài đặt camera, vì góc nhìn mặc định phía trước có thể ẩn phần đùn.  
- Cài đặt ánh sáng, vì ánh sáng giúp các mặt và các cạnh có thể nhìn được.  
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được hiển thị.  
- Cài đặt đùn hoặc độ sâu, vì một hình phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước và áp dụng định dạng 3D. Các giá trị xoay camera được tính bằng độ, và chiều cao đùn là 100 điểm. Ví dụ này hiển thị slide thành ảnh PNG với kích thước gấp đôi mặc định và lưu bản trình bày dưới dạng PPTX.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

Hình ảnh slide đã hiển thị cho thấy hình chữ nhật như một khối 3D dày:

![Hình chữ nhật 3D màu xanh được hiển thị với văn bản 3D màu trắng trên mặt trước](img_01_01.png)

## **Xoay một Hình bằng Camera**

Trong PowerPoint, việc xoay 3D được cấu hình từ bảng 3-D Rotation. Các giá trị xoay X, Y và Z tương ứng với góc xoay bạn thiết lập qua API camera.

![Bảng 3-D Rotation của PowerPoint với các giá trị xoay X, Y, Z được làm nổi bật](img_02_01.png)

Trong Aspose.Slides, truy cập camera thông qua [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/). Ví dụ này tạo một hình chữ nhật, chọn góc nhìn trực diện orthographic, và đặt các góc xoay X, Y, Z lần lượt là 20, 30 và 40 độ. Nó cấu hình hình trong bộ nhớ mà không lưu file:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Sử dụng camera khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide. Nó thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides sử dụng khi hiển thị.

### **Sao chép Định hướng Camera từ Hình Mẫu**

Để khớp định hướng của một hình mẫu, sao chép preset [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) và đọc góc xoay bằng [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/). Ví dụ mở `template.pptx` và sao chép định hướng camera từ hình đầu tiên trên slide đầu tiên sang hình thứ hai. Cả hai hình đã có ánh sáng 3D, và hình thứ hai không có góc xoay camera cụ thể.

Các góc đo bằng độ. Chỉ mục `0`, `1`, và `2` giữ lần lượt vĩ độ, kinh độ và vòng quay. Gửi chúng vào [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) theo thứ tự đó. Nếu nguồn không có góc xoay cụ thể, `get_rotation` trả về `None`, vì vậy để nguyên góc đích. Nếu nguồn đặt cả ba góc về 0, sao chép các giá trị 0 đó.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

Khi bạn mở lại `camera-copy.pptx` trong PowerPoint, cả hai hình có cùng preset camera và góc xoay. Mũi tên bên phải sử dụng định hướng được sao chép từ hình chữ nhật bên trái. Cả hai hình đều dùng cùng ánh sáng và độ sâu đùn.

![Một hình chữ nhật 3D màu xanh và một mũi tên sang phải với định hướng camera khớp, nhìn từ trên và bên phải](camera-orientation.png)

## **Thêm Đùn và Độ sâu**

Đùn làm cho một hình dạng trông dày hơn bằng cách mở rộng nó ra phía sau mặt trước. Trong PowerPoint, bộ điều khiển độ sâu đặt độ dày nhìn thấy được này, và bộ điều khiển màu đặt màu cho các mặt bên.

![Các điều khiển độ sâu của PowerPoint được ánh xạ tới các thuộc tính màu đùn và chiều cao đùn](img_02_02.png)

Đặt [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) để xác định độ dày và [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) để đặt màu mặt bên. Ví dụ này cho hình chữ nhật một đùn 100 điểm với các mặt bên màu tím và xoay camera để lộ độ dày. Nó cấu hình hình trong bộ nhớ mà không lưu file:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Thuộc tính [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) đặt độ sâu cho một hình 3D. Thuộc tính [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) điều khiển chiều cao của hiệu ứng đùn, như trong ví dụ này.

## **Sử dụng Đổ màu Gradient hoặc Hình ảnh với Hiệu ứng 3D**

Định dạng 3D độc lập với màu nền hình dạng. Bạn có thể áp dụng màu đặc, gradient, họa tiết hoặc hình ảnh lên mặt trước và vẫn dùng cùng camera, ánh sáng, vật liệu và cài đặt đùn.

Ví dụ này áp dụng một gradient màu xanh‑đến‑cam lên mặt trước và màu cam đậm cho đùn 150 điểm. Các điểm dừng gradient ở 0 và 100 đánh dấu đầu và cuối gradient. Các giá trị xoay camera tính bằng độ. Slide được hiển thị thành ảnh PNG với kích thước gấp đôi mặc định:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

![Hình chữ nhật 3D đã hiển thị với độ chuyển màu xanh đến cam và đùn màu cam](img_02_03.png)

Để dùng nền ảnh thay thế, thêm ảnh vào bản trình bày và gán nó cho màu nền hình dạng. Ví dụ này yêu cầu một tệp hiện có tên “image.jpg” trong thư mục làm việc. Nó kéo dài ảnh để lấp đầy hình chữ nhật, áp dụng đùn 150 điểm và đặt xoay camera theo độ. Nó cấu hình hình trong bộ nhớ mà không lưu hoặc hiển thị tệp:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

![Hình chữ nhật 3D đã hiển thị với nền ảnh trên mặt trước và đùn màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D của hình ảnh ảnh hưởng đến phần thân hình dạng. Định dạng 3D của văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt nơi các chữ cái cần đùn, vật liệu, ánh sáng và cài đặt camera.

Ví dụ sau tạo văn bản với họa tiết lưới cam‑trắng, áp dụng một vòng cung lên trên, và cấu hình các cài đặt 3D qua [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). Chiều cao và độ sâu đùn tính bằng điểm, và góc quay ánh sáng tính bằng độ. Màu nền và viền hình dạng được ẩn để chỉ hiển thị văn bản. Ví dụ này tạo ảnh PNG với kích thước gấp đôi slide mặc định và lưu bản trình bày dưới dạng PPTX:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

![Văn bản 3D đã hiển thị với biến đổi WordArt cong, nền họa tiết cam, và đùn tối](img_02_05.png)

## **Giữ Văn bản Phẳng trên Hình 3D**

Để giữ văn bản dễ đọc đồng thời giữ nguyên vẻ ngoài 3D của hình, đặt [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/) qua [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/). Khi giá trị là `True`, văn bản sẽ ở ngoài cảnh 3D. Khi là `False`, văn bản sẽ tham gia vào cảnh và tuân theo hướng 3D.

Cài đặt này không loại bỏ định dạng 3D của hình: camera, ánh sáng, vật liệu và đùn vẫn được cấu hình qua [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/). Nó cũng khác với xoay thông thường. [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) xoay hình trong mặt phẳng slide, trong khi [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) điều khiển góc xoay tùy chỉnh của văn bản trong khung của nó. Giữ văn bản ngoài cảnh 3D không đặt lại bất kỳ góc nào trong hai trường hợp này.

Ví dụ tự chứa sau tạo một hình chữ nhật xanh với văn bản và sao chép nó bên cạnh bản gốc. Cả hai hình đều có cùng định dạng 3D; chỉ cài đặt văn bản khác nhau: `False` ở bên trái và `True` ở bên phải. Các góc camera tính bằng độ, và chiều cao đùn là 40 điểm. Ví dụ lưu bản trình bày dưới dạng PPTX và hiển thị slide so sánh thành PNG với kích thước gấp đôi mặc định.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

![Hai hình chữ nhật 3D cạnh nhau: keep_text_flat là False ở bên trái và True ở bên phải](keep_text_flat.png)

## **Xuất và Hành vi Hiển thị**

Aspose.Slides bảo tồn định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi hiển thị hoặc xuất sang các định dạng bố cục cố định, cảnh 3D sẽ được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn hiển thị slide thành [PNG](/slides/vi/python-net/convert-powerpoint-to-png/), xuất ra [PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/), xuất ra [HTML](/slides/vi/python-net/convert-powerpoint-to-html/), hoặc tạo khung cho [chuyển đổi video](/slides/vi/python-net/convert-powerpoint-to-video/).

- Các ảnh và PDF đã xuất không tương tác. Đối tượng không thể được người xem xoay sau khi xuất.  
- Hiển thị cuối cùng phụ thuộc vào sự kết hợp của camera, bộ ánh sáng, vật liệu, đùn, màu nền và tỉ lệ slide.  
- Nếu bạn cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên chủ đề, đọc [các thuộc tính hình dạng hiệu quả](/slides/vi/python-net/shape-effective-properties/).  
- Một số định dạng đầu ra không thể lưu định dạng 3D PowerPoint có thể chỉnh sửa. Trong những định dạng đó, kết quả trực quan được hiển thị thay vì được giữ dưới dạng cài đặt 3D có thể chỉnh sửa.

## **Câu hỏi thường gặp**

**Aspose.Slides có thể tạo bản trình chiếu 3D tương tác không?**  
Aspose.Slides tạo và hiển thị các hiệu ứng 3D PowerPoint cho hình dạng và văn bản. Nó không làm cho ảnh, PDF hoặc trang HTML xuất ra trở thành các cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

**Sự khác nhau giữa mô hình 3D và hiệu ứng 3D là gì?**  
Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình bày. Hiệu ứng 3D là định dạng áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, chẳng hạn như xoay, đùn, bevel, chiếu sáng và vật liệu. Bài viết này chỉ đề cập đến hiệu ứng 3D.

**Cài đặt nào là bắt buộc để có một hình 3D nhìn thấy được?**  
Ít nhất, cần đặt góc xoay camera và hoặc đùn hoặc độ sâu. Thực tế, nên thêm bộ ánh sáng và vật liệu để các mặt được hiển thị có điểm nhấn và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình và văn bản không?**  
Có. Dùng [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) cho phần thân hình và [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) cho văn bản.

**Hiệu ứng 3D có xuất hiện khi xuất ra ảnh, PDF, HTML hoặc khung video không?**  
Có. Aspose.Slides hiển thị các hiệu ứng 3D khi tạo ảnh slide, đầu ra PDF, đầu ra HTML và các khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa hình ảnh đã hiển thị, không phải một đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi áp dụng kế thừa và chủ đề không?**  
Có. Sử dụng các API định dạng hiệu quả mô tả trong [các thuộc tính hình dạng hiệu quả](/slides/vi/python-net/shape-effective-properties/) để đọc camera, bộ ánh sáng, bevel và các giá trị 3D liên quan đã được tính cuối cùng.