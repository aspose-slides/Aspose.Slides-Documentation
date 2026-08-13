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
description: "Converteer oude PPT-presentaties naar moderne PPTX snel in Java met Aspose.Slides voor Android - duidelijke handleiding, gratis code-voorbeelden, zonder afhankelijkheid van Microsoft Office."
---
## **Overzicht**

Dit artikel legt uit hoe u een PowerPoint‑presentatie in PPT‑indeling kunt converteren naar PPTX‑indeling met Java en met de online PPT‑naar‑PPTX‑conversietoepassing. Het volgende onderwerp wordt behandeld.

- Convert PPT naar PPTX in Java

## **Convert PPT naar PPTX op Android**

Voor Java‑voorbeeldcode om PPT naar PPTX te converteren, zie de onderstaande sectie, namelijk [Convert PPT to PPTX](#convert-ppt-to-pptx). Het laadt simpelweg het PPT‑bestand en slaat het op in PPTX‑indeling. Door verschillende opslagindelingen op te geven, kunt u het PPT‑bestand ook opslaan in vele andere indelingen zoals PDF, XPS, ODP, HTML enzovoort, zoals besproken in deze artikelen.

- [Convert PPT naar PDF op Android](/slides/nl/androidjava/convert-powerpoint-to-pdf/)
- [Convert PPT naar XPS op Android](/slides/nl/androidjava/convert-powerpoint-to-xps/)
- [Convert PPT naar HTML op Android](/slides/nl/androidjava/convert-powerpoint-to-html/)
- [Convert PPT naar ODP op Android](/slides/nl/androidjava/save-presentation/)
- [Convert PPT naar PNG op Android](/slides/nl/androidjava/convert-powerpoint-to-png/)

## **Over PPT naar PPTX‑conversie**

Converteer het oude PPT‑formaat naar PPTX met de Aspose.Slides‑API. Als u duizenden PPT‑presentaties naar PPTX‑formaat moet converteren, is de beste oplossing om dit programmeermatig te doen. Met de Aspose.Slides‑API is het mogelijk om dit te doen in slechts een paar regels code. De API ondersteunt volledige compatibiliteit om PPT‑presentaties naar PPTX te converteren en maakt het mogelijk om:

- Gecompliceerde structuren van masters, lay-outs en dia's converteren.
- Presentaties met grafieken converteren.
- Presentaties met gegroepeerde vormen, auto‑vormen (zoals rechthoeken en ellipsen), vormen met aangepaste geometrie converteren.
- Presentaties met texturen en afbeelding‑vullingsstijlen voor auto‑vormen converteren.
- Presentaties met plaatshouders, tekstframes en tekstvullingen converteren.

{{% alert color="info" %}} 

Bekijk de [**Aspose.Slides PPT‑naar‑PPTX‑conversie**](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

Deze app is gebouwd op basis van de [**Aspose.Slides‑API**](https://products.aspose.com/slides/nl/androidjava/), zodat u een live‑voorbeeld van de basis‑PPT‑naar‑PPTX‑conversiemogelijkheden kunt zien. Aspose.Slides‑Conversion is een webapplicatie waarmee u een presentatiedossier in PPT‑indeling kunt slepen en het vervolgens gedownload krijgt als PPTX.

Bekijk andere live [**Aspose.Slides‑Conversion**](https://products.aspose.app/slides/nl/conversion/) voorbeelden.
{{% /alert %}} 

## **Convert PPT naar PPTX**

Aspose.Slides voor Android via Java maakt het nu mogelijk voor ontwikkelaars om de PPT te benaderen met de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse‑instantie en deze te converteren naar het overeenkomstige [PPTX](https://docs.fileformat.com/presentation/pptx/)‑formaat. Momenteel ondersteunt het gedeeltelijke conversie van [PPT ](https://docs.fileformat.com/presentation/ppt/)naar PPTX.

Aspose.Slides voor Android via Java biedt de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse die een **PPTX**‑presentatiebestand vertegenwoordigt. De Presentation‑klasse kan nu ook **PPT** benaderen via Presentation wanneer het object wordt geïnstantiëerd. Het volgende voorbeeld laat zien hoe u een PPT‑presentatie kunt converteren naar een PPTX‑presentatie.

```java
import com.aspose.slides.*;

// Maak een Presentation‑object aan dat een PPT‑bestand vertegenwoordigt
Presentation pres = new Presentation("Aspose.ppt");
try {
// Sla de PPT‑presentatie op in PPTX‑formaat
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figuur : Bron‑PPT‑presentatie**|

Het bovenstaande code‑fragment heeft de volgende PPTX‑presentatie gegenereerd na conversie

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figuur: Gegenereerde PPTX‑presentatie na conversie**|

## **FAQ**

### Wat is het verschil tussen PPT‑ en PPTX‑formaten?

PPT is het oudere binaire bestandsformaat dat door Microsoft PowerPoint wordt gebruikt, terwijl PPTX het nieuwere op XML gebaseerde formaat is dat werd geïntroduceerd met Microsoft Office 2007. PPTX‑bestanden bieden betere prestaties, een kleinere bestandsgrootte en verbeterde gegevensherstel.

### Ondersteunt Aspose.Slides batch‑conversie van meerdere PPT‑bestanden naar PPTX?

Ja, u kunt Aspose.Slides in een lus gebruiken om meerdere PPT‑bestanden programmatisch naar PPTX te converteren, waardoor het geschikt is voor batch‑conversiescenario’s.

### Worden de inhoud en opmaak behouden na conversie?

Aspose.Slides behoudt een hoge getrouwheid bij het converteren van presentaties. Dia‑lay-outs, animaties, vormen, grafieken en andere ontwerpelementen blijven behouden tijdens de PPT‑naar‑PPTX‑conversie.

### Kan ik andere formaten zoals PDF of HTML converteren vanuit PPT‑bestanden?

Ja, Aspose.Slides ondersteunt het converteren van PPT‑bestanden naar [meerdere formaten](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/), inclusief PDF, XPS, HTML, ODP en afbeeldingsformaten zoals PNG en JPEG.

### Is het mogelijk om PPT naar PPTX te converteren zonder Microsoft PowerPoint geïnstalleerd?

Ja, Aspose.Slides is een zelfstandige API en vereist geen Microsoft PowerPoint of enige derden‑software om de conversie uit te voeren.

### Is er een online tool beschikbaar voor PPT‑naar‑PPTX‑conversie?

Ja, u kunt de gratis [Aspose.Slides PPT‑naar‑PPTX‑Converter](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) webapplicatie gebruiken om de conversie direct in uw browser uit te voeren zonder enige code te schrijven.