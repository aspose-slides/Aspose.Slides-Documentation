---
title: Dia renderen als SVG-afbeelding
type: docs
weight: 50
url: /nl/net/render-slide-as-svg-image/
---
SVG — een afkorting voor Scalable Vector Graphics — is een standaardgrafiektype of -formaat dat wordt gebruikt om tweedimensionale afbeeldingen te renderen. SVG slaat afbeeldingen op als vectoren in XML met details die hun gedrag of uiterlijk definiëren.  

SVG is een van de weinige beeldformaten die zeer hoge normen voldoet op het gebied van: schaalbaarheid, interactiviteit, prestaties, toegankelijkheid, programmeerbaarheid en meer. Om deze redenen wordt het veel gebruikt in webontwikkeling.  

U wilt SVG‑bestanden wellicht gebruiken in de volgende situaties:

- wanneer u van plan bent uw presentatie af te drukken in een zeer groot formaat. SVG‑afbeeldingen kunnen opschalen tot elke resolutie of elk niveau. U kunt SVG‑afbeeldingen zoveel keer aanpassen als nodig zonder kwaliteitsverlies.  
- wanneer u diagrammen en grafieken uit uw dia's in verschillende media of platforms wilt gebruiken. De meeste lezers kunnen SVG‑bestanden interpreteren.  
- wanneer u de kleinst mogelijke afbeeldingsgroottes nodig heeft. SVG‑bestanden zijn doorgaans kleiner dan hun hoge‑resolutie‑equivalenten in andere formaten, vooral die formaten die gebaseerd zijn op bitmap (JPEG of PNG).  

Aspose.Slides for .NET stelt u in staat om dia's in uw presentaties te exporteren als **SVG**‑afbeeldingen. Om een SVG‑afbeelding vanuit een willekeurige dia te maken, doet u het volgende:

- Maak een instantie van de klasse Presentation.  
- Doorloop alle dia's in de presentatie.  
- Schrijf elke dia naar een eigen SVG‑bestand via een FileStream.  

{{% alert color="primary" %}} 
U wilt wellicht onze [gratis webapplicatie](https://products.aspose.app/slides/nl/conversion/ppt-to-svg) uitproberen waarin we de PPT‑naar‑SVG‑conversiefunctie van Aspose.Slides for .NET hebben geïmplementeerd. 
{{% /alert %}} 

Deze voorbeeldcode in C# toont hoe u PPT naar SVG kunt converteren met Aspose.Slides:

``` csharp
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