---
title: สไลด์เค้าโครง
type: docs
weight: 20
url: /th/php-java/examples/elements/layout-slide/
keywords:
- สไลด์เค้าโครง
- เพิ่มสไลด์เค้าโครง
- เข้าถึงสไลด์เค้าโครง
- ลบสไลด์เค้าโครง
- สไลด์เค้าโครงที่ไม่ได้ใช้
- คัดลอกสไลด์เค้าโครง
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ใช้ PHP เพื่อจัดการสไลด์เค้าโครงด้วย Aspose.Slides: สร้าง, ใช้, คัดลอก, เปลี่ยนชื่อ และปรับแต่งตัวแสดงตำแหน่งและธีมในงานนำเสนอสำหรับ PPT, PPTX และ ODP."
---
บทความนี้แสดงวิธีการทำงานกับ **Layout Slides** ใน Aspose.Slides สำหรับ PHP ผ่าน Java. Layout slide กำหนดการออกแบบและรูปแบบที่สไลด์ปกติสืบทอดมา. คุณสามารถเพิ่ม, เข้าถึง, คัดลอก, และลบ layout slides, รวมถึงทำความสะอาดสไลด์ที่ไม่ได้ใช้เพื่อลดขนาดการนำเสนอ.

## **เพิ่ม Layout Slide**

คุณสามารถสร้าง layout slide ที่กำหนดเองเพื่อกำหนดรูปแบบที่นำกลับมาใช้ได้ใหม่. ตัวอย่างเช่น คุณอาจเพิ่มกล่องข้อความที่ปรากฏบนทุกสไลด์ที่ใช้ layout นี้.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // สร้างสไลด์เค้าโครงด้วยประเภทเค้าโครงแบบว่างและชื่อที่กำหนดเอง.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** Layout slides ทำหน้าที่เป็นแม่แบบสำหรับสไลด์แต่ละอัน. คุณสามารถกำหนดองค์ประกอบทั่วไปครั้งเดียวและนำไปใช้ซ้ำในหลายสไลด์.

> 💡 **Tip 2:** เมื่อคุณเพิ่มรูปร่างหรือข้อความลงใน layout slide, สไลด์ทั้งหมดที่อิงจาก layout นี้จะแสดงเนื้อหาร่วมนี้โดยอัตโนมัติ.
> ภาพหน้าจอต่างด้านล่างแสดงสไลด์สองสไลด์ ที่แต่ละสไลด์สืบทอดกล่องข้อความจาก layout slide เดียวกัน.

![สไลด์ที่สืบทอดเนื้อหา Layout](layout-slide-result.png)


## **เข้าถึง Layout Slide**

สามารถเข้าถึง Layout slides ได้โดยใช้ดัชนีหรือโดยประเภทของ layout (เช่น `Blank`, `Title`, `SectionHeader`, เป็นต้น).

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // เข้าถึงโดยใช้ดัชนี.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // เข้าถึงโดยประเภทเค้าโครง.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบ Layout Slide**

คุณสามารถลบ layout slide เฉพาะที่ไม่ต้องการใช้อีกต่อไปได้.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // รับสไลด์เค้าโครงตามประเภทและลบมัน.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบ Layout Slides ที่ไม่ได้ใช้**

เพื่อลดขนาดการนำเสนอ คุณอาจต้องการลบ layout slides ที่ไม่มีสไลด์ปกติใดใช้.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // ลบสไลด์เค้าโครงทั้งหมดที่ไม่ได้อ้างอิงโดยสไลด์ใดโดยอัตโนมัติ.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **คัดลอก Layout Slide**

คุณสามารถทำสำเนา layout slide โดยใช้เมธอด `addClone`.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // รับสไลด์เค้าโครงที่มีอยู่ตามประเภท.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // คัดลอกสไลด์เค้าโครงไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์เค้าโครง.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **สรุป:** Layout slides เป็นเครื่องมือที่มีประสิทธิภาพในการจัดการรูปแบบที่สอดคล้องกันทั่วสไลด์. Aspose.Slides ให้การควบคุมเต็มรูปแบบในการสร้าง, จัดการ, และเพิ่มประสิทธิภาพของ layout slides.