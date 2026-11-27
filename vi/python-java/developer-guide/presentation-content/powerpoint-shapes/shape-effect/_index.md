---
title: Áp dụng hiệu ứng hình dạng trong bản trình bày bằng Python thông qua Java
linktitle: Hiệu ứng hình dạng
type: docs
weight: 30
url: /vi/python-java/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng phát sáng
- hiệu ứng cạnh mềm
- định dạng hiệu ứng
- PowerPoint
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho Python thông qua Java — tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được sử dụng để làm cho một hình dạng nổi bật, chúng khác với [đổ màu](/slides/vi/python-java/shape-formatting/#gradient-fill) hoặc đường viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan tỏa ánh sáng phát sáng của hình dạng, v.v.

![Hiệu ứng hình dạng](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số sự kết hợp của các hiệu ứng trông đẹp hơn các sự kết hợp khác. Vì lý do này, PowerPoint cung cấp các tùy chọn dưới **Preset**. Các tùy chọn Preset là sự kết hợp của hai hoặc nhiều hiệu ứng được biết là trông tốt. Bằng cách này, khi chọn một preset, bạn sẽ không phải tốn thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm một sự kết hợp hợp lý.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) cho phép bạn áp dụng cùng các hiệu ứng cho các hình dạng trong bản trình bày PowerPoint.

## **Áp dụng hiệu ứng bóng**

Aspose.Slides cho Python thông qua Java hỗ trợ bóng ngoài và bóng trong cho các hình dạng. Bạn có thể tùy chỉnh màu, hướng, khoảng cách và bán kính mờ để phù hợp với thiết kế bản trình bày của mình.

### **Áp dụng bóng ngoài**

Sử dụng bóng ngoài để làm cho một thẻ hoặc bảng nổi bật so với nền slide. Bóng mở rộng ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính mờ để phù hợp với ánh sáng và phong cách của mẫu của bạn.

Mã Python này cho thấy cách áp dụng [hiệu ứng bóng ngoài](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) vào một hình chữ nhật:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Hiệu ứng bóng](shadow_effect.png)

#### **Kiểm soát hướng bóng khi một hình dạng quay**

Mặc định, bóng ngoài quay cùng với hình dạng. Để làm cho các hình dạng có các góc quay khác nhau trông như được chiếu sáng từ cùng một hướng, gọi [setRotateShadowWithShape](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setRotateShadowWithShape) với `False` và sử dụng [setDirection](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setDirection) để đặt cùng hướng cho các bóng của chúng.

Ví dụ tạo hai mũi tên màu xanh dương với bóng màu xám lệch 42 điểm sang bên phải (0°). Sau đó sao chép slide và quay cả hai mũi tên 90° theo chiều kim đồng hồ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    before = presentation.getSlides().get_Item(0)
    
    left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60)
    left.getFillFormat().setFillType(FillType.Solid)
    left.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    left.getEffectFormat().enableOuterShadowEffect()
    shadow = left.getEffectFormat().getOuterShadowEffect()
    shadow.getShadowColor().setColor(Color.GRAY)
    shadow.setDirection(0)
    shadow.setDistance(42)
    shadow.setBlurRadius(0)
    shadow.setRotateShadowWithShape(True)

    right = before.getShapes().addClone(left)
    right.setX(395)
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(False)

    after = presentation.getSlides().addClone(before)
    for arrow in after.getShapes():
        arrow.setRotation(90)

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Trong slide thứ hai, mũi tên trái chiếu bóng xuống dưới, trong khi mũi tên phải vẫn chiếu bóng sang bên phải. Hướng đã cấu hình vẫn là 0° cho cả hai bóng.

![Kết xuất PowerPoint trước và sau khi quay 90°. Cả hai bóng đều bắt đầu ở bên phải. Sau khi quay, bóng di chuyển xuống dưới mũi tên trái và vẫn ở bên phải của mũi tên phải.](arrow-shadow-rotation.png)

### **Áp dụng bóng trong**

Khi sao chép phong cách trực quan của mẫu, sử dụng bóng trong để tạo ra cảm giác lún cho thẻ hoặc bảng. Bóng ngoài mở rộng ra bên ngoài hình dạng và làm cho nó trông nâng lên, trong khi bóng trong tạo bóng cho phần bên trong các cạnh.

Bạn gọi [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), sau đó cấu hình bóng được trả về bởi [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Giá trị bán kính mờ lớn hơn tạo ra các cạnh mềm hơn.

Ví dụ Python này tạo một thẻ màu xanh nhạt với bóng trong màu xám đậm và lưu nó dưới dạng tệp PPTX. Hướng bóng là 225 độ, khoảng cách là 7 điểm, và bán kính mờ là 6 điểm:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Hình chữ nhật màu xanh nhạt với bóng trong](inner_shadow_effect.png)

Để loại bỏ bóng trong, gọi [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) trên định dạng hiệu ứng của hình dạng.

### **Áp dụng, Thay đổi và Xóa bỏ bóng Preset**

Bạn gọi [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect), sau đó sử dụng [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) để chọn một [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/). Để chuyển đổi kiểu, thay đổi preset trên cùng một hình dạng. Gọi [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) để xóa bỏ bóng trong khi vẫn giữ nguyên màu đổ và đường viền.

Ví dụ sao chép hình chữ nhật ở mỗi giai đoạn để bạn có thể so sánh bốn trạng thái bên cạnh nhau trên một slide. Cả hai bóng đều lệch 10 điểm. Hướng 225° đặt bóng đầu tiên ở phía trên và bên trái của hình chữ nhật. Hướng 45° đặt bóng thứ hai ở phía dưới và bên phải.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Gốc | Preset đầu tiên | Preset thứ hai | Sau khi xóa |
| :---: | :---: | :---: | :---: |
| ![Không có bóng](preset_shadow_original.png) | ![Bóng góc trên trái](preset_shadow_top_left.png) | ![Bóng góc dưới phải](preset_shadow_bottom_right.png) | ![Không có bóng sau khi xóa](preset_shadow_removed.png) |

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides cho Python thông qua Java, bạn có thể thêm một phản chiếu giống gương vào các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao tính thẩm mỹ của bản trình bày bằng cách mang lại cho các hình dạng vẻ ngoài tinh tế và chuyên nghiệp hơn. Nó dễ thực hiện với mã đơn giản, cho phép áp dụng nhanh chóng trên nhiều yếu tố để có thiết kế nhất quán.

Mã Python này cho thấy cách áp dụng [hiệu ứng phản chiếu](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) vào một hình dạng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Hiệu ứng phản chiếu](reflection_effect.png)

## **Áp dụng hiệu ứng phát sáng**

Để áp dụng hiệu ứng phát sáng cho một hình dạng trong Aspose.Slides cho Python thông qua Java, bạn có thể thêm một hào quang mềm mại, rực rỡ quanh các hình dạng, điều chỉnh các thuộc tính như màu và kích thước. Hiệu ứng này giúp các hình dạng nổi bật và bổ sung một yếu tố hình ảnh hấp dẫn, thu hút mắt vào bản trình bày của bạn. Nó dễ thực hiện với ít mã, cải thiện tổng thể giao diện của các slide.

Mã Python này cho thấy cách áp dụng [hiệu ứng phát sáng](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) vào một hình dạng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Hiệu ứng phát sáng](glow_effect.png)

## **Áp dụng hiệu ứng cạnh mềm**

Để áp dụng hiệu ứng cạnh mềm trong Aspose.Slides cho Python thông qua Java, bạn có thể tạo một chuyển tiếp mượt mà, mờ quanh các cạnh của một hình dạng. Hiệu ứng này mang lại vẻ ngoài tinh tế và nhẹ nhàng hơn, phù hợp cho các thiết kế cần vẻ ngoài nhẹ nhàng, mềm mại. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu ứng mong muốn trên nhiều hình dạng trong bản trình bày.

Mã Python này cho thấy cách áp dụng [hiệu ứng cạnh mềm](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) vào một hình dạng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Hiệu ứng cạnh mềm](soft_edges_effect.png)

## **Áp dụng hiệu ứng làm mờ**

Sử dụng làm mờ hình dạng để làm mềm màu đổ và đường viền của hình dạng trong khi vẫn giữ khả năng chỉnh sửa. Gọi [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) trên định dạng hiệu ứng của hình dạng. Bán kính được đo bằng điểm (1/72 inch): sử dụng giá trị không âm, giá trị lớn hơn tạo độ mờ mạnh hơn. Bán kính bằng không sẽ không thay đổi ngoại hình.

Cài đặt [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) điều khiển giới hạn hiển thị của hiệu ứng. Với `False`, độ mờ bị cắt trong giới hạn đã vẽ ban đầu, bao gồm cả đường viền. Với `True`, độ mờ có thể mở rộng ra ngoài các giới hạn đó. Cả hai cài đặt đều không thay đổi vị trí hoặc kích thước của hình dạng.

So sánh bên dưới sử dụng cùng màu đổ, đường viền và kích thước hình dạng trong suốt. Hàng trên sử dụng `grow = False`; hàng dưới sử dụng `grow = True`.

![Hình chữ nhật gốc so sánh với bán kính mờ 5 và 15 điểm, với grow tắt và bật](shape_blur_comparison.png)

Ví dụ Python này tạo một hình chữ nhật màu cam với đường viền màu xanh đậm, áp dụng độ mờ 5 điểm, sau đó cập nhật lên độ mờ 15 điểm bằng cách gọi lại [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect). Nó lưu cả hai trạng thái đã làm mờ, sau đó gọi [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) và lưu hình dạng không có độ mờ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Làm mờ hình dạng ảnh hưởng đến cả màu đổ và đường viền cùng nhau. Hiệu ứng cạnh mềm làm mờ các cạnh của hình dạng, trong khi độ mờ bóng chỉ làm mềm bóng. Các hiệu ứng biến đổi hình ảnh hoạt động trên nội dung hình ảnh; ví dụ này áp dụng độ mờ trực tiếp vào định dạng hiệu ứng của hình dạng mà không chuyển đổi hình dạng thành hình ảnh.

## **Câu hỏi thường gặp**

**Có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, như bóng, phản chiếu và phát sáng, trên một hình dạng duy nhất để tạo ra diện mạo năng động hơn.

**Tôi có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm autoshapes, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và hơn nữa.

**Có thể áp dụng hiệu ứng cho các hình dạng nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng nhóm. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.