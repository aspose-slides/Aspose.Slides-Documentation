---
title: "انتقال الشريحة"
type: docs
weight: 110
url: /ar/python-net/examples/elements/slide-transition/
keywords:
- "انتقال شريحة"
- "إضافة انتقال شريحة"
- "الوصول إلى انتقال شريحة"
- "إزالة انتقال شريحة"
- "مدة الانتقال"
- "أمثلة الكود"
- "PowerPoint"
- "OpenDocument"
- "العرض التقديمي"
- "Python"
- "Aspose.Slides"
description: "التحكم في انتقالات الشرائح في بايثون باستخدام Aspose.Slides: اختر الأنواع والسرعة والصوت والتوقيت لتلميع العروض التقديمية في صيغ PPT و PPTX و ODP."
---
يوضح تطبيق تأثيرات وانتقالات الشرائح وتوقيتاتها باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة انتقال شريحة**

تطبيق تأثير الانتقال بالتلاشي على الشريحة الأولى.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # تطبيق انتقال تلاشي.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى انتقال الشريحة**

قراءة نوع الانتقال المعين حاليًا لشريحة.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # الوصول إلى نوع الانتقال.
        transition_type = slide.slide_show_transition.type
```

## **إزالة انتقال شريحة**

إزالة أي تأثير انتقال عن طريق تعيين النوع إلى `NONE`.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # إزالة الانتقال عن طريق تعيين لا شيء.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **تحديد مدة الانتقال**

تحديد المدة التي تُعرض فيها الشريحة قبل الانتقال تلقائيًا.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # بالملي ثانية.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```