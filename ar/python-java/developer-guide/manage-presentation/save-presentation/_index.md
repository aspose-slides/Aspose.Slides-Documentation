---
title: حفظ العروض التقديمية في بايثون عبر جافا
linktitle: حفظ العرض التقديمي
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
- العرض التقديمي إلى ملف
- العرض التقديمي إلى تيار
- نوع عرض مسبق التعريف
- صيغة Office Open XML الصارمة
- وضع Zip64
- تحديث المصغرة
- تقدم الحفظ
- Python
- Java
- Aspose.Slides
description: "حفظ عروض PowerPoint و OpenDocument إلى ملفات أو تدفقات في بايثون عبر جافا باستخدام Aspose.Slides، وتكوين إخراج PPTX وتقرير التقدم."
---
## **نظرة عامة**

بعد إنشاء عرض تقديمي أو [فتح عرض تقديمي موجود](/slides/ar/python-java/open-presentation/)، استخدم طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) لكتابة النتيجة. يمكن لـ Aspose.Slides for Python via Java حفظ عرض تقديمي إلى ملف أو تدفق بصيغة PowerPoint أو OpenDocument أو PDF أو صيغ أخرى. يغطي الأقسام التالية عمليات الحفظ القياسية والخيارات المتاحة لإخراج PPTX.

## **حفظ العروض التقديمية إلى ملفات**

لحفظ عرض تقديمي إلى ملف، مرر مسار الإخراج وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/) إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save). تحدد قيمة التنسيق نوع الملف الذي تنشئه Aspose.Slides.

المثال التالي ينشئ عرض تقديمي ويحفظه كملف PPTX:

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

لأمثلة اكتشاف الملفات والتدفقات، وسلوك العروض التي تم إنشاؤها حديثًا، والتمييز بين صيغ المصدر والإخراج، راجع [تحديد صيغة العرض التقديمي الأصلية](/slides/ar/python-java/detect-presentation-source-format/).

في تطبيق معالجة دفعات، قد لا تكون صيغة الإدخال معروفة مسبقًا. بعد تحميل ملف، اقرأ صيغته الأصلية من طريقة [Presentation.getSourceFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSourceFormat). مرر قيمة [SourceFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sourceformat/) الناتجة إلى [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideutil/#toSaveFormat) للحصول على قيمة [SaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/) المقابلة، ثم استخدم [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) لكتابة العرض المعدل.

المثال الكامل التالي يعالج كل ملف في دليل إدخال، يحدث عنوانه، ويحفظه إلى دليل إخراج بالصغة التي تم تحميله منها:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideutil/#toSaveFormat) يطابق PPT و PPTX و ODP و PPTM و PPSX و PPSM و POTX و POTM و PPS و POT و OTP و FODP و PowerPoint XML بصيغ حفظ العرض المقابلة. يطابق صيغ مصدر العرض فقط؛ ولا يُقصد به اختيار صيغ التصدير مثل PDF أو HTML أو TIFF أو الصور. تمرير قيمة [SourceFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sourceformat/) غير مدعومة أو غير صالحة ينتج عنه [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

تستخدم ملفات PPT و PPS و POT القديمة نفس الحاوية الثنائية. عندما يتم تحميل مثل هذا العرض من تدفق بدون امتداد ملف، قد يتم التعرف على ملف PPS أو POT كـ PPT. إذا كان من الضروري الحفاظ على هذه الأنواع الفرعية القديمة، احتفظ باسم الملف الأصلي أو بيانات التعريف الخاصة بالصغة بشكل منفصل واستخدمها عند اختيار اسم الصفة وصيغة الإخراج.

## **حفظ العروض التقديمية إلى تدفقات**

للكتابة إلى عرض تقديمي دون الاعتماد على مسار ملف نهائي، مرر تدفقًا قابلًا للكتابة وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/) إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save). هذا النهج مفيد عندما يجب إرجاع الإخراج من خدمة ويب، أو تخزينه في قاعدة بيانات، أو معالجته في الذاكرة.

المثال التالي يحفظ عرض تقديمي جديد إلى تدفق ملف:

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

يمكنك تحديد العرض الذي يفتح به PowerPoint العرض المحفوظ مبدئيًا. استخدم طريقة [ViewProperties.setLastView](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#setLastView) مع قيمة [ViewType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewtype/) قبل الحفظ.

المثال التالي يكوّن عرض Master كالعرض الأولي:

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

## **حفظ العروض التقديمية بصيغة Office Open XML الصارمة**

لإنشاء ملف PPTX يتوافق مع ملف التعريف الصارم لـ Office Open XML، أنشئ كائن [PptxOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxoptions/) واستخدم طريقة [setConformance](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxoptions/#setConformance) مع [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ar/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). ثم مرر الخيارات إلى طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save).

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

## **حفظ العروض التقديمية بصيغة Office Open XML في وضع Zip64**

يحد أرشيف ZIP القياسي من حجم كل مدخل مضغوط وغير مضغوط، وحجم الأرشيف الإجمالي، وعدد المدخلات. بما أن ملف PPTX هو أرشيف ZIP، قد يتجاوز عرض تقديمي كبير جدًا هذه الحدود. امتدادات ZIP64 ترفع الحدود المطبقة على الحجم وعدد المدخلات.

استخدم طريقة [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxoptions/#setZip64Mode) للتحكم فيما إذا كانت Aspose.Slides تكتب امتدادات ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zip64mode/#IfNecessary) يستخدم ZIP64 فقط عندما يتجاوز العرض حدود ZIP القياسية. هذه هي الوضعية الافتراضية.
- [Never](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zip64mode/#Never) يعطل امتدادات ZIP64.
- [Always](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zip64mode/#Always) يكتب دائمًا امتدادات ZIP64.

المثال التالي يفعّل دائمًا امتدادات ZIP64 للعرض الناتج:

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

{{% alert color="warning" title="Warning" %}}
إذا تم استخدام [Zip64Mode.Never](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zip64mode/#Never) ولا يمكن للعرض أن يتناسب ضمن حدود ZIP القياسية، سيطلق عملية الحفظ استثناءً من نوع [PptxException](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **حفظ العروض التقديمية بصيغة Office Open XML بمستويات ضغط**

لإخراج PPTX، يمكنك موازنة سرعة الحفظ مقابل حجم الملف باستخدام طريقة [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxoptions/#setCompressionLevel). توفر فئة [CompressionLevel](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/) القيم التالية:

- [None](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#None) يخزن البيانات دون ضغط.
- [Level1](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#Level1) يوفر أسرع ضغط وأكبر حجم مضغوط.
- [Level2](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#Level2) إلى [Level5](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#Level5) يفضل تدريجيًا حجمًا أصغر على حساب سرعة الحفظ.
- [Level6](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#Level6) يوازن بين سرعة الحفظ وحجم الملف. هذه هي المستوى الافتراضي.
- [Level7](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#Level7) و [Level8](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#Level8) يفضّلان حجمًا أصغر أكثر على حساب سرعة الحفظ.
- [Level9](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compressionlevel/#Level9) يوفر أقوى ضغط ويتطلب أطول وقت معالجة.

المثال التالي يحفظ عرضًا تقديميًا دون ضغط:

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

المثال التالي يستخدم أعلى مستوى ضغط:

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **حفظ العروض التقديمية دون تحديث المصغرة**

عند حفظ عرض تقديمي كـ PPTX، تتحكم طريقة [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) في مصغرة المستند:

- `True` يعيد إنشاء المصغرة أثناء عملية الحفظ. هذه هي القيمة الافتراضية.
- `False` يحافظ على المصغرة الحالية. إذا لم يكن للعرض مصغرة، لا تُنشئ Aspose.Slides واحدة.

المثال التالي يحفظ عرضًا تقديميًا دون تحديث المصغرة:

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

{{% alert color="info" title="Note" %}}
إلغاء تحديث المصغرة يمكن أن يقلل من الوقت المستغرق لحفظ ملف PPTX.
{{% /alert %}}

## **الإبلاغ عن تقدم الحفظ كنسبة مئوية**

لمراقبة عملية الحفظ، سجِّل معالج تقدم بلغة Python عبر `jpype.JProxy` ومرره إلى طريقة [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveoptions/#setProgressCallback). ثم تستدعي Aspose.Slides طريقة `reporting` للمعالج مع قيم التقدم أثناء التصدير.

المثال التالي يبلّغ عن تقدم تصدير PDF إلى وحدة التحكم:

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

{{% alert color="info" title="Note" %}}
توفر Aspose أداة مجانية لتقسيم PowerPoint ([PowerPoint Splitter](https://products.aspose.app/slides/ar/splitter)) مبنية على Aspose.Slides API. تقوم بحفظ الشرائح المحددة من عرض تقديمي كملفات PPT أو PPTX منفصلة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل تدعم Aspose.Slides الحفظ التدريجي أو “الحفظ السريع”？**

لا. كل عملية حفظ تكتب ملفًا كاملاً بدلاً من تحديث الأجزاء المتغيرة فقط.

**هل يمكن لعدة خيوط حفظ نفس كائن Presentation؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) غير آمن للخيوط ([is not thread-safe](/slides/ar/python-java/multithreading/)). ينبغي الوصول إلى كل كائن وحفظه من خيط واحد فقط في كل مرة.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عندما أحفظ عرضًا تقديميًا؟**

تبقى [الروابط التشعبية](/slides/ar/python-java/manage-hyperlinks/) في العرض. لا تقوم Aspose.Slides بنسخ الملفات المرتبطة خارجيًا، لذلك يجب أن يظل العرض المحفوظ قادرًا على الوصول إلى مواقعها.

**هل يمكنني حفظ بيانات تعريف المستند مثل المؤلف والعنوان والشركة وتاريخ الإنشاء؟**

نعم. عيّن [خصائص المستند](/slides/ar/python-java/presentation-properties/) المناسبة قبل الحفظ، وستكتب Aspose.Slides هذه الخصائص إلى ملف الإخراج.