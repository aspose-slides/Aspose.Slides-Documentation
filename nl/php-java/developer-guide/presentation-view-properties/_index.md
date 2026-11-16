---
title: Ophalen en bijwerken van presentatie‑weergave‑eigenschappen in PHP
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/php-java/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- structuurinhoud
- structuur‑pictogrammen
- verticale splitter vastzetten
- enkele weergave
- balkstatus
- dimensiegrootte
- automatisch aanpassen
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Gebruik Aspose.Slides voor PHP via Java om de lay‑out van de normale weergave, de zoom van dia’s en notities, de rasterafstand en de zichtbaarheid van opmerkingen in PowerPoint‑presentaties te configureren."
---
## **Inleiding**

In de normale weergave van PowerPoint wordt de dia weergegeven tussen een zijpaneel voor miniaturen of een structuur en een notitiepaneel eronder. Aspose.Slides for PHP via Java maakt de opgeslagen bewerkvoorkeuren van de presentatie beschikbaar via [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/). Deze omvatten de paneelindeling, zoomniveaus, rasterafstand en zichtbaarheid van opmerkingen.

## **Over NormalViewProperties**

Gebruik [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) om toegang te krijgen tot de klasse [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) bepaalt of er pictogrammen naast de titels van dia's in de structuur verschijnen. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) zorgt ervoor dat het zijpaneel naar zijn geminimaliseerde staat springt wanneer de gebruiker het vernauwt. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) geeft de voorkeur aan het weergeven van één paneel in het volledige venster.

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) regelt de scheiding tussen het zijpaneel en de dia. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) regelt de scheiding boven het notitiepaneel. Beide accepteren een waarde van type [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/): `Minimized`, `Maximized` of `Restored`.

## **Over het herstellen van NormalViewProperties**

Wanneer een scheiding wordt hersteld, levert [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) de opgeslagen grootte van het zijpaneel en levert [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) de opgeslagen grootte van het bovenste dia‑gebied. Beide geven toegang tot [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/). Zijn methode [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) accepteert een percentage van 0 tot 100, en [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) bepaalt of de editor de grootte aanpast wanneer het venster van formaat verandert.

Dit voorbeeld werkt een bestaande presentatie bij. Het herstelt de horizontale scheiding, stelt de grootte die wordt teruggegeven door [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) in op 80% met automatische aanpassing ingeschakeld, en maximaliseert de verticale scheiding. Het roept ook [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) aan om pictogrammen in de structuurweergave weer te geven.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Stel de standaard zoomwaarde in**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) en [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) slaan onafhankelijke zoominstellingen op voor de editor. Deze instellingen hebben geen invloed op de afmetingen van dia's, de weergave van diavoorstellingen of de resolutie bij het exporteren van afbeeldingen.

Dit voorbeeld opent een bestaande presentatie en roept [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) aan om de dia aan te passen aan het bewerkingsvenster. Voor de notitiepagina schakelt het automatische schalen uit en roept het [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) aan om een vaste zoom van 80% in te stellen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Stel de rasterafstand in**

De methode `setGridSpacing` van [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) stelt de afstand tussen bewerkingsrasterlijnen in de hele presentatie in. Het neemt een positieve waarde in punten, met 72 punten per inch. Dit voorbeeld geeft de huidige afstand weer in een bestaande presentatie en slaat een kwart‑inch raster op door het interval op 18 punten te zetten.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het raster herhaalt zich met een vaste interval. [Drawing guides](/slides/nl/php-java/drawing-guides/) markeren individuele horizontale of verticale posities. Beide zijn hulpmiddelen bij het bewerken en verschijnen alleen in editors die ze weergeven. Diavoorstellingen en export naar PDF, afbeeldingen of SVG laten ze weg.

## **Opmerkingen weergeven of verbergen bij het openen van een presentatie**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) slaat een voorkeur op die compatibele editors gebruiken bij het openen van de presentatie. Voor een bestaande presentatie met opmerkingen geeft dit voorbeeld de huidige instelling weer en slaat een kopie op met verborgen opmerkingen. Het roept ook [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) aan met [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) zodat de kopie wordt geopend in de diaweergave.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het verbergen van opmerkingen behoudt hun tekst, auteurs, posities, antwoorden en statussen. Om de opmerkingen zelf te wijzigen, zie [Presentation Comments](/slides/nl/php-java/presentation-comments/). Exporteerinstellingen bepalen of opmerkingen verschijnen in PDF, HTML, afbeeldingen, notities of hand‑outs.

## **FAQ**

**Waarom is het raster verborgen wanneer ik de presentatie opnieuw open?**  
De presentatie slaat het rasterinterval op. Om het raster te zien, schakel de rasterzichtbaarheid in de editor in.

**Verandert het wissen van tekengidsen de rasterafstand?**  
Nee. Het toevoegen, verplaatsen of wissen van een gids laat het rasterinterval ongewijzigd.

**Kunnen verschillende secties van een presentatie verschillende weergave‑instellingen hebben?**  
Nee. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) geldt voor de hele presentatie.

**Kan ik verschillende weergave‑instellingen opslaan voor verschillende gebruikers?**  
Het bestand slaat één set weergave‑eigenschappen op voor iedereen. Een editor kan bovendien de lokale voorkeuren van een gebruiker toepassen.

**Kan ik weergave‑instellingen opslaan in een sjabloon?**  
Ja. Presentaties die uit het sjabloon worden gemaakt, overnemen de opgeslagen weergave‑instellingen.