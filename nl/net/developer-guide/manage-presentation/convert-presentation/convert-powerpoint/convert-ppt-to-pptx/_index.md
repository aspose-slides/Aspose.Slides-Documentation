---
title: PPT naar PPTX converteren in .NET
linktitle: PPT naar PPTX
type: docs
weight: 20
url: /nl/net/convert-ppt-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "Converteer legacy PPT‑presentaties naar moderne PPTX snel in .NET met Aspose.Slides — duidelijke tutorial, gratis C#‑codevoorbeelden, geen afhankelijkheid van Microsoft Office."
---
## **Overzicht**

Dit artikel legt uit hoe je een PowerPoint‑presentatie in PPT‑formaat naar PPTX‑formaat kunt converteren met C# en met de online PPT‑naar‑PPTX‑conversietoepassing. De volgende onderwerpen worden behandeld.

- [PPT naar PPTX converteren in C#](#convert-ppt-to-pptx)

## **PPT naar PPTX converteren in .NET**

Voor C#‑voorbeeldcode om PPT naar PPTX te converteren, zie de sectie hieronder, namelijk [PPT naar PPTX converteren](#convert-ppt-to-pptx). De code laadt simpelweg het PPT‑bestand en slaat het op in PPTX‑formaat. Door verschillende opslaformaten op te geven, kun je het PPT‑bestand ook opslaan in tal van andere formaten zoals PDF, XPS, ODP, HTML enzovoort, zoals besproken in deze artikelen. 

- [PPT naar PDF converteren in .NET](/slides/nl/net/convert-powerpoint-to-pdf/)
- [PPT naar XPS converteren in .NET](/slides/nl/net/convert-powerpoint-to-xps/)
- [PPT naar HTML converteren in .NET](/slides/nl/net/convert-powerpoint-to-html/)
- [PPT naar ODP converteren in .NET](/slides/nl/net/save-presentation/)
- [PPT naar PNG converteren in .NET](/slides/nl/net/convert-powerpoint-to-png/)

## **Over PPT‑naar‑PPTX‑conversie**
Converteer het oude PPT‑formaat naar PPTX met de Aspose.Slides‑API. Als je duizenden PPT‑presentaties naar PPTX‑formaat moet omzetten, is de beste oplossing om dit programmatisch te doen. Met de Aspose.Slides‑API is dit mogelijk met slechts een paar regels code. De API biedt volledige compatibiliteit om een PPT‑presentatie naar PPTX te converteren en maakt het mogelijk om:

- Gecompliceerde structuren van masters, lay-outs en dia’s te converteren.
- Presentaties met diagrammen te converteren.
- Presentaties met groepsvormen, auto‑vormen (zoals rechthoeken en ellipsen), vormen met aangepaste geometrie te converteren.
- Presentaties met texturen en afbeeldingen als vulstijlen voor auto‑vormen te converteren.
- Presentaties met plaatsaanduidingen, tekstkaders en tekstvullingen te converteren.

{{% alert color="primary" %}} 

Neem een kijkje bij de [**Aspose.Slides PPT‑naar‑PPTX‑conversie**](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)‑app:

[](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

Deze app is gebouwd op basis van de **Aspose.Slides‑API**, zodat je een werkend voorbeeld van basis PPT‑naar‑PPTX‑conversiemogelijkheden kunt zien. Aspose.Slides Conversion is een webapp die het mogelijk maakt een presentatiebestand in PPT‑formaat te slepen en het geconverteerde PPTX‑bestand te downloaden.

Bekijk andere live [**Aspose.Slides‑conversie**](https://products.aspose.app/slides/nl/conversion/)‑voorbeelden.
{{% /alert %}} 


## **PPT naar PPTX converteren**
Om een PPT naar PPTX te converteren, geef je simpelweg de bestandsnaam en het opslaformaat door aan de [**Save**](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/methods/save/index)‑methode van de [**Presentation**](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse. De onderstaande C#‑codevoorbeeld converteert een Presentation van PPT naar PPTX met de standaardopties.

```c#
// Instantieer een Presentation-object dat een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// De PPTX-presentatie opslaan in PPTX-formaat
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

Lees meer over de presentatieformaten [**PPT vs PPTX**](/slides/nl/net/ppt-vs-pptx/) en hoe [**Aspose.Slides PPT‑naar‑PPTX‑conversie ondersteunt**](/slides/nl/net/convert-ppt-to-pptx/).

## **FAQ**

**Wat is het verschil tussen de formaten PPT en PPTX?**

PPT is het oudere binaire bestandsformaat dat door Microsoft PowerPoint wordt gebruikt, terwijl PPTX het nieuwere, op XML gebaseerde formaat is dat met Microsoft Office 2007 is geïntroduceerd. PPTX‑bestanden bieden betere prestaties, een kleinere bestandsgrootte en verbeterd dataherstel.

**Kan ik PPT naar PPTX converteren met .NET?**

Ja, met de Aspose.Slides for .NET‑bibliotheek kun je eenvoudig een PPT‑bestand laden en het met slechts enkâ paar regels code opslaan in PPTX‑formaat.

**Ondersteunt Aspose.Slides batch‑conversie van meerdere PPT‑bestanden naar PPTX?**

Ja, je kunt Aspose.Slides in een lus gebruiken om meerdere PPT‑bestanden programmatisch naar PPTX te converteren, wat geschikt is voor batch‑conversiescenario’s.

**Worden de inhoud en opmaak behouden na de conversie?**

Aspose.Slides behoudt een hoge getrouwheid bij het converteren van presentaties. Dia‑lay-outs, animaties, vormen, diagrammen en andere ontwerpelementen blijven behouden tijdens de PPT‑naar‑PPTX‑conversie.

**Kan ik andere formaten zoals PDF of HTML converteren vanuit PPT‑bestanden?**

Ja, Aspose.Slides ondersteunt het converteren van PPT‑bestanden naar meerdere formaten, waaronder PDF, XPS, HTML, ODP en afbeeldingsformaten zoals PNG en JPEG.

**Is het mogelijk om PPT naar PPTX te converteren zonder Microsoft PowerPoint geïnstalleerd te hebben?**

Ja, Aspose.Slides for .NET is een zelfstandige API en vereist geen Microsoft PowerPoint of andere derde‑partijsoftware om de conversie uit te voeren.

**Is er een online tool beschikbaar voor PPT‑naar‑PPTX‑conversie?**

Ja, je kunt de gratis [Aspose.Slides PPT‑naar‑PPTX‑converter](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) webapplicatie gebruiken om de conversie direct in je browser uit te voeren zonder code te schrijven.