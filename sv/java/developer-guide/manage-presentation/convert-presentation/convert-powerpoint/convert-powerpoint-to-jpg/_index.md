---
title: Konvertera PPT och PPTX till JPG i Java
linktitle: PowerPoint till JPG
type: docs
weight: 60
url: /sv/java/convert-powerpoint-to-jpg/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till JPG
- presentation till JPG
- bild till JPG
- PPT till JPG
- PPTX till JPG
- spara PowerPoint som JPG
- spara presentation som JPG
- spara bild som JPG
- spara PPT som JPG
- spara PPTX som JPG
- exportera PPT till JPG
- exportera PPTX till JPG
- Java
- Aspose.Slides
description: "Konvertera PowerPoint (PPT, PPTX)-bilder till högkvalitativa JPG-bilder i Java med Aspose.Slides för Java med snabba, pålitliga kodexempel."
---
## **Introduktion**

Att konvertera PowerPoint- och OpenDocument-presentationer till JPG‑bilder underlättar delning av bildspel, optimerar prestanda och möjliggör inbäddning av innehåll på webbplatser eller i applikationer. Aspose.Slides låter dig omvandla PPTX-, PPT‑ och ODP‑filer till högkvalitativa JPEG‑bilder. Denna guide beskriver olika metoder för konvertering.

Med dessa funktioner är det enkelt att implementera en egen presentationsvisare och skapa en miniatyrbild för varje bild. Detta kan vara användbart om du vill skydda bildspel från kopiering eller visa presentationen i skrivskyddat läge. Aspose.Slides gör det möjligt att konvertera hela presentationen eller en specifik bild till bildformat.

## **Konvertera PowerPoint PPT/PPTX till JPG**

Här är stegen för att konvertera PPT/PPTX till JPG:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)‑typen.
2. Hämta bildobjektet av [ISlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlide)‑typen från [Presentation.getSlides()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--)‑samlingen.
3. Skapa en miniatyr av varje bild och konvertera den sedan till JPG. Metoden [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlide#getImage-float-float-) används för att få en miniatyr av en bild och returnerar ett [Images](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Images)‑objekt. Metoden [getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) måste anropas från den önskade [ISlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlide)‑typen; skalan på den resulterande miniatyren skickas som parametrar till metoden.
4. När du har fått bildens miniatyr, anropa [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IImage#save(String formatName, int imageFormat))‑metoden från miniatyrobjektet. Skicka med det resulterande filnamnet och bildformatet.

{{% alert color="primary" %}}

**Obs**: Konvertering från PPT/PPTX till JPG skiljer sig från konvertering till andra typer i Aspose.Slides‑API:et. För andra typer använder du vanligtvis [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)‑metoden, men här måste du använda [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IImage#save(String formatName, int imageFormat))‑metoden.

{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Skapar en bild i full skala
        IImage slideImage = sld.getImage(1f, 1f);

        // Sparar bilden till disk i JPEG-format
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konvertera PowerPoint PPT/PPTX till JPG med anpassade dimensioner**

För att ändra dimensionen på den resulterande miniatyren och JPG‑bilden kan du sätta *ScaleX* och *ScaleY*-värdena genom att skicka dem till [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlide#getImage-float-float-)‑metoderna:

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Definierar dimensioner
    int desiredX = 1200;
    int desiredY = 800;
    // Hämtar skalade värden för X och Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Skapar en bild i full skala
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Sparar bilden till disk i JPEG-format
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rendera kommentarer när du sparar bilder av bilder**

Aspose.Slides för Java erbjuder en funktion som låter dig rendera kommentarer i en presentations bilder när du konverterar dem till bilder. Följande Java‑kod demonstrerar detta:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Aspose tillhandahåller en [FREE Collage web app](https://products.aspose.app/slides/sv/collage). Med den här onlinetjänsten kan du slå ihop [JPG to JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG‑till‑PNG‑bilder, skapa [photo grids](https://products.aspose.app/slides/sv/collage/photo-grid) och så vidare.

Genom att använda samma principer som beskrivs i den här artikeln kan du konvertera bilder från ett format till ett annat. För mer information, se dessa sidor: konvertera [image to JPG](https://products.aspose.com/slides/sv/java/conversion/image-to-jpg/); konvertera [JPG to image](https://products.aspose.com/slides/sv/java/conversion/jpg-to-image/); konvertera [JPG to PNG](https://products.aspose.com/slides/sv/java/conversion/jpg-to-png/), konvertera [PNG to JPG](https://products.aspose.com/slides/sv/java/conversion/png-to-jpg/); konvertera [PNG to SVG](https://products.aspose.com/slides/sv/java/conversion/png-to-svg/), konvertera [SVG to PNG](https://products.aspose.com/slides/sv/java/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Stöder den här metoden batch‑konvertering?**

Ja, Aspose.Slides möjliggör batch‑konvertering av flera bilder till JPG i en enda operation.

**Stöder konverteringen SmartArt, diagram och andra komplexa objekt?**

Ja, Aspose.Slides renderar allt innehåll, inklusive SmartArt, diagram, tabeller, former och mer. Renderingsnoggrannheten kan dock variera något jämfört med PowerPoint, särskilt vid användning av anpassade eller saknade teckensnitt.

**Finns det några begränsningar för hur många bilder som kan bearbetas?**

Aspose.Slides i sig har inga strikta begränsningar för antalet bilder du kan bearbeta. Du kan dock stöta på minnesbrist‑fel när du arbetar med stora presentationer eller högupplösta bilder.

## **Se även**

Se andra alternativ för att konvertera PPT/PPTX till bild, t.ex.:

- [PPT/PPTX to SVG conversion](/slides/sv/java/render-a-slide-as-an-svg-image/)