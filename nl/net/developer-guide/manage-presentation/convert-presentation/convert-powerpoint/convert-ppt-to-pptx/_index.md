---
title: Converteer PPT naar PPTX in .NET
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
description: "Converteer verouderde PPT-presentaties naar moderne PPTX snel in .NET met Aspose.Slides - duidelijke handleiding, gratis C#-codevoorbeelden, geen Microsoft Office-afhankelijkheid."
---
## **Overzicht**

Dit artikel legt uit hoe je een PowerPoint-presentatie in PPT-formaat converteert naar PPTX-formaat met C# en met de online PPT-naar-PPTX-conversie-app. Het volgende onderwerp wordt behandeld.

- [Converteer PPT naar PPTX in C#](#convert-ppt-to-pptx)

## **Converteer PPT naar PPTX in .NET**

Voor C#-voorbeeldcode om PPT naar PPTX te converteren, zie de sectie hieronder, namelijk [Converteer PPT naar PPTX](#convert-ppt-to-pptx). Het laadt simpelweg het PPT-bestand en slaat het op in PPTX-formaat. Door verschillende opslaan-formaten op te geven, kun je het PPT-bestand ook opslaan in tal van andere formaten zoals PDF, XPS, ODP, HTML enz., zoals besproken in deze artikelen. 

- [Converteer PPT naar PDF in .NET](/slides/nl/net/convert-powerpoint-to-pdf/)
- [Converteer PPT naar XPS in .NET](/slides/nl/net/convert-powerpoint-to-xps/)
- [Converteer PPT naar HTML in .NET](/slides/nl/net/convert-powerpoint-to-html/)
- [Converteer PPT naar ODP in .NET](/slides/nl/net/save-presentation/)
- [Converteer PPT naar PNG in .NET](/slides/nl/net/convert-powerpoint-to-png/)

## **Over PPT-naar-PPTX-conversie**
Converteer het oude PPT-formaat naar PPTX met de Aspose.Slides-API. Als je duizenden PPT-presentaties naar PPTX-formaat moet converteren, is de beste oplossing om dit programmatisch te doen. Met de Aspose.Slides-API is het mogelijk om dit in slechts een paar regels code te realiseren. De API ondersteunt volledige compatibiliteit om PPT-presentaties naar PPTX te converteren en het is mogelijk om:

- Converteer ingewikkelde structuren van masters, lay-outs en dia's.
- Converteer presentaties met grafieken.
- Converteer presentaties met groepsvormen, auto-vormen (zoals rechthoeken en ellipsen), vormen met aangepaste geometrie.
- Converteer presentaties met texturen en afbeelding-vulstijlen voor auto-vormen.
- Converteer presentaties met plaatshouders, tekstkaders en tekstelementen.

{{% alert color="info" %}} 

Bekijk de [**Aspose.Slides PPT-naar-PPTX-conversie**](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)‑app:

[](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx)

Deze app is gebouwd op basis van de **Aspose.Slides API**, zodat je een live voorbeeld kunt zien van de basis PPT-naar-PPTX-conversiemogelijkheden. Aspose.Slides Conversion is een webapp, die het mogelijk maakt een presentatiedossier in PPT-formaat te slepen en het geconverteerde bestand te downloaden als PPTX.

Bekijk andere live [**Aspose.Slides-conversie**](https://products.aspose.app/slides/nl/conversion/)‑voorbeelden.
{{% /alert %}} 


## **Converteer PPT naar PPTX**
Om een PPT naar PPTX te converteren, geef je eenvoudigweg de bestandsnaam en het opslagformaat door aan de [**Save**](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/methods/save/index)‑methode van de [**Presentation**](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse. De C#‑code‑voorbeeld hieronder converteert een Presentatie van PPT naar PPTX met de standaardopties.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een Presentation-object aan dat een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Sla de PPTX-presentatie op in PPTX-formaat
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

Lees meer over de [**PPT vs PPTX**](/slides/nl/net/ppt-vs-pptx/) presentatiefomaten en hoe [**Aspose.Slides PPT-naar-PPTX-conversie ondersteunt**](/slides/nl/net/convert-ppt-to-pptx/).

## **FAQ**

### Wat is het verschil tussen PPT- en PPTX-formaten?

PPT is het oudere binaire bestandsformaat dat door Microsoft PowerPoint wordt gebruikt, terwijl PPTX het nieuwere op XML gebaseerde formaat is dat werd geïntroduceerd met Microsoft Office 2007. PPTX-bestanden bieden betere prestaties, een kleinere bestandsgrootte en verbeterd gegevensherstel.

### Kan ik PPT naar PPTX converteren met .NET?

Ja, met de Aspose.Slides for .NET-bibliotheek kun je eenvoudig een PPT-bestand laden en het met slechts een paar regels code opslaan in PPTX-formaat.

### Ondersteunt Aspose.Slides batch-conversie van meerdere PPT-bestanden naar PPTX?

Ja, je kunt Aspose.Slides in een lus gebruiken om meerdere PPT-bestanden programmatisch naar PPTX te converteren, waardoor het geschikt is voor batch-conversiescenario's.

### Worden de inhoud en opmaak behouden na conversie?

Aspose.Slides behoudt een hoge getrouwheid bij het converteren van presentaties. Dia‑lay-outs, animaties, vormen, grafieken en andere ontwerpelementen blijven behouden tijdens de PPT-naar-PPTX-conversie.

### Kan ik andere formaten zoals PDF of HTML vanuit PPT-bestanden converteren?

Ja, Aspose.Slides ondersteunt het converteren van PPT-bestanden naar meerdere formaten, waaronder PDF, XPS, HTML, ODP en beeldformaten zoals PNG en JPEG.

### Is het mogelijk om PPT naar PPTX te converteren zonder Microsoft PowerPoint geïnstalleerd?

Ja, Aspose.Slides for .NET is een zelfstandige API en vereist geen Microsoft PowerPoint of enige andere derde-partijsoftware om de conversie uit te voeren.

### Is er een online tool beschikbaar voor PPT-naar-PPTX-conversie?

Ja, je kunt de gratis [Aspose.Slides PPT-naar-PPTX-converter](https://products.aspose.app/slides/nl/conversion/ppt-to-pptx) webapplicatie gebruiken om de conversie rechtstreeks in je browser uit te voeren zonder enige code te schrijven.