---
title: "تصدير العروض التقديمية إلى XAML في .NET"
linktitle: "العرض التقديمي إلى XAML"
type: docs
weight: 30
url: /ar/net/export-to-xaml/
keywords:
- "تصدير PowerPoint"
- "تصدير OpenDocument"
- "تصدير العرض التقديمي"
- "تحويل PowerPoint"
- "تحويل OpenDocument"
- "تحويل العرض التقديمي"
- "PowerPoint إلى XAML"
- "OpenDocument إلى XAML"
- "العرض التقديمي إلى XAML"
- "PPT إلى XAML"
- "PPTX إلى XAML"
- "ODP إلى XAML"
- "حفظ PPT كـ XAML"
- "حفظ PPTX كـ XAML"
- "حفظ ODP كـ XAML"
- "تصدير PPT إلى XAML"
- "تصدير PPTX إلى XAML"
- "تصدير ODP إلى XAML"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML في .NET باستخدام Aspose.Slides—حل سريع وخالٍ من Office يحافظ على تنسيقك كما هو."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تصدير عروض PowerPoint إلى XAML باستخدام Aspose.Slides. تتضمن مقدمة موجزة عن XAML، وتظهر كيفية حفظ عرض تقديمي كـ XAML بالإعدادات الافتراضية، وتوضح كيفية تخصيص التصدير عبر [XamlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export.xaml/xamloptions/)، بما في ذلك تصدير الشرائح المخفية. كما تجيب المقالة على بعض الأسئلة الشائعة المتعلقة بخطوط الاستFallback، توافق مجموعة XAML، وسلوك تصدير الشرائح المخفية.

## **حول XAML**

XAML هي لغة توصيف تستند إلى XML تُستخدم لوصف واجهات المستخدم في أطر مثل WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform)، وXamarin.Forms.

يمكنك العمل مع ملفات XAML في مصمم مرئي أو كتابة وتعديل العلامات مباشرة.

## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات الافتراضية**

يوضح المثال التالي بلغة C# كيفية تصدير عرض تقديمي إلى XAML بالإعدادات الافتراضية:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

بشكل افتراضي، تُحفظ الشرائح المُصدَّرة في مجلد فرعي باسم `pres` داخل دليل العمل الحالي للعملية، كما يُعيده [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory). يُنشأ المجلد تلقائيًا، وتُحفظ أي صور مطلوبة هناك أيضًا.

يُستمد اسم المجلد الناتج من اسم ملف المصدر دون امتداده. بالنسبة لـ `pres.pptx`، تُسمّى الملفات الناتجة `pres/Slide_1.xaml`، `pres/Slide_2.xaml`، وهكذا. حتى إذا مررت مسارًا مطلقًا للعرض التقديمي المُدخل، يُنشأ مجلد الإخراج نسبياً إلى دليل العمل الحالي، وليس بجانب ملف الإدخال.

## **تصدير العروض التقديمية إلى XAML باستخدام خيارات مخصصة**

استخدم واجهة [IXamlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export.xaml/ixamloptions/) للتحكم في طريقة تصدير Aspose.Slides لعرض تقديمي إلى XAML.

لحفظ الإخراج في موقع مخصص، نفّذ [IXamlOutputSaver](https://reference.aspose.com/slides/ar/net/aspose.slides.export.xaml/ixamloutputsaver/) وعين نسخة من تنفيذك إلى خاصية [OutputSaver](https://reference.aspose.com/slides/ar/net/aspose.slides.export.xaml/xamloptions/outputsaver/) في [XamlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export.xaml/xamloptions/).

لتضمين الشرائح المخفية في إخراج XAML، اضبط خاصية [ExportHiddenSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) على `true`، كما هو موضح في المثال التالي بلغة C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **التقاط جميع القطع المولدة من XAML**

يمكن لتصدير XAML أن ينتج مستند XAML لكل شريحة مُصدَّرة بالإضافة إلى صور منفصلة وموارد داعمة. عيّن [IXamlOutputSaver](https://reference.aspose.com/slides/ar/net/aspose.slides.export.xaml/ixamloutputsaver/) مخصصًا إلى [XamlOptions.OutputSaver](https://reference.aspose.com/slides/ar/net/aspose.slides.export.xaml/xamloptions/outputsaver/) لتستقبل هذه القطع بدلًا من استخدام الحفظ الافتراضي على نظام الملفات. ابدأ التصدير باستخدام نسخة [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) الخاصة بـ XAML التي تقبل خيارات XAML.

### **فهم دورة حياة رد الاتصال**

يستدعي المصدر [IXamlOutputSaver.Save](https://reference.aspose.com/slides/ar/net/aspose.slides.export.xaml/ixamloutputsaver/save/) بشكل منفصل لكل قطعة مُولدة:

- `path` يحدد القطعة وقد يتضمن أدلة نسبية. احتفظ بهذه المعلومات لأن XAML قد يُشير إلى موارد باستخدام مسارات نسبية.
- `data` يحتوي على بايتات القطعة. يجب عدم فك تشفير الصور والموارد الثنائية كالنص.
- المُحفظ مسؤول عن الاحتفاظ بالبيانات أو تثبيتها قبل الإرجاع. النسخ في الأمثلة تنسخ كل مصفوفة بايتات إلى ذاكرة مملوكة للتطبيق.
- اعتبر التصدير ناجحًا فقط عندما تُعيد عملية حفظ العرض التقديمي وتكتمل جميع ردود الاتصال بنجاح. لا تتجاهل أخطاء التخزين ولا تبدأ عمليات كتابة خلفية غير مراقبة. إذا تم الإحتفاظ بالبيانات بعد ذلك، أبلغ عن النجاح الكلي فقط بعد نجاح تلك الخطوة أيضًا.

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) ينطبق أيضًا على المُحفظ المخصص. قيمته الافتراضية `false` تستثني مستندات XAML للشرائح المخفية. ضبطه على `true` يضمّنها وكل الموارد المطلوبة لتصديرها. عدد الموارد يعتمد على العرض التقديمي؛ لا تفترض وجود رد اتصال واحد لكل شريحة أو ترتيب ثابت للردود.

### **التصدير إلى الذاكرة وتفقد القطع**

هذا المثال الكامل يقوم بتحميل `pres.pptx`، يجمع كل قطعة في [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)، ويطبع اسمها، نوعها، وعدد بايتاتها. يحافظ على الأسماء المقدمة تمامًا. الأسماء المتكررة تتسبب في فشل الجمع بدلًا من الكتابة فوق القطعة صامتًا.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // فك ترميز XAML فقط، وفقط عندما يكون فحص النص مطلوبًا.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

استدعِ `InMemoryXamlExample.Run` من تطبيقك. فحوصات الامتداد مفيدة للتفقد؛ احتفظ بجميع القطع، بما في ذلك أنواع الموارد غير المألوفة. اترك البايتات دون تعديل عند التخزين أو النقل. استخدم [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) فقط لـ XAML الذي يحتاج إلى معالجة نصية.

### **تعبئة القطع المُجمعة في أرشيف ZIP**

هذا المثال المستقل يجمع التصدير، يتحقق من صحة أسمائه، ويكتب البايتات الأصلية في أرشيف ZIP. اسم الأرشيف الفريد يفصل بين مهام التصدير المتزامنة. تستخدم إدخالات ZIP الشرط المائل الأمامي وتحتفظ بالأدلة النسبية. تُرفض الأسماء غير الآمنة أو المتصادمة بعد التطبيع قبل كتابة الحزمة.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // تم إغلاق دليل ZIP عند التخلص قبل الإبلاغ عن النجاح.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

استدعِ `ZipXamlExample.Run` من تطبيقك. يستخدم المثال [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) لكتابة أرشيف محلي واحد؛ لا يكتب المصدر ملفات XAML أو صور منفصلة. للتخزين عن بُعد، استبدل مرحلة كتابة الأرشيف بتحميل مصفوفات البايتات المجمعة. استخدم معرف وظيفة التصدير بالإضافة إلى الاسم النسبي الكامل للقطعة كمفتاح Blob، أو خزن معرف الوظيفة، الاسم النسبي، والبيانات الثنائية في صف قاعدة بيانات. انشر الوظيفة فقط بعد إكمال جميع التحميلات أو تأكيد عملية المعاملة في قاعدة البيانات. نظّف الإخراج الجزئي إذا فشل التخزين.

للعروض الكبيرة، يمكن للمُحفظ المخصص تثبيت كل قطعة مباشرةً في تخزين التطبيق لتجنب الاحتفاظ بنسخة إضافية من كامل التصدير في ذاكرة التطبيق. لا يزال المصدر يجمع جميع القطع المولدة في الذاكرة قبل استدعاء المُحفظ. احتفظ بكل رد اتصال متزامنًا من منظور المصدر: عد فقط بعد أن يقبل الوجهة البايتات، واسمح للأخطاء بالوصول إلى المتصل.

### **الحفاظ على أسماء الموارد والتحقق من المراجع**

- قم بتطبيع فواصل المسار عندما يتطلب الوجهة ذلك، لكن احتفظ بالأدلة النسبية. لا تستخدم فقط [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename) ما لم يكن كل اسم مولد معروفًا بأنه فريد وأن مراجع الموارد تظل صالحة.
- طبّق تحققًا من الأسماء خاصًا بالوجهة. عند كتابة ملفات منفصلة، رفض المسارات الجذرية وشرائح التنقل، حلّ الوجهة بـ [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath)، وتأكد من بقائها تحت الدليل المستهدف للتصدير متضمنة فاصل الدليل في اختبار الاحتواء. استخدم دليلًا يتحكم فيه التطبيق بدون روابط رمزية قد تعيد توجيه الكتابة.
- استخدم مُحفظًا ونطاق تخزين منفصلين لكل مهمة تصدير. اكتشف التصادمات بعد تطبيع الفواصل وفقًا لقواعد حساسية الحالة للوجهة.
- قبل النشر، حلّل كل مستند XAML كـ XML وتفقد مراجع الموارد القائمة على الملفات، مثل صفتى `Source` أو `ImageSource` للصور. حلّ كل URI نسبيًا بالنسبة لدليل القطعة XAML الحاوية، وطوّع الاسم الناتج، وتأكد من وجود المفتاح المقابل في القاموس أو إدخال ZIP أو الكائن المخزن. عالج URIs الخارجية وتعبيرات علامة XAML بشكل منفصل عن أسماء الملفات النسبية.

على سبيل المثال، إذا كان `pres/Slide_1.xaml` يشير إلى `images/image1.png`، يجب أن يكون المورد المخزن متاحًا كـ `pres/images/image1.png`. الاحتفاظ بـ `image1.png` فقط سيكسر هذه العلاقة. بالنسبة لتخزين الكائنات، احفظ نفس الهيكلية تحت بادئة الوظيفة واجعل عناوين URL لتلك الموارد قابلة للوصول للمستهلك XAML. أعد فتح الـ ZIP المكتمل للتحقق من أسماء الإدخالات وبايتات الموارد، وحمّل شرائح تمثيلية في بيئة XAML المستهدفة لتأكيد أن الصور تُحلّ بصورة صحيحة.

## **الأسئلة المتكررة**

**كيف يمكنني ضمان خطوط ثابتة إذا كان الخط الأصلي غير متوفر على الجهاز؟**

اضبط [DefaultRegularFont](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveoptions/defaultregularfont/) في [XamlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export.xaml/xamloptions/) — يُستخدم كخط احتياطي أثناء التصدير عندما يكون الأصلي مفقودًا. هذا لا يضمن أن XAML المُولَّد سيشير إلى الخط الاحتياطي أو أن الخط متوفر على الجهاز الهدف. تأكد من أن الخطوط المشار إليها في XAML متاحة في البيئة التي يُعرض فيها.

**هل يُقصد بـ XAML المُصدَّر فقط لـ WPF، أم يمكن استخدامه في مجموعات XAML أخرى أيضًا؟**

تُصدِّر Aspose.Slides XAML الخاص بـ WPF عبر واجهتها العامة. لا تُضمن التوافقية مع مجموعات XAML أخرى، مثل UWP وXamarin.Forms. اختبر العلامات المُولَّدة في بيئتك المستهدفة.

**هل تُدعم الشرائح المخفية، وكيف يمكنني منع تصديرها افتراضيًا؟**

بشكل افتراضي، لا تُضمن الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [ExportHiddenSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) في [XamlOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export.xaml/xamloptions/) — أبقها معطلة إذا لم تحتاج إلى تصديرها.