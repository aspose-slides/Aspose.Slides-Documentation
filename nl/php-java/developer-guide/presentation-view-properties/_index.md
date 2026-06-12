---
title: Opvragen en bijwerken van presentatie-weergave-eigenschappen in PHP
linktitle: Weergave-eigenschappen
type: docs
weight: 80
url: /nl/php-java/presentation-view-properties/
keywords:
- weergave-eigenschappen
- normale weergave
- schematekst
- schema-iconen
- verticale scheidingsbalk vastzetten
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
description: "Ontdek Aspose.Slides voor PHP via Java weergave-eigenschappen om PPT, PPTX en ODP-dia's aan te passen - lay-outs, zoomniveaus en weergave-instellingen wijzigen."
---
## **Inleiding**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zijinhoudsgebied en een onderinhoudsgebied. Eigenschappen die betrekking hebben op de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavestatus op te slaan in het bestand, zodat bij het opnieuw openen de weergave zich in dezelfde staat bevindt als toen de presentatie voor het laatst werd opgeslagen.

De methode [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie. 

[NormalViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewRestoredProperties) klassen en hun afstammelingen, [SplitterBarStateType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SplitterBarStateType) enum zijn toegevoegd.

## **Over INormalViewProperties**

Stelt normale weergave‑eigenschappen voor.

Methoden [getShowOutlineIcons](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) en [setShowOutlineIcons](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) geven aan of de applicatie pictogrammen moet weergeven bij het tonen van schemavoorstellinginhoud in een van de inhoudsgebieden van de normale weergavemodus.

Methoden [getSnapVerticalSplitter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) en [setSnapVerticalSplitter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) geven aan of de verticale scheidingsbalk moet ‘snap’ naar een geminimaliseerde toestand wanneer het zijgebied voldoende klein is.

Eigenschap [getPreferSingleView](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) en [setPreferSingleView](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) geeft aan of de gebruiker de voorkeur geeft aan een enkel‑inhoudsgebied over het volledige venster in plaats van de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld kan de applicatie ervoor kiezen om een van de inhoudsgebieden over het gehele venster weer te geven.

Methoden [getVerticalBarState](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) bepalen de toestand waarin de horizontale of verticale scheidingsbalk moet worden weergegeven. Een horizontale scheidingsbalk scheidt de dia van het inhoudsgebied onder de dia, een verticale scheidingsbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SplitterBarStateType/#Maximized) en [SplitterBarStateType::Restored](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SplitterBarStateType/#Restored).

Methoden [getRestoredLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) en [getRestoredTop](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties#getRestoredTop) bepalen de afmetingen van respectievelijk het linkere of bovenste dia‑gebied van de normale weergave, wanneer de waarde [SplitterBarStateType::Restored](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SplitterBarStateType/#Restored) is toegepast op [getVerticalBarState](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) en [getHorizontalBarState](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) overeenkomstig.

## **Over het herstellen van INormalViewProperties**

Geeft de afmetingen van het dia‑gebied (breedte wanneer een kind van [getRestoredTop](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), hoogte wanneer een kind van [getRestoredLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) van de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (noch geminimaliseerd noch gemaximaliseerd). 

Methode [getDimensionSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) bepaalt de grootte van het dia‑gebied (breedte wanneer een kind van restoredTop, hoogte wanneer een kind van restoredLeft).

Methode [getAutoAdjust](https://reference.aspose.com/slides/nl/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) geeft aan of de grootte van het zij‑inhoudsgebied moet compenseren bij het aanpassen van de grootte van het venster dat de weergave bevat binnen de applicatie.

Hieronder staat een voorbeeld dat laat zien hoe u toegang kunt krijgen tot de eigenschappen van [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) voor een presentatie.

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
{{% alert color="primary" %}} 

Aspose.Slides voor PHP via Java ondersteunt nu het instellen van de standaard zoomwaarde voor een presentatie, zodat bij het openen van de presentatie de zoom al is ingesteld. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties) van een presentatie in te stellen. [getSlideViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) en [getNotesViewProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) kunnen programmatisch worden ingesteld. In dit onderwerp laten we aan de hand van een voorbeeld zien hoe u de [View Properties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties) van [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) in [Aspose.Slides](/slides/nl/) kunt instellen.

{{% /alert %}} 

Om de weergave‑eigenschappen in te stellen, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation).
1. Stel de [View Properties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ViewProperties) van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation) in.
1. Schrijf de presentatie weg als een [PPTX ](https://docs.fileformat.com/presentation/pptx/)bestand.  
   In het onderstaande voorbeeld hebben we de zoomwaarde ingesteld voor zowel de diavoorstelling als de notitie‑weergave.

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

## **FAQ**

**Kan ik verschillende weergave‑instellingen voor verschillende secties van een presentatie instellen?**

[View settings](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getviewproperties/) worden op presentatieniveau gedefinieerd ([Normal View](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/nl/php-java/aspose.slides/viewproperties/getslideviewproperties/)), niet per sectie, dus een enkele set parameters geldt voor het hele document bij het openen.

**Kan ik verschillende weergave‑toestanden vooraf definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en zijn gedeeld. Viewer‑applicaties kunnen de voorkeuren van de gebruiker respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde View Properties zodat nieuwe presentaties op dezelfde manier worden geopend?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getviewproperties/) op presentatieniveau worden opgeslagen, kunt u ze in een sjabloon opnemen en nieuwe documenten ervan maken met dezelfde initiële weergave‑configuratie.