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
description: "أضف شرائح بسهولة إلى عروض PowerPoint و OpenDocument الخاصة بك باستخدام Aspose.Slides للبايثون عبر .NET—إدراج شرائح سلس وفعّال في ثوانٍ."
---

## **نظرة عامة**

قبل إضافة شرائح إلى عرض تقديمي، من المفيد فهم كيفية تنظيم PowerPoint لها. يحتوي كل عرض تقديمي على شريحة رئيسية (master slide)، شرائح تخطيط اختيارية، وشريحة أو أكثر عادية. لكل شريحة معرّف فريد، وتُرتب الشرائح العادية وفق فهرس يبدأ من الصفر. يوضح هذا المقال كيفية استخدام Aspose.Slides للبايثون لإنشاء شرائح واختيار التخطيطات المناسبة.

## **إضافة شرائح إلى العروض التقديمية**

يسمح لك Aspose.Slides بإلحاق شرائح جديدة بناءً على شرائح تخطيط موجودة. يوضح المثال أدناه كيفية التكرار عبر كل تخطيط في العرض التقديمي، إضافة شريحة تستخدم ذلك التخطيط، ثم حفظ الملف.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
3. لكل عنصر في `presentation.layout_slides`، استدعِ `add_empty_slide` لإضافة شريحة تستخدم ذلك التخطيط.
4. تعديل الشرائح المضافة حديثًا إذا رغبت.
5. حفظ العرض التقديمي كملف PPTX.

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

نعم. تدعم المكتبة عمليات جمع الشرائح و[الإدراج](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[الاستنساخ](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/)، لذا يمكنك إضافة شريحة في الفهرس المطلوب بدلًا من النهاية فقط.

**هل يتم الحفاظ على الثيم/الأنماط عند إضافة شريحة بناءً على تخطيط؟**

نعم. يرث التخطيط التنسيق من الماستر الخاص به، وتورّث الشريحة الجديدة التنسيق من التخطيط المختار والماستر المرتبط به.

**أي شريحة موجودة في عرض تقديمي جديد "فارغ" قبل إضافة الشرائح؟**

العرض التقديمي الذي تم إنشاؤه حديثًا يحتوي بالفعل على شريحة واحدة فارغة ذات فهرس صفر. هذا مهم لأخذ ذلك في الاعتبار عند حساب فهارس الإدراج.

**كيف أختار "التخطيط المناسب" لشريحة جديدة إذا كان للماستر العديد من الخيارات؟**

عادةً اختر [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) الذي يطابق الهيكل المطلوب (مثل [العنوان والمحتوى، محتوى مزدوج، إلخ](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). إذا كان هذا التخطيط غير موجود، يمكنك [إضافته إلى الماستر](/slides/ar/python-net/slide-layout/) ثم استخدامه.