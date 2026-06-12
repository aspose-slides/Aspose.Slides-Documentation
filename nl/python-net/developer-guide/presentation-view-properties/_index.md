---
title: Ophalen en bijwerken van presentatieweergave‑eigenschappen in Python
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/python-net/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- outline‑inhoud
- outline‑pictogrammen
- verticale splitter laten snapen
- enkele weergave
- balkstatus
- afmeting
- automatisch aanpassen
- standaardzoom
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Ontdek de weergave‑eigenschappen van Aspose.Slides voor Python via .NET om PPT-, PPTX- en ODP‑dia’s aan te passen—lay-outs, zoomniveaus en weergave‑instellingen wijzigen."
---
## **Introductie**

De normale weergave bestaat uit drie inhoudsregio's: de dia zelf, een zij‑inhoudsregio en een onderste inhoudsregio. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsregio's. Deze informatie stelt de applicatie in staat om de weergavetoestand naar het bestand op te slaan, zodat bij het opnieuw openen de weergave zich in dezelfde staat bevindt als toen de presentatie voor het laatst werd opgeslagen.

Eigenschap [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/normal_view_properties/) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie.  

[NormalViewProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/normalviewrestoredproperties/) klassen en hun afstammelingen, [SplitterBarStateType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/splitterbarstatetype/) enum zijn toegevoegd.

## **Over INormalViewProperties**

Stelt normale weergave‑eigenschappen voor.

Eigenschap **ShowOutlineIcons** bepaalt of de applicatie pictogrammen moet tonen bij het weergeven van de outline‑inhoud in een van de inhoudsregio's van de normale weergavemodus.

Eigenschap **SnapVerticalSplitter** bepaalt of de verticale splitter moet snapsen naar een geminimaliseerde toestand wanneer de zij‑regio voldoende klein is.

Eigenschap **PreferSingleView** bepaalt of de gebruiker de voorkeur geeft aan een enkel‑inhoudsgebied op volledig scherm boven de standaard normale weergave met drie inhoudsregio's. Indien ingeschakeld, kan de applicatie ervoor kiezen om een van de inhoudsregio's in het volledige venster weer te geven.

Eigenschappen **VerticalBarState** en **HorizontalBarState** geven de toestand aan waarin de horizontale of verticale splitterbalk moet worden weergegeven. Een horizontale splitterbalk scheidt de dia van de inhoudsregio onder de dia, een verticale splitterbalk scheidt de dia van de zij‑inhoudsregio. Mogelijke waarden zijn: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** en **SplitterBarStateType.Restored.**

Eigenschappen **RestoredLeft** en **RestoredTop** geven de afmeting aan van respectievelijk de zij‑ of bovenste dia‑regio van de normale weergave, wanneer de waarde **SplitterBarStateType.Restored** wordt toegepast op **VerticalBarState** en **HorizontalBarState**.

## **Over het herstellen van INormalViewProperties**

Bepaalt de afmeting van de dia‑regio (breedte wanneer een kind van RestoredTop, hoogte wanneer een kind van RestoredLeft) van de normale weergave, wanneer de regio een variabele herstelde grootte heeft (niet geminimaliseerd of gemaximaliseerd).

Eigenschap **DimensionSize** bepaalt de grootte van de dia‑regio (breedte wanneer een kind van restoredTop, hoogte wanneer een kind van restoredLeft).

Eigenschap **AutoAdjust** bepaalt of de grootte van de zij‑inhoudsregio moet compenseren voor de nieuwe grootte bij het wijzigen van de grootte van het venster dat de weergave in de applicatie bevat.

Een voorbeeld hieronder toont hoe je toegang kunt krijgen tot de **ViewProperties.NormalViewProperties**‑eigenschappen voor een presentatie.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Herstel de weergave-eigenschappen van de presentatie
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Instellen standaard zoomwaarde**

Aspose.Slides voor Python via .NET ondersteunt nu het instellen van de standaard zoomwaarde voor een presentatie, zodat wanneer de presentatie wordt geopend, de zoom al is ingesteld. Dit kan worden gedaan door de [view_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/view_properties/) van een presentatie in te stellen. Slide View Properties evenals [notes_view_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/notes_view_properties/) kunnen programmatig worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe de View Properties van een presentatie in Aspose.Slides kunnen worden ingesteld.

Om de weergave‑eigenschappen in te stellen, volg de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)
2. Stel de [view properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/) van de presentatie in
3. Schrijf de presentatie weg als een PPTX‑bestand

In het onderstaande voorbeeld hebben we de zoomwaarde ingesteld voor zowel de diaweergave als de notitieweergave.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Instellen van de weergave-eigenschappen van de presentatie
    presentation.view_properties.slide_view_properties.scale = 100 # Zoomwaarde in percentages voor de diaweergave
    presentation.view_properties.notes_view_properties.scale = 100 # Zoomwaarde in percentages voor de notitieweergave 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik verschillende weergave‑instellingen instellen voor verschillende secties van een presentatie?**

[View settings](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/view_properties/) worden gedefinieerd op het presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/slide_view_properties/)), niet per sectie, dus een enkele set parameters geldt voor het gehele document bij het openen.

**Kan ik verschillende weergavetoestanden vooraf definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en zijn gedeeld. Viewer‑applicaties kunnen de voorkeuren van de gebruiker respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde View Properties zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/view_properties/) op presentatieniveau worden opgeslagen, kun je ze in een sjabloon opnemen en nieuwe documenten vanuit dat sjabloon maken met dezelfde initiële weergave‑configuratie.