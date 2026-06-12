---
title: Přizpůsobení tvarů prezentace v PHP
linktitle: Vlastní tvar
type: docs
weight: 20
url: /cs/php-java/custom-shape/
keywords:
- vlastní tvar
- přidat tvar
- vytvořit tvar
- změnit tvar
- geometrie tvaru
- geometrická cesta
- body cesty
- editační body
- přidat bod
- odebrat bod
- operace úpravy
- zakřivený roh
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte tvary v prezentacích PowerPoint pomocí Aspose.Slides pro PHP přes Java: geometrické cesty, zakřivené rohy, složené tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary prezentace v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s `GeometryPath` k úpravě existujících tvarů, provádět základní operace úpravy cesty, přidávat nebo odebírat body a aplikovat aktualizovanou geometrii zpět na tvar.

Také demonstruje, jak vytvořit vlastní a složené tvary, stavět tvary s zakřivenými rohy, určit, zda je geometrie tvaru uzavřená, a převádět mezi `GeometryPath` a `java.awt.Shape` pro další scénáře přizpůsobení geometrie.

## **Změna tvaru pomocí editačních bodů**
Uvažujme čtverec. V PowerPointu můžete pomocí **edit points**:

* posunout roh čtverce dovnitř nebo ven
* specifikovat zakřivení rohu nebo bodu
* přidat nové body do čtverce
* manipulovat body na čtverci atd.

V podstatě můžete provádět popsané úkoly na libovolném tvaru. Pomocí editačních bodů můžete měnit tvar nebo vytvořit nový tvar z existujícího tvaru.

## **Tipy pro úpravu tvarů**

![overview_image](custom_shape_0.png)

Před tím, než začnete upravovat tvary PowerPointu pomocí editačních bodů, můžete zvážit následující body o tvarech:

* Tvar (nebo jeho cesta) může být buď uzavřený, nebo otevřený.
* Když je tvar uzavřený, postrádá počáteční nebo koncový bod. Když je otevřený, má začátek i konec.
* Všechny tvary se skládají alespoň ze 2 kotevních bodů propojených čarami
* Čára je buď přímá, nebo zakřivená. Kotevní body určují povahu čáry.
* Kotevní body existují jako rohové body, přímé body nebo hladké body:
  * Rohový bod je bod, kde se dva přímé úseky setkají pod úhlem.
  * Hladký bod je bod, kde jsou dva úchyty v jedné přímce a segmenty čáry se spojují do hladké křivky. V tomto případě jsou všechny úchyty od kotevního bodu vzdáleny stejnou vzdáleností.
  * Přímý bod je bod, kde jsou dva úchyty v jedné přímce a segmenty čáry se spojují do hladké křivky. V tomto případě nemusí být úchyty od kotevního bodu vzdáleny stejně.
* Přesouváním nebo úpravou kotevních bodů (což mění úhel čar) můžete změnit vzhled tvaru.

Pro úpravu tvarů PowerPointu pomocí editačních bodů poskytuje **Aspose.Slides** třídu [**GeometryPath**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/GeometryPath).

* Instance [GeometryPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/GeometryPath) představuje geometrickou cestu objektu [GeometryShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/geometryshape/) .
* Pro získání`GeometryPath` z instance `GeometryShape` můžete použít metodu [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/cs/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Pro nastavení `GeometryPath` pro tvar můžete použít tyto metody: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/geometryshape/#setGeometryPath) pro *plné tvary* a [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/cs/php-java/aspose.slides/geometryshape/#setGeometryPaths) pro *složité tvary*.
* Pro přidání segmentů můžete použít metody v rámci [GeometryPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/geometrypath/) .
* Pomocí metod [GeometryPath::setStroke](https://reference.aspose.com/slides/cs/php-java/aspose.slides/geometrypath/setstroke/) a [GeometryPath::setFillMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/geometrypath/setfillmode/) můžete nastavit vzhled geometrické cesty.
* Metodou [GeometryPath::getPathData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/geometrypath/getpathdata/) můžete získat geometrickou cestu `GeometryShape` jako pole segmentů cesty.
* Pro přístup k dalším možnostem přizpůsobení geometrie tvaru můžete převést [GeometryPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/geometrypath/) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html)
* Použijte [geometryPathToGraphicsPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapeutil/geometrypathtographicspath/) a [graphicsPathToGeometryPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapeutil/graphicspathtogeometrypath/) (z třídy [ShapeUtil](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ShapeUtil) ) k převodu [GeometryPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/geometrypath/) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) a zpět.

## **Jednoduché operace úpravy**

Tento PHP kód vám ukazuje, jak

**Přidat čáru** na konec cesty

```php

```
**Přidat čáru** na určenou pozici v cestě:

```php

```
**Přidat kubickou Bézierovu křivku** na konec cesty:

```php

```
**Přidat kubickou Bézierovu křivku** na určenou pozici v cestě:

```php

```
**Přidat kvadratickou Bézierovu křivku** na konec cesty:

```php

```
**Přidat kvadratickou Bézierovu křivku** na určenou pozici v cestě:

```php

```
**Připojit daný oblouk** k cestě:

```php

```
**Uzavřít aktuální útvar** cesty:

```php

```
**Nastavit pozici pro další bod**:

```php

```
**Odstranit segment cesty** na daném indexu:

```php

```

## **Přidat vlastní body do tvaru**
1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/GeometryShape) a nastavte typ [ShapeType::Rectangle](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ShapeType) .
2. Získejte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/GeometryPath) ze tvaru.
3. Přidejte nový bod mezi dvěma horními body v cestě.
4. Přidejte nový bod mezi dvěma spodními body v cestě.
5. Aplikujte cestu na tvar.

Tento PHP kód vám ukazuje, jak přidat vlastní body do tvaru:

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

## **Odstranit body z tvaru**

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/GeometryShape) a nastavte typ [ShapeType::Heart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ShapeType) .
2. Získejte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/GeometryPath) ze tvaru.
3. Odstraňte segment cesty.
4. Aplikujte cestu na tvar.

Tento PHP kód vám ukazuje, jak odstranit body z tvaru:

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

## **Vytvořit vlastní tvar**

1. Vypočítejte body pro tvar.
2. Vytvořte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/GeometryPath) .
3. Naplněte cestu body.
4. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/GeometryShape) .
5. Aplikujte cestu na tvar.

Tento Java vám ukazuje, jak vytvořit vlastní tvar:

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


## **Vytvořit složený vlastní tvar**

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/GeometryShape) .
2. Vytvořte první instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/GeometryPath) .
3. Vytvořte druhou instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/GeometryPath) .
4. Aplikujte cesty na tvar.

Tento PHP kód vám ukazuje, jak vytvořit složený vlastní tvar:

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

## **Vytvořit vlastní tvar s zakřivenými rohy**

Tento PHP kód vám ukazuje, jak vytvořit vlastní tvar s zakřivenými rohy (dovnitř);

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

## **Zjistit, zda je geometrie tvaru uzavřená**

Uzavřený tvar je definován jako takový, kde se všechny jeho strany spojují a tvoří jedinou hranici bez mezer. Takový tvar může být jednoduchý geometrický útvar nebo složitý vlastní obrys. Následující ukázka kódu ukazuje, jak zkontrolovat, zda je geometrie tvaru uzavřená:

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

## **Převést GeometryPath na java.awt.Shape** 

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/GeometryShape) .
2. Vytvořte instanci třídy [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) .
3. Převést instanci [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) na instanci [GeometryPath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/GeometryPath) pomocí [ShapeUtil](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ShapeUtil) .
4. Aplikujte cesty na tvar.

Tento PHP kód — implementace výše uvedených kroků — ukazuje proces konverze **GeometryPath** na **GraphicsPath**:

```php
  $pres = new Presentation();
  try {
    # Vytvořit nový tvar
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Získat geometrickou cestu tvaru
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Vytvořit novou grafickou cestu s textem
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
    # Převést grafickou cestu na geometrickou cestu
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Nastavit kombinaci nové geometrické cesty a původní geometrické cesty pro tvar
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstane u tvaru; mění se pouze kontura. Výplň a obrys jsou automaticky aplikovány na novou geometrii.

**Jak správně otočit vlastní tvar spolu s jeho geometrií?**

Použijte metodu [setRotation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/setrotation/) tvaru; geometrie se otáčí s tvarem, protože je svázána s vlastním souřadnicovým systémem tvaru.

**Mohu převést vlastní tvar na obrázek, aby byl „uzamčen“ výsledek?**

Ano. Exportujte požadovanou [slide](/slides/cs/php-java/convert-powerpoint-to-png/) oblast nebo samotný [shape](/slides/cs/php-java/create-shape-thumbnails/) do rastrového formátu; to usnadní další práci s těžkými geometriemi.