---
title: วิดีโอ
type: docs
weight: 80
url: /th/net/examples/elements/video/
keywords:
- วิดีโอ
- เฟรมวิดีโอ
- เพิ่มวิดีโอ
- เข้าถึงวิดีโอ
- ลบวิดีโอ
- การเล่นวิดีโอ
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เพิ่มและควบคุมวิดีโอด้วย Aspose.Slides for .NET: แทรก, เล่น, ตัด, ตั้งค่าเฟรมโปสเตอร์, และส่งออกพร้อมตัวอย่าง C# สำหรับงานนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีการฝังเฟรมวิดีโอและตั้งค่าตัวเลือกการเล่นโดยใช้ **Aspose.Slides for .NET**.

## **เพิ่มเฟรมวิดีโอ**

แทรกเฟรมวิดีโาว่างเปล่าบนสไลด์.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // เพิ่มวิดีโอ.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **เข้าถึงเฟรมวิดีโอ**

ดึงเฟรมวิดีโอตัวแรกที่เพิ่มลงในสไลด์.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // เข้าถึงเฟรมวิดีโอแรกบนสไลด์.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **ลบเฟรมวิดีโอ**

ลบเฟรมวิดีโอออกจากสไลด์.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // ลบเฟรมวิดีโอ.
    slide.Shapes.Remove(videoFrame);
}
```

## **ตั้งค่าการเล่นวิดีโอ**

กำหนดให้วิดีโอเล่นอัตโนมัติเมื่อสไลด์แสดงผล.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // กำหนดให้วิดีโอเล่นโดยอัตโนมัติ.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```