---
title: Beheer slide-show in Python
linktitle: Dia Show
type: docs
weight: 90
url: /nl/python-net/manage-slide-show/
keywords:
- type weergave
- gepresenteerd door spreker
- bekeken door individu
- bekeken op kiosk
- weergave-opties
- doorlopend herhalen
- weergave zonder narratie
- weergave zonder animatie
- penkleur
- weergave dia's
- aangepaste weergave
- dia's vooruit
- handmatig
- met timings
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u slide-shows beheert in Aspose.Slides voor Python via .NET. Controleer dia-overgangen, timings en meer in PPT-, PPTX- en ODP-formaten met gemak."
---
## **Introductie**

In Microsoft PowerPoint vormen de **Slide Show**-instellingen een cruciaal hulpmiddel voor het voorbereiden en geven van professionele presentaties. Een van de belangrijkste functies in deze sectie is **Set Up Show**, waarmee u uw presentatie kunt afstemmen op specifieke omstandigheden en doelgroepen, en zodat u flexibiliteit en gebruiksgemak krijgt. Met deze functie kunt u het type voorstelling selecteren (bijv. gepresenteerd door een spreker, bekeken door een individu of bekeken op een kiosk), de lus (loop) in- of uitschakelen, bepaalde dia’s kiezen om weer te geven en timings gebruiken. Deze voorbereidingsstap is essentieel om uw presentatie effectiever en professioneler te maken.

`slide_show_settings` is een eigenschap van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse, van het type [SlideShowSettings](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slideshowsettings/), waarmee u de slide-show-instellingen in een PowerPoint-presentatie kunt beheren. In dit artikel kijken we hoe u deze eigenschap kunt gebruiken om verschillende aspecten van slide-show-instellingen te configureren en te controleren.

## **Selecteer type weergave**

`SlideShowSettings.slide_show_type` definieert het type slide-show, dat een instantie kan zijn van de volgende klassen: [PresentedBySpeaker](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/nl/python-net/aspose.slides/browsedbyindividual/), of [BrowsedAtKiosk](https://reference.aspose.com/slides/nl/python-net/aspose.slides/browsedatkiosk/). Met deze eigenschap kunt u de presentatie aanpassen aan verschillende gebruikssituaties, zoals geautomatiseerde kiosken of handmatige presentaties.

Het code-voorbeeld hieronder maakt een nieuwe presentatie aan en stelt het toontype in op "Browsed by an individual" zonder de scrollbar weer te geven.

```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Schakel weergave-opties in**

`SlideShowSettings.loop` bepaalt of de slide-show moet herhalen in een lus tot handmatig gestopt. Dit is nuttig voor geautomatiseerde presentaties die continu moeten draaien. `SlideShowSettings.show_narration` bepaalt of voice-narraties moeten worden afgespeeld tijdens de slide-show. Het is nuttig voor geautomatiseerde presentaties die steminstructies voor het publiek bevatten. `SlideShowSettings.show_animation` bepaalt of animaties toegevoegd aan dia-objecten moeten worden afgespeeld. Dit is nuttig om het volledige visuele effect van de presentatie te bieden.

Het volgende code-voorbeeld maakt een nieuwe presentatie aan en laat de slide-show in een lus afspelen.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Selecteer dia’s om weer te geven**

`SlideShowSettings.slides` eigenschap stelt u in staat een bereik van dia’s te selecteren die tijdens de presentatie moeten worden weergegeven. Dit is handig wanneer u slechts een deel van de presentatie wilt tonen in plaats van alle dia’s. Het volgende code-voorbeeld maakt een nieuwe presentatie aan en stelt het dia-bereik in op dia’s `2` tot `9`.

```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Gebruik automatische dia’s**

`SlideShowSettings.use_timings` eigenschap maakt het mogelijk om het gebruik van vooraf ingestelde timings voor elke dia in- of uit te schakelen. Dit is handig om dia’s automatisch te tonen met vooraf bepaalde weergaveduur. Het onderstaande code-voorbeeld maakt een nieuwe presentatie aan en schakelt het gebruik van timings uit.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Media-besturingselementen weergeven**

`SlideShowSettings.show_media_controls` eigenschap bepaalt of mediabesturingselementen (zoals afspelen, pauzeren en stoppen) moeten worden weergegeven tijdens de slide-show wanneer multimediacontent (bijv. video of audio) wordt afgespeeld. Dit is handig wanneer u de presentator controle wilt geven over het afspelen van media tijdens de presentatie.

Het volgende code-voorbeeld maakt een nieuwe presentatie aan en schakelt het weergeven van mediabesturingselementen in.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik een presentatie opslaan zodat deze direct in de slide-show-modus opent?**

Ja. Sla het bestand op als PPSX of PPSM; deze formaten starten direct in slide-show wanneer ze in PowerPoint worden geopend. In Aspose.Slides kiest u het overeenkomstige opslaan-formaat [tijdens export](/slides/nl/python-net/save-presentation/).

**Kan ik individuele dia’s uitsluiten van de show zonder ze uit het bestand te verwijderen?**

Ja. Markeer een dia als [hidden](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/hidden/). Verborgen dia’s blijven in de presentatie, maar worden niet weergegeven tijdens de slide-show.

**Kan Aspose.Slides een slide-show afspelen of een live-presentatie op het scherm bedienen?**

Nee. Aspose.Slides bewerkt, analyseert en converteert presentatiebestanden; de daadwerkelijke weergave wordt afgehandeld door een kijk- of weergave-applicatie zoals PowerPoint.