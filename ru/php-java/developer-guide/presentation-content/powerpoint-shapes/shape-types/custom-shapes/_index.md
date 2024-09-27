---
title: Пользовательская Форма
type: docs
weight: 20
url: /ru/php-java/custom-shape/
keywords: "Форма PowerPoint, пользовательская форма, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Добавление пользовательской формы в презентацию PowerPoint"
---

# Изменение Форма с Использованием Точек Редактирования
Рассмотрим квадрат. В PowerPoint с помощью **точек редактирования** вы можете 

* переместить угол квадрата внутрь или наружу
* указать кривизну для угла или точки
* добавить новые точки в квадрат
* манипулировать точками на квадрате и т.д.

По сути, вы можете выполнять описанные задачи с любой формой. Используя точки редактирования, вы можете изменить форму или создать новую форму на основе существующей.

## **Советы по Редактированию Форм**

![overview_image](custom_shape_0.png)

Прежде чем начать редактировать формы PowerPoint с помощью точек редактирования, вы можете учесть следующие моменты о формах:

* Форма (или ее контур) может быть закрытой или открытой.
* Когда форма закрыта, у нее нет начальной или конечной точки. Когда форма открыта, у нее есть начало и конец.
* Все формы состоят как минимум из 2 якорных точек, связанных друг с другом линиями.
* Линия может быть либо прямой, либо изогнутой. Якорные точки определяют характер линии.
* Якорные точки могут быть угловыми, прямыми или гладкими:
  * Угловая точка — это точка, где соединяются 2 прямые линии под углом.
  * Гладкая точка — это точка, где 2 ручки находятся в прямой линии, а отрезки линии соединяются в плавной кривой. В этом случае все ручки отделены от якорной точки на равное расстояние.
  * Прямая точка — это точка, где 2 ручки находятся в прямой линии, и отрезки этой линии соединяются в плавной кривой. В этом случае ручки не обязательно должны быть отделены от якорной точки на равное расстояние.
* Перемещая или редактируя якорные точки (что изменяет угол линий), вы можете изменить внешний вид формы.

Чтобы редактировать формы PowerPoint с помощью точек редактирования, **Aspose.Slides** предоставляет класс [**GeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) и интерфейс [**IGeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) представляет собой геометрический путь объекта [IGeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape).
* Чтобы получить `GeometryPath` из экземпляра `IGeometryShape`, вы можете использовать метод [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#getGeometryPaths--).
* Чтобы установить `GeometryPath` для формы, вы можете использовать эти методы: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) для *сплошных форм* и [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) для *составных форм*.
* Чтобы добавить сегменты, вы можете использовать методы из [IGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath).
* Используя методы [IGeometryPath.setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setStroke-boolean-) и [IGeometryPath.setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setFillMode-byte-), вы можете установить внешний вид для геометрического пути.
* Используя метод [IGeometryPath.getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#getPathData--), вы можете получить геометрический путь формы `GeometryShape` в виде массива сегментов пути.
* Чтобы получить доступ к дополнительным параметрам настройки геометрии формы, вы можете преобразовать [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) в [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
* Используйте методы [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) и [graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (из класса [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil)) для двунаправленного преобразования [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) и [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).

## **Простые Операции Редактирования**

Этот PHP код показывает, как

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
**Добавить заданный дугу** к пути:

```php

```
**Закрыть текущую фигуру** пути:

```php

```
**Установить позицию для следующей точки**:

```php

```
**Удалить сегмент пути** по данному индексу:

```php

```

## **Добавление Пользовательских Точек к Фоме**
1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) и установите тип [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) из формы.
3. Добавьте новую точку между двумя верхними точками на пути.
4. Добавьте новую точку между двумя нижними точками на пути.
5. Примените путь к форме.

Этот PHP код показывает, как добавить пользовательские точки к форме:

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

##  Удаление Точек Из Фомы

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) и установите тип [ShapeType::Heart](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType).
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) из формы.
3. Удалите сегмент для пути.
4. Примените путь к форме.

Этот PHP код показывает, как удалить точки из формы:

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

##  **Создание Пользовательской Формы**

1. Рассчитайте точки для формы.
2. Создайте экземпляр класса [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
3. Заполните путь точками.
4. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
5. Примените путь к форме.

Этот Java код показывает, как создать пользовательскую форму:

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


## **Создание Составной Пользовательской Формы**

  1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
  2. Создайте первый экземпляр класса [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
  3. Создайте второй экземпляр класса [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath).
  4. Примените пути к форме.

Этот PHP код показывает, как создать составную пользовательскую форму:

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

## **Создание Пользовательской Формы С Закруглёнными Углами**

Этот PHP код показывает, как создать пользовательскую форму с закруглёнными углами (внутрь);

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

## **Преобразование GeometryPath в java.awt.Shape** 

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape).
2. Создайте экземпляр класса [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html).
3. Преобразуйте экземпляр [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) в экземпляр [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) с использованием [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil).
4. Примените пути к форме.

Этот PHP код — реализация вышеуказанных шагов — демонстрирует процесс конвертации **GeometryPath** в **GraphicsPath**:

```php
  $pres = new Presentation();
  try {
    # Создайте новую форму
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # Получите геометрический путь формы
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # Создайте новый графический путь с текстом
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Текст в форме";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # Преобразование графического пути в геометрический путь
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # Установите комбинацию нового геометрического пути и оригинального геометрического пути в форму
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)