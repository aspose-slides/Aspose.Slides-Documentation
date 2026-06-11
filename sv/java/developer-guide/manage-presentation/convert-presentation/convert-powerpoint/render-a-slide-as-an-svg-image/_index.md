---
title: Rendera presentationsbilder som SVG‑bilder i Java
linktitle: Bildruta till SVG
type: docs
weight: 50
url: /sv/java/render-a-slide-as-an-svg-image/
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
- Java
- Aspose.Slides
description: "Lär dig hur du renderar PowerPoint‑bilder som SVG‑bilder med Aspose.Slides för Java. Högkvalitativa visuella element med enkla kodexempel."
---
## **Översikt**

Den här artikeln förklarar hur du renderar presentationsbilder som SVG‑bilder med Aspose.Slides. Den beskriver SVG‑formatet och dess fördelar, inklusive skalbarhet, tillgänglighet och lämplighet för webbutveckling.

Du kommer att lära dig hur du läser in en presentationsfil, itererar genom dess bilder och sparar varje bild som en separat SVG‑fil. Artikeln täcker PowerPoint‑ och OpenDocument‑presentationsformat, inklusive PPT, PPTX, ODP och PPS, och visar hur du utför konverteringen programatiskt med klassen `Presentation` och metoden `writeAsSvg`.

## **SVG-format**

SVG—en förkortning för Scalable Vector Graphics—är en standardgrafiktyp eller -format som används för att rendera tvådimensionella bilder. SVG lagrar bilder som vektorer i XML med detaljer som definierar deras beteende eller utseende.

SVG är ett av de få bildformat som uppfyller mycket höga krav inom dessa områden: skalbarhet, interaktivitet, prestanda, tillgänglighet, programmerbarhet och andra. Av dessa skäl används det ofta i webbutveckling.

Du kan vilja använda SVG‑filer när du behöver

- **Skriv ut din presentation i ett *mycket stort format*.** SVG‑bilder kan skalas upp till vilken upplösning eller nivå som helst. Du kan ändra storlek på SVG‑bilder så många gånger som behövs utan att förlora kvalitet.
- **Använd diagram och grafer från dina bilder i *olika medier eller plattformar*.** De flesta läsare kan tolka SVG‑filer.
- **Använd de *minsta möjliga storlekarna* på bilderna.** SVG‑filer är generellt mindre än deras högupplösta motsvarigheter i andra format, särskilt de format som är baserade på bitmap (JPEG eller PNG).

## **Rendera en bildruta som en SVG‑bild**

Aspose.Slides for Java låter dig exportera bildrutor i dina presentationer som SVG‑bilder. Följ dessa steg för att generera SVG‑bilder:

1. Skapa en instans av klassen `Presentation`.
2. Iterera genom alla bildrutor i presentationen.
3. Skriv varje bildruta till sin egen SVG‑fil via `FileOutputStream`.

{{% alert color="primary" %}} 

Du kanske vill prova vår [gratis webapplikation](https://products.aspose.app/slides/sv/conversion/ppt-to-svg) där vi implementerade PPT‑till‑SVG‑konverteringsfunktionen från Aspose.Slides for Java.

{{% /alert %}} 

Det här exempelprogrammet i Java visar hur du konverterar PPT till SVG med Aspose.Slides:

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

**Varför kan den resulterande SVG‑filen se olika ut i olika webbläsare?**

Stödet för specifika SVG‑funktioner implementeras olika av webbläsarmotorer. Parametrar i [SVGOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/svgoptions/) hjälper till att jämna ut inkompatibiliteter.

**Är det möjligt att exportera inte bara bildrutor utan även enskilda former till SVG?**

Ja. Alla [former kan sparas som en separat SVG](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), vilket är praktiskt för ikoner, pictogram och återanvändning av grafik.

**Kan flera bildrutor kombineras till en enda SVG (strip/dokument)?**

Standardscenariot är en bildruta → en SVG. Att kombinera flera bildrutor till en enda SVG‑yta är ett efterbearbetningssteg som utförs på applikationsnivå.