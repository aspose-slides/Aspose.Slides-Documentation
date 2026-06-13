---
title: پشتیبانی از کتابخانه قابل قطع
type: docs
weight: 150
url: /fa/net/support-for-interruptable-library/
keywords:
- کتابخانه قابل قطع
- توکن قطع
- توکن لغو
- کار طولانی‌مدت
- کار قطع
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کارهای طولانی‌مدت را با Aspose.Slides برای .NET قابل لغو کنید. رندرینگ و تبدیل‌ها برای PowerPoint و OpenDocument را به‌صورت ایمن قطع کنید، همراه با مثال‌ها."
---
## **نمای کلی**

Aspose.Slides برای .NET مکانیزم پردازش قابل قطع برای کارهای طولانی‌مدت ارائه‌ها مانند بازگردانی سریال، سریال‌سازی و رندرینگ فراهم می‌کند. این مکانیزم بر پایهٔ کلاس‌های `InterruptionToken` و `InterruptionTokenSource` است.

یک `InterruptionToken` می‌تواند به `LoadOptions` اختصاص داده شده و به سازندهٔ `Presentation` پاس داده شود. وقتی `InterruptionTokenSource.Interrupt()` فراخوانی شود، کار طولانی‌مدت مرتبط متوقف می‌شود. این مقاله همچنین نشان می‌دهد چگونگی استفاده از این مکانیزم همراه با `CancellationToken` استاندارد .NET با نظارت بر درخواست‌های لغو و فراخوانی `Interrupt()` هنگام درخواست لغو.

## **کتابخانه قابل قطع**

در [Aspose.Slides 18.4](https://releases.aspose.com/slides/fa/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/) ما کلاس‌های [InterruptionToken](https://reference.aspose.com/slides/fa/net/aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/fa/net/aspose.slides/interruptiontokensource/) را معرفی کردیم. این کلاس‌ها به شما امکان می‌دهند کارهای طولانی‌مدت مانند بازگردانی سریال، سریال‌سازی و رندرینگ را متوقف کنید.

- [InterruptionTokenSource](https://reference.aspose.com/slides/fa/net/aspose.slides/interruptiontokensource/) منبع توکن(ها)ی است که به [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/fa/net/aspose.slides/iloadoptions/interruptiontoken/) پاس داده می‌شود.
- وقتی [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/fa/net/aspose.slides/iloadoptions/interruptiontoken/) تنظیم می‌شود و نمونهٔ [LoadOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/) به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) پاس داده شود، فراخوانی [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/fa/net/aspose.slides/interruptiontokensource/interrupt/) هر کار طولانی‌مدتی را که به آن [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) مرتبط است، قطع می‌کند.

کد زیر نمونه‌ای از قطع یک کار در حال اجرا را نشان می‌دهد:

```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("sample.pptx", options))
        {
            presentation.Save("sample.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // اجرا کردن عملیات در یک رشته جداگانه
    Thread.Sleep(10000);            // زمان‌سربری
    tokenSource.Interrupt();        // تبدیل را متوقف کنید
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken و کتابخانه قابل قطع**

زمانی که نیاز دارید از [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) همراه با کتابخانه قابل قطع Aspose.Slides استفاده کنید، پردازش [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) را درون یک حلقه بپیچید و زمانی که [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) برابر `true` شود، [InterruptionToken](https://reference.aspose.com/slides/fa/net/aspose.slides/interruptiontoken/) را متوقف کنید.

کد C# زیر این عملیات را نشان می‌دهد:

```cs
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("sample.pptx", "sample.pdf", tokenSource.Token);
}

static void ProcessPresentation(string path, string outPath, CancellationToken cancellationToken)
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions {InterruptionToken = token};
        using (Presentation presentation = new Presentation(path, options))
        {
            presentation.Save(outPath, SaveFormat.Pdf);
        }
    };
    
    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Task task = Run(action, tokenSource.Token); // اجرای عملیات در یک رشته جداگانه

    while (!task.Wait(500)) // صبر کنید و نظارت کنید آیا cancellationToken.IsCancellationRequested تنظیم شده است
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // قطع پردازش ارائه
        }
    }
}

private static Task Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    return Task.Run(() =>
    {
        action(token);
    });
}
```

## **سوالات متداول**

**هدف کتابخانه قابل قطع Aspose.Slides چیست؟**

این کتابخانه مکانیزمی را فراهم می‌کند تا عملیات‌های طولانی‌مدت مانند بارگذاری، ذخیره یا رندر کردن ارائه‌ها را قبل از اتمام آنها متوقف کنید. این ویژگی زمانی مفید است که زمان پردازش باید محدود شود یا کار دیگر نیازی به انجام ندارد.

**تفاوت بین [InterruptionToken](https://reference.aspose.com/slides/fa/net/aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/fa/net/aspose.slides/iinterruptiontokensource/) چیست؟**

- `InterruptionToken` به API Aspose.Slides پاس داده می‌شود و در طول عملیات طولانی‌مدت بررسی می‌شود.
- `InterruptionTokenSource` در کد شما برای ساخت توکن‌ها و ایجاد وقفه با فراخوانی `Interrupt()` استفاده می‌شود.

**آیا می‌توانم .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) را با کتابخانه قابل قطع استفاده کنم؟**

بله. می‌توانید در منطق برنامهٔ خود به [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) نظارت کنید و هنگام درخواست لغو، [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/fa/net/aspose.slides/iinterruptiontokensource/interrupt/) را فراخوانی کنید. این کار باعث می‌شود Aspose.Slides با جریان‌های لغو استاندارد .NET یکپارچه شود.

**چه کارهایی می‌توانند قطع شوند؟**

هر کاری از Aspose.Slides که یک [InterruptionToken](https://reference.aspose.com/slides/fa/net/aspose.slides/interruptiontoken/) می‌پذیرد—مانند بارگذاری یک ارائه با `Presentation(path, loadOptions)` یا ذخیره با `Presentation.Save(...)`—می‌تواند قطع شود.

**آیا قطع بلافاصله اتفاق می‌افتد؟**

خیر. قطع به صورت تعاملی است: عملیات به‌صورت دوره‌ای توکن را بررسی می‌کند و به محض اینکه تشخیص دهد [Interrupt()](https://reference.aspose.com/slides/fa/net/aspose.slides/iinterruptiontokensource/interrupt/) فراخوانی شده است، متوقف می‌شود.

**اگر پس از اتمام یک کار، [Interrupt()](https://reference.aspose.com/slides/fa/net/aspose.slides/iinterruptiontokensource/interrupt/) را صدا بزنم چه می‌شود؟**

هیچ تعییری نمی‌شود—فراخوانی اثر ندارد اگر کار مربوطه قبلاً به‌پایان رسیده باشد.

**آیا می‌توانم همان [InterruptionTokenSource](https://reference.aspose.com/slides/fa/net/aspose.slides/iinterruptiontokensource/) را برای چند کار استفاده کنم؟**

بله—اما پس از اینکه [Interrupt()](https://reference.aspose.com/slides/fa/net/aspose.slides/iinterruptiontokensource/interrupt/) را روی آن منبع صدا زدید، تمام کارهایی که از توکن‌های آن استفاده می‌کنند قطع خواهند شد. برای مدیریت مستقل کارها، از منابع توکن جداگانه استفاده کنید.