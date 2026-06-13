---
title: วิดีโอ
type: docs
weight: 80
url: /th/cpp/examples/elements/video/
keywords:
- ตัวอย่างโค้ด
- วิดีโอ
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "เพิ่มและควบคุมวิดีโอกับ Aspose.Slides for C++: แทรก, เล่น, ตัดส่วน, ตั้งค่าเฟรมโปสเตอร์, และส่งออกด้วยตัวอย่าง C++ สำหรับการนำเสนอ PPT, PPTX และ ODP."
---
บทความนี้แสดงวิธีฝังวิดีโอเฟรมและตั้งค่าตัวเลือกการเล่นโดยใช้ **Aspose.Slides for C++**.

## **เพิ่มวิดีโอเฟรม**

แทรกวิดีโอเฟรมเปล่าลงบนสไลด์.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // เพิ่มวิดีโอ.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **เข้าถึงวิดีโอเฟรม**

ดึงวิดีโอเฟรมแรกที่เพิ่มลงในสไลด์.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // เข้าถึงวิดีโอเฟรมแรกบนสไลด์.
    auto firstVideo = SharedPtr<IVideoFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            firstVideo = ExplicitCast<IVideoFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **ลบวิดีโอเฟรม**

ลบวิดีโอเฟรมออกจากสไลด์.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // ลบวิดีโอเฟรม.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **ตั้งค่าการเล่นวิดีโอ**

กำหนดให้วิดีโอเล่นอัตโนมัติเมื่อสไลด์แสดงผล.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // ตั้งค่าการเล่นวิดีโอให้เล่นอัตโนมัติ.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```