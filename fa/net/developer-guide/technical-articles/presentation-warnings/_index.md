---
title: مدیریت هشدارهای ارائه در .NET
type: docs
weight: 120
url: /fa/net/presentation-warnings/
aliases:
- /net/دریافت-کال‌بک-هشدار-برای-جایگزینی-قلم-در-aspose-slides/
keywords:
- کال‌بک هشدار
- سیاست هشدار
- از دست رفتن داده
- خراب‌سازی منبع
- مسئله سازگاری
- جایگزینی قلم
- امضای دیجیتال
- بارگذاری ارائه
- رندر ارائه
- تبدیل ارائه
- ذخیره ارائه
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه هشدارها را هنگام بارگذاری، رندر، تبدیل و ذخیره ارائه‌ها با Aspose.Slides برای .NET جمع‌آوری، دسته‌بندی و اقدام کنید."
---
## **نمای کلی**

Aspose.Slides می‌تواند مشکلات قابل بازیابی را هنگام بارگذاری، رندر، تبدیل یا ذخیره ارائه گزارش دهد. نمونه‌ها شامل ضبط‌های منبع خراب، محتواهایی که نمی‌توانند حفظ شوند، جایگزینی قلم و محدودیت‌های فرمت هدف هستند. یک فراخوانی هشدار به برنامه اجازه می‌دهد این شرایط را ثبت کند و تصمیم بگیرد آیا عملیات فعلی می‌تواند ادامه یابد یا نه.

پیاده‌سازی کنید رابط [IWarningCallback](https://reference.aspose.com/slides/fa/net/aspose.slides.warnings/iwarningcallback/) و خصوصیات [WarningType](https://reference.aspose.com/slides/fa/net/aspose.slides.warnings/iwarninginfo/warningtype/) و [Description](https://reference.aspose.com/slides/fa/net/aspose.slides.warnings/iwarninginfo/description/) را که از طریق [IWarningInfo](https://reference.aspose.com/slides/fa/net/aspose.slides.warnings/iwarninginfo/) فراهم می‌شوند، بررسی کنید. برای پذیرش هشدار `ReturnAction.Continue` را برگردانید یا برای متوقف کردن عملیات `ReturnAction.Abort` را برگردانید.

از [LoadOptions.WarningCallback](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/warningcallback/) برای هشدارهایی که در زمان باز کردن ارائه رخ می‌دهند، استفاده کنید. کلاس‌های گزینه رندر و خروجی، [SaveOptions.WarningCallback](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveoptions/warningcallback/) را ارث می‌برند که هشدارها را از رندر اسلاید، تبدیل و ذخیره دریافت می‌کند. چون خود هشدار عملیات برنامه را شناسایی نمی‌کند، هر نمونه فراخوانی را با مرحله‌ای از عملیات هنگام ساخت گزارش ترکیبی مرتبط کنید.

## **هشدارها و استثناها**

هشدار شرایطی را توصیف می‌کند که Aspose.Slides می‌تواند در صورت بازگشت `ReturnAction.Continue` از طرف فراخوانی، از آن بازیابی کند. یک استثنا به این معناست که عملیات درخواست شده نمی‌تواند به‌صورت معمول به پایان برسد؛ استثناها به هشدار تبدیل نمی‌شوند و نمی‌توانند توسط سیاست هشدار مدیریت شوند.

بازگشت `ReturnAction.Abort` از فراخوانی هشدار، درخواست‌کننده هشدار را مجبور می‌کند عملیات فعلی را با پرتاب یک استثنا خاتمه دهد. استثنای عمومی بسته به عملیات و فرمت ارائه متفاوت است. برای مثال، هنگام بارگذاری ممکن است یک [PptxReadException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxreadexception/) یا [PptReadException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptreadexception/) ظاهر شود، در حالی که هنگام ذخیره یا خروجی ممکن است یک [PptxException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxexception/) رخ دهد. استثنا را در مرز عملیات مدیریت کنید و از گزارش هشدار برای تعیین این که آیا سیاست برنامه سبب خاتمه شده است استفاده کنید نه فقط یک زیرنوع استثنا یا پیام خاص. فراخوانی هشدار را قبل از بازگشت `ReturnAction.Abort` ثبت می‌کند تا دلیل همچنان برای برنامه در دسترس باشد.

## **دسته‌بندی‌های هشدار**

چند‌الاختیاری [WarningType](https://reference.aspose.com/slides/fa/net/aspose.slides.warnings/warningtype/) دسته‌های زیر را فراهم می‌کند:

| نوع هشدار | معنی | سیاست معمول |
| --- | --- | --- |
| `SourceFileCorruption` | ارائه منبع شامل خراب‌کاری است که می‌تواند سند ذخیره‌شده در فرمت اصلی را غیرقابل استفاده کند. | توقف. |
| `DataLoss` | ممکن است متن، نمودارها، تصاویر یا داده‌های دیگر پس از بارگذاری یا ذخیره گم شوند. | توقف. |
| `MajorFormattingLoss` | احتمال از دست رفتن قالب‌بندی مهم در ارائه وجود دارد. | در حالت اعتبارسنجی سفت‌گیر توقف؛ در غیر این‌صورت ثبت و ادامه. |
| `MinorFormattingLoss` | ممکن است تفاوت قالب‌بندی محدودی رخ دهد. | ثبت برای عیب‌یابی و ادامه. |
| `CompatibilityIssue` | ممکن است نتیجه در برخی برنامه‌ها یا نسخه‌های قدیمی باز نشود یا به‌درستی عمل نکند. | ثبت و ادامه مگر آنکه سازگاری اجباری باشد. |
| `UnexpectedContent` | منبع شامل محتوای پشتیبانی‌نشده یا ناشناخته است که اثر آن هنوز شناخته نشده است. | ثبت و ادامه، یا در سیاست سفت‌گیر به‌عنوان خطا در نظر گرفته شود. |

دسته‌بندی باید تصمیم‌گیری سیاستی را هدایت کند. `Description` را برای عیب‌یابی ذخیره کنید، اما برای منطق برنامه بر روی متن آن تکیه نکنید زیرا متن پیام می‌تواند بین سناریوهای هشدار و نسخه‌های محصول متفاوت باشد.

## **جمع‌آوری و طبقه‌بندی هشدارها**

مثال زیر از یک گزارش سطح برنامه برای کل خط لوله پردازش استفاده می‌کند. یک نمونه فراخوانی جداگانه هشدارهای بارگذاری، رندر، تبدیل PDF و ذخیره PPTX را برچسب‌گذاری می‌کند. سیاست در صورت خرابی منبع یا از دست رفتن داده‌ها متوقف می‌شود، به‌صورت اختیاری در صورت از دست رفتن قالب‌بندی عمده نیز متوقف می‌شود و برای سایر هشدارها ادامه می‌دهد.

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

`abortOnMajorFormattingLoss` را به `false` تنظیم کنید وقتی که تفاوت‌های قالب‌بندی عمده قابل قبول هستند. مسائل سازگاری، از دست رفتن قالب‌بندی جزئی و محتوای غیرمنتظره همچنان در گزارش باقی می‌مانند حتی اگر عملیات ادامه یابد. اگر برنامه باید هر یک از این دسته‌ها را رد کند، متد `WarningPolicy.GetAction` را گسترش دهید.

## **سناریوهای رایج هشدار**

هشدارها می‌توانند در مراحل مختلف گردش کار ظاهر شوند:

- **امضاهای دیجیتال:** یک ارائه امضاشده می‌تواند هنگام بارگذاری هشدار دهد که امضای آن در طول پردازش از دست خواهد رفت. Aspose.Slides این وضعیت `DataLoss` را از طریق [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/fa/net/aspose.slides.warnings/ipresentationsignedwarninginfo/) گزارش می‌کند. یک فراخوانی در مرحله بارگذاری به برنامه اجازه می‌دهد فایل را رد کند یا صریحاً از از دست رفتن گزارش‌شده پذیرش کند.
- **جایگزینی قلم:** یک قلم در دسترس نبود می‌تواند در حین رندر یا خروجی اسلاید جایگزین شود. هشدارهای جایگزینی قلم به عنوان `DataLoss` گزارش می‌شوند، بنابراین سیاست سفت‌گیر بالا حتی اگر برنامه جایگزینی خاصی را بصری قابل قبول بداند، متوقف می‌شود. برای مشاهده این رفتار، از ارائه‌ای استفاده کنید که متنی با قلمی ناپذیر برای زمان اجرا داشته باشد. توضیح هشدار جایگزینی را شناسایی می‌کند؛ فونت‌های مورد نیاز یا [قواعد جایگزینی قلم](/slides/fa/net/font-substitution/) را قبل از تلاش مجدد پیکربندی کنید.
- **محتوای پشتیبانی‌نشده یا غیرمنتظره:** یک بارگذار می‌تواند با رکوردها یا ویژگی‌های ارائه‌ای مواجه شود که شناسایی نمی‌کند. چنین هشدارهایی ممکن است از `UnexpectedContent` استفاده کنند یا دسته‌ای جدی‌تر وقتی که داده یا قالب‌بندی تحت تأثیر باشد.
- **سازگاری فرمت:** ذخیره به فرمت ارائه‌ای دیگر می‌تواند ویژگی‌ها را حذف کند یا نتیجه‌ای تولید کند که در برخی برنامه‌ها رفتار متفاوتی داشته باشد. به‌عنوان مثال، ذخیره ارائه‌ای با بیش از هشت راهنمای افقی یا عمودی به PPT قدیمی، `CompatibilityIssue` گزارش می‌دهد. فراخوانی در مرحله ذخیره می‌تواند این نقصان را ثبت کرده و ادامه دهد یا در صورت لازم تمام راهنماها را حفظ کند.
- **رفتار بارگذاری:** گزینه‌های بارگذاری و رفتارهای قدیمی نیز می‌توانند هشدار تولید کنند. به‌عنوان مثال، [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/fa/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) استفاده از رفتار قفل‌گذاری منسوخ‌شده ارائه را به عنوان `CompatibilityIssue` شناسایی می‌کند.

هشدارها به سند منبع، فرمت هدف، عملیات و نسخه Aspose.Slides وابسته‌اند. فرض نکنید که هر فایل حتماً هشدار می‌دهد یا اینکه یک سناریو فقط به یک دسته مربوط می‌شود.

## **مدیریت ایمن عملیات‌های متوقف‌شده**

وقتی یک فراخوانی `ReturnAction.Abort` برمی‌گرداند، از شیئی که بارگذاری‌اش ناموفق بوده استفاده نکنید و فرض نکنید خروجی رندر یا ذخیره کامل است. عملیات می‌تواند پس از ایجاد فایل خروجی اما پیش از اتمام آن متوقف شود.

نتایج اعتبارسنجی شده را در مسیر جداگانه‌ای مانند `validated-output.pptx` ذخیره کنید. تنها پس از اتمام موفقیت‌آمیز عملیات، تأیید سیاست هشدار و توانایی باز و بررسی خروجی، ارائه موجود را جایگزین کنید. این کار از نوشتن فوق‌العاده یک فایل منبع معتبر با نتیجهٔ جزئی یا رد شده جلوگیری می‌کند.

گزارش هشدار خالی تضمین نمی‌کند که هر ویژگی منبع حفظ شده است. هر بررسی محتوا و بصری اضافی که برنامه نیاز دارد اعمال کنید. همچنین به [باز کردن ارائه‌ها](/slides/fa/net/open-presentation/) و [ذخیره ارائه‌ها](/slides/fa/net/save-presentation/) مراجعه کنید.

## **سوالات متداول**

**آیا فراخوانی هشدار می‌تواند تمام خطاهای Aspose.Slides را مدیریت کند؟**

خیر. فقط شرایط قابل بازیابی که به‌صورت هشدار گزارش می‌شوند را مدیریت می‌کند. استثناهایی که مستقل از فراخوانی رخ می‌دهند باید توسط برنامه در اطراف فراخوانی بارگذاری، رندر، تبدیل یا ذخیره مدیریت شوند.

**آیا بازگرداندن `ReturnAction.Continue` تضمین می‌کند خروجی یکسان باشد؟**

خیر. تنها اجازه ادامهٔ پردازش را می‌دهد. وضعیت گزارش‌شده هنوز ممکن است منجر به اختلافات داده، قالب‌بندی یا سازگاری شود، بنابراین نوع و توضیح هشدارهای جمع‌آوری‌شده را بررسی کنید.

**چگونه برنامه می‌تواند عملیاتی که هشدار را تولید کرده شناسایی کند؟**

برای هر عملیات یک نمونه فراخوانی ایجاد کنید و مرحله‌ای تعریف‌شده توسط برنامه را همراه با `WarningType` و `Description` ذخیره کنید، همان‌طور که در مثال نشان داده شده است.