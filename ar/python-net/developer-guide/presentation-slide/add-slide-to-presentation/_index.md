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
- باوربوينت
- OpenDocument
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "أضف الشرائح بسهولة إلى عروض PowerPoint وOpenDocument الخاصة بك باستخدام Aspose.Slides للبايثون عبر .NET — إدراج شرائح سلس وفعّال في ثوانٍ."
---

## **نظرة عامة**

قبل إضافة شرائح إلى عرض تقديمي، من المفيد أن تفهم كيف ينظم PowerPoint الشرائح. يحتوي كل عرض تقديمي على شريحة رئيسية، شرائح تخطيط اختيارية، وشريحة أو أكثر عادية. لكل شريحة معرف فريد، وتُرتب الشرائح العادية بحسب فهرس يبدأ من الصفر. يُظهر هذا المقال كيفية استخدام Aspose.Slides للبايثون لإنشاء الشرائح واختيار التخطيطات المناسبة.

## **إضافة شرائح إلى العروض التقديمية**

Aspose.Slides يتيح لك إلحاق شرائح جديدة بناءً على شرائح تخطيط موجودة. المثال أدناه يتنقل عبر كل تخطيط في العرض التقديمي، يضيف شريحة تستخدم ذلك التخطيط، ثم يحفظ الملف.

1. إنشاء مثيل لفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الوصول إلى [مجموعة الشرائح](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
3. لكل عنصر في `presentation.layout_slides`، استدعِ `add_empty_slide` لإلحاق شريحة تستخدم ذلك التخطيط.
4. اختيارياً، عدّل الشرائح التي تمت إضافتها حديثاً.
5. احفظ العرض التقديمي كملف PPTX.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation.
with slides.Presentation() as presentation:
    # الحصول على مجموعة الشرائح.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # إضافة شريحة فارغة إلى مجموعة الشرائح.
        slides.add_empty_slide(layout_slide)

    # تنفيذ بعض العمليات على الشرائح التي تم إضافتها حديثاً.

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يمكنني إدراج شريحة جديدة في موضع محدد، وليس فقط في النهاية؟**

نعم. المكتبة تدعم عمليات مجموعة الشرائح و[إدراج](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[استنساخ](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/)، لذا يمكنك إضافة شريحة عند الفهرس المطلوب بدلاً من النهاية فقط.

**هل تُحفظ الأنماط/التصاميم عند إضافة شريحة بناءً على تخطيط؟**

نعم. التخطيط يرث التنسيق من الرئيس الرئيسي، والشريحة الجديدة ترث من التخطيط المختار والرئيس المرتبط به.

**ما الشريحة الموجودة في عرض “فارغ” جديد قبل إضافة شرائح؟**

العرض التقديمي الذي يتم إنشاؤه حديثاً يحتوي بالفعل على شريحة فارغة واحدة بفهرس الصفر. هذا مهم عند حساب مؤشرات الإدراج.

**كيف أختار التخطيط “الصحيح” لشريحة جديدة إذا كان الرئيس يحتوي على خيارات كثيرة؟**

عادةً اختر [تخطيط الشريحة](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) الذي يطابق البنية المطلوبة ([عنوان ومحتوى، محتوى مزدوج، إلخ](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). إذا كان هذا التخطيط غير موجود، يمكنك [إضافته إلى الرئيس](/slides/ar/python-net/slide-layout/) ثم استخدامه.