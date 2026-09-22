---
title: Presentatieweergave‑eigenschappen ophalen en bijwerken in Python
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/python-net/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- outline‑inhoud
- outline‑pictogrammen
- verticale splitter vastklikken
- enkele weergave
- balkstatus
- dimension‑grootte
- automatisch aanpassen
- standaard‑zoom
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Python via .NET weergave‑eigenschappen om PPT, PPTX en ODP‑dia's aan te passen - lay-outs, zoomniveaus en weergave‑instellingen te wijzigen."
---
## **Introductie**

De normale weergave bestaat uit drie inhoudsregio's: de dia zelf, een zij-inhoudsregio en een onderste inhoudsregio. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsregio's. Deze informatie stelt de toepassing in staat haar weergavetoestand op te slaan in het bestand, zodat bij het opnieuw openen de weergave zich in dezelfde toestand bevindt als toen de presentatie voor het laatst werd opgeslagen.

Eigenschap [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/normal_view_properties/) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie.  

Klassen [NormalViewProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/normalviewrestoredproperties/) en hun afstammelingen, enum [SplitterBarStateType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/splitterbarstatetype/) zijn toegevoegd.

## **Over INormalViewProperties**

Vertegenwoordigt de normale weergave‑eigenschappen.

Eigenschap **ShowOutlineIcons** geeft aan of de toepassing pictogrammen moet tonen bij het weergeven van de outline‑inhoud in een van de inhoudsregio's van de normale weergavemodus.

Eigenschap **SnapVerticalSplitter** geeft aan of de verticale splitter moet vastklikken in een geminimaliseerde toestand wanneer de zij‑regio voldoende klein is.

Eigenschap **PreferSingleView** geeft aan of de gebruiker de voorkeur geeft aan één volledige venster‑inhoudsregio in plaats van de standaard normale weergave met drie inhoudsregio's. Indien ingeschakeld, kan de toepassing ervoor kiezen één van de inhoudsregio's over het volledige venster weer te geven.

Eigenschappen **VerticalBarState** en **HorizontalBarState** geven de toestand aan waarin de horizontale of verticale splitterbalk moet worden getoond. Een horizontale splitterbalk scheidt de dia van de inhoudsregio onder de dia; een verticale splitterbalk scheidt de dia van de zij‑inhoudsregio. Mogelijke waarden zijn **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** en **SplitterBarStateType.Restored**.

Eigenschappen **RestoredLeft** en **RestoredTop** bepalen de afmetingen van respectievelijk de boven‑ of zij‑diaregio van de normale weergave, wanneer de waarde **SplitterBarStateType.Restored** wordt toegepast op **VerticalBarState** en **HorizontalBarState**.

## **Over het herstellen van INormalViewProperties**

Bepaalt de afmetingen van de diaregio (breedte wanneer een kind van **RestoredTop**, hoogte wanneer een kind van **RestoredLeft**) van de normale weergave, wanneer de regio een variabele herstelde grootte heeft (niet geminimaliseerd of gemaximaliseerd).

Eigenschap **DimensionSize** geeft de grootte van de diaregio (breedte wanneer een kind van **RestoredTop**, hoogte wanneer een kind van **RestoredLeft**) aan.

Eigenschap **AutoAdjust** geeft aan of de grootte van de zij‑inhoudsregio moet worden aangepast aan de nieuwe grootte bij het wijzigen van het venster dat de weergave bevat binnen de toepassing.

Een voorbeeld hieronder toont hoe u **ViewProperties.NormalViewProperties**‑eigenschappen voor een presentatie kunt benaderen.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Herstel de weergave-eigenschappen van de presentatie
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Standaardzoomwaarde instellen**

Aspose.Slides for Python via .NET ondersteunt nu het instellen van de standaardzoomwaarde voor een presentatie, zodat de zoom al is ingesteld wanneer de presentatie wordt geopend. Dit kan worden gedaan door de [view_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/view_properties/) van een presentatie in te stellen. Slide View Properties evenals [notes_view_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/notes_view_properties/) kunnen programmatisch worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe de weergave‑eigenschappen van een presentatie in Aspose.Slides kunnen worden ingesteld.

Om de weergave‑eigenschappen in te stellen, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/).
1. Stel de [view properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/) van de presentatie in.
1. Schrijf de presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we de zoomwaarde ingesteld voor zowel de dia‑weergave als de notitie‑weergave.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Instellen van de weergave‑eigenschappen van de presentatie
    presentation.view_properties.slide_view_properties.scale = 100 # Zoomwaarde in procenten voor de dia‑weergave
    presentation.view_properties.notes_view_properties.scale = 100 # Zoomwaarde in procenten voor de notitie‑weergave

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Rasterafstand instellen**

Gebruik [Presentation.view_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/view_properties/) om de weergave‑instellingen voor de hele presentatie te benaderen. De eigenschap [ViewProperties.grid_spacing](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/grid_spacing/) leest of wijzigt het interval van het onderliggende bewerkingsraster. Deze instelling geldt voor de gehele presentatie, niet voor een individuele dia. Rasterafstand wordt gespecificeerd in punten, waarbij 72 punten gelijk zijn aan één duim. Gebruik een positieve waarde, zoals vereist door de API‑documentatie.

Het volgende voorbeeld opent een bestaande `demo.pptx`, geeft de huidige rasterafstand weer, stelt een kwartduim‑interval in en slaat het resultaat op.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Het raster verschilt van [tekenrichtlijnen](/slides/nl/python-net/drawing-guides/). Rasterafstand regelt een regelmatig interval, terwijl tekenrichtlijnen individueel gepositioneerde horizontale of verticale uitlijningslijnen zijn. Het toevoegen, verplaatsen of wissen van tekenrichtlijnen verandert de rasterafstand niet.

Zowel het raster als de tekenrichtlijnen zijn hulpmiddelen voor bewerking. Ze worden niet gerenderd als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterafstand garandeert niet dat een editor het raster weergeeft: de zichtbaarheid is ook afhankelijk van de voorkeuren van de viewer of editor.

## **FAQ**

**Waarom is het raster niet zichtbaar nadat ik de presentatie opnieuw heb geopend?**

Het bestand slaat de rasterafstand op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de raster‑zichtbaarheidsinstellingen van de editor.

**Verandert het wissen van tekenrichtlijnen de rasterafstand?**

Nee. Tekenrichtlijnen en rasterafstand zijn onafhankelijke instellingen. Het wissen van richtlijnen laat het opgeslagen rasterinterval ongewijzigd.

**Kan ik verschillende weergave‑instellingen definiëren voor verschillende secties van een presentatie?**

[Weergave‑instellingen](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/view_properties/) worden gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/nl/python-net/aspose.slides/viewproperties/slide_view_properties/)), niet per sectie, zodat één set parameters geldt voor het volledige document bij het openen.

**Kan ik vooraf verschillende weergavetoestanden definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en gedeeld. Viewer‑applicaties kunnen gebruikersvoorkeuren respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon maken met vooraf gedefinieerde weergave‑eigenschappen zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/view_properties/) op presentatieniveau worden opgeslagen, kunt u ze in een sjabloon opnemen en nieuwe documenten ervan maken met dezelfde initiële weergave‑configuratie.