---
title: การเปลี่ยนสไลด์
type: docs
weight: 110
url: /th/php-java/examples/elements/slide-transition/
keywords:
- การเปลี่ยนสไลด์
- เพิ่มการเปลี่ยนสไลด์
- เข้าถึงการเปลี่ยนสไลด์
- ลบการเปลี่ยนสไลด์
- ระยะเวลาการเปลี่ยน
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ควบคุมการเปลี่ยนสไลด์ใน PHP ด้วย Aspose.Slides: เลือกประเภท, ความเร็ว, เสียง และการตั้งเวลา เพื่อปรับปรุงการนำเสนอใน PPT, PPTX และ ODP."
---
สาธิตการใช้เอฟเฟ็กต์การเปลี่ยนสไลด์และการตั้งเวลาโดยใช้ **Aspose.Slides for PHP via Java**.

## **เพิ่มการเปลี่ยนสไลด์**

ใช้เอฟเฟ็กต์การเปลี่ยนแบบจางบนสไลด์แรก.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // ใช้การเปลี่ยนแบบจาง.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึงการเปลี่ยนสไลด์**

อ่านประเภทการเปลี่ยนที่กำหนดให้กับสไลด์

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เข้าถึงประเภทการเปลี่ยน
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบการเปลี่ยนสไลด์**

ลบเอฟเฟ็กต์การเปลี่ยนใด ๆ โดยตั้งค่าประเภทเป็น `None`.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // ลบการเปลี่ยนโดยตั้งค่าเป็นไม่มี.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ตั้งค่าระยะเวลาการเปลี่ยน**

กำหนดระยะเวลาที่สไลด์จะแสดงก่อนที่จะเลื่อนต่อโดยอัตโนมัติ.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // เป็นมิลลิวินาที.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```