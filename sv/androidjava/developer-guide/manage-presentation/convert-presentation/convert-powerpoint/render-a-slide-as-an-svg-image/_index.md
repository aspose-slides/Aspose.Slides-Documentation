---
title: Rendera presentationsbilder som SVG-bilder på Android
linktitle: Bild till SVG
type: docs
weight: 50
url: /sv/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du renderar PowerPoint‑bilder som SVG-bilder med Aspose.Slides för Android. Högkvalitativa visualiseringar med enkla Java‑kodexempel."
---
## **Översikt**

Den här artikeln förklarar hur du kan rendera presentationsbilder som SVG-bilder med Aspose.Slides. Den beskriver SVG-formatet och dess fördelar, inklusive skalbarhet, tillgänglighet och lämplighet för webbutveckling.

Du kommer att lära dig hur du laddar en presentationsfil, itererar genom dess bilder och sparar varje bild som en separat SVG-fil. Artikeln behandlar PowerPoint- och OpenDocument-presentationformat, inklusive PPT, PPTX, ODP och PPS, och visar hur du utför konverteringen programatiskt med `Presentation`‑klassen och `writeAsSvg`‑metoden.

## **SVG-format**

SVG—en förkortning för Scalable Vector Graphics—är en standardgrafiktyp eller -format som används för att rendera tvådimensionella bilder. SVG lagrar bilder som vektorer i XML med detaljer som definierar deras beteende eller utseende.  

SVG är ett av få bildformat som uppfyller mycket höga krav inom dessa områden: skalbarhet, interaktivitet, prestanda, tillgänglighet, programmerbarhet och andra. Av dessa skäl används det ofta i webbutveckling.  

Du kanske vill använda SVG-filer när du behöver

- **Skriva ut din presentation i ett *mycket stort format*.** SVG-bilder kan skalas upp till vilken upplösning eller nivå som helst. Du kan ändra storleken på SVG-bilder så ofta som behövs utan att kompromissa med kvaliteten.  
- **Använd diagram och grafer från dina bilder i *olika medier eller plattformar*.** De flesta läsare kan tolka SVG-filer.  
- **Använd de *minsta möjliga storlekarna på bilder***. SVG-filer är generellt mindre än motsvarande högupplösta versioner i andra format, särskilt de format som baseras på bitmap (JPEG eller PNG).

## **Rendera en bild som en SVG-bild**

Aspose.Slides för Android via Java låter dig exportera bilder i dina presentationer som SVG-bilder. Följ dessa steg för att skapa SVG-bilder:

1. Skapa en instans av `Presentation`‑klassen.  
2. Iterera genom alla bilder i presentationen.  
3. Skriv varje bild till sin egen SVG-fil via `FileOutputStream`.  

{{% alert color="primary" %}} 
Du kanske vill prova vår [gratis webbapplikation](https://products.aspose.app/slides/sv/conversion/ppt-to-svg) där vi har implementerat PPT‑till‑SVG‑konverteringsfunktionen från Aspose.Slides för Android via Java.
{{% /alert %}} 

Den här exempel­koden i Java visar hur du konverterar PPT till SVG med Aspose.Slides:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Varför kan den resulterande SVG:n se annorlunda ut i olika webbläsare?**  
Stödet för specifika SVG-funktioner implementeras olika av webbläsarmotorer. Parametrar i [SVGOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/) hjälper till att jämna ut inkompatibiliteter.

**Är det möjligt att exportera inte bara bilder utan även enskilda former till SVG?**  
Ja. Alla [former kan sparas som en separat SVG](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), vilket är praktiskt för ikoner, pictogram och återanvändning av grafik.

**Kan flera bilder kombineras till en enda SVG (strip/dokument)?**  
Det vanliga scenariot är en bild → en SVG. Att kombinera flera bilder till en enda SVG‑yta är ett efterbearbetningssteg som utförs på applikationsnivå.