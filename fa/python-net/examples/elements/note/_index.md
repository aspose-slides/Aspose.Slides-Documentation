---
title: یادداشت
type: docs
weight: 240
url: /fa/python-net/examples/elements/note/
keywords:
- یادداشت
- افزودن اسلاید یادداشت
- دسترسی به اسلاید یادداشت
- حذف اسلاید یادداشت
- به‌روزرسانی متن یادداشت
- نمونه‌های کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "افزودن، خواندن، ویرایش و استخراج یادداشت‌های سخنران در پایتون با Aspose.Slides: قالب‌بندی متن، مدیریت یادداشت‌ها برای هر اسلاید، و کنترل قابلیت مشاهده در PowerPoint و OpenDocument."
---
نحوه افزودن، خواندن، حذف و به‌روزرسانی اسلایدهای یادداشت را با استفاده از **Aspose.Slides for Python via .NET** نشان می‌دهد.

## **افزودن یک اسلاید یادداشت**

یک اسلاید یادداشت ایجاد کنید و متن را به آن اختصاص دهید.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به یک اسلاید یادداشت**

متن را از یک اسلاید یادداشت موجود بخوانید.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **حذف یک اسلاید یادداشت**

اسلاید یادداشت مرتبط با یک اسلاید را حذف کنید.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # اسلاید یادداشت را حذف کنید.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **به‌روزرسانی متن یادداشت**

متن یک اسلاید یادداشت را تغییر دهید.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # متن یادداشت را به‌روز کنید.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```