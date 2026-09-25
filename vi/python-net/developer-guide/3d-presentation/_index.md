---
title: Tạo Hiệu Ứng 3D trong Bài Thuyết Trình Sử Dụng Python
linktitle: Bài Thuyết Trình 3D
type: docs
weight: 232
url: /vi/python-net/3d-presentation/
keywords:
- PowerPoint 3D
- bài thuyết trình 3D
- xoay 3D
- độ sâu 3D
- đùn 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Áp dụng và render các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong Python với Aspose.Slides. Cấu hình máy ảnh, ánh sáng, vật liệu, đùn, các kiểu tô và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for Python via .NET có thể tạo, chỉnh sửa, bảo tồn và hiển thị định dạng 3D kiểu PowerPoint cho các hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như xoay, đùn, viền xiên, ánh sáng, vật liệu, tô gradient hoặc ảnh, và văn bản 3D.

{{% alert color="info" title="Lưu ý" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không nói về việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide ra ảnh, PDF hoặc HTML, Aspose.Slides sẽ chuyển các hiệu ứng 3D này thành kết quả 2D trong file xuất.
{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng thuộc tính [Shape.three_d_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/three_d_format/) để áp dụng định dạng 3D cho một hình dạng. Thuộc tính này cung cấp [ThreeDFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/), điều khiển cảnh 3D cho hình đó.

Đối với văn bản, sử dụng thuộc tính [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/three_d_format/). Thuộc tính này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình dạng.

Các thuộc tính quan trọng nhất là:

| Thuộc tính | Điều khiển | Khi nào sử dụng |
|---|---|---|
| [camera](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/camera/) | Góc nhìn, loại máy ảnh mặc định, xoay, thu phóng và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với một preset xoay 3D của PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/light_rig/) | Cài đặt ánh sáng, hướng và xoay ánh sáng. | Thay đổi cách ánh sáng và bóng đổ xuất hiện trên bề mặt 3D. |
| [material](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/material/) | Vật liệu bề mặt, chẳng hạn như phẳng, mờ, nhựa hoặc kim loại. | Làm cho cùng một hình học trông phẳng hơn, mềm hơn, bóng hơn hoặc kim loại hơn. |
| [extrusion_height](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/extrusion_height/) | Khoảng mà hình mở rộng ra phía sau mặt trước. | Biến một hình phẳng thành một đối tượng 3D dày có thể nhìn thấy. |
| [extrusion_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/extrusion_color/) | Màu của các mặt bên khi đùn. | Làm cho độ sâu hiển thị hoặc đồng bộ màu mặt bên với màu nền mặt trước. |
| [depth](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/depth/) | Độ sâu 3D bổ sung mà PowerPoint sử dụng. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt viền và vật liệu. |
| [bevel_top](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/bevel_top/) và [bevel_bottom](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/bevel_bottom/) | Các cạnh nhô lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm một cạnh mềm hoặc có khuôn dạng thay vì mặt phẳng sắc nhọn. |
| [contour_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/contour_color/) và [contour_width](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/contour_width/) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong đầu ra được render. |

## **Tạo một Hình dạng 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi nó trông thực sự 3D:

- Cài đặt máy ảnh, vì góc nhìn mặc định có thể ẩn phần đùn.
- Cài đặt ánh sáng, vì ánh sáng giúp các mặt và các bên dễ nhìn.
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được render.
- Cài đặt đùn hoặc độ sâu, vì một hình phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước và áp dụng định dạng 3D. Các giá trị xoay máy ảnh được tính bằng độ, và chiều cao đùn là 100 điểm. Ví dụ này render slide thành ảnh PNG có kích thước gấp đôi so với mặc định và lưu bản trình chiếu dưới dạng PPTX.

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

Ảnh slide đã render hiển thị hình chữ nhật như một khối 3D dày:

![Hình chữ nhật 3D màu xanh với văn bản 3D trắng trên mặt trước](img_01_01.png)

## **Xoay một Hình dạng bằng Máy ảnh**

Trong PowerPoint, xoay 3D được cấu hình từ bảng **3‑D Rotation**. Các giá trị xoay X, Y và Z tương ứng với các giá trị bạn đặt qua API máy ảnh.

![Bảng 3‑D Rotation của PowerPoint với các giá trị X, Y và Z được đánh dấu](img_02_01.png)

Trong Aspose.Slides, truy cập máy ảnh thông qua [ThreeDFormat.camera](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/camera/). Ví dụ này tạo một hình chữ nhật, chọn góc nhìn mặt trước trực giao, và đặt các góc xoay X, Y, Z thành 20°, 30° và 40° tương ứng. Nó cấu hình hình trong bộ nhớ mà không lưu file:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Sử dụng máy ảnh khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide, mà chỉ thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides sử dụng khi render.

## **Thêm Đùn và Độ sâu**

Đùn làm cho một hình dạng trông dày hơn bằng cách mở rộng nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu xác định độ dày này, và điều khiển màu xác định màu của các mặt bên.

![Các điều khiển độ sâu của PowerPoint được ánh xạ tới thuộc tính extrusion_color và extrusion_height](img_02_02.png)

Đặt [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/extrusion_height/) để xác định độ dày và [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/extrusion_color/) để xác định màu mặt bên. Ví dụ này cho hình chữ nhật một đùn 100 điểm với các mặt bên màu tím và xoay máy ảnh để hiển thị độ dày. Nó cấu hình hình trong bộ nhớ mà không lưu file:

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

Thuộc tính [ThreeDFormat.depth](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/depth/) đặt độ sâu cho một hình dạng 3D. Thuộc tính [extrusion_height](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/extrusion_height/) điều khiển chiều cao của hiệu ứng đùn, như trong ví dụ này.

## **Sử dụng Tô Gradient hoặc Ảnh với Hiệu ứng 3D**

Định dạng 3D không phụ thuộc vào loại tô của hình. Bạn có thể áp dụng màu nguyên bản, gradient, hoa văn hoặc ảnh cho mặt trước và vẫn sử dụng cùng các cài đặt máy ảnh, ánh sáng, vật liệu và đùn.

Ví dụ này áp dụng gradient màu xanh‑dương tới cam cho mặt trước và màu cam đậm cho đùn 150 điểm. Các điểm dừng gradient tại 0 và 100 đánh dấu đầu và cuối gradient. Các giá trị xoay máy ảnh được tính bằng độ. Slide được render thành ảnh PNG có kích thước gấp đôi mặc định:

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

Kết quả render giữ gradient trên mặt trước và render đùn riêng biệt:

![Hình chữ nhật 3D với gradient màu xanh‑dương tới cam và đùn màu cam](img_02_03.png)

Để sử dụng ảnh làm nền, thêm ảnh vào bản trình chiếu và gán nó cho tô hình. Ví dụ này yêu cầu có một tệp tồn tại tên “image.jpg” trong thư mục làm việc. Nó kéo dài ảnh để lấp đầy hình chữ nhật, áp dụng đùn 150 điểm và đặt xoay máy ảnh tính bằng độ. Nó cấu hình hình trong bộ nhớ mà không lưu hay render file:

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

Ảnh được render trên mặt trước, trong khi đùn được render như bề mặt bên 3D:

![Hình chữ nhật 3D với ảnh nền trên mặt trước và đùn màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D cho hình dạng ảnh hưởng đến thân hình. Định dạng 3D cho văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt nơi các ký tự cần đùn, vật liệu, ánh sáng và cài đặt máy ảnh.

Ví dụ sau tạo văn bản với hoa văn lưới màu cam‑trắng, áp dụng một vòng cung hướng lên trên và cấu hình các cài đặt 3D qua [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/three_d_format/). Chiều cao đùn và độ sâu tính bằng điểm, và xoay ánh sáng tính bằng độ. Tô hình và viền được ẩn để chỉ văn bản hiển thị. Ví dụ này render ảnh PNG gấp đôi kích thước slide mặc định và lưu bản trình chiếu dưới dạng PPTX:

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

Văn bản được render dưới dạng chữ 3D cong, đùn:

![Văn bản 3D được render với biến dạng WordArt dạng vòng cung, hoa văn màu cam và đùn tối màu](img_02_05.png)

## **Giữ Văn bản Phẳng trên Hình dạng 3D**

Để giữ cho văn bản dễ đọc đồng thời duy trì vẻ ngoài 3D của hình, đặt [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/keep_text_flat/) thông qua [TextFrame.text_frame_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/text_frame/text_frame_format/). Khi giá trị là `True`, văn bản sẽ ở ngoài cảnh 3D. Khi là `False`, văn bản sẽ tham gia vào cảnh và tuân theo định hướng 3D.

Cài đặt này không xóa bỏ định dạng 3D của hình: máy ảnh, ánh sáng, vật liệu và đùn vẫn được cấu hình qua [Shape.three_d_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/three_d_format/). Nó cũng khác với việc xoay thông thường. [Shape.rotation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/rotation/) xoay hình trong mặt phẳng slide, trong khi [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/rotation_angle/) điều khiển góc xoay tùy chỉnh của văn bản trong khung bao. Giữ văn bản ra khỏi cảnh 3D không đặt lại bất kỳ góc nào trong số đó.

Ví dụ tự chứa sau tạo một hình chữ nhật màu xanh với văn bản và sao chép nó bên cạnh bản gốc. Cả hai hình đều có cùng định dạng 3D; chỉ cài đặt văn bản khác nhau: `False` ở bên trái và `True` ở bên phải. Các góc máy ảnh tính bằng độ, và chiều cao đùn là 40 điểm. Ví dụ này lưu bản trình chiếu dưới dạng PPTX và render slide so sánh sang PNG gấp đôi kích thước mặc định.

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

Ở bên trái, văn bản theo định hướng 3D. Ở bên phải, văn bản giữ phẳng và dễ đọc hơn. Cả hai hình chữ nhật đều giữ cùng độ đùn và định hướng 3D hiển thị.

![Hai hình chữ nhật 3D cạnh nhau: keep_text_flat là False ở bên trái và True ở bên phải](keep_text_flat.png)

## **Xuất và Hành vi Render**

Aspose.Slides bảo tồn định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi render hoặc xuất sang các định dạng bố cục cố định, cảnh 3D sẽ được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn render slide thành [PNG](/slides/vi/python-net/convert-powerpoint-to-png/), xuất thành [PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/), xuất thành [HTML](/slides/vi/python-net/convert-powerpoint-to-html/), hoặc tạo khung cho [chuyển đổi video](/slides/vi/python-net/convert-powerpoint-to-video/).

Hãy nhớ những điểm sau:

- Ảnh và PDF được xuất không có tính tương tác. Đối tượng không thể bị xoay bởi người xem sau khi xuất.
- Ngoại hình cuối cùng phụ thuộc vào sự kết hợp giữa máy ảnh, hệ thống ánh sáng, vật liệu, đùn, tô và tỷ lệ slide.
- Nếu bạn cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên theme, hãy đọc [thuộc tính hình dạng hiệu quả](/slides/vi/python-net/shape-effective-properties/).
- Một số định dạng đầu ra không thể lưu trữ định dạng 3D có thể chỉnh sửa của PowerPoint. Trong những định dạng đó, kết quả hiển thị được render thay vì được giữ dưới dạng thiết lập 3D có thể chỉnh sửa.

## **Câu hỏi thường gặp**

**Aspose.Slides có tạo được bản trình chiếu 3D tương tác không?**

Aspose.Slides tạo và render các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các ảnh, PDF hoặc trang HTML xuất ra trở thành cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

**Sự khác biệt giữa mô hình 3D và hiệu ứng 3D là gì?**

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình chiếu. Hiệu ứng 3D là định dạng áp dụng cho một hình dạng hoặc văn bản PowerPoint bình thường, như xoay, đùn, viền xiên, ánh sáng và vật liệu. Bài viết này đề cập đến các hiệu ứng 3D.

**Những cài đặt nào cần cho một hình dạng 3D có thể nhìn thấy?**

Ít nhất, cần đặt một góc xoay máy ảnh và hoặc đùn hoặc độ sâu. Thực tế, nên còn cài đặt hệ thống ánh sáng và vật liệu để các mặt được render có điểm sáng và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**

Có. Sử dụng [Shape.three_d_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/three_d_format/) cho thân hình và [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/three_d_format/) cho văn bản.

**Hiệu ứng 3D có hiện ra khi xuất sang ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides render hiệu ứng 3D khi tạo ảnh slide, đầu ra PDF, đầu ra HTML và các khung dùng cho chuyển đổi video. Đầu ra được xuất chứa hình ảnh đã render, không phải đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi đã áp dụng kế thừa và cài đặt theme không?**

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [Shape Effective Properties](/slides/vi/python-net/shape-effective-properties/) để đọc camera, hệ thống ánh sáng, viền và các giá trị 3D liên quan cuối cùng.