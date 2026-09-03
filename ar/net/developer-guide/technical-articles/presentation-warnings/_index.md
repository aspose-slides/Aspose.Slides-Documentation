---
title: معالجة تحذيرات العرض التقديمي في .NET
type: docs
weight: 120
url: /ar/net/presentation-warnings/
aliases:
- /net/الحصول-على-استدعاءات-التحذير-لاستبدال-الخطوط-في-aspose-slides/
keywords:
- استدعاء التحذير
- سياسة التحذير
- فقدان البيانات
- تلف المصدر
- مسألة التوافق
- استبدال الخط
- توقيع رقمي
- تحميل العرض التقديمي
- تصيير العرض التقديمي
- تحويل العرض التقديمي
- حفظ العرض التقديمي
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية جمع، تصنيف، والتعامل مع التحذيرات أثناء تحميل، تصيير، تحويل، وحفظ العروض التقديمية باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides الإبلاغ عن المشكلات القابلة للتعافي أثناء تحميله أو عرضه أو تحويله أو حفظه للعرض التقديمي. تشمل الأمثلة سجلات المصدر التالفة، المحتوى الذي لا يمكن الاحتفاظ به، استبدال الخطوط، وقيود تنسيق الهدف. يتيح استدعاء تحذير (warning callback) للتطبيق تسجيل هذه الحالات وتحديد ما إذا كان يمكن متابعة العملية الحالية.

قم بتنفيذ الواجهة [IWarningCallback](https://reference.aspose.com/slides/ar/net/aspose.slides.warnings/iwarningcallback/) وفحص خصائص [WarningType](https://reference.aspose.com/slides/ar/net/aspose.slides.warnings/iwarninginfo/warningtype/) و[Description](https://reference.aspose.com/slides/ar/net/aspose.slides.warnings/iwarninginfo/description/) التي تُزوَّد عبر [IWarningInfo](https://reference.aspose.com/slides/ar/net/aspose.slides.warnings/iwarninginfo/). ارجع إلى [ReturnAction.Continue](https://reference.aspose.com/slides/ar/net/aspose.slides.warnings/returnaction/) لقبول التحذير أو `ReturnAction.Abort` لإيقاف العملية.

استخدم [LoadOptions.WarningCallback](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/warningcallback/) للتحذيرات التي تُثار أثناء فتح العرض التقديمي. توجد فئات خيارات العرض والتصدير ترث من [SaveOptions.WarningCallback](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveoptions/warningcallback/)، والتي تتلقى التحذيرات من عرض الشرائح، التحويل، والحفظ. لأن التحذير نفسه لا يحدد عملية التطبيق، اربط كل مثيل من استدعاء التحذير بمرحلة العملية عند بناء تقرير مركب.

## **التحذيرات والاستثناءات**

الوصف يوضح حالة يمكن لـ Aspose.Slides التعافي منها إذا أعاد الاستدعاء `ReturnAction.Continue`. الاستثناء يعني أن العملية المطلوبة لا يمكن إكمالها بشكل طبيعي؛ لا يتم تحويل الاستثناءات إلى تحذيرات ولا يمكن التعامل معها بسياسة التحذير.

إرجاع `ReturnAction.Abort` يطلب من موزع التحذير إنهاء العملية الحالية عن طريق رفع استثناء. يعتمد الاستثناء العام على العملية وتنسيق العرض التقديمي. على سبيل المثال، قد يُظهر التحميل استثناءً من نوع [PptxReadException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptxreadexception/) أو [PptReadException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptreadexception/)، بينما قد يُظهر الحفظ أو التصدير استثناءً من نوع [PptxException](https://reference.aspose.com/slides/ar/net/aspose.slides/pptxexception/). عالج الاستثناء عند حدود العملية واستخدم تقرير التحذير لتحديد ما إذا كانت سياسة التطبيق هي التي تسببت في الإنهاء بدلاً من الاعتماد على نوع فرعي واحد من الاستثناء أو رسالته. يقوم الاستدعاء بتسجيل التحذير قبل إرجاع `ReturnAction.Abort`، مما يضمن بقاء السبب متاحًا للتطبيق.

## **فئات التحذير**

توفر تعداد [WarningType](https://reference.aspose.com/slides/ar/net/aspose.slides.warnings/warningtype/) الفئات التالية:

| نوع التحذير | المعنى | السياسة النموذجية |
| --- | --- | --- |
| `SourceFileCorruption` | يحتوي عرض المصدر على تلف قد يجعل المستند المحفوظ بتنسيقه الأصلي غير قابل للاستخدام. | الإنهاء. |
| `DataLoss` | قد تكون النصوص أو المخططات أو الصور أو أي بيانات أخرى مفقودة بعد التحميل أو الحفظ. | الإنهاء. |
| `MajorFormattingLoss` | قد يفقد العرض تنسيقًا مهمًا. | الإنهاء في وضع التحقق الصارم؛ وإلا سجل واستمر. |
| `MinorFormattingLoss` | قد يحدث فرق تنسيق محدود. | سجل للتشخيص واستمر. |
| `CompatibilityIssue` | قد لا يفتح الناتج أو يعمل بشكل صحيح في بعض التطبيقات أو الإصدارات القديمة. | سجّل واستمر ما لم تكن التوافقية إلزامية. |
| `UnexpectedContent` | يحتوي المصدر على محتوى غير مدعوم أو غير معروف قد لا يُعرف تأثيره بعد. | سجّل واستمر، أو اعتبره خطأ في سياسة صارمة. |

يجب أن تقود الفئة قرار السياسة. احفظ `Description` للتشخيص، لكن لا تعتمد على صياغتها في منطق التطبيق لأن نص الرسالة قد يختلف بين سيناريوهات التحذير وإصدارات المنتج.

## **جمع وتصنيف التحذيرات**

يستخدم المثال التالي تقريرًا على مستوى التطبيق للمعالجة الكاملة للخط الأنابيب. يهيئ مثيل استدعاء منفصل لتصنيف التحذيرات من التحميل، العرض، تحويل PDF، وحفظ PPTX. تُلغي السياسة العملية عند حدوث تلف في المصدر أو فقدان البيانات، ويمكن أن تُلغي أيضًا عند فقدان تنسيق كبير، وتستمر لبقية التحذيرات.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

عيّن `abortOnMajorFormattingLoss` إلى `false` عندما تكون اختلافات التنسيق الكبرى مقبولة. لا تزال مشكلات التوافق، فقدان التنسيق الصغير، والمحتوى غير المتوقع محفوظة في التقرير حتى لو استمرت العملية. مدد `WarningPolicy.GetAction` إذا كان التطبيق بحاجة إلى رفض أي من هذه الفئات.

## **سيناريوهات التحذير الشائعة**

يمكن أن تظهر التحذيرات في مراحل مختلفة من سير العمل:

- **التوقيعات الرقمية:** قد ينتج عن عرض موقّع تحذير أثناء التحميل بأن توقيعه سيفقد أثناء المعالجة. تُبلغ Aspose.Slides عن هذه الحالة كـ `DataLoss` عبر [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ar/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). يتيح استدعاء مرحلة التحميل للتطبيق رفض الملف أو قبول الفقدان المُبلَّغ عنه صراحةً.
- **استبدال الخطوط:** قد يتم استبدال خط غير متاح أثناء عرض الشريحة أو تصديرها. تُبلغ تحذيرات استبدال الخطوط كـ `DataLoss`، لذا فإن السياسة الصارمة أعلاه تُلغي العملية حتى لو كان التطبيق قد يعتبر الاستبدال مقبولًا بصريًا. لاختبار هذا السلوك، استخدم عرضًا يحتوي على نص بخط غير متوفر في وقت التشغيل. يحدد وصف التحذير الاستبدال؛ قم بتهيئة الخطوط المطلوبة أو [قواعد استبدال الخطوط](/slides/ar/net/font-substitution/) قبل إعادة المحاولة.
- **محتوى غير مدعوم أو غير متوقع:** قد يواجه المحمّل سجلات أو ميزات للعرض لا يتعرف عليها. قد تستخدم هذه التحذيرات `UnexpectedContent`، أو فئة أكثر شدة إذا كان من المعروف أن البيانات أو التنسيق سيتضرران.
- **توافق التنسيق:** قد يؤدي الحفظ إلى تنسيق عرض آخر إلى حذف ميزات أو إنتاج نتيجة تتصرف بشكل مختلف في بعض التطبيقات. على سبيل المثال، حفظ عرض يحتوي على أكثر من ثمانية دلائل أفقية أو عمودية في نسخة PPT قد يُبلغ عن `CompatibilityIssue`. يمكن لاستدعاء مرحلة الحفظ تسجيل الفقدان والاستمرار، أو رفضه إذا كان الحفاظ على جميع الدلائل ضروريًا.
- **سلوك التحميل:** قد تُنتج خيارات التحميل والسلوكيات القديمة أيضًا تحذيرات. على سبيل المثال، يحدد [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ar/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) استخدام سلوك قفل عرض قديم كـ `CompatibilityIssue`.

تعتمد التحذيرات على مستند المصدر، تنسيق الهدف، العملية، وإصدار Aspose.Slides. لا تفترض أن كل ملف يُنتج تحذيرًا أو أن السيناريو يُطابق فئة واحدة فقط.

## **معالجة العمليات التي أُلغيت بأمان**

عند إرجاع الاستدعاء `ReturnAction.Abort`، لا تستخدم الكائن الذي فشل في التحميل ولا تفترض أن ناتج العرض أو الحفظ مكتمل. قد تُنهى العملية بعد إنشاء ملف الإخراج ولكن قبل إكماله.

احفظ النتائج التي تم التحقق منها إلى مسار منفصل مثل `validated-output.pptx`. استبدل العرض الموجود فقط بعد أن تنتهي العملية بنجاح، وأن تقرير التحذير يتوافق مع سياسة التطبيق، وأن الناتج يمكن فتحه والتحقق منه. هذا يجنّب كتابة ملف مصدر صالح بنتيجة جزئية أو مرفوضة.

عدم وجود تقرير تحذير لا يضمن أن كل ميزة في المصدر قد تم الحفاظ عليها. نفّذ أي فحوصات محتوى أو بصرية إضافية تطلبها التطبيق. راجع أيضًا [فتح العروض التقديمية](/slides/ar/net/open-presentation/) و[حفظ العروض التقديمية](/slides/ar/net/save-presentation/).

## **الأسئلة المتكررة**

**هل يمكن لمستدعي التحذير التعامل مع كل خطأ في Aspose.Slides؟**

لا. يتعامل مع الحالات القابلة للتعافي التي تُبلغ كتحذيرات. يجب على التطبيق معالجة الاستثناءات التي تحدث خارج نطاق المستدعي أثناء التحميل أو العرض أو التحويل أو الحفظ.

**هل يضمن إرجاع `ReturnAction.Continue` مخرجات مطابقة تمامًا؟**

لا. يسمح فقط بمتابعة المعالجة. قد تؤدي الحالة المبلَّغ عنها إلى اختلافات في البيانات أو التنسيق أو التوافق، لذا يجب مراجعة أنواع التحذيرات المجمّعة ووصفها.

**كيف يمكن للتطبيق تحديد العملية التي أنتجت التحذير؟**

أنشئ مثيلًا من المستدعي لكل عملية وخزن مرحلة معرفة من قبل التطبيق إلى جانب `WarningType` و`Description`، كما هو موضح في المثال.