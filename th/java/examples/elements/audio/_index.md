---
title: เสียง
type: docs
weight: 70
url: /th/java/examples/elements/audio/
keywords:
- ตัวอย่างโค้ด
- เสียง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบตัวอย่างเสียงของ Aspose.Slides for Java: แทรก, เล่น, ตัดและสกัดเสียงในงานนำเสนอ PPT, PPTX และ ODP ด้วยโค้ด Java ที่ชัดเจน"
---
บทความนี้แสดงวิธีฝังเฟรมเสียงและควบคุมการเล่นด้วย **Aspose.Slides for Java**. ตัวอย่างต่อไปนี้แสดงการดำเนินการพื้นฐานของเสียง.

## **เพิ่มเฟรมเสียง**

แทรกเฟรมเสียงว่างเปล่าที่สามารถเก็บข้อมูลเสียงที่ฝังไว้ในภายหลัง.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // สร้างเฟรมเสียงเปล่า (เสียงจะถูกฝังภายหลัง).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงเฟรมเสียง**

โค้ดนี้ดึงเฟรมเสียงแรกบนสไลด์.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // เข้าถึงเฟรมเสียงแรกบนสไลด์.
        IAudioFrame firstAudio = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAudioFrame) {
                firstAudio = (IAudioFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบเฟรมเสียง**

ลบเฟรมเสียงที่ได้เพิ่มไว้ก่อนหน้า.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // ลบเฟรมเสียง.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **ตั้งค่าการเล่นเสียง**

กำหนดค่าเฟรมเสียงให้เล่นโดยอัตโนมัติเมื่อสไลด์ปรากฏขึ้น.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // เล่นโดยอัตโนมัติเมื่อสไลด์ปรากฏ.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```