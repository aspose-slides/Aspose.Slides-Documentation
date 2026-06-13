---
title: เสียง
type: docs
weight: 70
url: /th/python-net/examples/elements/audio/
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
- Python
- Aspose.Slides
description: "ทำงานกับเสียงใน Python โดยใช้ Aspose.Slides: เพิ่ม, แทนที่, ดึงออกและตัดเสียง, ตั้งระดับเสียงและการเล่นสำหรับสไลด์และรูปร่างใน PowerPoint และ OpenDocument."
---
อธิบายวิธีฝังเฟรมเสียงและควบคุมการเล่นด้วย **Aspose.Slides for Python via .NET**. ตัวอย่างต่อไปนี้แสดงการดำเนินการพื้นฐานเกี่ยวกับเสียง

## **เพิ่มเฟรมเสียง**

โค้ดตัวอย่างด้านล่างเพิ่มเฟรมเสียงบนสไลด์ของงานนำเสนอ

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงเฟรมเสียง**

โค้ดนี้ดึงเฟรมเสียงแรกจากสไลด์

```py
def access_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        first_audio_frame = None
        for shape in slide.shapes:
            if isinstance(shape, slides.AudioFrame):
                first_audio_frame = shape
                break
```

## **ลบเฟรมเสียง**

ลบเฟรมเสียงที่ได้เพิ่งเพิ่มไว้ก่อนหน้า

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่า shape แรกเป็น AudioFrame.
        audio_frame = slide.shapes[0]

        # ลบ AudioFrame.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าการเล่นเสียง**

กำหนดค่าเฟรมเสียงให้เล่นโดยอัตโนมัติเมื่อสไลด์ปรากฏ

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่า shape แรกเป็น AudioFrame.
        audio_frame = slide.shapes[0]

        # เล่นโดยอัตโนมัติเมื่อสไลด์ปรากฏ.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```