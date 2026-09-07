---
title: Tạo Hiệu Ứng 3D trong Bản Trình Chiếu Sử Dụng Python
linktitle: Bản Trình Chiếu 3D
type: docs
weight: 232
url: /vi/python-java/3d-presentation/
keywords:
- PowerPoint 3D
- Bản trình chiếu 3D
- Xoay 3D
- Độ sâu 3D
- Đùn 3D
- Độ chuyển màu 3D
- Văn bản 3D
- PowerPoint
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Áp dụng và render các hiệu ứng 3D cho các hình dạng và văn bản PowerPoint trong Python thông qua Java với Aspose.Slides. Cấu hình camera, ánh sáng, vật liệu, đùn, nền và văn bản 3D."
---
## **Tổng quan**

Aspose.Slides cho Python thông qua Java có thể tạo, chỉnh sửa, bảo tồn và hiển thị định dạng 3D kiểu PowerPoint cho các hình dạng và văn bản. Bài viết này đề cập đến các hiệu ứng 3D như quay, đùn, góc cạnh, chiếu sáng, vật liệu, độ chuyển màu hoặc ảnh nền, và văn bản 3D.

{{% alert color="info" title="Note" %}}
Bài viết này nói về các hiệu ứng định dạng 3D trên các hình dạng và văn bản trong PowerPoint. Nó không liên quan đến việc chèn hoặc chỉnh sửa các tệp mô hình 3D độc lập. Khi bạn xuất một slide thành hình ảnh, PDF hoặc HTML, Aspose.Slides sẽ hiển thị các hiệu ứng 3D đó trong kết quả 2D đã xuất.
{{% /alert %}}

Cài đặt gói theo hướng dẫn trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ nhập `asposeslides`, khởi động JVM nếu cần, và sau đó nhập API. Ví dụ về ảnh nền yêu cầu một tệp `image.jpg` trong thư mục làm việc.

## **Khái niệm Định dạng 3D**

Sử dụng [Shape.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getThreeDFormat) để áp dụng định dạng 3D cho một hình dạng. Đối tượng định dạng trả về điều khiển cảnh 3D cho hình đó.

Đối với văn bản, sử dụng [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#getThreeDFormat). Điều này áp dụng định dạng 3D cho khung văn bản thay vì thân hình dạng.

Các thành viên API quan trọng nhất là:

| Thành viên API | Điều khiển gì | Khi nào sử dụng |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getCamera) | Góc nhìn, loại camera được đặt trước, quay, thu phóng và phối cảnh. | Xoay đối tượng trong không gian 3D hoặc khớp với một cài đặt quay 3D của PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getLightRig) | Cài đặt ánh sáng, hướng và quay ánh sáng. | Thay đổi cách các điểm nổi bật và bóng đổ xuất hiện trên bề mặt 3D. |
| [getMaterial](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getMaterial) và [setMaterial](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#setMaterial) | Vật liệu bề mặt, như phẳng, mờ, nhựa hoặc kim loại. | Làm cho cùng hình dạng trông phẳng hơn, mềm hơn, bóng hoặc kim loại. |
| [getExtrusionHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getExtrusionHeight) và [setExtrusionHeight](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Khoảng cách mà hình dạng mở rộng ra phía sau mặt trước. | Biến một hình dạng phẳng thành một đối tượng 3D dày có thể nhìn thấy. |
| [getExtrusionColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getExtrusionColor) | Màu của các mặt bên được đùn ra. | Làm cho độ sâu hiển thị hoặc đồng bộ màu mặt bên với màu nền phía trước. |
| [getDepth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getDepth) và [setDepth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#setDepth) | Độ sâu 3D bổ sung được PowerPoint sử dụng trong định dạng 3D. | Tinh chỉnh độ sâu cho hình dạng hoặc văn bản, đặc biệt khi kết hợp với cài đặt góc cạnh và vật liệu. |
| [getBevelTop](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getBevelTop) và [getBevelBottom](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getBevelBottom) | Các cạnh nâng lên hoặc bo tròn trên mặt trước và mặt sau. | Thêm một cạnh mềm mại hoặc được đúc thay vì mặt phẳng nhọn. |
| [getContourColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getContourWidth), và [setContourWidth](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#setContourWidth) | Đường viền quanh đối tượng 3D. | Nhấn mạnh ranh giới của đối tượng trong kết quả hiển thị. |

## **Tạo Hình 3D**

Một hình dạng thường cần bốn loại thiết lập trước khi trông thực sự 3D:

- Cài đặt camera, vì góc nhìn mặc định phía trước có thể ẩn phần đùn.  
- Cài đặt ánh sáng, vì ánh sáng làm cho các mặt và bên cạnh có thể quan sát được.  
- Cài đặt vật liệu, vì bề mặt ảnh hưởng đến cách ánh sáng được hiển thị.  
- Cài đặt đùn hoặc độ sâu, vì một hình phẳng cần độ dày.

Ví dụ dưới đây tạo một hình chữ nhật, thêm văn bản vào mặt trước, áp dụng định dạng 3D, lưu bản trình chiếu dưới dạng PPTX và tạo ảnh PNG cho slide.

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

![Hình chữ nhật 3D màu xanh được render với văn bản 3D màu trắng trên mặt trước](img_01_01.png)

## **Xoay Hình bằng Camera**

Trong PowerPoint, việc quay 3D được cấu hình từ bảng 3-D Rotation. Các giá trị quay X, Y và Z tương ứng với việc quay bạn thiết lập qua API camera.

![Bảng 3-D Rotation của PowerPoint với các giá trị quay X, Y và Z được làm nổi bật](img_02_01.png)

Trong Aspose.Slides, đặt loại camera và quay qua định dạng 3D trả về bởi [Shape.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getThreeDFormat):

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

Sử dụng camera khi bạn cần thay đổi cách người xem nhìn đối tượng. Nó không thay đổi hình học 2D của hình trên slide. Nó thay đổi góc nhìn 3D mà PowerPoint và Aspose.Slides sử dụng khi render.

## **Thêm Đùn và Độ sâu**

Đùn làm cho một hình dạng trông dày hơn bằng cách mở rộng nó ra phía sau mặt trước. Trong PowerPoint, điều khiển độ sâu đặt độ dày nhìn thấy này, và điều khiển màu đặt màu cho các mặt bên.

![Các điều khiển độ sâu của PowerPoint được ánh xạ tới các thuộc tính màu đùn và chiều cao đùn](img_02_02.png)

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

Sử dụng cài đặt độ sâu khi bạn cần làm việc trực tiếp với giá trị độ sâu của PowerPoint hoặc kết hợp độ sâu với góc cạnh, vật liệu và hiệu ứng văn bản. Trong nhiều trường hợp hình dạng, chiều cao đùn là thiết lập rõ ràng hơn vì nó diễn đạt trực tiếp độ đùn hiển thị.

## **Sử dụng Độ chuyển màu hoặc Ảnh nền với Hiệu ứng 3D**

Định dạng 3D độc lập với nền hình. Bạn có thể áp dụng màu đặc, độ chuyển màu, hoa văn hoặc ảnh nền cho mặt trước và vẫn sử dụng cùng một camera, ánh sáng, vật liệu và cài đặt đùn.

Ví dụ này áp dụng độ chuyển màu cho hình và màu đùn tối hơn cho các mặt bên:

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

![Hình chữ nhật 3D được render với độ chuyển màu xanh đến cam và phần đùn màu cam](img_02_03.png)

Để sử dụng ảnh nền thay thế, thêm ảnh vào bản trình chiếu và gán nó cho nền hình:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

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

![Hình chữ nhật 3D được render với ảnh nền trên mặt trước và phần đùn màu cam](img_02_04.png)

## **Áp dụng Định dạng 3D cho Văn bản**

Định dạng 3D của hình ảnh ảnh hưởng đến thân hình, trong khi định dạng 3D của văn bản ảnh hưởng đến khung văn bản. Điều này hữu ích cho các hiệu ứng kiểu WordArt nơi các ký tự cần đùn, vật liệu, ánh sáng và cài đặt camera.

Ví dụ dưới đây tạo văn bản với nền hoa văn, áp dụng biến đổi WordArt, và cấu hình các cài đặt 3D trên [TextFrameFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/):

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

![Văn bản 3D được render với biến đổi WordArt cong, độ chuyển màu họa tiết cam, và phần đùn tối màu](img_02_05.png)

## **Hành vi Xuất và Render**

Aspose.Slides bảo tồn định dạng 3D khi lưu dưới các định dạng PowerPoint như PPTX. Khi render hoặc xuất sang các định dạng bố cục cố định, cảnh 3D được raster hoá hoặc vẽ vào đầu ra dưới dạng kết quả 2D. Điều này áp dụng khi bạn render slide thành PNG, xuất ra PDF, xuất ra HTML, hoặc tạo khung cho việc chuyển đổi video.

- Các hình ảnh và PDF đã xuất không tương tác. Đối tượng không thể được người xem xoay sau khi xuất.  
- Giao diện cuối cùng phụ thuộc vào sự kết hợp của camera, bộ ánh sáng, vật liệu, đùn, nền và tỷ lệ slide.  
- Nếu bạn cần kiểm tra các giá trị định dạng được kế thừa hoặc dựa trên giao diện, hãy sử dụng API định dạng hiệu quả.  
- Một số định dạng đầu ra không thể lưu trữ định dạng 3D có thể chỉnh sửa của PowerPoint. Trong những định dạng đó, kết quả hình ảnh được render thay vì được lưu giữ dưới dạng cài đặt 3D có thể chỉnh sửa.

## **FAQ**

**Aspose.Slides có thể tạo bài thuyết trình 3D tương tác không?**

Aspose.Slides tạo và render các hiệu ứng 3D của PowerPoint cho hình dạng và văn bản. Nó không làm cho các hình ảnh, PDF hoặc trang HTML xuất ra trở thành cảnh 3D tương tác mà người xem có thể xoay. Trong PPTX, định dạng 3D vẫn có thể chỉnh sửa trong PowerPoint khi định dạng hỗ trợ.

**Sự khác nhau giữa mô hình 3D và hiệu ứng 3D là gì?**

Mô hình 3D là một đối tượng 3D riêng biệt được chèn vào bản trình chiếu. Hiệu ứng 3D là định dạng được áp dụng cho một hình dạng hoặc văn bản PowerPoint thông thường, chẳng hạn quay, đùn, góc cạnh, chiếu sáng và vật liệu. Bài viết này chỉ đề cập đến hiệu ứng 3D.

**Cài đặt nào cần thiết để có một hình 3D có thể nhìn thấy?**

Ít nhất, cần đặt quay camera và either đùn hoặc độ sâu. Thực tế, cũng nên đặt bộ ánh sáng và vật liệu để các mặt được render có điểm nổi bật và bóng rõ ràng.

**Tôi có thể áp dụng hiệu ứng 3D cho cả hình dạng và văn bản không?**

Có. Sử dụng [Shape.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getThreeDFormat) cho thân hình và [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#getThreeDFormat) cho văn bản.

**Các hiệu ứng 3D có xuất hiện khi xuất sang hình ảnh, PDF, HTML hoặc khung video không?**

Có. Aspose.Slides render các hiệu ứng 3D khi tạo ảnh slide, xuất ra PDF, xuất ra HTML và tạo khung dùng cho chuyển đổi video. Đầu ra đã xuất chứa hình ảnh đã render, không phải đối tượng 3D có thể chỉnh sửa.

**Tôi có thể đọc các giá trị 3D cuối cùng sau khi đã áp dụng kế thừa và cài đặt giao diện không?**

Có. Sử dụng [ThreeDFormat.getEffective](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getEffective) để đọc camera, bộ ánh sáng, góc cạnh và các giá trị 3D liên quan cuối cùng.