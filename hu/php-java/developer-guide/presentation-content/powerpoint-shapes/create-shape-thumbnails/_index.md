---
title: Diaalakzatok bélyegképeinek létrehozása PHP-ben
linktitle: Alakzat bélyegképek
type: docs
weight: 70
url: /hu/php-java/create-shape-thumbnails/
keywords:
- alakzat bélyegkép
- alakzat kép
- alakzat megjelenítése
- alakzat renderelés
- vizuális határok
- alakzat határok
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Készítsen magas minőségű alakzat-bélyegképeket PowerPoint diákról az Aspose.Slides for PHP via Java segítségével - egyszerűen hozhat és exportálhat prezentációs bélyegképeket."
---
## **Bevezetés**

Az Aspose.Slides-et prezentációs fájlok létrehozására használják, ahol minden oldal egy diát jelent. Ezeket a diákat a prezentációs fájlok Microsoft PowerPoint segítségével történő megnyitásával lehet megtekinteni. De néha a fejlesztőknek külön kell megtekinteniük a alakzatok képeit egy képnézőben. Ilyen esetben az Aspose.Slides segít a diaalakzatok bélyegképének előállításában. A funkció használatát ebben a cikkben ismertetjük.
Ez a cikk bemutatja, hogyan lehet a diákat különböző módokon bélyegképpé konvertálni:

- Alakzat bélyegképének generálása egy dián belül.
- Alakzat bélyegképének generálása a diaalakzathoz felhasználó által meghatározott méretekkel.
- Alakzat bélyegképének generálása az alakzat megjelenésének határain belül.

## **Alakzat bélyegképének létrehozása egy diáról**
Az Aspose.Slides for PHP via Java használatával bármely diáról alakzat bélyegképének előállításához tegye a következőket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
1. Szerezze be egy diára való hivatkozást annak ID-jével vagy indexével.
1. [Szerezze meg a forma bélyegképét](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getImage) a hivatkozott dia alapértelmezett méretben.
1. Mentse a bélyegképet a kívánt képfformátumban.

Ez a példa kód bemutatja, hogyan lehet egy diáról alakzat bélyegképet előállítani:

```php
  # Példányosítsa a Presentation osztályt, amely a prezentációs fájlt képviseli
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Hozzon létre egy teljes méretű képet
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Mentse a képet lemezre PNG formátumban
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

## **Felhasználó által meghatározott méretezési tényezővel rendelkező bélyegkép létrehozása**
Az Aspose.Slides for PHP via Java használatával egy diáról alakzat bélyegképének előállításához tegye a következőket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
1. Szerezze be egy diára való hivatkozást annak ID-jével vagy indexével.
1. [Szerezze meg a forma bélyegképét](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getImage) a hivatkozott diáról felhasználó által meghatározott méretekkel.
1. Mentse a bélyegképet a kívánt képfformátumban.

Ez a példa kód bemutatja, hogyan lehet egy alakzat bélyegképet előállítani egy meghatározott méretezési tényező alapján:

```php
  # Példányosítsa a Presentation osztályt, amely a prezentációs fájlt képviseli
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Hozzon létre egy teljes méretű képet
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Mentse a képet lemezre PNG formátumban
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

## **Határoláson alapuló alakzat megjelenés bélyegkép létrehozása**
Ez a módszer lehetővé teszi a fejlesztők számára, hogy a forma megjelenésének határain belül bélyegképet generáljanak. Figyelembe veszi az összes formahatást. A generált forma bélyegképét a dia határai korlátozzák. A forma megjelenésének határain belül történő bélyegkép generálásához tegye a következőket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
1. Szerezze be egy diára való hivatkozást annak ID-jével vagy indexével.
1. Szerezze meg a hivatkozott dia bélyegképét a forma határai megjelenésként legyenek használva.
1. Mentse a bélyegképet a kívánt képfformátumban.

Ez a példa kód a fenti lépéseken alapul:

```php
  # Példányosítsa a Presentation osztályt, amely a prezentációs fájlt képviseli
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Hozzon létre egy teljes méretű képet
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Mentse a képet lemezre PNG formátumban
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

## **Alakzat tényleges vizuális határainak lekérdezése**

A [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) keret‑tulajdonságai – `Shape::getX()`, `Shape::getY()`, `Shape::getWidth()` és `Shape::getHeight()` – a prezentációs modellben tárolt téglalapot írják le. A ténylegesen megjelenített tartalom meghaladhatja ezt a keretet, vagy egy másik tengely‑igazított téglalapot foglalhat el. A forgatás, körvonalak, nyilak, szöveg elrendezése és túlcsordulása, a generált SmartArt geometria és egyéb megjelenítési hatások mind módosíthatják a lefoglalt területet.

Használja a [Shape::getVisualBounds](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getVisualBounds) metódust a lefoglalt terület kiszámításához kép létrehozása nélkül. A metódus egy [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) objektumot ad vissza diára vonatkozó koordinátákkal. A visszakapott téglalap nincs levágva a diára, így koordinátái negatívak lehetnek, ha a tartalom a dia eredeti pontja túlra nyúlik.

A következő példa lekéri és összehasonlítja a keret‑ és a vizuális határokat:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

Ugyanaz a [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) használható a közeli alakzatok bal, jobb, felső vagy alsó élhez igazításához; elegendő hely lefoglalásához egy generált elrendezésben; vagy a megengedett régión kívüli tartalom felderítéséhez. A vizuális határok különösen hasznosak SmartArt, szövegdobozok, nyilak, képek, elforgatott alakzatok és csoportos alakzatok esetén, ahol a tárolt keret nem feltétlenül tükrözi a teljes megjelenített eredményt.

Használja a [Shape::getVisualBounds](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getVisualBounds) metódust, ha elrendezési vagy ellenőrzési koordinátákra van szüksége, és nem igényel bitmapet. Használja a [Shape::getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getImage) metódust, ha a formát meg kell jeleníteni. A [ShapeThumbnailBounds](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapethumbnailbounds/) esetén a `ShapeThumbnailBounds::Shape` a kép méretét a forma határaiból, a körvonal beállításokkal együtt határozza meg, míg a `ShapeThumbnailBounds::Appearance` a forma megjelenése alapján méretezi, és korlátozza az eredményt a dia határaihoz. Ezzel szemben a `Shape::getVisualBounds` csak a számított téglalapot adja vissza, és nem vágja le azt a diára.

## **GYIK**

**Milyen képfájlformátumok használhatók a forma bélyegképek mentésekor?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imageformat/), és egyebek. A formák [exportálhatók vektorgrafikaként SVG](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/writeassvg/) a forma tartalmának SVG-ként való mentésével.

**Mi a különbség a Shape és az Appearance határok között a bélyegkép renderelésekor?**

`Shape` a forma geometria alapján határozza meg; `Appearance` a [vizuális hatásokat](/slides/hu/php-java/shape-effect/) (árnyékok, ragyogások stb.) is figyelembe veszi.

**Mi történik, ha egy forma rejtettnek van jelölve? Továbbra is megjelenik majd bélyegképként?**

A rejtett forma továbbra is része a modellnek és renderelhető; a rejtett jelző a diavetítés megjelenítését befolyásolja, de nem akadályozza meg a forma képének előállítását.

**Támogatottak a csoportos alakzatok, diagramok, SmartArt és egyéb komplex objektumok?**

Igen. Bármely objektum, amely [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/)‑ként van reprezentálva (beleértve a [GroupShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/) és [SmartArt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/smartart/) típusokat) menthető bélyegkép vagy SVG formátumban.

**A rendszerben telepített betűkészletek befolyásolják a szöveges alakzatok bélyegképeinek minőségét?**

Igen. Ajánlott [a szükséges betűkészleteket biztosítani](/slides/hu/php-java/custom-font/) (vagy [betűkészlet‑helyettesítéseket beállítani](/slides/hu/php-java/font-substitution/)), hogy elkerülje a nem kívánt helyettesítéseket és a szöveg újratervezését.