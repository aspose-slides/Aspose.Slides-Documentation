---
title: حفظ العروض التقديمية في بايثون
linktitle: حفظ العروض التقديمية
type: docs
weight: 80
url: /ar/python-net/save-presentation/
keywords:
- حفظ PowerPoint
- حفظ OpenDocument
- حفظ عرض تقديمي
- حفظ شريحة
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
description: "اكتشف كيفية حفظ العروض التقديمية في بايثون باستخدام Aspose.Slides—التصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والتأثيرات."
---

## **نظرة عامة**

[فتح عرض تقديمي باستخدام بايثون](/slides/ar/python-net/open-presentation/) يوضح كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لفتح عرض تقديمي. يشرح هذا المقال كيفية إنشاء العروض التقديمية وحفظها. فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) تحتوي على محتويات العرض. سواءً كنت تنشئ عرضًا تقديميًا من الصفر أو تعدّل عرضًا موجودًا، ستحتاج إلى حفظه بعد الانتهاء. باستخدام Aspose.Slides for Python، يمكنك الحفظ إلى **ملف** أو **تدفق**. يوضح هذا المقال الطرق المختلفة لحفظ العرض التقديمي.

## **حفظ العروض التقديمية إلى ملفات**

احفظ عرضًا تقديميًا إلى ملف عن طريق استدعاء طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). مرّر اسم الملف وتنسيق الحفظ إلى الطريقة. يوضح المثال التالي كيفية حفظ عرض تقديمي باستخدام Aspose.Slides for Python.
```py
import aspose.slides as slides

# إنشاء كائن فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:
    
    # قم ببعض العمل هنا...

    # حفظ العرض التقديمي إلى ملف.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **حفظ العروض التقديمية إلى تدفقات**

يمكنك حفظ عرض تقديمي إلى تدفق بتمرير تدفق إخراج إلى طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). يمكن كتابة العرض إلى أنواع متعددة من التدفقات. في المثال أدناه، نقوم بإنشاء عرض جديد، نضيف نصًا إلى شكل، ونحفظه إلى تدفق.
```py
import aspose.slides as slides

# إنشاء كائن فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # حفظ العرض التقديمي إلى التدفق.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```


## **حفظ العروض التقديمية بنوع عرض مسبق التعريف**

يتيح Aspose.Slides for Python تحديد العرض الأولي الذي يستخدمه PowerPoint عند فتح العرض الذي تم إنشاؤه عبر فئة [ViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/). اضبط خاصية `last_view` على قيمة من تعداد [ViewType](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/).
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```


## **حفظ العروض التقديمية بتنسيق Strict Office Open XML**

يتيح Aspose.Slides حفظ العرض بتنسيق Strict Office Open XML. استخدم فئة [PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) واضبط خاصية `conformance` عند الحفظ. إذا ضبطت `Conformance.ISO_29500_2008_STRICT`، يتم حفظ ملف الإخراج بتنسيق Strict Office Open XML.

يوضح المثال أدناه إنشاء عرض وحفظه بتنسيق Strict Office Open XML.
```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# إنشاء كائن فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation() as presentation:
    # حفظ العرض التقديمي بتنسيق Strict Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```


## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدودًا قدرها 4 GB (2^32 بايت) على الحجم غير المضغوط لأي ملف، وحجم أي ملف مضغوط، وإجمالي حجم الأرشيف، كما يحد عدد الملفات إلى 65 535 (2^16‑1). تمديدات تنسيق ZIP64 ترفع هذه الحدود إلى 2^64.

خاصية [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) تسمح لك باختيار متى تستخدم امتدادات تنسيق ZIP64 عند حفظ ملف Office Open XML.

توفر هذه الخاصية الأوضاع التالية:

- `IF_NECESSARY` يستخدم امتدادات ZIP64 فقط إذا تجاوز العرض الحدود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- `NEVER` لا يستخدم امتدادات ZIP64 أبداً.
- `ALWAYS` يستخدم امتدادات ZIP64 دائماً.

يعرض الكود التالي كيفية حفظ عرض تقديمي كملف PPTX مع تمكين امتدادات ZIP64:
```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```


{{% alert title="NOTE" color="warning" %}}
عند الحفظ باستخدام `Zip64Mode.NEVER`، يتم طرح استثناء [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) إذا تعذر حفظ العرض بتنسيق ZIP32.
{{% /alert %}}

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

خاصية [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) تتحكم في توليد الصورة المصغرة عند حفظ العرض إلى PPTX:

- إذا تم ضبطها على `True`، تُحدث الصورة المصغرة أثناء الحفظ. هذا هو الوضع الافتراضي.
- إذا تم ضبطها على `False`، تُحفظ الصورة المصغرة الحالية. إذا لم يكن للعرض صورة مصغرة، لن يتم إنشاء أي واحدة.

في الكود أدناه، يتم حفظ العرض إلى PPTX دون تحديث صورته المصغرة.
```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```


{{% alert title="Info" color="info" %}}
هذا الخيار يساعد في تقليل الوقت المطلوب لحفظ العرض بتنسيق PPTX.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
قامت Aspose بتطوير تطبيق مجاني لتقسيم ملفات PowerPoint [Free PowerPoint Splitter app](https://products.aspose.app/slides/splitter) باستخدام واجهة برمجة التطبيقات الخاصة بها. يتيح لك التطبيق تقسيم عرض تقديمي إلى ملفات متعددة عن طريق حفظ الشرائح المحددة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم “الحفظ السريع” (الحفظ التزايدي) بحيث تُكتب التغييرات فقط؟**

لا. كل عملية حفظ تُنشئ الملف الهدف بالكامل؛ لا يُدعم الحفظ التزايدي “السريع”.

**هل من الآمن حفظ نفس كائن Presentation من عدة خيوط تشغيلية؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) غير آمن للاستخدام المتعدد الخيوط؛ احفظه من خيط واحد فقط.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**

يتم الحفاظ على [الروابط التشعبية](/slides/ar/python-net/manage-hyperlinks/). الملفات المرتبطة خارجيًا (مثل الفيديوهات عبر مسارات نسبية) لا تُنسخ تلقائيًا—تأكد من أن المسارات المرجعية لا تزال متاحة.

**هل يمكنني ضبط/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. تُدعم خصائص المستند القياسية [/slides/python-net/presentation-properties/] ويمكن حفظها في الملف عند الحفظ.