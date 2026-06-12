---
title: Beheer diavoorstelling in .NET
linktitle: Diavoorstelling
type: docs
weight: 90
url: /nl/net/manage-slide-show/
keywords:
- weergavetype
- gepresenteerd door spreker
- bekeken door individuele gebruiker
- bekeken op kiosk
- weergaveopties
- herhaal continu
- weergave zonder vertelling
- weergave zonder animatie
- penkleur
- dia's weergeven
- aangepaste weergave
- dia's vooruit
- handmatig
- met timings
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u diavoorstellingen beheert in Aspose.Slides voor .NET. Beheer dia-overgangen, timings en meer in PPT-, PPTX- en ODP-formaten met gemak."
---
## **Inleiding**

In Microsoft PowerPoint zijn de **Slide Show**-instellingen een belangrijk hulpmiddel voor het voorbereiden en geven van professionele presentaties. Een van de belangrijkste functies in deze sectie is **Set Up Show**, waarmee u uw presentatie kunt afstemmen op specifieke omstandigheden en doelgroepen, waardoor flexibiliteit en gemak worden gegarandeerd. Met deze functie kunt u het type weergave kiezen (bijv. gepresenteerd door een spreker, bekeken door een individuele gebruiker of bekeken op een kiosk), herhalen in‑en‑uit schakelen, specifieke dia's selecteren voor weergave en timings gebruiken. Deze stap in de voorbereiding is cruciaal om uw presentatie effectiever en professioneler te maken.

`SlideShowSettings` is een eigenschap van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse, van het type [SlideShowSettings](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slideshowsettings/), waarmee u de diavoorstelling‑instellingen in een PowerPoint‑presentatie kunt beheren. In dit artikel bekijken we hoe u deze eigenschap kunt gebruiken om verschillende aspecten van de diavoorstelling‑instellingen te configureren en te beheersen. 

## **Selecteer weergavetype**

`SlideShowSettings.SlideShowType` bepaalt het type diavoorstelling, dat een instantie kan zijn van de volgende klassen: [PresentedBySpeaker](https://reference.aspose.com/slides/nl/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/nl/net/aspose.slides/browsedbyindividual/), of [BrowsedAtKiosk](https://reference.aspose.com/slides/nl/net/aspose.slides/browsedatkiosk/). Door deze eigenschap te gebruiken, kunt u de presentatie aanpassen aan verschillende gebruiksscenario’s, zoals geautomatiseerde kiosken of handmatige presentaties.

De code‑voorbeeld hieronder maakt een nieuwe presentatie en stelt het weergavetype in op “Browsed by an individual” zonder de schuifbalk weer te geven.

```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Schakel weergaveopties in**

`SlideShowSettings.Loop` bepaalt of de diavoorstelling moet herhalen in een lus totdat deze handmatig wordt gestopt. Dit is handig voor geautomatiseerde presentaties die continu moeten draaien. `SlideShowSettings.ShowNarration` bepaalt of stem‑vertellingen moeten worden afgespeeld tijdens de diavoorstelling. Het is bruikbaar voor geautomatiseerde presentaties met stem‑begeleiding voor het publiek. `SlideShowSettings.ShowAnimation` bepaalt of animaties die aan dia‑objecten zijn toegevoegd moeten worden afgespeeld. Dit is nuttig om het volledige visuele effect van de presentatie te leveren.

De volgende code‑voorbeeld maakt een nieuwe presentatie en laat de diavoorstelling in een lus draaien.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Selecteer dia's om weer te geven**

`SlideShowSettings.Slides`‑eigenschap stelt u in staat een bereik van dia's te selecteren die tijdens de presentatie moeten worden getoond. Dit is handig wanneer u slechts een deel van de presentatie wilt laten zien in plaats van alle dia's. Het onderstaande code‑voorbeeld maakt een nieuwe presentatie en stelt het dia‑bereik in op weergave van dia’s `2` tot `9`.

```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Gebruik automatische doorloop van dia's**

`SlideShowSettings.UseTimings`‑eigenschap maakt het mogelijk om het gebruik van vooraf ingestelde timings voor elke dia in of uit te schakelen. Dit is nuttig om dia's automatisch te laten zien met vooraf gedefinieerde weergaveduur. Het code‑voorbeeld hieronder maakt een nieuwe presentatie en schakelt het gebruik van timings uit.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Media‑bedieningen weergeven**

`SlideShowSettings.ShowMediaControls`‑eigenschap bepaalt of media‑bedieningen (zoals afspelen, pauzeren en stoppen) moeten worden weergegeven tijdens de diavoorstelling wanneer multimedia‑inhoud (bijv. video of audio) wordt afgespeeld. Dit is handig wanneer u de presentator controle wilt geven over de weergave van media tijdens de presentatie.

De volgende code‑voorbeeld maakt een nieuwe presentatie en schakelt media‑bedieningen in.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Kan ik een presentatie opslaan zodat deze direct in de diavoorstellingsmodus opent?**

Ja. Sla het bestand op als PPSX of PPSM; deze formaten starten direct in de diavoorstelling wanneer ze in PowerPoint worden geopend. In Aspose.Slides kiest u het overeenkomstige opslagformaat [during export](/slides/nl/net/save-presentation/).

**Kan ik individuele dia's uit de show uitsluiten zonder ze uit het bestand te verwijderen?**

Ja. Markeer een dia als [Hidden](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/hidden/). Verborgen dia's blijven in de presentatie, maar worden niet getoond tijdens de diavoorstelling.

**Kan Aspose.Slides een diavoorstelling afspelen of een live presentatie op het scherm besturen?**

Nee. Aspose.Slides bewerkt, analyseert en converteert presentatiebestanden; de daadwerkelijke weergave wordt verzorgd door een viewer‑applicatie zoals PowerPoint.