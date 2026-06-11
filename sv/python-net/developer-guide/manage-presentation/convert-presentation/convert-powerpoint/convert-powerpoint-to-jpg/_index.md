---
title: Konvertera PPT, PPTX och ODP till JPG i Python
linktitle: Konvertera bildspel till JPG‑bilder
type: docs
weight: 60
url: /sv/python-net/convert-powerpoint-to-jpg/
keywords:
- konvertera PowerPoint till JPG
- konvertera presentation till JPG
- konvertera bild till JPG
- konvertera PPT till JPG
- konvertera PPTX till JPG
- konvertera ODP till JPG
- PowerPoint till JPG
- presentation till JPG
- bild till JPG
- PPT till JPG
- PPTX till JPG
- ODP till JPG
- konvertera PowerPoint till JPEG
- konvertera presentation till JPEG
- konvertera bild till JPEG
- konvertera PPT till JPEG
- konvertera PPTX till JPEG
- konvertera ODP till JPEG
- PowerPoint till JPEG
- presentation till JPEG
- bild till JPEG
- PPT till JPEG
- PPTX till JPEG
- ODP till JPEG
- Python
- Aspose.Slides
description: "Lär dig hur du omvandlar dina bilder från PowerPoint- och OpenDocument-presentationer till högkvalitativa JPEG‑bilder med bara några få kodrader i Python. Optimera presentationer för webbbruk, delning och arkivering. Läs hela guiden nu!"
---
## **Introduktion**

Att konvertera PowerPoint- och OpenDocument-presentationer till JPG-bilder hjälper till att dela bilder, optimera prestanda och bädda in innehåll i webbplatser eller applikationer. Aspose.Slides för Python låter dig omvandla PPTX-, PPT- och ODP-filer till högkvalitativa JPEG-bilder. Den här guiden förklarar olika metoder för konvertering.

Med dessa funktioner är det enkelt att implementera din egen presentationsvisare och skapa en miniatyr för varje bild. Detta kan vara användbart om du vill skydda presentationsbilder från kopiering eller demonstrera presentationen i skrivskyddat läge. Aspose.Slides låter dig konvertera hela presentationen eller en specifik bild till bildformat.

## **Konvertera presentationsbilder till JPG-bilder**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
1. Hämta bildobjektet av typen [Slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/) från samlingen [Presentation.slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/slides/sv/) .
1. Skapa en bild av bilden med hjälp av metoden [Slide.get_image(scale_x, scale_y)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/#float-float) .
1. Anropa metoden [IImage.save(filename, format)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/save/#str-imageformat) på bildobjektet. Ange filnamnet för utdata och bildformatet som argument.

{{% alert color="primary" %}}

**Obs:** Konvertering från PPT, PPTX eller ODP till JPG skiljer sig från konvertering till andra format i Aspose.Slides Python‑API. För andra format använder du vanligtvis metoden [Presentation.save(fname, format, options)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions). För JPG‑konvertering måste du dock använda metoden [IImage.save(filename, format)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/save/#str-imageformat) .

{{% /alert %}}

```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # Spara bilden till disk i JPEG-format.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **Konvertera bilder till JPG med anpassade dimensioner**

För att ändra dimensionerna på de resulterande JPG-bilderna kan du ange bildstorleken genom att skicka in den till metoden [Slide.get_image(image_size)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/get_image/#asposepydrawingsize). Detta gör att du kan generera bilder med specifika bredd- och höjdvärden, vilket säkerställer att utdata uppfyller dina krav på upplösning och bildförhållande. Denna flexibilitet är särskilt användbar när du genererar bilder för webbapplikationer, rapporter eller dokumentation, där exakta bilddimensioner krävs.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # Skapa en bild av bilden med den angivna storleken.
        with slide.get_image(image_size) as thumbnail:
            # Spara bilden till disk i JPEG-format.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **Rendera kommentarer vid sparande av bilder som bilder**

Aspose.Slides för Python erbjuder en funktion som låter dig rendera kommentarer på ett presentations bildspel när du konverterar dem till JPG-bilder. Denna funktion är särskilt användbar för att bevara annotationer, återkoppling eller diskussioner som lagts till av medarbetare i PowerPoint-presentationer. Genom att aktivera detta alternativ säkerställer du att kommentarer är synliga i de genererade bilderna, vilket gör det enklare att granska och dela återkoppling utan att behöva öppna originalfilen.

Anta att vi har en presentationsfil, "sample.pptx", med en bild som innehåller kommentarer:

![Bilden med kommentarer](slide_with_comments.png)

Följande Python‑kod konverterar bilden till en JPG‑bild samtidigt som kommentarerna bevaras:

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # Ange alternativ för bildkommentarerna.
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # Konvertera den första sliden till en bild.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```

Resultatet:

![JPG‑bilden med kommentarer](image_with_comments.png)

## **Se även**

- [Konvertera PowerPoint till GIF](/slides/sv/python-net/convert-powerpoint-to-animated-gif/)
- [Konvertera PowerPoint till PNG](/slides/sv/python-net/convert-powerpoint-to-png/)
- [Konvertera PowerPoint till TIFF](/slides/sv/python-net/convert-powerpoint-to-tiff/)
- [Konvertera PowerPoint till SVG](/slides/sv/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

För att se hur Aspose.Slides konverterar PowerPoint till JPG‑bilder, prova dessa gratis online‑konverterare: PowerPoint [PPTX till JPG](https://products.aspose.app/slides/sv/conversion/pptx-to-jpg) och [PPT till JPG](https://products.aspose.app/slides/sv/conversion/ppt-to-jpg) . 

{{% /alert %}} 

![Gratis online‑verktyg för PPTX till JPG‑konvertering](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose tillhandahåller en [GRATIS Collage‑webbapp](https://products.aspose.app/slides/sv/collage). Med den här onlinetjänsten kan du slå ihop [JPG till JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG till PNG‑bilder, skapa [fotogallerier](https://products.aspose.app/slides/sv/collage/photo-grid) och så vidare. 

Genom att använda samma principer som beskrivs i den här artikeln kan du konvertera bilder från ett format till ett annat. För mer information, se dessa sidor: konvertera [bild till JPG](https://products.aspose.com/slides/sv/python-net/conversion/image-to-jpg/); konvertera [JPG till bild](https://products.aspose.com/slides/sv/python-net/conversion/jpg-to-image/); konvertera [JPG till PNG](https://products.aspose.com/slides/sv/python-net/conversion/jpg-to-png/), konvertera [PNG till JPG](https://products.aspose.com/slides/sv/python-net/conversion/png-to-jpg/); konvertera [PNG till SVG](https://products.aspose.com/slides/sv/python-net/conversion/png-to-svg/), konvertera [SVG till PNG](https://products.aspose.com/slides/sv/python-net/conversion/svg-to-png/) .

{{% /alert %}}

## **FAQ**

**Stöder den här metoden batch‑konvertering?**

Ja, Aspose.Slides möjliggör batch‑konvertering av flera bilder till JPG i en enda operation.

**Stöder konverteringen SmartArt, diagram och andra komplexa objekt?**

Ja, Aspose.Slides renderar allt innehåll, inklusive SmartArt, diagram, tabeller, former och mer. Renderingsnoggrannheten kan dock variera något jämfört med PowerPoint, särskilt vid användning av anpassade eller saknade typsnitt.

**Finns det några begränsningar för antalet bilder som kan bearbetas?**

Aspose.Slides har i sig inga strikta begränsningar för hur många bilder du kan bearbeta. Däremot kan du stöta på minnesbrist‑fel när du arbetar med stora presentationer eller högupplösta bilder.