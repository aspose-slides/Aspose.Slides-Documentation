---
title: PowerPoint-dia's naar PNG converteren in .NET
linktitle: PowerPoint naar PNG
type: docs
weight: 30
url: /nl/net/convert-powerpoint-to-png/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar PNG
- presentatie naar PNG
- dia naar PNG
- PPT naar PNG
- PPTX naar PNG
- PPT opslaan als PNG
- PPTX opslaan als PNG
- PPT exporteren naar PNG
- PPTX exporteren naar PNG
- .NET
- C#
- Aspose.Slides
description: "Converteer PowerPoint-presentaties snel naar PNG-afbeeldingen van hoge kwaliteit met Aspose.Slides voor .NET, waarmee nauwkeurige, geautomatiseerde resultaten worden gegarandeerd."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt converteren naar PNG‑afbeeldingen met Aspose.Slides. Het laat zien hoe u presentatiebestanden in formaten zoals PPT, PPTX en ODP kunt laden, dia’s als afbeeldingen kunt renderen en de resultaten kunt opslaan in PNG‑formaat.

Het artikel laat ook zien hoe u de gegenereerde PNG‑afbeeldingen kunt aanpassen door schaalwaarden in te stellen of de gewenste breedte en hoogte op te geven.

## **PowerPoint naar PNG converteren**

Volg deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.  
2. Haal het dia‑object op uit de [Presentation.Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/properties/slides) collectie via de [ISlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide) interface.  
3. Gebruik de [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/) methode om elke dia te renderen op de schaal die u nodig hebt.  
4. Gebruik de [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.ipresentation/save/methods/5) methode om de diathumbnail op te slaan in PNG‑formaat.  

Deze C#‑code laat zien hoe u een PowerPoint‑presentatie naar PNG kunt converteren. Het Presentation‑object kan PPT, PPTX, ODP enz. laden; vervolgens wordt elke dia in het Presentation‑object geconverteerd naar PNG‑formaat of een ander afbeeldingsformaat.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 

**Opmerking:** De schaalargumenten `1f, 1f` renderen elke dia op de volledige grootte, dus een dia van 720×540 pt levert een afbeelding van 720×540 px op. De parameterloze [GetImage()](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/) overload geeft in plaats daarvan een veel kleinere voorbeeld‑thumbnail terug.

{{% /alert %}} 

## **PowerPoint naar PNG met aangepaste afmetingen**

Als u PNG‑bestanden wilt verkrijgen rond een bepaalde schaal, kunt u de waarden voor `desiredX` en `desiredY` instellen, die de afmetingen van de resulterende thumbnail bepalen. 

Deze C#‑code demonstreert de beschreven handeling:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **PowerPoint naar PNG met aangepaste grootte**

Als u PNG‑bestanden wilt verkrijgen rond een bepaalde grootte, kunt u uw gewenste `width`‑ en `height`‑argumenten doorgeven voor `imageSize`. 

Deze code laat zien hoe u een PowerPoint naar PNG kunt converteren terwijl u de grootte van de afbeeldingen specificeert: 

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Veelgestelde vragen**

### Hoe kan ik alleen een specifiek object (bijv. diagram of afbeelding) exporteren in plaats van de hele dia?

Aspose.Slides ondersteunt [het genereren van thumbnails voor individuele objecten](/slides/nl/net/create-shape-thumbnails/); u kunt een object renderen naar een PNG‑afbeelding.

### Wordt parallelle conversie ondersteund op een server?

Ja, maar [deel](/slides/nl/net/multithreading/) een enkele presentatie‑instantie niet over threads. Gebruik een aparte instantie per thread of proces.

### Wat zijn de beperkingen van de proefversie bij het exporteren naar PNG?

De evaluatiemodus voegt een watermerk toe aan de uitvoer‑afbeeldingen en handhaaft [andere beperkingen](/slides/nl/net/licensing/) totdat een licentie is toegepast.