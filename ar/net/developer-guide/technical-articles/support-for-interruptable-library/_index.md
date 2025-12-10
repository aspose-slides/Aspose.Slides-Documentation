---
title: دعم مكتبة القابلة للمقاطعة
type: docs
weight: 150
url: /ar/net/support-for-interruptable-library/
keywords:
- مكتبة القابلة للمقاطعة
- رمز المقاطعة
- رمز الإلغاء
- مهمة طويلة التنفيذ
- مهمة مقاطعة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اجعل المهام الطويلة قابلة للإلغاء باستخدام Aspose.Slides لـ .NET. مقاطعة عملية العرض والتحويل لـ PowerPoint و OpenDocument بأمان، مع أمثلة."
---

## **مكتبة القابلة للمقاطعة**

في [Aspose.Slides 18.4](https://releases.aspose.com/slides/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/)، قدمنا الفئات [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) و[InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/). تسمح لك بمقاطعة المهام الطويلة مثل فك التسلسل، التسلسل، وعرض الشرائح.

- [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) هو مصدر الرمز(الرموز) الممررة إلى [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/).
- عندما يتم تعيين [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/) وتمرير كائن [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) إلى مُنشئ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، يستدعي استدعاء [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) مقاطعة أي مهمة طويلة مرتبطة بهذا [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).

الجزء التالي من التعليمات البرمجية يوضح مقاطعة مهمة جارية:
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
    Run(action, tokenSource.Token); // تشغيل الإجراء في خيط منفصل
    Thread.Sleep(10000);            // مهلة
    tokenSource.Interrupt();        // إيقاف التحويل
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```


## **.NET CancellationToken ومكتبة القابلة للمقاطعة**

عند الحاجة إلى استخدام [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) إلى جانب مكتبة Aspose.Slides القابلة للمقاطعة، قم بلف معالجة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ومقاطعة [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) عندما تكون [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) `true`.

هذا الكود C# يوضح العملية:
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
    Task task = Run(action, tokenSource.Token); // تشغيل الإجراء في خيط منفصل

    while (!task.Wait(500)) // انتظر وراقب ما إذا كان cancellationToken.IsCancellationRequested قد تم تعيينه
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // مقاطعة معالجة العرض التقديمي
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


## **الأسئلة المتكررة**

**ما هو هدف مكتبة المقاطعة في Aspose.Slides؟**

توفر آلية لمقاطعة العمليات الطويلة—مثل تحميل أو حفظ أو عرض العروض التقديمية—قبل إكمالها. وهذا مفيد عندما يجب تقييد وقت المعالجة أو لم تعد الحاجة إلى المهمة.

**ما الفرق بين [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) و[InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/)?**

- `InterruptionToken` يتم تمريره إلى واجهة برمجة تطبيقات Aspose.Slides ويتم التحقق منه أثناء العمليات الطويلة.
- `InterruptionTokenSource` يُستخدم في الكود الخاص بك لإنشاء الرموز وتفعيل المقاطعات عبر استدعاء `Interrupt()`.

**هل يمكنني استخدام .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) مع مكتبة المقاطعة؟**

نعم. يمكنك مراقبة [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) في منطق تطبيقك والاستدعاء [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) عندما يتم طلب الإلغاء. وهذا يمكّن Aspose.Slides من الاندماج مع سير عمل الإلغاء القياسي في .NET.

**ما هي المهام التي يمكن مقاطعتها؟**

أي مهمة في Aspose.Slides تقبل [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/)—مثل تحميل عرض تقديمي باستخدام `Presentation(path, loadOptions)` أو حفظه عبر `Presentation.Save(...)`—يمكن مقاطعتها.

**هل تحدث المقاطعة فورًا؟**

لا. المقاطعة تعاونية: العملية تتحقق دوريًا من الرمز وتتوقف فور اكتشاف أنها تم استدعاء [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/).

**ماذا سيحدث إذا استدعيت [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) بعد أن تكمل المهمة بالفعل؟**

لا شيء—الاستدعاء لا يؤثر إذا كانت المهمة المقابلة قد اكتملت بالفعل.

**هل يمكنني إعادة استخدام نفس [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/) لمهام متعددة؟**

نعم—ولكن بعد استدعاء [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) على ذلك المصدر، ستُقاطع جميع المهام التي تستخدم رموزه. استخدم مصادر رموز منفصلة لإدارة المهام بشكل مستقل.