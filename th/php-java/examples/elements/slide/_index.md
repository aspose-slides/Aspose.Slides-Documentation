---
title: สไลด์
type: docs
weight: 10
url: /th/php-java/examples/elements/slide/
keywords:
- สไลด์
- เพิ่มสไลด์
- เข้าถึงสไลด์
- ดัชนีสไลด์
- คัดลอกสไลด์
- เรียงลำดับสไลด์ใหม่
- ลบสไลด์
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "จัดการสไลด์ใน PHP ด้วย Aspose.Slides: สร้าง, คัดลอก, เรียงลำดับใหม่, ซ่อน, ตั้งค่าพื้นหลังและขนาด, ใส่การเปลี่ยนภาพ, และส่งออกสำหรับ PowerPoint และ OpenDocument."
---
บทความนี้นำเสนอชุดตัวอย่างที่แสดงวิธีการทำงานกับสไลด์โดยใช้ **Aspose.Slides for PHP via Java** คุณจะได้เรียนรู้วิธีการเพิ่ม, เข้าถึง, คัดลอก, เรียงลำดับใหม่, และลบสไลด์ด้วยคลาส `Presentation`

แต่ละตัวอย่างด้านล่างประกอบด้วยคำอธิบายสั้น ๆ ตามด้วยโค้ดสแนปเพ็ตใน PHP

## **เพิ่มสไลด์**

เพื่อเพิ่มสไลด์ใหม่ คุณต้องเลือกเค้าโครงก่อน ในตัวอย่างนี้เราใช้เค้าโครง `Blank` และเพิ่มสไลด์เปล่าลงในงานนำเสนอ

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // แต่ละสไลด์อิงตามเค้าโครงซึ่งอิงตามมาสเตอร์สไลด์
        // ใช้เค้าโครง Blank เพื่อสร้างสไลด์ใหม่
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Add a new empty slide using the selected layout.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **เคล็ดลับ:** เค้าโครงแต่ละแบบสืบทอดมาจากมาสเตอร์สไลด์ซึ่งกำหนดการออกแบบโดยรวมและโครงสร้างของตัวพักข้อมูล รูปภาพด้านล่างแสดงวิธีที่มาสเตอร์สไลด์และเค้าโครงที่เกี่ยวข้องจัดเรียงกันใน PowerPoint

![ความสัมพันธ์ระหว่างมาสเตอร์และเลเอาต์](master-layout-slide.png)

## **เข้าถึงสไลด์ตามเลขลำดับ**

คุณสามารถเข้าถึงสไลด์โดยใช้เลขลำดับของมันได้

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // เข้าถึงสไลด์ตามดัชนี.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **คัดลอกสไลด์**

ตัวอย่างนี้แสดงวิธีคัดลอกสไลด์ที่มีอยู่ สไลด์ที่คัดลอกจะถูกเพิ่มโดยอัตโนมัติไปยังตำแหน่งสุดท้ายของชุดสไลด์

```php
function cloneSlide() {
    // ตามค่าเริ่มต้น การนำเสนอมีสไลด์เปล่า 1 สไลด์.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // คัดลอกสไลด์แรก; จะถูกเพิ่มไปที่ท้ายของการนำเสนอ.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // ดัชนีของสไลด์ที่คัดลอกคือ 1 (สไลด์ที่สองในการนำเสนอ).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เรียงลำดับสไลด์ใหม่**

คุณสามารถเปลี่ยนลำดับของสไลด์ได้โดยย้ายสไลด์ไปยังตำแหน่งดัชนีใหม่ ในกรณีนี้ เราย้ายสไลด์ไปยังตำแหน่งแรก

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // ย้ายสไลด์ไปยังตำแหน่งแรก (สไลด์อื่นเลื่อนลง).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบสไลด์**

เพื่อลบสไลด์ เพียงอ้างอิงสไลด์นั้นแล้วเรียก `remove` ตัวอย่างนี้ลบสไลด์โดยใช้เลขลำดับและโดยอ้างอิง

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // ลบสไลด์ตามดัชนี.
        $presentation->getSlides()->removeAt(0);

        // ลบสไลด์โดยอ้างอิง.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```