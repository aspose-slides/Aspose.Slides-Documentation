---  
title: Áp dụng hiệu ứng hình dạng trong bản trình chiếu bằng Python qua Java  
linktitle: Hiệu ứng hình dạng  
type: docs  
weight: 30  
url: /vi/python-java/shape-effect/  
keywords:  
- hiệu ứng hình dạng  
- hiệu ứng bóng  
- hiệu ứng phản chiếu  
- hiệu ứng hào quang  
- hiệu ứng cạnh mềm  
- định dạng hiệu ứng  
- PowerPoint  
- bản trình chiếu  
- Python  
- Java  
- Aspose.Slides  
description: "Biến đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho Python qua Java — tạo các slide ấn tượng, chuyên nghiệp trong vài giây."  
---
## **Giới thiệu**

Trong khi hiệu ứng trong PowerPoint có thể được sử dụng để làm nổi bật một hình dạng, chúng khác với [đổ màu](/slides/vi/python-java/shape-formatting/#gradient-fill) hoặc viền. Sử dụng các hiệu ứng PowerPoint, bạn có thể tạo các phản chiếu thuyết phục trên một hình dạng, lan tỏa hào quang của hình, v.v.

![Hiệu ứng hình dạng](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể được áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số sự kết hợp của các hiệu ứng trông đẹp hơn so với các sự kết hợp khác. Vì lý do này, PowerPoint cung cấp các tùy chọn dưới **Preset**. Các tùy chọn Preset là những sự kết hợp của hai hoặc nhiều hiệu ứng được biết là trông tốt. Nhờ vậy, khi chọn một preset, bạn sẽ không phải lãng phí thời gian để thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một sự kết hợp ưng ý.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình dạng trong bản trình chiếu PowerPoint.

## **Áp dụng hiệu ứng bóng**

Aspose.Slides for Python qua Java hỗ trợ bóng ngoài và bóng trong cho các hình dạng. Bạn có thể tùy chỉnh màu sắc, hướng, khoảng cách và bán kính làm mờ của chúng để phù hợp với thiết kế bản trình chiếu của mình.

### **Áp dụng bóng ngoài**

Sử dụng bóng ngoài để làm cho một thẻ hoặc bảng nổi bật so với nền slide. Bóng mở rộng ra ngoài các cạnh của hình dạng, tạo cảm giác rằng hình dạng được nâng lên trên slide. Điều chỉnh màu sắc, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và phong cách của mẫu của bạn.

Đoạn mã Python này cho thấy cách áp dụng [hiệu ứng bóng ngoài](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) cho một hình chữ nhật:

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

### **Áp dụng bóng trong**

Khi tái tạo kiểu dáng hình ảnh của một mẫu, sử dụng bóng trong để tạo cho thẻ hoặc bảng một bóng tối âm. Bóng ngoài mở rộng ra bên ngoài hình dạng và làm cho nó trông như được nâng lên, trong khi bóng trong tạo bóng cho bên trong các cạnh của nó.

Gọi [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), sau đó cấu hình bóng trả về bởi [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Giá trị bán kính làm mờ lớn hơn tạo ra các cạnh mềm hơn.

Ví dụ Python này tạo một thẻ màu xanh nhạt với bóng trong màu xám đậm và lưu nó dưới dạng tệp PPTX. Hướng bóng là 225 độ, khoảng cách là 7 điểm, và bán kính làm mờ là 6 điểm:

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

Để loại bỏ bóng trong, gọi [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) trên đối tượng effect format của hình dạng.

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides cho Python qua Java, bạn có thể thêm một phản chiếu giống gương vào các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ cho bản trình chiếu của bạn bằng cách mang lại cho các hình dạng một vẻ ngoài tinh tế và chuyên nghiệp hơn. Nó dễ dàng thực hiện với mã đơn giản, cho phép áp dụng nhanh chóng trên nhiều yếu tố để đạt được thiết kế đồng nhất.

Đoạn mã Python này cho thấy cách áp dụng [hiệu ứng phản chiếu](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) cho một hình dạng:

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

## **Áp dụng hiệu ứng hào quang**

Để áp dụng hiệu ứng hào quang cho một hình dạng trong Aspose.Slides cho Python qua Java, bạn có thể thêm một hào quang mềm mại, phát sáng xung quanh các hình dạng, điều chỉnh các thuộc tính như màu sắc và kích thước. Hiệu ứng này giúp làm nổi bật các hình dạng và thêm một yếu tố trực quan hấp dẫn, thu hút mắt vào bản trình chiếu của bạn. Nó dễ dàng thực hiện với ít mã, nâng cao tổng thể giao diện của các slide.

Đoạn mã Python này cho thấy cách áp dụng [hiệu ứng hào quang](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) cho một hình dạng:

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

![Hiệu ứng hào quang](glow_effect.png)

## **Áp dụng hiệu ứng cạnh mềm**

Để áp dụng hiệu ứng cạnh mềm trong Aspose.Slides cho Python qua Java, bạn có thể tạo một chuyển tiếp mượt mà, mờ xung quanh các cạnh của một hình dạng. Hiệu ứng này mang lại một vẻ ngoài tinh tế và nhẹ nhàng hơn, phù hợp cho các thiết kế cần một diện mạo nhẹ nhàng, mềm mại hơn. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu quả mong muốn trên nhiều hình dạng trong bản trình chiếu của mình.

Đoạn mã Python này cho thấy cách áp dụng [hiệu ứng cạnh mềm](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) cho một hình dạng:

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

Sử dụng làm mờ hình dạng để làm mềm phần tô và viền của hình mà vẫn giữ cho hình có thể chỉnh sửa được. Gọi [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) trên effect format của hình. Bán kính được đo bằng điểm (1/72 inch): sử dụng giá trị không âm, với giá trị lớn hơn tạo ra hiệu ứng mờ mạnh hơn. Bán kính bằng không sẽ giữ nguyên ngoại hình.

Cài đặt [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) kiểm soát giới hạn hiển thị của hiệu ứng. Khi `False`, hiệu ứng mờ bị cắt trong giới hạn đã tô màu ban đầu, bao gồm cả viền. Khi `True`, hiệu ứng mờ có thể mở rộng ra ngoài các giới hạn đó. Cả hai cài đặt đều không thay đổi vị trí hoặc kích thước của hình.

Bảng so sánh dưới đây sử dụng cùng một phần tô, viền và kích thước hình cho toàn bộ. Hàng trên sử dụng `grow = False`; hàng dưới sử dụng `grow = True`.

![Hình chữ nhật gốc so sánh với bán kính làm mờ 5 và 15 điểm, với grow tắt và bật](shape_blur_comparison.png)

Ví dụ Python này tạo một hình chữ nhật màu cam với viền màu xanh đậm, áp dụng làm mờ 5 điểm, và sau đó cập nhật lên làm mờ 15 điểm bằng cách gọi lại [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect). Nó lưu cả hai trạng thái đã làm mờ, sau đó gọi [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) và lưu hình mà không có hiệu ứng làm mờ.

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

Làm mờ hình ảnh ảnh hưởng đến cả phần tô và viền cùng lúc. Hiệu ứng cạnh mềm làm mờ dần các cạnh của hình, trong khi làm mờ bóng chỉ làm mềm bóng. Các hiệu ứng biến đổi hình ảnh hoạt động trên nội dung hình ảnh; ví dụ này áp dụng làm mờ trực tiếp lên effect format của hình mà không chuyển đổi hình thành ảnh.

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng, phản chiếu và hào quang, trên một hình duy nhất để tạo nên một diện mạo động hơn.

**Những hình dạng nào tôi có thể áp dụng hiệu ứng?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các hình tự động, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và hơn nữa.

**Tôi có thể áp dụng hiệu ứng cho các hình dạng được nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.