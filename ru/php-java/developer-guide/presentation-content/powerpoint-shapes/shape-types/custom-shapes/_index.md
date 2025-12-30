---
title: Настройка фигур презентаций в PHP
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
- геометрический путь
- точки пути
- точки редактирования
- добавить точку
- удалить точку
- операция редактирования
- скругленный угол
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создавайте и настраивайте фигуры в презентациях PowerPoint с помощью Aspose.Slides для PHP через Java: геометрические пути, скруглённые углы, составные фигуры."
---

## **Изменение фигуры с помощью точек редактирования**
Рассмотрим квадрат. В PowerPoint, используя **точки редактирования**, вы можете

* перемещать угол квадрата внутрь или наружу
* задавать кривизну для угла или точки
* добавлять новые точки к квадрату
* управлять точками квадрата и т.д.

По сути, вы можете выполнять описанные действия с любой фигурой. С помощью точек редактирования вы можете изменить фигуру или создать новую фигуру из существующей.

## **Советы по редактированию фигур**

![overview_image](custom_shape_0.png)

Прежде чем приступить к редактированию фигур PowerPoint через точки редактирования, обратите внимание на следующие особенности фигур:

* Фигура (или её путь) может быть закрытой или открытой.
* Когда фигура закрыта, у неё нет начала и конца. Когда фигура открыта, у неё есть начало и конец. 
* Все фигуры состоят минимум из 2 точек‑якорей, соединённых линиями.
* Линия может быть прямой или кривой. Точки‑якоря определяют характер линии. 
* Точки‑якоря бывают угловыми, прямыми или сглаженными:
  * Угловая точка – это точка, где две прямые линии соединяются под углом. 
  * Сглаженная точка – это точка, где два ручных узла находятся на одной прямой, и сегменты линии соединяются плавной кривой. В этом случае все ручные узлы находятся на одинаковом расстоянии от точки‑якоря. 
  * Прямая точка – это точка, где два ручных узла находятся на одной прямой, и сегменты линии соединяются плавной кривой. В этом случае расстояния ручных узлов от точки‑якоря могут различаться. 
* Перемещая или редактируя точки‑якоря (что изменяет угол линий), вы меняете внешний вид фигуры. 

Для редактирования фигур PowerPoint через точки редактирования **Aspose.Slides** предоставляет класс [**GeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) и интерфейс [**IGeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) представляет геометрический путь объекта [IGeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape).
* Чтобы получить `GeometryPath` из экземпляра `IGeometryShape`, используйте метод [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#getGeometryPaths--).
* Чтобы задать `GeometryPath` для фигуры, используйте методы: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) для *сплошных фигур* и [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) для *сложных фигур*.
* Чтобы добавить сегменты, используйте методы из [IGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).
* С помощью методов [IGeometryPath.setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setStroke-boolean-) и [IGeometryPath.setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setFillMode-byte-) можно задать отображение геометрического пути.
* Метод [IGeometryPath.getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#getPathData--) позволяет получить геометрический путь `GeometryShape` в виде массива сегментов пути.
* Чтобы получить дополнительные параметры настройки геометрии фигуры, можно преобразовать [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) в [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
* Используйте методы [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) и [graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (из класса [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil)) для преобразования [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) в [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) и обратно.

## **Простые операции редактирования**

Этот PHP‑код показывает, как

**Добавить линию** в конец пути
```php
```

**Добавить линию** в указанную позицию пути:
```php

```

**Добавить кубическую кривую Безье** в конец пути:
```php

```

**Добавить кубическую кривую Безье** в указанную позицию пути:
```php

```

**Добавить квадратную кривую Безье** в конец пути:
```php

```

**Добавить квадратную кривую Безье** в указанную позицию пути:
```php

```

**Присоединить заданную дугу** к пути:
```php

```

**Закрыть текущую фигуру** пути:
I’m unable to translate the comments because the code block you provided is empty. Could you please share the PHP code (including its comments) that you’d like translated into Russian?

**Задать позицию для следующей точки**:
I’m unable to translate the comments because the provided code block is empty. Please share the PHP code (including its comments) that you’d like translated into Russian.

**Удалить сегмент пути** по заданному индексу:
The code block you provided is empty, so there are no comments to translate. Please share the PHP code (including its comments) that you’d like translated into Russian.


## **Добавить пользовательские точки к фигуре**
1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) и задайте тип [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) из фигуры.
3. Добавьте новую точку между двумя верхними точками пути.
4. Добавьте новую точку между двумя нижними точками пути.
5. Примените путь к фигуре.

Этот PHP‑код показывает, как добавить пользовательские точки к фигуре:
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

## **Удалить точки из фигуры**

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) и задайте тип [ShapeType::Heart](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) из фигуры.
3. Удалите сегмент пути.
4. Примените путь к фигуре.

Этот PHP‑код показывает, как удалить точки из фигуры:
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

## **Создать пользовательскую фигуру**

1. Вычислите точки для фигуры.
2. Создайте экземпляр класса [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
3. Заполните путь точками.
4. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
5. Примените путь к фигуре.

Этот Java‑пример показывает, как создать пользовательскую фигуру:
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


## **Создать составную пользовательскую фигуру**

  1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
  2. Создайте первый экземпляр класса [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
  3. Создайте второй экземпляр класса [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
  4. Примените пути к фигуре.

Этот PHP‑код показывает, как создать составную пользовательскую фигуру:
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

## **Создать пользовательскую фигуру со скруглёнными углами**

Этот PHP‑код показывает, как создать пользовательскую фигуру со скруглёнными (внутренними) углами:
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


## **Определить, является ли геометрия фигуры закрытой**

Закрытая фигура определяется как такая, у которой все стороны соединены, образуя единую границу без разрывов. Это может быть простая геометрическая форма или сложный пользовательский контур. Пример кода показывает, как проверить, закрыта ли геометрия фигуры:
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


## **Преобразовать GeometryPath в java.awt.Shape** 

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
2. Создайте экземпляр класса [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
3. Преобразуйте экземпляр [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) в экземпляр [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) с помощью [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil).
4. Примените пути к фигуре.

Этот PHP‑код, реализующий описанные шаги, демонстрирует процесс преобразования **GeometryPath** в **GraphicsPath**:
```php
  $pres = new Presentation();
  try {
    # Создать новую фигуру
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Получить путь геометрии фигуры
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
    # Установить комбинацию нового геометрического пути и исходного геометрического пути для фигуры
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

Стиль остаётся привязанным к фигуре; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно вращать пользовательскую фигуру вместе с её геометрией?**

Используйте метод [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setrotation/) фигуры; геометрия вращается вместе с фигурой, поскольку привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую фигуру в изображение, чтобы «запечатлеть» результат?**

Да. Экспортируйте нужный [slide](/slides/ru/php-java/convert-powerpoint-to-png/) или саму [shape](/slides/ru/php-java/create-shape-thumbnails/) в растровый формат; это упростит дальнейшую работу с тяжёлыми геометриями.