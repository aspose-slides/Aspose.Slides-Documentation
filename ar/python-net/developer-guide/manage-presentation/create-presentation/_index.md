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
description: "إنشاء عروض PowerPoint باستخدام بايثون وAspose.Slides—إنتاج ملفات PPT وPPTX وODP، الاستفادة من دعم OpenDocument، وحفظها برمجياً للحصول على نتائج موثوقة."
---

## **نظرة عامة**

يتيح Aspose.Slides للبايثون إنشاء ملف عرض تقديمي جديد بالكامل عبر الكود. تُظهر هذه المقالة سير العمل الأساسي—إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، الحصول على الشريحة الأولى، إدخال شكل بسيط، وحفظ النتيجة—حتى تتمكن من رؤية مدى القليل من الإعداد المطلوب لإنشاء عرض تقديمي دون الحاجة إلى Microsoft Office. لأن نفس الـ API يكتب ملفات PPT وPPTX وODP، يمكنك استهداف صيغ PowerPoint التقليدية وصيغ OpenDocument من قاعدة شفرة واحدة. يُناسب Aspose.Slides بيئات سطح المكتب أو الويب أو الخادم، موفراً لتطبيق بايثون الخاص بك نقطة انطلاق فعّالة لإضافة محتوى أغنى مثل النصوص أو الصور أو الرسوم البيانية بمجرد وجود مجموعة الشرائح الأولية.

## **إنشاء عرض تقديمي**

إنشاء ملف PowerPoint من الصفر في Aspose.Slides للبايثون سهل بقدر استدعاء فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). يقوم المُنشئ تلقائيًا بتوفير مجموعة فارغة تحتوي على شريحة واحدة، لتمنحك مساحة عمل فورية للأشكال أو النصوص أو الرسوم البيانية أو أي محتوى آخر يحتاجه تطبيقك. بمجرد تعديل تلك الشريحة—أو إضافة شرائح جديدة—يمكنك حفظ النتيجة بصيغة PPTX أو PPT التقليدية أو حتى صيغ OpenDocument. يوضح مثال الشيفرة القصير أدناه هذا سير العمل بإضافة شكل بسيط إلى الشريحة الأولى.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على إشارة إلى الشريحة بحسب فهرستها.
3. إضافة كائن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `CLOUD` باستخدام طريقة `add_auto_shape` المتاحة في مجموعة `shapes`.
4. إضافة نص إلى الشكل التلقائي.
5. حفظ العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، يُضاف شكل سحابة إلى الشريحة الأولى من العرض التقديمي.

```py
import aspose.slides as slides

# إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي.
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

## **الأسئلة المتكررة**

**ما الصيغ التي يمكنني حفظ عرض تقديمي جديد بها؟**

يمكنك الحفظ إلى [PPTX, PPT, و ODP](/slides/ar/python-net/save-presentation/)، وتصدير إلى [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/python-net/convert-powerpoint-to-xps/)، [HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، [SVG](/slides/ar/python-net/convert-powerpoint-to-png/)، و[الصور](/slides/ar/python-net/convert-powerpoint-to-png/)، من بين صيغ أخرى.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كملف PPTX عادي؟**

نعم. قم بتحميل القالب واحفظه بالصيغ المطلوبة؛ الصيغ POTX/POTM/PPTM وغيرها [مدعومة](/slides/ar/python-net/supported-file-formats/).

**كيف يمكنني التحكم في حجم الشريحة/نسبة الأبعاد عند إنشاء عرض تقديمي؟**

حدد [حجم الشريحة](/slides/ar/python-net/slide-size/) (بما في ذلك القوالب مثل 4:3 و16:9 أو الأبعاد المخصصة) واختر كيفية تناسب المحتوى.

**بأي وحدات تُقاس الأحجام والإحداثيات؟**

بالنقاط: 1 بوصة تساوي 72 وحدة.

**كيف يمكنني التعامل مع عروض تقديمية ضخمة (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟**

استخدم [استراتيجيات إدارة الـ BLOB](/slides/ar/python-net/manage-blob/)، حدّ التخزين في الذاكرة عبر الاستفادة من الملفات المؤقتة، وفضّل سير عمل يعتمد على الملفات بدلاً من التدفقات في الذاكرة فقط.

**هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟**

لا يمكن تنفيذ عمليات على نفس كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/python-net/multithreading/). شغّل مثيلات منفصلة ومعزولة لكل خيط أو عملية.

**كيف يمكنني إزالة علامة التجربة المائية والقيود؟**

[طبق ترخيص](/slides/ar/python-net/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف الترخيص XML غير معدل، ويُنسق إعداد الترخيص إذا تم استخدام عدة خيوط.

**هل يمكنني توقيع PPTX رقمياً بعد إنشائه؟**

نعم. [التواقيع الرقمية](/slides/ar/python-net/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعروض التقديمية.

**هل تدعم الماكرو (VBA) في العروض التي تم إنشاؤها؟**

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/python-net/presentation-via-vba/) وحفظ ملفات تمكين الماكرو مثل PPTM/PPSM.