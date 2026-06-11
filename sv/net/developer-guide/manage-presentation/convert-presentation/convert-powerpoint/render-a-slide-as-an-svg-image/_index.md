---
title: Rendera presentationsbilder som SVG‑bilder i .NET
linktitle: Bildruta till SVG
type: docs
weight: 50
url: /sv/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint till SVG
- presentation till SVG
- bildruta till SVG
- PPT till SVG
- PPTX till SVG
- spara PPT som SVG
- spara PPTX som SVG
- exportera PPT till SVG
- exportera PPTX till SVG
- rendera bildruta
- konvertera bildruta
- exportera bildruta
- vektorbild
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du renderar PowerPoint‑bilder som SVG‑bilder med Aspose.Slides för .NET. Högkvalitativa visualiseringar med enkla C#‑kodexempel."
---
## **Översikt**

Den här artikeln förklarar hur du renderar presentationsbilder som SVG‑bilder med Aspose.Slides. Den beskriver SVG‑formatet och dess fördelar, inklusive skalbarhet, tillgänglighet och lämplighet för webb­utveckling.

Du kommer att lära dig hur du öppnar en presentationsfil, itererar genom bildrutor och sparar varje bildruta som en separat SVG‑fil. Artikeln täcker PowerPoint‑ och OpenDocument‑presentationsformat, inklusive PPT, PPTX, ODP och PPS, och visar hur du utför konverteringen programatiskt med klassen `Presentation` och metoden `WriteAsSvg`.

## **SVG‑format**
SVG — en förkortning för Scalable Vector Graphics — är en standardgrafiktyp eller -format som används för att rendera tvådimensionella bilder. SVG lagrar bilder som vektorer i XML med detaljer som definierar deras beteende eller utseende.  

SVG är ett av de få bildformat som uppfyller mycket höga krav på skalbarhet, interaktivitet, prestanda, tillgänglighet, programmerbarhet och annat. Av dessa skäl används formatet ofta i webb­utveckling.  

Du kan vilja använda SVG‑filer när du behöver

- **skriva ut din presentation i ett *mycket stort format*.** SVG‑bilder kan skalas till vilken upplösning eller nivå som helst. Du kan ändra storlek på SVG‑bilder så många gånger som behövs utan kvalitetsförlust.  
- **använda diagram och grafer från dina bildrutor i *olika medier eller plattformar*.** De flesta läsare kan tolka SVG‑filer.  
- **använda *minsta möjliga bildstorlekar*.** SVG‑filer är i allmänhet mindre än deras högupplösta motsvarigheter i andra format, särskilt de format som bygger på bitmap (JPEG eller PNG).

## **Rendera en bildruta som en SVG‑bild**

Aspose.Slides för .NET låter dig exportera bildrutor i dina presentationer som SVG‑bilder. Följ dessa steg för att generera SVG‑bilder:

*Steg: PowerPoint‑till‑SVG‑konverteringar i C#*

Följande exempelkod förklarar dessa konverteringar med .NET.  
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Steg: Konvertera PowerPoint till SVG i C#</strong></a>  
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Steg: Konvertera PPT till SVG i C#</strong></a>  
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Steg: Konvertera PPTX till SVG i C#</strong></a>  
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Steg: Konvertera ODP till SVG i C#</strong></a>

_Kodsteg:_

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).  
   * _.ppt_-tillägg för att läsa in **PPT**‑fil i _Presentation_-klassen.  
   * _.pptx_-tillägg för att läsa in **PPTX**‑fil i _Presentation_-klassen.  
   * _.odp_-tillägg för att läsa in **ODP**‑fil i _Presentation_-klassen.  
   * _.pps_-tillägg för att läsa in **PPS**‑fil i _Presentation_-klassen.  
2. Iterera genom alla bildrutor i presentationen.  
3. Skriv varje bildruta till en egen SVG‑fil via `FileStream`.

{{% alert color="primary" %}} 

Du kan prova vår [gratis webbapplikation](https://products.aspose.app/slides/sv/conversion/ppt-to-svg) där vi har implementerat PPT‑till‑SVG‑konverteringsfunktionen från Aspose.Slides för .NET.

{{% /alert %}} 

Den här exempel­koden i C# visar hur du konverterar PowerPoint till SVG med Aspose.Slides:  

``` csharp
// Presentation‑objektet kan läsa in PowerPoint‑format som PPT, PPTX, ODP med mera.
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

## **Vanliga frågor**

**Varför kan den resulterande SVG‑filen se olika ut i olika webbläsare?**

Stöd för specifika SVG‑funktioner implementeras olika i webbläsarmotorer. Parametrar i [SVGOptions](https://reference.aspose.com/slides/sv/net/aspose.slides.export/svgoptions/) hjälper till att jämna ut inkompatibiliteter.

**Är det möjligt att exportera inte bara bildrutor utan även enskilda former till SVG?**

Ja. Alla [former kan sparas som separata SVG‑filer](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/writeassvg/), vilket är praktiskt för ikoner, pictogram och återanvändning av grafik.

**Kan flera bildrutor kombineras till en enda SVG (strip/dokument)?**

Det vanliga scenariot är en bildruta → en SVG. Att kombinera flera bildrutor till en enda SVG‑canvas är ett efterbearbetningssteg som utförs på applikationsnivå.

## **Se även** 

Den här artikeln täcker även följande ämnen. Koderna är desamma som ovan.

_Format_: **PowerPoint**  
- [C# PowerPoint till SVG‑kod](#csharp-powerpoint-to-svg)  
- [C# PowerPoint till SVG‑API](#csharp-powerpoint-to-svg)  
- [C# PowerPoint till SVG‑programmering](#csharp-powerpoint-to-svg)  
- [C# PowerPoint till SVG‑bibliotek](#csharp-powerpoint-to-svg)  
- [C# Spara PowerPoint som SVG](#csharp-powerpoint-to-svg)  
- [C# Generera SVG från PowerPoint](#csharp-powerpoint-to-svg)  
- [C# Skapa SVG från PowerPoint](#csharp-powerpoint-to-svg)  
- [C# PowerPoint till SVG‑konverterare](#csharp-powerpoint-to-svg)  

_Format_: **PPT**  
- [C# PPT till SVG‑kod](#csharp-ppt-to-svg)  
- [C# PPT till SVG‑API](#csharp-ppt-to-svg)  
- [C# PPT till SVG‑programmering](#csharp-ppt-to-svg)  
- [C# PPT till SVG‑bibliotek](#csharp-ppt-to-svg)  
- [C# Spara PPT som SVG](#csharp-ppt-to-svg)  
- [C# Generera SVG från PPT](#csharp-ppt-to-svg)  
- [C# Skapa SVG från PPT](#csharp-ppt-to-svg)  
- [C# PPT till SVG‑konverterare](#csharp-ppt-to-svg)  

_Format_: **PPTX**  
- [C# PPTX till SVG‑kod](#csharp-pptx-to-svg)  
- [C# PPTX till SVG‑API](#csharp-pptx-to-svg)  
- [C# PPTX till SVG‑programmering](#csharp-pptx-to-svg)  
- [C# PPTX till SVG‑bibliotek](#csharp-pptx-to-svg)  
- [C# Spara PPTX som SVG](#csharp-pptx-to-svg)  
- [C# Generera SVG från PPTX](#csharp-pptx-to-svg)  
- [C# Skapa SVG från PPTX](#csharp-pptx-to-svg)  
- [C# PPTX till SVG‑konverterare](#csharp-pptx-to-svg)  

_Format_: **ODP**  
- [C# ODP till SVG‑kod](#csharp-odp-to-svg)  
- [C# ODP till SVG‑API](#csharp-odp-to-svg)  
- [C# ODP till SVG‑programmering](#csharp-odp-to-svg)  
- [C# ODP till SVG‑bibliotek](#csharp-odp-to-svg)  
- [C# Spara ODP som SVG](#csharp-odp-to-svg)  
- [C# Generera SVG från ODP](#csharp-odp-to-svg)  
- [C# Skapa SVG från ODP](#csharp-odp-to-svg)  
- [C# ODP till SVG‑konverterare](#csharp-odp-to-svg)