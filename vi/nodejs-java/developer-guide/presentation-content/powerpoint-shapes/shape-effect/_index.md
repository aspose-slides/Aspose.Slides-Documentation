---
title: Áp dụng các hiệu ứng hình dạng trong bài thuyết trình bằng JavaScript
linktitle: Hiệu ứng Hình dạng
type: docs
weight: 30
url: /vi/nodejs-java/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng viền mềm
- định dạng hiệu ứng
- PowerPoint
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Biến đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng JavaScript và Aspose.Slides cho Node.js—tạo các slide nổi bật, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được sử dụng để làm nổi bật một hình dạng, chúng khác với [đổ màu](/slides/vi/nodejs-java/shape-formatting/#gradient-fill) hoặc viền. Bằng cách sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan tỏa ánh hào quang của hình dạng, v.v.

![Hiệu ứng hình dạng](shape-effect.png)

PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng.

Một số kết hợp hiệu ứng trông đẹp hơn các kết hợp khác. Vì lý do này, PowerPoint cung cấp các tùy chọn dưới **Preset**. Các tùy chọn Preset là các kết hợp của hai hoặc nhiều hiệu ứng được biết là trông đẹp. Nhờ vậy, khi chọn một preset, bạn sẽ không phải tốn thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một sự kết hợp hợp lý.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình dạng trong bản trình bày PowerPoint.

## **Áp dụng hiệu ứng bóng**

Aspose.Slides for Node.js via Java hỗ trợ bóng ngoài và bóng trong cho các hình dạng. Bạn có thể tùy chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với thiết kế bản trình bày của mình.

### **Áp dụng bóng ngoài**

Sử dụng bóng ngoài để làm cho một thẻ hoặc bảng điều khiển nổi bật so với nền slide. Bóng mở rộng ra ngoài các cạnh của hình dạng, tạo ấn tượng rằng hình dạng được nâng lên trên slide. Điều chỉnh màu, hướng, khoảng cách và bán kính làm mờ để phù hợp với ánh sáng và kiểu dáng của mẫu.

Đoạn mã JavaScript này cho thấy cách áp dụng [hiệu ứng bóng ngoài](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) cho một hình chữ nhật:

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

![Hiệu ứng bóng](shadow_effect.png)

### **Áp dụng bóng trong**

Khi tái tạo kiểu dáng trực quan của một mẫu, sử dụng bóng trong để tạo cho thẻ hoặc bảng điều khiển một vẻ ngoài lõm. Bóng ngoài mở rộng ra bên ngoài hình dạng và làm cho nó trông nổi, trong khi bóng trong tạo bóng cho phía trong các cạnh của nó.

Gọi [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), sau đó cấu hình bóng được trả về bởi [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Giá trị bán kính làm mờ lớn hơn tạo ra các cạnh mềm hơn.

Đoạn mã JavaScript này tạo một thẻ màu xanh nhạt với bóng trong màu xám đậm và lưu nó dưới dạng tệp PPTX. Hướng bóng là 225 độ, khoảng cách là 7 điểm và bán kính làm mờ là 6 điểm:

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

![Hình chữ nhật màu xanh nhạt với bóng trong](inner_shadow_effect.png)

Để xóa bóng trong, gọi [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) trên định dạng hiệu ứng của hình dạng.

### **Áp dụng, thay đổi và xóa bóng đặt trước**

Gọi [enablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enablePresetShadowEffect) và sử dụng [setPreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadow/#setPreset) để chọn một [PresetShadowType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presetshadowtype/). Để chuyển đổi kiểu, thay đổi preset trên cùng một hình dạng. Gọi [disablePresetShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disablePresetShadowEffect) để xóa bóng trong khi vẫn giữ nguyên màu nền và viền.

Ví dụ này hiển thị bốn giai đoạn cạnh nhau trên một slide. Cả hai bóng đều dịch 10 điểm. Hướng 225° đặt bóng đầu tiên lên trên và sang trái của hình chữ nhật, và 45° đặt bóng thứ hai xuống dưới và sang phải.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, aspose.slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const shape = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    const shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(aspose.slides.PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(aspose.slides.PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Gốc | Bóng đặt trước thứ nhất | Bóng đặt trước thứ hai | Sau khi xóa |
| :---: | :---: | :---: | :---: |
| ![Không bóng](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![Không bóng sau khi xóa](preset_shadow_removed.png) |

## **Áp dụng hiệu ứng phản chiếu**

Để áp dụng một hiệu ứng phản chiếu trong Aspose.Slides for Node.js via Java, bạn có thể thêm một phản chiếu giống như gương vào các hình dạng, điều chỉnh các tham số như khoảng cách, độ trong suốt và kích thước. Hiệu ứng này nâng cao thẩm mỹ của bản trình bày bằng cách tạo cho các hình dạng một vẻ ngoài được đánh bóng và tinh tế hơn. Nó dễ thực hiện với mã đơn giản, cho phép áp dụng nhanh chóng trên nhiều phần tử để đạt thiết kế đồng nhất.

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

![Hiệu ứng phản chiếu](reflection_effect.png)

## **Áp dụng hiệu ứng hào quang**

Để áp dụng hiệu ứng hào quang cho một hình dạng trong Aspose.Slides for Node.js via Java, bạn có thể thêm một hào quang mềm mại, phát sáng quanh các hình dạng, điều chỉnh các thuộc tính như màu và kích thước. Hiệu ứng này giúp hình dạng nổi bật và thêm một yếu tố hình ảnh hấp dẫn, thu hút mắt vào bản trình bày của bạn. Nó dễ thực hiện với ít mã, nâng cao tổng thể giao diện của các slide.

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

![Hiệu ứng hào quang](glow_effect.png)

## **Áp dụng hiệu ứng viền mềm**

Để áp dụng hiệu ứng viền mềm trong Aspose.Slides for Node.js via Java, bạn có thể tạo một chuyển đổi mờ dần, mịn màng quanh các cạnh của một hình dạng. Hiệu ứng này thêm một vẻ ngoài tinh tế và nhẹ nhàng hơn, phù hợp với các thiết kế cần một diện mạo mềm mại. Bạn có thể dễ dàng điều chỉnh các tham số như bán kính để đạt được hiệu ứng mong muốn trên nhiều hình dạng trong bản trình bày.

Đoạn mã JavaScript này cho thấy cách áp dụng [hiệu ứng viền mềm](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) cho một hình dạng:

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

![Hiệu ứng viền mềm](soft_edges_effect.png)

## **Áp dụng hiệu ứng làm mờ**

Sử dụng làm mờ hình dạng để làm mềm màu nền và viền của hình dạng đồng thời vẫn giữ cho hình dạng có thể chỉnh sửa được. Gọi [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) trên định dạng hiệu ứng của hình dạng. Bán kính được đo bằng điểm (1/72 inch): sử dụng giá trị không âm, giá trị lớn hơn tạo ra mức độ làm mờ mạnh hơn. Bán kính bằng không sẽ giữ nguyên ngoại hình.

Cài đặt [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) điều khiển giới hạn hiển thị của hiệu ứng. Khi `false`, hiệu ứng làm mờ được cắt trong giới hạn đã vẽ ban đầu, bao gồm cả viền. Khi `true`, hiệu ứng làm mờ có thể mở rộng ra ngoài các giới hạn đó. Cả hai thiết lập đều không thay đổi vị trí hoặc kích thước của hình dạng.

Bảng so sánh dưới đây sử dụng cùng một màu nền, viền và kích thước hình dạng trong suốt quá trình so sánh. Hàng trên dùng `grow = false`; hàng dưới dùng `grow = true`.

![Hình chữ nhật gốc so sánh với bán kính làm mờ 5 và 15 điểm, với grow tắt và bật](shape_blur_comparison.png)

Đoạn mã JavaScript này tạo một hình chữ nhật màu cam với viền màu xanh đậm, áp dụng làm mờ 5 điểm, sau đó cập nhật lên làm mờ 15 điểm bằng cách gọi lại [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect). Nó lưu cả hai trạng thái đã làm mờ, sau đó gọi [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) và lưu hình dạng mà không có làm mờ.

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

Làm mờ hình dạng ảnh hưởng tới cả màu nền và viền đồng thời. Hiệu ứng viền mềm làm mờ các cạnh của hình dạng, trong khi làm mờ bóng chỉ làm mềm bóng. Các hiệu ứng biến đổi ảnh hoạt động trên nội dung ảnh; ví dụ này áp dụng làm mờ trực tiếp lên định dạng hiệu ứng của hình dạng mà không chuyển đổi hình dạng thành ảnh.

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra một ngoại hình năng động hơn.

**Tôi có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các autoshape, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và nhiều hơn nữa.

**Tôi có thể áp dụng hiệu ứng cho các hình dạng được nhóm không?**

Có, bạn có thể áp dụng hiệu ứng cho các hình dạng được nhóm. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.