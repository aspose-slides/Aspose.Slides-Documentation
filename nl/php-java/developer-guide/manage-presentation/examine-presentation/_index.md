---
title: Ophalen en bijwerken van presentatiesinformatie in PHP
linktitle: Presentatie‑informatie
type: docs
weight: 30
url: /nl/php-java/examine-presentation/
keywords:
- presentatieformaat
- presentatieweigenschappen
- documenteigenschappen
- eigenschappen ophalen
- eigenschappen lezen
- eigenschappen wijzigen
- eigenschappen aanpassen
- eigenschappen bijwerken
- PPTX onderzoeken
- PPT onderzoeken
- ODP onderzoeken
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek dia's, structuur en metadata in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor PHP voor snellere inzichten en slimmere inhoudsaudits."
---
## **Overzicht**

Dit artikel laat zien hoe u presentatiesinformatie in Aspose.Slides kunt inspecteren. Het legt uit hoe u het huidige formaat van een presentatie kunt bepalen zonder het volledige bestand te laden, de documenteigenschappen kunt lezen en die eigenschappen indien nodig kunt bijwerken.

De voorbeelden zijn gebaseerd op de PresentationInfo‑ en DocumentProperties‑API’s en demonstreren typische bewerkingen voor het werken met presentatiemetagegevens.

## **Controleer een presentatieformaat**

Voordat u aan een presentatie werkt, wilt u wellicht weten in welk formaat (PPT, PPTX, ODP en andere) de presentatie zich momenteel bevindt.

U kunt het formaat van een presentatie controleren zonder de presentatie te laden. Zie deze PHP‑code:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Verkrijg presentatieweigenschappen**

Deze PHP‑code laat zien hoe u presentatieweigenschappen kunt ophalen (informatie over de presentatie):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

U wilt wellicht de eigenschappen bekijken onder de DocumentProperties‑klasse.

## **Werk presentatieweigenschappen bij**

Aspose.Slides biedt de methode PresentationInfo.updateDocumentProperties die u in staat stelt wijzigingen aan te brengen in presentatieweigenschappen.

Laten we zeggen dat we een PowerPoint‑presentatie hebben met de onderstaande documenteigenschappen.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Dit codevoorbeeld laat zien hoe u enkele presentatieweigenschappen kunt bewerken:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

De resultaten van het wijzigen van de documenteigenschappen worden hieronder getoond.

![Gewijzigde documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige links**

Voor meer informatie over een presentatie en de beveiligingsattributen kunt u deze links nuttig vinden:

- [Presentaties met wachtwoord beveiligen](/slides/nl/php-java/password-protected-presentation/)
- [Presentaties tegen schrijven beveiligen](/slides/nl/php-java/write-protected-presentation/)

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Zoek naar [ingesloten-lettertype-informatie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/getembeddedfonts/) op presentatieniveau, en vergelijk die vermeldingen vervolgens met de set van [lettertypen die daadwerkelijk in de inhoud worden gebruikt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/getfonts/) om te bepalen welke lettertypen cruciaal zijn voor de weergave.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel?**

Itereer door de [slide collection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/) en inspecteer de [visibility flag](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/gethidden/) van elke dia.

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie worden gebruikt, en of die afwijken van de standaardinstellingen?**

Ja. Vergelijk de huidige [slide size](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getslidesize/) en oriëntatie met de standaard presets; dit helpt om het gedrag voor afdrukken en export te voorspellen.

**Is er een snelle manier om te zien of grafieken naar externe gegevensbronnen verwijzen?**

Ja. Doorloop alle [charts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/), controleer hun [data source](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/getdatasourcetype/) en noteer of de gegevens intern of via een koppeling zijn, inclusief eventuele gebroken links.

**Hoe kan ik 'zware' dia's beoordelen die de weergave of PDF‑export kunnen vertragen?**

Voor elke dia telt u het aantal objecten en zoekt u naar grote afbeeldingen, transparantie, schaduwen, animaties en multimedia; wijs een ruwe complexiteitsscore toe om potentiële prestatieknelpunten te markeren.