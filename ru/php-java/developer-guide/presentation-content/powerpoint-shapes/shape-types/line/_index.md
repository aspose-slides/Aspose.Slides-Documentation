---
title: Добавление линейных фигур в презентации на PHP
linktitle: Линия
type: docs
weight: 50
url: /ru/php-java/line/
keywords:
- линия
- создать линию
- добавить линию
- прямая линия
- настроить линию
- кастомизировать линию
- стиль штриха
- головка стрелки
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как управлять форматированием линий в презентациях PowerPoint с помощью Aspose.Slides for PHP via Java. Откройте свойства, методы и примеры."
---
## **Overview**

Aspose.Slides позволяет программно добавлять линейные фигуры в слайды PowerPoint. Эта статья показывает, как создать простую линию и как настроить её так, чтобы она выглядела как стрелка.

Вы узнаете, как добавить линейную фигуру на слайд, настроить её визуальный вид и сохранить обновлённую презентацию. Примеры сосредоточены на практических настройках форматирования линии, таких как стиль, ширина, тип штриха, параметры стрелок и цвет заливки.

## **Create a Plain Line**

Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line с помощью метода [addAutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/#addAutoShape), предоставленного объектом [ShapeCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/).
- Сохраните изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили линию на первый слайд презентации.

```php
  # Создайте объект класса PresentationEx, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получите первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавьте AutoShape типа линия
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Запишите PPTX на диск
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Create an Arrow-Shaped Line**

Aspose.Slides for PHP via Java также позволяет разработчикам настраивать свойства линии, чтобы она выглядела более привлекательно. Настроим несколько свойств линии, чтобы она выглядела как стрелка. Выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line с помощью метода [addAutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/#addAutoShape), предоставленного объектом [ShapeCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapecollection/).
- Установите [Line Style](https://reference.aspose.com/slides/ru/php-java/aspose.slides/LineStyle) в один из стилей, предлагаемых Aspose.Slides for PHP via Java.
- Задайте ширину линии.
- Установите [Dash Style](https://reference.aspose.com/slides/ru/php-java/aspose.slides/LineDashStyle) линии в один из стилей, предлагаемых Aspose.Slides for PHP via Java.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/ru/php-java/aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/ru/php-java/aspose.slides/LineArrowheadLength) начальной точки линии.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/ru/php-java/aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/ru/php-java/aspose.slides/LineArrowheadLength) конечной точки линии.
- Сохраните изменённую презентацию в файл PPTX.

```php
  # Создайте объект класса PresentationEx, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получите первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавьте AutoShape типа line
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Примените некоторое форматирование к линии
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Запишите PPTX на диск
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Можно ли преобразовать обычную линию в соединитель, чтобы она "прилипала" к фигурам?**

Нет. Обычная линия (an [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) of type [Line](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapetype/)) не становится автоматически соединителем. Чтобы она «прилипала» к фигурам, используйте специализированный тип [Connector](https://reference.aspose.com/slides/ru/php-java/aspose.slides/connector/) и [corresponding APIs](/slides/ru/php-java/connector/) для соединений.

**Что делать, если свойства линии унаследованы из темы и трудно определить конечные значения?**

[Прочитать эффективные свойства](/slides/ru/php-java/shape-effective-properties/) через `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — эти данные уже учитывают наследование и стили темы.

**Можно ли заблокировать линию от редактирования (перемещения, изменения размера)?**

Да. Фигуры предоставляют [lock objects](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/getautoshapelock/), которые позволяют запретить операции редактирования.