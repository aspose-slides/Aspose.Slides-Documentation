---
title: วิดีโอ
type: docs
weight: 80
url: /th/python-net/examples/elements/video/
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
- การนำเสนอ
- Python
- Aspose.Slides
description: "ทำงานกับวิดีโอใน Python ด้วย Aspose.Slides: แทรก, แทนที่, ตัดต่อ, ตั้งค่าเฟรมโปสเตอร์และตัวเลือกการเล่น, และส่งออกงานนำเสนอเป็น PPT, PPTX และ ODP."
---
แสดงวิธีการฝังเฟรมวิดีโอและตั้งค่าตัวเลือกการเล่นโดยใช้ **Aspose.Slides for Python via .NET**.

## **เพิ่มเฟรมวิดีโอ**

แทรกเฟรมวิดีโอเปล่าลงบนสไลด์.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # เพิ่มเฟรมวิดีโอ.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงเฟรมวิดีโอ**

ดึงเฟรมวิดีโอแรกที่เพิ่มลงในสไลด์.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # เข้าถึงเฟรมวิดีโอแรกบนสไลด์.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **ลบเฟรมวิดีโอ**

ลบเฟรมวิดีโอออกจากสไลด์.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่า shape แรกเป็นเฟรมวิดีโอ.
        video_frame = slide.shapes[0]

        # ลบเฟรมวิดีโอ.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าการเล่นวิดีโอ**

กำหนดค่าให้วิดีโอเล่นโดยอัตโนมัติเมื่อสไลด์แสดงผล.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่า shape แรกเป็นเฟรมวิดีโอ.
        video_frame = slide.shapes[0]

        # ตั้งค่าการเล่นวิดีโอให้ทำงานอัตโนมัติ.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```