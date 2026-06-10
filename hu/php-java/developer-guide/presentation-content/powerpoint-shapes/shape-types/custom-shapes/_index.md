---
title: Prezentációs alakzatok testreszabása PHP-ben
linktitle: Egyéni alakzat
type: docs
weight: 20
url: /hu/php-java/custom-shape/
keywords: 
- egyéni alakzat
- alakzat hozzáadása
- alakzat létrehozása
- alakzat módosítása
- alakzat geometriája
- geometriai útvonal
- útvonal pontok
- szerkesztési pontok
- pont hozzáadása
- pont eltávolítása
- szerkesztési művelet
- görbe sarok
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Alakzatok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for PHP (Java) segítségével: geometriai útvonalak, görbe sarkok, kompozit alakzatok."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testre szabni a prezentációs alakzatokat az Aspose.Slides-ben úgy, hogy a alakzatgeometriát szerkesztési pontok és geometriai útvonalak segítségével módosítjuk. Megmutatja, hogyan kell a `GeometryPath`‑t használni a meglévő alakzatok módosításához, alapvető útvonal‑szerkesztési műveletek végrehajtásához, pontok hozzáadásához vagy eltávolításához, és a frissített geometria visszaalkalmazásához egy alakzatra.

Emellett bemutatja, hogyan hozhatunk létre egyéni és kompozit alakzatokat, hogyan építhetünk görbe sarkokkal rendelkező alakzatokat, hogyan határozhatjuk meg, hogy egy alakzatgeometria zárt‑e, valamint hogyan konvertálhatjuk a `GeometryPath`‑t és a `java.awt.Shape`‑t egymásba további geometriai testreszabási helyzetekhez.

## **Alakzat módosítása szerkesztési pontokkal**

Vegyünk egy négyzetet. A PowerPointban a **szerkesztési pontok** segítségével a következőket teheti:

* a négyzet sarkát befelé vagy kifelé mozgatni
* megadni a görbületet egy sarokhoz vagy ponthoz
* új pontokat hozzáadni a négyzethez
* pontokat kezelni a négyzeten, stb.

Lényegében a leírt feladatokat bármely alakzaton végrehajthatja. A szerkesztési pontok használatával egy alakzatot módosíthat vagy egy új alakzatot hozhat létre egy meglévőből.

## **Alakzat szerkesztési tippek**

![overview_image](custom_shape_0.png)

Mielőtt elkezdené szerkeszteni a PowerPoint‑alkalmazás alakzatait szerkesztési pontokkal, vegye figyelembe az alábbi szempontokat az alakzatokról:

* Egy alakzat (vagy az útvonala) lehet zárt vagy nyitott.
* Ha egy alakzat zárt, nincs kezdő‑ vagy végpontja. Ha nyitott, van egy kezdeti és egy befejező pontja.
* Minden alakzat legalább 2 horgonypontból áll, amelyeket vonalak kötnek össze.
* Egy vonal lehet egyenes vagy ívelt. A horgonypontok határozzák meg a vonal jellegét.
* A horgonypontok lehetnek sarokpontok, simított pontok vagy egyenes pontok:
  * Egy **sarokpont** olyan pont, ahol 2 egyenes vonal szöggel találkozik.
  * Egy **simított pont** olyan pont, ahol 2 fogantyú egy egyenes vonalon helyezkedik el, és a vonalszakaszok sima ívben csatlakoznak. Ebben az esetben a fogantyúk azonos távolságra vannak a horgonyponttól.
  * Egy **egyenes pont** olyan pont, ahol 2 fogantyú egy egyenes vonalon helyezkedik el, és a vonalszakaszok sima ívben csatlakoznak. Itt a fogantyúknek nem kell azonos távolságra lenniük a horgonyponttól.
* A horgonypontok mozgatásával vagy szerkesztésével (ami a vonalak szögét változtatja) megváltoztathatja az alakzat megjelenését.

A PowerPoint‑alakzatok szerkesztéséhez szerkesztési pontokkal, az **Aspose.Slides** a [**GeometryPath**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/GeometryPath) osztályt biztosítja.

* Egy [GeometryPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/GeometryPath) példány egy geometriai útvonalat képvisel a [GeometryShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/geometryshape/) objektumban.
* A `GeometryShape` példányból a `GeometryPath`‑t a [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/hu/php-java/aspose.slides/geometryshape/#getGeometryPaths) metódussal kérhetjük le.
* Egy alakzat `GeometryPath`‑jának beállításához használhatja a következő metódusokat: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/geometryshape/#setGeometryPath) **szilárd alakzatok** esetén és [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/hu/php-java/aspose.slides/geometryshape/#setGeometryPaths) **kompozit alakzatok** esetén.
* Szakaszok hozzáadásához a [GeometryPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/geometrypath/) alatti metódusokat használhatja.
* A [GeometryPath::setStroke](https://reference.aspose.com/slides/hu/php-java/aspose.slides/geometrypath/setstroke/) és a [GeometryPath::setFillMode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/geometrypath/setfillmode/) metódusokkal beállíthatja egy geometriai útvonal megjelenését.
* A [GeometryPath::getPathData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/geometrypath/getpathdata/) metódussal lekérheti egy `GeometryShape` geometriai útvonalát útvonal‑szegmensek tömbjeként.
* További alakzat‑geometriai testreszabási lehetőségekhez konvertálhatja a [GeometryPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/geometrypath/)‑t [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) típusra.
* Használja a [geometryPathToGraphicsPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapeutil/geometrypathtographicspath/) és a [graphicsPathToGeometryPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapeutil/graphicspathtogeometrypath/) metódusokat (a [ShapeUtil](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ShapeUtil) osztályból) a [GeometryPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/geometrypath/) és a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) közötti konverzióhoz oda‑vissza.

## **Egyszerű szerkesztési műveletek**

Ez a PHP kód azt mutatja, hogyan lehet

**Vonal hozzáadása** az útvonal végéhez

```php

```
**Vonal hozzáadása** egy meghatározott pozícióban az útvonalon:

```php

```
**Köbös Bézier‑görbe hozzáadása** az útvonal végéhez:

```php

```
**Köbös Bézier‑görbe hozzáadása** egy meghatározott pozícióban az útvonalon:

```php

```
**Parabolikus Bézier‑görbe hozzáadása** az útvonal végéhez:

```php

```
**Parabolikus Bézier‑görbe hozzáadása** egy meghatározott pozícióban az útvonalon:

```php

```
**Megadott ív hozzáfűzése** az útvonalhoz:

```php

```
**Az aktuális alakzat lezárása** az útvonalon:

```php

```
**A következő pont pozíciójának beállítása**:

```php

```
**Az útvonal‑szegmens eltávolítása** egy adott indexnél:

```php

```

## **Egyéni pontok hozzáadása egy alakzathoz**

1. Hozzon létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/GeometryShape) osztályból, és állítsa be a [ShapeType::Rectangle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ShapeType) típust.
2. Szerezze be a [GeometryPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/GeometryPath) példányt az alakzatról.
3. Adjon hozzá egy új pontot a két felső pont között az útvonalon.
4. Adjon hozzá egy új pontot a két alsó pont között az útvonalon.
5. Alkalmazza az útvonalat az alakzatra.

Ez a PHP kód azt mutatja, hogyan adhat hozzá egyéni pontokat egy alakzathoz:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example1_image](custom_shape_1.png)

## **Pontok eltávolítása egy alakzatról**

1. Hozzon létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/GeometryShape) osztályból, és állítsa be a [ShapeType::Heart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ShapeType) típust.
2. Szerezze be a [GeometryPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/GeometryPath) példányt az alakzatról.
3. Távolítsa el a szegmenst az útvonalból.
4. Alkalmazza az útvonalat az alakzatra.

Ez a PHP kód azt mutatja, hogyan távolíthat el pontokat egy alakzatról:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example2_image](custom_shape_2.png)

## **Egyéni alakzat létrehozása**

1. Számolja ki az alakzat pontjait.
2. Hozzon létre egy példányt a [GeometryPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/GeometryPath) osztályból.
3. Töltse fel az útvonalat a pontokkal.
4. Hozzon létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/GeometryShape) osztályból.
5. Alkalmazza az útvonalat az alakzatra.

Ez a Java azt mutatja, hogyan hozhat létre egy egyéni alakzatot:

```php
  $points = new Java("java.util.ArrayList");
  $R = 100;
  $r = 50;
  $step = 72;
  for($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * java("java.lang.Math")->PI / 180.0;
    $x = $R * java("java.lang.Math")->cos($radians);
    $y = $R * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
    $radians = java("java.lang.Math")->PI * $angle . $step / 2 / 180.0;
    $x = $r * java("java.lang.Math")->cos($radians);
    $y = $r * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for($i = 1; $i < java_values($points->size()) ; $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example3_image](custom_shape_3.png)

## **Kompozit egyéni alakzat létrehozása**

1. Hozzon létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/GeometryShape) osztályból.
2. Hozzon létre egy első példányt a [GeometryPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/GeometryPath) osztályból.
3. Hozzon létre egy második példányt a [GeometryPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/GeometryPath) osztályból.
4. Alkalmazza a két útvonalat az alakzatra.

Ez a PHP kód azt mutatja, hogyan hozhat létre egy kompozit egyéni alakzatot:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(array($geometryPath0, $geometryPath1 ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example4_image](custom_shape_4.png)

## **Egyéni alakzat létrehozása görbe sarkokkal**

Ez a PHP kód azt mutatja, hogyan hozhat létre egy egyéni alakzatot görbe sarkokkal (befelé):

```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2DFloat($leftTopSize, 0);
    $point2 = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2DFloat($leftBottomSize, $shapeHeight);
    $point5 = new Point2DFloat(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Megállapítás, hogy egy alakzatgeometria zárt‑e**

A zárt alakzat olyan, amelynek minden oldala összekapcsolódik, egyetlen határolóvonalat alkotva rések nélkül. Ilyen alakzat lehet egyszerű geometriai forma vagy bonyolult egyéni kontúr. Az alábbi kódrészlet bemutatja, hogyan ellenőrizhető, hogy egy alakzatgeometria zárt‑e:

```php
function isGeometryClosed($geometryShape)
{
    $isClosed = null;

    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $dataLength = count(java_values($geometryPath->getPathData()));
        if ($dataLength === 0) {
            continue;
        }

        $lastSegment = java_values($geometryPath->getPathData())[$dataLength - 1];
        $isClosed = $lastSegment->getPathCommand() === PathCommandType::Close;

        if ($isClosed === false) {
            return false;
        }
    }

    return $isClosed === true;
}
```

## **GeometryPath átalakítása java.awt.Shape típusra**

1. Hozzon létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/GeometryShape) osztályból.
2. Hozzon létre egy példányt a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) osztályból.
3. A [ShapeUtil](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ShapeUtil) segítségével konvertálja a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) példányt a [GeometryPath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/GeometryPath) példányra.
4. Alkalmazza az útvonalakat az alakzatra.

Ez a PHP kód – a fenti lépések megvalósítása – bemutatja a **GeometryPath**‑tól **GraphicsPath**‑ig terjedő konverziós folyamatot:

```php
  $pres = new Presentation();
  try {
    # Új alakzat létrehozása
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Az alakzat geometriai útvonalának lekérése
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Új grafikus útvonal létrehozása szöveggel
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Text in shape";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # Grafikus útvonal konvertálása geometriai útvonalra
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Új geometriai útvonal és az eredeti geometriai útvonal kombinációjának beállítása az alakzatra
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)

## **GYIK**

**Mi történik a kitöltéssel és a kontúrral a geometria cseréje után?**

A stílus az alakzatnál marad; csak a kontúr változik. A kitöltés és a kontúr automatikusan az új geometriára kerülnek alkalmazásra.

**Hogyan tudom helyesen elforgatni egy egyéni alakzatot a geometriai adataival együtt?**

Használja az alakzat [setRotation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/setrotation/) metódusát; a geometria az alakzattal együtt forgó, mivel az az alakzat saját koordináta‑rendszeréhez van kötve.

**Átalakíthatom‑e egy egyéni alakzatot képpé a végeredmény „lezárásához”?**

Igen. Exportálja a szükséges [slide](/slides/hu/php-java/convert-powerpoint-to-png/) területet vagy a [shape](/slides/hu/php-java/create-shape-thumbnails/) saját magát raszteres formátumba; ez egyszerűsíti a nehéz geometriai elemekkel való további munkát.