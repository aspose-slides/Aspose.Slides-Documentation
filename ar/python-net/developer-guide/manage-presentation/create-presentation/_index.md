---
title: إنشاء عروض تقديمية في بايثون
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
description: "إنشاء عروض PowerPoint في بايثون باستخدام Aspose.Slides—إنتاج ملفات PPT و PPTX و ODP، والاستفادة من دعم OpenDocument، وحفظها برمجياً لتحقيق نتائج موثوقة."
---

## **نظرة عامة**

Aspose.Slides for Python يتيح لك إنشاء ملف عرض تقديمي جديد كليًا باستخدام الكود فقط. يعرض هذا المقال سير العمل الأساسي — إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ، الحصول على الشريحة الأولى ، إدراج شكل بسيط ، وحفظ النتيجة — لتتمكن من رؤية مدى القليل من الإعداد المطلوب لتوليد عرض تقديمي دون الحاجة إلى Microsoft Office. نظرًا لأن نفس الـ API يكتب ملفات PPT و PPTX و ODP ، يمكنك استهداف كل من صيغ PowerPoint التقليدية وصيغ OpenDocument من قاعدة شفرة واحدة. Aspose.Slides مناسب لبيئات سطح المكتب أو الويب أو الخوادم، مما يمنح تطبيق Python الخاص بك نقطة انطلاق فعالة لإضافة محتوى أكثر غنى مثل النصوص أو الصور أو المخططات بمجرد إنشاء مجموعة الشرائح الأولية.

## **إنشاء عرض تقديمي**

إنشاء ملف PowerPoint من الصفر في Aspose.Slides for Python سهل كاستدعاء فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). يقوم المُنشئ تلقائيًا بتوفير مجموعة فارغة بشريحة واحدة، مما يوفر لك لوحة قماش فورية للأشكال أو النصوص أو المخططات أو أي محتوى آخر يحتاجه تطبيقك. بعد تعديل تلك الشريحة — أو إضافة شريحة جديدة — يمكنك حفظ النتيجة كملف PPTX أو PPT التقليدي أو حتى صيغ OpenDocument. يوضح المثال القصير أدناه سير العمل هذا عن طريق إضافة شكل بسيط إلى الشريحة الأولى.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة بحسب فهرستها.
3. إضافة كائن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `CLOUD` باستخدام الطريقة `add_auto_shape` المتوفرة في مجموعة `shapes`.
4. إضافة نص إلى الشكل التلقائي.
5. حفظ العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، يتم إضافة شكل سحابة إلى الشريحة الأولى من العرض التقديمي.
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

## **الأسئلة الشائعة**

**ما الصيغ التي يمكنني حفظ عرض تقديمي جديد إليها؟**

يمكنك الحفظ إلى [PPTX, PPT, و ODP](/slides/ar/python-net/save-presentation/)، وتصدير إلى [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/python-net/convert-powerpoint-to-xps/)، [HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، [SVG](/slides/ar/python-net/convert-powerpoint-to-png/)، و[الصور](/slides/ar/python-net/convert-powerpoint-to-png/)، من بين صيغ أخرى.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كملف PPTX عادي؟**

نعم. حمّل القالب واحفظه بالصيغ المطلوبة؛ الصيغ مثل POTX/POTM/PPTM وغيرها [مدعومة](/slides/ar/python-net/supported-file-formats/).

**كيف يمكنني التحكم في حجم الشريحة/نسبة الأبعاد عند إنشاء عرض تقديمي؟**

حدد [حجم الشريحة](/slides/ar/python-net/slide-size/) (بما في ذلك القوالب مثل 4:3 و 16:9 أو الأبعاد المخصصة) واختر كيفية تحجيم المحتوى.

**ما هي الوحدات التي تُقاس بها الأحجام والإحداثيات؟**

بالنقطة: 1 بوصة تساوي 72 وحدة.

**كيف يمكنني التعامل مع عروض تقديمية ضخمة (مع الكثير من ملفات الوسائط) لتقليل استهلاك الذاكرة؟**

استخدم [استراتيجيات إدارة BLOB](/slides/ar/python-net/manage-blob/)، قلل التخزين في الذاكرة عبر الاستفادة من الملفات المؤقتة، وفضّل سير العمل القائم على الملفات على التدفقات داخل الذاكرة فقط.

**هل يمكنني إنشاء/حفظ عروض تقديمية بالتوازي؟**

لا يمكنك التعامل مع نفس كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/python-net/multithreading/). شغّل نسخًا منفصلة ومعزولة لكل خيط أو عملية.

**كيف أزيل علامة تجريبية واتفاقيات الترخيص؟**

[طبق ترخيص](/slides/ar/python-net/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف XML للترخيص غير معدل، ويجب مزامنة إعداد الترخيص إذا كانت هناك خيوط متعددة.

**هل يمكنني توقيع ملف PPTX رقميًا؟**

نعم. [التوقيعات الرقمية](/slides/ar/python-net/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعرض التقديمي.

**هل تدعم الماكروات (VBA) في العروض التي تم إنشاؤها؟**

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/python-net/presentation-via-vba/) وحفظ ملفات تمكين الماكرو مثل PPTM/PPSM.