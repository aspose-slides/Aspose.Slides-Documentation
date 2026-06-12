---
title: Vkládání písem do prezentací pomocí PHP
linktitle: Vkládání písma
type: docs
weight: 40
url: /cs/php-java/embedded-font/
keywords:
- přidat písmo
- vložit písmo
- vkládání písma
- získat vložené písmo
- přidat vložené písmo
- odstranit vložené písmo
- komprimovat vložené písmo
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Vkládejte písma TrueType do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java, což zajišťuje přesné vykreslování na všech platformách."
---
## **Úvod**

**Vložená písma v PowerPointu** jsou užitečná, když chcete, aby se vaše prezentace zobrazovala správně na jakémkoli systému nebo zařízení. Pokud jste použili písmo třetí strany nebo nestandardní písmo, protože jste byli kreativní, máte ještě důvod k jeho vložení. Jinak (bez vložených písem) se mohou texty nebo čísla na snímcích, rozvržení, stylování atd. změnit nebo se proměnit v matoucí obdélníky.

Třída [FontsManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontsManager), třída [FontData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontdata/) a třída [Compress](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/) obsahují většinu metod, které potřebujete pro práci s vloženými písmy v prezentacích PowerPoint.

## **Získání a odstranění vložených písem**

Aspose.Slides poskytuje metodu [getEmbeddedFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) (vystavenou třídou [FontsManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FontsManager)), která vám umožní získat (nebo zjistit) písma vložená v prezentaci. Pro odstranění písem se používá metoda [removeEmbeddedFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) (vystavená stejnou třídou).

Tento PHP kód vám ukáže, jak získat a odstranit vložená písma z prezentace:

```php
  # Vytváří objekt Presentation, který představuje soubor prezentace
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Vykresluje snímek obsahující textový rámec, který používá vložené "FunSized"
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Uloží obrázek na disk ve formátu JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Získá všechna vložená písma
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Vyhledá písmo "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # Odstraní písmo "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Vykresluje prezentaci; písmo "Calibri" je nahrazeno existujícím
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Uloží obrázek na disk ve formátu JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Uloží prezentaci bez vloženého písma "Calibri" na disk
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přidání vložených písem**

Pomocí třídy [EmbedFontCharacters](https://reference.aspose.com/slides/cs/php-java/aspose.slides/embedfontcharacters/) a dvou přetížení metody [addEmbeddedFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) můžete zvolit preferované (vkládací) pravidlo pro vložení písem do prezentace. Tento PHP kód vám ukáže, jak vložit a přidat písma do prezentace:

```php
  # Načte prezentaci
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # Uloží prezentaci na disk
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Komprese vložených písem**

Abychom vám umožnili komprimovat písma vložená v prezentaci a snížit její velikost souboru, Aspose.Slides poskytuje metodu [compressEmbeddedFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/#compressEmbeddedFonts) (vystavenou třídou [Compress](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/)).

Tento PHP kód vám ukáže, jak komprimovat vložená písma PowerPointu:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Jak mohu zjistit, že konkrétní písmo v prezentaci bude i přes vložení při vykreslování nahrazeno?**

Zkontrolujte [informace o nahrazování](/slides/cs/php-java/font-substitution/) ve správci písem a [pravidla pro fallback/nahrazení](/slides/cs/php-java/fallback-font/): pokud je písmo nedostupné nebo omezené, bude použito záložní písmo.

**Stojí za to vkládat „systémová“ písma jako Arial/Calibri?**

Obvykle ne – tato písma jsou téměř vždy k dispozici. Ale pro úplnou přenositelnost v „tenkých“ prostředích (Docker, Linux server bez předinstalovaných písem) může vložení systémových písem eliminovat riziko neočekávaných náhrad.