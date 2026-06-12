---
title: Beheer dia-show in JavaScript
linktitle: Dia-show
type: docs
weight: 90
url: /nl/nodejs-java/manage-slide-show/
keywords:
- showtype
- gepresenteerd door spreker
- bekeken door individu
- bekeken op kiosk
- showopties
- herhaal continu
- show zonder vertelling
- show zonder animatie
- penkleur
- toon dia's
- aangepaste show
- dia's vooruit
- handmatig
- met timings
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer dia-shows in JavaScript met Aspose.Slides voor Node.js. Beheer dia-overgangen, timings en meer in PPT, PPTX en ODP-formaten met gemak."
---
## **Introductie**

In Microsoft PowerPoint zijn de **Slide Show**-instellingen een belangrijk hulpmiddel voor het voorbereiden en geven van professionele presentaties. Een van de belangrijkste functies in dit gedeelte is **Set Up Show**, waarmee je je presentatie kunt afstemmen op specifieke omstandigheden en doelgroepen, waardoor flexibiliteit en gebruiksgemak gewaarborgd zijn. Met deze functie kun je het type show selecteren (bijv. gepresenteerd door een spreker, bekeken door een individu of bekeken op een kiosk), herhaling in- of uitschakelen, specifieke dia’s kiezen om weer te geven en timings gebruiken. Deze voorbereidende stap is cruciaal om je presentatie effectiever en professioneler te maken.

`getSlideShowSettings` is een methode van de [Presentatie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse die een object van het type [SlideShowSettings](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideshowsettings/) retourneert, waarmee je de slide‑show‑instellingen in een PowerPoint‑presentatie kunt beheren. In dit artikel onderzoeken we hoe je deze methode kunt gebruiken om verschillende aspecten van de slide‑show‑instellingen te configureren en te beheersen. 

## **Showtype selecteren**

`SlideShowSettings.setSlideShowType` definieert het type slide‑show, dat een instantie kan zijn van de volgende klassen: [PresentedBySpeaker](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/browsedbyindividual/), of [BrowsedAtKiosk](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/browsedatkiosk/). Met deze methode kun je de presentatie aanpassen aan verschillende gebruiksscenario’s, zoals geautomatiseerde kiosken of handmatige presentaties.

De onderstaande code‑voorbeeld maakt een nieuwe presentatie aan en stelt het showtype in op “Browsed by an individual” zonder de schuifbalk weer te geven.

```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Showopties inschakelen**

`SlideShowSettings.setLoop` bepaalt of de slide‑show in een lus moet worden herhaald totdat deze handmatig wordt gestopt. Dit is handig voor geautomatiseerde presentaties die continu moeten draaien. `SlideShowSettings.setShowNarration` bepaalt of stemvertellingen tijdens de slide‑show moeten worden afgespeeld. Dit is nuttig voor geautomatiseerde presentaties met spraakbegeleiding voor het publiek. `SlideShowSettings.setShowAnimation` bepaalt of animaties die aan dia‑objecten zijn toegevoegd moeten worden afgespeeld. Dit biedt het volledige visuele effect van de presentatie.

Het volgende code‑voorbeeld maakt een nieuwe presentatie aan en laat de slide‑show in een lus draaien.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Dia’s selecteren om weer te geven**

De methode `SlideShowSettings.setSlides` stelt je in staat een bereik van dia’s te selecteren die tijdens de presentatie moeten worden weergegeven. Dit is handig wanneer je slechts een deel van de presentatie wilt tonen in plaats van alle dia’s. Het volgende code‑voorbeeld maakt een nieuwe presentatie aan en stelt het dia‑bereik in van dia `2` tot en met `9`.

```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Gebruik automatische dia‑overgangen**

Met de methode `SlideShowSettings.setUseTimings` kun je het gebruik van vooraf ingestelde timings voor elke dia in‑ of uitschakelen. Dit is handig om dia’s automatisch weer te geven met vooraf gedefinieerde weergavetijden. Het onderstaande code‑voorbeeld maakt een nieuwe presentatie aan en schakelt het gebruik van timings uit.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Media‑bedieningsknoppen weergeven**

De methode `SlideShowSettings.setShowMediaControls` bepaalt of mediabedieningen (zoals afspelen, pauzeren en stoppen) moeten worden weergegeven tijdens de slide‑show wanneer multimediacontent (bijv. video of audio) wordt afgespeeld. Dit is handig wanneer je de presentator controle wilt geven over de mediavoorstelling tijdens de presentatie.

Het volgende code‑voorbeeld maakt een nieuwe presentatie aan en schakelt het weergeven van mediabedieningen in.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Kan ik een presentatie opslaan zodat deze direct in slide‑show‑modus opent?**

Ja. Sla het bestand op als PPSX of PPSM; deze formaten starten direct in slide‑show wanneer ze in PowerPoint worden geopend. In Aspose.Slides kies je het overeenkomstige opslagformaat [tijdens export](/slides/nl/nodejs-java/save-presentation/).

**Kan ik individuele dia’s uit de show uitsluiten zonder ze uit het bestand te verwijderen?**

Ja. Markeer een dia als [verborgen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/sethidden/). Verborgen dia’s blijven in de presentatie, maar worden niet weergegeven tijdens de slide‑show.

**Kan Aspose.Slides een slide‑show afspelen of een live presentatie op het scherm besturen?**

Nee. Aspose.Slides bewerkt, analyseert en converteert presentatiebestanden; het daadwerkelijke afspelen wordt afgehandeld door een viewer‑applicatie zoals PowerPoint.