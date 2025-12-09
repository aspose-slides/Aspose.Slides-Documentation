---
title: إنشاء عروض تقديمية في Python
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
description: "إنشاء عروض PowerPoint في Python باستخدام Aspose.Slides — إنتاج ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجيًا للحصول على نتائج موثوقة."
---

## **نظرة عامة**

تتيح لك Aspose.Slides for Python إنشاء ملف عرض تقديمي جديد بالكامل باستخدام الكود. تُظهر هذه المقالة سير العمل الأساسي — إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ، الحصول على الشريحة الأولى ، إدراج شكل بسيط ، وحفظ النتيجة — لتتمكن من رؤية مدى قلة الإعداد المطلوب لتوليد عرض تقديمي بدون Microsoft Office. نظرًا لأن نفس API يكتب ملفات PPT و PPTX و ODP ، يمكنك استهداف كل من تنسيقات PowerPoint التقليدية و OpenDocument من قاعدة شفرة واحدة. تُناسب Aspose.Slides بيئات سطح المكتب أو الويب أو الخادم، مما يمنح تطبيق Python الخاص بك نقطة انطلاق فعالة لإضافة محتوى أغنى مثل النصوص أو الصور أو المخططات بمجرد أن يكون مجموعة الشرائح الأولية جاهزة.

## **إنشاء عرض تقديمي**

إنشاء ملف PowerPoint من الصفر في Aspose.Slides for Python بسيط كاستدعاء فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). يقوم المُنشئ تلقائيًا بتوفير مجموعة فارغة بشريحة واحدة، مما يمنحك لوحة رسم فورية للأشكال أو النصوص أو المخططات أو أي محتوى آخر تحتاجه تطبيقاتك. بمجرد تعديل تلك الشريحة — أو إضافة شرائح جديدة — يمكنك حفظ النتيجة كملف PPTX أو PPT القديم أو حتى تنسيقات OpenDocument. يوضح المثال القصير أدناه هذا سير العمل بإضافة شكل بسيط إلى الشريحة الأولى.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة حسب فهرسها.
1. أضف كائن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `CLOUD` باستخدام طريقة `add_auto_shape` التي توفرها مجموعة `shapes`.
1. أضف نصًا إلى الشكل التلقائي.
1. احفظ العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، يتم إضافة شكل سحابة إلى الشريحة الأولى من العرض التقديمي.
```py
import aspose.slides as slides

# إنشاء كائن الفئة Presentation التي تمثل ملف عرض تقديمي.
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

## **الأسئلة الشائعة**

**ما هي الصيغ التي يمكنني حفظ عرض تقديمي جديد بها؟**

يمكنك الحفظ إلى [PPTX, PPT, and ODP](/slides/ar/python-net/save-presentation/)، والتصدير إلى [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/python-net/convert-powerpoint-to-xps/)، [HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، [SVG](/slides/ar/python-net/convert-powerpoint-to-png/)، و[الصور](/slides/ar/python-net/convert-powerpoint-to-png/)، من بين أخرى.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كـ PPTX عادي؟**

نعم. حمّل القالب واحفظه بالصيغة المطلوبة؛ تُدعم صيغ POTX/POTM/PPTM وما شابهها [/slides/python-net/supported-file-formats/].

**كيف يمكنني التحكم في حجم الشريحة/نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟**

حدد [حجم الشريحة](/slides/ar/python-net/slide-size/) (بما فيها الإعدادات المسبقة مثل 4:3 و 16:9 أو الأبعاد المخصصة) واختر طريقة تكبير المحتوى.

**بأي وحدات تُقاس الأحجام والإحداثيات؟**

بوحدات النقاط: إنش واحد يساوي 72 وحدة.

**كيف أتعامل مع عروض تقديمية كبيرة جدًا (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟**

استخدم [استراتيجيات إدارة BLOB](/slides/ar/python-net/manage-blob/)، وحدّ التخزين في الذاكرة باستخدام الملفات المؤقتة، وفضّل سير عمل يعتمد على الملفات بدلاً من التدفقات الداخلية فقط.

**هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟**

لا يمكنك العمل على نفس كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/python-net/multithreading/). شغّل مثيلات منفصلة ومعزولة لكل خيط أو عملية.

**كيف أزيل علامة مائية التجربة والقيود؟**

[قم بتطبيق ترخيص](/slides/ar/python-net/licensing/) مرة واحدة لكل عملية. يجب ألا يتغير ملف XML للترخيص، ويجب مزامنة إعداد الترخيص إذا كانت هناك خيوط متعددة.

**هل يمكنني توقيع PPTX رقمياً؟**

نعم. تدعم [التوقيعات الرقمية](/slides/ar/python-net/digital-signature-in-powerpoint/) (الإضافة والتحقق) للعرض التقديمي.

**هل تدعم العروض التقديمية التي تم إنشاؤها وحدات ماكرو (VBA)؟**

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/python-net/presentation-via-vba/) وحفظ ملفات تدعم الماكرو مثل PPTM/PPSM.