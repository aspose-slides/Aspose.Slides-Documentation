---
title: Ondersteuning voor onderbreekbare bibliotheek
type: docs
weight: 150
url: /nl/net/support-for-interruptable-library/
keywords:
- onderbreekbare bibliotheek
- onderbrekingstoken
- annuleringstoken
- langdurige taak
- taak onderbreken
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak langdurige taken annuleerbaar met Aspose.Slides voor .NET. Onderbreek veilig het renderen en de conversies voor PowerPoint en OpenDocument, met voorbeelden."
---
## **Overzicht**

Aspose.Slides voor .NET biedt een onderbreekbare verwerkingsmechanisme voor langdurige presentatietaken, zoals deserialisatie, serialisatie en weergave. Dit mechanisme is gebaseerd op de `InterruptionToken`‑ en `InterruptionTokenSource`‑klassen.

Een `InterruptionToken` kan worden toegewezen aan `LoadOptions` en doorgegeven aan de `Presentation`‑constructor. Wanneer `InterruptionTokenSource.Interrupt()` wordt aangeroepen, wordt de bijbehorende langdurige taak onderbroken. Het artikel toont ook hoe dit mechanisme samen met de standaard .NET `CancellationToken` kan worden gebruikt door annuleringsverzoeken te monitoren en `Interrupt()` aan te roepen wanneer annulering wordt gevraagd.

## **Onderbreekbare bibliotheek**

In [Aspose.Slides 18.4](https://releases.aspose.com/slides/nl/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/) hebben we de [InterruptionToken](https://reference.aspose.com/slides/nl/net/aspose.slides/interruptiontoken/)‑ en [InterruptionTokenSource](https://reference.aspose.com/slides/nl/net/aspose.slides/interruptiontokensource/)‑klassen geïntroduceerd. Ze stellen u in staat om langdurige taken zoals deserialisatie, serialisatie en weergave te onderbreken.

- [InterruptionTokenSource](https://reference.aspose.com/slides/nl/net/aspose.slides/interruptiontokensource/) is de bron van de token(s) die worden doorgegeven aan [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/nl/net/aspose.slides/iloadoptions/interruptiontoken/).
- Wanneer [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/nl/net/aspose.slides/iloadoptions/interruptiontoken/) is ingesteld en de [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/)‑instantie wordt doorgegeven aan de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑constructor, onderbreekt het aanroepen van [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/nl/net/aspose.slides/interruptiontokensource/interrupt/) elke langdurige taak die aan die [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) is gekoppeld.

De volgende code‑fragment toont hoe een draaiende taak wordt onderbroken:

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
    Run(action, tokenSource.Token); // voer de actie uit in een aparte thread
    Thread.Sleep(10000);            // time-out
    tokenSource.Interrupt();        // stop de conversie
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken en Onderbreekbare bibliotheek**

Wanneer u een [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) naast de Aspose.Slides‑onderbreekbare bibliotheek wilt gebruiken, wikkel dan de verwerking van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) en onderbreek de [InterruptionToken](https://reference.aspose.com/slides/nl/net/aspose.slides/interruptiontoken/) wanneer [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) `true` is.

Deze C#‑code demonstreert de werking:

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
    Task task = Run(action, tokenSource.Token); // voer de actie uit in een aparte thread

    while (!task.Wait(500)) // wacht en controleer of cancellationToken.IsCancellationRequested is ingesteld
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

## **FAQ**

**Wat is het doel van de Aspose.Slides‑onderbreekbare bibliotheek?**

Het biedt een mechanisme om langdurige bewerkingen—zoals het laden, opslaan of weergeven van presentaties—te onderbreken voordat ze zijn voltooid. Dit is nuttig wanneer de verwerkingstijd beperkt moet worden of de taak niet langer nodig is.

**Wat is het verschil tussen [InterruptionToken](https://reference.aspose.com/slides/nl/net/aspose.slides/interruptiontoken/) en [InterruptionTokenSource](https://reference.aspose.com/slides/nl/net/aspose.slides/iinterruptiontokensource/)?**

- `InterruptionToken` wordt aan de Aspose.Slides‑API doorgegeven en tijdens langdurige bewerkingen gecontroleerd.
- `InterruptionTokenSource` wordt in uw code gebruikt om tokens te maken en onderbrekingen te activeren door `Interrupt()` aan te roepen.

**Kan ik .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) gebruiken met de onderbreekbare bibliotheek?**

Ja. U kunt de [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) in uw toepassingslogica monitoren en [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/nl/net/aspose.slides/iinterruptiontokensource/interrupt/) aanroepen wanneer annulering wordt gevraagd. Dit maakt het mogelijk dat Aspose.Slides integreert met de standaard .NET‑annuleringsworkflows.

**Welke taken kunnen worden onderbroken?**

Elke Aspose.Slides‑taak die een [InterruptionToken](https://reference.aspose.com/slides/nl/net/aspose.slides/interruptiontoken/) accepteert—zoals het laden van een presentatie met `Presentation(path, loadOptions)` of het opslaan met `Presentation.Save(...)`—kan worden onderbroken.

**Wordt onderbreking onmiddellijk uitgevoerd?**

Nee. Onderbreking is coöperatief: de bewerking controleert periodiek de token en stopt zodra [Interrupt()](https://reference.aspose.com/slides/nl/net/aspose.slides/iinterruptiontokensource/interrupt/) is aangeroepen.

**Wat gebeurt er als ik [Interrupt()](https://reference.aspose.com/slides/nl/net/aspose.slides/iinterruptiontokensource/interrupt/) aanroep nadat een taak al is voltooid?**

Niets—de oproep heeft geen effect als de bijbehorende taak reeds is afgerond.

**Kan ik dezelfde [InterruptionTokenSource](https://reference.aspose.com/slides/nl/net/aspose.slides/iinterruptiontokensource/) hergebruiken voor meerdere taken?**

Ja—maar nadat u [Interrupt()](https://reference.aspose.com/slides/nl/net/aspose.slides/iinterruptiontokensource/interrupt/) op die bron hebt aangeroepen, worden alle taken die zijn tokens gebruiken onderbroken. Gebruik aparte token‑bronnen om taken onafhankelijk te beheren.