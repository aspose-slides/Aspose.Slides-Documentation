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
- outline‑pictogrammen
- verticaal scheidingsbalk vastklikken
- enkele weergave
- balk‑status
- dimension‑grootte
- automatisch aanpassen
- standaard‑zoom
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Ontdek de weergave‑eigenschappen van Aspose.Slides voor Python via Java om PPT-, PPTX- en ODP‑dia’s aan te passen — lay‑outs, zoomniveaus en weergave‑instellingen te wijzigen."
---
## **Introductie**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zijinhoudsgebied en een onderste inhoudsgebied. Eigenschappen van de normale weergave beschrijven de positionering van deze inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavetoestand op te slaan in het bestand, zodat bij het opnieuw openen de weergave in dezelfde staat is als toen de presentatie voor het laatst werd opgeslagen.

De methode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getNormalViewProperties) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie.

De klassen [NormalViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/) en [NormalViewRestoredProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewrestoredproperties/) en de enumeratie [SplitterBarStateType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/splitterbarstatetype/) zijn toegevoegd.

## **Over NormalViewProperties**

Stelt de eigenschappen van de normale weergave voor.

De methoden [getShowOutlineIcons](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) en [setShowOutlineIcons](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) geven aan of de applicatie pictogrammen moet weergeven bij het tonen van outline‑inhoud in een van de inhoudsgebieden van de normale weergavemodus.

De methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) en [setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) bepalen of de verticale scheidingsbalk moet vastklikken in een geminimaliseerde toestand wanneer het zijgebied voldoende klein is.

De methoden [getPreferSingleView](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) en [setPreferSingleView](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) geven aan of de gebruiker de voorkeur geeft aan een volledig‑venster enkel‑inhoudsgebied boven de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie ervoor kiezen om één van de inhoudsgebieden in het volledige venster weer te geven.

De methoden [getVerticalBarState](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) geven de toestand aan waarin de horizontale of verticale scheidingsbalk moet worden weergegeven. Een horizontale scheidingsbalk scheidt de dia van het inhoudsgebied onder de dia; een verticale scheidingsbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nl/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nl/python-java/aspose.slides/splitterbarstatetype/#Maximized) en [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/python-java/aspose.slides/splitterbarstatetype/#Restored).

De methoden [getRestoredLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) en [getRestoredTop](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredTop) geven de afmetingen aan van respectievelijk het boven‑ of zij‑dia‑gebied van de normale weergave, wanneer de waarde [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nl/python-java/aspose.slides/splitterbarstatetype/#Restored) wordt toegepast op [getVerticalBarState](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState).

## **Over het herstellen van NormalViewProperties**

Specificeert de afmetingen van het dia‑gebied (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredTop), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) van de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (niet geminimaliseerd noch gemaximaliseerd).

De methode [getDimensionSize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) specificeert de grootte van het dia‑gebied (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredTop), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

De methode [getAutoAdjust](https://reference.aspose.com/slides/nl/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) geeft aan of de grootte van het zij‑inhoudsgebied moet compenseren voor de nieuwe grootte bij het aanpassen van de grootte van het venster dat de weergave bevat binnen de applicatie.

Het onderstaande voorbeeld laat zien hoe men [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getNormalViewProperties) kan benaderen voor een presentatie.

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

    # Herstel de weergave‑eigenschappen van de presentatie.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Stel de standaard zoomwaarde in**

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java ondersteunt het instellen van de standaard zoomwaarde zodat deze al wordt toegepast wanneer de presentatie wordt geopend. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/) van een presentatie in te stellen. [getSlideViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getSlideViewProperties) en [getNotesViewProperties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getNotesViewProperties) kunnen programmatisch worden geconfigureerd. In dit onderwerp laten we met een voorbeeld zien hoe de [View Properties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/) van [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) in [Aspose.Slides](/slides/nl/) te setten.

{{% /alert %}}

Om de weergave‑eigenschappen in te stellen, volgt u de volgende stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) aan.
1. Stel de [View Properties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/) van [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) in.
1. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

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
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Zoompercentage voor diaweergave.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Zoompercentage voor notitie‑weergave.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik verschillende weergave‑instellingen instellen voor verschillende secties van een presentatie?**

[View settings](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getViewProperties) worden gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), niet per sectie, dus een enkele set parameters is van toepassing op het volledige document bij het openen.

**Kan ik vooraf verschillende weergavetoestanden definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en zijn gedeeld. Viewer‑applicaties kunnen mogelijk rekening houden met gebruikersvoorkeuren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde View Properties zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getViewProperties) worden opgeslagen op presentatieniveau, kunt u ze opnemen in een sjabloon en nieuwe documenten daarvan creëren met dezelfde initiële weergave‑configuratie.