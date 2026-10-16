---
title: Управление подписями данных диаграмм в презентациях с помощью JavaScript
linktitle: Подпись данных
type: docs
url: /ru/nodejs-java/chart-data-label/
keywords:
- диаграмма
- подпись данных
- точность данных
- процент
- расстояние подписи
- расположение подписи
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как добавлять и форматировать подписи данных диаграмм в презентациях PowerPoint с помощью JavaScript и Aspose.Slides для Node.js через Java для более привлекательных слайдов."
---
## **Введение**

Подписи данных отображают информацию о рядах диаграммы и отдельных точках данных, помогая читателям идентифицировать значения и понимать диаграмму. В этой статье объясняется, как форматировать значения, отображать проценты, считывать текст подписи, управлять подписями за пределами максимального значения оси, регулировать расстояние между подписями категориальной оси и размещать подписи на круговой диаграмме.

## **Установка точности данных в подписи диаграммы**

Используйте [setNumberFormatOfValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) для форматирования значений ряда. Этот пример создает линейную диаграмму с данными по умолчанию, отображает её таблицу данных и включает подписи значений для первого ряда. Формат `#,##0.00` отображает разделитель тысяч и два знака после запятой, не изменяя исходные значения.

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

## **Отображение процентов в подписях**

Для составной столбчатой диаграммы вычислите каждый показатель как процент от общей суммы категории и присвойте текст текстовому кадру, возвращаемому методом [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/). Этот пример использует данные диаграммы по умолчанию и отображает проценты с двумя знаками после запятой шрифтом 8 пунктов. Категории с нулевой суммой пропускаются, чтобы избежать деления на ноль. При изменении данных диаграммы пересчитайте пользовательский текст подписи.

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

## **Установка знака процента в подписях диаграммы**

Когда значения хранятся в виде дробей, используйте [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) для отображения процентов. Передайте `false` в [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/), чтобы применить формат подписи независимо от исходных ячеек.

В этом примере создаётся 100% составная столбчатая диаграмма с красными и синими рядами по четырём категориям. Каждая пара значений в сумме дает 1. Формат подписи `0.0%` выводит 0.30 как 30.0%, в то время как вертикальная ось использует два знака после запятой. Оба ряда используют белый текст подписи размером 10 пунктов.

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

## **Чтение фактического текста подписи данных**

Используйте [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) для получения текста, сформированного настройками подписи данных. Это полезно при извлечении подписей для отчетов, поиске содержимого презентаций или проверке сгенерированных диаграмм. В примере ниже формат подписи по умолчанию [data label format](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/) сочетает название категории, название ряда и значение. Для одной точки значение форматируется как процент, а для другой используется пользовательский текст из [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/).

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

Число, хранящееся в точке данных, остаётся `0.75`, даже если её подпись отображает `75%` вместе с названиями категории и ряда. Пользовательский текст заменяет сгенерированный текст подписи. [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) возвращает полученную строку подписи в обоих случаях. При необходимости извлекать только видимые подписи проверяйте [isVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/isvisible/) отдельно, как показано выше.

## **Управление подписями данных за пределами максимального значения оси**

Если ограничить диапазон оси вручную, отдельные точки данных могут превышать её максимум. Используйте [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) для управления отображением их подписей. Эта настройка меняет видимость подписи; она не меняет диапазон оси или исходные значения данных.

В приведённом примере создаётся 2‑D группированная столбчатая диаграмма со значениями 60 и 120. Метод [setAutomaticMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) получает значение `false`, а на вертикальной оси задаётся максимум 100 с помощью [setMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmaxvalue/). На первом слайде подписи за пределами максимума отображаются; копия этого слайда отключает их. Оба слайда сохраняются в файле `DataLabelsOverMaximum.pptx`.

Включите подписи значений с помощью [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/). Настройка уровня диаграммы не включает отображение значений сама по себе и не переопределяет отключённое отображение значения отдельной подписи. В этом примере включаются значения для всего ряда и используется [setPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setposition/) для размещения подписей у внешнего конца каждого столбца.

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

Ниже показаны сохранённые слайды, отрисованные в Microsoft PowerPoint. При `true` подпись **120** видна у верхней границы; при `false` она скрыта. Подпись **60** остаётся видимой, максимум оси остаётся **100**, а второе значение данных остаётся **120** в обоих случаях.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Диаграмма PowerPoint, отображающая подпись значения 120 при максимуме оси 100](data-labels-over-maximum-true.png) | ![Диаграмма PowerPoint, скрывающая подпись значения 120 при максимуме оси 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
В этом примере используется 2‑D столбчатая диаграмма с осью значений. Диаграммы без оси значений, такие как круговые и кольцевые диаграммы, не имеют максимального значения оси, которое можно было бы ограничить таким способом.
{{% /alert %}}

## **Установка расстояния подписи от оси**

Используйте [setLabelOffset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlabeloffset/) для управления расстоянием между подписями категориальной оси и самой осью. Значение представляет собой процент от максимального размера шрифта подписей оси. В этом примере создаётся группированная столбчатая диаграмма и устанавливается смещение подписи горизонтальной оси в 500. Эта настройка влияет на подписи категориальной оси, а не на подписи, привязанные к отдельным точкам данных.

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

## **Регулировка расположения подписи**

На круговой диаграмме регулируйте позиции подписей данных для улучшения интервалов и создания места для выноски.

В этом примере отображается значение первой точки данных, подпись размещается за пределами сектора и её горизонтальное и вертикальное смещения регулируются с помощью [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) и [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/). Эти смещения относятся соответственно к ширине и высоте диаграммы.

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

![Круговая диаграмма с отрегулированным положением подписи данных](pie-chart-adjusted-label.png)

## **Форматирование выносных линий**

Когда подписи круговой диаграммы находятся за пределами секторов, выносные линии помогают читателям сопоставить каждое значение с соответствующим сектором. Контрастный цвет и слегка более толстая линия делают соединения легче воспринимаемыми, а прозрачность и пунктирный стиль сохраняют линии визуально ненавязчивыми.

Используйте [getLeaderLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelcollection/getleaderlinesformat/) для форматирования выносных линий на уровне коллекции подписей ряда. Параметры в `series.getLabels().getLeaderLinesFormat().getLine()` применяются к всей коллекции, а не к отдельной подписи.

В этом примере создаётся круговая диаграмма с данными по умолчанию, значения отображаются за пределами секторов и включается [setShowLeaderLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowleaderlines/). Две подписи смещаются дальше от своих секторов с помощью смещений [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) и [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/), задаваемых в долях ширины и высоты диаграммы. Входная презентация не требуется.

Метод линии [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) задаёт сплошной синий цвет с альфа‑значением 191 из 255, что обеспечивает примерно 25 % прозрачности. [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/) задаёт толщину 2 пункта, а [setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setdashstyle/) делает линию пунктирной.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 80, 50, 560, 400);
    chart.setLegend(false);

    const series = chart.getChartData().getSeries().get_Item(0);

    const labelFormat = series.getLabels().getDefaultDataLabelFormat();
    labelFormat.setShowValue(true);
    labelFormat.setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    labelFormat.setShowLeaderLines(true);

    // Переместить две подписи дальше от их секторов.
    series.getLabels().get_Item(0).setX(java.newFloat(0.10));
    series.getLabels().get_Item(0).setY(java.newFloat(-0.05));
    series.getLabels().get_Item(1).setX(java.newFloat(-0.10));
    series.getLabels().get_Item(1).setY(java.newFloat(0.05));

    const line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 30, 90, 160, 191);
    line.getFillFormat().getSolidFillColor().setColor(lineColor);
    line.setWidth(2);
    line.setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    presentation.save("FormattedLeaderLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Включение выносных линий не гарантирует, что линия появится у каждой подписи. Видимость зависит от размещения подписи и поведения компоновки диаграммы. В этом примере у двух смещённых подписей есть видимые выносные линии; подписи, оставшиеся близко к своим секторам, их не требуют.

На следующем изображении показан сохранённый файл `FormattedLeaderLines.pptx`, отрисованный с помощью Aspose.Slides:

![Круговая диаграмма с синими полупрозрачными пунктирными выносными линиями, соединяющими две внешние подписи с их секторами](formatted-leader-lines.png)

## **Добавление нескольких строк подписей над столбчатой диаграммой**

В этом примере создаётся столбчатая диаграмма с двумя строками подписей над областью построения. Ряд A отображает видимые столбцы, а ряды B и C предоставляют дополнительные подписи. Их столбцы скрыты за счёт удаления заливки и контура. Метод [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) выравнивает все три ряда по центрам категорий.

Настройки [ChartPlotArea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartplotarea/) резервируют место для строк подписей. После того как [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) вычисляет позиции по умолчанию, [DataLabel.setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) и [DataLabel.setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) сохраняют горизонтальное выравнивание и применяют вертикальные смещения для размещения подписей в две строки. Числа остаются подписями данных, привязанными к значениям рядов; только заголовки строк являются отдельными текстовыми фигурами.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categories = ["North", "South", "East", "West"];
    const seriesNames = ["Series A", "Series B", "Series C"];
    const seriesValues = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]];

    for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        const categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        const seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        const series = chart.getChartData().getSeries().add(seriesCell, aspose.slides.ChartType.ClusteredColumn);

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // Скрыть столбцы B и C, но оставить их подписи данных.
            series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            const labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
            labelFill.getSolidFillColor().setColor(black);
            series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.InsideBase);
        }
    }

    // Выровнять все три ряда по одинаковым центрам категорий.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(java.newByte(100));

    // Использовать меньше линий сетки для этого компактного примера.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Зарезервировать место над областью построения для двух строк подписей данных.
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    chart.getPlotArea().setX(java.newFloat(0.15));
    chart.getPlotArea().setY(java.newFloat(0.32));
    chart.getPlotArea().setWidth(java.newFloat(0.80));
    chart.getPlotArea().setHeight(java.newFloat(0.48));
    chart.validateChartLayout();

    for (let seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const rowTop = seriesIndex == 1 ? 0.15 : 0.03;

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // Сохранить позицию по умолчанию по горизонтали. Y — смещение от
            // позиции подписи по умолчанию, выраженное в долях высоты диаграммы.
            dataLabel.setX(0);
            dataLabel.setY(java.newFloat(rowTop - dataLabel.getActualY() / chart.getHeight()));
        }

        // Только заголовок строки является отдельной текстовой фигурой.
        const rowHeading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        const headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        headingFormat.getFillFormat().getSolidFillColor().setColor(black);
    }

    presentation.save("multiple-rows-of-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Столбчатая диаграмма с двумя строками подписей над областью построения](multiple-rows-of-labels.png)

## **FAQ**

**Как предотвратить наложение подписей данных на плотных диаграммах?**

Сочетайте автоматическое размещение подписей, выносные линии и уменьшенный размер шрифта; при необходимости скрывайте некоторые поля (например, категорию) или отображайте подписи только для экстремальных значений или ключевых точек.

**Как отключить подписи только для нулевых, отрицательных или пустых значений?**

Отфильтруйте точки данных перед включением подписей и отключите отображение для значений 0, отрицательных или отсутствующих значений согласно заданному правилу.

**Как обеспечить единообразный стиль подписи при экспорте в PDF/изображения?**

Явно задайте семейство и размер шрифта и убедитесь, что шрифт доступен в среде рендеринга, чтобы избежать замены.