---
title: Управление метками данных диаграммы в презентациях с использованием JavaScript
linktitle: Метка данных
type: docs
url: /ru/nodejs-java/chart-data-label/
keywords:
- диаграмма
- метка данных
- точность данных
- процент
- расстояние метки
- расположение метки
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как добавлять и форматировать метки данных диаграмм в презентациях PowerPoint, используя JavaScript и Aspose.Slides для Node.js через Java, для создания более захватывающих слайдов."
---
## **Введение**

Метки данных отображают информацию о сериях диаграммы и отдельных точках данных, помогая читателям определять значения и понимать диаграмму. В этой статье объясняется, как форматировать значения, отображать проценты, считывать текст метки, управлять метками за пределами максимума оси, регулировать интервал меток оси категорий и позиционировать метки круговой диаграммы.

## **Установка точности данных в метках диаграммы**

Используйте [setNumberFormatOfValues](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) для форматирования значений серий. Этот пример создаёт линейную диаграмму с данными по умолчанию, отображает её таблицу данных и включает метки значений для первой серии. Формат `#,##0.00` отображает разделитель тысяч и два десятичных знака, не изменяя исходные значения.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    const series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Отображение процента в виде меток**

Для сложенной столбчатой диаграммы вычислите каждое значение как процент от общей суммы категории и присвойте текст фрейму текста, возвращаемому методом [getTextFrameForOverriding](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/). Этот пример использует данные диаграммы по умолчанию и отображает проценты с двумя знаками после запятой шрифтом 8 пунктов. Категории с нулевой общей суммой пропускаются, чтобы избежать деления на ноль. Пересчитайте пользовательский текст метки, если данные диаграммы изменятся.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);

    const categoryTotals = new Array(chart.getChartData().getCategories().size()).fill(0);
    for (let k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
            const series = chart.getChartData().getSeries().get_Item(i);
            const pointValue = series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += Number(pointValue);
        }
    }

    for (let x = 0; x < chart.getChartData().getSeries().size(); x++) {
        const series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            const pointValue = series.getDataPoints().get_Item(j).getValue().getData();
            const dataPointPercent = (Number(pointValue) / categoryTotals[j]) * 100;

            const portion = new aspose.slides.Portion();
            portion.setText(dataPointPercent.toFixed(2) + " %");
            portion.getPortionFormat().setFontHeight(8);

            label.getTextFrameForOverriding().setText("");
            const paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка знака процента в метках диаграммы**

Когда значения хранятся в виде дробей, используйте [setNumberFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) для отображения процентов. Передайте `false` в [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/), чтобы применить формат метки независимо от исходных ячеек.

Этот пример создаёт 100 % сложенную столбчатую диаграмму с красными и синими сериями по четырём категориям. Каждая пара значений складывается в 1. Формат метки `0.0%` отображает 0.30 как 30.0 %, а вертикальная ось использует два знака после запятой. Обе серии используют белый текст метки размером 10 пунктов.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    for (let i = 0; i < 4; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    const seriesNames = ["Reds", "Blues"];
    const white = java.getStaticFieldValue("java.awt.Color", "WHITE");
    const seriesColors = [java.getStaticFieldValue("java.awt.Color", "RED"), java.getStaticFieldValue("java.awt.Color", "BLUE")];
    const values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]];

    for (let i = 0; i < seriesNames.length; i++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (let j = 0; j < 4; j++) {
            const valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        const labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(white);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Чтение фактического текста меток данных**

Используйте [getActualLabelText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) для получения текста, сформированного настройками метки данных. Это полезно при извлечении меток для отчётов, поиске содержимого презентаций или проверке сгенерированных диаграмм. В примере ниже стандартный [data label format](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datalabelformat/) комбинирует имя категории, имя серии и значение. Одна точка форматирует своё значение как процент, а другая использует пользовательский текст из [getTextFrameForOverriding](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    const secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    const northSeriesCell = workbook.getCell(0, 0, 1, "North");
    const north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    const northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    const northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    const southSeriesCell = workbook.getCell(0, 0, 2, "South");
    const south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    const southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    const southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        const format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const point = series.getDataPoints().get_Item(j);
            const label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            console.log("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

Число, хранящееся в точке данных, остаётся `0.75`, даже когда её метка показывает `75 %` вместе с именами категории и серии. Пользовательский текст заменяет сгенерированный текст метки. [getActualLabelText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) возвращает полученную строку метки в обоих случаях. Проверяйте [isVisible](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datalabel/isvisible/) отдельно, как показано выше, когда нужно извлекать только видимые метки.

## **Управление метками данных за пределами максимума оси**

Когда вы вручную ограничиваете диапазон оси, некоторые точки данных могут превышать её максимум. Используйте [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) для управления тем, показываются ли их метки. Эта настройка меняет видимость меток; она не меняет диапазон оси и не изменяет исходные значения данных.

В примере ниже создаётся 2D сгруппированная столбчатая диаграмма со значениями 60 и 120. Метод [setAutomaticMaxValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) получает `false`, а максимальное значение оси задаётся `100` через [setMaxValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/axis/setmaxvalue/). На первом слайде метки отображаются за пределами максимума; копия этого слайда отключает их. Оба слайда сохраняются в `DataLabelsOverMaximum.pptx`.

Включите метки значений с помощью [setShowValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datalabelformat/setshowvalue/). Эта настройка уровня диаграммы не включает отображение значений сама по себе и не переопределяет отключённое отображение значения отдельной метки. В примере значения включаются для всей серии, а [setPosition](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datalabelformat/setposition/) размещает метки в наружном конце каждого столбца.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();

    const firstCategory = workbook.getCell(0, 1, 0, "Within range");
    const secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    const seriesName = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    const firstValue = workbook.getCell(0, 1, 1, 60);
    const secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    const secondSlide = presentation.getSlides().addClone(slide);
    const secondChart = secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Следующие изображения показывают сохранённые слайды, отрендеренные в Microsoft PowerPoint. При `true` метка **120** видна у верхней границы; при `false` она скрыта. Метка **60** остаётся видимой, максимум оси остаётся **100**, а вторая точка данных остаётся **120** в обоих случаях.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Диаграмма PowerPoint, показывающая метку значения 120 при максимуме оси 100](data-labels-over-maximum-true.png) | ![Диаграмма PowerPoint, скрывающая метку значения 120 при максимуме оси 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
В этом примере используется 2D столбчатая диаграмма с осью значений. Диаграммы без оси значений, такие как круговые и кольцевые диаграммы, не имеют максимума оси, который можно было бы ограничить таким образом.
{{% /alert %}}

## **Установка отступа метки от оси**

Используйте [setLabelOffset](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/axis/setlabeloffset/) для управления расстоянием между метками оси категорий и осью. Значение задаётся в процентах от максимального размера шрифта меток оси. Этот пример создаёт сгруппированную столбчатую диаграмму и устанавливает смещение меток горизонтальной оси в 500. Эта настройка влияет на метки оси категорий, а не на метки, привязанные к отдельным точкам данных.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Регулировка положения метки**

На круговой диаграмме регулируйте позицию меток данных, чтобы улучшить spacing и освободить место для выносных линий.

Этот пример отображает значение первой точки данных, помещает её метку за пределами сектора и регулирует горизонтальное и вертикальное смещения с помощью [setX](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datalabel/setx/) и [setY](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/datalabel/sety/). Эти смещения относительны к ширине и высоте диаграммы соответственно.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    const series = chart.getChartData().getSeries();

    const label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(java.newFloat(0.71));
    label.setY(java.newFloat(0.04));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Круговая диаграмма с отрегулированным положением метки данных](pie-chart-adjusted-label.png)

## **FAQ**

**Как я могу предотвратить перекрытие меток данных на плотных диаграммах?**

Сочетайте автоматическое размещение меток, выносные линии и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или отображайте метки только для экстремальных значений или ключевых точек.

**Как отключить метки только для нулевых, отрицательных или пустых значений?**

Отфильтруйте точки данных перед включением меток и отключите отображение для значений 0, отрицательных значений или отсутствующих данных согласно заданному правилу.

**Как обеспечить единообразный стиль меток при экспорте в PDF/изображения?**

Явно задайте семейство шрифта и размер, а также проверьте, что шрифт доступен в среде рендеринга, чтобы избежать использования резервного варианта.