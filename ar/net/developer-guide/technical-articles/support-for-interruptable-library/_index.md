---
title: الدعم لمكتبة القابلة للإيقاف
type: docs
weight: 150
url: /net/support-for-interruptable-library/

---

## **المكتبة القابلة للإيقاف**

في [Aspose.Slides 18.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-18-4-release-notes/)، أضفنا صنف [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken) وصنف [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource). إنها توفر الدعم لإيقاف المهام الطويلة الأمد، مثل إعادة التحميل، أو التسلسل، أو العرض.

- يمثل InterruptionTokenSource مصدر الرمز أو الرموز المتعددة التي يتم تمريرها إلى **ILoadOptions.InterruptionToken**.
- عندما يكون ILoadOptions.InterruptionToken محددًا ويتم تمرير مثيل LoadOptions إلى مُنشئ Presentation، فإن استدعاء طريقة InterruptionTokenSource.Interrupt يتسبب في إيقاف أي مهمة طويلة الأمد مرتبطة بـ Presentation.

توضح مقتطفات الشيفرة التالية إيقاف مهمة قيد التشغيل:

```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("pres.pptx", options))
        {
            presentation.Save("pres.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // تنفيذ الإجراء في خيط منفصل
    Thread.Sleep(10000);            // مهلة
    tokenSource.Interrupt();        // إيقاف التحويل
}
private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **CancellationToken في .NET والمكتبة القابلة للإيقاف**

عندما تحتاج إلى استخدام [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) جنبًا إلى جنب مع مكتبة Slides القابلة للإيقاف، يمكنك لف معالجة Presentation وإيقاف [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken) إذا كانت [cancellationToken.IsCancellationRequested](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) مثبتة على true.

توضح الشيفرة C# التالية العملية الموصوفة:

```csharp
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("pres.pptx", "pres.pdf", tokenSource.Token);
}

static void ProcessPresentation(string path, string outPath, CancellationToken cancellationToken)
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation(path, options))
        {
            presentation.Save(outPath, SaveFormat.Pdf);
        }
    };
    
    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Task task = Run(action, tokenSource.Token); // تنفيذ الإجراء في خيط منفصل

    while (!task.Wait(500)) // الانتظار لمراقبة ما إذا كان cancellationToken.IsCancellationRequested تم تعيينه.
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("تم إلغاء معالجة العرض التقديمي");
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