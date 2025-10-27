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
description: "إنشاء عروض PowerPoint في بايثون باستخدام Aspose.Slides—إنتاج ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجياً للحصول على نتائج موثوقة."
---

## **نظرة عامة**

تتيح لك Aspose.Slides للبايثون بناء ملف عرض تقديمي جديد تمامًا بواسطة الكود. تُظهر هذه المقالة سير العمل الأساسي — إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، الحصول على الشريحة الأولى، إدراج شكل بسيط، وحفظ النتيجة — حتى تتمكن من رؤية مقدار الإعداد القليل المطلوب لتوليد عرض تقديمي دون الحاجة إلى Microsoft Office. لأن نفس واجهة البرمجة تُكتب ملفات PPT و PPTX و ODP، يمكنك استهداف صيغ PowerPoint التقليدية وOpenDocument من قاعدة شفرة واحدة. Aspose.Slides مناسب لبيئات سطح المكتب أو الويب أو الخادم، مما يمنح تطبيق البايثون الخاص بك نقطة انطلاق فعّالة لإضافة محتوى غني مثل النصوص أو الصور أو المخططات بمجرد إعداد مجموعة الشرائح الأولية.

## **إنشاء عرض تقديمي**

إنشاء ملف PowerPoint من الصفر في Aspose.Slides للبايثون بسيط كإنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). يُوفر المُنشئ تلقائيًا مجموعة فارغة بشريحة واحدة، ليصبح لديك لوحة رسم فورية للأشكال أو النصوص أو المخططات أو أي محتوى آخر تحتاجه تطبيقك. بعد تعديل تلك الشريحة — أو إضافة شرائح جديدة — يمكنك حفظ النتيجة كملف PPTX أو PPT قديم أو حتى بصيغة OpenDocument. يوضح المثال البرمجي القصير أدناه هذا سير العمل بإضافة شكل بسيط إلى الشريحة الأولى.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة بواسطة فهرستها.
3. إضافة كائن [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) من النوع `CLOUD` باستخدام طريقة `add_auto_shape` المتاحة في مجموعة `shapes`.
4. إضافة نص إلى الشكل التلقائي.
5. حفظ العرض التقديمي المعدل كملف PPTX.

في المثال التالي، يُضاف شكل سحابة إلى الشريحة الأولى من العرض التقديمي.

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

## **الأسئلة الشائعة**

**ما الصيغ التي يمكنني حفظ عرض تقديمي جديد إليها؟**

يمكنك الحفظ إلى [PPTX و PPT و ODP](/slides/ar/python-net/save-presentation/)، وتصدير إلى [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/python-net/convert-powerpoint-to-xps/)، [HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، [SVG](/slides/ar/python-net/convert-powerpoint-to-png/)، و[الصور](/slides/ar/python-net/convert-powerpoint-to-png/) وغيرها.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كـ PPTX عادي؟**

نعم. حمّل القالب ثم احفظه بالصيغ المطلوبة؛ الصيغ مثل POTX/POTM/PPTM وغيرها [مدعومة](/slides/ar/python-net/supported-file-formats/).

**كيف يمكنني التحكم في حجم الشريحة/نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟**

حدد [حجم الشريحة](/slides/ar/python-net/slide-size/) (بما يشمل الإعدادات المسبقة مثل 4:3 و 16:9 أو الأبعاد المخصصة) واختر طريقة مقياس المحتوى.

**ما الوحدات المستخدمة للقياسات والإحداثيات؟**

بالنقاط: البوصة الواحدة تساوي 72 وحدة.

**كيف أتعامل مع عروض تقديمية ضخمة (مع ملفات وسائط كثيرة) لتقليل استهلاك الذاكرة؟**

استخدم [استراتيجيات إدارة BLOB](/slides/ar/python-net/manage-blob/)، قلل التخزين في الذاكرة عبر الاستفادة من الملفات المؤقتة، وفضّل سير العمل القائم على الملفات على تدفقات الذاكرة فقط.

**هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟**

لا يمكنك التعامل مع نفس كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/python-net/multithreading/). شغّل نسخًا منفصلة ومعزولة لكل خيط أو عملية.

**كيف أزيل علامة التجربة المائية والقيود؟**

[طبق ترخيص](/slides/ar/python-net/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف ترخيص XML دون تعديل، ويجب مزامنة إعداد الترخيص إذا كانت هناك خيوط متعددة.

**هل يمكنني توقيع PPTX رقمياً بعد إنشائه؟**

نعم. [التوقيعات الرقمية](/slides/ar/python-net/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعروض التقديمية.

**هل تدعم العروض التقديمية الماكرو (VBA)؟**

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/python-net/presentation-via-vba/) وحفظ ملفات تمكين الماكرو مثل PPTM/PPSM.