---
title: แอนิเมชัน
type: docs
weight: 100
url: /th/nodejs-java/examples/elements/animation/
keywords:
- ตัวอย่างโค้ด
- แอนิเมชัน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สำรวจตัวอย่างแอนิเมชันของ Aspose.Slides สำหรับ Node.js: เพิ่ม, จัดลำดับ, และปรับแต่งเอฟเฟกต์และการเปลี่ยนภาพด้วย JavaScript สำหรับการนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้สาธิตวิธีการสร้างแอนิเมชันง่าย ๆ และจัดการลำดับของมันโดยใช้ **Aspose.Slides for Node.js via Java**.

## **เพิ่มแอนิเมชัน**

สร้างรูปสี่เหลี่ยมและใช้เอฟเฟ็กต์การจางหายที่ทำงานเมื่อคลิก.

```js
function addAnimation() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100);

        // เอฟเฟ็กต์จาง.
        slide.getTimeline().getMainSequence().addEffect(
            shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

        presentation.save("animation.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงแอนิเมชัน**

ดึงเอฟเฟ็กต์แอนิเมชันแรกจากไทม์ไลน์ของสไลด์.

```js
function accessAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // เข้าถึงเอฟเฟกต์แอนิเมชันแรก.
        let effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **ลบแอนิเมชัน**

ลบเอฟเฟ็กต์แอนิเมชันออกจากลำดับ.

```js
function removeAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getTimeline().getMainSequence().length > 0) {
            // ลบเอฟเฟกต์แรก.
            slide.getTimeline().getMainSequence().removeAt(0);
        }

        presentation.save("animation_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ลำดับแอนิเมชัน**

เพิ่มเอฟเฟ็กต์หลายตัวและแสดงลำดับที่แอนิเมชันทำงาน.

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