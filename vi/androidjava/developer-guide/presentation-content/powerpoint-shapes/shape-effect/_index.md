---
title: Áp dụng hiệu ứng hình dạng trong bài thuyết trình trên Android
linktitle: Hiệu ứng hình dạng
type: docs
weight: 30
url: /vi/androidjava/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng viền mềm
- định dạng hiệu ứng
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Biến đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng tiên tiến bằng Aspose.Slides cho Android qua Java—tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được dùng để làm cho một hình dạng nổi bật, chúng khác với [đổ màu](/slides/vi/androidjava/shape-formatting/#gradient-fill) hoặc viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan tỏa ánh hào quang của hình dạng, v.v.

![Hiệu ứng hình dạng](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số sự kết hợp của các hiệu ứng trông đẹp hơn so với những thứ khác. Vì lý do này, PowerPoint cung cấp các tùy chọn dưới mục **Preset**. Các tùy chọn Preset là các sự kết hợp của hai hoặc nhiều hiệu ứng được biết là trông tốt. Nhờ vậy, khi chọn một preset, bạn sẽ không phải lãng phí thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một sự kết hợp phù hợp.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng giống nhau cho các hình dạng trong các bản trình bày PowerPoint.

## **Áp dụng hiệu ứng bóng**

Aspose.Slides cho Android qua Java hỗ trợ bóng ngoài và bóng trong cho các hình dạng. Bạn có thể tùy chỉnh màu, hướng, khoảng cách và bán kính mờ của chúng để phù hợp với thiết kế bản trình bày của mình.

### **Áp dụng bóng ngoài**

Sử dụng bóng ngoài để làm cho một thẻ hoặc bảng điều khiển nổi bật so với nền slide. Bóng mở rộng ra ngoài các cạnh của hình dạng, tạo ảo giác rằng hình dạng được nâng lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính mờ để phù hợp với ánh sáng và phong cách của mẫu.

Mã Java này cho thấy cách áp dụng [hiệu ứng bóng ngoài](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) cho một hình chữ nhật:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hiệu ứng bóng](shadow_effect.png)

#### **Kiểm soát hướng bóng khi hình dạng xoay**

Mặc định, bóng ngoài sẽ xoay cùng với hình dạng. Để các hình dạng có các góc quay khác nhau vẫn được chiếu sáng từ cùng một hướng, gọi [setRotateShadowWithShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setRotateShadowWithShape-boolean-) với `false` và sử dụng [setDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioutershadow/#setDirection-float-) để đặt cùng một hướng cho các bóng.

Ví dụ tạo hai mũi tên xanh tạo bóng xám lệch 42 điểm sang phải (0°). Sau đó sao chép slide và quay cả hai mũi tên 90° theo chiều kim đồng hồ.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide before = presentation.getSlides().get_Item(0);

    IAutoShape left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
    left.getFillFormat().setFillType(FillType.Solid);
    left.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    left.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = left.getEffectFormat().getOuterShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(128, 128, 128));
    shadow.setDirection(0);
    shadow.setDistance(42);
    shadow.setBlurRadius(0);
    shadow.setRotateShadowWithShape(true);

    IShape right = before.getShapes().addClone(left);
    right.setX(395);
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(false);

    ISlide after = presentation.getSlides().addClone(before);
    for (IShape arrow : after.getShapes()) {
        arrow.setRotation(90);
    }

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ở slide thứ hai, mũi tên trái tạo bóng xuống dưới, trong khi mũi tên phải vẫn tạo bóng sang phía phải. Hướng được cấu hình vẫn là 0° cho cả hai bóng.

![Kết quả render PowerPoint trước và sau khi xoay 90°. Cả hai bóng đều bắt đầu ở phía phải. Sau khi xoay, bóng di chuyển xuống dưới mũi tên trái và vẫn ở phía phải của mũi tên phải.](arrow-shadow-rotation.png)

### **Áp dụng bóng trong**

Khi tái tạo phong cách hình ảnh của mẫu, sử dụng bóng trong để tạo cảm giác lõm cho thẻ hoặc bảng điều khiển. Bóng ngoài mở rộng ra ngoài hình dạng và làm cho nó trông nổi lên, trong khi bóng trong làm tối phần bên trong các cạnh của nó.

Gọi [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) rồi cấu hình bóng trả về bởi [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). Giá trị bán kính mờ lớn hơn tạo ra các cạnh mềm hơn.

Mã Java này tạo một thẻ màu xanh nhạt có bóng trong màu xám đậm và lưu nó dưới dạng tệp PPTX. Hướng bóng là 225 độ, khoảng cách 7 điểm và bán kính mờ 6 điểm:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hình chữ nhật màu xanh nhạt có bóng trong](inner_shadow_effect.png)

Để xóa bóng trong, gọi [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) trên định dạng hiệu ứng của hình dạng.

### **Áp dụng, thay đổi và xóa bóng preset**

Gọi [enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) và sử dụng [setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-) để chọn một [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/). Để chuyển đổi kiểu, thay đổi preset trên cùng một hình dạng. Gọi [disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) để xóa bóng trong khi vẫn giữ nguyên màu nền và viền.

Ví dụ này hiển thị bốn trạng thái bên nhau trên một slide. Cả hai bóng đều lệch 10 điểm. Hướng 225° đặt bóng đầu tiên ở phía trên và bên trái của hình chữ nhật, còn 45° đặt bóng thứ hai ở phía dưới và bên phải.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Gốc | Preset đầu tiên | Preset thứ hai | Sau khi xóa |
| :---: | :---: | :---: | :---: |
| ![Không có bóng](preset_shadow_original.png) | ![Bóng thả xuống góc trên trái](preset_shadow_top_left.png) | ![Bóng thả xuống góc dưới phải](preset_shadow_bottom_right.png) | ![Không có bóng sau khi xóa](preset_shadow_removed.png) |

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng một hiệu ứng phản chiếu trong Aspose.Slides cho Android qua Java, bạn có thể thêm một phản chiếu giống gương cho các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ của bản trình bày bằng cách tạo cho các hình dạng một vẻ ngoài bóng bẩy và tinh tế hơn. Thực hiện dễ dàng với mã đơn giản, cho phép áp dụng nhanh chóng trên nhiều yếu tố để đạt thiết kế nhất quán.

Mã Java này cho thấy cách áp dụng [hiệu ứng phản chiếu](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) cho một hình dạng:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hiệu ứng phản chiếu](reflection_effect.png)

## **Áp dụng hiệu ứng hào quang**

Để áp dụng hiệu ứng hào quang cho một hình dạng trong Aspose.Slides cho Android qua Java, bạn có thể thêm một hào quang nhẹ nhàng, phát sáng quanh các hình dạng, điều chỉnh các thuộc tính như màu và kích thước. Hiệu ứng này giúp các hình dạng nổi bật và tạo một yếu tố hình ảnh hấp dẫn, thu hút mắt trong bài thuyết trình của bạn. Thực hiện dễ dàng với ít mã, nâng cao tổng thể giao diện các slide.

Mã Java này cho thấy cách áp dụng [hiệu ứng hào quang](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) cho một hình dạng:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hiệu ứng hào quang](glow_effect.png)

## **Áp dụng hiệu ứng viền mềm**

Để áp dụng hiệu ứng viền mềm trong Aspose.Slides cho Android qua Java, bạn có thể tạo một chuyển đổi mờ, mượt quanh các cạnh của một hình dạng. Hiệu ứng này thêm vẻ ngoài tinh tế, nhẹ nhàng, phù hợp cho các thiết kế cần một diện mạo mềm mại hơn. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt hiệu quả mong muốn trên nhiều hình dạng trong bản trình bày.

Mã Java này cho thấy cách áp dụng [hiệu ứng viền mềm](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) cho một hình dạng:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hiệu ứng viền mềm](soft_edges_effect.png)

## **Áp dụng hiệu ứng mờ**

Sử dụng mờ hình dạng để làm mềm màu nền và viền của hình dạng đồng thời giữ cho hình dạng vẫn có thể chỉnh sửa. Gọi [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) trên định dạng hiệu ứng của hình dạng. Bán kính đo bằng điểm (1/72 inch): dùng giá trị không âm, giá trị lớn hơn tạo độ mờ mạnh hơn. Bán kính bằng không giữ nguyên ngoại hình.

Cài đặt [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) điều khiển giới hạn hiển thị của hiệu ứng. Với `false`, độ mờ bị cắt trong giới hạn đã vẽ ban đầu, bao gồm viền. Với `true`, độ mờ có thể vượt ra ngoài giới hạn đó. Cả hai cài đặt đều không thay đổi vị trí hay kích thước của hình dạng.

So sánh dưới đây sử dụng cùng màu nền, viền và kích thước hình dạng trong suốt. Hàng trên dùng `grow = false`; hàng dưới dùng `grow = true`.

![Hình chữ nhật gốc so sánh với bán kính mờ 5 và 15 điểm, với grow tắt và bật](shape_blur_comparison.png)

Mã Java này tạo một hình chữ nhật màu cam với viền xanh đậm, áp dụng độ mờ 5 điểm, sau đó cập nhật lên độ mờ 15 điểm bằng cách gọi lại [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Nó lưu cả hai trạng thái mờ, rồi gọi [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) và lưu hình dạng không có mờ.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mờ hình dạng ảnh hưởng đến cả màu nền và viền cùng nhau. Hiệu ứng viền mềm làm mờ các cạnh của hình dạng, trong khi mờ bóng chỉ làm mềm bóng. Các hiệu ứng biến đổi hình ảnh hoạt động trên nội dung ảnh; ví dụ này áp dụng mờ trực tiếp lên định dạng hiệu ứng của hình dạng mà không chuyển hình dạng thành ảnh.

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra giao diện động hơn.

**Tôi có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các hình tự động, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và hơn thế nữa.

**Tôi có thể áp dụng hiệu ứng cho các hình dạng được nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.