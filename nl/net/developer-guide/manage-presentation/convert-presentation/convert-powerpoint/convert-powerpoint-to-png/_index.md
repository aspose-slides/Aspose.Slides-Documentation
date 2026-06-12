---
title: PowerPoint-dia's converteren naar PNG in .NET
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
description: "Converteer PowerPoint-presentaties snel naar PNG-afbeeldingen van hoge kwaliteit met Aspose.Slides voor .NET, waardoor nauwkeurige, geautomatiseerde resultaten gegarandeerd zijn."
---
## **Overzicht**

Dit artikel legt uit hoe je PowerPoint-presentaties naar PNG-afbeeldingen kunt converteren met Aspose.Slides. Het laat zien hoe je presentatiedossiers in formaten zoals PPT, PPTX en ODP kunt laden, dia's kunt renderen als afbeeldingen, en de resultaten kunt opslaan in PNG-formaat.

Het artikel laat ook zien hoe je de gegenereerde PNG-afbeeldingen kunt aanpassen door schaalwaarden in te stellen of de gewenste breedte en hoogte op te geven.

## **PowerPoint naar PNG converteren**

Volg deze stappen:

1. Instantieser de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Haal het dia-object op uit de [Presentation.Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/properties/slides) collectie via de [ISlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide) interface.
3. Gebruik de [ISlide.GetImage](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/getimage/) methode om de miniatuur van elke dia te verkrijgen.
4. Gebruik de [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.ipresentation/save/methods/5) methode om de dia-miniatuur op te slaan in PNG-formaat.

Deze C#-code laat zien hoe je een PowerPoint-presentatie naar PNG converteert. Het Presentation-object kan PPT, PPTX, ODP etc. laden; elke dia in het Presentation-object wordt vervolgens omgezet naar PNG-formaat of een ander afbeeldingsformaat.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **PowerPoint naar PNG converteren met aangepaste afmetingen**

Als je PNG-bestanden wilt verkrijgen met een bepaalde schaal, kun je de waarden voor `desiredX` en `desiredY` instellen, die de afmetingen van de resulterende miniatuur bepalen.

Deze C#-code demonstreert de beschreven bewerking:

```c#
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

## **PowerPoint naar PNG converteren met aangepaste grootte**

Als je PNG-bestanden wilt verkrijgen met een bepaalde grootte, kun je je gewenste `width`- en `height`-argumenten doorgeven voor `imageSize`.

Deze code laat zien hoe je een PowerPoint naar PNG converteert terwijl je de grootte van de afbeeldingen opgeeft:

```c#
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

## **FAQ**

**Hoe kan ik alleen een specifieke vorm (bijv. diagram of afbeelding) exporteren in plaats van de hele dia?**

Aspose.Slides ondersteunt [het genereren van miniaturen voor individuele vormen](/slides/nl/net/create-shape-thumbnails/); je kunt een vorm renderen naar een PNG-afbeelding.

**Wordt parallelle conversie ondersteund op een server?**

Ja, maar [deel](/slides/nl/net/multithreading/) geen enkele presentation-instantie over threads. Gebruik een aparte instantie per thread of proces.

**Wat zijn de beperkingen van de proefversie bij het exporteren naar PNG?**

De evaluatiemodus voegt een watermerk toe aan de uitvoerafbeeldingen en handhaaft [andere beperkingen](/slides/nl/net/licensing/) totdat er een licentie is toegepast.