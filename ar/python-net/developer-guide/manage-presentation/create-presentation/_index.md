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
- بايثون
- Aspose.Slides
description: "إنشاء عروض PowerPoint في بايثون باستخدام Aspose.Slides — إنتاج ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجياً للحصول على نتائج موثوقة."
---

## **نظرة عامة**

Aspose.Slides for Python يتيح لك إنشاء ملف عرض تقديمي جديد كليًا بالكامل عبر الشيفرة. يوضح هذا المقال سير العمل الأساسي—إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ، الحصول على الشريحة الأولى ، إدراج شكل بسيط ، وحفظ النتيجة—لتظهر كم هو عدد القليل من الإعدادات المطلوبة لإنشاء عرض تقديمي بدون Microsoft Office. بما أن نفس واجهة برمجة التطبيقات تكتب ملفات PPT و PPTX و ODP ، يمكنك استهداف كل من تنسيقات PowerPoint التقليدية و OpenDocument من قاعدة شيفرة واحدة. Aspose.Slides مناسب لبيئات سطح المكتب أو الويب أو الخادم، مما يمنح تطبيق Python الخاص بك نقطة انطلاق فعالة لإضافة محتوى غني مثل النصوص، الصور، أو المخططات بمجرد أن يكون مجموعة الشرائح الأولية موجودة.

## **إنشاء عرض تقديمي**

إنشاء ملف PowerPoint من الصفر في Aspose.Slides for Python هو بسيط مثل إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class. يقوم المنشئ تلقائيًا بتوفير مجموعة فارغة بشريحة واحدة، مما يمنحك لوحة فورية للأشكال، النص، المخططات، أو أي محتوى آخر تحتاجه تطبيقك. بمجرد تعديل تلك الشريحة—أو إضافة أخرى—يمكنك حفظ النتيجة إلى PPTX أو PPT القديم أو حتى تنسيقات OpenDocument. يوضح مثال الشيفرة القصير أدناه هذا سير العمل بإضافة شكل بسيط إلى الشريحة الأولى.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة حسب فهرستها.
3. إضافة كائن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `CLOUD` باستخدام طريقة `add_auto_shape` التي تُظهرها مجموعة `shapes`.
4. إضافة نص إلى الشكل التلقائي.
5. حفظ العرض المعدل كملف PPTX.

في المثال أدناه، يُضاف شكل سحابة إلى الشريحة الأولى من العرض.

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

## **الأسئلة المتكررة**

**ما الصيغ التي يمكنني حفظ عرض تقديمي جديد إليها؟**

يمكنك الحفظ إلى [PPTX و PPT و ODP](/slides/ar/python-net/save-presentation/)، وتصدير إلى [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ar/python-net/convert-powerpoint-to-html/), [SVG](/slides/ar/python-net/convert-powerpoint-to-png/), و [images](/slides/ar/python-net/convert-powerpoint-to-png/)، من بين أخرى.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كـ PPTX عادي؟**

نعم. حمّل القالب واحفظه بالصِيغة المطلوبة؛ الصيغ POTX/POTM/PPTM والصيغ المماثلة [مدعومة](/slides/ar/python-net/supported-file-formats/).

**كيف يمكنني التحكم في حجم الشريحة / نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟**

حدد [حجم الشريحة](/slides/ar/python-net/slide-size/) (بما في ذلك القوالب مثل 4:3 و 16:9 أو أبعاد مخصصة) واختر طريقة تكبير/تصغير المحتوى.

**بأي وحدات تُقاس الأحجام والإحداثيات؟**

بالنقاط: 1 بوصة تساوي 72 وحدة.

**كيف يمكنني التعامل مع عروض تقديمية كبيرة جدًا (مع ملفات وسائط متعددة) لتقليل استهلاك الذاكرة؟**

استخدم [استراتيجيات إدارة BLOB](/slides/ar/python-net/manage-blob/)، قلل من التخزين في الذاكرة باستخدام ملفات مؤقتة، وفضّل سير العمل القائم على الملفات بدلاً من التدفقات التي تُحفظ بالكامل في الذاكرة.

**هل يمكنني إنشاء/حفظ عروض تقديمية بالتوازي؟**

لا يمكنك التعامل مع نفس كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/python-net/multithreading/). شغّل نسخ منفصلة ومعزولة لكل خيط أو عملية.

**كيف يمكنني إزالة علامة التجربة والقيود؟**

[طبق ترخيصًا](/slides/ar/python-net/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف XML للترخيص غير معدل، ويجب مزامنة إعداد الترخيص إذا كانت هناك خيوط متعددة.

**هل يمكنني توقيع PPTX رقمياً؟**

نعم. [التوقيعات الرقمية](/slides/ar/python-net/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعروض التقديمية.

**هل تدعم الماكرو (VBA) في العروض التي تم إنشاؤها؟**

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/python-net/presentation-via-vba/) وحفظ ملفات تمكين الماكرو مثل PPTM/PPSM.