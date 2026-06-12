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
description: "Converteer verouderde PPT‑presentaties snel naar modern PPTX in Java met Aspose.Slides — heldere tutorial, gratis code‑voorbeelden, geen Microsoft Office‑afhankelijkheid."
---
## **Overzicht**

Dit artikel legt uit hoe u een PowerPoint‑presentatie in PPT‑formaat kunt omzetten naar PPTX‑formaat met Java en met de online PPT‑naar‑PPTX‑conversie‑app. Het volgende onderwerp wordt behandeld.

- PPT naar PPTX converteren in Java

## **PPT naar PPTX converteren in Java**

Voor voorbeeldcode in Java om PPT naar PPTX te converteren, zie de sectie hieronder, namelijk [Convert PPT to PPTX](#convert-ppt-to-pptx). Het laadt eenvoudigweg het PPT‑bestand en slaat het op in PPTX‑formaat. Door verschillende opslagformaten op te geven, kunt u het PPT‑bestand ook opslaan in diverse andere formaten zoals PDF, XPS, ODP, HTML enz., zoals besproken in deze artikelen.

- [PPT naar PDF converteren in Java](/slides/nl/java/convert-powerpoint-to-pdf/)
- [PPT naar XPS converteren in Java](/slides/nl/java/convert-powerpoint-to-xps/)
- [PPT naar HTML converteren in Java](/slides/nl/java/convert-powerpoint-to-html/)
- [PPT naar ODP converteren in Java](/slides/nl/java/save-presentation/)
- [PPT naar PNG converteren in Java](/slides/nl/java/convert-powerpoint-to-png/)

## **Over PPT‑naar‑PPTX‑conversie**
Converteer het oude PPT‑formaat naar PPTX met de Aspose.Slides‑API. Als u duizenden PPT‑presentaties naar PPTX‑formaat moet omzetten, is de beste oplossing om dit programmatically te doen. Met de Aspose.Slides‑API is het mogelijk in slechts een paar regels code. De API biedt volledige compatibiliteit om PPT‑presentaties naar PPTX te converteren en maakt het mogelijk om:

- Complexe structuren van masters, lay‑outs en dia's converteren.
- Presentaties met grafieken converteren.
- Presentaties met gegroepeerde vormen, auto‑shapes (zoals rechthoeken en ellipsen), vormen met aangepaste geometrie converteren.
- Presentaties met texturen en afbeeldingsvullingen voor auto‑shapes converteren.
- Presentaties met placeholders, tekstvakken en tekstinhoud converteren.

{{% alert color="primary" %}} 

Bekijk de [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

Deze app is gebouwd op basis van [**Aspose.Slides API**](https://products.aspose.com/slides/nl/java/), zodat u een werkend voorbeeld ziet van de basis PPT‑naar‑PPTX‑conversiemogelijkheden. Aspose.Slides Conversion is een webapplicatie waarmee u een presentatiebestand in PPT‑formaat kunt neerzetten en het geconverteerde PPTX‑bestand kunt downloaden.

Bekijk andere live [**Aspose.Slides Conversion**](https://products.aspose.app/slides/nl/conversion/) voorbeelden.
{{% /alert %}} 

## **PPT naar PPTX converteren**
Aspose.Slides for Java stelt ontwikkelaars nu in staat om via een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)-klasse‑instantie toegang te krijgen tot de PPT en deze te converteren naar het overeenkomstige [PPTX](https://docs.fileformat.com/presentation/pptx/)-formaat. Momenteel ondersteunt het een gedeeltelijke conversie van [PPT ](https://docs.fileformat.com/presentation/ppt/)naar PPTX. Voor meer details over welke functies wel of niet worden ondersteund bij PPT‑naar‑PPTX‑conversie, ga naar deze documentatie [link](/slides/nl/java/ppt-to-pptx-conversion/).

Aspose.Slides for Java biedt de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)-klasse die een **PPTX**‑presentatiebestand vertegenwoordigt. De Presentation‑klasse kan nu ook **PPT** benaderen via Presentation wanneer het object wordt geïnstantieerd. Het volgende voorbeeld toont hoe een PPT‑presentatie naar een PPTX‑presentatie kan worden geconverteerd.

```java
// Maak een Presentation-object aan dat een PPTX-bestand representeert
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
|**Figuur : Bron PPT‑presentatie**|

De bovenstaande code‑fragment genereerde de volgende PPTX‑presentatie na conversie

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figuur: Gegenereerde PPTX‑presentatie na conversie**|

## **FAQ**

**Wat is het verschil tussen PPT‑ en PPTX‑formaten?**

PPT is het oudere binaire bestandsformaat dat door Microsoft PowerPoint wordt gebruikt, terwijl PPTX het nieuwere, op XML gebaseerde formaat is dat werd geïntroduceerd met Microsoft Office 2007. PPTX‑bestanden bieden betere prestaties, een kleinere bestandsgrootte en verbeterde gegevensherstel.

**Ondersteunt Aspose.Slides batch‑conversie van meerdere PPT‑bestanden naar PPTX?**

Ja, u kunt Aspose.Slides in een lus gebruiken om meerdere PPT‑bestanden programmatically naar PPTX te converteren, waardoor het geschikt is voor batch‑conversiescenario's.

**Wordt de inhoud en opmaak behouden na conversie?**

Aspose.Slides behoudt een hoge nauwkeurigheid bij het converteren van presentaties. Dia‑lay‑outs, animaties, vormen, grafieken en andere designelementen blijven behouden tijdens de conversie van PPT naar PPTX.

**Kan ik andere formaten zoals PDF of HTML vanuit PPT‑bestanden converteren?**

Ja, Aspose.Slides ondersteunt het converteren van PPT‑bestanden naar [meerdere formaten](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/), waaronder PDF, XPS, HTML, ODP en afbeeldingsformaten zoals PNG en JPEG.

**Is het mogelijk om PPT naar PPTX te converteren zonder Microsoft PowerPoint geïnstalleerd?**

Ja, Aspose.Slides is een zelfstandige API en vereist geen Microsoft PowerPoint of andere software van derden om de conversie uit te voeren.

**Is er een online tool beschikbaar voor PPT‑naar‑PPTX‑conversie?**

Ja, u kunt de gratis [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) webapplicatie gebruiken om de conversie rechtstreeks in uw browser uit te voeren zonder enige code te schrijven.