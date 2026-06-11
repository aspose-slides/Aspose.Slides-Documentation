---
title: Rendera presentationsbilder som SVG-bilder i C++
linktitle: Bild till SVG
type: docs
weight: 50
url: /sv/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint till SVG
- presentation till SVG
- bild till SVG
- PPT till SVG
- PPTX till SVG
- spara PPT som SVG
- spara PPTX som SVG
- exportera PPT till SVG
- exportera PPTX till SVG
- rendera bild
- konvertera bild
- exportera bild
- vektorbild
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du renderar PowerPoint-bilder som SVG-bilder med Aspose.Slides för C++. Högkvalitativa visualiseringar med enkla kodexempel."
---
## **Översikt**

Den här artikeln förklarar hur man renderar presentationsbilder som SVG-bilder med Aspose.Slides. Den beskriver SVG-formatet och dess fördelar, inklusive skalbarhet, tillgänglighet och lämplighet för webbutveckling.

Du kommer att lära dig hur du läser in en presentationsfil, itererar genom dess bilder och sparar varje bild som en separat SVG-fil. Artikeln täcker PowerPoint- och OpenDocument-presentationformat, inklusive PPT, PPTX, ODP och PPS, och visar hur man utför konverteringen programmatiskt med `Presentation`‑klassen och `WriteAsSvg`‑metoden.

## **SVG-format**

SVG—en förkortning för Scalable Vector Graphics—är en standardgrafiktyp eller -format som används för att rendera tvådimensionella bilder. SVG lagrar bilder som vektorer i XML med detaljer som definierar deras beteende eller utseende.

SVG är ett av de få bildformat som uppfyller mycket höga krav på skalbarhet, interaktivitet, prestanda, tillgänglighet, programmerbarhet och annat. Av dessa skäl används det ofta i webbutveckling.

Du kan vilja använda SVG-filer när du behöver

- **Skriv ut din presentation i ett *mycket stort format*.** SVG-bilder kan skalas upp till vilken upplösning eller nivå som helst. Du kan ändra storlek på SVG-bilder så många gånger som behövs utan att förlora kvalitet.
- **Använd diagram och grafer från dina bilder i *olika medier eller plattformar*.** De flesta läsare kan tolka SVG-filer.
- **Använd de *minsta möjliga bildstorlekarna*.** SVG-filer är generellt mindre än deras högupplösta motsvarigheter i andra format, särskilt de format som baseras på bitmap (JPEG eller PNG).

## **Rendera en bild som en SVG-bild**

Aspose.Slides för C++ låter dig exportera bilder i dina presentationer som SVG-bilder. Följ dessa steg för att generera SVG-bilder:

1. Skapa en instans av Presentation-klassen.
2. Iterera genom alla bilder i presentationen.
3. Skriv varje bild till sin egen SVG-fil via FileStream.

{{% alert color="primary" %}} 
Du kan vilja prova vår [gratis webbapplikation](https://products.aspose.app/slides/sv/conversion/ppt-to-svg) där vi har implementerat PPT‑till‑SVG‑konverteringsfunktionen från Aspose.Slides för C++.
{{% /alert %}} 

Det här exempelprogrammet i C++ visar hur du konverterar PPT till SVG med Aspose.Slides:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
        
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto fileName = String::Format(u"slide-{0}.svg", index);
    auto fileStream = System::MakeObject<FileStream>(fileName, FileMode::Create, FileAccess::Write);

    auto slide = pres->get_Slides()->idx_get(index);
    slide->WriteAsSvg(fileStream);
}
```

## **FAQ**

**Varför kan den resulterande SVG:n se olika ut i olika webbläsare?**

Stöd för specifika SVG-funktioner implementeras olika av webbläsarmotorerna. [SVGOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/)‑parametrar hjälper till att jämna ut inkompatibiliteter.

**Är det möjligt att exportera inte bara bilder utan även enskilda former till SVG?**

Ja. Alla [former kan sparas som separata SVG-filer](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/writeassvg/), vilket är praktiskt för ikoner, piktogram och återanvändning av grafik.

**Kan flera bilder kombineras till en enda SVG (strip/dokument)?**

Standardscenario är en bild → en SVG. Att kombinera flera bilder till en enda SVG‑yta är ett efterbehandlingssteg som utförs på applikationsnivå.