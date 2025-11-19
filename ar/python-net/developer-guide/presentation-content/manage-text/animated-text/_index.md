---
title: تحريك نص PowerPoint في Python
linktitle: نص متحرك
type: docs
weight: 60
url: /ar/python-net/animated-text/
keywords:
- نص متحرك
- تحريك النص
- فقرة متحركة
- تحريك الفقرة
- تأثير التحريك
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء نص متحرك ديناميكي في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر .NET، مع أمثلة شفرة سهلة المتابعة ومُحسّنة."
---

## **نظرة عامة**

توضح هذه المقالة كيفية تحريك النص في عروض PowerPoint باستخدام Aspose.Slides للغة Python. ستتعلم كيفية إضافة تأثيرات إلى فقرات فردية، وضبط المشغلات، وقراءة تسلسلات الرسوم المتحركة الحالية. في النهاية، ستكون قادرًا على إنشاء تدفقات عمل تحريك نص قابلة لإعادة الاستخدام تُصدر إلى ملف PPTX قياسي وتعمل بشكل صحيح في PowerPoint.

## **إضافة تأثيرات تحريك الفقرة**

تسمح لك طريقة [add_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/add_effect/) في فئة [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) بتطبيق تأثير تحريكي على فقرة واحدة. يوضح الشيفرة النموذجية أدناه كيفية القيام بذلك:
```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # تحديد الفقرة لإضافة التأثير.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # إضافة تأثير تحريك Fly إلى الفقرة المحددة.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```


## **الحصول على تأثيرات تحريك الفقرة**

قد ترغب في تحديد ما هي تأثيرات التحريك المطبقة على فقرة—على سبيل المثال، إذا كنت تخطط لنسخ تلك التأثيرات إلى فقرة أو شكل آخر.

تتيح لك Aspose.Slides للغة Python استرجاع جميع تأثيرات التحريك المطبقة على الفقرات داخل إطار نص (شكل). يظهر الشيفرة النموذجية أدناه كيفية الحصول على تأثيرات التحريك لفقرة:
```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```


## **الأسئلة الشائعة**

**كيف تختلف تحريكات النص عن انتقالات الشرائح، وهل يمكن دمجها؟**

تتحكم تحريكات النص في سلوك الكائن بمرور الوقت على الشريحة، بينما تتحكم [الانتقالات](/slides/ar/python-net/slide-transition/) في طريقة تغيير الشرائح. هما مستقلان ويمكن استخدامهما معًا؛ يتم تحديد ترتيب التشغيل بواسطة مخطط تحريك الرسوم وإعدادات الانتقال.

**هل يتم الاحتفاظ بتحريكات النص عند التصدير إلى PDF أو الصور؟**

لا. ملفات PDF والصور النقطية ثابتة، لذلك سترى الحالة الوحيدة للشفرة دون حركة. للحفاظ على الحركة، استخدم تصدير [فيديو](/slides/ar/python-net/convert-powerpoint-to-video/) أو [HTML](/slides/ar/python-net/export-to-html5/).

**هل تعمل تحريكات النص في القوالب والماستر الخاص بالشرائح؟**

التأثيرات المطبقة على كائنات القالب/الماستر تُورث إلى الشرائح، لكن توقيتها وتفاعلها مع تحريكات مستوى الشريحة يعتمد على التسلسل النهائي على الشريحة.