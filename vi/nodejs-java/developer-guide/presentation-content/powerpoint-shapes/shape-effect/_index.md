---
title: Áp dụng hiệu ứng hình dạng trong bài thuyết trình bằng JavaScript
linktitle: Hiệu ứng Hình dạng
type: docs
weight: 30
url: /vi/nodejs-java/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng đổ
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng mép mềm
- định dạng hiệu ứng
- PowerPoint
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng JavaScript và Aspose.Slides cho Node.js—tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong PowerPoint, hiệu ứng có thể được sử dụng để làm cho một hình dạng nổi bật, nhưng chúng khác với [đổ màu](/slides/vi/nodejs-java/shape-formatting/#gradient-fill) hoặc viền. Khi sử dụng hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan tỏa ánh sáng hào quang của hình dạng, v.v.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng. 
* Một số kết hợp hiệu ứng trông tốt hơn các kết hợp khác. Vì lý do này, PowerPoint có các tùy chọn dưới **Preset**. Các tùy chọn Preset về cơ bản là một tổ hợp đã được chứng minh là đẹp mắt của hai hoặc nhiều hiệu ứng. Nhờ vậy, khi chọn một preset, bạn sẽ không phải tốn thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một sự kết hợp ưng ý.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/EffectFormat) cho phép bạn áp dụng cùng các hiệu ứng cho các hình dạng trong bản trình bày PowerPoint.

## **Áp dụng hiệu ứng bóng đổ**

Đoạn mã JavaScript này chỉ cho bạn cách áp dụng hiệu ứng bóng đổ bên ngoài ([getOuterShadowEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect)) cho một hình chữ nhật:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "DARK_GRAY"));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Áp dụng hiệu ứng phản chiếu**

Đoạn mã JavaScript này chỉ cho bạn cách áp dụng hiệu ứng phản chiếu cho một hình dạng:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);
    pres.save("reflection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Áp dụng hiệu ứng hào quang**

Đoạn mã JavaScript này chỉ cho bạn cách áp dụng hiệu ứng hào quang cho một hình dạng:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    shape.getEffectFormat().getGlowEffect().setRadius(15);
    pres.save("glow.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Áp dụng hiệu ứng mép mềm**

Đoạn mã JavaScript này chỉ cho bạn cách áp dụng các mép mềm cho một hình dạng:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);
    pres.save("softEdges.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn bóng đổ, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra diện mạo năng động hơn.

**Tôi có thể áp dụng hiệu ứng cho những loại hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các autoshape, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và nhiều hơn nữa.

**Tôi có thể áp dụng hiệu ứng cho các nhóm hình dạng không?**

Có, bạn có thể áp dụng hiệu ứng cho các nhóm hình dạng. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.