---
title: Управление фигурами презентации в PHP
linktitle: Манипулирование фигурами
type: docs
weight: 40
url: /ru/php-java/shape-manipulations/
keywords:
- Фигура PowerPoint
- Фигура презентации
- Фигура на слайде
- Поиск фигуры
- Клонирование фигуры
- Удаление фигуры
- Скрытие фигуры
- Изменение порядка фигур
- Получить Interop Shape ID
- Альтернативный текст фигуры
- Форматы макета фигуры
- Фигура как SVG
- Фигура в SVG
- Выравнивание фигуры
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как создавать, редактировать и оптимизировать фигуры в Aspose.Slides for PHP via Java и создавать высокопроизводительные презентации PowerPoint."
---

## **Найти фигуру на слайде**
В этой теме будет описана простая техника, упрощающая разработчикам поиск конкретной фигуры на слайде без использования её внутреннего Id. Важно знать, что файлы PowerPoint Presentation не имеют способа идентифицировать фигуры на слайде, кроме внутреннего уникального Id. Для разработчиков может быть трудно найти фигуру, используя её внутренний уникальный Id. Все фигуры, добавленные на слайды, имеют некоторый альтернативный текст. Мы предлагаем разработчикам использовать альтернативный текст для поиска конкретной фигуры. Вы можете использовать MS PowerPoint, чтобы задать альтернативный текст для объектов, которые планируете изменять в будущем.

После установки альтернативного текста любой нужной фигуры вы можете открыть эту презентацию с помощью Aspose.Slides for PHP via Java и пройтись по всем фигурам, добавленным на слайд. На каждой итерации можно проверить альтернативный текст фигуры, и фигура с совпадающим альтернативным текстом будет требуемой фигурой. Чтобы продемонстрировать эту технику более наглядно, мы создали метод [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-), который позволяет найти конкретную фигуру на слайде и просто возвращает эту фигуру.
```php
  # Создайте экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Альтернативный текст фигуры, которую ищем
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


## **Клонировать фигуру**
Чтобы клонировать фигуру на слайд с использованием Aspose.Slides for PHP via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к коллекции фигур исходного слайда.
4. Добавьте новый слайд в презентацию.
5. Клонируйте фигуры из коллекции фигур исходного слайда в новый слайд.
6. Сохраните изменённую презентацию в виде файла PPTX.

Ниже приведён пример, добавляющий групповую фигуру на слайд.
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


## **Удалить фигуру**
Aspose.Slides for PHP via Java позволяет разработчикам удалять любую фигуру. Чтобы удалить фигуру с любого слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Найдите фигуру с определённым AlternativeText.
4. Удалите фигуру.
5. Сохраните файл на диск.
```php
  # Создать объект Presentation
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить автоконтур типа Rectangle
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


## **Скрыть фигуру**
Aspose.Slides for PHP via Java позволяет разработчикам скрывать любую фигуру. Чтобы скрыть фигуру на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Найдите фигуру с определённым AlternativeText.
4. Скройте фигуру.
5. Сохраните файл на диск.
```php
  # Создать экземпляр класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить автоконтур типа Rectangle
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


## **Изменить порядок фигур**
Aspose.Slides for PHP via Java позволяет разработчикам менять порядок фигур. Перестановка фигур определяет, какая фигура находится спереди, а какая сзади. Чтобы изменить порядок фигур на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте фигуру.
4. Добавьте текст в текстовый фрейм фигуры.
5. Добавьте другую фигуру с теми же координатами.
6. Переставьте порядок фигур.
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


## **Получить Interop Shape ID**
Aspose.Slides for PHP via Java позволяет разработчикам получать уникальный идентификатор фигуры в пределах слайда, в отличие от метода [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getuniqueid/), который позволяет получить уникальный идентификатор в пределах презентации. Метод [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) был добавлен в класс [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/). Значение, возвращаемое методом [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/), соответствует значению Id объекта Microsoft.Office.Interop.PowerPoint.Shape. Ниже приведён пример кода.
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


## **Установить альтернативный текст для фигуры**
Aspose.Slides for PHP via Java позволяет разработчикам задавать AlternateText любой фигуры.  
Фигуры в презентации можно различать с помощью `Alternative Text` или метода [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/).  
Методы [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) и [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) можно читать и задавать как через Aspose.Slides, так и через Microsoft PowerPoint.  
С помощью этого метода вы можете пометить фигуру и выполнять различные операции, такие как удаление фигуры, скрытие фигуры или перестановка фигур на слайде.  
Чтобы установить AlternateText фигуры, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите доступ к первому слайду.
3. Добавьте любую фигуру на слайд.
4. Выполните некоторые действия с только что добавленной фигурой.
5. Пройдитесь по фигурам, чтобы найти нужную фигуру.
6. Задайте AlternativeText.
7. Сохраните файл на диск.
```php
  # Создать экземпляр класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить автоконтур типа Rectangle
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


## **Получить доступ к форматам макета для фигуры**
Aspose.Slides for PHP via Java предоставляет простой API для доступа к форматам макета фигуры. В этой статье демонстрируется, как можно получить доступ к форматам макета.

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


## **Отрисовать фигуру как SVG**
Теперь Aspose.Slides for PHP via Java поддерживает отрисовку фигуры в формате SVG. Метод [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) (и его перегрузка) был добавлен в класс [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/). Этот метод позволяет сохранять содержимое фигуры в файл SVG. Ниже показан фрагмент кода, демонстрирующий, как экспортировать фигуру слайда в файл SVG.
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


## **Выровнять фигуру**
Aspose.Slides позволяет выравнивать фигуры либо относительно полей слайда, либо относительно друг друга. Для этого была добавлена перегруженная версия метода [SlidesUtil::alignShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/alignshapes/). Перечисление [ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/shapesalignmenttype/) определяет возможные варианты выравнивания.

**Пример 1**
Исходный код ниже выравнивает фигуры с индексами 1,2 и 4 по верхней границе слайда.
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


**Пример 2**
Пример ниже показывает, как выровнять всю коллекцию фигур относительно самой нижней фигуры в наборе.
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
В Aspose.Slides класс [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) предоставляет управление горизонтальным и вертикальным отражением фигур через свойства `flipH` и `flipV`. Оба свойства имеют тип [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/), позволяя использовать значение `True` для указания отражения, `False` — без отражения, или `NotDefined` — для использования поведения по умолчанию. Эти значения доступны через [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) фигуры.

Чтобы изменить настройки отражения, создаётся новый экземпляр [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/), в котором указываются текущие позиция и размер фигуры, желаемые значения `flipH` и `flipV`, а также угол вращения. Присваивание этого экземпляра свойству [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) фигуры и сохранение презентации применяет трансформации отражения и фиксирует их в выходном файле.

Предположим, у нас есть файл sample.pptx, в котором первый слайд содержит одну фигуру с настройками отражения по умолчанию, как показано ниже.

![Фигура для отражения](shape_to_be_flipped.png)

Следующий пример кода получает текущие свойства отражения фигуры и отражает её одновременно по горизонтали и вертикали.
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


Результат:

![Отражённая фигура](flipped_shape.png)

## **FAQ**

**Могу ли я объединять фигуры (union/intersect/subtract) на слайде, как в настольном редакторе?**

Встроенного API для логических операций нет. Можно приблизительно реализовать это, самостоятельно построив нужный контур — например, вычислить получающуюся геометрию (через [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)) и создать новую фигуру с этим контуром, при необходимости удалив оригиналы.

**Как я могу управлять порядком наложения (z-order), чтобы фигура всегда оставалась «наверху»?**

Измените порядок вставки/перемещения в коллекции [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) слайда. Для предсказуемых результатов завершайте настройку z-order после всех остальных изменений слайда.

**Могу ли я «заблокировать» фигуру, чтобы пользователи не могли её редактировать в PowerPoint?**

Да. Установите [флаги защиты уровня фигуры](/slides/ru/php-java/applying-protection-to-presentation/) (например, блокировка выбора, перемещения, изменения размеров, редактирования текста). При необходимости аналогичные ограничения можно применить к шаблону или разметке. Учтите, что это защита на уровне пользовательского интерфейса, а не функция безопасности; для более надёжной защиты комбинируйте её с ограничениями на уровне файла, такими как [рекомендации только для чтения или пароли](/slides/ru/php-java/password-protected-presentation/).