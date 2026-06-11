---
title: Konvertera PPT och PPTX till JPG i JavaScript
linktitle: PowerPoint till JPG
type: docs
weight: 60
url: /sv/nodejs-java/convert-powerpoint-to-jpg/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertera PowerPoint (PPT, PPTX) bilder till högkvalitativa JPG-bilder i JavaScript med Aspose.Slides för Node.js via Java med snabba, pålitliga kodexempel."
---
## **Introduktion**

Att konvertera PowerPoint- och OpenDocument-presentationer till JPG‑bilder underlättar delning av bildspel, optimering av prestanda och inbäddning av innehåll i webbplatser eller applikationer. Aspose.Slides låter dig omvandla PPTX-, PPT- och ODP‑filer till högkvalitativa JPEG‑bilder. Denna guide förklarar olika metoder för konvertering.

Med dessa funktioner är det enkelt att implementera din egen presentationsvisare och skapa en miniatyrbild för varje bild. Detta kan vara användbart om du vill skydda presentationsbilder från kopiering eller demonstrera presentationen i skrivskyddat läge. Aspose.Slides låter dig konvertera hela presentationen eller en specifik bild till bildformat.

## **Konvertera PowerPoint PPT/PPTX till JPG**
Här är stegen för att konvertera PPT/PPTX till JPG:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) typen.
2. Hämta bildobjektet av typ [Slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Slide) från samlingen [Presentation.getSlides()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--) .
3. Skapa en miniatyrbild av varje bild och konvertera den sedan till JPG. Metoden [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Slide#getImage-float-float-) används för att hämta en miniatyrbild av en bild, den returnerar ett [Imagess](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Images)‑objekt som resultat. Metoden [getImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) måste anropas från den önskade bilden av typen [Slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Slide), skalförhållandena för den resulterande miniatyrbilden skickas in i metoden.
4. När du har fått bildens miniatyr, anropa metoden [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/#save) från miniatyrobjektet. Skicka med det resulterande filnamnet och bildformatet som argument.

{{% alert color="primary" %}}

**Obs!**: PPT/PPTX‑till‑JPG‑konvertering skiljer sig från konvertering till andra typer i Aspose.Slides‑API. För andra typer använder du vanligtvis metoden [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) , men här behöver du metoden [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/#save) .

{{% /alert %}} 

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Skapar en fullskalig bild
        var slideImage = sld.getImage(1.0, 1.0);
        // Sparar bilden till disk i JPEG-format
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konvertera PowerPoint PPT/PPTX till JPG med anpassade dimensioner**
För att ändra dimensionerna på den resulterande miniatyrbilden och JPG‑bilden kan du ange *ScaleX*- och *ScaleY*-värdena genom att skicka dem till metoderna [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Slide#getImage-float-float-) :

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // Definierar dimensioner
    var desiredX = 1200;
    var desiredY = 800;
    // Hämtar skalade värden för X och Y
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Skapar en fullskalig bild
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // Sparar bilden till disk i JPEG-format
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rendera kommentarer vid sparande av presentation som bild**
Aspose.Slides för Node.js via Java erbjuder en funktion som låter dig rendera kommentarer i en presentationsbilder när du konverterar dessa bilder till bilder. Denna JavaScript‑kod demonstrerar operationen:

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}

Aspose tillhandahåller en [GRATIS Collage‑webbapp](https://products.aspose.app/slides/sv/collage). Med den här onlinetjänsten kan du slå ihop [JPG till JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG till PNG‑bilder, skapa [fotogallerier](https://products.aspose.app/slides/sv/collage/photo-grid) och så vidare. 

{{% /alert %}}

## **Se också**

Se andra alternativ för att konvertera PPT/PPTX till bild, t.ex.:

- [PPT/PPTX till SVG‑konvertering](/slides/sv/nodejs-java/render-a-slide-as-an-svg-image/).

## **Vanliga frågor**

**Stöder den här metoden batch‑konvertering?**

Ja, Aspose.Slides möjliggör batch‑konvertering av flera bilder till JPG i en enda operation.

**Stöder konverteringen SmartArt, diagram och andra komplexa objekt?**

Ja, Aspose.Slides renderar allt innehåll, inklusive SmartArt, diagram, tabeller, former och mer. Renderingens noggrannhet kan dock variera något jämfört med PowerPoint, särskilt vid användning av anpassade eller saknade typsnitt.

**Finns det några begränsningar för antalet bilder som kan bearbetas?**

Aspose.Slides i sig själva har inga strikta begränsningar för hur många bilder du kan bearbeta. Du kan dock stöta på minnesbrist‑fel när du arbetar med stora presentationer eller högupplösta bilder.