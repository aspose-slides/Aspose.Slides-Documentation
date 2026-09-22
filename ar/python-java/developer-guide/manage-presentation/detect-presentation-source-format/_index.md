---
title: تحديد تنسيق العرض التقديمي الأصلي في Python عبر Java
linktitle: تنسيق المصدر
type: docs
weight: 35
url: /ar/python-java/detect-presentation-source-format/
keywords:
- تنسيق المصدر
- اكتشاف تنسيق العرض
- PowerPoint
- OpenDocument
- عرض تقديمي
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "قراءة التنسيق الأصلي للعرض التقديمي المحمَّل في Python عبر Java باستخدام Aspose.Slides للغة Python عبر Java، مقارنة واجهات الكشف، والتعامل مع الملفات، التدفقات، والتنسيقات القديمة."
---
## **نظرة عامة**

بعد تحميل عرض تقديمي، استدعِ طريقة [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSourceFormat) لتحديد تنسيقه الأصلي. استخدمها عندما يعتمد المعالجة اللاحقة على التنسيق الذي تم تحميل النسخة الحالية منه.

تنسيق المصدر يختلف عن [SaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/) المحدد لملف الإخراج. حفظ العرض إلى تنسيق آخر لا يغيّر تنسيق المصدر للنسخة الموجودة.

الأمثلة تتطلب Aspose.Slides للغة Python عبر Java وبيئة تشغيل Java متوافقة. يبدأ كل مثال تشغيل JVM إذا لم يكن قيد التشغيل بالفعل.

## **قراءة تنسيق المصدر لملف**

يتطلب هذا المثال ملف `sample.pptx` موجود. يقوم بتحميل الملف ويختار سياسة معالجة التطبيق باستخدام [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSourceFormat)، بدلاً من اسم الملف. غيّر مسار الإدخال لتجربة تنسيقات أخرى. يطبع المثال السياسة المختارة؛ استبدل الرسائل بمنطق تطبيقك.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **التعرف على القيم المدعومة**

تعرف الفئة [SourceFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sourceformat/) ثوابت عددية تميّز التنسيقات التالية للعرض التقديمي. الامتدادات أدناه هي امتدادات تقليدية، ليست إعادًة بناءً لاسم الملف الأصلي.

| قيمة SourceFormat | الامتداد | التنسيق |
| --- | --- | --- |
| `Ppt` | `.ppt` | عرض PowerPoint 97–2003 |
| `Pptx` | `.pptx` | عرض Office Open XML |
| `Pptm` | `.pptm` | عرض Office Open XML ممكّن للماكرو |
| `Pps` | `.pps` | عرض شريحة PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | عرض شريحة Office Open XML |
| `Ppsm` | `.ppsm` | عرض شريحة Office Open XML ممكّن للماكرو |
| `Pot` | `.pot` | قالب PowerPoint 97–2003 |
| `Potx` | `.potx` | قالب Office Open XML |
| `Potm` | `.potm` | قالب Office Open XML ممكّن للماكرو |
| `Odp` | `.odp` | عرض OpenDocument |
| `Otp` | `.otp` | قالب OpenDocument |
| `Fodp` | `.fodp` | عرض OpenDocument XML مسطح |
| `Xml` | `.xml` | عرض PowerPoint XML |

## **قراءة تنسيق المصدر لتدفق بيانات**

يتطلب هذا المثال ملف `sample.pps` موجود. يقرأ بايتاته في تدفق الذاكرة لنمذجة الإدخال المستلم دون اسم ملف، مثل قيمة قاعدة بيانات أو مصفوفة بايتات تم تحميلها. يتلقى المُنشئ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التدفق فقط. يقرأ Python بايتات الملف، ويحوّلها JPype إلى مصفوفة بايتات Java لتدفق الذاكرة Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

تستخدم PPT و PPS و POT نفس التنسيق الثنائي الأساسي. عند التحميل عبر مسار ملف، يمكن للامتداد المساعدة في تمييز عرض الشرائح أو القالب. بدون اسم ملف، قد يتم الإبلاغ عن محتوى PPS و POT القديم كـ `SourceFormat.Ppt`؛ المثال PPS أعلاه يطبع القيمة العددية لـ `SourceFormat.Ppt`.

إذا كان تطبيقك بحاجة للحفاظ على هذا الفرق، احتفظ باسم الملف الأصلي أو بيانات التعريف الفرعية بشكل منفصل. الامتداد هو تلميح مفيد لهذه الأنواع القديمة، لكن لا ينبغي أن يكون الأساس الوحيد لتحديد محتوى عرض تقديمي عشوائي.

## **مقارنة الكشف قبل وبعد التحميل**

استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationfactory/#getPresentationInfo) و[PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#getLoadFormat) عندما تحتاج إلى فحص ملف قبل تحميل نموذج كائن العرض التقديمي بالكامل. استخدم [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSourceFormat) عندما تكون النسخة موجودة بالفعل.

يتطلب هذا المثال `sample.pptx` ويطبع القيم العددية لـ `LoadFormat.Pptx` و`SourceFormat.Pptx` على التوالي. في الإنتاج، اختر الـ API المناسب لمرحلة المعالجة؛ العرض التقديمي المحمّل مسبقًا لا يحتاج إلى فحص ثانٍ فقط للحصول على تنسيق المصدر.

```python
import jpile
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

تستخدم النتائج ثوابت من فئات مختلفة: [LoadFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadformat/) و[SourceFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sourceformat/). لا تقارن قيمها العددية ولا تفترض أن كل تنسيق يعطي نتائج كشف متطابقة. قد يُبلّغ عن PowerPoint XML كـ `LoadFormat.Unknown` قبل التحميل و`SourceFormat.Xml` بعد التحميل.

## **الحفاظ على تنسيقات المصدر والإخراج منفصلة**

يتطلب هذا المثال `sample.pptx` ويكتب `converted.odp`. يطبع القيمة العددية لـ `SourceFormat.Pptx` قبل وبعد حفظ النسخة الأصلية. فقط النسخة الجديدة المحمّلة من ملف ODP الناتج تُبلّغ عن `Odp`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

العرض التقديمي الذي يُنشئ من الصفر باستخدام `Presentation()` يُبلّغ عن `SourceFormat.Pptx`. لا يمتلك ملف إدخال: هذه هي القيمة الافتراضية لنسخة تم إنشاؤها حديثًا، وليست دليلًا على تحميل ملف PPTX. تتبع ما إذا كان تطبيقك قد أنشأ أو حمّل النسخة بشكل منفصل إذا كان هذا الفارق مهمًا.

## **ربط تنسيق المصدر بامتداد**

يتطلب المثال التالي `sample.pptx`. يربط كل قيمة حالية مدعومة من [SourceFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sourceformat/) بامتداد تقليدي، دون تحليل اسم الملف المدخل. يتجنب الإرجاع الضمني تعيين امتداد صامت لقيمة غير معروفة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

هذا الربط لا يحوّل ملفًا ولا يستعيد نوع PPS/POT القديم الذي فقد أثناء تحميل التدفق. للحفظ الفعلي، حدد [SaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/) صراحةً، أو استخدم التحويل الموضح في [Save Presentations in Their Original Format](/slides/ar/python-java/save-presentation/#save-presentations-in-their-original-format).

## **التحقق من التنسيقات عبر الحفظ وإعادة الفتح**

هذا المثال المستقل يُنشئ عرضًا تقديميًا ويكتب ثلاثة ملفات في دليل العمل، مستبدلاً الملفات ذات الأسماء نفسها. يعيد فتح كل مخرجات إما عبر المسار أو من خلال تدفق الذاكرة. بالنسبة إلى PPTX و ODP، كلا المسارين يُبلّغان عن التنسيق المحفوظ. بالنسبة إلى PPS، يُبلّغ التحميل عبر المسار عن `Pps`، بينما يُبلّغ تحميل نفس البايتات بدون اسم ملف عن `Ppt`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

الجدول التالي يلخّص تحديد تنسيق المصدر للعرض التقديمي مع امتدادات مطابقة. الأسماء تشير إلى الثوابت؛ الأمثلة في Python تطبع القيم العددية لها:

| تنسيق الحفظ | SourceFormat من مسار ملف | SourceFormat من تدفق بدون اسم |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` على التوالي | نفس قيمة مسار الملف |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` على التوالي | نفس قيمة مسار الملف |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` على التوالي | نفس قيمة مسار الملف |
| ODP, OTP | `Odp`, `Otp` على التوالي | نفس قيمة مسار الملف |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

محتوى PPS/POT يُعرف كـ `Ppt` للتدفقات بدون اسم ملف. يصف الجدول تحديد التنسيق، لا حفظ كل ميزات العرض أثناء التحويل.

## **الأسئلة المتكررة**

**هل حفظ العرض إلى ODP يغيّر تنسيق المصدر للعرض المحمّل من PPTX؟**

لا. لا يزال النسخة الحالية تُبلّغ عن `Pptx`. النسخة التي تُحمَّل من ملف ODP المحفوظ تُبلّغ عن `Odp`.

**هل يمكن للتدفق دائمًا تمييز عرض تقديمي قديم، أو عرض شريحة، أو قالب؟**

لا. تشترك PPT و PPS و POT في نفس التنسيق الثنائي. احتفظ باسم الملف أو بيانات التعريف الفرعية بشكل منفصل عندما يكون هذا الفارق مطلوبًا.

**أي API يجب أن أستخدمه إذا كان العرض التقديمي محمَّلاً بالفعل؟**

اقرأ [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSourceFormat). استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationfactory/#getPresentationInfo) للفحص قبل التحميل.