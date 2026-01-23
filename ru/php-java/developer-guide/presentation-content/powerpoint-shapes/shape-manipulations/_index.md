---
title: Управление фигурами презентации в PHP
linktitle: Манипуляция фигурами
type: docs
weight: 40
url: /ru/php-java/shape-manipulations/
keywords:
- Фигура PowerPoint
- Фигура презентации
- Фигура на слайде
- Найти фигуру
- Клонировать фигуру
- Удалить фигуру
- Скрыть фигуру
- Изменить порядок фигур
- Получить Interop ID фигуры
- Альтернативный текст фигуры
- Форматы размещения фигуры
- Фигура как SVG
- Фигура в SVG
- Выровнять фигуру
- PowerPoint
- Презентация
- PHP
- Aspose.Slides
description: "Научитесь создавать, редактировать и оптимизировать фигуры в Aspose.Slides for PHP via Java и создавать высокопроизводительные презентации PowerPoint."
---

## **Найти объект на слайде**
Эта статья описывает простую методику, позволяющую разработчикам проще находить определённый объект на слайде без использования его внутреннего Id. Важно знать, что файлы презентаций PowerPoint не имеют способа идентифицировать объекты на слайде, кроме внутреннего уникального Id. Разработчикам часто трудно находить объект по его внутреннему уникальному Id. Все объекты, добавленные на слайды, имеют альтернативный текст. Мы рекомендуем разработчикам использовать альтернативный текст для поиска конкретного объекта. Вы можете использовать MS PowerPoint для задания альтернативного текста объектам, которые планируете менять в будущем.

После задания альтернативного текста нужному объекту вы можете открыть эту презентацию с помощью Aspose.Slides for PHP via Java и перебрать все объекты, добавленные на слайд. На каждой итерации можно проверить альтернативный текст объекта, и объект с совпадающим альтернативным текстом будет требуемым объектом. Чтобы лучше продемонстрировать эту методику, мы создали метод, [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) , который позволяет найти конкретный объект на слайде и просто возвращает его.
```php
  # Создайте экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Альтернативный текст фигуры, которую нужно найти
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **Клонировать объект**
Для клонирования объекта на слайд с использованием Aspose.Slides for PHP via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к коллекции объектов исходного слайда.
4. Добавьте новый слайд в презентацию.
5. Клонируйте объекты из коллекции объектов исходного слайда в новый слайд.
6. Сохраните изменённую презентацию как файл PPTX.

Пример ниже добавляет групповый объект на слайд.
```php
  # Создать экземпляр класса Presentation
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Сохранить файл PPTX на диск
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Удалить объект**
Aspose.Slides for PHP via Java позволяет разработчикам удалять любые объекты. Чтобы удалить объект с любого слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Найдите объект с определённым AlternativeText.
4. Удалите объект.
5. Сохраните файл на диск.
```php
  # Создать объект Presentation
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить автофигуру типа прямоугольник
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Сохранить презентацию на диск
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Скрыть объект**
Aspose.Slides for PHP via Java позволяет разработчикам скрывать любые объекты. Чтобы скрыть объект на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Найдите объект с определённым AlternativeText.
4. Скрыть объект.
5. Сохраните файл на диск.
```php
  # Создать экземпляр класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить автофигуру типа прямоугольник
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Сохранить презентацию на диск
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Изменить порядок объектов**
Aspose.Slides for PHP via Java позволяет разработчикам изменять порядок объектов. Переупорядочивание объектов определяет, какой объект находится спереди, а какой — сзади. Чтобы изменить порядок объектов на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте объект.
4. Добавьте некоторый текст в текстовый кадр объекта.
5. Добавьте другой объект с теми же координатами.
6. Переставьте объекты.
7. Сохраните файл на диск.
```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Получить Interop ID объекта**
Aspose.Slides for PHP via Java позволяет разработчикам получить уникальный идентификатор объекта в пределах слайда, в отличие от метода [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getuniqueid/), который возвращает уникальный идентификатор в пределах презентации. Метод [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) был добавлен в класс [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) соответственно. Значение, возвращаемое методом [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/), соответствует значению Id объекта Microsoft.Office.Interop.PowerPoint.Shape. Ниже приведён пример кода.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Получение уникального идентификатора фигуры в пределах слайда
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установить альтернативный текст для объекта**
Aspose.Slides for PHP via Java позволяет разработчикам задавать AlternateText любого объекта.
Объекты в презентации можно различать по `Alternative Text` или с помощью метода [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/).
Методы [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) и [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) можно читать и задавать как через Aspose.Slides, так и через Microsoft PowerPoint.
Используя этот метод, вы можете помечать объект и выполнять различные операции, такие как удаление объекта,
скрытие объекта или изменение порядка объектов на слайде.
Чтобы установить AlternateText для объекта, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте любой объект на слайд.
4. Выполните некоторое действие с вновь добавленным объектом.
5. Пройдите по объектам, чтобы найти нужный.
6. Установите AlternativeText.
7. Сохраните файл на диск.
```php
  # Создать экземпляр класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить автофигуру типа прямоугольник
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # Сохранить презентацию на диск
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Доступ к форматам размещения объекта**
Aspose.Slides for PHP via Java предоставляет простой API для доступа к форматам размещения объекта. В этой статье показано, как получить доступ к форматам размещения.

Ниже приведён пример кода.
```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Отобразить объект как SVG**
Теперь Aspose.Slides for PHP via Java поддерживает отображение объекта в формате SVG. Метод [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) (и его перегрузка) был добавлен в класс [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/). Этот метод позволяет сохранять содержимое объекта в файл SVG. Ниже приведён фрагмент кода, показывающий, как экспортировать объект слайда в файл SVG.
```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Выровнять объект**
Aspose.Slides позволяет выравнивать объекты относительно полей слайда или друг относительно друга. Для этого была добавлена перегруженная версия метода [SlidesUtil::alignShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/alignshapes/). Перечисление [ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/shapesalignmenttype/) определяет возможные варианты выравнивания.

**Example 1**

Исходный код ниже выравнивает объекты с индексами 1, 2 и 4 по верхнему краю слайда.
```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


**Example 2**

Пример ниже показывает, как выравнять всю коллекцию объектов относительно самого нижнего объекта в коллекции.
```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Свойства отражения**
В Aspose.Slides класс [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) предоставляет управление горизонтальным и вертикальным отражением объектов через свойства `flipH` и `flipV`. Оба свойства имеют тип [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/), позволяющий значения `True` для отражения, `False` — без отражения, или `NotDefined` для использования поведения по умолчанию. Эти значения доступны из [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) объекта.

Чтобы изменить параметры отражения, создаётся новый экземпляр [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) , содержащий текущие позицию и размер объекта, желаемые значения `flipH` и `flipV`, а также угол вращения. Присвоив этот экземпляр свойству [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) объекта и сохранив презентацию, вы применяете зеркальные трансформации и фиксируете их в выходном файле.

Предположим, у нас есть файл sample.pptx, в котором первый слайд содержит один объект с настройками отражения по умолчанию, как показано ниже.

![The shape to be flipped](shape_to_be_flipped.png)

Следующий пример кода получает текущие свойства отражения объекта и отражает его как по горизонтали, так и по вертикали.
```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Получить свойство горизонтального отражения фигуры.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Получить свойство вертикального отражения фигуры.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // Отразить по горизонтали.
    $flipV = NullableBool::True; // Отразить по горизонтали.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


![The flipped shape](flipped_shape.png)

## **Вопросы и ответы**

**Можно ли комбинировать объекты (объединять/пересекать/вычитать) на слайде, как в настольном редакторе?**

Встроенного API для булевых операций нет. Можно приблизительно реализовать это, построив требуемый контур вручную — например, вычислив результирующую геометрию (через [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)) и создав новый объект с этим контуром, при желании удалив оригиналы.

**Как контролировать порядок наложения (z-order), чтобы объект всегда оставался «поверх»?**

Измените порядок вставки/перемещения в коллекции [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) слайда. Для предсказуемого результата завершайте настройку z-order после всех остальных изменений слайда.

**Можно ли «заблокировать» объект, чтобы пользователи не могли его редактировать в PowerPoint?**

Да. Установите флаги защиты на уровне объекта (например, блокировать выделение, перемещение, изменение размеров, редактирование текста). При необходимости аналогичные ограничения можно задать для мастера или макета. Учтите, что это защита на уровне пользовательского интерфейса, а не функция безопасности; для более надёжной защиты комбинируйте с ограничениями уровня файла, например, рекомендациями только для чтения или паролями ([read-only recommendations or passwords](/slides/ru/php-java/password-protected-presentation/)).