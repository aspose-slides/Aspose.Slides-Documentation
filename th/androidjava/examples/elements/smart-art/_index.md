---
title: SmartArt
type: docs
weight: 140
url: /th/androidjava/examples/elements/smart-art/
keywords:
- ตัวอย่างโค้ด
- SmartArt
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ทำงานกับ SmartArt ใน Aspose.Slides สำหรับ Android: สร้าง, แก้ไข, แปลง, และจัดรูปแบบแผนภาพด้วย Java สำหรับการนำเสนอ PowerPoint และ OpenDocument"
---
บทความนี้สาธิตวิธีเพิ่มกราฟิก SmartArt, เข้าถึง, ลบ, และเปลี่ยนเลเอาต์โดยใช้ **Aspose.Slides for Android via Java**.

## **Add SmartArt**

แทรกกราฟิก SmartArt โดยใช้หนึ่งในเลเอาต์ในตัว.

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

ดึงอ็อบเจ็กต์ SmartArt ตัวแรกบนสไลด์.

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

ลบรูปทรง SmartArt จากสไลด์.

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

อัปเดตประเภทเลเอาต์ของกราฟิก SmartArt ที่มีอยู่.

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