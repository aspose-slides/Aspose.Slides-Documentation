---
title: Получить эффективные свойства фигуры из презентаций в PHP
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/php-java/shape-effective-properties/
keywords:
- свойства фигуры
- свойства камеры
- освещение
- форма с фаской
- текстовый кадр
- текстовый стиль
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for PHP via Java вычисляет и применяет эффективные свойства фигур для точного отображения PowerPoint."
---

В этой теме мы рассмотрим **эффективные** и **локальные** свойства. Когда мы задаём значения непосредственно на этих уровнях

1. В свойствах части на слайде части;
1. В стиле текста прототипной формы на макете или главном слайде (если у формы текстового кадра части есть стиль);
1. В глобальных настройках текста презентации;

Эти значения называют **локальными** значениями. На любом уровне **локальные** значения могут быть определены или опущены. Но когда приложению необходимо узнать, как должна выглядеть часть, оно использует **эффективные** значения. Вы можете получить эффективные значения, используя метод **getEffective()** локального формата.

Этот пример кода показывает, как получить эффективные значения:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat::getEffective();
    $localPortionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat::getEffective();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Получить эффективные свойства камеры**
Aspose.Slides for PHP via Java позволяет разработчикам получать эффективные свойства камеры. Для этой цели в Aspose.Slides был добавлен класс `ICameraEffectiveData`. Класс `ICameraEffectiveData` представляет собой неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр класса `ICameraEffectiveData` используется как часть класса `IThreeDFormatEffectiveData`, который является парой [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) для класса [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Этот пример кода показывает, как получить эффективные свойства камеры:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective camera properties =");
    echo("Type: " . $threeDEffectiveData->getCamera()->getCameraType());
    echo("Field of view: " . $threeDEffectiveData->getCamera()->getFieldOfViewAngle());
    echo("Zoom: " . $threeDEffectiveData->getCamera()->getZoom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Получить эффективные свойства светового оборудования**
Aspose.Slides for PHP via Java позволяет разработчикам получать эффективные свойства Light Rig. Для этой цели в Aspose.Slides был добавлен класс `ILightRigEffectiveData`. Класс `ILightRigEffectiveData` представляет собой неизменяемый объект, содержащий эффективные свойства светового оборудования. Экземпляр класса `ILightRigEffectiveData` используется как часть класса `IThreeDFormatEffectiveData`, который является парой [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) для класса [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Этот пример кода показывает, как получить эффективные свойства светового оборудования:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective light rig properties =");
    echo("Type: " . $threeDEffectiveData->getLightRig()->getLightType());
    echo("Direction: " . $threeDEffectiveData->getLightRig()->getDirection());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Получить эффективные свойства формы с фаской**
Aspose.Slides for PHP via Java позволяет разработчикам получать эффективные свойства Bevel Shape. Для этой цели в Aspose.Slides был добавлен класс `IShapeBevelEffectiveData`. Класс `IShapeBevelEffectiveData` представляет собой неизменяемый объект, содержащий эффективные свойства рельефа грани формы. Экземпляр класса `IShapeBevelEffectiveData` используется как часть класса `IThreeDFormatEffectiveData`, который является парой [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/) для класса [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Этот пример кода показывает, как получить эффективные свойства формы с фаской:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective shape's top face relief properties =");
    echo("Type: " . $threeDEffectiveData->getBevelTop()->getBevelType());
    echo("Width: " . $threeDEffectiveData->getBevelTop()->getWidth());
    echo("Height: " . $threeDEffectiveData->getBevelTop()->getHeight());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Получить эффективные свойства текстового кадра**
С помощью Aspose.Slides for PHP via Java вы можете получить эффективные свойства текстового кадра. Для этой цели в Aspose.Slides был добавлен класс `ITextFrameFormatEffectiveData`. Он содержит эффективные свойства форматирования текстового кадра.

Этот пример кода показывает, как получить эффективные свойства форматирования текстового кадра:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    echo("Anchoring type: " . $effectiveTextFrameFormat::getAnchoringType());
    echo("Autofit type: " . $effectiveTextFrameFormat::getAutofitType());
    echo("Text vertical type: " . $effectiveTextFrameFormat::getTextVerticalType());
    echo("Margins");
    echo("   Left: " . $effectiveTextFrameFormat::getMarginLeft());
    echo("   Top: " . $effectiveTextFrameFormat::getMarginTop());
    echo("   Right: " . $effectiveTextFrameFormat::getMarginRight());
    echo("   Bottom: " . $effectiveTextFrameFormat::getMarginBottom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Получить эффективные свойства текстового стиля**
С помощью Aspose.Slides for PHP via Java вы можете получить эффективные свойства текстового стиля. Для этой цели в Aspose.Slides был добавлен класс `ITextStyleEffectiveData`. Он содержит эффективные свойства текстового стиля.

Этот пример кода показывает, как получить эффективные свойства текстового стиля:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextStyle = $shape->getTextFrame()->getTextFrameFormat()->getTextStyle()->getEffective();
    for($i = 0; $i <= 8; $i++) {
      $effectiveStyleLevel = $effectiveTextStyle->getLevel($i);
      echo("= Effective paragraph formatting for style level #" . $i . " =");
      echo("Depth: " . $effectiveStyleLevel->getDepth());
      echo("Indent: " . $effectiveStyleLevel->getIndent());
      echo("Alignment: " . $effectiveStyleLevel->getAlignment());
      echo("Font alignment: " . $effectiveStyleLevel->getFontAlignment());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Получить эффективное значение высоты шрифта**
С помощью Aspose.Slides for PHP via Java вы можете получить эффективные свойства высоты шрифта. Здесь мы представляем код, который демонстрирует изменение эффективного значения высоты шрифта части после установки локальных значений высоты шрифта на разных уровнях структуры презентации:
```php
  $pres = new Presentation();
  try {
    $newShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $newShape->addTextFrame("");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->clear();
    $portion0 = new Portion("Sample text with first portion");
    $portion1 = new Portion(" and second portion.");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion0);
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion1);
    echo("Effective font height just after creation:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(24);
    echo("Effective font height after setting entire presentation default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(40);
    echo("Effective font height after setting paragraph default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(55);
    echo("Effective font height after setting portion #0 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setFontHeight(18);
    echo("Effective font height after setting portion #1 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Получить эффективный формат заливки для таблицы**
С помощью Aspose.Slides for PHP via Java вы можете получить эффективное форматирование заливки для различных логических частей таблицы. Для этой цели в Aspose.Slides был добавлен класс `ICellFormatEffectiveData`. Он содержит эффективные свойства форматирования заливки. Обратите внимание: форматирование ячейки всегда имеет приоритет над форматированием строки; строка имеет приоритет над столбцом; а столбец имеет приоритет над всей таблицей.
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $tableFormatEffective = $tbl->getTableFormat()->getEffective();
    $rowFormatEffective = $tbl->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnFormatEffective = $tbl->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellFormatEffective = $tbl->get_Item(0, 0)->getCellFormat()->getEffective();
    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Как я могу определить, что получил «снимок», а не «живой объект», и когда следует заново считывать эффективные свойства?**
Объекты EffectiveData являются неизменяемыми снимками вычисленных значений в момент вызова. Если вы измените локальные или унаследованные настройки формы, получите эффективные данные снова, чтобы получить обновленные значения.

**Влияет ли изменение макета/главного слайда на эффективные свойства, которые уже были получены?**
Да, но только после повторного чтения. Уже полученный объект EffectiveData не обновляется сам по себе — запросите его снова после изменения макета или главного слайда.

**Могу ли я изменять значения через EffectiveData?**
Нет. EffectiveData только для чтения. Вносите изменения в локальные объекты форматирования (форма/текст/3D и т.д.), а затем снова получайте эффективные значения.

**Что происходит, если свойство не задано на уровне формы, макета/главного слайда или глобальных настроек?**
Эффективное значение определяется механизмом значений по умолчанию (по умолчанию PowerPoint/Aspose.Slides). Это разрешённое значение становится частью снимка EffectiveData.

**Можно ли по эффективному значению шрифта определить, с какого уровня было получено размер или гарнитура?**
Не напрямую. EffectiveData возвращает окончательное значение. Чтобы найти источник, проверьте локальные значения в части/параграфе/текстовом кадре и стили текста в макете/главном слайде/презентации, чтобы увидеть, где появилось первое явное определение.

**Почему значения EffectiveData иногда совпадают с локальными?**
Потому что локальное значение оказалось окончательным (не требовалось наследование с более высоких уровней). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**
Используйте EffectiveData, когда нужен результат «как отображено» после применения всего наследования (например, для согласования цветов, отступов или размеров). Если требуется изменить форматирование на определённом уровне, измените локальные свойства и, при необходимости, снова прочитайте EffectiveData для проверки результата.