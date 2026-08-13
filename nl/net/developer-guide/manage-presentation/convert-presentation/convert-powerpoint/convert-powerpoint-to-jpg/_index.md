---
title: PPT en PPTX naar JPG converteren in .NET
linktitle: PowerPoint naar JPG
type: docs
weight: 60
url: /nl/net/convert-powerpoint-to-jpg/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar JPG
- presentatie naar JPG
- dia naar JPG
- PPT naar JPG
- PPTX naar JPG
- PowerPoint opslaan als JPG
- presentatie opslaan als JPG
- dia opslaan als JPG
- PPT opslaan als JPG
- PPTX opslaan als JPG
- PPT exporteren naar JPG
- PPTX exporteren naar JPG
- .NET
- C#
- Aspose.Slides
description: "Converteer PowerPoint (PPT, PPTX) dia's naar hoogwaardige JPG-afbeeldingen in C# met Aspose.Slides voor .NET, met snelle en betrouwbare code-voorbeelden."
---
## **Introductie**

Het converteren van PowerPoint‑ en OpenDocument‑presentaties naar JPG‑afbeeldingen vergemakkelijkt het delen van dia’s, optimaliseert de prestaties en maakt het mogelijk om inhoud in websites of applicaties te embedden. Aspose.Slides for .NET stelt je in staat om PPTX‑, PPT‑ en ODP‑bestanden om te zetten naar hoogwaardige JPEG‑afbeeldingen. Deze gids legt de verschillende conversiemethoden uit.

Met deze functionaliteit kun je eenvoudig je eigen presentatieweergave implementeren en een miniatuur voor elke dia maken. Dit kan handig zijn wanneer je presentatiedia’s wilt beschermen tegen kopiëren of de presentatie wilt tonen in alleen‑lezen‑modus. Aspose.Slides maakt het mogelijk om de gehele presentatie of een specifieke dia naar een afbeelding te converteren.

## **Convert Presentation Slides to JPG Images**

Hier volgen de stappen om een PPT‑, PPTX‑ of ODP‑bestand naar JPG te converteren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
1. Haal het dia‑object van het type [ISlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide) op uit de [Presentation.Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/properties/slides)‑collectie.
1. Maak een afbeelding van de dia met de [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/#getimage_5)‑methode.
1. Roep de [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/save/#save_3)‑methode aan op het afbeeldingsobject. Geef de naam van het uitvoerbestand en het afbeeldingsformaat als argumenten.

{{% alert color="info" %}} 

**Opmerking:** De conversie van PPT, PPTX of ODP naar JPG verschilt van conversie naar andere formaten in de Aspose.Slides .NET‑API. Voor andere formaten gebruik je doorgaans de [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/save/#save_5)‑methode. Voor JPG‑conversie moet je echter de [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/nl/net/aspose.slides/iimage/save/#save_3)‑methode gebruiken.

{{% /alert %}} 

```c#
using Aspose.Slides;

int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Maak een dia‑afbeelding van de opgegeven schaal.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Sla de afbeelding op schijf op in JPEG‑formaat.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Convert Slides to JPG with Customized Dimensions**

Om de afmetingen van de gegenereerde JPG‑afbeeldingen aan te passen, kun je de afbeeldingsgrootte instellen door deze door te geven aan de [ISlide.GetImage(Size)](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/#getimage_6)‑methode. Hierdoor kun je beelden genereren met specifieke breedte‑ en hoogte‑waarden, zodat de uitvoer voldoet aan je eisen voor resolutie en beeldverhouding. Deze flexibiliteit is vooral nuttig bij het genereren van afbeeldingen voor webapplicaties, rapporten of documentatie, waar precieze afmetingen vereist zijn.

```c#
using System.Drawing;
using Aspose.Slides;

Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Maak een dia‑afbeelding van de opgegeven grootte.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Sla de afbeelding op schijf op in JPEG‑formaat.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Render Comments When Saving Slides as Images**

Aspose.Slides for .NET biedt een functie waarmee je opmerkingen op de dia’s van een presentatie kunt renderen wanneer je ze converteert naar JPG‑afbeeldingen. Deze mogelijkheid is bijzonder handig om annotaties, feedback of discussies die door samenwerkers in PowerPoint‑presentaties zijn toegevoegd, te behouden. Door deze optie in te schakelen, zorg je ervoor dat opmerkingen zichtbaar zijn in de gegenereerde beelden, waardoor het eenvoudiger wordt om feedback te bekijken en te delen zonder het originele presentatiebestand te openen.

Stel, we hebben een presentatie‑bestand, "sample.pptx", met een dia die opmerkingen bevat:

![De dia met opmerkingen](slide_with_comments.png)

De volgende C#‑code converteert de dia naar een JPG‑afbeelding terwijl de opmerkingen behouden blijven:

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
        // Stel opties in voor de dia‑opmerkingen.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // Converteer de eerste dia naar een afbeelding.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

Het resultaat:

![De JPG‑afbeelding met opmerkingen](image_with_comments.png)

## **Zie ook**

Bekijk andere opties om PPT, PPTX of ODP naar afbeeldingen te converteren, zoals:

- [Convert PowerPoint to GIF](/slides/nl/net/convert-powerpoint-to-animated-gif/)
- [Convert PowerPoint to PNG](/slides/nl/net/convert-powerpoint-to-png/)
- [Convert PowerPoint to TIFF](/slides/nl/net/convert-powerpoint-to-tiff/)
- [Convert PowerPoint to SVG](/slides/nl/net/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Om te zien hoe Aspose.Slides PowerPoint naar JPG‑afbeeldingen converteert, probeer deze gratis online converters: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/nl/conversion/pptx-to-jpg) en [PPT to JPG](https://products.aspose.app/slides/nl/conversion/ppt-to-jpg). 

{{% /alert %}} 

![Gratis online PPTX‑naar‑JPG‑converter](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose biedt een [GRATIS Collage‑webapp](https://products.aspose.app/slides/nl/collage). Met deze online service kun je [JPG naar JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG naar PNG‑afbeeldingen samenvoegen, [fotogalerijen](https://products.aspose.app/slides/nl/collage/photo-grid) maken, enzovoort. 

Met dezelfde principes als in dit artikel kun je afbeeldingen van het ene formaat naar het andere converteren. Zie voor meer informatie deze pagina’s: converteer [image to JPG](https://products.aspose.com/slides/nl/net/conversion/image-to-jpg/); converteer [JPG to image](https://products.aspose.com/slides/nl/net/conversion/jpg-to-image/); converteer [JPG to PNG](https://products.aspose.com/slides/nl/net/conversion/jpg-to-png/), converteer [PNG to JPG](https://products.aspose.com/slides/nl/net/conversion/png-to-jpg/); converteer [PNG to SVG](https://products.aspose.com/slides/nl/net/conversion/png-to-svg/), converteer [SVG to PNG](https://products.aspose.com/slides/nl/net/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

### Ondersteunt deze methode batch‑conversie?

Ja, Aspose.Slides maakt batch‑conversie van meerdere dia’s naar JPG in één enkele bewerking mogelijk.

### Ondersteunt de conversie SmartArt, grafieken en andere complexe objecten?

Ja, Aspose.Slides rendert alle inhoud, inclusief SmartArt, grafieken, tabellen, vormen en meer. De rendernauwkeurigheid kan echter enigszins variëren ten opzichte van PowerPoint, vooral bij gebruik van aangepaste of ontbrekende lettertypen.

### Zijn er beperkingen op het aantal dia’s dat verwerkt kan worden?

Aspose.Slides zelf legt geen strikte limieten op aan het aantal dia’s dat je kunt verwerken. Bij zeer grote presentaties of hoge resoluties kun je echter een out‑of‑memory‑fout tegenkomen.