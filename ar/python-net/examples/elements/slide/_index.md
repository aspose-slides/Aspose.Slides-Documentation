---
title: شريحة
type: docs
weight: 10
url: /ar/python-net/examples/elements/slide/
keywords:
- شريحة
- إضافة شريحة
- الوصول إلى شريحة
- فهرس الشريحة
- استنساخ شريحة
- إعادة ترتيب الشرائح
- إزالة شريحة
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة الشرائح في Python باستخدام Aspose.Slides: إنشاء، استنساخ، إعادة ترتيب، إخفاء، تعيين الخلفيات والحجم، تطبيق الانتقالات، وتصدير إلى PowerPoint و OpenDocument."
---
توفر هذه المقالة مجموعة من الأمثلة التي توضح كيفية العمل مع الشرائح باستخدام **Aspose.Slides for Python via .NET**. ستتعلم كيفية إضافة، الوصول إلى، استنساخ، إعادة ترتيب، وإزالة الشرائح باستخدام الفئة `Presentation`.

يتضمن كل مثال أدناه شرحًا موجزًا يليه مقتطف شفرة بلغة Python.

## **إضافة شريحة**

لإضافة شريحة جديدة، يجب عليك أولاً اختيار تخطيط. في هذا المثال، نستخدم تخطيط `Blank` ونضيف شريحة فارغة إلى العرض التقديمي.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # كل شريحة مستندة إلى تخطيط، والذي نفسه مستند إلى شريحة رئيسية.
        # استخدم تخطيط Blank لإنشاء شريحة جديدة.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # أضف شريحة فارغة جديدة باستخدام التخطيط المحدد.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **نصيحة:** كل تخطيط شريحة مشتق من شريحة رئيسية، التي تحدد التصميم العام وهيكل العناصر النائبة. توضح الصورة أدناه كيفية تنظيم الشرائح الرئيسية والتخطيطات المرتبطة بها في PowerPoint.

![علاقة الشريحة الرئيسية والتخطيط](master-layout-slide.png)

## **الوصول إلى الشرائح بواسطة الفهرس**

يمكنك الوصول إلى الشرائح باستخدام فهرسها. هذا مفيد للتنقل عبر الشرائح أو تعديل شرائح معينة.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # الوصول إلى شريحة عبر الفهرس.
        first_slide = presentation.slides[0]
```

## **استنساخ شريحة**

يوضح هذا المثال كيفية استنساخ شريحة موجودة. تُضاف الشريحة المستنسخة تلقائيًا إلى نهاية مجموعة الشرائح.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # استنساخ الشريحة؛ سيتم إضافتها في نهاية العرض التقديمي.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **إعادة ترتيب الشرائح**

يمكنك تغيير ترتيب الشرائح بنقل إحدى الشرائح إلى فهرس جديد. في هذه الحالة، ننقل شريحة إلى الموضع الأول.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # نقل الشريحة إلى الموضع الأول (يتحرك باقي الشرائح إلى الأسفل).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة شريحة**

لإزالة شريحة، ما عليك سوى الإشارة إليها واستدعاء `remove`. يزيل هذا المثال الشريحة الأولى.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # إزالة الشريحة.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```