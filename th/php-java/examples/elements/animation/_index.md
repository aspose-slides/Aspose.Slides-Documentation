---
title: การเคลื่อนไหว
type: docs
weight: 100
url: /th/php-java/examples/elements/animation/
keywords:
- การเคลื่อนไหว
- เพิ่มการเคลื่อนไหว
- เข้าถึงการเคลื่อนไหว
- ลบการเคลื่อนไหว
- ลำดับการเคลื่อนไหว
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ควบคุมการเคลื่อนที่ของสไลด์ใน PHP ด้วย Aspose.Slides: เพิ่ม แก้ไข และลบเอฟเฟกต์ การตั้งเวลา และทริกเกอร์ เพื่อสร้างการนำเสนอแบบไดนามิกใน PPT, PPTX และ ODP."
---
แสดงวิธีสร้างการเคลื่อนไหวแบบง่ายและจัดการลำดับของพวกมันโดยใช้ **Aspose.Slides for PHP via Java**.

## **เพิ่มการเคลื่อนไหว**
สร้างรูปสี่เหลี่ยมผืนผ้าและใช้เอฟเฟกต์การค่อยๆ ปรากฏเมื่อคลิก.

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // เอฟเฟกต์ค่อยๆ ปรากฏ.
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึงการเคลื่อนไหว**
ดึงเอฟเฟกต์การเคลื่อนไหวแรกจากไทม์ไลน์ของสไลด์.

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เข้าถึงเอฟเฟกต์การเคลื่อนไหวแรก.
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบการเคลื่อนไหว**
ลบเอฟเฟกต์การเคลื่อนไหวออกจากลำดับ.

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // ลบเอฟเฟกต์.
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ลำดับการเคลื่อนไหว**
เพิ่มเอฟเฟกต์หลายรายการและแสดงลำดับที่การเคลื่อนไหวเกิดขึ้น.

```php
function sequenceAnimations() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 200, 50, 100, 100);

        $sequence = $slide->getTimeline()->getMainSequence();
        $sequence->addEffect($shape1, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
        $sequence->addEffect($shape2, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);

        $presentation->save("animation_sequence.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```