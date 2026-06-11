---
title: Konvertera PowerPoint‑bilder till PNG i PHP
linktitle: PowerPoint till PNG
type: docs
weight: 30
url: /sv/php-java/convert-powerpoint-to-png/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till PNG
- presentation till PNG
- bild till PNG
- PPT till PNG
- PPTX till PNG
- spara PPT som PNG
- spara PPTX som PNG
- exportera PPT till PNG
- exportera PPTX till PNG
- PHP
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till högkvalitativa PNG‑bilder snabbt med Aspose.Slides för PHP via Java, vilket säkerställer precisa, automatiserade resultat."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar PowerPoint‑presentationer till PNG‑bilder med Aspose.Slides. Den visar hur du laddar presentationsfiler i format såsom PPT, PPTX och ODP, renderar bilder som bilder och sparar resultaten i PNG‑format.

Artikeln visar också hur du anpassar de genererade PNG‑bilderna genom att ange skalvärden eller specificera önskad bredd och höjd.

## **Konvertera PowerPoint till PNG**

Gå igenom dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta bildobjektet från samlingen [Presentation.getSlides()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSlides) under klassen [Slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/).
3. Använd metoden [Slide.getImage()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getImage) för att få miniatyrbilden för varje bild.
4. Använd metoden [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/#save) för att spara bildens miniatyr till PNG‑format.

Den här PHP‑koden visar hur du konverterar en PowerPoint‑presentation till PNG:

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

## **Konvertera PowerPoint till PNG med anpassade dimensioner**

Om du vill få PNG‑filer med en viss skala kan du ange värdena för `desiredX` och `desiredY`, som bestämmer dimensionerna på den resulterande miniatyrbilden.

Den här koden demonstrerar den beskrivna operationen:

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

## **Konvertera PowerPoint till PNG med anpassad storlek**

Om du vill få PNG‑filer med en viss storlek kan du skicka dina föredragna argument `width` och `height` för `ImageSize`.

Den här koden visar hur du konverterar en PowerPoint till PNG samtidigt som du specificerar storleken på bilderna:

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

## **Vanliga frågor**

**Hur kan jag exportera endast en specifik form (t.ex. diagram eller bild) istället för hela bilden?**

Aspose.Slides stöder [generering av miniatyrer för enskilda former](/slides/sv/php-java/create-shape-thumbnails/); du kan rendera en form till en PNG‑bild.

**Stöds parallell konvertering på en server?**

Ja, men [dela inte](/slides/sv/php-java/multithreading/) en enda presentationsinstans över trådar. Använd en separat instans per tråd eller process.

**Vilka är begränsningarna i utvärderingsversionen vid export till PNG?**

Utvärderingsläget lägger till ett vattenmärke på utdatabilderna och tillämpar [andra begränsningar](/slides/sv/php-java/licensing/) tills en licens har tillämpats.