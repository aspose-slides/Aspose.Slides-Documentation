---
title: Ophalen en bijwerken van presentatieweergave‑eigenschappen in Python via Java
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/python-java/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- outline‑inhoud
- outline‑iconen
- snap‑verticale‑splitter
- enkele weergave
- balk‑toestand
- afmetingsgrootte
- automatisch aanpassen
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Ontdek de weergave‑eigenschappen van Aspose.Slides voor Python via Java om PPT-, PPTX- en ODP‑dia's aan te passen - lay-outs, zoomniveaus en weergave‑instellingen te wijzigen."
---
## **Introductie**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zijinhoudsgebied en een onderste inhoudsgebied. Eigenschappen van de normale weergave beschrijven de positionering van deze inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavetoestand op te slaan in het bestand, zodat bij het opnieuw openen de weergave zich in dezelfde toestand bevindt als toen de presentatie voor het laatst was opgeslagen.

De methode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getNormalViewProperties) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie.

De klassen [NormalViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/) en [NormalViewRestoredProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewrestoredproperties/) en de enumeratie [SplitterBarStateType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/splitterbarstatetype/) zijn toegevoegd.

## **Over NormalViewProperties**

Stelt de normale weergave‑eigenschappen voor.

De methoden [getShowOutlineIcons](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) en [setShowOutlineIcons](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) geven aan of de applicatie pictogrammen moet tonen wanneer de outline‑inhoud in een van de inhoudsgebieden van de normale weergavemodus wordt weergegeven.

De methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) en [setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) bepalen of de verticale splitter moet vastklikken op een geminimaliseerde toestand wanneer het zijgebied voldoende klein is.

De methoden [getPreferSingleView](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) en [setPreferSingleView](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) geven aan of de gebruiker de voorkeur geeft aan een enkel‑inhoudsgebied dat het volledige venster vult boven de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie ervoor kiezen om een van de inhoudsgebieden over het gehele venster te tonen.

De methoden [getVerticalBarState](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) geven de toestand op waarin de horizontale of verticale splitterbalk moet worden weergegeven. Een horizontale splitterbalk scheidt de dia van het inhoudsgebied onder de dia; een verticale splitterbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nl/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nl/python-java/aspose.slides/splitterbarstatetype/#Maximized) en [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/python-java/aspose.slides/splitterbarstatetype/#Restored).

De methoden [getRestoredLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) en [getRestoredTop](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredTop) specificeren de afmetingen van respectievelijk het linker‑ en bovenste dia‑gebied van de normale weergave wanneer de waarde [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/python-java/aspose.slides/splitterbarstatetype/#Restored) wordt toegepast op [getVerticalBarState](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState).

## **Over het herstellen van NormalViewProperties**

Specificeert de afmetingen van het dia‑gebied (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredTop), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) van de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (niet geminimaliseerd of gemaximaliseerd).

De methode [getDimensionSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) geeft de grootte van het dia‑gebied aan (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredTop), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

De methode [getAutoAdjust](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) bepaalt of de grootte van het zij‑inhoudsgebied moet compenseren voor de nieuwe grootte bij het wijzigen van de grootte van het venster dat de weergave binnen de applicatie bevat.

Het voorbeeld hieronder laat zien hoe u [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getNormalViewProperties) voor een presentatie kunt benaderen.

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
Aspose.Slides for Python via Java ondersteunt het instellen van de standaard zoomwaarde zodat deze al wordt toegepast wanneer de presentatie wordt geopend. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/) van een presentatie in te stellen. [getSlideViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getSlideViewProperties) en [getNotesViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getNotesViewProperties) kunnen programmatisch worden geconfigureerd. In dit onderwerp laten we met een voorbeeld zien hoe de [View Properties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/) van [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) in Aspose.Slides kunnen worden ingesteld.
{{% /alert %}}

Om de weergave‑eigenschappen in te stellen, volg deze stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/).
1. Stel de [View Properties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/) van [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) in.
1. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)-bestand.

In het onderstaande voorbeeld stellen we de zoomwaarde in voor zowel de dia‑weergave als de notitie‑weergave.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Stel de weergave‑eigenschappen van de presentatie in.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Zoompercentage voor dia‑weergave.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Zoompercentage voor notitie‑weergave.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Stel de rasterafstand in**

Gebruik [Presentation.getViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getViewProperties) om de weergave‑instellingen voor de volledige presentatie te benaderen. De methoden [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getGridSpacing) en [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#setGridSpacing) lezen of wijzigen het interval van het onderliggende bewerkingsraster. Deze instelling geldt voor de gehele presentatie, niet voor een individuele dia. Rasterafstand wordt opgegeven in punten, waarbij 72 punten één inch gelijk zijn. Gebruik een positieve waarde, zoals vereist door de API‑documentatie.

Het volgende voorbeeld opent een bestaande `demo.pptx`, geeft de huidige rasterafstand weer, stelt een kwart‑inch interval in en slaat het resultaat op.

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

Het raster verschilt van de [drawing guides](/slides/nl/python-java/drawing-guides/). Rasterafstand regelt een regelmatig interval, terwijl teken‑gidsen afzonderlijk gepositioneerde horizontale of verticale uitlijningslijnen zijn. Het toevoegen, verplaatsen of wissen van teken‑gidsen verandert de rasterafstand niet.

Zowel het raster als teken‑gidsen zijn hulpmiddelen bij het bewerken. Ze worden niet gerenderd als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterafstand garandeert niet dat een editor het raster weergeeft: de zichtbaarheid hangt ook af van de voorkeuren van de viewer of editor.

## **Toon of verberg opmerkingen bij het openen van een presentatie**

Gebruik [Presentation.getViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getViewProperties) om de weergave‑instellingen voor de volledige presentatie te benaderen. Gebruik [ViewProperties.getShowComments](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getShowComments) en [ViewProperties.setShowComments](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#setShowComments) om de opgeslagen voorkeur te lezen of te wijzigen of opmerkingen moeten worden weergegeven wanneer de presentatie wordt geopend in PowerPoint of een andere compatibele editor.

Deze instelling regelt alleen de opgeslagen weergave‑voorkeur. Het voegt geen opmerkingen toe, verwijdert, bewerkt of lost ze op. Het verbergen van opmerkingen behoudt hun inhoud, auteurs, posities, antwoorden en status. Zie [Presentation Comments](/slides/nl/python-java/presentation-comments/) voor bewerkingen die de opmerkingen zelf wijzigen.

Het volgende voorbeeld vereist een bestaande `comments.pptx` met opmerkingen. Het geeft de huidige zichtbaarheid weer, vraagt om de opmerkingen te verbergen en slaat een nieuwe PPTX op zonder opmerkingen te verwijderen. Het gebruikt ook [ViewProperties.setLastView](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#setLastView) met [ViewType.SlideView](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewtype/#SlideView) om de initiële bewerkingsweergave naast de commentaar‑zichtbaarheid te configureren.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Deze instelling bepaalt niet of opmerkingen worden opgenomen in PDF-, HTML-, afbeelding-, notities- of hand‑out‑exports. Configureer de relevante export‑specifieke opties afzonderlijk.

## **FAQ**

**Waarom is het raster niet zichtbaar nadat ik de presentatie opnieuw heb geopend?**

Het bestand slaat de rasterafstand op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de raster‑zichtbaarheidsinstellingen van de editor.

**Verandert het wissen van teken‑gidsen de rasterafstand?**

Nee. Teken‑gidsen en rasterafstand zijn onafhankelijke instellingen. Het wissen van gidsen laat het opgeslagen rasterinterval ongewijzigd.

**Kan ik verschillende weergave‑instellingen instellen voor verschillende secties van een presentatie?**

[View settings](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getViewProperties) worden gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), niet per sectie, zodat één set parameters geldt voor het hele document bij het openen.

**Kan ik verschillende weergave‑toestanden vooraf definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en gedeeld. Viewer‑applicaties kunnen gebruikersvoorkeuren respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde View Properties zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getViewProperties) worden opgeslagen op presentatieniveau, kunt u ze in een sjabloon opnemen en nieuwe documenten daarvan maken met dezelfde initiële weergave‑configuratie.