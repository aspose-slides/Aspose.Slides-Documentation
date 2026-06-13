---
title: ไฮเปอร์ลิงก์
type: docs
weight: 130
url: /th/php-java/examples/elements/hyperlink/
keywords:
- ไฮเปอร์ลิงก์
- เพิ่มไฮเปอร์ลิงก์
- เข้าถึงไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เพิ่ม, แก้ไข และลบไฮเปอร์ลิงก์ใน PHP ด้วย Aspose.Slides: ข้อความลิงก์, รูปทรง, สไลด์, URL และอีเมล; ตั้งค่าเป้าหมายและการกระทำสำหรับ PPT, PPTX และ ODP."
---
สาธิตการเพิ่ม, เข้าถึง, ลบ, และอัปเดตไฮเปอร์ลิงก์บนรูปทรงโดยใช้ **Aspose.Slides for PHP via Java**.

## **เพิ่มไฮเปอร์ลิงก์**

สร้างรูปสี่เหลี่ยมผืนผ้าพร้อมไฮเปอร์ลิงก์ที่ชี้ไปยังเว็บไซต์ภายนอก.

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึงไฮเปอร์ลิงก์**

อ่านข้อมูลไฮเปอร์ลิงก์จากส่วนข้อความของรูปทรง.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่า shape แรกมีไฮเปอร์ลิงก์อยู่.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบไฮเปอร์ลิงก์**

ล้างไฮเปอร์ลิงก์ออกจากข้อความของรูปทรง.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่า shape แรกมีไฮเปอร์ลิงก์อยู่.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **อัปเดตไฮเปอร์ลิงก์**

เปลี่ยนเป้าหมายของไฮเปอร์ลิงก์ที่มีอยู่ ใช้ `HyperlinkManager` เพื่อแก้ไขข้อความที่มีไฮเปอร์ลิงก์อยู่แล้ว ซึ่งทำหน้าที่เหมือนวิธีที่ PowerPoint อัปเดตไฮเปอร์ลิงก์อย่างปลอดภัย.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สมมติว่า shape แรกมีไฮเปอร์ลิงก์อยู่.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // การเปลี่ยนไฮเปอร์ลิงก์ในข้อความที่มีอยู่ควรทำผ่าน
        // HyperlinkManager แทนการตั้งค่า property โดยตรง.
        // สิ่งนี้เลียนแบบวิธีที่ PowerPoint ปรับปรุงไฮเปอร์ลิงก์อย่างปลอดภัย.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```