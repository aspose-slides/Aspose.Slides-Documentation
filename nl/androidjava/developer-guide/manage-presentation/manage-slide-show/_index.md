---  
title: Beheer dia-show op Android  
linktitle: Dia-show  
type: docs  
weight: 90  
url: /nl/androidjava/manage-slide-show/  
keywords:  
- type voorstelling  
- gepresenteerd door spreker  
- bekeken door individu  
- bekeken op kiosk  
- weergave-opties  
- doorlopend herhalen  
- weergeven zonder vertelling  
- weergeven zonder animatie  
- penkleur  
- dia's weergeven  
- aangepaste weergave  
- dia's vooruit  
- handmatig  
- met timings  
- PowerPoint  
- OpenDocument  
- presentatie  
- Android  
- Java  
- Aspose.Slides  
description: "Leer hoe u dia-shows beheert in Aspose.Slides voor Android via Java. Beheer dia-overgangen, timings en meer in PPT-, PPTX- en ODP-formaten met gemak."  
---
## **Inleiding**

In Microsoft PowerPoint zijn de **Slide Show**-instellingen een belangrijk hulpmiddel voor het voorbereiden en geven van professionele presentaties. Eén van de belangrijkste functies in dit gedeelte is **Set Up Show**, waarmee u uw presentatie kunt afstemmen op specifieke omstandigheden en doelgroepen, waardoor flexibiliteit en gebruiksgemak worden gegarandeerd. Met deze functie kunt u het type voorstelling selecteren (bijv. gepresenteerd door een spreker, bekeken door een individu of bekeken op een kiosk), looping in- of uitschakelen, specifieke dia’s kiezen om weer te geven en timings gebruiken. Deze stap in de voorbereiding is cruciaal om uw presentatie effectiever en professioneler te maken.

`getSlideShowSettings` is een methode van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse die een object van het type [SlideShowSettings](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slideshowsettings/) teruggeeft, waarmee u de slide‑show‑instellingen in een PowerPoint‑presentatie kunt beheren. In dit artikel verkennen we hoe u deze methode kunt gebruiken om verschillende aspecten van de slide‑show‑instellingen te configureren en te controleren. 

## **Selecteer het type weergave**

`SlideShowSettings.setSlideShowType` definieert het type slide‑show, dat een instantie kan zijn van een van de volgende klassen: [PresentedBySpeaker](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/browsedbyindividual/), of [BrowsedAtKiosk](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/browsedatkiosk/). Met deze methode kunt u de presentatie aanpassen aan verschillende gebruiksscenario’s, zoals geautomatiseerde kiosken of handmatige presentaties.

Het onderstaande code‑voorbeeld maakt een nieuwe presentatie aan en stelt het type voorstelling in op “Browsed by an individual” zonder de schuifbalk weer te geven.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Schakel weergave‑opties in**

`SlideShowSettings.setLoop` bepaalt of de slide‑show in een lus moet worden herhaald totdat deze handmatig wordt gestopt. Dit is handig voor geautomatiseerde presentaties die continu moeten draaien. `SlideShowSettings.setShowNarration` bepaalt of stemvertellingen tijdens de slide‑show moeten worden afgespeeld. Dit is nuttig voor geautomatiseerde presentaties die een gesproken begeleiding voor het publiek bevatten. `SlideShowSettings.setShowAnimation` bepaalt of animaties die aan dia‑objecten zijn toegevoegd afgespeeld moeten worden. Dit is nuttig om het volledige visuele effect van de presentatie te bieden.

Het volgende code‑voorbeeld maakt een nieuwe presentatie aan en laat de slide‑show in een lus uitvoeren.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Selecteer dia’s om weer te geven**

`SlideShowSettings.setSlides`‑methode stelt u in staat een reeks dia’s te selecteren die tijdens de presentatie moeten worden getoond. Dit is handig wanneer u slechts een deel van de presentatie wilt weergeven in plaats van alle dia’s. Het onderstaande code‑voorbeeld maakt een nieuwe presentatie aan en stelt het dia‑bereik in op weergave van dia’s `2` tot `9`.

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

`SlideShowSettings.setUseTimings`‑methode maakt het mogelijk om het gebruik van vooraf ingestelde timings voor elke dia in te schakelen of uit te schakelen. Dit is handig voor het automatisch weergeven van dia’s met vooraf gedefinieerde weergaveduur. Het onderstaande code‑voorbeeld maakt een nieuwe presentatie aan en schakelt het gebruik van timings uit.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Toon mediabedieningselementen**

`SlideShowSettings.setShowMediaControls`‑methode bepaalt of mediabedieningselementen (zoals afspelen, pauzeren en stoppen) moeten worden getoond tijdens de slide‑show wanneer multimedia‑inhoud (bijv. video of audio) wordt afgespeeld. Dit is handig wanneer u de presentator controle wilt geven over de mediastreaming tijdens de presentatie.

Het volgende code‑voorbeeld maakt een nieuwe presentatie aan en schakelt het weergeven van mediabedieningselementen in.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Kan ik een presentatie opslaan zodat deze direct in slide‑show‑modus opent?**

Ja. Sla het bestand op als PPSX of PPSM; deze formaten starten direct in slide‑show wanneer ze in PowerPoint worden geopend. In Aspose.Slides kiest u het overeenkomstige opslagformaat [tijdens export](/slides/nl/androidjava/save-presentation/).

**Kan ik individuele dia’s uit de voorstelling uitsluiten zonder ze uit het bestand te verwijderen?**

Ja. Markeer een dia als [hidden](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slide/#setHidden-boolean-). Verborgen dia’s blijven in de presentatie aanwezig, maar worden niet getoond tijdens de slide‑show.

**Kan Aspose.Slides een slide‑show afspelen of een live‑presentatie op het scherm bedienen?**

Nee. Aspose.Slides bewerkt, analyseert en converteert presentatiebestanden; de daadwerkelijke weergave wordt verzorgd door een viewer‑applicatie, zoals PowerPoint.