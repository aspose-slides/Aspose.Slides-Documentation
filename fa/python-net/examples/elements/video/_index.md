---
title: ویدئو
type: docs
weight: 80
url: /fa/python-net/examples/elements/video/
keywords:
- ویدئو
- فریم ویدئویی
- اضافه کردن ویدئو
- دسترسی به ویدئو
- حذف ویدئو
- پخش ویدئو
- مثال‌های کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "کار با ویدئو در Python با استفاده از Aspose.Slides: درج، جایگزینی، برش، تنظیم فریم‌های پوستر و گزینه‌های پخش، و استخراج ارائه‌ها برای PPT، PPTX و ODP."
---
نحوه جاسازی فریم‌های ویدئویی و تنظیم گزینه‌های پخش را با استفاده از **Aspose.Slides for Python via .NET** نشان می‌دهد.

## **اضافه‌کردن فریم ویدئویی**

یک فریم ویدئویی خالی را بر روی یک اسلاید درج کنید.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # اضافه کردن فریم ویدئویی.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به فریم ویدئویی**

اولین فریم ویدئویی که به اسلاید اضافه شده است را بازیابی کنید.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # دسترسی به اولین فریم ویدئویی در اسلاید.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **حذف فریم ویدئویی**

یک فریم ویدئویی را از اسلاید حذف کنید.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض می‌کنیم اولین شکل یک فریم ویدئویی است.
        video_frame = slide.shapes[0]

        # فریم ویدئویی را حذف کنید.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم پخش ویدئویی**

ویدئو را طوری تنظیم کنید که به‌صورت خودکار هنگام نمایش اسلاید پخش شود.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض می‌کنیم اولین شکل یک فریم ویدئویی است.
        video_frame = slide.shapes[0]

        # پیکربندی ویدئو برای پخش خودکار.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```