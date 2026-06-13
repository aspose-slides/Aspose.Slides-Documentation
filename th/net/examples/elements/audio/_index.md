---
title: เสียง
type: docs
weight: 70
url: /th/net/examples/elements/audio/
keywords:
- เสียง
- เฟรมเสียง
- เพิ่มเสียง
- เข้าถึงเสียง
- ลบเสียง
- การเล่นเสียง
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบตัวอย่างการใช้เสียงใน Aspose.Slides for .NET: แทรก, เล่น, ตัดและดึงเสียงในงานนำเสนอ PPT, PPTX และ ODP ด้วยโค้ด C# ที่ชัดเจน"
---
บทความนี้สาธิตวิธีการฝังเฟรมเสียงและควบคุมการเล่นด้วย **Aspose.Slides for .NET** ตัวอย่างต่อไปนี้แสดงการดำเนินการพื้นฐานของเสียง

## **เพิ่มเฟรมเสียง**

แทรกเฟรมเสียงเปล่าซึ่งสามารถบรรจุข้อมูลเสียงที่ฝังไว้ในภายหลังได้

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // สร้างเฟรมเสียงเปล่า (เสียงจะถูกฝังไว้ภายหลัง).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **เข้าถึงเฟรมเสียง**

โค้ดนี้เรียกคืนเฟรมเสียงแรกบนสไลด์

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // เข้าถึงเฟรมเสียงแรกบนสไลด์.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **ลบเฟรมเสียง**

ลบเฟรมเสียงที่เพิ่มไปก่อนหน้านี้

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // ลบเฟรมเสียง.
    slide.Shapes.Remove(audioFrame);
}
```

## **กำหนดการเล่นเสียง**

กำหนดค่าเฟรมเสียงให้เล่นอัตโนมัติเมื่อสไลด์ปรากฏ

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // เล่นอัตโนมัติเมื่อสไลด์ปรากฏ.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```