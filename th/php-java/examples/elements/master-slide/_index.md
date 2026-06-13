---
title: สไลด์มาสเตอร์
type: docs
weight: 30
url: /th/php-java/examples/elements/master-slide/
keywords:
- สไลด์มาสเตอร์
- เพิ่มสไลด์มาสเตอร์
- เข้าถึงสไลด์มาสเตอร์
- ลบสไลด์มาสเตอร์
- สไลด์มาสเตอร์ที่ไม่ได้ใช้
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการสไลด์มาสเตอร์ใน PHP ด้วย Aspose.Slides: สร้าง, แก้ไข, คัดลอก, และจัดรูปแบบธีม, พื้นหลัง, ตัวแทนตำแหน่งเพื่อทำให้สไลด์ใน PowerPoint และ OpenDocument มีความสอดคล้องกัน."
---
สไลด์มาสเตอร์เป็นระดับบนสุดของลำดับชั้นการสืบทอดสไลด์ใน PowerPoint. **สไลด์มาสเตอร์** กำหนดองค์ประกอบการออกแบบที่ใช้ร่วมกันเช่นพื้นหลัง, โลโก้, และการจัดรูปแบบข้อความ. **สไลด์เค้าโครง** สืบทอดจากสไลด์มาสเตอร์, และ **สไลด์ปกติ** สืบทอดจากสไลด์เค้าโครง.

บทความนี้สาธิตวิธีสร้าง, แก้ไข, และจัดการสไลด์มาสเตอร์โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java.

## **เพิ่มสไลด์มาสเตอร์**

ตัวอย่างนี้แสดงวิธีสร้างสไลด์มาสเตอร์ใหม่โดยการโคลนสไลด์เริ่มต้น.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // คัดลอกสไลด์มาสเตอร์เริ่มต้น.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **เคล็ดลับ 1:** สไลด์มาสเตอร์ให้วิธีการใช้แบรนด์หรือองค์ประกอบการออกแบบที่สอดคล้องกันทั่วทั้งหมดของสไลด์ การเปลี่ยนแปลงใด ๆ ที่ทำกับมาสเตอร์จะสะท้อนได้โดยอัตโนมัติบนสไลด์เค้าโครงและสไลด์ปกติที่ขึ้นอยู่.

> 💡 **เคล็ดลับ 2:** รูปร่างหรือการจัดรูปแบบใด ๆ ที่เพิ่มลงในสไลด์มาสเตอร์จะถูกสืบทอดโดยสไลด์เค้าโครงและต่อจากนั้นสไลด์ปกติทั้งหมดที่ใช้เค้าโครงเหล่านั้น.
> ภาพด้านล่างแสดงให้เห็นว่ากล่องข้อความที่เพิ่มบนสไลด์มาสเตอร์จะถูกเรนเดอร์โดยอัตโนมัติบนสไลด์สุดท้าย.

![Master Inheritance Example](master-slide-banner.png)

## **เข้าถึงสไลด์มาสเตอร์**

คุณสามารถเข้าถึงสไลด์มาสเตอร์โดยใช้เมธอด `Presentation::getMasters`ได้ นี่คือวิธีดึงและทำงานกับสไลด์เหล่านั้น:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // เข้าถึงสไลด์มาสเตอร์แรก.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบสไลด์มาสเตอร์**

สไลด์มาสเตอร์สามารถลบได้โดยใช้ดัชนีหรือโดยอ้างอิง.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // ลบตามดัชนี.
        $presentation->getMasters()->removeAt(0);

        // หรือลบตามอ้างอิง.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้**

บางงานนำเสนอมีสไลด์มาสเตอร์ที่ไม่ได้ใช้งาน การลบสไลด์เหล่านี้สามารถช่วยลดขนาดไฟล์ได้.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้ทั้งหมด (รวมถึงสไลด์ที่ถูกทำเครื่องหมายว่า Preserve).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **เคล็ดลับ:** ใช้ `removeUnused(true)` เพื่อล้างสไลด์มาสเตอร์ที่ไม่ได้ใช้และลดขนาดของงานนำเสนอ.