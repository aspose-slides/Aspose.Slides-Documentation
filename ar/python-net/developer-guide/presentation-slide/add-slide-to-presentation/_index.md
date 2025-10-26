---
title: إضافة شرائح إلى العروض التقديمية باستخدام Python
linktitle: إضافة شريحة
type: docs
weight: 10
url: /ar/python-net/developer-guide/presentation-slide/add-slide-to-presentation/
keywords:
- إضافة شريحة
- إنشاء شريحة
- شريحة فارغة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إضافة شرائح بسهولة إلى عروض PowerPoint وOpenDocument الخاصة بك باستخدام Aspose.Slides لـ Python عبر .NET—إدراج شرائح سلس وفعّال في ثوانٍ."
---

## **نظرة عامة**

قبل إضافة شرائح إلى عرض تقديمي، من المفيد فهم كيفية تنظيم PowerPoint لها. يحتوي كل عرض تقديمي على شريحة رئيسية (master slide)، شرائح تخطيط اختيارية (layout slides)، وشريحة أو أكثر عادية (normal slides). كل شريحة لها معرف فريد، وتُرتب الشرائح العادية بحسب فهرس يبدأ من الصفر. يُظهر هذا المقال كيفية استخدام Aspose.Slides لـ Python لإنشاء شرائح واختيار التخطيطات المناسبة.

## **إضافة شرائح إلى العروض التقديمية**

يسمح Aspose.Slides لك بإضافة شرائح جديدة بناءً على شرائح تخطيط موجودة. ي iterates المثال أدناه عبر كل تخطيط في العرض التقديمي، يضيف شريحة تستخدم ذلك التخطيط، ثم يحفظ الملف.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
1. لكل عنصر في `presentation.layout_slides`، استدعِ `add_empty_slide` لإضافة شريحة تستخدم ذلك التخطيط.
1. اختياريًا، عدّل الشرائح التي تم إضافتها حديثًا.
1. احفظ العرض التقديمي كملف PPTX.

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

## **الأسئلة المتكررة**

**هل يمكنني إدراج شريحة جديدة في موضع محدد، وليس فقط في النهاية؟**

نعم. تدعم المكتبة عمليات مجموعة الشرائح و[insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/)، لذا يمكنك إضافة شريحة في الفهرس المطلوب بدلاً من الإضافة فقط في النهاية.

**هل يتم الاحتفاظ بالسمات/الأنماط عند إضافة شريحة بناءً على تخطيط؟**

نعم. يرث التخطيط التنسيق من الماستر الخاص به، وتُورث الشريحة الجديدة من التخطيط المختار والماستر المرتبط به.

**أي شريحة موجودة في عرض تقديمي جديد «فارغ» قبل إضافة الشرائح؟**

العرض التقديمي الذي يتم إنشاؤه حديثًا يحتوي بالفعل على شريحة فارغة واحدة بفهرس الصفر. هذا مهم عند حساب مؤشرات الإدراج.

**كيف أختار التخطيط «الصحيح» لشريحة جديدة إذا كان للماستر العديد من الخيارات؟**

عمومًا اختر [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) الذي يتطابق مع الهيكلة المطلوبة ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). إذا كان هذا التخطيط غير موجود، يمكنك [إضافته إلى الماستر](/slides/ar/python-net/slide-layout/) ثم استخدامه.