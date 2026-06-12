---
title: Převod snímků PowerPoint do PNG v PHP
linktitle: PowerPoint do PNG
type: docs
weight: 30
url: /cs/php-java/convert-powerpoint-to-png/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do PNG
- prezentace do PNG
- snímek do PNG
- PPT do PNG
- PPTX do PNG
- uložit PPT jako PNG
- uložit PPTX jako PNG
- exportovat PPT do PNG
- exportovat PPTX do PNG
- PHP
- Aspose.Slides
description: "Převádějte prezentace PowerPoint na vysoce kvalitní PNG obrázky rychle pomocí Aspose.Slides pro PHP přes Java, což zajišťuje přesné a automatizované výsledky."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint na obrázky PNG pomocí Aspose.Slides. Ukazuje, jak načíst soubory prezentací ve formátech jako PPT, PPTX a ODP, renderovat snímky jako obrázky a uložit výsledky ve formátu PNG.  
Článek také demonstruje, jak přizpůsobit generované obrázky PNG nastavením hodnot měřítka nebo zadáním požadované šířky a výšky.

## **Převod PowerPointu do PNG**

Postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte objekt snímku z kolekce [Presentation.getSlides()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSlides) pod třídy [Slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/).
3. Použijte metodu [Slide.getImage()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getImage) pro získání miniatury každého snímku.
4. Použijte metodu [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/#save) pro uložení miniatury snímku do formátu PNG.

Tento PHP kód ukazuje, jak převést prezentaci PowerPoint do PNG:

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

## **Převod PowerPointu do PNG s vlastními rozměry**

Pokud chcete získat soubory PNG v určitém měřítku, můžete nastavit hodnoty `desiredX` a `desiredY`, které určují rozměry výsledné miniatury.  

Tento kód demonstruje popsanou operaci:

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

## **Převod PowerPointu do PNG s vlastní velikostí**

Pokud chcete získat soubory PNG v určité velikosti, můžete předat své preferované argumenty `width` a `height` pro `ImageSize`.  

Tento kód ukazuje, jak převést PowerPoint do PNG při zadání velikosti obrázků:  

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

## **Často kladené otázky**

**Jak mohu exportovat pouze konkrétní tvar (např. graf nebo obrázek) místo celého snímku?**  
Aspose.Slides podporuje [generování miniatur pro jednotlivé tvary](/slides/cs/php-java/create-shape-thumbnails/); můžete vykreslit tvar do PNG obrázku.

**Je paralelní konverze podporována na serveru?**  
Ano, ale [nesdílejte](/slides/cs/php-java/multithreading/) jednu instanci prezentace mezi vlákny. Používejte samostatnou instanci pro každé vlákno nebo proces.

**Jaká jsou omezení zkušební verze při exportu do PNG?**  
Režim hodnocení přidává vodoznak k výstupním obrázkům a uplatňuje [další omezení](/slides/cs/php-java/licensing/), dokud není licence použita.