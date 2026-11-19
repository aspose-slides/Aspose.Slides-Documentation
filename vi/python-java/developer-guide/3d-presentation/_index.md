---
title: Tạo hiệu ứng 3D trong bài thuyết trình bằng Python
linktitle: Bài thuyết trình 3D
type: docs
weight: 232
url: /vi/python-java/3d-presentation/
keywords:
- PowerPoint 3D
- bài thuyết trình 3D
- quay 3D
- độ sâu 3D
- đùn 3D
- gradient 3D
- văn bản 3D
- PowerPoint
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Áp dụng và render các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong Python qua Java với Aspose.Slides. Cấu hình máy ảnh, ánh sáng, vật liệu, độ đùn, màu nền và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides for Python via Java có thể tạo, chỉnh sửa, bảo tồn và hiển thị định dạng 3D kiểu PowerPoint cho các hình dạng và văn bản. Bài viết này bao gồm các hiệu ứng 3D như quay, đùn, cạnh vát, chiếu sáng, vật liệu, đổ màu gradient hoặc hình ảnh, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này đề cập đến các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không liên quan đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ chuyển các hiệu ứng 3D này thành kết quả 2D đã xuất.
{{% /alert %}}

## **Các khái niệm định dạng 3D**

Sử dụng phương thức [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) để áp dụng định dạng 3D cho một hình dạng. Phương thức này trả về [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/), bộ điều khiển cảnh 3D cho hình đó.

Đối với văn bản, sử dụng phương thức [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Điều này áp dụng định dạng 3D cho khung văn bản thay vì thân hình.

Những thành viên API quan trọng nhất là:

| Thành viên API | Kiểm soát gì | Khi nào nên dùng |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | Góc nhìn, loại máy ảnh cài sẵn, quay, phóng to và phối cảnh. | Quay đối tượng trong không gian 3D hoặc khớp với một thiết lập quay 3D của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | Cài đặt ánh sáng, hướng và góc quay ánh sáng. | Thay đổi cách bóng nổi và bóng đổ xuất hiện trên bề mặt 3D. |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) và [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | Vật liệu bề mặt, như phẳng, mờ, nhựa hoặc kim loại. | Làm cho cùng hình dạng trông phẳng hơn, mềm hơn, bóng hơn hoặc kim loại hơn. |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) và [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Khoảng cách mà hình mở rộng ra phía sau mặt trước. | Biến một hình phẳng thành một đối tượng 3D dày nhìn thấy được. |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | Màu của các mặt bên được đùn ra. | Làm cho độ sâu hiển thị hoặc phối màu mặt bên với màu nền mặt trước. |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) và [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | Độ sâu 3D bổ sung được PowerPoint sử dụng. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt bevel và vật liệu. |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) và [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | Các cạnh nâng lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm cạnh mềm hoặc đúc thay vì mặt phẳng sắc nét. |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) và [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) và [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | Đường viền quanh đối tượng 3D. | Nhấn mạnh biên giới đối tượng trong kết quả render. |

## **Tạo một hình 3D**

Một hình thường cần bốn loại cài đặt trước khi trông thật sự 3D:

- Cài đặt máy ảnh, vì góc nhìn mặt trước mặc định có thể ẩn phần đùn.
- Cài đặt ánh sáng, vì chiếu sáng làm cho các mặt và cạnh có thể nhìn thấy.
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được render.
- Cài đặt độ đùn hoặc độ sâu, vì một hình phẳng cần độ dày.

Ví dụ sau tạo một hình chữ nhật, thêm văn bản vào mặt trước và áp dụng định dạng 3D. Giá trị quay máy ảnh được tính bằng độ, và độ cao đùn là 100 điểm. Ví dụ này render slide thành ảnh PNG có kích thước gấp đôi so với mặc định và lưu bản trình bày dưới dạng PPTX.

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

Hình ảnh slide được render hiển thị hình chữ nhật như một khối 3D dày:

![Hình chữ nhật 3D xanh được render với văn bản 3D trắng trên mặt trước](img_01_01.png)

## **Xoay một hình bằng máy ảnh**

Trong PowerPoint, việc quay 3D được cấu hình từ bảng 3-D Rotation. Các giá trị quay X, Y và Z tương ứng với quay bạn thiết lập qua API máy ảnh.

![Bảng 3-D Rotation của PowerPoint với các giá trị quay X, Y và Z được đánh dấu](img_02_01.png)

Trong Aspose.Slides, truy cập máy ảnh qua [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera). Ví dụ này tạo một hình chữ nhật, chọn góc nhìn mặt trước orthographic, và đặt các góc quay X, Y, Z thành 20, 30 và 40 độ tương ứng. Nó cấu hình hình trong bộ nhớ mà không lưu file:

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

Sử dụng máy ảnh khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide. Nó thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides sử dụng khi render.

### **Sao chép định hướng máy ảnh từ một hình mẫu**

Để khớp định hướng của một hình mẫu, đọc cài đặt máy ảnh sẵn có của nó bằng [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) và các góc quay bằng [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation). Ví dụ mở `template.pptx` và sao chép định hướng máy ảnh từ hình đầu tiên trên slide đầu tiên sang hình thứ hai. Cả hai hình đều đã có ánh sáng 3D, và hình thứ hai không có góc quay máy ảnh rõ ràng.

Các góc được tính bằng độ. Chỉ số `0` là vĩ độ, chỉ số `1` là kinh độ, và chỉ số `2` là vòng quay. Gửi chúng tới [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) theo thứ tự đó. Nếu nguồn trả về `None`, nó không có góc quay rõ ràng, vì vậy để các góc của hình thứ hai không đặt. Một góc quay rõ ràng `(0, 0, 0)` trả về ba số 0 và nên được sao chép.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Khi bạn mở lại `camera-copy.pptx` trong PowerPoint, mũi tên bên phải có cùng cài đặt máy ảnh và góc quay như hình chữ nhật bên trái. Cả hai hình đều sử dụng cùng ánh sáng và độ sâu đùn.

![Một hình chữ nhật 3D xanh và một mũi tên hướng phải có định hướng máy ảnh phù hợp, được nhìn từ trên và bên phải](camera-orientation.png)

## **Thêm Độ đùn và Độ sâu**

Đùn làm cho một hình trông dày hơn bằng cách kéo dài nó phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu đặt độ dày nhìn thấy này, và điều khiển màu đặt màu cho các mặt bên.

![Các điều khiển độ sâu của PowerPoint được ánh xạ tới thuộc tính màu đùn và độ cao đùn](img_02_02.png)

Sử dụng [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) để đặt độ dày và [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) để truy cập màu mặt bên. Ví dụ này cho một hình chữ nhật độ đùn 100 điểm với các mặt bên màu tím và quay máy ảnh để hiển thị độ dày. Nó cấu hình hình trong bộ nhớ mà không lưu file:

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

Phương thức [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) đặt độ sâu cho một hình 3D. Phương thức [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) kiểm soát độ cao của hiệu ứng đùn, như trong ví dụ này.

## **Sử dụng Đổ màu Gradient hoặc Hình ảnh với Hiệu ứng 3D**

Định dạng 3D độc lập với việc đổ màu hình dạng. Bạn có thể áp dụng màu đặc, gradient, họa tiết hoặc đổ ảnh lên mặt trước và vẫn sử dụng cùng cài đặt máy ảnh, ánh sáng, vật liệu và độ đùn.

Ví dụ này áp dụng gradient từ xanh đến cam lên mặt trước và màu cam đậm cho độ đùn 150 điểm. Các điểm dừng gradient tại 0 và 100 đánh dấu bắt đầu và kết thúc gradient. Giá trị quay máy ảnh tính bằng độ. Slide được render thành ảnh PNG có kích thước gấp đôi mặc định:

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

Kết quả render giữ gradient trên mặt trước và render độ đùn riêng biệt:

![Hình chữ nhật 3D được render với đổ màu gradient xanh đến cam và độ đùn màu cam](img_02_03.png)

Để sử dụng đổ ảnh thay thế, thêm ảnh vào bản trình bày và chỉ định cho việc đổ hình dạng. Ví dụ này yêu cầu một tệp tồn tại tên "image.jpg" trong thư mục làm việc. Nó kéo dài ảnh để lấp đầy hình chữ nhật, áp dụng độ đùn 150 điểm, và đặt quay máy ảnh tính bằng độ. Nó cấu hình hình trong bộ nhớ mà không lưu hoặc render file:

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

Hình ảnh được render trên mặt trước, trong khi độ đùn được render như bề mặt bên 3D:

![Hình chữ nhật 3D được render với đổ ảnh trên mặt trước và độ đùn màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D của hình ảnh hưởng đến thân hình. Định dạng 3D của văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt, nơi các ký tự cần độ đùn, vật liệu, ánh sáng và cài đặt máy ảnh.

Ví dụ sau tạo văn bản với họa tiết lưới cam và trắng, áp dụng độ cong lên phía trên, và cấu hình cài đặt 3D qua [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Độ cao và độ sâu đùn tính bằng điểm, và góc quay ánh sáng tính bằng độ. Đổ màu và viền của hình được ẩn để chỉ hiển thị văn bản. Ví dụ render ảnh PNG có kích thước gấp đôi so với slide mặc định và lưu bản trình bày dưới dạng PPTX:

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

![Văn bản 3D được render với biến đổi WordArt cong, đổ họa tiết cam, và độ đùn tối](img_02_05.png)

## **Giữ Văn bản Phẳng trên Hình 3D**

Để giữ cho văn bản dễ đọc trong khi vẫn duy trì vẻ ngoài 3D của hình, gọi [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) qua [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat). Khi giá trị là `True`, văn bản nằm ngoài cảnh 3D. Khi là `False`, văn bản tham gia vào cảnh và tuân theo định hướng 3D.

Cài đặt này không loại bỏ định dạng 3D của hình: máy ảnh, ánh sáng, vật liệu và độ đùn vẫn được cấu hình qua [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat). Nó cũng khác với việc quay thông thường. [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) quay hình trên mặt phẳng slide, trong khi [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) kiểm soát góc quay tùy chỉnh của văn bản trong khung giới hạn của nó. Giữ văn bản ngoài cảnh 3D không đặt lại bất kỳ góc nào trong số đó.

Ví dụ tự chứa sau tạo một hình chữ nhật xanh với văn bản và sao chép nó bên cạnh bản gốc. Cả hai hình đều có cùng định dạng 3D; chỉ cài đặt văn bản khác nhau: `False` ở bên trái và `True` ở bên phải. Các góc máy ảnh tính bằng độ, và độ cao đùn là 40 điểm. Ví dụ lưu bản trình bày dưới dạng PPTX và render slide so sánh thành PNG có kích thước gấp đôi mặc định.

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

Bên trái, văn bản theo định hướng 3D. Bên phải, nó giữ phẳng và dễ đọc hơn. Cả hai hình chữ nhật đều giữ cùng độ đùn nhìn thấy và định hướng 3D.

![Hai hình chữ nhật 3D cạnh nhau: văn bản theo định hướng 3D bên trái và giữ phẳng bên phải](keep_text_flat.png)

## **Xuất và Hành vi Render**

Aspose.Slides giữ định dạng 3D khi lưu vào các định dạng PowerPoint như PPTX. Khi render hoặc xuất sang các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn render slide thành [PNG](/slides/vi/python-java/convert-powerpoint-to-png/), xuất sang [PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/), xuất sang [HTML](/slides/vi/python-java/convert-powerpoint-to-html/), hoặc tạo khung cho [video conversion](/slides/vi/python-java/convert-powerpoint-to-video/).

Nhớ các điểm sau:

- Các hình ảnh và PDF đã xuất không tương tác. Đối tượng không thể được người xem quay sau khi xuất.
- Ngoại hình cuối cùng phụ thuộc vào sự kết hợp của máy ảnh, hệ thống ánh sáng, vật liệu, độ đùn, màu nền và tỉ lệ slide.
- Nếu bạn cần kiểm tra các giá trị định dạng kế thừa hoặc dựa trên giao diện, đọc [thuộc tính hình dạng hiệu quả](/slides/vi/python-java/shape-effective-properties/).
- Một số định dạng đầu ra không thể lưu định dạng 3D PowerPoint có thể chỉnh sửa. Trong các định dạng đó, kết quả hình ảnh được render thay vì được giữ dưới dạng cài đặt 3D có thể chỉnh sửa.

## **FAQ**

**Aspose.Slides có thể tạo các bài trình bày 3D tương tác không?**

Aspose.Slides tạo và render các hiệu ứng 3D của PowerPoint cho hình và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML được xuất ra trở thành các cảnh 3D tương tác mà người xem có thể quay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint nếu định dạng hỗ trợ.

**Khác biệt giữa mô hình 3D và hiệu ứng 3D là gì?**

Một mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bài thuyết trình. Một hiệu ứng 3D là định dạng được áp dụng lên một hình dạng hoặc văn bản PowerPoint thông thường, như quay, đùn, bevel, ánh sáng và vật liệu. Bài viết này đề cập đến các hiệu ứng 3D.

**Các cài đặt nào cần thiết cho một hình 3D có thể nhìn thấy?**

Ở mức tối thiểu, thiết lập góc quay máy ảnh và hoặc độ đùn hoặc độ sâu. Thực tế, cũng nên thiết lập hệ thống ánh sáng và vật liệu để các mặt được render có điểm sáng và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình và văn bản không?**

Có. Dùng [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) cho thân hình và [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) cho văn bản.

**Các hiệu ứng 3D có xuất hiện khi xuất sang hình ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides render các hiệu ứng 3D khi tạo ảnh slide, PDF, HTML và các khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa giao diện đã render, không phải đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi kế thừa và cài đặt giao diện được áp dụng không?**

Có. Sử dụng các API định dạng hiệu quả được mô tả trong [Thuộc tính Hình dạng Hiệu quả](/slides/vi/python-java/shape-effective-properties/) để đọc các giá trị cuối cùng của máy ảnh, hệ thống ánh sáng, bevel và các giá trị 3D liên quan.