---
title: PowerPoint diák konvertálása PNG-re PHP-ben
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/php-java/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PNG-re
- prezentáció PNG-re
- dia PNG-re
- PPT PNG-re
- PPTX PNG-re
- PPT mentése PNG-ként
- PPTX mentése PNG-ként
- PPT exportálása PNG-be
- PPTX exportálása PNG-be
- PHP
- Aspose.Slides
description: "Konvertálja a PowerPoint prezentációkat gyorsan magas minőségű PNG képekké az Aspose.Slides for PHP via Java segítségével, biztosítva a pontos, automatizált eredményeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint előadásokat PNG képekké konvertálni az Aspose.Slides segítségével. Megmutatja, hogyan lehet PPT, PPTX és ODP formátumú előadásfájlokat betölteni, a diákat képekként renderelni, és az eredményeket PNG formátumban menteni.

A cikk továbbá bemutatja, hogyan lehet testre szabni a létrehozott PNG képeket skálázási értékek beállításával vagy a kívánt szélesség és magasság megadásával.

## **PowerPoint konvertálása PNG-be**

Kövesse az alábbi lépéseket:

1. Hozza létre a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztály példányát.
2. Szerezze meg a diát a [Presentation.getSlides()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSlides) gyűjteményből a [Slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/) osztály alatt.
3. Használja a [Slide.getImage()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#getImage) metódust, hogy megkapja az egyes diák bélyegképét.
4. Használja a [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/#save) metódust a diák bélyegkép PNG formátumba mentéséhez.

Ez a PHP kód megmutatja, hogyan kell egy PowerPoint előadást PNG formátumba konvertálni:

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

## **PowerPoint konvertálása PNG-be egyedi méretekkel**

Ha egy bizonyos skálához tartozó PNG fájlokat szeretne kapni, beállíthatja a `desiredX` és `desiredY` értékeket, amelyek meghatározzák a létrehozott bélyegkép méreteit.

Ez a kód bemutatja a leírt műveletet:

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

## **PowerPoint konvertálása PNG-be egyedi mérettel**

Ha egy bizonyos méretű PNG fájlokat szeretne, megadhatja a kívánt `width` és `height` argumentumokat az `ImageSize` számára.

Ez a kód megmutatja, hogyan konvertáljon egy PowerPointot PNG-be, miközben megadja a képek méretét:

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

## **GYIK**

**Hogyan exportálhatok csak egy adott alakzatot (pl. diagram vagy kép) a teljes diák helyett?**

Az Aspose.Slides támogatja az [egyedi alakzatok bélyegképeinek létrehozását](/slides/hu/php-java/create-shape-thumbnails/); egy alakzatot PNG képpé renderelhet.

**Támogatott a párhuzamos konvertálás szerveren?**

Igen, de [ne ossza meg](/slides/hu/php-java/multithreading/) egyetlen prezentációpéldányt a szálak között. Használjon külön példányt szálanként vagy folyamatként.

**Mik a próba verzió korlátozásai PNG exportálásakor?**

Az értékelési mód vízjelet helyez az kimeneti képekre, és [egyéb korlátozásokat](/slides/hu/php-java/licensing/) alkalmaz, amíg licencet nem adnak meg.