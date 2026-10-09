---
title: Áp dụng hiệu ứng hình dạng trong bài thuyết trình bằng Java
linktitle: Hiệu ứng hình dạng
type: docs
weight: 30
url: /vi/java/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng cạnh mềm
- định dạng hiệu ứng
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Chuyển đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides for Java—tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong PowerPoint, các hiệu ứng có thể được sử dụng để làm cho một hình dạng nổi bật, nhưng chúng khác với [đổ màu](/slides/vi/java/shape-formatting/#gradient-fill) hoặc viền. Sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan tỏa ánh hào quang của hình, v.v.

![Hiệu ứng hình dạng](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số tổ hợp hiệu ứng trông đẹp hơn các tổ hợp khác. Vì lý do này, PowerPoint cung cấp các tùy chọn dưới **Preset**. Các tùy chọn Preset là các tổ hợp của hai hoặc nhiều hiệu ứng được biết là trông đẹp. Nhờ vậy, bằng cách chọn một preset, bạn sẽ không phải tốn thời gian kiểm tra hoặc kết hợp các hiệu ứng khác nhau để tìm ra một tổ hợp ưng ý.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình dạng trong các bản trình chiếu PowerPoint.

## **Áp dụng hiệu ứng bóng**

Aspose.Slides for Java hỗ trợ bóng ngoài và bóng trong cho các hình dạng. Bạn có thể tùy chỉnh màu sắc, hướng, khoảng cách và bán kính làm mờ để phù hợp với thiết kế của bản trình chiếu.

### **Áp dụng bóng ngoài**

Sử dụng bóng ngoài để làm cho một thẻ hoặc bảng nổi bật so với nền slide. Bóng mở rộng ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và kiểu dáng của mẫu của bạn.

Đoạn mã Java này cho thấy cách áp dụng [hiệu ứng bóng ngoài](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) cho một hình chữ nhật:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hiệu ứng bóng](shadow_effect.png)

### **Áp dụng bóng trong**

Khi tái tạo kiểu hình ảnh của mẫu, sử dụng bóng trong để tạo cho thẻ hoặc bảng một vẻ ngoài lún xuống. Bóng ngoài mở rộng ra bên ngoài hình dạng và làm cho nó trông như được nâng lên, trong khi bóng trong tạo bóng cho bên trong các cạnh của nó.

Gọi [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) rồi cấu hình bóng được trả về bởi [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Giá trị bán kính làm mờ lớn hơn tạo ra các cạnh mềm hơn.

Đoạn mã Java này tạo một thẻ màu xanh nhạt với bóng trong màu xám đậm và lưu nó dưới dạng tệp PPTX. Hướng bóng là 225 độ, khoảng cách là 7 điểm và bán kính làm mờ là 6 điểm:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Hình chữ nhật màu xanh nhạt với bóng trong](inner_shadow_effect.png)

Để xóa bóng trong, gọi [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) trên định dạng hiệu ứng của hình dạng.

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng một hiệu ứng phản chiếu trong Aspose.Slides for Java, bạn có thể thêm một phản chiếu giống gương vào các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao tính thẩm mỹ của bản trình chiếu bằng cách tạo cho các hình dạng một vẻ ngoài mịn màng và tinh tế hơn. Nó dễ dàng thực hiện với đoạn mã đơn giản, cho phép áp dụng nhanh trên nhiều phần tử để đạt thiết kế nhất quán.

Đoạn mã Java này cho thấy cách áp dụng [hiệu ứng phản chiếu](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) cho một hình dạng:

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

Để áp dụng một hiệu ứng hào quang cho một hình dạng trong Aspose.Slides for Java, bạn có thể thêm một hào quang mềm mại, phát sáng quanh các hình dạng, điều chỉnh các thuộc tính như màu và kích thước. Hiệu ứng này giúp làm nổi bật các hình dạng và thêm yếu tố trực quan hấp dẫn cho bản trình chiếu. Nó dễ dàng thực hiện với ít mã, nâng cao tổng thể giao diện của các slide.

Đoạn mã Java này cho thấy cách áp dụng [hiệu ứng hào quang](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) cho một hình dạng:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Áp dụng hiệu ứng cạnh mềm**

Để áp dụng một hiệu ứng cạnh mềm trong Aspose.Slides for Java, bạn có thể tạo một chuyển đổi mờ, mượt quanh các cạnh của một hình dạng. Hiệu ứng này mang lại vẻ ngoài tinh tế, nhẹ nhàng, phù hợp cho các thiết kế cần một diện mạo nhẹ nhàng hơn. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu quả mong muốn trên nhiều hình dạng trong bản trình chiếu.

Đoạn mã Java này cho thấy cách áp dụng [hiệu ứng cạnh mềm](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) cho một hình dạng:

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

![Hiệu ứng cạnh mềm](soft_edges_effect.png)

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

**Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn bóng, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra vẻ ngoài năng động hơn.**

**Những hình dạng nào tôi có thể áp dụng hiệu ứng?**

**Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các autoshape, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE, và hơn nữa.**

**Tôi có thể áp dụng hiệu ứng cho các hình dạng được nhóm lại không?**

**Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm lại. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.**