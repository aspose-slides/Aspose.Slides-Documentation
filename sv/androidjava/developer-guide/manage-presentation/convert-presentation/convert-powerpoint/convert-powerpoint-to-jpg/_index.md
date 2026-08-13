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
description: "Konvertera PowerPoint (PPT, PPTX) bilder till högkvalitativa JPG‑bilder i Java med Aspose.Slides för Android med snabba, pålitliga kodexempel."
---
## **Introduktion**

Att konvertera PowerPoint- och OpenDocument-presentationer till JPG-bilder underlättar delning av bildspel, optimering av prestanda och inbäddning av innehåll i webbplatser eller applikationer. Aspose.Slides för Android via Java låter dig omvandla PPTX-, PPT- och ODP-filer till högkvalitativa JPEG-bilder. Den här guiden förklarar olika metoder för konvertering.

Med dessa funktioner är det enkelt att implementera din egen presentationsvisare och skapa en miniatyr för varje bild. Detta kan vara användbart om du vill skydda presentationsbilder från kopiering eller visa presentationen i skrivskyddat läge. Aspose.Slides låter dig konvertera hela presentationen eller en specifik bild till bildformat.

## **Konvertera presentationsbilder till JPG-bilder**

Här är stegen för att konvertera en PPT-, PPTX- eller ODP-fil till JPG:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta bildobjektet av typen [ISlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/) från samlingen som returneras av metoden [Presentation.getSlides()](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSlides--) .
1. Skapa en bild av bilden med hjälp av metoden [ISlide.getImage(float, float)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/#getImage-float-float-).
1. Anropa metoden [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) på bildobjektet. Skicka med utdatafilens namn och bildformat som argument.

{{% alert color="info" %}} 
**Obs:** PPT-, PPTX- eller ODP‑till‑JPG‑konvertering skiljer sig från konvertering till andra format i Aspose.Slides Android via Java‑API. För andra format använder du normalt metoden [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-). Men för JPG‑konvertering måste du använda metoden [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).
{{% /alert %}} 

```java
import com.aspose.slides.*;

int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Skapa en bild av bilden i angiven skala.
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

## **Konvertera bilder till JPG med anpassade dimensioner**

För att ändra dimensionerna på de resulterande JPG-bilderna kan du ställa in bildstorleken genom att skicka in den i metoden [ISlide.getImage(Size)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-). Detta gör det möjligt att skapa bilder med specifika bredd- och höjdvärden, vilket säkerställer att resultatet uppfyller dina krav på upplösning och bildförhållande. Denna flexibilitet är särskilt användbar vid generering av bilder för webbapplikationer, rapporter eller dokumentation, där exakta bilddimensioner krävs.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Skapa en bild av sliden i angiven storlek.
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

## **Rendera kommentarer vid sparande av bilder**

Aspose.Slides för Android via Java erbjuder en funktion som låter dig rendera kommentarer på en presentations bilder när du konverterar dem till JPG‑bilder. Denna funktion är särskilt användbar för att bevara anteckningar, återkoppling eller diskussioner som lagts till av samarbetspartners i PowerPoint‑presentationer. Genom att aktivera detta alternativ säkerställer du att kommentarer syns i de genererade bilderna, vilket gör det enklare att granska och dela återkoppling utan att behöva öppna originalfilen.

Låt oss säga att vi har en presentationsfil, "sample.pptx", med en bild som innehåller kommentarer:

![Bilden med kommentarer](slide_with_comments.png)

Följande Java‑kod konverterar bilden till en JPG‑bild samtidigt som kommentarer bevaras:

```java
import com.aspose.slides.*;
import java.awt.Color;

int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(new Color(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // Konvertera den första bilden till en bild.
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

## **Se även**

Se andra alternativ för att konvertera PPT, PPTX eller ODP till bilder, till exempel:

- [Konvertera PowerPoint till GIF](/slides/sv/androidjava/convert-powerpoint-to-animated-gif/)
- [Konvertera PowerPoint till PNG](/slides/sv/androidjava/convert-powerpoint-to-png/)
- [Konvertera PowerPoint till TIFF](/slides/sv/androidjava/convert-powerpoint-to-tiff/)
- [Konvertera PowerPoint till SVG](/slides/sv/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
För att se hur Aspose.Slides konverterar PowerPoint-presentationer till JPG‑bilder, prova dessa kostnadsfria online‑konverterare: PowerPoint [PPTX till JPG](https://products.aspose.app/slides/sv/conversion/pptx-to-jpg) och [PPT till JPG](https://products.aspose.app/slides/sv/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Gratis online PPTX till JPG‑konverterare](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose tillhandahåller en [GRATIS Collage‑webbapp](https://products.aspose.app/slides/sv/collage). Med den här onlinetjänsten kan du sammanslå [JPG till JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG till PNG‑bilder, skapa [fotogrid‑layouter](https://products.aspose.app/slides/sv/collage/photo-grid) och så vidare. 

Genom att använda samma principer som beskrivs i den här artikeln kan du konvertera bilder från ett format till ett annat. För mer information, se dessa sidor: konvertera [bild till JPG](https://products.aspose.com/slides/sv/java/conversion/image-to-jpg/); konvertera [JPG till bild](https://products.aspose.com/slides/sv/java/conversion/jpg-to-image/); konvertera [JPG till PNG](https://products.aspose.com/slides/sv/java/conversion/jpg-to-png/); konvertera [PNG till JPG](https://products.aspose.com/slides/sv/java/conversion/png-to-jpg/); konvertera [PNG till SVG](https://products.aspose.com/slides/sv/java/conversion/png-to-svg/), konvertera [SVG till PNG](https://products.aspose.com/slides/sv/java/conversion/svg-to-png/).
{{% /alert %}}

## **Vanliga frågor**

### Stöder den här metoden batch‑konvertering?

Ja, Aspose.Slides möjliggör batch‑konvertering av flera bilder till JPG i en enda operation.

### Stöder konverteringen SmartArt, diagram och andra komplexa objekt?

Ja, Aspose.Slides renderar allt innehåll, inklusive SmartArt, diagram, tabeller, former och mer. Renderingens noggrannhet kan dock variera något jämfört med PowerPoint, särskilt när anpassade eller saknade teckensnitt används.

### Finns det några begränsningar för antalet bilder som kan bearbetas?

Aspose.Slides i sig inför inga strikta begränsningar för hur många bilder du kan bearbeta. Du kan dock få ett out‑of‑memory‑fel när du arbetar med stora presentationer eller högupplösta bilder.