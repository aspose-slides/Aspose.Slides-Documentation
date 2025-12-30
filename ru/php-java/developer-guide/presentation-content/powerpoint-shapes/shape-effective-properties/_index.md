---
title: Получить эффективные свойства фигуры из презентаций в PHP
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/php-java/shape-effective-properties/
keywords:
- свойства фигуры
- свойства камеры
- осветительное оборудование
- скосная фигура
- текстовый кадр
- стиль текста
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for PHP via Java вычисляет и применяет эффективные свойства фигуры для точного рендеринга PowerPoint."
---

В этой теме мы обсудим **эффективные** и **локальные** свойства. Когда мы задаём значения непосредственно на этих уровнях

1. В свойствах части на слайде части;
1. В стиле текста прототипной фигуры на макете или слайде‑образце (если у формы текстового кадра части есть такой стиль);
1. В глобальных настройках текста презентации;

эти значения называются **локальными**. На любом уровне **локальные** значения могут быть определены или опущены. Но когда приложению необходимо знать, как должна выглядеть часть, оно использует **эффективные** значения. Получить эффективные значения можно, вызвав метод **getEffective()** из локального формата.

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
Aspose.Slides for PHP via Java позволяет разработчикам получать эффективные свойства камеры. Для этой цели в Aspose.Slides была добавлена интерфейс [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData). Интерфейс [ICameraEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) представляет неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) используется как часть интерфейса [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData), который является парой [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

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


## **Получить эффективные свойства осветительного оборудования**
Aspose.Slides for PHP via Java позволяет разработчикам получать эффективные свойства Light Rig. Для этой цели в Aspose.Slides был добавлен интерфейс [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData). Интерфейс [ILightRigEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) представляет неизменяемый объект, содержащий эффективные свойства осветительного оборудования. Экземпляр [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) используется как часть интерфейса [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData), который является парой [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Этот пример кода показывает, как получить эффективные свойства Light Rig:
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


## **Получить эффективные свойства скосной фигуры**
Aspose.Slides for PHP via Java позволяет разработчикам получать эффективные свойства Bevel Shape. Для этой цели в Aspose.Slides был добавлен интерфейс [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData). Интерфейс [IShapeBevelEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) представляет неизменяемый объект, содержащий эффективные свойства рельефа грани фигуры. Экземпляр [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) используется как часть интерфейса [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData)) , который является парой [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Этот пример кода показывает, как получить эффективные свойства скосной фигуры:
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
С помощью Aspose.Slides for PHP via Java вы можете получать эффективные свойства Text Frame. Для этой цели в Aspose.Slides был добавлен интерфейс [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormatEffectiveData). Он содержит эффективные свойства форматирования текстового кадра. 

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


## **Получить эффективные свойства стиля текста**
С помощью Aspose.Slides for PHP via Java вы можете получать эффективные свойства Text Style. Для этой цели в Aspose.Slides был добавлен интерфейс [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextStyleEffectiveData). Он содержит эффективные свойства стиля текста.

Этот пример кода показывает, как получить эффективные свойства стиля текста:
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


## **Получить значение эффективной высоты шрифта**
С помощью Aspose.Slides for PHP via Java вы можете получать эффективные свойства высоты шрифта. Здесь приводится код, показывающий изменение эффективного значения высоты шрифта части после установки локальных значений высоты шрифта на разных уровнях структуры презентации:
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
С помощью Aspose.Slides for PHP via Java вы можете получать эффективное форматирование заливки для разных логических частей таблицы. Для этой цели в Aspose.Slides был добавлен интерфейс [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICellFormatEffectiveData). Он содержит эффективные свойства форматирования заливки. Обратите внимание: форматирование ячейки всегда имеет приоритет над форматированием строки; строка имеет приоритет над столбцом; столбец имеет приоритет над всей таблицей.
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

**Как понять, что я получил «снимок», а не «живой объект», и когда следует снова читать эффективные свойства?**

Объекты EffectiveData — это неизменяемые снимки вычисленных значений на момент вызова. Если вы изменяете локальные или унаследованные настройки фигуры, получите эффективные данные снова, чтобы получить обновленные значения.

**Влияет ли изменение макета/слайда‑образца на уже полученные эффективные свойства?**

Да, но только после повторного чтения. Уже полученный объект EffectiveData сам не обновляется — запросите его снова после изменения макета или образца.

**Можно ли изменять значения через EffectiveData?**

Нет. EffectiveData доступен только для чтения. Вносите изменения в локальные объекты форматирования (фигура/текст/3D и т.д.), а затем снова получайте эффективные значения.

**Что происходит, если свойство не установлено ни на уровне фигуры, ни в макете/образце, ни в глобальных настройках?**

Эффективное значение определяется механизмом значений по умолчанию (PowerPoint/ Aspose.Slides). Это разрешённое значение становится частью снимка EffectiveData.

**Можно ли по эффективному значению шрифта определить, какой уровень задал размер или гарнитуру?**

Не напрямую. EffectiveData возвращает окончательное значение. Чтобы найти источник, проверьте локальные значения в части/абзаце/текстовом кадре и стили текста в макете/образце/презентации, где появляется первое явное определение.

**Почему значения EffectiveData иногда выглядят идентичными локальным?**

Потому что локальное значение оказалось окончательным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**

Используйте EffectiveData, когда нужен результат «как отрендерено» после применения всего наследования (например, для согласования цветов, отступов или размеров). Если нужно изменять форматирование на определённом уровне, модифицируйте локальные свойства и, при необходимости, повторно считывайте EffectiveData для проверки результата.