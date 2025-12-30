---
title: Управление фигурами презентации в PHP
linktitle: Манипуляция фигурами
type: docs
weight: 40
url: /ru/php-java/shape-manipulations/
keywords:
- фигура PowerPoint
- фигура презентации
- фигура на слайде
- поиск фигуры
- клонирование фигуры
- удаление фигуры
- скрытие фигуры
- изменение порядка фигур
- получить Interop Shape ID
- альтернативный текст фигуры
- форматы макета фигуры
- фигура как SVG
- фигура в SVG
- выравнивание фигуры
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как создавать, редактировать и оптимизировать фигуры в Aspose.Slides для PHP через Java и предоставлять высокопроизводительные презентации PowerPoint."
---

## **Найти форму на слайде**
В этой теме описывается простая техника, упрощающая разработчикам поиск конкретной формы на слайде без использования её внутреннего Id. Важно знать, что файлы PowerPoint Presentation не имеют способа идентифицировать формы на слайде, кроме внутреннего уникального Id. Для разработчиков зачастую сложно находить форму по её внутреннему уникальному Id. Все формы, добавленные на слайды, имеют альтернативный текст. Мы рекомендуем использовать альтернативный текст для поиска конкретной формы. Вы можете задать альтернативный текст в MS PowerPoint для объектов, которые планируете менять в будущем.

После задания альтернативного текста нужной формы вы можете открыть эту презентацию с помощью Aspose.Slides for PHP via Java и пройтись по всем формам, добавленным на слайд. На каждой итерации можно проверить альтернативный текст формы, и форма с совпадающим альтернативным текстом будет нужной вам формой. Чтобы продемонстрировать эту технику, мы создали метод [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) , который ищет конкретную форму на слайде и возвращает её.
```php
  # Создать объект класса Presentation, представляющий файл презентации
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Альтернативный текст формы, которую нужно найти
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


## **Клонирование формы**
Для клонирования формы на слайд с помощью Aspose.Slides for PHP via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд, указав его индекс.
1. Получите коллекцию форм исходного слайда.
1. Добавьте новый слайд в презентацию.
1. Клонируйте формы из коллекции форм исходного слайда в новый слайд.
1. Сохраните изменённую презентацию как файл PPTX.

Ниже приведён пример, добавляющий групповую форму на слайд.
```php
  # Создать объект класса Presentation
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Записать файл PPTX на диск
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Удаление формы**
Aspose.Slides for PHP via Java позволяет разработчикам удалять любые формы. Чтобы удалить форму с любого слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите первый слайд.
1. Найдите форму с определённым AlternativeText.
1. Удалите форму.
1. Сохраните файл на диск.
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


## **Сокрытие формы**
Aspose.Slides for PHP via Java позволяет разработчикам скрывать любые формы. Чтобы скрыть форму с любого слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите первый слайд.
1. Найдите форму с определённым AlternativeText.
1. Сокройте форму.
1. Сохраните файл на диск.
```php
  # Создать объект класса Presentation, представляющий PPTX
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


## **Изменение порядка форм**
Aspose.Slides for PHP via Java позволяет разработчикам изменять порядок форм. Переупорядочивание определяет, какая форма находится спереди, а какая — сзади. Чтобы переупорядочить формы на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите первый слайд.
1. Добавьте форму.
1. Добавьте текст в текстовый фрейм формы.
1. Добавьте ещё одну форму с теми же координатами.
1. Переупорядочьте формы.
1. Сохраните файл на диск.
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


## **Получение Interop Shape ID**
Aspose.Slides for PHP via Java позволяет разработчикам получать уникальный идентификатор формы в пределах слайда, в отличие от метода [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getUniqueId--), который выдаёт уникальный идентификатор в пределах презентации. Метод [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) был добавлен в интерфейс [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) и класс [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape). Значение, возвращаемое методом [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--), соответствует Id объекта Microsoft.Office.Interop.PowerPoint.Shape. Ниже приведён пример кода.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Получение уникального идентификатора формы в области слайда
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Установка альтернативного текста для формы**
Aspose.Slides for PHP via Java позволяет разработчикам задавать AlternateText любой формы. Формы в презентации можно различать с помощью метода [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) или [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setName-java.lang.String-). Методы [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) и [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) могут быть использованы как в Aspose.Slides, так и в Microsoft PowerPoint. С помощью этого метода вы можете пометить форму и выполнять различные операции, такие как удаление, сокрытие или переупорядочивание форм на слайде. Чтобы установить AlternateText формы, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите первый слайд.
1. Добавьте любую форму на слайд.
1. Выполните необходимые действия с новой формой.
1. Пройдитесь по формам, чтобы найти нужную.
1. Установите AlternativeText.
1. Сохраните файл на диск.
```php
  # Создать объект класса Presentation, представляющий PPTX
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


## **Доступ к форматам макета для формы**
Aspose.Slides for PHP via Java предоставляет простой API для доступа к форматам макета формы. В этой статье показано, как получить доступ к форматам макета.

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


## **Рендеринг формы как SVG**
Теперь Aspose.Slides for PHP via Java поддерживает рендеринг формы как SVG. Метод [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (и его перегрузка) добавлен в класс [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) и интерфейс [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape). Этот метод позволяет сохранять содержимое формы в файл SVG. Ниже показан фрагмент кода, экспортирующего форму со слайда в SVG.
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


## **Выравнивание формы**
Aspose.Slides позволяет выравнивать формы либо относительно полей слайда, либо относительно друг друга. Для этой цели добавлен перегруженный метод [SlidesUtil.alignShape()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). Перечисление [ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/ShapesAlignmentType) определяет возможные варианты выравнивания.

**Пример 1**

В приведённом ниже коде формы с индексами 1, 2 и 4 выравниваются по верхней границе слайда.
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

В примере показано, как выровнять всю коллекцию форм относительно самой нижней формы в наборе.
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

В Aspose.Slides класс [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) предоставляет управление горизонтальным и вертикальным зеркалированием форм через свойства `flipH` и `flipV`. Оба свойства имеют тип [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/), позволяя задавать `True` — отражение, `False` — без отражения или `NotDefined` — использовать значение по умолчанию. Эти значения доступны через [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) формы.

Чтобы изменить параметры отражения, создаётся новый экземпляр [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) с текущим положением и размером формы, желаемыми значениями `flipH` и `flipV` и углом поворота. Присвоив этот экземпляр свойству [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) и сохранив презентацию, вы применяете зеркальные преобразования.

Предположим, в файле sample.pptx первый слайд содержит одну форму с настройками отражения по умолчанию, как показано ниже.

![The shape to be flipped](shape_to_be_flipped.png)

Следующий пример кода получает текущие свойства отражения формы и отражает её по горизонтали и вертикали.
```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Получить горизонтальное отражение формы.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Получить вертикальное отражение формы.
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

![The flipped shape](flipped_shape.png)

## **FAQ**

**Можно ли объединять формы (union/intersect/subtract) на слайде, как в настольном редакторе?**

Встроенного API для булевых операций нет. Можно приблизительно реализовать это, построив требуемый контур самостоятельно — например, вычислив итоговую геометрию (через [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)) и создав новую форму с этим контуром, при необходимости удалив исходные.

**Как контролировать порядок наложения (z‑order), чтобы форма всегда находилась «поверх»?**

Изменяйте порядок вставки/перемещения внутри коллекции [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) слайда. Для предсказуемого результата завершайте настройку z‑order после всех остальных изменений слайда.

**Можно ли «заблокировать» форму, чтобы пользователь не мог её редактировать в PowerPoint?**

Да. Установите [флаги защиты уровня формы](/slides/ru/php-java/applying-protection-to-presentation/) (например, блокировку выбора, перемещения, изменения размера, редактирования текста). При необходимости аналогичные ограничения можно задать для мастера или макета. Учтите, что это защита уровня UI, а не безопасность; для более сильной защиты комбинируйте её с ограничениями уровня файла, такими как рекомендации «только для чтения» или пароли [/slides/php-java/password-protected-presentation/].