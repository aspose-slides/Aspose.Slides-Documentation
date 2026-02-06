---
title: شريحة تخطيط
type: docs
weight: 20
url: /ar/python-net/examples/elements/layout-slide/
keywords:
- شريحة تخطيط
- إضافة شريحة تخطيط
- الوصول إلى شريحة تخطيط
- إزالة شريحة تخطيط
- شريحة تخطيط غير مستخدمة
- استنساخ شريحة تخطيط
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "استخدم Python لإدارة شرائح التخطيط مع Aspose.Slides: إنشاء، تطبيق، استنساخ، إعادة تسمية، وتخصيص العناصر النائبة والسمات في العروض التقديمية بصيغة PPT، PPTX و ODP."
---
توضح هذه المقالة كيفية العمل مع **Layout Slides** في Aspose.Slides للغة Python عبر .NET. تُعرّف شريحة التخطيط التصميم والتنسيق الذي يتم وراثته من قبل الشرائح العادية. يمكنك إضافة، الوصول، استنساخ، وإزالة شرائح التخطيط، بالإضافة إلى تنظيف الشرائح غير المستخدمة لتقليل حجم العرض التقديمي.

## **إضافة شريحة تخطيط**

يمكنك إنشاء شريحة تخطيط مخصصة لتحديد تنسيق قابل لإعادة الاستخدام.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # إنشاء شريحة تخطيط بالنوع والاسم المحددين.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **نصيحة 1:** شريحة التخطيط تعمل كقوالب للشرائح الفردية. يمكنك تعريف العناصر المشتركة مرة واحدة وإعادة استخدامها عبر العديد من الشرائح.

> 💡 **نصيحة 2:** عند إضافة أشكال أو نص إلى شريحة تخطيط، ستعرض جميع الشرائح المستندة إلى ذلك التخطيط هذا المحتوى المشترك تلقائيًا.  
> تُظهر لقطة الشاشة أدناه شريحتين، كل منهما يرث مربع نص من شريحة التخطيط نفسها.

![شرائح ترث محتوى التخطيط](layout-slide-result.png)

## **الوصول إلى شريحة تخطيط**

يمكن الوصول إلى شرائح التخطيط عبر الفهرس أو عبر نوع التخطيط (مثل `Blank`، `Title`، `SectionHeader`، الخ).

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # الوصول عبر الفهرس.
        first_layout_slide = presentation.layout_slides[0]

        # الوصول عبر نوع التخطيط.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **إزالة شريحة تخطيط**

يمكنك إزالة شريحة تخطيط معينة إذا لم تعد بحاجة إليها.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # احصل على شريحة تخطيط وفق النوع وأزلها.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة شرائح التخطيط غير المستخدمة**

لتقليل حجم العرض، قد ترغب في إزالة شرائح التخطيط التي لا تستخدمها أي شرائح عادية.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # يحذف تلقائيًا جميع شرائح التخطيط التي لا يشير إليها أي شريحة.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **استنساخ شريحة تخطيط**

يمكنك تكرار شريحة تخطيط باستخدام الطريقة `AddClone`.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # احصل على شريحة تخطيط موجودة عبر النوع.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # استنساخ شريحة التخطيط إلى نهاية مجموعة شرائح التخطيط.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **ملخص:** شرائح التخطيط هي أدوات قوية لإدارة تنسيق ثابت عبر الشرائح. تسمح Aspose.Slides بالتحكم الكامل في إنشاء، إدارة، وتحسين شرائح التخطيط.