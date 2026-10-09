---
title: Áp dụng hiệu ứng hình dạng trong bản trình bày bằng JavaScript
linktitle: Hiệu ứng hình dạng
type: docs
weight: 30
url: /vi/nodejs-java/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng đổ bóng
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng cạnh mềm
- định dạng hiệu ứng
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Biến đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng JavaScript và Aspose.Slides cho Node.js—tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong PowerPoint, các hiệu ứng có thể được dùng để làm nổi bật một hình dạng, nhưng chúng khác với [đổ màu](/slides/vi/nodejs-java/shape-formatting/#gradient-fill) hoặc viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra những phản chiếu thuyết phục trên một hình dạng, lan truyền ánh hào quang của hình dạng, v.v.

![Shape effect](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số phối hợp hiệu ứng trông đẹp hơn các phối hợp khác. Vì lý do này, PowerPoint cung cấp các tùy chọn dưới **Preset**. Các tùy chọn Preset là các kết hợp của hai hoặc nhiều hiệu ứng đã được chứng minh là nhìn tốt. Nhờ đó, khi chọn một preset, bạn sẽ không phải tốn thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một sự kết hợp ưng ý.

Aspose.Slides cung cấp các thuộc tính và phương thức dưới lớp [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình dạng trong bản trình bày PowerPoint.

## **Áp dụng hiệu ứng Đổ bóng**

Aspose.Slides for Node.js via Java hỗ trợ đổ bóng ngoài và trong cho các hình dạng. Bạn có thể tùy chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với thiết kế của bản trình bày.

### **Áp dụng đổ bóng ngoài**

Sử dụng đổ bóng ngoài để làm cho một thẻ hoặc bảng điều khiển nổi bật so với nền slide. Đổ bóng mở rộng ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và kiểu dáng của mẫu.

Đoạn mã JavaScript sau minh họa cách áp dụng [outer shadow effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) cho một hình chữ nhật:

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

### **Áp dụng đổ bóng trong**

Khi sao chép phong cách hình ảnh của một mẫu, sử dụng đổ bóng trong để tạo cảm giác lõm cho thẻ hoặc bảng điều khiển. Đổ bóng ngoài mở rộng ra bên ngoài hình dạng và làm cho nó trông nổi lên, trong khi đổ bóng trong làm tối các cạnh bên trong.

Gọi [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), sau đó cấu hình đổ bóng trả về bởi [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Giá trị bán kính làm mờ lớn hơn tạo ra các cạnh mềm hơn.

Đoạn JavaScript dưới đây tạo một thẻ màu xanh nhạt với đổ bóng trong màu xám đậm và lưu nó dưới dạng tệp PPTX. Hướng đổ bóng là 225 độ, khoảng cách là 7 điểm, và bán kính làm mờ là 6 điểm:

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

Để loại bỏ đổ bóng trong, gọi [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) trên định dạng hiệu ứng của hình dạng.

## **Áp dụng hiệu ứng Phản chiếu**

Để áp dụng hiệu ứng phản chiếu trong Aspose.Slides for Node.js via Java, bạn có thể thêm một phản chiếu giống gương cho các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ của bản trình bày bằng cách tạo cho các hình dạng một vẻ ngoài tinh tế và chuyên nghiệp. Nó dễ thực hiện với đoạn mã ngắn gọn, cho phép áp dụng nhanh chóng trên nhiều yếu tố để đạt thiết kế đồng nhất.

Đoạn mã JavaScript sau hiển thị cách áp dụng [reflection effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) cho một hình dạng:

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

## **Áp dụng hiệu ứng Hào quang**

Để áp dụng hiệu ứng hào quang cho một hình dạng trong Aspose.Slides for Node.js via Java, bạn có thể thêm một hào quang mềm mại xung quanh các hình dạng, điều chỉnh các thuộc tính như màu và kích thước. Hiệu ứng này giúp các hình dạng nổi bật và tạo yếu tố hình ảnh thu hút, bắt mắt cho bản trình bày. Nó dễ triển khai với ít mã, nâng cao tổng thể vẻ ngoài của các slide.

Đoạn mã JavaScript dưới đây cho thấy cách áp dụng [glow effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) cho một hình dạng:

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

## **Áp dụng hiệu ứng Cạnh mềm**

Để áp dụng hiệu ứng cạnh mềm trong Aspose.Slides for Node.js via Java, bạn có thể tạo một chuyển tiếp mờ, mượt quanh các cạnh của một hình dạng. Hiệu ứng này mang lại vẻ ngoài tinh tế, nhẹ nhàng, phù hợp cho các thiết kế cần sự mềm mại. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu quả mong muốn trên nhiều hình dạng trong bản trình bày.

Đoạn mã JavaScript sau mô tả cách áp dụng [soft edges effect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) cho một hình dạng:

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

## **CÂU HỎI THƯỜNG GẶP**

**Tôi có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như đổ bóng, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra diện mạo động hơn.

**Tôi có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho các loại hình dạng khác nhau, bao gồm các hình tự động, biểu đồ, bảng, ảnh, đối tượng SmartArt, đối tượng OLE và hơn nữa.

**Tôi có thể áp dụng hiệu ứng cho các hình dạng được nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.