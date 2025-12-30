---
title: Добавление прямоугольников в презентации на PHP
linktitle: Прямоугольник
type: docs
weight: 80
url: /ru/php-java/rectangle/
keywords:
- добавить прямоугольник
- создать прямоугольник
- форма прямоугольника
- простой прямоугольник
- форматированный прямоугольник
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Улучшите свои презентации PowerPoint, добавляя прямоугольники с помощью Aspose.Slides для PHP через Java — легко разрабатывайте и модифицируйте фигуры программно."
---

{{% alert color="primary" %}} 

Как и в предыдущих темах, эта тоже посвящена добавлению фигуры, и на этот раз мы будем рассматривать **Rectangle**. В этой теме мы описали, как разработчики могут добавлять простые или форматированные прямоугольники на свои слайды, используя Aspose.Slides для PHP через Java.

{{% /alert %}} 

## **Добавить прямоугольник на слайд**
Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) типа Rectangle, используя метод [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) , предоставляемый объектом [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Сохраните изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили простой прямоугольник на первый слайд презентации.
```php
  # Создать объект класса Presentation, представляющий PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа эллипс
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Записать файл PPTX на диск
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Добавить форматированный прямоугольник на слайд**
Чтобы добавить форматированный прямоугольник на слайд, выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) типа Rectangle, используя метод [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) , предоставляемый объектом [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Установите [Fill Type](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) прямоугольника в Solid.
- Установите цвет прямоугольника, используя метод [SolidFillColor.setColor](https://reference.aspose.com/slides/php-java/aspose.slides/IColorFormat#setColor-java.awt.Color-) , предоставляемый объектом [IFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat), связанным с объектом [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).
- Установите цвет линий прямоугольника.
- Установите толщину линий прямоугольника.
- Сохраните изменённую презентацию в файл PPTX.

Вышеуказанные шаги реализованы в примере, приведённом ниже.
```php
  # Создать объект класса Presentation, представляющий PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа эллипс
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Применить форматирование к фигуре эллипса
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Применить форматирование к линии эллипса
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


## **Вопросы и ответы**

**Как добавить прямоугольник с закруглёнными углами?**

Используйте тип фигуры с закруглёнными углами [shape type](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) и настройте радиус скругления в свойствах фигуры; скругление также можно применять к каждому углу с помощью геометрических корректировок.

**Как залить прямоугольник изображением (текстурой)?**

Выберите тип заливки [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) «изображение», укажите источник изображения и настройте режимы [stretching/tiling modes](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/).

**Можно ли добавить тень и сияние к прямоугольнику?**

Да. Доступны [внешняя/внутренняя тень, сияние и мягкие края](/slides/ru/php-java/shape-effect/) с настраиваемыми параметрами.

**Можно ли превратить прямоугольник в кнопку с гиперссылкой?**

Да. [Назначьте гиперссылку](/slides/ru/php-java/manage-hyperlinks/) на щелчок по фигуре (переход к слайду, файлу, веб‑адресу или электронной почте).

**Как защитить прямоугольник от перемещения и изменений?**

[Используйте блокировку фигур](/slides/ru/php-java/applying-protection-to-presentation/): вы можете запретить перемещение, изменение размеров, выделение или редактирование текста, чтобы сохранить макет.

**Можно ли преобразовать прямоугольник в растровое изображение или SVG?**

Да. Вы можете [визуализировать фигуру](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) в изображение заданного размера/масштаба или [экспортировать её как SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) для векторного использования.

**Как быстро получить реальные (эффективные) свойства прямоугольника с учётом темы и наследования?**

[Используйте эффективные свойства фигуры](/slides/ru/php-java/shape-effective-properties/): API возвращает вычисленные значения, учитывающие стили темы, макет и локальные настройки, упрощая анализ форматирования.