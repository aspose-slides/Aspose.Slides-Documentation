---
title: Betűkészletek beágyazása prezentációkba PHP használatával
linktitle: Betűkészlet beágyazása
type: docs
weight: 40
url: /hu/php-java/embedded-font/
keywords:
- betűkészlet hozzáadása
- betűkészlet beágyazása
- betűkészlet beágyazás
- beágyazott betűkészlet lekérése
- beágyazott betűkészlet hozzáadása
- beágyazott betűkészlet eltávolítása
- beágyazott betűkészlet tömörítése
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Beágyazott TrueType betűkészletek PowerPoint és OpenDocument prezentációkba az Aspose.Slides for PHP via Java segítségével, biztosítva a pontos megjelenítést minden platformon."
---
## **Bevezetés**

**A PowerPointba ágyazott betűkészletek** hasznosak, amikor azt szeretné, hogy a bemutatója minden rendszeren vagy eszközön helyesen jelenjen meg. Ha harmadik fél vagy nem szabványos betűkészletet használt, mert kreatív volt a munkájában, akkor még több ok áll a betűkészlet beágyazása mellett. Ellenkező esetben (beágyazott betűkészletek nélkül) a diákon lévő szövegek vagy számok, az elrendezés, a stílus stb. megváltozhatnak vagy zavaró téglalapokká alakulhatnak.

A [FontsManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontsManager) osztály, a [FontData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontdata/) osztály és a [Compress](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/) osztály tartalmazza a legtöbb szükséges metódust a PowerPoint‑prezentációkba ágyazott betűkészletek kezeléséhez.

## **Beágyazott betűkészletek lekérése és eltávolítása**

Az Aspose.Slides a [getEmbeddedFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) metódust (amely a [FontsManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontsManager) osztályban érhető el) biztosítja, hogy lekérdezhesse (vagy megtudja), mely betűkészletek vannak beágyazva egy bemutatóban. A betűkészletek eltávolításához a [removeEmbeddedFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) metódust (szintén ugyanabban az osztályban) használják.

Ez a PHP kód megmutatja, hogyan lehet lekérni és eltávolítani a beágyazott betűkészleteket egy bemutatóból:
```php
  # Egy Presentation objektum példányosítása, amely egy prezentációs fájlt képvisel
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Egy diát renderel, amely szövegkeretet tartalmaz, beágyazott "FunSized" betűkészlettel
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # A képet JPEG formátumban a lemezen menti
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Az összes beágyazott betűkészlet lekérése
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # A "Calibri" betűkészlet megtalálása
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # A "Calibri" betűkészlet eltávolítása
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # A prezentáció renderelése; "Calibri" betűkészlet egy meglévővel lesz helyettesítve
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # A képet JPEG formátumban a lemezen menti
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # A prezentáció mentése a beágyazott "Calibri" betűkészlet nélkül a lemezre
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Beágyazott betűkészletek hozzáadása**

Az [EmbedFontCharacters](https://reference.aspose.com/slides/hu/php-java/aspose.slides/embedfontcharacters/) osztály és a [addEmbeddedFont](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) metódus két túlterhelése segítségével kiválaszthatja a kívánt (beágyazási) szabályt a betűkészletek bemutatóba ágyazásához. Ez a PHP kód megmutatja, hogyan ágyazhat be és adhat hozzá betűkészleteket egy bemutatóhoz:
```php
  # Betölti a prezentációt
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
    # A prezentációt lemezre menti
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Beágyazott betűkészletek tömörítése**

Az beágyazott betűkészletek tömörítésével és a fájlméret csökkentésével segíteni, az Aspose.Slides a [compressEmbeddedFonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/#compressEmbeddedFonts) metódust (amely a [Compress](https://reference.aspose.com/slides/hu/php-java/aspose.slides/compress/) osztályban érhető el) biztosítja.

Ez a PHP kód megmutatja, hogyan lehet tömöríteni a beágyazott PowerPoint betűkészleteket:
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

## **GYIK**

**Hogyan tudhatom, hogy egy adott betűkészlet a bemutatóban a beágyazás ellenére is helyettesítésre kerül a renderelés során?**

Ellenőrizze a [helyettesítési információkat](/slides/hu/php-java/font-substitution/) a betűkészlet-kezelőben és a [visszalépési/helyettesítési szabályokat](/slides/hu/php-java/fallback-font/): ha a betűkészlet nem érhető el vagy korlátozott, akkor egy visszalépő betűkészlet lesz használva.

**Éri-e meg a "rendszer" betűkészletek, például az Arial/Calibri beágyazása?**

Általában nem – ezek szinte mindig elérhetők. Azonban vékony környezetek („könnyű” környezetek, például Docker vagy egy előre telepített betűkészletek nélküli Linux szerver) a rendszerbetűkészletek beágyazása kiküszöbölheti a váratlan helyettesítések kockázatát.