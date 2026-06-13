---
title: انتقال اسلاید
type: docs
weight: 110
url: /fa/python-net/examples/elements/slide-transition/
keywords:
- انتقال اسلاید
- افزودن انتقال اسلاید
- دسترسی به انتقال اسلاید
- حذف انتقال اسلاید
- مدت زمان انتقال
- مثال‌های کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "کنترل انتقالات اسلاید در پایتون با Aspose.Slides: انتخاب انواع، سرعت، صدا و زمان‌بندی برای بهبود ارائه‌ها در فرمت‌های PPT، PPTX و ODP."
---
نشان می‌دهد که چگونه اثرهای انتقال اسلاید و زمان‌بندی‌ها را با **Aspose.Slides for Python via .NET** اعمال کنید.

## **افزودن انتقال اسلاید**

یک اثر انتقال محو را بر روی اولین اسلاید اعمال کنید.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # اعمال یک انتقال محو.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به انتقال اسلاید**

نوع انتقالی را که در حال حاضر به یک اسلاید اختصاص داده شده است بخوانید.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # دسترسی به نوع انتقال.
        transition_type = slide.slide_show_transition.type
```

## **حذف انتقال اسلاید**

هر اثر انتقالی را با تنظیم نوع به `NONE` پاک کنید.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # حذف انتقال با تنظیم none.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم مدت زمان انتقال**

مشخص کنید اسلاید تا چه مدت قبل از پیشروی خودکار نمایش داده شود.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # بر میلی‌ثانیه.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```