---
title: "PowerPoint-dia's naar PNG in Java"
linktitle: "PowerPoint naar PNG"
type: docs
weight: 30
url: /nl/java/convert-powerpoint-to-png/
keywords:
- "PowerPoint converteren"
- "presentatie converteren"
- "dia converteren"
- "PPT converteren"
- "PPTX converteren"
- "PowerPoint naar PNG"
- "presentatie naar PNG"
- "dia naar PNG"
- "PPT naar PNG"
- "PPTX naar PNG"
- "PPT opslaan als PNG"
- "PPTX opslaan als PNG"
- "PPT exporteren naar PNG"
- "PPTX exporteren naar PNG"
- Java
- Aspose.Slides
description: "PowerPoint-presentaties snel omzetten naar hoogwaardige PNG-afbeeldingen met Aspose.Slides voor Java, waarbij nauwkeurige, geautomatiseerde resultaten worden gegarandeerd."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt omzetten naar PNG‑afbeeldingen met Aspose.Slides. Het toont hoe u presentaties kunt laden in formaten zoals PPT, PPTX en ODP, dia’s kunt renderen als afbeeldingen en de resultaten kunt opslaan in PNG‑formaat.

Het artikel laat ook zien hoe u de gegenereerde PNG‑afbeeldingen kunt aanpassen door schaalwaarden in te stellen of de gewenste breedte en hoogte op te geven.

## **PowerPoint naar PNG converteren**

Volg deze stappen:

1. Instantiseer de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Haal het dia‑object op uit de [Presentation.getSlides()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#getSlides--) collectie via de [ISlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlide) interface.  
3. Gebruik de [ISlide.getImage()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISlide) methode om de miniatuur voor elke dia te verkrijgen.  
4. Gebruik de [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) methode om de dia‑miniatuur op te slaan in PNG‑formaat.

Deze Java‑code laat zien hoe u een PowerPoint‑presentatie naar PNG converteert:

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

Deze Java‑code demonstreert de beschreven bewerking:

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

Als u PNG‑bestanden wilt verkrijgen met een bepaalde grootte, kunt u uw gewenste `width`‑ en `height`‑argumenten doorgeven aan `ImageSize`.

Deze code laat zien hoe u een PowerPoint naar PNG converteert terwijl u de grootte voor de afbeeldingen opgeeft:

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

**Hoe kan ik alleen een specifieke vorm (bijv. grafiek of afbeelding) exporteren in plaats van de hele dia?**

Aspose.Slides ondersteunt het [genereren van miniaturen voor individuele vormen](/slides/nl/java/create-shape-thumbnails/); u kunt een vorm renderen naar een PNG‑afbeelding.

**Wordt parallelle conversie ondersteund op een server?**

Ja, maar [deel](/slides/nl/java/multithreading/) geen enkele presentatie‑instantie over threads. Gebruik een aparte instantie per thread of proces.

**Wat zijn de beperkingen van de proefversie bij het exporteren naar PNG?**

De evaluatiemodus voegt een watermerk toe aan uitvoerafbeeldingen en handhaaft [andere beperkingen](/slides/nl/java/licensing/) totdat er een licentie is toegepast.