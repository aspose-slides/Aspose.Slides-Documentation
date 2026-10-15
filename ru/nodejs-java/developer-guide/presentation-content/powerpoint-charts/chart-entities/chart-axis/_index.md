---
title: "Настройка осей диаграмм в презентациях с помощью JavaScript"
linktitle: "Ось диаграммы"
type: docs
url: /ru/nodejs-java/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настройка оси
- манипулировать осью
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
description: "Узнайте, как использовать JavaScript с Aspose.Slides для Node.js через Java, чтобы настраивать оси диаграмм в презентациях PowerPoint для отчетов и визуализаций."
---
## **Обзор**

В этой статье объясняется, как настраивать оси диаграмм с помощью Aspose.Slides для Node.js через Java. Охватываются рассчитанные значения осей, переключение строк и столбцов диаграммы, видимость осей, интервалы меток категорий и делений, датированные категории и их форматирование, вращение заголовка, позиционирование осей, единицы отображения и логарифмическое масштабирование.

## **Получить максимальные значения на вертикальной оси диаграмм**

Создайте [Презентацию](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и добавьте столбчатую диаграмму с данными по умолчанию. Вызовите [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) перед чтением рассчитанных значений осей, чтобы макет диаграммы был актуален.

Считайте [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) и [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) для пределов оси, а также [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) и [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) для интервалов делений. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) и [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) предоставляют масштаб единиц времени, что актуально для датированных осей. Пример сохраняет эти значения в локальные переменные и сохраняет диаграмму.

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

## **Переставить данные между осями**

Используйте [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) для обмена ролями рядов и категорий в данных диаграммы. Каждая бывшая категория становится рядом, а каждый бывший ряд — категорией. Это меняет способ группировки данных; это не меняет местами горизонтальную и вертикальную оси. В примере используется [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) для привязки данных по умолчанию к `Sheet1!A1:D5`, включая строку заголовка и столбец категорий, перед переключением строк и столбцов. Сохраняется диаграмма с четырьмя рядами и тремя категориями.

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

## **Обратить порядок построения оси**

Используйте [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) для обратного порядка категории или оси значений. Например, горизонтальная гистограмма может отображать этапы проекта сверху вниз в том же порядке, что и лист: Planning, Development, Testing. Обращение оси меняет направление построения; оно не сортирует и не переупорядочивает данные листа. Для сравнения, [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) меняет роли рядов и категорий.

Следующий пример создает горизонтальную гистограмму с тремя этапами и одним рядом. Он сохраняет презентацию из трех слайдов: обычный порядок, обратные категории и обратные значения. Каждая копия использует тот же набор данных, и на каждой копии обращается только одна ось.

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

    // Слайд 2: отображать первую категорию сверху.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Оставить горизонтальную ось значений внизу.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // Слайд 3: обратить только горизонтальную числовую шкалу.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Обращение оси может также переместить перпендикулярную ось на противоположную сторону построения. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) управляет тем, где другая ось пересекает конфигурируемую ось. На слайде 2 вызов с `aspose.slides.CrossesType.Maximum` на обратной оси категории оставляет горизонтальную ось значений внизу. Для указания конкретной точки пересечения используйте [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Проверьте настройки пересечения при смене направления, особенно если у диаграммы уже задана пользовательская точка пересечения. Вызов `setPlotOrderReversed` с `false` восстанавливает обычное направление построения; настройки пересечения независимы.

| Обычный порядок (слайд 1) | Обратные категории (слайд 2) | Обратные значения (слайд 3) |
| --- | --- | --- |
| ![Горизонтальная гистограмма с обычным порядком осей категории и значения](axis-order-normal.png) | ![Горизонтальная гистограмма с категориями, отображаемыми сверху вниз](axis-order-categories-reversed.png) | ![Горизонтальная гистограмма с обратной осью значений и нулем справа](axis-order-values-reversed.png) |
| Категории идут снизу вверх; значения увеличиваются слева направо. | Planning, Development и Testing идут сверху вниз. Значения и порядок строк листа остаются без изменений. | Категории сохраняют обычный порядок; значения увеличиваются справа налево. Ось категории пересекает ноль справа. |

## **Отключить вертикальную ось для линейных диаграмм**

Вызовите [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) с `false` на вертикальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой вертикальной осью.

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

## **Отключить горизонтальную ось для линейных диаграмм**

Вызовите [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) с `false` на горизонтальной оси, чтобы скрыть её. В примере создаётся линейная диаграмма с данными по умолчанию и сохраняется с скрытой горизонтальной осью.

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

## **Изменить ось категории**

Используйте [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) для выбора датированной или текстовой оси категории. Этот пример требует `ExistingChart.pptx`, где диаграмма является первой фигурой на первом слайде, а ячейки категории содержат численные даты Excel. Он меняет горизонтальную ось на датированную. Вызов [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) с `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) с `1` и [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) с `TimeUnitType.Months` размещает основные деления с интервалом в один месяц.

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

## **Управление интервалами меток оси категории**

Когда в диаграмме много категорий, уменьшите количество видимых меток оси, не удаляя категории и точки данных. Вызовите [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) с `false`, затем передайте желаемый интервал категории в [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Для текстовых категорий в их обычном порядке подсчёт начинается с первой категории:

| Интервал | Отображаемые метки в примере |
| --- | --- |
| `1` | Категория 1, Категория 2, Категория 3, ... Категория 24 |
| `2` | Категория 1, Категория 3, Категория 5, ... Категория 23 |
| `3` | Категория 1, Категория 4, Категория 7, ... Категория 22 |

Интервал `3` отображает каждую третью метку, оставляя две скрытыми между отображаемыми. Это не удаляет соответствующие столбцы. Автоматический выбор интервала основывается на доступном пространстве; он не обязателен отображать каждую метку.

Деления имеют отдельные параметры. Вызовите [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) с `false` и используйте [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) для задания их интервала. Например, `1` сохраняет деление на каждом интервале категории, в то время как метки появляются только каждые три категории. Используйте [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) с видимым стилем, чтобы увидеть результат. Повторный вызов любого из автоматических методов с `true` возвращает диаграмме возможность автоматически подобрать интервал.

Следующий автономный пример создаёт 24 категории и один ряд, затем сохраняет три слайда в `CategoryAxisIntervals.pptx`: автоматический интервал, ручной интервал меток при независимых делениях и восстановленный автоматический интервал. Две копии сохраняют исходные данные диаграммы. Входная презентация не требуется. Горизонтальный текст меток делает различие в плотности легко различимым.

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

    // Слайд 2: показывать каждую третью метку, но сохранять деление для каждой категории.
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

**Автоматический интервал (слайд 1):** В этом отображении каждая вторая метка категории показывается и переносится на две строки. Автоматический результат может различаться в зависимости от размера диаграммы, шрифтов и рендерера.

![Автоматический интервал меток категории при отображении всех 24 столбцов](category-axis-automatic.png)

**Ручной интервал (слайд 2):** Каждая третья метка показывается в одну строку, тогда как деления остаются на каждом интервале категории. Все 24 столбца, включая те, у которых нет меток, остаются видимыми с теми же значениями. Слайд 3 восстанавливает автоматический вид, показанный выше.

![Ручной интервал меток категории в три при отображении всех 24 столбцов](category-axis-manual.png)

### **Выберите правильную ось и интервал**

Используйте этот интервал количества категорий для текстовой оси категории, например оси категории столбчатой, линейной, площадной или гистограммы. В столбчатой диаграмме это горизонтальная ось. В горизонтальной гистограмме ось категории вертикальная, поэтому применяйте эти параметры к оси, возвращаемой [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Интервал делений также применяется к оси рядов в диаграммах, где она присутствует.

Не используйте интервалы меток категории для установки числовой шкалы оси значений. На оси значений [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) задаёт разность значений: например, основной шаг `10` создаёт деления 0, 10, 20 и т.д., когда ось начинается с нуля. Интервал меток категории `3` вместо этого считает позиции категорий независимо от их значений. Диаграммы разброса и пузырьковые используют оси значений, а не текстовую ось категории. Для датированной оси используйте временные основные единицы и масштабы, описанные в разделе [Изменить ось категории](#изменить-ось-категории).

## **Установить формат даты для значений оси категории**

Пример заменяет данные диаграммы по умолчанию четырьмя годовыми значениями. Даты хранятся как серийные номера OLE Automation в первом листе (индекс `0`), рассчитываемые как количество дней, прошедших с 30 декабря 1899, для этих дат. Вычисление в JavaScript использует UTC‑метки и делит разницу на 86 400 000 миллисекунд в день. Используйте [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) с `CategoryAxisType.Date`, вызовите [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) с `false` и передайте `yyyy` в [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/), чтобы метки категорий отображали четырёхзначные годы независимо от форматирования ячейки.

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

## **Установить угол вращения заголовка оси диаграммы**

Вызовите [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) с `true` на вертикальной оси, задайте текст заголовка и используйте [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) для его вращения. Угол измеряется в градусах; этот пример сохраняет столбчатую диаграмму с заголовком оси значений, повернутым на 90 градусов.

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

## **Установить позицию оси на оси категории или значений**

Используйте [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) для управления тем, пересекает ли ось значений ось категории между категориями или на делениях категории. Эта настройка применяется к осям категории. Пример устанавливает её в `true` на горизонтальной оси категории столбчатой диаграммы и сохраняет результат.

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

## **Установить единицу отображения на оси значений диаграммы**

Используйте [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) для масштабирования меток оси значений без изменения исходных данных. При типе [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) `Millions` значение 60 000 000 отображается как 60. Пример создаёт столбчатую диаграмму и применяет единицу отображения «миллионы» к её вертикальной оси.

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

## **Настроить логарифмическую ось значений**

Логарифмическая ось значений полезна, когда положительные значения охватывают несколько порядков величины. Например, сервис может получать 10, 100, 1 000, 10 000 и 100 000 запросов за пять периодов. На линейной шкале меньшие значения сосредоточены рядом с нулём. Логарифмическая шкала делает их относительный рост легче сравнивать: одинаковые расстояния представляют одинаковые отношения, а не одинаковые разности.

Вызовите [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) с `true` на оси значений и используйте [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) для выбора основания. Это меняет способ отображения существующих значений; это не меняет данные и не добавляет логарифмическую трендовую линию. Трендовая линия представляет собой подогнанную зависимость в данных и является отдельной функцией.

### **Выберите ось значений и основание**

Для линейной или столбчатой диаграммы ось значений возвращается методом [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Для горизонтальной гистограммы — методом [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Диаграммы разброса и пузырьковые имеют две оси значений, поэтому выбирайте горизонтальную ось для X‑значений, вертикальную для Y‑значений или обе. Не применяйте логарифмическое масштабирование к оси категории.

Основание логарифма по умолчанию — `10`. Для PPTX‑диаграмм допускается основание от `2` до `1000` включительно; также поддерживаются дробные основания, такие как `2.5`. При основании `10` последовательные степени — 10, 100, 1 000 и 10 000 — расположены равномерно.

### **Сравнение линейного и логарифмического масштабирования**

Следующий автономный пример создаёт линейную диаграмму с пятью количествами запросов на первом слайде, затем клонирует этот слайд и включает логарифмическую ось значений с основанием 10 на втором. Оба слайда сохраняют одинаковые данные.

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

    // Сохранить первый слайд линейным и изменить только масштаб оси значений у копии.
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

**Линейная шкала (слайд 1):** Равные вертикальные расстояния представляют равные разности количества запросов. Наибольшее значение доминирует в диаграмме, делая меньшие трудно различимыми.

![Линейная диаграмма в PowerPoint, показывающая пять количеств запросов на линейной оси значений](value-axis-linear.png)

**Логарифмическая шкала (слайд 2):** Равные вертикальные расстояния представляют равные отношения. Каждый период имеет в десять раз больше запросов, чем предыдущий, поэтому точки образуют прямую восходящую линию на шкале с основанием 10. Метки оси всё ещё показывают исходные количества запросов.

![Те же пять количеств запросов в PowerPoint на логарифмической оси значений с основанием 10](value-axis-logarithmic.png)

### **Обработка нулевых и отрицательных значений**

Логарифмическая шкала может отображать только строго положительные значения. Проверьте данные перед её включением. Если нулевые или отрицательные значения имеют смысл, оставьте линейную шкалу или отображайте их отдельно. Если исключение этих значений уместно для анализа, объясните причину. Не заменяйте их без предупреждения небольшими положительными числами, так как это меняет смысл данных. Любой вручную заданный минимум или максимум для логарифмической оси также должен быть положительным.

## **Часто задаваемые вопросы**

**Как задать значение, где одна ось пересекает другую (пересечение осей)?**

Используйте [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) для выбора поведения пересечения. Чтобы указать числовое значение пересечения, используйте [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Эти настройки позволяют переместить точку пересечения оси на подходящую базовую линию.

**Как позиционировать метки делений относительно оси?**

Вызовите [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) с использованием [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` или `None`. Чтобы управлять сами делениями, используйте [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) или [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); они независимы от позиционирования меток.