---
title: Onderbreek langdurige presentatiebewerkingen in .NET
linktitle: Onderbreek presentatiebewerkingen
type: docs
weight: 150
url: /nl/net/support-for-interruptable-library/
keywords:
- onderbreekbare bewerkingen
- onderbrekingstoken
- annuleringstoken
- langdurige taak
- onderbreek taak
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u langdurige presentatiebewerkingen in Aspose.Slides voor .NET kunt annuleren en een gedeeltelijk resultaat kunt retourneren bij het exporteren van dia's in een lus."
---
## **Overzicht**

Aspose.Slides for .NET kan langdurige bewerkingen zoals het laden, opslaan en renderen van presentaties onderbreken. Uw applicatie kan dezelfde interruption‑token gebruiken om een lus te stoppen voordat deze de volgende dia verwerkt.

## **Een presentatiebewerking onderbreken**

Maak een [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), wijs de [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) toe aan [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/) en geef de load‑opties door aan de [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Om een annulering aan te vragen, roep [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) aan op de bron. Een onderbreekbare bewerking stopt wanneer ze het verzoek opmerkt.

Het voorbeeld start met het converteren van `sample.pptx` naar `sample.ppt` in een achtergrondtaak en vraagt na 10 seconden om annulering. Als de conversie eerder klaar is, is de uitvoer al voltooid.

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
    Run(action, tokenSource.Token); // voer de actie uit in een aparte thread
    Thread.Sleep(10000);            // tijdslimiet
    tokenSource.Interrupt();        // stop de conversie
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET‑annulering koppelen aan Aspose.Slides**

Als uw applicatie een .NET‑[CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) gebruikt, stuur dan het annuleringsverzoek door naar Aspose.Slides. Het voorbeeld start met het exporteren van `sample.pptx` naar `sample.pdf` en stelt een timeout van 20 seconden in. Terwijl de export loopt, controleert het elke 500 milliseconden [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested). Zodra de eigenschap `true` wordt, wordt [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) aangeroepen.

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
    Task task = Run(action, tokenSource.Token); // voer de actie uit in een aparte thread

    while (!task.Wait(500)) // wacht en controleer of cancellationToken.IsCancellationRequested is gezet
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // onderbreek de verwerking van de presentatie
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

## **Stoppen voordat de volgende dia verwerkt wordt**

Gebruik dezelfde [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) voor zowel de presentatie als de lus die de dia’s exporteert. Controleer [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) voordat elke export gestart wordt. Indien de aanroeper een gedeeltelijk resultaat kan gebruiken, geef dan de dia‑nummers terug voor de exporten die succesvol voltooid zijn.

Gebruik een presentatie met de naam `sample.pptx` die minimaal twee dia’s bevat. Het voorbeeld vraagt direct na de eerste geslaagde export om annulering.

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

Het voorbeeld schrijft `slide-1.pdf` en toont `Starting slide 1` gevolgd door `Completed: [1]`. De lus ziet het verzoek voordat dia 2 gestart wordt. Als annulering in plaats daarvan [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) onderbreekt tijdens een export, verlaat de `catch`‑blok de lus voordat de code de huidige dia als voltooid registreert.

Indien de aanroeper annulering moet afhandelen, vervang dan de `if`‑controle en de `break` bovenaan de lus door een aanroep van [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) op de token. Verwijder de `try`/`catch` rond de export zodat annulering tijdens een opslaan eveneens de aanroeper bereikt. Met dezelfde invoer toont het voorbeeld alleen `Starting slide 1` en schrijft `slide-1.pdf`. Aan het begin van de tweede iteratie ontvangt de aanroeper een [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) voordat de export start. De methode retourneert geen lijst.

## **FAQ**

**Wanneer moet ik een annulering aanvragen?**

Vraag een annulering aan wanneer een bewerking uw tijdslimiet overschrijdt of wanneer uw applicatie het resultaat niet meer nodig heeft.

**Wat is het verschil tussen [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) en [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

De bron laat uw applicatie een annulering verzoeken. De token laat Aspose.Slides en uw applicatie dat verzoek controleren.

**Kan ik een .NET‑[CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) gebruiken met Aspose.Slides?**

Ja. Wanneer uw .NET‑token annulering signaleert, roep dan [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) aan op de bron die bij de presentatie hoort.

**Welke bewerkingen kan ik onderbreken?**

U kunt het laden, opslaan en renderen onderbreken. Geef de token door aan de [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) via [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/). De presentatie kan dan tijdens latere bewerkingen zoals [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) annulering waarnemen.

**Stopt een bewerking onmiddellijk?**

Annulering is coöperatief. Een bewerking controleert periodiek de token en stopt wanneer ze het verzoek opmerkt.

**Wat gebeurt er als ik [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) roep nadat een bewerking is voltooid?**

De voltooide bewerking behoudt haar resultaat.

**Kunnen meerdere bewerkingen een [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) delen?**

Ja. Het aanroepen van [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) vraagt annulering voor elke bewerking die een token van die bron gebruikt. Gebruik een aparte bron voor elke bewerking die u onafhankelijk wilt annuleren.