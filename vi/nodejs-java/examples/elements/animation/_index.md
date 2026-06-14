---
title: Hoạt ảnh
type: docs
weight: 100
url: /vi/nodejs-java/examples/elements/animation/
keywords:
- ví dụ mã
- hoạt ảnh
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá các ví dụ hoạt ảnh Aspose.Slides cho Node.js: thêm, sắp xếp và tùy chỉnh các hiệu ứng và chuyển đổi bằng JavaScript cho các bản trình bày PPT, PPTX và ODP."
---
Bài viết này trình bày cách tạo các hoạt ảnh đơn giản và quản lý chuỗi chúng bằng **Aspose.Slides for Node.js via Java**.

## **Thêm một hoạt ảnh**

Tạo một hình chữ nhật và áp dụng hiệu ứng mờ dần được kích hoạt khi nhấp chuột.

```js
function addAnimation() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100);

        // Hiệu ứng mờ dần.
        slide.getTimeline().getMainSequence().addEffect(
            shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

        presentation.save("animation.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập một hoạt ảnh**

Lấy hiệu ứng hoạt ảnh đầu tiên từ dòng thời gian của slide.

```js
function accessAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Truy cập hiệu ứng hoạt ảnh đầu tiên.
        let effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa một hoạt ảnh**

Xóa một hiệu ứng hoạt ảnh khỏi chuỗi.

```js
function removeAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getTimeline().getMainSequence().length > 0) {
            // Xóa hiệu ứng đầu tiên.
            slide.getTimeline().getMainSequence().removeAt(0);
        }

        presentation.save("animation_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Sắp xếp chuỗi hoạt ảnh**

Thêm nhiều hiệu ứng và minh họa thứ tự các hoạt ảnh diễn ra.

```js
function sequenceAnimations() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100);
        let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 200, 50, 100, 100);

        let sequence = slide.getTimeline().getMainSequence();
        sequence.addEffect(
            shape1, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);
        sequence.addEffect(
            shape2, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);

        presentation.save("animation_sequence.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```