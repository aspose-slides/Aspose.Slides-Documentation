---
title: Presentatieslides renderen als SVG-afbeeldingen in .NET
linktitle: Slide naar SVG
type: docs
weight: 50
url: /nl/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint naar SVG
- presentatie naar SVG
- slide naar SVG
- PPT naar SVG
- PPTX naar SVG
- PPT opslaan als SVG
- PPTX opslaan als SVG
- PPT exporteren naar SVG
- PPTX exporteren naar SVG
- slide renderen
- slide converteren
- slide exporteren
- vectorafbeelding
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u PowerPoint‑slides kunt renderen als SVG‑afbeeldingen met Aspose.Slides voor .NET. Hoogwaardige visuals met eenvoudige C#‑codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatieslides kunt renderen als SVG‑afbeeldingen met Aspose.Slides. Het beschrijft het SVG‑formaat en de voordelen, waaronder schaalbaarheid, toegankelijkheid en geschiktheid voor webontwikkeling.

U leert hoe u een presentatiebestand laadt, door de slides itereren, en elke slide opslaat als een afzonderlijk SVG‑bestand. Het artikel behandelt PowerPoint‑ en OpenDocument‑presentatieformaten, waaronder PPT, PPTX, ODP en PPS, en toont hoe u de conversie programmatisch kunt uitvoeren met de `Presentation`‑klasse en de `WriteAsSvg`‑methode.

## **SVG‑formaat**

SVG—een acroniem voor Scalable Vector Graphics— is een standaardgrafiektype of -formaat dat wordt gebruikt om tweedimensionale afbeeldingen weer te geven. SVG slaat afbeeldingen op als vectoren in XML met details die hun gedrag of uiterlijk definiëren.

SVG is een van de weinige afbeeldingsformaten die zeer hoge eisen voldoen op het gebied van schaalbaarheid, interactiviteit, prestaties, toegankelijkheid, programmeerbaarheid en meer. Om deze redenen wordt het veel gebruikt bij webontwikkeling.

U wilt SVG‑bestanden mogelijk gebruiken wanneer u:

- **uw presentatie afdrukken in een *zeer groot formaat*.** SVG‑afbeeldingen kunnen opschalen tot elke resolutie of elk niveau. U kunt SVG‑afbeeldingen zo vaak als nodig verkleinen of vergroten zonder kwaliteitsverlies.
- **grafieken en diagrammen uit uw slides gebruiken in *verschillende media of platformen*.** De meeste weergaveprogramma's kunnen SVG‑bestanden interpreteren.
- **de *kleinste mogelijke afbeeldingsgroottes* gebruiken**. SVG‑bestanden zijn over het algemeen kleiner dan hun hoog‑resolutie‑equivalenten in andere formaten, vooral die formaten die gebaseerd zijn op bitmap (JPEG of PNG).

## **Een slide renderen als een SVG‑afbeelding**

Aspose.Slides voor .NET stelt u in staat om slides in uw presentaties te exporteren als SVG‑afbeeldingen. Volg deze stappen om SVG‑afbeeldingen te genereren:

_Steps: PowerPoint to SVG Conversions in C#_

De onderstaande voorbeeldcode legt deze conversies uit met behulp van .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Stappen: PowerPoint naar SVG converteren in C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Stappen: PPT naar SVG converteren in C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Stappen: PPTX naar SVG converteren in C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Stappen: ODP naar SVG converteren in C#</strong></a>

_Code-stappen:_

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
   * _.ppt_-extensie om een **PPT**‑bestand te laden in de _Presentation_-klasse.
   * _.pptx_-extensie om een **PPTX**‑bestand te laden in de _Presentation_-klasse.
   * _.odp_-extensie om een **ODP**‑bestand te laden in de _Presentation_-klasse.
   * _.pps_-extensie om een **PPS**‑bestand te laden in de _Presentation_-klasse.
2. Itereer door alle slides in de presentatie.
3. Schrijf elke slide naar een eigen SVG‑bestand via FileStream.

{{% alert color="primary" %}} 

U kunt onze [gratis webapplicatie](https://products.aspose.app/slides/nl/conversion/ppt-to-svg) uitproberen, waarin we de PPT‑naar‑SVG‑conversiefunctie van Aspose.Slides voor .NET hebben geïmplementeerd.

{{% /alert %}} 

Deze voorbeeldcode in C# laat zien hoe u PowerPoint naar SVG kunt converteren met Aspose.Slides: 

``` csharp
// Presentatie‑object kan PowerPoint‑formaten laden zoals PPT, PPTX, ODP enz.
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

## **FAQ**

**Waarom kan de resulterende SVG er verschillend uitzien in verschillende browsers?**

Ondersteuning voor specifieke SVG‑functies wordt door verschillende browser‑engines anders geïmplementeerd. De parameters van [SVGOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/svgoptions/) helpen incompatibiliteiten te verzachten.

**Is het mogelijk om niet alleen slides maar ook individuele vormen naar SVG te exporteren?**

Ja. Elke [vorm kan als een afzonderlijke SVG worden opgeslagen](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/writeassvg/), wat handig is voor pictogrammen en het hergebruiken van grafische elementen.

**Kunnen meerdere slides worden gecombineerd tot één enkele SVG (strip/document)?**

Het standaardscenario is één slide → één SVG. Het combineren van meerdere slides tot één enkele SVG‑canvas is een nabewerkingsstap die op toepassingsniveau wordt uitgevoerd.

## **Zie ook** 

Dit artikel behandelt ook de volgende onderwerpen. De code is dezelfde als hierboven.

_Format_: **PowerPoint**
- [C# PowerPoint naar SVG‑code](#csharp-powerpoint-to-svg)
- [C# PowerPoint naar SVG‑API](#csharp-powerpoint-to-svg)
- [C# PowerPoint naar SVG‑programmering](#csharp-powerpoint-to-svg)
- [C# PowerPoint naar SVG‑bibliotheek](#csharp-powerpoint-to-svg)
- [C# PowerPoint opslaan als SVG](#csharp-powerpoint-to-svg)
- [C# SVG genereren vanuit PowerPoint](#csharp-powerpoint-to-svg)
- [C# SVG maken vanuit PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint naar SVG‑converter](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT naar SVG‑code](#csharp-ppt-to-svg)
- [C# PPT naar SVG‑API](#csharp-ppt-to-svg)
- [C# PPT naar SVG‑programmering](#csharp-ppt-to-svg)
- [C# PPT naar SVG‑bibliotheek](#csharp-ppt-to-svg)
- [C# PPT opslaan als SVG](#csharp-ppt-to-svg)
- [C# SVG genereren vanuit PPT](#csharp-ppt-to-svg)
- [C# SVG maken vanuit PPT](#csharp-ppt-to-svg)
- [C# PPT naar SVG‑converter](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX naar SVG‑code](#csharp-pptx-to-svg)
- [C# PPTX naar SVG‑API](#csharp-pptx-to-svg)
- [C# PPTX naar SVG‑programmering](#csharp-pptx-to-svg)
- [C# PPTX naar SVG‑bibliotheek](#csharp-pptx-to-svg)
- [C# PPTX opslaan als SVG](#csharp-pptx-to-svg)
- [C# SVG genereren vanuit PPTX](#csharp-pptx-to-svg)
- [C# SVG maken vanuit PPTX](#csharp-pptx-to-svg)
- [C# PPTX naar SVG‑converter](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP naar SVG‑code](#csharp-odp-to-svg)
- [C# ODP naar SVG‑API](#csharp-odp-to-svg)
- [C# ODP naar SVG‑programmering](#csharp-odp-to-svg)
- [C# ODP naar SVG‑bibliotheek](#csharp-odp-to-svg)
- [C# ODP opslaan als SVG](#csharp-odp-to-svg)
- [C# SVG genereren vanuit ODP](#csharp-odp-to-svg)
- [C# SVG maken vanuit ODP](#csharp-odp-to-svg)
- [C# ODP naar SVG‑converter](#csharp-odp-to-svg)