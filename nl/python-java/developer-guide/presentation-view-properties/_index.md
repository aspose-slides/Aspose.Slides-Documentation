---
title: Ophalen en bijwerken van presentatieweergave‑eigenschappen in Python via Java
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/python-java/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- overzichtsinhoud
- overzichtspictogrammen
- snap verticale scheidingsbalk
- enkele weergave
- balkstatus
- dimensiegrootte
- automatische aanpassing
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Gebruik Aspose.Slides for Python via Java om de layout van de normale weergave, de zoom van dia en notities, de rasterafstand en de zichtbaarheid van opmerkingen in PowerPoint‑presentaties te configureren."
---
## **Introductie**

In de normale weergave van PowerPoint wordt de dia weergegeven tussen een zijpaneel voor miniaturen of een overzicht en een notitiepaneel onderaan. Aspose.Slides for Python via Java maakt de opgeslagen bewerkingsvoorkeuren van de presentatie beschikbaar via [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties). Deze omvatten de lay-out van de panelen, zoomniveaus, rasterafstand en zichtbaarheid van opmerkingen.

## **Over NormalViewProperties**

Gebruik [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) om toegang te krijgen tot de klasse [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) bepaalt of er pictogrammen naast de diatitels in het overzicht verschijnen. [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) laat het zijpaneel snapen naar zijn geminimaliseerde toestand wanneer de gebruiker het verkleint. [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) geeft de voorkeur aan het weergeven van één paneel in het volledige venster.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) regelt de scheiding tussen het zijpaneel en de dia. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) regelt de scheiding boven het notitiepaneel. Beide accepteren een [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) waarde van `Minimized`, `Maximized` of `Restored`.

## **Over het herstellen van NormalViewProperties**

Wanneer een scheiding wordt hersteld, levert [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) de opgeslagen grootte van het zijpaneel en levert [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) de opgeslagen grootte van het bovenste dia‑gebied. Beide geven een instantie terug van [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/). De methode [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) accepteert een percentage van 0 tot 100, en [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) bepaalt of de editor de grootte aanpast wanneer het venster wordt gewijzigd.

Dit voorbeeld werkt een bestaande presentatie bij. Het herstelt de horizontale scheiding, stelt de grootte die door [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) wordt geretourneerd in op 80% met automatische aanpassing ingeschakeld, en maximaliseert de verticale scheiding. Het roept ook [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) aan om pictogrammen weer te geven in de overzichtsweergave.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Stel de standaardzoomwaarde in**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) en [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) slaan afzonderlijke zoominstellingen op voor de editor. Deze instellingen hebben geen invloed op de afmetingen van de dia, de weergave van de diavoorstelling of de resolutie van de afbeeldingsexport.

Dit voorbeeld opent een bestaande presentatie en roept [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) aan om de dia aan te passen aan het bewerkingsvenster. Voor de notitiepagina schakelt het automatische schaling uit en roept [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) aan om een vaste zoom van 80% in te stellen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Stel de rasterafstand in**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) stelt de afstand tussen bewerkingsrasterlijnen in de hele presentatie in. Het neemt een positieve waarde in punten, waarbij 72 punten gelijk zijn aan een inch. Dit voorbeeld toont de huidige afstand in een bestaande presentatie en slaat een kwart‑inch raster op door het interval in te stellen op 18 punten.

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

Het raster herhaalt zich met een vast interval. [Tekengidsen](/slides/nl/python-java/drawing-guides/) markeren individuele horizontale of verticale posities. Beide zijn hulpmiddelen bij het bewerken en verschijnen alleen in editors die ze tonen. Diavoorstellingen en exports naar PDF, afbeeldingen of SVG laten ze weg.

## **Toon of verberg opmerkingen bij het openen van een presentatie**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) slaat een voorkeur op die compatibele editors gebruiken bij het openen van de presentatie. Voor een bestaande presentatie met opmerkingen toont dit voorbeeld de huidige instelling en slaat een kopie op met verborgen opmerkingen. Het roept ook [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) aan met [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) zodat de kopie in de diaweergave wordt geopend.

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

Het verbergen van opmerkingen behoudt hun tekst, auteurs, posities, antwoorden en statussen. Om de opmerkingen zelf te wijzigen, zie [Presentatie‑opmerkingen](/slides/nl/python-java/presentation-comments/). Exportinstellingen bepalen of opmerkingen verschijnen in PDF, HTML, afbeeldingen, notities of hand‑outs.

## **FAQ**

**Waarom is het raster verborgen wanneer ik de presentatie opnieuw open?**

De presentatie slaat het rasterinterval op. Om het raster te zien, schakel de rasterzichtbaarheid in de editor in.

**Verandert het wissen van tekengidsen de rasterafstand?**

Nee. Het toevoegen, verplaatsen of wissen van een gids laat het rasterinterval ongewijzigd.

**Kunnen verschillende secties van een presentatie verschillende weergave‑instellingen hebben?**

Nee. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) geldt voor de volledige presentatie.

**Kan ik verschillende weergave‑instellingen opslaan voor verschillende gebruikers?**

Het bestand slaat één set weergave‑eigenschappen op voor iedereen. Een editor kan bovendien de lokale voorkeuren van een gebruiker toepassen.

**Kan ik weergave‑instellingen opslaan in een sjabloon?**

Ja. Presentaties die vanuit het sjabloon zijn gemaakt, erven de opgeslagen weergave‑instellingen van dat sjabloon.