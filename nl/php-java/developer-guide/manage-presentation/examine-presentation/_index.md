---
title: Presentatie-informatie ophalen en bijwerken in PHP
linktitle: Presentatie-informatie
type: docs
weight: 30
url: /nl/php-java/examine-presentation/
keywords:
- presentatieformaat
- presentatie-eigenschappen
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
description: "Ontdek dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor PHP voor snellere inzichten en slimmere inhoudsaudits."
---
## **Overzicht**

Dit artikel laat zien hoe je presentatiesinformatie in Aspose.Slides kunt inspecteren. Het legt uit hoe je het huidige formaat van een presentatie kunt bepalen zonder het volledige bestand te laden, de documenteigenschappen kunt lezen en die eigenschappen indien nodig kunt bijwerken.

De voorbeelden zijn gebaseerd op de [PresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/) en [DocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/) API's en tonen typische bewerkingen voor het werken met presentatiemetadata.

## **Controleer een presentatieformaat**

Voordat je aan een presentatie werkt, wil je wellicht weten in welk formaat (PPT, PPTX, ODP en andere) de presentatie momenteel is.

Je kunt het formaat van een presentatie controleren zonder de presentatie te laden. Zie deze PHP-code:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Presentatie‑eigenschappen ophalen**

Deze PHP‑code laat zien hoe je presentatie‑eigenschappen kunt ophalen (informatie over de presentatie):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

Misschien wil je de [eigenschappen onder de DocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#DocumentProperties--) klasse bekijken.

## **Presentatie‑eigenschappen bijwerken**

Aspose.Slides biedt de [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) methode waarmee je wijzigingen kunt aanbrengen in presentatie‑eigenschappen.

Stel dat we een PowerPoint‑presentatie hebben met de hieronder weergegeven documenteigenschappen.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Dit code‑voorbeeld laat zien hoe je enkele presentatie‑eigenschappen kunt bewerken:

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

Voor meer informatie over een presentatie en diens beveiligingskenmerken kunnen deze links nuttig zijn:

- [Controleren of een presentatie versleuteld is](https://docs.aspose.com/slides/nl/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Controleren of een presentatie schrijf beschermd is (alleen‑lezen)](https://docs.aspose.com/slides/nl/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Controleren of een presentatie met een wachtwoord beschermd is voordat deze wordt geladen](https://docs.aspose.com/slides/nl/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bevestigen van het wachtwoord dat gebruikt is om een presentatie te beschermen](https://docs.aspose.com/slides/nl/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Zoek naar [informatie over ingesloten lettertypen](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/getembeddedfonts/) op presentatieniveau, en vergelijk die vermeldingen vervolgens met de verzameling [lettertypen die daadwerkelijk in de inhoud worden gebruikt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/getfonts/) om te bepalen welke lettertypen cruciaal zijn voor weergave.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel?**

Loop door de [dia‑collectie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/) en inspecteer de [zichtbaarheidsvlag](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/gethidden/) van elke dia.

**Kan ik detecteren of er een aangepaste dia‑grootte en -oriëntatie wordt gebruikt, en of deze afwijkt van de standaardinstellingen?**

Ja. Vergelijk de huidige [dia‑grootte](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getslidesize/) en oriëntatie met de standaardpresets; dit helpt bij het voorspellen van het gedrag bij afdrukken en export.

**Is er een snelle manier om te zien of grafieken naar externe gegevensbronnen verwijzen?**

Ja. Doorloop alle [grafieken](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/), controleer hun [gegevensbron](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/getdatasourcetype/) en let op of de gegevens intern of op een link gebaseerd zijn, inclusief eventuele verbroken links.

**Hoe kan ik 'zware' dia's beoordelen die de weergave of PDF‑export kunnen vertragen?**

Tel per dia het aantal objecten en kijk naar grote afbeeldingen, transparantie, schaduwen, animaties en multimedia; wijs een ruwe complexiteitsscore toe om mogelijke prestatieknelpunten te signaleren.