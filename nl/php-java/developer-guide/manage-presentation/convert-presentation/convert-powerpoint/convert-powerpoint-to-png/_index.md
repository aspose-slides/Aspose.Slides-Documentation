---
title: PowerPoint-dia's naar PNG converteren in PHP
linktitle: PowerPoint naar PNG
type: docs
weight: 30
url: /nl/php-java/convert-powerpoint-to-png/
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
- PHP
- Aspose.Slides
description: "Converteer PowerPoint-presentaties snel naar hoogwaardige PNG-afbeeldingen met Aspose.Slides voor PHP via Java, met nauwkeurige en geautomatiseerde resultaten."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties kunt converteren naar PNG‑afbeeldingen met Aspose.Slides. Het toont hoe u presentatiedocumenten kunt laden in formaten zoals PPT, PPTX en ODP, dia’s kunt renderen als afbeeldingen en de resultaten kunt opslaan in PNG‑formaat.

Het artikel laat ook zien hoe u de gegenereerde PNG‑afbeeldingen kunt aanpassen door schaalwaarden in te stellen of de gewenste breedte en hoogte op te geven.

## **PowerPoint naar PNG converteren**

Volg de volgende stappen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Haalt het dia‑object op uit de [Presentation.getSlides()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getSlides) collectie van de [Slide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/) klasse.
3. Gebruik de [Slide.getImage()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getImage) methode om de miniatuur van elke dia te verkrijgen.
4. Gebruik de [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/#save) methode om de dia‑miniatuur op te slaan in PNG‑formaat.

Deze PHP‑code toont hoe u een PowerPoint‑presentatie naar PNG kunt converteren:

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PowerPoint naar PNG converteren met aangepaste afmetingen**

Als u PNG‑bestanden wilt verkrijgen met een bepaalde schaal, kunt u de waarden voor `desiredX` en `desiredY` instellen, die de afmetingen van de resulterende miniatuur bepalen.

Deze code demonstreert de beschreven bewerking:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PowerPoint naar PNG converteren met aangepaste grootte**

Als u PNG‑bestanden wilt verkrijgen met een bepaalde grootte, kunt u uw gewenste `width`‑ en `height`‑argumenten doorgeven aan `ImageSize`.

Deze code laat zien hoe u een PowerPoint naar PNG kunt converteren waarbij u de grootte van de afbeeldingen opgeeft:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Hoe kan ik alleen een specifiek vorm (bijv. grafiek of afbeelding) exporteren in plaats van de hele dia?**

Aspose.Slides ondersteunt [het genereren van miniaturen voor individuele vormen](/slides/nl/php-java/create-shape-thumbnails/); u kunt een vorm renderen naar een PNG‑afbeelding.

**Wordt parallelle conversie ondersteund op een server?**

Ja, maar [deel](/slides/nl/php-java/multithreading/) een enkele presentatie‑instantie niet over threads. Gebruik een aparte instantie per thread of proces.

**Wat zijn de beperkingen van de proefversie bij het exporteren naar PNG?**

De evaluatiemodus voegt een watermerk toe aan de uitvoer‑afbeeldingen en voert [andere beperkingen](/slides/nl/php-java/licensing/) af totdat een licentie is toegepast.