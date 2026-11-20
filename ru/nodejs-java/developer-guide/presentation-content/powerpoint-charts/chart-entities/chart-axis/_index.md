---
title: Настройка осей диаграмм в презентациях с использованием JavaScript
linktitle: Ось диаграммы
type: docs
url: /ru/nodejs-java/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настройка оси
- управление осью
- управление осью
- свойства оси
- максимальное значение
- минимальное значение
- линия оси
- формат даты
- заголовок оси
- позиция оси
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как использовать JavaScript с Aspose.Slides для Node.js через Java для настройки осей диаграмм в презентациях PowerPoint для отчетов и визуализаций."
---
## **Обзор**

В этой статье описывается, как настраивать оси диаграмм с помощью Aspose.Slides for Node.js via Java. Рассматриваются вычисляемые значения осей, переключение строк и столбцов диаграммы, видимость осей, интервалы подписей категорий и делений, датированные категории и их форматирование, поворот заголовка, позиционирование осей, единицы отображения и логарифмическое масштабирование.

## **Получить максимальные значения по вертикальной оси диаграмм**

Создайте [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и добавьте областьную диаграмму с данными по умолчанию. Вызовите [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) перед чтением вычисленных значений осей, чтобы макет диаграммы был актуален.

Прочитайте [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) и [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) для пределов оси, а также [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) и [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) для интервалов делений. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) и [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) предоставляют масштабы единиц времени, которые имеют значение для датированных осей. В примере эти значения сохраняются в локальные переменные и диаграмма сохраняется.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Перестановка данных между осями**

Используйте [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) для обмена ролями рядов и категорий в данных диаграммы. Каждая прежняя категория становится рядом, а каждый прежний ряд — категорией. Это меняет способ группировки данных; оси не меняются местами. В примере применяется [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) для привязки данных по умолчанию к `Sheet1!A1:D5`, включая строку заголовка и столбец категорий, перед перестановкой строк и столбцов. Сохраняется диаграмма с четырьмя рядами и тремя категориями.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Обратный порядок построения по оси**

Используйте [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) для обратного порядка построения категориальной или значительной оси. Например, горизонтальная гистограмма может показывать стадии проекта сверху вниз в том же порядке, что и в листе: Планирование, Разработка, Тестирование. Обратный порядок изменяет направление построения; он не сортирует и не переставляет данные листа. Для сравнения, [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) меняет роли рядов и категорий.

В следующем примере создаётся горизонтальная гистограмма с тремя стадиями и одним рядом. Сохраняется презентация из трёх слайдов: обычный порядок, обратные категории и обратные значения. Каждая копия использует один и тот же набор данных, и только одна ось в каждой копии обратна.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Слайд 2: отображать первую категорию вверху.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Сохранить горизонтальную ось значений внизу.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // Слайд 3: обратить лишь горизонтальную числовую шкалу.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Обратный порядок оси может также переместить перпендикулярную ось на противоположную сторону построения. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) управляет тем, где другая ось пересекает настраиваемую ось. На слайде 2 вызов с параметром `aspose.slides.CrossesType.Maximum` для обратной категориальной оси оставляет горизонтальную значительную ось внизу. Для указания конкретной точки пересечения используйте [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Проверьте настройки пересечения при изменении направления, особенно если у диаграммы уже задана пользовательская точка пересечения. Вызов `setPlotOrderReversed` с `false` восстанавливает обычное направление построения; настройки пересечения независимы от этого.

| Обычный порядок (слайд 1) | Обратные категории (слайд 2) | Обратные значения (слайд 3) |
| --- | --- | --- |
| ![Горизонтальная гистограмма с обычным порядком категорий и значений](axis-order-normal.png) | ![Горизонтальная гистограмма с отображением категорий сверху вниз](axis-order-categories-reversed.png) | ![Горизонтальная гистограмма с обратной значительной осью и нулём справа](axis-order-values-reversed.png) |
| Категории идут снизу вверх; значения растут слева направо. | Планирование, Разработка и Тестирование идут сверху вниз. Значения и порядок строк листа не изменяются. | Категории сохраняют обычный порядок; значения растут справа налево. Категориальная ось пересекает ось значений в нуле справа. |

## **Скрыть вертикальную ось для линейных диаграмм**

Вызовите [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) с параметром `false` для вертикальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой вертикальной осью.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Скрыть горизонтальную ось для линейных диаграмм**

Вызовите [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) с параметром `false` для горизонтальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой горизонтальной осью.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Показать или скрыть линии сетки диаграммы**

Вызовите [getShowMajorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowmajorgridlines/) и [getShowMinorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowminorgridlines/) для проверки, какие линии сетки отображаются у оси. Чтобы отобразить мелкие линии сетки, используйте [getMinorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getminorgridlinesformat/) и задайте заливку линии сплошным видимым цветом. Чтобы скрыть их, установите заливку в [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/). Для основных линий сетки используйте [getMajorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getmajorgridlinesformat/) аналогичным способом. Изменение заливки сохраняет видимость оси и деления.

Вертикальная ось этой сгруппированной столбчатой диаграммы изначально показывает только основные линии сетки. В примере мелкие линии сетки выводятся оранжевым цветом, затем снова скрываются перед сохранением презентации. На каждом этапе выводится информация о видимости линий сетки.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 30, 660, 230);
    var axis = chart.getAxes().getVerticalAxis();
    console.log("Initial: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    var minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    var darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    minorFill.getSolidFillColor().setColor(darkOrange);
    console.log("Enabled: minor=%s", axis.getShowMinorGridLines());

    minorFill.setFillType(java.newByte(aspose.slides.FillType.NoFill));
    console.log("Hidden: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Мелкие линии сетки включены | Мелкие линии сетки скрыты |
| --- | --- |
| ![Оранжевые мелкие линии сетки между основными линиями сетки на вертикальной оси](minor-gridlines-enabled.png) | ![Та же столбчатая диаграмма только с основными линиями сетки](minor-gridlines-hidden.png) |

## **Изменить категориальную ось**

Используйте [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) для выбора датированной или текстовой категориальной оси. Этот пример требует файл `ExistingChart.pptx`, где диаграмма является первой фигурой на первом слайде, а ячейки категорий содержат числовые даты Excel. Горизонтальная ось меняется на датированную. Вызов [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) с `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) с `1` и [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) с `TimeUnitType.Months` размещают основные деления с интервалом в один месяц.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Определить тип категориальной оси по данным**

После заполнения категорий вызовите [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistypeautomatically/), затем прочитайте [getCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getcategoryaxistype/) для проверки результата. Это полезно, когда одна и та же диаграмма может получать либо текстовые метки, либо числовые датированные значения. Метод определяет тип в момент вызова; он не включает постоянный режим, который переоценивает последующие изменения данных. Вызовите его снова после замены категорий.

В следующем примере создаётся диаграмма с текстовыми категориями и выводится `true`, когда выбран тип `CategoryAxisType.Text`. Затем значения ячеек категорий заменяются датами, метод вызывается снова, и выводится `true` для типа `CategoryAxisType.Date`. Даты хранятся как числовые OLE Automation значения, вычисляемые как количество дней, прошедших с 30 декабря 1899, а не как строки дат. Расчёт в JavaScript использует UTC‑метки и делит разницу на 86 400 000 миллисекунд в дне; индексы месяцев начинаются с нуля. Для передачи каждой даты в Java как `double` используйте `java.newDouble`. [setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) управляет отображением этих значений; он не преобразует текст в числовые даты. Подробнее о ячейках категорий см. [Chart Workbook](/slides/ru/nodejs-java/chart-workbook/).

Используйте автоматическое определение, когда известно, что входные данные содержат либо текстовые категории, либо числовые даты, как в этом примере. Для обычных числовых меток, смешанных категорий или пустых данных явно вызывайте [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) для указания нужного типа. Одни лишь числовые значения не гарантируют, что категории представляют даты.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var seriesName = workbook.getCell(0, 0, 1, "Sales");
    var series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    var labels = ["First", "Second", "Third"];

    for (var i = 0; i < labels.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Text); // true

    var baseDate = Date.UTC(1899, 11, 30);
    var dates = [Date.UTC(2026, 0, 1), Date.UTC(2026, 0, 2), Date.UTC(2026, 1, 1)];

    for (var i = 0; i < dates.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0);
        var dateValue = java.newDouble((dates[i] - baseDate) / 86400000);
        categoryCell.setValue(dateValue);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Date); // true

    presentation.save("AutomaticCategoryAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Управление интервалами подписей категориальной оси**

Когда в диаграмме много категорий, уменьшите количество видимых подписей оси, не удаляя категории и точки данных. Вызовите [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) с `false`, затем задайте нужный интервал категорий через [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Для текстовых категорий в их обычном порядке нумерация начинается с первой категории:

| Интервал | Подписи, отображаемые в примере |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

Интервал `3` отображает каждую третью подпись, скрывая две между ними. Это не удаляет соответствующие столбцы. Автоматический интервал выбирается исходя из доступного пространства; он не обязателен к отображению каждой подписи.

Деления имеют отдельные настройки. Вызовите [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) с `false` и используйте [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) для задания их интервала. Например, `1` оставит деление на каждом интервале категории, тогда как подписи будут показываться только каждую третью. Используйте [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) с видимым стилем, чтобы увидеть результат. Повторный вызов автоматических методов с `true` возвращает прежний автоматический выбор интервала.

В следующем самостоятельном примере создаются 24 категории и один ряд, затем сохраняются три слайда в `CategoryAxisIntervals.pptx`: автоматический интервал, ручной интервал подписей с независимыми делениями и восстановленный автоматический интервал. Обе копии сохраняют исходные данные диаграммы. Исходная презентация не требуется. Горизонтальный текст подписей делает различия в плотности легко заметными.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Слайд 2: показывать каждую третью подпись, но оставлять деление для каждой категории.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Слайд 3: позволить диаграмме снова выбрать оба интервала.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Автоматический интервал (слайд 1):** При таком отображении каждая вторая подпись категории показывается и переносится на две строки. Автоматический результат может варьироваться в зависимости от размера диаграммы, шрифтов и рендерера.

![Автоматический интервал подписей категорий при видимых всех 24 столбцах](category-axis-automatic.png)

**Ручной интервал (слайд 2):** Каждая третья подпись отображается в одну строку, при этом деления остаются на каждом интервале категории. Все 24 столбца, включая те, у которых нет подписей, остаются видимыми с теми же значениями. Слайд 3 восстанавливает автоматический вид, показанный выше.

![Ручной интервал подписей категорий (три) при видимых всех 24 столбцах](category-axis-manual.png)

### **Выбор правильной оси и интервала**

Используйте этот интервал количества категорий для текстовой категориальной оси, например, для оси категорий столбчатой, линейной, областной или гистограммы. В столбчатой диаграмме это горизонтальная ось. В горизонтальной гистограмме категориальная ось вертикальна, поэтому применяйте эти настройки к оси, возвращаемой [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Интервал делений также применим к оси рядов в диаграммах, где она присутствует.

Не используйте интервал подписей категорий для задания числового масштаба значительной оси. На значительной оси [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) задаёт разницу в значениях: например, основной шаг `10` создаёт деления 0, 10, 20 и т.д., когда ось начинается с нуля. Интервал подписи категорий `3` считает позиции категорий независимо от их значений. Диаграммы рассеяния и пузырьковые используют значительные оси, а не текстовую категориальную. Для датированной оси используйте единицы времени, как описано в разделе [Изменить категориальную ось](#изменить-категориальную-ось).

## **Установить формат даты для значений категориальной оси**

В примере заменяются данные диаграммы четырьмя годовыми значениями. Даты хранятся как серийные числа OLE Automation в первом листе (индекс `0`), вычисляемые как количество дней, прошедших с 30 декабря 1899. Расчёт в JavaScript использует UTC‑метки и делит разницу на 86 400 000 миллисекунд в дне. Используйте [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) с `CategoryAxisType.Date`, вызывайте [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) с `false` и передайте `yyyy` в [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/), чтобы подписи категорий отображали четырехзначные годы независимо от форматирования ячеек.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Задать угол поворота заголовка оси диаграммы**

Вызовите [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) с `true` для вертикальной оси, укажите текст заголовка и используйте [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) для поворота заголовка. Угол измеряется в градусах; в этом примере сохраняется столбчатая диаграмма с заголовком оси значений, повернутым на 90 градусов.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить позицию оси на категориальной или значительной оси**

Используйте [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) для управления тем, пересекает ли значительная ось категориальную ось между категориями или на метках категорий. Эта настройка применяется к категориальным осям. В примере она устанавливается в `true` для горизонтальной категориальной оси столбчатой диаграммы и результат сохраняется.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить единицу отображения на значительной оси диаграммы**

Используйте [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) для масштабирования меток значительной оси без изменения исходных данных. При типе [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) `Millions` значение 60 000 000 отображается как 60. В примере создаётся столбчатая диаграмма и к её вертикальной оси применяется единица отображения «миллионы».

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Настроить логарифмическую значительную ось**

Логарифмическая значительная ось полезна, когда положительные значения охватывают несколько порядков масштаба. Например, сервис может получать 10, 100, 1 000, 10 000 и 100 000 запросов за пять периодов. На линейной шкале меньшие значения находятся близко друг к другу около нуля. Логарифмическая шкала делает их относительный рост более читабельным: одинаковые расстояния соответствуют одинаковым отношениям, а не одинаковым разницам.

Вызовите [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) с `true` для значительной оси и используйте [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) для выбора основания. Это меняет только отображение существующих значений; данные и добавление логарифмической линии тренда не изменяются. Линия тренда представляет подгонку зависимости в данных и является отдельной функцией.

### **Выбор значительной оси и основания**

Для линейной или столбчатой диаграммы значительная ось возвращается методом [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Для горизонтальной гистограммы — методом [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Диаграммы рассеяния и пузырьковые имеют две значительные оси, поэтому выбирайте горизонтальную ось для X‑значений, вертикальную — для Y‑значений, либо обе. Не применяйте логарифмическое масштабирование к категориальной оси.

Основание логарифма по умолчанию — `10`. Для PPTX‑диаграмм допускаются основания от `2` до `1000` включительно; также поддерживаются дробные основания, такие как `2.5`. При основании `10` последовательные степени 10, 100, 1 000 и 10 000 равномерно распределены.

### **Сравнение линейного и логарифмического масштабирования**

В следующем самостоятельном примере создаётся линейная диаграмма с пятью подсчётами запросов на первом слайде, затем этот слайд клонируется, и на втором включается логарифмическая значительная ось с основанием 10. Оба слайда сохраняют одинаковые данные.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Сохранить первый слайд линейным и изменить только масштаб оси значений в копии.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Линейная шкала (слайд 1):** Равные вертикальные расстояния соответствуют одинаковым разницам в количестве запросов. Наибольшее значение доминирует, делая меньшие значения трудноразличимыми.

![Линейная линейная диаграмма в PowerPoint, показывающая пять подсчётов запросов на линейной оси значений](value-axis-linear.png)

**Логарифмическая шкала (слайд 2):** Равные вертикальные расстояния соответствуют одинаковым отношениям. Каждый период имеет в десять раз больше запросов, чем предыдущий, поэтому точки образуют прямую восходящую линию на шкале с основанием 10. Метки оси всё равно показывают исходные подсчёты запросов.

![Те же пять подсчётов запросов в PowerPoint на логарифмической оси значений с основанием 10](value-axis-logarithmic.png)

### **Обработка нулевых и отрицательных значений**

Логарифмическая шкала может отображать только строго положительные значения. Проверьте данные перед её включением. Если нулевые или отрицательные значения имеют смысл, оставьте линейную шкалу или показывайте их отдельно. Если исключение этих значений оправдано, объясните причину. Не заменяйте их «тихо» небольшими положительными числами, так как это меняет смысл данных. Любой вручную заданный минимум или максимум для логарифмической оси также должен быть положительным.

## **FAQ**

**Как задать значение, в котором одна ось пересекает другую (пересечение осей)?**

Используйте [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) для выбора поведения пересечения. Чтобы указать числовое значение пересечения, используйте [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Эти настройки позволяют переместить пересечение осей к удобной базовой линии.

**Как позиционировать подписи делений относительно оси?**

Вызовите [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) с использованием [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` или `None`. Чтобы управлять самими делениями, используйте [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) или [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); они независимы от позиции подписей.