---
title: ไฮเปอร์ลิงก์
type: docs
weight: 130
url: /th/androidjava/examples/elements/hyperlink/
keywords:
- ตัวอย่างโค้ด
- ไฮเปอร์ลิงก์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เพิ่มและจัดการไฮเปอร์ลิงก์ใน Aspose.Slides สำหรับ Android: เชื่อมข้อความ, รูปทรง, และภาพ, ตั้งค่าเป้าหมายและการดำเนินการสำหรับ PPT, PPTX, และ ODP ด้วยตัวอย่าง Java."
---
บทความนี้แสดงวิธีการเพิ่ม, เข้าถึง, ลบ และอัปเดตไฮเปอร์ลิงก์บนรูปทรงโดยใช้ **Aspose.Slides for Android via Java**.

## **เพิ่มไฮเปอร์ลิงก์**

สร้างรูปสี่เหลี่ยมผืนผ้าที่มีไฮเปอร์ลิงก์ชี้ไปยังเว็บไซต์ภายนอก.

```java
static void addHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงไฮเปอร์ลิงก์**

อ่านข้อมูลไฮเปอร์ลิงก์จากส่วนข้อความของรูปทรง.

```java
static void accessHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        IHyperlink hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **ลบไฮเปอร์ลิงก์**

ล้างไฮเปอร์ลิงก์ออกจากข้อความของรูปทรง.

```java
static void removeHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        textPortion.getPortionFormat().setHyperlinkClick(null);
    } finally {
        presentation.dispose();
    }
}
```

## **อัปเดตไฮเปอร์ลิงก์**

เปลี่ยนเป้าหมายของไฮเปอร์ลิงก์ที่มีอยู่ ใช้ `HyperlinkManager` เพื่อแก้ไขข้อความที่มีไฮเปอร์ลิงก์อยู่แล้ว ซึ่งเลียนแบบวิธีที่ PowerPoint ปรับปรุงไฮเปอร์ลิงก์อย่างปลอดภัย.

```java
static void updateHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://old.example.com"));

        // การเปลี่ยนไฮเปอร์ลิงก์ภายในข้อความที่มีอยู่ควรทำผ่าน
        // HyperlinkManager แทนการตั้งค่าคุณสมบัติโดยตรง.
        // นี้เลียนแบบวิธีที่ PowerPoint ปรับปรุงไฮเปอร์ลิงก์อย่างปลอดภัย.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```