---
title: PPT naar PPTX converteren in PHP
linktitle: PPT naar PPTX
type: docs
weight: 20
url: /nl/php-java/convert-ppt-to-pptx/
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
- PHP
- Aspose.Slides
description: "Converteer oude PPT-presentaties naar modern PPTX snel met Aspose.Slides voor PHP via Java — duidelijke handleiding, gratis code-voorbeelden, geen afhankelijkheid van Microsoft Office."
---
## **Overzicht**

Dit artikel legt uit hoe u een PowerPoint‑presentatie in PPT‑formaat naar PPTX‑formaat kunt converteren met PHP en met een online PPT‑naar‑PPTX‑conversie‑app. De volgende onderwerpen worden behandeld.

- PPT naar PPTX converteren

## **PPT naar PPTX converteren in PHP**

Voor voorbeeldcode in Java om PPT naar PPTX te converteren, zie de onderstaande sectie, namelijk [PPT naar PPTX converteren](#convert-ppt-to-pptx). Het laadt gewoon het PPT‑bestand en slaat het op in PPTX‑formaat. Door verschillende opslagformaten op te geven, kunt u het PPT‑bestand ook opslaan in vele andere formaten zoals PDF, XPS, ODP, HTML, enz., zoals besproken in deze artikelen.

- [PPT naar PDF converteren in PHP](/slides/nl/php-java/convert-powerpoint-to-pdf/)
- [PPT naar XPS converteren in PHP](/slides/nl/php-java/convert-powerpoint-to-xps/)
- [PPT naar HTML converteren in PHP](/slides/nl/php-java/convert-powerpoint-to-html/)
- [PPT naar ODP converteren in PHP](/slides/nl/php-java/save-presentation/)
- [PPT naar PNG converteren in PHP](/slides/nl/php-java/convert-powerpoint-to-png/)

## **Over PPT naar PPTX-conversie**
Converteer het oude PPT‑formaat naar PPTX met de Aspose.Slides‑API. Als u duizenden PPT‑presentaties naar PPTX‑formaat moet converteren, is de beste oplossing om dit programmatisch te doen. Met de Aspose.Slides‑API is het mogelijk om dit in slechts enkele regels code te realiseren. De API ondersteunt volledige compatibiliteit voor het converteren van PPT‑presentaties naar PPTX en maakt het mogelijk om:

- Complexe structuren van masters, lay-outs en dia's converteren.
- Presentaties met grafieken converteren.
- Presentaties met groepen vormen, auto‑shapes (zoals rechthoeken en ellipsen), vormen met aangepaste geometrie converteren.
- Presentaties met texturen en opvulstijlen voor afbeeldingen in auto‑shapes converteren.
- Presentaties met placeholders, tekstkaders en tekstvullingen converteren.

{{% alert color="primary" %}} 

Bekijk de app [**Aspose.Slides PPT naar PPTX-conversie**](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

Deze app is gebouwd op basis van de [**Aspose.Slides API**](https://products.aspose.com/slides/nl/php-java/), zodat u een levend voorbeeld kunt zien van de basisfunctionaliteit voor PPT‑naar‑PPTX‑conversie. Aspose.Slides Conversion is een webapp, waarmee u een presentatiebestand in PPT‑formaat kunt slepen en het geconverteerde PPTX‑bestand kunt downloaden.

Bekijk andere live [**Aspose.Slides-conversie**](https://products.aspose.app/slides/nl/conversion/) voorbeelden.
{{% /alert %}} 

## **PPT naar PPTX converteren**
Aspose.Slides voor PHP via Java maakt het nu voor ontwikkelaars mogelijk om toegang te krijgen tot de PPT met behulp van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)-klasse en deze te converteren naar het overeenkomstige [PPTX](https://docs.fileformat.com/presentation/pptx/)‑formaat. Momenteel ondersteunt het gedeeltelijke conversie van [PPT](https://docs.fileformat.com/presentation/ppt/) naar PPTX. Voor meer details over welke functies wel en niet ondersteund worden bij de PPT‑naar‑PPTX‑conversie, ga naar deze documentatie [link](/slides/nl/php-java/ppt-to-pptx-conversion/).

Aspose.Slides voor PHP via Java biedt de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)-klasse die een **PPTX**‑presentatiebestand vertegenwoordigt. De Presentation‑klasse kan nu ook **PPT**‑bestanden benaderen via Presentation wanneer het object wordt geïnstalleerd. Het volgende voorbeeld toont hoe u een PPT‑presentatie naar een PPTX‑presentatie kunt converteren.

```php
  # Maak een Presentation-object aan dat een PPTX-bestand representeert
  $pres = new Presentation("Aspose.ppt");
  try {
    # Sla de PPTX-presentatie op in PPTX-formaat
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figuur: Bron‑PPT‑presentatie**|

De bovenstaande code‑snippet genereerde de volgende PPTX‑presentatie na conversie

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figuur: Gegenereerde PPTX‑presentatie na conversie**|

## **Veelgestelde vragen**

**Wat is het verschil tussen PPT‑ en PPTX‑formaten?**

PPT is het oudere binaire bestandsformaat dat door Microsoft PowerPoint wordt gebruikt, terwijl PPTX het nieuwere, op XML gebaseerde formaat is dat werd geïntroduceerd met Microsoft Office 2007. PPTX‑bestanden bieden betere prestaties, een kleinere bestandsgrootte en verbeterde gegevensherstel.

**Ondersteunt Aspose.Slides batchconversie van meerdere PPT‑bestanden naar PPTX?**

Ja, u kunt Aspose.Slides in een lus gebruiken om meerdere PPT‑bestanden programmatisch naar PPTX te converteren, waardoor het geschikt is voor batch‑conversiescenario’s.

**Blijven de inhoud en opmaak behouden na conversie?**

Aspose.Slides behoudt een hoge nauwkeurigheid bij het converteren van presentaties. Dia‑lay-outs, animaties, vormen, grafieken en andere ontwerpelementen blijven behouden tijdens de conversie van PPT naar PPTX.

**Kan ik andere formaten zoals PDF of HTML vanuit PPT‑bestanden converteren?**

Ja, Aspose.Slides ondersteunt het converteren van PPT‑bestanden naar [meerdere formaten](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/), waaronder PDF, XPS, HTML, ODP en beeldformaten zoals PNG en JPEG.

**Is het mogelijk om PPT naar PPTX te converteren zonder Microsoft PowerPoint geïnstalleerd?**

Ja, Aspose.Slides is een zelfstandige API en vereist geen Microsoft PowerPoint of andere software van derden om de conversie uit te voeren.

**Is er een online tool beschikbaar voor PPT naar PPTX‑conversie?**

Ja, u kunt de gratis [Aspose.Slides PPT naar PPTX‑converter](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) webapplicatie gebruiken om de conversie rechtstreeks in uw browser uit te voeren zonder enige code te schrijven.