---
title: Rendera bild som SVG‑bild
type: docs
weight: 50
url: /sv/net/render-slide-as-svg-image/
---
SVG—en akronym för Scalable Vector Graphics—är en standardgrafiktyp eller -format som används för att rendera tvådimensionella bilder. SVG lagrar bilder som vektorer i XML med detaljer som definierar deras beteende eller utseende. 

SVG är ett av de få bildformat som uppfyller mycket höga krav på dessa områden: skalbarhet, interaktivitet, prestanda, tillgänglighet, programmerbarhet och annat. Av dessa skäl används det ofta i webbutveckling. 

Du kan vilja använda SVG‑filer i följande scenarier:

- när du planerar att skriva ut din presentation i ett mycket stort format. SVG‑bilder kan skalas upp till godtycklig upplösning eller nivå. Du kan ändra storlek på SVG‑bilder så många gånger som behövs utan att kompromissa med kvaliteten.
- när du avser att använda diagram och grafer från dina bildspel i olika medier eller plattformar. De flesta läsare kan tolka SVG‑filer. 
- när du behöver använda minsta möjliga bildstorlekar. SVG‑filer är generellt mindre än deras högupplösta motsvarigheter i andra format, särskilt de format som är baserade på bitmap (JPEG eller PNG).

Aspose.Slides for .NET gör det möjligt att exportera bildspel i dina presentationer som **SVG**‑bilder. För att generera en SVG‑bild från någon, gör så här:

- Skapa en instans av Presentation‑klassen.
- Iterera genom alla bildspel i presentationen.
- Skriv varje bild till en egen SVG‑fil via FileStream.

{{% alert color="info" %}} 

Du kan prova vår [gratis webbapplikation](https://products.aspose.app/slides/sv/conversion/ppt-to-svg) där vi har implementerat PPT‑till‑SVG‑konverteringsfunktionen från Aspose.Slides for .NET.

{{% /alert %}} 

Den här exempelkoden i C# visar hur du konverterar PPT till SVG med Aspose.Slides:

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