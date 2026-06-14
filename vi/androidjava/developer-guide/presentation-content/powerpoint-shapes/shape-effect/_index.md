---
title: Áp dụng hiệu ứng hình dạng trong bản trình chiếu trên Android
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
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Biến đổi các tệp PPT và PPTX của bạn với các hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho Android thông qua Java—tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được dùng để làm nổi bật một hình dạng, chúng khác với [fills](/slides/vi/androidjava/shape-formatting/#gradient-fill) hoặc đường viền. Bằng cách sử dụng các hiệu ứng của PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan tỏa ánh hào quang của hình, v.v.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng. 

* Một số kết hợp hiệu ứng trông tốt hơn so với những cái khác. Vì lý do này, PowerPoint có tùy chọn dưới **Preset**. Các tùy chọn Preset thực chất là một sự kết hợp đã được biết là đẹp mắt của hai hoặc nhiều hiệu ứng. Nhờ vậy, khi chọn một preset, bạn sẽ không phải tốn thời gian thử nghiệm hoặc kết hợp các hiệu ứng khác nhau để tìm ra một sự kết hợp ưng ý.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/EffectFormat) cho phép bạn áp dụng cùng các hiệu ứng cho các hình dạng trong bản trình bày PowerPoint.

## **Áp dụng hiệu ứng bóng**

Đoạn mã Java này cho bạn thấy cách áp dụng hiệu ứng bóng ngoài ([OuterShadowEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) cho một hình chữ nhật:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Áp dụng hiệu ứng phản chiếu**

Đoạn mã Java này cho bạn thấy cách áp dụng hiệu ứng phản chiếu cho một hình dạng:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Áp dụng hiệu ứng hào quang**

Đoạn mã Java này cho bạn thấy cách áp dụng hiệu ứng hào quang cho một hình dạng:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Áp dụng hiệu ứng viền mềm**

Đoạn mã Java này cho bạn thấy cách áp dụng viền mềm cho một hình dạng:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, như bóng, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra một diện mạo năng động hơn.

**Tôi có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các autoshape, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE, và nhiều hơn nữa.

**Tôi có thể áp dụng hiệu ứng cho các nhóm hình dạng không?**

Có, bạn có thể áp dụng hiệu ứng cho các nhóm hình dạng. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.