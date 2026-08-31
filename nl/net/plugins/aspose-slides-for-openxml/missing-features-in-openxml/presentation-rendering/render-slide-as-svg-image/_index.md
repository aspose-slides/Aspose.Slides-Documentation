---
title: Dia weergeven als SVG-afbeelding
type: docs
weight: 50
url: /nl/net/render-slide-as-svg-image/
---
SVG—een afkorting voor Scalable Vector Graphics—is een standaard grafiektype of -formaat dat wordt gebruikt om tweedimensionale afbeeldingen weer te geven. SVG slaat afbeeldingen op als vectoren in XML met details die hun gedrag of uiterlijk definiëren. 

SVG is een van de weinige formaten voor afbeeldingen die zeer hoge standaarden halen op het gebied van schaalbaarheid, interactiviteit, prestaties, toegankelijkheid, programmeerbaarheid en andere. Om deze redenen wordt het veel gebruikt in webontwikkeling. 

U wilt SVG‑bestanden mogelijk gebruiken in de volgende scenario's:

- wanneer u uw presentatie wilt afdrukken in een zeer groot formaat. SVG‑afbeeldingen kunnen opschalen naar elke resolutie of elk niveau. U kunt SVG‑afbeeldingen zo vaak als nodig aanpassen zonder kwaliteitsverlies.
- wanneer u diagrammen en grafieken uit uw dia's wilt gebruiken in verschillende media of platformen. De meeste lezers kunnen SVG‑bestanden interpreteren. 
- wanneer u de kleinst mogelijke afbeeldingsgrootte nodig heeft. SVG‑bestanden zijn over het algemeen kleiner dan hun hoge‑resolutie‑equivalenten in andere formaten, vooral die formaten die gebaseerd zijn op bitmap (JPEG of PNG).

Aspose.Slides for .NET stelt u in staat om dia's in uw presentaties te exporteren als **SVG**‑afbeeldingen. Om een SVG‑afbeelding van een dia te genereren, doet u het volgende:

- Maak een instantie van de Presentation‑klasse.
- Loop door alle dia's in de presentatie.
- Schrijf elke dia naar een eigen SVG‑bestand via FileStream.

{{% alert color="info" %}} 
U wilt misschien onze [gratis webapplicatie](https://products.aspose.app/slides/nl/conversion/ppt-to-svg) uitproberen, waarin we de PPT‑naar‑SVG‑conversiefunctie van Aspose.Slides for .NET hebben geïmplementeerd.
{{% /alert %}} 

Deze voorbeeldcode in C# laat zien hoe u PPT naar SVG kunt converteren met Aspose.Slides:

``` csharp
using Aspose.Slides;

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