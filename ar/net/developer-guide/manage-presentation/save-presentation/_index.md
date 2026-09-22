---
title: حفظ العروض التقديمية في .NET
linktitle: حفظ العرض التقديمي
type: docs
weight: 80
url: /ar/net/save-presentation/
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
- تنسيق Office Open XML الصارم
- وضع Zip64
- تجديد الصورة المصغرة
- حفظ التقدم
- .NET
- C#
- Aspose.Slides
description: "احفظ عروض PowerPoint و OpenDocument إلى ملفات أو تدفقات باستخدام C# مع Aspose.Slides لـ .NET، وقم بتكوين إخراج PPTX وتقرير التقدم."
---
## **نظرة عامة**

بعد إنشاء عرض تقديمي أو [فتح عرض موجود](/slides/ar/net/open-presentation/)، استخدم طريقة [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) لكتابة النتيجة. يمكن لـ Aspose.Slides for .NET حفظ عرض تقديمي إلى ملف أو تدفق بصيغة PowerPoint أو OpenDocument أو PDF أو صيغ أخرى. تغطي الأقسام التالية عمليات الحفظ القياسية والخيارات المتاحة لإخراج PPTX.

## **حفظ العروض التقديمية إلى ملفات**

لحفظ عرض تقديمي إلى ملف، مرّر مسار الإخراج وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/) إلى طريقة [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/). تحدد قيمة التنسيق نوع الملف الذي تُنشئه Aspose.Slides.

المثال التالي يُنشئ عرض تقديمي ويحفظه كملف PPTX:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// أضف أو عدّل محتوى العرض التقديمي هنا.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **حفظ العروض التقديمية بتنسيقها الأصلي**

لأمثلة اكتشاف الملف والتدفق، سلوك العروض التي تم إنشاؤها حديثًا، والتمييز بين تنسيقات المصدر والإخراج، راجع [Determine the Original Presentation Format](/slides/ar/net/detect-presentation-source-format/).

في تطبيق معالجة دفعات، قد لا يكون تنسيق الإدخال معروفًا مسبقًا. بعد تحميل ملف، اقرأ تنسيقه الأصلي من خاصية [IPresentation.SourceFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/sourceformat/). مرّر القيمة الناتجة من [SourceFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/sourceformat/) إلى [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/tosaveformat/) للحصول على قيمة [SaveFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/) المقابلة، ثم استخدم [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) لكتابة العرض المعدل.

المثال الكامل التالي يعالج كل ملف في دليل الإدخال، يحدّث عنوانه، ويحفظه إلى دليل الإخراج بالتنسيق الذي تم تحميله منه:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/tosaveformat/) يطابق PPT و PPTX و ODP و PPTM و PPSX و PPSM و POTX و POTM و PPS و POT و OTP و FODP و PowerPoint XML إلى صيغ الحفظ المقابلة للعروض. يطابق صيغ مصدر العرض فقط؛ لا يُقصد منه اختيار صيغ التصدير مثل PDF أو HTML أو TIFF أو الصور. تمرير قيمة [SourceFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/sourceformat/) غير مدعومة أو غير صالحة ينتج عنه استثناء [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception).

ملفات PPT و PPS و POT القديمة تستخدم نفس الحاوية الثنائية. عند تحميل مثل هذا العرض من تدفق دون امتداد ملف، قد يُعرّف ملف PPS أو POT كـ PPT. إذا كان من الضروري الحفاظ على هذه الأنواع القديمة، احتفظ باسم الملف الأصلي أو بيانات التعريف الخاصة بالتنسيق بشكل منفصل واستخدمها عند اختيار اسم ملف الإخراج وتنسيقه.

## **حفظ العروض التقديمية إلى تدفقات**

للكتابة إلى عرض تقديمي دون الاعتماد على مسار ملف نهائي، مرّر كائن [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) قابل للكتابة وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/) إلى طريقة [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/). هذا النهج مفيد عندما يجب إرجاع الإخراج من خدمة ويب، أو تخزينه في قاعدة بيانات، أو معالجته في الذاكرة.

المثال التالي يحفظ عرضًا تقديميًا جديدًا إلى تدفق ملف:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **حفظ العروض التقديمية بنوع عرض مسبق التعريف**

يمكنك تحديد طريقة العرض التي يفتح فيها PowerPoint العرض المحفوظ أولًا. اضبط خاصية [ViewProperties.LastView](https://reference.aspose.com/slides/ar/net/aspose.slides/viewproperties/lastview/) إلى قيمة [ViewType](https://reference.aspose.com/slides/ar/net/aspose.slides/viewtype/) قبل الحفظ.

المثال التالي يضبط عرض الـ Slide Master كطريقة العرض الأولية:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **حفظ العروض التقديمية بتنسيق Office Open XML الصارم**

لإنشاء ملف PPTX يطابق الملف التعريفي Strict لـ Office Open XML، أنشئ مثيلًا من [PptxOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pptxoptions/) واضبط خاصية [Conformance](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pptxoptions/conformance/) إلى `Conformance.Iso29500_2008_Strict`. ثم مرّر الخيارات إلى طريقة [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**

أرشيف ZIP القياسي يحد من حجم كل عنصر مضغوط وغير مضغوط، الحجم الكلي للأرشيف، وعدد العناصر. بما أن ملف PPTX هو أرشيف ZIP، قد يتجاوز العرض كبير الحجم هذه الحدود. امتدادات ZIP64 ترفع الحدود المطبقة على الحجم وعدد العناصر.

استخدم خاصية [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pptxoptions/zip64mode/) للتحكم فيما إذا كانت Aspose.Slides تكتب امتدادات ZIP64:

- `IfNecessary` يستخدم ZIP64 فقط عندما يتجاوز العرض حدود ZIP القياسية. هذا هو الوضع الافتراضي.
- `Never` يوقف امتدادات ZIP64.
- `Always` يكتب دائمًا امتدادات ZIP64.

المثال التالي يفعّل دائمًا امتدادات ZIP64 للعرض الناتج:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
إذا تم تعيين `Zip64Mode` إلى `Never` ولم يتمكن العرض من التناسب ضمن حدود ZIP القياسية، ستُثير عملية الحفظ استثناء [PptxException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptxexception/).
{{% /alert %}}

## **حفظ العروض التقديمية بتنسيق Office Open XML مع مستويات الضغط**

لإخراج PPTX، يمكنك موازنة سرعة الحفظ مقابل حجم الملف بضبط خاصية [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pptxoptions/compressionlevel/). تعداد [CompressionLevel](https://reference.aspose.com/slides/ar/net/aspose.slides.export/compressionlevel/) يقدم القيم التالية:

- `None` يخزن البيانات بدون ضغط.
- `Level1` يوفر أسرع ضغط وأكبر حجم مضغوط.
- `Level2` إلى `Level5` يفضّلون تدريجيًا حجمًا أصغر على حساب سرعة الحفظ.
- `Level6` يوازن بين سرعة الحفظ وحجم الملف. هذا هو المستوى الافتراضي.
- `Level7` و `Level8` يفضلان حجمًا أصغر على حساب سرعة الحفظ.
- `Level9` يوفر أقوى ضغط ويتطلب أكبر وقت معالجة.

المثال التالي يحفظ عرضًا تقديميًا بدون ضغط:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

المثال التالي يستخدم أقصى مستوى ضغط:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

عند حفظ عرض تقديمي كـ PPTX، تتحكم خاصية [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/ar/net/aspose.slides.export/pptxoptions/refreshthumbnail/) في الصورة المصغرة للمستند:

- `true` يُعيد توليد الصورة المصغرة أثناء عملية الحفظ. هذه هي القيمة الافتراضية.
- `false` يحافظ على الصورة المصغرة الحالية. إذا لم يكن للعرض صورة مصغرة، فإن Aspose.Slides لا تُنشئ واحدة.

المثال التالي يحفظ عرضًا تقديميًا دون تجديد صورته المصغرة:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
تعطيل تجديد الصورة المصغرة يمكن أن يقلل من الوقت المطلوب لحفظ ملف PPTX.
{{% /alert %}}

## **تحديثات تقدم الحفظ بالنسبة المئوية**

لمراقبة عملية الحفظ، نفّذ الواجهة [IProgressCallback](https://reference.aspose.com/slides/ar/net/aspose.slides/iprogresscallback/) وعين التنفيذ إلى خاصية [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/ar/net/aspose.slides.export/isaveoptions/progresscallback/). ثم ستستدعي Aspose.Slides طريقة [IProgressCallback.Reporting](https://reference.aspose.com/slides/ar/net/aspose.slides/iprogresscallback/reporting/) بقيم التقدم أثناء التصدير.

المثال التالي يُبلغ عن تقدم تصدير PDF إلى وحدة التحكم:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
توفر Aspose أداة مجانية تُدعى [PowerPoint Splitter](https://products.aspose.app/slides/ar/splitter) مبنية على Aspose.Slides API. تُحفظ الشرائح المختارة من عرض تقديمي كملفات PPT أو PPTX منفصلة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides الحفظ المتزايد أو "الحفظ السريع"?**

لا. كل عملية حفظ تكتب ملف ناتج كامل بدلاً من تحديث الأجزاء المتغيّرة فقط.

**هل يمكن لعدة خيوط حفظ نفس كائن Presentation؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) [ليس آمنًا للتعددية](/slides/ar/net/multithreading/). يجب الوصول إلى كل كائن وحفظه من خيط واحد فقط في كل مرة.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عندما أحفظ عرضًا تقديميًا؟**

تظل [Hyperlinks](/slides/ar/net/manage-hyperlinks/) موجودة في العرض. لا تقوم Aspose.Slides بنسخ الملفات المرتبطة خارجيًا، لذا يجب أن يكون للعرض المحفوظ القدرة على الوصول إلى مواقعها.

**هل يمكنني حفظ بيانات تعريف المستند مثل المؤلف والعنوان والشركة وتاريخ الإنشاء؟**

نعم. اضبط [document properties](/slides/ar/net/presentation-properties/) المناسبة قبل الحفظ، وستكتب Aspose.Slides هذه الخصائص إلى ملف الإخراج.