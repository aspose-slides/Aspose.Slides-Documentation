---
title: PowerPoint-dia's naar PNG converteren op Android
linktitle: PowerPoint naar PNG
type: docs
weight: 30
url: /nl/androidjava/convert-powerpoint-to-png/
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
- Android
- Java
- Aspose.Slides
description: "Converteer PowerPoint-presentaties snel naar PNG-afbeeldingen van hoge kwaliteit met Aspose.Slides voor Android via Java, waardoor nauwkeurige, geautomatiseerde resultaten worden gegarandeerd."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties naar PNG‑afbeeldingen kunt converteren met Aspose.Slides. Het laat zien hoe u presentaties‑bestanden in formaten zoals PPT, PPTX en ODP kunt laden, dia’s als afbeeldingen kunt renderen en de resultaten in PNG‑formaat kunt opslaan.

Het artikel laat ook zien hoe u de gegenereerde PNG‑afbeeldingen kunt aanpassen door schaalwaarden in te stellen of de gewenste breedte en hoogte op te geven.

## **PowerPoint naar PNG converteren**

Volg deze stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)-klasse.
2. Haal het dia‑object op uit de [Presentation.getSlides()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--)‑collectie via de [ISlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlide)-interface.
3. Gebruik de [ISlide.getImage()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlide)-methode om de miniatuur van elke dia op te halen.
4. Gebruik de [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat))-methode om de miniatuur van de dia op te slaan in PNG‑formaat.

Deze Java‑code laat zien hoe u een PowerPoint‑presentatie naar PNG kunt converteren:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint naar PNG converteren met aangepaste afmetingen**

Als u PNG‑bestanden wilt verkrijgen met een bepaalde schaal, kunt u de waarden voor `desiredX` en `desiredY` instellen, die de afmetingen van de resulterende miniatuur bepalen.

Deze code in Java demonstreert de beschreven bewerking:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint naar PNG converteren met aangepaste grootte**

Als u PNG‑bestanden wilt verkrijgen met een bepaalde grootte, kunt u uw gewenste `width`‑ en `height`‑argumenten doorgeven voor `ImageSize`.

Deze code laat zien hoe u een PowerPoint naar PNG kunt converteren terwijl u de grootte van de afbeeldingen opgeeft: 

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Hoe kan ik alleen een specifiek vormelement (bijv. een diagram of afbeelding) exporteren in plaats van de hele dia?**

Aspose.Slides ondersteunt het [genereren van miniaturen voor individuele vormen](/slides/nl/androidjava/create-shape-thumbnails/); u kunt een vorm renderen naar een PNG‑afbeelding.

**Wordt parallelle conversie ondersteund op een server?**

Ja, maar [deel niet](/slides/nl/androidjava/multithreading/) een enkele presentatie‑instance over threads. Gebruik een aparte instance per thread of proces.

**Wat zijn de beperkingen van de proefversie bij het exporteren naar PNG?**

De evaluatiemodus voegt een watermerk toe aan de uitvoer‑afbeeldingen en handhaaft [andere beperkingen](/slides/nl/androidjava/licensing/) totdat een licentie is toegepast.