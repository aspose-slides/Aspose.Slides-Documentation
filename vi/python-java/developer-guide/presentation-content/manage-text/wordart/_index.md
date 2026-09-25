---
title: Tạo và áp dụng hiệu ứng WordArt trong Python qua Java
linktitle: WordArt
type: docs
weight: 110
url: /vi/python-java/wordart/
keywords:
- WordArt
- tạo WordArt
- mẫu WordArt
- hiệu ứng WordArt
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng phát sáng
- biến đổi WordArt
- hiệu ứng 3D
- hiệu ứng bóng ngoài
- hiệu ứng bóng trong
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh các hiệu ứng WordArt trong Aspose.Slides cho Python qua Java. Hướng dẫn từng bước này giúp các nhà phát triển nâng cao bản trình bày với văn bản chuyên nghiệp trong Python qua Java."
---
## **Tổng quan**

Các hiệu ứng WordArt cho phép bạn tạo kiểu cho văn bản với các màu nền, viền, bóng, phản chiếu, ánh sáng phát sáng, biến đổi và định dạng 3D. Bài viết này giải thích cách tạo và tùy chỉnh các hiệu ứng này trong bản trình bày PowerPoint bằng Aspose.Slides for Python via Java, mà không cần cài đặt Microsoft Office.

## **Tạo mẫu WordArt đơn giản và áp dụng nó vào văn bản**

Các ví dụ sau tạo một kiểu WordArt đơn giản bằng cách thiết lập văn bản, phông chữ, đầy mẫu và viền.

Mỗi ví dụ tạo một bài thuyết trình mới và thêm một hình chữ nhật vào slide đầu tiên; không cần tệp đầu vào. Ví dụ đầu tiên đặt văn bản là "Aspose.Slides". Vị trí và kích thước của hình được đo bằng điểm:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```

Đặt phông chữ thành Arial Black kích thước 36 điểm để làm nổi bật định dạng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)
finally:
    presentation.dispose()
```

Áp dụng mẫu [SmallGrid](https://reference.aspose.com/slides/vi/python-java/aspose.slides/patternstyle/#SmallGrid) với màu nền trước cam đậm và nền trắng, sau đó thêm viền văn bản màu đen với độ rộng 1 điểm:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    dark_orange = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(dark_orange)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid)

    portion.getPortionFormat().getLineFormat().setWidth(1)
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Văn bản kết quả:

![The simple WordArt template](WordArt_template.png)

## **Áp dụng các hiệu ứng WordArt khác**

Các ví dụ sau minh họa cách áp dụng bóng, phản chiếu, phát sáng, biến đổi và hiệu ứng 3D vào văn bản.

### **Áp dụng hiệu ứng bóng bên ngoài**

Bóng bên ngoài tạo độ sâu bằng cách đặt bóng phía sau văn bản. Bạn có thể tùy chỉnh màu, hướng, khoảng cách, bán kính mờ, tỉ lệ và độ nghiêng của nó.

Ví dụ này gọi enableOuterShadowEffect và thiết lập một bóng đen với bán kính mờ 4 điểm, hướng 230 độ và khoảng cách 30 điểm. Giá trị tỉ lệ 100 giữ nguyên kích thước bóng, trong khi độ nghiêng ngang nghiêng bóng 20 độ. Biến đổi alpha đặt độ mờ của nó ở mức 32%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect()
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Văn bản kết quả:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Khi bóng ngoài và bóng dựng sẵn được sử dụng đồng thời, chỉ bóng ngoài được áp dụng.
- Nếu bóng ngoài và bóng trong được sử dụng cùng lúc, hiệu ứng kết quả phụ thuộc vào phiên bản PowerPoint. Ví dụ, trong PowerPoint 2013, hiệu ứng được nhân đôi, trong khi trong PowerPoint 2007, chỉ bóng ngoài được áp dụng.
{{% /alert %}}

### **Áp dụng hiệu ứng phản chiếu**

Phản chiếu tạo một bản sao phản chiếu của văn bản. Điều chỉnh vị trí, tỉ lệ, độ mờ và độ trong suốt để kiểm soát diện mạo của nó.

Ví dụ này gọi enableReflectionEffect và lật phản chiếu theo chiều dọc với tỉ lệ -100%. Nó sử dụng bán kính mờ 0.5 điểm và khoảng cách 4.72 điểm. Độ trong suốt giảm từ 60% xuống 0.9% giữa các vị trí 0% và 60% dọc theo phản chiếu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect()
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

Văn bản kết quả:

![The Reflection effect](reflection_effect.png)

### **Áp dụng hiệu ứng phát sáng**

Phát sáng thêm một viền màu nhẹ xung quanh văn bản. Điều chỉnh màu, độ trong suốt và bán kính để kiểm soát hiệu ứng.

Ví dụ này gọi enableGlowEffect và áp dụng phát sáng màu đỏ với độ trong suốt 54% và bán kính 7 điểm:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableGlowEffect()
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7)
finally:
    presentation.dispose()
```

Văn bản kết quả:

![The Glow effect](glow_effect.png)

### **Áp dụng các biến đổi WordArt**

Biến đổi WordArt uốn cong, kéo dài hoặc biến dạng một khối văn bản.

Đặt setTransform thành ArchUpPour để uốn cong toàn bộ khung văn bản lên phía trên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")
    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Văn bản kết quả:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java cung cấp một tập hợp các loại biến đổi được định sẵn [transformation types](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Áp dụng hiệu ứng 3D cho hình dạng và văn bản**

Bạn có thể áp dụng hiệu ứng 3D cho một hình dạng hoặc cho văn bản của nó. Các góc vát, độ nhô, chiếu sáng và cài đặt máy ảnh kiểm soát diện mạo kết quả.

Ví dụ sau sử dụng ThreeDFormat để thêm các góc vát tròn, độ nhô màu cam và viền màu đỏ đậm vào hình chữ nhật. Kích thước góc vát, chiều cao độ nhô, độ rộng viền và độ sâu được đo bằng điểm. Vật liệu nhựa, ánh sáng cân bằng quay 40 độ quanh trục Z, và máy ảnh phối cảnh xác định diện mạo của nó:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    auto_shape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelBottom().setHeight(10.5)
    auto_shape.getThreeDFormat().getBevelBottom().setWidth(10.5)

    auto_shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelTop().setHeight(12.5)
    auto_shape.getThreeDFormat().getBevelTop().setWidth(11)

    orange = Color(255, 165, 0)
    auto_shape.getThreeDFormat().getExtrusionColor().setColor(orange)
    auto_shape.getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    auto_shape.getThreeDFormat().getContourColor().setColor(dark_red)
    auto_shape.getThreeDFormat().setContourWidth(1.5)

    auto_shape.getThreeDFormat().setDepth(3)

    auto_shape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    auto_shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    auto_shape.getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Hình dạng kết quả:

![The shape 3D effect](shape_3D_effect.png)

Ví dụ này áp dụng định dạng 3D tương tự cho văn bản thông qua TextFrameFormat.getThreeDFormat. Các góc vát nhỏ hơn tạo hình các cạnh chữ, trong khi độ nhô và ánh sáng tạo độ sâu cho văn bản:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5)

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4)

    orange = Color(255, 165, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange)
    text_frame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(dark_red)
    text_frame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5)

    text_frame.getTextFrameFormat().getThreeDFormat().setDepth(3)

    text_frame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    text_frame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Văn bản kết quả:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Việc áp dụng hiệu ứng 3D cho văn bản hoặc các hình dạng của chúng — và tương tác giữa các hiệu ứng này — được điều chỉnh bởi các quy tắc cụ thể. Hãy xem xét một cảnh bao gồm cả văn bản và hình dạng chứa nó. Một hiệu ứng 3D bao gồm đại diện 3D của đối tượng và cảnh mà nó được đặt trong.

- Nếu một cảnh được đặt cho cả hình dạng và văn bản, cảnh của hình dạng được ưu tiên và cảnh của văn bản bị bỏ qua.
- Nếu hình dạng không có cảnh riêng nhưng có đại diện 3D, thì cảnh của văn bản được sử dụng.
- Nếu hình dạng không có hiệu ứng 3D nào, nó được xem là phẳng, và hiệu ứng 3D chỉ được áp dụng cho văn bản.

Các hành vi này liên quan đến các phương thức ThreeDFormat.getLightRig và ThreeDFormat.getCamera.
{{% /alert %}}

Để giữ văn bản phẳng và dễ đọc trong khi giữ định dạng 3D của hình dạng, xem [Keep Text Flat on a 3D Shape](/slides/vi/python-java/3d-presentation/) để so sánh cả hai cài đặt và một ví dụ Python đầy đủ.

## **Câu hỏi thường gặp**

**Tôi có thể sử dụng hiệu ứng WordArt với các phông chữ hoặc bảng chữ viết khác nhau (ví dụ: Ả Rập, Trung Quốc) không?**

Có, Aspose.Slides for Python via Java hỗ trợ Unicode và hoạt động với tất cả các phông chữ và bảng chữ viết chính. Các hiệu ứng WordArt như bóng, nền và viền có thể được áp dụng bất kể ngôn ngữ, tuy nhiên khả năng có sẵn của phông chữ và việc hiển thị có thể phụ thuộc vào phông chữ hệ thống.

**Tôi có thể áp dụng hiệu ứng WordArt cho các thành phần của master slide không?**

Có, bạn có thể áp dụng hiệu ứng WordArt cho các hình dạng trên master slide, bao gồm các ký hiệu tiêu đề, chân trang hoặc văn bản nền. Các thay đổi được thực hiện trên bố cục master sẽ được phản ánh trên tất cả các slide liên quan.

**Các hiệu ứng WordArt có ảnh hưởng đến kích thước tệp bản thuyết trình không?**

Một chút. Các hiệu ứng WordArt như bóng, phát sáng và nền gradient có thể làm tăng nhẹ kích thước tệp do thêm siêu dữ liệu định dạng, nhưng sự khác biệt thường không đáng kể.

**Tôi có thể xem trước kết quả của các hiệu ứng WordArt mà không lưu bản thuyết trình không?**

Có, bạn có thể kết xuất các slide chứa WordArt thành hình ảnh (ví dụ: PNG, JPEG) bằng cách sử dụng [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage), hoặc kết xuất các hình dạng riêng lẻ bằng [Shape.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage). Điều này cho phép bạn xem trước kết quả trong bộ nhớ hoặc trên màn hình trước khi lưu hoặc xuất bản thuyết trình đầy đủ.