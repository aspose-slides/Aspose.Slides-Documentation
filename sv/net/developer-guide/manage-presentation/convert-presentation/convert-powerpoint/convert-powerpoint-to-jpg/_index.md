---
title: Konvertera PPT och PPTX till JPG i .NET
linktitle: PowerPoint till JPG
type: docs
weight: 60
url: /sv/net/convert-powerpoint-to-jpg/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertera PowerPoint (PPT, PPTX)-bilder till högkvalitativa JPG-bilder i C# med Aspose.Slides för .NET med snabba, pålitliga kodexempel."
---
## **Introduktion**

Att konvertera PowerPoint- och OpenDocument-presentationer till JPG-bilder hjälper till att dela bilder, optimera prestanda och bädda in innehåll i webbplatser eller applikationer. Aspose.Slides för .NET låter dig omvandla PPTX-, PPT- och ODP-filer till högkvalitativa JPEG-bilder. Denna guide förklarar olika metoder för konvertering.

Med dessa funktioner är det enkelt att implementera din egen presentationsvisare och skapa en miniatyrbild för varje bild. Detta kan vara användbart om du vill skydda presentationsbilder från kopiering eller visa presentationen i skrivskyddat läge. Aspose.Slides låter dig konvertera hela presentationen eller en specifik bild till bildformat.

## **Konvertera presentationsbilder till JPG-bilder**

Här är stegen för att konvertera en PPT-, PPTX- eller ODP-fil till JPG:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Hämta bildobjektet av typen [ISlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide) från samlingen [Presentation.Slides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/properties/slides).
1. Skapa en bild av bilden med metoden [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/getimage/#getimage_5).
1. Anropa metoden [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/save/#save_3) på bildobjektet. Skicka med utskriftsfilens namn och bildformat som argument.

{{% alert color="info" %}} 
**Obs:** PPT, PPTX eller ODP till JPG-konvertering skiljer sig från konvertering till andra format i Aspose.Slides .NET API. För andra format använder du vanligtvis metoden [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/save/#save_5). För JPG-konvertering måste du dock använda metoden [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/save/#save_3).
{{% /alert %}} 

```c#
using Aspose.Slides;

int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Skapa en bild av sliden med angiven skala.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Spara bilden till disk i JPEG-format.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Konvertera bilder till JPG med anpassade dimensioner**

För att ändra dimensionerna på de resulterande JPG-bilderna kan du ange bildstorleken genom att skicka in den i metoden [ISlide.GetImage(Size)](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/getimage/#getimage_6). Detta låter dig generera bilder med specifika bredd- och höjdvärden, vilket säkerställer att utdata uppfyller dina krav på upplösning och bildförhållande. Denna flexibilitet är särskilt användbar när du genererar bilder för webbapplikationer, rapporter eller dokumentation, där exakt bilddimension är nödvändig.

```c#
using System.Drawing;
using Aspose.Slides;

Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Skapa en bild av sliden med angiven storlek.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Spara bilden till disk i JPEG-format.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Rendera kommentarer när du sparar bilder som bilder**

Aspose.Slides för .NET erbjuder en funktion som låter dig rendera kommentarer på ett presentations bildspel när du konverterar dem till JPG-bilder. Denna funktion är särskilt användbar för att bevara anteckningar, återkoppling eller diskussioner som lagts till av medarbetare i PowerPoint-presentationer. Genom att aktivera detta alternativ säkerställer du att kommentarer syns i de genererade bilderna, vilket gör det enklare att granska och dela återkoppling utan att behöva öppna den ursprungliga presentationsfilen.

Anta att vi har en presentationsfil, "sample.pptx", med en bild som innehåller kommentarer:

![Bilden med kommentarer](slide_with_comments.png)

Följande C#-kod konverterar bilden till en JPG-bild samtidigt som kommentarerna bevaras:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // Använd alternativ för bildkommentarerna.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // Konvertera den första sliden till en bild.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

Resultatet:

![JPG-bilden med kommentarer](image_with_comments.png)

## **Se även**

Se andra alternativ för att konvertera PPT, PPTX eller ODP till bilder, till exempel:

- [Konvertera PowerPoint till GIF](/slides/sv/net/convert-powerpoint-to-animated-gif/)
- [Konvertera PowerPoint till PNG](/slides/sv/net/convert-powerpoint-to-png/)
- [Konvertera PowerPoint till TIFF](/slides/sv/net/convert-powerpoint-to-tiff/)
- [Konvertera PowerPoint till SVG](/slides/sv/net/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
För att se hur Aspose.Slides konverterar PowerPoint till JPG-bilder, prova dessa gratis online-omvandlare: PowerPoint [PPTX till JPG](https://products.aspose.app/slides/sv/conversion/pptx-to-jpg) och [PPT till JPG](https://products.aspose.app/slides/sv/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Gratis online PPTX till JPG-konverterare](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose tillhandahåller en [GRATIS Collage-webbapp](https://products.aspose.app/slides/sv/collage). Med denna onlinetjänst kan du slå samman [JPG till JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG till PNG-bilder, skapa [fotogallerier](https://products.aspose.app/slides/sv/collage/photo-grid), osv. 

Genom att använda samma principer som beskrivs i den här artikeln kan du konvertera bilder från ett format till ett annat. För mer information, se dessa sidor: konvertera [bild till JPG](https://products.aspose.com/slides/sv/net/conversion/image-to-jpg/); konvertera [JPG till bild](https://products.aspose.com/slides/sv/net/conversion/jpg-to-image/); konvertera [JPG till PNG](https://products.aspose.com/slides/sv/net/conversion/jpg-to-png/); konvertera [PNG till JPG](https://products.aspose.com/slides/sv/net/conversion/png-to-jpg/); konvertera [PNG till SVG](https://products.aspose.com/slides/sv/net/conversion/png-to-svg/); konvertera [SVG till PNG](https://products.aspose.com/slides/sv/net/conversion/svg-to-png/).

{{% /alert %}}

## **Vanliga frågor**

### Stöder den här metoden batchkonvertering?

Ja, Aspose.Slides möjliggör batchkonvertering av flera bilder till JPG i en enda operation.

### Stöder konverteringen SmartArt, diagram och andra komplexa objekt?

Ja, Aspose.Slides renderar allt innehåll, inklusive SmartArt, diagram, tabeller, former och mer. Noggrannheten i rendering kan dock variera något jämfört med PowerPoint, särskilt när du använder anpassade eller saknade teckensnitt.

### Finns det några begränsningar för antalet bilder som kan bearbetas?

Aspose.Slides i sig begränsar inte strikt antalet bilder du kan bearbeta. Du kan dock stöta på minnesbristfel när du arbetar med stora presentationer eller högupplösta bilder.