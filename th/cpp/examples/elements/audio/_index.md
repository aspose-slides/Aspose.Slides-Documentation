---
title: เสียง
type: docs
weight: 70
url: /th/cpp/examples/elements/audio/
keywords:
- ตัวอย่างโค้ด
- เสียง
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบตัวอย่างเสียงของ Aspose.Slides for C++: แทรก, เล่น, ตัดและดึงเสียงในงานนำเสนอแบบ PPT, PPTX, และ ODP ด้วยโค้ด C++ ที่ชัดเจน"
---
บทความนี้สาธิตวิธีฝังกรอบเสียงและควบคุมการเล่นด้วย **Aspose.Slides for C++** ตัวอย่างต่อไปนี้แสดงการดำเนินการพื้นฐานของเสียง

## **เพิ่มกรอบเสียง**

แทรกกรอบเสียงเปล่าที่สามารถเก็บข้อมูลเสียงที่ฝังมาได้ในภายหลัง

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // สร้างกรอบเสียงเปล่า (เสียงจะถูกฝังในภายหลัง).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **เข้าถึงกรอบเสียง**

โค้ดนี้จะดึงกรอบเสียงแรกบนสไลด์

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // เข้าถึงกรอบเสียงแรกบนสไลด์.
    auto firstAudio = SharedPtr<IAudioFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAudioFrame>(shape))
        {
            firstAudio = ExplicitCast<IAudioFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **ลบกรอบเสียง**

ลบกรอบเสียงที่เพิ่มไว้ก่อนหน้านี้

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // ลบกรอบเสียง.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **ตั้งค่าการเล่นเสียง**

กำหนดค่ากรอบเสียงให้เล่นอัตโนมัติเมื่อสไลด์แสดง

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // เล่นโดยอัตโนมัติเมื่อสไลด์ปรากฏ.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```