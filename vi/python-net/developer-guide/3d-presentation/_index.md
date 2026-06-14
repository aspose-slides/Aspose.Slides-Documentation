---
title: Tạo hiệu ứng 3D trong bản trình chiếu bằng Python
linktitle: Bản trình chiếu 3D
type: docs
weight: 232
url: /vi/python-net/3d-presentation/
keywords:
- PowerPoint 3D
- Bản trình chiếu 3D
- Xoay 3D
- Độ sâu 3D
- Đùn 3D
- Gradient 3D
- Văn bản 3D
- PowerPoint
- Bản trình chiếu
- Python
- Aspose.Slides
description: "Áp dụng và render hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong Python với Aspose.Slides. Cấu hình camera, ánh sáng, vật liệu, ép đùn, tô màu và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for Python via .NET có thể tạo, chỉnh sửa, bảo tồn và hiển thị định dạng 3D kiểu PowerPoint cho hình dạng và văn bản. Bài viết này bao gồm các hiệu ứng 3D như xoay, ép đùn, viền vát, ánh sáng, vật liệu, tô gradient hoặc ảnh, và văn bản 3D.

{{% alert color="primary" %}}

Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không liên quan đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành ảnh, PDF hoặc HTML, Aspose.Slides sẽ render các hiệu ứng 3D này thành đầu ra 2D đã xuất.

{{% /alert %}}

## **Khái niệm Định dạng 3D**

Sử dụng thuộc tính [Shape.three_d_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/three_d_format/) để áp dụng định dạng 3D cho một hình dạng. Thuộc tính này cung cấp [ThreeDFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/), điều khiển cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng thuộc tính [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/three_d_format/). Thuộc tính này áp dụng định dạng 3D cho khung văn bản thay vì thân hình dạng.

Các thuộc tính quan trọng nhất là:

| Thuộc tính | Điều khiển | Khi nào dùng |
|---|---|---|
| [camera](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/camera/) | Góc nhìn, loại camera đã đặt trước, xoay, thu phóng và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với một preset xoay 3D của PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/light_rig/) | Preset ánh sáng, hướng và xoay ánh sáng. | Thay đổi cách nổi bật và bóng xuất hiện trên bề mặt 3D. |
| [material](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/material/) | Vật liệu bề mặt, như phẳng, mờ, nhựa hoặc kim loại. | Làm cho cùng hình học trông phẳng hơn, mềm hơn, bóng hoặc kim loại. |
| [extrusion_height](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/extrusion_height/) | Khoảng cách hình dạng kéo dài ra phía sau mặt trước. | Biến một hình dạng phẳng thành một đối tượng 3D dày rõ rệt. |
| [extrusion_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/extrusion_color/) | Màu của các mặt bên được ép. | Làm cho độ sâu hiển thị hoặc phối hợp màu mặt bên với màu nền phía trước. |
| [depth](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/depth/) | Độ sâu 3D bổ sung được PowerPoint sử dụng trong định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt bevel và vật liệu. |
| [bevel_top](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/bevel_top/) và [bevel_bottom](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/bevel_bottom/) | Các cạnh được nâng lên hoặc làm tròn trên mặt trước và mặt sau. | Thêm cạnh mềm mại hoặc đúc thay vì mặt phẳng sắc nhọn. |
| [contour_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/contour_color/) và [contour_width](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/contour_width/) | Đường viền quanh đối tượng 3D. | Nhấn mạnh đường biên của đối tượng trong đầu ra render. |

## **Tạo một Hình dạng 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi nó trông thuyết phục là 3D:

- Cài đặt camera, vì góc nhìn mặc định phía trước có thể ẩn phần ép đùn.
- Cài đặt ánh sáng, vì ánh sáng làm cho các mặt và cạnh có thể nhìn được.
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được render.
- Cài đặt ép đùn hoặc độ sâu, vì một hình dạng phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt phía trước, áp dụng định dạng 3D, lưu bản trình bày dưới dạng PPTX và render slide thành ảnh PNG.

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

Hình ảnh slide đã render hiển thị hình chữ nhật như một khối 3D dày:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Xoay một Hình dạng bằng Camera**

Trong PowerPoint, xoay 3D được cấu hình từ bảng 3-D Rotation. Các giá trị xoay X, Y và Z tương ứng với xoay bạn đặt qua API camera.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Trong Aspose.Slides, đặt loại camera và xoay qua [ThreeDFormat.camera](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/camera/):

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Sử dụng camera khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình dạng trên slide. Nó thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides sử dụng khi render.

## **Thêm Extrusion và Depth**

Extrusion làm cho hình dạng trông dày hơn bằng cách mở rộng nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu thiết lập độ dày hiển thị này, và điều khiển màu đặt màu cho các mặt bên.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Đặt [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/extrusion_height/) để xác định độ dày và [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/extrusion_color/) để đặt màu các mặt bên:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Sử dụng [ThreeDFormat.depth](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/depth/) khi bạn cần làm việc trực tiếp với giá trị độ sâu của PowerPoint hoặc kết hợp độ sâu với bevel, vật liệu và hiệu ứng văn bản. Trong nhiều trường hợp hình dạng, [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/vi/python-net/aspose.slides/threedformat/extrusion_height/) là cài đặt rõ ràng hơn vì nó diễn đạt trực tiếp độ ép đùn có thể nhìn thấy.

## **Sử dụng Gradient hoặc Picture Fills với Hiệu ứng 3D**

Định dạng 3D độc lập với việc tô màu hình dạng. Bạn có thể áp dụng màu nguyên chất, gradient, pattern hoặc picture fill cho mặt trước và vẫn sử dụng cùng camera, ánh sáng, vật liệu và cài đặt extrusion.

Ví dụ này áp dụng gradient fill cho hình dạng và màu extrusion tối hơn cho các mặt bên:

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

Kết quả render giữ gradient trên mặt trước và render extrusion riêng biệt:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Để sử dụng picture fill thay thế, thêm ảnh vào bản trình bày và gán cho fill của hình dạng:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

Ảnh được render trên mặt trước, trong khi extrusion được render như bề mặt 3D bên:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D cho hình dạng ảnh hưởng đến thân hình dạng. Định dạng 3D cho văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt nơi các ký tự cần extrusion, vật liệu, ánh sáng và cài đặt camera.

Ví dụ sau tạo văn bản với pattern fill, áp dụng biến đổi WordArt và cấu hình cài đặt 3D trên [TextFrameFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/):

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

Văn bản được render dưới dạng chữ 3D cong, ép đùn:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Hành vi Xuất và Render**

Aspose.Slides bảo tồn định dạng 3D khi lưu sang các định dạng PowerPoint như PPTX. Khi render hoặc xuất sang các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn render slide thành [PNG](/slides/vi/python-net/convert-powerpoint-to-png/), xuất sang [PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/), xuất sang [HTML](/slides/vi/python-net/convert-powerpoint-to-html/), hoặc tạo khung cho [video conversion](/slides/vi/python-net/convert-powerpoint-to-video/).

Hãy nhớ các điểm sau:

- Ảnh và PDF đã xuất không có tính tương tác. Đối tượng không thể được xoay bởi người xem sau khi xuất.
- Ngoại hình cuối cùng phụ thuộc vào sự kết hợp của camera, light rig, vật liệu, extrusion, fill và tỉ lệ slide.
- Nếu bạn cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên theme, đọc [effective shape properties](/slides/vi/python-net/shape-effective-properties/).
- Một số định dạng xuất không thể lưu trữ định dạng 3D PowerPoint có thể chỉnh sửa. Trong các định dạng đó, kết quả trực quan được render thay vì được bảo tồn dưới dạng cài đặt 3D có thể chỉnh sửa.

## **FAQ**

**Aspose.Slides có thể tạo bản trình bày 3D tương tác không?**

Aspose.Slides tạo và render các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho ảnh, PDF hoặc trang HTML xuất ra trở thành cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

**Sự khác biệt giữa mô hình 3D và hiệu ứng 3D là gì?**

Mô hình 3D là đối tượng 3D riêng biệt được chèn vào bản trình bày. Hiệu ứng 3D là định dạng được áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, chẳng hạn xoay, extrusion, bevel, ánh sáng và vật liệu. Bài viết này đề cập đến hiệu ứng 3D.

**Cài đặt nào bắt buộc cho một hình dạng 3D có thể nhìn thấy?**

Ít nhất, đặt xoay camera và either extrusion hoặc depth. Trong thực tế, cũng nên đặt light rig và vật liệu để các mặt render có điểm nhấn và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**

Có. Sử dụng [Shape.three_d_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/three_d_format/) cho thân hình dạng và [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/textframeformat/three_d_format/) cho văn bản.

**Hiệu ứng 3D có xuất hiện khi xuất sang ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides render hiệu ứng 3D khi tạo ảnh slide, PDF, HTML và khung dùng cho chuyển đổi video. Đầu ra được xuất chứa hình ảnh đã render, không phải đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi kế thừa và cài đặt theme được áp dụng không?**

Có. Sử dụng API định dạng hiệu quả mô tả trong [Shape Effective Properties](/slides/vi/python-net/shape-effective-properties/) để đọc camera, light rig, bevel và các giá trị 3D liên quan cuối cùng.