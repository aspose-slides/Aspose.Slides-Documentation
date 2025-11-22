---
title: إنشاء عرض تقديمي في بايثون
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
description: "إنشاء عروض PowerPoint في بايثون باستخدام Aspose.Slides — إنتاج ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجيًا للحصول على نتائج موثوقة."
---

## **نظرة عامة**

تتيح لك Aspose.Slides for Python إنشاء ملف عرض تقديمي جديد بالكامل باستخدام الشيفرة. تُظهر هذه المقالة سير العمل الأساسي—إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، الحصول على الشريحة الأولى، إدخال شكل بسيط، وحفظ النتيجة—حتى تتمكن من رؤية مدى القليل من الإعداد المطلوب لإنشاء عرض تقديمي دون Microsoft Office. نظرًا لأن نفس الواجهة البرمجية تكتب ملفات PPT وPPTX وODP، يمكنك استهداف كل من صيغة PowerPoint التقليدية وصياغة OpenDocument من قاعدة شيفرة واحدة. Aspose.Slides مناسبة لبيئات سطح المكتب أو الويب أو الخادم، مما يمنح تطبيق Python الخاص بك نقطة انطلاق فعّالة لإضافة محتوى أغنى مثل النصوص، الصور، أو المخططات بمجرد وجود مجموعة الشرائح الأولية.

## **إنشاء عرض تقديمي**

إنشاء ملف PowerPoint من الصفر في Aspose.Slides for Python مباشر كإنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). المُنشئ يزودك تلقائيًا بمجموعة فارغة بشريحة واحدة، مما يمنحك لوحة رسم فورية للأشكال، النص، المخططات، أو أي محتوى آخر يحتاجه تطبيقك. بمجرد تعديل تلك الشريحة—أو إضافة شرايح جديدة—يمكنك حفظ النتيجة كملف PPTX أو PPT legacy أو حتى صيغ OpenDocument. يوضح مثال الشيفرة القصير أدناه هذا سير العمل بإضافة شكل بسيط إلى الشريحة الأولى.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة بحسب الفهرس الخاص بها.
3. إضافة كائن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `CLOUD` باستخدام الطريقة `add_auto_shape` المتاحة في مجموعة `shapes`.
4. إضافة نص إلى الشكل التلقائي.
5. حفظ العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، يتم إضافة شكل سحابة إلى الشريحة الأولى من العرض التقديمي.
```py
import aspose.slides as slides

    # إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
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

يمكنك الحفظ إلى [PPTX, PPT, and ODP](/slides/ar/python-net/save-presentation/)، وتصدير إلى [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/python-net/convert-powerpoint-to-xps/)، [HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، [SVG](/slides/ar/python-net/convert-powerpoint-to-png/)، و[images](/slides/ar/python-net/convert-powerpoint-to-png/)، وغيرها.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كملف PPTX عادي؟**

نعم. قم بتحميل القالب وحفظه بالصيغة المطلوبة؛ صيغ POTX/POTM/PPTM والصيغ المماثلة [are supported](/slides/ar/python-net/supported-file-formats/).

**كيف يمكنني التحكم في حجم الشريحة/نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟**

حدد [slide size](/slides/ar/python-net/slide-size/) (بما في ذلك الإعدادات المسبقة مثل 4:3 و16:9 أو الأبعاد المخصصة) واختر كيف يجب أن يتم تحجيم المحتوى.

**بأي وحدة تُقاس الأحجام والإحداثيات؟**

بالنقاط: 1 بوصة تساوي 72 وحدة.

**كيف أقوم بالتعامل مع عروض تقديمية كبيرة جدًا (مع الكثير من ملفات الوسائط) لتقليل استهلاك الذاكرة؟**

استخدم [BLOB management strategies](/slides/ar/python-net/manage-blob/)، قلل التخزين في الذاكرة من خلال الاستفادة من الملفات المؤقتة، وفضّل سير العمل المعتمد على الملفات بدلاً من التدفقات داخل الذاكرة فقط.

**هل يمكنني إنشاء/حفظ العروض التقديمية بشكل متوازي؟**

لا يمكنك العمل على نفس كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من عدة خيوط. شغّل مثيلات منفصلة ومعزولة لكل خيط أو عملية.

**كيف يمكنني إزالة علامة الماء التجريبية والقيود؟**

[Apply a license](/slides/ar/python-net/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف XML للترخيص بدون تعديل، ويجب مزامنة إعداد الترخيص إذا كان هناك عدة خيوط.

**هل يمكنني توقيع ملف PPTX رقمياً؟**

نعم. [Digital signatures](/slides/ar/python-net/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعروض التقديمية.

**هل الماكرو (VBA) مدعومة في العروض التي تم إنشاؤها؟**

نعم. يمكنك [create/edit VBA projects](/slides/ar/python-net/presentation-via-vba/) وحفظ ملفات تمكين الماكرو مثل PPTM/PPSM.