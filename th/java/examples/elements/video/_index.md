---
title: วิดีโอ
type: docs
weight: 80
url: /th/java/examples/elements/video/
keywords:
- ตัวอย่างโค้ด
- วิดีโอ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เพิ่มและควบคุมวิดีโอด้วย Aspose.Slides for Java: แทรก, เล่น, ตัด, ตั้งค่ากรอบโปสเตอร์, และส่งออกด้วยตัวอย่าง Java สำหรับงานนำเสนอในรูปแบบ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีการฝังกรอบวิดีโอและตั้งค่าตัวเลือกการเล่นโดยใช้ **Aspose.Slides for Java**.

## **เพิ่มกรอบวิดีโอ**

แทรกกรอบวิดีโอเปล่าลงบนสไลด์.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // เพิ่มวิดีโอ.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงกรอบวิดีโอ**

ดึงกรอบวิดีโอแรกที่เพิ่มลงในสไลด์.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // เข้าถึงกรอบวิดีโอแรกบนสไลด์.
        IVideoFrame firstVideo = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                firstVideo = (IVideoFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบกรอบวิดีโอ**

ลบกรอบวิดีโอออกจากสไลด์.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // ลบกรอบวิดีโอ.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **ตั้งค่าการเล่นวิดีโอ**

กำหนดค่าวิดีโอให้เล่นอัตโนมัติเมื่อสไลด์แสดง.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // ตั้งค่าการเล่นวิดีโอให้เล่นโดยอัตโนมัติ.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```