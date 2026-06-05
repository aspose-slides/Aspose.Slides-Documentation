---
title: Получить эффективные свойства фигур из презентаций на PHP
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/php-java/shape-effective-properties/
keywords:
- свойства фигуры
- свойства камеры
- световое оборудование
- фаска формы
- текстовый кадр
- текстовый стиль
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как Aspose.Slides для PHP через Java вычисляет и применяет эффективные свойства фигур для точного отображения PowerPoint."
---
## **Обзор**

Эта статья объясняет разницу между **локальными** и **эффективными** свойствами. Локальные значения — это значения, задаваемые непосредственно на определённом уровне форматирования, например:

1. Свойства фрагмента на слайде.  
1. Прототипные стили текста формы на макете или слайде‑шаблоне, если у формы текстового кадра фрагмента есть такой стиль.  
1. Глобальные настройки текста в презентации.

Локальные значения могут быть определены или опущены на любом уровне. Когда Aspose.Slides требуется окончательное «как отображается» форматирование, она разрешает цепочку наследования и возвращает **эффективные** значения. Вы можете получить их, вызвав метод `getEffective` у локального объекта формата.

Следующий пример показывает, как получить эффективные значения. Предполагается, что первая фигура на первом слайде — это [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) с текстовым кадром и как минимум одним фрагментом.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Эффективные данные форматирования представляют текущие вычисленные свойства после применения наследования. В текущей реализации некоторые объекты эффективных данных, возвращаемые методами, например, [PortionFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/geteffective/), могут кэшироваться внутренне. Повторный вызов `getEffective` после изменения родительского или унаследованного форматирования может обновить кэшированные данные, и ранее полученный объект может больше не соответствовать прежнему состоянию. Если необходимо сохранить эффективные значения для последующего использования, скопируйте требуемые свойства, такие как высота шрифта, цвет заливки, стиль шрифта или выравнивание, в свой собственный объект данных.
{{% /alert %}}

## **Получить эффективные свойства камеры**

Aspose.Slides позволяет получить эффективные свойства камеры. Эффективные данные, возвращаемые [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/geteffective/), содержат окончательные свойства камеры для [ThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/).

Следующий фрагмент кода показывает, как получить эффективные свойства камеры. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Получить эффективные свойства светового оборудования**

Aspose.Slides позволяет получить эффективные свойства светового оборудования. Эффективные данные, возвращаемые [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/geteffective/), содержат окончательные свойства светового оборудования для [ThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/).

Следующий фрагмент кода показывает, как получить эффективные свойства светового оборудования. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Получить эффективные свойства фаски формы**

Aspose.Slides позволяет получить эффективные свойства фаски формы. Эффективные данные, возвращаемые [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/geteffective/), содержат окончательные свойства рельефа для [ThreeDFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/threedformat/).

Следующий фрагмент кода показывает, как получить эффективные свойства верхней фаски формы. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Получить эффективные свойства текстового кадра**

С помощью Aspose.Slides вы можете получить эффективные свойства текстового кадра. Эффективные данные, возвращаемые [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/geteffective/), содержат свойства форматирования текстового кадра.

Следующий фрагмент кода показывает, как получить эффективные свойства форматирования текстового кадра. Предполагается, что первая фигура на первом слайде — это [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) с текстовым кадром.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Получить эффективные свойства текстового стиля**

С помощью Aspose.Slides вы можете получить эффективные свойства текстового стиля. Эффективные данные, возвращаемые [TextStyle.getEffective](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textstyle/geteffective/), содержат свойства текстового стиля.

Следующий фрагмент кода показывает, как получить эффективные свойства текстового стиля. Предполагается, что первая фигура на первом слайде — это [AutoShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/autoshape/) с текстовым кадром.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Получить эффективное значение высоты шрифта**

С помощью Aspose.Slides вы можете получить эффективную высоту шрифта. Ниже показан пример, демонстрирующий, как эффективная высота шрифта фрагмента меняется после задания локальных значений высоты шрифта на разных уровнях структуры презентации.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Получить эффективный формат заливки для таблицы**

С помощью Aspose.Slides вы можете получить эффективное форматирование заливки для разных частей таблицы. Эффективные данные, возвращаемые объектами формата, содержат свойства [FillFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fillformat/). Форматирование ячейки имеет более высокий приоритет, чем форматирование строки; форматирование строки — выше, чем форматирование столбца; форматирование столбца — выше, чем форматирование всей таблицы.

В результате свойства эффективного [CellFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/cellformat/) используются при отрисовке ячейки таблицы. Следующий фрагмент кода показывает, как получить эффективное форматирование заливки для разных частей таблицы. Предполагается, что первая фигура на первом слайде — это [Table](https://reference.aspose.com/slides/ru/php-java/aspose.slides/table/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Возвращает ли `getEffective` «снимок» состояния?**

Не всегда. Эффективные данные представляют вычисленное форматирование после применения наследования, но некоторые объекты эффективных данных могут кэшироваться внутри. Последующий вызов `getEffective` может пересчитать форматирование и обновить кэш, поэтому ранее полученный объект не следует рассматривать как постоянный «снимок».

**Когда следует снова считывать эффективные свойства?**

Вызовите `getEffective` повторно после изменения локального форматирования, родительских стилей, форматирования макета, форматирования шаблона или глобальных настроек презентации. Следующий вызов переоценит иерархию форматирования и вернёт текущий эффективный результат.

**Влияет ли изменение или удаление макета/шаблона на уже полученные эффективные свойства?**

Да, но изменение отразится только при следующем вызове `getEffective`. Если источник родительского форматирования изменён или удалён, ранее полученные эффективные данные могут стать устаревшими. После повторного вызова `getEffective` Aspose.Slides переоценит дерево форматирования, и полученные шрифты, цвета, размеры или другие значения могут измениться.

**Могу ли я модифицировать значения через объекты эффективных данных?**

Нет. Объекты эффективных данных предоставляют только вычисленные значения. Вносите изменения в локальные объекты форматирования, а затем заново получайте эффективные значения.

**Что происходит, если свойство не задано ни на уровне фигуры, ни в макете/шаблоне, ни в глобальных настройках?**

Эффективное значение определяется механизмом значений по умолчанию, включающим настройки PowerPoint и Aspose.Slides. Это разрешённое значение становится частью текущих эффективных данных.

**Можно ли по эффективному значению шрифта определить, на каком уровне был задан размер или типографика?**

Не напрямую. Эффективные данные возвращают окончательное значение. Чтобы определить источник, проверьте локальные значения в фрагменте, абзаце, текстовом кадре и текстовых стилях на уровнях макета, шаблона и презентации, чтобы увидеть, где появилось первое явное определение.

**Почему эффективные значения иногда совпадают с локальными?**

Потому что локальное значение оказалось окончательным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**

Используйте эффективные данные, когда нужен результат «как отображается» после применения всего наследования, например, для согласования цветов, отступов или размеров. Если необходимо сохранить эти значения независимо от будущих изменений форматирования, скопируйте нужные свойства в свой объект. Если требуется изменить форматирование на определённом уровне, модифицируйте локальные свойства и, при необходимости, снова прочитайте эффективные данные, чтобы проверить результат.