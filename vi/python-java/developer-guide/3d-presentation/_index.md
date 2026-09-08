---
title: Tạo hiệu ứng 3D trong bản trình chiếu bằng Python
linktitle: Bản trình chiếu 3D
type: docs
weight: 232
url: /vi/python-java/3d-presentation/
keywords:
- PowerPoint 3D
- bản trình chiếu 3D
- quay 3D
- độ sâu 3D
- đùn 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Áp dụng và render hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong Python qua Java với Aspose.Slides. Cấu hình camera, ánh sáng, vật liệu, đùn, các loại tô đầy và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for Python via Java có thể tạo, chỉnh sửa, giữ nguyên và hiển thị định dạng 3D kiểu PowerPoint cho hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như quay, đùn, bevel, ánh sáng, vật liệu, độ chuyển màu hoặc ảnh nền, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không liên quan tới việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành ảnh, PDF hoặc HTML, Aspose.Slides sẽ chuyển các hiệu ứng 3D này thành đầu ra 2D đã được render.
{{% /alert %}}

Cài đặt gói theo hướng dẫn trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ sẽ import `asposeslides`, khởi động JVM nếu cần, và sau đó import API. Ví dụ về ảnh nền yêu cầu một tệp `image.jpg` trong thư mục làm việc.

## **Khái niệm Định dạng 3D**

Sử dụng [Shape.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getThreeDFormat) để áp dụng định dạng 3D cho một hình dạng. Đối tượng định dạng trả về điều khiển cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#getThreeDFormat). Cách này áp dụng định dạng 3D cho khung văn bản thay vì thân hình dạng.

Các thành viên API quan trọng nhất:

| Thành viên API | Điều khiển | Khi nào sử dụng |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getCamera) | Góc nhìn, loại camera preset, quay, thu phóng và phối cảnh. | Quay đối tượng trong không gian 3D hoặc khớp với preset quay 3D của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getLightRig) | Ánh sáng preset, hướng và quay ánh sáng. | Thay đổi cách các điểm nhấn và bóng tối xuất hiện trên bề mặt 3D. |
| [getMaterial](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getMaterial) và [setMaterial](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#setMaterial) | Vật liệu bề mặt, như phẳng, mờ, nhựa hoặc kim loại. | Làm cho cùng hình học trông phẳng hơn, mềm hơn, bóng hơn hoặc kim loại hơn. |
| [getExtrusionHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getExtrusionHeight) và [setExtrusionHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Khoảng cách mà hình dạng kéo ra phía sau mặt trước. | Biến một hình dạng phẳng thành một đối tượng 3D dày có thể nhìn thấy. |
| [getExtrusionColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getExtrusionColor) | Màu của các mặt bên được đùn. | Làm cho độ sâu hiện ra hoặc đồng bộ màu mặt bên với màu nền phía trước. |
| [getDepth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getDepth) và [setDepth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#setDepth) | Độ sâu 3D bổ sung do PowerPoint sử dụng. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với bevel và vật liệu. |
| [getBevelTop](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getBevelTop) và [getBevelBottom](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getBevelBottom) | Các cạnh nhô lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm một cạnh mềm mại hoặc được tạo khuôn thay vì mặt phẳng sắc nét. |
| [getContourColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getContourWidth) và [setContourWidth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#setContourWidth) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong kết quả render. |

## **Tạo một Hình dạng 3D**

Một hình dạng thường cần bốn loại thiết lập trước khi nó trông thực sự 3D:

- Thiết lập camera, vì góc nhìn mặc định có thể ẩn đùn.
- Thiết lập ánh sáng, vì ánh sáng giúp các mặt và cạnh trở nên rõ ràng.
- Thiết lập vật liệu, vì bề mặt ảnh hưởng tới cách ánh sáng được render.
- Thiết lập đùn hoặc độ sâu, vì một hình dạng phẳng cần độ dày.

Ví dụ dưới đây tạo một hình chữ nhật, thêm văn bản vào mặt trước, áp dụng định dạng 3D, lưu bản trình chiếu dưới dạng PPTX và render slide thành ảnh PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hình ảnh slide đã render hiển thị hình chữ nhật như một khối 3D dày:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Quay một Hình dạng bằng Camera**

Trong PowerPoint, quay 3D được cấu hình từ bảng 3-D Rotation. Các giá trị quay X, Y và Z tương ứng với quay bạn thiết lập thông qua API camera.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Trong Aspose.Slides, đặt loại camera và góc quay thông qua định dạng 3D trả về bởi [Shape.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getThreeDFormat):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

Sử dụng camera khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide. Nó chỉ thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides dùng khi render.

## **Thêm Đùn và Độ sâu**

Đùn làm cho một hình dạng trông dày hơn bằng cách kéo nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu thiết lập độ dày này, và điều khiển màu thiết lập màu cho các mặt bên.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Đặt chiều cao đùn cho độ dày và màu đùn cho màu mặt bên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Sử dụng thiết lập độ sâu khi bạn cần làm việc trực tiếp với giá trị độ sâu của PowerPoint hoặc kết hợp độ sâu với bevel, vật liệu và hiệu ứng văn bản. Trong nhiều trường hợp, chiều cao đùn là thiết lập rõ ràng hơn vì nó biểu thị trực tiếp độ dày có thể nhìn thấy.

## **Sử dụng Độ chuyển màu hoặc Ảnh nền với Hiệu ứng 3D**

Định dạng 3D độc lập với việc tô đầy hình dạng. Bạn có thể áp dụng màu đồng nhất, gradient, pattern hoặc picture fill cho mặt trước và vẫn sử dụng cùng một thiết lập camera, ánh sáng, vật liệu và đùn.

Ví dụ này áp dụng gradient fill cho hình và màu đùn tối hơn cho các mặt bên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

Kết quả render giữ gradient trên mặt trước và render đùn riêng biệt:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Để sử dụng picture fill thay thế, thêm ảnh vào bản trình chiếu và gán nó cho fill của hình:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Ảnh được render trên mặt trước, trong khi đùn được render như bề mặt 3D bên:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D của hình ảnh ảnh hưởng đến thân hình dạng. Định dạng 3D của văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt, nơi các ký tự cần đùn, vật liệu, ánh sáng và camera.

Ví dụ sau tạo văn bản với pattern fill, áp dụng biến đổi WordArt và cấu hình các thiết lập 3D trên [TextFrameFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Văn bản được render dưới dạng chữ 3D cong, đùn:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Hành vi Xuất và Render**

Aspose.Slides giữ định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi render hoặc xuất sang các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn render slide thành PNG, xuất sang PDF, xuất sang HTML, hoặc tạo khung cho chuyển đổi video.

Lưu ý các điểm sau:

- Ảnh và PDF đã xuất không có tính tương tác. Đối tượng không thể quay lại bởi người xem sau khi xuất.
- Ngoại hình cuối cùng phụ thuộc vào sự kết hợp của camera, light rig, vật liệu, đùn, fill và tỉ lệ slide.
- Nếu bạn cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên theme, hãy sử dụng API định dạng effective.
- Một số định dạng đầu ra không thể lưu trữ định dạng 3D chỉnh sửa được của PowerPoint. Trong các định dạng đó, kết quả trực quan được render thay vì được giữ dưới dạng cài đặt 3D có thể chỉnh sửa.

## **Câu hỏi Thường gặp**

**Aspose.Slides có thể tạo các bài thuyết trình 3D tương tác không?**

Aspose.Slides tạo và render các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các ảnh, PDF hoặc trang HTML xuất ra trở thành cảnh 3D tương tác mà người xem có thể quay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

**Sự khác nhau giữa mô hình 3D và hiệu ứng 3D là gì?**

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình chiếu. Hiệu ứng 3D là định dạng áp dụng lên một hình dạng hoặc văn bản PowerPoint bình thường, như quay, đùn, bevel, ánh sáng và vật liệu. Bài viết này đề cập đến các hiệu ứng 3D.

**Những thiết lập nào cần cho một hình dạng 3D có thể nhìn thấy?**

Ít nhất, cần thiết lập quay camera và hoặc đùn hoặc độ sâu. Thực tế, cũng nên thiết lập light rig và vật liệu để các mặt được render có điểm nhấn và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**

Có. Sử dụng [Shape.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getThreeDFormat) cho thân hình dạng và [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#getThreeDFormat) cho văn bản.

**Hiệu ứng 3D có xuất hiện khi xuất sang ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides render hiệu ứng 3D khi tạo ảnh slide, xuất PDF, xuất HTML và tạo khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa hình ảnh đã render, không phải đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc giá trị 3D cuối cùng sau khi áp dụng kế thừa và theme không?**

Có. Sử dụng [ThreeDFormat.getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getEffective) để đọc camera, light rig, bevel và các giá trị 3D liên quan cuối cùng.