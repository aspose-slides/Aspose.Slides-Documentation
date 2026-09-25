---
title: Tạo hiệu ứng 3D trong bài thuyết trình bằng Python
linktitle: Bài thuyết trình 3D
type: docs
weight: 232
url: /vi/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- Bài thuyết trình 3D
- Xoay 3D
- Độ sâu 3D
- Đùn 3D
- Gradient 3D
- Văn bản 3D
- PowerPoint
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Áp dụng và hiển thị các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong Python qua Java với Aspose.Slides. Cấu hình camera, ánh sáng, vật liệu, đùn, tô màu và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for Python via Java có thể tạo, chỉnh sửa, bảo tồn và hiển thị định dạng 3D kiểu PowerPoint cho hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như xoay, đùn, bevels, ánh sáng, vật liệu, gradient hoặc hình ảnh nền, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản của PowerPoint. Nó không liên quan đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ hiển thị các hiệu ứng 3D đó vào đầu ra 2D đã xuất.
{{% /alert %}}

## **Các khái niệm định dạng 3D**

Sử dụng phương thức [Shape.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getThreeDFormat) để áp dụng định dạng 3D cho một hình dạng. Phương thức này trả về [ThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/), kiểm soát cảnh 3D cho hình dạng đó.

Đối với văn bản, sử dụng phương thức [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#getThreeDFormat). Phương thức này áp dụng định dạng 3D cho khung văn bản thay vì phần thân hình dạng.

Các thành viên API quan trọng nhất là:

| Thành viên API | Điều nó điều khiển | Khi nào nên sử dụng |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getCamera) | Góc nhìn, loại camera mặc định, xoay, phóng đại và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với một preset xoay 3D của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getLightRig) | Preset ánh sáng, hướng và góc quay ánh sáng. | Thay đổi cách các điểm sáng và bóng tối xuất hiện trên bề mặt 3D. |
| [getMaterial](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getMaterial) và [setMaterial](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#setMaterial) | Vật liệu bề mặt, chẳng hạn như phẳng, mờ, nhựa hoặc kim loại. | Làm cho cùng hình học trông phẳng hơn, mềm hơn, bóng hoặc kim loại. |
| [getExtrusionHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getExtrusionHeight) và [setExtrusionHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Khoảng cách mà hình dạng mở rộng ra phía sau mặt trước. | Biến một hình dạng phẳng thành một đối tượng 3D dày rõ ràng. |
| [getExtrusionColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getExtrusionColor) | Màu của các mặt bên được đùn. | Làm cho độ sâu hiển thị hoặc phối màu mặt bên với phần nền mặt trước. |
| [getDepth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getDepth) và [setDepth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#setDepth) | Độ sâu 3D bổ sung được PowerPoint sử dụng để định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt bevel và vật liệu. |
| [getBevelTop](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getBevelTop) và [getBevelBottom](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getBevelBottom) | Các cạnh nhô lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm một cạnh mềm mại hoặc đúc thay vì mặt phẳng sắc nhọn. |
| [getContourColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getContourColor) và [getContourWidth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getContourWidth) và [setContourWidth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#setContourWidth) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới đối tượng trong đầu ra được hiển thị. |

## **Tạo một hình 3D**

Một hình dạng thường cần bốn loại cài đặt trước khi nó trông thuyết phục là 3D:

- Cài đặt camera, vì góc nhìn mặt trước mặc định có thể ẩn phần đùn.
- Cài đặt ánh sáng, vì ánh sáng giúp các mặt và các phía bên có thể nhìn thấy.
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được hiển thị.
- Cài đặt đùn hoặc độ sâu, vì một hình dạng phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước và áp dụng định dạng 3D. Các giá trị xoay camera được tính bằng độ, và chiều cao đùn là 100 điểm. Ví dụ này hiển thị slide thành hình ảnh PNG với kích thước gấp đôi mặc định và lưu bản trình bày dưới dạng PPTX.

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
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

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

Ảnh slide đã hiển thị cho thấy hình chữ nhật như một khối 3D dày:

![Hình chữ nhật 3D màu xanh đậm với văn bản 3D trắng trên mặt trước được hiển thị](img_01_01.png)

## **Xoay một hình dạng bằng Camera**

Trong PowerPoint, việc xoay 3D được cấu hình từ bảng 3-D Rotation. Các giá trị xoay X, Y và Z tương ứng với góc xoay bạn thiết lập qua API camera.

![Bảng 3-D Rotation của PowerPoint với các giá trị xoay X, Y và Z được đánh dấu](img_02_01.png)

Trong Aspose.Slides, truy cập camera thông qua [ThreeDFormat.getCamera](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getCamera). Ví dụ này tạo một hình chữ nhật, chọn góc nhìn mặt trước trực giao, và đặt các góc xoay X, Y, Z thành 20, 30 và 40 độ tương ứng. Nó cấu hình hình dạng trong bộ nhớ mà không lưu tệp:

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

Sử dụng camera khi bạn cần thay đổi cách người xem nhìn thấy đối tượng. Nó không thay đổi hình học 2D của hình dạng trên slide. Nó thay đổi quan điểm 3D được PowerPoint và Aspose.Slides sử dụng khi hiển thị.

## **Thêm Đùn và Độ sâu**

Đùn làm cho một hình dạng trông dày hơn bằng cách mở rộng nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu đặt độ dày hiển thị này, và điều khiển màu đặt màu cho các mặt bên.

![Điều khiển độ sâu của PowerPoint được ánh xạ tới các thuộc tính màu đùn và chiều cao đùn](img_02_02.png)

Sử dụng [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#setExtrusionHeight) để đặt độ dày và [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getExtrusionColor) để truy cập màu mặt bên. Ví dụ này cho một hình chữ nhật độ đùn 100 điểm với các mặt bên màu tím và xoay camera để lộ độ dày. Nó cấu hình hình dạng trong bộ nhớ mà không lưu tệp:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Phương thức [ThreeDFormat.setDepth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#setDepth) thiết lập độ sâu cho một hình 3D. Phương thức [setExtrusionHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#setExtrusionHeight) điều khiển chiều cao của hiệu ứng đùn, như trong ví dụ này.

## **Sử dụng độ gradient hoặc hình ảnh nền với hiệu ứng 3D**

Định dạng 3D độc lập với việc tô màu hình dạng. Bạn có thể áp dụng màu duy nhất, gradient, mẫu hoặc hình ảnh nền cho mặt trước và vẫn sử dụng cùng cài đặt camera, ánh sáng, vật liệu và đùn.

Ví dụ này áp dụng gradient xanh đến cam cho mặt trước và màu cam đậm cho phần đùn 150 điểm. Các điểm dừng gradient tại 0 và 100 đánh dấu đầu và cuối gradient. Các giá trị xoay camera được tính bằng độ. Slide được hiển thị thành hình PNG với kích thước gấp đôi mặc định:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

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

Đầu ra đã hiển thị giữ gradient trên mặt trước và hiển thị phần đùn riêng biệt:

![Hình chữ nhật 3D với độ gradient xanh‑cà‑cam và phần đùn màu cam](img_02_03.png)

Để sử dụng hình ảnh nền thay thế, thêm hình ảnh vào bản trình bày và gán nó cho phần tô màu của hình dạng. Ví dụ này yêu cầu một tệp hiện có tên "image.jpg" trong thư mục làm việc. Nó kéo dài hình ảnh để lấp đầy hình chữ nhật, áp dụng đùn 150 điểm và đặt góc xoay camera bằng độ. Nó cấu hình hình dạng trong bộ nhớ mà không lưu hoặc hiển thị tệp:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
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
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Hình ảnh được hiển thị trên mặt trước, trong khi phần đùn được hiển thị như bề mặt bên 3D:

![Hình chữ nhật 3D với hình ảnh nền trên mặt trước và phần đùn màu cam](img_02_04.png)

## **Áp dụng định dạng 3D cho Văn bản**

Định dạng 3D của hình dạng ảnh hưởng đến phần thân hình dạng. Định dạng 3D của văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt, nơi các ký tự cần đùn, vật liệu, ánh sáng và cài đặt camera.

Ví dụ sau tạo văn bản với mẫu lưới cam‑trắng, áp dụng một vòng cung hướng lên, và cấu hình cài đặt 3D qua [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#getThreeDFormat). Chiều cao đùn và độ sâu tính bằng điểm, và góc xoay ánh sáng tính bằng độ. Phần tô và viền của hình dạng được ẩn để chỉ văn bản hiển thị. Ví dụ này hiển thị hình ảnh PNG với kích thước gấp đôi slide mặc định và lưu bản trình bày dưới dạng PPTX:

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

Văn bản được hiển thị dưới dạng chữ 3D cong, đùn:

![Văn bản 3D đã hiển thị với biến đổi WordArt cong, mẫu nền cam, và phần đùn tối](img_02_05.png)

## **Giữ Văn bản Phẳng trên Hình 3D**

Để giữ văn bản dễ đọc trong khi vẫn duy trì hình dạng 3D, gọi [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setKeepTextFlat) qua [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getTextFrameFormat). Khi giá trị là `True`, văn bản sẽ nằm ngoài cảnh 3D. Khi là `False`, văn bản sẽ tham gia vào cảnh và tuân theo định hướng 3D.

Cài đặt này không loại bỏ định dạng 3D của hình dạng: camera, ánh sáng, vật liệu và đùn vẫn được cấu hình qua [Shape.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getThreeDFormat). Nó cũng khác với việc xoay thông thường. [Shape.setRotation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#setRotation) xoay hình dạng trên mặt phẳng slide, trong khi [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setRotationAngle) điều khiển góc xoay tùy chỉnh của văn bản trong khung bao. Giữ văn bản ngoài cảnh 3D không đặt lại bất kỳ góc nào trong số đó.

Ví dụ tự chứa sau tạo một hình chữ nhật màu xanh với văn bản và sao chép nó bên cạnh hình gốc. Cả hai hình đều có cùng định dạng 3D; chỉ cài đặt văn bản khác nhau: `False` ở bên trái và `True` ở bên phải. Các góc camera tính bằng độ, và chiều cao đùn là 40 điểm. Ví dụ này lưu bản trình bày dưới dạng PPTX và hiển thị slide so sánh thành PNG với kích thước gấp đôi mặc định.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Ở bên trái, văn bản theo định hướng 3D. Ở bên phải, nó giữ phẳng và dễ đọc hơn. Cả hai hình chữ nhật đều giữ cùng độ đùn và định hướng 3D hiển thị.

![Hai hình chữ nhật 3D cạnh nhau: văn bản theo định hướng 3D ở bên trái và giữ phẳng ở bên phải](keep_text_flat.png)

## **Hành vi Xuất và Hiển thị**

Aspose.Slides giữ định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi hiển thị hoặc xuất ra các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào đầu ra như một kết quả 2D. Điều này áp dụng khi bạn hiển thị slide thành [PNG](/slides/vi/python-java/convert-powerpoint-to-png/), xuất ra [PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/), xuất ra [HTML](/slides/vi/python-java/convert-powerpoint-to-html/), hoặc tạo khung cho [video conversion](/slides/vi/python-java/convert-powerpoint-to-video/).

Hãy nhớ những điểm sau:

- Hình ảnh và PDF đã xuất không tương tác. Đối tượng không thể được người xem xoay sau khi xuất.
- Giao diện cuối cùng phụ thuộc vào sự kết hợp của camera, bộ ánh sáng, vật liệu, đùn, tô màu và tỷ lệ slide.
- Nếu cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên giao diện, đọc [thuộc tính hình dạng hiệu quả](/slides/vi/python-java/shape-effective-properties/).
- Một số định dạng đầu ra không thể lưu định dạng 3D có thể chỉnh sửa của PowerPoint. Trong các định dạng đó, kết quả trực quan được hiển thị thay vì được lưu như cài đặt 3D có thể chỉnh sửa.

## **FAQ**

**Aspose.Slides có thể tạo bản trình bày 3D tương tác không?**

Aspose.Slides tạo và hiển thị các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML đã xuất trở thành các cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

**Sự khác nhau giữa mô hình 3D và hiệu ứng 3D là gì?**

Một mô hình 3D là một đối tượng 3D riêng được chèn vào bản trình bày. Một hiệu ứng 3D là định dạng được áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, như xoay, đùn, bevel, ánh sáng và vật liệu. Bài viết này đề cập đến các hiệu ứng 3D.

**Cài đặt nào cần thiết cho một hình 3D có thể nhìn thấy?**

Ít nhất, cần đặt xoay camera và một trong hai: đùn hoặc độ sâu. Thực tế, cũng cần đặt bộ ánh sáng và vật liệu để các mặt được hiển thị có điểm sáng và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**

Có. Sử dụng [Shape.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getThreeDFormat) cho phần thân hình dạng và [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#getThreeDFormat) cho văn bản.

**Các hiệu ứng 3D có xuất hiện khi xuất sang hình ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides hiển thị các hiệu ứng 3D khi tạo hình ảnh slide, xuất ra PDF, xuất ra HTML và tạo khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa giao diện đã hiển thị, không phải đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi kế thừa và cài đặt giao diện được áp dụng không?**

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [thuộc tính hình dạng hiệu quả](/slides/vi/python-java/shape-effective-properties/) để đọc camera cuối cùng, bộ ánh sáng, bevel và các giá trị 3D liên quan.