---
title: Converteer PPT naar PPTX op Android
linktitle: PPT naar PPTX
type: docs
weight: 20
url: /nl/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Converteer verouderde PPT‑presentaties snel naar moderne PPTX in Java met Aspose.Slides voor Android — duidelijke tutorial, gratis code‑voorbeelden, geen Microsoft Office‑afhankelijkheid."
---
## **Overzicht**

Dit artikel legt uit hoe je een PowerPoint‑presentatie in PPT‑formaat kunt omzetten naar PPTX‑formaat met Java en met de online PPT‑naar‑PPTX‑conversietoepassing. De volgende onderwerpen worden behandeld.

- PPT naar PPTX converteren in Java

## **PPT naar PPTX converteren op Android**

Voor Java‑voorbeeldcode om PPT naar PPTX te converteren, zie de sectie hieronder, namelijk [PPT naar PPTX converteren](#convert-ppt-to-pptx). Het laadt simpelweg het PPT‑bestand en slaat het op in PPTX‑formaat. Door verschillende opslagformaten op te geven, kun je het PPT‑bestand ook opslaan in vele andere formaten zoals PDF, XPS, ODP, HTML enzovoort, zoals besproken in deze artikelen.

- [PPT naar PDF converteren op Android](/slides/nl/androidjava/convert-powerpoint-to-pdf/)
- [PPT naar XPS converteren op Android](/slides/nl/androidjava/convert-powerpoint-to-xps/)
- [PPT naar HTML converteren op Android](/slides/nl/androidjava/convert-powerpoint-to-html/)
- [PPT naar ODP converteren op Android](/slides/nl/androidjava/save-presentation/)
- [PPT naar PNG converteren op Android](/slides/nl/androidjava/convert-powerpoint-to-png/)

## **Over PPT naar PPTX-conversie**
Converteer het oude PPT‑formaat naar PPTX met de Aspose.Slides‑API. Als je duizenden PPT‑presentaties naar PPTX‑formaat moet omzetten, is de beste oplossing dit programmatically te doen. Met de Aspose.Slides‑API is dit mogelijk in slechts enkele regels code. De API biedt volledige compatibiliteit om PPT‑presentaties naar PPTX te converteren en maakt het mogelijk om:

- Complexe structuren van masters, lay‑outs en dia's converteren.
- Presentaties met diagrammen converteren.
- Presentaties met groepsvormen, automatisch vormen (zoals rechthoeken en ellipsen), vormen met aangepaste geometrie converteren.
- Presentaties met texturen en afbeeldingsvullingen voor automatisch vormen converteren.
- Presentaties met tijdelijke aanduidingen, tekstframes en teksthouders converteren.

{{% alert color="primary" %}} 

Bekijk de [**Aspose.Slides PPT naar PPTX-conversie**](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

Deze app is gebouwd op basis van [**Aspose.Slides API**](https://products.aspose.com/slides/nl/androidjava/), zodat je een live voorbeeld van basis PPT‑naar‑PPTX‑conversiemogelijkheden kunt zien. Aspose.Slides Conversion is een webapp, die je in staat stelt een presentatiebestand in PPT‑formaat te uploaden en het geconverteerde PPTX te downloaden.

Bekijk andere live [**Aspose.Slides-conversie**](https://products.aspose.app/slides/nl/conversion/) voorbeelden.
{{% /alert %}} 

## **PPT naar PPTX converteren**
Aspose.Slides voor Android via Java maakt het nu mogelijk voor ontwikkelaars om de PPT te benaderen via een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse‑instance en deze te converteren naar het overeenkomstige [PPTX](https://docs.fileformat.com/presentation/pptx/)‑formaat. Momenteel ondersteunt het gedeeltelijke conversie van [PPT](https://docs.fileformat.com/presentation/ppt/) naar PPTX.

Aspose.Slides voor Android via Java biedt de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse die een **PPTX**‑presentatiebestand representeert. De Presentation‑klasse kan nu ook **PPT** benaderen wanneer het object wordt ge‑instantieerd. Het volgende voorbeeld toont hoe je een PPT‑presentatie naar een PPTX‑presentatie converteert.

```java
// Maak een Presentation-object aan dat een PPTX-bestand voorstelt
Presentation pres = new Presentation("Aspose.ppt");
try {
// De PPTX-presentatie opslaan in PPTX-formaat
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figuur: Bron‑PPT‑presentatie**|

De bovenstaande code‑snippet genereerde de volgende PPTX‑presentatie na conversie

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figuur: Gegenereerde PPTX‑presentatie na conversie**|

## **FAQ**

**Wat is het verschil tussen PPT- en PPTX-formaten?**

PPT is het oudere binaire bestandformaat dat door Microsoft PowerPoint wordt gebruikt, terwijl PPTX het nieuwere XML‑gebaseerde formaat is dat werd geïntroduceerd met Microsoft Office 2007. PPTX‑bestanden bieden betere prestaties, een kleinere bestandsgrootte en verbeterde gegevensherstel.

**Ondersteunt Aspose.Slides batchconversie van meerdere PPT‑bestanden naar PPTX?**

Ja, je kunt Aspose.Slides in een lus gebruiken om meerdere PPT‑bestanden programmatically naar PPTX te converteren, waardoor het geschikt is voor batch‑conversiescenario’s.

**Worden inhoud en opmaak behouden na conversie?**

Aspose.Slides behoudt een hoge getrouwheid bij het converteren van presentaties. Dia‑lay‑outs, animaties, vormen, diagrammen en andere ontwerpelementen blijven behouden tijdens de PPT‑naar‑PPTX‑conversie.

**Kan ik andere formaten zoals PDF of HTML converteren vanuit PPT‑bestanden?**

Ja, Aspose.Slides ondersteunt het converteren van PPT‑bestanden naar [meerdere formaten](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/), inclusief PDF, XPS, HTML, ODP en beeldformaten zoals PNG en JPEG.

**Is het mogelijk om PPT naar PPTX te converteren zonder Microsoft PowerPoint geïnstalleerd?**

Ja, Aspose.Slides is een zelfstandige API en vereist geen Microsoft PowerPoint of andere derden‑software om de conversie uit te voeren.

**Is er een online tool beschikbaar voor PPT‑naar‑PPTX‑conversie?**

Ja, je kunt de gratis [Aspose.Slides PPT naar PPTX Converter](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) webapplicatie gebruiken om de conversie direct in je browser uit te voeren zonder code te schrijven.