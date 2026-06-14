---
title: Hoạt ảnh
type: docs
weight: 100
url: /vi/java/examples/elements/animation/
keywords:
- ví dụ mã
- hoạt ảnh
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Khám phá các ví dụ hoạt ảnh Aspose.Slides for Java: thêm, sắp xếp chuỗi và tùy chỉnh hiệu ứng và chuyển đổi bằng Java cho các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách tạo các hoạt ảnh đơn giản và quản lý chuỗi của chúng bằng **Aspose.Slides for Java**.

## **Thêm hoạt ảnh**

Tạo một hình chữ nhật và áp dụng hiệu ứng mờ dần được kích hoạt khi nhấp chuột.

```java
static void addAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

        // Hiệu ứng mờ dần.
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick
        );
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập hoạt ảnh**

Lấy hiệu ứng hoạt ảnh đầu tiên từ dòng thời gian của slide.

```java
static void accessAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Truy cập hiệu ứng hoạt ảnh đầu tiên.
        IEffect effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa hoạt ảnh**

Xóa một hiệu ứng hoạt ảnh khỏi chuỗi.

```java
static void removeAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IEffect effect = slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Xóa hiệu ứng.
        slide.getTimeline().getMainSequence().remove(effect);
    } finally {
        presentation.dispose();
    }
}
```

## **Sắp xếp chuỗi hoạt ảnh**

Thêm nhiều hiệu ứng và minh họa thứ tự các hoạt ảnh diễn ra.

```java
static void sequenceAnimations() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

        ISequence sequence = slide.getTimeline().getMainSequence();
        sequence.addEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
        sequence.addEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    } finally {
        presentation.dispose();
    }
}
```