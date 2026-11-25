---
title: Hosszú futású prezentációs műveletek megszakítása .NET-ben
linktitle: Prezentációs műveletek megszakítása
type: docs
weight: 150
url: /hu/net/support-for-interruptable-library/
keywords:
- megszakítható műveletek
- interrupciós token
- leállítási token
- hosszú futású feladat
- feladat megszakítása
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan lehet megszakítani a hosszú futású prezentációs műveleteket az Aspose.Slides for .NET-ben, és hogyan adhat vissza részleges eredményt a dia exportálásakor egy ciklusban."
---
## **Áttekintés**

Az Aspose.Slides for .NET képes megszakítani a hosszú futású műveleteket, például a prezentációk betöltését, mentését és renderelését. Az alkalmazása ugyanazt az interrupciós tokent használhatja a ciklus leállításához, mielőtt a következő diát feldolgozná.

## **Megszakítani egy prezentáció műveletét**

Hozzon létre egy [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), rendelje a [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) értékét a [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/)-hez, és adja át a betöltési beállításokat a [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)‑nek. A leállítás kéréséhez hívja meg a [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) metódust a forráson. Egy megszakítható művelet leáll, amikor észleli a kérést.

A példa a `sample.pptx` fájlt háttérfeladatban `sample.ppt`‑re konvertálja, és 10 másodperc után kéri a leállítást. Ha a konvertálás korábban befejeződik, a kimenet már készen van.

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
    Run(action, tokenSource.Token); // futtassa a műveletet egy külön szálon
    Thread.Sleep(10000);            // időkorlát
    tokenSource.Interrupt();        // állítsa le a konverziót
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **A .NET leállítás összekapcsolása az Aspose.Slides‑szal**

Ha az alkalmazása .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)‑t használ, továbbítsa annak leállítási kérését az Aspose.Slides felé. A példa a `sample.pptx`‑et `sample.pdf`‑re exportálja, és 20 másodperces időkorlátot állít be. Az exportálás közben 500 milliszekundumonként ellenőrzi a [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) értékét. Amikor a tulajdonság `true`‑ra vált, meghívja a [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) metódust.

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
    Task task = Run(action, tokenSource.Token); // futtassa a műveletet egy külön szálon

    while (!task.Wait(500)) // várjon és figyelje, hogy a cancellationToken.IsCancellationRequested be van-e állítva
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // szakítsa meg a Presentation feldolgozását
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

## **Megállás a következő dia feldolgozása előtt**

Használja ugyanazt a [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/)‑t a prezentációhoz és a diaexportáló ciklushoz. Minden exportálás előtt ellenőrizze a [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) állapotot. Ha a hívó részleges eredményt is elfogadhat, adja vissza azoknak az exportálásoknak a dia számait, amelyek sikeresen befejeződtek.

A példa egy legalább két dia‑val rendelkező `sample.pptx` prezentációt használ. A leállítási kérés már az első sikeres exportálás után azonnal megtörténik.

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

A példa a `slide-1.pdf`‑t írja, és a `Starting slide 1` után kiírja a `Completed: [1]` üzenetet. A ciklus a második dia előtt észleli a leállítási kérést. Ha a leállítás a [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) közben történik, a `catch` blokk kilép a ciklusból, mielőtt a jelenlegi dia befejezettként lenne rögzítve.

Ha a hívónak kezelnije kell a leállítást, cserélje le a `if` ellenőrzést és a `break`‑et a ciklus tetején egy [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) hívásra a tokenen. Távolítsa el a `try`/`catch`‑et az export körül, hogy a mentés közbeni leállítás is eljusson a hívóhoz. Ugyanazzal a bemenettel a példa csak a `Starting slide 1` üzenetet írja ki, és csak a `slide-1.pdf`‑t hozza létre. A második iteráció elején a hívó egy [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception)‑t kap, mielőtt az exportálás elkezdődne. A metódus ilyenkor nem ad vissza listát.

## **Gyakran Ismételt Kérdések**

**Mikor kell kérni a leállítást?**

A leállítást akkor kérje, ha egy művelet meghaladja az időkorlátját, vagy ha az alkalmazása már nem igényli az eredményt.

**Mi a különbség a [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) és a [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) között?**

A forrás teszi lehetővé, hogy az alkalmazása leállítási kérést indítson. A token pedig azt biztosítja, hogy az Aspose.Slides és az alkalmazása ellenőrizhesse ezt a kérést.

**Használhatok .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken)‑t az Aspose.Slides‑szel?**

Igen. Amikor a .NET token leállítást jelez, hívja meg a [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) metódust a prezentációval összekapcsolt forráson.

**Milyen műveleteket szakíthatok meg?**

A betöltést, mentést és renderelést szakíthatja meg. Adja át a tokent a [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)‑nek a [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/) segítségével. A prezentáció ezután leállítási kérelmet észlelhet olyan későbbi műveletek során, mint a [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/).

**Azonnal leáll a művelet?**

A leállítás együttműködésen alapul. A művelet időközönként ellenőrzi a tokent, és akkor áll le, amikor észleli a kérést.

**Mi történik, ha a [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) hívását a művelet befejezése után hajtom végre?**

A már befejeződött művelet megtartja az eredményét.

**Több művelet is használhatja ugyanazt az [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)-t?**

Igen. A [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) hívása minden olyan művelet leállítását kéri, amely az adott forrás tokenjét használja. Ha külön-külön szeretne műveleteket leállítani, használjon külön forrást minden egyes művelethez.