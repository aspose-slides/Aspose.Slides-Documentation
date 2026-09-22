---
title: Presentatie-weergave-eigenschappen ophalen en bijwerken in Python via Java
linktitle: Weergave-eigenschappen
type: docs
weight: 80
url: /nl/python-java/presentation-view-properties/
keywords:
- weergave-eigenschappen
- normale weergave
- outline-inhoud
- outline-pictogrammen
- verticale splitter-snap
- enkele weergave
- balk-status
- dimensie-grootte
- auto-aanpassing
- standaard-zoom
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Ontdek de weergave-eigenschappen van Aspose.Slides voor Python via Java om PPT, PPTX en ODP-dias aan te passen - lay-out, zoom-niveaus en weergave-instellingen bij te stellen."
---
## **Introductie**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zij‑inhoudsgebied en een onder‑inhoudsgebied. Normal view‑eigenschappen beschrijven de positionering van deze inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavetoestand op te slaan in het bestand, zodat bij opnieuw openen de weergave in dezelfde toestand is als toen de presentatie voor het laatst werd opgeslagen.

De methode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getNormalViewProperties) is toegevoegd om toegang te bieden tot de normal view‑eigenschappen van een presentatie.

De klassen [NormalViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/) en [NormalViewRestoredProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewrestoredproperties/) en de enumeratie [SplitterBarStateType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/splitterbarstatetype/) zijn toegevoegd.

## **Over NormalViewProperties**

Stelt normal view‑eigenschappen voor.

De methoden [getShowOutlineIcons](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) en [setShowOutlineIcons](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) geven aan of de applicatie pictogrammen moet tonen bij het weergeven van de outline‑inhoud in een van de inhoudsgebieden van de normal view‑modus.

De methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) en [setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) geven aan of de verticale splitter moet ‘snappen’ naar een geminimaliseerde staat wanneer het zij‑gebied klein genoeg is.

De methoden [getPreferSingleView](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) en [setPreferSingleView](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) geven aan of de gebruiker de voorkeur geeft aan een enkel‑inhoudsgebied over het volledige venster in plaats van de standaard normal view met drie inhoudsgebieden. Indien geactiveerd, kan de applicatie ervoor kiezen één van de inhoudsgebieden over het hele venster weer te geven.

De methoden [getVerticalBarState](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) specificeren in welke staat de horizontale of verticale splitter‑balk moet worden getoond. Een horizontale splitter‑balk scheidt de dia van het inhoudsgebied onder de dia; een verticale splitter‑balk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nl/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nl/python-java/aspose.slides/splitterbarstatetype/#Maximized) en [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/python-java/aspose.slides/splitterbarstatetype/#Restored).

De methoden [getRestoredLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) en [getRestoredTop](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredTop) bepalen de grootte van respectievelijk het boven‑ of zij‑dia‑gebied van de normal view, wanneer de waarde [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/python-java/aspose.slides/splitterbarstatetype/#Restored) wordt toegepast op [getVerticalBarState](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState).

## **Over het herstellen van NormalViewProperties**

Specificeert de grootte van het dia‑gebied (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredTop), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) van de normal view, wanneer het gebied een variabel hersteld formaat heeft (niet geminimaliseerd noch gemaximaliseerd).

De methode [getDimensionSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) bepaalt de grootte van het dia‑gebied (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredTop), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

De methode [getAutoAdjust](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) geeft aan of de grootte van het zij‑inhoudsgebied zich moet aanpassen aan de nieuwe grootte bij het wijzigen van het venster dat de weergave bevat.

Het voorbeeld hieronder laat zien hoe [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getNormalViewProperties) voor een presentatie kan worden benaderd.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Herstel de weergave-eigenschappen van de presentatie.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Stel de standaard zoomwaarde in**

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java ondersteunt het instellen van de standaard zoomwaarde zodat deze al wordt toegepast bij het openen van de presentatie. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/) van een presentatie in te stellen. [getSlideViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getSlideViewProperties) en [getNotesViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getNotesViewProperties) kunnen programmatic worden geconfigureerd. In dit onderwerp laten we met een voorbeeld zien hoe de [View Properties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/) van [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) in Aspose.Slides worden ingesteld.

{{% /alert %}}

Om de weergave‑eigenschappen in te stellen, volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Stel de **Weergave‑eigenschappen** van [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) in.
1. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

In het voorbeeld hieronder stellen we de zoomwaarde in voor zowel de dia‑weergave als de notitie‑weergave.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Stel de weergave‑eigenschappen van de presentatie in.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Zoompercentage voor diaview.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Zoompercentage voor notitie‑view.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Stel de rasterafstand in**

Gebruik [Presentation.getViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getViewProperties) om de weergave‑instellingen voor de hele presentatie te benaderen. De methoden [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getGridSpacing) en [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#setGridSpacing) lezen of wijzigen het interval van het onderliggende bewerkingsraster. Deze instelling geldt voor de volledige presentatie, niet voor een afzonderlijke dia. Rasterafstand wordt opgegeven in punten, waarbij 72 punten gelijk zijn aan één inch. Gebruik een positieve waarde, zoals vereist door de API‑documentatie.

Het volgende voorbeeld opent een bestaande `demo.pptx`, toont de huidige rasterafstand, stelt een kwart‑inch interval in en slaat het resultaat op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het raster verschilt van [drawing guides](/slides/nl/python-java/drawing-guides/). Rasterafstand regelt een regelmatige interval, terwijl tekenhulplijnen individueel gepositioneerde horizontale of verticale uitlijningslijnen zijn. Het toevoegen, verplaatsen of verwijderen van tekenhulplijnen verandert de rasterafstand niet.

Zowel het raster als tekenhulplijnen zijn hulpmiddelen bij het bewerken. Ze worden niet gerenderd als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterafstand garandeert niet dat een editor het raster weergeeft: de zichtbaarheid hangt ook af van de voorkeuren van de viewer of editor.

## **FAQ**

**Waarom is het raster niet zichtbaar nadat ik de presentatie opnieuw heb geopend?**

Het bestand slaat de rasterafstand op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de raster‑zichtbaarheidsinstellingen van de editor.

**Verandert het verwijderen van tekenhulplijnen de rasterafstand?**

Nee. Tekenhulplijnen en rasterafstand zijn onafhankelijke instellingen. Het wissen van hulplijnen laat het opgeslagen rasterinterval ongewijzigd.

**Kan ik verschillende weergave‑instellingen instellen voor verschillende secties van een presentatie?**

[View settings](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getViewProperties) worden gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), niet per sectie, zodat één set parameters geldt voor het hele document bij het openen.

**Kan ik verschillende weergave‑toestanden vooraf definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en gedeeld. Viewer‑applicaties kunnen gebruikersvoorkeuren respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde weergave‑eigenschappen zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getViewProperties) worden opgeslagen op presentatieniveau, kun je ze in een sjabloon opnemen en nieuwe documenten ervan maken met dezelfde initiële weergave‑configuratie.