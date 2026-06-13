---
title: ไฮเปอร์ลิงก์
type: docs
weight: 130
url: /th/java/examples/elements/hyperlink/
keywords:
- ตัวอย่างโค้ด
- ไฮเปอร์ลิงก์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เพิ่มและจัดการไฮเปอร์ลิงก์ใน Aspose.Slides for Java: เชื่อมข้อความ รูปทรง และภาพ ตั้งค่าเป้าหมายและการกระทำสำหรับ PPT, PPTX, และ ODP พร้อมตัวอย่าง Java."
---
บทความนี้สาธิตการเพิ่ม การเข้าถึง การลบ และการอัปเดตไฮเปอร์ลิงก์บนรูปทรงโดยใช้ **Aspose.Slides for Java**.

## **Add a Hyperlink**

สร้างรูปสี่เหลี่ยมผืนผ้าพร้อมไฮเปอร์ลิงก์ที่ชี้ไปยังเว็บไซต์ภายนอก.

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

## **Access a Hyperlink**

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

## **Remove a Hyperlink**

ลบไฮเปอร์ลิงก์ออกจากข้อความของรูปทรง.

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

## **Update a Hyperlink**

เปลี่ยนเป้าหมายของไฮเปอร์ลิงก์ที่มีอยู่แล้ว ใช้ `HyperlinkManager` เพื่อแก้ไขข้อความที่มีไฮเปอร์ลิงก์อยู่แล้ว ซึ่งจำลองวิธีการอัปเดตไฮเปอร์ลิงก์ของ PowerPoint อย่างปลอดภัย.

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

        // การเปลี่ยนไฮเปอร์ลิงก์ในข้อความที่มีอยู่ควรทำผ่าน
        // HyperlinkManager แทนการตั้งค่าคุณสมบัติโดยตรง.
        // นี่เป็นการจำลองวิธีที่ PowerPoint อัปเดตไฮเปอร์ลิงก์อย่างปลอดภัย.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```