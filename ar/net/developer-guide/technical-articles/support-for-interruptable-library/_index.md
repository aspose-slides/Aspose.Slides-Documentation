---
title: إلغاء عمليات العرض التقديمي طويلة الأمد في .NET
linktitle: إلغاء عمليات العرض التقديمي
type: docs
weight: 150
url: /ar/net/support-for-interruptable-library/
keywords:
- عمليات قابلة للإلغاء
- رمز الإيقاف
- رمز الإلغاء
- مهمة طويلة الأمد
- إلغاء المهمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إلغاء عمليات العرض التقديمي طويلة الأمد في Aspose.Slides for .NET وإرجاع نتيجة جزئية عند تصدير الشرائح في حلقة."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for .NET إلغاء عمليات طويلة الأمد مثل التحميل والحفظ وعرض العروض التقديمية. يمكن لتطبيقك استخدام نفس رمز الإيقاف لإيقاف حلقة قبل أن تبدأ بمعالجة الشريحة التالية.

## **إلغاء عملية عرض تقديمي**

أنشئ [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)، عيّن الـ[Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) إلى [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/)، ومرّر خيارات التحميل إلى [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). لطلب الإلغاء، استدعِ [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) على المصدر. تتوقف العملية القابلة للإلغاء عندما تلاحظ الطلب.

يبدأ المثال بتحويل `sample.pptx` إلى `sample.ppt` في مهمة خلفية ويطلب الإلغاء بعد 10 ثوانٍ. إذا انتهى التحويل قبل ذلك، يكون الناتج جاهزًا بالفعل.

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
    Run(action, tokenSource.Token); // تشغيل الإجراء في خيط منفصل
    Thread.Sleep(10000);            // مهلة
    tokenSource.Interrupt();        // إيقاف التحويل
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **ربط إلغاء .NET بـ Aspose.Slides**

إذا كان تطبيقك يستخدم [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)، قم بتمرير طلب إلغائه إلى Aspose.Slides. يبدأ المثال بتصدير `sample.pptx` إلى `sample.pdf` ويحدد مهلة 20 ثانية. أثناء التصدير، يتحقق كل 500 مللي ثانية من [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested). عندما تصبح الخاصية `true`، يستدعي [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/).

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
    Task task = Run(action, tokenSource.Token); // تشغيل الإجراء في خيط منفصل

    while (!task.Wait(500)) // انتظار ومراقبة ما إذا تم تعيين cancellationToken.IsCancellationRequested
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // إيقاف معالجة العرض التقديمي
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

## **التوقف قبل معالجة الشريحة التالية**

استخدم نفس [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) لكل من العرض التقديمي والحلقة التي تصدر شرائحه. تحقق من [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) قبل بدء كل عملية تصدير. إذا كان المتصل يمكنه الاستفادة من نتيجة جزئية، أعد أرقام الشرائح التي اكتملت تصديراتها بنجاح.

استخدم عرضًا تقديميًا باسم `sample.pptx` يحتوي على شريحتين على الأقل. يطلب المثال الإلغاء فور تسجيل أول تصدير ناجح.

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

يكتب المثال `slide-1.pdf` ويطبع `Starting slide 1` متبوعًا بـ `Completed: [1]`. ترى الحلقة الطلب قبل بدء الشريحة 2. إذا قاطع الإلغاء [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) أثناء تصدير، يخرج كتلة `catch` من الحلقة قبل تسجيل الشريحة الحالية كمكتملة.

إذا كان المتصل بحاجة إلى معالجة الإلغاء، استبدل فحص `if` وعبارة `break` في أعلى الحلقة باستدعاء [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) على الرمز. احذف كتلة `try`/`catch` حول التصدير بحيث يصل الإلغاء أثناء الحفظ إلى المتصل. باستخدام نفس المدخلات، يطبع المثال فقط `Starting slide 1` ويكتب `slide-1.pdf`. عند بدء التكرار الثاني، يتلقى المتصل استثناء [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) قبل بدء التصدير. لا تُرجع الطريقة أي قائمة.

## **الأسئلة الشائعة**

**متى يجب طلب الإلغاء؟**

اطلب الإلغاء عندما تتجاوز العملية حدود الوقت المحدد أو عندما لا يحتاج تطبيقك إلى النتيجة بعد الآن.

**ما الفرق بين [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) و[InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

المصدر يتيح لتطبيقك طلب الإلغاء. الرمز يتيح لـ Aspose.Slides وتطبيقك التحقق من وجود هذا الطلب.

**هل يمكنني استخدام [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) الخاص بـ .NET مع Aspose.Slides؟**

نعم. عندما يشير رمز .NET الخاص بك إلى الإلغاء، استدعِ [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) على المصدر المرتبط بالعرض التقديمي.

**ما العمليات التي يمكنني إلغاؤها؟**

يمكنك إلغاء التحميل والحفظ والعرض. مرّر الرمز إلى [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) عبر [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/). بعد ذلك يمكن للعرض التقديمي ملاحظة الإلغاء أثناء العمليات اللاحقة مثل [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/).

**هل تتوقف العملية فورًا؟**

الإلغاء تعاوني. تتحقق العملية من الرمز دوريًا وتتوقف عندما تلاحظ الطلب.

**ماذا يحدث إذا استدعيت [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) بعد انتهاء العملية؟**

تظل نتيجة العملية المكتملة كما هي.

**هل يمكن لعدة عمليات مشاركة نفس [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

نعم. استدعاء [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) يطلب الإلغاء لكل عملية تستخدم رمزًا من ذلك المصدر. استخدم مصدرًا منفصلاً لكل عملية تريد إلغاؤها بشكل مستقل.