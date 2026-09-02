---
title: حفظ العروض التقديمية في بايثون
linktitle: حفظ العروض التقديمية
type: docs
weight: 80
url: /ar/python-net/save-presentation/
keywords:
- حفظ PowerPoint
- حفظ OpenDocument
- حفظ العرض التقديمي
- حفظ الشريحة
- حفظ PPT
- حفظ PPTX
- حفظ ODP
- عرض تقديمي إلى ملف
- عرض تقديمي إلى تدفق
- نوع عرض مسبق التعريف
- تنسيق Strict Office Open XML
- وضع Zip64
- تحديث الصورة المصغرة
- تقدم الحفظ
- بايثون
- Aspose.Slides
description: "اكتشف كيفية حفظ العروض التقديمية في بايثون باستخدام Aspose.Slides—تصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والتأثيرات."
---
## **نظرة عامة**

[فتح عرض تقديمي في Python](/slides/ar/python-net/open-presentation/) يصف كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) لفتح عرض تقديمي. تشرح هذه المقالة كيفية إنشاء العروض التقديمية وحفظها. فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) تحتوي على محتويات العرض التقديمي. سواء كنت تنشئ عرضًا تقديميًا من الصفر أو تعدل عرضًا موجودًا، فستحتاج إلى حفظه عند الانتهاء. مع Aspose.Slides for Python، يمكنك الحفظ إلى **ملف** أو **تيار**. تشرح هذه المقالة الطرق المختلفة لحفظ العرض التقديمي.

## **حفظ العروض التقديمية إلى ملفات**

احفظ عرضًا تقديميًا إلى ملف عن طريق استدعاء طريقة `save` الخاصة بفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/). مرّر اسم الملف وتنسيق الحفظ إلى الطريقة. يوضح المثال التالي كيفية حفظ عرض تقديمي باستخدام Aspose.Slides for Python.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:
    
    # قم ببعض العمل هنا...

    # احفظ العرض التقديمي إلى ملف.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **حفظ العروض التقديمية إلى تيارات**

يمكنك حفظ عرض تقديمي إلى تيار بتمرير تيار إخراج إلى طريقة `save` الخاصة بفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/). يمكن كتابة العرض التقديمي إلى العديد من أنواع التيارات. في المثال أدناه، ننشئ عرضًا تقديميًا جديدًا ونحفظه إلى تيار ملف.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # حفظ العرض التقديمي إلى التيار.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **حفظ العروض التقديمية بنوع عرض مسبق التعريف**

يتيح Aspose.Slides for Python لك ضبط العرض الأولي الذي يستخدمه PowerPoint عند فتح العرض التقديمي الذي تم توليده من خلال فئة [ViewProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/). اضبط خاصية `last_view` إلى قيمة من تعداد [ViewType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **حفظ العروض التقديمية بتنسيق Strict Office Open XML**

يتيح Aspose.Slides لك حفظ عرض تقديمي بتنسيق Strict Office Open XML. استخدم فئة [PptxOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/pptxoptions/) واضبط خاصية `conformance` عند الحفظ. إذا ضبطت `Conformance.ISO_29500_2008_STRICT`، سيتم حفظ ملف الإخراج بتنسيق Strict Office Open XML.

يوضح المثال أدناه إنشاء عرض تقديمي وحفظه بتنسيق Strict Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:
    # حفظ العرض التقديمي بتنسيق Strict Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدودًا قدرها 4 جيجابايت (2^32 بايت) على الحجم غير المضغوط لأي ملف، وحجم أي ملف مضغوط، وإجمالي حجم الأرشيف، كما يحد من عدد الملفات إلى 65 535 (2^16‑1). توسعات تنسيق ZIP64 ترفع هذه الحدود إلى 2^64.

تتيح خاصية [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) اختيار متى يتم استخدام توسعات تنسيق ZIP64 عند حفظ ملف Office Open XML.

تقدم هذه الخاصية الأوضاع التالية:

- `IF_NECESSARY` يستخدم توسعات ZIP64 فقط إذا تجاوز العرض التقديمي الحدود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- `NEVER` لا يستخدم توسعات ZIP64 أبداً.
- `ALWAYS` يستخدم توسعات ZIP64 دائمًا.

يوضح الكود التالي كيفية حفظ عرض تقديمي كملف PPTX مع تمكين توسعات ZIP64:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="ملاحظة" color="warning" %}}
عند الحفظ باستخدام `Zip64Mode.NEVER`، يتم إلقاء استثناء [PptxException](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pptxexception/) إذا تعذر حفظ العرض التقديمي بتنسيق ZIP32.
{{% /alert %}}

## **حفظ العروض التقديمية بتنسيق Office Open XML مع مستويات الضغط**

عند التعامل مع عروض تقديمية كبيرة، يمكنك ضبط مستوى الضغط لتحقيق توازن بين حجم الملف وزمن المعالجة. بناءً على متطلباتك، قد تفضِّل معالجة أسرع أو ملفات أصغر حجمًا.

توفر Aspose.Slides خاصية [PptxOptions.compression_level](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/pptxoptions/compression_level/) التي تسمح بتحديد مستوى الضغط المستخدم عند حفظ العرض التقديمي بتنسيق Office Open XML.

المستويات المتاحة هي:

- [**NONE**](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/compressionlevel/): لا يُطبق ضغط. تُخزن الملفات كما هي.
- [**LEVEL1**](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/compressionlevel/): أسرع ضغط بأقل نسبة ضغط.
- [**LEVEL2**](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/compressionlevel/): ضغط أسرع مع نسبة ضغط أفضل قليلًا من **LEVEL1**.
- [**LEVEL3**](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/compressionlevel/): يوفر ضغطًا أفضل من **LEVEL2** مع تأثير متوسط على زمن المعالجة.
- [**LEVEL4**](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/compressionlevel/): يوفر ضغطًا أفضل من **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/compressionlevel/): يحسن الضغط عن **LEVEL4** مع زمن معالجة إضافي.
- [**LEVEL6**](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/compressionlevel/): ضغط قياسي يقدم توازنًا جيدًا بين سرعة المعالجة وحجم الملف. هذا هو *مستوى الضغط الافتراضي*.
- [**LEVEL7**](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/compressionlevel/): يوفر ضغطًا أفضل من **LEVEL6** مع معالجة أبطأ.
- [**LEVEL8**](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/compressionlevel/): يوفر ضغطًا أفضل من **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/compressionlevel/): أقصى ضغط. ينتج أصغر حجم ملف على حساب أطول زمن معالجة.

يوضح المثال التالي كيفية حفظ عرض تقديمي كملف PPTX *بدون ضغط*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

هذا المثال يوضح كيفية حفظ عرض تقديمي كملف PPTX *بأقصى ضغط*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

تتحكم خاصية [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) في توليد الصورة المصغرة عند حفظ العرض التقديمي بصيغة PPTX:

- إذا تم ضبطها على `True`، يتم تحديث الصورة المصغرة أثناء الحفظ. هذا هو الإعداد الافتراضي.
- إذا تم ضبطها على `False`، تُحافظ على الصورة المصغرة الحالية. إذا لم يحتوي العرض التقديمي على صورة مصغرة، فلن يتم توليد أي صورة.

في الكود أدناه، يُحفظ العرض التقديمي بصيغة PPTX دون تحديث صورته المصغرة.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="معلومات" color="info" %}}
هذا الخيار يساعد على تقليل الوقت اللازم لحفظ العرض التقديمي بصيغة PPTX.
{{% /alert %}}

{{% alert title="معلومات" color="info" %}}
قامت Aspose بتطوير تطبيق مجاني لتقسيم ملفات PowerPoint [[free PowerPoint Splitter app]](https://products.aspose.app/slides/ar/splitter) باستخدام واجهتها البرمجية الخاصة. يتيح التطبيق تقسيم عرض تقديمي إلى ملفات متعددة عن طريق حفظ الشرائح المحددة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يتم دعم "الحفظ السريع" (الحفظ التزايدي) بحيث تُكتب التغييرات فقط؟**

لا. يُنشئ الحفظ ملف الهدف الكامل في كل مرة؛ لا يُدعم الحفظ التزايدي "السريع".

**هل من الآمن من حيث الخيوط (thread‑safe) حفظ نفس كائن Presentation من خيوط متعددة؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) **ليس thread‑safe**؛ احفظه من خيط واحد فقط.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**

يتم الحفاظ على [الروابط التشعبية](/slides/ar/python-net/manage-hyperlinks/). الملفات المرتبطة خارجيًا (مثل الفيديوهات عبر مسارات نسبية) لا تُنسخ تلقائيًا—تأكد من أن المسارات المشار إليها ما زالت قابلة للوصول.

**هل يمكنني ضبط/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. تُدعم خصائص المستند القياسية [/slides/ar/python-net/presentation-properties/] وسيتم كتابتها إلى الملف عند الحفظ.