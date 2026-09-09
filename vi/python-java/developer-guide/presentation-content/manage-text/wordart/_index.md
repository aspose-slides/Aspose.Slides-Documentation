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
- hiệu ứng bóng đổ
- hiệu ứng phản chiếu
- hiệu ứng phát sáng
- biến đổi WordArt
- hiệu ứng 3D
- hiệu ứng bóng đổ ngoài
- hiệu ứng bóng đổ trong
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Tạo và tùy chỉnh các hiệu ứng WordArt trong Aspose.Slides cho Python qua Java. Hướng dẫn từng bước này giúp các nhà phát triển nâng cao bản trình bày với văn bản chuyên nghiệp trong Python qua Java."
---
## **Tổng quan**

Hiệu ứng WordArt cho phép bạn thêm văn bản dạng nghệ thuật, được thiết kế đẹp mắt vào bản trình bày PowerPoint. Với Aspose.Slides, các nhà phát triển có thể tạo, tùy chỉnh và quản lý WordArt một cách lập trình, giống như trong Microsoft PowerPoint—không cần cài đặt Office. Bài viết này cung cấp tổng quan về cách làm việc với WordArt, bao gồm cách áp dụng biến đổi văn bản, kiểu tô màu, viền, bóng đổ và các tùy chọn định dạng khác để làm cho nội dung bài thuyết trình sinh động và hấp dẫn hơn. WordArt cho phép bạn xử lý văn bản như một đối tượng đồ họa. Nó bao gồm các hiệu ứng hoặc chỉnh sửa đặc biệt được áp dụng cho văn bản để làm cho nó bắt mắt hoặc dễ nhận thấy hơn.

## **Tạo mẫu WordArt đơn giản và áp dụng vào văn bản**

**Sử dụng Aspose.Slides**

Đầu tiên, chúng ta tạo một đoạn văn bản đơn giản bằng đoạn mã Python sau:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
Tiếp theo, tăng kích thước phông chữ để hiệu ứng rõ rệt hơn:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**Sử dụng Microsoft PowerPoint**

Đi tới menu hiệu ứng WordArt trong Microsoft PowerPoint:

![Menu hiệu ứng WordArt trong PowerPoint](image-20200930113926-1.png)

Từ menu bên phải, bạn có thể chọn một hiệu ứng WordArt có sẵn. Từ menu bên trái, bạn có thể chỉ định cài đặt cho WordArt mới.

Đây là một số tham số hoặc tùy chọn có sẵn:

![Các tùy chọn định dạng WordArt](image-20200930114015-3.png)

**Sử dụng Aspose.Slides**

Ở đây, chúng ta áp dụng mẫu [PatternStyle.SmallGrid](https://reference.aspose.com/slides/vi/python-java/aspose.slides/patternstyle/#SmallGrid) vào văn bản và thêm đường viền đen cho văn bản bằng đoạn mã sau:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Văn bản kết quả:

![Văn bản với mẫu tô và viền đen](image-20200930114108-4.png)

## **Áp dụng các hiệu ứng WordArt khác**

**Sử dụng Microsoft PowerPoint**

Từ giao diện của chương trình, bạn có thể áp dụng các hiệu ứng này cho văn bản, khối văn bản, hình dạng hoặc các phần tử tương tự:

![Hiệu ứng văn bản và hình dạng trong PowerPoint](image-20200930114129-5.png)

Ví dụ, các hiệu ứng Bóng đổ, Phản chiếu và Glow có thể được áp dụng cho văn bản; các hiệu ứng Định dạng 3D và Xoay 3D có thể được áp dụng cho một khối văn bản; hiệu ứng Độ mịn mềm có thể được áp dụng cho một hình dạng (hiệu ứng vẫn tồn tại khi không có hiệu ứng Định dạng 3D được thiết lập).

### **Áp dụng hiệu ứng Bóng đổ**

Đoạn mã Python dưới đây áp dụng hiệu ứng bóng đổ chỉ cho văn bản:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

API Aspose.Slides hỗ trợ ba loại bóng đổ: [OuterShadow](https://reference.aspose.com/slides/vi/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/vi/python-java/aspose.slides/innershadow/), và [PresetShadow](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presetshadow/).

Với [PresetShadow](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presetshadow/), bạn có thể áp dụng bóng đổ cho văn bản bằng các giá trị đã được định sẵn.

**Sử dụng Microsoft PowerPoint**

Trong PowerPoint, bạn chỉ có thể sử dụng một loại bóng đổ. Dưới đây là một ví dụ:

![Cài đặt bóng đổ trong PowerPoint](image-20200930114225-6.png)

**Sử dụng Aspose.Slides**

Aspose.Slides thực sự cho phép bạn áp dụng đồng thời hai loại bóng đổ: [InnerShadow](https://reference.aspose.com/slides/vi/python-java/aspose.slides/innershadow/) và [PresetShadow](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presetshadow/).

**Lưu ý:**

- Khi kết hợp [OuterShadow](https://reference.aspose.com/slides/vi/python-java/aspose.slides/outershadow/) và [PresetShadow](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presetshadow/), chỉ hiệu ứng [OuterShadow](https://reference.aspose.com/slides/vi/python-java/aspose.slides/outershadow/) được áp dụng.
- Nếu đồng thời sử dụng [OuterShadow](https://reference.aspose.com/slides/vi/python-java/aspose.slides/outershadow/) và [InnerShadow](https://reference.aspose.com/slides/vi/python-java/aspose.slides/innershadow/), hiệu ứng kết quả hay được áp dụng phụ thuộc vào phiên bản PowerPoint. Ví dụ, trong PowerPoint 2013, hiệu ứng sẽ được nhân đôi. Nhưng trong PowerPoint 2007, chỉ hiệu ứng [OuterShadow](https://reference.aspose.com/slides/vi/python-java/aspose.slides/outershadow/) được áp dụng.

### **Áp dụng Phản chiếu cho Văn bản**

Chúng tôi thêm phản chiếu vào văn bản bằng đoạn mã mẫu Python qua Java sau:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **Áp dụng Hiệu ứng Glow cho Văn bản**

Chúng tôi áp dụng hiệu ứng glow cho văn bản để làm nó tỏa sáng hoặc nổi bật hơn bằng đoạn mã sau:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

Kết quả của thao tác:

![Văn bản với hiệu ứng glow](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}

Bạn có thể thay đổi các tham số cho bóng đổ, phản chiếu và glow. Các thuộc tính của hiệu ứng được thiết lập riêng cho từng phần của văn bản.

{{% /alert %}}

### **Sử dụng Biến đổi trong WordArt**

Sử dụng [TextFrameFormat.setTransform](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframeformat/#setTransform) để biến đổi toàn bộ khối văn bản:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Kết quả:

![Văn bản với biến đổi dạng cung](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}

Cả Microsoft PowerPoint và Aspose.Slides for Python via Java đều cung cấp một số loại biến đổi đã được định sẵn.

{{% /alert %}}

**Sử dụng PowerPoint**

Để truy cập các loại biến đổi đã định sẵn, vào: **Format** -> **TextEffect** -> **Transform**

**Sử dụng Aspose.Slides**

Để chọn loại biến đổi, sử dụng liệt kê [TextShapeType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textshapetype/).

### **Áp dụng Hiệu ứng 3D cho Văn bản và Hình dạng**

Chúng tôi áp dụng hiệu ứng 3D cho một hình dạng văn bản bằng đoạn mã mẫu sau:

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
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Văn bản và hình dạng kết quả:

![Hình dạng văn bản với hiệu ứng 3D](image-20200930114816-9.png)

Chúng tôi áp dụng hiệu ứng 3D cho văn bản bằng đoạn mã Python sau:

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
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Kết quả của thao tác:

![Văn bản với hiệu ứng 3D](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}

Việc áp dụng hiệu ứng 3D cho văn bản hoặc các hình dạng của nó và tương tác giữa các hiệu ứng dựa trên một số quy tắc nhất định.

Xem xét một cảnh cho văn bản và hình dạng chứa văn bản đó. Hiệu ứng 3D bao gồm một đại diện đối tượng 3D và cảnh mà trong đó đối tượng được đặt.

- Khi cảnh được đặt cho cả hình dạng và văn bản, cảnh của hình dạng được ưu tiên—cảnh của văn bản bị bỏ qua.
- Khi hình dạng không có cảnh riêng nhưng có đại diện 3D, cảnh của văn bản sẽ được sử dụng.
- Ngược lại—khi hình dạng ban đầu không có hiệu ứng 3D—hình dạng sẽ phẳng và hiệu ứng 3D chỉ được áp dụng cho văn bản.

Các quy tắc này liên quan đến các phương thức [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getLightRig) và [ThreeDFormat.getCamera](https://reference.aspose.com/slides/vi/python-java/aspose.slides/threedformat/#getCamera).

{{% /alert %}}

## **Áp dụng Hiệu ứng Bóng đổ Ngoài cho Văn bản**

Aspose.Slides for Python via Java cung cấp các lớp [OuterShadow](https://reference.aspose.com/slides/vi/python-java/aspose.slides/outershadow/) và [InnerShadow](https://reference.aspose.com/slides/vi/python-java/aspose.slides/innershadow/) cho phép bạn áp dụng hiệu ứng bóng đổ cho văn bản trong một [TextFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/). Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy tham chiếu tới một slide bằng chỉ mục của nó.
3. Thêm một hình dạng hình chữ nhật vào slide.
4. Truy cập khung văn bản liên kết với hình dạng.
5. Tắt màu nền của hình dạng.
6. Bật hiệu ứng bóng đổ ngoài.
7. Đặt bán kính làm mờ của bóng đổ.
8. Đặt hướng của bóng đổ.
9. Đặt khoảng cách của bóng đổ.
10. Căn chỉnh bóng đổ về phía trên bên trái.
11. Đặt màu bóng đổ thành màu đen.
12. Ghi bản trình bày dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/).

Mã mẫu Python via Java—thực hiện các bước trên—cho thấy cách áp dụng hiệu ứng bóng đổ ngoài cho văn bản:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Lấy tham chiếu của slide
    slide = presentation.getSlides().get_Item(0)

    # Thêm một AutoShape dạng Hình chữ nhật
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # Thêm TextFrame vào Hình chữ nhật
    auto_shape.addTextFrame("Aspose TextBox")

    # Tắt màu nền của hình dạng trong trường hợp muốn lấy bóng đổ của văn bản
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Thêm bóng đổ ngoài và đặt tất cả các tham số cần thiết
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # Ghi bản trình bày vào đĩa
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Áp dụng Hiệu ứng Bóng đổ Trong cho Hình dạng**

Thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy tham chiếu tới slide.
3. Thêm một hình dạng hình chữ nhật.
4. Bật hiệu ứng bóng đổ trong.
5. Đặt tất cả các tham số cần thiết.
6. Đặt kiểu màu bóng đổ để sử dụng màu chủ đề.
7. Đặt màu chủ đề.
8. Ghi bản trình bày dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/).

Mã mẫu này (dựa trên các bước trên) cho thấy cách áp dụng hiệu ứng bóng đổ trong cho văn bản trong một hình dạng bằng Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # Lấy tham chiếu của slide
    slide = presentation.getSlides().get_Item(0)

    # Thêm một AutoShape dạng Hình chữ nhật
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Thêm TextFrame vào Hình chữ nhật
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # Bật InnerShadowEffect
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # Đặt tất cả các tham số cần thiết
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # Đặt ColorType là Scheme
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Đặt Scheme Color
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # Lưu bản trình bày
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể sử dụng hiệu ứng WordArt với các phông chữ hoặc ký tự khác nhau (ví dụ: Ả Rập, Trung Quốc) không?**

Có, Aspose.Slides hỗ trợ Unicode và hoạt động với mọi phông chữ và ký tự chính. Các hiệu ứng WordArt như bóng đổ, tô màu và viền có thể được áp dụng bất kể ngôn ngữ, mặc dù việc có sẵn và hiển thị phông chữ có thể phụ thuộc vào phông chữ hệ thống.

**Tôi có thể áp dụng hiệu ứng WordArt cho các thành phần trong master slide không?**

Có, bạn có thể áp dụng hiệu ứng WordArt cho các hình dạng trên master slide, bao gồm các khung tiêu đề, chân trang hoặc văn bản nền. Các thay đổi trên bố cục master sẽ được phản ánh trên tất cả các slide liên quan.

**Hiệu ứng WordArt có ảnh hưởng đến kích thước tệp của bản trình bày không?**

Có chút ảnh hưởng. Các hiệu ứng WordArt như bóng đổ, glow và tô gradient có thể làm tăng nhẹ kích thước tệp do thêm siêu dữ liệu định dạng, nhưng sự chênh lệch thường là không đáng kể.

**Tôi có thể xem trước kết quả của hiệu ứng WordArt mà không lưu bản trình bày không?**

Có, bạn có thể render các slide chứa WordArt thành ảnh (ví dụ: PNG, JPEG) bằng [Shape.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage) hoặc [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage). Điều này cho phép bạn xem trước kết quả trong bộ nhớ hoặc trên màn hình trước khi lưu hoặc xuất bản trình bày đầy đủ.