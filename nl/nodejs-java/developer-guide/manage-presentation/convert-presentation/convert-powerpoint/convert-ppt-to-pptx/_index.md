---
title: PPT naar PPTX converteren in JavaScript
linktitle: PPT naar PPTX
type: docs
weight: 20
url: /nl/nodejs-java/convert-ppt-to-pptx/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPT naar PPTX
- PPT opslaan als PPTX
- PPT exporteren naar PPTX
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer legacy PPT‑presentaties naar moderne PPTX snel met Aspose.Slides voor Node.js - duidelijke tutorial, gratis code‑voorbeelden, zonder afhankelijkheid van Microsoft Office."
---
## **Overzicht**

Dit artikel legt uit hoe je een PowerPoint‑presentatie in PPT‑formaat kunt omzetten naar PPTX‑formaat met JavaScript en met de online PPT‑naar‑PPTX‑conversietoepassing. Het volgende onderwerp wordt behandeld.

- PPT naar PPTX converteren in JavaScript

## **JavaScript PPT naar PPTX converteren**

Voor voorbeeldcode in JavaScript om PPT naar PPTX te converteren, zie de sectie hieronder: [Convert PPT to PPTX](#convert-ppt-to-pptx). De code laadt simpelweg het PPT‑bestand en slaat het op in PPTX‑formaat. Door verschillende opslaformaten op te geven, kun je het PPT‑bestand ook opslaan in vele andere formaten zoals PDF, XPS, ODP, HTML enzovoort, zoals besproken in deze artikelen.

- [PPT naar PDF converteren in JavaScript](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/)
- [PPT naar XPS converteren in JavaScript](/slides/nl/nodejs-java/convert-powerpoint-to-xps/)
- [PPT naar HTML converteren in JavaScript](/slides/nl/nodejs-java/convert-powerpoint-to-html/)
- [PPT naar ODP converteren in JavaScript](/slides/nl/nodejs-java/save-presentation/)
- [PPT naar PNG converteren in JavaScript](/slides/nl/nodejs-java/convert-powerpoint-to-png/)

## **Over PPT naar PPTX conversie**
Converteer het oude PPT‑formaat naar PPTX met de Aspose.Slides‑API. Als je duizenden PPT‑presentaties naar PPTX‑formaat moet omzetten, is de beste oplossing om dit programmeermatig te doen. Met de Aspose.Slides‑API is dit mogelijk met slechts een paar regels code. De API biedt volledige compatibiliteit om een PPT‑presentatie naar PPTX te converteren en maakt het mogelijk om:

- Complexe structuren van masters, lay-outs en dia’s te converteren.
- Presentaties met grafieken te converteren.
- Presentaties met groepsvormen, auto‑vormen (zoals rechthoeken en ellipsen), vormen met aangepaste geometrie te converteren.
- Presentaties met texturen en afbeeldingsvullingen voor auto‑vormen te converteren.
- Presentaties met placeholders, tekstkaders en tekstinhoud te converteren.

{{% alert color="primary" %}} 

Bekijk de [**Aspose.Slides PPT‑naar‑PPTX Conversie**](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)‑app:

[](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

Deze app is gebouwd op basis van de [**Aspose.Slides API**](https://products.aspose.com/slides/nl/nodejs-java/), zodat je een live‑voorbeeld van de basis‑PPT‑naar‑PPTX‑conversiemogelijkheden kunt zien. Aspose.Slides Conversion is een webapplicatie die het mogelijk maakt een presentatie‑bestand in PPT‑formaat te uploaden en het geconverteerde PPTX‑bestand te downloaden.

Bekijk andere live‑[**Aspose.Slides Conversion**](https://products.aspose.app/slides/nl/conversion/)‑voorbeelden.
{{% /alert %}} 

## **PPT naar PPTX converteren**
Aspose.Slides voor Node.js via Java maakt het nu mogelijk voor ontwikkelaars om via de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse een PPT‑bestand te openen en dit naar het overeenkomstige [PPTX](https://docs.fileformat.com/presentation/pptx/)‑formaat te converteren. Momenteel ondersteunt het gedeeltelijke conversie van [PPT](https://docs.fileformat.com/presentation/ppt/) naar PPTX.

Aspose.Slides voor Node.js via Java biedt de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse die een **PPTX**‑presentatiebestand vertegenwoordigt. De Presentation‑klasse kan nu ook **PPT** benaderen wanneer het object wordt geïnstantieerd. Het volgende voorbeeld laat zien hoe je een PPT‑presentatie converteert naar een PPTX‑presentatie.

```javascript
// Instantieer een Presentation object dat een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // Sla de PPTX‑presentatie op in PPTX‑formaat
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figuur : Bron PPT‑presentatie**|

De bovenstaande code‑snippet genereerde de volgende PPTX‑presentatie na conversie

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figuur: Gegenereerde PPTX‑presentatie na conversie**|

## **FAQ**

**Wat is het verschil tussen de PPT‑ en PPTX‑formaten?**

PPT is het oudere binaire bestandformaat dat Microsoft PowerPoint gebruikt, terwijl PPTX het nieuwere XML‑gebaseerde formaat is dat werd geïntroduceerd met Microsoft Office 2007. PPTX‑bestanden bieden betere prestaties, een kleinere bestandsgrootte en verbeterd herstel van gegevens.

**Ondersteunt Aspose.Slides batch‑conversie van meerdere PPT‑bestanden naar PPTX?**

Ja, je kunt Aspose.Slides in een lus gebruiken om meerdere PPT‑bestanden programmatisch naar PPTX te converteren, waardoor het geschikt is voor batch‑conversiescenario’s.

**Worden inhoud en opmaak behouden na de conversie?**

Aspose.Slides behoudt een hoge nauwkeurigheid bij het converteren van presentaties. Dia‑lay-outs, animaties, vormen, grafieken en andere ontwerpelementen blijven behouden tijdens de PPT‑naar‑PPTX‑conversie.

**Kan ik andere formaten, zoals PDF of HTML, converteren vanuit PPT‑bestanden?**

Ja, Aspose.Slides ondersteunt het converteren van PPT‑bestanden naar meerdere formaten, inclusief PDF, XPS, HTML, ODP en afbeeldingsformaten zoals PNG en JPEG.

**Is het mogelijk om PPT naar PPTX te converteren zonder Microsoft PowerPoint geïnstalleerd te hebben?**

Ja, Aspose.Slides is een zelfstandige API en vereist geen Microsoft PowerPoint of andere derden‑software om de conversie uit te voeren.

**Is er een online hulpmiddel beschikbaar voor PPT‑naar‑PPTX‑conversie?**

Ja, je kunt de gratis [Aspose.Slides PPT‑naar‑PPTX Converter](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) webapplicatie gebruiken om de conversie direct in je browser uit te voeren zonder enige code te schrijven.