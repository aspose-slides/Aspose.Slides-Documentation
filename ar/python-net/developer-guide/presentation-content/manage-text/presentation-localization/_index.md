---
title: أتمتة تعريب العروض التقديمية باستخدام بايثون
linktitle: تعريب العروض التقديمية
type: docs
weight: 100
url: /ar/python-net/presentation-localization/
keywords:
- تغيير اللغة
- تدقيق إملائي
- معرف اللغة
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "أتمتة تعريب شرائح PowerPoint وOpenDocument باستخدام بايثون مع Aspose.Slides، باستخدام أمثلة شفرة عملية ونصائح لتسريع النشر العالمي."
---

## **تغيير اللغة للعرض التقديمي ونص الشكل**
- إنشاء كائن من الفئة[العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
- الحصول على مرجع الشريحة باستخدام فهرستها.
- إضافة AutoShape من نوع مستطيل إلى الشريحة.
- إضافة بعض النص إلى TextFrame.
- تعيين معرف اللغة إلى النص.
- حفظ العرض التقديمي كملف PPTX.

The implementation of the above steps is demonstrated below in an example.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل يؤدي language_id إلى ترجمة النص تلقائيًا؟**

لا. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) في Aspose.Slides يخزن اللغة للتدقيق الإملائي وإثبات القواعد، لكنه لا يترجم أو يغير محتوى النص. إنه بيانات وصفية تفهمها PowerPoint لإثبات النص.

**هل يؤثر language_id على التجزية وكسر الأسطر أثناء العرض؟**

في Aspose.Slides، [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) مخصص للإثبات. جودة التجزية وتوزيع الأسطر تعتمد أساسًا على توفر [الخطوط المناسبة](/slides/ar/python-net/powerpoint-fonts/) وإعدادات التخطيط/كسر الأسطر لنظام الكتابة. لضمان عرض صحيح، احرص على توفير الخطوط المطلوبة، تكوين [قواعد استبدال الخطوط](/slides/ar/python-net/font-substitution/)، و/أو [تضمين الخطوط](/slides/ar/python-net/embedded-font/) في العرض.

**هل يمكنني تعيين لغات مختلفة داخل فقرة واحدة؟**

نعم. يتم تطبيق [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) على مستوى جزء النص، لذا يمكن لفقرة واحدة أن تجمع عدة لغات بإعدادات إثبات مميزة.