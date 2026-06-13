---
title: ส่วน
type: docs
weight: 90
url: /th/php-java/examples/elements/section/
keywords:
- ส่วน
- ส่วนสไลด์
- เพิ่มส่วน
- เข้าถึงส่วน
- ลบส่วน
- เปลี่ยนชื่อส่วน
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการส่วนของสไลด์ใน PHP ด้วย Aspose.Slides: สร้าง, เปลี่ยนชื่อ, จัดลำดับใหม่ได้ง่าย, ย้ายสไลด์ระหว่างส่วน, และควบคุมการมองเห็นสำหรับ PPT, PPTX และ ODP."
---
ตัวอย่างการจัดการส่วนของงานนำเสนอ—เพิ่ม, เข้าถึง, ลบ และเปลี่ยนชื่อโดยใช้ **Aspose.Slides for PHP via Java** อย่างโปรแกรมเมชัน

## **เพิ่มส่วน**

สร้างส่วนที่เริ่มจากสไลด์เฉพาะ

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // ระบุสไลด์ที่เป็นจุดเริ่มต้นของส่วน.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึงส่วน**

อ่านข้อมูลส่วนจากงานนำเสนอ

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // เข้าถึงส่วนโดยใช้ดัชนี.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบส่วน**

ลบส่วนที่ได้เพิ่มไว้ก่อนหน้า

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // ลบส่วน.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เปลี่ยนชื่อส่วน**

เปลี่ยนชื่อของส่วนที่มีอยู่

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```