---
title: Konvertera PPT och PPTX till JPG i C++
linktitle: PowerPoint till JPG
type: docs
weight: 60
url: /sv/cpp/convert-powerpoint-to-jpg/
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
- C++
- Aspose.Slides
description: "Konvertera PowerPoint (PPT, PPTX)-bilder till högkvalitativa JPG-bilder i C++ med Aspose.Slides med hjälp av snabba, pålitliga kodexempel."
---
## **Introduktion**

Att konvertera PowerPoint‑ och OpenDocument‑presentationer till JPG‑bilder hjälper till att dela bilder, optimera prestanda och bädda in innehåll i webbplatser eller applikationer. Aspose.Slides för C++ låter dig omvandla PPTX‑, PPT‑ och ODP‑filer till högkvalitativa JPEG‑bilder. Denna guide förklarar olika metoder för konvertering.

Med dessa funktioner är det enkelt att implementera en egen presentationsvisare och skapa en miniatyr för varje bild. Detta kan vara användbart om du vill skydda presentationsbilder från kopiering eller demonstrera presentationen i skrivskyddat läge. Aspose.Slides låter dig konvertera hela presentationen eller en specifik bild till bildformat.

## **Konvertera presentationsbilder till JPG‑bilder**

Här är stegen för att konvertera en PPT‑, PPTX‑ eller ODP‑fil till JPG:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) .
1. Hämta bildobjektet av typen [ISlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/) från presentationens bildsamling.
1. Skapa en bild av bilden med metoden [ISlide.GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/getimage/) .
1. Anropa metoden [IImage.Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/save/) på bildobjektet. Skicka med filnamnet för utdata och bildformatet som argument.

{{% alert color="primary" %}} 
**Obs:** PPT, PPTX eller ODP till JPG‑konvertering skiljer sig från konvertering till andra format i Aspose.Slides för C++‑API. För andra format använder du vanligtvis metoden [IPresentation.Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/save/) . Men för JPG‑konvertering måste du använda metoden [IImage.Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iimage/save/) .
{{% /alert %}} 

```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Skapa en bild av sliden med den angivna skalan.
    auto image = slide->GetImage(scaleX, scaleY);

    // Spara bilden på disk i JPEG-format.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Konvertera bilder till JPG med anpassade dimensioner**

För att ändra dimensionerna på de resulterande JPG‑bilderna kan du ställa in bildstorleken genom att skicka den till metoden [ISlide.GetImage(Size)](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) . Detta gör att du kan generera bilder med specifika bredd‑ och höjdvärden, vilket säkerställer att utdata uppfyller dina krav på upplösning och bildförhållande. Denna flexibilitet är särskilt användbar när du skapar bilder för webbapplikationer, rapporter eller dokumentation, där exakta bilddimensioner krävs.

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Skapa en bild av sliden med angiven storlek.
    auto image = slide->GetImage(imageSize);

    // Spara bilden på disk i JPEG-format.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Rendera kommentarer när du sparar bilder som bilder**

Aspose.Slides för C++ tillhandahåller en funktion som låter dig rendera kommentarer på presentationens bilder när du konverterar dem till JPG‑bilder. Denna funktion är särskilt användbar för att bevara anteckningar, återkoppling eller diskussioner som lagts till av medarbetare i PowerPoint‑presentationer. Genom att aktivera detta alternativ säkerställer du att kommentarer syns i de genererade bilderna, vilket gör det enklare att granska och dela återkoppling utan att öppna den ursprungliga presentationsfilen.

Låt oss säga att vi har en presentationsfil, "sample.pptx", med en bild som innehåller kommentarer:

![Bild med kommentarer](slide_with_comments.png)

Följande C++‑kod konverterar bilden till en JPG‑bild samtidigt som kommentarerna bevaras:

```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Ställ in alternativ för bildkommentarerna.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Konvertera den första bilden till en bild.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

Resultatet:

![JPG‑bild med kommentarer](image_with_comments.png)

## **Se även**

Se andra alternativ för att konvertera PPT, PPTX eller ODP till bilder, såsom:

- [Konvertera PowerPoint till GIF](/slides/sv/cpp/convert-powerpoint-to-animated-gif/)
- [Konvertera PowerPoint till PNG](/slides/sv/cpp/convert-powerpoint-to-png/)
- [Konvertera PowerPoint till TIFF](/slides/sv/cpp/convert-powerpoint-to-tiff/)
- [Konvertera PowerPoint till SVG](/slides/sv/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
För att se hur Aspose.Slides konverterar PowerPoint till JPG‑bilder, prova dessa gratis online‑konverterare: PowerPoint [PPTX till JPG](https://products.aspose.app/slides/sv/conversion/pptx-to-jpg) och [PPT till JPG](https://products.aspose.app/slides/sv/conversion/ppt-to-jpg) .
{{% /alert %}}

![Gratis online PPTX till JPG‑konverterare](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose tillhandahåller en [GRATIS Collage‑webbapp](https://products.aspose.app/slides/sv/collage). Med den här onlinetjänsten kan du slå ihop [JPG till JPG](https://products.aspose.app/slides/sv/collage/jpg) eller PNG till PNG‑bilder, skapa [fotogrid](https://products.aspose.app/slides/sv/collage/photo-grid) och så vidare.

Använd samma principer som beskrivs i den här artikeln för att konvertera bilder från ett format till ett annat. För mer information, se dessa sidor: konvertera [bild till JPG](https://products.aspose.com/slides/sv/cpp/conversion/image-to-jpg/) ; konvertera [JPG till bild](https://products.aspose.com/slides/sv/cpp/conversion/jpg-to-image/) ; konvertera [JPG till PNG](https://products.aspose.com/slides/sv/cpp/conversion/jpg-to-png/) , konvertera [PNG till JPG](https://products.aspose.com/slides/sv/cpp/conversion/png-to-jpg/) ; konvertera [PNG till SVG](https://products.aspose.com/slides/sv/cpp/conversion/png-to-svg/) , konvertera [SVG till PNG](https://products.aspose.com/slides/sv/cpp/conversion/svg-to-png/) .
{{% /alert %}}

## **FAQ**

**Stöder den här metoden batch‑konvertering?**

Ja, Aspose.Slides möjliggör batch‑konvertering av flera bilder till JPG i en enda operation.

**Stöder konverteringen SmartArt, diagram och andra komplexa objekt?**

Ja, Aspose.Slides renderar allt innehåll, inklusive SmartArt, diagram, tabeller, former och mer. Dock kan renderingsnoggrannheten variera något jämfört med PowerPoint, särskilt vid användning av anpassade eller saknade typsnitt.

**Finns det några begränsningar för hur många bilder som kan bearbetas?**

Aspose.Slides själv pålägger inga strikt begränsningar för antalet bilder du kan bearbeta. Du kan dock stöta på minnesbrist‑fel när du arbetar med stora presentationer eller högupplösta bilder.