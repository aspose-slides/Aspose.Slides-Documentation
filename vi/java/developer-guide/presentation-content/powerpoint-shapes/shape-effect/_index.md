---
title: Áp dụng hiệu ứng hình dạng trong bản trình bày bằng Java
linktitle: Hiệu ứng hình dạng
type: docs
weight: 30
url: /vi/java/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng mép mềm
- định dạng hiệu ứng
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Chuyển đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho Java — tạo các slide ấn tượng, chuyên nghiệp chỉ trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được sử dụng để làm nổi bật một hình, chúng khác với [đổ màu](/slides/vi/java/shape-formatting/#gradient-fill) hoặc đường viền. Sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra những phản chiếu thuyết phục trên một hình, lan tỏa ánh sáng hào quang của hình, v.v.

![Hiệu ứng hình dạng](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình.

Một số kết hợp của các hiệu ứng trông tốt hơn các kết hợp khác. Vì lý do này, PowerPoint cung cấp các tùy chọn dưới **Preset**. Các tùy chọn Preset là các kết hợp của hai hoặc nhiều hiệu ứng đã được biết là trông đẹp. Nhờ đó, bằng cách chọn một preset, bạn sẽ không phải tốn thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm một sự kết hợp ưng ý.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình trong bản trình bày PowerPoint.

## **Áp dụng hiệu ứng bóng**

Aspose.Slides cho Java hỗ trợ bóng ngoài và bóng trong cho các hình. Bạn có thể tùy chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với thiết kế bản trình bày của mình.

### **Áp dụng bóng ngoài**

Sử dụng bóng ngoài để làm cho một thẻ hoặc bảng nổi bật so với nền slide. Bóng mở rộng ra bên ngoài các cạnh của hình, tạo ấn tượng rằng hình được nâng lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và kiểu dáng của mẫu.

Đoạn mã Java này hiển thị cách áp dụng [hiệu ứng bóng ngoài](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) cho một hình chữ nhật:

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

Khi tái tạo kiểu dáng hình ảnh của mẫu, sử dụng bóng trong để tạo cho thẻ hoặc bảng một vẻ ngoài lồi vào. Bóng ngoài mở rộng ra bên ngoài hình và làm cho nó trông như được nâng lên, trong khi bóng trong tạo bóng cho bên trong các cạnh của nó.

Gọi [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) rồi cấu hình bóng được trả về bởi [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Giá trị bán kính làm mờ lớn hơn tạo ra các cạnh mềm hơn.

Ví dụ Java này tạo một thẻ màu xanh nhạt với bóng trong màu xám đậm và lưu dưới dạng tệp PPTX. Hướng bóng là 225 độ, khoảng cách là 7 điểm, và bán kính làm mờ là 6 điểm:

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

Để loại bỏ bóng trong, gọi [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) trên định dạng hiệu ứng của hình.

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides cho Java, bạn có thể thêm một phản chiếu giống gương vào các hình, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ của bản trình bày bằng cách tạo cho các hình một vẻ ngoài mịn màng và tinh tế hơn. Nó dễ dàng triển khai với mã đơn giản, cho phép áp dụng nhanh trên nhiều phần tử để đạt thiết kế đồng nhất.

Đoạn mã Java này hiển thị cách áp dụng [hiệu ứng phản chiếu](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) cho một hình:

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

Để áp dụng hiệu ứng hào quang cho một hình trong Aspose.Slides cho Java, bạn có thể thêm một hào quang mềm mại, phát sáng quanh các hình, điều chỉnh các thuộc tính như màu sắc và kích thước. Hiệu ứng này giúp các hình nổi bật và thêm một yếu tố hình ảnh thu hút, hấp dẫn vào bản trình bày của bạn. Nó dễ dàng triển khai với một chút mã, nâng cao tổng thể hình ảnh của các slide.

Đoạn mã Java này hiển thị cách áp dụng [hiệu ứng hào quang](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) cho một hình:

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

## **Áp dụng hiệu ứng mép mềm**

Để áp dụng hiệu ứng mép mềm trong Aspose.Slides cho Java, bạn có thể tạo một chuyển tiếp mượt mà, mờ quanh các cạnh của một hình. Hiệu ứng này mang lại vẻ ngoài tinh tế và nhẹ nhàng hơn, phù hợp cho các thiết kế cần một diện mạo nhẹ nhàng, mềm mại. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu ứng mong muốn trên nhiều hình trong bản trình bày.

Đoạn mã Java này hiển thị cách áp dụng [hiệu ứng mép mềm](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) cho một hình:

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

![Hiệu ứng mép mềm](soft_edges_effect.png)

## **Áp dụng hiệu ứng làm mờ**

Sử dụng làm mờ hình để làm mềm nền và đường viền của hình trong khi vẫn giữ cho hình có thể chỉnh sửa. Gọi [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) trên định dạng hiệu ứng của hình. Bán kính được đo bằng điểm (1/72 inch): sử dụng giá trị không âm, với giá trị lớn hơn tạo ra độ mờ mạnh hơn. Bán kính bằng không sẽ giữ nguyên giao diện.

Cài đặt [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) kiểm soát phạm vi hiển thị của hiệu ứng. Khi `false`, độ mờ bị cắt theo phạm vi đã vẽ ban đầu, bao gồm cả đường viền. Khi `true`, độ mờ có thể mở rộng ra ngoài phạm vi đó. Cả hai cài đặt đều không thay đổi vị trí hoặc kích thước của hình.

So sánh dưới đây sử dụng cùng một nền, đường viền và kích thước hình trong toàn bộ. Hàng trên sử dụng `grow = false`; hàng dưới sử dụng `grow = true`.

![Hình chữ nhật gốc so sánh với bán kính mờ 5 và 15 điểm, với grow tắt và bật](shape_blur_comparison.png)

Ví dụ Java này tạo một hình chữ nhật màu cam với đường viền màu xanh đậm, áp dụng độ mờ 5 điểm, sau đó cập nhật lên độ mờ 15 điểm bằng cách gọi lại [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Nó lưu cả hai trạng thái đã làm mờ, sau đó gọi [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) và lưu hình mà không có độ mờ.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
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

Làm mờ hình ảnh ảnh hưởng tới nền và đường viền đồng thời. Hiệu ứng mép mềm làm mờ dần các cạnh của hình, trong khi làm mờ bóng chỉ làm mềm bóng. Các hiệu ứng biến đổi hình ảnh hoạt động trên nội dung hình ảnh; ví dụ này áp dụng làm mờ trực tiếp lên định dạng hiệu ứng của hình mà không chuyển hình sang dạng ảnh.

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng nhiều hiệu ứng cho cùng một hình không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn bóng, phản chiếu và hào quang, trên một hình duy nhất để tạo ra một diện mạo năng động hơn.

**Tôi có thể áp dụng hiệu ứng cho những loại hình nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình, bao gồm các autoshape, biểu đồ, bảng, ảnh, đối tượng SmartArt, đối tượng OLE và các loại khác.

**Tôi có thể áp dụng hiệu ứng cho các hình nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình nhóm. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.