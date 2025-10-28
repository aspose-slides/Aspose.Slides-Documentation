---
title: إضافة شرائح إلى العروض التقديمية باستخدام بايثون
linktitle: إضافة شريحة
type: docs
weight: 10
url: /ar/python-net/add-slide-to-presentation/
keywords:
- إضافة شريحة
- إنشاء شريحة
- شريحة فارغة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "أضف الشرائح بسهولة إلى عروض PowerPoint و OpenDocument التقديمية باستخدام Aspose.Slides للبايثون عبر .NET—إدراج شرائح سلس وفعال في ثوانٍ."
---

## **نظرة عامة**

قبل إضافة الشرائح إلى عرض تقديمي، من المفيد فهم طريقة تنظيم PowerPoint لها. يحتوي كل عرض تقديمي على شريحة رئيسية، وشريحات تخطيط اختيارية، وشريحة أو أكثر عادية. لكل شريحة معرف فريد، وتُرتب الشرائح العادية حسب فهرس يبدأ من الصفر. يوضح هذا المقال كيفية استخدام Aspose.Slides للبايثون لإنشاء شرائح واختيار التخطيطات المناسبة.

## **إضافة شرائح إلى العروض التقديمية**

يتيح لك Aspose.Slides إرفاق شرائح جديدة استنادًا إلى شريحات التخطيط الموجودة. يمرّ المثال أدناه عبر كل تخطيط في العرض التقديمي، يضيف شريحة تستخدم ذلك التخطيط، ثم يحفظ الملف.

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الوصول إلى [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) .
3. لكل عنصر في `presentation.layout_slides`، استدعِ `add_empty_slide` لإضافة شريحة تستخدم ذلك التخطيط.
4. اختياريًا، عدّل الشرائح التي تم إضافتها حديثًا.
5. احفظ العرض التقديمي كملف PPTX.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Access the slide collection.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Add an empty slide to the slide collection.
        slides.add_empty_slide(layout_slide)

    # Do some work on the newly added slides.

    # Save the presentation to disk.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يمكنني إدراج شريحة جديدة في موضع محدد، وليس فقط في النهاية؟**

نعم. تدعم المكتبة مجموعات الشرائح وعمليات [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/) ، لذلك يمكنك إضافة شريحة في الفهرس المطلوب بدلاً من الإضافة فقط في النهاية.

**هل يتم الحفاظ على السمات/الأنماط عند إضافة شريحة استنادًا إلى تخطيط؟**

نعم. يرث التخطيط التنسيق من رئيسه، وتورّث الشريحة الجديدة التنسيق من التخطيط المختار والرئيس المرتبط به.

**أي شريحة موجودة في عرض تقديمي "فارغ" جديد قبل إضافة الشرائح؟**

العرض التقديمي الجديد يحتوي مسبقًا على شريحة فارغة واحدة ذات الفهرس صفر. من المهم مراعاة ذلك عند حساب مؤشرات الإدراج.

**كيف يمكن اختيار التخطيط "الصحيح" لشريحة جديدة إذا كان الرئيس يحتوي على العديد من الخيارات؟**

عمومًا اختر الـ [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) الذي يطابق الهيكل المطلوب ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). إذا كان هذا التخطيط غير موجود، يمكنك [إضافته إلى الرئيس](/slides/ar/python-net/slide-layout/) ثم استخدامه.