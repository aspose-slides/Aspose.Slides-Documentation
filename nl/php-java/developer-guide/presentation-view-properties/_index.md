---
title: Opvragen en bijwerken van presentatie-weergave-eigenschappen in PHP
linktitle: Weergave-eigenschappen
type: docs
weight: 80
url: /nl/php-java/presentation-view-properties/
keywords:
- weergave-eigenschappen
- normale weergave
- outline-inhoud
- outline-pictogrammen
- verticale splitter vastzetten
- enkele weergave
- balkstatus
- afmeting
- automatische aanpassing
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek de weergave-eigenschappen van Aspose.Slides for PHP via Java om PPT-, PPTX- en ODP-dia's aan te passen — lay-outs, zoomniveaus en weergave-instellingen te wijzigen."
---
## **Inleiding**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zij‑inhoudsgebied en een onder‑inhoudsgebied. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavestatus op te slaan in het bestand, zodat bij het opnieuw openen de weergave zich in dezelfde staat bevindt als toen de presentatie voor het laatst werd opgeslagen.

Methode [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie.  

[NormalViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewRestoredProperties) klassen en hun afstammelingen, [SplitterBarStateType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SplitterBarStateType) enum zijn toegevoegd.

## **Over INormalViewProperties**

Stelt de normale weergave‑eigenschappen voor.

De methoden [getShowOutlineIcons](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) en [setShowOutlineIcons](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) geven aan of de applicatie pictogrammen moet weergeven bij het tonen van de outline‑inhoud in een van de inhoudsgebieden van de normale weergavemodus.

De methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) en [setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) geven aan of de verticale splitter moet 'snappen' naar een geminimaliseerde staat wanneer het zijgebied voldoende klein is.

De eigenschap [getPreferSingleView](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) en [setPreferSingleView](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) geeft aan of de gebruiker de voorkeur heeft om een enkel‑inhoudsgebied over het volledige venster te zien in plaats van de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld kan de applicatie ervoor kiezen om één van de inhoudsgebieden in het gehele venster weer te geven.

De methoden [getVerticalBarState](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) bepalen de staat waarin de horizontale of verticale splitter‑balk moet worden weergegeven. Een horizontale splitter‑balk scheidt de dia van het inhoudsgebied onder de dia, een verticale splitter‑balk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SplitterBarStateType/#Maximized) en [SplitterBarStateType::Restored](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SplitterBarStateType/#Restored).

De methoden [getRestoredLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) en [getRestoredTop](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties#getRestoredTop) specificeren de afmetingen van respectievelijk het boven‑ of zij‑dia‑gebied van de normale weergave wanneer de waarde [SplitterBarStateType::Restored](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SplitterBarStateType/#Restored) van [getVerticalBarState](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) is toegepast.

## **Over het herstellen van INormalViewProperties**

Specificeert de afmeting van het dia‑gebied (breedte wanneer het een kind is van [getRestoredTop](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), hoogte wanneer het een kind is van [getRestoredLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) van de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (noch geminimaliseerd noch gemaximaliseerd).  

Methode [getDimensionSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) geeft de grootte van het dia‑gebied (breedte wanneer het een kind is van restoredTop, hoogte wanneer het een kind is van restoredLeft) aan.  

Methode [getAutoAdjust](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) geeft aan of de grootte van het zij‑inhoudsgebied moet compenseren voor de nieuwe grootte bij het wijzigen van de grootte van het venster dat de weergave bevat binnen de applicatie.  

Een voorbeeld hieronder toont hoe u toegang kunt krijgen tot de eigenschappen van [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) voor een presentatie.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Herstel de weergave-eigenschappen van de presentatie
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Instellen van de standaard zoomwaarde**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java ondersteunt nu het instellen van de standaard zoomwaarde voor een presentatie, zodat de zoom al is ingesteld wanneer de presentatie wordt geopend. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties) van een presentatie in te stellen. [getSlideViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) en [getNotesViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) kunnen programmatic worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe de [View Properties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties) van [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) in Aspose.Slides kunnen worden ingesteld.

{{% /alert %}} 

Om de weergave‑eigenschappen in te stellen, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) aan.  
1. Stel de [View Properties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties) van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) in.  
1. Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.  
   In het onderstaande voorbeeld hebben we zowel de zoomwaarde voor de dia‑weergave als voor de notitie‑weergave ingesteld.

```php
  $presentation = new Presentation();
  try {
    # Instellen van de weergave-eigenschappen van de presentatie
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Zoomwaarde in percentages voor diavoorstelling
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Zoomwaarde in percentages voor notitie-weergave

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Instellen van de rasterafstand**

Gebruik [Presentation::getViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getViewProperties) om toegang te krijgen tot de weergave‑instellingen voor de hele presentatie. De methoden [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/#getGridSpacing) en [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/#setGridSpacing) lezen of wijzigen het interval van het onderliggende bewerkingsraster. Deze instelling is van toepassing op de gehele presentatie, niet op een afzonderlijke dia. Rasterafstand wordt opgegeven in punten, waarbij 72 punten gelijk zijn aan één inch. Gebruik een positieve waarde, zoals vereist door de API‑documentatie.

Het volgende voorbeeld opent een bestaand `demo.pptx`, drukt de huidige rasterafstand af, stelt een kwart‑inch interval in en slaat het resultaat op.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het raster verschilt van [drawing guides](/slides/nl/php-java/drawing-guides/). Rasterafstand regelt een regelmatig interval, terwijl tekengidsen afzonderlijk gepositioneerde horizontale of verticale uitlijningslijnen zijn. Het toevoegen, verplaatsen of verwijderen van tekengidsen verandert de rasterafstand niet.

Zowel het raster als de tekengidsen zijn hulpmiddelen bij het bewerken. Ze worden niet gerenderd als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterafstand garandeert niet dat een editor het raster weergeeft: de zichtbaarheid hangt ook af van de voorkeuren van de viewer of editor.

## **FAQ**

**Waarom is het raster niet zichtbaar na het opnieuw openen van de presentatie?**

Het bestand slaat de rasterafstand op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de raster‑zichtbaarheidsinstellingen van de editor.

**Verandert het wissen van tekengidsen de rasterafstand?**

Nee. Tekengidsen en rasterafstand zijn onafhankelijk van elkaar. Het wissen van gidsen laat het opgeslagen raster‑interval ongewijzigd.

**Kan ik verschillende weergave‑instellingen instellen voor verschillende secties van een presentatie?**

[View settings](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getviewproperties/) worden gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/getslideviewproperties/)), niet per sectie, dus één set parameters geldt voor het gehele document bij het openen.

**Kan ik vooraf verschillende weergavetoestanden definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en zijn gedeeld. Viewer‑applicaties kunnen de voorkeuren van de gebruiker respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde View Properties zodat nieuwe presentaties op dezelfde manier worden geopend?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getviewproperties/) worden opgeslagen op presentatieniveau, kunt u ze in een sjabloon opnemen en nieuwe documenten ervan maken met dezelfde initiële weergave‑configuratie.