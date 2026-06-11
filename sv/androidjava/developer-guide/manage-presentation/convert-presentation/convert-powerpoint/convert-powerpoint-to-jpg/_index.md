---
title: Konvertera PPT och PPTX till JPG på Android
linktitle: PowerPoint till JPG
type: docs
weight: 60
url: /sv/androidjava/convert-powerpoint-to-jpg/
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
- Android
- Java
- Aspose.Slides
description: "Konvertera PowerPoint (PPT, PPTX)-bilder till högkvalitativa JPG-bilder i Java med Aspose.Slides för Android med snabba, pålitliga kodexempel."
---
## **Introduktion**

Att konvertera PowerPoint- och OpenDocument-presentationer till JPG-bilder hjälper till med att dela bilder, optimera prestanda och bädda in innehåll i webbplatser eller applikationer. Aspose.Slides för Android via Java låter dig omvandla PPTX-, PPT- och ODP-filer till JPEG-bilder av hög kvalitet. Denna guide förklarar olika metoder för konvertering.

Med dessa funktioner är det enkelt att implementera din egen presentationsvisare och skapa en miniatyrbild för varje slide. Detta kan vara användbart om du vill skydda presentationsbilder från kopiering eller demonstrera presentationen i skrivskyddat läge. Aspose.Slides låter dig konvertera hela presentationen eller en specifik slide till bildformat.

## **Konvertera presentationsbilder till JPG-bilder**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta slide‑objektet av typen [ISlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/) från samlingen som returneras av metoden [Presentation.getSlides()](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSlides--).
1. Skapa en bild av sliden med hjälp av metoden [ISlide.getImage(float, float)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/#getImage-float-float-).
1. Anropa metoden [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) på bildobjektet. Skicka med utskriftsfilnamnet och bildformatet som argument.

{{% alert color="primary" %}} 
**Obs:** PPT-, PPTX- eller ODP‑till‑JPG‑konvertering skiljer sig från konvertering till andra format i Aspose.Slides Android via Java‑API. För andra format använder du vanligtvis metoden [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-). För JPG‑konvertering måste du dock använda metoden [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).
{{% /alert %}} 

```java
int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Skapa en bild av sliden med angiven skala.
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // Spara bilden till disk i JPEG-format.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Konvertera slides till JPG med anpassade dimensioner**

För att ändra dimensionerna på de resulterande JPG‑bilderna kan du ställa in bildstorleken genom att skicka in den i metoden [ISlide.getImage(Size)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-). Detta låter dig generera bilder med specifika bredd‑ och höjdvärden, vilket säkerställer att utskriften uppfyller dina krav på upplösning och bildförhållande. Denna flexibilitet är särskilt användbar när du genererar bilder för webbapplikationer, rapporter eller dokumentation där exakta bilddimensioner krävs.

```java
Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Skapa en bild av sliden med angiven storlek.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // Spara bilden till disk i JPEG-format.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Rendera kommentarer när du sparar slides som bilder**

Aspose.Slides för Android via Java erbjuder en funktion som låter dig rendera kommentarer på presentationens slides när de konverteras till JPG‑bilder. Denna funktionalitet är särskilt användbar för att bevara annoteringar, återkoppling eller diskussioner som lagts till av medarbetare i PowerPoint‑presentationer. Genom att aktivera detta alternativ säkerställer du att kommentarer är synliga i de genererade bilderna, vilket gör det enklare att granska och dela återkoppling utan att behöva öppna originalfilen.

Anta att vi har en presentationsfil, "sample.pptx", med en slide som innehåller kommentarer:

![Sliden med kommentarer](slide_with_comments.png)

Följande Java‑kod konverterar sliden till en JPG‑bild samtidigt som kommentarer bevaras:

```java
int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(Color.rgb(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // Konvertera den första sliden till en bild.
    IImage slideImage = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        slideImage.save("Slide_1.jpg", ImageFormat.Jpeg);
    } finally {
        slideImage.dispose();
    }
} finally {
    presentation.dispose();
}
```

Resultatet:

![JPG‑bilden med kommentarer](image_with_comments.png)

## **Se också**

Se andra alternativ för att konvertera PPT, PPTX eller ODP till bilder, såsom:

- [Konvertera PowerPoint till GIF](/slides/sv/androidjava/convert-powerpoint-to-animated-gif/)
- [Konvertera PowerPoint till PNG](/slides/sv/androidjava/convert-powerpoint-to-png/)
- [Konvertera PowerPoint till TIFF](/slides/sv/androidjava/convert-powerpoint-to-tiff/)
- [Konvertera PowerPoint till SVG](/slides/sv/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
För att se hur Aspose.Slides konverterar PowerPoint‑presentationer till JPG‑bilder, prova dessa gratis online‑konverterare: PowerPoint [PPTX till JPG](https://products.aspose.app/slides/sv/conversion/pptx-to-jpg) och [PPT till JPG](https://products.aspose.app/slides/sv/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Gratis online‑konverterare för PPTX till JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose tillhandahåller en [GRATIS Collage‑webbapp](https://products.aspose.app/slides/sv/collage). Med den här onlinetjänsten kan du slå ihop [JPG till JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG till PNG‑bilder, skapa [fotogrids](https://products.aspose.app/slides/sv/collage/photo-grid), och så vidare. 

Genom att använda samma principer som beskrivs i den här artikeln kan du konvertera bilder från ett format till ett annat. För mer information, se dessa sidor: konvertera [bild till JPG](https://products.aspose.com/slides/sv/java/conversion/image-to-jpg/); konvertera [JPG till bild](https://products.aspose.com/slides/sv/java/conversion/jpg-to-image/); konvertera [JPG till PNG](https://products.aspose.com/slides/sv/java/conversion/jpg-to-png/), konvertera [PNG till JPG](https://products.aspose.com/slides/sv/java/conversion/png-to-jpg/); konvertera [PNG till SVG](https://products.aspose.com/slides/sv/java/conversion/png-to-svg/), konvertera [SVG till PNG](https://products.aspose.com/slides/sv/java/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Stöder den här metoden batch‑konvertering?**

Ja, Aspose.Slides möjliggör batch‑konvertering av flera slides till JPG i en enda operation.

**Stöder konverteringen SmartArt, diagram och andra komplexa objekt?**

Ja, Aspose.Slides renderar allt innehåll, inklusive SmartArt, diagram, tabeller, former och mer. Renderingsnoggrannheten kan dock variera något jämfört med PowerPoint, särskilt vid användning av anpassade eller saknade typsnitt.

**Finns det några begränsningar för antalet slides som kan bearbetas?**

Aspose.Slides i sig sätter inga strikta gränser för hur många slides du kan bearbeta. Du kan dock stöta på minnesbrist‑fel när du arbetar med stora presentationer eller bilder med hög upplösning.