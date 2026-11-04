---
title: Áp dụng hiệu ứng hình dạng trong bản trình bày bằng JavaScript
linktitle: Hiệu ứng hình dạng
type: docs
weight: 30
url: /vi/nodejs-java/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng đổ
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng cạnh mềm
- định dạng hiệu ứng
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng JavaScript và Aspose.Slides cho Node.js — tạo các slide ấn tượng, chuyên nghiệp trong vòng vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được sử dụng để làm nổi bật một hình dạng, chúng khác với [đổ màu](/slides/vi/nodejs-java/shape-formatting/#gradient-fill) hoặc đường viền. Sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan rộng ánh hào quang của hình dạng, v.v.

![Shape effect](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số tổ hợp hiệu ứng trông tốt hơn một số khác. Vì lý do này, PowerPoint cung cấp các tùy chọn dưới **Preset**. Các tùy chọn Preset là các tổ hợp của hai hoặc nhiều hiệu ứng được biết là trông đẹp. Nhờ vậy, khi chọn một preset, bạn sẽ không cần mất thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm một tổ hợp phù hợp.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình dạng trong bản trình bày PowerPoint.

## **Áp dụng hiệu ứng bóng đổ**

Aspose.Slides cho Node.js qua Java hỗ trợ bóng đổ ngoài và bên trong cho các hình dạng. Bạn có thể tùy chỉnh màu sắc, hướng, khoảng cách và bán kính làm mờ để phù hợp với thiết kế của bản trình bày.

### **Áp dụng bóng đổ ngoài**

Sử dụng bóng đổ ngoài để làm cho một thẻ hoặc bảng nổi bật hơn nền slide. Bóng đổ mở rộng ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và kiểu dáng của mẫu.

Đoạn mã JavaScript này cho thấy cách áp dụng [hiệu ứng bóng đổ ngoài](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) cho một hình chữ nhật:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Shadow effect](shadow_effect.png)

### **Áp dụng bóng đổ bên trong**

Khi sao chép kiểu dáng hình ảnh của một mẫu, sử dụng bóng đổ bên trong để tạo cho thẻ hoặc bảng một vẻ ngoài lõm. Bóng đổ ngoài mở rộng ra bên ngoài hình dạng và làm cho nó trông như nổi lên, trong khi bóng đổ bên trong tạo bóng cho phía trong các cạnh của nó.

Gọi [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), sau đó cấu hình bóng đổ được trả về bởi [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Giá trị bán kính làm mờ lớn hơn tạo ra các cạnh mềm hơn.

Ví dụ JavaScript này tạo một thẻ màu xanh nhạt với bóng đổ bên trong màu xám đậm và lưu nó dưới dạng tệp PPTX. Hướng bóng đổ là 225 độ, khoảng cách là 7 điểm và bán kính làm mờ là 6 điểm:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Để loại bỏ bóng đổ bên trong, gọi [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) trên định dạng hiệu ứng của hình dạng.

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides cho Node.js qua Java, bạn có thể thêm một phản chiếu giống gương vào các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ của bản trình bày bằng cách tạo cho các hình dạng vẻ ngoài tinh tế và sang trọng hơn. Nó dễ thực hiện với mã đơn giản, cho phép áp dụng nhanh chóng trên nhiều yếu tố để có thiết kế nhất quán.

Đoạn mã JavaScript này cho thấy cách áp dụng [hiệu ứng phản chiếu](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) cho một hình dạng:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Reflection effect](reflection_effect.png)

## **Áp dụng hiệu ứng hào quang**

Để áp dụng hiệu ứng hào quang cho một hình dạng trong Aspose.Slides cho Node.js qua Java, bạn có thể thêm một hào quang nhẹ, rực rỡ quanh các hình dạng, điều chỉnh các thuộc tính như màu sắc và kích thước. Hiệu ứng này giúp các hình dạng nổi bật và thêm một yếu tố hình ảnh thu hút, bắt mắt vào bản trình bày của bạn. Nó dễ thực hiện với ít mã, nâng cao tổng thể giao diện của các slide.

Đoạn mã JavaScript này cho thấy cách áp dụng [hiệu ứng hào quang](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) cho một hình dạng:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Glow effect](glow_effect.png)

## **Áp dụng hiệu ứng cạnh mềm**

Để áp dụng hiệu ứng cạnh mềm trong Aspose.Slides cho Node.js qua Java, bạn có thể tạo một chuyển tiếp mượt mà, làm mờ quanh các cạnh của một hình dạng. Hiệu ứng này mang lại vẻ ngoài tinh tế và nhẹ nhàng hơn, phù hợp cho các thiết kế cần diện mạo nhẹ nhàng, mềm mại. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu ứng mong muốn trên nhiều hình dạng trong bản trình bày.

Đoạn mã JavaScript này cho thấy cách áp dụng [hiệu ứng cạnh mềm](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) cho một hình dạng:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Soft edges effect](soft_edges_effect.png)

## **Áp dụng hiệu ứng làm mờ**

Sử dụng làm mờ hình dạng để làm mềm màu nền và đường viền của hình dạng trong khi vẫn giữ cho hình dạng có thể chỉnh sửa. Gọi [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) trên định dạng hiệu ứng của hình dạng. Bán kính được đo bằng điểm (1/72 inch): sử dụng giá trị không âm, với giá trị lớn hơn tạo ra độ mờ mạnh hơn. Bán kính bằng không sẽ giữ nguyên giao diện.

Cài đặt [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) điều khiển phạm vi hiển thị của hiệu ứng. Khi `false`, độ mờ bị cắt trong giới hạn đã vẽ ban đầu, bao gồm cả đường viền. Khi `true`, độ mờ có thể mở rộng ra ngoài các giới hạn đó. Cả hai cài đặt đều không thay đổi vị trí hay kích thước của hình dạng.

So sánh dưới đây sử dụng cùng màu nền, đường viền và kích thước hình dạng trong suốt. Hàng trên sử dụng `grow = false`; hàng dưới sử dụng `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Ví dụ JavaScript này tạo một hình chữ nhật màu cam với đường viền màu xanh đậm, áp dụng độ mờ 5 điểm, sau đó cập nhật thành độ mờ 15 điểm bằng cách gọi lại [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) một lần nữa. Nó lưu cả hai trạng thái đã làm mờ, sau đó gọi [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) và lưu hình dạng mà không có độ mờ.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Độ mờ hình dạng ảnh hưởng đến cả màu nền và đường viền cùng lúc. Hiệu ứng cạnh mềm làm mờ các cạnh của hình dạng, trong khi độ mờ bóng chỉ làm mềm bóng. Các hiệu ứng biến đổi hình ảnh hoạt động trên nội dung hình ảnh; ví dụ này áp dụng độ mờ trực tiếp lên định dạng hiệu ứng của hình dạng mà không chuyển hình dạng thành hình ảnh.

## **Câu hỏi thường gặp**

**Có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra một diện mạo sinh động hơn.

**Tôi có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các dạng tự động, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và các loại khác.

**Có thể áp dụng hiệu ứng cho các hình dạng được nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm. Hiệu ứng sẽ áp dụng cho toàn bộ nhóm.