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
description: "إنشاء عروض PowerPoint في بايثون باستخدام Aspose.Slides—إنشاء ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجياً للحصول على نتائج موثوقة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إنشاء عرض تقديمي باستخدام Aspose.Slides لـ Python عبر .NET، وإضافة شكل يحتوي على نص إلى الشريحة الأولى، وحفظ النتيجة كملف PPTX. كما أن نفس API يحفظ العروض التقديمية كـ PPT و ODP، بحيث يمكنك استهداف صيغ PowerPoint و OpenDocument من قاعدة شفرة واحدة، دون الحاجة إلى Microsoft Office. يغطي قسم الأسئلة المتداولة القصير في النهاية الأسئلة الشائعة حول الصيغ والقوالب وحجم الشرائح والوحدات واستهلاك الذاكرة وخيوط التنفيذ والترخيص والتوقيعات الرقمية ودعم VBA.

قبل البدء، قم بتثبيت الحزمة من PyPI باستخدام `pip install aspose.slides`. راجع [التثبيت](/slides/ar/python-net/installation/) للحصول على المكتبات التي يحتاجها Linux و macOS أيضًا، وللحصول على البيئة الافتراضية التي يتطلبها Python نظام Debian و Ubuntu.

## **إنشاء عرض تقديمي**

لإنشاء عرض تقديمي ووضع شكل يحتوي على نص على الشريحة الأولى، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) . يحتوي عرض تقديمي جديد بالفعل على شريحة فارغة واحدة.
2. احصل على تلك الشريحة من مجموعة [slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/slides/ar/) باستخدام الفهرس 0.
3. أضف شكلًا سحابيًا من النوع [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) باستخدام طريقة [add_auto_shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_auto_shape/) لمجموعة [shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/shapes/) الخاصة بالشريحة، ثم عيّن خاصية [text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/textframe/text/).
4. احفظ العرض التقديمي كملف PPTX باستخدام طريقة [save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/).

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

زاوية السحابة العلوية اليسرى تبعد 20 نقطة عن الحافة اليسرى و20 نقطة عن الحافة العلوية للشريحة، وعرض السحابة 200 نقطة وارتفاعها 80 نقطة. يحرر بيان `with` موارد العرض التقديمي عند انتهاء الكتلة. يحفظ البرنامج النصي *new_presentation.pptx* في المجلد الحالي، مع شريحة واحدة تحتوي على السحابة ونصها. بدون ترخيص، يضيف Aspose.Slides علامة مائية تقييمية إلى كل شريحة يتم حفظها؛ راجع [الترخيص](/slides/ar/python-net/licensing/).

النتيجة:

![العرض التقديمي الجديد](new_presentation.png)

## **الأسئلة الشائعة**

### ما الصيغ التي يمكنني حفظ عرض تقديمي جديد إليها؟

يمكنك حفظ العرض إلى [PPTX, PPT, و ODP](/slides/ar/python-net/save-presentation/)، وتصديره إلى [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ar/python-net/convert-powerpoint-to-html/), [SVG](/slides/ar/python-net/render-a-slide-as-an-svg-image/), و[images](/slides/ar/python-net/convert-powerpoint-to-png/)، من بين أخرى.

### هل يمكنني البدء من قالب (POTX/POTM) وحفظه كملف PPTX عادي؟

نعم. حمّل القالب واحفظه بالصيغة المطلوبة؛ الصيغ POTX/POTM/PPTM وغيرها [مدعومة](/slides/ar/python-net/supported-file-formats/).

### كيف يمكنني التحكم في حجم الشريحة/نسبة الأبعاد عند إنشاء عرض تقديمي؟

حدد [حجم الشريحة](/slides/ar/python-net/slide-size/) (بما في ذلك القوالب مثل 4:3 و 16:9 أو أبعاد مخصصة) واختر كيفية مقياس المحتوى.

### بأي وحدات يتم قياس الأحجام والإحداثيات؟

بالنقاط: 1 بوصة يساوي 72 وحدة.

### كيف أتعامل مع عروض تقديمية كبيرة جدًا (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟

استخدم [BLOB management strategies](/slides/ar/python-net/manage-blob/)، حدّ التخزين في الذاكرة باستخدام ملفات مؤقتة، وفضّل سير عمل قائم على الملفات بدلاً من التدفقات التي تظل في الذاكرة فقط.

### هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟

لا يمكنك العمل على نفس كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) من [multiple threads](/slides/ar/python-net/multithreading/). شغّل مثيلات منفصلة ومعزولة لكل خيط أو عملية.

### كيف يمكنني إزالة علامة التجربة المائية والقيود؟

[Apply a license](/slides/ar/python-net/licensing/) مرة واحدة لكل عملية. يجب أن يظل ملف ترخيص XML بدون تعديل، ويجب مزامنة إعداد الترخيص إذا كانت هناك عدة خيوط.

### هل يمكنني توقيع ملف PPTX الذي أنشئه رقميًا؟

نعم. [Digital signatures](/slides/ar/python-net/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعروض التقديمية.

### هل تدعم الماكرو (VBA) في العروض التقديمية التي تم إنشاؤها؟

نعم. يمكنك [create/edit VBA projects](/slides/ar/python-net/presentation-via-vba/) وحفظ ملفات مفعلة للماكرو مثل PPTM/PPSM.