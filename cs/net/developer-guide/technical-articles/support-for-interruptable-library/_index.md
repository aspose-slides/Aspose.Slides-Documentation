---
title: Přerušení dlouho běžících operací prezentace v .NET
linktitle: Přerušení operací prezentace
type: docs
weight: 150
url: /cs/net/support-for-interruptable-library/
keywords:
- přerušitelné operace
- token přerušení
- token zrušení
- dlouho běžící úloha
- přerušit úlohu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak zrušit dlouho běžící operace prezentace v Aspose.Slides pro .NET a vrátit částečný výsledek při exportu snímků v smyčce."
---
## **Přehled**

Aspose.Slides pro .NET může přerušovat dlouho běžící operace, jako je načítání, ukládání a vykreslování prezentací. Vaše aplikace může použít stejný token přerušení k zastavení smyčky předtím, než začne zpracovávat další snímek.

## **Přerušení operace prezentace**

Vytvořte [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), přiřaďte jeho [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) k [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/), a předajte možnosti načítání konstruktoru [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Chcete‑li požádat o zrušení, zavolejte [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) na zdroj. Přerušitelná operace se zastaví, jakmile zaznamená požadavek.

Příklad spustí konverzi `sample.pptx` na `sample.ppt` v úkolu na pozadí a po 10 sekundách požádá o zrušení. Pokud konverze skončí dříve, výstup je již kompletní.

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
    Run(action, tokenSource.Token); // spustí akci v samostatném vlákně
    Thread.Sleep(10000);            // časový limit
    tokenSource.Interrupt();        // zastaví konverzi
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **Propojení zrušení .NET s Aspose.Slides**

Pokud vaše aplikace používá .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken), předejte její požadavek na zrušení Aspose.Slides. Příklad spustí export `sample.pptx` do `sample.pdf` a nastaví časový limit 20 sekund. Během exportu kontroluje [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) každých 500 milisekund. Když se vlastnost změní na `true`, zavolá [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/).

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
    Task task = Run(action, tokenSource.Token); // spustí akci v samostatném vlákně

    while (!task.Wait(500)) // čeká a monitoruje, zda je nastaveno cancellationToken.IsCancellationRequested
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // přeruší zpracování prezentace
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

## **Zastavit před zpracováním dalšího snímku**

Použijte stejný [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) pro prezentaci i smyčku, která exportuje její snímky. Před zahájením každého exportu zkontrolujte [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/). Pokud volající může použít částečný výsledek, vraťte čísla snímků pro exporty, které byly úspěšně dokončeny.

Použijte prezentaci pojmenovanou `sample.pptx` s alespoň dvěma snímky. Příklad požádá o zrušení okamžitě po zaznamenání prvního úspěšného exportu.

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

Příklad zapíše `slide-1.pdf` a vytiskne `Starting slide 1` následované `Completed: [1]`. Smyčka zaznamená požadavek před zahájením snímku 2. Pokud by zrušení místo toho přerušilo [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) během exportu, blok `catch` ukončí smyčku předtím, než kód zaznamená aktuální snímek jako dokončený.

Pokud volající potřebuje zrušení ošetřit, nahraďte kontrolu `if` a jeho `break` na začátku smyčky voláním [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) na tokenu. Odstraňte blok `try`/`catch` okolo exportu, aby zrušení během ukládání také dosáhlo volajícího. Se stejným vstupem příklad vytiskne pouze `Starting slide 1` a zapíše `slide-1.pdf`. Na začátku druhé iterace volající obdrží [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) před zahájením exportu. Metoda nevrací žádný seznam.

## **Často kladené otázky**

**Kdy bych měl požádat o zrušení?**

Požádejte o zrušení, když operace překročí váš časový limit nebo když vaše aplikace již výsledek nepotřebuje.

**Jaký je rozdíl mezi [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Zdroj umožňuje vaší aplikaci požádat o zrušení. Token umožňuje Aspose.Slides i vaší aplikaci kontrolovat tento požadavek.

**Mohu použít .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) s Aspose.Slides?**

Ano. Když váš .NET token signalizuje zrušení, zavolejte [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) na zdroj spojený s prezentací.

**Které operace mohu přerušit?**

Můžete přerušit načítání, ukládání a vykreslování. Předajte token konstruktoru [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) přes [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/). Prezentace pak může během následujících operací, například [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), sledovat zrušení.

**Zastaví se operace okamžitě?**

Zrušení je kooperativní. Operace periodicky kontroluje token a zastaví se, jakmile zaznamená požadavek.

**Co se stane, když zavolám [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) po dokončení operace?**

Dokončená operace si uchová svůj výsledek.

**Mohou více operací sdílet [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Ano. Zavolání [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) požaduje zrušení pro každou operaci, která používá token z tohoto zdroje. Použijte samostatný zdroj pro každou operaci, kterou chcete rušit nezávisle.