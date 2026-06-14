---
title: Áp dụng hiệu ứng hình dạng trong bài thuyết trình bằng Java
linktitle: Hiệu ứng hình dạng
type: docs
weight: 30
url: /vi/java/shape-effect/
keywords:
- hiệu ứng hình dạng
- hiệu ứng bóng đổ
- hiệu ứng phản chiếu
- hiệu ứng hào quang
- hiệu ứng cạnh mềm
- định dạng hiệu ứng
- PowerPoint
- bài thuyết trình
- Java
- Aspose.Slides
description: "Chuyển đổi các tệp PPT và PPTX của bạn với những hiệu ứng hình dạng nâng cao bằng Aspose.Slides cho Java - tạo các slide ấn tượng, chuyên nghiệp trong vài giây."
---
## **Giới thiệu**

Trong khi các hiệu ứng trong PowerPoint có thể được dùng để làm nổi bật một hình dạng, chúng khác với [fills](/slides/vi/java/shape-formatting/#gradient-fill) hoặc viền. Sử dụng các hiệu ứng PowerPoint, bạn có thể tạo ra các phản chiếu thuyết phục trên một hình dạng, lan truyền ánh sáng hào quang của hình dạng, v.v.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint cung cấp sáu hiệu ứng có thể áp dụng cho các hình dạng. Bạn có thể áp dụng một hoặc nhiều hiệu ứng cho một hình dạng. 

* Một số kết hợp hiệu ứng trông tốt hơn những kết hợp khác. Vì lý do này, PowerPoint có các tùy chọn dưới **Preset**. Các tùy chọn Preset về cơ bản là một sự kết hợp đã được chứng minh là đẹp mắt của hai hoặc nhiều hiệu ứng. Nhờ vậy, khi chọn một preset, bạn sẽ không phải tốn thời gian kiểm tra hoặc kết hợp các hiệu ứng khác nhau để tìm ra một sự kết hợp hợp lý.

Aspose.Slides cung cấp các thuộc tính và phương thức trong lớp [EffectFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/EffectFormat) cho phép bạn áp dụng các hiệu ứng tương tự cho các hình dạng trong bản trình chiếu PowerPoint.

## **Áp dụng hiệu ứng bóng đổ**

Đoạn mã Java này cho bạn thấy cách áp dụng hiệu ứng bóng đổ ngoài ([OuterShadowEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) cho một hình chữ nhật:

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

## **Áp dụng hiệu ứng cạnh mềm**

Đoạn mã Java này cho bạn thấy cách áp dụng cạnh mềm cho một hình dạng:

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

## **FAQ**

**Tôi có thể áp dụng nhiều hiệu ứng cho cùng một hình dạng không?**

Có, bạn có thể kết hợp các hiệu ứng khác nhau, chẳng hạn như bóng đổ, phản chiếu và hào quang, trên một hình dạng duy nhất để tạo ra giao diện năng động hơn.

**Tôi có thể áp dụng hiệu ứng cho những hình dạng nào?**

Bạn có thể áp dụng hiệu ứng cho nhiều loại hình dạng, bao gồm các autoshape, biểu đồ, bảng, hình ảnh, đối tượng SmartArt, đối tượng OLE và hơn thế nữa.

**Tôi có thể áp dụng hiệu ứng cho các nhóm hình dạng không?**

Có, bạn có thể áp dụng hiệu ứng cho các nhóm hình dạng. Hiệu ứng sẽ được áp dụng cho toàn bộ nhóm.