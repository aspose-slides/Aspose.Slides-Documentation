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
description: "إنشاء عروض PowerPoint في Python باستخدام Aspose.Slides—إنتاج ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجيًا للحصول على نتائج موثوقة."
---

## **نظرة عامة**

Aspose.Slides for Python يتيح لك إنشاء ملف عرض تقديمي جديد بالكامل عن طريق الشيفرة. توضح هذه المقالة سير العمل الأساسي — إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ، الحصول على الشريحة الأولى ، إدراج شكل بسيط ، وحفظ النتيجة — لتتمكن من رؤية مدى قلة الإعدادات المطلوبة لتوليد عرض تقديمي بدون Microsoft Office. نظرًا لأن نفس واجهة برمجة التطبيقات تكتب ملفات PPT و PPTX و ODP ، يمكنك استهداف كل من صيغ PowerPoint التقليدية وصيغة OpenDocument من قاعدة شيفرة واحدة. Aspose.Slides مناسبة لبيئات سطح المكتب أو الويب أو الخادم، مما يمنح تطبيق Python الخاص بك نقطة انطلاق فعّالة لإضافة محتوى أغنى مثل النصوص أو الصور أو المخططات بمجرد توفر مجموعة الشرائح الأولية.

## **إنشاء عرض تقديمي**

إنشاء ملف PowerPoint من الصفر في Aspose.Slides for Python مباشر مثل إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). يقوم المُنشئ تلقائيًا بتوفير مجموعة فارغة بشريحة واحدة، مما يمنحك لوحة رسم فورية للأشكال أو النصوص أو المخططات أو أي محتوى آخر يحتاجه تطبيقك. بمجرد تعديل تلك الشريحة — أو إضافة شرايح جديدة — يمكنك حفظ النتيجة كملف PPTX أو PPT التقليدي أو حتى بصيغة OpenDocument. يوضح نموذج الشيفرة القصير أدناه هذا سير العمل بإضافة شكل بسيط إلى الشريحة الأولى.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة حسب فهرستها.
1. إضافة كائن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `CLOUD` باستخدام طريقة `add_auto_shape` المتوفرة في مجموعة `shapes`.
1. إضافة نص إلى الشكل التلقائي.
1. حفظ العرض التقديمي المعدل كملف PPTX.

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

## **الأسئلة المتداولة**

**ما الصيغ التي يمكنني حفظ عرض تقديمي جديد بها؟**

يمكنك الحفظ إلى [PPTX و PPT و ODP](/slides/ar/python-net/save-presentation/)، وتصدير إلى [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ar/python-net/convert-powerpoint-to-html/), [SVG](/slides/ar/python-net/convert-powerpoint-to-png/), و[images](/slides/ar/python-net/convert-powerpoint-to-png/)، من بين أخرى.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كملف PPTX عادي؟**

نعم. قم بتحميل القالب واحفظه بالصيغة المطلوبة؛ الصيغ مثل POTX/POTM/PPTM وما شابهها [مدعومة](/slides/ar/python-net/supported-file-formats/).

**كيف يمكنني التحكم في حجم الشريحة/نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟**

قم بتعيين [حجم الشريحة](/slides/ar/python-net/slide-size/) (بما في ذلك القوالب المسبقة مثل 4:3 و 16:9 أو الأبعاد المخصصة) واختر كيفية تكبير المحتوى.

**بأي وحدات تُقاس الأحجام والإحداثيات؟**

بالنقاط: إن البوصة الواحدة تساوي 72 وحدة.

**كيف يمكنني التعامل مع العروض التقديمية الكبيرة جدًا (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟**

استخدم [استراتيجيات إدارة BLOB](/slides/ar/python-net/manage-blob/)، وقم بتقليل التخزين في الذاكرة من خلال الاستفادة من الملفات المؤقتة، وفضّل سير عمل قائم على الملفات بدلًا من التدفقات التي تُحفظ بالكامل في الذاكرة.

**هل يمكنني إنشاء/حفظ العروض التقديمية بشكل متوازي؟**

لا يمكنك العمل على نفس كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/python-net/multithreading/). شغّل مثيلات منفصلة ومعزولة لكل خيط أو عملية.

**كيف يمكنني إزالة علامة التجربة والقيود؟**

[طبق ترخيصًا](/slides/ar/python-net/licensing/) مرة واحدة لكل عملية. يجب أن يظل ملف XML للترخيص غير معدل، ويجب مزامنة إعداد الترخيص إذا كانت هناك خيوط متعددة.

**هل يمكنني توقيع الـ PPTX رقمياً؟**

نعم. [التوقيعات الرقمية](/slides/ar/python-net/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعرض التقديمي.

**هل يتم دعم الماكروز (VBA) في العروض التقديمية التي تم إنشاؤها؟**

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/python-net/presentation-via-vba/) وحفظ الملفات المدعومة للماكرو مثل PPTM/PPSM.