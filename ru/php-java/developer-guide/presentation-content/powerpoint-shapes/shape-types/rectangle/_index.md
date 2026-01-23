---
title: Добавление прямоугольников в презентации на PHP
linktitle: Прямоугольник
type: docs
weight: 80
url: /ru/php-java/rectangle/
keywords:
- добавить прямоугольник
- создать прямоугольник
- прямоугольная фигура
- простой прямоугольник
- отформатированный прямоугольник
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Улучшите свои презентации PowerPoint, добавляя прямоугольники с помощью Aspose.Slides для PHP через Java — легко создавайте и изменяйте фигуры программно."
---

{{% alert color="primary" %}} 

Как и в предыдущих темах, эта тоже посвящена добавлению фигуры, и на этот раз мы будем обсуждать **Rectangle**. В этой теме мы описали, как разработчики могут добавлять простые или отформатированные прямоугольники в свои слайды, используя Aspose.Slides для PHP через Java.

{{% /alert %}} 

## **Добавить прямоугольник на слайд**
Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) типа Rectangle, используя метод [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape), предоставляемый объектом [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- Сохраните изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили простой прямоугольник на первый слайд презентации.
```php
  # Создать экземпляр класса Prseetation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа эллипса
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Записать файл PPTX на диск
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Добавить отформатированный прямоугольник на слайд**
Чтобы добавить отформатированный прямоугольник на слайд, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) типа Rectangle, используя метод [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape), предоставляемый объектом [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- Установите [Fill Type](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) прямоугольника в Solid.
- Задайте цвет прямоугольника с помощью метода [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor), предоставляемого объектом [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/), связанным с объектом [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).
- Установите цвет линий прямоугольника.
- Установите ширину линий прямоугольника.
- Сохраните изменённую презентацию в файл PPTX.

Вышеуказанные шаги реализованы в примере, приведённом ниже.
```php
  # Создать экземпляр класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа эллипса
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Применить некоторые параметры форматирования к эллипсу
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Применить некоторые параметры форматирования к линии эллипса
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Записать файл PPTX на диск
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Как добавить прямоугольник с закруглёнными углами?**

Используйте тип фигуры с закруглёнными углами [shape type](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) и отрегулируйте радиус угла в свойствах фигуры; закругление также можно применить к каждому углу отдельно с помощью корректировок геометрии.

**Как залить прямоугольник изображением (текстурой)?**

Выберите тип заливки изображением [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), укажите источник изображения и настройте режимы [растяжения/мозаики](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/).

**Можно ли добавить к прямоугольнику тень и светящийся контур?**

Да. Доступны [внешняя/внутренняя тень, светящийся контур и мягкие края](/slides/ru/php-java/shape-effect/) с настраиваемыми параметрами.

**Можно ли превратить прямоугольник в кнопку с гиперссылкой?**

Да. [Назначьте гиперссылку](/slides/ru/php-java/manage-hyperlinks/) при щелчке по фигуре (перейти к слайду, файлу, веб‑адресу или e‑mail).

**Как защитить прямоугольник от перемещения и изменений?**

Используйте блокировки фигуры: вы можете запретить перемещение, изменение размера, выделение или редактирование текста, чтобы сохранить макет.

**Можно ли преобразовать прямоугольник в растровое изображение или SVG?**

Да. Вы можете [отрендерить фигуру](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) в изображение с заданным размером/масштабом или [экспортировать её как SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) для векторного использования.

**Как быстро получить фактические (эффективные) свойства прямоугольника с учётом темы и наследования?**

[Используйте эффективные свойства фигуры](/slides/ru/php-java/shape-effective-properties/): API возвращает вычисленные значения, учитывающие стили темы, макет и локальные настройки, упрощая анализ форматирования.