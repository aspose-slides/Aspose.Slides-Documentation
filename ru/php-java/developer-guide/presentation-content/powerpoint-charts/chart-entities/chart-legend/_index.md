---
title: Настройка легенд диаграмм в презентациях с использованием PHP
linktitle: Легенда диаграммы
type: docs
url: /ru/php-java/chart-legend/
keywords:
- легенда диаграммы
- позиция легенды
- размер шрифта
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Настройте легенды диаграмм с помощью Aspose.Slides для PHP через Java, чтобы оптимизировать презентации PowerPoint с индивидуальным форматированием легенд."
---
## **Обзор**

Aspose.Slides for PHP via Java предоставляет возможности настройки легенд диаграмм в презентациях PowerPoint. В этой статье показано, как задать позицию и размер легенды, установить размер шрифта для всей легенды, отформатировать отдельный элемент легенды и скрыть или восстановить выбранные элементы.

Раздел FAQ охватывает связанные поведения, включая резервирование места для легенды, отображение многострочных подписей и наследование форматирования из темы презентации.

## **Расположение легенды**

Используйте методы легенды [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/), и [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/), чтобы задать её позицию и размер в виде долей от размеров диаграммы.

В этом примере создаётся презентация и на первый слайд добавляется сгруппированная столбчатая диаграмма с данными по умолчанию. Делением требуемых смещений и размеров легенды на ширину и высоту диаграммы они преобразуются в относительные значения: легенда смещена на 50 пунктов от верхнего левого угла диаграммы и имеет размер 100 × 100 пунктов. Пример использует java_values для преобразования размеров диаграммы, возвращаемых PHP/Java Bridge, в числа PHP перед делением.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // Задайте позицию и размер легенды относительно диаграммы.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Установка размера шрифта легенды**

Используйте [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/), чтобы получить доступ к форматированию текста легенды, и [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight), чтобы задать размер шрифта в пунктах.

В этом примере создаётся диаграмма с данными по умолчанию и задаётся размер текста легенды 20 пунктов. Также отключаются автоматические границы вертикальной оси и задаётся диапазон от -5 до 10.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Установка размера шрифта отдельного элемента легенды**

Используйте коллекцию, возвращаемую методом легенды [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/), чтобы получить форматирование конкретного элемента. Индексы элементов нумеруются с нуля, поэтому индекс `1` относится ко второму элементу.

В этом примере создаётся сгруппированная столбчатая диаграмма, в данных которой по умолчанию присутствует как минимум две серии. Второй элемент легенды форматируется полужирным, курсивом и синим текстом размером 20 пунктов.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Скрытие отдельных элементов легенды**

Чтобы исключить вспомогательную серию из легенды, оставив её данные видимыми, вызовите [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) с параметром `true` через [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/). Это скрывает только выбранный элемент легенды; серия и её точки данных не удаляются. В отличие от этого, вызов [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) с параметром `false` скрывает всю легенду.

В приведённом ниже примере создаётся сгруппированная столбчатая диаграмма с несколькими сериями на основе данных по умолчанию. Он скрывает элемент легенды второй серии (индекс `1`) и сохраняет презентацию. Затем элемент восстанавливается вызовом [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) с параметром `false` и сохраняется вторая копия. Столбцы остаются видимыми в обоих файлах.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // Восстановить тот же элемент без изменения данных диаграммы.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Сравнение ниже демонстрирует одну и ту же диаграмму с видимыми всеми элементами и со скрытым вторым элементом. Столбцы второй серии остаются без изменения.

![Сравнение диаграммы с видимыми всеми элементами легенды и со скрытой второй серией в легенде; все столбцы остаются видимыми.](hide-legend-entry.png)

В столбчатых, линейных и гистограммных диаграммах элементы легенды обозначают серии. Для круговых диаграмм они обозначают отдельные точки данных (секторы), поэтому вместо этого используйте [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) для выбранного сектора. API документирует этот метод точки данных для типов диаграмм `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` и `BarOfPie`. Не следует полагать, что он применим к кольцевым диаграммам, которые не включены в этот список.

## **FAQ**

**Могу ли я заставить диаграмму выделять место для легенды вместо наложения её?**  
Да. Вызовите [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) с параметром `false`, чтобы зарезервировать место для легенды вместо её наложения на область построения.

**Могу ли я сделать многострочные подписи легенды?**  
Да. Длинные подписи могут переноситься, когда доступной ширины недостаточно. Вы также можете использовать символы переноса строки в названиях серий, чтобы задать разрывы.

**Как заставить легенду следовать цветовой схеме темы презентации?**  
Оставьте цвета, заливки и шрифты легенды не заданными, чтобы они наследовали форматирование темы. Явное форматирование переопределяет соответствующие настройки темы.