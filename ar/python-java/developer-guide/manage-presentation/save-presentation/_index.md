---
title: حفظ العروض التقديمية في بايثون عبر جافا
linktitle: حفظ العرض
type: docs
weight: 80
url: /ar/python-java/save-presentation/
keywords:
- حفظ PowerPoint
- حفظ OpenDocument
- حفظ العرض التقديمي
- حفظ الشريحة
- حفظ PPT
- حفظ PPTX
- حفظ ODP
- العرض إلى ملف
- العرض إلى تدفق
- نوع عرض محدد مسبقًا
- تنسيق Office Open XML الصارم
- وضع Zip64
- تحديث الصورة المصغرة
- تقدم الحفظ
- بايثون
- جافا
- Aspose.Slides
description: "حفظ عروض PowerPoint و OpenDocument إلى ملفات أو تدفقات في بايثون عبر جافا باستخدام Aspose.Slides، وتكوين إخراج PPTX والإبلاغ عن التقدم."
---
## **نظرة عامة**

بعد أن تقوم بإنشاء عرض تقديمي أو [فتح عرض موجود](/slides/ar/python-java/open-presentation/)، استخدم طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) لكتابة النتيجة. يمكن لـ Aspose.Slides للـ Python عبر Java حفظ العرض التقديمي إلى ملف أو تدفق في صيغ PowerPoint و OpenDocument و PDF وغيرها. الأقسام التالية تغطي عمليات الحفظ القياسية والخيارات المتاحة لإخراج PPTX.

## **حفظ العروض التقديمية إلى ملفات**

لحفظ عرض تقديمي إلى ملف، مرّر مسار الإخراج وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/) إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save). تحدد قيمة التنسيق نوع الملف الذي تنشئه Aspose.Slides.

المثال التالي ينشئ عرضاً تقديمياً ويحفظه كملف PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # إضافة أو تعديل محتوى العرض التقديمي هنا.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **حفظ العروض التقديمية بصيغتها الأصلية**

في تطبيق معالجة دفعات، قد لا يكون تنسيق الإدخال معروفًا مسبقًا. بعد تحميل ملف، اقرأ تنسيقه الأصلي من طريقة [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSourceFormat). مرّر قيمة [SourceFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sourceformat/) الناتجة إلى [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideutil/#toSaveFormat) للحصول على قيمة [SaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/) المقابلة، ثم استخدم [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) لكتابة العرض المعدل.

المثال الكامل التالي يعالج كل ملف في دليل الإدخال، يحدّث عنوانه، ويحفظه إلى دليل الإخراج بالتنسيق الذي تم تحميله منه:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideutil/#toSaveFormat) يطابق صيغ PPT و PPTX و ODP و PPTM و PPSX و PPSM و POTX و POTM و PPS و POT و OTP و FODP و XML PowerPoint إلى صيغ الحفظ المقابلة لها. يطابق صيغ المصدر للعرض فقط؛ ولا يُقصد به اختيار صيغ التصدير مثل PDF أو HTML أو TIFF أو الصور. تمرير قيمة [SourceFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sourceformat/) غير مدعومة أو غير صالحة يؤدي إلى حدوث [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

تستخدم ملفات PPT و PPS و POT القديمة نفس الحاوية الثنائية. عندما يتم تحميل مثل هذا العرض من تدفق بدون امتداد ملف، قد يتم التعرف على ملف PPS أو POT على أنه PPT. إذا كان من الضروري الحفاظ على هذه الأنواع الفرعية القديمة، احتفظ باسم الملف الأصلي أو بيانات التنسيق الوصفية بشكل منفصل واستخدمها عند اختيار اسم ملف الإخراج وتنسيقه.

## **حفظ العروض التقديمية إلى تدفقات**

للكتابة إلى عرض تقديمي دون الاعتماد على مسار ملف نهائي، مرّر تدفقًا قابلًا للكتابة وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/) إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save). هذا الأسلوب مفيد عندما يجب إرجاع النتيجة من خدمة ويب، أو تخزينها في قاعدة بيانات، أو معالجتها في الذاكرة.

المثال التالي يحفظ عرضًا تقديميًا جديدًا إلى تدفق ملف:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **حفظ العروض التقديمية بنوع عرض محدد مسبقًا**

يمكنك تحديد طريقة العرض التي يفتح بها PowerPoint العرض المحفوظ في البداية. استخدم طريقة [ViewProperties.setLastView](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#setLastView) مع قيمة [ViewType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewtype/) قبل الحفظ.

المثال التالي يكوّن عرض شريحة الرئيس كالعرض الأولي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **حفظ العروض التقديمية بتنسيق Office Open XML الصارم**

لإنشاء ملف PPTX يتوافق مع ملف التعريف الصارم لـ Office Open XML، أنشئ مثيلًا من [PptxOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxoptions/) واستخدم طريقة [setConformance](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxoptions/#setConformance) معه مع [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ar/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). ثم مرّر الخيارات إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**

يحدّ أرشيف ZIP القياسي الحجم المضغوط وغير المضغوط لكل إدخال، وحجم الأرشيف الكلي، وعدد الإدخالات. نظرًا لأن ملف PPTX هو أرشيف ZIP، قد يتجاوز عرض تقديمي كبير جدًا هذه الحدود. تمديدات ZIP64 ترفع الحدود المطبقة على الحجم وعدد الإدخالات.

استخدم طريقة [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxoptions/#setZip64Mode) للتحكم فيما إذا كانت Aspose.Slides تكتب امتدادات ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zip64mode/#IfNecessary) يستخدم ZIP64 فقط عندما يتجاوز العرض حدود ZIP القياسية. هذا هو الوضع الافتراضي.
- [Never](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zip64mode/#Never) يعرّض امتدادات ZIP64.
- [Always](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zip64mode/#Always) يكتب دائمًا امتدادات ZIP64.

المثال التالي يمكّن دائمًا امتدادات ZIP64 لعرض الإخراج:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="تحذير" %}}
إذا تم استخدام [Zip64Mode.Never](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zip64mode/#Never) ولا يمكن للعرض التقديمي أن يتناسب مع حدود ZIP القياسية، فإن عملية الحفظ تُثير استثناءً من نوع [PptxException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **حفظ العروض التقديمية بتنسيق Office Open XML مع مستويات الضغط**

لإخراج PPTX، يمكنك موازنة سرعة الحفظ بحجم الملف باستخدام طريقة [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxoptions/#setCompressionLevel). توفر الفئة [CompressionLevel](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/) القيم التالية:

- [None](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#None) يخزن البيانات بدون ضغط.
- [Level1](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#Level1) يوفر أسرع ضغط وأكبر حجم مضغوط للخرج.
- [Level2](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#Level2) إلى [Level5](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#Level5) يفضّلان تدريجيًا خفض حجم الخرج على سرعة الحفظ.
- [Level6](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#Level6) يوازن بين سرعة الحفظ وحجم الملف. هذا هو المستوى الافتراضي.
- [Level7](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#Level7) و [Level8](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#Level8) يفضّلان خفض حجم الخرج أكثر على حساب سرعة الحفظ.
- [Level9](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#Level9) يوفر أقوى ضغط ويتطلب أكبر زمن معالجة.

المثال التالي يحفظ عرضًا تقديميًا بدون ضغط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

المثال التالي يستخدم أعلى مستوى للضغط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

عند حفظ عرض تقديمي كـ PPTX، تتحكم طريقة [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) في الصورة المصغرة للمستند:

- `True` يعيد إنشاء الصورة المصغرة أثناء عملية الحفظ. هذه هي القيمة الافتراضية.
- `False` يحافظ على الصورة المصغرة الحالية. إذا لم يكن للعرض مصغرة، فإن Aspose.Slides لا يولد واحدة.

المثال التالي يحفظ عرضًا تقديميًا دون تحديث صورته المصغرة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="ملاحظة" %}}
تعطيل تحديث الصورة المصغرة يمكن أن يقلل الوقت المطلوب لحفظ ملف PPTX.
{{% /alert %}}

## **الإبلاغ عن تقدم الحفظ كنسبة مئوية**

لمراقبة عملية الحفظ، سجّل معالج تقدم بلغة Python عبر `jpype.JProxy` ومرره إلى طريقة [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveoptions/#setProgressCallback). ثم تستدعي Aspose.Slides طريقة `reporting` للمعالج مع قيم التقدم خلال التصدير.

المثال التالي يبلغ عن تقدم تصدير PDF إلى وحدة التحكم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="ملاحظة" %}}
توفر Aspose أداة مجانية [PowerPoint Splitter](https://products.aspose.app/slides/ar/splitter) مبنية على Aspose.Slides API. تقوم بحفظ الشرائح المختارة من عرض تقديمي كملفات PPT أو PPTX منفصلة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تدعم Aspose.Slides الحفظ المتدرج أو “الحفظ السريع”?**

لا. كل عملية حفظ تكتب ملف إخراج كامل بدلاً من تحديث الأجزاء المتغيّرة فقط.

**هل يمكن لعدة خيوط حفظ نفس كائن Presentation؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) [ليس آمناً للـ thread](/slides/ar/python-java/multithreading/). يجب الوصول إلى كل كائن وحفظه من خيط واحد فقط في كل مرة.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند حفظ عرض تقديمي؟**

تظل [Hyperlinks](/slides/ar/python-java/manage-hyperlinks/) داخل العرض. لا تقوم Aspose.Slides بنسخ الملفات المرتبطة خارجيًا، لذا يجب أن يكون للعرض المحفوظ القدرة على الوصول إلى مواقعها.

**هل يمكنني حفظ بيانات تعريف المستند مثل المؤلف، العنوان، الشركة، وتاريخ الإنشاء؟**

نعم. عيّن [document properties](/slides/ar/python-java/presentation-properties/) المناسبة قبل الحفظ، وستقوم Aspose.Slides بكتابتها إلى ملف الإخراج.