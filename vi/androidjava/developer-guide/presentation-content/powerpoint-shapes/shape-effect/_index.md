---
title: Áp dụng Hiệu ứng Hình dạng trong Bài thuyết trình trên Android
linktitle: Hiệu ứng Hình dạng
type: docs
weight: 30
url: /vi/androidjava/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng phát sáng
- hiệu ứng viền mềm
- định dạng hiệu ứng
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Biến đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho Android qua Java—tạo các slide nổi bật, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được sử dụng để làm nổi bật một hình dạng, chúng khác với [đổ màu](/slides/vi/androidjava/shape-formatting/#gradient-fill) hoặc viền. Khi sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, phát tán ánh sáng phát sáng của hình dạng, v.v.

![Hiệu ứng hình dạng](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể được áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số kết hợp của các hiệu ứng trông tốt hơn những kết hợp khác. Vì lý do này, PowerPoint cung cấp các tùy chọn dưới mục **Preset**. Các tùy chọn Preset là các kết hợp của hai hoặc nhiều hiệu ứng được biết là trông đẹp. Nhờ vậy, bằng cách chọn một preset, bạn sẽ không phải tốn thời gian kiểm tra hoặc kết hợp các hiệu ứng khác nhau để tìm ra một sự kết hợp hợp lý.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng giống nhau cho các hình dạng trong bản trình chiếu PowerPoint.

## **Áp dụng hiệu ứng bóng**

Aspose.Slides cho Android qua Java hỗ trợ bóng ngoài và bóng trong cho các hình dạng. Bạn có thể tùy chỉnh màu, hướng, khoảng cách và bán kính làm mờ của chúng để phù hợp với thiết kế bản trình chiếu của mình.

### **Áp dụng bóng ngoài**

Sử dụng bóng ngoài để làm cho thẻ hoặc bảng nổi bật so với nền slide. Bóng mở rộng ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và kiểu mẫu của bạn.

Đoạn mã Java này minh họa cách áp dụng [hiệu ứng bóng ngoài](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) cho một hình chữ nhật:

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

### **Áp dụng bóng trong**

Khi tái tạo kiểu dáng trực quan của mẫu, sử dụng bóng trong để tạo cho thẻ hoặc bảng một vẻ ngoài chìm. Bóng ngoài mở rộng ra bên ngoài hình dạng và làm cho nó trông như được nâng lên, trong khi bóng trong tạo bóng bên trong các cạnh của nó.

Gọi [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--), sau đó cấu hình bóng được trả về bởi [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). Giá trị bán kính làm mờ lớn hơn tạo ra các cạnh mềm hơn.

Ví dụ Java này tạo một thẻ màu xanh nhạt với bóng trong màu xám đậm và lưu nó dưới dạng tệp PPTX. Hướng bóng là 225 độ, khoảng cách của nó là 7 điểm, và bán kính làm mờ là 6 điểm:

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

![Hình chữ nhật xanh nhạt với bóng trong](inner_shadow_effect.png)

Để loại bỏ bóng trong, gọi [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) trên định dạng hiệu ứng của hình dạng.

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides cho Android qua Java, bạn có thể thêm một phản chiếu giống gương vào các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ của bản trình chiếu bằng cách tạo cho các hình dạng một vẻ ngoài bóng bẩy và tinh tế hơn. Nó dễ dàng thực hiện với mã đơn giản, cho phép áp dụng nhanh chóng trên nhiều yếu tố để có thiết kế nhất quán.

Đoạn mã Java này minh họa cách áp dụng [hiệu ứng phản chiếu](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) cho một hình dạng:

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

## **Áp dụng hiệu ứng phát sáng**

Để áp dụng hiệu ứng phát sáng cho một hình dạng trong Aspose.Slides cho Android qua Java, bạn có thể thêm một hào quang mềm mại, rực rỡ xung quanh các hình dạng, điều chỉnh các thuộc tính như màu sắc và kích thước. Hiệu ứng này giúp làm nổi bật các hình dạng và thêm một yếu tố trực quan hấp dẫn, thu hút mắt vào bản trình chiếu của bạn. Nó dễ dàng thực hiện với ít mã, nâng cao tổng thể vẻ ngoài của các slide.

Đoạn mã Java này minh họa cách áp dụng [hiệu ứng phát sáng](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) cho một hình dạng:

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

![Hiệu ứng phát sáng](glow_effect.png)

## **Áp dụng hiệu ứng viền mềm**

Để áp dụng hiệu ứng viền mềm trong Aspose.Slides cho Android qua Java, bạn có thể tạo một chuyển tiếp mượt mà, mờ quanh các cạnh của hình dạng. Hiệu ứng này mang lại vẻ ngoài tinh tế và nhẹ nhàng hơn, hoàn hảo cho các thiết kế cần một diện mạo mềm mại, nhẹ nhàng. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu ứng mong muốn trên nhiều hình dạng trong bản trình chiếu.

Đoạn mã Java này minh họa cách áp dụng [hiệu ứng viền mềm](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) cho một hình dạng:

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

## **Câu hỏi thường gặp**

**Có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, như bóng, phản chiếu và phát sáng, trên một hình dạng duy nhất để tạo ra vẻ ngoài sinh động hơn.

**Những hình dạng nào tôi có thể áp dụng hiệu ứng?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các autoshape, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE, và nhiều hơn nữa.

**Có thể áp dụng hiệu ứng cho các hình dạng được nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm. Hiệu ứng sẽ áp dụng cho toàn bộ nhóm.