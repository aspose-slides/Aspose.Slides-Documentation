---
title: Verkrijg en werk presentatiesinformatie bij in JavaScript
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
description: "Verken dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met JavaScript voor snellere inzichten en slimmer documentonderzoek."
---
## **Overzicht**

Dit artikel laat zien hoe u presentatiesinformatie in Aspose.Slides kunt inspecteren. Het legt uit hoe u het huidige formaat van een presentatie kunt bepalen zonder het volledige bestand te laden, de documenteigenschappen kunt lezen en die eigenschappen indien nodig kunt bijwerken.

De voorbeelden zijn gebaseerd op de [PresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/) en [DocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/) API's en demonstreren typische bewerkingen voor het werken met presentatiemetadata.

## **Controleer presentatiefomaat**

Voordat u met een presentatie werkt, wilt u wellicht weten in welk formaat (PPT, PPTX, ODP en andere) de presentatie zich momenteel bevindt.

U kunt het formaat van een presentatie controleren zonder de presentatie te laden. Zie deze JavaScript‑code:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Presentatie‑eigenschappen ophalen**

Deze JavaScript‑code toont hoe u presentatieweigenschappen (informatie over de presentatie) kunt ophalen:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

U wilt wellicht de [eigenschappen onder de DocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) klasse bekijken.

## **Presentatie‑eigenschappen bijwerken**

Aspose.Slides biedt de [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) methode die u in staat stelt wijzigingen aan te brengen in presentatieweigenschappen.

Stel dat we een PowerPoint‑presentatie hebben met de onderstaande documenteigenschappen.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Dit code‑voorbeeld laat zien hoe u enkele presentatieweigenschappen kunt bewerken:

```javascript
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

Voor meer informatie over een presentatie en de beveiligingsattributen kunt u deze links nuttig vinden:

- [Controleren of een presentatie versleuteld is](https://docs.aspose.com/slides/nl/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Controleren of een presentatie schrijfbeveiligd (alleen‑lezen) is](https://docs.aspose.com/slides/nl/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Controleren of een presentatie met wachtwoord beschermd is voordat deze wordt geladen](https://docs.aspose.com/slides/nl/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bevestigen van het wachtwoord dat is gebruikt om een presentatie te beveiligen](https://docs.aspose.com/slides/nl/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Veelgestelde vragen**

**Hoe kan ik controleren of lettertypen zijn ingebed en welke dat zijn?**

Zoek naar [informatie over ingebedde lettertypen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) op het presentatieniveau en vergelijk die items vervolgens met de verzameling [lettertypen die daadwerkelijk in de inhoud worden gebruikt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getfonts/) om te bepalen welke lettertypen cruciaal zijn voor weergave.

**Hoe kan ik snel bepalen of het bestand verborgen dia's bevat en hoeveel?**

Itereer door de [slide‑collectie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/) en inspecteer de [zichtbaarheidsvlag](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/gethidden/) van elke dia.

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie worden gebruikt, en of deze afwijken van de standaardinstellingen?**

Ja. Vergelijk de huidige [dia‑grootte](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getslidesize/) en oriëntatie met de standaardpresets; dit helpt om het gedrag bij afdrukken en export te voorspellen.

**Is er een snelle manier om te zien of grafieken externe gegevensbronnen gebruiken?**

Ja. Doorloop alle [grafieken](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/), controleer hun [gegevensbron](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), en noteer of de gegevens intern of link‑gebaseerd zijn, inclusief eventuele verbroken links.

**Hoe kan ik 'zware' dia's beoordelen die de weergave of PDF‑export kunnen vertragen?**

Tel per dia het aantal objecten en zoek naar grote afbeeldingen, transparantie, schaduwen, animaties en multimedia; ken een ruwe complexiteitsscore toe om mogelijke prestatieknelpunten te markeren.