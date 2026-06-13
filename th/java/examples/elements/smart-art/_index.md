---
title: SmartArt
type: docs
weight: 140
url: /th/java/examples/elements/smart-art/
keywords:
- ตัวอย่างโค้ด
- SmartArt
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ทำงานกับ SmartArt ใน Aspose.Slides for Java: สร้าง, แก้ไข, แปลง, และออกแบบแผนภูมิด้วย Java สำหรับงานนำเสนอ PowerPoint และ OpenDocument"
---
บทความนี้สาธิตวิธีการเพิ่มกราฟิก SmartArt, เข้าถึง, ลบ, และเปลี่ยนการจัดวางโดยใช้ **Aspose.Slides for Java**.

## **Add SmartArt**
เพิ่ม SmartArt

Insert a SmartArt graphic using one of the built-in layouts.
แทรกกราฟิก SmartArt โดยใช้หนึ่งในรูปแบบการจัดวางที่มาพร้อม.

```java
static void addSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
    } finally {
        presentation.dispose();
    }
}
```

## **Access SmartArt**
เข้าถึง SmartArt

Retrieve the first SmartArt object on a slide.
ดึงออบเจ็กต์ SmartArt ตัวแรกบนสไลด์.

```java
static void accessSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        ISmartArt firstSmartArt = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ISmartArt) {
                firstSmartArt = (ISmartArt) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove SmartArt**
ลบ SmartArt

Delete a SmartArt shape from the slide.
ลบรูปร่าง SmartArt จากสไลด์.

```java
static void removeSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        slide.getShapes().remove(smartArt);
    } finally {
        presentation.dispose();
    }
}
```

## **Change SmartArt Layout**
เปลี่ยนการจัดวาง SmartArt

Update the layout type of an existing SmartArt graphic.
อัปเดตประเภทการจัดวางของกราฟิก SmartArt ที่มีอยู่.

```java
static void changeSmartArtLayout() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
        smartArt.setLayout(SmartArtLayoutType.VerticalPictureList);
    } finally {
        presentation.dispose();
    }
}
```