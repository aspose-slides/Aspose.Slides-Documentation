---
title: การเคลื่อนไหว
type: docs
weight: 100
url: /th/androidjava/examples/elements/animation/
keywords:
- ตัวอย่างโค้ด
- การเคลื่อนไหว
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สำรวจตัวอย่างการเคลื่อนไหวของ Aspose.Slides สำหรับ Android: เพิ่ม ลำดับ และปรับแต่งเอฟเฟกต์และการเปลี่ยนภาพด้วย Java สำหรับการนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีการสร้างการเคลื่อนไหวแบบง่ายและจัดการลำดับของมันโดยใช้ **Aspose.Slides for Android via Java**.

## **เพิ่มการเคลื่อนไหว**

สร้างรูปสี่เหลี่ยมและใช้เอฟเฟกต์การจางที่ทำงานเมื่อคลิก.

```java
static void addAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

        // เอฟเฟกต์การจาง.
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick
        );
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงการเคลื่อนไหว**

ดึงเอฟเฟกต์การเคลื่อนไหวแรกจากไทม์ไลน์ของสไลด์.

```java
static void accessAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // เข้าถึงเอฟเฟกต์การเคลื่อนไหวแรก.
        IEffect effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **ลบการเคลื่อนไหว**

ลบเอฟเฟกต์การเคลื่อนไหวออกจากลำดับ.

```java
static void removeAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IEffect effect = slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // ลบเอฟเฟกต์.
        slide.getTimeline().getMainSequence().remove(effect);
    } finally {
        presentation.dispose();
    }
}
```

## **ลำดับการเคลื่อนไหว**

เพิ่มเอฟเฟกต์หลายรายการและแสดงลำดับที่การเคลื่อนไหวเกิดขึ้น.

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