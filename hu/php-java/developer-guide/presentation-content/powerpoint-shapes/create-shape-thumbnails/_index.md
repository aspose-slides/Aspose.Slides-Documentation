---
title: Diák alakzatok bélyegképének létrehozása PHP-ben
linktitle: Alakzat bélyegképek
type: docs
weight: 70
url: /hu/php-java/create-shape-thumbnails/
keywords:
- alakzat bélyegkép
- alakzat kép
- alakzat renderelése
- alakzat renderelés
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Készítsen kiváló minőségű alakzat bélyegképeket a PowerPoint diákról az Aspose.Slides for PHP via Java segítségével – könnyedén hozhat létre és exportálhat prezentációs bélyegképeket."
---
## **Bevezetés**

Az Aspose.Slides a bemutatófájlok létrehozására szolgál, ahol minden oldal egy diát jelent. Ezeket a diákat a Microsoft PowerPoint segítségével lehet megnyitni. Néha azonban a fejlesztőknek külön szeretnék megtekinteni a formák képeit egy képmegjelenítőben. Ilyenkor az Aspose.Slides segít a diák alakzatainak bélyegképeinek előállításában. Ennek a funkciónak a használatát ebben a cikkben ismertetjük.

Ez a cikk elmagyarázza, hogyan lehet különböző módokon generálni diabélyegképeket:

- Alakzat bélyegkép generálása egy dián belül.
- Alakzat bélyegkép generálása felhasználó által definiált méretekkel.
- Alakzat bélyegkép generálása a forma megjelenésének határai szerint.

## **Alakzat bélyegkép generálása diából**
A shape bélyegkép előállításához tetszőleges diáról az Aspose.Slides for PHP via Java használatával kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
1. Szerezze meg egy tetszőleges dia hivatkozását azonosítója vagy indexe alapján.
1. Kérje le a hivatkozott dia alakzat bélyegkép képét alapértelmezett méretezésben a [Get the shape thumbnail image](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getImage) módszerrel.
1. Mentse el a bélyegkép képet a kívánt képformátumban.

Ez a példakód bemutatja, hogyan lehet egy alakzat bélyegképet előállítani egy diáról:

```php
  # Példányosít egy Presentation osztályt, amely a prezentációs fájlt képviseli
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Létrehoz egy teljes méretű képet
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # A képet PNG formátumban menti le a merevlemezre
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Felhasználó által definiált méretezési tényezővel bélyegkép generálása**
A shape bélyegkép előállításához egy diáról az Aspose.Slides for PHP via Java használatával kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
1. Szerezze meg egy tetszőleges dia hivatkozását azonosítója vagy indexe alapján.
1. Kérje le a hivatkozott dia alakzat bélyegkép képét felhasználó által meghatározott méretekkel a [Get the shape thumbnail image](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getImage) módszerrel.
1. Mentse el a bélyegkép képet a kívánt képformátumban.

Ez a példakód bemutatja, hogyan lehet egy alakzat bélyegképet generálni egy definiált méretezési tényező alapján:

```php
  # Példányosít egy Presentation osztályt, amely a prezentációs fájlt képviseli
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Létrehoz egy teljes méretű képet
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # A képet PNG formátumban menti le a merevlemezre
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Határokon alapuló alakzat megjelenés bélyegkép létrehozása**
Ez a módszer lehetővé teszi, hogy a fejlesztők a forma megjelenésének határain belül generáljanak bélyegképet, figyelembe véve minden formahatást. A létrehozott bélyegkép a diahatárok által van korlátozva. A diában szereplő forma megjelenésének határain belül bélyegkép előállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
1. Szerezze meg egy tetszőleges dia hivatkozását azonosítója vagy indexe alapján.
1. Szerezze meg a hivatkozott dia bélyegkép képét a forma határokkal mint megjelenés beállítással.
1. Mentse el a bélyegkép képet a kívánt képformátumban.

Ez a példakód a fenti lépések alapján készült:

```php
  # Példányosít egy Presentation osztályt, amely a prezentációs fájlt képviseli
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Létrehoz egy teljes méretű képet
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # A képet PNG formátumban menti le a merevlemezre
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Milyen képformátumok használhatók a forma bélyegképek mentésekor?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imageformat/), és egyebek. A formák [vektor SVG-ként exportálhatók](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/writeassvg/) a forma tartalmának SVG-ként történő mentésével.

**Mi a különbség a Shape és az Appearance határok között egy bélyegkép renderelésekor?**

`Shape` a forma geometriáját használja; `Appearance` figyelembe veszi a [vizuális effektusokat](/slides/hu/php-java/shape-effect/) (árnyékok, fénylő kontúrok stb.).

**Mi történik, ha egy forma rejtettként van megjelölve? Megjelenik még mindig bélyegképként?**

Egy rejtett forma továbbra is része a modellnek és renderelhető; a rejtett jelző a diavetítés megjelenítését befolyásolja, de nem akadályozza meg a forma képének előállítását.

**Támogatottak a csoportos alakzatok, diagramok, SmartArt és egyéb összetett objektumok?**

Igen. Bármely objektum, amely [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/)‑ként van reprezentálva (beleértve a [GroupShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/groupshape/), a [Chart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/) és a [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) elemeket) elmenthető bélyegképként vagy SVG‑ként.

**A rendszer által telepített betűtípusok befolyásolják a szöveges alakzatok bélyegképeinek minőségét?**

Igen. Ajánlott [megadni a szükséges betűtípusokat](/slides/hu/php-java/custom-font/) (vagy [beállítani a betűtípus helyettesítéseket](/slides/hu/php-java/font-substitution/)), hogy elkerülje a nem kívánt helyettesítéseket és a szöveg újrarendeződését.