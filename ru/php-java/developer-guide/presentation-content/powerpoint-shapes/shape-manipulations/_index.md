---
title: Манипуляции с формами
type: docs
weight: 40
url: /ru/php-java/manipulations-with-shapes/
---

## **Найти форму на слайде**
Эта тема будет описывать простую технику, которая поможет разработчикам находить конкретную форму на слайде без использования ее внутреннего идентификатора. Важно знать, что файлы презентаций PowerPoint не имеют способа идентифицировать формы на слайде, кроме уникального внутреннего идентификатора. Разработчикам сложно найти форму, используя ее внутренний уникальный идентификатор. Все формы, добавленные на слайды, имеют некоторый альтернативный текст. Мы предлагаем разработчикам использовать альтернативный текст для поиска конкретной формы. Вы можете использовать MS PowerPoint для определения альтернативного текста для объектов, которые планируете изменить в будущем.

После установки альтернативного текста для любой желаемой формы, вы можете открыть эту презентацию с помощью Aspose.Slides для PHP через Java и перебрать все формы, добавленные на слайд. Во время каждой итерации вы можете проверить альтернативный текст формы, и форма с совпадающим альтернативным текстом будет той, которая вам нужна. Чтобы продемонстрировать эту технику более наглядно, мы создали метод [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-), который позволяет находить конкретную форму на слайде и просто возвращать эту форму.

```php
  # Создать экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Альтернативный текст формы, которую нужно найти
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Имя формы: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Клонировать форму**
Чтобы клонировать форму на слайде с помощью Aspose.Slides для PHP через Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Получите коллекцию форм исходного слайда.
1. Добавьте новый слайд к презентации.
1. Клонируйте формы из коллекции форм исходного слайда на новый слайд.
1. Сохраните измененную презентацию как файл PPTX.

Пример ниже добавляет групповую форму на слайд.

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
    # Записать файл PPTX на диск
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Удалить форму**
Aspose.Slides для PHP через Java позволяет разработчикам удалять любые формы. Чтобы удалить форму с любого слайда, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Найдите форму с конкретным альтернативным текстом.
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
    $altText = "Пользовательский текст";
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

## **Скрыть форму**
Aspose.Slides для PHP через Java позволяет разработчикам скрывать любые формы. Чтобы скрыть форму с любого слайда, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Найдите форму с конкретным альтернативным текстом.
1. Скрыть форму.
1. Сохраните файл на диск.

```php
  # Создать экземпляр класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить автофигуру типа прямоугольник
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "Пользовательский текст";
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

## **Изменить порядок форм**
Aspose.Slides для PHP через Java позволяет разработчикам изменять порядок форм. Изменение порядка форм определяет, какая форма находится на переднем плане, а какая - на заднем. Чтобы изменить порядок форм на любом слайде, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте форму.
1. Добавьте текст в текстовую рамку формы.
1. Добавьте еще одну форму с теми же координатами.
1. Измените порядок форм.
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
    $portion->setText("Текст водяного знака Текст водяного знака Текст водяного знака");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Получить идентификатор Interop формы**
Aspose.Slides для PHP через Java позволяет разработчикам получить уникальный идентификатор формы в пределах слайда, в отличие от метода [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getUniqueId--), который позволяет получить уникальный идентификатор в пределах презентации. Метод [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) был добавлен к интерфейсам [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) и классу [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape). Значение, возвращаемое методом [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) соответствует значению идентификатора объекта Microsoft.Office.Interop.PowerPoint.Shape. Приведен образец кода.

```php
  $pres = new Presentation("Презентация.pptx");
  try {
    # Получение уникального идентификатора формы в пределах слайда
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Установить альтернативный текст для формы**
Aspose.Slides для PHP через Java позволяет разработчикам устанавливать альтернативный текст для любой формы. Формы в презентации можно различать с помощью метода [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) или метода [Имя формы](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setName-java.lang.String-). Методы [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) и [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) могут быть прочитаны или установлены с помощью Aspose.Slides, а также Microsoft PowerPoint. Используя этот метод, вы можете пометить форму и выполнять различные операции, такие как удаление формы, скрытие формы или изменение порядка форм на слайде. Чтобы установить альтернативный текст для формы, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите доступ к первому слайду.
1. Добавьте любую форму на слайд.
1. Выполните некоторые действия с недавно добавленной формой.
1. Переберите формы, чтобы найти нужную форму.
1. Установите альтернативный текст.
1. Сохраните файл на диск.

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
        $shape->setAlternativeText("Пользовательский текст");
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

## **Получить доступ к форматам макета для формы**
Aspose.Slides для PHP через Java предоставляет простой API для доступа к форматам макета для формы. Эта статья демонстрирует, как вы можете получить доступ к форматам макета.

Приведен пример кода.

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

## **Отобразить форму как SVG**
Теперь Aspose.Slides для PHP через Java поддерживает отображение формы как SVG. Метод [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (и его перегрузки) был добавлен в класс [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) и интерфейс [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape). Этот метод позволяет сохранить содержимое формы как файл SVG. Приведен фрагмент кода, который показывает, как экспортировать форму слайда в файл SVG.

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

## **Выравнивание форм**
Aspose.Slides позволяет выравнивать формы либо относительно краев слайда, либо относительно друг друга. Для этой цели был добавлен перегруженный метод [SlidesUtil.alignShape()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). Перечисление [ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/ShapesAlignmentType) определяет возможные опции выравнивания.

**Пример 1**

Исходный код ниже выравнивает формы с индексами 1, 2 и 4 вдоль верхней границы слайда.

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

Пример ниже показывает, как выровнять всю коллекцию форм относительно самой нижней формы в коллекции.

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