---
title: Beheer diavoorstelling in Java
linktitle: Diavoorstelling
type: docs
weight: 90
url: /nl/java/manage-slide-show/
keywords:
- presentatietype
- gepresenteerd door spreker
- bekeken door individuele gebruiker
- bekeken in kiosk
- showopties
- herhalen continu
- weergeven zonder narratie
- weergeven zonder animatie
- penkleur
- dia's weergeven
- aangepaste show
- dia's vooruit
- handmatig
- met timings
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u diavoorstellingen beheert in Aspose.Slides voor Java. Beheer dia-overgangen, timings en meer in de formaten PPT, PPTX en ODP met gemak."
---
## **Inleiding**

In Microsoft PowerPoint zijn de **Slide Show**-instellingen een belangrijk hulpmiddel voor het voorbereiden en geven van professionele presentaties. Een van de belangrijkste functies in dit gedeelte is **Set Up Show**, waarmee u uw presentatie kunt afstemmen op specifieke omstandigheden en doelgroepen, waardoor flexibiliteit en gemak worden gegarandeerd. Met deze functie kunt u het type voorstelling selecteren (bijv. gepresenteerd door een spreker, bekeken door een individuele gebruiker, of bekeken in een kiosk), de lus inschakelen of uitschakelen, specifieke dia’s kiezen om weer te geven, en timings gebruiken. Deze stap in de voorbereiding is cruciaal om uw presentatie effectiever en professioneler te maken.

`getSlideShowSettings` is een methode van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse die een object van type [SlideShowSettings](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slideshowsettings/) retourneert, waarmee u de slide‑show‑instellingen in een PowerPoint‑presentatie kunt beheren. In dit artikel bekijken we hoe u deze methode kunt gebruiken om verschillende aspecten van de slide‑show‑instellingen te configureren en te beheersen. 

## **Selecteer showtype**

`SlideShowSettings.setSlideShowType` definieert het type slide‑show, dat een instantie kan zijn van de volgende klassen: [PresentedBySpeaker](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/nl/java/com.aspose.slides/browsedbyindividual/), of [BrowsedAtKiosk](https://reference.aspose.com/slides/nl/java/com.aspose.slides/browsedatkiosk/). Met deze methode kunt u de presentatie aanpassen aan verschillende gebruiksscenario’s, zoals geautomatiseerde kiosken of handmatige presentaties.

De code‑voorbeeld hieronder maakt een nieuwe presentatie en stelt het showtype in op "Browsed by an individual" zonder de schuifbalk te tonen.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Schakel showopties in**

`SlideShowSettings.setLoop` bepaalt of de slide‑show moet herhalen in een lus totdat deze handmatig wordt gestopt. Dit is nuttig voor geautomatiseerde presentaties die continu moeten draaien. `SlideShowSettings.setShowNarration` bepaalt of voice‑narraties moeten worden afgespeeld tijdens de slide‑show. Het is handig voor geautomatiseerde presentaties die spraaginstructies voor het publiek bevatten. `SlideShowSettings.setShowAnimation` bepaalt of animaties die aan dia‑objecten zijn toegevoegd moeten worden afgespeeld. Dit is bruikbaar om het volledige visuele effect van de presentatie te bieden.

De volgende code‑voorbeeld maakt een nieuwe presentatie en laat de slide‑show in een lus draaien.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Selecteer dia’s om weer te geven**

`SlideShowSettings.setSlides`‑methode maakt het mogelijk een bereik van dia’s te kiezen dat tijdens de presentatie getoond moet worden. Dit is handig wanneer u slechts een deel van de presentatie wilt laten zien in plaats van alle dia’s. De volgende code‑voorbeeld maakt een nieuwe presentatie en stelt het dia‑bereik in op dia’s `2` tot en met `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Gebruik automatische dia‑overgangen**

`SlideShowSettings.setUseTimings`‑methode maakt het mogelijk het gebruik van vooraf ingestelde timings voor elke dia in te schakelen of uit te schakelen. Dit is nuttig om dia’s automatisch te laten verschijnen met vooraf gedefinieerde weergaveduur. Het code‑voorbeeld hieronder maakt een nieuwe presentatie en schakelt het gebruik van timings uit.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Toon mediabedieningen**

`SlideShowSettings.setShowMediaControls`‑methode bepaalt of mediabedieningen (zoals afspelen, pauzeren en stoppen) moeten worden weergegeven tijdens de slide‑show wanneer multimedia‑inhoud (bijv. video of audio) wordt afgespeeld. Dit is handig wanneer u de presentator controle wilt geven over de weergave van media tijdens de presentatie.

De volgende code‑voorbeeld maakt een nieuwe presentatie en schakelt weergeven van mediabedieningen in.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Kan ik een presentatie opslaan zodat deze direct in de slide‑show‑modus opent?**

Ja. Sla het bestand op als PPSX of PPSM; deze formaten starten direct in slide‑show wanneer ze in PowerPoint worden geopend. In Aspose.Slides kiest u het overeenkomstige opslagformaat [tijdens export](/slides/nl/java/save-presentation/).

**Kan ik individuele dia’s uit de show uitsluiten zonder ze uit het bestand te verwijderen?**

Ja. Markeer een dia als [hidden](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#setHidden-boolean-). Verborgen dia’s blijven in de presentatie, maar worden niet getoond tijdens de slide‑show.

**Kan Aspose.Slides een slide‑show afspelen of een live‑presentatie op het scherm besturen?**

Nee. Aspose.Slides bewerkt, analyseert en converteert presentatiebestanden; het daadwerkelijke afspelen wordt afgehandeld door een viewer‑applicatie zoals PowerPoint.