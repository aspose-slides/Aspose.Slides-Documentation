---
title: Dostosowywanie kształtów prezentacji w PHP
linktitle: Kształt niestandardowy
type: docs
weight: 20
url: /pl/php-java/custom-shape/
keywords:
- kształt niestandardowy
- dodaj kształt
- utwórz kształt
- zmień kształt
- geometria kształtu
- ścieżka geometryczna
- punkty ścieżki
- punkty edycji
- dodaj punkt
- usuń punkt
- operacja edycji
- zaokrąglony róg
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint za pomocą Aspose.Slides dla PHP poprzez Java: ścieżki geometryczne, zaokrąglone rogi, kształty złożone."
---
## **Overview**

Ten artykuł wyjaśnia, jak dostosować kształty prezentacji w Aspose.Slides poprzez edycję geometrii kształtu przy użyciu punktów kontrolnych i ścieżek geometrycznych. Pokazuje, jak korzystać z `GeometryPath` do modyfikacji istniejących kształtów, wykonywania podstawowych operacji edycji ścieżek, dodawania lub usuwania punktów oraz zastosowania zaktualizowanej geometrii do kształtu.

Pokazuje również, jak tworzyć kształty niestandardowe i złożone, budować kształty z zaokrąglonymi narożnikami, określać, czy geometria kształtu jest zamknięta, oraz konwertować pomiędzy `GeometryPath` a `java.awt.Shape` w dodatkowych scenariuszach dostosowywania geometrii.

## **Change a Shape Using Edit Points**

Rozważmy kwadrat. W PowerPoint, korzystając z **punktów kontrolnych**, możesz

* przesunąć róg kwadratu do wewnątrz lub na zewnątrz
* określić stopień krzywizny rogu lub punktu
* dodać nowe punkty do kwadratu
* manipulować punktami na kwadracie itp.

W zasadzie możesz wykonywać opisane zadania na dowolnym kształcie. Korzystając z punktów kontrolnych, możesz zmienić kształt lub utworzyć nowy kształt na podstawie istniejącego.

## **Shape Editing Tips**

![overview_image](custom_shape_0.png)

Zanim zaczniesz edytować kształty PowerPoint za pomocą punktów kontrolnych, warto rozważyć następujące kwestie dotyczące kształtów:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Gdy kształt jest zamknięty, nie ma punktu początkowego ani końcowego. Gdy jest otwarty, posiada początek i koniec.
* Wszystkie kształty składają się z co najmniej 2 punktów kotwiczących połączonych ze sobą liniami
* Linia może być prosta lub zakrzywiona. Punkty kotwiczące określają charakter linii.
* Punkty kotwiczące występują jako punkty narożne, proste lub płynne:
  * Punkt narożny to punkt, w którym 2 proste linie łączą się pod kątem.
  * Punkt płynny to punkt, w którym 2 uchwyty znajdują się w jednej prostej, a odcinki linii łączą się w płynną krzywą. W tym przypadku wszystkie uchwyty są oddalone od punktu kotwiczącego o równą odległość.
  * Punkt prosty to punkt, w którym 2 uchwyty znajdują się w jednej prostej, a odcinki linii łączą się w płynną krzywą. W tym przypadku uchwyty nie muszą być oddalone od punktu kotwiczącego o równą odległość.
* Przesuwając lub edytując punkty kotwiczące (co zmienia kąt linii), możesz zmienić wygląd kształtu.

Aby edytować kształty PowerPoint za pomocą punktów kontrolnych, **Aspose.Slides** udostępnia klasę [**GeometryPath**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/GeometryPath).

* Instancja [GeometryPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/GeometryPath) reprezentuje ścieżkę geometryczną obiektu [GeometryShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/geometryshape/).
* Aby pobrać `GeometryPath` z instancji `GeometryShape`, możesz użyć metody [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/pl/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Aby ustawić `GeometryPath` dla kształtu, możesz użyć następujących metod: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/geometryshape/#setGeometryPath) dla *kształtów jednorodnych* oraz [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/pl/php-java/aspose.slides/geometryshape/#setGeometryPaths) dla *kształtów złożonych*.
* Aby dodać segmenty, możesz użyć metod dostępnych w [GeometryPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/geometrypath/).
* Korzystając z metod [GeometryPath::setStroke](https://reference.aspose.com/slides/pl/php-java/aspose.slides/geometrypath/setstroke/) oraz [GeometryPath::setFillMode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/geometrypath/setfillmode/), możesz określić wygląd ścieżki geometrycznej.
* Korzystając z metody [GeometryPath::getPathData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/geometrypath/getpathdata/), możesz pobrać ścieżkę geometryczną `GeometryShape` jako tablicę segmentów.
* Aby uzyskać dodatkowe opcje dostosowywania geometrii kształtu, możesz przekonwertować [GeometryPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/geometrypath/) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
* Użyj metod [geometryPathToGraphicsPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapeutil/geometrypathtographicspath/) i [graphicsPathToGeometryPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapeutil/graphicspathtogeometrypath/) (z klasy [ShapeUtil](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ShapeUtil)), aby konwertować [GeometryPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/geometrypath/) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) i z powrotem.

## **Simple Editing Operations**

Ten kod PHP pokazuje, jak

**Dodaj linię** na koniec ścieżki

```php

```
**Dodaj linię** do określonej pozycji w ścieżce:

```php

```
**Dodaj krzywą Beziera stopnia trzeciego** na koniec ścieżki:

```php

```
**Dodaj krzywą Beziera stopnia trzeciego** do określonej pozycji w ścieżce:

```php

```
**Dodaj krzywą Beziera stopnia drugiego** na koniec ścieżki:

```php

```
**Dodaj krzywą Beziera stopnia drugiego** do określonej pozycji w ścieżce:

```php

```
**Dołącz podany łuk** do ścieżki:

```php

```
**Zamknij bieżącą figurę** ścieżki:

```php

```
**Ustaw pozycję następnego punktu**:

```php

```
**Usuń segment ścieżki** o podanym indeksie:

```php

```

## **Add Custom Points to a Shape**

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/GeometryShape) i ustaw typ [ShapeType::Rectangle](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ShapeType).
2. Pobierz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/GeometryPath) z kształtu.
3. Dodaj nowy punkt pomiędzy dwoma górnymi punktami ścieżki.
4. Dodaj nowy punkt pomiędzy dwoma dolnymi punktami ścieżki.
5. Zastosuj ścieżkę do kształtu.

Ten kod PHP pokazuje, jak dodać własne punkty do kształtu:

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

## **Remove Points from a Shape**

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/GeometryShape) i ustaw typ [ShapeType::Heart](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ShapeType).
2. Pobierz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/GeometryPath) z kształtu.
3. Usuń segment ścieżki.
4. Zastosuj ścieżkę do kształtu.

Ten kod PHP pokazuje, jak usunąć punkty z kształtu:

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

## **Create a Custom Shape**

1. Oblicz punkty dla kształtu.
2. Utwórz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/GeometryPath).
3. Wypełnij ścieżkę punktami.
4. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/GeometryShape).
5. Zastosuj ścieżkę do kształtu.

Ten kod Java pokazuje, jak utworzyć własny kształt:

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

## **Create a Composite Custom Shape**

  1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/GeometryShape).
  2. Utwórz pierwszą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/GeometryPath).
  3. Utwórz drugą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/GeometryPath).
  4. Zastosuj ścieżki do kształtu.

Ten kod PHP pokazuje, jak utworzyć złożony własny kształt:

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

## **Create a Custom Shape with Curved Corners**

Ten kod PHP pokazuje, jak utworzyć własny kształt z zaokrąglonymi narożnikami (do wnętrza);

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

## **Find Out If a Shape Geometry Is Closed**

Kształt zamknięty definiuje się jako taki, w którym wszystkie jego boki łączą się, tworząc jednolitą granicę bez przerw. Taki kształt może być prostą formą geometryczną lub złożonym, własnym konturem. Poniższy przykład kodu pokazuje, jak sprawdzić, czy geometria kształtu jest zamknięta:

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

## **Convert GeometryPath to java.awt.Shape** 

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/GeometryShape).
2. Utwórz instancję klasy [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
3. Przekonwertuj instancję [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) na instancję [GeometryPath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/GeometryPath), używając klasy [ShapeUtil](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ShapeUtil).
4. Zastosuj ścieżki do kształtu.

Ten kod PHP — implementacja powyższych kroków — demonstruje proces konwersji **GeometryPath** na **GraphicsPath**:

```php
  $pres = new Presentation();
  try {
    # Utwórz nowy kształt
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Pobierz ścieżkę geometryczną kształtu
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Utwórz nową ścieżkę graficzną z tekstem
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
    # Konwertuj ścieżkę graficzną na ścieżkę geometryczną
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Ustaw kombinację nowej ścieżki geometrycznej i oryginalnej ścieżki geometrycznej dla kształtu
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Co się stanie z wypełnieniem i obramowaniem po zamianie geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się tylko kontur. Wypełnienie i obramowanie są automatycznie stosowane do nowej geometrii.

**Jak poprawnie obrócić własny kształt razem z jego geometrią?**

Użyj metody [setRotation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/setrotation/) kształtu; geometria obraca się razem z kształtem, ponieważ jest związana z własnym układem współrzędnych kształtu.

**Czy mogę przekonwertować własny kształt na obraz, aby „zablokować” wynik?**

Tak. Wyeksportuj odpowiedni obszar [slajdu](/slides/pl/php-java/convert-powerpoint-to-png/) lub sam [kształt](/slides/pl/php-java/create-shape-thumbnails/) do formatu rastrowego; ułatwia to dalszą pracę z rozbudowanymi geometriami.