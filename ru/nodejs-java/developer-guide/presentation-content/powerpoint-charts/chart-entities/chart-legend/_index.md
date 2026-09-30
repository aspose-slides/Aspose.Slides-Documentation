---
title: Настройка легенд диаграмм в презентациях с использованием JavaScript
linktitle: Легенда диаграммы
type: docs
url: /ru/nodejs-java/chart-legend/
keywords:
- легенда диаграммы
- позиция легенды
- размер шрифта
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Настройте легенды диаграмм с помощью Aspose.Slides for Node.js via Java для оптимизации презентаций PowerPoint с индивидуальным форматированием легенд."
---
## **Обзор**

Aspose.Slides for Node.js via Java предоставляет возможности настройки легенд диаграмм в презентациях PowerPoint. В этой статье показано, как задать позицию и размер легенды, установить размер шрифта для всей легенды, отформатировать отдельный элемент легенды и скрыть или восстановить выбранные элементы.

В разделе FAQ рассматриваются связанные поведения, включая резервирование места для легенды, отображение многострочных меток и наследование форматирования из темы презентации.

## **Позиционирование легенды**

Используйте методы легенды [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/) и [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) для указания её позиции и размеров в долях от размеров диаграммы.

В этом примере создаётся презентация и добавляется сгруппированная столбчатая диаграмма с данными по умолчанию на первый слайд. Деление желаемых смещений и размеров легенды на ширину и высоту диаграммы переводит их в относительные значения: легенда смещена на 50 пунктов от верхнего левого угла диаграммы и имеет размер 100 × 100 пунктов.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Задайте позицию и размер легенды относительно диаграммы.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка размера шрифта легенды**

Получите объект форматирования текста легенды через [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) и задайте размер шрифта в пунктах с помощью [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight).

В этом примере создаётся диаграмма с данными по умолчанию и задаётся размер шрифта текста легенды — 20 пунктов. Также отключаются автоматические границы вертикальной оси и задаётся диапазон от ‑5 до 10.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка размера шрифта отдельного элемента легенды**

Получите коллекцию, возвращаемую методом [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) легенды, чтобы обратиться к форматированию конкретного элемента. Индексы элементов начинаются с нуля, поэтому индекс `1` относится ко второму элементу.

В этом примере создаётся сгруппированная столбчатая диаграмма, у которой данные по умолчанию включают как минимум две серии. Второй элемент легенды форматируется полужирным, курсивом и синим текстом размером 20 пунктов.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Скрытие отдельных элементов легенды**

Чтобы исключить вспомогательную серию из легенды, оставив её данные видимыми, вызовите [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) со значением `true` через [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/). Это скрывает только выбранный элемент легенды; серия и её точки данных остаются. В отличие от этого, вызов [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) со значением `false` скрывает всю легенду.

Ниже пример, где создаётся сгруппированная столбчатая диаграмма с несколькими сериями на основе данных по умолчанию. Скрывается элемент легенды второй серии (индекс `1`) и презентация сохраняется. Затем элемент восстанавливается вызовом [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) со значением `false` и сохраняется вторая копия. Столбцы остаются видимыми в обоих файлах.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // Восстановить тот же элемент без изменения данных диаграммы.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сравнение ниже показывает одну и ту же диаграмму с видимыми всеми элементами легенды и с скрытым вторым элементом. Столбцы второй серии остаются без изменений.

![Сравнение диаграммы с видимыми всеми элементами легенды и с скрытым элементом серии 2; все столбцы остаются видимыми.](hide-legend-entry.png)

В столбчатых, линейных и гистограммах элементы легенды идентифицируют серии. В круговых диаграммах они идентифицируют отдельные точки данных (дольки), поэтому используйте [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) для выбранной дольки. API документирует этот метод для типов диаграмм `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` и `BarOfPie`. Не следует считать, что он применим к кольцевым диаграммам, которые в этом списке не указаны.

## **FAQ**

**Можно ли заставить диаграмму выделять место для легенды вместо её наложения?**

Да. Вызовите [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) со значением `false`, чтобы зарезервировать место для легенды, а не позволять ей накладываться на область построения.

**Можно ли делать многострочные подписи в легенде?**

Да. Длинные подписи могут переноситься, если доступной ширины недостаточно. Также можно использовать символы новой строки в названиях серий, чтобы задать разрывы строк.

**Как сделать так, чтобы легенда использовала цветовую схему темы презентации?**

Не задавайте явно цвета, заливки и шрифты для легенды, чтобы она могла наследовать форматирование из темы. Явное форматирование переопределяет соответствующие настройки темы.