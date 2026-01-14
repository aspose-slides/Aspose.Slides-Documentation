---
title: Настройка фигур в презентациях с помощью PHP
linktitle: Пользовательская фигура
type: docs
weight: 20
url: /ru/php-java/custom-shape/
keywords:
- пользовательская фигура
- добавить фигуру
- создать фигуру
- изменить фигуру
- геометрия фигуры
- путь геометрии
- точки пути
- точки редактирования
- добавить точку
- удалить точку
- операция редактирования
- закруглённый угол
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создавайте и настраивайте фигуры в презентациях PowerPoint с помощью Aspose.Slides для PHP через Java: геометрические пути, закруглённые углы, составные фигуры."
---

## **Изменение формы с помощью точек редактирования**
Рассмотрим квадрат. В PowerPoint с помощью **точек редактирования** вы можете 

* переместить угол квадрата внутрь или наружу
* задать кривизну угла или точки
* добавить новые точки к квадрату
* управлять точками на квадрате и т.д. 

По сути, вы можете выполнять описанные задачи с любой формой. Используя точки редактирования, вы можете изменить форму или создать новую форму из существующей. 

## **Советы по редактированию форм**

![overview_image](custom_shape_0.png)

Прежде чем начать редактировать формы PowerPoint с помощью точек редактирования, стоит обратить внимание на следующие моменты о формах:

* Форма (или её путь) может быть закрытой или открытой.
* Когда форма закрыта, у неё нет начальной или конечной точки. Когда форма открыта, у неё есть начало и конец. 
* Все формы состоят как минимум из 2 опорных точек, соединённых линиями
* Линия может быть прямой или кривой. Опорные точки определяют характер линии. 
* Опорные точки могут быть угловыми, прямыми или сглаженными:
  * Угловая точка — это точка, где две прямые линии соединяются под углом. 
  * Сглаженная точка — это точка, где два рукоятки находятся на одной прямой и отрезки линии соединяются плавной кривой. В этом случае все рукоятки находятся на одинаковом расстоянии от опорной точки. 
  * Прямая точка — это точка, где два рукоятки находятся на одной прямой, и отрезки линии соединяются плавной кривой. В этом случае рукоятки не обязаны находиться на одинаковом расстоянии от опорной точки. 
* Перемещая или редактируя опорные точки (что изменяет угол линий), вы можете изменить внешний вид формы. 

Для редактирования форм PowerPoint через точки редактирования **Aspose.Slides** предоставляет класс [**GeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) представляет геометрический путь объекта [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) .
* Чтобы получить `GeometryPath` из экземпляра `GeometryShape`, можно использовать метод [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Чтобы задать `GeometryPath` для формы, можно использовать эти методы: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) для *сплошных форм* и [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) для *композитных форм*.
* Чтобы добавить сегменты, можно использовать методы из [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) .
* С помощью методов [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/setstroke/) и [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/setfillmode/) можно задать внешний вид геометрического пути.
* С помощью метода [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/getpathdata/) можно получить геометрический путь `GeometryShape` в виде массива сегментов пути.
* Чтобы получить доступ к дополнительным параметрам настройки геометрии формы, можно преобразовать [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) в [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html)
* Используйте методы [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/aspose.slides/shapeutil/geometrypathtographicspath/) и [graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/shapeutil/graphicspathtogeometrypath/) (из класса [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil) ) для преобразования [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) в [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) и обратно.

## **Простые операции редактирования**

Этот PHP‑код показывает, как

**Добавить линию** в конец пути
```php

```

**Добавить линию** в указанную позицию на пути:
```php

```

**Добавить кубическую кривую Безье** в конец пути:
```php

```

**Добавить кубическую кривую Безье** в указанную позицию на пути:
```php

```

**Добавить квадратичную кривую Безье** в конец пути:
```php

```

**Добавить квадратичную кривую Безье** в указанную позицию на пути:
```php

```

**Добавить заданную дугу** к пути:
```php

```

**Замкнуть текущую фигуру** пути:
```php

```

**Установить позицию для следующей точки**:
```php

```

**Удалить сегмент пути** по заданному индексу:
```php

```


## **Добавление пользовательских точек к форме**
1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) и задайте тип [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType) .
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) из формы.
3. Добавьте новую точку между двумя верхними точками пути.
4. Добавьте новую точку между двумя нижними точками пути.
5. Примените путь к форме.

Этот PHP‑код показывает, как добавить пользовательские точки к форме:
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

## **Удаление точек из формы**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) и задайте тип [ShapeType::Heart](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType) .
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) из формы.
3. Удалите сегмент пути.
4. Примените путь к форме.

Этот PHP‑код показывает, как удалить точки из формы:
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

## **Создание пользовательской формы**

1. Рассчитайте точки для формы.
2. Создайте экземпляр класса [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) .
3. Заполните путь точками.
4. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) .
5. Примените путь к форме.

Этот пример на Java показывает, как создать пользовательскую форму:
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

## **Создание составной пользовательской формы**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) .
2. Создайте первый экземпляр класса [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) .
3. Создайте второй экземпляр класса [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) .
4. Примените пути к форме.

Этот PHP‑код показывает, как создать составную пользовательскую форму:
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

## **Создание пользовательской формы со скруглёнными углами**

Этот PHP‑код показывает, как создать пользовательскую форму со скруглёнными углами (внутренняя сторона);
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


## **Определение, является ли геометрия формы замкнутой**

Замкнутая форма определяется как такая, у которой все стороны соединены, образуя единую границу без зазоров. Такая форма может быть простой геометрической фигурой или сложным пользовательским контуром. Следующий пример кода показывает, как проверить, является ли геометрия формы замкнутой:
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


## **Преобразование GeometryPath в java.awt.Shape** 

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) .
2. Создайте экземпляр класса [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) .
3. Преобразуйте экземпляр [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) в экземпляр [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) с помощью [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil) .
4. Примените пути к форме.

Этот PHP‑код — реализация вышеуказанных шагов — демонстрирует процесс преобразования **GeometryPath** в **GraphicsPath**:
```php
  $pres = new Presentation();
  try {
    # Создать новую форму
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Получить геометрический путь формы
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Создать новый графический путь с текстом
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
    # Преобразовать графический путь в геометрический путь
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Установить комбинацию нового геометрического пути и исходного геометрического пути для формы
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![example5_image](custom_shape_5.png)

## **FAQ**

**Что произойдёт с заливкой и контурами после замены геометрии?**

Стиль остаётся привязанным к форме; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно вращать пользовательскую форму вместе с её геометрией?**

Используйте метод формы [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setrotation/) , тогда геометрия будет вращаться вместе с формой, так как она привязана к системе координат самой формы.

**Могу ли я преобразовать пользовательскую форму в изображение, чтобы “зафиксировать” результат?**

Да. Экспортируйте требуемую область [slide](/slides/ru/php-java/convert-powerpoint-to-png/) или саму [shape](/slides/ru/php-java/create-shape-thumbnails/) в растровый формат; это упрощает дальнейшую работу с тяжёлыми геометриями.