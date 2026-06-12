---
title: Presentaties maken in .NET
linktitle: Presentatie maken
type: docs
weight: 10
url: /nl/net/create-presentation/
keywords:
- presentatie maken
- nieuwe presentatie
- PPT maken
- nieuwe PPT
- PPTX maken
- nieuwe PPTX
- ODP maken
- nieuwe ODP
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak presentaties in .NET met Aspose.Slides — produceer PPT-, PPTX- en ODP-bestanden, profiteer van OpenDocument-ondersteuning, en sla ze programmatisch op voor betrouwbare resultaten."
---
## **Overzicht**

Dit artikel laat zien hoe je een presentatie maakt met Aspose.Slides, eenvoudige inhoud aan een dia toevoegt en het resultaat opslaat als bestand. Het toont ook hoe je een nieuwe presentatie maakt en opslaat, een bestaande presentatie in een ondersteund formaat opent en deze opslaat naar een ander formaat. Daarnaast bevat het een korte FAQ met veelgestelde vragen over formaten, sjablonen, dia-grootte, eenheden, geheugenverbruik, threading, licenties, digitale handtekeningen en VBA-ondersteuning.

## **Maak een PowerPoint-presentatie**
Om een eenvoudige rechte lijn toe te voegen aan een geselecteerde dia van de presentatie, volg je de onderstaande stappen:

1. Maak een instantie van de **Presentation**‑klasse.
1. Verkrijg de referentie van een dia door zijn index te gebruiken.
1. Voeg een AutoShape van het type **Line** toe met de **AddAutoShape**‑methode van het **Shapes**‑object.
1. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een lijn toegevoegd aan de eerste dia van de presentatie.

```c#
// Instantieser een Presentation-object dat een presentatiebestand vertegenwoordigt
using (Presentation presentation = new Presentation())
{
    // Verkrijg de eerste dia
    ISlide slide = presentation.Slides[0];

    // Voeg een autoshape van het type line toe
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## **Maak en sla een presentatie op**

<a name="csharp-create-save-presentation"><strong>Stappen: Maak en sla een presentatie op in C#</strong></a>

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
2. Sla _Presentatie_ op in elk formaat dat wordt ondersteund door [SaveFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveformat/)

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Openen en opslaan van een presentatie**

<a name="csharp-open-save-presentation"><strong>Stappen: Openen en opslaan van een presentatie in C#</strong></a>

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse met elk formaat, bijv. PPT, PPTX, ODP, enz.
2. Sla _Presentatie_ op in elk formaat dat wordt ondersteund door [SaveFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveformat/)

```c#
// Laad elk ondersteund bestand in Presentation, bijv. ppt, pptx, odp, enz.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **FAQ**

**In welke formaten kan ik een nieuwe presentatie opslaan?**

Je kunt opslaan naar [PPTX, PPT en ODP](/slides/nl/net/save-presentation/), en exporteren naar [PDF](/slides/nl/net/convert-powerpoint-to-pdf/), [XPS](/slides/nl/net/convert-powerpoint-to-xps/), [HTML](/slides/nl/net/convert-powerpoint-to-html/), [SVG](/slides/nl/net/convert-powerpoint-to-png/) en [afbeeldingen](/slides/nl/net/convert-powerpoint-to-png/), onder andere.

**Kan ik starten vanuit een sjabloon (POTX/POTM) en opslaan als een gewone PPTX?**

Ja. Laad het sjabloon en sla op naar het gewenste formaat; POTX/POTM/PPTM en soortgelijke formaten [worden ondersteund](/slides/nl/net/supported-file-formats/).

**Hoe regel ik de dia‑grootte/beeldverhouding bij het maken van een presentatie?**

Stel de [dia‑grootte](/slides/nl/net/slide-size/) in (inclusief voorgedefinieerde opties zoals 4:3 en 16:9 of aangepaste afmetingen) en kies hoe de inhoud moet worden geschaald.

**In welke eenheden worden afmetingen en coördinaten gemeten?**

In punten: 1 inch is gelijk aan 72 eenheden.

**Hoe ga ik om met zeer grote presentaties (met veel mediabestanden) om het geheugenverbruik te verminderen?**

Gebruik [BLOB‑beheersstrategieën](/slides/nl/net/manage-blob/), beperk opslag in het geheugen door tijdelijke bestanden te benutten, en geef de voorkeur aan bestandsgebaseerde workflows boven puur in‑memory streams.

**Kan ik presentaties parallel creëren/op slaan?**

Je kunt niet dezelfde [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instantie bewerken vanuit [meerdere threads](/slides/nl/net/multithreading/). Maak aparte, geïsoleerde instanties per thread of proces.

**Hoe verwijder ik het proefwatermerk en de beperkingen?**

[Pas een licentie toe](/slides/nl/net/licensing/) één keer per proces. Het licentie‑XML‑bestand moet onveranderd blijven, en de licentie‑initialisatie moet gesynchroniseerd worden als meerdere threads betrokken zijn.

**Kan ik de PPTX die ik maak digitaal ondertekenen?**

Ja. [Digitale handtekeningen](/slides/nl/net/digital-signature-in-powerpoint/) (toevoegen en verifiëren) worden ondersteund voor presentaties.

**Worden macro's (VBA) ondersteund in gemaakte presentaties?**

Ja. Je kunt [VBA‑projecten creëren/bewerken](/slides/nl/net/presentation-via-vba/) en macro‑geactiveerde bestanden opslaan, zoals PPTM/PPSM.