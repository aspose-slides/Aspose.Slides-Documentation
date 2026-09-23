---
title: Presentatie-weergave-eigenschappen ophalen en bijwerken in PHP
linktitle: Weergave-eigenschappen
type: docs
weight: 80
url: /nl/php-java/presentation-view-properties/
keywords:
- weergave-eigenschappen
- normale weergave
- outline-inhoud
- outline-pictogrammen
- snap verticale splitter
- enkele weergave
- balktoestand
- dimensiegrootte
- automatisch aanpassen
- standaard zoom
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek de weergave-eigenschappen van Aspose.Slides voor PHP via Java om PPT-, PPTX- en ODP-dia's aan te passen — pas indelingen, zoomniveaus en weergave-instellingen aan."
---
## **Inleiding**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zij‑inhoudsgebied en een onderin inhoudsgebied. Eigenschappen met betrekking tot de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavetoestand op te slaan in het bestand, zodat bij het opnieuw openen de weergave zich in dezelfde toestand bevindt als toen de presentatie voor het laatst werd opgeslagen.

Methode [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van de presentatie.

De klassen [NormalViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewRestoredProperties) en hun afstammelingen, en de enum [SplitterBarStateType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SplitterBarStateType) zijn toegevoegd.

## **Over INormalViewProperties**

Vertegenwoordigt de normale weergave‑eigenschappen.

De methoden [getShowOutlineIcons](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) en [setShowOutlineIcons](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) geven aan of de applicatie pictogrammen moet tonen bij het weergeven van outline‑inhoud in een van de inhoudsgebieden van de normale weergavemodus.

De methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) en [setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) geven aan of de verticale splitsbalk moet “snap” naar een geminimaliseerde toestand wanneer het zijgebied voldoende klein is.

De eigenschap [getPreferSingleView](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) en [setPreferSingleView](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) geeft aan of de gebruiker de voorkeur geeft aan een enkel‑inhoudsgebied dat het volledige venster beslaat boven de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie ervoor kiezen om een van de inhoudsgebieden over het gehele venster weer te geven.

De methoden [getVerticalBarState](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) specificeren de toestand waarin de horizontale of verticale splitsbalk moet worden weergegeven. Een horizontale splitsbalk scheidt de dia van het inhoudsgebied onder de dia, een verticale splitsbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SplitterBarStateType/#Maximized) en [SplitterBarStateType::Restored](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SplitterBarStateType/#Restored).

De methoden [getRestoredLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) en [getRestoredTop](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties#getRestoredTop) geven de afmetingen van respectievelijk het linker‑ of boven‑inhoudsgebied van de normale weergave aan, wanneer de [SplitterBarStateType::Restored](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SplitterBarStateType/#Restored)‑waarde wordt toegepast op [getVerticalBarState](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) overeenkomstig.

## **Over het herstellen van INormalViewProperties**

Geeft de afmetingen van het dia‑gebied (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) van de normale weergave aan, wanneer het gebied een variabele herstelde grootte heeft (noch geminimaliseerd, noch gemaximaliseerd).

De methode [getDimensionSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) specificeert de grootte van het dia‑gebied (breedte wanneer een kind van restoredTop, hoogte wanneer een kind van restoredLeft).

De methode [getAutoAdjust](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) geeft aan of de grootte van het zij‑inhoudsgebied moet compenseren voor de nieuwe afmeting bij het wijzigen van de grootte van het venster dat de weergave bevat binnen de applicatie.

Een voorbeeld hieronder toont hoe u de [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties/#getNormalViewProperties)‑eigenschappen van een presentatie kunt benaderen.

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

## **Stel de standaard zoomwaarde in**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java ondersteunt nu het instellen van de standaard zoomwaarde voor een presentatie, zodat bij het openen van de presentatie de zoom al is ingesteld. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties) van een presentatie in te stellen. [getSlideViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) en [getNotesViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) kunnen programmatic worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe de [View Properties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties) van [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) in Aspose.Slides kunnen worden ingesteld.

{{% /alert %}} 

Om de weergave‑eigenschappen in te stellen, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) aan.
2. Stel de [View Properties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties) van [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) in.
3. Schrijf de presentatie als een [PPTX ](https://docs.fileformat.com/presentation/pptx/)bestand. In het onderstaande voorbeeld hebben we de zoomwaarde ingesteld voor zowel de diaweergave als de notitieweergave.

```php
  $presentation = new Presentation();
  try {
    # Instellen van de weergave‑eigenschappen van de presentatie
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Zoomwaarde in procenten voor diaweergave
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Zoomwaarde in procenten voor notitie‑weergave

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Stel de rasterafstand in**

Gebruik [Presentation::getViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getViewProperties) om de weergave‑instellingen voor de gehele presentatie te benaderen. De methoden [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/#getGridSpacing) en [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/#setGridSpacing) lezen of wijzigen het interval van het onderliggende bewerkingsraster. Deze instelling geldt voor de hele presentatie, niet voor een enkele dia. Rasterafstand wordt opgegeven in points, waarbij 72 points gelijk zijn aan één inch. Gebruik een positieve waarde, zoals vereist in de API‑documentatie.

Het volgende voorbeeld opent een bestaande `demo.pptx`, geeft de huidige rasterafstand weer, stelt een kwart‑inch interval in, en slaat het resultaat op.

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

Het raster verschilt van [drawing guides](/slides/nl/php-java/drawing-guides/). Rasterafstand regelt een regelmatig interval, terwijl tekengidsen individueel gepositioneerde horizontale of verticale uitlijningslijnen zijn. Het toevoegen, verplaatsen of verwijderen van tekengidsen wijzigt de rasterafstand niet.

Zowel het raster als tekengidsen zijn hulpmiddelen bij het bewerken. Ze worden niet weergegeven als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterafstand garandeert niet dat een editor het raster weergeeft: de zichtbaarheid hiervan hangt ook af van de voorkeuren van de viewer of editor.

## **Toon of verberg commentaren bij het openen van een presentatie**

Gebruik [Presentation::getViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getviewproperties/) om de weergave‑instellingen voor de gehele presentatie te benaderen. Gebruik [ViewProperties::getShowComments](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/getshowcomments/) en [ViewProperties::setShowComments](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/setshowcomments/) om de opgeslagen voorkeur te lezen of te wijzigen of commentaren getoond moeten worden wanneer de presentatie wordt geopend in PowerPoint of een andere compatibele editor.

Deze instelling regelt alleen de opgeslagen weergavevoorkeur. Het voegt geen commentaren toe, verwijdert ze niet, bewerkt of lost ze niet op. Het verbergen van commentaren behoudt hun inhoud, auteurs, posities, antwoorden en statussen. Zie [Presentation Comments](/slides/nl/php-java/presentation-comments/) voor bewerkingen die de commentaren zelf wijzigen.

Het volgende voorbeeld vereist een bestaande `comments.pptx` met commentaren. Het geeft de huidige zichtbaarheid weer, vraagt om commentaren te verbergen, en slaat een nieuwe PPTX op zonder commentaren te verwijderen. Het gebruikt ook [ViewProperties::setLastView](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/setlastview/) met [ViewType::SlideView](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewtype/#SlideView) om de initiële bewerkingsweergave in te stellen naast de commentaarzichtbaarheid.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Deze instelling bepaalt niet of commentaren worden opgenomen in PDF-, HTML-, afbeelding-, notitie- of handout‑exporten. Configureer de relevante export‑specifieke opties afzonderlijk.

## **Veelgestelde vragen**

**Waarom is het raster niet zichtbaar nadat ik de presentatie opnieuw open?**

Het bestand slaat de rasterafstand op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de rasterzichtbaarheidsinstellingen van de editor.

**Verandert het verwijderen van tekengidsen de rasterafstand?**

Nee. Tekengidsen en rasterafstand zijn onafhankelijke instellingen. Het verwijderen van gidsen laat het opgeslagen rasterinterval ongewijzigd.

**Kan ik verschillende weergave‑instellingen instellen voor verschillende secties van een presentatie?**

[View settings](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getviewproperties/) worden gedefinieerd op presentatieniveau (Normal View/Slide View), niet per sectie, dus een enkele set parameters is van toepassing op het volledige document bij het openen.

**Kan ik vooraf verschillende weergave‑toestanden definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en gedeeld. Viewer‑applicaties kunnen de gebruikersvoorkeuren respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde View Properties zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getviewproperties/) worden opgeslagen op presentatieniveau, kun je ze in een sjabloon opnemen en nieuwe documenten ervan maken met dezelfde initiële weergaveconfiguratie.