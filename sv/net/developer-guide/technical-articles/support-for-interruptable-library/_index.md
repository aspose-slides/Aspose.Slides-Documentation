---
title: Stöd för avbrytbart bibliotek
type: docs
weight: 150
url: /sv/net/support-for-interruptable-library/
keywords:
- avbrytbart bibliotek
- avbrottstoken
- avbokningstoken
- långvarig uppgift
- avbryt uppgift
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Gör långvariga uppgifter avbrytbara med Aspose.Slides för .NET. Avbryt rendering och konverteringar för PowerPoint och OpenDocument på ett säkert sätt, med exempel."
---
## **Översikt**

Aspose.Slides för .NET tillhandahåller en avbrytbar bearbetningsmekanism för långvariga presentationsuppgifter, såsom deserialisering, serialisering och rendering. Denna mekanism är baserad på klasserna `InterruptionToken` och `InterruptionTokenSource`.

Ett `InterruptionToken` kan tilldelas `LoadOptions` och skickas till `Presentation`‑konstruktorn. När `InterruptionTokenSource.Interrupt()` anropas avbryts den associerade långvariga uppgiften. Artikeln visar också hur man använder denna mekanism tillsammans med standard‑.NET `CancellationToken` genom att övervaka avbokningsförfrågningar och anropa `Interrupt()` när avbokning begärs.

## **Avbrytbar Bibliotek**

I [Aspose.Slides 18.4](https://releases.aspose.com/slides/sv/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/), introducerade vi klasserna [InterruptionToken](https://reference.aspose.com/slides/sv/net/aspose.slides/interruptiontoken/) och [InterruptionTokenSource](https://reference.aspose.com/slides/sv/net/aspose.slides/interruptiontokensource/). De låter dig avbryta långvariga uppgifter som deserialisering, serialisering och rendering.

- [InterruptionTokenSource] är källan till token(en) som skickas till [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/sv/net/aspose.slides/iloadoptions/interruptiontoken/).
- När [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/sv/net/aspose.slides/iloadoptions/interruptiontoken/) är satt och instansen av [LoadOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/) skickas till [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑konstruktorn, avbryter ett anrop av [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/sv/net/aspose.slides/interruptiontokensource/interrupt/) alla långvariga uppgifter som är associerade med den [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).

Följande kodsnutt demonstrerar hur man avbryter en pågående uppgift:

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
    Run(action, tokenSource.Token); // kör åtgärden i en separat tråd
    Thread.Sleep(10000);            // tidsgräns
    tokenSource.Interrupt();        // stoppa konverteringen
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken och avbrytbar Bibliotek**

När du behöver använda en [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) tillsammans med Aspose.Slides avbrytbara bibliotek, omslut [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑bearbetningen och avbryt [InterruptionToken](https://reference.aspose.com/slides/sv/net/aspose.slides/interruptiontoken/) när [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) är `true`.

Den här C#‑koden demonstrerar operationen:

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
    Task task = Run(action, tokenSource.Token); // kör åtgärden i en separat tråd

    while (!task.Wait(500)) // vänta och övervaka om cancellationToken.IsCancellationRequested är satt
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // avbryt Presentation-bearbetning
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

## **Vanliga frågor**

**Vad är syftet med Aspose.Slides avbrytbiblioteket?**

Det tillhandahåller en mekanism för att avbryta långvariga operationer — såsom inläsning, sparande eller rendering av presentationer — innan de slutförs. Detta är användbart när bearbetningstiden måste begränsas eller uppgiften inte längre behövs.

**Vad är skillnaden mellan [InterruptionToken](https://reference.aspose.com/slides/sv/net/aspose.slides/interruptiontoken/) och [InterruptionTokenSource](https://reference.aspose.com/slides/sv/net/aspose.slides/iinterruptiontokensource/)?**

- `InterruptionToken` skickas till Aspose.Slides‑API:et och kontrolleras under långvariga operationer.
- `InterruptionTokenSource` används i din kod för att skapa token och utlösa avbrott genom att anropa `Interrupt()`.

**Kan jag använda .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) med avbrytbiblioteket?**

Ja. Du kan övervaka [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) i din applikationslogik och anropa [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/sv/net/aspose.slides/iinterruptiontokensource/interrupt/) när avbokning begärs. Detta gör att Aspose.Slides kan integreras med standard‑.NET avbokningsarbetsflöden.

**Vilka uppgifter kan avbrytas?**

Alla Aspose.Slides‑uppgifter som accepterar ett [InterruptionToken](https://reference.aspose.com/slides/sv/net/aspose.slides/interruptiontoken/) — exempelvis inläsning av en presentation med `Presentation(path, loadOptions)` eller sparande med `Presentation.Save(...)` — kan avbrytas.

**Sker avbrottet omedelbart?**

Nej. Avbrott är samarbetsbaserat: operationen kontrollerar token periodiskt och stoppar så snart den upptäcker att [Interrupt()](https://reference.aspose.com/slides/sv/net/aspose.slides/iinterruptiontokensource/interrupt/) har anropats.

**Vad händer om jag anropar [Interrupt()](https://reference.aspose.com/slides/sv/net/aspose.slides/iinterruptiontokensource/interrupt/) efter att en uppgift redan har slutförts?**

Ingenting — anropet har ingen effekt om den motsvarande uppgiften redan har slutförts.

**Kan jag återanvända samma [InterruptionTokenSource](https://reference.aspose.com/slides/sv/net/aspose.slides/iinterruptiontokensource/) för flera uppgifter?**

Ja — men efter att du har anropat [Interrupt()](https://reference.aspose.com/slides/sv/net/aspose.slides/iinterruptiontokensource/interrupt/) på den källan kommer alla uppgifter som använder dess token att avbrytas. Använd separata token‑källor för att hantera uppgifter oberoende.