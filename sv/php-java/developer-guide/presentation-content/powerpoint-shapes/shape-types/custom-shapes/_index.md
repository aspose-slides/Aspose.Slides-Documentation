---
title: Anpassa presentationsformer i PHP
linktitle: Anpassad form
type: docs
weight: 20
url: /sv/php-java/custom-shape/
keywords:
- anpassad form
- lägg till form
- skapa form
- ändra form
- formgeometri
- geometribana
- banpunkter
- redigera punkter
- lägg till punkt
- ta bort punkt
- redigeringsoperation
- rundat hörn
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Skapa och anpassa former i PowerPoint-presentationer med Aspose.Slides för PHP via Java: geometribanor, rundade hörn, sammansatta former."
---
## **Översikt**

Denna artikel förklarar hur man anpassar presentationsformer i Aspose.Slides genom att redigera formgeometri via redigeringspunkter och geometriska banor. Den visar hur man arbetar med `GeometryPath` för att modifiera befintliga former, utföra grundläggande banredigeringsoperationer, lägga till eller ta bort punkter och tillämpa uppdaterad geometri på en form igen.

Den demonstrerar också hur man skapar anpassade och sammansatta former, bygger former med rundade hörn, avgör om en formgeometri är sluten och konverterar mellan `GeometryPath` och `java.awt.Shape` för ytterligare geometri‑anpassningsscenarier.

## **Ändra en form med redigeringspunkter**
Tänk dig en kvadrat. I PowerPoint, med **redigeringspunkter**, kan du  

* flytta kvadratens hörn inåt eller utåt  
* ange krökning för ett hörn eller en punkt  
* lägga till nya punkter till kvadraten  
* manipulera punkter på kvadraten osv.  

I princip kan du utföra dessa uppgifter på vilken form som helst. Med redigeringspunkter kan du ändra en befintlig form eller skapa en ny form från en befintlig form.  

## **Tips för formredigering**

![översiktsbild](custom_shape_0.png)

Innan du börjar redigera PowerPoint‑former via redigeringspunkter kan det vara bra att tänka på följande om former:

* En form (eller dess bana) kan vara antingen sluten eller öppen.  
* När en form är sluten saknar den en start‑ eller slutpunkt. När en form är öppen har den en början och ett slut.  
* Alla former består av minst två ankare‑punkter som är länkade till varandra med linjer.  
* En linje är antingen rak eller kurvig. Ankare‑punkter bestämmer linjens natur.  
* Ankare‑punkter finns som hörnpunkter, raka punkter eller släta punkter:  
  * En hörnpunkt är en punkt där två raka linjer möts i en vinkel.  
  * En slät punkt är en punkt där två handtag ligger i en rak linje och linjesegmenten förenas i en mjuk kurva. I detta fall är alla handtag separerade från ankare‑punkten med lika avstånd.  
  * En rak punkt är en punkt där två handtag ligger i en rak linje och linjesegmenten förenas i en mjuk kurva. I detta fall behöver handtagen inte vara separerade från ankare‑punkten med lika avstånd.  
* Genom att flytta eller redigera ankare‑punkter (vilket ändrar linjernas vinklar) kan du förändra hur en form ser ut.  

För att redigera PowerPoint‑former via redigeringspunkter tillhandahåller **Aspose.Slides** klassen [**GeometryPath**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/GeometryPath).

* En [GeometryPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/GeometryPath)-instans representerar en geometrisk bana för objektet [GeometryShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/geometryshape/).  
* För att hämta `GeometryPath` från ett `GeometryShape`‑objekt kan du använda metoden [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/sv/php-java/aspose.slides/geometryshape/#getGeometryPaths).  
* För att sätta `GeometryPath` för en form kan du använda dessa metoder: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/geometryshape/#setGeometryPath) för *solida former* och [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/sv/php-java/aspose.slides/geometryshape/#setGeometryPaths) för *sammansatta former*.  
* För att lägga till segment kan du använda metoderna under [GeometryPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/geometrypath/).  
* Med metoderna [GeometryPath::setStroke](https://reference.aspose.com/slides/sv/php-java/aspose.slides/geometrypath/setstroke/) och [GeometryPath::setFillMode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/geometrypath/setfillmode/) kan du ange utseendet för en geometrisk bana.  
* Med metoden [GeometryPath::getPathData](https://reference.aspose.com/slides/sv/php-java/aspose.slides/geometrypath/getpathdata/) kan du hämta geometrisk bana för ett `GeometryShape` som en array av bansegment.  
* För att få tillgång till ytterligare alternativ för anpassning av formgeometri kan du konvertera [GeometryPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/geometrypath/) till [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).  
* Använd [geometryPathToGraphicsPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapeutil/geometrypathtographicspath/) och [graphicsPathToGeometryPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapeutil/graphicspathtogeometrypath/) (från klassen [ShapeUtil](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ShapeUtil)) för att konvertera [GeometryPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/geometrypath/) till [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) fram och tillbaka.

## **Enkla redigeringsoperationer**

Den här PHP‑koden visar hur du  

**Lägger till en linje** i slutet av en bana  

```php

```
**Lägger till en linje** på en specificerad position i en bana:  

```php

```
**Lägger till en kubisk Bézier‑kurva** i slutet av en bana:  

```php

```
**Lägger till en kubisk Bézier‑kurva** på en specificerad position i en bana:  

```php

```
**Lägger till en kvadratisk Bézier‑kurva** i slutet av en bana:  

```php

```
**Lägger till en kvadratisk Bézier‑kurva** på en specificerad position i en bana:  

```php

```
**Lägger till en given båge** till en bana:  

```php

```
**Stänger den aktuella figuren** i en bana:  

```php

```
**Sätter positionen för nästa punkt**:  

```php

```
**Tar bort ett bansegment** på ett givet index:  

```php

```

## **Lägg till anpassade punkter i en form**
1. Skapa en instans av [GeometryShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/GeometryShape)-klassen och ange typen [ShapeType::Rectangle](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ShapeType).  
2. Hämta en instans av [GeometryPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/GeometryPath)-klassen från formen.  
3. Lägg till en ny punkt mellan de två övre punkterna på banan.  
4. Lägg till en ny punkt mellan de två nedre punkterna på banan.  
5. Tillämpa banan på formen.  

Den här PHP‑koden visar hur du lägger till anpassade punkter i en form:  

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
![exempel1_bild](custom_shape_1.png)

## **Ta bort punkter från en form**

1. Skapa en instans av [GeometryShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/GeometryShape)-klassen och ange typen [ShapeType::Heart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ShapeType).  
2. Hämta en instans av [GeometryPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/GeometryPath)-klassen från formen.  
3. Ta bort segmentet för banan.  
4. Tillämpa banan på formen.  

Den här PHP‑koden visar hur du tar bort punkter från en form:  

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
![exempel2_bild](custom_shape_2.png)

## **Skapa en anpassad form**

1. Beräkna punkterna för formen.  
2. Skapa en instans av [GeometryPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/GeometryPath)-klassen.  
3. Fyll banan med punkterna.  
4. Skapa en instans av [GeometryShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/GeometryShape)-klassen.  
5. Tillämpa banan på formen.  

Den här Java‑koden visar hur du skapar en anpassad form:  

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
![exempel3_bild](custom_shape_3.png)


## **Skapa en sammansatt anpassad form**

1. Skapa en instans av [GeometryShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/GeometryShape)-klassen.  
2. Skapa en första instans av [GeometryPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/GeometryPath)-klassen.  
3. Skapa en andra instans av [GeometryPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/GeometryPath)-klassen.  
4. Tillämpa banorna på formen.  

Den här PHP‑koden visar hur du skapar en sammansatt anpassad form:  

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
![exempel4_bild](custom_shape_4.png)

## **Skapa en anpassad form med rundade hörn**

Den här PHP‑koden visar hur du skapar en anpassad form med rundade (inåtriktade) hörn;  

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

## **Ta reda på om en formgeometri är sluten**

En sluten form definieras som en där alla sidor är sammanlänkade och bildar en enda gräns utan hål. En sådan form kan vara en enkel geometrisk figur eller en komplex anpassad kontur. Följande kodexempel visar hur du kontrollerar om en formgeometri är sluten:  

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

## **Konvertera GeometryPath till java.awt.Shape** 

1. Skapa en instans av [GeometryShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/GeometryShape)-klassen.  
2. Skapa en instans av [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html)-klassen.  
3. Konvertera [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html)-instansen till [GeometryPath](https://reference.aspose.com/slides/sv/php-java/aspose.slides/GeometryPath)-instansen med hjälp av [ShapeUtil](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ShapeUtil).  
4. Tillämpa banorna på formen.  

Den här PHP‑koden—en implementering av stegen ovan—demonstrerar konverteringsprocessen **GeometryPath** till **GraphicsPath**:  

```php
  $pres = new Presentation();
  try {
    # Skapa ny form
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Hämta geometribana för formen
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Skapa ny grafikbana med text
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
    # Konvertera grafikbana till geometribana
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Ange kombination av ny geometribana och ursprunglig geometribana till formen
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![exempel5_bild](custom_shape_5.png)

## **Vanliga frågor**

**Vad händer med fyllning och kontur efter att geometrin har ersatts?**  
Stilen förblir knuten till formen; endast konturen ändras. Fyllning och kontur appliceras automatiskt på den nya geometrin.

**Hur roterar jag en anpassad form korrekt tillsammans med dess geometri?**  
Använd formens [setRotation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/setrotation/)‑metod; geometrin roterar med formen eftersom den är bunden till formens eget koordinatsystem.

**Kan jag konvertera en anpassad form till en bild för att \"låsa\" resultatet?**  
Ja. Exportera det önskade [slide](/slides/sv/php-java/convert-powerpoint-to-png/)-området eller själva [shape](/slides/sv/php-java/create-shape-thumbnails/) till ett rasterformat; detta förenklar vidare arbete med tunga geometrier.