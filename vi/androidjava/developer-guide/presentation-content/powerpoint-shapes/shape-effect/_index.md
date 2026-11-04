---
title: Áp dụng hiệu ứng hình dạng trong các bản trình chiếu trên Android
linktitle: Hiệu ứng Hình dạng
type: docs
weight: 30
url: /vi/androidjava/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng phát sáng
- hiệu ứng mép mềm
- định dạng hiệu ứng
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho Android qua Java—tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Mặc dù các hiệu ứng trong PowerPoint có thể được dùng để làm nổi bật một hình dạng, chúng khác với [đổ màu](/slides/vi/androidjava/shape-formatting/#gradient-fill) hoặc đường viền. Khi sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan tỏa ánh sáng bao quanh của hình dạng, v.v.

![Hiệu ứng hình dạng](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể được áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số kết hợp hiệu ứng trông tốt hơn các kết hợp khác. Vì vậy, PowerPoint cung cấp các tùy chọn dưới **Preset**. Các tùy chọn Preset là các kết hợp của hai hoặc nhiều hiệu ứng được biết là trông đẹp. Bằng cách này, khi chọn một preset, bạn sẽ không phải tốn thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một tổ hợp ưng ý.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) cho phép bạn áp dụng cùng các hiệu ứng vào hình dạng trong các bài thuyết trình PowerPoint.

## **Áp dụng hiệu ứng bóng**

Aspose.Slides for Android via Java hỗ trợ đổ bóng ngoài và đổ bóng bên trong cho các hình dạng. Bạn có thể tùy chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với thiết kế bài thuyết trình của mình.

### **Áp dụng đổ bóng ngoài**

Sử dụng đổ bóng ngoài để làm cho thẻ hoặc bảng nổi bật trên nền slide. Bóng kéo dài ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và phong cách của mẫu.

Mã Java này cho thấy cách áp dụng [hiệu ứng đổ bóng ngoài](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) cho một hình chữ nhật:

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

### **Áp dụng đổ bóng bên trong**

Khi tái tạo phong cách hình ảnh của mẫu, sử dụng đổ bóng bên trong để tạo cho thẻ hoặc bảng một vẻ ngoài lõm. Đổ bóng ngoài mở rộng ra bên ngoài hình dạng và làm cho nó nhìn như nổi lên, trong khi đổ bóng bên trong làm tối các cạnh bên trong của nó.

Gọi [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) rồi cấu hình bóng trả về bởi [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). Giá trị bán kính làm mờ lớn hơn tạo ra các cạnh mềm hơn.

Ví dụ Java này tạo một thẻ màu xanh nhạt với đổ bóng bên trong màu xám đậm và lưu dưới dạng file PPTX. Hướng bóng là 225 độ, khoảng cách là 7 điểm, và bán kính làm mờ là 6 điểm:

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

![Hình chữ nhật màu xanh nhạt với đổ bóng bên trong](inner_shadow_effect.png)

Để loại bỏ đổ bóng bên trong, gọi [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) trên định dạng hiệu ứng của hình dạng.

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng một hiệu ứng phản chiếu trong Aspose.Slides for Android via Java, bạn có thể thêm một phản chiếu giống gương vào các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ của bài thuyết trình bằng cách tạo cho các hình dạng một vẻ ngoài mượt mà và tinh tế hơn. Nó dễ thực hiện với mã đơn giản, cho phép áp dụng nhanh chóng trên nhiều phần tử để duy trì thiết kế nhất quán.

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

## **Áp dụng hiệu ứng phát sáng**

Để áp dụng một hiệu ứng phát sáng cho một hình dạng trong Aspose.Slides for Android via Java, bạn có thể thêm một hào quang nhẹ, phát sáng quanh các hình dạng, điều chỉnh các thuộc tính như màu và kích thước. Hiệu ứng này giúp các hình dạng nổi bật và thêm một yếu tố hình ảnh hấp dẫn, thu hút mắt cho bài thuyết trình của bạn. Nó dễ thực hiện với ít mã, nâng cao tổng thể giao diện của các slide.

Mã Java này cho thấy cách áp dụng [hiệu ứng phát sáng](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) cho một hình dạng:

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

## **Áp dụng hiệu ứng mép mềm**

Để áp dụng một hiệu ứng mép mềm trong Aspose.Slides for Android via Java, bạn có thể tạo một chuyển đổi mượt mà, mờ dần quanh các cạnh của một hình dạng. Hiệu ứng này mang lại vẻ ngoài tinh tế và nhẹ nhàng hơn, phù hợp cho những thiết kế cần một diện mạo mềm mại. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu quả mong muốn trên các hình dạng khác nhau trong bài thuyết trình.

Mã Java này cho thấy cách áp dụng [hiệu ứng mép mềm](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) cho một hình dạng:

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

## **Áp dụng hiệu ứng mờ**

Sử dụng làm mờ hình dạng để làm mềm màu nền và đường viền của hình dạng mà vẫn giữ được khả năng chỉnh sửa hình dạng. Gọi [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) trên định dạng hiệu ứng của hình dạng. Bán kính được đo bằng điểm (1/72 inch): sử dụng giá trị không âm, giá trị lớn hơn tạo ra độ mờ mạnh hơn. Bán kính bằng không giữ nguyên vẻ ngoài.

Cài đặt [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) kiểm soát giới hạn hiển thị của hiệu ứng. Khi `false`, độ mờ bị cắt trong giới hạn đã vẽ ban đầu, bao gồm cả đường viền. Khi `true`, độ mờ có thể mở rộng ra ngoài các giới hạn đó. Không cài đặt nào thay đổi vị trí hoặc kích thước của hình dạng.

So sánh dưới đây sử dụng cùng một màu nền, đường viền và kích thước hình suốt quá trình. Hàng trên dùng `grow = false`; hàng dưới dùng `grow = true`.

![Hình chữ nhật gốc so sánh với bán kính mờ 5 và 15 điểm, với grow bị tắt và bật](shape_blur_comparison.png)

Ví dụ Java này tạo một hình chữ nhật màu cam với đường viền màu xanh đậm, áp dụng độ mờ 5 điểm, sau đó cập nhật lên độ mờ 15 điểm bằng cách gọi lại [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Nó lưu cả hai trạng thái đã mờ, rồi gọi [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) và lưu hình dạng mà không có độ mờ.

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

Làm mờ hình dạng ảnh hưởng đến cả màu nền và đường viền cùng lúc. Hiệu ứng mép mềm làm nhạt các cạnh của hình dạng, trong khi làm mờ bóng chỉ làm mềm bóng. Các hiệu ứng chuyển đổi hình ảnh hoạt động trên nội dung ảnh; ví dụ này áp dụng độ mờ trực tiếp lên định dạng hiệu ứng của hình dạng mà không chuyển đổi hình dạng thành ảnh.

## **CÂU HỎI THƯỜNG GẶP**

**Tôi có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng, phản chiếu và phát sáng, trên một hình dạng duy nhất để tạo ra một diện mạo động hơn.

**Tôi có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các hình tự động, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và hơn thế nữa.

**Tôi có thể áp dụng hiệu ứng cho các hình dạng nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm lại. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.