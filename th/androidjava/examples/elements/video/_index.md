---
title: วิดีโอ
type: docs
weight: 80
url: /th/androidjava/examples/elements/video/
keywords:
- ตัวอย่างโค้ด
- วิดีโอ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เพิ่มและควบคุมวิดีโอด้วย Aspose.Slides for Android: แทรก, เล่น, ตัดต่อ, ตั้งค่าเฟรมโปสเตอร์, และส่งออกพร้อมตัวอย่าง Java สำหรับการนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีการแทรกรูปวิดีโอและตั้งค่าตัวเลือกการเล่นโดยใช้ **Aspose.Slides for Android via Java**.

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

        // เข้าถึงเฟรมวิดีโอแรกบนสไลด์.
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

        // ลบเฟรมวิดีโอ.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **ตั้งค่าการเล่นวิดีโอ**

กำหนดค่าวิดีโอให้เล่นอัตโนมัติเมื่อแสดงสไลด์.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // กำหนดค่าวิดีโอให้เล่นอัตโนมัติ.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```