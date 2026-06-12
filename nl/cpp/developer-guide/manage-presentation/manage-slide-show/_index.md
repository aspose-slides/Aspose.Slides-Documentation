---
title: Beheer slide-show in C++
linktitle: Slide Show
type: docs
weight: 90
url: /nl/cpp/manage-slide-show/
keywords:
- showtype
- gepresenteerd door spreker
- bekeken door individuele gebruiker
- bekeken op kiosk
- showopties
- continu herhalen
- show zonder narratie
- show zonder animatie
- penkleur
- dia's weergeven
- aangepaste show
- dia's vooruit
- handmatig
- met timing
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u slide-shows kunt beheren in Aspose.Slides voor C++. Beheer dia-overgangen, timing en meer in de formaten PPT, PPTX en ODP met gemak."
---
## **Inleiding**

In Microsoft PowerPoint zijn de **Slide Show**‑instellingen een belangrijk hulpmiddel voor het voorbereiden en geven van professionele presentaties. Een van de belangrijkste functies in deze sectie is **Set Up Show**, waarmee je je presentatie kunt afstemmen op specifieke omstandigheden en doelgroepen, en daarmee flexibiliteit en gemak biedt. Met deze functie kun je het type show selecteren (bijv. gepresenteerd door een spreker, bekeken door een individuele gebruiker, of bekeken op een kioskmodus), looping in‑ of uitschakelen, specifieke dia's kiezen om weer te geven, en tijdsinstellingen gebruiken. Deze stap in de voorbereiding is cruciaal om je presentatie effectiever en professioneler te maken.

`get_SlideShowSettings` is een methode van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse die een object van het type [SlideShowSettings](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slideshowsettings/) teruggeeft, waarmee je de slide show‑instellingen in een PowerPoint‑presentatie kunt beheren. In dit artikel bekijken we hoe je deze methode kunt gebruiken om verschillende aspecten van de slide show‑instellingen te configureren en te controleren. 

## **Selecteer Showtype**

`SlideShowSettings.set_SlideShowType` definieert het type slide show, dat een instantie kan zijn van de volgende klassen: [PresentedBySpeaker](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/nl/cpp/aspose.slides/browsedbyindividual/), of [BrowsedAtKiosk](https://reference.aspose.com/slides/nl/cpp/aspose.slides/browsedatkiosk/). Met deze methode kun je de presentatie aanpassen voor verschillende gebruiksscenario’s, zoals geautomatiseerde kiosken of handmatige presentaties.

Het codevoorbeeld hieronder maakt een nieuwe presentatie en stelt het showtype in op "Browsed by an individual" zonder de schuifbalk weer te geven.

```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Schakel Showopties in**

`SlideShowSettings.set_Loop` bepaalt of de slide show moet blijven herhalen in een lus totdat deze handmatig wordt gestopt. Dit is nuttig voor geautomatiseerde presentaties die continu moeten draaien. `SlideShowSettings.set_ShowNarration` bepaalt of voice‑narraties moeten worden afgespeeld tijdens de slide show. Het is handig voor geautomatiseerde presentaties die gesproken begeleiding voor het publiek bevatten. `SlideShowSettings.set_ShowAnimation` bepaalt of animaties die aan dia‑objecten zijn toegevoegd moeten worden afgespeeld. Dit is nuttig om het volledige visuele effect van de presentatie te bieden.

Het volgende codevoorbeeld maakt een nieuwe presentatie en laat de slide show in een lus draaien.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Selecteer Dia's om weer te geven**

`SlideShowSettings.set_Slides`-methode stelt je in staat een bereik van dia's te selecteren die tijdens de presentatie getoond moeten worden. Dit is handig wanneer je slechts een deel van de presentatie wilt laten zien in plaats van alle dia's. Het volgende codevoorbeeld maakt een nieuwe presentatie en stelt het dia‑bereik in op weergave vanaf dia `2` tot en met `9`.

```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gebruik Vooruitgang Dia's**

`SlideShowSettings.set_UseTimings`-methode maakt het mogelijk om het gebruik van vooraf ingestelde tijdsduur voor elke dia in of uit te schakelen. Dit is nuttig voor het automatisch weergeven van dia's met vooraf gedefinieerde weergavetijden. Het codevoorbeeld hieronder maakt een nieuwe presentatie en schakelt het gebruik van timing uit.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Geef Media‑besturingselementen weer**

`SlideShowSettings.set_ShowMediaControls`-methode bepaalt of mediabesturingselementen (zoals afspelen, pauzeren en stoppen) moeten worden weergegeven tijdens de slide show wanneer multimediale inhoud (bijv. video of audio) wordt afgespeeld. Dit is handig wanneer je de presentator controle wilt geven over de weergave van media tijdens de presentatie.

Het volgende codevoorbeeld maakt een nieuwe presentatie en schakelt weergeven van mediabesturingselementen in.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Kan ik een presentatie opslaan zodat deze direct in de slide‑show‑modus opent?**

Ja. Sla het bestand op als PPSX of PPSM; deze formaten starten direct in de slide‑show wanneer ze in PowerPoint worden geopend. In Aspose.Slides kies je het overeenkomstige opslagformaat [tijdens export](/slides/nl/cpp/save-presentation/).

**Kan ik individuele dia's uitsluiten van de show zonder ze uit het bestand te verwijderen?**

Ja. Markeer een dia als [hidden](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/set_hidden/). Verborgen dia's blijven in de presentatie aanwezig, maar worden niet getoond tijdens de slide‑show.

**Kan Aspose.Slides een slide‑show afspelen of een live‑presentatie op het scherm besturen?**

Nee. Aspose.Slides bewerkt, analyseert en converteert presentatiebestanden; de daadwerkelijke weergave wordt afgehandeld door een viewer‑applicatie zoals PowerPoint.