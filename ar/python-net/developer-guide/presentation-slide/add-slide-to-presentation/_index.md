---
title: إضافة شرائح إلى العروض التقديمية باستخدام Python
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
description: "أضف الشرائح بسهولة إلى عروض PowerPoint و OpenDocument الخاصة بك باستخدام Aspose.Slides للغة Python عبر .NET—إدراج شرائح سلس وفعال في ثوانٍ."
---

## **نظرة عامة**

قبل إضافة الشرائح إلى عرض تقديمي، من المفيد فهم كيفية تنظيم PowerPoint لها. يحتوي كل عرض تقديمي على شريحة رئيسية، وشَرائح تخطيط اختيارية، وشريحة أو أكثر عادية. لكل شريحة معرف فريد، وتُرتب الشرائح العادية حسب فهرس يبدأ من الصفر. يُظهر هذا المقال كيفية استخدام Aspose.Slides للغة Python لإنشاء شرائح واختيار التخطيطات المناسبة.

## **إضافة شرائح إلى العروض التقديمية**

تتيح لك Aspose.Slides إلحاق شرائح جديدة استنادًا إلى شرائح التخطيط الموجودة. يت iterates المثال أدناه عبر كل تخطيط في العرض التقديمي، يضيف شريحة تستخدم ذلك التخطيط، ثم يحفظ الملف.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الوصول إلى مجموعة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) .
3. لكل عنصر في `presentation.layout_slides`، استدعِ `add_empty_slide` لإلحاق شريحة تستخدم هذا التخطيط.
4. تعديل الشرائح المضافة حديثًا بشكل اختياري.
5. حفظ العرض التقديمي كملف PPTX.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation.
with slides.Presentation() as presentation:
    # الوصول إلى مجموعة الشرائح.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # إضافة شريحة فارغة إلى مجموعة الشرائح.
        slides.add_empty_slide(layout_slide)

    # تنفيذ بعض الأعمال على الشرائح المضافة حديثًا.

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**هل يمكنني إدراج شريحة جديدة في موضع محدد، وليس فقط في النهاية؟**

نعم. تدعم المكتبة مجموعات الشرائح وعمليات [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/) ، لذا يمكنك إضافة شريحة في الفهرس المطلوب بدلاً من الإضافة فقط في النهاية.

**هل تُحفظ السمات/الأنماط عند إضافة شريحة استنادًا إلى تخطيط؟**

نعم. يرث التخطيط التنسيق من الرئيسي، وتورث الشريحة الجديدة من التخطيط المحدد والماستر المرتبط به.

**أي شريحة تكون موجودة في عرض تقديمي "فارغ" جديد قبل إضافة الشرائح؟**

العرض التقديمي المُنشأ حديثًا يحتوي بالفعل على شريحة فارغة واحدة بفهرس الصفر. وهذا أمر مهم مراعاته عند حساب فهارس الإدراج.

**كيف أختار "التخطيط المناسب" لشريحة جديدة إذا كان للماستر العديد من الخيارات؟**

عادةً اختر [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) الذي يطابق البنية المطلوبة ([Title and Content, Two Content, إلخ](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). إذا كان هذا التخطيط غير موجود، يمكنك [add it to the master](/slides/ar/python-net/slide-layout/) ثم استخدامه.