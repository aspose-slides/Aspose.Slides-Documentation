---
title: قطع عملیات طولانی‌مدت ارائه در .NET
linktitle: قطع عملیات ارائه
type: docs
weight: 150
url: /fa/net/support-for-interruptable-library/
keywords:
- عملیات‌های قابل قطع
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
description: "یاد بگیرید چگونه عملیات ارائهٔ طولانی‌مدت را در Aspose.Slides برای .NET لغو کنید و هنگام صادرات اسلایدها در یک حلقه، نتیجهٔ جزئی بازگردانید."
---
## **نمای کلی**

Aspose.Slides for .NET می‌تواند عملیات طولانی‌مدت مانند بارگذاری، ذخیره‌سازی و رندر ارائه‌ها را قطع کند. برنامه شما می‌تواند از همان توکن قطع استفاده کند تا حلقه‌ای را قبل از پردازش اسلاید بعدی متوقف کند.

## **قطع یک عملیات ارائه**

یک [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) ایجاد کنید، ‎[Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) آن را به ‎[LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/) اختصاص دهید و گزینه‌های بارگذاری را به ‎[Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) پاس دهید. برای درخواست لغو، ‎[InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) را روی منبع فراخوانی کنید. یک عملیات قابل قطع وقتی درخواست را مشاهده کند، متوقف می‌شود.

در مثال، تبدیل `sample.pptx` به `sample.ppt` در یک کار پس‌زمینه آغاز می‌شود و پس از 10 ثانیه درخواست لغو می‌شود. اگر تبدیل زودتر تمام شود، خروجی از پیش کامل است.

```c#
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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
    Run(action, tokenSource.Token); // اجرای اکشن در یک رشته جداگانه
    Thread.Sleep(10000);            // محدودیت زمان
    tokenSource.Interrupt();        // توقف تبدیل
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **اتصال لغو .NET به Aspose.Slides**

اگر برنامه شما از یک .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) استفاده می‌کند، درخواست لغو آن را به Aspose.Slides منتقل کنید. در مثال، فرآیند صادرات `sample.pptx` به `sample.pdf` آغاز می‌شود و یک زمان انتظار 20 ثانیه‌ای تنظیم می‌گردد. در حین اجرا، هر 500 میلی‌ثانیه یک بار ‎[CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) بررسی می‌شود. وقتی مقدار این ویژگی به `true` تغییر کند، ‎[InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) فراخوانی می‌شود.

```cs
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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
    Task task = Run(action, tokenSource.Token); // اجرای اکشن در یک رشته جداگانه

    while (!task.Wait(500)) // انتظار و نظارت بر اینکه آیا cancellationToken.IsCancellationRequested تنظیم شده است
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

## **توقف قبل از پردازش اسلاید بعدی**

از همان ‎[IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) برای ارائه و حلقه‌ای که اسلایدهای آن را صادرات می‌کند، استفاده کنید. قبل از شروع هر صادرات، ‎[IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) را بررسی کنید. اگر فراخوانی می‌تواند از نتیجه جزئی استفاده کند، شماره اسلایدهای صادراتی که با موفقیت تکمیل شده‌اند را برگردانید.

از ارائه‌ای به نام `sample.pptx` که حداقل دو اسلاید دارد استفاده کنید. در مثال، بلافاصله پس از ثبت اولین صادرات موفق، درخواست لغو انجام می‌شود.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new InterruptionTokenSource();
var completed = ExportSlides("sample.pptx", source);
Console.WriteLine($"Completed: [{string.Join(", ", completed)}]");

static List<int> ExportSlides(string path, IInterruptionTokenSource source)
{
    var completed = new List<int>();
    IInterruptionToken token = source.Token;
    var options = new LoadOptions { InterruptionToken = token };
    using var presentation = new Presentation(path, options);

    for (var number = 1; number <= presentation.Slides.Count; number++)
    {
        if (token.IsInterruptionRequested)
            break;

        Console.WriteLine($"Starting slide {number}");
        try
        {
            presentation.Save($"slide-{number}.pdf", new[] { number }, SaveFormat.Pdf);
        }
        catch (OperationCanceledException) when (token.IsInterruptionRequested)
        {
            break;
        }

        completed.Add(number);
        if (number == 1)
            source.Interrupt();
    }

    return completed;
}
```

در مثال، `slide-1.pdf` نوشته می‌شود و `Starting slide 1` چاپ می‌گردد و سپس `Completed: [1]`. حلقه درخواست را پیش از شروع اسلاید 2 می‌بیند. اگر لغو به جای آن ‎[Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) را در حین یک صادرات قطع کند، بلوک `catch` قبل از اینکه کد اسلاید فعلی را به‌عنوان کامل ثبت کند، حلقه را خارج می‌شود.

اگر فراخوانی نیاز به مدیریت لغو داشته باشد، بررسی `if` و `break` آن در ابتدای حلقه را با یک فراخوانی به ‎[ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) روی توکن جایگزین کنید. `try`/`catch` دور صادرات را حذف کنید تا لغو در حین ذخیره هم به فراخوانی برسد. با همان ورودی، مثال فقط `Starting slide 1` چاپ می‌کند و `slide-1.pdf` می‌نویسد. در شروع تکرار دوم، فراخوانی یک ‎[OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) دریافت می‌کند پیش از شروع صادرات. متد هیچ فهرستی برنمی‌گرداند.

## **FAQ**

**کی باید درخواست لغو کنم؟**

در صورتی که یک عملیات زمان محدودهٔ شما را عبور کند یا برنامهٔ شما دیگر به نتیجه نیاز نداشته باشد، درخواست لغو کنید.

**فرق بین [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) چیست؟**

منبع به برنامهٔ شما امکان درخواست لغو را می‌دهد. توکن به Aspose.Slides و برنامهٔ شما امکان بررسی آن درخواست را می‌دهد.

**آیا می‌توانم از یک .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) با Aspose.Slides استفاده کنم؟**

بله. هنگامی که توکن .NET شما لغو را سیگنال می‌دهد، ‎[InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) را روی منبع مرتبط با ارائه فراخوانی کنید.

**کدام عملیات‌ها را می‌توانم قطع کنم؟**

می‌توانید بارگذاری، ذخیره‌سازی و رندر را قطع کنید. توکن را از طریق ‎[LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/) به ‎[Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) پاس دهید. سپس ارائه می‌تواند لغو را در عملیات بعدی مانند ‎[Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) مشاهده کند.

**آیا عملیات بلافاصله متوقف می‌شود؟**

لغو به صورت تعاونی است. یک عملیات به‌صورت دوره‌ای توکن را بررسی می‌کند و وقتی درخواست را مشاهده کند، متوقف می‌شود.

**اگر پس از پایان یک عملیات ‎[InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) را فراخوانی کنم چه می‌شود؟**

عملیات تکمیل‌شده نتیجهٔ خود را حفظ می‌کند.

**آیا چندین عملیات می‌توانند یک ‎[InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) را به‌اشتراک بگذارند؟**

بله. فراخوانی ‎[InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) برای همهٔ عملیات‌هایی که از توکنی از آن منبع استفاده می‌کنند درخواست لغو می‌کند. برای هر عملیاتی که می‌خواهید به‌طور مستقل لغو شود، منبع جداگانه‌ای استفاده کنید.