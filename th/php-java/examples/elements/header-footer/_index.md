---
title: ส่วนหัวและส่วนท้าย
type: docs
weight: 220
url: /th/php-java/examples/elements/header-footer/
keywords:
- ส่วนหัวและส่วนท้าย
- เพิ่มส่วนหัวและส่วนท้าย
- อัปเดตส่วนหัวและส่วนท้าย
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "ควบคุมส่วนหัวและส่วนท้ายใน PHP ด้วย Aspose.Slides: เพิ่มหรือแก้ไขวันที่/เวลา, หมายเลขสไลด์, และข้อความส่วนท้าย, แสดงหรือซ่อนตัวแปรตำแหน่งในไฟล์ PPT, PPTX และ ODP."
---
แสดงวิธีการเพิ่มส่วนท้ายและอัปเดตตัวแปรตำแหน่งของวันที่และเวลาโดยใช้ **Aspose.Slides for PHP via Java**.

## **เพิ่มส่วนท้าย**
เพิ่มข้อความลงในพื้นที่ส่วนท้ายของสไลด์และทำให้แสดงผล.

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **อัปเดตวันที่และเวลา**
แก้ไขตำแหน่งตัวอ้างอิงของวันที่และเวลาในสไลด์.

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```