---
title: تحديد صيغة العرض التقديمي الأصلية في Python
linktitle: صيغة المصدر
type: docs
weight: 35
url: /ar/python-net/detect-presentation-source-format/
keywords:
- صيغة المصدر
- اكتشاف صيغة العرض التقديمي
- PowerPoint
- OpenDocument
- عرض تقديمي
- PPT
- PPTX
- Python
- Aspose.Slides
description: "قراءة الصيغة الأصلية لعرض تقديمي تم تحميله في Python باستخدام Aspose.Slides for Python via .NET، مقارنة واجهات كشف الصيغ، ومعالجة الملفات، التدفقات، والصيغ القديمة."
---
## **نظرة عامة**

بعد تحميل عرض تقديمي، اقرأ الخاصية للقراءة فقط [Presentation.source_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/source_format/) لتحديد صيغته الأصلية. استخدمها عندما تعتمد المعالجة اللاحقة على الصيغة التي تم تحميل الكائن الحالي منها.

صيغة المصدر تختلف عن [SaveFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveformat/) المختارة لملف الإخراج. الحفظ إلى صيغة أخرى لا يغير صيغة المصدر للكائن الموجود.

## **قراءة صيغة المصدر لملف**

هذا المثال يتطلب وجود ملف `sample.pptx`. يقوم بتحميل الملف ويختار سياسة معالجة التطبيق باستخدام [Presentation.source_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/source_format/)، بدلاً من اسم الملف. غيّر مسار الإدخال لتجربة صيغ أخرى. المثال يطبع السياسة المختارة؛ استبدل الرسائل بمنطق التطبيق الخاص بك.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **التعرف على القيم المدعومة**

تُميز تعداد [SourceFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sourceformat/) الصيغ التالية للعرض التقديمي. الامتدادات أدناه هي امتدادات تقليدية، ليست إعادة إنشاء لاسم الملف الأصلي.

| قيمة SourceFormat | الامتداد | الصيغة |
| --- | --- | --- |
| `PPT` | `.ppt` | عرض PowerPoint 97–2003 |
| `PPTX` | `.pptx` | عرض Office Open XML |
| `PPTM` | `.pptm` | عرض Office Open XML مع تمكين الماكرو |
| `PPS` | `.pps` | عرض شرائح PowerPoint 97–2003 |
| `PPSX` | `.ppsx` | عرض شرائح Office Open XML |
| `PPSM` | `.ppsm` | عرض شرائح Office Open XML مع تمكين الماكرو |
| `POT` | `.pot` | قالب PowerPoint 97–2003 |
| `POTX` | `.potx` | قالب Office Open XML |
| `POTM` | `.potm` | قالب Office Open XML مع تمكين الماكرو |
| `ODP` | `.odp` | عرض OpenDocument |
| `OTP` | `.otp` | قالب عرض OpenDocument |
| `FODP` | `.fodp` | عرض OpenDocument XML مسطح |
| `XML` | `.xml` | عرض PowerPoint XML |

## **قراءة صيغة المصدر لتدفق**

هذا المثال يتطلب وجود ملف `sample.pps`. قراءة بايتاته إلى تدفق ذاكرة يحاكي إدخالًا يتم استلامه دون اسم ملف، مثل قيمة في قاعدة بيانات أو مصفوفة بايتات تم رفعها. يتلقى المُنشئ [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) فقط التدفق.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

تستخدم صيغ PPT و PPS و POT نفس الصيغة الثنائية الأساسية. عند التحميل عبر مسار ملف، يمكن للامتداد أن يساعد على تمييز عرض الشرائح أو القالب. بدون اسم ملف، قد يتم الإبلاغ عن محتوى PPS و POT القديم كـ `SourceFormat.PPT`؛ مثال PPS أعلاه يعلن `PPT`.

إذا كان تطبيقك يحتاج إلى الحفاظ على هذا التمييز، احتفظ باسم الملف الأصلي أو ببيانات التعريف الفرعية بشكل منفصل. الامتداد هو إشارة مفيدة لهذه الأنواع القديمة، لكنه لا يجب أن يكون الأساس الوحيد لتحديد محتوى عرض تقديمي عشوائي.

## **مقارنة الكشف قبل وبعد التحميل**

استخدم [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) و [PresentationInfo.load_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/load_format/) عندما تحتاج إلى فحص ملف قبل تحميل نموذج كائن العرض التقديمي الكامل. استخدم [Presentation.source_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/source_format/) عندما يكون الكائن موجودًا بالفعل.

هذا المثال يتطلب `sample.pptx` ويطبع `PPTX` لكلا الفحصين. في بيئة الإنتاج، اختر واجهة برمجة التطبيقات المناسبة لمرحلة المعالجة؛ العرض المسبق التحميل لا يحتاج إلى فحص ثانٍ فقط للحصول على صيغة المصدر.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

النتائج لها أنواع تعداد مختلفة: [LoadFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadformat/) و [SourceFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sourceformat/). لا تقارنهما بتحويل القيم الرقمية أو بافتراض أن كل صيغة لها نتائج كشف متماثلة. في فحص الحفظ وإعادة الفتح الموضح أدناه، تم الإبلاغ عن PowerPoint XML كـ `LoadFormat.UNKNOWN` قبل التحميل و `SourceFormat.XML` بعد التحميل.

## **الإبقاء على صيغ المصدر والإخراج منفصلة**

هذا المثال يتطلب `sample.pptx` ويكتب `converted.odp`. يطبع `PPTX` قبل وبعد حفظ الكائن الأصلي. فقط الكائن الجديد المحمّل من مخرجات ODP يعلن `ODP`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

العرض التقديمي الذي يتم إنشاؤه من الصفر باستخدام `slides.Presentation()` يعلن `SourceFormat.PPTX`. لا يمتلك ملف إدخال: هذا هو القيمة الافتراضية لكائن تم إنشاؤه حديثًا، وليس دليلًا على أنه تم تحميل ملف PPTX. تتبع ما إذا كان تطبيقك قد أنشأ أو حمّل الكائن بشكل منفصل إذا كان هذا التمييز مهمًا.

## **تحويل صيغة المصدر إلى امتداد**

المثال التالي يتطلب `sample.pptx`. يطابق كل قيمة [SourceFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sourceformat/) مدعومة حاليًا بامتداد تقليدي، دون تحليل اسم الملف المدخل. يضمن الاست fallback عدم إسناد امتداد صامت لقيمة غير معروفة.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

هذا التحويل لا يُحوّل ملفًا ولا يستعيد النوع الفرعي legacy PPS/POT الذي فقد أثناء تحميل التدفق. للحفظ الفعلي، اختر [SaveFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveformat/) صراحةً، أو استخدم التحويل الموضح في [Save Presentations in Their Original Format](/slides/ar/python-net/save-presentation/#save-presentations-in-their-original-format).

## **التحقق من الصيغ عن طريق الحفظ وإعادة الفتح**

هذا المثال المستقل يخلق عرضًا تقديميًا ويكتب ثلاثة ملفات في دليل العمل، مستبدلًا الملفات ذات الأسماء نفسها. يعيد فتح كل مخرج إما عبر المسار أو عبر تدفق ذاكرة. بالنسبة لـ PPTX و ODP، كلا المسارين يعلنان الصيغة المحفوظة. بالنسبة لـ PPS، التحميل عبر المسار يعلن `PPS`، بينما تحميل البايتات نفسها دون اسم ملف يعلن `PPT`.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

نفس الفحص مع جميع الصيغ المذكورة أعلاه أنتج هذه النتائج للعروض التقديمية التي تم إنشاؤها بامتدادات مطابقة:

| الصيغة المحفوظة | SourceFormat من مسار الملف | SourceFormat من تدفق بلا اسم |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` على التوالي | نفس مسار الملف |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` على التوالي | نفس مسار الملف |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` على التوالي | نفس مسار الملف |
| ODP, OTP | `ODP`, `OTP` على التوالي | نفس مسار الملف |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

في هذه الفحوصات، كان التوحيد الوحيد لصيغة المصدر هو تحويل PPS/POT إلى `PPT` للتدفقات بلا اسم. الجدول يصف طريقة التعرف على الصيغة، وليس الحفاظ على كل ميزات العرض أثناء التحويل.

## **الأسئلة الشائعة**

**هل تغيير حفظ إلى ODP صيغة المصدر لعرض تم تحميله من PPTX؟**

لا. الكائن الموجود لا يزال يعلن `PPTX`. الكائن المحمّل من ملف ODP المحفوظ يعلن `ODP`.

**هل يمكن للتدفق دائمًا تمييز عرض تقديمي قديم، عرض شرائح، أو قالب؟**

لا. صيغ PPT و PPS و POT تشترك في الصيغة الثنائية. احتفظ باسم الملف أو ببيانات التعريف الفرعية بشكل منفصل عندما يكون هذا التمييز مطلوبًا.

**أي واجهة برمجة تطبيقات يجب استخدامها إذا كان العرض مُحمَّلاً بالفعل؟**

اقرأ [Presentation.source_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/source_format/). استخدم [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) للفحص قبل التحميل.