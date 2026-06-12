---
title: Beheer diavoorstelling in PHP
linktitle: Diavoorstelling
type: docs
weight: 90
url: /nl/php-java/manage-slide-show/
keywords:
- showtype
- gepresenteerd door spreker
- bekeken door individu
- bekeken op kiosk
- showopties
- doorlopend herhalen
- weergave zonder narratie
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
- PHP
- Aspose.Slides
description: "Leer hoe u diavoorstellingen beheert in Aspose.Slides voor PHP via Java. Beheer diaovergangen, timings en meer in PPT, PPTX en ODP-formats met gemak."
---
## **Introductie**

In Microsoft PowerPoint zijn de **Slide Show**-instellingen een belangrijk hulpmiddel voor het voorbereiden en geven van professionele presentaties. Een van de belangrijkste functies in deze sectie is **Set Up Show**, waarmee u uw presentatie kunt aanpassen aan specifieke omstandigheden en doelgroepen, waardoor flexibiliteit en gemak worden gegarandeerd. Met deze functie kunt u het type show kiezen (bijvoorbeeld gepresenteerd door een spreker, bekeken door een individu, of bekeken op een kiosk), herhalen in‑ of uitschakelen, specifieke dia's selecteren voor weergave en timing gebruiken. Deze stap in de voorbereiding is cruciaal om uw presentatie effectiever en professioneler te maken.

`getSlideShowSettings` is een methode van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse die een object van het type [SlideShowSettings](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowsettings/) teruggeeft, waarmee u de slide‑show‑instellingen in een PowerPoint‑presentatie kunt beheren. In dit artikel bekijken we hoe u deze methode kunt gebruiken om verschillende aspecten van de slide‑show‑instellingen te configureren en te beheersen. 

## **Selecteer Showtype**

`SlideShowSettings->setSlideShowType` definieert het type slide‑show, dat een instantie kan zijn van de volgende klassen: [PresentedBySpeaker](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/nl/php-java/aspose.slides/browsedbyindividual/), of [BrowsedAtKiosk](https://reference.aspose.com/slides/nl/php-java/aspose.slides/browsedatkiosk/). Met deze methode kunt u de presentatie aanpassen aan verschillende gebruiksscenario’s, zoals geautomatiseerde kiosken of handmatige presentaties.

Het onderstaande code‑voorbeeld maakt een nieuwe presentatie aan en stelt het showtype in op “Browsed by an individual” zonder de schuifbalk weer te geven.

```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Showopties inschakelen**

`SlideShowSettings->setLoop` bepaalt of de slide‑show in een lus moet worden herhaald totdat deze handmatig wordt gestopt. Dit is handig voor geautomatiseerde presentaties die continu moeten draaien. `SlideShowSettings->setShowNarration` bepaalt of voice‑narraties moeten worden afgespeeld tijdens de slide‑show. Dit is nuttig voor geautomatiseerde presentaties met spraakinstructies voor het publiek. `SlideShowSettings->setShowAnimation` bepaalt of animaties die aan dia‑objecten zijn toegevoegd moeten worden afgespeeld. Dit is nuttig om het volledige visuele effect van de presentatie te leveren.

Het volgende code‑voorbeeld maakt een nieuwe presentatie aan en laat de slide‑show in een lus afspelen.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Selecteer dia's om te tonen**

`SlideShowSettings->setSlides`-methode stelt u in staat een bereik van dia's te selecteren die tijdens de presentatie getoond moeten worden. Dit is handig wanneer u slechts een deel van de presentatie wilt weergeven in plaats van alle dia's. Het volgende code‑voorbeeld maakt een nieuwe presentatie aan en stelt het dia‑bereik in op dia's `2` tot `9`.

```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Gebruik dia‑timings**

`SlideShowSettings->setUseTimings`-methode maakt het mogelijk om het gebruik van vooraf ingestelde timings voor elke dia in te schakelen of uit te schakelen. Dit is handig om dia's automatisch weer te geven met vooraf bepaalde weergaveduur. Het onderstaande code‑voorbeeld maakt een nieuwe presentatie aan en schakelt het gebruik van timings uit.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Media‑besturingselementen tonen**

`SlideShowSettings->setShowMediaControls`-methode bepaalt of mediabesturingselementen (zoals afspelen, pauzeren en stoppen) moeten worden weergegeven tijdens de slide‑show wanneer multimedia‑inhoud (bijvoorbeeld video of audio) wordt afgespeeld. Dit is handig wanneer u de presentator controle wilt geven over het afspelen van media tijdens de presentatie.

Het volgende code‑voorbeeld maakt een nieuwe presentatie aan en schakelt het weergeven van mediabesturingselementen in.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **FAQ**

**Kan ik een presentatie opslaan zodat deze direct in de slide‑show‑modus opent?**

Ja. Sla het bestand op als PPSX of PPSM; deze formaten starten direct in de slide‑show wanneer ze in PowerPoint worden geopend. In Aspose.Slides kiest u het overeenkomstige opslagformaat [tijdens export](/slides/nl/php-java/save-presentation/).

**Kan ik individuele dia's uitsluiten van de show zonder ze uit het bestand te verwijderen?**

Ja. Markeer een dia als [hidden](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/sethidden/). Verborgen dia's blijven in de presentatie, maar worden niet weergegeven tijdens de slide‑show.

**Kan Aspose.Slides een slide‑show afspelen of een live‑presentatie op het scherm besturen?**

Nee. Aspose.Slides bewerkt, analyseert en converteert presentatiebestanden; de daadwerkelijke weergave wordt verzorgd door een weergave‑applicatie zoals PowerPoint.