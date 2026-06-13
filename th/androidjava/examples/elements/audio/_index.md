---
title: เสียง
type: docs
weight: 70
url: /th/androidjava/examples/elements/audio/
keywords:
- ตัวอย่างโค้ด
- เสียง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบตัวอย่างเสียงของ Aspose.Slides สำหรับ Android: แทรก, เล่น, ตัดและดึงเสียงในงานนำเสนอ PPT, PPTX และ ODP ด้วยโค้ด Java ที่ชัดเจน"
---
บทความนี้แสดงวิธีการฝังกรอบเสียงและควบคุมการเล่นด้วย **Aspose.Slides for Android via Java** ตัวอย่างต่อไปนี้แสดงการดำเนินการพื้นฐานของเสียง

## **เพิ่มกรอบเสียง**

แทรกกรอบเสียงเปล่าที่สามารถใส่ข้อมูลเสียงที่ฝังไว้ในภายหลังได้.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // สร้างกรอบเสียงเปล่า (เสียงจะถูกฝังในภายหลัง).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงกรอบเสียง**

โค้ดนี้จะดึงกรอบเสียงแรกบนสไลด์

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // เข้าถึงกรอบเสียงแรกบนสไลด์.
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

## **ลบกรอบเสียง**

ลบกรอบเสียงที่เพิ่มไว้ก่อนหน้า

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // ลบกรอบเสียง.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **ตั้งค่าการเล่นเสียง**

กำหนดค่ากรอบเสียงให้เล่นอัตโนมัติเมื่อสไลด์ปรากฏ

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