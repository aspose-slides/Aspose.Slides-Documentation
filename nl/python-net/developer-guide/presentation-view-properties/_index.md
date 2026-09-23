---
title: Weergave‑eigenschappen van presentaties ophalen en bijwerken in Python
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/python-net/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- inhoudsoverzicht
- overzichtspictogrammen
- verticale splitter vastklikken
- enkele weergave
- balk‑toestand
- afmeting
- automatisch aanpassen
- standaardzoom
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Python via .NET weergave‑eigenschappen om PPT-, PPTX- en ODP‑dia’s aan te passen — lay‑outs, zoomniveaus en weergave‑instellingen te wijzigen."
---
## **Introductie**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zijinhoudsgebied en een onderste inhoudsgebied. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavestatus op te slaan in het bestand, zodat bij het opnieuw openen de weergave in dezelfde staat is als toen de presentatie voor het laatst werd opgeslagen.

Eigenschap [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/normal_view_properties/) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie. 

De klassen [NormalViewProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/normalviewrestoredproperties/) en hun afstammelingen, en de enum [SplitterBarStateType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/splitterbarstatetype/) zijn toegevoegd.

## **Over INormalViewProperties** 

Stelt normale weergave‑eigenschappen voor.

Eigenschap **ShowOutlineIcons** bepaalt of de applicatie pictogrammen moet weergeven wanneer inhoudsoverzicht wordt getoond in een van de inhoudsgebieden van de normale weergavemodus.

Eigenschap **SnapVerticalSplitter** bepaalt of de verticale splitter moet vastklikken in een geminimaliseerde toestand wanneer het zijgebied voldoende klein is.

Eigenschap **PreferSingleView** bepaalt of de gebruiker de voorkeur geeft aan één enkel‑inhoudsgebied over het volledige venster in plaats van de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie kiezen om één van de inhoudsgebieden over het gehele venster te tonen.

Eigenschappen **VerticalBarState** en **HorizontalBarState** geven de toestand aan waarin de verticale of horizontale splitterbalk moet worden weergegeven. Een horizontale splitterbalk scheidt de dia van het inhoudsgebied onder de dia, een verticale splitterbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** en **SplitterBarStateType.Restored**.

Eigenschappen **RestoredLeft** en **RestoredTop** geven de afmeting van respectievelijk het boven‑ of zij‑dia‑gebied van de normale weergave aan, wanneer de waarde **SplitterBarStateType.Restored** wordt toegepast op **VerticalBarState** en **HorizontalBarState**.

## **Over het herstellen van INormalViewProperties**

Specificeert de afmeting van het dia‑gebied (breedte wanneer een kind van RestoredTop, hoogte wanneer een kind van RestoredLeft) van de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (noch geminimaliseerd, noch gemaximaliseerd).

Eigenschap **DimensionSize** specificeert de grootte van het dia‑gebied (breedte wanneer een kind van restoredTop, hoogte wanneer een kind van restoredLeft).

Eigenschap **AutoAdjust** bepaalt of de grootte van het zij‑inhoudsgebied moet worden aangepast aan de nieuwe grootte bij het wijzigen van de afmetingen van het venster dat de weergave bevat binnen de applicatie.

Een voorbeeld hieronder toont hoe u **ViewProperties.NormalViewProperties**‑eigenschappen voor een presentatie kunt benaderen.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Herstel de weergave‑eigenschappen van de presentatie
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Standaardzoomwaarde instellen**

Aspose.Slides for Python via .NET ondersteunt nu het instellen van de standaardzoomwaarde voor een presentatie, zodat bij het openen van de presentatie de zoom al is ingesteld. Dit kan worden gedaan door de [view_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/view_properties/) van een presentatie in te stellen. Slide View Properties evenals [notes_view_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/notes_view_properties/) kunnen programmatically worden ingesteld. In dit onderwerp bekijken we met een voorbeeld hoe de View Properties van een presentatie in Aspose.Slides kunnen worden ingesteld.

Om de weergave‑eigenschappen in te stellen, volg de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan
1. Stel de [view properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/) van de presentatie in
1. Schrijf de presentatie weg als een PPTX‑bestand

In het onderstaande voorbeeld hebben we zowel de zoomwaarde voor slide‑view als voor notes‑view ingesteld.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # De weergave‑eigenschappen van de presentatie instellen
    presentation.view_properties.slide_view_properties.scale = 100 # Zoomwaarde in procenten voor slide‑weergave
    presentation.view_properties.notes_view_properties.scale = 100 # Zoomwaarde in procenten voor notitie‑weergave 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Rasterafstand instellen**

Gebruik [Presentation.view_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/view_properties/) om de view‑instellingen voor de hele presentatie te benaderen. De eigenschap [ViewProperties.grid_spacing](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/grid_spacing/) leest of wijzigt het interval van het onderliggende bewerkingsraster. Deze instelling geldt voor de volledige presentatie, niet voor een enkele dia. Rasterafstand wordt opgegeven in punten, waarbij 72 punten gelijk zijn aan één inch. Gebruik een positieve waarde, zoals vereist door de API‑documentatie.

Het volgende voorbeeld opent een bestaande `demo.pptx`, toont de huidige rasterafstand, stelt een kwart‑inch interval in en slaat het resultaat op.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Het raster verschilt van [drawing guides](/slides/nl/python-net/drawing-guides/). Rasterafstand regelt een regelmatig interval, terwijl tekengidsen afzonderlijk gepositioneerde horizontale of verticale uitlijningslijnen zijn. Het toevoegen, verplaatsen of wissen van tekengidsen verandert de rasterafstand niet.

Zowel het raster als de tekengidsen zijn hulpmiddelen voor bewerken. Ze worden niet gerenderd als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterafstand garandeert niet dat een editor het raster toont: de zichtbaarheid hangt ook af van de voorkeuren van de viewer of editor.

## **Opmerkingen weergeven of verbergen bij het openen van een presentatie**

Gebruik [Presentation.view_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/view_properties/) om de view‑instellingen voor de hele presentatie te benaderen. Lees of wijzig [ViewProperties.show_comments](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/show_comments/) om een voorkeur op te slaan voor het al dan niet tonen van opmerkingen wanneer de presentatie wordt geopend in PowerPoint of een andere compatibele editor.

Deze instelling regelt alleen de opgeslagen weergave‑voorkeur. Het voegt geen opmerkingen toe, verwijdert ze niet, bewerkt ze niet en lost ze niet op. Het verbergen van opmerkingen behoudt hun inhoud, auteurs, posities, antwoorden en statussen. Zie [Presentation Comments](/slides/nl/python-net/presentation-comments/) voor bewerkingen die de opmerkingen zelf wijzigen.

Het onderstaande voorbeeld vereist een bestaande `comments.pptx` met opmerkingen. Het toont de huidige zichtbaarheid, vraagt om opmerkingen te verbergen en slaat een nieuwe PPTX op zonder opmerkingen te verwijderen. Het stelt ook [ViewProperties.last_view](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/last_view/) in op [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewtype/) om de initiële bewerkingsweergave naast de opmerkingen‑zichtbaarheid te configureren.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Deze instelling bepaalt niet of opmerkingen worden meegenomen in PDF-, HTML-, afbeelding-, notitie‑ of handout‑exporten. Configureer de relevante export‑specifieke opties apart.

## **FAQ**

**Waarom is het raster niet zichtbaar nadat ik de presentatie opnieuw heb geopend?**

Het bestand slaat de rasterafstand op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de raster‑zichtbaarheidsinstellingen van de editor.

**Verandert het wissen van tekengidsen de rasterafstand?**

Nee. Tekengidsen en rasterafstand zijn onafhankelijke instellingen. Het wissen van gidsen laat het opgeslagen rasterinterval ongewijzigd.

**Kan ik verschillende weergave‑instellingen voor verschillende secties van een presentatie instellen?**

[View settings](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/view_properties/) worden gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/slide_view_properties/)), niet per sectie, dus één set parameters geldt voor het gehele document bij het openen.

**Kan ik vooraf verschillende weergavetoestanden voor verschillende gebruikers definiëren?**

Nee. De instellingen worden in het bestand opgeslagen en zijn gedeeld. Viewer‑applicaties kunnen gebruikersvoorkeuren respecteren, maar het bestand zelf bevat slechts één set weergave‑eigenschappen.

**Kan ik een sjabloon maken met vooraf gedefinieerde weergave‑eigenschappen zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/view_properties/) worden opgeslagen op presentatieniveau, kun je ze in een sjabloon opnemen en nieuwe documenten daarvan maken met dezelfde initiële weergave‑configuratie.