---
title: Эффективные свойства формы
type: docs
weight: 50
url: /ru/php-java/shape-effective-properties/
---

В этой теме мы обсудим **эффективные** и **локальные** свойства. Когда мы устанавливаем значения непосредственно на этих уровнях

1. В свойствах порции на слайде порции;
1. В текстовом стиле формы прототипа на макете или основном слайде (если форма текстового фрейма порции имеет один);
1. В глобальных текстовых настройках презентации;

эти значения называются **локальными** значениями. На любом уровне **локальные** значения могут быть определены или опущены. Но когда приложению необходимо знать, как должна выглядеть порция, оно использует **эффективные** значения. Вы можете получить эффективные значения, используя метод **getEffective()** из локального формата.

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

## **Получение эффективных свойств камеры**
Aspose.Slides для PHP через Java позволяет разработчикам получать эффективные свойства камеры. Для этой цели в Aspose.Slides был добавлен интерфейс [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData). Интерфейс [ICameraEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) представляет собой неизменяемый объект, который содержит эффективные свойства камеры. Экземпляр интерфейса [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) используется как часть интерфейса [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData), который является парой [эффективных значений](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Этот пример кода показывает, как получить эффективные свойства для камеры:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Эффективные свойства камеры =");
    echo("Тип: " . $threeDEffectiveData->getCamera()->getCameraType());
    echo("Угол обзора: " . $threeDEffectiveData->getCamera()->getFieldOfViewAngle());
    echo("Масштаб: " . $threeDEffectiveData->getCamera()->getZoom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Получение эффективных свойств Light Rig**
Aspose.Slides для PHP через Java позволяет разработчикам получать эффективные свойства Light Rig. Для этой цели в Aspose.Slides был добавлен интерфейс [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData). Интерфейс [ILightRigEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) представляет собой неизменяемый объект, который содержит эффективные свойства Light Rig. Экземпляр интерфейса [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) используется как часть интерфейса [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData), который является парой [эффективных значений](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Этот пример кода показывает, как получить эффективные свойства Light Rig:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Эффективные свойства Light Rig =");
    echo("Тип: " . $threeDEffectiveData->getLightRig()->getLightType());
    echo("Направление: " . $threeDEffectiveData->getLightRig()->getDirection());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Получение эффективных свойств Bevel Shape**
Aspose.Slides для PHP через Java позволяет разработчикам получать эффективные свойства Bevel Shape. Для этой цели в Aspose.Slides был добавлен интерфейс [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData). Интерфейс [IShapeBevelEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) представляет собой неизменяемый объект, который содержит эффективные свойства рельефа верхней грани формы. Экземпляр интерфейса [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) используется как часть интерфейса [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData)), который является парой [эффективных значений](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) для класса [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat).

Этот пример кода показывает, как получить эффективные свойства для Bevel Shape:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Эффективные свойства верхней грани формы =");
    echo("Тип: " . $threeDEffectiveData->getBevelTop()->getBevelType());
    echo("Ширина: " . $threeDEffectiveData->getBevelTop()->getWidth());
    echo("Высота: " . $threeDEffectiveData->getBevelTop()->getHeight());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Получение эффективных свойств текстового фрейма**
Используя Aspose.Slides для PHP через Java, вы можете получить эффективные свойства текстового фрейма. Для этой цели в Aspose.Slides был добавлен интерфейс [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormatEffectiveData). Он содержит эффективные свойства форматирования текстового фрейма.

Этот пример кода показывает, как получить эффективные свойства форматирования текстового фрейма:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    echo("Тип привязки: " . $effectiveTextFrameFormat::getAnchoringType());
    echo("Тип автоподбора: " . $effectiveTextFrameFormat::getAutofitType());
    echo("Вертикальный текст: " . $effectiveTextFrameFormat::getTextVerticalType());
    echo("Отступы");
    echo("   Слева: " . $effectiveTextFrameFormat::getMarginLeft());
    echo("   Сверху: " . $effectiveTextFrameFormat::getMarginTop());
    echo("   Справа: " . $effectiveTextFrameFormat::getMarginRight());
    echo("   Снизу: " . $effectiveTextFrameFormat::getMarginBottom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Получение эффективных свойств стиля текста**
Используя Aspose.Slides для PHP через Java, вы можете получить эффективные свойства стиля текста. Для этой цели в Aspose.Slides был добавлен интерфейс [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextStyleEffectiveData). Он содержит эффективные свойства стиля текста.

Этот пример кода показывает, как получить эффективные свойства стиля текста:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextStyle = $shape->getTextFrame()->getTextFrameFormat()->getTextStyle()->getEffective();
    for($i = 0; $i <= 8; $i++) {
      $effectiveStyleLevel = $effectiveTextStyle->getLevel($i);
      echo("= Эффективное форматирование абзацев для уровня стиля #" . $i . " =");
      echo("Глубина: " . $effectiveStyleLevel->getDepth());
      echo("Отступ: " . $effectiveStyleLevel->getIndent());
      echo("Выравнивание: " . $effectiveStyleLevel->getAlignment());
      echo("Выравнивание шрифта: " . $effectiveStyleLevel->getFontAlignment());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Получение эффективного значения высоты шрифта**
Используя Aspose.Slides для PHP через Java, вы можете получить эффективные свойства высоты шрифта. Здесь мы предоставляем код, который демонстрирует изменение эффективного значения высоты шрифта порции после установки локальных значений высоты шрифта на различных уровнях структуры презентации:

```php
  $pres = new Presentation();
  try {
    $newShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $newShape->addTextFrame("");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->clear();
    $portion0 = new Portion("Пример текста с первой порцией");
    $portion1 = new Portion(" и второй порцией.");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion0);
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion1);
    echo("Эффективная высота шрифта сразу после создания:");
    echo("Порция #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Порция #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(24);
    echo("Эффективная высота шрифта после установки высоты шрифта по умолчанию для всей презентации:");
    echo("Порция #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Порция #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(40);
    echo("Эффективная высота шрифта после установки высоты шрифта по умолчанию для абзаца:");
    echo("Порция #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Порция #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(55);
    echo("Эффективная высота шрифта после установки высоты шрифта для порции #0:");
    echo("Порция #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Порция #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setFontHeight(18);
    echo("Эффективная высота шрифта после установки высоты шрифта для порции #1:");
    echo("Порция #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Порция #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Получение эффективного формата заливки для таблицы**
Используя Aspose.Slides для PHP через Java, вы можете получить эффективное форматирование заливки для различных логических частей таблицы. Для этой цели в Aspose.Slides был добавлен интерфейс [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICellFormatEffectiveData). Он содержит эффективные свойства форматирования заливки. Обратите внимание на это: форматирование ячейки всегда имеет приоритет над форматированием строки; форматирование строки имеет приоритет над форматированием столбца; и форматирование столбца имеет приоритет над всей таблицей.

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