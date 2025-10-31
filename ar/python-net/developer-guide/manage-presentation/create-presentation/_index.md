---
title: إنشاء عرض تقديمي بلغة بايثون
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/python-net/create-presentation/
keywords:
- إنشاء عرض تقديمي
- عرض تقديمي جديد
- إنشاء PPT
- PPT جديد
- إنشاء PPTX
- PPTX جديد
- إنشاء ODP
- ODP جديد
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "إنشاء عروض PowerPoint في بايثون باستخدام Aspose.Slides—إنشاء ملفات PPT وPPTX وODP، الاستفادة من دعم OpenDocument، وحفظها برمجياً للحصول على نتائج موثوقة."
---

## **نظرة عامة**

تتيح لك Aspose.Slides for Python إنشاء ملف عرض تقديمي جديد كليًا بالكامل عبر الشيفرة. يوضح هذا المقال سير العمل الأساسي—إنشاء كائن [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ، الحصول على الشريحة الأولى، إدخال شكل بسيط، وحفظ النتيجة—حتى تتمكن من رؤية القليل من الإعداد المطلوب لتوليد عرض تقديمي دون الحاجة إلى Microsoft Office. بما أن نفس الـ API يكتب صيغ PPT وPPTX وODP، يمكنك استهداف صيغ PowerPoint التقليدية وصيغ OpenDocument من قاعدة شفرة واحدة. Aspose.Slides ملائمة لبيئات سطح المكتب أو الويب أو الخادم، وتوفر لتطبيق بايثون نقطة انطلاق فعّالة لإضافة محتوى أغنى مثل النصوص أو الصور أو المخططات بمجرد إعداد مجموعة الشرائح الأولية.

## **إنشاء عرض تقديمي**

إنشاء ملف PowerPoint من الصفر في Aspose.Slides for Python مباشر مثل إنشاء كائن من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). يقوم المنشئ بتوفير مجموعة فارغة تحتوي على شريحة واحدة تلقائيًا، مما يمنحك لوحة رسم فورية للأشكال أو النصوص أو المخططات أو أي محتوى آخر يحتاجه تطبيقك. بمجرد تعديل تلك الشريحة—أو إضافة شرائح جديدة—يمكنك حفظ النتيجة كملف PPTX أو PPT قديم أو حتى صيغ OpenDocument. يوضح المثال البرمجي القصير أدناه هذا سير العمل عبر إضافة شكل بسيط إلى الشريحة الأولى.

1. إنشاء مثال من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة بحسب فهرستها.
1. إضافة كائن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `CLOUD` باستخدام طريقة `add_auto_shape` المتوفرة في مجموعة `shapes`.
1. إضافة نص إلى الشكل التلقائي.
1. حفظ العرض التقديمي المعدل كملف PPTX.

في المثال التالي، يُضاف شكل سحابة إلى الشريحة الأولى من العرض التقديمي.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:
    # الحصول على الشريحة الأولى.
    slide = presentation.slides[0]

    # إضافة شكل تلقائي من النوع CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

النتيجة:

![العرض التقديمي الجديد](new_presentation.png)

## **FAQ**

**ما الصيغ التي يمكنني حفظ عرض تقديمي جديد إليها؟**

يمكنك الحفظ إلى [PPTX وPPT وODP](/slides/ar/python-net/save-presentation/)، والتصدير إلى [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/python-net/convert-powerpoint-to-xps/)، [HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، [SVG](/slides/ar/python-net/convert-powerpoint-to-png/)، و[الصور](/slides/ar/python-net/convert-powerpoint-to-png/)، من بين صيغ أخرى.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كـ PPTX عادي؟**

نعم. حمّل القالب واحفظه بالصيغ المطلوبة؛ القوالب POTX/POTM/PPTM والصيغ المماثلة [مدعومة](/slides/ar/python-net/supported-file-formats/).

**كيف يمكنني التحكم في حجم الشريحة/نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟**

حدد [حجم الشريحة](/slides/ar/python-net/slide-size/) (بما في ذلك الإعدادات المسبقة مثل 4:3 و16:9 أو الأبعاد المخصصة) واختر طريقة تحجيم المحتوى.

**بأي وحدة تُقاس الأحجام والإحداثيات؟**

بالنقاط: 1 بوصة يساوي 72 وحدة.

**كيف أتعامل مع عروض تقديمية ضخمة (مع ملفات وسائط متعددة) لتقليل استهلاك الذاكرة؟**

استخدم [استراتيجيات إدارة BLOB](/slides/ar/python-net/manage-blob/)، وحدّد التخزين في الذاكرة عبر الاستفادة من الملفات المؤقتة، وفضّل سير عمل قائم على الملفات بدلاً من التدفقات داخل الذاكرة فقط.

**هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟**

لا يمكنك العمل على نفس كائن [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/python-net/multithreading/). شغّل مثيلات منفصلة ومعزولة لكل خيط أو عملية.

**كيف أزيل علامة تجريبية الماء والقيود؟**

[تطبيق ترخيص](/slides/ar/python-net/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف XML للترخيص غير معدل، ويجب مزامنة إعداد الترخيص إذا شاركت عدة خيوط.

**هل يمكنني توقيع PPTX رقميًا عند إنشائه؟**

نعم. [التوقيعات الرقمية](/slides/ar/python-net/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعروض التقديمية.

**هل تدعم الماكرو (VBA) في العروض التي تم إنشاؤها؟**

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/python-net/presentation-via-vba/) وحفظ ملفات مفعّلة للماكرو مثل PPTM/PPSM.