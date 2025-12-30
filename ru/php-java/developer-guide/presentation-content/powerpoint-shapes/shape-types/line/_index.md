---
title: Добавить линейные фигуры в презентации на PHP
linktitle: Линия
type: docs
weight: 50
url: /ru/php-java/Line/
keywords:
- линия
- создать линию
- добавить линию
- простая линия
- настроить линию
- кастомизировать линию
- стиль штриха
- стрелка
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Изучите, как управлять форматированием линий в презентациях PowerPoint с помощью Aspose.Slides for PHP via Java. Узнайте свойства, методы и примеры."
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java поддерживает добавление различных видов фигур на слайды. В этой теме мы начнём работу с фигурами, добавляя линии на слайды. С помощью Aspose.Slides for PHP via Java разработчики могут не только создавать простые линии, но и рисовать на слайдах интересные декоративные линии.

{{% /alert %}} 

## **Создать простую линию**

Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line с помощью метода [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Запишите изменённую презентацию в файл PPTX.

В примере ниже мы добавили линию на первый слайд презентации.
```php
  # Создать экземпляр класса PresentationEx, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа линия
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Записать PPTX на диск
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Создать линию со стрелкой**

Aspose.Slides for PHP via Java также позволяет разработчикам настраивать свойства линии, чтобы она выглядела более привлекательно. Попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Line с помощью метода [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Установите [Line Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) в один из стилей, предлагаемых Aspose.Slides for PHP via Java.
- Установите ширину линии.
- Установите [Dash Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) линии в один из стилей, предлагаемых Aspose.Slides for PHP via Java.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) начальной точки линии.
- Установите [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) и [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) конечной точки линии.
- Запишите изменённую презентацию в файл PPTX.
```php
  # Создать экземпляр класса PresentationEx, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа линия
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Применить некоторое форматирование к линии
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Записать PPTX на диск
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Могу ли я преобразовать обычную линию в соединитель, чтобы она «привязывалась» к фигурам?**

Нет. Обычная линия (AutoShape типа Line) автоматически не превращается в соединитель. Чтобы привязать её к фигурам, используйте отдельный тип [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) и [соответствующие API](/slides/ru/php-java/connector/) для соединений.

**Что делать, если свойства линии наследованы из темы и сложно определить конечные значения?**

[Читайте эффективные свойства](/slides/ru/php-java/shape-effective-properties/) через `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — они уже учитывают наследование и стили темы.

**Можно ли заблокировать линию от редактирования (перемещения, изменения размеров)?**

Да. Фигуры предоставляют [объекты блокировки](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/getautoshapelock/), которые позволяют [запретить операции редактирования](/slides/ru/php-java/applying-protection-to-presentation/).