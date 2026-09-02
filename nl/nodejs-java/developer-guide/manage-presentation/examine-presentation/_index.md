---
title: Presentatie-informatie ophalen en bijwerken in JavaScript
linktitle: Presentatie-informatie
type: docs
weight: 30
url: /nl/nodejs-java/examine-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ontdek dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met JavaScript voor snellere inzichten en slimmere content-audits."
---
## **Overzicht**

Dit artikel laat zien hoe u presentatiesinformatie in Aspose.Slides kunt inspecteren. Het legt uit hoe u het huidige formaat van een presentatie kunt bepalen zonder het volledige bestand te laden, de documenteigenschappen kunt lezen en die eigenschappen kunt bijwerken wanneer dat nodig is.

De voorbeelden zijn gebaseerd op de [PresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/) en [DocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/) API's en demonstreren typische bewerkingen voor het werken met presentatiemetadata.

## **Controleer het formaat van een presentatie**

Voordat u aan een presentatie werkt, wilt u mogelijk weten in welk formaat (PPT, PPTX, ODP en andere) de presentatie zich momenteel bevindt.

U kunt het formaat van een presentatie controleren zonder de presentatie te laden. Zie deze JavaScript‑code:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Presentatie‑eigenschappen ophalen**

Deze JavaScript‑code toont u hoe u presentatie‑eigenschappen (informatie over de presentatie) kunt verkrijgen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

U wilt mogelijk de [eigenschappen onder de DocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) klasse bekijken.

## **Presentatie‑eigenschappen bijwerken**

Aspose.Slides biedt de [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) methode die u in staat stelt wijzigingen aan te brengen in presentatie‑eigenschappen.

Stel dat we een PowerPoint‑presentatie hebben met de onderstaande documenteigenschappen.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Dit codevoorbeeld toont u hoe u enkele presentatie‑eigenschappen kunt bewerken:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

De resultaten van het wijzigen van de documenteigenschappen worden hieronder getoond.

![Gewijzigde documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige links**

Voor meer informatie over een presentatie en de beveiligingsattributen, kunnen deze links nuttig voor u zijn:

- [Presentaties met wachtwoord beveiligen](/slides/nl/nodejs-java/password-protected-presentation/)
- [Presentaties met schrijfbeveiliging](/slides/nl/nodejs-java/write-protected-presentation/)

## **Veelgestelde vragen**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Zoek naar [embedded‑font‑informatie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) op presentatieniveau, en vergelijk die vermeldingen vervolgens met de set van [werkelijk gebruikte lettertypen in de content](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getfonts/) om te bepalen welke lettertypen cruciaal zijn voor het renderen.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel?**

Itereer door de [dia‑collectie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/) en inspecteer de [zichtbaarheidsvlag](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/gethidden/) van elke dia.

**Kan ik detecteren of een aangepaste dia‑grootte en oriëntatie worden gebruikt, en of deze afwijken van de standaardwaarden?**

Ja. Vergelijk de huidige [dia‑grootte](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getslidesize/) en oriëntatie met de standaardpresets; dit helpt om het gedrag bij afdrukken en export te voorspellen.

**Is er een snelle manier om te zien of grafieken naar externe gegevensbronnen verwijzen?**

Ja. Doorloop alle [grafieken](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/), controleer hun [gegevensbron](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), en noteer of de gegevens intern of link‑gebaseerd zijn, inclusief eventuele kapotte koppelingen.

**Hoe kan ik 'zware' dia's beoordelen die het renderen of exporteren naar PDF kunnen vertragen?**

Tel voor elke dia het aantal objecten en let op grote afbeeldingen, transparantie, schaduwen, animaties en multimedia; ken een ruwe complexiteitsscore toe om mogelijke prestatie‑knelpunten te markeren.