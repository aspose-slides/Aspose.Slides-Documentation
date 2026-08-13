---
title: PPT naar PPTX converteren in Java
linktitle: PPT naar PPTX
type: docs
weight: 20
url: /nl/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Converteer legacy PPT‑presentaties snel naar modern PPTX in Java met Aspose.Slides — duidelijke handleiding, gratis code‑voorbeelden, geen afhankelijkheid van Microsoft Office."
---
## **Overzicht**

Dit artikel legt uit hoe je een PowerPoint‑presentatie in PPT‑formaat naar PPTX‑formaat kunt converteren met Java en met de online PPT‑naar‑PPTX‑conversie‑app. Het volgende onderwerp wordt behandeld.

- PPT naar PPTX converteren in Java

## **PPT naar PPTX converteren in Java**

Voor voorbeeldcode in Java om PPT naar PPTX te converteren, zie de sectie hieronder, namelijk [PPT naar PPTX converteren](#convert-ppt-to-pptx). Het laadt simpelweg het PPT‑bestand en slaat het op in PPTX‑formaat. Door verschillende opslaan‑formaten op te geven, kun je het PPT‑bestand ook opslaan in vele andere formaten zoals PDF, XPS, ODP, HTML enz., zoals besproken in deze artikelen.

- [PPT naar PDF converteren in Java](/slides/nl/java/convert-powerpoint-to-pdf/)
- [PPT naar XPS converteren in Java](/slides/nl/java/convert-powerpoint-to-xps/)
- [PPT naar HTML converteren in Java](/slides/nl/java/convert-powerpoint-to-html/)
- [PPT naar ODP converteren in Java](/slides/nl/java/save-presentation/)
- [PPT naar PNG converteren in Java](/slides/nl/java/convert-powerpoint-to-png/)

## **Over PPT‑naar‑PPTX‑conversie**

Converteer het oude PPT‑formaat naar PPTX met de Aspose.Slides‑API. Als je duizenden PPT‑presentaties naar PPTX‑formaat moet converteren, is de beste oplossing dit programmatisch te doen. Met de Aspose.Slides‑API is het mogelijk om dit in slechts enkele regels code te doen. De API biedt volledige compatibiliteit om PPT‑presentaties naar PPTX te converteren en maakt het mogelijk om:

- Complexe structuren van masters, lay-outs en dia’s converteren.
- Presentaties met grafieken converteren.
- Presentaties met groepsvormen, auto‑vormen (zoals rechthoeken en ellipsen), vormen met aangepaste geometrie converteren.
- Presentaties met texturen en afbeeldingsvullingen voor auto‑vormen converteren.
- Presentaties met placeholders, tekstframes en tekstelementen converteren.

{{% alert color="info" %}} 

Bekijk de [**Aspose.Slides PPT‑naar‑PPTX‑conversie**](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

Deze app is gebouwd op basis van de [**Aspose.Slides API**](https://products.aspose.com/slides/nl/java/), zodat je een live voorbeeld kunt zien van de basis PPT‑naar‑PPTX‑conversiemogelijkheden. Aspose.Slides Conversion is een webapplicatie die het mogelijk maakt om een presentatiebestand in PPT‑formaat te slepen en het geconverteerde bestand als PPTX te downloaden.

Bekijk andere live [**Aspose.Slides Conversion**](https://products.aspose.app/slides/nl/conversion/) voorbeelden.
{{% /alert %}} 

## **PPT naar PPTX converteren**

Aspose.Slides for Java maakt het nu mogelijk voor ontwikkelaars om de PPT te openen met een instance van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse en deze naar het bijbehorende [PPTX](https://docs.fileformat.com/presentation/pptx/)‑formaat te converteren. Momenteel ondersteunt het gedeeltelijke conversie van [PPT](https://docs.fileformat.com/presentation/ppt/) naar PPTX. Voor meer details over welke functies wel of niet ondersteund worden bij PPT‑naar‑PPTX‑conversie, ga naar deze documentatie [link](/slides/nl/java/ppt-to-pptx-conversion/).

Aspose.Slides for Java biedt de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse die een **PPTX**‑presentatiebestand vertegenwoordigt. De Presentation‑klasse kan nu ook **PPT** benaderen via Presentation wanneer het object wordt geïnstantieerd. Het volgende voorbeeld laat zien hoe je een PPT‑presentatie naar een PPTX‑presentatie kunt converteren.

```java
import com.aspose.slides.*;

// Instantieer een Presentation‑object dat een PPT‑bestand vertegenwoordigt
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
|**Figuur: Bron‑PPT‑presentatie**|

De bovenstaande code‑fragment genereerde de volgende PPTX‑presentatie na conversie

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figuur: Gegenereerde PPTX‑presentatie na conversie**|

## **Veelgestelde vragen**

### Wat is het verschil tussen PPT‑ en PPTX‑formaten?

PPT is het oudere binaire bestandsformaat dat door Microsoft PowerPoint wordt gebruikt, terwijl PPTX het nieuwere op XML gebaseerde formaat is dat geïntroduceerd werd met Microsoft Office 2007. PPTX‑bestanden bieden betere prestaties, een kleinere bestandsgrootte en verbeterd gegevensherstel.

### Ondersteunt Aspose.Slides batch‑conversie van meerdere PPT‑bestanden naar PPTX?

Ja, je kunt Aspose.Slides in een lus gebruiken om meerdere PPT‑bestanden programmatisch naar PPTX te converteren, waardoor het geschikt is voor batch‑conversiescenario's.

### Wordt de inhoud en opmaak behouden na conversie?

Aspose.Slides behoudt een hoge nauwkeurigheid bij het converteren van presentaties. Dia‑lay-outs, animaties, vormen, grafieken en andere ontwerpelementen blijven behouden tijdens de PPT‑naar‑PPTX‑conversie.

### Kan ik andere formaten zoals PDF of HTML converteren vanuit PPT‑bestanden?

Ja, Aspose.Slides ondersteunt het converteren van PPT‑bestanden naar [meerdere formaten](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/), waaronder PDF, XPS, HTML, ODP en afbeeldingsformaten zoals PNG en JPEG.

### Is het mogelijk om PPT naar PPTX te converteren zonder Microsoft PowerPoint geïnstalleerd te hebben?

Ja, Aspose.Slides is een zelfstandige API en vereist geen Microsoft PowerPoint of andere externe software om de conversie uit te voeren.

### Is er een online tool beschikbaar voor PPT‑naar‑PPTX‑conversie?

Ja, je kunt de gratis [Aspose.Slides PPT‑naar‑PPTX‑Converter](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) webapplicatie gebruiken om de conversie rechtstreeks in je browser uit te voeren zonder code te schrijven.