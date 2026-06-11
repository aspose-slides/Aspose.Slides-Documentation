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
description: "Konvertera PowerPoint (PPT, PPTX) bilder till högkvalitativa JPG-bilder i C# med Aspose.Slides för .NET med hjälp av snabba, pålitliga kodexempel."
---
## **Introduktion**

Att konvertera PowerPoint- och OpenDocument-presentationer till JPG-bilder underlättar delning av bilder, optimerar prestanda och inbäddning av innehåll i webbplatser eller applikationer. Aspose.Slides för .NET låter dig omvandla PPTX-, PPT- och ODP-filer till högkvalitativa JPEG‑bilder. Denna guide förklarar olika metoder för konvertering.

Med dessa funktioner är det enkelt att implementera din egen presentationsvisare och skapa en miniatyrbild för varje bild. Detta kan vara användbart om du vill skydda presentationsbilder från kopiering eller visa presentationen i skrivskyddat läge. Aspose.Slides låter dig konvertera hela presentationen eller en specifik bild till bildformat.

## **Konvertera presentationsbilder till JPG‑bilder**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) .
1. Hämta bildobjektet av typen [ISlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide) från samlingen [Presentation.Slides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/properties/slides) .
1. Skapa en bild av bilden med metoden [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/getimage/#getimage_5) .
1. Anropa metoden [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/save/#save_3) på bildobjektet. Skicka med utskriftsfilnamnet och bildformatet som argument.

{{% alert color="primary" %}} 

**Note:** PPT, PPTX eller ODP till JPG‑konvertering skiljer sig från konvertering till andra format i Aspose.Slides .NET‑API:et. För andra format använder du vanligtvis metoden [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/save/#save_5) . Men för JPG‑konvertering måste du använda metoden [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/sv/net/aspose.slides/iimage/save/#save_3) .

{{% /alert %}} 

```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Skapa en bild av bilden i angiven skala.
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

För att ändra dimensionerna på de resulterande JPG‑bilderna kan du ange bildstorleken genom att skicka den till metoden [ISlide.GetImage(Size)](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/getimage/#getimage_6) . Detta gör att du kan generera bilder med specifika bredd‑ och höjdlägen, vilket säkerställer att resultatet uppfyller dina krav på upplösning och bildförhållande. Denna flexibilitet är särskilt användbar vid generering av bilder för webbapplikationer, rapporter eller dokumentation, där exakta bilddimensioner krävs.

```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Skapa en bild av bilden med den angivna storleken.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Spara bilden till disk i JPEG-format.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Rendera kommentarer när du sparar bilder som JPEG‑bilder**

Aspose.Slides för .NET erbjuder en funktion som låter dig rendera kommentarer på en presentations bilder när du konverterar dem till JPG‑bilder. Denna funktionalitet är särskilt användbar för att bevara annotationer, återkoppling eller diskussioner som lagts till av samarbetspartners i PowerPoint‑presentationer. Genom att aktivera detta alternativ säkerställer du att kommentarer syns i de genererade bilderna, vilket gör det enklare att granska och dela återkoppling utan att öppna den ursprungliga presentationsfilen.

Anta att vi har en presentationsfil, "sample.pptx", med en bild som innehåller kommentarer:

![Bilden med kommentarer](slide_with_comments.png)

Följande C#‑kod konverterar bilden till en JPG‑bild samtidigt som kommentarerna bevaras:

```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // Ställ in alternativ för bildkommentarerna.
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

![JPG‑bilden med kommentarer](image_with_comments.png)

## **Se även**

Se andra alternativ för att konvertera PPT, PPTX eller ODP till bilder, till exempel:

- [Konvertera PowerPoint till GIF](/slides/sv/net/convert-powerpoint-to-animated-gif/)
- [Konvertera PowerPoint till PNG](/slides/sv/net/convert-powerpoint-to-png/)
- [Konvertera PowerPoint till TIFF](/slides/sv/net/convert-powerpoint-to-tiff/)
- [Konvertera PowerPoint till SVG](/slides/sv/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

För att se hur Aspose.Slides konverterar PowerPoint till JPG‑bilder, prova dessa kostnadsfria online‑konverterare: PowerPoint [PPTX till JPG](https://products.aspose.app/slides/sv/conversion/pptx-to-jpg) och [PPT till JPG](https://products.aspose.app/slides/sv/conversion/ppt-to-jpg) . 

{{% /alert %}} 

![Gratis online PPTX‑till‑JPG‑konverterare](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose tillhandahåller en [GRATIS Collage‑webbapp](https://products.aspose.app/slides/sv/collage). Med den här onlinetjänsten kan du slå ihop [JPG till JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG till PNG‑bilder, skapa [fotogrids](https://products.aspose.app/slides/sv/collage/photo-grid), och så vidare. 

Genom att använda samma principer som beskrivs i den här artikeln kan du konvertera bilder från ett format till ett annat. För mer information, se dessa sidor: konvertera [bild till JPG](https://products.aspose.com/slides/sv/net/conversion/image-to-jpg/) ; konvertera [JPG till bild](https://products.aspose.com/slides/sv/net/conversion/jpg-to-image/) ; konvertera [JPG till PNG](https://products.aspose.com/slides/sv/net/conversion/jpg-to-png/), konvertera [PNG till JPG](https://products.aspose.com/slides/sv/net/conversion/png-to-jpg/) ; konvertera [PNG till SVG](https://products.aspose.com/slides/sv/net/conversion/png-to-svg/), konvertera [SVG till PNG](https://products.aspose.com/slides/sv/net/conversion/svg-to-png/) .

{{% /alert %}}

## **FAQ**

**Stöder den här metoden batchkonvertering?**

Ja, Aspose.Slides möjliggör batchkonvertering av flera bilder till JPG i en enda operation.

**Stöder konverteringen SmartArt, diagram och andra komplexa objekt?**

Ja, Aspose.Slides renderar allt innehåll, inklusive SmartArt, diagram, tabeller, former och mer. Renderingens exakthet kan dock variera något jämfört med PowerPoint, särskilt när anpassade eller saknade typsnitt används.

**Finns det några begränsningar för hur många bilder som kan bearbetas?**

Aspose.Slides i sig har inga strikta begränsningar för hur många bilder du kan bearbeta. Du kan dock stöta på minnesbrist‑fel när du arbetar med stora presentationer eller högupplösta bilder.