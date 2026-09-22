---
title: حفظ العروض التقديمية في بايثون
linktitle: حفظ العرض
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
- العرض التقديمي إلى ملف
- العرض التقديمي إلى تدفق
- نوع عرض محدد مسبقًا
- تنسيق Office Open XML الصارم
- وضع Zip64
- تحديث الصورة المصغرة
- حفظ التقدم
- Python
- Aspose.Slides
description: "حفظ عروض PowerPoint و OpenDocument إلى ملفات أو تدفقات في بايثون باستخدام Aspose.Slides، وتكوين خيارات إخراج PPTX."
---
## **نظرة عامة**

بعد أن تنشئ عرضًا تقديميًا أو [فتح أحد العروض الموجودة](/slides/ar/python-net/open-presentation/)، استخدم طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ipresentation/save/) لكتابة النتيجة. يمكن لـ Aspose.Slides for Python عبر .NET حفظ عرض تقديمي إلى ملف أو تدفق بصيغ PowerPoint و OpenDocument و PDF وغيرها. الأقسام التالية تغطي عمليات الحفظ القياسية والخيارات المتاحة لإخراج PPTX.

## **حفظ العروض التقديمية إلى ملفات**

لحفظ عرض تقديمي إلى ملف، مرّر مسار الإخراج وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveformat/) إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ipresentation/save/). تحدد قيمة التنسيق نوع الملف الذي ينشئه Aspose.Slides.

المثال التالي ينشئ عرضًا تقديميًا ويحفظه كملف PPTX:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # إضافة أو تعديل محتوى العرض التقديمي هنا.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **حفظ العروض التقديمية بصيغتها الأصلية**

لأمثلة كشف الملف والتدفق، وسلوك العروض المُنشأة حديثًا، والتمييز بين صيغ المصدر والإخراج، راجع [Determine the Original Presentation Format](/slides/ar/python-net/detect-presentation-source-format/).

في تطبيق معالجة دفعية، قد لا يُعرف تنسيق الإدخال مسبقًا. بعد تحميل ملف، اقرأ صيغته الأصلية من خاصية [Presentation.source_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/source_format/). مرّر قيمة [SourceFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sourceformat/) الناتجة إلى [SlideUtil.to_save_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/slideutil/to_save_format/) للحصول على قيمة [SaveFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveformat/) المقابلة، ثم استخدم [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ipresentation/save/) لكتابة العرض المعدل.

المثال الكامل التالي يعالج كل ملف في دليل الإدخال، يحدث عنوانه، ويحفظه إلى دليل الإخراج بالصيغ التي تم تحميله بها:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/slideutil/to_save_format/) يربط صيغ PPT و PPTX و ODP و PPTM و PPSX و PPSM و POTX و POTM و PPS و POT و OTP و FODP و PowerPoint XML بصيغ الحفظ المقابلة. يربط صيغ مصدر العرض فقط؛ لا يُقصد به اختيار صيغ التصدير مثل PDF أو HTML أو TIFF أو الصور. تمرير قيمة [SourceFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sourceformat/) غير مدعومة أو غير صالحة يرفع استثناء.

ملفات PPT و PPS و POT القديمة تستخدم نفس الحاوية الثنائية. عندما يُحمَّل عرض من تدفق بدون امتداد ملف، قد يُحدد ملف PPS أو POT كـ PPT. إذا كان من الضروري الحفاظ على هذه الأنواع الفرعية القديمة، احتفظ باسم الملف الأصلي أو بيانات التعريف الخاصة بالتنسيق بشكل منفصل واستخدمها عند اختيار اسم ملف الإخراج وتنسيقه.

## **حفظ العروض التقديمية إلى تدفقات**

للكتابة إلى عرض تقديمي دون الاعتماد على مسار ملف نهائي، مرّر تدفقًا قابلًا للكتابة من نوع [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveformat/) إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ipresentation/save/). هذا الأسلوب مفيد عندما يجب إرجاع الإخراج من خدمة ويب، أو تخزينه في قاعدة بيانات، أو معالجته في الذاكرة.

المثال التالي يحفظ عرضًا تقديميًا جديدًا إلى تدفق ملف:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **حفظ العروض التقديمية بنوع عرض محدد مسبقًا**

يمكنك تحديد العرض الذي يفتح به PowerPoint العرض المحفوظ أولًا. اضبط خاصية [ViewProperties.last_view](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/last_view/) إلى قيمة [ViewType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewtype/) قبل الحفظ.

المثال التالي يضبط عرض Slide Master كالعرض الأولي:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **حفظ العروض التقديمية بالتنسيق الصارم لـ Office Open XML**

لإنشاء ملف PPTX يتوافق مع ملف تعريف Strict لـ Office Open XML، أنشئ كائنًا من [PptxOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/pptxoptions/) واضبط خاصية [conformance](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/pptxoptions/conformance/) إلى `Conformance.ISO_29500_2008_STRICT`. ثم مرّر الخيارات إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ipresentation/save/).

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**

حدود أرشيف ZIP القياسي تحصر حجم كل إدخال مضغوط وغير مضغوط، وحجم الأرشيف الكلي، وعدد الإدخالات. لأن ملف PPTX هو أرشيف ZIP، قد يتجاوز العرض الضخم تلك الحدود. امتدادات ZIP64 ترفع الحدود المطبقة لحجم الإدخال وعدد الإدخالات.

استخدم خاصية [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) للتحكم فيما إذا كان Aspose.Slides يكتب امتدادات ZIP64:

- `IF_NECESSARY` يستخدم ZIP64 فقط عندما يتجاوز العرض حدود ZIP القياسية. هذا هو الوضع الافتراضي.
- `NEVER` يعطل امتدادات ZIP64.
- `ALWAYS` يكتب دائمًا امتدادات ZIP64.

المثال التالي يفعّل دائمًا امتدادات ZIP64 للعرض الناتج:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
إذا تم استخدام `Zip64Mode.NEVER` ولا يمكن للعرض أن يتناسب مع حدود ZIP القياسية، فإن عملية الحفظ تُثير استثناء [PptxException](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pptxexception/).
{{% /alert %}}

## **حفظ العروض التقديمية بتنسيق Office Open XML مع مستويات الضغط**

لإخراج PPTX، يمكنك موازنة سرعة الحفظ ضد حجم الملف بضبط خاصية [PptxOptions.compression_level](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/pptxoptions/compression_level/). توفر تعداد [CompressionLevel](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/compressionlevel/) القيم التالية:

- `NONE` يخزن البيانات بدون ضغط.
- `LEVEL1` يقدم أسرع ضغط وأكبر حجم للملف المضغوط.
- `LEVEL2` إلى `LEVEL5` تفضّل تدريجيًا حجمًا أصغر على سرعة الحفظ.
- `LEVEL6` يوازن بين سرعة الحفظ وحجم الملف. وهذا هو المستوى الافتراضي.
- `LEVEL7` و `LEVEL8` يفضّلان حجمًا أصغر أكثر على سرعة الحفظ.
- `LEVEL9` يوفر أقوى ضغط ويتطلب أكبر وقت معالجة.

المثال التالي يحفظ عرضًا تقديميًا بدون ضغط:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

المثال التالي يستخدم أقصى مستوى ضغط:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

عند حفظ عرض تقديمي كـ PPTX، تتحكم خاصية [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) في صورة المستند المصغرة:

- `True` يعيد إنشاء الصورة المصغرة أثناء عملية الحفظ. وهذه هي القيمة الافتراضية.
- `False` يحافظ على الصورة المصغرة الحالية. إذا لم يكن للعرض صورة مصغرة، فإن Aspose.Slides لا يولد واحدة.

المثال التالي يحفظ عرضًا تقديميًا دون تحديث صورته المصغرة:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
تعطيل تحديث الصورة المصغرة يمكن أن يقلل الوقت المطلوب لحفظ ملف PPTX.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
توفر Aspose أداة مجانية [PowerPoint Splitter](https://products.aspose.app/slides/ar/splitter) تم بناؤها باستخدام Aspose.Slides API. تقوم بحفظ الشرائح المحددة من عرض تقديمي كملفات PPT أو PPTX منفصلة.
{{% /alert %}}

## **FAQ**

**هل يدعم Aspose.Slides الحفظ المتزايد أو “الحفظ السريع”?**

لا. كل عملية حفظ تكتب ملفًا نهائيًا مكتملًا بدلاً من تحديث الأجزاء التي تغيرت فقط.

**هل يمكن لعدة خيوط حفظ نفس كائن Presentation؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) غير آمن للاستخدام المتعدد الخيوط. يجب الوصول إلى كل كائن وحفظه من خيط واحد في كل مرة.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند حفظ العرض التقديمي؟**

تظل [Hyperlinks](/slides/ar/python-net/manage-hyperlinks/) في العرض. لا تقوم Aspose.Slides بنسخ الملفات المرتبطة خارجيًا، لذا يجب أن يتمكن العرض المحفوظ من الوصول إلى مواقعها.

**هل يمكنني حفظ بيانات تعريف المستند مثل المؤلف، العنوان، الشركة، وتاريخ الإنشاء؟**

نعم. اضبط [document properties](/slides/ar/python-net/presentation-properties/) المناسبة قبل الحفظ، وستكتبها Aspose.Slides إلى ملف الإخراج.